using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form23 : Form
    {
        private readonly int _id = 0;
        public Form23()
        {
            InitializeComponent();
            var context = new VisualPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            _id = user[count - 1].Id;
            WriteTable1(_id);
        }

        public Form23(int id)
        {
            InitializeComponent();
            _id = id;
            WriteTable1(_id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form7();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void DeleteTextBox()
        {
            for (var i = this.Controls.Count - 1; i >= 0; i--)
            {
                var c = this.Controls[i];
                if (c is TextBox)
                {
                    this.Controls.Remove(c);
                }
            }
        }

        private void CreateTextBox(int name, int x, int y, int width, int height, string text, HorizontalAlignment textAlign)
        {
            this.Controls.Add(new TextBox()
            {
                Name = "textBox" + name,
                Location = new Point(x, y),
                BackColor = SystemColors.ButtonHighlight,
                Multiline = true,
                Text = text,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = textAlign,
                ReadOnly = true,
                Width = width,
                Height = height
            });
        }

        private void CreateTable1(int presenting)
        {
            CreateTextBox(1, 8, 184, 210, 20, "Номер стимула", HorizontalAlignment.Left);
            CreateTextBox(2, 8, 204, 210, 20, "Количество воспринятых слов", HorizontalAlignment.Left);
            CreateTextBox(3, 8, 224, 210, 20, "Среднее количество воспринятых слов", HorizontalAlignment.Left);

            const int firstLineTextBoxNumber = 4;
            var firstLineTextBoxLastNumber = firstLineTextBoxNumber + presenting;
            var xFirst = 218;
            var increase = 500 / presenting;

            for (var i = firstLineTextBoxNumber; i < firstLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 184, increase, 20, (i - 3).ToString(), HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var secondLineTextBoxNumber = firstLineTextBoxLastNumber;
            var secondLineTextBoxLastNumber = secondLineTextBoxNumber + presenting;

            for (var i = secondLineTextBoxNumber; i < secondLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 204, increase, 20, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            CreateTextBox(secondLineTextBoxLastNumber, xFirst, 224, 500, 20, "", HorizontalAlignment.Center);
        }

        private void WriteTable1(int id)
        {
            DeleteTextBox();

            var context = new VisualPerceptionContext();
            var presenting = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            CreateTable1(presenting);

            var experimentResult = context.Experiment1Result.Where(x => x.IdUser == id).ToList();

            var row = 0;
            foreach (var result in experimentResult)
            {
                var String = "";
                var provided = result.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                var reproduced = result.ReproducedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var i in reproduced)
                {
                    if (!provided.Contains(i))
                    {
                        String += i + ",";
                    }
                }

                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay.ToString();

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                providedIncentive.Value = result.ProvidedIncentive.ToLower();

                var reproducedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                reproducedIncentive.Value = result.ReproducedIncentive.ToLower();

                var _id = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[3];
                _id.Value = result.Id;

                var mistake = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[4];
                mistake.Value = String.ToLower();


                row++;
            }

            var numberSum = experimentResult.Sum(experiment1Result => experiment1Result.NumberReproducedOfIncentive);

            var iValue = 4 + presenting;
            var upperValue = iValue + presenting;

            for (var i = iValue; i < upperValue; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - presenting - 3)).NumberReproducedOfIncentive.ToString();
            }

            var divider = presenting + ",0";
            var average = numberSum / double.Parse(divider);
            this.Controls["textBox" + upperValue].Text = average.ToString();
        }

        private void CreateTable2(int presenting)
        {
            CreateTextBox(1, 8, 184, 210, 20, "Номер стимула", HorizontalAlignment.Left);
            CreateTextBox(2, 8, 204, 210, 20, "Количество воспринятых слов", HorizontalAlignment.Left);
            CreateTextBox(3, 8, 224, 210, 30, "Количество групп, в которые входят воспринятые слова", HorizontalAlignment.Left);
            CreateTextBox(4, 8, 254, 210, 30, "Относительное распределение слов по группам", HorizontalAlignment.Left);
            CreateTextBox(5, 8, 284, 210, 30, "Среднее относительное распределение слов по группам", HorizontalAlignment.Left);

            const int firstLineTextBoxNumber = 6;
            var firstLineTextBoxLastNumber = firstLineTextBoxNumber + presenting;
            var xFirst = 218;
            var increase = 500 / presenting;

            for (var i = firstLineTextBoxNumber; i < firstLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 184, increase, 20, (i - 5).ToString(), HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var secondLineTextBoxNumber = firstLineTextBoxLastNumber;
            var secondLineTextBoxLastNumber = secondLineTextBoxNumber + presenting;

            for (var i = secondLineTextBoxNumber; i < secondLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 204, increase, 20, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var thirdLineTextBoxNumber = secondLineTextBoxLastNumber;
            var thirdLineTextBoxLastNumber = thirdLineTextBoxNumber + presenting;

            for (var i = thirdLineTextBoxNumber; i < thirdLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 224, increase, 30, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var fourthLineTextBoxNumber = thirdLineTextBoxLastNumber;
            var fourthLineTextBoxLastNumber = fourthLineTextBoxNumber + presenting;

            for (var i = fourthLineTextBoxNumber; i < fourthLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 254, increase, 30, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            CreateTextBox(fourthLineTextBoxLastNumber, xFirst, 284, 500, 30, "", HorizontalAlignment.Center);
        }

        private void WriteTable2(int id)
        {
            DeleteTextBox();

            var context = new VisualPerceptionContext();
            var presenting = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            CreateTable2(presenting);

            var experimentResult = context.Experiment2Result.Where(x => x.IdUser == id).ToList();

            var row = 0;
            foreach (var result in experimentResult)
            {
                var String = "";
                var provided = result.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                var reproduced = result.ReproducedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var i in reproduced)
                {
                    if (!provided.Contains(i))
                    {
                        String += i + ",";
                    }
                }

                dataGridView2.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay.ToString();

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[1];
                providedIncentive.Value = result.ProvidedIncentive.ToString().ToLower();

                var reproducedIncentive = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[2];
                reproducedIncentive.Value = result.ReproducedIncentive.ToString().ToLower();

                var _id = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[3];
                _id.Value = result.Id;

                var mistake = (DataGridViewTextBoxCell)dataGridView2.Rows[row].Cells[4];
                mistake.Value = String.ToLower();

                row++;
            }
            var numberSum = experimentResult.Sum(experiment1Result => experiment1Result.RelativeDistributionWord);

            var iValue = 6 + presenting;
            var upperValue1 = iValue + presenting;

            for (var i = iValue; i < upperValue1; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - presenting - 5)).NumberReproducedOfIncentive.ToString();
            }

            var upperValue2 = upperValue1 + presenting;

            for (var i = upperValue1; i < upperValue2; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 2) - 5)).NumberGroupsWithWord.ToString();
            }

            var upperValue3 = upperValue2 + presenting;

            for (var i = upperValue2; i < upperValue3; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 3) - 5)).RelativeDistributionWord.ToString("##.#");
            }

            var divider = presenting + ",0";
            var average = numberSum / double.Parse(divider);
            this.Controls["textBox" + upperValue3].Text = average.ToString("##.#");
        }

        private void CreateTable3(int presenting)
        {
            CreateTextBox(1, 8, 184, 210, 20, "Номер стимула", HorizontalAlignment.Left);
            CreateTextBox(2, 8, 204, 210, 20, "Количество воспринятых слов", HorizontalAlignment.Left);
            CreateTextBox(3, 8, 224, 210, 30, "Из них, обладающих отличительным признаком (%)", HorizontalAlignment.Left);
            CreateTextBox(4, 8, 254, 210, 30, "Среднее количество воспринятых слов, обладаю-щих отличительным признаком (%)", HorizontalAlignment.Left);

            const int firstLineTextBoxNumber = 5;
            var firstLineTextBoxLastNumber = firstLineTextBoxNumber + presenting;
            var xFirst = 218;
            var increase = 500 / presenting;

            for (var i = firstLineTextBoxNumber; i < firstLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 184, increase, 20, (i - 4).ToString(), HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var secondLineTextBoxNumber = firstLineTextBoxLastNumber;
            var secondLineTextBoxLastNumber = secondLineTextBoxNumber + presenting;

            for (var i = secondLineTextBoxNumber; i < secondLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 204, increase, 20, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var thirdLineTextBoxNumber = secondLineTextBoxLastNumber;
            var thirdLineTextBoxLastNumber = thirdLineTextBoxNumber + presenting;

            for (var i = thirdLineTextBoxNumber; i < thirdLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 224, increase, 30, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            CreateTextBox(thirdLineTextBoxLastNumber, xFirst, 254, 500, 30, "", HorizontalAlignment.Center);
        }

        private void WriteTable3(int id)
        {
            DeleteTextBox();
            var context = new VisualPerceptionContext();
            var presenting = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            CreateTable3(presenting);

            var experimentResult = context.Experiment3Result.Where(x => x.IdUser == id).ToList();

            var row = 0;
            foreach (var result in experimentResult)
            {
                var String = "";
                var provided = result.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                var reproduced = result.ReproducedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var i in reproduced)
                {
                    if (!provided.Contains(i))
                    {
                        String += i + ",";
                    }
                }

                dataGridView3.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView3.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay.ToString();

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView3.Rows[row].Cells[1];
                providedIncentive.Value = result.ProvidedIncentive.ToString().ToLower();

                var reproducedIncentive = (DataGridViewTextBoxCell)dataGridView3.Rows[row].Cells[2];
                reproducedIncentive.Value = result.ReproducedIncentive.ToString().ToLower();

                var _id = (DataGridViewTextBoxCell)dataGridView3.Rows[row].Cells[3];
                _id.Value = result.Id;

                var mistake = (DataGridViewTextBoxCell)dataGridView3.Rows[row].Cells[4];
                mistake.Value = String.ToLower();

                row++;
            }
            var numberSum = experimentResult.Sum(experiment1Result => experiment1Result.PossessesHallmark);

            var iValue = 5 + presenting;
            var upperValue1 = iValue + presenting;

            for (var i = iValue; i < upperValue1; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - presenting - 4)).NumberReproducedOfIncentive.ToString();
            }

            var upperValue2 = upperValue1 + presenting;

            for (var i = upperValue1; i < upperValue2; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 2) - 4)).PossessesHallmark.ToString("##.0");
            }

            var divider = presenting + ",0";
            var average = numberSum / double.Parse(divider);
            this.Controls["textBox" + upperValue2].Text = average.ToString("##.0");
        }

        private void CreateTable4(int presenting)
        {
            CreateTextBox(1, 8, 184, 210, 20, "Номер стимула", HorizontalAlignment.Left);
            CreateTextBox(2, 8, 204, 210, 20, "Количество воспринятых слов", HorizontalAlignment.Left);
            CreateTextBox(3, 8, 224, 210, 30, "Из них, обладающих отличительным признаком (%)", HorizontalAlignment.Left);
            CreateTextBox(4, 8, 254, 210, 30, "Среднее количество воспринятых слов, обладаю-щих отличительным признаком (%)", HorizontalAlignment.Left);

            const int firstLineTextBoxNumber = 5;
            var firstLineTextBoxLastNumber = firstLineTextBoxNumber + presenting;
            var xFirst = 218;
            var increase = 500 / presenting;

            for (var i = firstLineTextBoxNumber; i < firstLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 184, increase, 20, (i - 4).ToString(), HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var secondLineTextBoxNumber = firstLineTextBoxLastNumber;
            var secondLineTextBoxLastNumber = secondLineTextBoxNumber + presenting;

            for (var i = secondLineTextBoxNumber; i < secondLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 204, increase, 20, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var thirdLineTextBoxNumber = secondLineTextBoxLastNumber;
            var thirdLineTextBoxLastNumber = thirdLineTextBoxNumber + presenting;

            for (var i = thirdLineTextBoxNumber; i < thirdLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 224, increase, 30, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            CreateTextBox(thirdLineTextBoxLastNumber, xFirst, 254, 500, 30, "", HorizontalAlignment.Center);
        }

        private void WriteTable4(int id)
        {
            DeleteTextBox();
            var context = new VisualPerceptionContext();
            var presenting = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            CreateTable4(presenting);

            var experimentResult = context.Experiment4Result.Where(x => x.IdUser == id).ToList();

            var row = 0;
            foreach (var result in experimentResult)
            {
                var String = "";
                var provided = result.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                var reproduced = result.ReproducedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var i in reproduced)
                {
                    if (!provided.Contains(i))
                    {
                        String += i + ",";
                    }
                }

                dataGridView4.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView4.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay.ToString();

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView4.Rows[row].Cells[1];
                providedIncentive.Value = result.ProvidedIncentive.ToString().ToLower();

                var reproducedIncentive = (DataGridViewTextBoxCell)dataGridView4.Rows[row].Cells[2];
                reproducedIncentive.Value = result.ReproducedIncentive.ToString().ToLower();

                var _id = (DataGridViewTextBoxCell)dataGridView4.Rows[row].Cells[3];
                _id.Value = result.Id;

                var mistake = (DataGridViewTextBoxCell)dataGridView4.Rows[row].Cells[4];
                mistake.Value = String.ToLower();

                row++;
            }
            var numberSum = experimentResult.Sum(experiment1Result => experiment1Result.PossessesHallmark);

            var iValue = 5 + presenting;
            var upperValue1 = iValue + presenting;

            for (var i = iValue; i < upperValue1; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - presenting - 4)).NumberReproducedOfIncentive.ToString();
            }

            var upperValue2 = upperValue1 + presenting;

            for (var i = upperValue1; i < upperValue2; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 2) - 4)).PossessesHallmark.ToString("##.0");
            }

            var divider = presenting + ",0";
            var average = numberSum / double.Parse(divider);
            this.Controls["textBox" + upperValue2].Text = average.ToString("##.0");
        }

        private void CreateTable5(int presenting)
        {
            CreateTextBox(1, 8, 184, 210, 20, "Номер стимула", HorizontalAlignment.Left);
            CreateTextBox(2, 8, 204, 210, 20, "Количество воспринятых слов", HorizontalAlignment.Left);
            CreateTextBox(3, 8, 224, 210, 30, "Количество групп, в которые входят воспринятые слова", HorizontalAlignment.Left);
            CreateTextBox(4, 8, 254, 210, 30, "Относительное распределение слов по группам", HorizontalAlignment.Left);
            CreateTextBox(5, 8, 284, 210, 30, "Среднее относительное распределение слов по группам", HorizontalAlignment.Left);
            CreateTextBox(6, 8, 314, 210, 30, "Количество групп со словами, имеющими отличительный признак", HorizontalAlignment.Left);
            CreateTextBox(7, 8, 344, 210, 30, "Среднее количество групп со словами, имеющими отличительный признак", HorizontalAlignment.Left);

            const int firstLineTextBoxNumber = 8;
            var firstLineTextBoxLastNumber = firstLineTextBoxNumber + presenting;
            var xFirst = 218;
            var increase = 500 / presenting;

            for (var i = firstLineTextBoxNumber; i < firstLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 184, increase, 20, (i - 7).ToString(), HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var secondLineTextBoxNumber = firstLineTextBoxLastNumber;
            var secondLineTextBoxLastNumber = secondLineTextBoxNumber + presenting;

            for (var i = secondLineTextBoxNumber; i < secondLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 204, increase, 20, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var thirdLineTextBoxNumber = secondLineTextBoxLastNumber;
            var thirdLineTextBoxLastNumber = thirdLineTextBoxNumber + presenting;

            for (var i = thirdLineTextBoxNumber; i < thirdLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 224, increase, 30, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            var fourthLineTextBoxNumber = thirdLineTextBoxLastNumber;
            var fourthLineTextBoxLastNumber = fourthLineTextBoxNumber + presenting;

            for (var i = fourthLineTextBoxNumber; i < fourthLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 254, increase, 30, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            CreateTextBox(fourthLineTextBoxLastNumber, xFirst, 284, 500, 30, "", HorizontalAlignment.Center);

            xFirst = 218;
            var fifthLineTextBoxNumber = fourthLineTextBoxLastNumber + 1;
            var fifthLineTextBoxLastNumber = fifthLineTextBoxNumber + presenting;

            for (var i = fifthLineTextBoxNumber; i < fifthLineTextBoxLastNumber; i++)
            {
                CreateTextBox(i, xFirst, 314, increase, 30, "", HorizontalAlignment.Center);
                xFirst += increase;
            }

            xFirst = 218;
            CreateTextBox(fifthLineTextBoxLastNumber, xFirst, 344, 500, 30, "", HorizontalAlignment.Center);
        }

        private void WriteTable5(int id)
        {
            DeleteTextBox();
            var context = new VisualPerceptionContext();
            var presenting = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            CreateTable5(presenting);

            var experimentResult = context.Experiment5Result.Where(x => x.IdUser == id).ToList();

            var row = 0;
            foreach (var result in experimentResult)
            {
                var String = "";
                var provided = result.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                var reproduced = result.ReproducedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var i in reproduced)
                {
                    if (!provided.Contains(i))
                    {
                        String += i + ",";
                    }
                }

                dataGridView5.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView5.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay.ToString();

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView5.Rows[row].Cells[1];
                providedIncentive.Value = result.ProvidedIncentive.ToString().ToLower();

                var reproducedIncentive = (DataGridViewTextBoxCell)dataGridView5.Rows[row].Cells[2];
                reproducedIncentive.Value = result.ReproducedIncentive.ToString().ToLower();

                var _id = (DataGridViewTextBoxCell)dataGridView5.Rows[row].Cells[3];
                _id.Value = result.Id;

                var mistake = (DataGridViewTextBoxCell)dataGridView5.Rows[row].Cells[4];
                mistake.Value = String.ToLower();

                row++;
            }

            var numberSum = 0.0;
            var numberSumHallmark = 0;

            foreach (var experiment1Result in experimentResult)
            {
                numberSum += experiment1Result.RelativeDistributionWord;
                numberSumHallmark += experiment1Result.NumberGroupsHallmark;
            }

            var iValue = 8 + presenting;
            var upperValue1 = iValue + presenting;

            for (var i = iValue; i < upperValue1; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - presenting - 7)).NumberReproducedOfIncentive.ToString();
            }

            var upperValue2 = upperValue1 + presenting;

            for (var i = upperValue1; i < upperValue2; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 2) - 7)).NumberGroupsWithWord.ToString();
            }

            var upperValue3 = upperValue2 + presenting;

            for (var i = upperValue2; i < upperValue3; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 3) - 7)).RelativeDistributionWord.ToString("##.0");
            }

            var divider = presenting + ",0";
            var average = numberSum / double.Parse(divider);
            this.Controls["textBox" + upperValue3].Text = average.ToString("##.0");

            var upperValue4 = upperValue3 + 1 + presenting;

            for (var i = upperValue3 + 1; i < upperValue4; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 4) - 8)).NumberGroupsHallmark.ToString();
            }

            var divider1 = presenting + ",0";
            var average1 = numberSumHallmark / double.Parse(divider1);
            this.Controls["textBox" + upperValue4].Text = average1.ToString("##.0");
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0: WriteTable1(_id);
                    break;

                case 1: WriteTable2(_id);
                    break;

                case 2: WriteTable3(_id);
                    break;

                case 3: WriteTable4(_id);
                    break;

                case 4: WriteTable5(_id);
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView5.CurrentRow.Cells[3].Value.ToString());

            var nForm = new Form28(id);
            nForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            var nForm = new Form24(id);
            nForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());

            var nForm = new Form25(id);
            nForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView3.CurrentRow.Cells[3].Value.ToString());

            var nForm = new Form26(id);
            nForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView4.CurrentRow.Cells[3].Value.ToString());

            var nForm = new Form27(id);
            nForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new VisualPerceptionContext();
            var user = context.User.FirstOrDefault(x => x.Id == _id);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FileName = user.Name + " результаты опытов";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            var result = new StringBuilder();

            var name ="Имя испытуемого: " + user.Name + "\n";
            var group = "Номер группы: " + user.GroupNumber + "\nРезультаты опытов\n";

            result.Append(name);
            result.Append(group);
            result.Append(ExperimentResult1());
            result.Append(ExperimentResult2());
            result.Append(ExperimentResult3());
            result.Append(ExperimentResult4());
            result.Append(ExperimentResult5());
            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, result.ToString());
            }
        }

        private string ExperimentResult1()
        {
            var context = new VisualPerceptionContext();
            var user = context.User.FirstOrDefault(x => x.Id == _id);

            var result = new StringBuilder();

            var numberExperiment = "Опыт №1\n\n";
            var experimentResult = context.Experiment1Result.Where(x => x.IdUser == _id).ToList();

            var header = string.Format("{0}|{1}", "Номер стимула", "Количество воспринятых слов\n");
            var line1 = "------------------------------------------\n";
            result.Append(numberExperiment);

            foreach (var i in experimentResult)
            {
                var rez = string.Format("Предъявленный ряд №{0}: {1}\nВоспринятый ряд: {2}\n", i.NumberDisplay,
                    i.ProvidedIncentive, i.ReproducedIncentive);
                result.Append(rez);
            }
            result.Append("\n\n");
            result.Append(header);
            result.Append(line1);

            foreach (var i in experimentResult)
            {
                var line2 = string.Format("     {0}       |             {1}\n",
                    i.NumberDisplay,
                    i.NumberReproducedOfIncentive);
                result.Append(line2);
                result.Append(line1);
            }

            return result.ToString();
        }

        private string ExperimentResult2()
        {
            var context = new VisualPerceptionContext();

            var result = new StringBuilder();

            var numberExperiment = "Опыт №2\n\n";
            var experimentResult = context.Experiment2Result.Where(x => x.IdUser == _id).ToList();

            var header = string.Format("{0}|{1}|{2}|{3}", 
                "Номер стимула", 
                "Количество воспринятых слов", 
                "Количество групп, в которые входят воспринятые слова", 
                "Относительное распределение слов по группам\n");
            var line1 = "-------------------------------------------------------------------------------------------------------------------------------------------\n";
            result.Append(numberExperiment);

            foreach (var i in experimentResult)
            {
                var rez = string.Format("Предъявленный ряд №{0}: {1}\nВоспринятый ряд: {2}\n", i.NumberDisplay,
                    i.ProvidedIncentive, i.ReproducedIncentive);
                result.Append(rez);
            }
            result.Append("\n\n");
            result.Append(header);
            result.Append(line1);

            foreach (var i in experimentResult)
            {
                var line2 = string.Format("     {0}       |             {1}             |                         {2}                          |                    {3}\n",
                    i.NumberDisplay,
                    i.NumberReproducedOfIncentive,
                    i.NumberGroupsWithWord,
                    i.RelativeDistributionWord);
                result.Append(line2);
                result.Append(line1);
            }

            return result.ToString();
        }

        private string ExperimentResult3()
        {
            var context = new VisualPerceptionContext();

            var result = new StringBuilder();

            var numberExperiment = "Опыт №3\n\n";
            var experimentResult = context.Experiment3Result.Where(x => x.IdUser == _id).ToList();

            var header = string.Format("{0}|{1}|{2}",
                "Номер стимула",
                "Количество воспринятых слов",
                "Из них, обладающих отличительным признаком\n");
            var line1 = "-------------------------------------------------------------------------------------\n";
            result.Append(numberExperiment);

            foreach (var i in experimentResult)
            {
                var reproduced = i.Hallmark.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
                var words = i.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
                var list = "";
                for (var j = 0; j < reproduced.Count; j++)
                {
                    list += words[int.Parse(reproduced[j]) - 1] + ",";
                }


                var rez = string.Format("Предъявленный ряд №{0}: {1}\nВоспринятый ряд: {2}\nСлова с отличительным признаком: {3}\n", i.NumberDisplay,
                    i.ProvidedIncentive, i.ReproducedIncentive,list);
                result.Append(rez);
            }
            result.Append("\n\n");
            result.Append(header);
            result.Append(line1);

            foreach (var i in experimentResult)
            {
                var line2 = string.Format("     {0}       |             {1}             |                    {2}\n",
                    i.NumberDisplay,
                    i.NumberReproducedOfIncentive,
                    i.PossessesHallmark);
                result.Append(line2);
                result.Append(line1);
            }

            return result.ToString();
        }

        private string ExperimentResult4()
        {
            var context = new VisualPerceptionContext();

            var result = new StringBuilder();

            var numberExperiment = "Опыт №4\n\n";
            var experimentResult = context.Experiment4Result.Where(x => x.IdUser == _id).ToList();

            var header = string.Format("{0}|{1}|{2}",
                "Номер стимула",
                "Количество воспринятых слов",
                "Из них, обладающих отличительным признаком\n");
            var line1 = "-------------------------------------------------------------------------------------\n";
            result.Append(numberExperiment);

            foreach (var i in experimentResult)
            {
                var reproduced = i.Hallmark.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
                var words = i.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
                var list = "";
                for (var j = 0; j < reproduced.Count; j++)
                {
                    list += words[int.Parse(reproduced[j]) - 1] + ",";
                }


                var rez = string.Format("Предъявленный ряд №{0}: {1}\nВоспринятый ряд: {2}\nСлова с отличительным признаком: {3}\n", i.NumberDisplay,
                    i.ProvidedIncentive, i.ReproducedIncentive, list);
                result.Append(rez);
            }
            result.Append("\n\n");
            result.Append(header);
            result.Append(line1);

            foreach (var i in experimentResult)
            {
                var line2 = string.Format("     {0}       |             {1}             |                    {2}\n",
                    i.NumberDisplay,
                    i.NumberReproducedOfIncentive,
                    i.PossessesHallmark);
                result.Append(line2);
                result.Append(line1);
            }

            return result.ToString();
        }

        private string ExperimentResult5()
        {
            var context = new VisualPerceptionContext();

            var result = new StringBuilder();

            var numberExperiment = "Опыт 5\n\n";
            var experimentResult = context.Experiment5Result.Where(x => x.IdUser == _id).ToList();

            var header = string.Format("{0}|{1}|{2}|{3}|{4}",
                "Номер стимула",
                "Количество воспринятых слов",
                "Количество групп, в которые входят воспринятые слова",
                "Относительное распределение слов по группам",
                "Количество групп со словами, имеющими отличительный признак\n");
            var line1 = "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n";
            result.Append(numberExperiment);

            foreach (var i in experimentResult)
            {
                var reproduced = i.Hallmark.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
                var words = i.ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();
                var list = "";
                for (var j = 0; j < reproduced.Count; j++)
                {
                    list += words[int.Parse(reproduced[j]) - 1] + ",";
                }


                var rez = string.Format("Предъявленный ряд №{0}: {1}\nВоспринятый ряд: {2}\nСлова с отличительным признаком: {3}\n", i.NumberDisplay,
                    i.ProvidedIncentive, i.ReproducedIncentive, list);
                result.Append(rez);
            }
            result.Append("\n\n");
            result.Append(header);
            result.Append(line1);

            foreach (var i in experimentResult)
            {
                var line2 = string.Format("     {0}       |             {1}             |                         {2}                          |                     {3}                  |                             {4}\n",
                    i.NumberDisplay,
                    i.NumberReproducedOfIncentive,
                    i.NumberGroupsWithWord,
                    i.RelativeDistributionWord.ToString("##.#0"),
                    i.NumberGroupsHallmark);
                result.Append(line2);
                result.Append(line1);
            }

            return result.ToString();
        }
    }
}

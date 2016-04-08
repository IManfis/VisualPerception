using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form28 : Form
    {
        public Form28()
        {
            var context = new VisualPerceptionContext();
            var presenting = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            CreateTable(presenting);

            InitializeComponent();

            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            var experimentResult = context.Experiment5Result.Where(x => x.IdUser == id).ToList();

            var row = 0;
            foreach (var result in experimentResult)
            {
                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = result.NumberDisplay.ToString();

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                providedIncentive.Value = result.ProvidedIncentive.ToString().ToLower();

                var reproducedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                reproducedIncentive.Value = result.ReproducedIncentive.ToString().ToLower();

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
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 3) - 7)).RelativeDistributionWord.ToString("##.00");
            }

            var divider = presenting + ",0";
            var average = numberSum / double.Parse(divider);
            this.Controls["textBox" + upperValue3].Text = average.ToString("##.00");

            var upperValue4 = upperValue3 + 1 + presenting;

            for (var i = upperValue3 + 1; i < upperValue4; i++)
            {
                this.Controls["textBox" + i].Text = experimentResult.First(x => x.NumberDisplay == (i - (presenting * 4) - 8)).NumberGroupsHallmark.ToString();
            }

            var divider1 = presenting + ",0";
            var average1 = numberSumHallmark / double.Parse(divider1);
            this.Controls["textBox" + upperValue4].Text = average1.ToString("##.00");
        }

        private void CreateTable(int presenting)
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

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form23();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form24 : Form
    {
        public Form24()
        {
            var context = new VisualPerceptionContext();
            var presenting = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            CreateTable(presenting);
            InitializeComponent();

            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            var experimentResult = context.Experiment1Result.Where(x => x.IdUser == id).ToList();

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

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form23();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void CreateTextBox(int name, int x, int y, int width, int height, string text, HorizontalAlignment textAlign)
        {
            this.Controls.Add(new TextBox()
            {
                Name = "textBox" + name,
                Location = new Point(x, y),
                BackColor = SystemColors.ButtonHighlight,
                Text = text,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = textAlign,
                ReadOnly = true,
                Width = width,
                Height = height
            });
        }

        private void CreateTable(int presenting)
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
    }
}

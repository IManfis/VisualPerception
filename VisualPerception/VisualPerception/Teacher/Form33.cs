using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Teacher
{
    public partial class Form33 : Form
    {
        public Form33()
        {
            InitializeComponent();
            WriteInformation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form29();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var number = 0;
            if (radioButton1.Checked)
            {
                number = 8;
            }
            if (radioButton2.Checked)
            {
                number = 12;
            }
            if (radioButton3.Checked)
            {
                number = 16;
            }
            var context = new VisualPerceptionContext();
            var model = new ExperimentSetting { Id = 2, Name = "Слов", Value = number.ToString() };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            WriteInformation();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            var number = int.Parse(textBox1.Text);
            if (number < 5 || number > 20)
            {
                label1.Visible = true;
                textBox1.Text = "";
            }
            else
            {
                var context = new VisualPerceptionContext();
                var model = new ExperimentSetting { Id = 1, Name = "Предъявлений", Value = number.ToString() };

                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();

                WriteInformation();
                textBox1.Text = "";
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58 ) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double number;
            label7.Visible = false;
            label15.Visible = false;

            if (double.TryParse(textBox3.Text, out number))
            {
                if (number >= 2.0 && number <= 5.0)
                {
                    var context = new VisualPerceptionContext();
                    var model = new ExperimentSetting { Id = 3, Name = "Время", Value = number.ToString("#.#") };

                    context.Entry(model).State = EntityState.Modified;
                    context.SaveChanges();

                    WriteInformation();
                }
                else
                {
                    label7.Visible = true;
                    label7.Text = "Время должно быть от 2 до 5 сек.";
                    textBox1.Text = "";
                }
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Введено неверное время.";
                label15.Visible = true;
                label15.Text = "Пример: 1,2";
                textBox1.Text = "";
            }
        }

        private void WriteInformation()
        {
            var context = new VisualPerceptionContext();
            label12.Text = context.ExperimentSetting.First(x => x.Name == "Слов").Value;
            label13.Text = context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value;
            label14.Text = context.ExperimentSetting.First(x => x.Name == "Время").Value + " c.";
        }
    }
}

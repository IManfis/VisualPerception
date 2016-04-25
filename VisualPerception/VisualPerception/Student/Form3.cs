using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form5();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form2();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            var Name = textBox1.Text;
            var GroupNumber = int.Parse(textBox2.Text);

            var context = new VisualPerceptionContext();
            var user = context.User.ToList();
            var number = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);

            if (user.Any(x => x.Name == Name &&
                user.Any(m => m.GroupNumber == GroupNumber)))
            {
                var id = user.First(x => x.Name == Name).Id;

                if (context.Experiment1Result.Count(x => x.IdUser == id) == number &&
                    context.Experiment2Result.Count(x => x.IdUser == id) == number &&
                    context.Experiment3Result.Count(x => x.IdUser == id) == number &&
                    context.Experiment4Result.Count(x => x.IdUser == id) == number &&
                    context.Experiment5Result.Count(x => x.IdUser == id) == number)
                {
                    label5.Visible = true;
                }
                else
                {
                    var result = MessageBox.Show("У Вас есть незавершенные опыты, хотите продолжить?", "Незавершенные опыты", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        var nForm = new Form34(id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                context.User.Add(new User { Name = Name, GroupNumber = GroupNumber });
                context.SaveChanges();

                label4.Visible = true;
                button3.Visible = true;   
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label6.Visible = false;
            var l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
                label6.Visible = true;
            }
        }
    }
}

using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            var context = new VisualPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            var number = int.Parse(context.ExperimentSetting.FirstOrDefault(x => x.Name == "Предъявлений").Value);
            if (context.Experiment1Result.Count(x => x.IdUser == id) == number &&
                context.Experiment2Result.Count(x => x.IdUser == id) == number &&
                context.Experiment3Result.Count(x => x.IdUser == id) == number &&
                context.Experiment4Result.Count(x => x.IdUser == id) == number &&
                context.Experiment5Result.Count(x => x.IdUser == id) == number)
            {
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                comboBox1.Visible = false;

                label3.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form5();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new VisualPerceptionContext();
            var item = comboBox1.SelectedItem.ToString();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;

            switch (item)
            {
                case "Опыт 1":
                    if (!context.Experiment1Result.Any())
                    {
                        var nForm = new Form8();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }

                    if (!context.Experiment1Result.Any(x => x.IdUser == id))
                    {
                        var nForm = new Form8();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    }
                    break;
                case "Опыт 2":
                    if (!context.Experiment2Result.Any())
                    {
                        var nForm = new Form11();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }

                    if (!context.Experiment2Result.Any(x => x.IdUser == id))
                    {
                        var nForm = new Form11();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    }break;
                case "Опыт 3":
                    if (!context.Experiment3Result.Any())
                    {
                        var nForm = new Form14();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }

                    if (!context.Experiment3Result.Any(x => x.IdUser == id))
                    {
                        var nForm = new Form14();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    } break;
                case "Опыт 4":
                    if (!context.Experiment4Result.Any())
                    {
                        var nForm = new Form17();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }

                    if (!context.Experiment4Result.Any(x => x.IdUser == id))
                    {
                        var nForm = new Form17();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    } break;
                case "Опыт 5": 
                    if (!context.Experiment5Result.Any())
                    {
                        var nForm = new Form20();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }

                    if (!context.Experiment5Result.Any(x => x.IdUser == id))
                    {
                        var nForm = new Form20();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    } break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nForm = new Form23();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}

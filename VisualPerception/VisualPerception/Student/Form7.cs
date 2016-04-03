using System;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
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
            var Item = comboBox1.SelectedItem.ToString();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            var userExperiment = context.Experiment1Result.First(x => x.IdUser == id);


            switch (Item)
            {
                case "Опыт 1":
                    if (userExperiment == null)
                    {
                        var nForm = new Form8();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        label2.Visible = true;
                    }
                    break;
                case "Опыт 2": 
                    if (userExperiment == null)
                    {
                        var nForm = new Form11();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        label2.Visible = true;
                    }break;
                case "Опыт 3": break;
                case "Опыт 4": break;
                case "Опыт 5": break;
            }
        }
    }
}

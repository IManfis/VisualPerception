using System;
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
            var Name = textBox1.Text;
            var GroupNumber = int.Parse(textBox2.Text);

            var context = new VisualPerceptionContext();
            context.User.Add(new User{Name = Name, GroupNumber = GroupNumber});
            //context.SaveChanges();

            label4.Visible = true;
            button3.Visible = true;
        }
    }
}

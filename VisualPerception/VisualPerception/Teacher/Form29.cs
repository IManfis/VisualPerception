using System;
using System.Windows.Forms;

namespace VisualPerception.Teacher
{
    public partial class Form29 : Form
    {
        public Form29()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form4();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var nForm = new Form30();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
            if (radioButton2.Checked)
            {
                var nForm = new Form32();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
            if (radioButton3.Checked)
            {
                var nForm = new Form33();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }
    }
}

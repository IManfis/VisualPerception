using System;
using System.Windows.Forms;
using VisualPerception.Student;

namespace VisualPerception
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var nForm = new Form3();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();   
            }
            if (radioButton2.Checked)
            {
                var nForm = new Form4();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form1();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}

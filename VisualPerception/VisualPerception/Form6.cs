using System;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace VisualPerception
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form5();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text();
            textboxUpdate();
            Thread.Sleep(2000);
            textClear();
            show();
        }

        private void text()
        {
            textBox1.Text = "2222";
            textBox2.Text = "2222";
            textBox3.Text = "2222";
            textBox4.Text = "2222";
            textBox5.Text = "2222";
            textBox6.Text = "2222";
            textBox7.Text = "2222";
            textBox8.Text = "2222";
            textBox9.Text = "2222";
            textBox10.Text = "2222";
            textBox11.Text = "2222";
            textBox12.Text = "2222";
            textBox13.Text = "2222";
            textBox14.Text = "2222";
            textBox15.Text = "2222";
            textBox16.Text = "2222";
        }

        private void textboxUpdate()
        {
            textBox1.Update();
            textBox2.Update();
            textBox3.Update();
            textBox4.Update();
            textBox5.Update();
            textBox6.Update();
            textBox7.Update();
            textBox8.Update();
            textBox9.Update();
            textBox10.Update();
            textBox11.Update();
            textBox12.Update();
            textBox13.Update();
            textBox14.Update();
            textBox15.Update();
            textBox16.Update();
        }

        private void textClear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
        }

        private void show()
        {
            label4.Visible = true;
            textBox17.Visible = true;
            button3.Visible = true;
        }
    }
}

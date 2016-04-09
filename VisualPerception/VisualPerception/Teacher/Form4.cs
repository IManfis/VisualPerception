﻿using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Teacher
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form2();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var context = new VisualPerceptionContext();
            var user = context.User;

            var name = textBox1.Text;
            var password = textBox2.Text;

            var admin = user.FirstOrDefault(x => x.Name == name);

            if (admin == null)
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }else if (admin.Password == password && admin.GroupNumber == 0)
            {
                var nForm = new Form29();
                nForm.FormClosed += (o, ep) => this.Close();
                nForm.Show();
                this.Hide();
            }
            else
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}

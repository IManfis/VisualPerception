using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
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
            button2.Visible = false;
            unShow();
            text();
            textboxUpdate();
            Thread.Sleep(2000);
            textClear();
            show();
        }

        private void text()
        {
            var context = new VisualPerceptionContext();
            var stimulModel = context.ExperimentData.ToList();
            Random random = new Random();
            int k;
            var lst = new List<string>();

            for (var i = 0; i < 16; i++)
            {
                while (true)
                {
                    k = random.Next(stimulModel.Count);
                    if (!lst.Any(x => x.Equals(stimulModel[k].Stimul)))
                    {
                        lst.Add(stimulModel[k].Stimul);
                        break;
                    }
                }
            }

            textBox1.Text = lst[0];
            textBox2.Text = lst[1];
            textBox3.Text = lst[2];
            textBox4.Text = lst[3];
            textBox5.Text = lst[4];
            textBox6.Text = lst[5];
            textBox7.Text = lst[6];
            textBox8.Text = lst[7];
            textBox9.Text = lst[8];
            textBox10.Text = lst[9];
            textBox11.Text = lst[10];
            textBox12.Text = lst[11];
            textBox13.Text = lst[12];
            textBox14.Text = lst[13];
            textBox15.Text = lst[14];
            textBox16.Text = lst[15];
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

        private void unShow()
        {
            label4.Visible = false;
            textBox17.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var nForm = new Form7();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}

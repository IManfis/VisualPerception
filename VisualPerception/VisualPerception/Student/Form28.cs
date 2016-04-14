using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form28 : Form
    {
        public Form28()
        {
            InitializeComponent();
        }

        public Form28(int id)
        {
            InitializeComponent();
            WorkWithView(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WorkWithView(int _id)
        {
            var context = new VisualPerceptionContext();
            var word = context.ExperimentSetting.First(x => x.Name == "Слов").Value;

            Write(int.Parse(word), _id);
        }

        private void Write(int word, int _id)
        {
            var context = new VisualPerceptionContext();

            var reproducedIncentive = context.Experiment5Result.First(x => x.Id == _id).ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            var reproducedIncentiveInt = context.Experiment5Result.First(x => x.Id == _id).Hallmark.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            var ints = reproducedIncentiveInt.Select(o => int.Parse(o)).ToList();

            switch (word)
            {
                case 8: panel3.Visible = true; panel3.BringToFront(); WriteToTextbox8(reproducedIncentive, ints); break;
                case 12: panel2.Visible = true; panel2.BringToFront(); WriteToTextbox12(reproducedIncentive, ints); break;
                case 16: panel1.Visible = true; panel1.BringToFront(); WriteToTextbox16(reproducedIncentive, ints); break;
            }
        }

        private void WriteToTextbox8(List<string> list, List<int> ints)
        {
            if (ints.Contains(30))
            {
                textBox30.Font = new Font("Microsoft Sans Serif", 14);
            } if (ints.Contains(31))
            {
                textBox31.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(32))
            {
                textBox32.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(33))
            {
                textBox33.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(34))
            {
                textBox34.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(35))
            {
                textBox35.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(36))
            {
                textBox36.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(37))
            {
                textBox37.Font = new Font("Microsoft Sans Serif", 14);
            }
            textBox30.Text = list[0];
            textBox31.Text = list[1];
            textBox32.Text = list[2];
            textBox33.Text = list[3];
            textBox34.Text = list[4];
            textBox35.Text = list[5];
            textBox36.Text = list[6];
            textBox37.Text = list[7];
        }

        private void WriteToTextbox12(List<string> list, List<int> ints)
        {
            if (ints.Contains(18))
            {
                textBox18.Font = new Font("Microsoft Sans Serif", 14);
            } if (ints.Contains(19))
            {
                textBox19.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(20))
            {
                textBox20.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(21))
            {
                textBox21.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(22))
            {
                textBox22.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(23))
            {
                textBox23.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(24))
            {
                textBox24.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(25))
            {
                textBox25.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(26))
            {
                textBox26.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(27))
            {
                textBox27.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(28))
            {
                textBox28.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(29))
            {
                textBox29.Font = new Font("Microsoft Sans Serif", 14);
            }
            textBox18.Text = list[0];
            textBox19.Text = list[1];
            textBox20.Text = list[2];
            textBox21.Text = list[3];
            textBox22.Text = list[4];
            textBox23.Text = list[5];
            textBox24.Text = list[6];
            textBox25.Text = list[7];
            textBox26.Text = list[8];
            textBox27.Text = list[9];
            textBox28.Text = list[10];
            textBox29.Text = list[11];
        }

        private void WriteToTextbox16(List<string> list, List<int> ints)
        {
            if (ints.Contains(1))
            {
                textBox1.Font = new Font("Microsoft Sans Serif", 14);
            } if (ints.Contains(2))
            {
                textBox2.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(3))
            {
                textBox3.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(4))
            {
                textBox4.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(5))
            {
                textBox5.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(6))
            {
                textBox6.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(7))
            {
                textBox7.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(8))
            {
                textBox8.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(9))
            {
                textBox9.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(10))
            {
                textBox10.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(11))
            {
                textBox11.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(12))
            {
                textBox12.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(13))
            {
                textBox13.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(14))
            {
                textBox14.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(15))
            {
                textBox15.Font = new Font("Microsoft Sans Serif", 14);
            }
            if (ints.Contains(16))
            {
                textBox16.Font = new Font("Microsoft Sans Serif", 14);
            }
            textBox1.Text = list[0];
            textBox2.Text = list[1];
            textBox3.Text = list[2];
            textBox4.Text = list[3];
            textBox5.Text = list[4];
            textBox6.Text = list[5];
            textBox7.Text = list[6];
            textBox8.Text = list[7];
            textBox9.Text = list[8];
            textBox10.Text = list[9];
            textBox11.Text = list[10];
            textBox12.Text = list[11];
            textBox13.Text = list[12];
            textBox14.Text = list[13];
            textBox15.Text = list[14];
            textBox16.Text = list[15];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
        }
        public Form25(int id)
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

            var reproducedIncentive = context.Experiment2Result.First(x => x.Id == _id).ProvidedIncentive.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            switch (word)
            {
                case 8: panel3.Visible = true; panel3.BringToFront(); WriteToTextbox8(reproducedIncentive); break;
                case 12: panel2.Visible = true; panel2.BringToFront(); WriteToTextbox12(reproducedIncentive); break;
                case 16: panel1.Visible = true; panel1.BringToFront(); WriteToTextbox16(reproducedIncentive); break;
            }
        }

        private void WriteToTextbox8(List<string> list)
        {
            textBox30.Text = list[0];
            textBox31.Text = list[1];
            textBox32.Text = list[2];
            textBox33.Text = list[3];
            textBox34.Text = list[4];
            textBox35.Text = list[5];
            textBox36.Text = list[6];
            textBox37.Text = list[7];
        }

        private void WriteToTextbox12(List<string> list)
        {
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

        private void WriteToTextbox16(List<string> list)
        {
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

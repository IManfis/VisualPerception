﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form21 : Form
    {
        public List<string> Lst = new List<string>();
        public List<string> Lst1 = new List<string>();
        public List<int> Ints = new List<int>(); 
        public int Number = 1;
        public Form21()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form20();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorkWithView();
        }

        private void WorkWithView()
        {
            var context = new VisualPerceptionContext();
            var presenting = context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value;
            var word = context.ExperimentSetting.First(x => x.Name == "Слов").Value;
            var time = int.Parse(context.ExperimentSetting.First(x => x.Name == "Время").Value);

            Header(Number, presenting);

            UnShowTextbox();

            Write(int.Parse(word));

            UpdateTextbox(int.Parse(word));

            Thread.Sleep(time * 1000);

            ClearTextbox(int.Parse(word));

            ShowTextbox();
        }

        private void Header(int number, string presenting)
        {
            label5.Text = number.ToString();
            label5.Visible = true;
            label5.Update();
            label6.Visible = true;
            label6.Update();
            label7.Text = presenting;
            label7.Visible = true;
            label7.Update();
            button2.Visible = false;
            button2.Update();
        }

        private void ClearTextbox(int word)
        {
            switch (word)
            {
                case 8: ClearTextbox8(); break;
                case 12: ClearTextbox12(); break;
                case 16: ClearTextbox16(); break;
            }
        }

        private void ClearTextbox8()
        {
            textBox30.Clear();
            textBox31.Clear();
            textBox32.Clear();
            textBox33.Clear();
            textBox34.Clear();
            textBox35.Clear();
            textBox36.Clear();
            textBox37.Clear();
            MakeTextRegular8(Ints);
        }

        private void ClearTextbox12()
        {
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            MakeTextRegular12(Ints);
        }

        private void ClearTextbox16()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            MakeTextRegular16(Ints);
        }

        public void UpdateTextbox(int word)
        {
            switch (word)
            {
                case 8: UpdateTextbox8(); break;
                case 12: UpdateTextbox12(); break;
                case 16: UpdateTextbox16(); break;
            }
        }

        private void UpdateTextbox8()
        {
            textBox30.Update();
            textBox31.Update();
            textBox32.Update();
            textBox33.Update();
            textBox34.Update();
            textBox35.Update();
            textBox36.Update();
            textBox37.Update();
        }

        private void UpdateTextbox12()
        {
            textBox18.Update();
            textBox19.Update();
            textBox20.Update();
            textBox21.Update();
            textBox22.Update();
            textBox23.Update();
            textBox24.Update();
            textBox25.Update();
            textBox26.Update();
            textBox27.Update();
            textBox28.Update();
            textBox29.Update();
        }

        private void UpdateTextbox16()
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

        private void Write(int word)
        {
            var context = new VisualPerceptionContext();
            var stimulModel = context.ExperimentData.ToList();
            Random random = new Random();
            int k;
            Lst.Clear();
            for (var i = 0; i < word; i++)
            {
                while (true)
                {
                    k = random.Next(stimulModel.Count);
                    if (!Lst.Any(x => x.Equals(stimulModel[k].Stimul)))
                    {
                        Lst.Add(stimulModel[k].Stimul.Trim().ToUpper());
                        break;
                    }
                }
            }

            Ints.Clear();
            Lst1.Clear();
            if (word == 8)
            {
                Ints.Add(30);
                Ints.Add(31);
                Ints.Add(32);
                Ints.Add(33);
                Ints.Add(34);
                Ints.Add(35);
                Ints.Add(36);
                Ints.Add(37);
            }
            Ints.Clear();
            Lst1.Clear();
            if (word == 12)
            {
                Ints.Add(18);
                Ints.Add(19);
                Ints.Add(20);
                Ints.Add(21);
                Ints.Add(22);
                Ints.Add(23);
                Ints.Add(24);
                Ints.Add(25);
                Ints.Add(26);
                Ints.Add(27);
                Ints.Add(28);
                Ints.Add(29);
            }
            Ints.Clear();
            Lst1.Clear();
            if (word == 16)
            {
                Ints.Add(1);
                Ints.Add(2);
                Ints.Add(3);
                Ints.Add(4);
                Ints.Add(5);
                Ints.Add(6);
                Ints.Add(7);
                Ints.Add(8);
                Ints.Add(9);
                Ints.Add(10);
                Ints.Add(11);
                Ints.Add(12);
                Ints.Add(13);
                Ints.Add(14);
                Ints.Add(15);
                Ints.Add(16);
            }

            for (var i = 0; i < word / 2; i++)
            {
                while (true)
                {
                    k = random.Next(Ints.Count - 1);
                    Ints.Remove(Ints[k]);
                    break;
                }
            }

            foreach (var i in Ints)
            {
                Lst1.Add(Lst[i - 1]);
            }

            switch (word)
            {
                case 8: panel3.Visible = true; panel3.BringToFront(); WriteToTextbox8(Lst, Ints); break;
                case 12: panel2.Visible = true; panel2.BringToFront(); WriteToTextbox12(Lst, Ints); break;
                case 16: panel1.Visible = true; panel1.BringToFront(); WriteToTextbox16(Lst, Ints); break;
            }
        }

        private void WriteToTextbox8(List<string> list, List<int> ints)
        {
            if (ints.Contains(30))
            {
                textBox30.Font = new Font("Microsoft Sans Serif", 12);
            } if (ints.Contains(31))
            {
                textBox31.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(32))
            {
                textBox32.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(33))
            {
                textBox33.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(34))
            {
                textBox34.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(35))
            {
                textBox35.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(36))
            {
                textBox36.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(37))
            {
                textBox37.Font = new Font("Microsoft Sans Serif", 12);
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
                textBox18.Font = new Font("Microsoft Sans Serif", 12);
            } if (ints.Contains(19))
            {
                textBox19.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(20))
            {
                textBox20.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(21))
            {
                textBox21.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(22))
            {
                textBox22.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(23))
            {
                textBox23.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(24))
            {
                textBox24.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(25))
            {
                textBox25.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(26))
            {
                textBox26.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(27))
            {
                textBox27.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(28))
            {
                textBox28.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(29))
            {
                textBox29.Font = new Font("Microsoft Sans Serif", 12);
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
                textBox1.Font = new Font("Microsoft Sans Serif", 12);
            } if (ints.Contains(2))
            {
                textBox2.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(3))
            {
                textBox3.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(4))
            {
                textBox4.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(5))
            {
                textBox5.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(6))
            {
                textBox6.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(7))
            {
                textBox7.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(8))
            {
                textBox8.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(9))
            {
                textBox9.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(10))
            {
                textBox10.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(11))
            {
                textBox11.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(12))
            {
                textBox12.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(13))
            {
                textBox13.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(14))
            {
                textBox14.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(15))
            {
                textBox15.Font = new Font("Microsoft Sans Serif", 12);
            }
            if (ints.Contains(16))
            {
                textBox16.Font = new Font("Microsoft Sans Serif", 12);
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

        private void MakeTextRegular8(List<int> ints)
        {
            if (ints.Contains(30))
            {
                textBox30.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            } if (ints.Contains(31))
            {
                textBox31.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(32))
            {
                textBox32.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(33))
            {
                textBox33.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(34))
            {
                textBox34.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(35))
            {
                textBox35.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(36))
            {
                textBox36.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(37))
            {
                textBox37.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
        }

        private void MakeTextRegular12(List<int> ints)
        {
            if (ints.Contains(18))
            {
                textBox18.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            } if (ints.Contains(19))
            {
                textBox19.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(20))
            {
                textBox20.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(21))
            {
                textBox21.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(22))
            {
                textBox22.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(23))
            {
                textBox23.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(24))
            {
                textBox24.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(25))
            {
                textBox25.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(26))
            {
                textBox26.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(27))
            {
                textBox27.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(28))
            {
                textBox28.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(29))
            {
                textBox29.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
        }

        private void MakeTextRegular16(List<int> ints)
        {
            if (ints.Contains(1))
            {
                textBox1.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            } if (ints.Contains(2))
            {
                textBox2.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(3))
            {
                textBox3.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(4))
            {
                textBox4.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(5))
            {
                textBox5.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(6))
            {
                textBox6.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(7))
            {
                textBox7.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(8))
            {
                textBox8.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(9))
            {
                textBox9.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(10))
            {
                textBox10.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(11))
            {
                textBox11.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(12))
            {
                textBox12.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(13))
            {
                textBox13.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(14))
            {
                textBox14.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(15))
            {
                textBox15.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            if (ints.Contains(16))
            {
                textBox16.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
        }

        private void ShowTextbox()
        {
            label4.Visible = true;
            textBox17.Clear();
            textBox17.Visible = true;
            button3.Visible = true;
        }

        private void UnShowTextbox()
        {
            label4.Visible = false;
            textBox17.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var context = new VisualPerceptionContext();
            var count = int.Parse(context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value);
            WriteResultToDb();
            if (Number == count + 1)
            {
                UnShowTextbox();
                button4.Visible = true;
            }
            else
            {
                WorkWithView();
            }
        }

        private void WriteResultToDb()
        {
            var context = new VisualPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;
            var presenting = context.ExperimentSetting.First(x => x.Name == "Предъявлений").Value;
            var word = int.Parse(context.ExperimentSetting.First(x => x.Name == "Слов").Value);

            var providedIncentiveString = Lst.Aggregate("", (current, s) => current + (s + ","));

            var reproducedIncentiveString = textBox17.Text;
            reproducedIncentiveString = reproducedIncentiveString.Replace(" ", string.Empty).ToUpper();
            var reproducedIncentive = reproducedIncentiveString.Split(new char[] { ',', '.', '/' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            var numberReproducedOfIncentive = reproducedIncentive.Count(s => Lst.Contains(s));
            var numberOfGroups = 0;
            switch (word)
            {
                case 8: numberOfGroups = NumberOfGroups8(reproducedIncentive); break;
                case 12: numberOfGroups = NumberOfGroups12(reproducedIncentive); break;
                case 16: numberOfGroups = NumberOfGroups16(reproducedIncentive); break;
            }
            var numberOfGroupsHallmark = 0;
            switch (word)
            {
                case 8: numberOfGroupsHallmark = NumberOfGroupsHallmark8(reproducedIncentive); break;
                case 12: numberOfGroupsHallmark = NumberOfGroupsHallmark12(reproducedIncentive); break;
                case 16: numberOfGroupsHallmark = NumberOfGroupsHallmark16(reproducedIncentive); break;
            }

            context.Experiment5Result.Add(new Experiment5Result
            {
                IdUser = id,
                ProvidedIncentive = providedIncentiveString,
                ReproducedIncentive = reproducedIncentiveString,
                NumberReproducedOfIncentive = numberReproducedOfIncentive,
                NumberGroupsWithWord = numberOfGroups,
                RelativeDistributionWord = numberReproducedOfIncentive / double.Parse(numberOfGroups + ",0"),
                NumberGroupsHallmark = numberOfGroupsHallmark,
                NumberDisplay = Number,
                AllNumberDisplay = int.Parse(presenting)
            });
            //context.SaveChanges();

            Number++;
            Thread.Sleep(1000);
        }

        private int NumberOfGroups8(List<string> reproducedIncentive)
        {
            var numberOfGroups = 0;

            var group1 = reproducedIncentive.Count(t => Lst[0] == t || Lst[1] == t);

            var group2 = reproducedIncentive.Count(t => Lst[2] == t || Lst[3] == t);

            var group3 = reproducedIncentive.Count(t => Lst[4] == t || Lst[5] == t);

            var group4 = reproducedIncentive.Count(t => Lst[6] == t || Lst[7] == t);

            if (group1 > 0)
            {
                numberOfGroups += 1;
            }

            if (group2 > 0)
            {
                numberOfGroups += 1;
            }

            if (group3 > 0)
            {
                numberOfGroups += 1;
            }

            if (group4 > 0)
            {
                numberOfGroups += 1;
            }

            return numberOfGroups;
        }

        private int NumberOfGroups12(List<string> reproducedIncentive)
        {
            var numberOfGroups = 0;

            var group1 = reproducedIncentive.Count(t => Lst[0] == t || Lst[1] == t || Lst[4] == t);

            var group2 = reproducedIncentive.Count(t => Lst[2] == t || Lst[3] == t || Lst[5] == t);

            var group3 = reproducedIncentive.Count(t => Lst[8] == t || Lst[9] == t || Lst[6] == t);

            var group4 = reproducedIncentive.Count(t => Lst[10] == t || Lst[11] == t || Lst[7] == t);

            if (group1 > 0)
            {
                numberOfGroups += 1;
            }

            if (group2 > 0)
            {
                numberOfGroups += 1;
            }

            if (group3 > 0)
            {
                numberOfGroups += 1;
            }

            if (group4 > 0)
            {
                numberOfGroups += 1;
            }

            return numberOfGroups;
        }

        private int NumberOfGroups16(List<string> reproducedIncentive)
        {
            var numberOfGroups = 0;

            var group1 = reproducedIncentive.Count(t => Lst[0] == t || Lst[1] == t || Lst[4] == t || Lst[5] == t);

            var group2 = reproducedIncentive.Count(t => Lst[2] == t || Lst[3] == t || Lst[6] == t || Lst[7] == t);

            var group3 = reproducedIncentive.Count(t => Lst[8] == t || Lst[9] == t || Lst[12] == t || Lst[13] == t);

            var group4 = reproducedIncentive.Count(t => Lst[10] == t || Lst[11] == t || Lst[14] == t || Lst[15] == t);

            if (group1 > 0)
            {
                numberOfGroups += 1;
            }

            if (group2 > 0)
            {
                numberOfGroups += 1;
            }

            if (group3 > 0)
            {
                numberOfGroups += 1;
            }

            if (group4 > 0)
            {
                numberOfGroups += 1;
            }

            return numberOfGroups;
        }

        private int NumberOfGroupsHallmark8(List<String> reproducedIncentive)
        {
            var numberOfGroups = 0;

            var group1 = reproducedIncentive.Count(t => Lst[0] == t || Lst[1] == t);

            var group2 = reproducedIncentive.Count(t => Lst[2] == t || Lst[3] == t);

            var group3 = reproducedIncentive.Count(t => Lst[4] == t || Lst[5] == t);

            var group4 = reproducedIncentive.Count(t => Lst[6] == t || Lst[7] == t);

            var grouphallmark1 = 0;
            var grouphallmark2 = 0;
            var grouphallmark3 = 0;
            var grouphallmark4 = 0;

            foreach (var item in reproducedIncentive)
            {
                if (Lst.FindIndex(x => x.Contains(item)) == 0 || Lst.FindIndex(x => x.Contains(item)) == 1)
                {
                    grouphallmark1++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 2 || Lst.FindIndex(x => x.Contains(item)) == 3)
                {
                    grouphallmark2++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 4 || Lst.FindIndex(x => x.Contains(item)) == 5)
                {
                    grouphallmark3++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 6 || Lst.FindIndex(x => x.Contains(item)) == 7)
                {
                    grouphallmark4++;
                }
            }

            if (group1 > 0 && grouphallmark1 > 0)
            {
                numberOfGroups += 1;
            }

            if (group2 > 0 && grouphallmark2 > 0)
            {
                numberOfGroups += 1;
            }

            if (group3 > 0 && grouphallmark3 > 0)
            {
                numberOfGroups += 1;
            }

            if (group4 > 0 && grouphallmark4 > 0)
            {
                numberOfGroups += 1;
            }

            return numberOfGroups;
        }

        private int NumberOfGroupsHallmark12(List<String> reproducedIncentive)
        {
            var numberOfGroups = 0;

            var group1 = reproducedIncentive.Count(t => Lst[0] == t || Lst[1] == t || Lst[4] == t);

            var group2 = reproducedIncentive.Count(t => Lst[2] == t || Lst[3] == t || Lst[5] == t);

            var group3 = reproducedIncentive.Count(t => Lst[8] == t || Lst[9] == t || Lst[6] == t);

            var group4 = reproducedIncentive.Count(t => Lst[10] == t || Lst[11] == t || Lst[7] == t);

            var grouphallmark1 = 0;
            var grouphallmark2 = 0;
            var grouphallmark3 = 0;
            var grouphallmark4 = 0;

            foreach (var item in reproducedIncentive)
            {
                if (Lst.FindIndex(x => x.Contains(item)) == 0 || Lst.FindIndex(x => x.Contains(item)) == 1 ||
                    Lst.FindIndex(x => x.Contains(item)) == 4)
                {
                    grouphallmark1++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 2 || Lst.FindIndex(x => x.Contains(item)) == 3 ||
                    Lst.FindIndex(x => x.Contains(item)) == 5)
                {
                    grouphallmark2++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 8 || Lst.FindIndex(x => x.Contains(item)) == 9 ||
                    Lst.FindIndex(x => x.Contains(item)) == 6)
                {
                    grouphallmark3++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 10 || Lst.FindIndex(x => x.Contains(item)) == 11 ||
                    Lst.FindIndex(x => x.Contains(item)) == 7)
                {
                    grouphallmark4++;
                }
            }
          
            if (group1 > 0 && grouphallmark1 > 0)
            {
                numberOfGroups += 1;
            }

            if (group2 > 0 && grouphallmark2 > 0)
            {
                numberOfGroups += 1;
            }

            if (group3 > 0 && grouphallmark3 > 0)
            {
                numberOfGroups += 1;
            }

            if (group4 > 0 && grouphallmark4 > 0)
            {
                numberOfGroups += 1;
            }

            return numberOfGroups;
        }

        private int NumberOfGroupsHallmark16(List<String> reproducedIncentive)
        {
            var numberOfGroups = 0;

            var group1 = reproducedIncentive.Count(t => Lst[0] == t || Lst[1] == t || Lst[4] == t || Lst[5] == t);

            var group2 = reproducedIncentive.Count(t => Lst[2] == t || Lst[3] == t || Lst[6] == t || Lst[7] == t);

            var group3 = reproducedIncentive.Count(t => Lst[8] == t || Lst[9] == t || Lst[12] == t || Lst[13] == t);

            var group4 = reproducedIncentive.Count(t => Lst[10] == t || Lst[11] == t || Lst[14] == t || Lst[15] == t);

            var grouphallmark1 = 0;
            var grouphallmark2 = 0;
            var grouphallmark3 = 0;
            var grouphallmark4 = 0;

            foreach (var item in reproducedIncentive)
            {
                if (Lst.FindIndex(x => x.Contains(item)) == 0 || Lst.FindIndex(x => x.Contains(item)) == 1 ||
                    Lst.FindIndex(x => x.Contains(item)) == 4 || Lst.FindIndex(x => x.Contains(item)) == 5)
                {
                    grouphallmark1++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 2 || Lst.FindIndex(x => x.Contains(item)) == 3 ||
                    Lst.FindIndex(x => x.Contains(item)) == 6 || Lst.FindIndex(x => x.Contains(item)) == 7)
                {
                    grouphallmark2++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 8 || Lst.FindIndex(x => x.Contains(item)) == 9 ||
                    Lst.FindIndex(x => x.Contains(item)) == 12 || Lst.FindIndex(x => x.Contains(item)) == 13)
                {
                    grouphallmark3++;
                }

                if (Lst.FindIndex(x => x.Contains(item)) == 10 || Lst.FindIndex(x => x.Contains(item)) == 11 ||
                    Lst.FindIndex(x => x.Contains(item)) == 14 || Lst.FindIndex(x => x.Contains(item)) == 15)
                {
                    grouphallmark4++;
                }
            }

            if (group1 > 0 && grouphallmark1 > 0)
            {
                numberOfGroups += 1;
            }

            if (group2 > 0 && grouphallmark2 > 0)
            {
                numberOfGroups += 1;
            }

            if (group3 > 0 && grouphallmark3 > 0)
            {
                numberOfGroups += 1;
            }

            if (group4 > 0 && grouphallmark4 > 0)
            {
                numberOfGroups += 1;
            }

            return numberOfGroups;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var nForm = new Form22();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}

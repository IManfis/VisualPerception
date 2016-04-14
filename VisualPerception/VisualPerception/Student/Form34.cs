﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form34 : Form
    {
        private int _id = 0;
        public Form34()
        {
            InitializeComponent();
            var id = 3;
            WriteData(3);
        }

        public Form34(int id)
        {
            InitializeComponent();
            WriteData(id);

            var context = new VisualPerceptionContext();

            if (context.Experiment1Result.Any(x => x.IdUser == id) &&
                context.Experiment2Result.Any(x => x.IdUser == id) &&
                context.Experiment3Result.Any(x => x.IdUser == id) &&
                context.Experiment4Result.Any(x => x.IdUser == id) &&
                context.Experiment5Result.Any(x => x.IdUser == id))
            {
                button1.Visible = true;
                button3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form3();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void WriteData(int id)
        {
            _id = id;
            var context = new VisualPerceptionContext();
            var experimentResult = context.Experiment1Result.Where(x => x.IdUser == id).ToList();

            var rez = experimentResult[experimentResult.Count - 1];

            dataGridView1.Rows.Add();

            var name = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[0];
            name.Value = "Опыт №1";

            var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[1];
            numberDisplay.Value = rez.NumberDisplay.ToString();

            var allNumberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[0].Cells[2];
            allNumberDisplay.Value = rez.AllNumberDisplay.ToString();
            if (rez.NumberDisplay == rez.AllNumberDisplay)
            {
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Green;
            }
            else
            {
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Red;
            }

            var experimentResult1 = context.Experiment2Result.Where(x => x.IdUser == id).ToList();

            var rez1 = experimentResult1[experimentResult1.Count - 1];

            dataGridView1.Rows.Add();

            var name1 = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[0];
            name1.Value = "Опыт №2";

            var numberDisplay1 = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[1];
            numberDisplay1.Value = rez1.NumberDisplay.ToString();

            var allNumberDisplay1 = (DataGridViewTextBoxCell)dataGridView1.Rows[1].Cells[2];
            allNumberDisplay1.Value = rez1.AllNumberDisplay.ToString();
            
            if (rez1.NumberDisplay == rez1.AllNumberDisplay)
            {
                dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Green;
            }
            else
            {
                dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Red;
            }

            var experimentResult2 = context.Experiment3Result.Where(x => x.IdUser == id).ToList();

            var rez2 = experimentResult2[experimentResult2.Count - 1];

            dataGridView1.Rows.Add();

            var name2 = (DataGridViewTextBoxCell)dataGridView1.Rows[2].Cells[0];
            name2.Value = "Опыт №3";

            var numberDisplay2 = (DataGridViewTextBoxCell)dataGridView1.Rows[2].Cells[1];
            numberDisplay2.Value = rez2.NumberDisplay.ToString();

            var allNumberDisplay2 = (DataGridViewTextBoxCell)dataGridView1.Rows[2].Cells[2];
            allNumberDisplay2.Value = rez2.AllNumberDisplay.ToString();
            if (rez2.NumberDisplay == rez2.AllNumberDisplay)
            {
                dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.Green;
            }
            else
            {
                dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.Red;
            }

            var experimentResult3 = context.Experiment4Result.Where(x => x.IdUser == id).ToList();

            var rez3 = experimentResult3[experimentResult3.Count - 1];

            dataGridView1.Rows.Add();

            var name3 = (DataGridViewTextBoxCell)dataGridView1.Rows[3].Cells[0];
            name3.Value = "Опыт №4";

            var numberDisplay3 = (DataGridViewTextBoxCell)dataGridView1.Rows[3].Cells[1];
            numberDisplay3.Value = rez3.NumberDisplay.ToString();

            var allNumberDisplay3 = (DataGridViewTextBoxCell)dataGridView1.Rows[3].Cells[2];
            allNumberDisplay3.Value = rez3.AllNumberDisplay.ToString();
            if (rez3.NumberDisplay == rez3.AllNumberDisplay)
            {
                dataGridView1.Rows[3].DefaultCellStyle.BackColor = Color.Green;
            }
            else
            {
                dataGridView1.Rows[3].DefaultCellStyle.BackColor = Color.Red;
            }

            var experimentResult4 = context.Experiment5Result.Where(x => x.IdUser == id).ToList();

            var rez4 = experimentResult4[experimentResult4.Count - 1];

            dataGridView1.Rows.Add();

            var name4 = (DataGridViewTextBoxCell)dataGridView1.Rows[4].Cells[0];
            name4.Value = "Опыт №5";

            var numberDisplay4 = (DataGridViewTextBoxCell)dataGridView1.Rows[4].Cells[1];
            numberDisplay4.Value = rez4.NumberDisplay.ToString();

            var allNumberDisplay4 = (DataGridViewTextBoxCell)dataGridView1.Rows[4].Cells[2];
            allNumberDisplay4.Value = rez4.AllNumberDisplay.ToString();
            if (rez4.NumberDisplay == rez4.AllNumberDisplay)
            {
                dataGridView1.Rows[4].DefaultCellStyle.BackColor = Color.Green;
            }
            else
            {
                dataGridView1.Rows[4].DefaultCellStyle.BackColor = Color.Red;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;

            var context = new VisualPerceptionContext();
            var name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var experimentResult = context.Experiment1Result.Where(x => x.IdUser == _id).ToList();
            var experimentResult1 = context.Experiment2Result.Where(x => x.IdUser == _id).ToList();
            var experimentResult2 = context.Experiment3Result.Where(x => x.IdUser == _id).ToList();
            var experimentResult3 = context.Experiment4Result.Where(x => x.IdUser == _id).ToList();
            var experimentResult4 = context.Experiment5Result.Where(x => x.IdUser == _id).ToList();


            var rez = experimentResult[experimentResult.Count - 1];
            var rez1 = experimentResult1[experimentResult2.Count - 1];
            var rez2 = experimentResult2[experimentResult2.Count - 1];
            var rez3 = experimentResult3[experimentResult3.Count - 1];
            var rez4 = experimentResult4[experimentResult4.Count - 1];
            switch (name)
            {
                case "Опыт №1":
                    if (rez.NumberDisplay == rez.AllNumberDisplay)
                    {
                        label2.Visible = true;
                        break;
                    }
                    else
                    {
                        var nForm = new Form9(rez.NumberDisplay + 1, _id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                case "Опыт №2":
                    if (rez1.NumberDisplay == rez1.AllNumberDisplay)
                    {
                        label2.Visible = true;
                        break;
                    }
                    else
                    {
                        var nForm = new Form12(rez1.NumberDisplay + 1, _id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                case "Опыт №3":
                    if (rez2.NumberDisplay == rez2.AllNumberDisplay)
                    {
                        label2.Visible = true;
                        break;
                    }
                    else
                    {
                        var nForm = new Form15(rez2.NumberDisplay + 1, _id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                case "Опыт №4":
                    if (rez3.NumberDisplay == rez3.AllNumberDisplay)
                    {
                        label2.Visible = true;
                        break;
                    }
                    else
                    {
                        var nForm = new Form18(rez3.NumberDisplay + 1, _id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                case "Опыт №5":
                    if (rez4.NumberDisplay == rez4.AllNumberDisplay)
                    {
                        label2.Visible = true;
                        break;
                    }
                    else
                    {
                        var nForm = new Form21(rez4.NumberDisplay + 1, _id);
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form23(_id);
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}

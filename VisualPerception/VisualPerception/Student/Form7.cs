﻿using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form5();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new VisualPerceptionContext();
            var item = comboBox1.SelectedItem.ToString();
            var count = context.User.Count();
            var user = context.User.ToList();
            var id = user[count - 1].Id;

            switch (item)
            {
                case "Опыт 1":
                    if (!context.Experiment1Result.Any())
                    {
                        var nForm = new Form8();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                    }

                    var userExperiment1 = context.Experiment1Result.First(x => x.IdUser == id);
                    if (userExperiment1 == null)
                    {
                        var nForm = new Form8();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    }
                    break;
                case "Опыт 2":
                    if (!context.Experiment2Result.Any())
                    {
                        var nForm = new Form11();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                    }

                    var userExperiment2 = context.Experiment2Result.First(x => x.IdUser == id);
                    if (userExperiment2 == null)
                    {
                        var nForm = new Form11();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    }break;
                case "Опыт 3":
                    if (!context.Experiment3Result.Any())
                    {
                        var nForm = new Form14();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                        break;
                    }

                    var userExperiment3 = context.Experiment3Result.First(x => x.IdUser == id);
                    if (userExperiment3 == null)
                    {
                        var nForm = new Form14();
                        nForm.FormClosed += (o, ep) => this.Close();
                        nForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        label2.Visible = false;
                        label2.Update();
                        Thread.Sleep(500);
                        label2.Visible = true;
                    } break;
                case "Опыт 4": break;
                case "Опыт 5": break;
            }
        }
    }
}

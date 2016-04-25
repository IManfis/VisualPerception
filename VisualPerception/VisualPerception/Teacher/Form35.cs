using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Teacher
{
    public partial class Form35 : Form
    {
        public Form35()
        {
            InitializeComponent();
        }

        private void Form35_Load(object sender, EventArgs e)
        {
            var context = new VisualPerceptionContext();
            var text = context.ExperimentSetting.FirstOrDefault(x => x.Name == "Теоретические").Value;
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form29();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = richTextBox1.Text;
            var context = new VisualPerceptionContext();
            var model = new ExperimentSetting() { Id = 4, Name = "Теоретические", Value = text };

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
            label2.Visible = true;
        }
    }
}

using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Teacher
{
    public partial class Form31 : Form
    {
        public Form31()
        {
            InitializeComponent();
        }

        public Form31(int id)
        {
            InitializeComponent();
            var context = new VisualPerceptionContext();
            var model = context.ExperimentData.First(x => x.Id == id);
            textBox1.MaxLength = 10;
            textBox1.Text = model.Stimul.Trim();
            label3.Text = id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new VisualPerceptionContext();
            var model = new ExperimentData {Id = int.Parse(label3.Text), Stimul = textBox1.Text};

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            Close();
        }
    }
}

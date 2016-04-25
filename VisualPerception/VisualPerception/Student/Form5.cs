using System;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            var context = new VisualPerceptionContext();
            var firstOrDefault = context.ExperimentSetting.FirstOrDefault(x => x.Name == "Теоретические");
            if (firstOrDefault != null)
            {
                var text = firstOrDefault.Value;
                richTextBox1.Text = text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form3();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form6();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }
    }
}

using System;
using System.Windows.Forms;

namespace VisualPerception
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
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Опыт 1": var nForm = new Form8();
                    nForm.FormClosed += (o, ep) => this.Close();
                    nForm.Show();
                    this.Hide();
                    break;
                case "Опыт 2": break;
                case "Опыт 3": break;
                case "Опыт 4": break;
                case "Опыт 5": break;
            }
        }
    }
}

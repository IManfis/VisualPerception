using System;
using System.Windows.Forms;

namespace VisualPerception.Student
{
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nForm = new Form7();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem.ToString();

            switch (item)
            {
                case "Опыт 1": 
                    var nForm1 = new Form24();
                    nForm1.FormClosed += (o, ep) => this.Close();
                    nForm1.Show();
                    this.Hide();
                    break;
                case "Опыт 2":
                    var nForm2 = new Form25();
                    nForm2.FormClosed += (o, ep) => this.Close();
                    nForm2.Show();
                    this.Hide();
                    break;
                case "Опыт 3":
                    var nForm3 = new Form26();
                    nForm3.FormClosed += (o, ep) => this.Close();
                    nForm3.Show();
                    this.Hide();
                    break;
                case "Опыт 4":
                    var nForm4 = new Form27();
                    nForm4.FormClosed += (o, ep) => this.Close();
                    nForm4.Show();
                    this.Hide();
                    break;
                case "Опыт 5":
                    var nForm5 = new Form28();
                    nForm5.FormClosed += (o, ep) => this.Close();
                    nForm5.Show();
                    this.Hide();
                    break;
            }
        }
    }
}

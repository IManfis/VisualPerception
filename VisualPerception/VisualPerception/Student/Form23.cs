using System;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Student
{
    public partial class Form23 : Form
    {
        private readonly int _id = 0;
        public Form23()
        {
            InitializeComponent();
            var context = new VisualPerceptionContext();
            var count = context.User.Count();
            var user = context.User.ToList();
            _id = user[count - 1].Id;
        }

        public Form23(int id)
        {
            InitializeComponent();
            _id = id;
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
                    var nForm1 = new Form24(_id);
                    nForm1.FormClosed += (o, ep) => this.Close();
                    nForm1.Show();
                    this.Hide();
                    break;
                case "Опыт 2":
                    var nForm2 = new Form25(_id);
                    nForm2.FormClosed += (o, ep) => this.Close();
                    nForm2.Show();
                    this.Hide();
                    break;
                case "Опыт 3":
                    var nForm3 = new Form26(_id);
                    nForm3.FormClosed += (o, ep) => this.Close();
                    nForm3.Show();
                    this.Hide();
                    break;
                case "Опыт 4":
                    var nForm4 = new Form27(_id);
                    nForm4.FormClosed += (o, ep) => this.Close();
                    nForm4.Show();
                    this.Hide();
                    break;
                case "Опыт 5":
                    var nForm5 = new Form28(_id);
                    nForm5.FormClosed += (o, ep) => this.Close();
                    nForm5.Show();
                    this.Hide();
                    break;
            }
        }
    }
}

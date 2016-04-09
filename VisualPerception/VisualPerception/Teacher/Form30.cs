using System;
using System.Linq;
using System.Windows.Forms;
using VisualPerception.Model;

namespace VisualPerception.Teacher
{
    public partial class Form30 : Form
    {
        public Form30()
        {
            InitializeComponent();
            WriteToDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nForm = new Form29();
            nForm.FormClosed += (o, ep) => this.Close();
            nForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            var context = new VisualPerceptionContext();
            var experimentData = context.ExperimentData;

            var stimul = textBox1.Text;

            if (!experimentData.Any(x => x.Stimul == stimul))
            {
                context.ExperimentData.Add(new ExperimentData { Stimul = stimul });
                context.SaveChanges();
                WriteToDataGridView();
            }
            else
            {
                label4.Visible = true;
                textBox1.Text = "";
            }
        }

        private void WriteToDataGridView()
        {
            dataGridView1.Rows.Clear();
            var context = new VisualPerceptionContext();
            var data = context.ExperimentData;

            var row = 0;
            foreach (var result in data)
            {
                dataGridView1.Rows.Add();
                var numberDisplay = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[0];
                numberDisplay.Value = row + 1;

                var providedIncentive = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[1];
                providedIncentive.Value = result.Stimul;

                var id = (DataGridViewTextBoxCell)dataGridView1.Rows[row].Cells[2];
                id.Value = result.Id;

                row++;
            }

            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            var stimul = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            var context = new VisualPerceptionContext();
            var model = new ExperimentData {Id = id};

            var result = MessageBox.Show("Вы уверены, что хотите удалить данный стимул?", "Удаление стимула", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                context.ExperimentData.Attach(model);
                context.ExperimentData.Remove(model);
                context.SaveChanges();

                WriteToDataGridView();   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            var f = new Form31(id);
            f.ShowDialog();
        }

        private void Form30_Activated(object sender, EventArgs e)
        {
            WriteToDataGridView();
        }
    }
}

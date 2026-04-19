using System.Data;
using System.Xml.Linq;

namespace dental_record_system
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Treatment");
            dt.Columns.Add("Date");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Status");

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Rows.Add(
                textBox1.Text,
                textBox2.Text,
                comboBox3,
                comboBox1.Text,
                dateTimePicker1.Value.ToShortDateString(),
                textBox3.Text,
                comboBox2.Text
            );

            MessageBox.Show("Record Added!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int row = dataGridView1.CurrentRow.Index;

                dt.Rows[row]["ID"] = textBox1.Text;
                dt.Rows[row]["Name"] = textBox2.Text;
                dt.Rows[row]["Treatment"] = comboBox2.Text;
                dt.Rows[row]["Date"] = dateTimePicker1.Value.ToShortDateString();
                dt.Rows[row]["Amount"] = textBox7.Text;
                dt.Rows[row]["Status"] = comboBox5.Text;

                MessageBox.Show("Record Updated!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                MessageBox.Show("Record Deleted!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox7.Clear();

            comboBox2.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;

            dateTimePicker1.Value = DateTime.Now;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name"].Value != null &&
                    row.Cells["Name"].Value.ToString().ToLower().Contains(textBox2.Text.ToLower()))
                {
                    row.Selected = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ID"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                comboBox3.Text = row.Cells["Name"].Value.ToString();
                comboBox2.Text = row.Cells["Treatment"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                textBox7.Text = row.Cells["Amount"].Value.ToString();
                comboBox5.Text = row.Cells["Status"].Value.ToString();
            }
        }
    }
}



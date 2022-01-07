using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class deleteform : Form
    {
        public deleteform()
        {
            InitializeComponent();
        }

        private void deleteform_Load(object sender, EventArgs e)
        {
            this.Text = "csharp-console-examples.com";
            this.BackColor = Color.IndianRed;
            DataGridViewTextBoxColumn dgvId = new DataGridViewTextBoxColumn();
            dgvId.HeaderText = "Id";
            DataGridViewTextBoxColumn dgvFn = new DataGridViewTextBoxColumn();
            dgvFn.HeaderText = "First Name";
            DataGridViewTextBoxColumn dgvLn = new DataGridViewTextBoxColumn();
            dgvLn.HeaderText = "Last Name";


            DataGridViewCheckBoxColumn dgvCheckBox = new DataGridViewCheckBoxColumn();
            dgvCheckBox.HeaderText = "Select";

            dataGridView1.Columns.Add(dgvId);
            dataGridView1.Columns.Add(dgvFn);
            dataGridView1.Columns.Add(dgvLn);
            dataGridView1.Columns.Add(dgvCheckBox);


            dataGridView1.Rows.Add("1", "First Name 1", "Last Name 1", false);
            dataGridView1.Rows.Add("2", "First Name 2", "Last Name 2", false);
            dataGridView1.Rows.Add("3", "First Name 3", "Last Name 3", false);
            dataGridView1.Rows.Add("4", "First Name 4", "Last Name 4", false);
            dataGridView1.Rows.Add("5", "First Name 5", "Last Name 5", false);
            dataGridView1.Rows.Add("6", "First Name 6", "Last Name 6", false);
            dataGridView1.Rows.Add("7", "First Name 7", "Last Name 7", false);
            dataGridView1.Rows.Add("8", "First Name 8", "Last Name 8", false);
            dataGridView1.Rows.Add("9", "First Name 9", "Last Name 9", false);
            dataGridView1.Rows.Add("10", "First Name 10", "Last Name 10", false);
            dataGridView1.Rows.Add("11", "First Name 11", "Last Name 11", false);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                bool chk = (bool)dataGridView1.Rows[i].Cells[2].Value;
                if (chk == true)
                {
                    DataGridViewRow drow = dataGridView1.Rows[i];
                    dataGridView1.Rows.Remove(drow);
                }
            }
        }
    }
}

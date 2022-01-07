using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DormitoryCodeForm : Form
    {
        //Connection String  
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection conn;
        OracleDataAdapter adaptt;
        DataTable dtt;
        public DormitoryCodeForm()
        {            
            InitializeComponent();
        }        
        
        private void DormitoryCodeForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(css);
            conn.Open();
            adaptt = new OracleDataAdapter("select * from P22_LMG_TATM_DON order by DON_CODE", conn);
            dtt = new DataTable();
            adaptt.Fill(dtt);
            dataGridView1.DataSource = dtt;            
            conn.Close();

            //datagridview1 Columns
            dataGridView1.Columns[0].HeaderText = "동";
            dataGridView1.Columns[1].HeaderText = "기숙사명";
            dataGridView1.Columns[0].Name = "Dong";
            dataGridView1.Columns[1].Name = "Name";
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string val = this.dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            string val1 = this.dataGridView1.CurrentRow.Cells["Dong"].Value.ToString();

            textBox1.Text = val;
            textBox2.Text = val1;

            this.Close();
        }
        public string _textBox1
        {
            get { return textBox1.Text.Trim(); }
        }
        public string _textBox2
        {
            get { return textBox2.Text.Trim(); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(css);
            conn.Open();
            adaptt = new OracleDataAdapter("select * from P22_LMG_TATM_DON where DON_NAME like '" + textBox1.Text + "%' order by DON_CODE", conn);
            dtt = new DataTable();
            adaptt.Fill(dtt);
            dataGridView1.DataSource = dtt;
            conn.Close();
        }
    }
}

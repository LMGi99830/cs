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
    public partial class SupportAreasCodeForm : Form
    {
        //Connection String  
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;

        public SupportAreasCodeForm()
        {
            InitializeComponent();
        }

        private void SupportAreasCodeForm_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_SUP order by SUP_CODE", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            //datagridview1 Columns
            dataGridView1.Columns[0].HeaderText = "지원코드";
            dataGridView1.Columns[1].HeaderText = "분야명";
            dataGridView1.Columns[0].Name = "Code";
            dataGridView1.Columns[1].Name = "Name";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string SUP1 = this.dataGridView1.CurrentRow.Cells["Code"].Value.ToString();
            string SUP2 = this.dataGridView1.CurrentRow.Cells["Name"].Value.ToString();

            textBox1.Text = SUP1;
            textBox2.Text = SUP2;

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

        private void button1_Click(object sender, EventArgs e)
        {
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_SUP where SUP_NAME like '" + textBox1.Text + "%' order by SUP_CODE", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}

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
    public partial class test : Form
    {
        //Connection String  
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        public test()
        {
            InitializeComponent();
        }


        private void test_Load(object sender, EventArgs e)
        {

            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_DON order by DON_CODE", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            //datagridview1 Columns            
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Category";

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string val = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            string val1 = this.dataGridView1.CurrentRow.Cells["Category"].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_DON where DON_NAME like '" + textBox3.Text + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                string queryString = "select * from P22_LMG_TATM_STU where STU_STUNO like '" + textBox5.Text + "'";
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    OracleCommand command = new OracleCommand(queryString, connection);
                    connection.Open();
                    OracleDataReader reader;
                    reader = command.ExecuteReader();

                    // Always call Read before accessing data.
                    while (reader.Read())
                    {
                       textBox6.Text =  reader.GetString(2);
                       textBox7.Text = reader.GetString(3);
                }

                    // Always call Close when done reading.
                    reader.Close();
                }
            
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}


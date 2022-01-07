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
    public partial class AdminAttendance : Form
    {
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        OracleCommand cmd;
        DataSet dtSet = new DataSet();

        public AdminAttendance()
        {
            InitializeComponent();
            textBox12.TabStop = false;
            textBox9.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
            textBox4.TabStop = false;
            textBox5.TabStop = false;
            textBox11.TabStop = false;
            textBox16.TabStop = false;
            

        }

        private void AdminAttendance_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_PRO order by PRO_YEAR ASC", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns[0].HeaderText = "연도";
            dataGridView1.Columns[1].HeaderText = "계절";
            dataGridView1.Columns[2].HeaderText = "명칭";
            dataGridView1.Columns[3].HeaderText = "실습기간(시작)";
            dataGridView1.Columns[4].HeaderText = "실습기간(종료)";
            dataGridView1.Columns[5].HeaderText = "실습시간(시작)";
            dataGridView1.Columns[6].HeaderText = "실습시간(종료)";
            dataGridView1.Columns[7].HeaderText = "자료처리일시";
            dataGridView1.Columns[8].HeaderText = "자료처리구분";
            dataGridView1.Columns[9].HeaderText = "자료처리자";


            dataGridView1.Columns[0].Name = "Year";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Season";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AttendanceCodeForm Form1 = new AttendanceCodeForm();
            Form1.ShowDialog();
            textBox12.Text = Form1._textBox1.ToString();
            textBox9.Text = Form1._textBox2.ToString();
        }
    }
}

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
    public partial class testsql : Form
    {
        //디비 연결  
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        OracleCommand cmd;
        DataSet dtSet = new DataSet();
        public testsql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(css);
            con.Open();

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "select ATT_STUNO from P22_LMG_TATM_ATT where ATT_STUNO = '" + textBox1.Text + "' and ATT_DATE = '"+ textBox2.Text +"'";

            OracleDataReader dr = cmd.ExecuteReader();
            Boolean check = false;
            while (dr.Read())
            {
                check = true;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("정보들을 먼저 입력해주세요");
                return;
            }

            else if (check)
            {
                MessageBox.Show("이미 출석하셨습니다.");
                return;
            }
            else
            {
                MessageBox.Show("등록 완료");
            }
            dr.Close();
            con.Close();
        }
    }
}

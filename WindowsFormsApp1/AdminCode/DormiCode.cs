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
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class DormiCode : Form
    {
        //Connection String  
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection conn;
        OracleDataAdapter adaptt;
        DataTable dtt;
        OracleCommand cmd;
        DataSet dtSet = new DataSet();        
        public DormiCode()
        {
            InitializeComponent();     
            
        }

        private void DormiCode_Load(object sender, EventArgs e)
        {
            reset_form();
            
        }
        private void reset_form()
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

        }
        
        public void InsertDB()
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("코드를 입력해주세요.");
                return;
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("명칭을 입력해주세요.");
                    return;
                }
            }

            // 오라클 연결
            OracleConnection conn = new OracleConnection(css);
            conn.Open();

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            // SQL문 지정 및 INSERT 실행
            this.dataGridView1.AllowUserToAddRows = true;
            cmd.CommandText = "INSERT INTO P22_LMG_TATM_DON(DON_CODE, DON_NAME) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";

            cmd.ExecuteNonQuery();
            conn.Close();
            reset_form();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("코드를 입력해주세요.");
                return;
            }
            else
            {
                if( textBox2.Text == "")
                {
                    MessageBox.Show("명칭을 입력해주세요.");
                    return;
                }
            }

            // 오라클 연결
            OracleConnection conn = new OracleConnection(css);
            conn.Open();

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            // SQL문 지정 및 INSERT 실행
            this.dataGridView1.AllowUserToAddRows = true;
            cmd.CommandText = "INSERT INTO P22_LMG_TATM_DON(DON_CODE, DON_NAME) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
            
            cmd.ExecuteNonQuery();
            conn.Close();
            reset_form();



        }
    }
}


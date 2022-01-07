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
        //Connection String  
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
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
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_DON order by DON_CODE", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            //datagridview1 Columns
            dataGridView1.Columns[0].HeaderText = "동";
            dataGridView1.Columns[1].HeaderText = "기숙사명";
            dataGridView1.Columns[0].Name = "Code";
            dataGridView1.Columns[1].Name = "Name";

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
            OracleConnection conn = new OracleConnection(cs);
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
                if (textBox2.Text == "")
                {
                    MessageBox.Show("명칭을 입력해주세요.");
                    return;
                }
            }

            // 오라클 연결
            string queryString = "select * from P22_LMG_TATM_DON where DON_CODE = '" + textBox1.Text + "'";
            using (OracleConnection connection = new OracleConnection(cs))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                connection.Open();
                OracleDataReader reader;
                reader = command.ExecuteReader();
                Boolean check1 = false;

                // Always call Read before accessing data.
                while (reader.Read())
                {
                    check1 = true;
                }
                if (check1)
                {
                    MessageBox.Show("이미 존재하는 동입니다.");
                    return;
                }
                else
                {
                    command.Connection = connection;

                    // SQL문 지정 및 INSERT 실행
                    this.dataGridView1.AllowUserToAddRows = true;
                    command.CommandText = "INSERT INTO P22_LMG_TATM_DON(DON_CODE, DON_NAME) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
                    MessageBox.Show("등록이 완료되었습니다.");
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // Always call Close when done reading.
                reader.Close();
                connection.Close();
            }
            reset_form();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string DOR1 = this.dataGridView1.CurrentRow.Cells["Code"].Value.ToString();
            string DOR2 = this.dataGridView1.CurrentRow.Cells["Name"].Value.ToString();

            textBox1.Text = DOR1;
            textBox2.Text = DOR2;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string DOR1 = this.dataGridView1.CurrentRow.Cells["Code"].Value.ToString();

            if (textBox1.Text != DOR1)
            {
                MessageBox.Show("동은 변경할 수 없습니다");
            }

            
            else
            {
                // 명령 객체 생성
                con = new OracleConnection(cs);
                con.Open();
                OracleCommand cmdd = new OracleCommand();
                cmdd.Connection = con;
                //학번이 텍박1과 동일한것을 찾아 이름을 변경해준다.
                cmdd.CommandText = "UPDATE P22_LMG_TATM_DON SET DON_NAME = '"+ textBox2.Text +"' WHERE DON_CODE = '"+ textBox1.Text +"'";
                MessageBox.Show("수정이 완료 되었습니다.");
                cmdd.ExecuteNonQuery();
                reset_form();
                con.Close();
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;            
            String indexvalue = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            con = new OracleConnection(cs);
            con.Open();
            OracleCommand cmdd = new OracleCommand();
            cmdd.Connection = con;
            //선택한 동과 같은 값을 db에서 찾아서 제거
            cmdd.CommandText = "DELETE P22_LMG_TATM_DON WHERE DON_CODE = '"+ indexvalue +"'";
            MessageBox.Show("삭제가 완료되었습니다.");
            cmdd.ExecuteNonQuery();
            reset_form();
            con.Close();

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_DON where DON_CODE like '" + textBox1.Text + "%' and DON_NAME like '"+ textBox2.Text + "%' order by DON_CODE", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4_Click(sender, e);
            }
        }
    }
    
}


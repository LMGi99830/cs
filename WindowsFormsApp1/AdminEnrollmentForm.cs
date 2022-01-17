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
    public partial class AdminEnrollmentForm : Form
    {
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        public AdminEnrollmentForm()
        {
            InitializeComponent();
        }

        public void btn_enrollment()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("아이디를 입력해주세요.");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("이름을 입력해주세요.");
                return;
            }
            else
            {
                con = new OracleConnection(css);
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into P22_LMG_TATM_ADMIN (ADM_ID, ADM_PW, ADM_NAME) values( :id, :pw, :name)";
                cmd.Parameters.Add(new OracleParameter("id", textBox1.Text.ToString()));
                cmd.Parameters.Add(new OracleParameter("pw", textBox2.Text.ToString()));
                cmd.Parameters.Add(new OracleParameter("name", textBox3.Text.ToString()));
                cmd.ExecuteNonQuery();
                MessageBox.Show("등록 완료");

                btn_load();
                con.Close();
            }
       }
    
           
        

        public void btn_load()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_ADMIN order by ADM_ID", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            Headertext(); //헤더텍스트 이름

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
        }
        public void Headertext()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "PW";
            dataGridView1.Columns[2].HeaderText = "이름";
        }

        private void AdminEnrollmentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_enrollment();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index1 = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[index1].Cells[0].Value.ToString(); //아이디
            textBox2.Text = dataGridView1.Rows[index1].Cells[1].Value.ToString(); //비번
            textBox3.Text = dataGridView1.Rows[index1].Cells[2].Value.ToString(); //이름

            if(textBox1.Text == "")
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }

            
        }
        public void btn_delete()
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            String id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            con = new OracleConnection(css);
            con.Open();
            OracleCommand cmdd = new OracleCommand();
            cmdd.Connection = con;
            //선택한 동과 같은 값을 db에서 찾아서 제거
            cmdd.CommandText = "DELETE P22_LMG_TATM_ADMIN WHERE ADM_ID = '" + id + "'";
            MessageBox.Show("삭제가 완료되었습니다.");
            cmdd.ExecuteNonQuery();
            btn_load();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn_delete();
        }

        public void btn_update()
        {
            con = new OracleConnection(css);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //선택한 동과 같은 값을 db에서 찾아서 제거
            cmd.CommandText = "update P22_LMG_TATM_ADMIN set ADM_NAME = :name , ADM_PW = :pw where ADM_ID = :id";
            cmd.Parameters.Add(new OracleParameter("name", textBox3.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("pw", textBox2.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("id", textBox1.Text.ToString()));
            
            MessageBox.Show("수정 되었습니다.");
            cmd.ExecuteNonQuery();
            btn_load();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btn_update();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_search();
            }
        }
        public void btn_search()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_ADMIN where ADM_NAME like '" + textBox4.Text + "%' order by ADM_ID", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}

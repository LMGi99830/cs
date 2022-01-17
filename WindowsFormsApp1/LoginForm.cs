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

    public partial class LoginForm : Form
    {
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new OracleConnection(css);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from P22_LMG_TATM_ADMIN where ADM_ID = :id and ADM_PW = :pw";
            cmd.Parameters.Add("id", textBox1.Text);
            cmd.Parameters.Add("pw", textBox2.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            Boolean check = false;
            while (dr.Read())
            {
                check = true;                
            }
            if(check)
            {
                MessageBox.Show("관리자로 로그인 됨");
                this.Visible = false; // 현재 폼 안보이게 하기
                AdminMenuForm frm = new AdminMenuForm(); // 새 폼 생성¬
                frm.Owner = this; // 새 폼의 오너를 현재 폼으로
                frm.Show(); // 새폼 보여 주 기
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호를 잘못입력하셨습니다.");
            }
            

            con.Close();
            dr.Close();
        }
    }

}
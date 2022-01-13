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
    public partial class application : Form
    {

        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        OracleCommand cmd;
        DataSet dtSet = new DataSet();

        public application()
        {
            InitializeComponent();


        }
        
        public void application_reset()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_PRO where PRO_STATE = '신청가능' order by PRO_YEAR ASC", con);
            dt = new DataTable();
            
            dt.Columns.Add("선택", typeof(bool));

            adapt.Fill(dt);
            dataGridView2.DataSource = dt;

            
            dataGridView2.Columns[1].HeaderText = "연도";
            dataGridView2.Columns[2].HeaderText = "계절";
            dataGridView2.Columns[3].HeaderText = "상태";
            dataGridView2.Columns[4].HeaderText = "실습명";
            dataGridView2.Columns[5].HeaderText = "정원";
            dataGridView2.Columns[6].HeaderText = "신청인원";
            dataGridView2.Columns[7].HeaderText = "실습시작일자";
            dataGridView2.Columns[8].HeaderText = "실습종료일자";
            dataGridView2.Columns[9].HeaderText = "실습시작시간";
            dataGridView2.Columns[10].HeaderText = "실습종료시간";
            dataGridView2.Columns[11].HeaderText = "자료처리시간";
            dataGridView2.Columns[12].HeaderText = "자료처리구분";
            dataGridView2.Columns[13].HeaderText = "자료처리자";
        }
        private void application_Load(object sender, EventArgs e)
        {
            application_reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApplicationForm Form1 = new ApplicationForm();
            Form1.Show();
        }
        private void reset_userform()
        {

            int rowindex = dataGridView2.CurrentCell.RowIndex;
            String year = dataGridView2.Rows[rowindex].Cells[1].Value.ToString(); // 연도
            String season = dataGridView2.Rows[rowindex].Cells[2].Value.ToString(); // 계절

            adapt = new OracleDataAdapter("select * from p22_lmg_tatm_app a" +
                "                                       where a.APP_YEAR = '" + year + "' and a.APP_SEASON = '" + season + "' and a.APP_APPRO = 'N'", con);
            dt = new DataTable();
            dt.Columns.Add("선택", typeof(bool));
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns[1].HeaderText = "학번";
            dataGridView1.Columns[2].HeaderText = "계절";
            dataGridView1.Columns[3].HeaderText = "연도";
            dataGridView1.Columns[4].HeaderText = "지원분야(코드)";
            dataGridView1.Columns[5].HeaderText = "연락처";
            dataGridView1.Columns[6].HeaderText = "평균평점";
            dataGridView1.Columns[7].HeaderText = "군대유무";
            dataGridView1.Columns[8].HeaderText = "자격증명";
            dataGridView1.Columns[9].HeaderText = "자격증발급일";
            dataGridView1.Columns[10].HeaderText = "자격증시행청";
            dataGridView1.Columns[11].HeaderText = "자격증명";
            dataGridView1.Columns[12].HeaderText = "자격증발급일";
            dataGridView1.Columns[13].HeaderText = "자격증시행청";
            dataGridView1.Columns[14].HeaderText = "어학능력(회화)";
            dataGridView1.Columns[15].HeaderText = "어학능력(독해)";
            dataGridView1.Columns[16].HeaderText = "어학능력(작문)";
            dataGridView1.Columns[17].HeaderText = "자기소개및각오";
            dataGridView1.Columns[18].HeaderText = "신청승인";
            dataGridView1.Columns[19].HeaderText = "자료처리일시";
            dataGridView1.Columns[20].HeaderText = "자료처리구분";
            dataGridView1.Columns[21].HeaderText = "자료처리자";

            //////////////////////////////////////////////


            int rowindex1 = dataGridView2.CurrentCell.RowIndex;
            String year1 = dataGridView2.Rows[rowindex1].Cells[1].Value.ToString(); // 연도
            String season1 = dataGridView2.Rows[rowindex1].Cells[2].Value.ToString(); // 계절

            adapt = new OracleDataAdapter("select * from p22_lmg_tatm_app a" +
                "                                       where a.APP_YEAR = '" + year1 + "' and a.APP_SEASON = '" + season1 + "' and a.APP_APPRO = 'Y'", con);
            dt = new DataTable();
            dt.Columns.Add("선택", typeof(bool));
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();

            dataGridView4.Columns[1].HeaderText = "학번";
            dataGridView4.Columns[2].HeaderText = "계절";
            dataGridView4.Columns[3].HeaderText = "연도";
            dataGridView4.Columns[4].HeaderText = "지원분야(코드)";
            dataGridView4.Columns[5].HeaderText = "연락처";
            dataGridView4.Columns[6].HeaderText = "평균평점";
            dataGridView4.Columns[7].HeaderText = "군대유무";
            dataGridView4.Columns[8].HeaderText = "자격증명";
            dataGridView4.Columns[9].HeaderText = "자격증발급일";
            dataGridView4.Columns[10].HeaderText = "자격증시행청";
            dataGridView4.Columns[11].HeaderText = "자격증명";
            dataGridView4.Columns[12].HeaderText = "자격증발급일";
            dataGridView4.Columns[13].HeaderText = "자격증시행청";
            dataGridView4.Columns[14].HeaderText = "어학능력(회화)";
            dataGridView4.Columns[15].HeaderText = "어학능력(독해)";
            dataGridView4.Columns[16].HeaderText = "어학능력(작문)";
            dataGridView4.Columns[17].HeaderText = "자기소개및각오";
            dataGridView4.Columns[18].HeaderText = "신청승인";
            dataGridView4.Columns[19].HeaderText = "자료처리일시";
            dataGridView4.Columns[20].HeaderText = "자료처리구분";
            dataGridView4.Columns[21].HeaderText = "자료처리자";





        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            reset_userform();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex1 = dataGridView2.CurrentCell.RowIndex;

            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                bool chk = (bool)dataGridView1.Rows[i].Cells[0].Value;
                Console.WriteLine(chk);
                if (chk == true)
                {
                    OracleConnection conn = new OracleConnection(css);
                    conn.Open();

                    // 명령 객체 생성
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;

                    // SQL문 지정 및 INSERT 실행

                    this.dataGridView4.AllowUserToAddRows = true;
                    cmd.CommandText = "Update P22_LMG_TATM_APP set APP_APPRO = 'Y' where APP_YEAR = :YEAR1  and APP_SEASON = :SEASON1 ";
                    cmd.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex1].Cells[1].Value.ToString()));
                    cmd.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex1].Cells[2].Value.ToString()));
                    cmd.ExecuteNonQuery();

                    UpdateStudentCount();

                    MessageBox.Show("승인되었습니다.");
                    con.Close();
                    reset_userform();
                    UpdateState();
                    application_reset();
                }
            }
        }
        public void UpdateStudentCount()
        {
            int rowindex1 = dataGridView2.CurrentCell.RowIndex;
            OracleConnection conn = new OracleConnection(css);
            conn.Open();

            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;

            cmd1.CommandText = "update P22_LMG_TATM_PRO set PRO_STCOUNT = (select count(*) PRO_STCOUNT from p22_lmg_tatm_app a" +
                "                         where a.APP_YEAR = :YEAR1 and a.APP_SEASON = :SEASON1 and a.APP_APPRO = 'Y') where pro_year = :YEAR1 " +
                "                         and PRO_SEASON = :SEASON1 ";
            cmd1.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex1].Cells[1].Value.ToString()));
            cmd1.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex1].Cells[2].Value.ToString()));
            cmd1.ExecuteNonQuery();
        }

        public void UpdateState()
        {

            int rowindex = dataGridView2.CurrentCell.RowIndex;
            OracleConnection con = new OracleConnection(css);
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select PRO_COUNT, PRO_STCOUNT from P22_LMG_TATM_PRO where PRO_COUNT = PRO_STCOUNT and PRO_YEAR = :YEAR1 and PRO_SEASON = :SEASON1";
            cmd.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex].Cells[1].Value.ToString()));
            cmd.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex].Cells[2].Value.ToString()));
            OracleDataReader dr = cmd.ExecuteReader();
            Boolean check = false;
            while (dr.Read())
            {
                check = true;
            }
            if (check)
            {
                OracleConnection conn = new OracleConnection(css);
                conn.Open();

                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;

                cmd1.CommandText = "update P22_LMG_TATM_PRO set PRO_STATE = '마감' where PRO_YEAR = :YEAR1 and PRO_SEASON = :SEASON1";
                cmd1.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex].Cells[1].Value.ToString()));
                cmd1.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex].Cells[2].Value.ToString()));
                cmd1.ExecuteNonQuery();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowindex1 = dataGridView2.CurrentCell.RowIndex;

            for (int i = 0; i < dataGridView4.RowCount - 1; i++)
            {
                bool chk = (bool)dataGridView4.Rows[i].Cells[0].Value;
                Console.WriteLine(chk);
                if (chk == true)
                {
                    OracleConnection conn = new OracleConnection(css);
                    conn.Open();

                    // 명령 객체 생성
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;

                    // SQL문 지정 및 INSERT 실행

                    this.dataGridView4.AllowUserToAddRows = true;
                    cmd.CommandText = "Update P22_LMG_TATM_APP set APP_APPRO = 'N' where APP_YEAR = :YEAR1  and APP_SEASON = :SEASON1 ";
                    cmd.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex1].Cells[1].Value.ToString()));
                    cmd.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex1].Cells[2].Value.ToString()));
                    cmd.ExecuteNonQuery();

                    UpdateStudentCount();

                    MessageBox.Show("반려되었습니다.");
                    reset_userform();
                    DeleteState();
                    application_reset();

                    con.Close();

                }
            }
        }

        public void DeleteState()
        {
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            OracleConnection con = new OracleConnection(css);
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select PRO_COUNT, PRO_STCOUNT from P22_LMG_TATM_PRO where PRO_COUNT = PRO_STCOUNT and PRO_YEAR = :YEAR1 and PRO_SEASON = :SEASON1";
            cmd.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex].Cells[1].Value.ToString()));
            cmd.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex].Cells[2].Value.ToString()));
            OracleDataReader dr = cmd.ExecuteReader();
            Boolean check = false;
            while (dr.Read())
            {
                check = false;
            }
            if (check)
            {
                OracleConnection conn = new OracleConnection(css);
                conn.Open();

                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;

                cmd1.CommandText = "update P22_LMG_TATM_PRO set PRO_STATE = '신청가능' where PRO_YEAR = :YEAR1 and PRO_SEASON = :SEASON1";
                cmd1.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex].Cells[1].Value.ToString()));
                cmd1.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex].Cells[2].Value.ToString()));
                cmd1.ExecuteNonQuery();
            }
        }
    }
}

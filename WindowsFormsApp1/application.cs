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
        #region 공통 선언 변수
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;       
        DataSet dtSet = new DataSet();
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";

        public static string STUNO = "";
        public static string YEAR = "";
        public static string SEASON = "";
        public static string FIE_CODE = "";
        public static string TELNO = "";
        public static string AVG = "";
        public static string MIL = "";
        public static string CER1 = "";
        public static string CER1_DATE = "";
        public static string CER1_PLACE = "";
        public static string CER2 = "";
        public static string CER2_DATE = "";
        public static string CER2_PLACE = "";
        public static string ENG_CON = "";
        public static string ENG_REA = "";
        public static string ENG_WRT = "";
        public static string SELF = "";
        #endregion
        public application()
        {
            InitializeComponent();


        }
         public void btn_load()
        {
               
            con = new OracleConnection(css);
            con.Open();
            String sql = @"select *
                                from P22_LMG_TATM_PRO
                                where to_date(PRO_DAYS) between sysdate and sysdate + 16
                                and PRO_COUNT != PRO_STCOUNT";

            adapt = new OracleDataAdapter(sql, con);
            dt = new DataTable();
            
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            dataGridView2.Columns[0].HeaderText = "연도";
            dataGridView2.Columns[1].HeaderText = "계절";            
            dataGridView2.Columns[2].HeaderText = "실습명";
            dataGridView2.Columns[3].HeaderText = "정원";
            dataGridView2.Columns[4].HeaderText = "신청인원";
            dataGridView2.Columns[5].HeaderText = "실습시작일자";
            dataGridView2.Columns[6].HeaderText = "실습종료일자";
            dataGridView2.Columns[7].HeaderText = "실습시작시간";
            dataGridView2.Columns[8].HeaderText = "실습종료시간";
            dataGridView2.Columns[9].HeaderText = "자료처리시간";
            dataGridView2.Columns[10].HeaderText = "자료처리구분";
            dataGridView2.Columns[11].HeaderText = "자료처리자";

            dataGridView2.Columns[0].Name = "Year";
            dataGridView2.Columns[1].Name = "Season";

            
        }
        private void application_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex1 = dataGridView2.CurrentCell.RowIndex;
            SetValueForText1 = dataGridView2.Rows[rowindex1].Cells[0].Value.ToString();
            SetValueForText2 = dataGridView2.Rows[rowindex1].Cells[1].Value.ToString();

            OracleConnection con = new OracleConnection(css);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from P22_LMG_TATM_PRO p where p.PRO_SEASON = :SEASON and p.PRO_YEAR = :YEAR" +
                "                         and p.PRO_COUNT = (select count(*) from P22_LMG_TATM_APP a where a.APP_SEASON = '동계'" +
                "                         and a.APP_YEAR = 2021)";
            cmd.Parameters.Add(new OracleParameter("SEASON", SetValueForText2.ToString()));
            cmd.Parameters.Add(new OracleParameter("YEAR", SetValueForText1.ToString()));
            OracleDataReader dr = cmd.ExecuteReader();
            Boolean check1 = false;
            while (dr.Read())
            {
                check1 = true;
            }

            if (check1)
            {
                MessageBox.Show("현재 승인 대기자가 많습니다. 나중에 다시 이용해주세요");
                return;
            }
            else
            {
                ApplicationForm Form1 = new ApplicationForm();
                Form1.Show();
            }
        }

        
        public void reset_userform()
        {

            con = new OracleConnection(css);
            con.Open();
            int rowindex6 = dataGridView2.CurrentCell.RowIndex;
            String year = dataGridView2.Rows[rowindex6].Cells[0].Value.ToString(); // 연도
            String season = dataGridView2.Rows[rowindex6].Cells[1].Value.ToString(); // 계절

            adapt = new OracleDataAdapter("select * from p22_lmg_tatm_app a" +
                "                                       where a.APP_YEAR = '" + year + "' and a.APP_SEASON = '" + season + "' and a.APP_APPRO = 'N'", con);
            dt = new DataTable();

            
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns[0].HeaderText = "학번";
            dataGridView1.Columns[1].HeaderText = "계절";
            dataGridView1.Columns[2].HeaderText = "연도";
            dataGridView1.Columns[3].HeaderText = "지원분야(코드)";
            dataGridView1.Columns[4].HeaderText = "연락처";
            dataGridView1.Columns[5].HeaderText = "평균평점";
            dataGridView1.Columns[6].HeaderText = "군대유무";
            dataGridView1.Columns[7].HeaderText = "자격증명";
            dataGridView1.Columns[8].HeaderText = "자격증발급일";
            dataGridView1.Columns[9].HeaderText = "자격증시행청";
            dataGridView1.Columns[10].HeaderText = "자격증명";
            dataGridView1.Columns[11].HeaderText = "자격증발급일";
            dataGridView1.Columns[12].HeaderText = "자격증시행청";
            dataGridView1.Columns[13].HeaderText = "어학능력(회화)";
            dataGridView1.Columns[14].HeaderText = "어학능력(독해)";
            dataGridView1.Columns[15].HeaderText = "어학능력(작문)";
            dataGridView1.Columns[16].HeaderText = "자기소개및각오";
            dataGridView1.Columns[17].HeaderText = "신청승인";
            dataGridView1.Columns[18].HeaderText = "자료처리일시";
            dataGridView1.Columns[19].HeaderText = "자료처리구분";
            dataGridView1.Columns[20].HeaderText = "자료처리자";

          

            /////////////////////////////////////////////

        }
        public void reset_userform2()
        {

            con = new OracleConnection(css);
            con.Open();
            int rowindex5= dataGridView2.CurrentCell.RowIndex;
            String year1 = dataGridView2.Rows[rowindex5].Cells[0].Value.ToString(); // 연도
            String season1 = dataGridView2.Rows[rowindex5].Cells[1].Value.ToString(); // 계절

            adapt = new OracleDataAdapter("select * from p22_lmg_tatm_app a" +
                "                                       where a.APP_YEAR = '" + year1 + "' and a.APP_SEASON = '" + season1 + "' and a.APP_APPRO = 'Y'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();

            dataGridView4.Columns[0].HeaderText = "학번";
            dataGridView4.Columns[1].HeaderText = "계절";
            dataGridView4.Columns[2].HeaderText = "연도";
            dataGridView4.Columns[3].HeaderText = "지원분야(코드)";
            dataGridView4.Columns[4].HeaderText = "연락처";
            dataGridView4.Columns[5].HeaderText = "평균평점";
            dataGridView4.Columns[6].HeaderText = "군대유무";
            dataGridView4.Columns[7].HeaderText = "자격증명";
            dataGridView4.Columns[8].HeaderText = "자격증발급일";
            dataGridView4.Columns[9].HeaderText = "자격증시행청";
            dataGridView4.Columns[10].HeaderText = "자격증명";
            dataGridView4.Columns[11].HeaderText = "자격증발급일";
            dataGridView4.Columns[12].HeaderText = "자격증시행청";
            dataGridView4.Columns[13].HeaderText = "어학능력(회화)";
            dataGridView4.Columns[14].HeaderText = "어학능력(독해)";
            dataGridView4.Columns[15].HeaderText = "어학능력(작문)";
            dataGridView4.Columns[16].HeaderText = "자기소개및각오";
            dataGridView4.Columns[17].HeaderText = "신청승인";
            dataGridView4.Columns[18].HeaderText = "자료처리일시";
            dataGridView4.Columns[19].HeaderText = "자료처리구분";
            dataGridView4.Columns[20].HeaderText = "자료처리자";

            dataGridView1.CurrentCell = null;
            dataGridView4.CurrentCell = null;


        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            
            reset_userform();
            reset_userform2();
            dataGridView1.CurrentCell = null;
            dataGridView4.CurrentCell = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count.ToString() == "0")
            {
                MessageBox.Show("승인 시키고 싶은 학생을 선택해주세요.");
                return;
            }
            else
            {
                int rowindex1 = dataGridView1.CurrentCell.RowIndex;
                OracleConnection conn = new OracleConnection(css);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                this.dataGridView4.AllowUserToAddRows = true;
                cmd.CommandText = "Update P22_LMG_TATM_APP set APP_APPRO = 'Y' where APP_STUNO = :STUNO1";
                cmd.Parameters.Add(new OracleParameter("STUNO1", dataGridView1.Rows[rowindex1].Cells[0].Value.ToString()));
                cmd.ExecuteNonQuery();
                UpdateStudentCount();
                MessageBox.Show("승인되었습니다.");
                conn.Close();
                reset_userform();
                reset_userform2();
                UpdateState();
                btn_load();
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
            cmd1.Parameters.Add(new OracleParameter("YEAR1", dataGridView2.Rows[rowindex1].Cells[0].Value.ToString()));
            cmd1.Parameters.Add(new OracleParameter("SEASON1", dataGridView2.Rows[rowindex1].Cells[1].Value.ToString()));
            cmd1.ExecuteNonQuery();
            con.Close();
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
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            OracleConnection con = new OracleConnection(css);
            con.Open();

            OracleCommand cmdE = con.CreateCommand();
            cmdE.CommandText = "select * from P22_LMG_TATM_ATT where ATT_STUNO = :STUNOO";
            cmdE.Parameters.Add(new OracleParameter("STUNOO", dataGridView2.Rows[rowindex].Cells[0].Value.ToString()));            
            OracleDataReader drrl = cmdE.ExecuteReader();
            Boolean check = false;
            while (drrl.Read())
            {
                check = true;
            }
            if(check)
            {
                MessageBox.Show("현재 출석중인 학생은 반려 시킬 수 없습니다.");
                return;
            }
                if (dataGridView4.SelectedCells.Count.ToString() == "0")
            {
                MessageBox.Show("반려 시키고 싶은 학생을 선택해주세요.");
                return;
            }
            else
            {
                int rowindex1 = dataGridView4.CurrentCell.RowIndex;

                OracleConnection conn = new OracleConnection(css);
                conn.Open();

                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                // SQL문 지정 및 INSERT 실행

                this.dataGridView4.AllowUserToAddRows = true;
                cmd.CommandText = "Update P22_LMG_TATM_APP set APP_APPRO = 'N' where APP_STUNO = :STUNO1";
                cmd.Parameters.Add(new OracleParameter("STUNO1", dataGridView4.Rows[rowindex1].Cells[0].Value.ToString()));
                cmd.ExecuteNonQuery();

                UpdateStudentCount();

                MessageBox.Show("반려되었습니다.");

                reset_userform();
                reset_userform2();
                DeleteState();
                btn_load();
                conn.Close();
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
            UpdateStudentCount();
        }
    
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView4.ClearSelection();
        }

        #region 실습목록 삭제 기능
        public void DeleteDatagridview2()
        {
            if (dataGridView2.SelectedCells.Count.ToString() == "0")
            {
                MessageBox.Show("지우고 싶은 실습을 먼저 선택해주세요!");
                return;
            }
            else
            {
                int rowindex1 = dataGridView2.CurrentCell.RowIndex;
                SetValueForText1 = dataGridView2.Rows[rowindex1].Cells[0].Value.ToString();
                SetValueForText2 = dataGridView2.Rows[rowindex1].Cells[1].Value.ToString();

                OracleConnection con = new OracleConnection(css);
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "select count(*) from P22_LMG_TATM_APP a where a.APP_SEASON = :SEASON and a.APP_YEAR = :YEAR";
                cmd.Parameters.Add(new OracleParameter("SEASON", SetValueForText2.ToString()));
                cmd.Parameters.Add(new OracleParameter("YEAR", SetValueForText1.ToString()));
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int a = int.Parse(dr.GetString(0));
                    if (a != 0)
                    {
                        MessageBox.Show("현재 신청한 또는 승인된 학생들이 존재해서 삭제할 수 없습니다.");
                        return;
                    }
                    else
                    {

                        OracleCommand cmd1 = con.CreateCommand();
                        cmd1.CommandText = "delete from p22_lmg_tatm_pro where pro_year = :YEAR1 and pro_season = :SEASON1";
                        cmd1.Parameters.Add(new OracleParameter("YEAR1", SetValueForText1));
                        cmd1.Parameters.Add(new OracleParameter("SEASON1", SetValueForText2));
                        cmd1.ExecuteReader();
                        MessageBox.Show("삭제가 완료되었습니다.");
                        btn_load();
                    }
                }
            }

            con.Close();
        }
        #endregion

        public void DeleteDatagridview1()
        {
            if (dataGridView1.SelectedCells.Count.ToString() == "0")
            {
                MessageBox.Show("지우고 싶은 학생을 선택해주세요!");
                return;
            }
            else
            {
                int rowindex1 = dataGridView1.CurrentCell.RowIndex;
                SetValueForText1 = dataGridView1.Rows[rowindex1].Cells[0].Value.ToString();
                OracleConnection con = new OracleConnection(css);
                con.Open();
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = "delete from p22_lmg_tatm_app where app_stuno = :STUNO1";
                cmd1.Parameters.Add(new OracleParameter("STUNO1", SetValueForText1));                    
                cmd1.ExecuteReader();
                MessageBox.Show("삭제가 완료되었습니다.");
                btn_load();
                reset_userform();
                con.Close();
            }
        }

        public void DeleteDatagridview4()
        {
            if (dataGridView4.SelectedCells.Count.ToString() == "0")
            {
                MessageBox.Show("지우고 싶은 학생을 선택해주세요!");
                return;
            }
            else
            {
                int rowindex1 = dataGridView4.CurrentCell.RowIndex;
                SetValueForText1 = dataGridView4.Rows[rowindex1].Cells[0].Value.ToString();
                OracleConnection con = new OracleConnection(css);
                con.Open();
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = "delete from p22_lmg_tatm_app where app_stuno = :STUNO1";
                cmd1.Parameters.Add(new OracleParameter("STUNO1", SetValueForText1));
                cmd1.ExecuteReader();
                MessageBox.Show("삭제가 완료되었습니다.");
                btn_load();
                DeleteState();                
                reset_userform2();
                con.Close();
            }
        }

        public void btn_delete()
        {
            if (dataGridView1.SelectedCells.Count.ToString() == "0" && dataGridView4.SelectedCells.Count.ToString() == "0")
            {
                DeleteDatagridview2();
            }
            else
            {
                if (dataGridView2.SelectedCells.Count.ToString() != "0" && dataGridView4.SelectedCells.Count.ToString() == "0")
                {
                    DeleteDatagridview1();
                }
                else
                {
                    DeleteDatagridview4();
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            dataGridView4.ClearSelection();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}

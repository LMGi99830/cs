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
        int count = 0;

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

        public void btn_load()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select pro_year, pro_season, pro_name, pro_days, pro_daye, PRO_TIMES, PRO_TIMEE, datasys1, datasys2, datasys3" +
                " from P22_LMG_TATM_PRO order by PRO_YEAR ASC", con);
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
            dataGridView1.Columns[1].Name = "Season";
            dataGridView1.Columns[2].Name = "Name";

            count = count + 1;
        }

        public void btn_update()
        {
            if (count == 0)
            {
                MessageBox.Show("조회버튼 클릭 후 수정하고 싶은 값을 더블클릭 해주세요");
                return;
            }
            else if (textBox6.Text == "조퇴" || textBox6.Text == "지각 조퇴")
            {
                if (textBox18.Text == "")
                {
                    MessageBox.Show("조퇴사유를 작성해주세요!");
                    return;
                }
                else
                {
                    con = new OracleConnection(css);
                    con.Open();
                    OracleCommand cmd = con.CreateCommand();
                    // 명령 객체 생성                        
                    String updateJSQL = @"UPDATE P22_LMG_TATM_DIL
                                                    SET DIL_JREASON = :JREA1
                                                    WHERE DIL_DATE = :DATE1
                                                      AND DIL_STUNO = :STUNO1";
                    cmd.CommandText = updateJSQL;
                    cmd.Parameters.Add(new OracleParameter("JREA1", textBox18.Text));
                    cmd.Parameters.Add(new OracleParameter("DATE1", textBox10.Text));
                    cmd.Parameters.Add(new OracleParameter("STUNO1", textBox16.Text));
                    cmd.ExecuteNonQuery();

                    Update_time();
                    btn_load();
                    con.Close();
                }
            }
            else if (textBox6.Text == "결근")
            {
                if (textBox18.Text == "")
                {
                    MessageBox.Show("결근사유를 작성해주세요!");
                    return;
                }
                else
                {
                    con = new OracleConnection(css);
                    con.Open();
                    OracleCommand cmd = con.CreateCommand();
                    // 명령 객체 생성                        
                    String updateSQL = @"UPDATE P22_LMG_TATM_DIL SET
                                                DIL_GREASON = :JREA WHERE DIL_DATE = :DATE AND DIL_STUNO = :STUNO";
                    cmd.CommandText = updateSQL;
                    cmd.Parameters.Add(new OracleParameter("JREA", textBox18.Text));
                    cmd.Parameters.Add(new OracleParameter("DATE", textBox10.Text));
                    cmd.Parameters.Add(new OracleParameter("STUNO", textBox16.Text));
                    cmd.ExecuteNonQuery();

                    Update_time();

                    MessageBox.Show("수정이 완료되었습니다.");
                    con.Close();
                    btn_load();
                }
            }
            else
            {
                if (textBox6.Text != "조퇴" && textBox6.Text != "결근" && textBox18.Text != "")
                {
                    MessageBox.Show("사유는 조퇴 또는 결근인 사람만 작성가능합니다.");
                    return;
                }
                else
                {

                    Update_time();
                }

            }
            con.Close();
        }

        public void Update_time()
        {
            con = new OracleConnection(css);
            con.Open();
            OracleCommand cmd1 = con.CreateCommand();
            // 명령 객체 생성                         
            String updateTIMESQL = @"UPDATE P22_LMG_TATM_ATT
                                            SET ATT_FTIME = :FTIME,
                                                ATT_TTIME = :TTIME
                                            WHERE ATT_DATE = :DATE1
                                              AND ATT_STUNO = :STUNO";
            cmd1.CommandText = updateTIMESQL;
            cmd1.Parameters.Add(new OracleParameter("FTIME", textBox17.Text));
            cmd1.Parameters.Add(new OracleParameter("TTIME", textBox23.Text));
            cmd1.Parameters.Add(new OracleParameter("DATE1", textBox10.Text));
            cmd1.Parameters.Add(new OracleParameter("STUNO", textBox16.Text));
            cmd1.ExecuteNonQuery();


            int rowindex = dataGridView1.CurrentCell.RowIndex;
            String dayy = dataGridView1.Rows[rowindex].Cells[5].Value.ToString(); // 명칭
            String dayE = dataGridView1.Rows[rowindex].Cells[6].Value.ToString(); // 명칭
            int state = 0; //근태 상태를 나타내는 함수

            int in_ftime = int.Parse(dayy); //출석해야하는 실습의 시간
            int in_ttime = int.Parse(dayE); //퇴근해야하는 실습의 시간
            int in_sysftime = int.Parse(textBox17.Text); //출석을 눌렀을때의 시간
            int in_systtime = int.Parse(textBox23.Text); //퇴근을 눌렀을때의 시간

            int time_cha = 0;
            if (in_sysftime <= in_ftime && in_ttime <= in_systtime)
            {
                state = 1;

            }
            else if (in_sysftime > in_ftime && in_systtime < in_ttime)
            {
                state = 5;
                time_cha = in_sysftime - in_ftime;
            }
            else if (in_sysftime > in_ftime)
            {
                state = 2;
                time_cha = in_sysftime - in_ftime;
            }
            
            else if (textBox17.Text == null && textBox23.Text == null)
            {
                state = 4;
            }
            else
            {
                state = 3;
            }
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = con;
            cmd2.CommandText = @"UPDATE P22_LMG_TATM_DIL SET DIL_DILCODE = :STATE1, DIL_DILTIME = :Difference1
                                                WHERE DIL_STUNO = :STUNO1 AND DIL_DATE = :DATE1";
            cmd2.Parameters.Add(new OracleParameter("STATE1", state));
            cmd2.Parameters.Add(new OracleParameter("Difference1", time_cha));
            cmd2.Parameters.Add(new OracleParameter("STUNO1", textBox16.Text));
            cmd2.Parameters.Add(new OracleParameter("DATE1", textBox10.Text));
            cmd2.ExecuteNonQuery();

            MessageBox.Show("수정이 완료 되었습니다.");            
            dataGridViewCellClick();
            con.Close();
        }

        public void dataGridViewCellClick()
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            String indexvalue = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //연도
            String indexvalue1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString(); // 계절
            String indexvalue2 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString(); // 명칭
            String dayy = dataGridView1.Rows[rowindex].Cells[3].Value.ToString(); // 명칭
            String days = dataGridView1.Rows[rowindex].Cells[4].Value.ToString(); // 명칭

            textBox2.Text = indexvalue;
            textBox11.Text = indexvalue1;
            textBox5.Text = indexvalue2;

            con = new OracleConnection(css);
            con.Open();
            string sql = $@"select d.*
                                    from P22_LMG_TATM_DIL d, P22_LMG_TATM_APP p
                                    where d.DIL_STUNO = p.APP_STUNO
                                    and p.APP_APPRO = 'Y'
                                    and p.APP_YEAR = '{indexvalue}'
                                    and p.APP_SEASON = '{indexvalue1}'
                                    and d.dil_dilcode != 6
                                    order by d.dil_dilcode";
            adapt = new OracleDataAdapter(sql, con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            dataGridView2.Columns[0].HeaderText = "근무일자";
            dataGridView2.Columns[1].HeaderText = "학번";
            dataGridView2.Columns[2].HeaderText = "근무코드";
            dataGridView2.Columns[3].HeaderText = "지각시간";
            dataGridView2.Columns[4].HeaderText = "조퇴사유";
            dataGridView2.Columns[5].HeaderText = "결근사유";

            dataGridView2.Columns[0].Name = "date";
            dataGridView2.Columns[1].Name = "stuno";
            dataGridView2.Columns[2].Name = "code";
            dataGridView2.Columns[3].Name = "early";
            dataGridView2.Columns[4].Name = "jreason";
            dataGridView2.Columns[5].Name = "greason";

            textBox16.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AttendanceCodeForm Form1 = new AttendanceCodeForm();
            Form1.ShowDialog();
            textBox12.Text = Form1._textBox1.ToString();
            textBox9.Text = Form1._textBox2.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewCellClick();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            textBox18.Text = "";
            int rowindex2 = dataGridView2.CurrentCell.RowIndex;
            String date = dataGridView2.Rows[rowindex2].Cells[0].Value.ToString(); // 근무일자 
            String stuno = dataGridView2.Rows[rowindex2].Cells[1].Value.ToString(); // 학번
            String code = dataGridView2.Rows[rowindex2].Cells[2].Value.ToString(); // 근무코드
            String early = dataGridView2.Rows[rowindex2].Cells[3].Value.ToString(); // 지각시간
            String jrea = dataGridView2.Rows[rowindex2].Cells[4].Value.ToString(); // 조퇴사유
            String grea = dataGridView2.Rows[rowindex2].Cells[4].Value.ToString(); // 결근사유
            
            textBox16.Text = stuno;
            textBox10.Text = date;
            textBox20.Text = early;

            // 2 11
            OracleConnection con = new OracleConnection(css);
            con.Open();
            OracleCommand cmdd = new OracleCommand();
            cmdd.Connection = con;
            cmdd.CommandText = "select STU_NAME , DEF_NAME from P22_LMG_TATM_STU stu , P22_LMG_TATM_DEF def where stu.STU_DEPART = def.DEF_CODE and stu.STU_STUNO = :STUNO";
            cmdd.Parameters.Add(new OracleParameter("STUNO", stuno));
            OracleDataReader drr = cmdd.ExecuteReader();
            while (drr.Read())
            {
                textBox3.Text = drr.GetString(0);
                textBox4.Text = drr.GetString(1);
            }

            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "select * from P22_LMG_TATM_ATT where ATT_DATE = :YEAR and ATT_STUNO = :STUNO";
            cmd1.Parameters.Add(new OracleParameter("YEAR", date));
            cmd1.Parameters.Add(new OracleParameter("STUNO", stuno));
            OracleDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                textBox17.Text = dr1.GetString(2);
                textBox23.Text = dr1.GetString(3);
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;   
            cmd.CommandText = "select DILC_NAME from P22_LMG_TATM_DILC where DILC_CODE = :CODE1";
            cmd.Parameters.Add(new OracleParameter("CODE1", code));
            OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String codename = dr.GetString(0);
                    textBox6.Text = codename;
                    if(dr.GetString(0).Equals("결근"))
                    {
                        textBox17.Text = "";
                        textBox23.Text = "";
                    }
                }
                dr.Close();
            
            if(textBox6.Text == "조퇴")
            {
                textBox18.Text = jrea;
            }
            else if(textBox6.Text == "결근")
            {
                textBox18.Text = grea;
            }
            else if (textBox6.Text == "지각 조퇴")
            {
                textBox18.Text = grea;
            }
            dr1.Close();
            con.Close();

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

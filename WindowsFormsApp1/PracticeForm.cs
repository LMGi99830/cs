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
using System.IO;
using System.Globalization;



namespace WindowsFormsApp1
{
    public partial class PracticeForm : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        int count = 0;
        int nBetweenDayCnt = 0;
        public PracticeForm()
        {
            InitializeComponent();
            panel1.TabStop = false;
            panel2.TabStop = false;
            panel4.TabStop = false;
        }

        public void btn_enrollment()
        {
            if (String.IsNullOrEmpty(dateTimePicker4.Text))
            {
                MessageBox.Show("연도를 입력해주세요");
                return;
            }
            else if (String.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("계절을 선택해주세요");
                return;
            }
            else if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("실습명을 입력해주세요");
                return;
            }
            else if (String.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("정원을 입력해주세요");
                return;
            }
            else if (String.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("실습 시작 기간을 입력해주세요");
                return;
            }
            else if (String.IsNullOrEmpty(dateTimePicker2.Text))
            {
                MessageBox.Show("실습 종료 기간을 입력해주세요");
                return;
            }
            else if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("실습 시작 시간을 입력해주세요");
                return;
            }
            else if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("실습 종료 시간을 입력해주세요");
                return;
            }
            int start_time = int.Parse(textBox1.Text);
            int end_time = int.Parse(textBox2.Text);
            if (start_time > 2359 || end_time > 2359)
            {
                MessageBox.Show("시간을 다시 입력해주세요(24시는 00시로 입력합니다.)");
                return;
            }
            else
            {
                OracleConnection con = new OracleConnection(cs);
                con.Open();
                OracleCommand cmd1 = con.CreateCommand();
                cmd1.CommandText = "select PRO_YEAR, PRO_SEASON from P22_LMG_TATM_PRO where PRO_YEAR = :YEAR and PRO_SEASON = :SEASON";
                cmd1.Parameters.Add(new OracleParameter("YEAR1", dateTimePicker4.Text.ToString()));
                cmd1.Parameters.Add(new OracleParameter("SEASON1", comboBox2.Text.ToString()));
                OracleDataReader dr = cmd1.ExecuteReader();
                Boolean check1 = false;
                while (dr.Read())
                {
                    check1 = true;
                }

                if (check1)
                {
                    MessageBox.Show("연도와 계절은 변경할 수 없습니다.");
                    return;
                }
                else
                {
                    // 명령 객체 생성
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"insert into P22_LMG_TATM_PRO (
                                                PRO_YEAR, PRO_SEASON, PRO_NAME, PRO_COUNT, PRO_STCOUNT, PRO_DAYS, PRO_DAYE,
                                                PRO_TIMES, PRO_TIMEE)
                                            values (:YEAR,:SEASON,:NAME,:COUNT, :STCOUNT, :DAYS,:DAYE,:TIMES,:TIMEE)";
                    cmd.Parameters.Add(new OracleParameter("YEAR", dateTimePicker4.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("SEASON", comboBox2.Text.ToString()));                    
                    cmd.Parameters.Add(new OracleParameter("NAME", textBox3.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("COUNT", textBox6.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("STCOUNT", "0"));
                    cmd.Parameters.Add(new OracleParameter("DAYS", dateTimePicker1.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("DAYE", dateTimePicker2.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("TIMES", textBox1.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("TIMEE", textBox2.Text.ToString()));

                    cmd.ExecuteNonQuery();

                    hoilday();
                    MessageBox.Show("등록이 완료되었습니다.");
                }
                con.Close();
                btn_load();
            }
        }

        public void hoilday()
        {
            nBetweenDayCnt = 0;
            int i = 0;
            DateTime temp;
            while (true)
            {
                temp = dateTimePicker1.Value.Date.AddDays(i);
                if (temp.DayOfWeek == DayOfWeek.Sunday || temp.DayOfWeek == DayOfWeek.Saturday)
                {
                    String date1 = "휴일";
                    String date2 = temp.Date.ToString("yyyyMMdd");
                    OracleConnection con = new OracleConnection(cs);
                    con.Open();
                    OracleCommand cmd1 = new OracleCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = "INSERT INTO P22_LMG_TATM_HOI(HOI_YEAR, HOI_SEASON, HOI_DATE, HOI_NAME)" +
                        "VALUES(:YEAR1,:SEASON1,:DAY2, :DAY1)";
                    cmd1.Parameters.Add(new OracleParameter("YEAR1", dateTimePicker4.Text.ToString()));
                    cmd1.Parameters.Add(new OracleParameter("SEASON1", comboBox2.Text.ToString()));
                    cmd1.Parameters.Add(new OracleParameter("DAY2", date2));
                    cmd1.Parameters.Add(new OracleParameter("DAY1", date1));
                    cmd1.ExecuteNonQuery();
                }
                    if (temp.DayOfWeek != DayOfWeek.Sunday && temp.DayOfWeek != DayOfWeek.Saturday)
                        nBetweenDayCnt++;
                    TimeSpan Between = dateTimePicker2.Value.Date - temp;
                    if (Between.Days <= 0)
                    {
                        break;
                    }
                    temp = dateTimePicker1.Value.Date.AddDays(i);
                    i++;
                }
            }

        public void btn_load()
        {
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_PRO order by PRO_YEAR", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            count = count + 1;
            dataHearder(); //헤더텍스트 이름
        }

        public void dataHearder()
        {
            dataGridView1.Columns[0].HeaderText = "연도";
            dataGridView1.Columns[1].HeaderText = "계절";            
            dataGridView1.Columns[2].HeaderText = "실습명";
            dataGridView1.Columns[3].HeaderText = "정원";
            dataGridView1.Columns[4].HeaderText = "신청인원";
            dataGridView1.Columns[5].HeaderText = "실습시작일자";
            dataGridView1.Columns[6].HeaderText = "실습종료일자";
            dataGridView1.Columns[7].HeaderText = "실습시작시간";
            dataGridView1.Columns[8].HeaderText = "실습종료시간";
            dataGridView1.Columns[9].HeaderText = "자료처리시간";
            dataGridView1.Columns[10].HeaderText = "자료처리구분";
            dataGridView1.Columns[11].HeaderText = "자료처리자";
        }

        public void btn_update()
        {
            if (count == 0)
            {
                MessageBox.Show("조회버튼 클릭 후 수정하고 싶은 값을 더블클릭 해주세요");
                return;
            }
            else
            {
                con = new OracleConnection(cs);
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                // 명령 객체 생성                        
                String updateSQL = @"UPDATE P22_LMG_TATM_PRO SET
                                                PRO_NAME = :NAME, PRO_COUNT = :COUNT, PRO_DAYS = :DAYS, PRO_DAYE = :DAYE, PRO_TIMES = :TIMES,
                                                PRO_TIMEE = :TIMEE WHERE PRO_YEAR = :YEAR and PRO_SEASON = :SEASON";
                // a는 DOR_USE가 체크 되있는지 확인하는 변수       
                cmd.CommandText = updateSQL;
                cmd.Parameters.Add(new OracleParameter("NAME", textBox3.Text));
                cmd.Parameters.Add(new OracleParameter("COUNT", textBox6.Text));
                cmd.Parameters.Add(new OracleParameter("DAYS", dateTimePicker1.Text));
                cmd.Parameters.Add(new OracleParameter("DAYE", dateTimePicker2.Text));
                cmd.Parameters.Add(new OracleParameter("TIMES", textBox1.Text));
                cmd.Parameters.Add(new OracleParameter("TIMEE", textBox2.Text));
                cmd.Parameters.Add(new OracleParameter("YEAR", dateTimePicker4.Text));
                cmd.Parameters.Add(new OracleParameter("SEASON", comboBox2.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("수정이 완료되었습니다.");
                con.Close();
                btn_load();
            }

        }

        public void btn_delete()
        {
            if (count == 0)
            {
                MessageBox.Show("조회버튼 클릭 후 삭제하고 싶은 행을 선택해주세요.");
                return;
            }
            else
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                String yearindex = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
                String seasonindex = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
                String indexvalue1 = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();

                if (indexvalue1 != "0")
                {
                    MessageBox.Show("신청한 학생이 있는 경우에는 삭제가 불가능합니다.");
                    return;
                }
                else
                {
                    con = new OracleConnection(cs);
                    con.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;                    
                    cmd.CommandText = "DELETE P22_LMG_TATM_PRO WHERE PRO_YEAR = :YEAR_IN and PRO_SEASON = :SEASON_IN";
                    cmd.Parameters.Add(new OracleParameter("YEAR_IN", yearindex));
                    cmd.Parameters.Add(new OracleParameter("SEASON_IN", seasonindex));
                    cmd.ExecuteNonQuery();

                    OracleCommand cmd1 = new OracleCommand();
                    cmd1.Connection = con;                    
                    cmd1.CommandText = "DELETE P22_LMG_TATM_HOI WHERE HOI_YEAR = :YEAR_HO and HOI_SEASON = :SEASON_HO";
                    cmd1.Parameters.Add(new OracleParameter("YEAR_HO", yearindex));
                    cmd1.Parameters.Add(new OracleParameter("SEASON_HO", seasonindex));
                    MessageBox.Show("삭제가 완료되었습니다.");
                    cmd1.ExecuteNonQuery();
                    btn_load();
                    con.Close();
                }
            }


        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker4.Enabled = false;
            comboBox2.Enabled = false;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[rowindex].Cells[0].Value.ToString() == "")
            {
                dateTimePicker4.Enabled = true;
                comboBox2.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox6.Text = "";
            }
            else
            {
                DateTime dateValue;
                DateTime dateValue1;
                DateTime dateValue2;

                String P_YEAR = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); // 연도
                String P_SEASON = dataGridView1.Rows[rowindex].Cells[1].Value.ToString(); // 계절
                String P_NAME = dataGridView1.Rows[rowindex].Cells[2].Value.ToString(); // 이름
                String P_COUNT = dataGridView1.Rows[rowindex].Cells[3].Value.ToString(); // 정원
                String P_DAYS = dataGridView1.Rows[rowindex].Cells[5].Value.ToString(); // 실습 시작 기간
                String P_DAYE = dataGridView1.Rows[rowindex].Cells[6].Value.ToString(); // 실습 종료 기간
                String P_TIME = dataGridView1.Rows[rowindex].Cells[7].Value.ToString(); // 실습 시작 시간
                String P_TIMES = dataGridView1.Rows[rowindex].Cells[8].Value.ToString(); //실습 종료 시간       

                DateTime.TryParseExact(P_YEAR, "yyyy", null, DateTimeStyles.None, out dateValue2);
                dateTimePicker4.Value = dateValue2;
                comboBox2.Text = P_SEASON;
                textBox3.Text = P_NAME;
                textBox6.Text = P_COUNT;

                DateTime.TryParseExact(P_DAYS, "yyyyMMdd", null, DateTimeStyles.None, out dateValue);
                DateTime.TryParseExact(P_DAYE, "yyyyMMdd", null, DateTimeStyles.None, out dateValue1);
                dateTimePicker1.Value = dateValue;
                dateTimePicker2.Value = dateValue1;
                textBox1.Text = P_TIME;
                textBox2.Text = P_TIMES;

            }
        }
    }
}
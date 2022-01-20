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
    public partial class AttendanceForm : Form
    {
        //디비 연결  
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        OracleCommand cmd;
        DataSet dtSet = new DataSet();



        public AttendanceForm()
        {
            InitializeComponent();

            label4.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
           

            
        }

        private void atd_reset()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select pro_year, pro_season, pro_name, pro_days, pro_daye, pro_times, pro_timee from P22_LMG_TATM_PRO where PRO_YEAR in (select APP_YEAR from P22_LMG_TATM_APP where APP_STUNO = '"+ textBox2.Text +"' and APP_APPRO = 'Y')" +
                "and PRO_SEASON in (select APP_SEASON from P22_LMG_TATM_APP where APP_STUNO = '" + textBox2.Text + "' and APP_APPRO = 'Y')" +
                "and PRO_DAYS <= '"+ label10.Text +"' and PRO_DAYE >= '"+ label10.Text + "'", con);
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


            dataGridView1.Columns[0].Name = "Year";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Season";
        }            

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = System.DateTime.Now.ToString("yyyy/MM/dd  hh:mm:ss");
            label9.Text = System.DateTime.Now.ToString("HHmm");
            label10.Text = System.DateTime.Now.ToString("yyyyMMdd");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int rowindex2 = dataGridView1.CurrentCell.RowIndex;
            String ftime = dataGridView1.Rows[rowindex2].Cells[5].Value.ToString(); // 학번
            int state = 0; //근태 상태를 나타내는 함수

            int in_ftime = int.Parse(ftime); //출석해야하는 실습의 시간
            int in_sysftime = int.Parse(label9.Text); //출석을 눌렀을때의 시간
            int time_cha = 0;
            if ( in_sysftime <= in_ftime)
            {
                state = 1;

            }
            else
            {
                state = 2;
                time_cha = in_sysftime - in_ftime;
            }            

            OracleConnection con = new OracleConnection(css);
            con.Open();

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO P22_LMG_TATM_ATT(ATT_DATE ,ATT_STUNO, ATT_FTIME, ATT_TTIME) VALUES(:DAY, :STUNO, :TIME ,null)";
            cmd.Parameters.Add(new OracleParameter("DAY", label10.Text));            
            cmd.Parameters.Add(new OracleParameter("STUNO", textBox2.Text));
            cmd.Parameters.Add(new OracleParameter("TIME", label9.Text));


            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = con;

              cmd1.CommandText = "INSERT INTO P22_LMG_TATM_DIL(DIL_DATE ,DIL_STUNO, DIL_DILCODE, DIL_DILTIME) VALUES(:DAY1, :STUNO1,:STATE1, :Difference1)";
              cmd1.Parameters.Add(new OracleParameter("DAY1", label10.Text));
              cmd1.Parameters.Add(new OracleParameter("STUNO1", textBox2.Text));              
              cmd1.Parameters.Add(new OracleParameter("STATE1", state));
              cmd1.Parameters.Add(new OracleParameter("Difference1", time_cha));
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            MessageBox.Show("출근 완료 되었습니다.");
            button1.Enabled = false;
            button2.Enabled = true;

        }
        
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string Year = this.dataGridView1.CurrentRow.Cells["Year"].Value.ToString();
            string Season = this.dataGridView1.CurrentRow.Cells["Season"].Value.ToString();
            string Name = this.dataGridView1.CurrentRow.Cells["Name"].Value.ToString();

            textBox6.Text = Year;
            textBox5.Text = Season;
            textBox1.Text = Name;
            Read_Check();

        }
        public void Read_Check()
        {
            
            OracleConnection con = new OracleConnection(css);
            con.Open();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //db에 학번이랑 현재 날짜가 있는경우 (출근만 했을수도, 출퇴근 다했을수도 있음) 없으면 출근을 안했다는 뜻
            cmd.CommandText = "select nvl2(ATT_TTIME, 'B' , 'A'), att_ftime from p22_lmg_tatm_att t inner join p22_lmg_tatm_app p on t.ATT_STUNO = p.APP_STUNO where t.ATT_STUNO = :STUNO1 and t.ATT_DATE = :TIME1 and p.APP_YEAR = :YEAR1 and p.APP_SEASON = :SEASON1";
            cmd.Parameters.Add(new OracleParameter("STUNO1", textBox2.Text));
            cmd.Parameters.Add(new OracleParameter("TIME1", label10.Text));
            cmd.Parameters.Add(new OracleParameter("YEAR1", textBox6.Text));
            cmd.Parameters.Add(new OracleParameter("SEASON1", textBox1.Text));
            Boolean check = false;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                check = true;
                if(check)
                {
                    if(dr.GetString(0).Equals("A"))
                    {
                        button2.Enabled = true;
                    }
                    else
                    {
                        button2.Enabled = false;
                    }
                }
                if(dr.GetString(1).Equals(null))
                {
                    button1.Enabled = true;
                }
            }

            int rowindex2 = dataGridView1.CurrentCell.RowIndex;
            String ttime = dataGridView1.Rows[rowindex2].Cells[6].Value.ToString(); // 학번
            int state = 0; //근태 상태를 나타내는 함수

            int in_ttime = int.Parse(ttime); //퇴근해야하는 실습의 시간
            int in_sysftime = int.Parse(label9.Text); //폼이 로드됐을때의 시간

            if (check == false)
            {
                if (in_ttime < in_sysftime)
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            
            
        }
        public void btn_load()
        {
            string queryString = "select stu_name, stu_depart from P22_LMG_TATM_STU where STU_STUNO like '" + textBox2.Text + "'";
            using (OracleConnection connection = new OracleConnection(css))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                connection.Open();
                OracleDataReader reader;
                reader = command.ExecuteReader();

                // Always call Read before accessing data.
                while (reader.Read())
                {
                    if (reader.GetString(0) != null)
                    {
                        textBox3.Text = reader.GetString(0);
                        textBox4.Text = reader.GetString(1);
                        atd_reset();
                        return;
                    }                    
                }
                MessageBox.Show("존재하지않는 학번입니다.");
                return;
            }
                // Always call Close when done reading.                
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_load();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                OracleConnection conn = new OracleConnection(css);
                conn.Open();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                // SQL문 지정 및 INSERT 실행            
                cmd.CommandText = "UPDATE P22_LMG_TATM_ATT SET ATT_TTIME = :label9 where ATT_STUNO = :STUNO1 and ATT_DATE = :TIME1 ";
                cmd.Parameters.Add(new OracleParameter("TIME2", label9.Text.ToString()));
                cmd.Parameters.Add(new OracleParameter("STUNO1", textBox2.Text.ToString()));
                cmd.Parameters.Add(new OracleParameter("TIME1", label10.Text.ToString()));
            MessageBox.Show("퇴근 완료 되었습니다. 오늘도 수고하셨어요~");
                cmd.ExecuteNonQuery();
                conn.Close();
                
                button1.Enabled = false;
                button2.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

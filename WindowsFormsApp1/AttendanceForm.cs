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

            label4.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            atd_reset();
        }

        private void atd_reset()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_PRO order by PRO_YEAR ASC", con);
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
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Season";
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = System.DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss");
            label9.Text = System.DateTime.Now.ToString("hhmm");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                MessageBox.Show("정보들을 먼저 입력해주세요");
            }
            else
            { // 출근을 한 사람은 한번 더 출근 못하게 막는 코드
                if()
                {

                }
                else
                {

                
                OracleConnection conn = new OracleConnection(css);
                conn.Open();

                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                // SQL문 지정 및 INSERT 실행            
                cmd.CommandText = "INSERT INTO P22_LMG_TATM_ATT(ATT_DATE, ATT_STUNO, ATT_FTIME, ATT_TTIME) VALUES(sysdate,'" + textBox2.Text + "','" + label9.Text + "',null)";
                MessageBox.Show("출근 완료 되었습니다.");
                cmd.ExecuteNonQuery();
                conn.Close();

                }
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string Year = this.dataGridView1.CurrentRow.Cells["Year"].Value.ToString();
            string Season = this.dataGridView1.CurrentRow.Cells["Season"].Value.ToString();
            string Name = this.dataGridView1.CurrentRow.Cells["Name"].Value.ToString();

            textBox6.Text = Year;
            textBox5.Text = Season;
            textBox1.Text = Name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string queryString = "select * from P22_LMG_TATM_STU where STU_STUNO like '" + textBox2.Text + "'";
            using (OracleConnection connection = new OracleConnection(css))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                connection.Open();
                OracleDataReader reader;
                reader = command.ExecuteReader();

                // Always call Read before accessing data.
                while (reader.Read())
                {
                    textBox3.Text = reader.GetString(2);
                    textBox4.Text = reader.GetString(4);
                }

                // Always call Close when done reading.
                reader.Close();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("정보들을 먼저 입력해주세요");
            }
            else
            {
                OracleConnection conn = new OracleConnection(css);
                conn.Open();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                // SQL문 지정 및 INSERT 실행            
                cmd.CommandText = "INSERT INTO P22_LMG_TATM_ATT(ATT_DATE, ATT_STUNO, ATT_FTIME, ATT_TTIME) VALUES(sysdate,'" + textBox2.Text + "',null,'" + label9.Text + "')";
                MessageBox.Show("퇴근 완료 되었습니다. 오늘도 수고하셨음 ㅋ");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

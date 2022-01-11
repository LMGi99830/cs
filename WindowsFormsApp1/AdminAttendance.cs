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
        OracleCommand cmd;
        DataSet dtSet = new DataSet();

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

        private void AdminAttendance_Load(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            AttendanceCodeForm Form1 = new AttendanceCodeForm();
            Form1.ShowDialog();
            textBox12.Text = Form1._textBox1.ToString();
            textBox9.Text = Form1._textBox2.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            int rowindex = dataGridView1.CurrentCell.RowIndex;
            String indexvalue = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //연도
            String indexvalue1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString(); // 계절
            String indexvalue2 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString(); // 명칭

            textBox2.Text = indexvalue;
            textBox5.Text = indexvalue2;
            textBox11.Text = indexvalue1;
            
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select a.app_stuno, s.stu_name, s.stu_depart, t.att_date, t.att_ftime, t.att_ttime from P22_LMG_TATM_APP a, P22_LMG_TATM_ATT t, P22_LMG_TATM_STU s where a.app_stuno = t.att_stuno and t.att_stuno = s.stu_stuno and a.app_year = '" + indexvalue + "' and a.app_season = '" + indexvalue1 + "' and t.att_name = '" + indexvalue2 + "'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            dataGridView2.Columns[0].HeaderText = "학번";
            dataGridView2.Columns[1].HeaderText = "이름";
            dataGridView2.Columns[2].HeaderText = "학과";
            dataGridView2.Columns[3].HeaderText = "근무일자";
            dataGridView2.Columns[4].HeaderText = "출석시간";
            dataGridView2.Columns[5].HeaderText = "퇴근시간";            

            dataGridView2.Columns[0].Name = "stuno";
            dataGridView2.Columns[1].Name = "name";
            dataGridView2.Columns[2].Name = "depart";
            dataGridView2.Columns[3].Name = "date";
            dataGridView2.Columns[4].Name = "ftime";
            dataGridView2.Columns[5].Name = "ttime";

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            int rowindex2 = dataGridView2.CurrentCell.RowIndex;
            String stuno = dataGridView2.Rows[rowindex2].Cells[0].Value.ToString(); // 학번
            String name = dataGridView2.Rows[rowindex2].Cells[1].Value.ToString(); // 이름
            String dor = dataGridView2.Rows[rowindex2].Cells[2].Value.ToString(); // 학과
            String date = dataGridView2.Rows[rowindex2].Cells[3].Value.ToString(); // 근무일자
            String ftime = dataGridView2.Rows[rowindex2].Cells[4].Value.ToString(); // 출석시간
            String ttime = dataGridView2.Rows[rowindex2].Cells[5].Value.ToString(); // 퇴근시간
            if (ttime == "")
            {
                String a = "";
                ttime = "01";
                String abc = "01";
                textBox23.Text = a;
                textBox22.Text = a;
            }
            else
            {
                textBox23.Text = ttime.Substring(0, 2);
                textBox22.Text = ttime.Substring(2, 2);
            }

            textBox16.Text = stuno;
            textBox3.Text = name;
            textBox4.Text = dor; // 19 13 14
            textBox19.Text = date.Substring(0, 2);
            textBox13.Text = date.Substring(2, 2);
            textBox14.Text = date.Substring(4, 2);
            textBox17.Text = ftime.Substring(0, 2);
            textBox10.Text = ftime.Substring(2, 2);
            // 2 11
            OracleConnection con = new OracleConnection(css);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from P22_LMG_TATM_PRO where pro_year = :YEAR and pro_season = :SEASON";
            cmd.Parameters.Add(new OracleParameter("YEAR", textBox2.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("SEASON", textBox11.Text.ToString()));
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                int starttime = int.Parse(ftime); // 학생이 출석한 시간
                int startdr = int.Parse(dr.GetString(5)); // 실습 출석 시간

                int endtime = int.Parse(ttime); // 학생이 퇴근한 시간
                int enddr = int.Parse(dr.GetString(6)); // 실습 퇴근 시간

                if (ftime != "")
                {
                    setStimeAndTTime(starttime, startdr);
                }
            }

            dr.Close();
            con.Close();

        }


        private void setStimeAndTTime(int starttime, int startdr)
        {
            if (startdr < starttime)
            {
                TextBox6ValueChange("지각");
                return;
            }
            TextBox6ValueChange("출근");
        }

        public void TextBox6ValueChange(string value)
        {
            this.CustomTextBoxValueChange(textBox6, value);
            textBox6.Text = value;
        }

        public void CustomTextBoxValueChange(TextBox textbox, string value)
        {
            textbox.Text = value;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}

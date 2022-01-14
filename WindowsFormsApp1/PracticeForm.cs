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


namespace WindowsFormsApp1
{
    public partial class PracticeForm : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        public PracticeForm()
        {
            InitializeComponent();
            panel1.TabStop = false;
            panel2.TabStop = false;            
            panel4.TabStop = false;            
            
        }
        public void OracleParameter()
        {
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("연도를 입력해주세요");
                return;
            }



            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "select PRO_YEAR, PRO_SEASON from P22_LMG_TATM_PRO where PRO_YEAR = :YEAR and PRO_SEASON = :SEASON";
            cmd1.Parameters.Add(new OracleParameter("YEAR1", textBox4.Text.ToString()));
            cmd1.Parameters.Add(new OracleParameter("SEASON1", comboBox2.Text.ToString()));
            OracleDataReader dr = cmd1.ExecuteReader();
            Boolean check1 = false;
            while (dr.Read())
            {
                check1 = true;
            }
                
            if (check1)
            {
                MessageBox.Show("중복된 값");                
            }
            else
            {


                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = @"insert into P22_LMG_TATM_PRO (
                                                PRO_YEAR,PRO_SEASON,PRO_NAME,PRO_COUNT,PRO_DAYS,PRO_DAYE,
                                                PRO_TIMES,PRO_TIMEE)
                                            values (:YEAR,:SEASON,:NAME,:COUNT, :DAYS,:DAYE,:TIMES,:TIMEE)";
            cmd.Parameters.Add(new OracleParameter("YEAR", textBox4.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("SEASON", comboBox2.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("NAME", textBox3.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("COUNT", textBox6.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DAYS", dateTimePicker1.Value.ToString("yymmdd")));
            cmd.Parameters.Add(new OracleParameter("DAYE", dateTimePicker2.Value.ToString("yymmdd")));            
            cmd.Parameters.Add(new OracleParameter("TIMES", textBox1.Text.ToString()));            
            cmd.Parameters.Add(new OracleParameter("TIMEE", textBox2.Text.ToString()));

            cmd.ExecuteNonQuery();
            }
            reset_pro();
        }

        private void PracticeForm_Load(object sender, EventArgs e)
        {
            reset_pro();
        }
        public void reset_pro()
        {
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_PRO order by PRO_YEAR", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleParameter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Text);


            textBox7.Text = dateTimePicker1.Value.ToString("yymmdd");


        }
    }
}

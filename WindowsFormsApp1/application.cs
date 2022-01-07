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

        private void application_Load(object sender, EventArgs e)
        {

            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_PRO order by PRO_YEAR ASC", con);
            dt = new DataTable();

            dt.Columns.Add("선택", typeof(bool));
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            

            dataGridView2.Columns[1].HeaderText = "연도";
            dataGridView2.Columns[2].HeaderText = "계절";
            dataGridView2.Columns[3].HeaderText = "명칭";
            dataGridView2.Columns[4].HeaderText = "실습기간(시작)";
            dataGridView2.Columns[5].HeaderText = "실습기간(종료)";
            dataGridView2.Columns[6].HeaderText = "실습시간(시작)";
            dataGridView2.Columns[7].HeaderText = "실습시간(종료)";
            dataGridView2.Columns[8].HeaderText = "자료처리일시";
            dataGridView2.Columns[9].HeaderText = "자료처리구분";
            dataGridView2.Columns[10].HeaderText = "자료처리자";
            dataGridView2.Columns[11].HeaderText = "정원";

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApplicationForm Form1 = new ApplicationForm();
            Form1.Show();
        }
        private void reset_userform()
        {

            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_APP where APP_APPRO = 'N' order by APP_YEAR ASC", con);
            dt = new DataTable();
            dt.Columns.Add("선택", typeof(bool));
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

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
            dataGridView1.Columns[1].Name = "StuNO";
            string val = this.dataGridView1.CurrentRow.Cells["StuNO"].Value.ToString();
            

            //////////////////////////////////////////////

            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_APP where APP_APPRO = 'Y' order by APP_YEAR ASC", con);
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
            dataGridView4.Columns[1].Name = "StuNO";
            string vall = this.dataGridView4.CurrentRow.Cells["StuNO"].Value.ToString();
            MessageBox.Show(vall);




        }
        public string _textBox1
        {
            get { return textBox1.Text.Trim(); }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            reset_userform();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                bool chk =  (bool)dataGridView1.Rows[i].Cells[0].Value;
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
                    cmd.CommandText = "Update P22_LMG_TATM_APP set APP_APPRO = 'Y' where APP_STUNO = '" + _textBox1 + "'";

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("업데이트 완료");
                    conn.Close();
                    reset_userform();
                }
            }
        }
    }
}

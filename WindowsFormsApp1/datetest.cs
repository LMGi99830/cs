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
    public partial class datetest : Form
    {
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;       
        DataSet dtSet = new DataSet();
        int nBetweenDayCnt = 0;

        public datetest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    OracleConnection con = new OracleConnection(css);
                    con.Open();

                    // 명령 객체 생성
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO P22_LMG_TATM_TEST(TEST_DATE, TEST_NAME) VALUES(:DAY2, :DAY1)";
                    cmd.Parameters.Add(new OracleParameter("DAY2", date2));         
                    cmd.Parameters.Add(new OracleParameter("DAY1", date1));

                    cmd.ExecuteNonQuery();                    
                }
                else
                {
                    textBox2.Text = "평일";
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
            textBox1.Text = nBetweenDayCnt.ToString();            
            asdef();
        }
        public void asdef()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select * from p22_lmg_tatm_test order by test_date", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns[0].HeaderText = "날짜";
            dataGridView1.Columns[1].HeaderText = "이름";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

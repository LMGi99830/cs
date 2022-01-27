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
    public partial class HolidayForm : Form
    {
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;       
        DataSet dtSet = new DataSet();
        int a = 0;
        string stuno = "";       

        public HolidayForm()
        {
            InitializeComponent();
        }


        public void btn_load()
        {
            con = new OracleConnection(css);
            con.Open();
            adapt = new OracleDataAdapter("select PRO_YEAR,PRO_SEASON,PRO_NAME,PRO_DAYS, PRO_DAYE from p22_lmg_tatm_pro", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            dataGridView2.Columns[0].HeaderText = "날짜";
            dataGridView2.Columns[1].HeaderText = "계절";
            dataGridView2.Columns[2].HeaderText = "실습명";
            dataGridView2.Columns[3].HeaderText = "실습시작기간";
            dataGridView2.Columns[4].HeaderText = "실습종료기간";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(css);
            con.Open();
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            string year2 = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
            string season2 = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
            OracleCommand cmd2 = con.CreateCommand();
            string sqql = $@"select count(*) from p22_lmg_tatm_hoi where hoi_year = '{year2}' and hoi_season = '{season2}'";
            cmd2.CommandText = sqql;
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while(dr2.Read())
            {
                int count = int.Parse(dr2.GetString(0));                
                while (true)
                {
                    if (a >= 0 && a < count)
                    {
                        OracleCommand cmd1 = con.CreateCommand();
                        String sql = "select app_stuno from p22_lmg_tatm_app where app_appro = 'Y' and app_year = '"+ year2 + "' and app_season = '"+ season2 + "'";
                        cmd1.CommandText = sql;
                        OracleDataReader dr = cmd1.ExecuteReader();
                        while (dr.Read())
                        {
                            stuno = dr.GetString(0);
                            string data = dataGridView1.Rows[a].Cells[0].Value.ToString();
                            // 명령 객체 생성
                            OracleCommand cmd = new OracleCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "INSERT INTO P22_LMG_TATM_DIL(DIL_DATE, DIL_STUNO, DIL_DILCODE) VALUES(:date1, :stuno1,:code1)";
                            cmd.Parameters.Add(new OracleParameter("date1", data));
                            cmd.Parameters.Add(new OracleParameter("stuno1", stuno));
                            cmd.Parameters.Add(new OracleParameter("code1", "6"));

                            cmd.ExecuteNonQuery();
                        }
                    }
                    a++;
                    if (a > 7)
                    {
                        break;
                    }
                }
            }


            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con = new OracleConnection(css);
            con.Open();
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            string year1 = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
            string season1 = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
            adapt = new OracleDataAdapter("select hoi_date , hoi_name from p22_lmg_tatm_hoi where hoi_year = '" + year1 + "' and hoi_season = '" + season1 + "'order by hoi_date", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns[0].HeaderText = "날짜";
            dataGridView1.Columns[1].HeaderText = "이름";
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            while (true)
            {
                if (a >= 0 && a <= 7)
                {

                    OracleConnection con = new OracleConnection(css);
                    con.Open();

                    OracleCommand cmd1 = con.CreateCommand();
                    String sql = "select app_stuno from p22_lmg_tatm_app where app_appro = 'Y'";
                    cmd1.CommandText = sql;
                    OracleDataReader dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {
                        stuno = dr.GetString(0);
                        string data = dataGridView1.Rows[a].Cells[0].Value.ToString();
                        // 명령 객체 생성
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO P22_LMG_TATM_DIL(DIL_DATE, DIL_STUNO, DIL_DILCODE) VALUES(:date1, :stuno1,:code1)";
                        cmd.Parameters.Add(new OracleParameter("date1", data));
                        cmd.Parameters.Add(new OracleParameter("stuno1", stuno));
                        cmd.Parameters.Add(new OracleParameter("code1", "6"));

                        cmd.ExecuteNonQuery();
                    }
                }
                a++;
                if (a > 7)
                {
                    break;
                }
            }
        }

        public void asd()
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

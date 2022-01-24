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
    public partial class AttendanceTotal : Form
    {
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        OracleCommand cmd;
        DataSet dtSet = new DataSet();
        public AttendanceTotal()
        {
            InitializeComponent();
        }

        public void btn_load()
        {
            con = new OracleConnection(css);
            con.Open();
            String sql = @"select PRO_YEAR, PRO_SEASON, PRO_NAME, (to_date(PRO_DAYE) - to_date(PRO_DAYS)) from P22_LMG_TATM_PRO";

            adapt = new OracleDataAdapter(sql, con);
            dt = new DataTable();

            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns[0].HeaderText = "연도";
            dataGridView1.Columns[1].HeaderText = "계절";
            dataGridView1.Columns[2].HeaderText = "실습명";
            dataGridView1.Columns[3].HeaderText = "총 출석 일자";            

            dataGridView1.Columns[0].Name = "Year";
            dataGridView1.Columns[1].Name = "Season";
            dataGridView1.Columns[2].Name = "Name";
            dataGridView1.Columns[3].Name = "Ftime_total";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con = new OracleConnection(css);
            con.Open();
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            String Year1 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); // 연도
            String Season1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString(); // 계절

            String sql = $@"select DIL_STUNO, STU_NAME, DEF_NAME, (select count(*) from P22_LMG_TATM_DIL where DIL_DILCODE = 1),(select count(*) from P22_LMG_TATM_DIL where DIL_DILCODE = 3),
                                   (select count(*) from P22_LMG_TATM_DIL where DIL_DILCODE = 4),(select count(*) from P22_LMG_TATM_DIL where DIL_DILCODE = 5),
                                   (select count(*) from P22_LMG_TATM_DIL where DIL_DILCODE = 2), sum(DIL_DILTIME)
                                    from P22_LMG_TATM_DIL dil, P22_LMG_TATM_APP app, P22_LMG_TATM_STU stu, P22_LMG_TATM_DEF def
                                    where dil.DIL_STUNO = app.APP_STUNO
                                    and app.APP_STUNO = stu.STU_STUNO
                                    and STU_DEPART = DEF_CODE
                                    and app.APP_YEAR = '{Year1}'
                                    and app.APP_SEASON = '{Season1}'
                                    group by DIL_STUNO, STU_NAME,DEF_NAME";

            adapt = new OracleDataAdapter(sql, con);
            dt = new DataTable();


            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            dataGridView2.Columns[0].HeaderText = "학번";
            dataGridView2.Columns[1].HeaderText = "이름";
            dataGridView2.Columns[2].HeaderText = "학과";
            dataGridView2.Columns[3].HeaderText = "출석";
            dataGridView2.Columns[4].HeaderText = "조퇴";
            dataGridView2.Columns[5].HeaderText = "결근";
            dataGridView2.Columns[6].HeaderText = "지각과조퇴";
            dataGridView2.Columns[7].HeaderText = "지각";
            dataGridView2.Columns[8].HeaderText = "지각 시간";
            
        }
    }
}

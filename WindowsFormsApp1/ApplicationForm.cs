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
    public partial class ApplicationForm : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupportAreasCodeForm Form1 = new SupportAreasCodeForm();
            Form1.ShowDialog();
            textBox12.Text = Form1._textBox1.ToString();
            textBox13.Text = Form1._textBox2.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "select * from P22_LMG_TATM_STU where STU_STUNO = :STUNO";
            cmd1.Parameters.Add(new OracleParameter("STUNO", textBox1.Text.ToString()));
            OracleDataReader dr = cmd1.ExecuteReader();
            Boolean check1 = true;
            OracleCommand cmd2 = con.CreateCommand();
            cmd2.CommandText = "select * from P22_LMG_TATM_APP where APP_STUNO = :STUNO and APP_YEAR = :YEAR and APP_SEASON = :SEASON";
            cmd2.Parameters.Add(new OracleParameter("STUNO", textBox1.Text.ToString()));
            cmd2.Parameters.Add(new OracleParameter("YEAR", textBox2.Text.ToString()));
            cmd2.Parameters.Add(new OracleParameter("SEASON", textBox3.Text.ToString()));
            OracleDataReader drr = cmd2.ExecuteReader();
            Boolean check2 = false;
            while (dr.Read())
            {
                check1 = false;
            }
            while (drr.Read())
            {
                check2 = true;
            }
            if (check1)
            {
                MessageBox.Show("존재 하지 않는 학번입니다.");
                return;
            }
            else
            {
                if(check2)
                {
                    MessageBox.Show("이미 신청한 학번입니다.");
                    return;

                }
                else
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"insert into P22_LMG_TATM_APP ( APP_STUNO, APP_YEAR, APP_SEASON, APP_FIE_CODE, APP_TELNO, APP_AVG, APP_MIL,
                                                                                    APP_CER1, APP_CER1_DATE, APP_CER1_PLACE, APP_CER2, APP_CER2_DATE,
                                                                                    APP_CER2_PLACE, APP_ENG_CON, APP_ENG_REA, APP_ENG_WRT, APP_SELF, APP_APPRO )
                                                    values (    :STUNO ,:YEAR, :SEASON, :FIE_CODE, :TELNO, :AVG, :MIL, :CER1, :CER1_DATE,
                                                                :CER1_PLACE, :CER2, :CER2_DATE, :CER2_PLACE, :ENG_CON, :ENG_REA, :ENG_WRT, :SELF, :APPRO ) ";
                    cmd.Parameters.Add(new OracleParameter("STUNO", textBox1.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("YEAR", textBox2.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("SEASON", textBox3.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("FIE_CODE", textBox12.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("TELNO", textBox6.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("AVG", textBox4.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("MIL", comboBox4.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("CER1", textBox7.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("CER1_DATE", textBox11.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("CER1_PLACE", textBox5.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("CER2", textBox8.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("CER2_DATE", textBox14.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("CER2_PLACE", textBox9.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("ENG_CON", comboBox5.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("ENG_REA", comboBox3.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("ENG_WRT", comboBox6.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("SELF", textBox10.Text.ToString()));
                    cmd.Parameters.Add(new OracleParameter("APPRO", "N"));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("신청완료");
                    this.Close();
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = application.SetValueForText1;
            textBox3.Text = application.SetValueForText2;


            
        }
    }
}

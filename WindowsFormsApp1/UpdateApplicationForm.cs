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
    public partial class UpdateApplicationForm : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";       
        public UpdateApplicationForm()
        {
            InitializeComponent();
        }

        private void UpdateApplicationForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = application.STUNO;
            textBox2.Text = application.YEAR;
            textBox3.Text = application.SEASON;
            textBox12.Text = application.FIE_CODE;
            textBox6.Text = application.TELNO;
            textBox4.Text = application.AVG;
            comboBox4.Text = application.MIL;
            textBox7.Text = application.CER1;
            textBox11.Text = application.CER1_DATE;
            textBox5.Text = application.CER1_PLACE;
            textBox8.Text = application.CER2;
            textBox14.Text = application.CER2_DATE;
            textBox9.Text = application.CER2_PLACE;
            comboBox5.Text = application.ENG_CON;
            comboBox3.Text = application.ENG_REA;
            comboBox6.Text = application.ENG_WRT;
            textBox10.Text = application.SELF;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = @"update P22_LMG_TATM_APP
                                            set  APP_YEAR = :YEAR1, APP_SEASON = :SEASON1, APP_FIE_CODE = :FIE_CODE1, APP_TELNO = :TELNO1,
                                            APP_AVG = :AVG1, APP_MIL = :MIL1, APP_CER1 = :CER11, APP_CER1_DATE = :CER1_DATE1,
                                             APP_CER1_PLACE = :CER1_PLACE1, APP_CER2 = :CER21, APP_CER2_DATE = :CER2_DATE1,
                                             APP_CER2_PLACE = :CER2_PLACE1, APP_ENG_CON = :ENG_CON1, APP_ENG_REA = :ENG_REA1,
                                             APP_ENG_WRT = :ENG_WRT1 ,APP_SELF = :SELF1, APP_APPRO = :APPRO1
                                            where APP_STUNO = :STUNO1";
            cmd.Parameters.Add(new OracleParameter("YEAR1", textBox2.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("SEASON1", textBox3.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("FIE_CODE1", textBox12.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("TELNO1", textBox6.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("AVG1", textBox4.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("MIL1", comboBox4.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("CER11", textBox7.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("CER1_DATE1", textBox11.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("CER1_PLACE1", textBox5.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("CER21", textBox8.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("CER2_DATE1", textBox14.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("CER2_PLACE1", textBox9.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ENG_CON1", comboBox5.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ENG_REA1", comboBox3.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ENG_WRT1", comboBox6.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("SELF1", textBox10.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("APPRO1", "N"));
            cmd.Parameters.Add(new OracleParameter("STUNO1", textBox1.Text.ToString()));
            cmd.ExecuteNonQuery();
            MessageBox.Show("수정완료");

            
            this.Close();
        }
    }
}

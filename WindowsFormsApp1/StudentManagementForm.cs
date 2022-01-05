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
    public partial class StudentManagementForm : Form
    {
        //디비 연결  
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection conn;
        OracleDataAdapter adaptt;
        DataTable dtt;

        public StudentManagementForm()
        {
            InitializeComponent();
            

        }        
        private void button3_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;           

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"D:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
            }
            else
            {
                return;
            }

            pictureBox1.Image = Bitmap.FromFile(image_file);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DormitoryCodeForm Form1 = new DormitoryCodeForm();
            Form1.ShowDialog();
            textBox7.Text = Form1._textBox1.ToString();
            textBox14.Text = Form1._textBox2.ToString();            
        }

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(css);
            conn.Open();
            adaptt = new OracleDataAdapter("select * from P22_LMG_TATM_STU order by STU_NAME", conn);
            dtt = new DataTable();
            adaptt.Fill(dtt);
            dataGridView1.DataSource = dtt;
            conn.Close();

            dataGridView1.Columns[0].HeaderText = "학번";
            dataGridView1.Columns[1].HeaderText = "주민등록번호";
            dataGridView1.Columns[2].HeaderText = "성명";
            dataGridView1.Columns[3].HeaderText = "성별";
            dataGridView1.Columns[4].HeaderText = "학과명(계열)";
            dataGridView1.Columns[5].HeaderText = "연락처";
            dataGridView1.Columns[6].HeaderText = "이메일";
            dataGridView1.Columns[7].HeaderText = "우편번호";
            dataGridView1.Columns[8].HeaderText = "주소";
            dataGridView1.Columns[9].HeaderText = "주소나머지";
            dataGridView1.Columns[10].HeaderText = "사용구분";
            dataGridView1.Columns[11].HeaderText = "동";
            dataGridView1.Columns[12].HeaderText = "호실";
            dataGridView1.Columns[13].HeaderText = "은행명";
            dataGridView1.Columns[14].HeaderText = "예금주";
            dataGridView1.Columns[15].HeaderText = "계좌번호";
            dataGridView1.Columns[16].HeaderText = "파일명";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankCodeForm Form1 = new BankCodeForm();
            Form1.ShowDialog();
            textBox3.Text = Form1._textBox1.ToString();
            textBox16.Text = Form1._textBox2.ToString();
        }

       
    }
}

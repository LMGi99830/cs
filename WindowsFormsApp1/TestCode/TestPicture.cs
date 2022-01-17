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
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class TestPicture : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection con;
        OracleDataAdapter adapt;
        DataTable dt;
        public TestPicture()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.Filter = "Image File (*.png;)|*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
                pictureBox1.BackgroundImage = Bitmap.FromFile(image_file);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            Bitmap bitmap = new Bitmap((Image)pictureBox1.BackgroundImage);
            ImageConverter converter = new ImageConverter();
            byte[] b = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
            String InsertSQL = "insert into P22_LMG_TATM_PIC(imageno,image) values (:NO,:PIC)";

            cmd.CommandText = InsertSQL;
            cmd.Parameters.Add("NO", '6');
            cmd.Parameters.Add("PIC", OracleDbType.Blob, b.Length, b, ParameterDirection.Input);
            cmd.ExecuteNonQuery();
            MessageBox.Show("사진저장완료");
            reset_select_form();
            con.Close();
        }

        public void reset_select_form()
        {
            con = new OracleConnection(cs);
            con.Open();
            adapt = new OracleDataAdapter("select * from P22_LMG_TATM_PIC", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataHearder(); //헤더텍스트 이름
        }

        public void dataHearder()
        {
            dataGridView1.Columns[0].HeaderText = "이미지번호";
            dataGridView1.Columns[1].HeaderText = "이미지";
        }

        private void TestPicture_Load(object sender, EventArgs e)
        {
            reset_select_form();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            /* int rowindex = dataGridView1.CurrentCell.RowIndex;

             String STUNO1 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //학번
             String PIC1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString(); //학번
             con.Open();
             OracleCommand cmd = con.CreateCommand();
             cmd.CommandText = "select * from P22_LMG_TATM_PIC where IMAGENO=:no";
             cmd.Parameters.Add("no", STUNO1);
             OracleDataReader dr = cmd.ExecuteReader();
             dr.Read();

             if (!dr.IsDBNull(1))
             {
                 byte[] imgByte = (byte[])dr["IMAGE"];

                 MemoryStream memoryStream = new MemoryStream(imgByte);
                 pictureBox1.Image = new Bitmap(memoryStream);
             }
             else
             {
                 bool isNullOrEmpty = pictureBox1 == null || pictureBox1.Image == null;
             }
             con.Close();       */
            try { 
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            String STUNO1 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //학번
            con = new OracleConnection(cs);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            string query = "select * from P22_LMG_TATM_PIC where IMAGENO= '" + STUNO1 + "'";
            con.Open();
            OracleDataAdapter da = new OracleDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "P22_LMG_TATM_PIC");
            DataTable tbl = ds.Tables[0];
            DataRow row = tbl.Rows[0];
            if ((row["IMAGE"]) == System.DBNull.Value)
            {
                MessageBox.Show("NULL");
            }
            Byte[] byteBLOBData = new Byte[0];
            byteBLOBData = (Byte[])(row["IMAGE"]);
            MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
            Image theImage = null;
            theImage = Image.FromStream(stmBLOBData);
            pictureBox1.Image = theImage;
            con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

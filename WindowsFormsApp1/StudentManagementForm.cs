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
    public partial class StudentManagementForm : Form
    {
        //디비 연결  
        string css = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        OracleConnection conn;
        OracleDataAdapter adaptt;
        DataTable dtt;
        string image_file = string.Empty;
        public StudentManagementForm()
        {
            InitializeComponent();


        }
        private void STU_IMG_BTN_Click(object sender, EventArgs e)
        {
            Imageload();
        }
        public void Imageload()
        {


            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.Filter = "Image File (*.jpg;*.png;)|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
                STU_IMG.BackgroundImage = Bitmap.FromFile(image_file);
            }
            STU_IMG.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ZIP_BTN_Click(object sender, EventArgs e)
        {

        }

        private void DOR_BTN_Click(object sender, EventArgs e)
        {
            DormitoryCodeForm Form1 = new DormitoryCodeForm();
            Form1.ShowDialog();
            DOR_NAME.Text = Form1._textBox1.ToString();

            DOR_DON.Text = Form1._textBox2.ToString();
        }

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {
            reset_student();
        }
        #region 학생 조회 쿼리
        public void reset_student()
        {
            conn = new OracleConnection(css);
            conn.Open();
            adaptt = new OracleDataAdapter("select * from P22_LMG_TATM_STU order by STU_NAME", conn);
            dtt = new DataTable();
            adaptt.Fill(dtt);
            dataGridView1.DataSource = dtt;
            conn.Close();
            dataHearder(); //헤더텍스트 이름
        }
        #endregion

        #region 그리드뷰1 헤더 텍스트
        public void dataHearder()
        {
            dataGridView1.Columns[0].HeaderText = "학번";
            dataGridView1.Columns[1].HeaderText = "주민등록번호";
            dataGridView1.Columns[2].HeaderText = "성명";
            dataGridView1.Columns[3].HeaderText = "성별";
            dataGridView1.Columns[4].HeaderText = "학과코드";
            dataGridView1.Columns[5].HeaderText = "학과명(계열)";
            dataGridView1.Columns[6].HeaderText = "연락처";
            dataGridView1.Columns[7].HeaderText = "이메일";
            dataGridView1.Columns[8].HeaderText = "우편번호";
            dataGridView1.Columns[9].HeaderText = "주소";
            dataGridView1.Columns[10].HeaderText = "주소나머지";
            dataGridView1.Columns[11].HeaderText = "사용구분";
            dataGridView1.Columns[12].HeaderText = "이름";
            dataGridView1.Columns[13].HeaderText = "동";
            dataGridView1.Columns[14].HeaderText = "호실";
            dataGridView1.Columns[15].HeaderText = "은행코드";
            dataGridView1.Columns[16].HeaderText = "은행명";
            dataGridView1.Columns[17].HeaderText = "예금주";
            dataGridView1.Columns[18].HeaderText = "계좌번호";
            dataGridView1.Columns[19].HeaderText = "파일명";
        }
        #endregion

        private void ACC_BANK_BTN_Click(object sender, EventArgs e)
        {
            BankCodeForm Form1 = new BankCodeForm();
            Form1.ShowDialog();
            ACC_BANK.Text = Form1._textBox1.ToString();
            ACC_BANK_NAME.Text = Form1._textBox2.ToString();
        }

        private void Enrollment_Click(object sender, EventArgs e)
        {
            required();
        }
        #region 학번이 빈칸이면 작동
        public void required()
        {
            if (string.IsNullOrEmpty(STUNO.Text))
            {
                MessageBox.Show("학번은 필 수 입력 항목입니다.");
                return;
            }
            else
            {
                OracleParameter();
            }
        }
        #endregion

        #region 학생 정보들 insert문
        public void OracleParameter()
        {

            OracleConnection con = new OracleConnection(css);
            con.Open();
            Bitmap bitmap = new Bitmap((Image)STU_IMG.BackgroundImage);
            ImageConverter converter = new ImageConverter();
            byte[] b = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = @"insert into P22_LMG_TATM_STU
                                                (STU_STUNO, STU_RESNO, STU_NAME, STU_FIX, STU_DEPART_NO,STU_DEPART, STU_PHONE, STU_EMAIL, STU_ZIP,
                                                 STU_ZIPADDR, STU_ADDR, STU_DOR_USE, STU_DOR_NAME, STU_DOR_DON, STU_DOR_MB, STU_ACC_BANK_CODE,
                                                 STU_ACC_BANK, STU_ACC_NAME, STU_ACC_NO, STU_IMG) 
                                            values( :STUNO, :RESNO, :NAME, :FIX, :DEPART_NO, :DEPART, :PHONE,
                                                   :EMAIL, :ZIP, :ZIPADDR, :ADDR, :DOR_USE, :DOR_NAME, :DOR_DON,
                                                   :DOR_MB, :ACC_BANK_NO, :ACC_BANK, :ACC_NAME, :ACC_NO, :STU_IMG)";
            MessageBox.Show("등록이 완료되었습니다.");

            // a는 DOR_USE가 체크 되있는지 확인하는 변수
            string a = Dor_Use_Check();
            cmd.Parameters.Add(new OracleParameter("STUNO", STUNO.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("RESNO", RESNO.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("NAME", NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("FIX", FIX.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DEPART_NO", DEPART.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DEPART", DEPART_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("PHONE", PHONE.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("EMAIL", EMAIL.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ZIP", ZIP.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ZIPADDR", ZIPADDR.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ADDR", ADDR.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_USE", a.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_NAME", DOR_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_DON", DOR_DON.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_MB", DOR_MB.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_BANK_NO", ACC_BANK.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_BANK", ACC_BANK_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_NAME", ACC_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_NO", ACC_NO.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("STU_IMG", OracleDbType.Blob, b.Length, b, ParameterDirection.Input));

            cmd.ExecuteNonQuery();

            reset_student();
        }
        #endregion

        #region 그룹 체크박스 체크 여부 확인
        private string Dor_Use_Check()
        {
            string a = "";
            if (DOR_USE.Checked == true)
            {
                a = "사용";
            }
            else
            {
                a = "미사용";
            }

            return a;
        }
        #endregion

        private void DEPART_BTN_Click(object sender, EventArgs e)
        {
            AdminCode.defCodeForm Form1 = new AdminCode.defCodeForm();
            Form1.ShowDialog();
            DEPART.Text = Form1._textBox1.ToString();
            DEPART_NAME.Text = Form1._textBox2.ToString();
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search1_Click(sender, e);
            }
        }

        #region 검색 기능 버튼 1
        private void Search1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(css);
            conn.Open();
            adaptt = new OracleDataAdapter("select * from P22_LMG_TATM_STU where STU_STUNO like '" + SearchBox1.Text + "%' order by STU_STUNO", conn);
            dtt = new DataTable();
            adaptt.Fill(dtt);
            dataGridView1.DataSource = dtt;
            conn.Close();
        }
        #endregion

        #region 검색 기능 버튼2
        private void Search2_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(css);
            conn.Open();
            adaptt = new OracleDataAdapter("select * from P22_LMG_TATM_STU where STU_NAME like '" + SearchBox2.Text + "%' order by STU_STUNO", conn);
            dtt = new DataTable();
            adaptt.Fill(dtt);
            dataGridView1.DataSource = dtt;
            conn.Close();
        }
        #endregion

        #region 텍박2 키다운
        private void SearchBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search2_Click(sender, e);
            }
        }
        #endregion

        public void picture_load()
        {
            STU_IMG = null;
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            String STUNO1 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //학번
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from P22_LMG_TATM_STU where STU_STUNO=:no";
            cmd.Parameters.Add("no", STUNO1);
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if (!dr.IsDBNull(19))
            {
                byte[] imgByte = (byte[])dr["STU_IMG"];

                MemoryStream memoryStream = new MemoryStream(imgByte);
                STU_IMG.Image = new Bitmap(memoryStream);
            }
            
            conn.Close();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            String STUNO1 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //학번
            String RESNO1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString(); // 주민번호
            String NAME1 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString(); // 성명
            String FIX1 = dataGridView1.Rows[rowindex].Cells[3].Value.ToString(); // 성별
            String DEPART_NO1 = dataGridView1.Rows[rowindex].Cells[4].Value.ToString(); // 학과코드
            String DEPART1 = dataGridView1.Rows[rowindex].Cells[5].Value.ToString(); // 학과명(계열)
            String PHONE1 = dataGridView1.Rows[rowindex].Cells[6].Value.ToString(); // 연락처
            String EMAIL1 = dataGridView1.Rows[rowindex].Cells[7].Value.ToString(); // 이메일
            String ZIP1 = dataGridView1.Rows[rowindex].Cells[8].Value.ToString(); // 우편번호
            String ZIPADDR1 = dataGridView1.Rows[rowindex].Cells[9].Value.ToString(); // 주소
            String ADDR1 = dataGridView1.Rows[rowindex].Cells[10].Value.ToString(); // 주소나머지
            String DOR_USE1 = dataGridView1.Rows[rowindex].Cells[11].Value.ToString(); // 사용구분
            String DOR_NAME1 = dataGridView1.Rows[rowindex].Cells[12].Value.ToString(); // 기숙사 이름
            String DOR_DON1 = dataGridView1.Rows[rowindex].Cells[13].Value.ToString(); // 동
            String DOR_MB1 = dataGridView1.Rows[rowindex].Cells[14].Value.ToString(); // 호실
            String ACC_BANK_NO1 = dataGridView1.Rows[rowindex].Cells[15].Value.ToString(); // 은행코드
            String ACC_BANK1 = dataGridView1.Rows[rowindex].Cells[16].Value.ToString(); // 은행명
            String ACC_NAME1 = dataGridView1.Rows[rowindex].Cells[17].Value.ToString(); // 예금주
            String ACC_NO1 = dataGridView1.Rows[rowindex].Cells[18].Value.ToString(); // 계좌번호            

            STUNO.Text = STUNO1;
            RESNO.Text = RESNO1;
            NAME.Text = NAME1;
            FIX.Text = FIX1;
            DEPART.Text = DEPART_NO1;
            DEPART_NAME.Text = DEPART1;
            PHONE.Text = PHONE1;
            EMAIL.Text = EMAIL1;
            ZIP.Text = ZIP1;
            ZIPADDR.Text = ZIPADDR1;
            ADDR.Text = ADDR1;

            if (DOR_USE1 == "사용")
            {
                DOR_USE.Checked = true;
            }
            else
            {
                DOR_USE.Checked = false;
            }
            DOR_NAME.Text = DOR_NAME1;
            DOR_DON.Text = DOR_DON1;
            DOR_MB.Text = DOR_MB1;
            ACC_BANK.Text = ACC_BANK_NO1;
            ACC_BANK_NAME.Text = ACC_BANK1;
            ACC_NAME.Text = ACC_NAME1;
            ACC_NO.Text = ACC_NO1;            

            picture_load();
        }

        #region 업데이트문
        private void update_btn_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            String STUNO1 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //학번

            if (STUNO1 != STUNO.Text)
            {
                MessageBox.Show("학번은 변경 불가능 합니다.");
                return;
            }
            OracleConnection con = new OracleConnection(css);
            con.Open();

            Bitmap bitmap = new Bitmap((Image)STU_IMG.BackgroundImage);
            ImageConverter converter = new ImageConverter();
            byte[] b = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = @"UPDATE P22_LMG_TATM_STU SET
                                                STU_RESNO = :RESNO, STU_NAME = :NAME, STU_FIX = :FIX, STU_DEPART_NO = :DEPART_NO,
                                                STU_DEPART = :DEPART, STU_PHONE = :PHONE, STU_EMAIL = :EMAIL, STU_ZIP = :ZIP,
                                                STU_ZIPADDR = :ZIPADDR, STU_ADDR = :ADDR, STU_DOR_USE = :DOR_USE, STU_DOR_NAME = :DOR_NAME,
                                                STU_DOR_DON = :DOR_DON, STU_DOR_MB = :DOR_MB, STU_ACC_BANK_CODE = :ACC_BANK_NO,
                                                STU_ACC_BANK = :ACC_BANK, STU_ACC_NAME = :ACC_NAME, STU_ACC_NO = :ACC_NO, STU_IMG = :STU_IMG
                                            WHERE STU_STUNO = :STUNO";
            // a는 DOR_USE가 체크 되있는지 확인하는 변수            
            string a = Dor_Use_Check();
            cmd.Parameters.Add(new OracleParameter("STUNO", STUNO.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("RESNO", RESNO.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("NAME", NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("FIX", FIX.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DEPART_NO", DEPART.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DEPART", DEPART_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("PHONE", PHONE.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("EMAIL", EMAIL.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ZIP", ZIP.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ZIPADDR", ZIPADDR.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ADDR", ADDR.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_USE", a.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_NAME", DOR_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_DON", DOR_DON.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("DOR_MB", DOR_MB.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_BANK_NO", ACC_BANK.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_BANK", ACC_BANK_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_NAME", ACC_NAME.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("ACC_NO", ACC_NO.Text.ToString()));
            cmd.Parameters.Add(new OracleParameter("STU_IMG", OracleDbType.Blob, b.Length, b, ParameterDirection.Input));

            cmd.ExecuteNonQuery();
            MessageBox.Show("수정이 완료되었습니다.");
            reset_student();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            delete_sql();
        }

        #region 선택한 행 삭제
        public void delete_sql()
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            String indexvalue = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            conn = new OracleConnection(css);
            conn.Open();
            OracleCommand cmdd = new OracleCommand();
            cmdd.Connection = conn;
            //선택한 동과 같은 값을 db에서 찾아서 제거
            cmdd.CommandText = "DELETE P22_LMG_TATM_STU WHERE STU_STUNO = '" + indexvalue + "'";
            MessageBox.Show("삭제가 완료되었습니다.");
            cmdd.ExecuteNonQuery();
            reset_student();
            conn.Close();
        }
        #endregion
    }

}


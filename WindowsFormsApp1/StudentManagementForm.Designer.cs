
namespace WindowsFormsApp1
{
    partial class StudentManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SearchBox1 = new System.Windows.Forms.TextBox();
            this.SearchBox2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ACC_BANK_BTN = new System.Windows.Forms.Button();
            this.ACC_BANK = new System.Windows.Forms.TextBox();
            this.ACC_NO = new System.Windows.Forms.TextBox();
            this.ACC_NAME = new System.Windows.Forms.TextBox();
            this.ACC_BANK_NAME = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DEPART_BTN = new System.Windows.Forms.Button();
            this.DEPART = new System.Windows.Forms.TextBox();
            this.DEPART_NAME = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RESNO = new System.Windows.Forms.TextBox();
            this.DOR_USE = new WindowsFormsApp1.CheckedGroupBox();
            this.DOR_DON = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DOR_NAME = new System.Windows.Forms.TextBox();
            this.DOR_MB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DOR_BTN = new System.Windows.Forms.Button();
            this.STU_IMG_BTN = new System.Windows.Forms.Button();
            this.FIX = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.NAME = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.STUNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ZIP_BTN = new System.Windows.Forms.Button();
            this.ADDR = new System.Windows.Forms.TextBox();
            this.ZIPADDR = new System.Windows.Forms.TextBox();
            this.PHONE = new System.Windows.Forms.TextBox();
            this.STU_IMG = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EMAIL = new System.Windows.Forms.TextBox();
            this.ZIP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DOR_USE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.STU_IMG)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.10204F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.12245F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.58575F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.925094F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.55431F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 534);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 56);
            this.panel4.Name = "panel4";
            this.tableLayoutPanel1.SetRowSpan(this.panel4, 2);
            this.panel4.Size = new System.Drawing.Size(426, 475);
            this.panel4.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(426, 475);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 47);
            this.panel2.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SearchBox1);
            this.groupBox4.Controls.Add(this.SearchBox2);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(426, 47);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "학생 검색";
            // 
            // SearchBox1
            // 
            this.SearchBox1.Font = new System.Drawing.Font("굴림", 9F);
            this.SearchBox1.Location = new System.Drawing.Point(39, 20);
            this.SearchBox1.Name = "SearchBox1";
            this.SearchBox1.Size = new System.Drawing.Size(106, 21);
            this.SearchBox1.TabIndex = 1;
            this.SearchBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox11_KeyDown);
            // 
            // SearchBox2
            // 
            this.SearchBox2.Font = new System.Drawing.Font("굴림", 9F);
            this.SearchBox2.Location = new System.Drawing.Point(186, 20);
            this.SearchBox2.Name = "SearchBox2";
            this.SearchBox2.Size = new System.Drawing.Size(88, 21);
            this.SearchBox2.TabIndex = 2;
            this.SearchBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox2_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("굴림", 9F);
            this.label20.Location = new System.Drawing.Point(4, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 2;
            this.label20.Text = "학번";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("굴림", 9F);
            this.label21.Location = new System.Drawing.Point(151, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 3;
            this.label21.Text = "이름";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(435, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(346, 528);
            this.panel1.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ACC_BANK_BTN);
            this.groupBox1.Controls.Add(this.ACC_BANK);
            this.groupBox1.Controls.Add(this.ACC_NO);
            this.groupBox1.Controls.Add(this.ACC_NAME);
            this.groupBox1.Controls.Add(this.ACC_BANK_NAME);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.DEPART_BTN);
            this.groupBox1.Controls.Add(this.DEPART);
            this.groupBox1.Controls.Add(this.DEPART_NAME);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RESNO);
            this.groupBox1.Controls.Add(this.DOR_USE);
            this.groupBox1.Controls.Add(this.STU_IMG_BTN);
            this.groupBox1.Controls.Add(this.FIX);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.NAME);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.STUNO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ZIP_BTN);
            this.groupBox1.Controls.Add(this.ADDR);
            this.groupBox1.Controls.Add(this.ZIPADDR);
            this.groupBox1.Controls.Add(this.PHONE);
            this.groupBox1.Controls.Add(this.STU_IMG);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.EMAIL);
            this.groupBox1.Controls.Add(this.ZIP);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("굴림", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 528);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "학생정보";
            // 
            // ACC_BANK_BTN
            // 
            this.ACC_BANK_BTN.Font = new System.Drawing.Font("굴림", 8F);
            this.ACC_BANK_BTN.Location = new System.Drawing.Point(122, 394);
            this.ACC_BANK_BTN.Name = "ACC_BANK_BTN";
            this.ACC_BANK_BTN.Size = new System.Drawing.Size(55, 21);
            this.ACC_BANK_BTN.TabIndex = 97;
            this.ACC_BANK_BTN.Text = "찾기";
            this.ACC_BANK_BTN.UseVisualStyleBackColor = true;
            // 
            // ACC_BANK
            // 
            this.ACC_BANK.Font = new System.Drawing.Font("굴림", 9F);
            this.ACC_BANK.Location = new System.Drawing.Point(69, 395);
            this.ACC_BANK.Name = "ACC_BANK";
            this.ACC_BANK.ReadOnly = true;
            this.ACC_BANK.Size = new System.Drawing.Size(47, 21);
            this.ACC_BANK.TabIndex = 95;
            // 
            // ACC_NO
            // 
            this.ACC_NO.Font = new System.Drawing.Font("굴림", 9F);
            this.ACC_NO.Location = new System.Drawing.Point(69, 451);
            this.ACC_NO.MaxLength = 20;
            this.ACC_NO.Name = "ACC_NO";
            this.ACC_NO.Size = new System.Drawing.Size(232, 21);
            this.ACC_NO.TabIndex = 100;
            // 
            // ACC_NAME
            // 
            this.ACC_NAME.Font = new System.Drawing.Font("굴림", 9F);
            this.ACC_NAME.Location = new System.Drawing.Point(69, 424);
            this.ACC_NAME.MaxLength = 10;
            this.ACC_NAME.Name = "ACC_NAME";
            this.ACC_NAME.Size = new System.Drawing.Size(108, 21);
            this.ACC_NAME.TabIndex = 99;
            // 
            // ACC_BANK_NAME
            // 
            this.ACC_BANK_NAME.Font = new System.Drawing.Font("굴림", 9F);
            this.ACC_BANK_NAME.Location = new System.Drawing.Point(184, 394);
            this.ACC_BANK_NAME.MaxLength = 20;
            this.ACC_BANK_NAME.Name = "ACC_BANK_NAME";
            this.ACC_BANK_NAME.ReadOnly = true;
            this.ACC_BANK_NAME.Size = new System.Drawing.Size(117, 21);
            this.ACC_BANK_NAME.TabIndex = 98;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("굴림", 9F);
            this.label18.Location = new System.Drawing.Point(10, 454);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 93;
            this.label18.Text = "계좌번호";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("굴림", 9F);
            this.label17.Location = new System.Drawing.Point(22, 424);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 94;
            this.label17.Text = "예금주";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("굴림", 9F);
            this.label16.Location = new System.Drawing.Point(34, 398);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 96;
            this.label16.Text = "은행";
            // 
            // DEPART_BTN
            // 
            this.DEPART_BTN.Font = new System.Drawing.Font("굴림", 8F);
            this.DEPART_BTN.Location = new System.Drawing.Point(274, 112);
            this.DEPART_BTN.Name = "DEPART_BTN";
            this.DEPART_BTN.Size = new System.Drawing.Size(55, 21);
            this.DEPART_BTN.TabIndex = 72;
            this.DEPART_BTN.Text = "찾기";
            this.DEPART_BTN.UseVisualStyleBackColor = true;
            // 
            // DEPART
            // 
            this.DEPART.Font = new System.Drawing.Font("굴림", 9F);
            this.DEPART.Location = new System.Drawing.Point(199, 112);
            this.DEPART.Name = "DEPART";
            this.DEPART.ReadOnly = true;
            this.DEPART.Size = new System.Drawing.Size(57, 21);
            this.DEPART.TabIndex = 71;
            // 
            // DEPART_NAME
            // 
            this.DEPART_NAME.Font = new System.Drawing.Font("굴림", 9F);
            this.DEPART_NAME.Location = new System.Drawing.Point(199, 134);
            this.DEPART_NAME.Name = "DEPART_NAME";
            this.DEPART_NAME.ReadOnly = true;
            this.DEPART_NAME.Size = new System.Drawing.Size(130, 21);
            this.DEPART_NAME.TabIndex = 73;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("굴림", 8F);
            this.label22.Location = new System.Drawing.Point(335, 51);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 11);
            this.label22.TabIndex = 92;
            this.label22.Text = "( - 생략)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F);
            this.label2.Location = new System.Drawing.Point(140, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 91;
            this.label2.Text = "주민번호";
            // 
            // RESNO
            // 
            this.RESNO.Font = new System.Drawing.Font("굴림", 9F);
            this.RESNO.Location = new System.Drawing.Point(199, 47);
            this.RESNO.MaxLength = 13;
            this.RESNO.Name = "RESNO";
            this.RESNO.Size = new System.Drawing.Size(130, 21);
            this.RESNO.TabIndex = 67;
            // 
            // DOR_USE
            // 
            this.DOR_USE.Checked = true;
            this.DOR_USE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DOR_USE.Controls.Add(this.DOR_DON);
            this.DOR_USE.Controls.Add(this.label14);
            this.DOR_USE.Controls.Add(this.DOR_NAME);
            this.DOR_USE.Controls.Add(this.DOR_MB);
            this.DOR_USE.Controls.Add(this.label15);
            this.DOR_USE.Controls.Add(this.label10);
            this.DOR_USE.Controls.Add(this.DOR_BTN);
            this.DOR_USE.Location = new System.Drawing.Point(17, 279);
            this.DOR_USE.Name = "DOR_USE";
            this.DOR_USE.Size = new System.Drawing.Size(312, 110);
            this.DOR_USE.TabIndex = 80;
            this.DOR_USE.TabStop = false;
            this.DOR_USE.Text = "기숙사 사용여부";
            this.DOR_USE.ThreeState = false;
            // 
            // DOR_DON
            // 
            this.DOR_DON.Font = new System.Drawing.Font("굴림", 9F);
            this.DOR_DON.Location = new System.Drawing.Point(97, 59);
            this.DOR_DON.Name = "DOR_DON";
            this.DOR_DON.ReadOnly = true;
            this.DOR_DON.Size = new System.Drawing.Size(63, 21);
            this.DOR_DON.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 9F);
            this.label14.Location = new System.Drawing.Point(74, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 56;
            this.label14.Text = "동";
            // 
            // DOR_NAME
            // 
            this.DOR_NAME.Font = new System.Drawing.Font("굴림", 9F);
            this.DOR_NAME.Location = new System.Drawing.Point(97, 32);
            this.DOR_NAME.Name = "DOR_NAME";
            this.DOR_NAME.ReadOnly = true;
            this.DOR_NAME.Size = new System.Drawing.Size(97, 21);
            this.DOR_NAME.TabIndex = 15;
            // 
            // DOR_MB
            // 
            this.DOR_MB.Font = new System.Drawing.Font("굴림", 9F);
            this.DOR_MB.Location = new System.Drawing.Point(200, 60);
            this.DOR_MB.Name = "DOR_MB";
            this.DOR_MB.Size = new System.Drawing.Size(63, 21);
            this.DOR_MB.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 9F);
            this.label15.Location = new System.Drawing.Point(165, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 52;
            this.label15.Text = "호실";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F);
            this.label10.Location = new System.Drawing.Point(62, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 50;
            this.label10.Text = "이름";
            // 
            // DOR_BTN
            // 
            this.DOR_BTN.Font = new System.Drawing.Font("굴림", 8F);
            this.DOR_BTN.Location = new System.Drawing.Point(200, 31);
            this.DOR_BTN.Name = "DOR_BTN";
            this.DOR_BTN.Size = new System.Drawing.Size(55, 21);
            this.DOR_BTN.TabIndex = 16;
            this.DOR_BTN.Text = "찾기";
            this.DOR_BTN.UseVisualStyleBackColor = true;
            // 
            // STU_IMG_BTN
            // 
            this.STU_IMG_BTN.Location = new System.Drawing.Point(17, 137);
            this.STU_IMG_BTN.Name = "STU_IMG_BTN";
            this.STU_IMG_BTN.Size = new System.Drawing.Size(113, 23);
            this.STU_IMG_BTN.TabIndex = 81;
            this.STU_IMG_BTN.Text = "사진 선택";
            this.STU_IMG_BTN.UseVisualStyleBackColor = true;
            // 
            // FIX
            // 
            this.FIX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FIX.FormattingEnabled = true;
            this.FIX.Items.AddRange(new object[] {
            "남",
            "여"});
            this.FIX.Location = new System.Drawing.Point(199, 91);
            this.FIX.Name = "FIX";
            this.FIX.Size = new System.Drawing.Size(57, 20);
            this.FIX.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F);
            this.label8.Location = new System.Drawing.Point(164, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 89;
            this.label8.Text = "성별";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("굴림", 9F);
            this.label19.Location = new System.Drawing.Point(164, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 90;
            this.label19.Text = "학과";
            // 
            // NAME
            // 
            this.NAME.Font = new System.Drawing.Font("굴림", 9F);
            this.NAME.Location = new System.Drawing.Point(199, 69);
            this.NAME.MaxLength = 20;
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(130, 21);
            this.NAME.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F);
            this.label4.Location = new System.Drawing.Point(164, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 87;
            this.label4.Text = "이름";
            // 
            // STUNO
            // 
            this.STUNO.Font = new System.Drawing.Font("굴림", 9F);
            this.STUNO.Location = new System.Drawing.Point(199, 25);
            this.STUNO.MaxLength = 9;
            this.STUNO.Name = "STUNO";
            this.STUNO.Size = new System.Drawing.Size(130, 21);
            this.STUNO.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F);
            this.label1.Location = new System.Drawing.Point(164, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 88;
            this.label1.Text = "학번";
            // 
            // ZIP_BTN
            // 
            this.ZIP_BTN.Font = new System.Drawing.Font("굴림", 8F);
            this.ZIP_BTN.Location = new System.Drawing.Point(144, 208);
            this.ZIP_BTN.Name = "ZIP_BTN";
            this.ZIP_BTN.Size = new System.Drawing.Size(55, 21);
            this.ZIP_BTN.TabIndex = 77;
            this.ZIP_BTN.Text = "찾기";
            this.ZIP_BTN.UseVisualStyleBackColor = true;
            // 
            // ADDR
            // 
            this.ADDR.Font = new System.Drawing.Font("굴림", 9F);
            this.ADDR.Location = new System.Drawing.Point(69, 252);
            this.ADDR.MaxLength = 100;
            this.ADDR.Name = "ADDR";
            this.ADDR.Size = new System.Drawing.Size(260, 21);
            this.ADDR.TabIndex = 79;
            // 
            // ZIPADDR
            // 
            this.ZIPADDR.Font = new System.Drawing.Font("굴림", 9F);
            this.ZIPADDR.Location = new System.Drawing.Point(69, 230);
            this.ZIPADDR.MaxLength = 100;
            this.ZIPADDR.Name = "ZIPADDR";
            this.ZIPADDR.ReadOnly = true;
            this.ZIPADDR.Size = new System.Drawing.Size(260, 21);
            this.ZIPADDR.TabIndex = 78;
            // 
            // PHONE
            // 
            this.PHONE.Font = new System.Drawing.Font("굴림", 9F);
            this.PHONE.Location = new System.Drawing.Point(199, 157);
            this.PHONE.MaxLength = 15;
            this.PHONE.Name = "PHONE";
            this.PHONE.Size = new System.Drawing.Size(130, 21);
            this.PHONE.TabIndex = 74;
            // 
            // STU_IMG
            // 
            this.STU_IMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.STU_IMG.Location = new System.Drawing.Point(17, 23);
            this.STU_IMG.Name = "STU_IMG";
            this.STU_IMG.Size = new System.Drawing.Size(113, 107);
            this.STU_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.STU_IMG.TabIndex = 69;
            this.STU_IMG.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F);
            this.label9.Location = new System.Drawing.Point(154, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 82;
            this.label9.Text = "이메일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F);
            this.label6.Location = new System.Drawing.Point(152, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 83;
            this.label6.Text = "연락처";
            // 
            // EMAIL
            // 
            this.EMAIL.Font = new System.Drawing.Font("굴림", 9F);
            this.EMAIL.Location = new System.Drawing.Point(199, 179);
            this.EMAIL.MaxLength = 30;
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.Size = new System.Drawing.Size(130, 21);
            this.EMAIL.TabIndex = 75;
            // 
            // ZIP
            // 
            this.ZIP.Font = new System.Drawing.Font("굴림", 9F);
            this.ZIP.Location = new System.Drawing.Point(69, 208);
            this.ZIP.MaxLength = 5;
            this.ZIP.Name = "ZIP";
            this.ZIP.Size = new System.Drawing.Size(71, 21);
            this.ZIP.TabIndex = 76;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 9F);
            this.label13.Location = new System.Drawing.Point(12, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 84;
            this.label13.Text = "상세주소";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 9F);
            this.label12.Location = new System.Drawing.Point(36, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 85;
            this.label12.Text = "주소";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F);
            this.label5.Location = new System.Drawing.Point(10, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 86;
            this.label5.Text = "우편번호";
            // 
            // StudentManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 534);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StudentManagementForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DOR_USE.ResumeLayout(false);
            this.DOR_USE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.STU_IMG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox SearchBox1;
        private System.Windows.Forms.TextBox SearchBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ACC_BANK_BTN;
        private System.Windows.Forms.TextBox ACC_BANK;
        private System.Windows.Forms.TextBox ACC_NO;
        private System.Windows.Forms.TextBox ACC_NAME;
        private System.Windows.Forms.TextBox ACC_BANK_NAME;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button DEPART_BTN;
        private System.Windows.Forms.TextBox DEPART;
        private System.Windows.Forms.TextBox DEPART_NAME;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RESNO;
        private CheckedGroupBox DOR_USE;
        private System.Windows.Forms.TextBox DOR_DON;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox DOR_NAME;
        private System.Windows.Forms.TextBox DOR_MB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button DOR_BTN;
        private System.Windows.Forms.Button STU_IMG_BTN;
        private System.Windows.Forms.ComboBox FIX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox NAME;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox STUNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ZIP_BTN;
        private System.Windows.Forms.TextBox ADDR;
        private System.Windows.Forms.TextBox ZIPADDR;
        private System.Windows.Forms.TextBox PHONE;
        private System.Windows.Forms.PictureBox STU_IMG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EMAIL;
        private System.Windows.Forms.TextBox ZIP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
    }
}
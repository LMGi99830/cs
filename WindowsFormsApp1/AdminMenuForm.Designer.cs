
namespace WindowsFormsApp1
{
    partial class AdminMenuForm
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
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("관리자 등록");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("관리자관리", new System.Windows.Forms.TreeNode[] {
            treeNode55});
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("학생인사정보등록/조회");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("학생관리", new System.Windows.Forms.TreeNode[] {
            treeNode57});
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("현장실습등록");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("현장실습신청인원신청/조회/승인");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("현장실습관리", new System.Windows.Forms.TreeNode[] {
            treeNode59,
            treeNode60});
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("출퇴근관리");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("근태현황");
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("근태관리", new System.Windows.Forms.TreeNode[] {
            treeNode62,
            treeNode63});
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("은행 등록");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("기숙사 등록");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("근태 등록");
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("지원분야 등록");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("코드관리", new System.Windows.Forms.TreeNode[] {
            treeNode65,
            treeNode66,
            treeNode67,
            treeNode68});
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("관리자", new System.Windows.Forms.TreeNode[] {
            treeNode56,
            treeNode58,
            treeNode61,
            treeNode64,
            treeNode69});
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("출/퇴근");
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("학생", new System.Windows.Forms.TreeNode[] {
            treeNode71});
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.09494F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.43987F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.406953F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.59305F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 761);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 684);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode55.Name = "노드1";
            treeNode55.Text = "관리자 등록";
            treeNode56.Name = "노드0";
            treeNode56.Text = "관리자관리";
            treeNode57.Name = "노드3";
            treeNode57.Text = "학생인사정보등록/조회";
            treeNode58.Name = "노드0";
            treeNode58.Text = "학생관리";
            treeNode59.Name = "노드4";
            treeNode59.Text = "현장실습등록";
            treeNode60.Name = "노드9";
            treeNode60.Text = "현장실습신청인원신청/조회/승인";
            treeNode61.Name = "노드1";
            treeNode61.Text = "현장실습관리";
            treeNode62.Name = "노드3";
            treeNode62.Text = "출퇴근관리";
            treeNode63.Name = "노드7";
            treeNode63.Text = "근태현황";
            treeNode64.Name = "노드2";
            treeNode64.Text = "근태관리";
            treeNode65.Name = "노드1";
            treeNode65.Text = "은행 등록";
            treeNode66.Name = "노드2";
            treeNode66.Text = "기숙사 등록";
            treeNode67.Name = "노드3";
            treeNode67.Text = "근태 등록";
            treeNode68.Name = "노드4";
            treeNode68.Text = "지원분야 등록";
            treeNode69.Name = "노드0";
            treeNode69.Text = "코드관리";
            treeNode70.Name = "노드1";
            treeNode70.Text = "관리자";
            treeNode71.Name = "노드5";
            treeNode71.Text = "출/퇴근";
            treeNode72.Name = "노드2";
            treeNode72.Text = "학생";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode70,
            treeNode72});
            this.treeView1.Size = new System.Drawing.Size(248, 684);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(257, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 684);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1004, 684);
            this.tabControl1.TabIndex = 0;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(257, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 65);
            this.panel3.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(902, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 23);
            this.button4.TabIndex = 1;
            this.button4.Tag = "btn_load";
            this.button4.Text = "조회";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(803, 39);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "신청";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(704, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 3;
            this.button3.Tag = "btn_delete";
            this.button3.Text = "삭제";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(606, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 4;
            this.button2.Tag = "btn_update";
            this.button2.Text = "수정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 5;
            this.button1.Tag = "btn_enrollment";
            this.button1.Text = "등록";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 65);
            this.panel4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "근태관리 시스템";
            // 
            // AdminMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AdminMenuForm";
            this.Text = "AdminMenuForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
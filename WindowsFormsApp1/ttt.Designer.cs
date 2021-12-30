
namespace WindowsFormsApp1
{
    partial class ttt
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkedGroupBox1 = new WindowsFormsApp1.CheckedGroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.checkedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedGroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // checkedGroupBox1
            // 
            this.checkedGroupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.checkedGroupBox1.Checked = false;
            this.checkedGroupBox1.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.checkedGroupBox1.Controls.Add(this.textBox1);
            this.checkedGroupBox1.Enabled = false;
            this.checkedGroupBox1.Location = new System.Drawing.Point(100, 65);
            this.checkedGroupBox1.Name = "checkedGroupBox1";
            this.checkedGroupBox1.Size = new System.Drawing.Size(251, 100);
            this.checkedGroupBox1.TabIndex = 0;
            this.checkedGroupBox1.TabStop = false;
            this.checkedGroupBox1.Text = "ch123";
            this.checkedGroupBox1.ThreeState = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // ttt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ttt";
            this.Text = "ttt";
            this.panel1.ResumeLayout(false);
            this.checkedGroupBox1.ResumeLayout(false);
            this.checkedGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CheckedGroupBox checkedGroupBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StudentManagementForm : Form
    {
        
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

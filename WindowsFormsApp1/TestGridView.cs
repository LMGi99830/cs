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
    public partial class TestGridView : Form
    {
        public TestGridView()
        {
            InitializeComponent();            
        }


        private void TestGridView_Load(object sender, EventArgs e)
        {
           

        }


        private void button1_Click(object sender, EventArgs e)
        {
            test frm = new test();
            frm.ShowDialog();
            textBox5.Text = frm._textBox1.ToString();
            textBox6.Text = frm._textBox2.ToString();


        }
       
    }
}

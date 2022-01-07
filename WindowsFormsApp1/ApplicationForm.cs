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
    public partial class ApplicationForm : Form
    {
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
    }
}

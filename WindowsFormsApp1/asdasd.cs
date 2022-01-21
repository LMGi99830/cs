using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;




namespace WindowsFormsApp1
{      

    public partial class asdasd : Form
    {
        string label2 = "";
        public asdasd()
        {
            InitializeComponent();                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("yyyyMMdd");


        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }
    }
}

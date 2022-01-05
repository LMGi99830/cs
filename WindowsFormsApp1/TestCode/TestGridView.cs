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
            //datagridview1 Columns
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Category";
            dataGridView1.Columns[2].Name = "Description";

            //datagridview2 Columns
            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].Name = "ID";
            dataGridView2.Columns[1].Name = "Category";
            dataGridView2.Columns[2].Name = "Description";


            dataGridView1.Rows.Add("1", "Computer", "Lorem Ipsum");
            dataGridView1.Rows.Add("2", "Book", "Lorem Ipsum");
            dataGridView1.Rows.Add("3", "Telephone", "Lorem Ipsum");
            dataGridView1.Rows.Add("4", "Card Reader", "Lorem Ipsum");
            dataGridView1.Rows.Add("5", "Modem", "Lorem Ipsum");
            dataGridView1.Rows.Add("6", "USB", "Lorem Ipsum");
            dataGridView1.Rows.Add("7", "Printer", "Lorem Ipsum");
            dataGridView1.Rows.Add("8", "Scanner", "Lorem Ipsum");


        }


        private void button1_Click(object sender, EventArgs e)
        {
            test frm = new test();
            frm.ShowDialog();
            textBox5.Text = frm._textBox1.ToString();
            textBox6.Text = frm._textBox2.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                this.dataGridView2.Rows.Add(rowData);
                
                
            }
        }
    }
}

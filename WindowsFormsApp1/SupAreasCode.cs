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
    public partial class SupAreasCode : Form
    {
        public SupAreasCode()
        {
            InitializeComponent();

            DataTable table = new DataTable();

            
            table.Columns.Add("코드명", typeof(string));
            table.Columns.Add("분야명", typeof(string));


            // 각각의 행에 내용을 입력합니다.
            table.Rows.Add("001", "컴퓨터정보융합과");
            table.Rows.Add("002", "디지털문화콘텐츠과");


            // 값들이 입력된 테이블을 DataGridView에 입력합니다.
            dataGridView1.DataSource = table;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SupAreasCode_Load(object sender, EventArgs e)
        {

        }
    }
}

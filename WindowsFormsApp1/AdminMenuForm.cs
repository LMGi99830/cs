using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApp1
{

    public partial class AdminMenuForm : Form
    {
        private Point _imageLocation = new Point(15, 5);
        private Point _imgHitArea = new Point(13, 2);
        string str = "";
        public AdminMenuForm()
        {
            InitializeComponent();
            // set the Mode of Drawing as Owner Drawn
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            // Add the Handler to draw the Image on Tab Pages
            tabControl1.DrawItem += tabControl1_DrawItem;

        }
        public static Dictionary<string, int> DICT_REMOVE_INDEX = new Dictionary<string, int>();
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            str = (e.Node.ToString()).Substring(10);
            //공장코드관리
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = true;
            switch (str)
            {                
                case "관리자 등록   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        AdminEnrollmentForm form = new AdminEnrollmentForm();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {                        
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    
                    break;
                case "학생인사정보등록/조회   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        Type formType = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(a => a.BaseType == typeof(Form) && a.Name == "StudentManagementForm")
                         .FirstOrDefault();
                        Form form = (Form)Activator.CreateInstance(formType);  // 동적생성(폼)
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    break;
                case "현장실습등록   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        PracticeForm form = new PracticeForm();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    break;
                case "현장실습신청인원신청/조회/승인   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        application form = new application();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    button1.Enabled = false;
                    button2.Enabled = false;
                    break;

                case "출퇴근관리   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        AdminAttendance form = new AdminAttendance();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    button1.Enabled = false;
                    button3.Enabled = false;
                    break;
                case "근태현황   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        AttendanceTotal form = new AttendanceTotal();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    break;
                case "휴일관리   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        HolidayForm form = new HolidayForm();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    break;
                case "은행 등록   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        BnkCode form = new BnkCode();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    button6.Enabled = false;
                    break;
                case "기숙사 등록   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        DormiCode form = new DormiCode();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    button6.Enabled = false;
                    break;
                case "근태 등록   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        AtdCode form = new AtdCode();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    button6.Enabled = false;
                    break;
                case "지원분야 등록   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        SupAreasCode form = new SupAreasCode();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    button6.Enabled = false;
                    break;
                case "출/퇴근   ": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        AttendanceForm form = new AttendanceForm();
                        form.TopLevel = false;
                        tabControl1.TabPages.Add(str);
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                        AdminMenuForm.DICT_REMOVE_INDEX.Add(str, tabControl1.SelectedIndex); //Dictionary로 화면텍스트와 탭번호 저장
                        form.Dock = DockStyle.Fill;                        
                        form.Show();
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[AdminMenuForm.DICT_REMOVE_INDEX[str]];
                    }
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button6.Enabled = false;
                    break;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ApplicationForm Form1 = new ApplicationForm();
            Form1.StartPosition = FormStartPosition.Manual; 
            Form1.Location = new Point(850, 110);
            Form1.Show();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            tabControl1
                .SelectedTab.Controls[0]
                .GetType()
                .GetMethod("btn_enrollment")
                .Invoke(tabControl1.SelectedTab.Controls[0], null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1
                .SelectedTab.Controls[0]
                .GetType()
                .GetMethod("btn_load")
                .Invoke(tabControl1.SelectedTab.Controls[0], null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1
                .SelectedTab.Controls[0]
                .GetType()
                .GetMethod("btn_update")
                .Invoke(tabControl1.SelectedTab.Controls[0], null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1
                .SelectedTab.Controls[0]
                .GetType()
                .GetMethod("btn_delete")
                .Invoke(tabControl1.SelectedTab.Controls[0], null);
        }
        public void Enabled_btn()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("로그 아웃 되었습니다.");
            this.Close(); // 현재 폼 종료, Application.Restart만 하니깐 현재 폼이 안죽음
            Application.Restart(); // 현재 어플리케이션을 종료하고 즉시 새 인스턴스를 시작
            


        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                // Close Image to draw
                Image img = new Bitmap("C:\\Close.gif");

                Rectangle r = e.Bounds;
                r = this.tabControl1.GetTabRect(e.Index);
                r.Offset(2, 2);

                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;

                string title = this.tabControl1.TabPages[e.Index].Text;

                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
                e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
            }
            catch (Exception) { }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var _key = AdminMenuForm.DICT_REMOVE_INDEX.FirstOrDefault(x => x.Value == tabControl1.SelectedIndex).Key;            
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tabControl1.GetTabRect(tc.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tabControl1.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (r.Contains(p))
            {
                TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                tc.TabPages.Remove(TabP);
                AdminMenuForm.DICT_REMOVE_INDEX.Remove(_key);
            }            
        }
    }
}



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

    public partial class AdminMenuForm : Form
    {
        public AdminMenuForm()
        {
            InitializeComponent();

        }
        public static Dictionary<string, int> DICT_REMOVE_INDEX = new Dictionary<string, int>();
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
            {
               
            }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = (e.Node.ToString()).Substring(10);
            //공장코드관리

            switch (str)
            {
                case "학생인사정보등록/조회": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        StudentManagementForm form = new StudentManagementForm();
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
                case "현장실습등록": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                case "현장실습신청인원신청/조회/승인": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                    break;

                case "출퇴근관리": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                    break;
                case "근태현황": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    MessageBox.Show("점검중");
                    break;
                case "은행 등록": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                    break;
                case "기숙사 등록": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                    break;
                case "근태 등록": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                    break;
                case "지원분야 등록": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                    break;
                case "출/퇴근": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
                    break;
            }
        }        

        private void button6_Click_1(object sender, EventArgs e)
        {
            new ApplicationForm().Show();
        }
    }

}


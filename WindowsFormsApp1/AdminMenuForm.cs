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
        public AdminMenuForm()
        {
            InitializeComponent();

        }
        public static Dictionary<string, int> DICT_REMOVE_INDEX = new Dictionary<string, int>();
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            string str = (e.Node.ToString()).Substring(10);
            //공장코드관리

            switch (str)
            {
                case "관리자 등록": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
                    if (!AdminMenuForm.DICT_REMOVE_INDEX.ContainsKey(str))
                    {
                        Type formType = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(a => a.BaseType == typeof(Form) && a.Name == "AdminEnrollmentForm")
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
                case "학생인사정보등록/조회": //탭이 겹치면 그 탭을 열고 겹치는 탭이 없으면 새로운 탭 생성
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
            ApplicationForm Form1 = new ApplicationForm();
            Form1.StartPosition = FormStartPosition.Manual; 
            Form1.Location = new Point(850, 110);
            Form1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //버튼1
            String btg = (String)(sender as Button).Tag as string;

            Form form = (Form)tabControl1.SelectedTab.Controls[0];
            Type type = form.GetType();  //> system.type의 형식결과를 반환 (메소드,필드, 프로퍼피등) 표현
            System.Reflection.MethodInfo mtd = type.GetMethod(btg);

            if (mtd == null) return;

            //폼2에 있는 버튼클릭 메소드를 호출한다.
            mtd.Invoke(form, null);

        }

        private void AdminMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}



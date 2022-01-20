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
    // 웹브라우저컨트롤을 위해서..
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]    


    public partial class asdasd : Form
    {
        /// <summary>
        /// 반환할 우편코드와 주소
        /// </summary>
        public string gstrZipCode = "";
        public string gstrAddress1 = "";        


        public asdasd()
        {
            InitializeComponent();
            wb.Navigate("http://요기에 웹페이지가 있는 주소를 넣음");
            wb.ObjectForScripting = this; // 제일 중요            

        }
        /// <summary>
        /// 해당 브라우저에 있는 javascript 함수 명 호출
        /// </summary>
        /// <param name="sZipCode"></param>
        /// <param name="sAddress1"></param>
        public void CallForm(object sZipCode, object sAddress1)
        {
            try
            {
                gstrZipCode = (string)sZipCode;
                gstrAddress1 = (string)sAddress1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        [출처] c# winform 다음 주소api 사용하기|작성자 지워진기억



    }
}

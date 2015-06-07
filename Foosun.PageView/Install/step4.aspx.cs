using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Foosun.CMS;

namespace Foosun.PageView.Install
{
    public partial class step4 :Foosun.PageBasic.BasePage
    {
        public string gError = string.Empty;
        Foosun.CMS.Admin cadmin = new Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Attributes.Add("onclick", "return showLoading();");
            gError = Request.QueryString["error"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string adminUserName = this.UserName.Text;
            string Password = this.Password.Text;
            string cPassword = this.confimPassword.Text;          
            if (adminUserName.Length < 1)
            {
                Response.Redirect("step4.aspx?error=\"请输入管理员用户名\"");
            }
            if (Password.Length < 3)
            {
                Response.Redirect("step4.aspx?error=\"密码不能小于3位\"");
            }
            if (Password != cPassword)
            {
                Response.Redirect("step4.aspx?error=\"2次密码不一致！\"");
            }
            Foosun.Model.AdminInfo madmin = new Foosun.Model.AdminInfo();
            madmin.UserName = adminUserName;
            madmin.UserPassword = Common.Input.MD5(Password, true);
            madmin.RealName ="admin";
            madmin.isAdmin = 1;
            madmin.Email = "";
            madmin.UserFace = "/sysImages/user/noHeadpic.gif";
            madmin.userFacesize = "50|50";
            madmin.RegTime = DateTime.Now;
            madmin.SiteID = "0";
            madmin.LoginNumber = 0;
            madmin.OnlineTF = 0;
            madmin.OnlineTime = 0;
            madmin.isLock = 0;
            madmin.aPoint = 0;
            madmin.ePoint = 0;
            madmin.cPoint = 0;
            madmin.gPoint = 0;
            madmin.iPoint = 0;
            madmin.UserGroupNumber = "00000000001";
            madmin.adminGroupNumber = "00000001";
            madmin.isSuper = 1;
            madmin.OnlyLogin = 1;
            madmin.isChannel = 1;
            madmin.isChSupper = 0;
            madmin.Iplimited ="";
            if (cadmin.Add(madmin) > 0)
            {
                Response.Redirect("step_End.aspx?error=false");
            }
            else
            {
                Response.Redirect("step4.aspx?error=\"安装失败，可能已经有管理员存在！\"");
            }
        }
    }
}

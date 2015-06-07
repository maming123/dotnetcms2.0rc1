using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.PlugIn.Passport;

namespace Foosun.PageView.manage.user
{
    public partial class userAdd : Foosun.PageBasic.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void CreateFolder(string FolderPathName)
        {
            string _dirdum = Foosun.Config.UIConfig.dirDumm;
            string Userfiles = Foosun.Config.UIConfig.UserdirFile;
            string Path = string.Empty;
            if (_dirdum.Trim() != string.Empty)
            {
                _dirdum = "/" + _dirdum;
            }
            Path = _dirdum + "/" + Userfiles;
            string CreatePath = Server.MapPath(Path);
            try
            {
                Foosun.CMS.Templet tc = new Foosun.CMS.Templet();
                tc.AddDir(CreatePath, FolderPathName);
            }
            catch { }
        }

        protected void sumbitsave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                Foosun.CMS.user User = new Foosun.CMS.user();
                Foosun.Model.UserParam upi = upi = User.UserParam(SiteID);
                string UserName = txtUserName.Text.Trim();
                if (User.sel_username(UserName) != 0)
                {
                    PageError("注册失败，用户名已经被占用", "userAdd.aspx");
                }

                #region 取得会员表注册参数
                string pwd = txtPassword.Text.Trim();
                string UserPassword = Common.Input.MD5(pwd, true);
                string UserNum = Common.Rand.Number(12);//产生12位随机字符

                Foosun.Model.User ui = new Foosun.Model.User();
                Foosun.Model.UserFields ufi = new Foosun.Model.UserFields();

                ui.Id = 0;
                ui.UserNum = UserNum;
                ui.UserName = UserName;
                ui.UserPassword = UserPassword;
                ui.Email = txtEmail.Text.Trim();
                if (User.sel_email(ui.Email) != 0)
                {
                    PageError("注册失败，电子邮件已经被占用", "userAdd.aspx");
                }
                ui.isAdmin = 0;
                ui.UserGroupNumber = upi.RegGroupNumber;///取得注册时默认组编号
                ui.Sex = 0;
                ui.birthday = Convert.ToDateTime("1980-11-11");
                ui.Userinfo = "";
                ui.UserFace =  "/sysImages/user/noHeadpic.gif";
                ui.userFacesize = "80|80";
                ui.marriage = 0;

                ///取得注册时获得积分
                string[] selsetPoint = upi.setPoint.Split('|');
                string selectiPoint = selsetPoint[0].ToString();
                string selectgPoint = selsetPoint[1].ToString();
                ui.iPoint = Convert.ToInt32(selectiPoint);
                ui.gPoint = Convert.ToInt32(selectgPoint);

                ui.cPoint = 0;
                ui.aPoint = 0;
                ui.isLock = 0;
                ui.RegTime = DateTime.Now;
                ui.LastLoginTime = DateTime.Now;
                ui.OnlineTime = 0;
                ui.OnlineTF = 0;
                ui.LoginNumber = 0;
                ui.FriendClass = "";
                ui.LoginLimtNumber = 0;
                ui.LastIP = Common.Public.getUserIP();
                ui.SiteID = SiteID;
                ui.Addfriend = "2";
                ui.isOpen = 0;
                ui.ParmConstrNum = 0;

                ///注册是否需要实名验证
                Foosun.Model.UserGroup ugi = new Foosun.Model.UserGroup();
                ugi = User.UserGroup(upi.RegGroupNumber);
                ui.isIDcard = 0;
                ui.IDcardFiles = "";

                ui.Addfriendbs = 2;

                ///注册是否需要电子邮件验证
                if (upi.returnemail == 1)
                {
                    ui.EmailATF = 0;
                    ui.EmailCode = Common.Input.MD5(Common.Rand.Str(15), false); ;
                }
                else
                {
                    ui.EmailATF = 1;
                    ui.EmailCode = "";
                }

                ///注册是否需要手机验证
                if (upi.returnmobile == 1)
                {
                    ui.isMobile = 0;
                    ui.MobileCode = Foosun.CMS.FSSecurity.FDESEncrypt(Common.Rand.Str(8), 1);
                }
                else
                {
                    ui.isMobile = 1;
                    ui.MobileCode = "";
                }
                ui.BindTF = 0;
                ui.NickName = "";
                ui.RealName = "";
                ui.PassQuestion = "";
                ui.PassKey = "";
                ui.CertType = "";
                ui.CertNumber = "";
                ui.mobile = "";
                ufi.province = "";
                ufi.City = "";
                ufi.Address = "";
                ufi.Postcode = "";
                ufi.FaTel = "";
                ufi.WorkTel = "";
                ufi.Fax = "";
                ufi.QQ = "";
                ufi.MSN = "";
                ufi.ID = 0;
                ufi.userNum = UserNum;
                ufi.character = "";
                ufi.UserFan = "";
                ufi.Nation = "";
                ufi.nativeplace = "";
                ufi.Job = "";
                ufi.education = "";
                ufi.Lastschool = "";
                ufi.orgSch = "";
                #endregion
                #region 取得会员冲值记录参数
                Foosun.Model.UserGhistory ughi = new Foosun.Model.UserGhistory();
                ughi.Id = 0;
                ughi.GhID = Common.Rand.Number(12);//产生12位随机字符
                ughi.ghtype = 1;
                ughi.Gpoint = ui.gPoint;
                ughi.iPoint = ugi.iPoint;
                ughi.Money = 0;
                ughi.CreatTime = DateTime.Now;
                ughi.userNum = ui.UserNum;
                ughi.gtype = 7;
                ughi.content = "注册获得";
                ughi.SiteID = ui.SiteID;
                #endregion
                //在其他系统中同步注册
                DPO_Request request = new DPO_Request(this.Context);
                request.UserName = ui.UserName;
                request.EMail = ui.Email;
                request.PassWord = pwd;
                request.ProcessMultiPing("reguser");
                if (request.FoundErr)
                {
                    PageError("同步注册失败!<br/>" + string.Join(",", request.ErrStr.ToArray()), "userAdd.aspx");
                }
                else if (User.Add_User(ui) == 1 && User.Add_userfields(ufi) == 1 && User.Add_Ghistory(ughi) == 1)
                {
                    CreateFolder(ui.UserNum);

                    if (upi.returnemail == 1)
                    {
                        //发送电子邮件
                        string Emailto = ui.Email;
                        string EmailUserNum = ui.UserNum;
                        string EmailCode = ui.EmailCode;
                        string EmailFrom = Foosun.Config.UIConfig.emailfrom;
                        string EmailSmtpServer = Foosun.Config.UIConfig.smtpserver;
                        string EmailUserName = Foosun.Config.UIConfig.emailuserName;
                        string EmailPwd = Foosun.Config.UIConfig.emailuserpwd;
                        string subj = "邮件密码验证";

                        string bodys = "亲爱的" + UserName + ":<br />";
                        bodys += "&nbsp;&nbsp;您注册的用户名：" + UserName + ",用户编号：" + UserNum + ",密码：" + pwd + "<br />";
                        bodys += "&nbsp;&nbsp;请点击此联接激活您的电子邮件:" + Foosun.Publish.CommonData.SiteDomain + "/" + Foosun.Config.UIConfig.dirUser + "/info" +
                                 "/getPassport.aspx?t=mail&e=" + Common.Input.MD5(ui.Email, true) + "&" +
                                 "u=" + Common.Input.MD5(ui.UserNum, true) + "&c=" + ui.EmailCode + "";

                        Common.Public.sendMail(EmailSmtpServer, EmailUserName, EmailPwd, EmailFrom, Emailto, subj, bodys);
                    }
                    PageRight("<span style=\"font-size:14px;font-weight:bold;\">" +
                                                            "添加成功</span>", "userlist.aspx");
                }
                else
                {
                    PageError("注册失败!", "userAdd.aspx");
                }
            }
        }
    }
}
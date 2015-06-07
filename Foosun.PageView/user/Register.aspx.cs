using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;
using Foosun.PlugIn.Passport;
using Foosun.Model;
using System.Text.RegularExpressions;

namespace Foosun.PageView.user
{
    public partial class Register : Foosun.PageBasic.BasePage
    {
        string Userfiles = Foosun.Config.UIConfig.UserdirFile;
        new Foosun.CMS.user User = new Foosun.CMS.user();
        Foosun.Model.UserParam upi = new Foosun.Model.UserParam();
        Foosun.CMS.News cNew = new CMS.News();
        public string agreement = null;
        string _dirdum = Foosun.Config.UIConfig.dirDumm;
        protected void Page_Init(object sernder, EventArgs e)
        {
            Response.AppendHeader("P3P", "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");
            getRegInfo();

        }
        protected void getRegInfo()
        {
            checkUserName();

            if (_dirdum.Trim() != "")
                _dirdum = "/" + _dirdum;
            copyright.InnerHtml = CopyRight;
            string siteID = "0";
            if (upi == null)
                PageError("错误的频道ID，找不到记录.", "");
            upi = User.UserParam(siteID);
            if (upi.RegTF == 0)
                PageError("系统已关闭注册，不能注册", "");
            agreement = upi.RegContent;
            SiteID.Value = siteID;
            CreateControl();
            ImageButton bt2 = (ImageButton)Page.FindControl("storeBut");
            bt2.Click +=new ImageClickEventHandler (this.storeBut);
        }

        protected void checkUserName()
        {
            if (Request.Form["Action"] == "checkusername")
            {
                string str_Username = Request.Form["username"];
                Regex re = new Regex(@"[\u4e00-\u9fa5]", RegexOptions.Compiled);
                Match m = re.Match(str_Username);
                if (m.Success)
                {
                    if (str_Username.Length < 2)
                    {
                        Response.Write("用户名为中文时不少于两个字符!");
                        Response.End();
                    }
                    if (str_Username.Length > 16)
                    {
                        Response.Write("用户名为中文时不大于十八个字符!");
                        Response.End();
                    }
                }
                if (User.sel_username(str_Username) != 0)
                {
                    Response.Write("用户名已存在!");
                    Response.End();
                }
                else
                {
                    Response.Write("true");
                    Response.End();
                }
            }
            else if (Request.Form["Action"] == "checkemail")
            {
                if (User.sel_email(Request.Form["email"].ToString()) != 0)
                {
                    Response.Write("电子邮件地址已存在!");
                    Response.End();
                }
                else
                {
                    Response.Write("true");
                    Response.End();
                }
            }

        }
        protected void storeBut(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string UserName = Request.Form["usernameBox"].ToString();
                if (User.sel_username(UserName) != 0)
                {
                    PageError("注册失败，用户名已经被占用", "Register.aspx");
                }

                #region 取得会员表注册参数
                string pwd = Request.Form["pwdBox"].ToString();
                string UserPassword = Common.Input.MD5(pwd, true);
                string UserNum = Common.Rand.Number(12);//产生12位随机字符

                Foosun.Model.User ui = new Foosun.Model.User();
                Foosun.Model.UserFields ufi = new Foosun.Model.UserFields();

                ui.Id = 0;
                ui.UserNum = UserNum;
                ui.UserName = UserName;
                ui.UserPassword = UserPassword;

                ui.isAdmin = 0;
                ui.UserGroupNumber = upi.RegGroupNumber;///取得注册时默认组编号
                ui.Sex = 0;
                ui.birthday = Convert.ToDateTime("1980-11-11");
                ui.Userinfo = "";
                ui.UserFace = "" + Common.Public.GetSiteDomain() + "/Images/user/noHeadpic.gif";
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
                ui.SiteID = SiteID.Value;
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


                string[] regItem = upi.regItem.Split(',');
                ui.NickName = "";
                ui.RealName = "";
                ui.PassQuestion = "";
                ui.PassKey = "";
                ui.CertType = "";
                ui.CertNumber = "";
                ui.Email = "";
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
                for (int i = 0; i < regItem.Length; i++)
                {
                    if (regItem[i] == "NickName")
                        ui.NickName = Request.Form["NickNameBox"].ToString();
                    //else
                    //    ui.NickName = "";

                    if (regItem[i] == "RealName")
                        ui.RealName = Request.Form["RealNameBox"].ToString();
                    //else
                    //    ui.RealName = "";

                    if (regItem[i] == "PassQuestion")
                        ui.PassQuestion = Request.Form["PassQuestionBox"].ToString();
                    //else
                    //    ui.PassQuestion = "";

                    if (regItem[i] == "PassKey")
                        ui.PassKey = Request.Form["PassKeyBox"].ToString();
                    //else
                    //    ui.PassKey = "";

                    if (regItem[i] == "CertType")
                        ui.CertType = Request.Form["CertTypeBox"].ToString();
                    //else
                    //    ui.CertType = "";

                    if (regItem[i] == "CertNumber")
                        ui.CertNumber = Request.Form["CertNumberBox"].ToString();
                    //else
                    //    ui.CertNumber = "";

                    if (regItem[i] == "email")
                    {
                        ui.Email = Request.Form["emailBox"].ToString();
                        if (User.sel_email(Request.Form["emailBox"].ToString()) != 0)
                        {
                            PageError("注册失败，电子邮件已经被占用", "Register.aspx");
                        }
                    }
                    //else
                    //    ui.Email = "";

                    if (regItem[i] == "Mobile")
                        ui.mobile = Request.Form["MobileBox"].ToString();
                    //else
                    //    ui.mobile = "";
                #endregion

                    #region 取得会员附表参数
                    if (regItem[i] == "province")
                    {
                        ufi.province = Request.Form["province"].ToString();
                        DataTable dt = cNew.GetProvinceOrCityList("0");
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            //如果编号对应上了，则设置为名称
                            if (dt.Rows[j][1].ToString().Equals(ufi.province))
                            {
                                ufi.province = dt.Rows[j][0].ToString();
                                break;
                            }
                        }
                    }

                    if (regItem[i] == "City"&&Request.Form["City"]!=null)
                    {
                        ufi.City = Request.Form["City"].ToString();
                        //查询出此省份下的城市
                        DataTable dt = cNew.GetProvinceOrCityList(Request.Form["province"].ToString());
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            //如果编号对应上了，则设置为名称
                            if (dt.Rows[j][1].ToString().Equals(ufi.City))
                            {
                                ufi.City = dt.Rows[j][0].ToString();
                                break;
                            }
                        }
                    }
                    else
                        ufi.City = "";

                    if (regItem[i] == "Address")
                        ufi.Address = Request.Form["AddressBox"].ToString();
                    //else
                    //    ufi.Address = "";

                    if (regItem[i] == "Postcode")
                        ufi.Postcode = Request.Form["PostcodeBox"].ToString();
                    //else
                    //    ufi.Postcode = "";

                    if (regItem[i] == "FaTel")
                        ufi.FaTel = Request.Form["FaTelBox"].ToString();
                    //else
                    //    ufi.FaTel = "";

                    if (regItem[i] == "WorkTel")
                        ufi.WorkTel = Request.Form["WorkTelBox"].ToString();
                    //else
                    //    ufi.WorkTel = "";

                    if (regItem[i] == "Fax")
                        ufi.Fax = Request.Form["FaxBox"].ToString();
                    //else
                    //    ufi.Fax = "";

                    if (regItem[i] == "QQ")
                        ufi.QQ = Request.Form["QQBox"].ToString();
                    //else
                    //    ufi.QQ = "";

                    if (regItem[i] == "MSN")
                        ufi.MSN = Request.Form["MSNBox"].ToString();
                    //else
                    //    ufi.MSN = "";
                }
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
                string question = Request.Form["PassQuestionBox"];

                string answer = Request.Form["PassKeyBox"];
                request.Question = question;
                request.Answer = answer;
                request.ProcessMultiPing("reguser");
                if (request.FoundErr)
                {
                    PageError("同步注册失败!<br/>" + string.Join(",", request.ErrStr.ToArray()), "Register.aspx");
                }
                else if (User.Add_User(ui) == 1 && User.Add_userfields(ufi) == 1 && User.Add_Ghistory(ughi) == 1)
                {
                    CreateFolder(ui.UserNum);
                    Foosun.Global.Current.Set(new GlobalUserInfo(ui.UserNum, ui.UserName, ui.SiteID, "0"));

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
                        string subj = "激活您的帐号";

                        string activeUrl = Common.Public.GetDomainConfig() + "/" + Foosun.Config.UIConfig.dirUser + "/info" + "/getPassport.aspx?t=mail&e=" + Common.Input.MD5(ui.Email, true) + "&" + "u=" + Common.Input.MD5(ui.UserNum, true) + "&c=" + ui.EmailCode;

                        string bodys = "亲爱的" + UserName + ":<br />";
                        bodys += "&nbsp;&nbsp;您注册的用户名：" + UserName + ",用户编号：" + UserNum + ",密码：" + pwd + "<br />";
                        bodys += "&nbsp;&nbsp;请点<a href=\"" + activeUrl + "\" target=\"_blank\">击此连接</a>激活您的帐号。如果你无法点击，请复制下面的地址到浏览器来激活您的帐号。<br />激活地址：<br />" + activeUrl;

                        Common.Public.sendMail(EmailSmtpServer, EmailUserName, EmailPwd, EmailFrom, Emailto, subj, bodys);

                        PageRight("<span style=\"font-size:14px;font-weight:bold;\">" +
                                                            "恭喜(" + UserName + ")!您已经在本站注册成功。</span>" +
                                                            "<span style=\"color:red\">但是您需要验证电子邮件才能登陆.</span>" +
                                                            "<li>一封电子邮件已经发送到您的邮件：" + ui.Email + "</li>" +
                                                            "<li>您的用户名：" + UserName + "&nbsp;&nbsp;&nbsp;" +
                                                            "用户唯一编号：" + UserNum + "</li>", "login.aspx");
                    }

                    if (upi.returnmobile == 1)
                    {
                        //发送验证码到ISP
                        //如果成功转向到下面页面
                        Response.Redirect("info/MobileValidate.aspx?uid=" + UserName);
                    }

                    if (ugi.IsCert == 1)
                    {
                        Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert" +
                                       "('注册成功！\\n但是要求实名认证.\\n点 [确定] 进行实名认证。');" +
                                       "location.href='index.aspx?urls=" + Foosun.Publish.CommonData.SiteDomain + "/info/userinfo" +
                                       "_idcard.aspx?type=CreatCert\';</script>");
                        DPO_Request dporequest = new DPO_Request(Context);
                        dporequest.RequestLogin(UserName, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5").Substring(8, 16).ToLower(), string.Empty);
                        Response.End();
                    }
                    else
                    {
                        DPO_Request dporequest = new DPO_Request(Context);
                        dporequest.RequestLogin(UserName, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5").Substring(8, 16).ToLower(),
                            string.Format("{0}/user/index.aspx", Request.ApplicationPath == "/" ? string.Empty : Request.ApplicationPath)
                            );
                        Response.Write("注册成功，页面转接中，请稍候……");
                        Response.End();
                    }
                }
                else
                {
                    PageError("注册失败!", "Register.aspx");
                }
            }
        }

        #region  创建文件夹
        public void CreateFolder(string FolderPathName)
        {
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
        #endregion


        protected void CreateControl()
        {
            string[] arr_regItem = upi.regItem.Split(',');
            for (int i = 0; i < arr_regItem.Length; i++)
            {
                if (arr_regItem[i] == "UserName")
                {
                    string ctr = "<table class=\"table\"><tbody><tr><td class=\"tab1\" valign=\"top\" width=\"25%\">用户名：</td><td width=\"30%\"><asp:TextBox ID=\"usernameBox\" MaxLength=\"18\" runat=\"server\" class=\"inp width\"></asp:TextBox></td><td width=\"45%\"><div class=\"tishi fail\"></div></td></tr><tr><td class=\"tab1\" valign=\"top\"></td><td colspan=\"2\"><font class=\"span1\">4~18个字符，可使用字母、数字、符号</font></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "UserPassword")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">密码：</td><td><asp:TextBox ID=\"pwdBox\" runat=\"server\" class=\"inp width\" MaxLength=\"18\" TextMode=\"Password\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr><tr><td class=\"tab1\" valign=\"top\"></td><td colspan=\"2\"><font class=\"span1\">4~18个字符，区分大小写</font></td></tr><tr><td class=\"tab1\" valign=\"top\">确认密码：</td><td><asp:TextBox ID=\"pwdsBox\" runat=\"server\" class=\"inp width\" TextMode=\"Password\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "email")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">电子邮件：</td><td><asp:TextBox ID=\"emailBox\" runat=\"server\" class=\"inp width\" MaxLength=\"50\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "PassQuestion")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">密码问题：</td><td><asp:TextBox ID=\"PassQuestionBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "PassKey")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">密码问题答案：</td><td><asp:TextBox ID=\"PassKeyBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "RealName")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">真实姓名：</td><td><asp:TextBox ID=\"RealNameBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "NickName")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">昵称：</td><td><asp:TextBox ID=\"NickNameBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "CertType")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">证件类型：</td><td><asp:DropDownList ID=\"CertTypeBox\" runat=\"server\" class=\"inpm\"><asp:ListItem>身份证</asp:ListItem><asp:ListItem>学生证</asp:ListItem><asp:ListItem>驾驶证</asp:ListItem><asp:ListItem>军人证</asp:ListItem><asp:ListItem>护照</asp:ListItem></asp:DropDownList></td><td></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "CertNumber")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">证件号码：</td><td><asp:TextBox ID=\"CertNumberBox\" runat=\"server\" class=\"inp width\" MaxLength=\"18\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "province")
                {
                    DataTable dt = cNew.GetProvinceOrCityList("0");
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">省份：</td><td><select id=\"province\" name=\"province\" class=\"inpm\" onchange=\"GetSubClass(this.options[this.selectedIndex].value)\">";
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ctr += "<option value=\"" + dt.Rows[j][1].ToString() + "\">" + dt.Rows[j][0].ToString() + "</option>";

                    }
                    ctr += "</select></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }

                if (arr_regItem[i] == "City")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">城市：</td><td><div id=\"citydiv\"></div></td><td></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "Address")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">地址：</td><td><asp:TextBox ID=\"AddressBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "Postcode")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">邮政编码：</td><td><asp:TextBox ID=\"PostcodeBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "Mobile")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">手机：</td><td><asp:TextBox ID=\"MobileBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "Fax")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">传真：</td><td><asp:TextBox ID=\"FaxBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "WorkTel")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">工作电话：</td><td><asp:TextBox ID=\"WorkTelBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "FaTel")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">家庭电话：</td><td><asp:TextBox ID=\"FaTelBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "QQ")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">QQ：</td><td><asp:TextBox ID=\"QQBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
                if (arr_regItem[i] == "MSN")
                {
                    string ctr = "<tr><td class=\"tab1\" valign=\"top\">MSN：</td><td><asp:TextBox ID=\"MSNBox\" runat=\"server\" class=\"inp width\" MaxLength=\"16\"></asp:TextBox></td><td><div class=\"tishi fail\"></div></td></tr>";
                    Control ctrl = Page.ParseControl(ctr);
                    PlaceHolder1.Controls.Add(ctrl);
                }
            }

            string ctrs = "<tr><td class=\"tab1\" colspan=\"2\"><input type=\"checkbox\" id=\"reginfo\"/> 我已经认真阅读并同意<a href=\"javascript:showinfo()\">《服务条款》</a></td><td><div class=\"tishi fail\"></div></td></tr><tr><td align=\"tab1\"></td><td><asp:ImageButton ID=\"storeBut\" runat=\"server\" OnClick=\"storeBut_Click\"  ImageUrl=\"~/user/images/rig1_03.gif\" CommandArgument = \"bt2\"/></td><td><div class=\"tishi fail\"></div></td></tr><tr><td align=\"right\">已有账号？</td><td colspan=\"2\"><a href=\"Login.aspx\" target=\"_parent\">现在登录</a></td></tr></tbody></table>";
            Control ctrls = Page.ParseControl(ctrs);
            PlaceHolder1.Controls.Add(ctrls);
        }
    }
}
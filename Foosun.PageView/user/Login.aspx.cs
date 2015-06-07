using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using Foosun.CMS;
using Foosun.Model;
using Foosun.PlugIn.Passport;

namespace Foosun.PageView.user
{
    public partial class Login : Foosun.PageBasic.BasePage
    {
        Foosun.CMS.user rot = new CMS.user();
        RootPublic pd = new RootPublic();
        public string SiteID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("P3P", "CP=CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR");

            if (!IsPostBack)
            {
                Logout();
                string TmUrl = Request.QueryString["urls"];
                if (TmUrl != null && TmUrl != "")
                {
                    string tmDir = Foosun.Config.UIConfig.dirUser.Trim() + "/index.aspx";
                    if ((TmUrl.ToString().ToLower()).IndexOf(tmDir.ToLower()) == -1) { this.HidUrl.Value = TmUrl.ToString(); }
                }
                if (pd.GetUserLoginCode() != 1) { safecodeTF.Visible = false; }
                else { safecodeTF.Visible = true; }
                SiteID = getSiteID();
            }
        }


        protected string getSiteID()
        {
            string _Str = "";
            string _dirdumm = Foosun.Config.UIConfig.dirDumm;
            if (_dirdumm.Trim() != "") { _dirdumm = "/" + _dirdumm; }
            if (!File.Exists(Server.MapPath(_dirdumm + "/site.xml"))) { PageError("找不到配置文件(/site.xml).<li>请与系统管理员联系。</li>", ""); }
            string xmlPath = Server.MapPath(_dirdumm + "/site.xml");
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("siteid");
            _Str = elemList[0].InnerXml;
            return _Str;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserName = this.TxtName.Text;
            string PassWord = this.TxtPassword.Text;
            if (UserName.Trim() == string.Empty || PassWord.Trim() == string.Empty)
            {
                Label1.Text = "请输入用户名和密码!";
                return;
            }
            if (pd.GetUserLoginCode() != 0)
            {
                string SafeCode = this.TxtVerifyCode.Text;
                if (Session["CheckCode"] == null)
                {
                    Label1.Text = "验证码已过期,请返回重新登录!";
                    return;
                }
                string _SafeCode = Session["CheckCode"].ToString().ToUpper();
                Session.Remove("CheckCode");
                if (SafeCode != _SafeCode)
                {
                    Label1.Text = "验证码输入不正确!";
                    return;
                }
            }
            GlobalUserInfo info;
            EnumLoginState state = Login(UserName, PassWord, out info);
            if (state == EnumLoginState.Succeed)
            {
                Foosun.Global.Current.Set(info);

                if (info.uncert)
                {
                    LoginResultShow(EnumLoginState.Err_UnCert);
                }
                if (Request.QueryString["reurl"] != null && Request.QueryString["reurl"].Trim() != string.Empty)
                {
                    Response.Write("登录成功，自动转接中，请稍候……");
                    //同步登录
                    DPO_Request request = new DPO_Request(Context);
                    request.RequestLogin(UserName, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord, "MD5").Substring(8, 16).ToLower(), Request.QueryString["reurl"]);
                    Response.End();
                }
                else
                {
                    DPO_Request request = new DPO_Request(Context);
                    request.RequestLogin(UserName, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(PassWord, "MD5").Substring(8, 16).ToLower(), string.Format("{0}/user/index.aspx", Request.ApplicationPath == "/" ? string.Empty : Request.ApplicationPath));
                    Response.End();
                    /*
                    #region 整合Discuz!NT
                    try
                    {
                        string xmlName = Server.MapPath("..\\api\\dz\\Adapt.config");
                        AdaptConfig conf = new AdaptConfig(xmlName);
                        if (conf.isAdapt)
                        {
                            string adaptePath = conf.adaptPath;
                            adaptePath += "?username=" + UserName + "&password=" + PassWord + "&tag=login";
                            //Response.Write("<script type=\"text/javascript\" language=\"javascript\">window.open(\"" + adaptePath + "\",\"\",\"left=5000,top=5000\");</script>");
                            string str = "<script language=\"javascript\" type=\"text/javascript\" src=\"" + adaptePath + "\"></script>";                         
                            Response.Write(str);          
                        }
                    }
                    finally
                    {
                        Response.Write("<script language=\"javascript\">window.top.location.href=\"Index.aspx?urls=" + this.HidUrl.Value + "\";</script>");
                        System.Web.HttpContext.Current.Response.End();
                        //Response.End();
                        //Response.Redirect("index.aspx?urls=" + this.HidUrl.Value, false);
                    } 
                     #endregion
                     * */
                }
            }
            else
            {
                LoginResultShow(state);
            }
        }
    }
}
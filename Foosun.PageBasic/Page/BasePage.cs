using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Foosun.CMS;
using Foosun.Config;
using Foosun.Model;

namespace Foosun.PageBasic
{
	public class BasePage : System.Web.UI.Page {
		protected readonly int PAGESIZE = Config.UIConfig.GetPageSize();
		protected internal UserLogin _UserLogin;
		protected internal string CopyRight = "(c)2002-2013 Foosun Inc. By " + Foosun.Config.verConfig.Productversion;
		protected void AddStyleSheet(Page page, string cssPath) {
			HtmlLink link = new HtmlLink();
			link.Href = cssPath;
			link.Attributes["rel"] = "stylesheet";
			link.Attributes["type"] = "text/css";
		}

		public BasePage() {
			_UserLogin = new UserLogin();
		}

		protected void PageRight(string rightMsg, string url) {
			PageRight(rightMsg, url, false, false);
		}


		protected void PageRight(string rightMsg, string url, bool noHistory) {
			PageRight(rightMsg, url, false, noHistory);
		}
		protected void PageRight(string errMsg, string url, bool retrunurl, bool noHistory) {
			WebHint.ShowRight(errMsg, url, retrunurl, noHistory);
		}

		protected void PageError(string errMsg, string url) {
			PageError(errMsg, url, false);
		}

		protected void PageError(string errMsg, string url, bool retrunurl) {
			WebHint.ShowError(errMsg, url, retrunurl);
		}

		/// <summary>
		/// 退出
		/// </summary>
		protected virtual void Logout() {
			//得到用户数据
			HttpCookie cook = HttpContext.Current.Request.Cookies["SITEINFO"];
			if (cook != null) {
				//设置用户的cookie为过期
				cook.Expires = DateTime.Now.AddDays(-1);
				cook.Value = null;
				Response.Cookies.Add(cook);
			}
		}
		/// <summary>
		/// 执行一个JS语句
		/// </summary>
		/// <param name="sentence">要执行的语句</param>
		protected void ExecuteJs(string sentence) {
			Context.Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
			Context.Response.Write(sentence);
			Context.Response.Write("</script>");
		}
		/// <summary>
		/// 检查用户信息会话是否超时
		/// </summary>
		/// <returns></returns>
		protected bool Validate_Session() {
			return !Foosun.Global.Current.IsTimeout();
		}

		protected void LoginResultShow(EnumLoginState state) {
			string dimm = Foosun.Config.UIConfig.dirDumm.Trim();
			if (dimm != string.Empty) {
				dimm = "/" + dimm;
			}
			string ErrorMsg = string.Empty;
			int isAdminReturn = 0;
			switch (state) {
				case EnumLoginState.Err_IPLimited:
					ErrorMsg = "您IP[" + Common.Computer.GetIP() + "]被限制，不能登陆!";
					isAdminReturn = 2;
					break;
				case EnumLoginState.Err_Locked:
					ErrorMsg = "您已经被锁定!";
					isAdminReturn = 2;
					break;
				case EnumLoginState.Err_AdminLogined:
                    Response.Write("<script language=\"javascript\">window.parent.location.href=\"" + dimm + "/" + Foosun.Config.UIConfig.dirMana + "/login.aspx?urls=" + Request.Url + "\";</script>");
					Response.End();
					break;
				case EnumLoginState.Err_UnEmail:
					ErrorMsg = "您还没通过电子邮件激活，不能登陆本系统!";
					isAdminReturn = 0;
					break;
				case EnumLoginState.Err_TimeOut:
                    Response.Write("<script language=\"javascript\">window.parent.location.href=\"" + dimm + "/" + Foosun.Config.UIConfig.dirUser + "/login.aspx?urls=" + Request.Url + "\";</script>");
					Response.End();
					break;
				case EnumLoginState.Err_AdminTimeOut:
                    Response.Write("<script language=\"javascript\">window.parent.location.href=\"" + dimm + "/" + Foosun.Config.UIConfig.dirMana + "/login.aspx?urls=" + Request.Url + "\";</script>");
					Response.End();
					break;
				case EnumLoginState.Err_UnMobile:
					ErrorMsg = "您还没通过手机验证，不能登陆本系统!<li><a href=\"" + dimm + "/" + UIConfig.dirUser + "info/MobileValidate.aspx?uid=" + Global.Current.UserName + "\"><font color=\"Blue\">点击此处验证您的手机</font></li>";
					isAdminReturn = 0;
					break;
				case EnumLoginState.Err_UnCert:
					ErrorMsg = "<script language=\"javascript\" type=\"text/javascript\">alert('您还没认证资料！\\n点 [确定] 进行实名认证。');top.location.href='" + dimm + "/" + UIConfig.dirUser + "/info/userinfo_idcard.aspx?type=CreatCert\';</script>";
					isAdminReturn = 0;
					break;
				case EnumLoginState.Err_NoAuthority:
					ErrorMsg = "您没有此项的操作权限!";
					isAdminReturn = 1;
					break;
				case EnumLoginState.Err_AdminLocked:
					ErrorMsg = "您已被锁定";
					isAdminReturn = 1;
					break;
				case EnumLoginState.Err_DbException:
					ErrorMsg = "系统错误。<li><span style=\"color:red\">出错原因：</span></li><li>与数据库服务器的通信失败。</li><li>数据库连接字符串不正确。</li><li>数据库发生异常。</li>";
					isAdminReturn = 2;
					break;
				case EnumLoginState.Err_UserNumInexistent:
					ErrorMsg = "用户不存在";
					isAdminReturn = 2;
					break;
				case EnumLoginState.Err_AdminNumInexistent:
					ErrorMsg = "权限不足！";
					isAdminReturn = 1;
					break;
				case EnumLoginState.Err_DurativeLogError:
					ErrorMsg = "连续错误登陆，您已经被锁定,请" + _UserLogin.GetLoginSpan() + "分钟后再登录!";
					isAdminReturn = 0;
					break;
				case EnumLoginState.Err_NameOrPwdError:
					ErrorMsg = "用户名不存在或者密码错误";
					isAdminReturn = 2;
					break;
				case EnumLoginState.Err_GroupExpire:
					ErrorMsg = "您的帐号已过期";
					isAdminReturn = 0;
					break;
				case EnumLoginState.Err_NotAdmin:
					ErrorMsg = "抱歉，您不是管理员。您的操作已经记录！<li>您的IP：[" + Common.Computer.GetIP() + "]已被记录</li>";
					isAdminReturn = 1;
					break;
				case EnumLoginState.Succeed:
					return;
				default:
					ErrorMsg = "异常错误：" + state.ToString();
					isAdminReturn = 2;
					break;
			}
			string Returnurl = string.Empty;
			switch (isAdminReturn) {
				case 0:
					Returnurl = dimm + "/" + Foosun.Config.UIConfig.dirUser + "/login.aspx?urls=" + Request.Url;
					break;
				case 1:
					if (state == EnumLoginState.Err_NoAuthority) {
						Returnurl = dimm + "/" + Foosun.Config.UIConfig.dirMana + "/main.aspx";
					}
					else {
                        Returnurl = dimm + "/" + Foosun.Config.UIConfig.dirMana + "/login.aspx?urls=" + Request.Url;
					}
					break;
				default:
					Returnurl = dimm + "/";
					break;
			}
            if (state == EnumLoginState.Err_NameOrPwdError ||state== EnumLoginState.Err_DbException)
            {
                Common.MessageBox.Show(this, ErrorMsg, "错误", "");
            }
            else
            {                
                PageError(ErrorMsg, Returnurl, true);
            }
		}
		protected void CheckUserLogin() {
			if (!Validate_Session())
				LoginResultShow(EnumLoginState.Err_TimeOut);
			else
				LoginResultShow(CheckUserLogin(Foosun.Global.Current.UserNum, false));
		}
		protected void CheckUserLoginCert() {
			if (!Validate_Session())
				LoginResultShow(EnumLoginState.Err_TimeOut);
			else
				LoginResultShow(CheckUserLogin(Foosun.Global.Current.UserNum, true));
		}
		protected void CheckAdminLogin() {
			if (!Validate_Session())
				LoginResultShow(EnumLoginState.Err_AdminTimeOut);
			else
				LoginResultShow(CheckAdminLogin(Foosun.Global.Current.UserNum));
		}
		/// <summary>
		/// 检查普通会员登录状态
		/// </summary>
		/// <param name="UserNum"></param>
		/// <param name="IsCert"></param>
		/// <param name="LimitedIP"></param>
		/// <returns></returns>
		private EnumLoginState CheckUserLogin(string UserNum, bool IsCert) {
			return _UserLogin.CheckUserLogin(UserNum, IsCert);
		}
		/// <summary>
		/// 检查管理员登录状态
		/// </summary>
		/// <param name="UserNum"></param>
		/// <param name="LimitedIP"></param>
		/// <returns></returns>
		private EnumLoginState CheckAdminLogin(string UserNum) {
			return _UserLogin.CheckAdminLogin(UserNum);
		}
		/// <summary>
		/// 用户登录
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="Password"></param>
		/// <param name="info"></param>
		/// <param name="IsAdmin"></param>
		/// <returns></returns>
		protected EnumLoginState Login(string UserName, string Password, out GlobalUserInfo info, bool IsAdmin) {
			if (IsAdmin)
				return _UserLogin.AdminLogin(UserName, Password, out info);
			else
				return _UserLogin.PersonLogin(UserName, Password, out info);

		}
		/// <summary>
		/// 个人用户登录
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="Password"></param>
		/// <param name="info"></param>
		/// <returns></returns>
		protected EnumLoginState Login(string UserName, string Password, out GlobalUserInfo info) {
			return _UserLogin.PersonLogin(UserName, Password, out info);
		}
		/// <summary>
		/// 个人用户登录
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="Password"></param>
		protected void Login(string UserName, string Password) {
			GlobalUserInfo info;
			EnumLoginState state = _UserLogin.PersonLogin(UserName, Password, out info);
			if (state == EnumLoginState.Succeed)
				Global.Current.Set(info);
			else
				LoginResultShow(state);
		}
	}
}

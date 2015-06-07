using Foosun.Config;

namespace Foosun.PageBasic
{
	public class WebHint {
		/// <summary>
		/// 页面错误提示信息
		/// </summary>
		/// <param name="ErrMsg">错误信息</param>
		/// <param name="Url">返回管理员地址  默认可以填写:""或"0"</param>
		static public void ShowError(string ErrMsg, string Url, bool returnUrl) {
			PageRender(ErrMsg, Url, false, returnUrl);
		}
		/// <summary>
		///
		/// </summary>
		/// <param name="strUrl"></param>
		/// <returns></returns>
		static private string UserUrl(string strUrl) {
			if (!string.IsNullOrEmpty(strUrl) && strUrl.Trim().Length > 5) {
				strUrl = "<a href=\"" + strUrl + "\"><font color=\"red\">返回管理</font></a>";
			}
			return strUrl;
		}

		/// <summary>
		/// 页面操作成功提示信息
		/// </summary>
		/// <param name="rightMsg">操作成功信息</param>
		/// <param name="url">返回管理员地址</param>
		static internal void ShowRight(string rightMsg, string url, bool returnUrl, bool noHistory) {
			PageRender(rightMsg, url, true, returnUrl, noHistory);
		}
		static internal void ShowRight(string rightMsg, string url, bool returnUrl) {
			PageRender(rightMsg, url, true, returnUrl, false);
		}
		static internal void PageRender(string msg, string url, bool succeed, bool returnUrl) {
			PageRender(msg, url, succeed, returnUrl, false);
		}
		static internal void PageRender(string msg, string url, bool succeed, bool returnUrl, bool noHistory) {
			string cssDir = Common.ServerInfo.GetRootURI() + "/CSS/";
			string STitle = "操作结果!";
			string ReUrlStr = "";
			string _tmp = "<img src=\"" + cssDir + "imges/11.gif\" border=\"0\">";
            string SCaption = "<strong>恭喜！操作成功</strong>";
			if (!succeed) {
				STitle = "操作失败信息";
                _tmp = "<img src=\"" + cssDir + "imges/52.gif\" border=\"0\">";
				SCaption = "<font color=\"red\">抱歉！操作失败</font>";
			}
			System.Web.HttpContext.Current.Response.Clear();
			System.Web.HttpContext.Current.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r<head>\r");
			System.Web.HttpContext.Current.Response.Write("<title>" + STitle + "_Foosun Inc.</title>\r");
			System.Web.HttpContext.Current.Response.Write("<link href=\"" + cssDir +  "base.css\" rel=\"stylesheet\" type=\"text/css\" />\r");
            System.Web.HttpContext.Current.Response.Write("<link href=\"" + cssDir + "style.css\" rel=\"stylesheet\" type=\"text/css\" />\r");
            System.Web.HttpContext.Current.Response.Write("<link href=\"" + cssDir + UIConfig.CssPath() + "/css/blue.css\" rel=\"stylesheet\" type=\"text/css\" />\r");
			System.Web.HttpContext.Current.Response.Write("\r</head>\r");
			if (returnUrl) {
				if (url != string.Empty && url != null) {
                    System.Web.HttpContext.Current.Response.Write("<body  class=\"czbody\">\r");
				}
			}
			else {
				System.Web.HttpContext.Current.Response.Write("<body class=\"czbody\">\r");
			}
            System.Web.HttpContext.Current.Response.Write("<div class=\"czbig\"><div class=\"czware\"><div class=\"czware_big\"><div class=\"czware_top\">" + SCaption + "</div><div class=\"czware_bot\"><div class=\"czware_bot_left\">" + _tmp + "</div><div class=\"czware_bot_right\"><h4>操作描述：</h4><ul> \r");
            System.Web.HttpContext.Current.Response.Write("    <ul>\r");
            if (noHistory)
            {
                System.Web.HttpContext.Current.Response.Write("        <li>" + UserUrl(url) + "</li>" + ReUrlStr + "\r");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("        <li><span style=\"word-wrap:bread-word;word-break:break-all;font-size:11.5px;\">" + msg + "</span></li>\r         <li><a href='javascript:history.back();'><font color=\"red\">返回上一级</font></a>&nbsp;&nbsp;&nbsp;&nbsp;" + UserUrl(url) + "</li>" + ReUrlStr + "\r");
            }
            System.Web.HttpContext.Current.Response.Write("     <li style=\"line-height:20px;\">" + UIConfig.returnCopyRight + "</li>\r");
            System.Web.HttpContext.Current.Response.Write("     </ul></div></div></div></div></div>\r");
			System.Web.HttpContext.Current.Response.Write("</body>\r</html>\r");
			System.Web.HttpContext.Current.Response.End();
		}
	}
}

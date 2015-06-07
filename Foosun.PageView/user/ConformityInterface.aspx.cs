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
using Foosun.PlugIn.Passport;

namespace Foosun.PageView.user
{
    public partial class ConformityInterface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["tag"];
            string userName = Request.QueryString["userName"];
            string password = Request.QueryString["password"];

            string msg = "";
            switch (type)
            { 
                case"login":
                    msg = login(userName, password);
                    break;
                case "logout":
                    msg = loginout(userName);
                    break;
            }
            Response.ContentType = "text/xml";
            Response.Write(msg);
            Response.End();
        }

        private string login(string username,string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(username))
                return null;
            DPO_Request request = new DPO_Request(Context);
            string str = request.GetRequestURL(username, password);
            return str;
        }

        private string loginout(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;
            DPO_Request request = new DPO_Request(Context);
            string str = request.GetRequestURL(username, null);
            return str;
        }
    }
}

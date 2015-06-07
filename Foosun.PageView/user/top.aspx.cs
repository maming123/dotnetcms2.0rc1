using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Foosun.CMS;

namespace Foosun.PageView.user
{
    public partial class top : Foosun.PageBasic.UserPage
    {
        UserMisc rd = new UserMisc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = messageChar();
            }
        }
        /// <summary>
        /// 是否有新消息
        /// </summary>
        /// <returns></returns>
        string messageChar()
        {
            string liststr = "";
            DataTable dt = rd.messageChar(Foosun.Global.Current.UserNum);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    liststr += "<a href=\"../" + Foosun.Config.UIConfig.dirUser + "/message/Message_box.aspx?Id=1\" class=\"tbie\" target=\"sys_main\">新短消息(" + dt.Rows.Count + ")</a><bgsound src=\"../sysImages/sound/newmessage.wav\" />";
                }
                else
                {
                    liststr += "<a href=\"../" + Foosun.Config.UIConfig.dirUser + "/message/Message_box.aspx?Id=1\"  class=\"Lion_1\" target=\"sys_main\">短消息(0)</a>";
                }
            }
            else
            {
                liststr += "<a href=\"../" + Foosun.Config.UIConfig.dirUser + "/message/Message_box.aspx?Id=1\" class=\"Lion_1\" target=\"_self\">短消息(0)</a>";
            }
            return liststr;
        }
    }
}
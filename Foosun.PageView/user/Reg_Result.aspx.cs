//=====================================================================
//==                  (c)2011 Foosun Inc.By doNetCMS1.0              ==
//==                     Forum:bbs.foosun.net                        ==
//==                     WebSite:www.foosun.net                      ==
//=====================================================================
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
using Common;
using Foosun.CMS;

public partial class user_Reg_Result : Foosun.PageBasic.BasePage
{   
    protected void Page_Load(object sender, EventArgs e)
    {
            RootPublic rd = new RootPublic ();
            this.username.Text = rd.GetUserName(Foosun.Global.Current.UserNum);
    }
}
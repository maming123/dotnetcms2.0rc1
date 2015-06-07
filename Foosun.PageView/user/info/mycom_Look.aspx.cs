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
using Foosun.CMS;

public partial class mycom_Look : Foosun.PageBasic.UserPage
{
    Info inf = new Info();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.CacheControl = "no-cache";
        string Commid = Common.Input.Filter(Request.QueryString["Commid"]);
        DataTable dt = inf.sel_19(Commid);
        this.TitleBox.Text=dt.Rows[0]["Title"].ToString();
        this.ContentBox.Text=dt.Rows[0]["Content"].ToString();
    }   
    protected void shortCutsubmit(object sender, EventArgs e)
    {
        Response.Redirect("mycom.aspx");
    }
}

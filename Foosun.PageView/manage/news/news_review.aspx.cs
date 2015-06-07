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

public partial class news_review : Foosun.PageBasic.ManagePage
{
    News rd = new News();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            string gType = "";
            if (Request.QueryString["type"] != null && Request.QueryString["type"] != string.Empty)
            {
                gType = Request.QueryString["type"].ToString();
            }
            else
            {
                gType = "news";
            }
            string URLS = rd.GetNewsReview(Request.QueryString["ID"].ToString(), gType);
            string url = null;
            if (URLS.ToLower().IndexOf("http://") != -1)
            {
                url = URLS.Substring("http://".Length, URLS.Length - "http://".Length);
                url = url.Replace("//", "/");
                url = "http://" + url;
            }
            else
            {
                url = URLS.Replace("//", "/");
            }
            Response.Redirect(url);
        }
    }
}

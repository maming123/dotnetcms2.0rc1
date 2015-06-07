using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;

namespace Foosun.PageView.manage.news
{
    public partial class NewsPreview : Foosun.PageBasic.ManagePage
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
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.news
{
    public partial class ClassSite : Foosun.PageBasic.ManagePage
    {
        Foosun.CMS.UserMisc rd = new Foosun.CMS.UserMisc();
        Foosun.CMS.NewsClass cClass = new CMS.NewsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getlist();
            }
        }
        void getlist()
        {
            string content = "<ul  id=\"tree\">";
             DataTable site = rd.getSiteList();
             if (site.Rows.Count > 0)
             {
                 foreach (DataRow item in site.Rows)
                 {
                     content += "<li  class=\"open\"><a target=\"sys_main\" href=\"NewsList.aspx\">" + item["CName"].ToString() + "</a>";
                     content += list(item["ChannelID"].ToString (),"0"); ;
                     content += "</li>";
                 }
             }
             content += "</ul>";
             navlist.InnerHtml = content;
        }
        string list(string siteid, string classid)
        {
            string content = "";
            DataTable dt = cClass.GetContent("ClassID,ClassCName", "ParentID='" + classid + "' and SiteID='" +siteid + "'", "");
            if (dt.Rows.Count>0)
            {
                content = "<ul>";
                foreach (DataRow item in dt.Rows)
                {
                    content += "<li><a target=\"sys_main\" href=\"NewsList.aspx?ClassID=" + item["ClassID"].ToString() + "\">" + item["ClassCName"].ToString() + "</a>";
                    content += list(siteid, item["ClassID"].ToString());
                    content += "</li>";
                }
                content += "</ul>";
            }
            return content;
        }

    }
}
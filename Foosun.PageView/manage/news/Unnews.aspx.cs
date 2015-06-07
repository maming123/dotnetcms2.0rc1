using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.news
{
    public partial class Unnews : Foosun.PageBasic.ManagePage
    {
        public Unnews()
        {
            Authority_Code = "CE02";
        }
        Foosun.CMS.News cnews = new CMS.News();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_OnPageChange);
            if (Request.Form["UnID"] != null && Request.Form["UnID"].ToString() != "")
            {
                if (Request.Form["type"] != null && Request.Form["type"] == "del")
                {
                    cnews.DelUnNews(Request.Form["UnID"].ToString());
                    Response.Clear();
                    Response.Write("删除不规则新闻成功！");
                    Response.End();
                }
                else if (Request.Form["type"] != null && Request.Form["type"] == "show")
                {
                    DataTable DT = cnews.GetUnNews(Request.Form["UnID"].ToString());
                    string content = "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    if (DT!=null&&DT.Rows.Count>0)
                    {
                        foreach (DataRow item in DT.Rows)
                        {
                            content += "<tr><td>"+item["unTitle"]+"</td></tr>";
                        }
                    }
                    content+="</table>";
                    Response.Clear();
                    Response.Write(content);
                    Response.End();
                }
            }
           
            if (!IsPostBack)
            {
                GetunNewsPage(1);
            }

        }

        private void PageNavigator1_OnPageChange(object sender, int pageindex)
        {
            GetunNewsPage(pageindex);
        }

        private void GetunNewsPage(int pageindex)
        {
            int i = 0, j = 0;
            DataTable DT;
            DT = cnews.GetPages(pageindex, 20, out i, out j, null);
            this.PageNavigator1.RecordCount = i;
            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = pageindex;
            RptunNews.DataSource = DT;
            RptunNews.DataBind();
            DT.Dispose();
        }
    }
}
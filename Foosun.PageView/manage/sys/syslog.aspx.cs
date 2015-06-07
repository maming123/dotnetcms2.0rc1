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
using Foosun.Model;

namespace Foosun.PageView.manage.Sys
{
    public partial class syslog : Foosun.PageBasic.ManagePage
    {
        public syslog()
        {
            Authority_Code = "Q039";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StartLoad(1);
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_OnPageChange);
        }

        void PageNavigator1_OnPageChange(object send, int nPageIndex)
        {
            StartLoad(nPageIndex);
        }

        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            StartLoad(PageIndex);
        }
        protected void StartLoad(int PageIndex)
        {
            int i, j;
            DataTable dt = null;
            string site = Request.QueryString["SiteID"];
            if (site != "" && site != null)
            {
                SQLConditionInfo st = new SQLConditionInfo("@SiteID", site);
                dt = Foosun.CMS.Pagination.GetPage("manage_Sys_syslog_aspx", PageIndex, 20, out i, out j, st);
            }
            else
            {
                dt = Foosun.CMS.Pagination.GetPage(this.GetType().Name, PageIndex, 20, out i, out j, null);
            }
            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = i;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int k = 0; dt.Rows.Count > k; k++)
                    {
                    }
                }
                DataList1.DataSource = dt;
                DataList1.DataBind();
                dt.Clear();
                dt.Dispose();
            }
        }

    }
}
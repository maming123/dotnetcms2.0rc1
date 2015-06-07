using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.Attachments
{
    public partial class PicManage : Foosun.PageBasic.ManagePage
    {
        CMS.Attachments AttachmentsCMS = new CMS.Attachments();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            string Action = Request.QueryString["Action"];
            if (Action == "del")
            {
                string Ids = Request.QueryString["ids"];
                AttachmentsCMS.DeleteList(Ids);
            }
            if (!IsPostBack)
            {
                ListDataBind(1);
            }
        }

        protected void ListDataBind(int pageIndex)
        {
            DataTable dt = new DataTable();
            int RecordCount = 0;
            int PageCount = 0;
            dt = AttachmentsCMS.GetPage("2",this.txtBeginDate.Text.Trim(), this.txtEndDate.Text.Trim(), pageIndex, Foosun.Config.UIConfig.GetPageSize(), out RecordCount, out PageCount);
            this.PageNavigator1.PageCount = PageCount;
            this.PageNavigator1.RecordCount = RecordCount;
            this.PageNavigator1.PageIndex = pageIndex;
            if (dt != null)
            {
                this.rpt_list.DataSource = dt;
                this.rpt_list.DataBind();
            }
        }

        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            ListDataBind(PageIndex);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListDataBind(1);
        }
    }
}
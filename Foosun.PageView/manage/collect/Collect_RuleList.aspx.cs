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

public partial class Collect_RuleList : Foosun.PageBasic.ManagePage
{
    private Foosun.CMS.Collect.Collect cl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Option"] != null && !Request.QueryString["Option"].Trim().Equals("")
            && Request.QueryString["ID"] != null && !Request.QueryString["ID"].Trim().Equals(""))
        {
            try
            {
                int id = int.Parse(Request.QueryString["ID"]);
                if (Request.QueryString["Option"].Equals("DeleteRule"))
                {
                    cl = new Foosun.CMS.Collect.Collect();
                    cl.RuleDelete(id);
                }
                Response.Write("1%成功删除一个规则");
            }
            catch (Exception ex)
            {
                Response.Write("0%" + ex.Message);
            }
            Response.End();
            return;
        }
        this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_OnPageChange);
        if (!Page.IsPostBack)
        {
            ListDataBind(1);
        }
    }
    protected void PageNavigator1_OnPageChange(object sender, int PageIndex)
    {
        ListDataBind(PageIndex);
    }
    private void ListDataBind(int PageIndex)
    {
        int nRCount, nPCount;
        cl = new Foosun.CMS.Collect.Collect();
        this.RptRule.DataSource = cl.GetRulePage(PageIndex, PAGESIZE, out nRCount, out nPCount);
        this.RptRule.DataBind();
        this.PageNavigator1.PageCount = nPCount;
        this.PageNavigator1.RecordCount = nRCount;
        this.PageNavigator1.PageIndex = PageIndex;
    }
}

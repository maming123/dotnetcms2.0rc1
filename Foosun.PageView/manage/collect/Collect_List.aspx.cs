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
using System.Text.RegularExpressions;

public partial class Collect_List : Foosun.PageBasic.ManagePage
{
    public Collect_List()
    {
        Authority_Code = "S008";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Option"] != null && !Request.QueryString["Option"].Trim().Equals("")
            && Request.QueryString["ID"] != null && !Request.QueryString["ID"].Trim().Equals(""))
        {
            try
            {
                int id = int.Parse(Request.QueryString["ID"]);
                Foosun.CMS.Collect.Collect bl = new Foosun.CMS.Collect.Collect();
                switch (Request.QueryString["Option"])
                {
                    case "ReproduceFolder":
                        bl.FolderCopy(id);
                        break;
                    case "ReproduceSite":
                        bl.SiteCopy(id);
                        break;
                    case "DeleteFolder":
                        bl.FolderDelete(id);
                        break;
                    case "DeleteSite":
                        this.Authority_Code = "S010";
                        this.CheckAdminAuthority();
                        bl.SiteDelete(id);
                        break;
                }
                Response.Write("操作成功!");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Response.End();
            return;
        }
        this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_OnPageChange);
        if (!Page.IsPostBack)
        {
            this.HidFolderID.Value = "";
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
        int FID = 0;
        if (!HidFolderID.Value.Equals(""))
            FID = int.Parse(HidFolderID.Value);
        Foosun.CMS.Collect.Collect collect = new Foosun.CMS.Collect.Collect();
        this.RptSite.DataSource = collect.GetFolderSitePage(FID, PageIndex, PAGESIZE, out nRCount, out nPCount);
        this.RptSite.DataBind();
        this.PageNavigator1.PageCount = nPCount;
        this.PageNavigator1.RecordCount = nRCount;
        this.PageNavigator1.PageIndex = PageIndex;
    }
    protected void RptSite_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Panel pl = (Panel)e.Item.FindControl("PnlUpFolder");
            if (pl != null)
            {
                if (this.HidFolderID.Value.Equals("") || this.HidFolderID.Value.Equals("0"))
                    pl.Visible = false;
                else
                    pl.Visible = true;
            }
        }
        else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl = (Label)e.Item.FindControl("LblState");
            if (lbl != null && !lbl.Text.Equals("有效"))
                lbl.ForeColor = System.Drawing.Color.Red;
            Image imgc = (Image)e.Item.FindControl("ImgRowCaption");
            if (imgc != null)
            {
                if (imgc.AlternateText.Equals("0"))
                {
                    imgc.ImageUrl = "../imges/lie_32.gif";
                    imgc.AlternateText = "采集栏目";
                }
                else
                {
                    imgc.ImageUrl = "../imges/SiteSet.gif";
                    imgc.AlternateText = "采集站点";
                }
            }
            Image imgl = (Image)e.Item.FindControl("ImgLink");
            if (imgl != null)
            {
                if (imgl.AlternateText.Equals("0"))
                {
                    imgl.Visible = false;
                }
                else
                {
                    imgl.AlternateText = "点击访问";
                }
            }
        }
    }
    protected void LnkBtnEnter_Click(object sender, EventArgs e)
    {
        this.HidFolderID.Value = ((LinkButton)sender).CommandArgument;
        ListDataBind(1);
    }
    protected void LnkBtnUp_Click(object sender, EventArgs e)
    {
        this.HidFolderID.Value = "";
        ListDataBind(1);
    }
}

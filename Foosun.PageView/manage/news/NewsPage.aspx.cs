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
using System.IO;
using System.Xml;

public partial class NewsPage : Foosun.PageBasic.ManagePage
{
    /// <summary>
    /// 权限设置
    /// </summary>
    public NewsPage()
    {
        Authority_Code = "C098";
    }
    public string UDir = "\\Content";
    Foosun.CMS.NewsClass NewsClassCMS = new NewsClass();
    Foosun.CMS.sys param = new Foosun.CMS.sys();
    Foosun.CMS.DropTemplet DropTempletCMS = new DropTemplet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region 模版加载
            string publishType = param.GetParamBase("publishType");
            if (publishType == "0")
            {
                labelTemplet.Style.Add("display", "block");
                dropTemplet.Style.Add("display", "none");
            }
            else
            {
                labelTemplet.Style.Add("display", "none");
                dropTemplet.Style.Add("display", "block");
            }
            #endregion
            try
            {
                this.CheckBox1.Checked = bool.Parse(Foosun.Config.UIConfig.enableAutoPage);
            }
            catch
            {
                this.CheckBox1.Checked = false;
            }
            try
            {
                if (Common.Input.IsInteger(Foosun.Config.UIConfig.splitPageCount))
                    this.TxtPageCount.Text = Foosun.Config.UIConfig.splitPageCount;
            }
            catch
            {
                this.TxtPageCount.Text = "20";
            }
            SiteCopyRight.InnerHtml = CopyRight;
            string ClassId = Request.QueryString["Number"] == null ? "0" : Request.QueryString["Number"];
            string Action = Request.QueryString["Action"];
            if (ClassId == null && ClassId == string.Empty)
            {
                Common.MessageBox.ShowAndRedirect(this, "参数错误!", "NewsClassList.aspx");
            }
            else
            {
                if (Action == "Edit")
                {
                    this.acc.Value = "Edit";
                    this.gClassID.Value = ClassId;
                    Foosun.Model.NewsClass NewsClassModel = NewsClassCMS.GetModel(ClassId);
                    lblClassName.Text = NewsClassCMS.GetNewsClassCName(NewsClassModel.ParentID);
                    if (NewsClassModel != null)
                    {
                        this.TCname.Text = NewsClassModel.ClassCName;
                        if (NewsClassModel.NaviShowtf == 1)
                        {
                            this.NaviShowtf.Checked = true;
                        }
                        this.TParentId.Text = NewsClassModel.ParentID.ToString();
                        this.TOrder.Text = NewsClassModel.OrderID.ToString();
                        this.KeyMeata.Text = NewsClassModel.MetaKeywords;
                        this.BeWrite.Text = NewsClassModel.MetaDescript;
                        this.FProjTemplets.Text = NewsClassModel.ClassTemplet;
                        this.dTemplet.Text = DropTempletCMS.GetClassTemplet(ClassId);
                        this.TPath.Text = NewsClassModel.SavePath;
                        this.Content.Value = NewsClassModel.PageContent;
                        this.tContent.Text = NewsClassModel.PageContent;
                    }
                }
                else
                {
                    lblClassName.Text = NewsClassCMS.GetNewsClassCName(ClassId);
                    this.NaviShowtf.Checked = true;
                    if (ClassId != null && ClassId != string.Empty)
                    {
                        TParentId.Text = ClassId;
                    }
                    else
                    {
                        TParentId.Text = "0";
                    }
                    if (SiteID == "0")
                    {
                        FProjTemplets.Text = "/{@dirTemplet}/Content/page.html";
                        dTemplet.Text = "/{@dirTemplet}/Content/page.html";
                    }
                    else
                    {
                        FProjTemplets.Text = "/{@dirTemplet}/siteTemplets/" + SiteID + "/Content/page.html";
                        dTemplet.Text = "/{@dirTemplet}/siteTemplets/" + SiteID + "/Content/page.html";
                    }
                    TPath.Text = "/" + Foosun.Config.UIConfig.dirHtml + "/" + Common.Rand.Str_char(5).ToLower() + ".html";
                    this.TOrder.Text = "0";
                }
            }
        }
    }


    protected void Buttonsave_Click(object sender, EventArgs e)
    {
        string Action = this.acc.Value;
        string ClassID = "";
        if (Action == "Edit")
        {
            ClassID = this.gClassID.Value;
            NewsClassCMS.UpdateClassStat(0, ClassID);
        }
        else
        {
            ClassID = Common.Rand.Number(12);
        }
        if (TParentId.Text.Trim() != "0")
        {
            string s = NewsClassCMS.GetDataLib(TParentId.Text);
            if (s == null || s.Trim() == string.Empty)
            {
                Common.MessageBox.Show(this, "找不到栏目数据！");
                return;
            }
        }
        Foosun.Model.NewsClass NewsClassModel = new Foosun.Model.NewsClass();
        string Content = string.Empty;
        if (!this.zt.Checked)
        {
            Content = this.Content.Value;
            if (Content.Trim() == "")
            {
                Common.MessageBox.Show(this, "输入内容");
                return;
            }
            NewsClassModel.ClassTemplet = this.FProjTemplets.Text;
        }
        else
        {
            Content = this.tContent.Text;
            NewsClassModel.ClassTemplet = "";
        }
        NewsClassModel.ClassID = ClassID;
        NewsClassModel.ClassCName = this.TCname.Text;
        NewsClassModel.ClassEName = Common.Rand.Str_char(10).ToLower();
        NewsClassModel.ParentID = this.TParentId.Text;

        NewsClassModel.IsURL = 0;
        NewsClassModel.OrderID = int.Parse(this.TOrder.Text);
        NewsClassModel.CreatTime = DateTime.Now;
        NewsClassModel.SavePath = this.TPath.Text; ;
        NewsClassModel.SiteID = SiteID;
        if (this.NaviShowtf.Checked)
        {
            NewsClassModel.NaviShowtf = 1;
        }
        else
        {
            NewsClassModel.NaviShowtf = 0;
        }
        NewsClassModel.MetaKeywords = this.KeyMeata.Text; 
        NewsClassModel.MetaDescript = this.BeWrite.Text;
        NewsClassModel.isDelPoint = 0; 
        NewsClassModel.Gpoint = 0;
        NewsClassModel.iPoint = 0;
        NewsClassModel.GroupNumber = "";
        NewsClassModel.isPage = 1;
        NewsClassModel.PageContent = Content;

        if (acc.Value == "Edit")
        {
            NewsClassCMS.UpdatePage(NewsClassModel);
            DropTempletCMS.UpdateTemplet(ClassID, dTemplet.Text, "", "1");
        }
        else
        {
            NewsClassCMS.InsertPage(NewsClassModel);
            DropTempletCMS.AddTemplet(ClassID, dTemplet.Text, "", "1");
        }
        Common.MessageBox.ShowAndRedirect(this, "保存数据成功!", "NewsClassList.aspx");
    }
}

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
using System.Net;
using System.Text.RegularExpressions;
using Foosun.Model;

public partial class Collect_NewsModify : Foosun.PageBasic.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] == null || Request.QueryString["ID"].Trim().Equals(""))
            {
                Common.MessageBox.Show(this, "参数不正确或无效");
                return;
            }
            this.TxtClassName.Attributes.Add("readonly", "true");
            int id = int.Parse(Request.QueryString["ID"].Trim());
            Foosun.CMS.Collect.Collect cl = new Foosun.CMS.Collect.Collect();
            this.HidNewsID.Value = id.ToString();
            DataTable tb = cl.SiteList();
            if (tb != null)
            {
                this.DdlSite.DataTextField = "SiteName";
                this.DdlSite.DataValueField = "ID";
                this.DdlSite.DataSource = tb;
                this.DdlSite.DataBind();
                tb.Dispose();
            }
            CollectNewsInfo info = cl.GetNews(id);
            this.TxtTitle.Text = info.Title;
            this.TxtLink.Text = info.Links;
            this.DdlSite.SelectedValue = info.SiteID.ToString();
            this.TxtAuthor.Text = info.Author;
            this.TxtSource.Text = info.Source;
            this.TxtDate.Text = info.AddDate.ToString();
            this.EdtContent.Value = info.Content;
            this.LblClTime.Text = info.CollectTime.ToString();
            this.HidClassID.Value = info.ClassID;
            Foosun.CMS.NewsClass cm = new Foosun.CMS.NewsClass();
            string ClassName = cm.GetNewsClassCName(this.HidClassID.Value);
            this.TxtClassName.Text = ClassName;
        }
    }
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int id = int.Parse(HidNewsID.Value);
            int site = int.Parse(DdlSite.SelectedValue);
            if (TxtTitle.Text.Trim().Equals(""))
            {
                Common.MessageBox.Show(this, "标题不能为空!");
            }
            if (TxtLink.Text.Trim().Equals(""))
            {
                Common.MessageBox.Show(this, "链接地址不能为空!");
            }
            if (this.EdtContent.Value.Trim().Equals(""))
            {
                Common.MessageBox.ShowAndRedirect(this, "新闻内容不能为空!", "Collect_News.aspx");
            }
            if (this.HidClassID.Value.Trim().Equals(""))
            {
                Common.MessageBox.ShowAndRedirect(this, "新闻入库后的栏目不能为空!", "Collect_News.aspx");
            }
            CollectNewsInfo info = new CollectNewsInfo();
            if (!this.TxtDate.Text.Trim().Equals(""))
            {
                try
                {
                    info.AddDate = Convert.ToDateTime(this.TxtDate.Text);
                }
                catch
                {
                    Common.MessageBox.ShowAndRedirect(this, "采集日期格式不正确!", "Collect_News.aspx");
                }
            }
            else
            {
                info.AddDate = DateTime.Now;
            }
            info.SiteID = site;
            info.Title = this.TxtTitle.Text;
            info.Source = this.TxtSource.Text;
            info.Author = this.TxtAuthor.Text;
            info.Content = this.EdtContent.Value;
            info.Links = this.TxtLink.Text.Trim();
            info.ClassID = this.HidClassID.Value;
            Foosun.CMS.Collect.Collect cl = new Foosun.CMS.Collect.Collect();
            cl.NewsUpdate(id, info);
            Common.MessageBox.ShowAndRedirect(this, "修改新闻成功!", "Collect_News.aspx");
        }
    }
}

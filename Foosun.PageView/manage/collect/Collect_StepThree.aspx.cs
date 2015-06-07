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
using System.IO;
using Foosun.CMS.Collect;

public partial class Collect_StepThree : Foosun.PageBasic.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.EdtListURL.SetTextAreaRows = 7;
            this.EdtListURL.SetTag = new string[] { "[列表URL]", "[变量]" };
            this.EdtListURL.SetMaxLength = 4000;
            if (Request.QueryString["ID"] == null || Request.QueryString["ID"].Trim().Equals(""))
            {
                Common.MessageBox.Show(this, "没有传送必要的参数!");
            }
            else
            {
                int n = int.Parse(Request.QueryString["ID"]);
                Foosun.CMS.Collect.Collect cl = new Foosun.CMS.Collect.Collect();
                DataTable tb = cl.GetSite(n);
                if (tb == null || tb.Rows.Count == 0)
                {
                    Common.MessageBox.ShowAndRedirect(this, "传送的参数无效,没有找到该站点的信息!", "Collect_StepTwo.aspx?id=" + n);
                }
                if (!tb.Rows[0].IsNull("LinkSetting"))
                    this.EdtListURL.Text = tb.Rows[0]["LinkSetting"].ToString();
                this.HidSiteID.Value = n.ToString();
                string sUrl = this.HidUrl.Value = tb.Rows[0]["objURL"].ToString();
                string pattern = @"<body[^>]*>(?<list>[\s\S]+?)</body>";
                if (!tb.Rows[0].IsNull("ListSetting"))
                {
                    pattern = tb.Rows[0]["ListSetting"].ToString();
                }
                PageList pl = new PageList(sUrl, tb.Rows[0]["Encode"].ToString());
                pl.RuleOfList = pattern;
                if (!pl.Fetch())
                {
                    PageError(pl.LastError, "");
                    return;
                }
                pl.FigureList();
                this.TxtContentCode.Text = pl.List;
                tb.Dispose();
                if (this.TxtContentCode.Text == null || this.TxtContentCode.Text.Trim() == "")
                {
                    Common.MessageBox.ShowAndRedirect(this, "采集不到任何网页,请返回检查页址是否正确,编码方式是否正确!", "Collect_Add.aspx?Type=Site&ID=" + n);
                }
            }
        }
    }
    protected void BtnNext_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (EdtListURL.Text.IndexOf("[列表URL]") < 0)
            {
                Common.MessageBox.Show(this, "列表URL没有设置或设置不正确!");
            }
            int id = int.Parse(HidSiteID.Value);
            string surl = this.HidUrl.Value;
            string sList = this.TxtContentCode.Text;
            string pattern = this.EdtListURL.Text.Trim();
            PageList pl = new PageList(surl);
            pl.RuleOfLink = pattern;
            pl.List = this.TxtContentCode.Text;
            pl.Fetch();
            pl.FigureNewsUrls();
            string oburl = "";
            string[] url = pl.NewsUrl;
            try
            {
                for (int i = 0; i < url.Length; i++)
                {
                    if (i > 0)
                        oburl += "***";
                    oburl += url[i];
                }
            }
            catch
            {
            }
            HttpCookie ck = new HttpCookie("CollectObtainURL");
            ck.Value = oburl;
            Response.Cookies.Add(ck);
            Foosun.Model.CollectSiteInfo nf = new Foosun.Model.CollectSiteInfo();
            nf.ID = id;
            nf.LinkSetting = EdtListURL.Text;
            Foosun.CMS.Collect.Collect cl = new Foosun.CMS.Collect.Collect();
            cl.SiteUpdate(nf, 3);
            Server.Transfer("Collect_StepFour.aspx?ID=" + this.HidSiteID.Value);
        }
    }
}

using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.jsmodel
{
    public partial class JSAdd : Foosun.PageBasic.ManagePage
    {
        public string jspath = "";
        public string title = "";
        public JSAdd()
        {
            Authority_Code = "C052";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";//设置页面无缓存
            if (!Page.IsPostBack)
            {
                if (Request.Form["tid"] != null && !Request.Form["tid"].Trim().Equals(""))
                {
                    Response.Write(templets(Request.Form["tid"]));
                    Response.End();
                }
                else
                {
                    if (SiteID != "0")
                    {
                        jspath = "jsfiles/js/" + SiteID;
                    }
                    else
                    {
                        jspath = "jsfiles/js";
                    }
                    this.TxtSavePath.Text = "/" + jspath;
                    this.TxtSavePath.Attributes.Add("readonly", "true");
                    title = "新增JS";
                    Foosun.CMS.NewsJSTemplet jt = new Foosun.CMS.NewsJSTemplet();
                    DataTable tb = jt.GetList("");
                    if (tb == null || tb.Rows.Count < 1)
                    {
                        PageError("没有JS模板,请先新增JS模板!", "JSTempletAdd.aspx");
                    }
                    int fsys = 0, ffree = 0;
                    foreach (DataRow r in tb.Rows)
                    {
                        ListItem it = new ListItem();
                        it.Value = r["TempletID"].ToString();
                        it.Text = r["CName"].ToString();
                        if (r["jsTType"].ToString().Equals("0"))
                        {
                            fsys++;
                            this.DdlTempSys.Items.Add(it);
                        }
                        else
                        {
                            ffree++;
                            this.DdlTempFree.Items.Add(it);
                        }
                    }
                    ListItem itm = new ListItem();
                    itm.Text = "<没有可用模板>";
                    if (fsys.Equals(0))
                    {
                        this.DdlTempSys.Items.Add(itm);
                        this.RadTypeSys.Enabled = false;
                        this.RadTypeSys.Text += "[无可用模板]";
                        this.RadTypeFree.Checked = true;
                    }
                    if (ffree.Equals(0))
                    {
                        this.DdlTempFree.Items.Add(itm);
                        this.RadTypeFree.Enabled = false;
                        this.RadTypeFree.Text += "[无可用模板]";
                        this.RadTypeSys.Checked = true;
                    }
                    this.HidID.Value = "-1";
                    if (Request.QueryString["ID"] != null && !Request.QueryString["ID"].Trim().Equals(""))
                    {
                        this.Authority_Code = "C053";
                        this.CheckAdminAuthority();
                        int id = int.Parse(Request.QueryString["ID"]);
                        title = "修改JS";
                        this.HidID.Value = id.ToString();
                        Foosun.CMS.NewsJS nj = new Foosun.CMS.NewsJS();
                        Foosun.Model.NewsJS jf = nj.GetModel(id);
                        this.HidJsID.Value = jf.JsID;
                        this.TxtName.Text = jf.JSName;
                        this.TxtNum.Text = jf.jsNum.ToString();
                        this.TxtSavePath.Text = jf.jssavepath;
                        this.TxtFileName.Text = jf.jsfilename;
                        TxtContent.Text = jf.jsContent;
                        if (jf.jsType.Equals(0))
                        {
                            this.RadTypeSys.Checked = true;
                            this.DdlTempSys.SelectedValue = jf.JsTempletID;
                        }
                        else if (jf.jsType.Equals(1))
                        {
                            this.RadTypeFree.Checked = true;
                            this.TxtLenContent.Text = jf.jsLenContent.ToString();
                            this.TxtLenTitle.Text = jf.jsLenTitle.ToString();
                            this.TxtColsNum.Text = jf.jsColsNum.ToString();
                            this.TxtLenNavi.Text = jf.jsLenNavi.ToString();
                            this.DdlTempFree.SelectedValue = jf.JsTempletID;
                        }
                        else
                        {
                            PageError("未知的JS类型!", "JSTempletAdd.aspx");
                        }
                        this.RadTypeSys.Enabled = false;
                        this.RadTypeFree.Enabled = false;
                    }
                }
            }
        }
        /// <summary>
        /// 得到内容
        /// </summary>
        /// <returns></returns>
        protected string templets(string tid)
        {
            string tmplet = "找不到内容模型";
            Foosun.CMS.NewsJSTemplet rd = new Foosun.CMS.NewsJSTemplet();
            if (tid != "" && tid != null)
            {
                DataTable dt = rd.GetList(" and TempletID='" + tid.ToString() + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        tmplet = dt.Rows[0]["JSTContent"].ToString();
                    }
                    dt.Clear(); dt.Dispose();
                }
            }
            else
            {
                return "参数错误！";
            }
            return tmplet;
        }
        protected void BtnOK_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Foosun.Model.NewsJS info = new Foosun.Model.NewsJS();
                info.Id = int.Parse(this.HidID.Value);
                info.JSName = this.TxtName.Text.Trim();
                info.jsNum = int.Parse(this.TxtNum.Text);
                info.jsContent = this.TxtContent.Text.Trim();
                info.jsType = 0;
                info.JsID = this.HidJsID.Value;
                info.JsTempletID = this.DdlTempSys.SelectedValue;
                info.jsLenContent = -1;
                info.jsLenNavi = -1;
                info.jsLenTitle = -1;
                info.jsColsNum = -1;
                if (this.RadTypeFree.Checked)
                {
                    info.jsType = 1;
                    info.JsTempletID = this.DdlTempFree.SelectedValue;
                    info.jsLenContent = int.Parse(this.TxtLenContent.Text);
                    info.jsLenNavi = int.Parse(this.TxtLenNavi.Text);
                    info.jsLenTitle = int.Parse(this.TxtLenTitle.Text);
                    info.jsColsNum = int.Parse(this.TxtColsNum.Text);
                }
                info.jssavepath = this.TxtSavePath.Text.Trim();
                info.jsfilename = this.TxtFileName.Text.Trim();
                Foosun.CMS.NewsJS nj = new Foosun.CMS.NewsJS();
                string message = "";
                if (info.Id > 0)
                {
                    string result = "";
                    try
                    {
                        result = nj.Update(info);
                    }
                    catch (Exception ex)
                    {

                        PageError(ex.Message, "JSList.aspx");
                    }
                    if (Common.Input.IsInteger(result))
                    {
                        message = "修改JS成功!";
                        Foosun.Publish.UltiPublish.PublishSingleJsFile(info.Id);
                        PageRight(message, "JSList.aspx");
                    }
                    else
                    {
                        message = result;
                        PageError(message, "JSList.aspx");
                    }
                }
                else
                {
                    string result = "";
                    try
                    {
                        result = nj.Add(info);
                    }
                    catch (Exception ex)
                    {
                        PageError(ex.Message, "JSList.aspx");
                    }

                    if (Common.Input.IsInteger(result))
                    {
                        message = "新增JS成功!";
                        Foosun.Publish.UltiPublish.PublishSingleJsFile(Convert.ToInt32(result));
                        PageRight(message, "JSList.aspx");
                    }
                    else
                    {
                        message = result;
                        PageError(message, "JSList.aspx");
                    }
                }
            }
        }
    }
}
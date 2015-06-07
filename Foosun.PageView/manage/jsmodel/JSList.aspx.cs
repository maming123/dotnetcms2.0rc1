using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.jsmodel
{
    public partial class JSList : Foosun.PageBasic.ManagePage
    {
        public JSList()
        {
            Authority_Code = "C051";
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_OnPageChange);
            Response.CacheControl = "no-cache"; //清除缓存
            if (Request.Form["JSID"] != null && !Request.Form["JSID"].Trim().Equals(""))
            {
                if (Request.Form["Option"] != null && Request.Form["Option"].Equals("DeleteJS"))
                {
                    this.Authority_Code = "C054";
                    this.CheckAdminAuthority();
                    Foosun.CMS.NewsJS nj = new Foosun.CMS.NewsJS();
                    try
                    {
                        nj.Delete(Request.Form["JSID"].Trim());
                        Response.Write("成功删除指定JS");
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    Response.End();
                    return;
                }
                else if (Request.Form["Option"] != null && Request.Form["Option"].Equals("GetCode"))
                {
                    int id = int.Parse(Request.Form["JSID"]);
                    Foosun.CMS.NewsJS nj = new Foosun.CMS.NewsJS();
                    Foosun.Model.NewsJS info = nj.GetModel(id);
                    Response.Write("<textarea name=\"textfield\" id=\"codecontent\" style=\"width: 99%; height: 110px\"><script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.ServerInfo.GetRootURI(Request) + info.jssavepath + "/" + info.jsfilename + ".js\"></script></textarea>");
                    Response.End();
                    return;
                    
                }               
            }
            if (!IsPostBack)
            {
                this.HidType.Value = "-1";
                this.LnkBtnALL.Enabled = false;
                DataListBind(1);
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="IndexPage"></param>

        protected void PageNavigator1_OnPageChange(object sender, int IndexPage)
        {
            DataListBind(IndexPage);
        }

        /// <summary>
        /// 管理页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// code by chenzhaohui

        protected void DataListBind(int PageIndex)
        {
            int RdCount = 0, PgCount = 0;
            Foosun.CMS.NewsJS nj = new Foosun.CMS.NewsJS();
            Foosun.CMS.NewsJSFile cnjf= new CMS.NewsJSFile();
            DataTable dt = nj.GetPage(PageIndex, PAGESIZE, out RdCount, out PgCount, int.Parse(this.HidType.Value));
            this.PageNavigator1.RecordCount = RdCount;
            this.PageNavigator1.PageCount = PgCount;
            this.PageNavigator1.PageIndex = PageIndex;
            if (dt!=null&&dt.Rows.Count>0)
            {
                dt.Columns.Add("type", typeof(string));
                dt.Columns.Add("code",typeof(string));
                dt.Columns.Add("number", typeof(string));
                dt.Columns.Add("edit", typeof(string));
                foreach (DataRow item in dt.Rows)
                {
                    string _type = "";
                    if (item["jsType"].ToString ()=="0")
                    {
                        _type = "系统JS";
                        item["number"] = item["jsNum"];
                    }
                    else if (item["jsType"].ToString() == "1")
                    {
                        _type = "自由JS";
                        item["number"] = "<a href=\"javascript:ShowNewsJs(" + item["id"] + ");\">" + cnjf.GetRecordCount("JsID='" + item["JsID"] + "'") + "(<font color=\"red\">" + item["jsNum"] + "</font>)[查看]</a>";
                    }
                    else
                    {
                        item["number"] = item["jsNum"];
                        _type = "未知类型";
                    }
                    item["type"] = _type;
                    item["code"] = "<a href=\"javascript:GetJSCode(" + item["id"] + ");\" >代码</a>";
                    item["edit"] = "<a href=\"JSAdd.aspx?ID=" + item["id"] + "\">修改</a><a href=\"javascript:DeleteJS(" + item["id"] + ");\" ><img src=\"../imges/lie_65.gif\" alt=\"彻底删除\"></a> <input type=\"checkbox\" name=\"checkbox\" value=\"" + item["id"] + "\"/>";
                }
            }
            rptjs.DataSource = dt.DefaultView;
            rptjs.DataBind();
        }
        protected void LnkBtnALL_Click(object sender, EventArgs e)
        {
            this.HidType.Value = "-1";
            this.LnkBtnALL.Enabled = false;
            this.LnkBtnFree.Enabled = true;
            this.LnkBtnSys.Enabled = true;
            DataListBind(1);

        }
        protected void LnkBtnSys_Click(object sender, EventArgs e)
        {
            this.HidType.Value = "0";
            this.LnkBtnALL.Enabled = true; ;
            this.LnkBtnFree.Enabled = true;
            this.LnkBtnSys.Enabled = false;
            DataListBind(1);
        }
        protected void LnkBtnFree_Click(object sender, EventArgs e)
        {
            this.HidType.Value = "1";
            this.LnkBtnALL.Enabled = true; ;
            this.LnkBtnFree.Enabled = false;
            this.LnkBtnSys.Enabled = true;
            DataListBind(1);
        }
    }
}
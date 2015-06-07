using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.jsmodel
{
    public partial class JsTemplet : Foosun.PageBasic.ManagePage
    {
        public JsTemplet()
        {
            Authority_Code = "C055";
        }
        Foosun.CMS.NewsJSTemplet cjs = new CMS.NewsJSTemplet();
        Foosun.CMS.NewsJSTempletClass cjssclass = new CMS.NewsJSTempletClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_OnPageChange);
            Response.CacheControl = "no-cache"; //清除缓存           
            if (Request.Form["Option"] != null && Request.Form["ID"] != null)
            {
                try
                {
                    string id = Request.Form["ID"];
                    switch (Request.Form["Option"])
                    {
                        case "DeleteJSTmpClass":
                            cjssclass.ClassDelete(id);
                            Response.Write("成功删除一个JS模型分类及其子分类和所属JS模型!");
                            break;
                        case "DeleteJSTemplet":
                            cjs.Delete(int.Parse(id));
                            Response.Write("成功删除一个JS模型!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("0%" + ex.Message);
                }
                Response.End();
            }
            if (!IsPostBack)
            {
                DataTable tb = cjssclass.GetList("");
                ClassRender(tb, "0", 0);
                DataListBind(1);
            }
        }
        protected void PageNavigator1_OnPageChange(object sender, int IndexPage)
        {
            DataListBind(IndexPage);
        }
        protected void DataListBind(int PageIndex)
        {
            int RCount = 0, PCount = 0;
            DataTable tb = cjs.GetPage(PageIndex, PAGESIZE, out RCount, out PCount, this.DdlClass.SelectedValue);
            this.PageNavigator1.RecordCount = RCount;
            this.PageNavigator1.PageCount = PCount;
            this.PageNavigator1.PageIndex = PageIndex;
            if (tb!=null&&tb.Rows.Count>0)
            {
                tb.Columns.Add("type",typeof(string));
                tb.Columns.Add("edit", typeof(string));
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    string _type = "";
                    string _edit = "";
                    if (tb.Rows[i]["JSTType"].ToString() == "0")
                    {
                        _type = "系统JS模型";
                        _edit = "<a href=\"JSTempletAdd.aspx?ID=" +tb.Rows[i]["id"].ToString() + "\">修改</a> <a href=\"javascript:DeleteTmp(" + tb.Rows[i]["id"].ToString() + ");\"><img src=\"../imges/lie_65.gif\" /></a>";
                    }
                    else if (tb.Rows[i]["JSTType"].ToString() == "1")
                    {
                        _type = "自由JS模型";
                        _edit = "<a href=\"JSTempletAdd.aspx?ID=" + tb.Rows[i]["id"].ToString() + "\">修改</a> <a href=\"javascript:DeleteTmp(" + tb.Rows[i]["id"].ToString() + ");\"><img src=\"../imges/lie_65.gif\" /></a>";
                    }
                    else
                    {
                        _type = "有" + tb.Rows[i]["NumCLS"].ToString() + "个分类," + tb.Rows[i]["NumTMP"].ToString() + "个模型";
                        _edit = "<a href=\"javascript:GoToClass('" + tb.Rows[i]["TmpID"].ToString() + "');\">进入</a> <a href=\"JSTempletClass.aspx?ID=" + tb.Rows[i]["id"].ToString() + "\">修改</a> <a href=\"javascript:DeleteClass('" + tb.Rows[i]["TmpID"].ToString() + "');\"><img src=\"../imges/lie_65.gif\" /></a>";
                    }
                    tb.Rows[i]["type"] = _type;
                    tb.Rows[i]["edit"] = _edit;                  
                }
                
            }
            DataList1.DataSource = tb.DefaultView;
            DataList1.DataBind();
        }
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="PID"></param>
        /// <param name="Layer"></param>
        private void ClassRender(DataTable tb, string PID, int Layer)
        {
            DataRow[] row = tb.Select("ParentID='" + PID + "'");
            if (row.Length < 1)
                return;
            else
            {
                foreach (DataRow r in row)
                {
                    ListItem it = new ListItem();
                    it.Value = r["ClassID"].ToString();
                    string stxt = "├";
                    for (int i = 0; i < Layer; i++)
                    {
                        stxt += "─";
                    }
                    it.Text = stxt + r["CName"].ToString();
                    this.DdlClass.Items.Add(it);
                    ClassRender(tb, r["ClassID"].ToString(), Layer + 1);
                }
            }
        }
        protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataListBind(1);
        }
    }
}
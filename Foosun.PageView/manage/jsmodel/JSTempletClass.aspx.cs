using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.jsmodel
{
    public partial class JSTempletClass : Foosun.PageBasic.ManagePage
    {
        public JSTempletClass()
        {
            Authority_Code = "C056";
        }
        private int id;
        Foosun.CMS.NewsJSTempletClass cNewsJS = new CMS.NewsJSTempletClass();
        public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache"; //清除缓存           
            if (!IsPostBack)
            {
                
                id = 0;
                if (Request.QueryString["ID"] != null)
                {
                    id = int.Parse(Request.QueryString["ID"]);
                }
                DataTable tb = cNewsJS.GetList("");
                ClassRender(tb, "0", 0);
                title = "新增JS模型分类";
                if (id > 0)
                {
                    title = "修改JS模型分类";
                    DataTable dt = cNewsJS.GetList(" and id="+id);
                    if (dt == null || dt.Rows.Count < 1)
                        PageError("没有找到相关记录", "JSTemplet.aspx");
                    this.TxtName.Text = dt.Rows[0]["CName"].ToString();
                    this.DdlUpperClass.SelectedValue = dt.Rows[0]["ParentID"].ToString();
                    this.TxtDescription.Text = dt.Rows[0]["Description"].ToString();
                }
                this.HidID.Value = id.ToString();
                if (Request.QueryString["Upper"] != null && !Request.QueryString["Upper"].Trim().Equals(""))
                    this.DdlUpperClass.SelectedValue = Request.QueryString["Upper"];
            }
        }
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="PID"></param>
        /// <param name="Layer"></param>
        private void ClassRender(DataTable tb, string PID, int Layer)
        {
            string sFilter = "ParentID='" + PID + "'";
            if (id > 0)
                sFilter += " and id<>" + id;
            DataRow[] row = tb.Select(sFilter);
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
                    this.DdlUpperClass.Items.Add(it);
                    ClassRender(tb, r["ClassID"].ToString(), Layer + 1);
                }
            }
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)//判断页面是否通过验证
            {
                Foosun.Model.NewsJSTempletClass mJS = new Model.NewsJSTempletClass();
                int cid = int.Parse(this.HidID.Value);
                mJS.CName=this.TxtName.Text.Trim();
                if (mJS.CName.Equals(""))
                {
                    PageError("分类名称请必须填写!", "");
                }
                 mJS.ParentID= this.DdlUpperClass.SelectedValue;
                 mJS.Description= this.TxtDescription.Text.Trim();
                 if (mJS.Description.Length > 500)
                {
                    PageError("描述信息必须在500字以内!", "");
                }

                 if (cid > 0)
                 {
                     try
                     {
                         cNewsJS.Update(mJS);
                     }
                     catch (Exception ex)
                     {
                         PageError(ex.Message, "JSTempletClass.aspx");
                     }

                     PageRight("修改JS模型分类成功!", "JSTemplet.aspx");
                 }
                 else
                 {
                     try
                     {
                         cNewsJS.Add(mJS);
                     }
                     catch (Exception ex)
                     {
                         PageError(ex.Message, "JSTempletClass.aspx");
                     }

                     PageRight("新增JS模型分类成功!", "JSTemplet.aspx");
                 }
            }
        }
    }
}
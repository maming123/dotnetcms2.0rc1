using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.label
{
    public partial class syslabelbak : Foosun.PageBasic.ManagePage
    {
        public syslabelbak()
        {
            Authority_Code = "T015";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";                        //设置页面无缓存           
            string str_Op = Request.Form["Op"];
            if (str_Op != "" && str_Op != null && str_Op != string.Empty)
            {
                string str_ID = Request.Form["LabelID"];
                Rec(Common.Input.checkID(str_ID));
            }
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            StartLoad(1);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <returns>分页</returns>
        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            StartLoad(PageIndex);
        }

        protected void StartLoad(int PageIndex)
        {
            int i, j;
            Foosun.Model.SQLConditionInfo st = new Foosun.Model.SQLConditionInfo("@SiteID", SiteID);
            DataTable dt = Foosun.CMS.Pagination.GetPage("manage_label_syslabelbak_aspx", PageIndex, 20, out i, out j, st);
            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = i;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    //----------------------------------------添加列------------------------------------------------
                    dt.Columns.Add("Op", typeof(string));
                    for (int k = 0; dt.Rows.Count > k; k++)
                    {
                        dt.Rows[k]["Op"] = "<a href=\"javascript:Rec('" + dt.Rows[k]["LabelID"].ToString() + "');\">[恢复标签]<a href=\"syslableadd.aspx?LabelID=" + dt.Rows[k]["LabelID"].ToString() + "\">[修改]</a>";
                    }
                }
                DataList1.DataSource = dt;                              //设置datalist数据源
                DataList1.DataBind();                                   //绑定数据源
                dt.Clear();
                dt.Dispose();
            }
        }

        /// <summary>
        /// 恢复标签
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns>恢复标签</returns>
        protected void Rec(string ID)
        {
            Foosun.CMS.Label lc = new Foosun.CMS.Label();
            lc.LabelToResume(ID);
            Response.Clear();
            Response.Write("标签恢复成功！");
            Response.End();
        }
    }
}
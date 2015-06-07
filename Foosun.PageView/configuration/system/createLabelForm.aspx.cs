using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.configuration.system
{
    public partial class createLabelForm : Foosun.PageBasic.ManagePage
    {
        public string APIID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            APIID = SiteID;
            if (!IsPostBack)
            {

                showForm(1);
            }
        }

        /// <summary>
        /// 填充表单类型
        /// </summary>
        protected void showForm(int PageIndex)
        {
            int nRCount, nPCount;
            DataTable tb = Foosun.CMS.Pagination.GetPage("manage_label_style_add.aspx", PageIndex, 20, out nRCount, out nPCount);
            //表单列表中表单类型绑定
            this.FormTableName.DataSource = tb;
            this.FormTableName.DataTextField = "formname";
            this.FormTableName.DataValueField = "formtablename";
            this.FormTableName.DataBind();
            FormTableName.Items.Insert(0, new ListItem("请选择表单", ""));
            //表单列表中提交表单绑定
            this.FormID.DataSource = tb;
            this.FormID.DataTextField = "formname";
            this.FormID.DataValueField = "id";
            this.FormID.DataBind();
            this.FormID.Items.Insert(0, new ListItem("请选择表单", ""));
        }
    }
}
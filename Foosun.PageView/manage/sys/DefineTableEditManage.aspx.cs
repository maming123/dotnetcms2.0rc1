using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.sys
{
    public partial class DefineTableEditManage : Foosun.PageBasic.ManagePage
    {
        public DefineTableEditManage()
        {
            Authority_Code = "Q033";
        }
        Foosun.CMS.DefineTable def = new Foosun.CMS.DefineTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Start();
            }
        }
        /// <summary>
        /// 初始
        /// </summary>

        protected void Start()
        {
            string DefID = Request.QueryString["DefID"];
            if (DefID == null || DefID == "" || DefID == string.Empty)
            {
                PageError("参数错误", "");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = def.Str_DefID(DefID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    #region 取值
                    this.PraText.Text = dt.Rows[0]["ParentInfoId"].ToString();
                    this.NewText.Text = dt.Rows[0]["DefineName"].ToString();
                    #endregion
                }
                else
                {
                    PageError("未知错误", "");
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region save
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)//判断页面是否通过验证
            {
                string DefID = Request.QueryString["DefID"];
                if (DefID == null || DefID == "" || DefID == string.Empty)
                {
                    PageError("参数错误", "DefineTableEditManage.aspx");
                }
                else
                {
                    string Str_NewText = Common.Input.Filter(this.NewText.Text.Trim());//名称               
                    #region 刷新页面
                    if (def.Update1(Str_NewText, DefID) != 0)
                    {
                        PageRight("修改成功", "DefineTableManage.aspx");
                    }
                    else
                    {
                        PageError("意外错误：未知错误", "");
                    }
                }
                    #endregion
            }
        }
        #endregion
    }
}
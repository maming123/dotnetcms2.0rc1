using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.Contribution
{
    public partial class ConstrReturn :Foosun.PageBasic.ManagePage
    {
        public ConstrReturn()
        {
            Authority_Code = "C044";
        }
        Constr con = new Constr();
        public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            if (!IsPostBack)
            {
                string ConID = Common.Input.Filter(Request.QueryString["ConID"].ToString());
                DataTable dt = con.Sel23(ConID);
                int ispass = int.Parse(dt.Rows[0]["ispass"].ToString());
                if (ispass == 1)
                {
                    PageError("抱歉此稿已退不能再次退稿", "");
                }
                title = dt.Rows[0]["Title"].ToString();
            }

        }
        protected void But_Click(object sender, EventArgs e)
        {
            RootPublic rd = new RootPublic();
            string ConIDs = Common.Input.Filter(Request.QueryString["ConID"].ToString());
            string passcontent = Common.Input.Filter(Request.Form["passcontent"].ToString());
            if (con.Update6(passcontent, ConIDs) == 0)
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "退稿", "操作失败");
                PageError("退稿失败", "");
            }
            else
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "退稿", "操作成功");
                PageRight("退稿成功", "ConstrList.aspx");
            }
        }
    }
}
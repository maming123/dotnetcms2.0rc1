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
using Foosun.CMS;

public partial class user_arealist_upc : Foosun.PageBasic.ManagePage
{
    public user_arealist_upc()
    {
        Authority_Code = "U032";
    }
    Arealist ali = new Arealist();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Response.CacheControl = "no-cache";
            
            DataTable dtp = ali.sel_5();
            this.DropDownList1.DataSource = dtp;
            this.DropDownList1.DataTextField = "cityName";
            this.DropDownList1.DataValueField = "Cid";
            this.DropDownList1.DataBind();
            string pname = Common.Input.Filter(Request.QueryString["Cid"].ToString());
            DataTable dtc = ali.sel_6(pname);
            if (dtc.Rows[0]["Pid"].ToString() != "")
            {
                string pNm = dtc.Rows[0]["Pid"].ToString();
                for (int r = 0; r < this.DropDownList1.Items.Count - 1; r++)
                {
                    if (this.DropDownList1.Items[r].Value == pNm)
                    {
                        this.DropDownList1.Items[r].Selected = true;
                    }
                }
            }
            this.cityName.Text = dtc.Rows[0]["cityName"].ToString();
            this.OrderID.Text = dtc.Rows[0]["OrderID"].ToString();
        }
    }
    protected void but1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            RootPublic rd = new RootPublic();
            string cityName = Common.Input.Filter(Request.Form["cityName"].ToString());
            string cids = Common.Input.Filter(Request.QueryString["Cid"].ToString());
            string OrderID = this.OrderID.Text;
            if (!Common.Input.IsInteger(OrderID))
            {
                PageError("排序号请用0-100的数字。数字越大，越靠前。", "arealist.aspx");
            }
            DateTime creatTime = DateTime.Now;
            string Pid = this.DropDownList1.SelectedValue;

            if (ali.Update(Pid, cityName, creatTime, cids, int.Parse(OrderID)) == 0)
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "修改大类", "修改错误");
                PageError("修改错误", "arealist.aspx");
            }
            else
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "修改大类", "修改成功");
                PageRight("修改成功", "arealist.aspx");
            }

        }
    }

}


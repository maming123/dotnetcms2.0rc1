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
public partial class user_arealist_add : Foosun.PageBasic.ManagePage
{
    public user_arealist_add()
    {
        Authority_Code = "U032";
    }
    Arealist ali = new Arealist();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Response.CacheControl = "no-cache";
            if (Request.QueryString["Cid"]!=null)
            {
                string Cid = Common.Input.Filter(Request.QueryString["Cid"].ToString());
                DataTable dt = ali.sel_7(Cid);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.cityName.Text = dt.Rows[0]["cityName"].ToString();
                        this.OrderID.Text = dt.Rows[0]["OrderID"].ToString();
                    }
                    dt.Clear(); dt.Dispose();
                }
            }
        }
    }
    protected void but1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            RootPublic rd = new RootPublic();
            string cityName = Common.Input.Filter(Request.Form["cityName"].ToString());
            if (ali.sel_nameTF(cityName) == 1){PageError("此名称已经存在!", "arealist.aspx");}
            string OrderID = this.OrderID.Text;
            if (!Common.Input.IsInteger(OrderID))
            {
                PageError("排序号请用0-100的数字。数字越大，越靠前。", "arealist.aspx");
            }
            if (Request.QueryString["Cid"] != null)
            {
                DateTime creatTime = DateTime.Now;
                string Cids = Common.Input.Filter(Request.QueryString["Cid"].ToString());
                if (ali.Update_1(cityName, creatTime, Cids, int.Parse(OrderID)) == 0)
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "修改大类", "修改错误");
                    PageError("修改错误<br>", "arealist.aspx");
                }
                else
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "修改大类", "修改成功");
                    PageRight("修改成功", "arealist.aspx");
                }
            }
            else
            {
                string Cid = Common.Rand.Number(12);
                DateTime creatTime = DateTime.Now;
                DataTable dt = ali.sel_2();
                int cutb = dt.Rows.Count;
                string Cids = "";
                if (cutb > 0)
                {
                    Cids = dt.Rows[0]["Cid"].ToString();
                }

                if (Cids != Cid)
                {
                    if (ali.Add(Cid, cityName, creatTime, int.Parse(OrderID)) == 0)
                    {
                        rd.SaveUserAdminLogs(1, 1, UserNum, "添加大类", "添加失败");
                        PageError("添加错误<br>", "arealist.aspx");
                    }
                    else
                    {
                        rd.SaveUserAdminLogs(1, 1, UserNum, "添加大类", "添加成功");
                        PageRight("添加成功", "arealist.aspx");
                    }
                }
                else
                {
                    PageError("对不起建立失败有可能是编号重复<br>", "arealist.aspx");
                }
            }

        }
    }

}


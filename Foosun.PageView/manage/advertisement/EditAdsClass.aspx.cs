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

public partial class EditAdsClass : Foosun.PageBasic.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";                        //设置页面无缓存
        if (!IsPostBack)
        {
            getAdsClassInfo();
        }
    }

    /// <summary>
    /// 修改分类信息
    /// </summary>
    /// <returns>修改分类信息</returns>
    /// Code By DengXi

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Foosun.Model.AdsClassInfo aci = new Foosun.Model.AdsClassInfo();
            aci.AcID = Common.Input.Filter(Request.Form["adsclassid"]);
            aci.Cname = Common.Input.Filter(Request.Form["AdsClassName"]);
            aci.ParentID = "";
            if (Request.Form["AdsPrice"].ToString() != null && Request.Form["AdsPrice"].ToString() != "")
                aci.Adprice = int.Parse(Request.Form["AdsPrice"].ToString());
            else
                aci.Adprice = 0;
            aci.creatTime = DateTime.Now;
            aci.SiteID = SiteID;

            Foosun.CMS.Ads ac = new Foosun.CMS.Ads();
            int result = ac.EditClass(aci);

            if (result == 1)
                Common.MessageBox.ShowAndRedirect(this, "修改分类信息成功!", "AdList.aspx");
            else
                Common.MessageBox.Show(this, "修改分类信息失败");
        }
    }

    /// <summary>
    /// 在前台显示分类信息
    /// </summary>
    /// <returns>在前台显示分类信息</returns>
    /// Code By DengXi

    protected void getAdsClassInfo()
    {
        string classid = Common.Input.Filter(Request.QueryString["AdsClassID"]);

        Foosun.CMS.Ads ac = new Foosun.CMS.Ads();
        DataTable dt = ac.getAdsClassInfo(classid);

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                string price = dt.Rows[0][2].ToString();
                AdsClassName.Text = dt.Rows[0][0].ToString();
                AdsParentID.Text = dt.Rows[0][1].ToString();
                AdsPrice.Text = price;
                adsclassid.Value = classid;
            }
            else
            {
                Common.MessageBox.Show(this, "参数传递错误!");
            }
            dt.Clear();
            dt.Dispose();
        }
        else
        {
            Common.MessageBox.Show(this, "参数传递错误!");
        }
    }
}

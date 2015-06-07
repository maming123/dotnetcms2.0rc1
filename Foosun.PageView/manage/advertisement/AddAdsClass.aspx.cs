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

public partial class AddAdsClass : Foosun.PageBasic.ManagePage
{
    public AddAdsClass()
    {
        Authority_Code = "S007";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";                        //设置页面无缓存
        if (!IsPostBack)
        {
                        //获取版权信息
            GetParentValue();
        }
    }

    /// <summary>
    /// 添加分类信息
    /// </summary>
    /// <returns>添加分类信息</returns>
    /// Code By DengXi

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            Foosun.Model.AdsClassInfo aci = new Foosun.Model.AdsClassInfo();
            aci.AcID = "";
            aci.Cname = Common.Input.Filter(AdsClassName.Text.ToString());
            aci.ParentID = Common.Input.Filter(AdsParentID.Text.ToString());
            if(AdsPrice.Text.ToString()!=null&& AdsPrice.Text.ToString()!="")
                aci.Adprice = int.Parse(AdsPrice.Text.ToString());
            else
                aci.Adprice = 0;
            aci.creatTime = DateTime.Now;
            aci.SiteID = SiteID;

            int result = 0;
            Foosun.CMS.Ads ac = new Foosun.CMS.Ads();
            result = ac.AddClass(aci);
            if(result==1)
                Common.MessageBox.ShowAndRedirect(this, "添加广告分类成功!", "AdList.aspx");
            else
                Common.MessageBox.Show(this, "添加广告分类成功!");
        }
    }


    /// <summary>
    /// 获取父类ID
    /// </summary>
    /// <returns>返回父类ID</returns>
    /// Code By DengXi

    protected void GetParentValue()
    {
        string str_parentID = Request.QueryString["ParentID"];
        if (str_parentID == "" || str_parentID == null || str_parentID == string.Empty)
            AdsParentID.Text = "0";
        else
            AdsParentID.Text = Common.Input.Filter(str_parentID);
    }
}

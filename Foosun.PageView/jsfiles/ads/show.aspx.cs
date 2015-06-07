///************************************************************************************************************
///**********增加广告显示次数Code By DengXi********************************************************************
///************************************************************************************************************
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

public partial class jsfiles_ads_show : Foosun.PageBasic.BasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string adsID = Request.QueryString["adsID"];
		adsID = Common.Input.checkID(adsID);
		if (CreateJs.CheckJs(adsID) == false)
		{
			Foosun.CMS.Ads ac = new Foosun.CMS.Ads();
			ac.upShowNum(adsID);

			DataTable dt = ac.getAdsPicInfo(" ClassID", "ads", adsID);
			//Response.Write("document.write('1234"+dt.Rows.Count+"')");
			if (dt != null && dt.Rows.Count > 0)
			{
				Response.Write("document.write('<script language=\"javascript\" " +
							   "src=\"" + Common.Public.GetSiteDomain() + "/jsfiles/ads/" +
							   "" + dt.Rows[0]["ClassID"].ToString() + "/" + adsID + ".js\"></script>');");
				dt.Clear(); dt.Dispose();
			}
		}
		else
		{
			Response.Write("document.write('此广告已失效');");
		}

	}
}

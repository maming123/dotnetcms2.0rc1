using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.Publish;

namespace Foosun.PageView.customform
{
	public partial class CustomFormList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "text/javascript";
			string pageindex = Request.Params["pageindex"];
			string divid = Request.Params["divid"];
			LabelMass l = new LabelMass("", "", "", "", 0, 0, 0, 0);
			string context = l.Analyse_FormList(Convert.ToInt32(pageindex), divid).Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r\n", "\\n").Replace("\n", "\\n");
			string info = "document.getElementById('" + divid + "').innerHTML='" + context + "';";
			Response.Write(info);
		}
	}
}

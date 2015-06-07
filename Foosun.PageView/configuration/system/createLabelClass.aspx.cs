using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.configuration.system
{
    public partial class createLabelClass :  Foosun.PageBasic.ManagePage {
		public string APIID = "0";
		Foosun.CMS.Label rd = new Foosun.CMS.Label();
		protected void Page_Load(object sender, EventArgs e) {
			APIID = SiteID;
			if (!IsPostBack) {

				string _dirdumm = Foosun.Config.UIConfig.dirDumm;
				if (_dirdumm.Trim() != "") { _dirdumm = "/" + _dirdumm; }
				style_class.InnerHtml = Common.Public.getxmlstylelist("styleContent2", _dirdumm + "/xml/cuslabeStyle/cstyleClassInfo.xml");				
			}
		}
	}
}
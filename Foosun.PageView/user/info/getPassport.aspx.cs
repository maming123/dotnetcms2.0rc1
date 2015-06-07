using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foosun.PageView.user.info {
	public partial class getPassport : Foosun.PageBasic.BasePage {
		protected void Page_Load(object sender, EventArgs e) {
			string emailCode = Request["c"];
			string vType = Request["t"];
			string userNumber = Request["u"];
			string email = Request["e"];
			if (vType == "mail") {
				Foosun.CMS.user userBll = new Foosun.CMS.user();
				if (userBll.EmailActive(emailCode, userNumber, email)) {
					PageRight("你的帐号激活成功！", "../Login.aspx");
				}
				else {
					PageError("激活失败！请联系管理员。", "");
				}
			}
		}
	}
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foosun.PageView.configuration {
	public partial class dateTime : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			for (int c = 1960; c < DateTime.Now.Year + 50; c++) {
				YearList.Items.Add(new ListItem(c + "年", c.ToString()));
			}
		}
	}
}
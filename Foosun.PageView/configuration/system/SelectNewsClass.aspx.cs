using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Foosun.CMS;

public partial class SelectNewsClass : Foosun.PageBasic.DialogPage {
    public SelectNewsClass()
    {
		BrowserAuthor = EnumDialogAuthority.ForPerson;
	}
	protected void Page_Load(object sender, EventArgs e) {
		if (!IsPostBack) {
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
		}
	}
}

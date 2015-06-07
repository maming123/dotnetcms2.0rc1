using System;
using Foosun.CMS;

public partial class GetClassCname : Foosun.PageBasic.DialogPage {
	public GetClassCname() {
		BrowserAuthor = EnumDialogAuthority.ForAdmin;
	}
	protected void Page_Load(object sender, EventArgs e) {
        Foosun.CMS.NewsClass NewsClassCMS = new NewsClass();
		string Type = Request.QueryString["Type"];
		string ClassID = Request.QueryString["ClassID"];
		string TCID = "";
		if (Type == "Class") {
			//add
            TCID = NewsClassCMS.GetNewsClassCName(ClassID.ToString());
			if (TCID == "没选择栏目") {
				if (!string.IsNullOrEmpty(Request.QueryString["add"])) {
					TCID = "根目录";
				}
			}
		}
		else if (Type == "special") {
			//TCID = rd.getspecialCName(ClassID.ToString());
		}
		Response.Write(TCID);
	}
}

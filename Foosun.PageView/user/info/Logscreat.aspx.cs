using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;

public partial class manage_Logscreat : Foosun.PageBasic.UserPage {
	user rd = new user();
	protected void Page_Load(object sender, EventArgs e) {
		if (!IsPostBack) {

			copyright.InnerHtml = CopyRight;
			LogDateTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
			if (Request.QueryString["Type"] == "edit") {
				int id = int.Parse(Request.QueryString["ID"]);
				DataTable dt = rd.getUserLogsValue(id);
				if (dt.Rows.Count > 0) {
					title.Text = dt.Rows[0]["title"].ToString();
					LogDateTime.Text = ((DateTime)dt.Rows[0]["LogDateTime"]).ToString("yyyy-MM-dd");
					Content.Text = dt.Rows[0]["Content"].ToString();
					dateNum.Text = dt.Rows[0]["dateNum"].ToString();
					log_id.Value = dt.Rows[0]["id"].ToString();
				}
			}
		}
	}
	protected void Logssubmit(object sender, EventArgs e) {
		//判断是否验证成功
		if (Page.IsValid == true) {
			//------------------获取表单值-----------------------------------------
			string title = Common.Input.Htmls(this.title.Text);
			string content = Common.Input.Htmls(this.Content.Text);
			DateTime LogDateTime = DateTime.Parse(this.LogDateTime.Text);
			int dateNum = int.Parse(this.dateNum.Text);
			DateTime creatDate = System.DateTime.Now;
			string ramAID;
			ramAID = Common.Rand.Number(12);//产生12位随机字符
			if (Request.Form["log_id"] == "") {
				DataTable dt = rd.getUserLogsRecord(ramAID);
				if (dt.Rows.Count > 0) {
					PageError("意外错误：有可能是系统编号重复，请重新添加", "");
				}
				else {
					Foosun.Model.UserLog1 uc = new Foosun.Model.UserLog1();
					uc.LogID = ramAID;
					uc.title = title;
					uc.content = content;
					uc.creatTime = creatDate;
					uc.dateNum = dateNum;
					uc.LogDateTime = LogDateTime;
					uc.usernum = Foosun.Global.Current.UserNum;
					rd.InsertUserLogs(uc);
					PageRight("添加日历成功。", "logs.aspx");
				}
			}
			else {
				int id = int.Parse(Request.Form["log_id"]);
				Foosun.Model.UserLog1 uc = new Foosun.Model.UserLog1();
				uc.Id = id;
				uc.title = title;
				uc.content = content;
				uc.dateNum = dateNum;
				uc.LogDateTime = LogDateTime;
				rd.UpdateUserLogs(uc);
				PageRight("修改日历成功。", "logs.aspx");
			}
		}
	}
}

using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

public partial class TempletEditor : Foosun.PageBasic.ManagePage
{
	public string Dir = string.Empty;
	public string FileName = string.Empty;
	private string DirMana = Foosun.Config.UIConfig.dirDumm;
	private string Templet = Foosun.Config.UIConfig.dirTemplet;  //获取模板路径
	private string str_FilePath = string.Empty;

	protected void Page_Load(object sender, EventArgs e) {
		Response.CacheControl = "no-cache";

		if (SiteID == "0") {
			str_FilePath = Server.MapPath(DirMana + "\\" + Templet);
		}
		else {
			string SitePath = DirMana + "\\" + Templet + "\\siteTemplets\\" + Foosun.Global.Current.SiteID;
			if (!Directory.Exists(Server.MapPath(SitePath))) { Directory.CreateDirectory(Server.MapPath(SitePath)); }
			str_FilePath = Server.MapPath(SitePath);
		}
		Dir = Request.QueryString["dir"];
		FileName = Request.QueryString["filename"];
		string filepath = str_FilePath + Dir.Replace("\\\\", "\\") + "\\" + FileName;
		string action = Request.QueryString["action"];
		if (!IsPostBack)                                               //判断页面是否重载
        {
			//判断用户是否登录
			dirPath.InnerHtml = "<span style=\"color:#999999;font-size:11.5px;\">当前路径:" + str_FilePath + Dir.Replace("\\\\", "\\") + "&nbsp;&nbsp;&nbsp;&nbsp;当前文件:" + FileName + "</span>";

            //copyright.InnerHtml = CopyRight;            //获取版权信息
			ShowFileContet(filepath);
			GetLabelList();
		}
		FilePath.Text = filepath;
	}

	/// <summary>
	/// 显示文件内容
	/// </summary>
	/// <param name="filepath">文件夹路径</param>
	/// <returns>显示文件内容</returns>
	protected void ShowFileContet(string filepath) {
		this.ContentTextBox.Value = Common.FileAction.ShowFileContet(filepath);
	}

	/// <summary>
	/// 保存文件
	/// </summary>
	/// <returns>保存文件</returns>
	protected void Button1_ServerClick(object sender, EventArgs e) {
		int Result = 0;
		string Content = this.ContentTextBox.Value;

		string doctypeContent = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>";
        string firstDoc = Content;
        if (Content.IndexOf("<html") != -1)
        {
            Content.Substring(Content.IndexOf("<html"), Content.Length - Content.IndexOf("<html"));
        }
		Content = doctypeContent + firstDoc;

		string Path = FilePath.Text.ToString();

		Result = Common.FileAction.SaveFile(Path, Content);

		string[] ForderPath = Dir.Split('\\');
		string TempSrc = string.Empty;
		foreach (string s in ForderPath) {
			if (s != "\\" && s != "") {
				TempSrc += "/" + s;
			}
		}
		ForderPath = TempSrc.Split('/');
		TempSrc = string.Empty;
		foreach (string s in ForderPath) {
			if (s != "/" && s != "") {
				TempSrc += "/" + s;
			}
		}

		TempSrc = TempSrc.Replace('/', '\\');
        string url = "TempletManageList.aspx";
        if (TempSrc != "")
        {
            url += "?Path=\\" + TempSrc;
        }
		if (Result == 1) {
            Common.MessageBox.ShowAndRedirect(this, "保存成功", url);
		}
		else {
            Common.MessageBox.ShowAndRedirect(this, "参数错误", url);
		}
	}

	protected void GetLabelList() {
		Foosun.CMS.Label lb = new Foosun.CMS.Label();
		DataTable dt = lb.getLableList(SiteID, 2);
		if (dt != null) {
			LabelList.DataTextField = "Label_Name";
			LabelList.DataValueField = "Label_Name";
			LabelList.DataSource = dt;
			LabelList.DataBind();
			dt.Clear();
			dt.Dispose();
		}
		ListItem itm = new ListItem();
		itm.Selected = true;
		itm.Value = "";
		itm.Text = "=自定义标签(最新20条)";
		LabelList.Items.Insert(0, itm);
		itm = null;
	}
}

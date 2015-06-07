using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Txteditor : Foosun.PageBasic.ManagePage
{
	public string dir = "";
	public string filename = "";
	private string str_dirMana = Foosun.Config.UIConfig.dirDumm;
	private string str_Templet = Foosun.Config.UIConfig.dirTemplet;  //获取模板路径
	private string str_FilePath = "";

	protected void Page_Load(object sender, EventArgs e) {
		dir = Request.QueryString["dir"];
		filename = Request.QueryString["filename"];
		if (!IsPostBack)                                               //判断页面是否重载
        {
			//判断用户是否登录

			if (SiteID == "0") {
				str_FilePath = Server.MapPath(str_dirMana + "\\" + str_Templet);
			}
			else {
				string _sitePath = str_dirMana + "\\" + str_Templet + "\\siteTemplets\\" + Foosun.Global.Current.SiteID;
				if (!Directory.Exists(Server.MapPath(_sitePath))) { Directory.CreateDirectory(Server.MapPath(_sitePath)); }
				str_FilePath = Server.MapPath(_sitePath);
			}

			dirPath.InnerHtml = "<span style=\"color:#999999;font-size:11.5px;\">当前路径:" + str_FilePath + dir.Replace("\\\\", "\\") + "&nbsp;&nbsp;&nbsp;&nbsp;当前文件:" + filename + "</span>";
            //copyright.InnerHtml = CopyRight;            //获取版权信息
			string filepath = str_FilePath + dir.Replace("\\\\", "\\") + "\\" + filename;
			FilePath.Text = filepath;
			ShowFileContet(filepath);
			getLabelList();
		}
	}

	/// <summary>
	/// 显示文件内容
	/// </summary>
	/// <param name="filepath">文件路径</param>
	/// <returns>显示文件内容</returns>
	protected void ShowFileContet(string filepath) {
		FileContent.Text = Common.FileAction.ShowFileContet(filepath);
	}

	protected void getLabelList() {
		Foosun.CMS.Label lb = new Foosun.CMS.Label();
		DataTable dt = lb.getLableList(Foosun.Global.Current.SiteID, 2);
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
		itm.Text = "自定义标签(最新20条)";
		LabelList.Items.Insert(0, itm);
		itm = null;
	}

	protected void Button2_Click(object sender, EventArgs e) {
		if (Page.IsValid) {
			string filepath = FilePath.Text;
			int result = 0;
			result = Common.FileAction.SaveFile(filepath, this.FileContent.Text);
			string[] strForderPath = dir.Split('\\');
			string tempSrc = string.Empty;
			foreach (string s in strForderPath) {
				if (s != "\\" && s != "") {
					tempSrc += "/" + s;
				}
			}
			strForderPath = tempSrc.Split('/');
			tempSrc = string.Empty;
			foreach (string s in strForderPath) {
				if (s != "/" && s != "") {
					tempSrc += "/" + s;
				}
			}

			tempSrc = tempSrc.Replace('/', '\\');
            string url = "TempletManageList.aspx";
            if (tempSrc != "")
            {
                url += "?Path=\\" + tempSrc;
            }
            if (result == 1)
                Common.MessageBox.ShowAndRedirect(this, "保存成功", url);
            else
                Common.MessageBox.ShowAndRedirect(this, "参数错误", url);
		}
	}
}

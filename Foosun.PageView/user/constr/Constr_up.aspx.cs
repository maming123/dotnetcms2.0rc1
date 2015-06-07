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
using Foosun.CMS;

public partial class user_Constr_up : Foosun.PageBasic.UserPage
{
	protected static string getSiteRoot = "";
	private string dimmdir = Foosun.Config.UIConfig.dirDumm;
	private string localSavedir = Foosun.Config.UIConfig.dirFile;
	public string UDir = "\\Content";
	public int _SetTime = 180;
	public string loadTime = "";
	private DateTime getDateTime = System.DateTime.Now;
	//子新闻
	protected String UnNewsJsArray = "";
	//以下为以后预留
	protected String TopLineArray = "new Array()";
	protected String unNewsid = "";
	protected String FamilyArray = "['Agency FB','Arial','仿宋_GB2312','华文中宋','华文仿宋','华文彩云','华文新魏','华文细黑','华文行楷','宋体','宋体-方正超大字符集','幼圆','新宋体','方正姚体','方正舒体','楷体_GB2312','隶书','黑体']";
	protected String FontStyleArray = "{Regular:0,Bold:1,Italic:2,Underline:4,Strikeout:8}";
	protected String fs_PicInfo = "";
	protected string siteDomain =Common.Public.readparamConfig("siteDomain");
	/// <summary>
	/// 初始化信息
	/// </summary>
	#region 初始化信息
	Constr con = new Constr();
	public string ConstrTF = "";
	protected void Page_Load(object sender, EventArgs e)
	{
		getSiteRoot = siteDomain + dimmdir;
		ClassCName.Attributes["readonly"] = "true";
		txtFile.Attributes["readonly"] = "true";
		ClassCName.Attributes["readonly"] = "true";
		Response.CacheControl = "no-cache";
		ConstrTF = con.ConstrTF();
		string _ConID = Request.QueryString["ConID"];
		if (_ConID == "" && _ConID == null) { PageError("参数错误", ""); }
		string ConID = Common.Input.Filter(_ConID.ToString());
		if (!IsPostBack)
		{
			DataTable dt = con.Sel1(ConID);
			DataRow dr = dt.Rows[0];
			int cut = dt.Rows.Count;
			if (cut == 0)
			{
				PageError("参数错误", "");
			}
			if (dr["isCheck"].ToString() == "1")
			{
				PageError("稿件已经通过审核不能在修改", "");
			}
			else
			{
				//加载频道
                Foosun.CMS.UserMisc rd = new Foosun.CMS.UserMisc();
				DataTable SiteTB = rd.getSiteList();
				if (SiteTB != null)
				{
					this.site.DataSource = SiteTB;
					this.site.DataTextField = "CName";
					this.site.DataValueField = "ChannelID";
					this.site.DataBind();
				}

				//加载稿件分类
				DataTable tb1 = con.SelConstrClass(Foosun.Global.Current.UserNum);
				this.ConstrClass.DataSource = tb1;
				this.ConstrClass.DataTextField = "cName";
				this.ConstrClass.DataValueField = "Ccid";
				this.ConstrClass.DataBind();
				string u_ClassID = dr["ClassID"].ToString();
				ConstrClass.Text = u_ClassID;
				string selcNames = con.SelcName(u_ClassID);
				for (int s = 0; s < this.ConstrClass.Items.Count - 1; s++)
				{
					if (this.ConstrClass.Items[s].Text == selcNames)
					{
						this.ConstrClass.Items[s].Selected = true;
					}
				}

				string u_SiteID = dr["SiteID"].ToString();
				for (int s = 0; s < this.site.Items.Count - 1; s++)
				{
					if (this.site.Items[s].Value == u_SiteID) { this.site.Items[s].Selected = true; }
				}

				string Sourceaa = dr["Source"].ToString();
				for (int s = 0; s < this.lxList1.Items.Count - 1; s++)
				{
					if (this.lxList1.Items[s].Text == Sourceaa) { this.lxList1.Items[s].Selected = true; }
				}
				this.photo.Text = dr["PicURL"].ToString().Replace("{@dirfile}", Foosun.Config.UIConfig.dirFile).Replace("{@userdirfile}", Foosun.Config.UIConfig.UserdirFile);
				Contentbox.Value = dr["Content"].ToString();
				this.Title.Text = dr["Title"].ToString();
				this.Author.Text = dr["Author"].ToString();
				this.Tags.Text = dr["Tags"].ToString();
				string[] Tagsp = dr["Contrflg"].ToString().Split('|');
				int tags1 = int.Parse(Tagsp[0].ToString());
				int tags2 = int.Parse(Tagsp[1].ToString());
				int tags3 = int.Parse(Tagsp[2].ToString());
				int tags4 = int.Parse(Tagsp[3].ToString());
				if (tags1 == 0) { this.inList1.Items[0].Selected = true; }
				else if (tags1 == 1) { this.inList1.Items[1].Selected = true; }
				else { this.inList1.Items[2].Selected = true; }
				if (tags2 == 1) { fbList1.Items[0].Selected = true; }
				else { fbList1.Items[1].Selected = true; }
				if (tags3 == 1) { Locking.Items[0].Selected = true; }
				else { Locking.Items[1].Selected = true; }
				if (tags4 == 1) { Recommendation.Items[0].Selected = true; }
				else { Recommendation.Items[1].Selected = true; }
				this.ClassID.Value = dr["ClassID"].ToString();
				this.txtFile.Text = dr["fileURL"].ToString().Replace("{@dirfile}", Foosun.Config.UIConfig.dirFile).Replace("{@userdirfile}", Foosun.Config.UIConfig.UserdirFile);
				if (!string.IsNullOrEmpty(this.ClassID.Value))
				{
                    Foosun.CMS.NewsClass cNews = new NewsClass();
                    DataTable dta = cNews.GetList("ClassID='"+this.ClassID.Value+"'");
					if (dta != null)
					{
						this.ClassCName.Text = dta.Rows[0][1].ToString();
					}
				}

			}
		}
	}
	#endregion
	/// <summary>
	/// 修改信息
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	#region 修改信息
	protected void Button1_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			string ConIDs = Common.Input.Filter(Request.QueryString["ConID"].ToString());
			string Contents = Common.Input.Htmls(Contentbox.Value);
			string ClassID = this.ConstrClass.SelectedValue.ToString();
			string Title = Common.Input.Htmls(Request.Form["Title"].ToString());
			string Author = Common.Input.Htmls(Request.Form["Author"].ToString());
			string SiteID = this.site.SelectedValue.ToString();
			string Source = this.lxList1.SelectedValue.ToString();
			string Contrflg = "";
			Contrflg = this.inList1.SelectedValue.ToString() + "|" + fbList1.SelectedValue.ToString() + "|" + Locking.SelectedValue.ToString() + "|" + Recommendation.SelectedValue.ToString();
			string PicURL = Common.Input.Htmls(Request.Form["photo"].ToString());
			string Tags = this.Tags.Text;
			Foosun.Model.STConstr stcn;
			stcn.Content = Contents;
			stcn.ClassID = ClassID;
			stcn.Title = Title;
			stcn.Source = Source;
			stcn.Tags = Tags;
			stcn.Contrflg = Contrflg;
			stcn.Author = Author;
			stcn.PicURL = PicURL;
			stcn.SiteID = SiteID;
			stcn.UserNum = Foosun.Global.Current.UserNum;
			stcn.fileURL = this.txtFile.Text;
			if (con.Update(stcn, ConIDs) == 0)
			{
				PageError("更新错误", "Constrlist.aspx");
			}
			else
			{
				PageRight("更新成功", "Constrlist.aspx");
			}
		}
	}
	#endregion
}
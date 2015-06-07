using System;
using System.Data;
using System.Text;
using System.Web;
using Common;
using Foosun.CMS;

public partial class SelectNewsClassAjax : Foosun.PageBasic.ManagePage {
    RootPublic pd = new RootPublic();
    Foosun.CMS.UserLogin _UL = new Foosun.CMS.UserLogin();
	protected void Page_Load(object sender, EventArgs e) {
		if (!IsPostBack) {
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Write(newsstr());
		}
	}

	string newsstr() {
		string ParentId = Request.QueryString["ParentId"];
		string multi = Request["multi"];
		if (string.IsNullOrEmpty(ParentId)) {
			ParentId = "0";
		}
		string liststr = string.Empty;
		StringBuilder htmlStr = new StringBuilder();
		IDataReader rd = pd.GetAjaxsNewsList(ParentId);
        string _AllPopClassList = _UL.GetAdminGroupClassList(); 
		while (rd.Read()) {
            if (_AllPopClassList != "isSuper" && _AllPopClassList.IndexOf(rd["ClassID"].ToString()) < 0)
            {
                continue;
            }
			if (Validate_Session()) {
				int children = Convert.ToInt32(rd["HasSub"]);
                string ControlName = Request.QueryString["controlName"];
				string formatString = "<div>";
				if (children > 0) {
					formatString += "<img src=\"../../sysImages/normal/b.gif\" alt=\"点击展开子栏目\" border=\"0\" class=\"LableItem\" onclick=\"SwitchImg(this,'{0}');\" />";
				}
				else {
					formatString += "<img src=\"../../sysImages/normal/s.gif\" alt=\"没有子栏目\" border=\"0\" class=\"LableItem\" />";
				}

				if (!string.IsNullOrEmpty(multi) && multi == "true") {
					formatString += "<input name=\"cbClassId\" type=\"checkbox\" value=\"{0}\" />";
				}
                this.ClassID = rd["ClassID"].ToString();
                if (_AllPopClassList == "isSuper" || this.CheckAuthority())
                {
                    if (children > 0)
                    {
                        formatString += "<span id=\"{0}\" class=\"LableItem\" ondblclick=\"ReturnValue('" + ControlName + "');\" onclick=\"SelectLable('{0}','{1}');\">{1}</span><div id=\"Parent{0}\" class=\"SubItem\" HasSub=\"True\" style=\"display:none;\"></div></div>";
                    }
                    else
                    {
                        formatString += "<span id=\"{0}\" class=\"LableItem\" ondblclick=\"ReturnValue('" + ControlName + "');\" onclick=\"SelectLable('{0}','{1}');\">{1}</span></div>";
                    }
                }
                else
                {
                    if (children > 0)
                    {
                        formatString += "<span id=\"{0}\" class=\"LableItem\">{1}</span><div id=\"Parent{0}\" class=\"SubItem\" HasSub=\"True\" style=\"display:none;\"></div></div>";
                    }
                    else
                    {
                        formatString += "<span id=\"{0}\" class=\"LableItem\">{1}</span></div>";
                    }
                }

				htmlStr.Append(string.Format(formatString, rd["ClassID"], rd["ClassCName"]));
			}
		}
		rd.Close();
		if (htmlStr.Length > 0) {
			htmlStr.Insert(0, "Succee|||" + ParentId + "|||");
		}
		else {
			htmlStr.Append("Fail|||" + ParentId + "|||");
		}
		return htmlStr.ToString();
	}
}

using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage
{
    public partial class Left : Foosun.PageBasic.ManagePage
    {
        Foosun.CMS.UserMisc rd = new Foosun.CMS.UserMisc();
        Foosun.CMS.NewsClass cClass = new CMS.NewsClass();
        Foosun.CMS.News NewsCMS = new CMS.News();
        Foosun.CMS.UserLogin _UL = new Foosun.CMS.UserLogin();
        public static string _AllPopClassList;
        public DataTable dtcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ClassID"] != null && Request.QueryString["ClassID"].ToString() != "")
                {
                    string ClassID = Request.QueryString["ClassID"].ToString();
                    //判断ClassID位数是否正确
                    if (ClassID.Length == 12)
                    {
                        GetMenus(ClassID);

                    }
                    else
                    {

                    }
                }
            }
        }

        protected void GetMenus(string parentId)
        {
            CMS.Navi navi = new CMS.Navi();
            CMS.sys param = new CMS.sys();
            DataTable dt = navi.GetList("[am_ClassID]='" + parentId + "'");
            string publishType = param.GetParamBase("publishType");
            string content = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable dtMenus = new DataTable();
                if (publishType == "0")
                {
                    dtMenus = navi.GetList(" [am_ClassID] in ('" + dt.Rows[0]["am_ChildrenID"].ToString().Replace(",", "','") + "') and am_ClassID<>'769542672350'");
                }
                else
                {
                    dtMenus = navi.GetList(" [am_ClassID] in ('" + dt.Rows[0]["am_ChildrenID"].ToString().Replace(",", "','") + "') and (am_ClassID<>'773524937370' and am_ClassID<>'295612982016' and am_ClassID<>'000000000017' and am_ClassID<>'000000000021' and am_ClassID<>'000000000022')");
                }

                if (dtMenus != null && dtMenus.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtMenus.Rows)
                    {
                        if (dr["am_ClassID"].ToString() == "000000000008")
                        {
                            content += "<div class=\"left_menu_1\"><a hidefocus=true href=\"javascript:Newsclick()\"><span>" + dr["am_Name"] + "</span></a></div><div id=\"NewsNav\" class=\"NewsNav\">" + getlist() + "</div>";
                        }
                        else
                        {
                            content += "<div class=\"left_menu_1\"><a hidefocus=true href=\"" + dr["am_FilePath"] + "\" target='sys_main'><span>" + dr["am_Name"] + "</span></a></div>";
                        }
                    }
                }
            }
            navcontent.InnerHtml = content;
        }
        string getlist()
        {
            _AllPopClassList = _UL.GetAdminGroupClassList();
            dtcount = cClass.GetNewsCount();
            string content = "<ul id=\"tree\">";
            DataTable site = rd.getSiteList();
            if (site.Rows.Count > 0)
            {
                foreach (DataRow item in site.Rows)
                {
                    content += "<li  class=\"open\"><img src=\"/CSS/" + Foosun.Config.UIConfig.CssPath() + "/imges/lie_26.gif\" border=\"0\" /><a target=\"sys_main\" href=\"news/NewsList.aspx\">" + item["CName"].ToString() + "</a><a href=\"javascript:location.reload()\">(刷新)</a>";
                    content += list(item["ChannelID"].ToString(), "0"); ;
                    content += "</li>";
                }
            }
            content += "</ul>";
            return content;
        }
        string list(string siteid, string classid)
        {
            string content = "";
            DataTable dt = cClass.GetContent("ClassID,ClassCName", "isPage=0 and ParentID='" + classid + "' and SiteID='" + siteid + "'", " OrderID desc,id desc ");
            if (dt.Rows.Count > 0)
            {
                content = "<ul>";
                foreach (DataRow item in dt.Rows)
                {
                    if (_AllPopClassList != "isSuper" && _AllPopClassList.IndexOf(item["ClassID"].ToString()) < 0)
                    {
                        continue;
                    }
                    this.ClassID = item["ClassID"].ToString();
                    string count = dtcount.Select("ClassID='" + item["ClassID"].ToString() + "'").Length == 0 ? "0" : dtcount.Select("ClassID='" + item["ClassID"].ToString() + "'")[0][0].ToString();
                    if (_AllPopClassList == "isSuper" || this.CheckAuthority())
                    {
                        content += "<li><img src=\"/CSS/" + Foosun.Config.UIConfig.CssPath() + "/imges/lie_26.gif\" border=\"0\" /><a target=\"sys_main\" href=\"news/NewsList.aspx?ClassID=" + item["ClassID"].ToString() + "\">" + item["ClassCName"].ToString() + "(<span style=\"color:red\">" + count + "</span>)</a><a target=\"sys_main\" href=\"news/newsAdd.aspx?ClassID=" + item["ClassID"].ToString() + "&EditAction=Add\" title=\"添加此栏目下的内容\"><img src=\"imges/lie_78.gif\" border=\"0\" /></a>";
                        content += list(siteid, item["ClassID"].ToString());
                        content += "</li>";
                    }
                    else
                    {
                        content += "<li><img src=\"/CSS/" + Foosun.Config.UIConfig.CssPath() + "/imges/lie_26.gif\" border=\"0\" />" + item["ClassCName"].ToString() + "(<span style=\"color:red\">" + count + "</span>)";
                        content += list(siteid, item["ClassID"].ToString());
                        content += "</li>";
                    }
                }
                content += "</ul>";
            }
            return content;
        }
    }
}
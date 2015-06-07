using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage
{
    public partial class main1 : Foosun.PageBasic.ManagePage
    {
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CMS.Navi navi = new CMS.Navi();
                dt = navi.GetList("");
            }
        }

        protected string GetMenus(string parentId)
        { 
            string content = "";

            CMS.sys param = new CMS.sys();
            string publishType = param.GetParamBase("publishType");

            DataRow[] row = dt.Select("am_ClassID='" + parentId + "'");
            if (row[0]["am_ChildrenID"].ToString() != "")
            {
                string childId = row[0]["am_ChildrenID"].ToString();

                if (publishType == "0")
                {
                    childId = childId.Replace("769542672350", "");
                }
                else
                {
                    childId = childId.Replace("773524937370", "").Replace("295612982016", "").Replace("000000000017", "").Replace("000000000021", "").Replace("000000000022", "");
                }

                string[] classID = childId.Split(',');
                foreach (var item in classID)
                {
                    if (item != "")
                    {
                        DataRow[] dtMenus = dt.Select("am_ClassID='" + item + "'");
                        if (dtMenus != null && dtMenus.Length > 0)
                        {
                            string img = "/CSS/imges/m2.png";
                            string width = dtMenus[0]["imgwidth"].ToString();
                            if (width != "120")
                            {
                                img = "/CSS/imges/m1.png";
                                width = "250";
                            }
                            if (dtMenus[0]["imgPath"] != null && dtMenus[0]["imgPath"].ToString() != "")
                            {
                                img = dtMenus[0]["imgPath"].ToString();
                            }
                            content += "<li onclick=\"seturl('" + dtMenus[0]["am_FilePath"].ToString() + "','Left.aspx?ClassID=" + parentId + "')\" style=\"background:url(" + img + ") no-repeat; width:" + width + "px\">";
                            content += "<span class=\"span\">" + dtMenus[0]["am_Name"].ToString() + "</span>";
                            content += "</li>";
                        }
                    }
                }
            }
            content += " <li><a href=\"Addmeun.aspx?ClassID=" + parentId + "\"><img src='/CSS/imges/27.png'  width='120' height='116'/></a></li>";
            return content;
        }
    }
}
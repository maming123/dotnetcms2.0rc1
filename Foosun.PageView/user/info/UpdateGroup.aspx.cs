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
using Common;

public partial class user_info_UpdateGroup : Foosun.PageBasic.UserPage
{
    UserMisc rd = new UserMisc();
    RootPublic pd = new RootPublic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            string UserGroupNumber = Request.QueryString["UserGroupNumber"];
            if (UserGroupNumber != null && UserGroupNumber != "")
            {
                GroupName.InnerHtml = pd.GetGroupName(UserGroupNumber.ToString());
            }
            else
            {
                PageError("错误的编号", "");
            }
            copyright.InnerHtml = CopyRight;
            groupList.InnerHtml = GetGroupList();
        }
    }

    protected string GetGroupList()
    {
        string _Str = "<select name=\"GroupNumber\">";
        IDataReader dr = pd.GetGroupList();
        while (dr.Read())
        {
            _Str += "<option value=\"" + dr["GroupNumber"] + "\">" + dr["GroupName"] + "</option>\r";
        }
        dr.Close();
        _Str += "</select>";
        return _Str;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}

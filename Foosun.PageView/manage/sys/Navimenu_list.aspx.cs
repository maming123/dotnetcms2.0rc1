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

public partial class Navimenu_list : Foosun.PageBasic.ManagePage
{
    public Navimenu_list()
    {
        Authority_Code = "Q025";
    }
    UserMisc rd = new UserMisc();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            
           // copyright.InnerHtml = CopyRight;
        }
        navimenu_list.InnerHtml = navimenusub();
        string action = Request.QueryString["action"];
        if (action == "del")
        {
            this.Authority_Code = "Q026";
            this.CheckAdminAuthority();
            int qID = int.Parse(Request.QueryString["ID"]);
            string qClassID = Request.QueryString["ClassID"];
            Shortcutdel(qID, qClassID);
        }
    }

    protected void Shortcutdel(int qID, string ClassID)
    {
        if (ClassID.Trim() == "")
        {
            Common.MessageBox.Show(this, "错误的参数(参数传递错误)!");
        }
        else
        {
            rd.Shortcutdel(qID);
            //rd.Shortcutde2(ClassID);
            Common.MessageBox.ShowAndRedirect(this, "删除成功!", "Navimenu_list.aspx");
        }
    }
    string navimenusub()//显示快捷菜单
    {
        //显示列表开始
        string type = Request.QueryString["type"];
        string sqlStr = "";
        switch (type)
        {
            case "sys":
                sqlStr = " and issys=1";
                break;
            case "unsys":
                sqlStr = " and isSys=0";
                break;
            default:
                sqlStr = "";
                break;
        }
        string liststr = "<table class=\"jstable\">";
        liststr = liststr + "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">\r";
        liststr = liststr + "<th width='100' align='center'>名称</th>\r";
        liststr = liststr + "<th width='60' align='center'>位置</th>\r";
        liststr = liststr + "<th align='center'>连接地址</th>\r";
        liststr = liststr + "<th  width=\"60\" align='center'>系统菜单</th>\r";
        liststr = liststr + "<th align='center'>频道</th>\r";
        liststr = liststr + "<th align='center'>操作</th>\r";
        liststr = liststr + "</tr>";
        DataTable dt = rd.navimenusub(sqlStr);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string am_Name = dt.Rows[i]["am_Name"].ToString();
            string positionstr = "普通菜单";
            string am_FilePath = dt.Rows[i]["am_FilePath"].ToString();
            string am_ClassID = dt.Rows[i]["am_ClassID"].ToString();
            string isSys = dt.Rows[i]["isSys"].ToString();
            string strisSys = "后台";
            if (isSys == "0")
            {
                strisSys = "用户";
            }
            else
            {
                strisSys = "系统";
            }
            string siteID = dt.Rows[i]["siteID"].ToString();
            if (siteID == "0")
            {
                siteID = "主站";
            }
            string id = dt.Rows[i]["am_id"].ToString();
            
            liststr = liststr + "<tr  class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">\r";
            liststr = liststr + "<td align=\"center\">" + am_Name + "</td>\r";
            liststr = liststr + "<td align=\"center\">" + positionstr + "</td>\r";
            liststr = liststr + "<td align=\"center\"><div style=\"font-size:11px\">" + am_FilePath + "</div></td>\r";
            liststr = liststr + "<td align=\"center\">" + strisSys + "</td>\r";
            liststr = liststr + "<td align=\"center\">" + siteID + "</td>\r";
            if (isSys == "0")
            {
                liststr = liststr + "<td align=\"center\"><a class=\"xa3\" href=\"navimenuEdit.aspx?id=" + id + "\">修改</a>&nbsp;┊&nbsp;<a class=\"xa3\" href=\"Navimenu_list.aspx?action=del&id=" + id + "&ClassID=" + am_ClassID + "\" onclick=\"{if(confirm('确认删除吗？')){return true;}return false;}\">删除</a></td>\r";
            }
            else
            {
                liststr = liststr + "<td align=\"center\"><a class=\"xa3\" href=\"navimenuEdit.aspx?id=" + id + "\">修改</a>&nbsp;┊&nbsp;<font color=\"999999\">删除</font><span class=\"helpstyle\" onClick=\"Help('H_navimenulist_0001',this)\">帮助</span></td>\r";
            }
                liststr = liststr + "</tr>";
        }
        liststr = liststr + "</table>";
        return liststr;
        //显示列表结束
    }
}

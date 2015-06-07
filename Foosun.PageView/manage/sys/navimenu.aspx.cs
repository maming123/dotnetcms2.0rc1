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

public partial class navimenu : Foosun.PageBasic.ManagePage
{
    public navimenu()
    {
        Authority_Code = "Q025";
    }
    UserMisc rd = new UserMisc();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!IsPostBack)
        {
            
            //copyright.InnerHtml = CopyRight;
        }
    }

    string childparentidlist(string pID,string nchar)
    {
        DataTable dt = rd.ManagechildmenuNavilist(pID);
        string TempStr = nchar + "┉";
        string liststr = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string Am_position = dt.Rows[i]["Am_position"].ToString();
            string am_Name = dt.Rows[i]["am_Name"].ToString();
            string am_ParentID = dt.Rows[i]["am_ParentID"].ToString();
            string am_ClassID = dt.Rows[i]["am_ClassID"].ToString();
            liststr = liststr + "<option value=\"" + am_ClassID + "\">" + TempStr + am_Name + "</option>\r";
            if (am_ClassID != "0")
            {
                liststr = liststr + childparentidlist(am_ClassID, TempStr);
            }
        }
        return liststr;
    }

    protected void Navisubmit(object sender, EventArgs e)
    {
        if (Page.IsValid == true)                       //判断是否验证成功
        {
            //------------------获取表单值-----------------------------------------
            string am_Name = Request.Form["menuName"];
            string am_FilePath = Request.Form["FilePath"];
            int am_orderID = int.Parse(Request.Form["orderID"]);
            string isSys = Request.Form["isSys"]+"foosun";
            string popCode = this.popCode.Text;
            int am_isSys=0;
            if (isSys=="foosun") 
            { 
                am_isSys = 0; 
            } 
            else 
            {
                am_isSys = 1; 
            }

            //连接数据库
            string am_ClassID = Common.Rand.Number(12);//产生12位随机字符
            DataTable dt = rd.getManageChildNaviRecord(am_ClassID);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Common.MessageBox.Show(this, "意外错误：有可能是系统编号重复，请重新添加");
                }
                else
                {
                    if (!Common.Input.IsInteger(imgheight.Text))
                    {
                        Common.MessageBox.Show(this, "图片高度只能是整数!");
                        return;
                    }
                    if (!Common.Input.IsInteger(imgwidth.Text))
                    {
                        Common.MessageBox.Show(this, "图片宽度只能是整数!");
                        return;
                    }
                    Foosun.Model.UserInfo7 uc = new Foosun.Model.UserInfo7();
                    uc.am_ClassID = am_ClassID;
                    uc.am_Name = am_Name;
                    uc.am_FilePath = am_FilePath;
                    uc.am_creatTime = System.DateTime.Now;
                    uc.am_orderID = am_orderID;
                    uc.popCode = popCode;
                    uc.isSys = am_isSys;
                    uc.siteID = SiteID;
                    uc.userNum = UserNum;
                    uc.imgPath = imgPath.Text;
                    uc.imgheight = imgheight.Text;
                    uc.imgwidth = imgwidth.Text;
                    uc.am_ChildrenID = "0";
                    rd.InsertManageMenu(uc);
                    Common.MessageBox.ShowAndRedirect(this, "添加菜单成功。", "navimenu_list.aspx");
                }
            }
        }
    }
}
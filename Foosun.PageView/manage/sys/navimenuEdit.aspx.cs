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

public partial class navimenuEdit : Foosun.PageBasic.ManagePage
{
    public navimenuEdit()
    {
        Authority_Code = "Q026";
    }
    UserMisc rd = new UserMisc();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            
            //copyright.InnerHtml = CopyRight;
            int id = int.Parse(Request.QueryString["id"]);
            DataTable dt = rd.GetNaviEditID(id);
            menuName.Text = dt.Rows[0]["am_Name"].ToString();
            
            if(dt.Rows[0]["isSys"].ToString()=="1")
            {
                isSys.Checked=true;
                FilePath.Text = dt.Rows[0]["am_FilePath"].ToString();
                FilePath.Enabled = false;
                isSys.Enabled = false;
                imgheight.Enabled = false;
                imgwidth.Enabled = false;
                imgPath.Enabled = false;
            }
            else
            {
                isSys.Checked=false;
                FilePath.Text = dt.Rows[0]["am_FilePath"].ToString();
            }
            orderID.Text = dt.Rows[0]["am_orderID"].ToString();
            am_id.Value = Request.QueryString["id"];
            Hiddenissys.Value = dt.Rows[0]["isSys"].ToString();
            imgheight.Text = dt.Rows[0]["imgheight"].ToString();
            imgwidth.Text = dt.Rows[0]["imgwidth"].ToString();
            imgPath.Text = dt.Rows[0]["imgPath"].ToString();
        }
    }

    /// <summary>
    /// 得到子类
    /// </summary>
    /// <param name="pID"></param>
    /// <param name="nchar"></param>
    /// <param name="sparentid"></param>
    /// <param name="isablue"></param>
    /// <returns></returns>
    protected string childparentidlist(string pID, string nchar, string sparentid, string isablue)
    {
        DataTable dt = rd.Getchildparentidlist(pID);
        string TempStr = nchar + "┉";
        string liststr = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string Am_position = dt.Rows[i]["Am_position"].ToString();
            string am_id = dt.Rows[i]["am_id"].ToString();
            string am_Name = dt.Rows[i]["am_Name"].ToString();
            string am_ParentID = dt.Rows[i]["am_ParentID"].ToString();
            string am_ClassID = dt.Rows[i]["am_ClassID"].ToString();
            if (sparentid == am_ClassID)
            {
                liststr = liststr + "<option value=\"" + am_ClassID + "\" selected>" + TempStr + am_Name + "</option>\r";
            }
            else
            {
                liststr = liststr + "<option value=\"" + am_ClassID + "\">" + TempStr + am_Name + "</option>\r";
            }
            if (am_ClassID != "0")
            {
                liststr = liststr + childparentidlist(am_ClassID, TempStr, sparentid, isablue);
            }
        }
        return liststr;
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void naviedit(object sender, EventArgs e)
    {
        if (Page.IsValid)                       //判断是否验证成功
        {
            string issys = this.Hiddenissys.Value;
            string am_Name = this.menuName.Text;;
            int orderID = int.Parse(this.orderID.Text);
            int am_id = int.Parse(this.am_id.Value);
            string popCode = this.popCode.Text;
            if (issys.ToString() == "1")
            {
                Foosun.Model.UserInfo7 uc = new Foosun.Model.UserInfo7();
                uc.am_Name = am_Name;
                uc.am_orderID = orderID;
                uc.am_ID = am_id;
                uc.popCode = popCode;
                rd.EditManageMenu1(uc);
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
                string Am_position = Request.Form["position"];
                string am_FilePath = Request.Form["FilePath"];
                string am_target = Request.Form["f_target"];
                string am_ParentID = Request.Form["parentID"];
                Foosun.Model.UserInfo7 uc = new Foosun.Model.UserInfo7();
                uc.am_Name = am_Name;
                uc.am_FilePath = am_FilePath;
                uc.popCode = popCode;
                uc.am_orderID = orderID;
                uc.imgPath = imgPath.Text;
                uc.imgheight = imgheight.Text;
                uc.imgwidth = imgwidth.Text;
                uc.userNum = Foosun.Global.Current.UserNum;
                uc.siteID = SiteID;
                uc.am_creatTime = DateTime.Now;
                if(this.isSys.Checked)
                {
                    uc.isSys = 1;
                }
                else
                {
                    uc.isSys = 0;
                }
                uc.am_ID = am_id;
                rd.EditManageMenu(uc);
            }
            Common.MessageBox.ShowAndRedirect(this, "修改菜单成功。", "navimenu_list.aspx");
        }
    }
}

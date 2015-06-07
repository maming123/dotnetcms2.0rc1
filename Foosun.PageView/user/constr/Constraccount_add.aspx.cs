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

public partial class user_Constraccount_add : Foosun.PageBasic.UserPage
{
    Constr con = new Constr();

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    #region 初始化
    protected void Page_Load(object sender, EventArgs e)
    {
          //判断是否登录
        Response.CacheControl = "no-cache";  //清除缓存
        string UserNum = Foosun.Global.Current.UserNum;
        int cut = con.Sel3(UserNum);
        if (cut > 0)
        {
            PageError("对不起不能在设置了一个账号只能设置一个", "Constraccount.aspx");
        }
    }
    #endregion
    //设置账号
    /// <summary>
    /// 设置账号
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    #region 设置账号
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string address = Common.Input.Htmls(Request.Form["addressBox"].ToString());
            string postcode = Common.Input.Htmls(Request.Form["postcodeBox"].ToString());
            string RealName = Common.Input.Htmls(Request.Form["RealNameBox"].ToString());
            string bankName = Common.Input.Htmls(Request.Form["bankNameBox"].ToString());
            string bankaccount = Common.Input.Htmls(Request.Form["bankaccountBox"].ToString());
            string bankcard = Common.Input.Htmls(Request.Form["bankcardBox"].ToString());
            string bankRealName = Common.Input.Htmls(Request.Form["bankRealNameBox"].ToString());
            string UserNum = Foosun.Global.Current.UserNum;
            Foosun.Model.STuserother stcn;
            stcn.address = address;
            stcn.postcode = postcode;
            stcn.RealName = RealName;
            stcn.bankName = bankName;
            stcn.bankaccount = bankaccount;
            stcn.bankcard = bankcard;
            stcn.bankRealName = bankRealName;
            if (con.Add1(stcn, UserNum) == 0)
            {
                PageError("添加失败<br>", "Constraccount.aspx");
            }
            else
            {
                PageRight("添加成功", "Constraccount.aspx");
            }
        }
    }
    #endregion
}



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

public partial class user_discussacti_up : Foosun.PageBasic.UserPage
{
    //连接数据库
    Discuss dis = new Discuss();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            string AId = "";
            if (Request.QueryString["AId"] != "" && Request.QueryString["AId"] != null)
            {
                AId = Common.Input.Filter(Request.QueryString["AId"].ToString());
            }
            else 
            {
                PageError("对不起数据错误", "discussacti_list.aspx");
            }
            DataTable dt = dis.sel_17(AId);
            this.ActivesubjectBox.Text = dt.Rows[0]["Activesubject"].ToString();
            this.ActivePlaceBox.Text = dt.Rows[0]["ActivePlace"].ToString();
            this.CutofftimeBox.Text = DateTime.Parse(dt.Rows[0]["Cutofftime"].ToString()).ToShortDateString();
            this.AnumBox.Text = dt.Rows[0]["Anum"].ToString();
            this.ActiveExpenseBox.Text = dt.Rows[0]["ActiveExpense"].ToString();
            this.ContactmethodBox.Text = dt.Rows[0]["Contactmethod"].ToString();
            this.ActivePlanBox.Text = dt.Rows[0]["ActivePlan"].ToString();
            
            if (dt.Rows[0]["ALabel"].ToString() != "")
            {
                int ALabelsa = Convert.ToInt32(dt.Rows[0]["ALabel"].ToString());//会员性别
                switch (ALabelsa)
                {
                    case 0:
                        this.ALabelList.Items[0].Selected = true;
                        break;
                    case 1:
                        this.ALabelList.Items[1].Selected = true;
                        break;
                }
            }
        }
    }

    protected void inBox_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)//判断是否通过验证
        {
            string AIds = Common.Input.Filter(Request.QueryString["AId"].ToString());
            string Activesubject = Common.Input.Filter(Request.Form["ActivesubjectBox"].ToString());
            string ActivePlace = Common.Input.Filter(Request.Form["ActivePlaceBox"].ToString());
            int Anum = int.Parse(Common.Input.Filter(Request.Form["AnumBox"].ToString()));
            string ActivePlan = Common.Input.Filter(Request.Form["ActivePlanBox"].ToString());
            string Contactmethod = Common.Input.Filter(Request.Form["ContactmethodBox"].ToString());
            DateTime Cutofftime = DateTime.Parse(Common.Input.Filter(Request.Form["CutofftimeBox"].ToString()));
            string ActiveExpense = Common.Input.Filter(Request.Form["ActiveExpenseBox"].ToString());
            int ALabel = this.ALabelList.SelectedIndex;
            DateTime CreaTime = DateTime.Now;//获取当前系统时间
            if (dis.Update_2(Activesubject, ActivePlace, ActiveExpense, Anum, ActivePlan, Contactmethod, Cutofftime, CreaTime, ALabel, AIds) != 0)
            {
                PageRight("修改成功", "discussacti_list.aspx");
            }
            else
            {
                PageError("修改失败", "discussacti_list.aspx");
            }
        }
    }
}
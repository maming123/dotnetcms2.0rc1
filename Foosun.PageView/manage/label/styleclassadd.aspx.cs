using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.label
{
    public partial class styleclassadd : Foosun.PageBasic.ManagePage
    {
        public styleclassadd()
        {
            Authority_Code = "T019";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";  
            if (!IsPostBack)
            {
                if (Request.QueryString["ClassID"]!=null)
                {
                    getClassInfo();  
                }
             
            }
        }
        protected void getClassInfo()
        {
            string str_ClassID = Common.Input.checkID(Request.QueryString["ClassID"]);
            ClassID.Value = str_ClassID;
            string str_ClassName = "";

            Foosun.CMS.Style.Style stClass = new Foosun.CMS.Style.Style();
            DataTable dt = stClass.GetstyleClassInfo(str_ClassID);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                    str_ClassName = dt.Rows[0][0].ToString();
                else
                    PageError("参数错误!", "");
                dt.Clear();
                dt.Dispose();
            }
            styleClassName.Text = str_ClassName;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int result = 0;
                Foosun.Model.StyleClassInfo stClass = new Foosun.Model.StyleClassInfo();
                stClass.Sname = styleClassName.Text;
                stClass.CreatTime = DateTime.Now;
                stClass.isRecyle = 0;
                Foosun.CMS.Style.Style stcClass = new Foosun.CMS.Style.Style();
                if (ClassID.Value != "")
                {
                    stClass.ClassID = ClassID.Value;
                    try
                    {
                        result = stcClass.StyleClassEdit(stClass);
                    }
                    catch (Exception ex)
                    {

                        PageError(ex.Message, "styleclassadd.aspx");
                    }
                }
                else
                {
                    try
                    {
                        result = stcClass.SytleClassAdd(stClass);
                    }
                    catch (Exception ex)
                    {

                        PageError(ex.Message, "styleclassadd.aspx");
                    }
                }

                if (result == 1)
                    PageRight("添加分类成功!", "style.aspx");
                else
                    PageError("添加分类失败!", "");
            }
        }
    }
}
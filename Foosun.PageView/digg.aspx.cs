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

public partial class digg : Foosun.PageBasic.BasePage
{
    News RD = new News();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        string str_newsID = Request.QueryString["newsid"];
        string str_getNum = Request.QueryString["getNum"];
        string str_getundig = Request.QueryString["getundig"];
        if (str_newsID != null && str_newsID != string.Empty&&str_getNum!=null&&str_getNum!=string.Empty)
        {
            if (str_getNum.ToString() == "0")
            {
                Response.Write(RD.GetTopNum(Common.Input.Filter(str_newsID.ToString()), "0"));
            }
            else
            {
                if (Request.Cookies["FoosunCookeisdigg" + str_newsID + ""] == null)
                {
                    Response.Cookies["FoosunCookeisdigg" + str_newsID + ""].Value = "1";
                    Response.Write(RD.GetTopNum(Common.Input.Filter(str_newsID.ToString()), "1"));
                }
                else
                {
                    Response.Write(RD.GetTopNum(Common.Input.Filter(str_newsID.ToString()), "0"));
                }
            }
            Response.End();
        }
        else if (str_newsID != null && str_newsID != string.Empty && str_getundig != null && str_getundig != string.Empty)
        {

            if (str_getundig.ToString() == "0")
            {
                Response.Write(RD.GetUndigs(Common.Input.Filter(str_newsID.ToString()), "0"));
            }
            else
            {
                if (Request.Cookies["FoosunCookeisundigg" + str_newsID + ""] == null)
                {
                    Response.Cookies["FoosunCookeisundigg" + str_newsID + ""].Value = "1";
                    Response.Write(RD.GetUndigs(Common.Input.Filter(str_newsID.ToString()), "1"));
                }
                else
                {
                    Response.Write(RD.GetUndigs(Common.Input.Filter(str_newsID.ToString()), "0"));
                }
            }
            Response.End();
            
        }

        else
        {
            Response.Write("0");
            Response.End();
        }
    }
}

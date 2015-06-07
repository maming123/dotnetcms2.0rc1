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
using System.Text.RegularExpressions;
using Foosun.Model;

namespace Foosun.PageView
{
    public partial class TopNews : Foosun.PageBasic.BasePage
    {
        protected string newLine = "\r\n";
        protected string str_dirMana = Foosun.Config.UIConfig.dirDumm;
        protected string str_Templet = Foosun.Config.UIConfig.dirTemplet;  //获取模板路径

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            string str_masscontent = Request.QueryString["masscontent"].ToString();
            str_masscontent = str_masscontent.Replace("FS:LabelType=TopNews", "FS:LabelType=TopNews1");
            string str_currentclassid = Request.QueryString["currentclassid"].ToString();
            string str_currentspecialid = Request.QueryString["currentspecialid"].ToString();
            string str_currentnewsid = Request.QueryString["currentnewsid"].ToString();
            int str_ChID = int.Parse(Request.QueryString["ChID"].ToString());
            int str_currentchclassid = int.Parse(Request.QueryString["currentchclassid"].ToString());
            int str_currentchspecialid = int.Parse(Request.QueryString["currentchspecialid"].ToString());
            int str_currentchnewsid = int.Parse(Request.QueryString["currentchnewsid"].ToString());
            string str_templatetype = Request.QueryString["TemplateType"].ToString();

            Foosun.Publish.LabelMass labelmass = new Foosun.Publish.LabelMass(str_masscontent, str_currentclassid, str_currentspecialid, str_currentnewsid, str_ChID, str_currentchclassid, str_currentchspecialid, str_currentchnewsid);
            labelmass.TemplateType = (Foosun.Publish.TempType)(int.Parse(str_templatetype));
            labelmass.ParseContent();
            string str_newslist = labelmass.Parse();  
            Response.Write("Suc$$$" + str_newslist);
            Response.End();
        }
    }
}

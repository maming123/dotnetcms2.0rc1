using System;
using System.Web;
public partial class survey_VoteJs : Foosun.PageBasic.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Container = Request["ajaxid"];
        int Steps = 0, PicWidth = 60;
        string Tid = "0";
        if (Request["TID"] == null)
        {
            Response.Write("document.write('投票编号不能为空');");
            Response.End();
        }
        else
        {
            Tid = Request["TID"];
        }
        if (Request["Steps"] != null)
            Steps = int.Parse(Request["Steps"]);
        if (Request["PicW"] != null)
            PicWidth = int.Parse(Request["PicW"]);
        if (Request["OutHtmlID"] != null && !Request["OutHtmlID"].Trim().Equals(""))
            Container = Request["OutHtmlID"];
        Container = HttpUtility.HtmlEncode(Container);
        string script = "";
        script += "jQuery(document).ready(function () { \r\n";
        script += "    jQuery.get('/survey/Vote_Show.aspx?TID=" + Tid + "&OutHtmlID=" + Container + "&PicW=" + PicWidth + "&Steps=" + Steps + "', function (transport) {\r\n";
        script += "        jQuery('#" + Container + "').html(transport);\r\n";
        script += "     });\r\n";
        script += "});\r\n";
        Response.Write(script);
        Response.End();
    }
}

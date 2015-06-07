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

public partial class manage_collect_Default : Foosun.PageBasic.ManagePage
{
    public manage_collect_Default()
    {
        Authority_Code = "S008";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string AppPath = "";
         string UrlAuthority  = Request.Url.GetLeftPart(UriPartial.Authority);
        if(HttpContext.Current.Request.ApplicationPath == "/")  
          //直接安装在   Web   站点   
            AppPath = UrlAuthority;
        else  
          //安装在虚拟子目录下   
            AppPath = UrlAuthority + HttpContext.Current.Request.ApplicationPath;

        Response.Write(AppPath);
    }
}

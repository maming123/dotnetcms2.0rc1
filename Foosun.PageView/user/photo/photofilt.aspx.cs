//=====================================================================
//==                  (c)2011 Foosun Inc.By doNetCMS1.0              ==
//==                     Forum:bbs.foosun.net                        ==
//==                     WebSite:www.foosun.net                      ==
//=====================================================================
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

public partial class user_photofilt : Foosun.PageBasic.UserPage
{
    Photo pho = new Photo();
    protected string sImgUrl = "";
    protected int photocount = 0;
    protected string photostr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        
        getPhoto();

    }
    protected void getPhoto()
    {
        string PhotoalbumID = Common.Input.Filter(Request.QueryString["PhotoalbumID"]);
        string pwd = pho.sel_1(PhotoalbumID);
        string UserNum = pho.sel_20(PhotoalbumID);
        if (pwd != "" && pwd != null && UserNum != Foosun.Global.Current.UserNum)
        {
            Response.Redirect("Photoalbumlist.aspx");
        }
        else
        {
            DataTable dt = pho.sel_18(PhotoalbumID);
            photocount = dt.Rows.Count;
            if (dt != null)
            {
                string dirDumm = Foosun.Config.UIConfig.dirDumm;
                if (dirDumm.Trim() != "")
                    dirDumm = "/" + dirDumm;

                photostr += "ImgName = new ImgArray(" + photocount + ");\n";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    photostr += "ImgName[" + i + "] =\"" + dt.Rows[i][0].ToString().Replace("{@userdirfile}", dirDumm + Foosun.Config.UIConfig.UserdirFile) + "\";\n";
                }

                //foreach (DataRow r in dt.Rows)
                //{
                //    if (!r.IsNull(0))
                //    {
                //        if (n > 0)
                //            sImgUrl += "\t";
                //        sImgUrl += r[0].ToString().Replace("{@UserdirFile}", dirDumm + Foosun.Config.UIConfig.UserdirFile);
                //        n++;

                //    }
                //}
                dt.Dispose();
            }
            DataBind();
        }
    }
}
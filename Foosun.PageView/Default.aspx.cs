using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Foosun.CMS;
using System.Text.RegularExpressions;

namespace Foosun.PageView
{
    public partial class _Default : Foosun.PageBasic.BasePage
    {
        protected string SiteRootPath = Common.ServerInfo.GetRootPath();
        protected string dimm = Foosun.Config.UIConfig.dirDumm;
        protected string TempletDir = Foosun.Config.UIConfig.dirTemplet;
        public static string gInstallDir = "{$InstallDir}";
        public static string gTempletDir = "{$TempletDir}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string gChID = Request.QueryString["ChID"];
            int ChID = 0;
            if (gChID != null && gChID != string.Empty)
            {
                if (Common.Input.IsInteger(gChID.ToString()))
                {
                    ChID = int.Parse(gChID.ToString());
                }
            }
            Foosun.Publish.CommonData.Initialize();
            string indexname = "index.html";
            string TempletPath = Common.Public.readparamConfig("IndexTemplet");
            if (ChID != 0)
            {
                TempletPath = "/" + Foosun.Config.UIConfig.dirTemplet + "/" + Common.Public.readCHparamConfig("channeltemplet", ChID);
            }
            TempletPath = TempletPath.Replace("/", "\\");
            TempletPath = TempletPath.ToLower().Replace("{@dirtemplet}", TempletDir);
            indexname = Common.Public.readparamConfig("IndexFileName");
            Foosun.Publish.Template indexTemp = null;
            if (ChID != 0)
            {
                indexname = Common.Public.readCHparamConfig("channelindexname", ChID);
                indexTemp = new Foosun.Publish.Template(SiteRootPath.Trim('\\') + TempletPath, Foosun.Publish.TempType.ChIndex);
            }
            else
            {
                indexTemp = new Foosun.Publish.Template(SiteRootPath.Trim('\\') + TempletPath, Foosun.Publish.TempType.Index);
            }
            indexTemp.GetHTML();
            indexTemp.ReplaceLabels();
            string getContent = indexTemp.FinallyContent;

            if (Regex.Match(getContent, @"\</head\>[\s\S]*\<body", RegexOptions.IgnoreCase | RegexOptions.Compiled).Success)
            {
                getContent = Regex.Replace(getContent, "<body", getjs() + "<body", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            }
            else
            {
                getContent = getjs() + getContent;
            }
            getContent = (getContent.Replace(gInstallDir, Common.Public.GetSiteDomain())).Replace(gTempletDir, TempletDir);
            Response.Write(getContent);
        }

        protected string getjs()
        {
            return "";
            //string getajaxJS = "<script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.Public.GetSiteDomain() + "/Scripts/jquery.js\"></script>\r\n";
            //getajaxJS += "<script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.Public.GetSiteDomain() + "/Scripts/public.js\"></script>\r\n";
            //getajaxJS += "<script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.Public.GetSiteDomain() + "/Scripts/jspublick.js\"></script>\r\n";
            //getajaxJS += "<script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.Public.GetSiteDomain() + "/ckplayer/js/ckplayer.js\"></script>\r\n";
            //getajaxJS += "<script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.Public.GetSiteDomain() + "/ckplayer/js/load.js\"></script>\r\n";
            //getajaxJS += "\r\n<!--Created by " + Foosun.Config.verConfig.Productversion + " For Foosun Inc. Published at " + DateTime.Now + "-->\r\n";
            //return getajaxJS;
        }
    }
}

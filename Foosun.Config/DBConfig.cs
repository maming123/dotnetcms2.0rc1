using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
namespace Foosun.Config
{
    public class DBConfig
    {
        //public static readonly string CmsConString = ConfigurationManager.ConnectionStrings["foosun"].ConnectionString;
        //public static readonly string HelpConString =ConfigurationManager.ConnectionStrings["HelpKey"].ConnectionString; 
        //public static readonly string CollectConString =  ConfigurationManager.ConnectionStrings["Collect"].ConnectionString;
        public static string CmsConString
        {
            get
            {
                string tstr = ConfigurationManager.ConnectionStrings["foosun"].ConnectionString;
                if (Foosun.Config.UIConfig.WebDAL.ToLower() == "foosun.accessdal")
                {
                    return getConnectionString(tstr);
                }
                else
                {
                    return tstr;
                }
            }
        }
        public static string HelpConString
        {
            get
            {
                string tstr = ConfigurationManager.ConnectionStrings["HelpKey"].ConnectionString;
                if (Foosun.Config.UIConfig.WebDAL.ToLower() == "foosun.accessdal")
                {
                    return getConnectionString(tstr);
                }
                else
                {
                    return tstr;
                }
            }
        }
        public static string CollectConString
        {
            get
            {
                string tstr = ConfigurationManager.ConnectionStrings["Collect"].ConnectionString;
                if (Foosun.Config.UIConfig.WebDAL.ToLower() == "foosun.accessdal")
                {
                    return getConnectionString(tstr);
                }
                else
                {
                    return tstr;
                }
            }
        }

        public static string OtherConString
        {
            get
            {
                string tstr = ConfigurationManager.ConnectionStrings["other"].ConnectionString;
                if (Foosun.Config.UIConfig.WebDAL.ToLower() == "foosun.accessdal")
                {
                    return getConnectionString(tstr);
                }
                else
                {
                    return tstr;
                }
            }
        }

        /// <summary>
        /// 取得连接字符串
        /// </summary>
        /// <param name="tstr"></param>
        /// <returns></returns>
        private static string getConnectionString(string tstr)
        {
            string conns = string.Empty;
            tstr = tstr.Replace('/', '\\');
            string[] str = tstr.Split('\\');
            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (!string.IsNullOrEmpty(str[i]))
                {
                    if (j == 0)
                        conns = str[i];
                    else
                        conns += "\\" + str[i];
                    j++;
                }
            }

            if (HttpContext.Current == null)
            {
                conns = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpRuntime.AppDomainAppPath + conns + ";Persist Security Info=True;";
            }
            else
                conns = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(tstr) + ";Persist Security Info=True;";
            return conns;
        }

        public static readonly string TableNamePrefix = Foosun.Config.UIConfig.dataRe;
    }
}

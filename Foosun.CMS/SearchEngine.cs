using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Xml;
using System.Data;

namespace Foosun.CMS
{
    public class SearchEngine
    {
        /// <summary>
        /// 得到虚拟目录
        /// </summary>
        private static string _dirdumm = Foosun.Config.UIConfig.dirDumm;

        /// <summary>
        /// 是否生成百度搜索协议xml文件
        /// </summary>
        /// <returns>返回1或者0</returns>
        public static string IsBaidu()
        {
            string str = "0";
            if (_dirdumm.Trim() != "") { _dirdumm = "/" + _dirdumm; }
            try
            {

                if (!File.Exists(HttpContext.Current.Server.MapPath(_dirdumm + "/xml/sys/baiduSearch.xml")))
                {
                    throw new Exception("找不到配置文件(" + _dirdumm + "/xml/sys/baiduSearch.xml" + ").<li>可能是虚拟目录配置出错.请修改web.config</li>");
                }
                string xmlPath = HttpContext.Current.Server.MapPath(_dirdumm + "/xml/sys/baiduSearch.xml");
                FileInfo finfo = new FileInfo(xmlPath);
                System.Xml.XmlDocument xdoc = new XmlDocument();
                xdoc.Load(xmlPath);
                XmlElement root = xdoc.DocumentElement;
                XmlNodeList isbaidu1 = root.GetElementsByTagName("isbaidu");
                str = isbaidu1[0].InnerXml;
            }
            catch
            {
                throw new Exception("配置文件出错:" + _dirdumm + "/xml/sys/baiduSearch.xml" + "");
            }
            return str;
        }

        /// <summary>
        /// 生成百度搜索新闻协议xml文件
        /// </summary>
        public static void RefreshBaidu()
        {
            News cms = new News();
            NewsClass classcms = new NewsClass();
            RootPublic pd = new RootPublic();
            int getnumber = 50;
            int getType = 0;
            string updatePeri = "60";
            string website = "www.foosun.net";
            string webmaster = "service@foosun.cn";
            StreamWriter sw = null;
            if (_dirdumm.Trim() != "") { _dirdumm = "/" + _dirdumm; }
            try
            {
                if (!File.Exists(HttpContext.Current.Server.MapPath(_dirdumm + "/xml/sys/baiduSearch.xml")))
                {
                    throw new Exception("找不到配置文件(" + _dirdumm + "/xml/sys/baiduSearch.xml" + ").<li>可能是虚拟目录配置出错.请修改web.config</li>");
                }
                string xmlPath = HttpContext.Current.Server.MapPath(_dirdumm + "/xml/sys/baiduSearch.xml");
                FileInfo finfo = new FileInfo(xmlPath);
                System.Xml.XmlDocument xdoc = new XmlDocument();
                xdoc.Load(xmlPath);
                XmlElement root = xdoc.DocumentElement;
                XmlNodeList number1 = root.GetElementsByTagName("number");
                XmlNodeList searchtype1 = root.GetElementsByTagName("searchtype");
                XmlNodeList updatePeri1 = root.GetElementsByTagName("updatePeri");
                XmlNodeList website1 = root.GetElementsByTagName("website");
                XmlNodeList webmaster1 = root.GetElementsByTagName("webmaster");
                getnumber = int.Parse(number1[0].InnerXml);
                getType = int.Parse(searchtype1[0].InnerXml);
                updatePeri = updatePeri1[0].InnerXml;
                website = website1[0].InnerXml;
                webmaster = webmaster1[0].InnerXml;
            }
            catch
            {
                throw new Exception("配置文件出错:" + _dirdumm + "/xml/sys/baiduSearch.xml");
            }
            string FileName = HttpContext.Current.Server.MapPath("~/baidu.xml");
            sw = File.CreateText(FileName);
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sw.WriteLine("<document>");
            sw.WriteLine("  <webMaster>" + webmaster + "</webMaster>");
            sw.WriteLine("  <webSite>http://" + website + "</webSite>");
            sw.WriteLine("  <updatePeri>" + updatePeri + "</updatePeri>");
            string urls = "";
            DataTable dt = cms.GetLastFormTB();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < getnumber; i++)
                {
                    if (dt.Rows.Count > i)
                    {
                        try
                        {
                            IDataReader drs = cms.GetNewsID(dt.Rows[i]["NewsID"].ToString());
                            if (drs.Read())
                            {
                                sw.WriteLine("  <item>");
                                sw.WriteLine("      <title></title>");
                                if (drs["NewsType"].ToString() == "2")
                                {
                                    urls = drs["URLaddress"].ToString();
                                }
                                else
                                {
                                    DataTable dt1 = classcms.GetParentClass(drs["ClassID"].ToString());
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        if (Common.Public.readparamConfig("ReviewType") == "1")
                                        {
                                            urls = "/content-" + drs["NewsID"].ToString() + ".aspx";
                                        }
                                        else
                                        {
                                            if (drs["isDelPoint"].ToString() != "0")
                                            {
                                                urls = "/content-" + drs["NewsID"].ToString() + ".aspx";
                                            }
                                            else
                                            {
                                                urls = "/" + dt1.Rows[0]["SavePath"].ToString() + "/" + dt1.Rows[0]["SaveClassframe"].ToString() + "/" + drs["SavePath"].ToString() + "/" + drs["FileName"].ToString() + drs["FileEXName"].ToString();
                                            }
                                        }
                                        urls = Common.Public.GetSiteDomain() + urls.Replace("//", "/");
                                        dt1.Clear(); dt1.Dispose();
                                    }
                                }
                                sw.WriteLine("      <link>" + urls + "</link>");
                                sw.WriteLine("      <description><![CDATA[" + Common.Input.LostHTML(drs["naviContent"].ToString()) + "]]></description>");
                                sw.WriteLine("      <text><![CDATA[" + Common.Input.LostHTML(drs["Content"].ToString()) + "]]></text>");
                                if (drs["PicURL"].ToString().Trim() != "" && drs["PicURL"].ToString().Trim() != null) { sw.WriteLine("      <image>http://" + website + _dirdumm + (drs["PicURL"].ToString()).Replace("{@dirfile}", Foosun.Config.UIConfig.dirFile) + "</image>"); }
                                else { sw.WriteLine("      <image></image>"); }
                                sw.WriteLine("      <keywords>" + drs["Metakeywords"].ToString().Replace(",", " ") + "</keywords>");
                                sw.WriteLine("      <author>" + drs["Author"] + "</author>");
                                sw.WriteLine("      <source>" + drs["Souce"] + "</source>");
                                sw.WriteLine("      <pubDate>" + drs["CreatTime"] + "</pubDate>");
                                sw.WriteLine("  </item>");
                            }
                            drs.Close();
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                dt.Clear(); dt.Dispose();
            }
            sw.WriteLine("</document>");
            sw.Flush();
            sw.Close(); sw.Dispose();
        }
    }
}

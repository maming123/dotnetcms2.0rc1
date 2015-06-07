namespace Foosun.Publish
{
    using Common;
    using Foosun.CMS;
    using Foosun.Config;
    using Foosun.Global;
    using HtmlAgilityPack;
    using LitJson;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Xml;

    public class DropPublish
    {
        private static string GetPageTop(DataRow dr, string ptype)
        {
            string str = "<html>\r\n";
            str = str + "<head>\r\n";
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (ptype == "index")
            {
                sys sys = new sys();
                string str4 = "";
                IDataReader sysParam = CommonData.DalPublish.GetSysParam();
                if (sysParam.Read() && (sysParam["SiteName"] != DBNull.Value))
                {
                    str4 = sysParam["SiteName"].ToString();
                }
                sysParam.Close();
                str = str + "<title>" + str4 + "</title>\r\n";
                str2 = "<meta name=\"keywords\" content=\"首页,新闻,CMS\" />\r\n";
                str3 = "<meta name=\"description\" content=\"首页,新闻,CMS\" />\r\n";
            }
            else if (ptype == "new")
            {
                str = str + "<title>" + dr["NewsTitle"].ToString() + "</title>\r\n";
                str2 = "<meta name=\"keywords\" content=\"" + dr["MetaKeywords"] + "\" />\r\n";
                str3 = "<meta name=\"description\" content=\"" + dr["Metadesc"] + "\" />\r\n";
            }
            else if (ptype == "class")
            {
                str = str + "<title>" + dr["ClassCName"].ToString() + "</title>\r\n";
                str2 = "<meta name=\"keywords\" content=\"" + dr["MetaKeywords"] + "\" />\r\n";
                str3 = "<meta name=\"description\" content=\"" + dr["MetaDescript"] + "\" />\r\n";
            }
            else if (ptype == "special")
            {
                str = str + "<title>" + dr["SpecialCName"].ToString() + "</title>\r\n";
            }
            else if (ptype == "page")
            {
                str = str + "<title>" + dr["ClassCName"].ToString() + "</title>\r\n";
                str2 = "<meta name=\"keywords\" content=\"" + dr["MetaKeywords"] + "\" />\r\n";
                str3 = "<meta name=\"description\" content=\"" + dr["MetaDescript"] + "\" />\r\n";
            }
            return (str + str2 + str3);
        }

        private string GetSavePath(DataRow dr, string ptype, int pageindex, out string indexname)
        {
            Page page = new Page();
            string path = "";
            indexname = "index.html";
            indexname = Public.readparamConfig("IndexFileName");
            if (ptype == "index")
            {
                path = page.Server.MapPath("/" + indexname);
            }
            else if (ptype == "new")
            {
                path = page.Server.MapPath(string.Concat(new object[] { "/html/", dr["SavePath"].ToString(), "/", dr["FileName"], dr["FileEXName"] }));
            }
            else if (ptype == "class")
            {
                if (pageindex == 1)
                {
                    path = string.Concat(new object[] { ServerInfo.GetRootPath(), dr["SavePath"], "/", dr["ClassEName"], "/index.html" });
                }
                else
                {
                    path = string.Concat(new object[] { ServerInfo.GetRootPath(), dr["SavePath"], "/", dr["ClassEName"], "/index_", pageindex, ".html" });
                }
            }
            else if (ptype == "special")
            {
                path = page.Server.MapPath(string.Concat(new object[] { dr["SavePath"].ToString(), "/", dr["saveDirPath"], "/", dr["FileName"], dr["FileEXName"] }));
            }
            else if (ptype == "page")
            {
                path = page.Server.MapPath(dr["SavePath"].ToString());
            }
            string directoryName = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            return path;
        }

        private string ParsingControl(DataRow dr, string ptype, List<string> cssList, HtmlNode node, int pageindex, out int pageCount, out string pid)
        {
            Page handler = new Page();
            string str = node.Attributes["value"].Value;
            JsonData data = JsonMapper.ToObject(str.Substring(1, str.Length - 2));
            string virtualPath = (string) data["path"];
            pid = (string) data["PID"];
            UserControl control = new UserControl();
            try
            {
                control = (UserControl) handler.LoadControl(virtualPath);
            }
            catch
            {
                Public.savePublicLogFiles("□□□发布", string.Concat(new object[] { "【ID】:", dr["ID"], "\r\n【错误描述：】\r\n模版路径错误:不存在路径", virtualPath }), Current.UserName);
            }
            string str3 = "";
            XmlDocument document = new XmlDocument();
            document.Load(handler.Server.MapPath(Path.GetDirectoryName((string) data["path"]) + @"\index.xml"));
            XmlNodeList childNodes = document.DocumentElement.SelectSingleNode("Attribute").ChildNodes;
            string innerText = document.DocumentElement.SelectSingleNode("type").InnerText;
            foreach (XmlElement element in childNodes)
            {
                control.GetType().GetProperty(element.ChildNodes[0].InnerText).SetValue(control, (string) data[element.ChildNodes[0].InnerText], null);
                if (ptype != "index")
                {
                    switch (innerText)
                    {
                        case "newinfo":
                            control.GetType().GetProperty("NewsID").SetValue(control, dr["NewsID"], null);
                            break;

                        case "newslist":
                            control.GetType().GetProperty("ClassID").SetValue(control, dr["ClassID"], null);
                            control.GetType().GetProperty("PageIndex").SetValue(control, pageindex.ToString(), null);
                            break;

                        case "classnavi":
                            control.GetType().GetProperty("ClassID").SetValue(control, dr["ClassID"], null);
                            break;

                        case "positionnavi":
                            control.GetType().GetProperty("ClassID").SetValue(control, dr["ClassID"], null);
                            break;

                        case "newsflash":
                            control.GetType().GetProperty("ClassID").SetValue(control, dr["ClassID"], null);
                            break;

                        case "newspiclist":
                            control.GetType().GetProperty("ClassID").SetValue(control, dr["ClassID"], null);
                            break;

                        case "newspictxtlist":
                            control.GetType().GetProperty("ClassID").SetValue(control, dr["ClassID"], null);
                            break;
                    }
                }
            }
            handler.Controls.Add(control);
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.Execute(handler, writer, false);
            if (innerText == "newslist")
            {
                pageCount = Convert.ToInt32(control.GetType().GetProperty("PageCount").GetValue(control, null));
            }
            else
            {
                pageCount = 0;
            }
            string html = writer.ToString();
            HtmlDocument document2 = new HtmlDocument();
            document2.LoadHtml(html);
            HtmlNode node2 = document2.DocumentNode.SelectSingleNode("//link[@rel=\"stylesheet\"]");
            string item = "";
            if (node2 != null)
            {
                item = node2.OuterHtml;
            }
            if (!(cssList.Contains(item) || !(item != "")))
            {
                cssList.Add(item);
                document2.DocumentNode.SelectSingleNode("//link[@rel=\"stylesheet\"]").Remove();
            }
            return (str3 + document2.DocumentNode.OuterHtml);
        }

        private string ParsingLayout(HtmlNode node)
        {
            string json = node.Attributes["value"].Value;
            string str2 = "";
            JsonData data = JsonMapper.ToObject(json);
            if (data.IsArray)
            {
                foreach (JsonData data2 in (IEnumerable) data)
                {
                    string str4 = str2;
                    str2 = str4 + "<div id=\"" + ((string) data2["ID"]) + "\" pid=\"" + ((string) data2["PID"]) + "\"";
                    int num = (int) data2["type"];
                    if (num == 2)
                    {
                        str2 = str2 + " class=\"" + ((string) data2["divstyle"]) + "\"";
                    }
                    else if (num == 1)
                    {
                        str2 = str2 + " style=\"width:" + ((string) data2["width"]) + "px\"";
                    }
                    else
                    {
                        str2 = str2 + " style=\"width:" + ((string) data2["width"]) + "%\"";
                    }
                    str2 = str2 + "></div>";
                }
            }
            return str2;
        }

        public bool publish(DataRow dr, string ptype)
        {
            string dropTemplet = UIConfig.dropTemplet;
            string path = "";
            string html = "";
            if (ptype == "index")
            {
                path = Public.readparamConfig("IndexTemplet").Replace("/", @"\");
                path = new Page().Server.MapPath(path.ToLower().Replace("{@dirtemplet}", dropTemplet));
            }
            else
            {
                DropTemplet templet = new DropTemplet();
                if (ptype == "new")
                {
                    path = templet.GetNewsTemplet(dr["NewsID"].ToString());
                }
                else if ((ptype == "class") || (ptype == "page"))
                {
                    path = templet.GetClassTemplet(dr["ClassID"].ToString());
                }
                else if (ptype == "special")
                {
                    path = templet.GetSpecialTemplet(dr["SpecialID"].ToString());
                }
                path = new Page().Server.MapPath(path.Replace("{@dirtemplet}", dropTemplet));
            }
            try
            {
                FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                html = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                List<string> cssList = new List<string>();
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);
                HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[@class=\"mobot_top\"]");
                foreach (HtmlNode node in (IEnumerable<HtmlNode>) nodes)
                {
                    node.Remove();
                }
                nodes.Clear();
                nodes = document.DocumentNode.SelectNodes("//div[@class=\"mobot_mobi\"]");
                foreach (HtmlNode node in (IEnumerable<HtmlNode>) nodes)
                {
                    node.Remove();
                }
                nodes.Clear();
                int pageindex = 1;
                int pageCount = 0;
                string indexname = "";
                do
                {
                    string pageTop = GetPageTop(dr, ptype);
                    string str6 = "";
                    string outerHtml = "";
                    nodes = document.DocumentNode.SelectNodes("//input[@name=\"divinfo\"]");
                    HtmlDocument document2 = new HtmlDocument();
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) nodes)
                    {
                        outerHtml = outerHtml + this.ParsingLayout(node);
                    }
                    document2.LoadHtml(outerHtml);
                    HtmlNodeCollection nodes2 = document2.DocumentNode.SelectNodes("//div");
                    foreach (HtmlNode node2 in (IEnumerable<HtmlNode>) nodes2)
                    {
                        if (node2.Attributes["pid"].Value != "0")
                        {
                            document2.DocumentNode.SelectSingleNode("//div[@id=\"" + node2.Id + "\"]").Remove();
                            document2.DocumentNode.SelectSingleNode("//div[@id=\"" + node2.Attributes["pid"].Value + "\"]").ChildNodes.Add(node2);
                            outerHtml = document2.DocumentNode.OuterHtml;
                            document2.LoadHtml(outerHtml);
                        }
                    }
                    outerHtml = document2.DocumentNode.OuterHtml;
                    nodes = document.DocumentNode.SelectNodes("//input[@name=\"controlinfo\"]");
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) nodes)
                    {
                        string pid = "0";
                        str6 = this.ParsingControl(dr, ptype, cssList, node, pageindex, out pageCount, out pid);
                        HtmlDocument document3 = new HtmlDocument();
                        document3.LoadHtml(str6);
                        document2.DocumentNode.SelectSingleNode("//div[@id=\"" + pid + "\"]").ChildNodes.Add(document3.DocumentNode);
                        outerHtml = document2.DocumentNode.InnerHtml;
                        document2.LoadHtml(outerHtml);
                    }
                    foreach (string str9 in cssList)
                    {
                        pageTop = pageTop + str9 + "\r\n";
                    }
                    string str10 = (("<script type=\"text/javascript\" src=\"" + CommonData.SiteDomain + "/Scripts/jquery.js\"></script>\r\n") + "<script type=\"text/javascript\" src=\"" + CommonData.SiteDomain + "/Scripts/jspublick.js\" charset=\"utf-8\"></script>\r\n") + "<link href=\"" + CommonData.SiteDomain + "/Plugins/css/base.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n";
                    if (Public.readparamConfig("Open", "Cnzz") == "11")
                    {
                        str10 = str10 + "<script src='http://pw.cnzz.com/c.php?id=" + Public.readparamConfig("SiteID", "Cnzz") + "'  type=\"text/javascript\" charset='gb2312'></script>\r\n";
                    }
                    if (pageindex > 1)
                    {
                        str10 = str10 + "<link href=\"" + CommonData.SiteDomain + "/sysImages/css/PagesCSS.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n";
                    }
                    pageTop = ((pageTop + str10 + string.Concat(new object[] { "\r\n<!--Created by ", verConfig.Productversion, " For Foosun Inc. Published at ", DateTime.Now, "-->\r\n" })) + "</head>\r\n") + "<body>\r\n" + outerHtml + "</body>\r\n";
                    StreamWriter writer = new StreamWriter(this.GetSavePath(dr, ptype, pageindex, out indexname), false, Encoding.UTF8);
                    writer.Write(pageTop);
                    writer.Close();
                    writer.Dispose();
                    pageindex++;
                }
                while (pageindex <= pageCount);
                return true;
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□发布", string.Concat(new object[] { "【ID】:", dr["ID"], "\r\n【错误描述：】\r\n", exception.Message }), Current.UserName);
                return false;
            }
        }
    }
}


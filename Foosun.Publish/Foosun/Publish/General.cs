namespace Foosun.Publish
{
    using Common;
    using Foosun.CMS;
    using Foosun.Config;
    using Foosun.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class General
    {
        public static string InstallDir = "{$InstallDir}";
        public static string RootInstallDir = CommonData.SiteDomain;
        public static string strgTemplet = UIConfig.dirTemplet;
        public static string TempletDir = "{$TempletDir}";

        public static void CreateDirectory(string Path)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }

        public static string GetChineseNumber(int PageCount)
        {
            string[] strArray = new string[] { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
            return strArray[PageCount - 1];
        }

        private static string GetDNSUrl()
        {
            string str = Public.readparamConfig("siteDomain");
            string serverPort = ServerInfo.ServerPort;
            if (serverPort != "80")
            {
                serverPort = ":" + serverPort;
            }
            else
            {
                serverPort = "";
            }
            return ("http://" + str + serverPort);
        }

        public static string GetHistoryContent(string historyId)
        {
            string rootPath = ServerInfo.GetRootPath();
            string dirTemplet = UIConfig.dirTemplet;
            string str3 = "/{@dirtemplet}/Content/history.html";
            str3 = str3.Replace("/", @"\").Replace("{@dirtemplet}", dirTemplet);
            Template template = new Template(rootPath + str3, TempType.Index);
            template.GetHTML();
            template.ReplaceLabels();
            string finallyContent = template.FinallyContent;
            DataTable historyContent = CommonData.DalPublish.GetHistoryContent(historyId);
            if (historyContent.Rows.Count > 0)
            {
                return finallyContent.Replace("{#history_PageTitle}", historyContent.Rows[0]["NewsTitle"].ToString()).Replace("{#history_PageAuthor}", historyContent.Rows[0]["Author"].ToString()).Replace("{#history_PageSouce}", historyContent.Rows[0]["Souce"].ToString()).Replace("{#history_PageContent}", historyContent.Rows[0]["Content"].ToString()).Replace("{#history_PageCreatTime}", historyContent.Rows[0]["CreatTime"].ToString());
            }
            return finallyContent.Replace("{#history_PageTitle}", "").Replace("{#history_PageAuthor}", "").Replace("{#history_PageSouce}", "").Replace("{#history_PageContent}", "").Replace("{#history_PageCreatTime}", "");
        }

        private static string GetNewsURL(string _dim, string _NewsType, string _isDelPoint, string _NewsID, string _SavePath, string _SavePath1, string _SaveClassframe, string _FileName, string _FileEXName, string _URLaddress)
        {
            string str = "";
            string str2 = "";
            if (_NewsType != "2")
            {
                if (_isDelPoint != "0")
                {
                    str = _dim + "/content-" + _NewsID + UIConfig.extensions;
                }
                else
                {
                    str = _dim + "/" + _SavePath1 + "/" + _SaveClassframe + "/" + _SavePath + "/" + _FileName + _FileEXName;
                }
                str2 = str.Replace("//", "/").Replace(@"\\", @"\");
                return (GetDNSUrl() + str2);
            }
            if (_URLaddress.IndexOf("http://") > -1)
            {
                return _URLaddress;
            }
            return ("http://" + _URLaddress);
        }

        private static string getPageDefaultStyleSheet()
        {
            return "";
            //return "<link href=\"/sysImages/css/PagesCSS.css\" rel=\"stylesheet\" type=\"text/css\" />";
        }

        public static string GetPageLinkTextStr(string _PageStyles, int _CurrentPage, int _PageCount, int _PageLinkCount, string _fileName, string _EXName)
        {
            string str15;
            string str16;
            string str17;
            string str18;
            if (_PageCount <= 1)
            {
                return "";
            }
            string str = "";
            string str2 = " class=\"foosun_pagebox\"";
            string str3 = " class=\"foosun_pagebox_num_nonce\"";
            string str4 = " class=\"foosun_pagebox_num\"";
            if (string.IsNullOrEmpty(_PageStyles))
            {
                _PageStyles = "0";
            }
            string str5 = string.Empty;
            string str6 = "";
            string str7 = "";
            string chineseNumber = GetChineseNumber(_PageLinkCount);
            int num = (((_CurrentPage - 1) / _PageLinkCount) * _PageLinkCount) + 1;
            if (num == 0)
            {
                num = 1;
            }
            if (_PageStyles == "3")
            {
                str6 = "<div " + str2 + " style=\"padding-top:15px;\">";
            }
            else
            {
                str6 = "<div style=\"padding-top:15px;\">";
            }
            int num2 = ((_CurrentPage - _PageLinkCount) >= 1) ? (_CurrentPage - _PageLinkCount) : 1;
            int num3 = ((_CurrentPage + _PageLinkCount) <= _PageCount) ? (_CurrentPage + _PageLinkCount) : _PageCount;
            string str9 = _fileName + _EXName;
            string str10 = string.Concat(new object[] { _fileName, "_", _PageCount, _EXName });
            string str11 = string.Concat(new object[] { _fileName, "_", _CurrentPage - 1, _EXName });
            if (_CurrentPage <= 2)
            {
                str11 = str9;
            }
            string str12 = string.Concat(new object[] { _fileName, "_", num2, _EXName });
            if (num2 <= 2)
            {
                str12 = str9;
            }
            string str13 = string.Concat(new object[] { _fileName, "_", _CurrentPage + 1, _EXName });
            string str14 = string.Concat(new object[] { _fileName, "_", num3, _EXName });
            if (_PageStyles == "3")
            {
                str7 = "";
            }
            else
            {
                str7 = "&nbsp;";
            }
            int num4 = 0;
            for (int i = num; i <= _PageCount; i++)
            {
                object obj2;
                num4++;
                if (num4 > Convert.ToInt32(_PageLinkCount))
                {
                    break;
                }
                if (i == _CurrentPage)
                {
                    if (_PageStyles == "3")
                    {
                        obj2 = str5;
                        str5 = string.Concat(new object[] { obj2, "<strong><span ", str3, ">", i, "</span></strong>", str7 });
                    }
                    else
                    {
                        obj2 = str5;
                        str5 = string.Concat(new object[] { obj2, "<strong><span>", i, "</span></strong>", str7 });
                    }
                }
                else if (i == 1)
                {
                    obj2 = str5;
                    str5 = string.Concat(new object[] { obj2, "<a href=\"", _fileName, _EXName, "\">", i, "</a>", str7 });
                }
                else
                {
                    obj2 = str5;
                    str5 = string.Concat(new object[] { obj2, "<a href=\"", _fileName, "_", i, _EXName, "\">", i, "</a>", str7 });
                }
            }
            switch (Convert.ToInt32(_PageStyles))
            {
                case 0:
                    if (_PageCount <= _PageLinkCount)
                    {
                        str15 = "";
                        str16 = "";
                        str17 = "";
                        str18 = "";
                        break;
                    }
                    str15 = "<span>上" + chineseNumber + "页</span>&nbsp;";
                    str16 = "<a href=\"" + str12 + "\" title=\"上" + chineseNumber + "页\"><span>上" + chineseNumber + "页</span></a>&nbsp;";
                    str17 = "<span>下" + chineseNumber + "页</span>&nbsp;";
                    str18 = "<a href=\"" + str14 + "\" title=\"下" + chineseNumber + "页\"><span>下" + chineseNumber + "页</span></a>&nbsp;";
                    break;

                case 1:
                    if (_CurrentPage > 1)
                    {
                        if (_CurrentPage >= _PageCount)
                        {
                            str = "<a href=\"" + str11 + "\">上一页</a>&nbsp;" + str5 + "<span>下一页</span></div>";
                        }
                        else
                        {
                            str = "<a href=\"" + str11 + "\">上一页</a>&nbsp;" + str5 + "<a href=\"" + str13 + "\">下一页</a></div>";
                        }
                    }
                    else
                    {
                        str = "<span>上一页</span>&nbsp;" + str5 + "<a href=\"" + str13 + "\">下一页</a></div>";
                    }
                    goto Label_0B8A;

                case 2:
                    if (_PageCount <= _PageLinkCount)
                    {
                        str15 = "";
                        str16 = "";
                        str17 = "";
                        str18 = "";
                    }
                    else
                    {
                        str15 = "<span><font face=webdings>7</font></span>&nbsp;";
                        str16 = "<a  href=\"" + str12 + "\" title=\"上" + chineseNumber + "页\"><span><font face=webdings>7</font></span></a>&nbsp;";
                        str17 = "<span><font face=webdings>8</font></span>&nbsp;";
                        str18 = "<a href=\"" + str14 + "\" title=\"下" + chineseNumber + "页\"><span><font face=webdings>8</font></span></a>&nbsp;";
                    }
                    if (_CurrentPage <= 1)
                    {
                        str = "<span><font face=webdings title=\"首页\">9</font></span>&nbsp;<span><font face=webdings title=\"上一页\">3</font></span>&nbsp;" + str15 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span><font face=webdings>4</font></span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span><font face=webdings>:</font></span></a></div>";
                    }
                    else if (_CurrentPage >= _PageCount)
                    {
                        str = "<a href=\"" + str9 + "\"><span><font face=webdings title=\"首页\">9</font></span></a>&nbsp;<a href=\"" + str11 + "\"><span><font face=webdings title=\"上一页\">3</font></span></a>&nbsp;" + str16 + str5 + str17 + "<span><font face=webdings>4</font></span>&nbsp;<span><font face=webdings>:</font></span></div>";
                    }
                    else
                    {
                        str = "<a href=\"" + str9 + "\"<span><font face=webdings title=\"首页\">9</font></span></a>&nbsp;<a href=\"" + str11 + "\"><span><font face=webdings title=\"上一页\">3</font></span></a>&nbsp;" + str16 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span><font face=webdings>4</font></span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span><font face=webdings>:</font></span></a></div>";
                    }
                    goto Label_0B8A;

                case 3:
                    if (_PageCount <= _PageLinkCount)
                    {
                        str15 = "";
                        str16 = "";
                        str17 = "";
                        str18 = "";
                    }
                    else
                    {
                        str15 = "<span " + str4 + ">上" + chineseNumber + "页</span>";
                        str16 = "<a href=\"" + str12 + "\" title=\"上" + chineseNumber + "页\">上" + chineseNumber + "页</a>";
                        str17 = "<span " + str4 + ">下" + chineseNumber + "页</span>";
                        str18 = "<a href=\"" + str14 + "\" title=\"下" + chineseNumber + "页\">下" + chineseNumber + "页</a>";
                    }
                    if (_CurrentPage <= 1)
                    {
                        str = "<span " + str4 + ">首页</span><span " + str4 + ">上一页</span>" + str15 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\">下一页</a><a  href=\"" + str10 + "\" title=\"尾页\">尾页</a></div>";
                    }
                    else if (_CurrentPage >= _PageCount)
                    {
                        str = "<a href=\"" + str9 + "\">首页</a><a href=\"" + str11 + "\">上一页</a>" + str16 + str5 + str17 + "<span " + str4 + ">下一页</span><span " + str4 + ">尾页</span></div>";
                    }
                    else
                    {
                        str = "<a href=\"" + str9 + "\">首页</a><a href=\"" + str11 + "\">上一页</a>" + str16 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\">下一页</a><a  href=\"" + str10 + "\" title=\"尾页\">尾页</a></div>";
                    }
                    goto Label_0B8A;

                default:
                    str = "";
                    goto Label_0B8A;
            }
            if (_CurrentPage <= 1)
            {
                str = "<span>首页</span>&nbsp;<span>上一页</span>&nbsp;" + str15 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span>下一页</span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span>尾页</span></a></div>";
            }
            else if (_CurrentPage >= _PageCount)
            {
                str = "<a href=\"" + str9 + "\"><span>首页</span></a>&nbsp;<a href=\"" + str11 + "\"><span>上一页</span></a>&nbsp;" + str16 + str5 + str17 + "<span>下一页</span>&nbsp;<span>尾页</span></div>";
            }
            else
            {
                str = "<a href=\"" + str9 + "\"><span>首页</span></a>&nbsp;<a href=\"" + str11 + "\"><span>上一页</span></a>&nbsp;" + str16 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span>下一页</span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span>尾页</span></a></div>";
            }
        Label_0B8A:
            return (str6 + str);
        }

        public static string GetPageLinkTextStrPage(string _PageStyles, int _CurrentPage, int _PageCount, int _PageLinkCount, string _fileName, string _EXName)
        {
            string str15;
            string str16;
            string str17;
            string str18;
            if (_PageCount <= 1)
            {
                return "";
            }
            string str = "";
            string str2 = " class=\"foosun_pagebox\"";
            string str3 = " class=\"foosun_pagebox_num_nonce\"";
            string str4 = " class=\"foosun_pagebox_num\"";
            if (string.IsNullOrEmpty(_PageStyles))
            {
                _PageStyles = "0";
            }
            string str5 = string.Empty;
            string str6 = "";
            string str7 = "";
            string chineseNumber = GetChineseNumber(_PageLinkCount);
            int num = (((_CurrentPage - 1) / _PageLinkCount) * _PageLinkCount) + 1;
            if (num == 0)
            {
                num = 1;
            }
            if (_PageStyles == "3")
            {
                str6 = "<div " + str2 + " style=\"padding-top:15px;\">";
            }
            else
            {
                str6 = "<div style=\"padding-top:15px;\">";
            }
            int num2 = ((_CurrentPage - _PageLinkCount) >= 1) ? (_CurrentPage - _PageLinkCount) : 1;
            int num3 = ((_CurrentPage + _PageLinkCount) <= _PageCount) ? (_CurrentPage + _PageLinkCount) : _PageCount;
            string str9 = _fileName + _EXName;
            string str10 = string.Concat(new object[] { _fileName, "-", _PageCount, _EXName });
            string str11 = string.Concat(new object[] { _fileName, "-", _CurrentPage - 1, _EXName });
            if (_CurrentPage <= 2)
            {
                str11 = str9;
            }
            string str12 = string.Concat(new object[] { _fileName, "-", num2, _EXName });
            if (num2 <= 2)
            {
                str12 = str9;
            }
            string str13 = string.Concat(new object[] { _fileName, "-", _CurrentPage + 1, _EXName });
            string str14 = string.Concat(new object[] { _fileName, "-", num3, _EXName });
            if (_PageStyles == "3")
            {
                str7 = "";
            }
            else
            {
                str7 = "&nbsp;";
            }
            int num4 = 0;
            for (int i = num; i <= _PageCount; i++)
            {
                object obj2;
                num4++;
                if (num4 > Convert.ToInt32(_PageLinkCount))
                {
                    break;
                }
                if (i == _CurrentPage)
                {
                    if (_PageStyles == "3")
                    {
                        obj2 = str5;
                        str5 = string.Concat(new object[] { obj2, "<strong><span ", str3, ">", i, "</span></strong>", str7 });
                    }
                    else
                    {
                        obj2 = str5;
                        str5 = string.Concat(new object[] { obj2, "<strong><span>", i, "</span></strong>", str7 });
                    }
                }
                else if (i == 1)
                {
                    obj2 = str5;
                    str5 = string.Concat(new object[] { obj2, "<a href=\"", _fileName, _EXName, "\">", i, "</a>", str7 });
                }
                else
                {
                    obj2 = str5;
                    str5 = string.Concat(new object[] { obj2, "<a href=\"", _fileName, "-", i, _EXName, "\">", i, "</a>", str7 });
                }
            }
            switch (Convert.ToInt32(_PageStyles))
            {
                case 0:
                    if (_PageCount <= _PageLinkCount)
                    {
                        str15 = "";
                        str16 = "";
                        str17 = "";
                        str18 = "";
                        break;
                    }
                    str15 = "<span>上" + chineseNumber + "页</span>&nbsp;";
                    str16 = "<a href=\"" + str12 + "\" title=\"上" + chineseNumber + "页\"><span>上" + chineseNumber + "页</span></a>&nbsp;";
                    str17 = "<span>下" + chineseNumber + "页</span>&nbsp;";
                    str18 = "<a href=\"" + str14 + "\" title=\"下" + chineseNumber + "页\"><span>下" + chineseNumber + "页</span></a>&nbsp;";
                    break;

                case 1:
                    if (_CurrentPage > 1)
                    {
                        if (_CurrentPage >= _PageCount)
                        {
                            str = "<a href=\"" + str11 + "\">上一页</a>&nbsp;" + str5 + "<span>下一页</span></div>";
                        }
                        else
                        {
                            str = "<a href=\"" + str11 + "\">上一页</a>&nbsp;" + str5 + "<a href=\"" + str13 + "\">下一页</a></div>";
                        }
                    }
                    else
                    {
                        str = "<span>上一页</span>&nbsp;" + str5 + "<a href=\"" + str13 + "\">下一页</a></div>";
                    }
                    goto Label_0B8A;

                case 2:
                    if (_PageCount <= _PageLinkCount)
                    {
                        str15 = "";
                        str16 = "";
                        str17 = "";
                        str18 = "";
                    }
                    else
                    {
                        str15 = "<span><font face=webdings>7</font></span>&nbsp;";
                        str16 = "<a  href=\"" + str12 + "\" title=\"上" + chineseNumber + "页\"><span><font face=webdings>7</font></span></a>&nbsp;";
                        str17 = "<span><font face=webdings>8</font></span>&nbsp;";
                        str18 = "<a href=\"" + str14 + "\" title=\"下" + chineseNumber + "页\"><span><font face=webdings>8</font></span></a>&nbsp;";
                    }
                    if (_CurrentPage <= 1)
                    {
                        str = "<span><font face=webdings title=\"首页\">9</font></span>&nbsp;<span><font face=webdings title=\"上一页\">3</font></span>&nbsp;" + str15 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span><font face=webdings>4</font></span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span><font face=webdings>:</font></span></a></div>";
                    }
                    else if (_CurrentPage >= _PageCount)
                    {
                        str = "<a href=\"" + str9 + "\"><span><font face=webdings title=\"首页\">9</font></span></a>&nbsp;<a href=\"" + str11 + "\"><span><font face=webdings title=\"上一页\">3</font></span></a>&nbsp;" + str16 + str5 + str17 + "<span><font face=webdings>4</font></span>&nbsp;<span><font face=webdings>:</font></span></div>";
                    }
                    else
                    {
                        str = "<a href=\"" + str9 + "\"<span><font face=webdings title=\"首页\">9</font></span></a>&nbsp;<a href=\"" + str11 + "\"><span><font face=webdings title=\"上一页\">3</font></span></a>&nbsp;" + str16 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span><font face=webdings>4</font></span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span><font face=webdings>:</font></span></a></div>";
                    }
                    goto Label_0B8A;

                case 3:
                    if (_PageCount <= _PageLinkCount)
                    {
                        str15 = "";
                        str16 = "";
                        str17 = "";
                        str18 = "";
                    }
                    else
                    {
                        str15 = "<span " + str4 + ">上" + chineseNumber + "页</span>";
                        str16 = "<a href=\"" + str12 + "\" title=\"上" + chineseNumber + "页\">上" + chineseNumber + "页</a>";
                        str17 = "<span " + str4 + ">下" + chineseNumber + "页</span>";
                        str18 = "<a href=\"" + str14 + "\" title=\"下" + chineseNumber + "页\">下" + chineseNumber + "页</a>";
                    }
                    if (_CurrentPage <= 1)
                    {
                        str = "<span " + str4 + ">首页</span><span " + str4 + ">上一页</span>" + str15 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\">下一页</a><a  href=\"" + str10 + "\" title=\"尾页\">尾页</a></div>";
                    }
                    else if (_CurrentPage >= _PageCount)
                    {
                        str = "<a href=\"" + str9 + "\">首页</a><a href=\"" + str11 + "\">上一页</a>" + str16 + str5 + str17 + "<span " + str4 + ">下一页</span><span " + str4 + ">尾页</span></div>";
                    }
                    else
                    {
                        str = "<a href=\"" + str9 + "\">首页</a><a href=\"" + str11 + "\">上一页</a>" + str16 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\">下一页</a><a  href=\"" + str10 + "\" title=\"尾页\">尾页</a></div>";
                    }
                    goto Label_0B8A;

                default:
                    str = "";
                    goto Label_0B8A;
            }
            if (_CurrentPage <= 1)
            {
                str = "<span>首页</span>&nbsp;<span>上一页</span>&nbsp;" + str15 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span>下一页</span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span>尾页</span></a></div>";
            }
            else if (_CurrentPage >= _PageCount)
            {
                str = "<a href=\"" + str9 + "\"><span>首页</span></a>&nbsp;<a href=\"" + str11 + "\"><span>上一页</span></a>&nbsp;" + str16 + str5 + str17 + "<span>下一页</span>&nbsp;<span>尾页</span></div>";
            }
            else
            {
                str = "<a href=\"" + str9 + "\"><span>首页</span></a>&nbsp;<a href=\"" + str11 + "\"><span>上一页</span></a>&nbsp;" + str16 + str5 + str18 + "<a  href=\"" + str13 + "\" title=\"下一页\"><span>下一页</span></a>&nbsp;<a  href=\"" + str10 + "\" title=\"尾页\"><span>尾页</span></a></div>";
            }
        Label_0B8A:
            return (str6 + str);
        }

        public static string getPageStyle(string Input, string sColor, string Css)
        {
            string str2 = "";
            if (sColor.Trim() != string.Empty)
            {
                str2 = " style=\"color:" + sColor + "\" ";
            }
            if (!string.IsNullOrEmpty(Css))
            {
                str2 = str2 + Css;
                return ("<span" + str2 + ">" + Input + "</span>");
            }
            return Input;
        }

        public static string getResultPage(string _Content, DateTime _DateTime, string ClassID, string EName)
        {
            string str = "";
            if (_Content != string.Empty)
            {
                str = _Content.ToLower();
                string newValue = _DateTime.Year.ToString().PadRight(2);
                string str3 = _DateTime.Year.ToString();
                string str4 = _DateTime.Month.ToString();
                string str5 = _DateTime.Day.ToString();
                string str6 = _DateTime.Hour.ToString();
                string str7 = _DateTime.Minute.ToString();
                string str8 = _DateTime.Second.ToString();
                str = str.Replace("{@year02}", newValue).Replace("{@year04}", str3).Replace("{@month}", str4).Replace("{@day}", str5).Replace("{@second}", str8).Replace("{@minute}", str7).Replace("{@hour}", str6).Replace("{@ename}", EName);
                if (str.IndexOf("{@ram", 0) == -1)
                {
                    return str;
                }
                for (int i = 0; i <= 9; i++)
                {
                    str = str.Replace("{@ram" + i + "_0}", Rand.Number(i)).Replace("{@ram" + i + "_1}", Rand.Str_char(i)).Replace("{@ram" + i + "_2}", Rand.Str(i));
                }
            }
            return str;
        }

        public static bool PublishChPage(int ClassID, int ChID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string str2 = string.Empty;
                string rootPath = ServerInfo.GetRootPath();
                string strgTemplet = General.strgTemplet;
                string dirDumm = UIConfig.dirDumm;
                IDataReader singleCHPageClass = CommonData.DalPublish.GetSingleCHPageClass(ClassID);
                while (singleCHPageClass.Read())
                {
                    str2 = singleCHPageClass.GetString(0).Replace("/", @"\").ToLower().ToLower().Replace("{@dirtemplet}", strgTemplet);
                    Template template = new Template(rootPath.TrimEnd(new char[] { '\\' }) + str2, TempType.ChClass);
                    template.CHNewsID = 0;
                    template.CHClassID = ClassID;
                    template.ChID = ChID;
                    template.GetHTML();
                    template.ReplaceLabels();
                    string content = template.FinallyContent.Replace("{#Page_Title}", singleCHPageClass["ClassCName"].ToString()).Replace("{#Page_MetaKey}", singleCHPageClass["KeyMeta"].ToString()).Replace("{#Page_MetaDesc}", singleCHPageClass["DescMeta"].ToString()).Replace("{#Page_Content}", singleCHPageClass["PageContent"].ToString()).Replace("{#Page_Split}", "").Replace("{#Page_Navi}", "<a href=\"" + dirDumm + "/\">首页</a> >> " + singleCHPageClass["ClassCName"].ToString());
                    str = ((Public.readCHparamConfig("htmldir", ChID).Replace("{@dirHTML}", UIConfig.dirHtml) + "/" + singleCHPageClass["SavePath"].ToString()).Replace("//", "/").Trim(new char[] { '/' }) + "/" + singleCHPageClass["FileName"].ToString()).Replace("/", @"\");
                    str = Path.Combine(rootPath, str);
                    if (dirDumm.Trim() != string.Empty)
                    {
                        dirDumm = "/" + dirDumm;
                    }
                    WriteHtml(content, str);
                    flag = true;
                }
                singleCHPageClass.Close();
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成单页面,频道ID:" + ChID, string.Concat(new object[] { "【ClassID】:", ClassID, "\r\n【错误描述：】\r\n", exception.ToString() }), "");
                flag = false;
            }
            return flag;
        }

        public bool PublishCHSingleClass(int classID, int ChID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string str2 = string.Empty;
                string rootPath = ServerInfo.GetRootPath();
                string strgTemplet = General.strgTemplet;
                PubCHClassInfo cHClassById = CommonData.GetCHClassById(classID);
                if (cHClassById == null)
                {
                    return flag;
                }
                if (cHClassById.isDelPoint == 0)
                {
                    str2 = cHClassById.Templet.Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet);
                    Template tempRe = new Template(rootPath.Trim(new char[] { '\\' }) + str2, TempType.ChClass);
                    tempRe.CHClassID = classID;
                    tempRe.ChID = ChID;
                    tempRe.GetHTML();
                    string str5 = cHClassById.SavePath.Trim();
                    str = ((Public.readCHparamConfig("htmldir", ChID).Replace("{@dirHTML}", UIConfig.dirHtml) + "/" + str5).Replace("//", "/").Trim(new char[] { '/' }) + "/" + cHClassById.FileName.Trim()).Replace("/", @"\");
                    string savePath = Path.Combine(rootPath, str);
                    this.ReplaceTempg(tempRe, savePath, classID.ToString(), "class");
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成栏目,频道ID：" + ChID, "【classID】:" + classID.ToString() + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
            }
            return flag;
        }

        public static bool PublishCHSingleNews(int newsID, int classID, int ChID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string temppath = string.Empty;
                string str3 = ServerInfo.GetRootPath() + @"\";
                string strgTemplet = General.strgTemplet;
                IDataReader cHNewsSavePath = CommonData.DalPublish.GetCHNewsSavePath(newsID, ChID);
                while (cHNewsSavePath.Read())
                {
                    if (cHNewsSavePath["isDelPoint"].ToString() == "0")
                    {
                        temppath = cHNewsSavePath["templet"].ToString().Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet);
                        temppath = str3.Trim(new char[] { '\\' }) + temppath;
                        string str5 = Public.readCHparamConfig("htmldir", ChID).Replace("{@dirHTML}", UIConfig.dirHtml);
                        str = @"\" + str5.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + cHNewsSavePath["SavePath1"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + cHNewsSavePath["SavePath"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + cHNewsSavePath["FileName"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' });
                        Template template = new Template(temppath, TempType.ChNews);
                        template.CHNewsID = newsID;
                        template.CHClassID = classID;
                        template.ChID = ChID;
                        template.GetHTML();
                        template.ReplaceLabels();
                        string finallyContent = template.FinallyContent;
                        if (template.MyTempType == TempType.ChNews)
                        {
                            int index = finallyContent.IndexOf("<!-FS:STAR=");
                            int num2 = finallyContent.IndexOf("FS:END->");
                            if (index > -1)
                            {
                                int startIndex = str.LastIndexOf(".");
                                int num4 = str.LastIndexOf(@"\");
                                string fileName = str.Substring(num4 + 1, (startIndex - num4) - 1);
                                string eXName = str.Substring(startIndex);
                                string str9 = finallyContent.Substring(0, index);
                                string str10 = finallyContent.Substring(num2 + 8);
                                string[] strArray = finallyContent.Substring(index + 11, (num2 - index) - 11).Split(new string[] { "[FS:PAGE]" }, StringSplitOptions.RemoveEmptyEntries);
                                int length = strArray.Length;
                                for (int i = 0; i < length; i++)
                                {
                                    string filePath = str3 + str;
                                    if (i > 0)
                                    {
                                        int num7 = filePath.LastIndexOf('.');
                                        filePath = string.Concat(new object[] { filePath.Substring(0, num7), "_", i + 1, filePath.Substring(num7) });
                                    }
                                    string str13 = str9 + strArray[i] + str10;
                                    WriteHtml(ReplaceResultPage(cHNewsSavePath["id"].ToString(), str13.Replace("[FS:PAGE]", "").Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), fileName, eXName, length, i + 1, 0), filePath);
                                }
                            }
                            else
                            {
                                WriteHtml(finallyContent.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), str3 + str);
                            }
                        }
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                cHNewsSavePath.Close();
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成新闻(频道ID" + ChID + ")", "【ID】:" + newsID.ToString() + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                flag = false;
            }
            return flag;
        }

        public bool PublishCHSingleSpecial(int specialID, int ChID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string temppath = string.Empty;
                string str3 = ServerInfo.GetRootPath() + @"\";
                string strgTemplet = General.strgTemplet;
                PubCHSpecialInfo cHSpecial = CommonData.GetCHSpecial(specialID);
                if (cHSpecial != null)
                {
                    temppath = cHSpecial.templet.Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet);
                    string str5 = Public.readCHparamConfig("htmldir", ChID).Replace("{@dirHTML}", UIConfig.dirHtml);
                    temppath = str3.Trim(new char[] { '\\' }) + temppath;
                    str = string.Concat(new object[] { str5.Trim(new char[] { '\\' }).Trim(new char[] { '/' }), @"\", cHSpecial.savePath.Trim(new char[] { '\\' }).Trim(new char[] { '/' }), '\\', cHSpecial.filename });
                    Template tempRe = new Template(temppath, TempType.Chspecial);
                    tempRe.CHSpecialID = specialID;
                    tempRe.ChID = ChID;
                    tempRe.GetHTML();
                    tempRe.ReplaceLabels();
                    this.ReplaceTempg(tempRe, str3 + str, specialID.ToString(), "special");
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成专题,频道ID:" + ChID, string.Concat(new object[] { "【specialID】:", specialID, "\r\n【错误描述：】\r\n", exception.ToString() }), "");
            }
            return flag;
        }

        public static bool PublishCHXML(int ClassID, int ChID)
        {
            bool flag = false;
            try
            {
                object obj2;
                string str9;
                string str = ServerInfo.GetRootPath() + @"\";
                string str2 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
                str2 = (str2 + "<?xml-stylesheet type=\"text/css\" href=\"" + CommonData.SiteDomain + "/sysImages/css/rss.css\"?>\r\n") + "<rss version=\"2.0\">\r\n" + "<channel>\r\n";
                DataTable table = CommonData.DalPublish.GetLastCHNews(50, ClassID, ChID);
                string str3 = "none";
                string str4 = Public.readCHparamConfig("htmldir", ChID).Replace("{@dirHTML}", UIConfig.dirHtml);
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    return flag;
                }
                string str5 = ("/" + str4 + "/" + table.Rows[0]["savepath1"].ToString() + "/" + table.Rows[0]["fileName"].ToString()).Replace("//", "/");
                if (ClassID == 0)
                {
                    obj2 = str2 + "<title>最新RSS订阅</title>\r\n";
                    str2 = string.Concat(new object[] { obj2, "<link>", CommonData.SiteDomain, "/xml/channel/", ChID, "_index.xml</link>\r\n" });
                }
                else
                {
                    str9 = str2 + "<title>" + table.Rows[0]["ClassCName"].ToString() + "</title>\r\n";
                    str2 = str9 + "<link>" + CommonData.SiteDomain + str5.Replace("//", "/") + "</link>\r\n";
                }
                str2 = str2 + "<description>RSS订阅_by " + verConfig.Productversion + "</description>\r\n";
                str3 = table.Rows[0]["ClassEName"].ToString();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    obj2 = str2;
                    str2 = string.Concat(new object[] { obj2, "<item id=\"", i + 1, "\">\r\n" }) + "<title><![CDATA[" + table.Rows[i]["Title"].ToString() + "]]></title>\r\n";
                    string str6 = "/" + str4 + "/" + table.Rows[i]["savepath1"].ToString() + "/" + table.Rows[i]["SavePath"].ToString() + "/" + table.Rows[i]["FileName"].ToString();
                    str9 = str2;
                    str2 = str9 + "<link>" + CommonData.SiteDomain + str6.Replace("//", "/") + "</link>\r\n";
                    string str7 = table.Rows[i]["Content"].ToString();
                    if ((str7 != string.Empty) && (str7 != null))
                    {
                        str2 = str2 + "<description><![CDATA[" + Input.FilterHTML(Input.GetSubString(str7, 200)) + "]]></description>\r\n";
                    }
                    else
                    {
                        str2 = str2 + "<description><![CDATA[]]></description>\r\n";
                    }
                    str2 = (str2 + "<pubDate>" + table.Rows[i]["CreatTime"].ToString() + "</pubDate>\r\n") + "</item>\r\n";
                }
                str2 = str2 + "</channel>\r\n" + "</rss>\r\n";
                string path = string.Concat(new object[] { str, @"\xml\channel\", ChID, "_", table.Rows[0]["id1"].ToString(), ".xml" });
                if (ClassID == 0)
                {
                    path = string.Concat(new object[] { str, @"\xml\channel\", ChID, "_index.xml" });
                }
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.Write(str2);
                    writer.Dispose();
                }
                return true;
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成栏目XML,频道ID" + ChID, string.Concat(new object[] { "【ClassID】:", ClassID, "\r\n【错误描述：】\r\n", exception.ToString() }), "");
                return false;
            }
        }

        public static bool PublishClassIndex(string ClassID)
        {
            CommonData.Initialize();
            try
            {
                string str = ServerInfo.GetRootPath() + @"\";
                string dirPige = UIConfig.dirPige;
                string dirDumm = UIConfig.dirDumm;
                string dirTemplet = UIConfig.dirTemplet;
                PubClassInfo classById = CommonData.GetClassById(ClassID);
                if (classById != null)
                {
                    string str5 = classById.ClassTemplet.Replace("/", @"\").ToLower().ToLower().Replace("{@dirtemplet}", dirTemplet);
                    Template template = new Template(str.Trim(new char[] { '\\' }) + str5, TempType.Class);
                    template.NewsID = null;
                    template.ClassID = ClassID;
                    template.GetHTML();
                    template.ReplaceLabels();
                    string filePath = str + dirPige + @"\" + getResultPage(classById.ClassIndexRule, DateTime.Now, ClassID, classById.ClassEName) + @"\" + classById.ClassEName + ".html";
                    string str8 = ("<span style=\"text-align:center;\" id=\"gPtypenowdiv" + DateTime.Now.ToShortDateString() + "\">加载中...</span>") + "<script language=\"javascript\" type=\"text/javascript\">";
                    string newValue = (str8 + "pubajax('" + CommonData.SiteDomain + "/configuration/system/public.aspx','NowStr=" + DateTime.Now.ToShortDateString() + "&ruleStr=1','gPtypenowdiv" + DateTime.Now.ToShortDateString() + "');") + "</script>";
                    WriteHtml(template.FinallyContent.Replace("{Foosun:NewsLIST}", "").Replace("{/Foosun:NewsLIST}", "").Replace("{$FS:P1}", newValue), filePath);
                }
                return true;
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成索引", "【ClassID】:" + ClassID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                return false;
            }
        }

        public static bool PublishHistryIndex(int Numday)
        {
            try
            {
                string str = ServerInfo.GetRootPath() + @"\";
                string dirPige = UIConfig.dirPige;
                string dirDumm = UIConfig.dirDumm;
                string dirTemplet = UIConfig.dirTemplet;
                if (dirDumm.Trim() != string.Empty)
                {
                    dirDumm = "/" + dirDumm;
                }
                DataTable history = CommonData.DalPublish.Gethistory(Numday);
                string str5 = "/{@dirtemplet}/Content/indexPage.html";
                str5 = str5.Replace("/", @"\").ToLower().ToLower().Replace("{@dirtemplet}", dirTemplet);
                Template template = new Template(str.Trim(new char[] { '\\' }) + str5, TempType.Index);
                template.GetHTML();
                template.ReplaceLabels();
                string finallyContent = template.FinallyContent;
                string newValue = "";
                string str8 = "";
                string filePath = "";
                if ((history != null) && (history.Rows.Count > 0))
                {
                    for (int i = 0; i < history.Rows.Count; i++)
                    {
                        if (history.Rows[i]["NewsType"].ToString() == "2")
                        {
                            str8 = history.Rows[i]["URLaddress"].ToString();
                        }
                        else
                        {
                            str8 = dirDumm + "/history-" + history.Rows[i]["newsid"].ToString() + UIConfig.extensions;
                        }
                        str8 = str8.Replace("//", "/");
                        string str10 = newValue;
                        newValue = str10 + "<li><a href=\"" + str8 + "\">" + history.Rows[i]["NewsTitle"].ToString() + "</a></li>";
                    }
                    finallyContent = finallyContent.Replace("{#history_list}", newValue).Replace("{#history_PageTitle}", "历史查询__" + DateTime.Now.AddDays((double) -Numday).ToShortDateString());
                    filePath = str + dirPige + @"\" + getResultPage(Public.readparamConfig("SaveIndexPage"), DateTime.Now.AddDays((double) -Numday), "", "history") + @"\index.html";
                    history.Clear();
                    history.Dispose();
                    WriteHtml(finallyContent, filePath);
                    return true;
                }
                finallyContent = finallyContent.Replace("{#history_list}", "今天没有归档新闻").Replace("{#history_PageTitle}", "历史查询__" + DateTime.Now.AddDays((double) -Numday).ToShortDateString());
                filePath = str + dirPige + @"\" + getResultPage(Public.readparamConfig("SaveIndexPage"), DateTime.Now.AddDays((double) -Numday), "", "history") + @"\index.html";
                history.Clear();
                history.Dispose();
                WriteHtml(finallyContent, filePath);
                return true;
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成历史文档", "【错误描述：】\r\n" + exception.ToString(), "");
                return false;
            }
        }

        public static bool PublishPage(string ClassID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string temppath = string.Empty;
                string str3 = ServerInfo.GetRootPath() + @"\";
                string strgTemplet = General.strgTemplet;
                string dirDumm = UIConfig.dirDumm;
                IDataReader singlePageClass = CommonData.DalPublish.GetSinglePageClass(ClassID);
                string content = string.Empty;
                while (singlePageClass.Read())
                {
                    Template template;
                    if ((singlePageClass["ClassTemplet"] == DBNull.Value) || (singlePageClass["ClassTemplet"].ToString().Trim() == ""))
                    {
                        content = singlePageClass["PageContent"].ToString().Replace("{#Page_Navi}", "<a href=\"" + dirDumm + "/\">首页</a> >> " + singlePageClass["ClassCName"].ToString());
                        str = singlePageClass["SavePath"].ToString();
                        WriteHtml(content, str3 + str);
                        template = new Template(str3 + str, TempType.Class);
                        template.NewsID = null;
                        template.ClassID = ClassID;
                        template.GetHTML();
                        template.ReplaceLabels();
                        WriteHtml(template.FinallyContent, str3 + str);
                    }
                    else
                    {
                        temppath = singlePageClass.GetString(0).Replace("/", @"\").ToLower().ToLower().Replace("{@dirtemplet}", strgTemplet);
                        temppath = str3.Trim(new char[] { '\\' }) + temppath;
                        str = singlePageClass["SavePath"].ToString();
                        template = new Template(temppath, TempType.Class);
                        template.NewsID = null;
                        template.ClassID = ClassID;
                        template.GetHTML();
                        template.ReplaceLabels();
                        content = template.FinallyContent.Replace("{#Page_Title}", singlePageClass["ClassCName"].ToString()).Replace("{#Page_MetaKey}", singlePageClass["MetaKeywords"].ToString()).Replace("{#Page_MetaDesc}", singlePageClass["MetaDescript"].ToString()).Replace("{#Page_Navi}", "<a href=\"" + dirDumm + "/\">首页</a> >> " + singlePageClass["ClassCName"].ToString());
                        int index = content.IndexOf("{#Page_Content}", 0);
                        string str7 = string.Empty;
                        string str8 = string.Empty;
                        if (index <= 0)
                        {
                            str7 = content;
                            str8 = content;
                        }
                        else
                        {
                            str7 = content.Substring(0, index);
                            str8 = content.Substring(index + "{#Page_Content}".Length, (content.Length - str7.Length) - "{#Page_Content}".Length);
                            content = content.Replace("{#Page_Content}", singlePageClass["PageContent"].ToString());
                        }
                        content = content.Replace("{#Page_Content}", singlePageClass["PageContent"].ToString());
                        if (dirDumm.Trim() != string.Empty)
                        {
                            dirDumm = "/" + dirDumm;
                        }
                        int startIndex = str.LastIndexOf(".");
                        int num3 = str.LastIndexOf(@"\");
                        string str9 = str.Substring(num3 + 1, (startIndex - num3) - 1);
                        string str10 = str.Substring(startIndex);
                        string input = singlePageClass["PageContent"].ToString();
                        input = new Regex(@"(\[FS:PAGE=(?<p>[\s\S]+?)\$\])|(\[FS:PAGE\])", RegexOptions.IgnoreCase).Replace(input, "[FS:PAGE]");
                        string[] strArray = Regex.Split(input, @"\[FS:PAGE\]", RegexOptions.IgnoreCase);
                        int pageCount = 0;
                        if (strArray != null)
                        {
                            pageCount = strArray.Length;
                        }
                        string fileName = null;
                        string eXName = null;
                        for (int i = 0; i < pageCount; i++)
                        {
                            string filePath = str3 + str;
                            fileName = str.Substring(str.LastIndexOf('/'), str.Length - str.LastIndexOf('/'));
                            fileName = fileName.Substring(1, fileName.IndexOf('.') - 1);
                            eXName = str.Substring(str.LastIndexOf('.'), str.Length - str.LastIndexOf('.'));
                            int length = filePath.LastIndexOf('.');
                            if (i == 0)
                            {
                                filePath = filePath.Substring(0, length) + filePath.Substring(length);
                            }
                            else
                            {
                                filePath = string.Concat(new object[] { filePath.Substring(0, length), "_", i + 1, filePath.Substring(length) });
                            }
                            string str15 = str7;
                            if (index > 0)
                            {
                                str15 = str7 + strArray[i] + str8;
                            }
                            WriteHtml(ReplacePageLink(str15, fileName, eXName, pageCount, i + 1), filePath);
                        }
                        if (pageCount == 0)
                        {
                            WriteHtml(input, str3 + str);
                        }
                    }
                    flag = true;
                }
                singlePageClass.Close();
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成单页面", "【ClassID】:" + ClassID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                flag = false;
            }
            return flag;
        }

        public bool PublishSingleClass(string classID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string temppath = string.Empty;
                string rootPath = ServerInfo.GetRootPath();
                string strgTemplet = General.strgTemplet;
                PubClassInfo classById = CommonData.GetClassById(classID);
                if (classById == null)
                {
                    return flag;
                }
                if (classById.isDelPoint != 0)
                {
                    return flag;
                }
                temppath = classById.ClassTemplet.Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet);
                temppath = rootPath.Trim(new char[] { '\\' }) + temppath;
                string str5 = classById.SavePath.Trim();
                if (str5.Substring(0, 1) != "/")
                {
                    str5 = @"\" + str5;
                }
                str = string.Concat(new object[] { str5, @"\", classById.SaveClassframe, '\\', classById.ClassSaveRule.Trim() }).Replace("/", @"\\");
                Template tempRe = new Template(temppath, TempType.Class);
                tempRe.ClassID = classID;
                tempRe.GetHTML();
                string savePath = rootPath + str;
                this.ReplaceTempg(tempRe, savePath, classID, "class");
                flag = true;
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成栏目", "【classID】:" + classID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
            }
            return flag;
        }

        public static bool PublishSingleNews(string newsID, string classID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                Foosun.Model.News news = CommonData.getNewsInfoById(newsID);
                string str = string.Empty;
                string temppath = string.Empty;
                string str3 = ServerInfo.GetRootPath() + @"\";
                string strgTemplet = General.strgTemplet;
                IDataReader newsSavePath = CommonData.DalPublish.GetNewsSavePath(newsID);
                while (newsSavePath.Read())
                {
                    if (newsSavePath["isDelPoint"].ToString() == "0")
                    {
                        temppath = newsSavePath["templet"].ToString().Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet);
                        temppath = str3.Trim(new char[] { '\\' }) + temppath;
                        str = @"\" + newsSavePath["SavePath1"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + newsSavePath["SaveClassframe"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + newsSavePath["SavePath"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + newsSavePath["FileName"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + newsSavePath["FileEXName"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' });
                        Template template = new Template(temppath, TempType.News);
                        template.NewsID = newsID;
                        template.ClassID = classID;
                        template.GetHTML();
                        template.IsContent = (news != null) && (news.CommTF == 1);
                        template.ReplaceLabels();
                        string finallyContent = template.FinallyContent;
                        if (template.MyTempType == TempType.News)
                        {
                            int index = finallyContent.IndexOf("<!-FS:STAR=");
                            int num2 = finallyContent.IndexOf("FS:END->");
                            if (index > -1)
                            {
                                int startIndex = str.LastIndexOf(".");
                                int num4 = str.LastIndexOf(@"\");
                                string fileName = str.Substring(num4 + 1, (startIndex - num4) - 1);
                                string eXName = str.Substring(startIndex);
                                string str8 = finallyContent.Substring(0, index);
                                string str9 = finallyContent.Substring(num2 + 8);
                                string input = finallyContent.Substring(index + 11, (num2 - index) - 11);
                                Regex regex = new Regex(@"(\[FS:PAGE=(?<p>[\s\S]+?)\$\])|(\[FS:PAGE\])", RegexOptions.IgnoreCase);
                                string[] strArray = Regex.Split(regex.Replace(input, "[FS:PAGE]"), @"\[FS:PAGE\]", RegexOptions.IgnoreCase);
                                int length = strArray.Length;
                                for (int i = 0; i < length; i++)
                                {
                                    string filePath = str3 + str;
                                    if (i > 0)
                                    {
                                        int num7 = filePath.LastIndexOf('.');
                                        filePath = string.Concat(new object[] { filePath.Substring(0, num7), "_", i + 1, filePath.Substring(num7) });
                                    }
                                    string str12 = str8 + strArray[i] + str9;
                                    str12 = regex.Replace(str12, "");
                                    WriteHtml(ReplaceResultPage(newsSavePath["NewsID"].ToString(), str12.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), fileName, eXName, length, i + 1, 0), filePath);
                                }
                            }
                            else
                            {
                                WriteHtml(finallyContent.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), str3 + str);
                            }
                        }
                        if (CommonData.DalPublish.updateIsHtmlState(newsID) > 0)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                newsSavePath.Close();
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成新闻", "【NewsID】:" + newsID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                flag = false;
            }
            return flag;
        }

        public static bool PublishSingleNews(string newsID, string classID, bool isContent)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string temppath = string.Empty;
                string str3 = ServerInfo.GetRootPath() + @"\";
                string strgTemplet = General.strgTemplet;
                IDataReader newsSavePath = CommonData.DalPublish.GetNewsSavePath(newsID);
                while (newsSavePath.Read())
                {
                    if (newsSavePath["isDelPoint"].ToString() == "0")
                    {
                        if (newsSavePath["CheckStat"].ToString().IndexOf("0|0|0") >= 0)
                        {
                            temppath = newsSavePath["templet"].ToString().Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet);
                            temppath = str3.Trim(new char[] { '\\' }) + temppath;
                            str = @"\" + newsSavePath["SavePath1"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + newsSavePath["SaveClassframe"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + newsSavePath["SavePath"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + newsSavePath["FileName"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + newsSavePath["FileEXName"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' });
                            Template template = new Template(temppath, TempType.News);
                            template.NewsID = newsID;
                            template.ClassID = classID;
                            template.IsContent = isContent;
                            template.GetHTML();
                            template.ReplaceLabels();
                            string finallyContent = template.FinallyContent;
                            if (template.MyTempType == TempType.News)
                            {
                                int index = finallyContent.IndexOf("<!-FS:STAR=");
                                int num2 = finallyContent.IndexOf("FS:END->");
                                if (index > -1)
                                {
                                    int startIndex = str.LastIndexOf(".");
                                    int num4 = str.LastIndexOf(@"\");
                                    string fileName = str.Substring(num4 + 1, (startIndex - num4) - 1);
                                    string eXName = str.Substring(startIndex);
                                    string str8 = finallyContent.Substring(0, index);
                                    string str9 = finallyContent.Substring(num2 + 8);
                                    string input = finallyContent.Substring(index + 11, (num2 - index) - 11);
                                    Regex regex = new Regex(@"(\[FS:PAGE=(?<p>[\s\S]+?)\$\])|(\[FS:PAGE\])", RegexOptions.IgnoreCase);
                                    string[] strArray = Regex.Split(regex.Replace(input, "[FS:PAGE]"), @"\[FS:PAGE\]", RegexOptions.IgnoreCase);
                                    int length = strArray.Length;
                                    for (int i = 0; i < length; i++)
                                    {
                                        string filePath = str3 + str;
                                        if (i > 0)
                                        {
                                            int num7 = filePath.LastIndexOf('.');
                                            filePath = string.Concat(new object[] { filePath.Substring(0, num7), "_", i + 1, filePath.Substring(num7) });
                                        }
                                        string str12 = str8 + strArray[i] + str9;
                                        str12 = regex.Replace(str12, "");
                                        WriteHtml(ReplaceResultPage(newsSavePath["NewsID"].ToString(), str12.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), fileName, eXName, length, i + 1, 0), filePath);
                                    }
                                }
                                else
                                {
                                    WriteHtml(finallyContent.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), str3 + str);
                                }
                            }
                            if (CommonData.DalPublish.updateIsHtmlState(newsID) > 0)
                            {
                                flag = true;
                            }
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                newsSavePath.Close();
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成新闻", "【NewsID】:" + newsID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                flag = false;
            }
            return flag;
        }

        public bool PublishSingleSpecial(string specialID)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string temppath = string.Empty;
                string str3 = ServerInfo.GetRootPath() + @"\";
                string strgTemplet = General.strgTemplet;
                PubSpecialInfo special = CommonData.GetSpecial(specialID);
                if (special == null)
                {
                    return flag;
                }
                if (special.isDelPoint == 0)
                {
                    temppath = special.Templet.Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet.ToLower());
                    temppath = str3.Trim(new char[] { '\\' }) + temppath;
                    str = string.Concat(new object[] { @"\", special.SavePath.Trim(new char[] { '\\' }).Trim(new char[] { '/' }), @"\", special.saveDirPath.Trim(new char[] { '\\' }).Trim(new char[] { '/' }), '\\', special.FileName, special.FileEXName });
                    Template tempRe = new Template(temppath, TempType.Special);
                    tempRe.SpecialID = specialID;
                    tempRe.GetHTML();
                    tempRe.ReplaceLabels();
                    this.ReplaceTempg(tempRe, str3 + str, specialID, "special");
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成专题", "【specialID】:" + specialID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
            }
            return flag;
        }

        public static bool PublishXML(string ClassID)
        {
            bool flag = false;
            try
            {
                string str = ServerInfo.GetRootPath() + @"\";
                string str2 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
                str2 = (str2 + "<?xml-stylesheet type=\"text/css\" href=\"" + CommonData.SiteDomain + "/sysImages/css/rss.css\"?>\r\n") + "<rss version=\"2.0\">\r\n" + "<channel>\r\n";
                DataTable lastNews = CommonData.DalPublish.GetLastNews(50, ClassID);
                string str3 = "none";
                string str4 = "";
                Regex regex = new Regex("<[^>]*>");
                if ((lastNews == null) || (lastNews.Rows.Count <= 0))
                {
                    return flag;
                }
                string str5 = string.Concat(new object[] { "/", lastNews.Rows[0]["savepath1"].ToString(), "/", lastNews.Rows[0]["SaveClassframe"].ToString(), "/", lastNews.Rows[0]["ClassSaveRule"] });
                if (ClassID == "0")
                {
                    str4 = (str4 + "<title>最新RSS订阅</title>\r\n") + "<link>" + GetDNSUrl() + "/xml/Content/all/news.xml</link>\r\n";
                }
                else
                {
                    string str9 = str4 + "<title>" + lastNews.Rows[0]["ClassCName"].ToString() + "</title>\r\n";
                    str4 = str9 + "<link>" + GetDNSUrl() + str5.Replace("//", "/") + "</link>\r\n";
                }
                str4 = str4 + "<description>RSS订阅_by " + verConfig.Productversion + "</description>\r\n";
                str3 = lastNews.Rows[0]["ClassEName"].ToString();
                Regex regex2 = new Regex(@"(\[FS:PAGE=(?<p>[\s\S]+?)\$\])|(\[FS:PAGE\])", RegexOptions.IgnoreCase);
                for (int i = 0; i < lastNews.Rows.Count; i++)
                {
                    object obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, "<item id=\"", i + 1, "\">\r\n" }) + "<title><![CDATA[" + lastNews.Rows[i]["NewsTitle"].ToString() + "]]></title>\r\n";
                    string str6 = GetNewsURL("", lastNews.Rows[i]["NewsType"].ToString(), lastNews.Rows[i]["isDelPoint"].ToString(), lastNews.Rows[i]["NewsID"].ToString(), lastNews.Rows[i]["SavePath"].ToString(), lastNews.Rows[i]["savepath1"].ToString(), lastNews.Rows[i]["SaveClassframe"].ToString(), lastNews.Rows[i]["FileName"].ToString(), lastNews.Rows[i]["FileEXName"].ToString(), lastNews.Rows[i]["URLaddress"].ToString());
                    str4 = str4 + "<link>" + str6 + "</link>\r\n";
                    string input = lastNews.Rows[i]["Content"].ToString();
                    if ((input != string.Empty) && (input != null))
                    {
                        input = regex.Replace(input, "");
                        input = regex2.Replace(input, "");
                        str4 = str4 + "<description><![CDATA[" + Input.FilterHTML(Input.GetSubString(input, 200)) + "]]></description>\r\n";
                    }
                    else
                    {
                        str4 = str4 + "<description><![CDATA[]]></description>\r\n";
                    }
                    str4 = (str4 + "<pubDate>" + lastNews.Rows[i]["CreatTime"].ToString() + "</pubDate>\r\n") + "</item>\r\n";
                }
                str2 = (str2 + str4) + "</channel>\r\n" + "</rss>\r\n";
                string path = str + @"\xml\Content\" + str3 + ".xml";
                if (ClassID == "0")
                {
                    path = str + @"\xml\Content\all\news.xml";
                }
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.Write(str2);
                    writer.Dispose();
                }
                return true;
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成栏目XML", "【ClassID】:" + ClassID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                return false;
            }
        }

        public static string ReadHtml(string Path)
        {
            string str = string.Empty;
            if (File.Exists(Path))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(Path))
                    {
                        str = reader.ReadToEnd();
                        reader.Close();
                    }
                    return str;
                }
                catch
                {
                }
                return str;
            }
            return "模板不存在!";
        }

        private static string ReplacePageLink(string content, string fileName, string EXName, int PageCount, int CurrentPage)
        {
            string enableAutoPage = UIConfig.enableAutoPage;
            if (!(!string.IsNullOrEmpty(enableAutoPage) && bool.Parse(enableAutoPage)))
            {
                return content.Replace("{#Page_Split}", "");
            }
            string str2 = Public.readparamConfig("PageLinkCount");
            if (string.IsNullOrEmpty(str2))
            {
                str2 = "10";
            }
            string str3 = Public.readparamConfig("PageStyle");
            if (str3 == "4")
            {
                str3 = "0";
            }
            string newValue = null;
            newValue = GetPageLinkTextStr(str3, CurrentPage, PageCount, Convert.ToInt32(str2), fileName, EXName);
            content = content.Replace("{#Page_Split}", newValue);
            return content;
        }

        public static string ReplaceResultPage(string NewsID, string Content, string FileName, string EXName, int PageCount, int CurrentPage, int isPop)
        {
            string str = Public.readparamConfig("PageStyle");
            string str2 = Public.readparamConfig("PageLinkCount");
            if (string.IsNullOrEmpty(str2))
            {
                str2 = "10";
            }
            if (((((str == "0") || (str == "1")) || (str == "2")) || (str == "3")) && (Content.IndexOf("{#PageStyleSolid}") > -1))
            {
                if (PageCount <= 1)
                {
                    Content = Content.Replace("{#PageStyleSolid}", "");
                }
                else
                {
                    string str3;
                    if (isPop == 1)
                    {
                        str3 = GetPageLinkTextStrPage(str, CurrentPage, PageCount, Convert.ToInt16(str2), FileName, EXName);
                    }
                    else
                    {
                        str3 = GetPageLinkTextStr(str, CurrentPage, PageCount, Convert.ToInt16(str2), FileName, EXName);
                    }
                    Content = Content.Replace("{#PageStyleSolid}", str3);
                }
                Content = Content.Replace("{#PageStartLink}", "");
                Content = Content.Replace("{#PagePreLink}", "");
                Content = Content.Replace("{#PageNextLink}", "");
                Content = Content.Replace("{#PageEndLink}", "");
                Content = Content.Replace("{#PageCurrentNews}", "");
                Content = Content.Replace("{#PageCount}", "");
                Content = Content.Replace("{#PageCurrentNews}", "");
                Content = Content.Replace("{#PagePreTenLink}", "");
                Content = Content.Replace("{#PageNextTenLink}", "");
                return Content;
            }
            string chineseNumber = GetChineseNumber(Convert.ToInt16(str2));
            string str6 = Public.readparamConfig("ReviewType");
            if (Content.IndexOf("{#PageStartLink}") > -1)
            {
                if (CurrentPage == 1)
                {
                    Content = Content.Replace("{#PageStartLink}", "首页");
                }
                else if (str6 == "1")
                {
                    Content = Content.Replace("{#PageStartLink}", "<a href='Content-" + NewsID + UIConfig.extensions + "'>首页</a>");
                }
                else if (isPop == 1)
                {
                    Content = Content.Replace("{#PageStartLink}", "<a href='Content-" + NewsID + UIConfig.extensions + "'>首页</a>");
                }
                else
                {
                    Content = Content.Replace("{#PageStartLink}", string.Format("<a href='{0}'>首页</a>", FileName + EXName));
                }
            }
            if (Content.IndexOf("{#PageEndLink}") > -1)
            {
                if (CurrentPage == PageCount)
                {
                    Content = Content.Replace("{#PageEndLink}", "末页");
                }
                else if (str6 == "1")
                {
                    Content = Content.Replace("{#PageEndLink}", string.Concat(new object[] { "<a href='Content-", NewsID, "-", PageCount, UIConfig.extensions, "'>末页</a>" }));
                }
                else if (isPop == 1)
                {
                    Content = Content.Replace("{#PageStartLink}", string.Concat(new object[] { "<a href='Content-", NewsID, "-", PageCount, UIConfig.extensions, "'>末页</a>" }));
                }
                else
                {
                    Content = Content.Replace("{#PageEndLink}", string.Format("<a href='{0}'>末页</a>", string.Concat(new object[] { FileName, "_", PageCount, EXName })));
                }
            }
            if (Content.IndexOf("{#PagePreLink}") > -1)
            {
                if (CurrentPage == 1)
                {
                    Content = Content.Replace("{#PagePreLink}", "上一页");
                }
                else if (CurrentPage <= 2)
                {
                    if (str6 == "1")
                    {
                        Content = Content.Replace("{#PagePreLink}", "<a href='Content-" + NewsID + UIConfig.extensions + "'>上一页</a>");
                    }
                    else if (isPop == 1)
                    {
                        Content = Content.Replace("{#PagePreLink}", "<a href='Content-" + NewsID + UIConfig.extensions + "'>上一页</a>");
                    }
                    else
                    {
                        Content = Content.Replace("{#PagePreLink}", string.Format("<a href='{0}'>上一页</a>", FileName + EXName));
                    }
                }
                else if (str6 == "1")
                {
                    Content = Content.Replace("{#PagePreLink}", string.Concat(new object[] { "<a href='Content-", NewsID, "-", CurrentPage - 1, UIConfig.extensions, "'>上一页</a>" }));
                }
                else if (isPop == 1)
                {
                    Content = Content.Replace("{#PagePreLink}", string.Concat(new object[] { "Content-", NewsID, "-", CurrentPage - 1, UIConfig.extensions, "'>上一页</a>" }));
                }
                else
                {
                    Content = Content.Replace("{#PagePreLink}", string.Format("<a href='{0}'>上一页</a>", string.Concat(new object[] { FileName, "_", CurrentPage - 1, EXName })));
                }
            }
            if (Content.IndexOf("{#PageNextLink}") > -1)
            {
                if (CurrentPage == PageCount)
                {
                    Content = Content.Replace("{#PageNextLink}", "下一页");
                }
                else if (str6 == "1")
                {
                    Content = Content.Replace("{#PageNextLink}", string.Format("<a href='{0}'>下一页</a>", string.Concat(new object[] { "Content-", NewsID, "-", CurrentPage + 1, UIConfig.extensions })));
                }
                else if (isPop == 1)
                {
                    Content = Content.Replace("{#PageNextLink}", string.Format("<a href='{0}'>下一页</a>", string.Concat(new object[] { "Content-", NewsID, "-", CurrentPage + 1, UIConfig.extensions })));
                }
                else
                {
                    Content = Content.Replace("{#PageNextLink}", string.Format("<a href='{0}'>下一页</a>", string.Concat(new object[] { FileName, "_", CurrentPage + 1, EXName })));
                }
            }
            if (Content.IndexOf("{#PagePreTenLink}") > -1)
            {
                if (CurrentPage == 1)
                {
                    Content = Content.Replace("{#PagePreTenLink}", "上" + chineseNumber + "页");
                }
                else if (CurrentPage < 10)
                {
                    if (str6 == "1")
                    {
                        Content = Content.Replace("{#PagePreTenLink}", string.Format("<a href='{0}'>上" + chineseNumber + "页</a>", "Content-" + NewsID + UIConfig.extensions));
                    }
                    else if (isPop == 1)
                    {
                        Content = Content.Replace("{#PagePreTenLink}", string.Format("<a href='{0}'>上" + chineseNumber + "页</a>", "Content-" + NewsID + UIConfig.extensions));
                    }
                    else
                    {
                        Content = Content.Replace("{#PagePreTenLink}", string.Format("<a href='{0}'>上" + chineseNumber + "页</a>", FileName + EXName));
                    }
                }
                else if (str6 == "1")
                {
                    Content = Content.Replace("{#PagePreTenLink}", string.Format("<a href='{0}'>上" + chineseNumber + "页</a>", string.Concat(new object[] { "Content-", NewsID, "-", CurrentPage - 10, UIConfig.extensions })));
                }
                else if (isPop == 1)
                {
                    Content = Content.Replace("{#PagePreTenLink}", string.Format("<a href='{0}'>上" + chineseNumber + "页</a>", string.Concat(new object[] { "Content-", NewsID, "-", CurrentPage - 10, UIConfig.extensions })));
                }
                else
                {
                    Content = Content.Replace("{#PagePreTenLink}", string.Format("<a href='{0}'>上" + chineseNumber + "页</a>", string.Concat(new object[] { FileName, "_", CurrentPage - 10, EXName })));
                }
            }
            if (Content.IndexOf("{#PageNextTenLink}") > -1)
            {
                if (CurrentPage == PageCount)
                {
                    Content = Content.Replace("{#PageNextTenLink}", "下" + chineseNumber + "页");
                }
                else if ((CurrentPage + 10) > PageCount)
                {
                    if (str6 == "1")
                    {
                        Content = Content.Replace("{#PageNextTenLink}", string.Format("<a href='{0}'>下" + chineseNumber + "页</a>", string.Concat(new object[] { "Content-", NewsID, "-", PageCount, UIConfig.extensions })));
                    }
                    else if (isPop == 1)
                    {
                        Content = Content.Replace("{#PageNextTenLink}", string.Format("<a href='{0}'>下" + chineseNumber + "页</a>", string.Concat(new object[] { "Content-", NewsID, "-", PageCount, UIConfig.extensions })));
                    }
                    else
                    {
                        Content = Content.Replace("{#PageNextTenLink}", string.Format("<a href='{0}'>下" + chineseNumber + "页</a>", string.Concat(new object[] { FileName, "_", PageCount, EXName })));
                    }
                }
                else if (str6 == "1")
                {
                    Content = Content.Replace("{#PageNextTenLink}", string.Format("<a href='{0}'>下" + chineseNumber + "页</a>", string.Concat(new object[] { "Content-", NewsID, "-", CurrentPage + 10, UIConfig.extensions })));
                }
                else if (isPop == 1)
                {
                    Content = Content.Replace("{#PageNextTenLink}", string.Format("<a href='{0}'>下" + chineseNumber + "页</a>", string.Concat(new object[] { "Content-", NewsID, "-", CurrentPage + 10, UIConfig.extensions })));
                }
                else
                {
                    Content = Content.Replace("{#PageNextTenLink}", string.Format("<a href='{0}'>下" + chineseNumber + "页</a>", string.Concat(new object[] { FileName, "_", CurrentPage + 10, EXName })));
                }
            }
            if (Content.IndexOf("{#PageCount}") > -1)
            {
                Content = Content.Replace("{#PageCount}", string.Format("共{0}页", PageCount));
            }
            if (Content.IndexOf("{#PageCurrentNews}") > -1)
            {
                Content = Content.Replace("{#PageCurrentNews}", string.Format("第{0}页", CurrentPage));
            }
            if ((Content.IndexOf("{#NewsPage:Loop") > -1) && (Content.IndexOf("{/@NewsPage:Loop}") > -1))
            {
            }
            Content = new Regex("<a[^>]+href=(\\\"|\\')?javascript:void\\(0\\)\\;(\\\"|\\')?[^>]*>[^<]*<\\/a>").Replace(Content, "");
            return Content;
        }

        public void ReplaceTempg(Template tempRe, string savePath, string id, string ContentType)
        {
            tempRe.ReplaceLabels();
            savePath = savePath.Replace("/", @"\\");
            savePath = savePath.Replace(@"\\\\", @"\\");
            if ((((tempRe.MyTempType == TempType.Class) || (tempRe.MyTempType == TempType.Special)) || (tempRe.MyTempType == TempType.ChClass)) || (tempRe.MyTempType == TempType.Chspecial))
            {
                string finallyContent = tempRe.FinallyContent;
                string currentSytle = "";
                string otherStyle = "";
                string pattern = @"\{FS\:PageLinksStyle=\w+\|\w+\}";
                Regex regex = new Regex(pattern, RegexOptions.Compiled);
                string str5 = regex.Match(finallyContent).Value;
                int index = finallyContent.IndexOf(str5);
                finallyContent = finallyContent.Substring(0, index) + finallyContent.Substring(index + str5.Length, finallyContent.Length - (finallyContent.IndexOf(str5) + str5.Length));
                tempRe.FinallyContent = finallyContent;
                pattern = @"[^=]\w+\|\w+[^\}]";
                regex = new Regex(pattern, RegexOptions.Compiled);
                str5 = regex.Match(str5).Value;
                string[] strArray = null;
                if (!string.IsNullOrEmpty(str5))
                {
                    strArray = str5.Split(new char[] { '|' });
                    currentSytle = strArray[0];
                    otherStyle = strArray[1];
                }
                int length = finallyContent.IndexOf("{Foosun:NewsLIST}");
                int num3 = finallyContent.IndexOf("{/Foosun:NewsLIST}");
                string filePath = savePath;
                string str7 = savePath;
                if ((num3 > length) && (length > -1))
                {
                    int startIndex = savePath.LastIndexOf(".");
                    int num5 = savePath.LastIndexOf(@"\");
                    string getFileName = savePath.Substring(num5 + 1, (startIndex - num5) - 1);
                    string getFileEXName = savePath.Substring(startIndex);
                    string str10 = finallyContent.Substring(0, length);
                    string str11 = finallyContent.Substring(num3 + 0x12);
                    string input = finallyContent.Substring(length + 0x11, (num3 - length) - 0x11);
                    string str13 = @"\{\$FS\:P[01]\}\{Page\:\d\$[^\$]{0,6}\$[^\$]{0,20}\}";
                    Regex regex2 = new Regex(str13, RegexOptions.Compiled);
                    Match match2 = regex2.Match(input);
                    if (match2.Success && (((verConfig.PublicType == "0") || (tempRe.MyTempType == TempType.ChClass)) || (tempRe.MyTempType == TempType.Chspecial)))
                    {
                        string str14 = match2.Value;
                        int num6 = str14.IndexOf("}{Page:");
                        string[] strArray2 = str14.Substring(num6 + 7).TrimEnd(new char[] { '}' }).Split(new char[] { '$' });
                        string numstr = strArray2[0];
                        string str17 = strArray2[1];
                        string str18 = strArray2[2];
                        string str19 = "";
                        if (str18.Trim() != string.Empty)
                        {
                            str19 = " class=\"" + str18 + "\"";
                        }
                        string[] strArray3 = regex2.Split(input);
                        int n = strArray3.Length;
                        if ((strArray3[n - 1] == null) || (strArray3[n - 1].Trim() == string.Empty))
                        {
                            n--;
                        }
                        for (int i = 0; i < n; i++)
                        {
                            string str20 = "";
                            if (i > 0)
                            {
                                int num9 = str7.LastIndexOf('.');
                                filePath = string.Concat(new object[] { str7.Substring(0, num9), "_", i + 1, str7.Substring(num9) });
                            }
                            str20 = new UltiPublish(true).GetPagelist(numstr, i, getFileName, getFileEXName, str17, str19, n, id, ContentType, 0, currentSytle, otherStyle);
                            string content = str10 + strArray3[i] + str20 + str11;
                            if (content.IndexOf("{PageLists}") > 0)
                            {
                                content = (str10 + strArray3[i] + str11).Replace("{PageLists}", str20);
                            }
                            WriteHtml(content, filePath);
                        }
                        if (n > 0)
                        {
                            return;
                        }
                    }
                }
            }
            string str23 = ("<span style=\"text-align:center;\" id=\"gPtypenowdiv" + DateTime.Now.ToShortDateString() + "\">加载中...</span>") + "<script language=\"javascript\" type=\"text/javascript\">";
            string newValue = (str23 + "pubajax('" + CommonData.SiteDomain + "/configuration/system/public.aspx','NowStr=" + DateTime.Now.ToShortDateString() + "&ruleStr=1','gPtypenowdiv" + DateTime.Now.ToShortDateString() + "');") + "</script>";
            WriteHtml(tempRe.FinallyContent.Replace("{Foosun:NewsLIST}", "").Replace("{/Foosun:NewsLIST}", "").Replace("{PageLists}", "").Replace("{$FS:P1}", newValue), savePath);
        }

        public static string VirtualDir()
        {
            return ConfigurationManager.AppSettings["dirDumm"];
        }

        public static void WriteHtml(string Content, string FilePath)
        {
            string str3;
            FilePath = FilePath.Replace("/", @"\").Replace(@"\\", @"\");
            string input = "";
            //maming 注释
            //string str2 = ((("<script type=\"text/javascript\" src=\"" + CommonData.SiteDomain + "/Scripts/jquery.js\"></script>\r\n") + "<script type=\"text/javascript\" src=\"" + CommonData.SiteDomain + "/Scripts/jspublick.js\" charset=\"utf-8\"></script>\r\n") + "<script type=\"text/javascript\" src=\"" + CommonData.SiteDomain + "/ckplayer/js/ckplayer.js\" charset=\"utf-8\"></script>\r\n") + "<script type=\"text/javascript\" src=\"" + CommonData.SiteDomain + "/ckplayer/js/load.js\" charset=\"utf-8\"></script>\r\n";
            string str2 = "";
            if (Public.readparamConfig("Open", "Cnzz") == "11")
            {
                str2 = str2 + "<script src='http://pw.cnzz.com/c.php?id=" + Public.readparamConfig("SiteID", "Cnzz") + "'  type=\"text/javascript\" charset='gb2312'></script>\r\n";
            }
            if (Public.readparamConfig("PageStyle") == "3")
            {
                str3 = getPageDefaultStyleSheet();
            }
            else
            {
                str3 = "";
            }
            string str4 = str3;
            //maming 注释
            //string str4 = string.Concat(new object[] { str3, "\r\n<!--Created by ", verConfig.Productversion, " For Foosun Inc. Published at ", DateTime.Now, "-->\r\n" });

            try
            {
                FtpConfig config;
                string directoryName = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                input = Content;
                if (Regex.IsMatch(input, "</head>", RegexOptions.IgnoreCase))
                {
                    input = Regex.Replace(input, "</head>", str2 + str4 + "</head>", RegexOptions.IgnoreCase);
                }
                else if (Regex.IsMatch(input, "<body>", RegexOptions.IgnoreCase))
                {
                    input = Regex.Replace(input, "<body>", "<body>" + str2 + str4, RegexOptions.IgnoreCase);
                }
                input = input.Replace(InstallDir, RootInstallDir).Replace(TempletDir, strgTemplet);
                StreamWriter writer = new StreamWriter(FilePath, false, Encoding.UTF8);
                writer.Write(input);
                writer.Close();
                writer.Dispose();
                if (HttpContext.Current == null)
                {
                    config = new FtpConfig();
                    sys sys = new sys();
                    if (sys.FtpRss().Rows[0]["FtpTF"].ToString() == "1")
                    {
                        config.Enabled = 1;
                    }
                }
                else
                {
                    config = HttpContext.Current.Application["FTPInfo"] as FtpConfig;
                }
                if (config.Enabled == 1)
                {
                    List<string> fTPQueue = Public.GetFTPQueue();
                    if (!fTPQueue.Contains(FilePath))
                    {
                        fTPQueue.Add(FilePath);
                        Public.SetFTPQueue(fTPQueue);
                    }
                }
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("写入文件", "【错误描述：】\r\n" + exception.ToString(), "");
            }
        }
    }
}


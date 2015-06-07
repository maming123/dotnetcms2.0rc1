namespace Foosun.Publish
{
    using Common;
    using Foosun.CMS;
    using Foosun.Config;
    using Foosun.Global;
    using Foosun.Model;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web;

    public class UltiPublishServirce
    {
        private string _publisStateStr = null;
        private static Hashtable _userPublishInfo = new Hashtable();
        public static int classCount = 0;
        private IList<string> failedList = new List<string>();
        private int fs_ClassFlag;
        private bool fs_isClassIndex;
        private bool fs_isProgressBar;
        private bool fs_isPubClass;
        private bool fs_isPubindex;
        private bool fs_isPubIsPage;
        private bool fs_isPubNews;
        private bool fs_isPubSpecial;
        private int fs_newsFlag;
        private int fs_specialFlag;
        private string fs_strClassIsPageParam;
        private string fs_strClassParams = string.Empty;
        private string fs_strNewsParams = string.Empty;
        private string fs_strSpecialParams = string.Empty;
        public static int indexCount = 0;
        private int nClassCount = 0;
        public static int newsCount = 0;
        private int nNewsCount = 0;
        private int nSpecialCount = 0;
        public static int pageCount = 0;
        private string saveClassPath = string.Empty;
        private string saveNewsPath = string.Empty;
        private string saveSpecialPath = string.Empty;
        public string SiteRootPath = string.Empty;
        public static int specialCount = 0;
        private string strTempletDir = UIConfig.dirTemplet;
        private IList<string> succeedList = new List<string>();
        private IList<Template> templateList = new List<Template>();
        private string TempletPath;
        public static Thread ths;
        private string userName = string.Empty;
        private int userPublishID = 0;

        public UltiPublishServirce(bool isProgressBar)
        {
        }

        private void clearPublicshCatch()
        {
            CommonData.DisposeSystemCatch();
            LabelStyle.CatchClear();
        }

        public void CloseAllConnection()
        {
        }

        protected IDataReader GetAllClass()
        {
            switch (this.fs_ClassFlag)
            {
                case 0:
                    return this.GetClassesAll();

                case 1:
                    return this.GetClassesSelect();
            }
            return null;
        }

        protected IDataReader GetAllNews()
        {
            switch (this.fs_newsFlag)
            {
                case 0:
                    return this.GetNewsAll();

                case 1:
                    return this.GetNewsLast();

                case 2:
                    return this.GetNewsUnhtml();

                case 3:
                    return this.GetNewsClasses();

                case 4:
                    return this.GetNewsDate();

                case 5:
                    return this.GetNewsId();
            }
            return null;
        }

        protected IDataReader GetAllSpecials()
        {
            string spid = string.Empty;
            switch (this.fs_specialFlag)
            {
                case 0:
                    break;

                case 1:
                    spid = this.GetSpecialsSelect();
                    break;

                default:
                    return null;
            }
            return CommonData.DalPublish.GetPublishSpecial(spid, out this.nSpecialCount);
        }

        protected IDataReader GetClassesAll()
        {
            if (this.fs_strClassParams.IndexOf("#") >= 0)
            {
                return CommonData.DalPublish.GetPublishClass(Current.SiteID, "", true, out this.nClassCount);
            }
            return CommonData.DalPublish.GetPublishClass(Current.SiteID, "", false, out this.nClassCount);
        }

        protected IDataReader GetClassesSelect()
        {
            if (this.fs_strClassParams != null)
            {
                string classid = "";
                string[] strArray = this.fs_strClassParams.Split(new char[] { '$' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (i > 0)
                    {
                        classid = classid + ",";
                    }
                    classid = classid + "'" + strArray[i] + "'";
                }
                return CommonData.DalPublish.GetPublishClass("", classid, true, out this.nClassCount);
            }
            return null;
        }

        protected IDataReader GetNewsAll()
        {
            return CommonData.DalPublish.GetPublishNewsAll(out this.nNewsCount);
        }

        protected IDataReader GetNewsClasses()
        {
            bool unpublish = false;
            bool isdesc = false;
            if (this.fs_strNewsParams.IndexOf("#") >= 0)
            {
                unpublish = true;
                this.fs_strNewsParams = this.fs_strNewsParams.Replace("#", "");
            }
            if (this.fs_strNewsParams.IndexOf("&") >= 0)
            {
                isdesc = true;
                this.fs_strNewsParams = this.fs_strNewsParams.Replace("&", "");
            }
            string classid = "";
            string[] strArray = this.fs_strNewsParams.Split(new char[] { '$' });
            int length = strArray.Length;
            for (int i = 0; i < (length - 1); i++)
            {
                if (i > 0)
                {
                    classid = classid + ",";
                }
                classid = classid + "'" + strArray[i] + "'";
            }
            return CommonData.DalPublish.GetPublishNewsByClass(classid, unpublish, isdesc, strArray[length - 1], out this.nNewsCount);
        }

        protected IDataReader GetNewsDate()
        {
            DateTime startTm = Convert.ToDateTime(this.fs_strNewsParams.Split(new char[] { '$' })[0]);
            DateTime endTm = Convert.ToDateTime(this.fs_strNewsParams.Split(new char[] { '$' })[1]);
            return CommonData.DalPublish.GetPublishNewsByTime(startTm, endTm, out this.nNewsCount);
        }

        protected IDataReader GetNewsId()
        {
            int minid = Convert.ToInt32(this.fs_strNewsParams.Split(new char[] { '$' })[0]);
            int maxid = Convert.ToInt32(this.fs_strNewsParams.Split(new char[] { '$' })[1]);
            return CommonData.DalPublish.GetPublishNewsByID(minid, maxid, out this.nNewsCount);
        }

        protected IDataReader GetNewsLast()
        {
            int num;
            IDataReader reader = CommonData.DalPublish.GetPublishNewsLast(Convert.ToInt32(this.fs_strNewsParams), false, out num);
            this.nNewsCount = Convert.ToInt32(this.fs_strNewsParams);
            if (num < this.nNewsCount)
            {
                this.nNewsCount = num;
            }
            return reader;
        }

        protected IDataReader GetNewsUnhtml()
        {
            int num;
            IDataReader reader = CommonData.DalPublish.GetPublishNewsLast(Convert.ToInt32(this.fs_strNewsParams), true, out num);
            this.nNewsCount = Convert.ToInt32(this.fs_strNewsParams);
            if (num < this.nNewsCount)
            {
                this.nNewsCount = num;
            }
            return reader;
        }

        private string GetPageDefaultStyleSheet()
        {
            return "";
        }

        public string GetPagelist(string Numstr, int i, string getFileName, string getFileEXName, string postResult_color, string postResult_css, int n, string ID, string ContentType, int isPop, string CurrentSytle, string OtherStyle)
        {
            int num;
            int num2;
            int num3;
            object obj2;
            string str6;
            if (string.IsNullOrEmpty(CurrentSytle))
            {
                CurrentSytle = "";
            }
            else if (CurrentSytle != "")
            {
                CurrentSytle = " class=\"" + CurrentSytle + "\"";
            }
            if (string.IsNullOrEmpty(OtherStyle))
            {
                OtherStyle = "";
            }
            else if (OtherStyle != "")
            {
                OtherStyle = " class=\"" + OtherStyle + "\"";
            }
            string str = string.Empty;
            string readType = Public.readparamConfig("ReviewType");
            switch (Numstr)
            {
                case "0":
                    obj2 = str;
                    str = string.Concat(new object[] { obj2, "<div style=\"padding-top:15px;\" ", postResult_css, "><span>共", n, "页</span><span>第", i + 1, "页</span>" });
                    if (i == 0)
                    {
                        str = str + GetPageStyle("首页", postResult_color, CurrentSytle) + GetPageStyle("上一页", postResult_color, CurrentSytle);
                    }
                    else
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"首页\" " + OtherStyle + ">" + GetPageStyle("首页", postResult_color, null) + "</a>";
                        if (i == 1)
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"上一页\" " + OtherStyle + ">" + GetPageStyle("上一页", postResult_color, null) + "</a>";
                        }
                        else
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i, getFileName, getFileEXName, isPop) + "\" title=\"上一页\" " + OtherStyle + ">" + GetPageStyle("上一页", postResult_color, null) + "</a>";
                        }
                    }
                    if (n < 10)
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"上十页\" " + OtherStyle + ">" + GetPageStyle("上十页", postResult_color, null) + "</a>";
                        for (num = 0; num < n; num++)
                        {
                            if (num == i)
                            {
                                str = str + GetPageStyle((num + 1).ToString(), postResult_color, CurrentSytle);
                            }
                            else if (num == 0)
                            {
                                str6 = str;
                                str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                            }
                            else
                            {
                                str6 = str;
                                str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, num + 1, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                            }
                        }
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, n, getFileName, getFileEXName, isPop) + "\" title=\"下十页\" " + OtherStyle + ">" + GetPageStyle("下十页", postResult_color, null) + "</a>";
                    }
                    else if (n > 10)
                    {
                        if (i < 11)
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"上十页\" " + OtherStyle + ">" + GetPageStyle("上十页", postResult_color, null) + "</a>";
                        }
                        else
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, (i + 1) - 10, getFileName, getFileEXName, isPop) + "\" title=\"上十页\" " + OtherStyle + ">" + GetPageStyle("上十页", postResult_color, null) + "</a>";
                        }
                        num2 = i + 10;
                        if ((n - i) < 10)
                        {
                            num2 = n;
                        }
                        for (num = i; num < num2; num++)
                        {
                            if (num == i)
                            {
                                str = str + GetPageStyle((num + 1).ToString(), postResult_color, CurrentSytle);
                            }
                            else if (num == 0)
                            {
                                str6 = str;
                                str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                            }
                            else
                            {
                                str6 = str;
                                str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, num + 1, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                            }
                        }
                        if ((i + 10) > n)
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, n, getFileName, getFileEXName, isPop) + "\" title=\"下十页\" " + OtherStyle + ">" + GetPageStyle("下十页", postResult_color, null) + "</a>";
                        }
                        else
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, (i + 1) + 10, getFileName, getFileEXName, isPop) + "\" title=\"下十页\" " + OtherStyle + ">" + GetPageStyle("下十页", postResult_color, null) + "</a>";
                        }
                    }
                    if (i == (n - 1))
                    {
                        return ((str + GetPageStyle("下一页", postResult_color, CurrentSytle)) + GetPageStyle("尾页", postResult_color, CurrentSytle) + "</div>");
                    }
                    str6 = str;
                    str6 = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i + 2, getFileName, getFileEXName, isPop) + "\" title=\"下一页\" " + OtherStyle + ">" + GetPageStyle("下一页", postResult_color, null) + "</a>";
                    return (str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, n, getFileName, getFileEXName, isPop) + "\" title=\"尾页\" " + OtherStyle + ">" + GetPageStyle("尾页", postResult_color, null) + "</a></div>");

                case "1":
                    obj2 = str;
                    str = string.Concat(new object[] { obj2, "<div style=\"padding-top:15px;\" ", postResult_css, "><span>共", n, "页</span><span>第", i + 1, "页</span>" });
                    if ((i + 1) > 2)
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("上一页", postResult_color, null) + "</a>";
                    }
                    else if (i == 0)
                    {
                        str = str + GetPageStyle("上一页", postResult_color, CurrentSytle) + "&nbsp;&nbsp;";
                    }
                    else
                    {
                        str6 = str;
                        str = str6 + "<a " + postResult_css + " href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("上一页", postResult_color, null) + "</a>";
                    }
                    for (num3 = 0; num3 < n; num3++)
                    {
                        if (num3 == i)
                        {
                            str = str + GetPageStyle("第" + (num3 + 1) + "页", postResult_color, CurrentSytle);
                        }
                        else if (num3 == 0)
                        {
                            str6 = str;
                            str = str6 + "<a " + postResult_css + " href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("第" + (num3 + 1) + "页", postResult_color, null) + "</a>";
                        }
                        else
                        {
                            str6 = str;
                            str = str6 + "<a " + postResult_css + " href=\"" + this.GetPageresult(ID, readType, ContentType, num3 + 1, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("第" + (num3 + 1) + "页", postResult_color, null) + "</a>";
                        }
                    }
                    if ((i + 1) == n)
                    {
                        str = str + GetPageStyle("下一页", postResult_color, CurrentSytle);
                    }
                    else
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i + 2, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("下一页", postResult_color, null) + "</a>";
                    }
                    return (str + "</div>");

                case "2":
                    obj2 = str;
                    str = string.Concat(new object[] { obj2, "<div style=\"padding-top:15px;\" ", postResult_css, "><span>共", n, "页</span><span>第", i + 1, "页</span>" });
                    if ((i + 1) > 2)
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("上一页", postResult_color, null) + "</a>";
                    }
                    else if (i == 0)
                    {
                        str = str + GetPageStyle("上一页", postResult_color, CurrentSytle);
                    }
                    else
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("上一页", postResult_color, null) + "</a>";
                    }
                    for (num3 = 0; num3 < n; num3++)
                    {
                        if (num3 == i)
                        {
                            str = str + GetPageStyle((num3 + 1).ToString(), postResult_color, CurrentSytle);
                        }
                        else if (num3 == 0)
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num3 + 1).ToString(), postResult_color, null) + "</a>";
                        }
                        else
                        {
                            str6 = str;
                            str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, num3 + 1, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num3 + 1).ToString(), postResult_color, null) + "</a>";
                        }
                    }
                    if ((i + 1) == n)
                    {
                        str = str + GetPageStyle("下一页", postResult_color, CurrentSytle);
                    }
                    else
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i + 2, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle("下一页", postResult_color, null) + "</a>";
                    }
                    return (str + "</div>");

                case "4":
                {
                    if (postResult_css == string.Empty)
                    {
                        postResult_css = " class=\"foosun_pagebox\"";
                        CurrentSytle = " class=\"foosun_pagebox_num_nonce\"";
                        OtherStyle = " class=\"foosun_pagebox_num\"";
                    }
                    if (Public.readparamConfig("PageStyle") != "3")
                    {
                        str = str + this.GetPageDefaultStyleSheet();
                    }
                    str = str + "<div style=\"padding-top:15px;\" " + postResult_css + ">";
                    int num4 = 5;
                    int constStr = 0;
                    int num6 = n - 1;
                    int num7 = 0;
                    int num8 = 0;
                    int num9 = (i / num4) * num4;
                    if (i >= num4)
                    {
                        constStr = (num9 - num4) + 1;
                        if (constStr == 1)
                        {
                            constStr = 0;
                        }
                        str = str + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, constStr, getFileName, getFileEXName, isPop) + "\">上五页</a>";
                    }
                    else
                    {
                        str = str + GetPageStyle("上五页", postResult_color, OtherStyle);
                    }
                    if (i <= 0)
                    {
                        str = str + GetPageStyle("上一页", postResult_color, OtherStyle);
                    }
                    else
                    {
                        if (i == 1)
                        {
                            constStr = 0;
                        }
                        else
                        {
                            constStr = i;
                        }
                        str = str + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, constStr, getFileName, getFileEXName, isPop) + "\">上一页</a>";
                    }
                    for (num8 = 0; num8 < num4; num8++)
                    {
                        num7 = num9 + num8;
                        if (num7 > num6)
                        {
                            break;
                        }
                        if (num7 == 0)
                        {
                            constStr = 0;
                        }
                        else
                        {
                            constStr = num7 + 1;
                        }
                        if (i == num7)
                        {
                            int num10 = num7 + 1;
                            str = str + GetPageStyle(num10.ToString(), postResult_color, CurrentSytle);
                        }
                        else
                        {
                            str6 = str;
                            string[] strArray = new string[] { str6, "<a  href=\"", this.GetPageresult(ID, readType, ContentType, constStr, getFileName, getFileEXName, isPop), "\">", (num7 + 1).ToString(), "</a>" };
                            str = string.Concat(strArray);
                        }
                    }
                    if (i >= num6)
                    {
                        str = str + GetPageStyle("下一页", postResult_color, OtherStyle);
                    }
                    else
                    {
                        str = str + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i + 2, getFileName, getFileEXName, isPop) + "\">下一页</a>";
                    }
                    if ((num6 - num9) < num4)
                    {
                        str = str + GetPageStyle("下五页", postResult_color, OtherStyle);
                    }
                    else
                    {
                        str = str + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, (num9 + num4) + 1, getFileName, getFileEXName, isPop) + "\">下五页</a>";
                    }
                    return (str + "</div>");
                }
            }
            obj2 = str;
            str = string.Concat(new object[] { obj2, "<div style=\"padding-top:15px;\" ", postResult_css, "><span>共", n, "页</span><span>第", i + 1, "页</span>" });
            if (i == 0)
            {
                str = str + GetPageStyle("<font face=webdings title=\"首页\">9</font>", postResult_color, CurrentSytle) + GetPageStyle("<font face=webdings title=\"上一页\">3</font>", postResult_color, CurrentSytle);
            }
            else
            {
                str6 = str;
                str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"首页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>9</font>", postResult_color, null) + "</a>";
                if (i == 1)
                {
                    str6 = str;
                    str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"上一页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>3</font>", postResult_color, null) + "</a>";
                }
                else
                {
                    str6 = str;
                    str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i, getFileName, getFileEXName, isPop) + "\" title=\"上一页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>3</font>", postResult_color, null) + "</a>";
                }
            }
            if (n < 10)
            {
                str6 = str;
                str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"上十页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>7</font>", postResult_color, null) + "</a>";
                for (num = 0; num < n; num++)
                {
                    if (num == i)
                    {
                        str = str + "<strong>" + GetPageStyle((num + 1).ToString(), postResult_color, CurrentSytle) + "</strong>&nbsp;";
                    }
                    else if (num == 0)
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                    }
                    else
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, num + 1, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                    }
                }
                str = str + GetPageStyle("<font face=webdings>8</font>", postResult_color, CurrentSytle);
            }
            else if (n > 10)
            {
                if (i < 11)
                {
                    str6 = str;
                    str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" title=\"上十页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>7</font>", postResult_color, null) + "</a>";
                }
                else
                {
                    str6 = str;
                    str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, (i + 1) - 10, getFileName, getFileEXName, isPop) + "\" title=\"上十页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>7</font>", postResult_color, null) + "</a>";
                }
                num2 = i + 10;
                if ((n - i) < 10)
                {
                    num2 = n;
                }
                for (num = i; num < num2; num++)
                {
                    if (num == i)
                    {
                        str = str + GetPageStyle((num + 1).ToString(), postResult_color, CurrentSytle);
                    }
                    else if (num == 0)
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, 0, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                    }
                    else
                    {
                        str6 = str;
                        str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, num + 1, getFileName, getFileEXName, isPop) + "\" " + OtherStyle + ">" + GetPageStyle((num + 1).ToString(), postResult_color, null) + "</a>";
                    }
                }
                if ((i + 10) > n)
                {
                    str6 = str;
                    str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, n, getFileName, getFileEXName, isPop) + "\" title=\"下十页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>8</font>", postResult_color, null) + "</a>";
                }
                else
                {
                    str6 = str;
                    str = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, (i + 1) + 10, getFileName, getFileEXName, isPop) + "\" title=\"下十页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>8</font>", postResult_color, null) + "</a>";
                }
            }
            if (i == (n - 1))
            {
                return ((str + GetPageStyle("<font face=webdings title=\"下一页\">4</font>", postResult_color, CurrentSytle)) + GetPageStyle("<font face=webdings title=\"尾页\">:</font>", postResult_color, CurrentSytle) + "</div>");
            }
            str6 = str;
            str6 = str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, i + 2, getFileName, getFileEXName, isPop) + "\" title=\"下一页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>4</font>", postResult_color, null) + "</a>&nbsp;";
            return (str6 + "<a  href=\"" + this.GetPageresult(ID, readType, ContentType, n, getFileName, getFileEXName, isPop) + "\" title=\"尾页\" " + OtherStyle + ">" + GetPageStyle("<font face=webdings>:</font>", postResult_color, null) + "</a></div>");
        }

        public string GetPageresult(string ID, string ReadType, string ContentType, int ConstStr, string getFileName, string getFileEXName, int isPop)
        {
            string str2 = string.Empty;
            if (ReadType == "1")
            {
                if (ContentType == "class")
                {
                    if (ConstStr == 0)
                    {
                        return ("list-" + ID + str2 + UIConfig.extensions);
                    }
                    return string.Concat(new object[] { "list-", ID, str2, "-", ConstStr, UIConfig.extensions });
                }
                if (ConstStr == 0)
                {
                    return ("Special-" + ID + str2 + UIConfig.extensions);
                }
                return string.Concat(new object[] { "Special-", ID, str2, "-", ConstStr, UIConfig.extensions });
            }
            if (isPop == 0)
            {
                if (ConstStr == 0)
                {
                    return (getFileName + getFileEXName);
                }
                return string.Concat(new object[] { getFileName, "_", ConstStr, getFileEXName });
            }
            if (ContentType == "class")
            {
                if (ConstStr == 0)
                {
                    return ("list-" + ID + str2 + "-1" + UIConfig.extensions);
                }
                return string.Concat(new object[] { "list-", ID, str2, "-", ConstStr, UIConfig.extensions });
            }
            if (ConstStr == 0)
            {
                return ("Special-" + ID + str2 + "-1" + UIConfig.extensions);
            }
            return string.Concat(new object[] { "Special-", ID, str2, "-", ConstStr, UIConfig.extensions });
        }

        public static string GetPageStyle(string Input, string sColor, string Css)
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

        protected string GetSpecialsSelect()
        {
            if (this.fs_strSpecialParams != null)
            {
                string str = "";
                string[] strArray = this.fs_strSpecialParams.Split(new char[] { '$' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (i > 0)
                    {
                        str = str + ",";
                    }
                    str = str + "'" + strArray[i] + "'";
                }
                return str;
            }
            return "";
        }

        protected void makeHtmlFile(Template tempRe, bool existFlag, string classID, string NewsID)
        {
            tempRe.ReplaceLabels();
            if (tempRe.MyTempType == TempType.News)
            {
                string finallyContent = tempRe.FinallyContent;
                int index = finallyContent.IndexOf("<!-FS:STAR=");
                int num2 = finallyContent.IndexOf("FS:END->");
                if (index > -1)
                {
                    int startIndex = this.saveNewsPath.LastIndexOf(".");
                    int num4 = this.saveNewsPath.LastIndexOf(@"\");
                    string fileName = this.saveNewsPath.Substring(num4 + 1, (startIndex - num4) - 1);
                    string eXName = this.saveNewsPath.Substring(startIndex);
                    string str4 = finallyContent.Substring(0, index);
                    string str5 = finallyContent.Substring(num2 + 8);
                    string input = finallyContent.Substring(index + 11, (num2 - index) - 11);
                    Regex regex = new Regex(@"(\[FS:PAGE=(?<p>[\s\S]+?)\$\])|(\[FS:PAGE\])", RegexOptions.IgnoreCase);
                    string[] strArray = Regex.Split(regex.Replace(input, "[FS:PAGE]"), @"\[FS:PAGE\]", RegexOptions.IgnoreCase);
                    int length = strArray.Length;
                    for (int i = 0; i < length; i++)
                    {
                        string filePath = this.SiteRootPath + this.saveNewsPath;
                        if (i > 0)
                        {
                            int num7 = filePath.LastIndexOf('.');
                            filePath = string.Concat(new object[] { filePath.Substring(0, num7), "_", i + 1, filePath.Substring(num7) });
                        }
                        string str8 = str4 + strArray[i] + str5;
                        str8 = regex.Replace(str8, "");
                        General.WriteHtml(General.ReplaceResultPage(NewsID, str8.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), fileName, eXName, length, i + 1, 0), filePath);
                    }
                    if (length > 0)
                    {
                        if (!existFlag)
                        {
                            this.templateList.Add(tempRe);
                        }
                        return;
                    }
                }
            }
            General.WriteHtml(tempRe.FinallyContent.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), this.SiteRootPath + this.saveNewsPath);
            if (!existFlag)
            {
                this.templateList.Add(tempRe);
            }
        }

        public bool publishSingleClass(string classID, string datalib, string saveClassPath)
        {
            try
            {
                Template template2;
                this.TempletPath = this.SiteRootPath.Trim(new char[] { '\\' }) + this.TempletPath;
                bool existFlag = false;
                string savePath = HttpContext.Current.Server.MapPath(saveClassPath);
                if (this.templateList.Count != 0)
                {
                    foreach (Template template in this.templateList)
                    {
                        if (this.TempletPath == template.TempFilePath)
                        {
                            existFlag = true;
                            template.ClassID = classID;
                            this.ReplaceTemp(template, existFlag, savePath, classID, "class");
                            break;
                        }
                    }
                    if (!existFlag)
                    {
                        template2 = new Template(this.TempletPath, TempType.Class);
                        template2.ClassID = classID;
                        template2.GetHTML();
                        this.ReplaceTemp(template2, existFlag, savePath, classID, "class");
                    }
                }
                else
                {
                    template2 = new Template(this.TempletPath, TempType.Class);
                    template2.ClassID = classID;
                    template2.GetHTML();
                    this.ReplaceTemp(template2, existFlag, savePath, classID, "class");
                }
                this.succeedList.Add(classID);
                classCount++;
                return true;
            }
            catch (Exception exception)
            {
                this.failedList.Add(classID + "$" + exception.Message);
                Public.savePublicLogFiles("□□□发布栏目", "【ID】:" + classID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                return false;
            }
        }

        public static bool PublishSingleJsFile(int tid)
        {
            try
            {
                Foosun.CMS.NewsJS sjs = new Foosun.CMS.NewsJS();
                Foosun.Model.NewsJS model = sjs.GetModel(tid);
                string str = "";
                string jsTmpContent = sjs.GetJsTmpContent(model.JsTempletID);
                if (jsTmpContent.Trim() != "")
                {
                    LabelMass mass;
                    if (model.jsType == 0)
                    {
                        CommonData.Initialize();
                        mass = new LabelMass(jsTmpContent, "", "", "", 0, 0, 0, 0);
                        mass.TemplateType = TempType.News;
                        mass.ParseContent();
                        str = mass.Analyse_List(null, null);
                    }
                    else
                    {
                        DataTable jSFiles = sjs.GetJSFiles(model.JsID);
                        if ((jSFiles != null) && (jSFiles.Rows.Count > 0))
                        {
                            CommonData.Initialize();
                            int num = int.Parse(sjs.GetJSNum(model.JsID).Rows[0][0].ToString());
                            int num2 = 0;
                            foreach (DataRow row in jSFiles.Rows)
                            {
                                mass = new LabelMass(jsTmpContent, "", "", row["NewsId"].ToString(), 0, 0, 0, 0);
                                mass.TemplateType = TempType.News;
                                str = str + mass.Analyse_ReadNews(0, model.jsLenTitle.Value, model.jsLenContent.Value, model.jsLenNavi.Value, jsTmpContent, "", 1, 1, 0);
                                num2++;
                                if (num2 == num)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                string jssavepath = model.jssavepath;
                if (jssavepath.Substring(jssavepath.Length - 1, 1) != @"\")
                {
                    jssavepath = jssavepath + @"\";
                }
                if (jssavepath.Substring(0, 1) == "/")
                {
                    jssavepath = jssavepath.Substring(1);
                }
                jssavepath = ServerInfo.GetRootPath() + @"\" + jssavepath;
                if (!Directory.Exists(jssavepath))
                {
                    Directory.CreateDirectory(jssavepath);
                }
                using (StreamWriter writer = new StreamWriter(jssavepath + model.jsfilename + ".js", false))
                {
                    string str5 = "document.write('";
                    str5 = str5 + str.Replace("'", "'").Replace("\n", "") + "');";
                    writer.Write(str5.Replace("\r", "").Replace("1 ", ""));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool publishSingleNews(string newsID, string classID, string templet, string isDelPoint, string SavePath1, string SaveClassframe, string SavePath, string FileName, string FileEXName, string CommTF)
        {
            bool flag = false;
            try
            {
                CommonData.Initialize();
                string str = string.Empty;
                string temppath = string.Empty;
                string str3 = ServerInfo.GetRootPath() + @"\";
                string strgTemplet = General.strgTemplet;
                if (isDelPoint == "0")
                {
                    temppath = templet;
                    temppath = temppath.Replace("/", @"\").ToLower().Replace("{@dirtemplet}", strgTemplet);
                    temppath = str3.Trim(new char[] { '\\' }) + temppath;
                    str = @"\" + SavePath1.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + SaveClassframe.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + SavePath.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + FileName.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + FileEXName.Trim(new char[] { '\\' }).Trim(new char[] { '/' });
                    Template template = new Template(temppath, TempType.News);
                    template.NewsID = newsID;
                    template.ClassID = classID;
                    template.GetHTML();
                    template.IsContent = CommTF == "1";
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
                                General.WriteHtml(General.ReplaceResultPage(newsID, str12.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), fileName, eXName, length, i + 1, 0), filePath);
                            }
                        }
                        else
                        {
                            General.WriteHtml(finallyContent.Replace("FS:END->", "").Replace("<!-FS:STAR=", ""), str3 + str);
                        }
                    }
                    if (CommonData.DalPublish.updateIsHtmlState(newsID) > 0)
                    {
                        flag = true;
                        newsCount++;
                    }
                    return flag;
                }
                return false;
            }
            catch (Exception exception)
            {
                Public.savePublicLogFiles("□□□ 生成新闻", "【NewsID】:" + newsID + "\r\n【错误描述：】\r\n" + exception.ToString(), "");
                return false;
            }
        }

        public bool publishSingleSpecial(string specialID, string saveSpecialPath)
        {
            try
            {
                Template template2;
                saveSpecialPath = saveSpecialPath.Replace("{@dirHtml}", UIConfig.dirHtml).Replace("/", @"\");
                this.TempletPath = this.SiteRootPath.Trim(new char[] { '\\' }) + this.TempletPath;
                string savePath = HttpContext.Current.Server.MapPath(saveSpecialPath);
                bool existFlag = false;
                if (this.templateList.Count != 0)
                {
                    foreach (Template template in this.templateList)
                    {
                        if (this.TempletPath == template.TempFilePath)
                        {
                            existFlag = true;
                            template.SpecialID = specialID;
                            this.ReplaceTemp(template, existFlag, savePath, specialID, "special");
                            break;
                        }
                    }
                    if (!existFlag)
                    {
                        template2 = new Template(this.TempletPath, TempType.Special);
                        template2.SpecialID = specialID;
                        template2.GetHTML();
                        this.ReplaceTemp(template2, existFlag, savePath, specialID, "special");
                    }
                }
                else
                {
                    template2 = new Template(this.TempletPath, TempType.Special);
                    template2.SpecialID = specialID;
                    template2.GetHTML();
                    this.ReplaceTemp(template2, existFlag, savePath, specialID, "special");
                }
                this.succeedList.Add(specialID);
                specialCount++;
                return true;
            }
            catch (Exception exception)
            {
                this.failedList.Add(specialID + "$" + exception.Message);
                return false;
            }
        }

        protected void ReplaceTemp(Template tempRe, bool existFlag, string savePath, string id, string ContentType)
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
                            General.WriteHtml(content, filePath);
                        }
                        if (n > 0)
                        {
                            if (!existFlag)
                            {
                                this.templateList.Add(tempRe);
                            }
                            return;
                        }
                    }
                }
            }
            string str23 = ("<span style=\"text-align:center;\" id=\"gPtypenowdiv" + DateTime.Now.ToShortDateString() + "\">加载中...</span>") + "<script language=\"javascript\" type=\"text/javascript\">";
            string newValue = (str23 + "pubajax('" + CommonData.SiteDomain + "/configuration/system/public.aspx','NowStr=" + DateTime.Now.ToShortDateString() + "&ruleStr=1','gPtypenowdiv" + DateTime.Now.ToShortDateString() + "');") + "</script>";
            General.WriteHtml(tempRe.FinallyContent.Replace("{Foosun:NewsLIST}", "").Replace("{/Foosun:NewsLIST}", "").Replace("{PageLists}", "").Replace("{$FS:P1}", newValue), savePath);
            if (!existFlag)
            {
                this.templateList.Add(tempRe);
            }
        }

        private void SetNewsCatch(int count, string list)
        {
            int num4;
            string[] strArray = list.Split(new char[] { ',' });
            int num = strArray.Length / 200;
            int num2 = ((strArray.Length + 200) - 1) / 200;
            bool flag = false;
            int num3 = 0;
            for (num4 = 1; num4 <= num2; num4++)
            {
                num3 = (num4 - 1) * 200;
                if (num3 == count)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                StringBuilder builder = new StringBuilder();
                int num5 = 0;
                for (num4 = num3; num4 < strArray.Length; num4++)
                {
                    num5++;
                    if (num5 > 200)
                    {
                        break;
                    }
                    if ((num5 == 200) || (num4 == (strArray.Length - 1)))
                    {
                        builder.Append("'" + strArray[num4] + "'");
                    }
                    else
                    {
                        builder.Append("'" + strArray[num4] + "',");
                    }
                }
                string idList = builder.ToString();
                CommonData.NewsInfoList = CommonData.DalPublish.GetNewsListByAll(idList);
            }
        }

        private void setSaveNewsPath(string classID, string SavePath, string FileName, string FileEXName)
        {
            PubClassInfo classById = CommonData.GetClassById(classID);
            if (classById != null)
            {
                this.saveNewsPath = @"\" + classById.SavePath.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + classById.SaveClassframe.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + SavePath.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + @"\" + FileName.Trim(new char[] { '\\' }).Trim(new char[] { '/' }) + FileEXName.Trim(new char[] { '\\' }).Trim(new char[] { '/' });
            }
        }

        public static string showMessages(int ajaxUserPublishID)
        {
            ShowMessage message = (ShowMessage) _userPublishInfo[ajaxUserPublishID];
            if (message == null)
            {
                message = new ShowMessage();
            }
            return string.Concat(new object[] { "<indexname>", message.Indexname, "</indexname><thisPublish>", message.PubName, "</thisPublish><maxPublishNumber>", message.MaxPublishNumber, "</maxPublishNumber><thisPublisCount>", message.ThisPublisCount, "</thisPublisCount><success>", message.Success, "</success><error>", message.Error, "</error><barNum>", message.BarNum, "</barNum>" });
        }

        private void showMSGNotThread(string msg, int count)
        {
        }

        public void StartPublish()
        {
            this.clearPublicshCatch();
            CommonData.Initialize();
            if (this.fs_isPubindex)
            {
                this.ultiPublishIndex();
            }
            if (this.fs_isPubClass)
            {
                this.ultiPublishClass();
            }
            if (this.fs_isPubSpecial)
            {
                this.ultiPublishSpecial();
            }
            if (this.fs_isPubIsPage)
            {
                this.ultiPublishIsPage();
            }
            if (SearchEngine.IsBaidu() == "1")
            {
                SearchEngine.RefreshBaidu();
            }
        }

        public void ultiPublishClass()
        {
            using (IDataReader reader = this.GetAllClass())
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                bool flag = false;
                string str = "index.html";
                str = Public.readparamConfig("IndexFileName");
                if (this.nClassCount > 0)
                {
                    while (reader.Read())
                    {
                        flag = true;
                        this.TempletPath = reader["classtemplet"].ToString();
                        this.TempletPath = this.TempletPath.Replace("/", @"\");
                        this.TempletPath = this.TempletPath.ToLower().Replace("{@dirtemplet}", this.strTempletDir);
                        this.saveClassPath = string.Concat(new object[] { @"\", reader["savePath"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }), @"\", reader["SaveClassframe"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }), '\\', reader["ClassSaveRule"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) }).Replace("/", @"\");
                        string classID = reader["classid"].ToString();
                        bool flag2 = this.publishSingleClass(classID, reader["Datalib"].ToString(), this.saveClassPath);
                        if (this.fs_isClassIndex)
                        {
                            General.PublishClassIndex(classID);
                        }
                        num++;
                        if (flag2)
                        {
                            num2++;
                        }
                        else
                        {
                            num3++;
                        }
                    }
                }
            }
            if (this.templateList.Count != 0)
            {
                this.templateList.Clear();
            }
            if (this.failedList.Count != 0)
            {
                for (int i = 0; i < this.failedList.Count; i++)
                {
                    Public.savePublicLogFiles("□□□发布栏目", "【ID】:" + this.failedList[i].Split(new char[] { '$' })[0] + "\r\n【错误描述：】\r\n" + this.failedList[i].Split(new char[] { '$' })[1], "");
                }
                this.failedList.Clear();
            }
            if (this.succeedList.Count != 0)
            {
                this.updateNewsIsHtml(DBConfig.TableNamePrefix + "news_class", "isunHtml", "cLassID");
            }
        }

        public void ultiPublishIndex()
        {
            string str = "index.html";
            this.TempletPath = Public.readparamConfig("IndexTemplet");
            this.TempletPath = this.TempletPath.Replace("/", @"\");
            this.TempletPath = this.TempletPath.ToLower().Replace("{@dirtemplet}", this.strTempletDir);
            str = Public.readparamConfig("IndexFileName");
            Template template = new Template(this.SiteRootPath.Trim(new char[] { '\\' }) + this.TempletPath, TempType.Index);
            template.GetHTML();
            template.ReplaceLabels();
            General.WriteHtml(template.FinallyContent, this.SiteRootPath.TrimEnd(new char[] { '\\' }) + @"\" + str);
            General.PublishXML("0");
            General.PublishHistryIndex(0);
            indexCount++;
        }

        private void ultiPublishIsPage()
        {
            string classid = "";
            if (this.fs_strClassIsPageParam != null)
            {
                int num;
                string[] strArray = this.fs_strClassIsPageParam.Split(new char[] { '$' });
                for (num = 0; num < strArray.Length; num++)
                {
                    if (num > 0)
                    {
                        classid = classid + ",";
                    }
                    classid = classid + "'" + strArray[num] + "'";
                }
                IDataReader reader = CommonData.DalPublish.GetPublishClass("", classid, true, out this.nClassCount);
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                bool flag = false;
                string str2 = "index.html";
                str2 = Public.readparamConfig("IndexFileName");
                if (this.nClassCount > 0)
                {
                    while (reader.Read())
                    {
                        flag = true;
                        this.TempletPath = reader["classtemplet"].ToString();
                        this.TempletPath = this.TempletPath.Replace("/", @"\");
                        this.TempletPath = this.TempletPath.ToLower().Replace("{@dirtemplet}", this.strTempletDir);
                        this.saveClassPath = (@"\" + reader["savePath"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' })).Replace("/", @"\");
                        bool flag2 = General.PublishPage(reader["classid"].ToString());
                        num2++;
                        if (flag2)
                        {
                            num3++;
                            pageCount++;
                        }
                        else
                        {
                            num4++;
                        }
                    }
                }
                if (this.templateList.Count != 0)
                {
                    this.templateList.Clear();
                }
                if (this.failedList.Count != 0)
                {
                    for (num = 0; num < this.failedList.Count; num++)
                    {
                        Public.savePublicLogFiles("□□□发布单页", "【ID】:" + this.failedList[num].Split(new char[] { '$' })[0] + "\r\n【错误描述：】\r\n" + this.failedList[num].Split(new char[] { '$' })[1], "");
                    }
                    this.failedList.Clear();
                }
            }
        }

        private void ultiPublishNews()
        {
            ShowMessage message = new ShowMessage();
            message.Indexname = Public.readparamConfig("IndexFileName");
            IDataReader allNews = this.GetAllNews();
            if (this.nNewsCount <= 0)
            {
                HProgressBar.Roll("没有新闻", 0);
            }
            else
            {
                DataTable table = new DataTable();
                DataRow row = null;
                table.Columns.Add("newsID");
                table.Columns.Add("datalib");
                table.Columns.Add("classID");
                table.Columns.Add("SavePath");
                table.Columns.Add("FileName");
                table.Columns.Add("FileEXName");
                table.Columns.Add("templet");
                table.Columns.Add("isDelPoint");
                table.Columns.Add("SavePath1");
                table.Columns.Add("SaveClassframe");
                table.Columns.Add("CommTF");
                StringBuilder builder = new StringBuilder();
                while (allNews.Read())
                {
                    row = table.NewRow();
                    row["newsID"] = allNews["newsID"];
                    row["datalib"] = allNews["datalib"];
                    row["classID"] = allNews["classID"];
                    row["SavePath"] = allNews["SavePath"];
                    row["FileName"] = allNews["FileName"];
                    row["FileEXName"] = allNews["FileEXName"];
                    row["templet"] = allNews["templet"];
                    row["isDelPoint"] = allNews["isDelPoint"];
                    row["SavePath1"] = allNews["SavePath1"];
                    row["SaveClassframe"] = allNews["SaveClassframe"];
                    row["CommTF"] = allNews["CommTF"];
                    builder.Append(row["newsID"] + ",");
                    table.Rows.Add(row);
                }
                message.ThreadRt = table;
                message.NewsIdNameList = builder.ToString().Substring(0, builder.Length - 1);
                StringBuilder builder2 = new StringBuilder();
                this.userPublishID = new Random().Next(0x3e8, 0x270f);
                _userPublishInfo.Add(this.userPublishID, message);
            }
        }

        public void ultiPublishSpecial()
        {
            float num = 0f;
            int num2 = 0;
            int num3 = 0;
            bool flag = false;
            string str = "index.html";
            str = Public.readparamConfig("IndexFileName");
            IDataReader allSpecials = this.GetAllSpecials();
            if (this.nSpecialCount > 0)
            {
                while (allSpecials.Read())
                {
                    flag = true;
                    this.TempletPath = allSpecials["Templet"].ToString();
                    this.TempletPath = this.TempletPath.Replace("/", @"\");
                    this.TempletPath = this.TempletPath.ToLower().Replace("{@dirtemplet}", this.strTempletDir);
                    string str2 = string.Concat(new object[] { @"\", allSpecials["SavePath"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }), @"\", allSpecials["saveDirPath"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }), '\\', allSpecials["FileName"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }), allSpecials["FileEXName"].ToString().Trim(new char[] { '\\' }).Trim(new char[] { '/' }) });
                    this.saveSpecialPath = str2.Replace("{@dirHtml}", UIConfig.dirHtml).Replace("/", @"\");
                    if (this.publishSingleSpecial(allSpecials["specialID"].ToString(), this.saveSpecialPath))
                    {
                        num++;
                        num2++;
                    }
                    else
                    {
                        num3++;
                    }
                }
            }
            allSpecials.Close();
            if (this.templateList.Count != 0)
            {
                this.templateList.Clear();
            }
            if (this.failedList.Count != 0)
            {
                for (int i = 0; i < this.failedList.Count; i++)
                {
                    Public.savePublicLogFiles("□□□发布专题", "【ID】:" + this.failedList[i].Split(new char[] { '$' })[0] + "\r\n【错误描述：】\r\n" + this.failedList[i].Split(new char[] { '$' })[1], "");
                }
                this.failedList.Clear();
            }
        }

        private void updateNewsIsHtml(string tableName, string isHtml, string idField)
        {
            try
            {
                CommonData.DalPublish.UpdateNewsIsHtml(tableName, isHtml, idField, this.succeedList);
            }
            catch
            {
            }
            finally
            {
                this.succeedList.Clear();
            }
        }

        public int ClassFlag
        {
            set
            {
                this.fs_ClassFlag = value;
            }
        }

        public bool isClassIndex
        {
            get
            {
                return this.fs_isClassIndex;
            }
            set
            {
                this.fs_isClassIndex = value;
            }
        }

        public bool IsPubClass
        {
            get
            {
                return this.fs_isPubClass;
            }
            set
            {
                this.fs_isPubClass = value;
            }
        }

        public bool IsPubIsPage
        {
            get
            {
                return this.fs_isPubIsPage;
            }
            set
            {
                this.fs_isPubIsPage = value;
            }
        }

        public bool IsPublishIndex
        {
            get
            {
                return this.fs_isPubindex;
            }
            set
            {
                this.fs_isPubindex = value;
            }
        }

        public bool IsPubNews
        {
            get
            {
                return this.fs_isPubNews;
            }
            set
            {
                this.fs_isPubNews = value;
            }
        }

        public bool IsPubSpecial
        {
            get
            {
                return this.fs_isPubSpecial;
            }
            set
            {
                this.fs_isPubSpecial = value;
            }
        }

        public int newsFlag
        {
            set
            {
                this.fs_newsFlag = value;
            }
        }

        private bool PublisStates
        {
            get
            {
                if (this._publisStateStr == null)
                {
                    this._publisStateStr = Public.readparamConfig("publishState");
                }
                try
                {
                    bool result = false;
                    if (!bool.TryParse(this._publisStateStr, out result))
                    {
                        result = true;
                    }
                    return result;
                }
                catch
                {
                    return true;
                }
            }
        }

        public int specialFlag
        {
            set
            {
                this.fs_specialFlag = value;
            }
        }

        public string StrClassIsPageParam
        {
            set
            {
                this.fs_strClassIsPageParam = value;
            }
        }

        public string strClassParams
        {
            set
            {
                this.fs_strClassParams = value;
            }
        }

        public string strNewsParams
        {
            set
            {
                this.fs_strNewsParams = value;
            }
        }

        public string strSpecialParams
        {
            set
            {
                this.fs_strSpecialParams = value;
            }
        }

        private class ShowMessage
        {
            private int _barNum = 0;
            private int _error = 0;
            private string _indexname = null;
            private DateTime _lastPublishTime = DateTime.Now;
            private int _maxPublishNumber = 0;
            private string _newsIdNameList = null;
            private string _pubName = null;
            private int _success = 0;
            private int _thisPublisCount = 0;
            private bool _ThreadFlag = false;
            private DataTable _ThreadRt = null;

            public int BarNum
            {
                get
                {
                    return this._barNum;
                }
                set
                {
                    this._barNum = value;
                }
            }

            public int Error
            {
                get
                {
                    return this._error;
                }
                set
                {
                    this._error = value;
                }
            }

            public string Indexname
            {
                get
                {
                    return this._indexname;
                }
                set
                {
                    this._indexname = value;
                }
            }

            public DateTime LastPublichTime
            {
                get
                {
                    return this._lastPublishTime;
                }
                set
                {
                    this._lastPublishTime = value;
                }
            }

            public int MaxPublishNumber
            {
                get
                {
                    return this._maxPublishNumber;
                }
                set
                {
                    this._maxPublishNumber = value;
                }
            }

            public string NewsIdNameList
            {
                get
                {
                    return this._newsIdNameList;
                }
                set
                {
                    this._newsIdNameList = value;
                }
            }

            public string PubName
            {
                get
                {
                    return this._pubName;
                }
                set
                {
                    this._pubName = value;
                }
            }

            public int Success
            {
                get
                {
                    return this._success;
                }
                set
                {
                    this._success = value;
                }
            }

            public int ThisPublisCount
            {
                get
                {
                    return this._thisPublisCount;
                }
                set
                {
                    this._thisPublisCount = value;
                }
            }

            public bool ThreadFlag
            {
                get
                {
                    return this._ThreadFlag;
                }
                set
                {
                    this._ThreadFlag = value;
                }
            }

            public DataTable ThreadRt
            {
                get
                {
                    return this._ThreadRt;
                }
                set
                {
                    this._ThreadRt = value;
                }
            }
        }
    }
}


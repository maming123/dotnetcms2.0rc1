namespace Foosun.Publish
{
    using Common;
    using Foosun.CMS;
    using Foosun.Config;
    using Foosun.Config.API;
    using Foosun.DALFactory;
    using Foosun.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class LabelMass
    {
        protected LabelParameter[] _LblParams = null;
        protected TempType _TemplateType;
        private string Analyse_SitemapString = null;
        public static string dimmDir = UIConfig.dirDumm;
        protected bool FormatValid = true;
        protected string InvalidInfo = string.Empty;
        protected string Mass_Content = string.Empty;
        protected string Mass_Inserted = string.Empty;
        protected string Mass_Primary = string.Empty;
        public const string newLine = "\r\n";
        protected int Param_ChID = 0;
        protected int Param_CurrentCHClassID;
        protected int Param_CurrentCHNewsID;
        protected int Param_CurrentCHSpecialID;
        protected string Param_CurrentClassID;
        protected string Param_CurrentNewsID;
        protected string Param_CurrentSpecialID;
        protected EnumLabelType Param_LabelType;
        protected int Param_Loop;
        protected string Param_SiteID = "0";

        public LabelMass(string masscontent, string currentclassid, string currentspecialid, string currentnewsid, int ChID, int currentchclassid, int currentchspecialid, int currentchnewsid)
        {
            this.Mass_Content = masscontent;
            this.Param_ChID = ChID;
            if ((currentclassid == string.Empty) || (currentclassid == null))
            {
                this.Param_CurrentClassID = null;
            }
            else
            {
                this.Param_CurrentClassID = currentclassid;
            }
            if ((currentspecialid == string.Empty) || (currentspecialid == null))
            {
                this.Param_CurrentSpecialID = null;
            }
            else
            {
                this.Param_CurrentSpecialID = currentspecialid;
            }
            if ((currentnewsid == string.Empty) || (currentnewsid == null))
            {
                this.Param_CurrentNewsID = null;
            }
            else
            {
                this.Param_CurrentNewsID = currentnewsid;
            }
            this.Param_CurrentCHClassID = currentchclassid;
            this.Param_CurrentCHSpecialID = currentchspecialid;
            this.Param_CurrentCHNewsID = currentchnewsid;
        }

        private void AddParameter(LabelParameter lp, ref IList<LabelParameter> list)
        {
            bool flag = true;
            foreach (LabelParameter parameter in list)
            {
                if (parameter.LPName.Equals(lp.LPName))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                list.Add(lp);
            }
        }

        public string Analse_ReadNews()
        {
            string input = this.Mass_Inserted;
            string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (id != string.Empty)
            {
                input = LabelStyle.GetStyleByID(id);
            }
            if (input.Trim() == string.Empty)
            {
                return string.Empty;
            }
            return input;
        }

        public string Analyse_adJS()
        {
            string paramValue = this.GetParamValue("FS:JSID");
            string str2 = string.Empty;
            if (paramValue != null)
            {
                str2 = "<script language=\"javascript\" src=\"" + CommonData.SiteDomain + "/jsfiles/ads/show.aspx?adsID=" + paramValue + "\"></script>";
            }
            return str2;
        }

        public string Analyse_ChannelClassList(int ChID)
        {
            int num;
            string cHDatable = CommonData.DalPublish.GetCHDatable(ChID);
            if (cHDatable == "#")
            {
                return "频道数据库找不到";
            }
            string input = this.Mass_Inserted;
            string s = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (!s.Equals(string.Empty))
            {
                input = LabelStyle.GetCHStyleByID(int.Parse(s), ChID);
            }
            if (input.Trim().Equals(string.Empty))
            {
                return string.Empty;
            }
            string paramValue = this.GetParamValue("FS:Type");
            if (!int.TryParse(this.GetParamValue("FS:Cols"), out num))
            {
                num = 1;
            }
            if (num < 1)
            {
                num = 1;
            }
            string str5 = this.GetParamValue("FS:Desc");
            string str6 = this.GetParamValue("FS:OrderBy");
            if (str6 == null)
            {
                str6 = "id";
            }
            string isDiv = this.GetParamValue("FS:isDiv");
            if (isDiv == null)
            {
                isDiv = "true";
            }
            string str8 = this.GetParamValue("FS:bfStr");
            string str9 = this.GetParamValue("FS:isPic");
            string str10 = this.GetParamValue("FS:TitleNumer");
            string showNavi = this.GetParamValue("FS:ShowNavi");
            string naviCSS = this.GetParamValue("FS:NaviCSS");
            string str13 = this.GetParamValue("FS:ColbgCSS");
            string str14 = this.GetParamValue("FS:PageStyle");
            int num2 = 0;
            int num3 = 100;
            string str15 = "";
            string str16 = "";
            if (((str8 != string.Empty) && (str8 != null)) && (str8.IndexOf("|") > -1))
            {
                string[] strArray = str8.Split(new char[] { '|' });
                num2 = int.Parse(strArray[0].ToString());
                num3 = int.Parse(strArray[1].ToString());
                str15 = strArray[2].ToString();
                switch (num2)
                {
                    case 0:
                        str16 = "<span class=\"" + str15 + "\" style=\"width:100%\"></span>";
                        break;

                    case 1:
                        str16 = "<img src=\"" + str15 + "\" border=\"0\" />";
                        break;

                    case 2:
                        str16 = str15;
                        break;
                }
            }
            string str17 = "";
            if (paramValue == "info")
            {
                str17 = str17 + " and ClassID=" + this.Param_CurrentCHClassID;
            }
            else
            {
                object obj2 = str17;
                str17 = string.Concat(new object[] { obj2, " And SpecialID='", this.Param_CurrentCHSpecialID, "'" });
            }
            string str18 = " [id] ";
            string str19 = cHDatable + " Where [isLock]=0 " + str17;
            switch (str9)
            {
                case "true":
                    str19 = str19 + " And [PicURL]<>''";
                    break;

                case "false":
                    str19 = str19 + " And [PicURL]='' ";
                    break;
            }
            string str20 = "{$FS:P0}{Page:0$$}";
            int num4 = 30;
            string str21 = "0";
            string str22 = "";
            string str23 = "";
            if ((str14 != string.Empty) && (str14 != null))
            {
                string[] strArray2 = str14.Split(new char[] { '$' });
                str21 = strArray2[0].ToString();
                num4 = int.Parse(strArray2[2].ToString());
                str22 = strArray2[1].ToString();
                str23 = strArray2[3].ToString();
            }
            str20 = "{$FS:P0}{Page:" + str21 + "$" + str22 + "$" + str23 + "}";
            string str24 = string.Empty;
            if ((str5 != null) && (str5.ToLower() == "asc"))
            {
                str24 = str24 + " asc";
            }
            else
            {
                str24 = str24 + " Desc";
            }
            string str30 = str6.ToLower();
            if (str30 != null)
            {
                if (!(str30 == "id"))
                {
                    if (str30 == "creattime")
                    {
                        str24 = " Order By [CreatTime] " + str24 + ",id " + str24;
                        goto Label_050F;
                    }
                    if (str30 == "click")
                    {
                        str24 = " Order By [Click] " + str24 + ",id " + str24;
                        goto Label_050F;
                    }
                    if (str30 == "orderid")
                    {
                        str24 = " Order By [OrderID]" + str24 + ",id " + str24;
                        goto Label_050F;
                    }
                }
                else
                {
                    str24 = " Order By id " + str24;
                    goto Label_050F;
                }
            }
            str24 = " Order By [CreatTime]" + str24 + ",id " + str24;
        Label_050F:;
            string sql = "select " + str18 + " from " + str19 + str24;
            DataTable table = CommonData.DalPublish.ExecuteSql(sql);
            if ((table == null) || (table.Rows.Count < 1))
            {
                return string.Empty;
            }
            string str26 = string.Empty;
            int titleNumer = 30;
            if ((str10 != null) && Input.IsInteger(str10))
            {
                titleNumer = int.Parse(str10);
            }
            int count = table.Rows.Count;
            str26 = "{Foosun:NewsLIST}" + this.News_List_Head(isDiv, "", "", "");
            string str27 = "";
            if (isDiv != "true")
            {
                str26 = str26 + this.News_List_Head(isDiv, "", "", "");
                if (num != 1)
                {
                    str26 = str26 + "<tr>";
                }
            }
            for (int i = 0; i < count; i++)
            {
                if (((i + 1) % num3) == 0)
                {
                    str27 = str16;
                }
                else
                {
                    str27 = "";
                }
                if (isDiv == "false")
                {
                    string str28 = this.getNavi(showNavi, naviCSS, "", i) + this.Analyse_ChRead((int) table.Rows[i][0], titleNumer, input, s, 0, cHDatable, ChID);
                    if (num == 1)
                    {
                        str28 = str28 + str27;
                    }
                    if (num == 1)
                    {
                        str26 = str26 + "<tr>\r\n<td>\r\n" + str28 + "\r\n</td>\r\n</tr>\r\n";
                    }
                    else
                    {
                        str28 = string.Concat(new object[] { "<td width=\"", 100 / num, "%\">\r\n", str28, "\r\n</td>\r\n" });
                        if ((((i + 1) % num) == 0) && ((i + 1) < count))
                        {
                            str28 = str28 + "</tr>\r\n<tr>\r\n";
                        }
                        str26 = str26 + str28;
                    }
                }
                else
                {
                    isDiv = "true";
                    str26 = (str26 + this.getNavi(showNavi, naviCSS, "", i)) + this.Analyse_ChRead((int) table.Rows[i][0], titleNumer, input, s, 0, cHDatable, ChID) + str27;
                }
                if ((((i + 1) % num4) == 0) && ((i + 1) < count))
                {
                    str26 = str26 + this.News_List_End(isDiv) + str20 + this.News_List_Head(isDiv, "", "", "");
                }
                if ((isDiv == "false") && ((i + 1) == count))
                {
                    if (num != 1)
                    {
                        str26 = str26 + "</tr>\r\n";
                    }
                    str26 = str26 + this.News_List_End(isDiv) + "\r\n";
                }
            }
            table.Clear();
            table.Dispose();
            return (str26 + "{/Foosun:NewsLIST}");
        }

        public string Analyse_ChannelContent(int ChID)
        {
            string cHDatable = CommonData.DalPublish.GetCHDatable(ChID);
            if (cHDatable == "#")
            {
                return "频道数据库找不到";
            }
            return this.Analyse_ChRead(this.Param_CurrentCHNewsID, 0, "", "", 1, cHDatable, ChID);
        }

        public string Analyse_ChannelFlash(int ChID)
        {
            string str = "暂无幻灯新闻";
            string cHDatable = CommonData.DalPublish.GetCHDatable(ChID);
            if (cHDatable == "#")
            {
                return "频道数据库找不到";
            }
            string paramValue = this.GetParamValue("FS:ClassID");
            string input = this.GetParamValue("FS:Flashweight");
            string str5 = this.GetParamValue("FS:Flashheight");
            string str6 = this.GetParamValue("FS:FlashBG");
            string str7 = this.GetParamValue("FS:ShowTitle");
            if (!((input != null) || Input.IsInteger(input)))
            {
                input = "200";
            }
            if (!((str5 != null) || Input.IsInteger(str5)))
            {
                str5 = "150";
            }
            if (str6 == null)
            {
                str6 = "FFF";
            }
            string str8 = " Where [isLock]=0 And [ChID]=" + ChID + " And ContentProperty like '____1%'";
            string str9 = " Order By [CreatTime] Desc";
            DataTable table = null;
            string str10 = string.Empty;
            if (paramValue == null)
            {
                str10 = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", cHDatable, "] ", str8, str9 });
            }
            else
            {
                string str16 = paramValue;
                if (str16 != null)
                {
                    if (!(str16 == "0"))
                    {
                        if (str16 == "-1")
                        {
                            str10 = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", cHDatable, "]", str8, str9 });
                            goto Label_02C4;
                        }
                    }
                    else
                    {
                        if (this._TemplateType == TempType.ChClass)
                        {
                            str10 = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", cHDatable, "] ", str8, " And ClassID=", this.Param_CurrentCHClassID, " ", str9 });
                        }
                        goto Label_02C4;
                    }
                }
                if (Input.IsInteger(paramValue))
                {
                    str10 = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", cHDatable, "]", str8, " and ClassID=", int.Parse(paramValue), str9 });
                }
            }
        Label_02C4:
            if (!string.IsNullOrEmpty(str10))
            {
                table = CommonData.DalPublish.ExecuteSql(str10);
                string str11 = "";
                string str12 = "";
                string str13 = "";
                if ((table != null) && (table.Rows.Count > 0))
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        PubCHClassInfo cHClassById = CommonData.GetCHClassById(int.Parse(table.Rows[i]["ClassID"].ToString()));
                        str11 = str11 + table.Rows[i]["PicURL"].ToString() + "|";
                        str12 = str12 + this.getCHInfoURL(ChID, int.Parse(table.Rows[i]["isDelPoint"].ToString()), int.Parse(table.Rows[i]["id"].ToString()), cHClassById.SavePath, table.Rows[i]["SavePath"].ToString(), table.Rows[i]["FileName"].ToString()) + "|";
                        str13 = str13 + table.Rows[i]["Title"].ToString() + "|";
                    }
                }
                table.Clear();
                table.Dispose();
                str11 = Input.CutComma(str11, "|");
                str11 = this.RelpacePicPath(str11);
                str12 = Input.CutComma(str12, "|");
                str13 = Input.CutComma(str13, "|");
                if ((!(str11 != string.Empty) || !(str12 != string.Empty)) || !(str13 != string.Empty))
                {
                    return str;
                }
                string[] strArray = str11.Split(new char[] { '|' });
                string[] strArray2 = str12.Split(new char[] { '|' });
                string[] strArray3 = str13.Split(new char[] { '|' });
                if ((strArray.Length != strArray2.Length) || (strArray.Length != strArray3.Length))
                {
                    return str;
                }
                if (strArray.Length < 2)
                {
                    return "flash幻灯至少要两条以上才可以显示";
                }
                string str14 = CommonData.SiteDomain + "/Flash.swf";
                str = "<script type=\"text/javascript\">\r\n";
                str = (str + "var Flash_Width = " + input + ";\r\n") + "var Flash_Height = " + str5 + ";\r\n";
                if (str7 == "true")
                {
                    str = str + "var Txt_Height = 20;\r\n";
                }
                else
                {
                    str = str + "var Txt_Height = 0;\r\n";
                }
                string str17 = ((((str + "var Swf_Height = parseInt(Flash_Height + Txt_Height);\r\n") + "var Pics_ = '" + str11 + "';\r\n") + "var Links_ = '" + str12 + "';\r\n") + "var Texts_ = '" + str13 + "';\r\n") + "document.write('<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"'+ Flash_Width +'\" height=\"'+ Swf_Height +'\">');\r\n";
                str17 = (str17 + "document.write('<param name=\"allowScriptAccess\" value=\"sameDomain\"><param name=\"movie\" value=\"" + str14 + "\"><param name=\"quality\" value=\"high\"><param name=\"bgcolor\" value=\"#" + str6 + "\">');\r\n") + "document.write('<param name=\"menu\" value=\"false\"><param name=\"wmode\" value=\"opaque\">');\r\n" + "document.write('<param name=\"FlashVars\" value=\"pics='+Pics_+'&links='+Links_+'&texts='+Texts_+'&borderwidth='+Flash_Width+'&borderheight='+Flash_Height+'&textheight='+Txt_Height+'\">');\r\n";
                return ((str17 + "document.write('<embed src=\"" + str14 + "\" wmode=\"opaque\" FlashVars=\"pics='+Pics_+'&links='+Links_+'&texts='+Texts_+'&borderwidth='+Flash_Width+'&borderheight='+Flash_Height+'&textheight='+Txt_Height+'\" menu=\"false\" bgcolor=\"#" + str6 + "\" quality=\"high\" width=\"'+ Flash_Width +'\" height=\"'+ Swf_Height +'\" allowScriptAccess=\"sameDomain\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />');\r\n") + "document.write('</object>');\r\n" + "</script>\r\n");
            }
            return "";
        }

        public string Analyse_ChannellList(string Tags, int ChID)
        {
            int num;
            string str20;
            string str24;
            string cHDatable = CommonData.DalPublish.GetCHDatable(ChID);
            if (cHDatable == "#")
            {
                return "频道数据库找不到!";
            }
            string input = this.Mass_Inserted;
            string s = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (!s.Equals(string.Empty))
            {
                input = LabelStyle.GetCHStyleByID(int.Parse(s), ChID);
            }
            if (input.Trim().Equals(string.Empty))
            {
                return string.Empty;
            }
            string paramValue = this.GetParamValue("FS:Type");
            string str5 = this.GetParamValue("FS:ClassID");
            string str6 = this.GetParamValue("FS:SpecialID");
            if (!int.TryParse(this.GetParamValue("FS:Cols"), out num))
            {
                num = 1;
            }
            if (num < 1)
            {
                num = 1;
            }
            string str7 = this.GetParamValue("FS:Desc");
            string str8 = this.GetParamValue("FS:OrderBy");
            string isDiv = this.GetParamValue("FS:isDiv");
            string str10 = this.GetParamValue("FS:isPic");
            string str11 = this.GetParamValue("FS:TitleNumer");
            string str12 = this.GetParamValue("FS:ClickNumber");
            string str13 = this.GetParamValue("FS:ShowDateNumer");
            string showNavi = this.GetParamValue("FS:ShowNavi");
            string naviCSS = this.GetParamValue("FS:NaviCSS");
            string str16 = this.GetParamValue("FS:ColbgCSS");
            string str17 = " [ID] ";
            string str18 = cHDatable + " Where [islock]=0";
            switch (str10)
            {
                case "true":
                    str18 = str18 + " And [PicURL]<>''";
                    break;

                case "false":
                    str18 = str18 + "And [PicURL]=''";
                    break;
            }
            if ((str12 != null) && (str12 != ""))
            {
                str18 = str18 + " And [Click] > " + int.Parse(str12);
            }
            if ((str13 != null) && (str13 != ""))
            {
                if (UIConfig.WebDAL.ToLower() == "foosun.accessdal")
                {
                    str18 = str18 + " And DateDiff('d',[CreatTime] ,now()) < " + int.Parse(str13);
                }
                else
                {
                    str18 = str18 + " And DateDiff(Day,[CreatTime] ,Getdate()) < " + int.Parse(str13);
                }
            }
            if ((Tags != null) && (Tags != string.Empty))
            {
                str24 = str18;
                str18 = str24 + " And ([Tags] Like '%" + Tags + "%' or title Like '%" + Tags + "%')";
            }
            switch (paramValue)
            {
                case "rec":
                    str18 = str18 + " And ContentProperty like '1%'";
                    break;

                case "mar":
                    str18 = str18 + " And ContentProperty like '______1%'";
                    break;

                case "hot":
                    str18 = str18 + " And ContentProperty like '__1%'";
                    break;

                case "filt":
                    str18 = str18 + " And ContentProperty like '____1%'";
                    break;

                case "tnews":
                    str18 = str18 + " And ContentProperty like '________1%'";
                    break;

                case "special":
                    if (str6 != null)
                    {
                        str18 = str18 + " And SpecialID='" + str6 + "'";
                        break;
                    }
                    if (this.Param_CurrentSpecialID != null)
                    {
                        str18 = str18 + " And SpecialID='" + this.Param_CurrentSpecialID + "'";
                        break;
                    }
                    return string.Empty;

                case "constr":
                    str18 = str18 + " And [isConstr]=1";
                    break;
            }
            string str19 = string.Empty;
            if (paramValue == "last")
            {
                str19 = str19 + " order by CreatTime desc,ID Desc";
            }
            else
            {
                if ((str7 != null) && (str7.ToLower() == "asc"))
                {
                    str19 = str19 + " asc";
                }
                else
                {
                    str19 = str19 + " Desc";
                }
                string str25 = str8;
                if (str25 == null)
                {
                    goto Label_0581;
                }
                if (!(str25 == "id"))
                {
                    if (str25 == "CreatTime")
                    {
                        str19 = " Order By [CreatTime] " + str19 + ",id " + str19;
                        goto Label_05C8;
                    }
                    if (str25 == "click")
                    {
                        str19 = " Order By [Click] " + str19 + ",id " + str19;
                        goto Label_05C8;
                    }
                    if (str25 == "orderid")
                    {
                        str19 = " Order By [OrderID]" + str19 + ",id " + str19;
                        goto Label_05C8;
                    }
                    goto Label_0581;
                }
                str19 = " Order By id " + str19;
            }
            goto Label_05C8;
        Label_0581:
            if (paramValue == "hot")
            {
                str19 = " Order By [Click] " + str19 + ",id " + str19;
            }
            else
            {
                str19 = " Order By [CreatTime] " + str19 + ",id " + str19;
            }
        Label_05C8:
            str20 = string.Empty;
            if ((str5 == null) || (str5 == "0"))
            {
                if (this._TemplateType == TempType.ChClass)
                {
                    str18 = str18 + " And [ClassID]=" + this.Param_CurrentCHClassID;
                    str20 = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str17, " from ", str18, " ", str19 });
                }
                else
                {
                    str20 = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str17, " from ", str18, str19 });
                }
            }
            else if (str5 == "-1")
            {
                str20 = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str17, " from ", str18, str19 });
            }
            else
            {
                str18 = str18 + " And [ClassID] =" + int.Parse(str5);
                str20 = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str17, " from ", str18, str19 });
            }
            DataTable table = CommonData.DalPublish.ExecuteSql(str20);
            if ((table == null) || (table.Rows.Count < 1))
            {
                return string.Empty;
            }
            string str21 = string.Empty;
            int titleNumer = 30;
            if ((str11 != null) && Input.IsInteger(str11))
            {
                titleNumer = int.Parse(str11);
            }
            int count = table.Rows.Count;
            string[] strArray = null;
            bool flag = false;
            if (str16 != null)
            {
                strArray = str16.Split(new char[] { '|' });
                flag = true;
            }
            string str22 = string.Empty;
            int i = 0;
            while (i < count)
            {
                str16 = "";
                if (flag)
                {
                    if ((i % 2) == 0)
                    {
                        str16 = " class=\"" + strArray[0].ToString() + "\"";
                    }
                    else
                    {
                        str16 = " class=\"" + strArray[1].ToString() + "\"";
                    }
                }
                if (isDiv == "false")
                {
                    str22 = this.getNavi(showNavi, naviCSS, "", i) + " " + this.Analyse_ChRead((int) table.Rows[i][0], titleNumer, input, s, 0, cHDatable, ChID);
                    if (num == 1)
                    {
                        str24 = str21;
                        str21 = str24 + "<tr>\r\n<td" + str16 + ">\r\n" + str22 + "\r\n</td>\r\n</tr>\r\n";
                    }
                    else
                    {
                        str22 = string.Concat(new object[] { "<td width=\"", 100 / num, "%\"", str16, ">\r\n", str22, "\r\n</td>\r\n" });
                        if ((i > 0) && (((i + 1) % num) == 0))
                        {
                            str22 = str22 + "</tr>\r\n<tr>\r\n";
                        }
                        str21 = str21 + str22;
                    }
                }
                else
                {
                    isDiv = "true";
                    str21 = str21 + this.getNavi(showNavi, naviCSS, "", i) + this.Analyse_ChRead((int) table.Rows[i][0], titleNumer, input, s, 0, cHDatable, ChID);
                }
                i++;
            }
            table.Clear();
            table.Dispose();
            if ((str21 != string.Empty) && (num > 1))
            {
                str21 = "<tr>\r\n" + str21;
                if ((i % num) != 0)
                {
                    int num5 = num - i;
                    if (num5 < 0)
                    {
                        num5 = num - (i % num);
                    }
                    for (int j = 0; j < num5; j++)
                    {
                        object obj2 = str21;
                        str21 = string.Concat(new object[] { obj2, "<td width=\"", 100 / num, "%\">\r\n </td>\r\n" });
                    }
                }
                str21 = str21 + "</tr>\r\n";
            }
            return (this.News_List_Head(isDiv, "", "", "") + str21 + this.News_List_End(isDiv));
        }

        public string Analyse_ChannelRSS(int ChID)
        {
            object obj2;
            string paramValue = this.GetParamValue("FS:ClassID");
            if (paramValue == null)
            {
                paramValue = "0";
            }
            string str2 = string.Empty;
            if (paramValue == "0")
            {
                if (this.Param_CurrentCHClassID == 0)
                {
                    obj2 = str2;
                    return string.Concat(new object[] { obj2, CommonData.SiteDomain, "/xml/channel/", ChID, "_index.xml" });
                }
                obj2 = str2;
                return string.Concat(new object[] { obj2, CommonData.SiteDomain, "/xml/channel/", ChID, "_", this.Param_CurrentCHClassID, ".xml" });
            }
            obj2 = str2;
            return string.Concat(new object[] { obj2, CommonData.SiteDomain, "/xml/channel/", ChID, "_", paramValue, ".xml" });
        }

        public string Analyse_ChannelSearch(int ChID)
        {
            string str9;
            string str = string.Concat(new object[] { "<div><form id=\"SearchCH_Form_", ChID, "\" name=\"SearchCH_Form_", ChID, "\" method=\"get\" action=\"search.html\">" });
            string paramValue = this.GetParamValue("FS:Type");
            string str3 = this.GetParamValue("FS:Cols");
            string str4 = Rand.Number(3);
            string str5 = string.Empty;
            string str6 = "&nbsp;";
            if (str3 == "single")
            {
                str5 = "<div>";
                str6 = "</div>";
            }
            if (paramValue == "normal")
            {
                str9 = str;
                str9 = str9 + str5 + "<input name=\"tags\" type=\"text\"  size=\"10\" maxlength=\"20\" onkeydown=\"javascript:if(event.keyCode==13){SearchCHGo_" + str4 + "(this.form);}\" />" + str6;
                str = str9 + str5 + "<input name=\"buttongo\" type=\"button\" value=\"搜索\" onclick=\"javascript:SearchCHGo_" + str4 + "(this.form);\">" + str6;
            }
            else
            {
                str4 = Rand.Number(4);
                str9 = str;
                str = (((str9 + str5 + "<input id=\"tags\" name=\"tags\" type=\"text\"  size=\"10\" maxlength=\"20\" onkeydown=\"javascript:if(event.keyCode==13){SearchCHGo_" + str4 + "(this.form);}\" />" + str6) + str5 + "<select name=\"fieldname\"  id=\"fieldname\">") + "<option value=\"title\">标题</option>\r\n" + "<option value=\"content\">全文</option>\r\n") + "<option value=\"author\">作者</option>\r\n" + "<option value=\"TAGS\">TAG</option>\r\n";
                IDataReader fieldName = CommonData.DalPublish.GetFieldName(this.Param_ChID);
                while (fieldName.Read())
                {
                    str9 = str;
                    str = str9 + "<option value=\"" + fieldName["EName"].ToString() + "\">" + fieldName["CName"].ToString() + "</option>\r\n";
                }
                fieldName.Close();
                str = str ?? "";
                str9 = str + "</select >" + str6;
                str = str9 + str5 + "<input name=\"buttongo\" type=\"button\" value=\"搜索\" onclick=\"javascript:SearchCHGo_" + str4 + "(this.form);\">" + str6;
            }
            str = ((str + "</form></div>" + "<script language=\"javascript\" type=\"text/javascript\">\r\n") + "function SearchCHGo_" + str4 + "(obj)\r\n") + "{\r\n";
            int num = 0;
            int num2 = 20;
            string str7 = Public.readparamConfig("LenSearch");
            num = int.Parse(str7.Split(new char[] { '|' })[0]);
            num2 = int.Parse(str7.Split(new char[] { '|' })[1]);
            object obj2 = str;
            obj2 = string.Concat(new object[] { obj2, "if(obj.tags.value.length<", num, "||obj.tags.value.length>", num2, ")\r\n" }) + "{\r\n";
            str = ((string.Concat(new object[] { obj2, " alert('搜索最小长度", num, "字符，最大长度", num2, "字符。');return false;\r\n" }) + "}\r\n") + "if(obj.tags.value=='')\r\n" + "{\r\n") + " alert('请填写关键字');return false;\r\n" + "}\r\n";
            if (paramValue == "normal")
            {
                obj2 = str + "window.location.href='" + CommonData.SiteDomain + "/Search.html?type=news";
                str = string.Concat(new object[] { obj2, "&ChID='+", ChID, "+'" }) + "&tags='+encodeURIComponent(obj.tags.value)+'';\r\n";
            }
            else
            {
                obj2 = str;
                str = string.Concat(new object[] { obj2, "window.location.href='", CommonData.SiteDomain, "/Search.html?type=news&ChID='+", ChID, "+'&tags='+encodeURIComponent(obj.tags.value)+'&fieldname='+obj.fieldname.value+'';\r\n" });
            }
            return (str + "}\r\n" + "</script>\r\n");
        }

        public string Analyse_ChRead(int ID, int TitleNumer, string str_Style, string StyleID, int NewsTF, string DTable, int ChID)
        {
            string str8;
            ChContentParam cHInfo = new ChContentParam();
            if (NewsTF == 1)
            {
                cHInfo = this.GetCHInfo(this.Param_CurrentCHNewsID, DTable);
            }
            else
            {
                cHInfo = this.GetCHInfo(ID, DTable);
            }
            string str = "";
            if (dimmDir.Trim() != string.Empty)
            {
                str = "/" + dimmDir;
            }
            if (NewsTF == 1)
            {
                str_Style = this.Mass_Inserted;
                string s = Regex.Match(str_Style, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
                if (s != string.Empty)
                {
                    str_Style = LabelStyle.GetCHStyleByID(int.Parse(s), ChID);
                }
                if (str_Style.Trim() == string.Empty)
                {
                    return string.Empty;
                }
            }
            if (cHInfo == null)
            {
                return string.Empty;
            }
            if (TitleNumer <= 0)
            {
                TitleNumer = 15;
            }
            PubCHClassInfo cHClassById = CommonData.GetCHClassById(cHInfo.ClassID);
            if (cHClassById == null)
            {
                cHClassById = new PubCHClassInfo();
            }
            PubCHSpecialInfo cHSpecial = new PubCHSpecialInfo();
            if (cHInfo.SpecialID != "")
            {
                cHSpecial = CommonData.GetCHSpecial(int.Parse(cHInfo.SpecialID));
            }
            if (str_Style.IndexOf("{CH#Title}") > -1)
            {
                string title = cHInfo.Title;
                if (NewsTF == 0)
                {
                    title = this.GetStyle(Input.GetSubString(title, TitleNumer), cHInfo.TitleColor, cHInfo.TitleITF, cHInfo.TitleBTF);
                }
                str_Style = str_Style.Replace("{CH#Title}", title);
            }
            if (str_Style.IndexOf("{CH#uTitle}") > -1)
            {
                if (NewsTF == 1)
                {
                    str_Style = str_Style.Replace("{CH#uTitle}", cHInfo.Title);
                }
                else
                {
                    str_Style = this.GetStyle(cHInfo.Title, cHInfo.TitleColor, cHInfo.TitleITF, cHInfo.TitleBTF);
                }
            }
            if (str_Style.IndexOf("{CH#URL}") > -1)
            {
                string newValue = this.getCHInfoURL(ChID, cHInfo.isDelPoint, cHInfo.ID, cHClassById.SavePath, cHInfo.SavePath, cHInfo.FileName);
                str_Style = str_Style.Replace("{CH#URL}", newValue);
            }
            if (str_Style.IndexOf("{CH#Content$") > -1)
            {
                string content = cHInfo.Content;
                string input = content;
                string str7 = string.Empty;
                int num = 0;
                str8 = @"\{CH\#Content\$(?<p>[\s\S]+?)\}";
                Match match = new Regex(str8, RegexOptions.Compiled).Match(str_Style);
                if (match.Success)
                {
                    str7 = match.Groups["p"].Value;
                }
                if (Input.IsInteger(str7) && (str7.Trim() != "0"))
                {
                    num = int.Parse(str7);
                }
                if (NewsTF == 0)
                {
                    string str9 = Input.LostPage(Input.LostHTML(content));
                    if (num == 0)
                    {
                        content = Input.GetSubString(str9, 200) + "...";
                    }
                    else
                    {
                        content = Input.GetSubString(str9, num) + "...";
                    }
                    str_Style = str_Style.Replace("{CH#Content$" + str7 + "}", content.Replace("[FS:PAGE]", "").Replace("[FS:PAGE", "").Replace("$]", ""));
                }
                else if ((((str_Style.IndexOf("{CH#PageTitle_select}") > -1) || (str_Style.IndexOf("{CH#PageTitle_textdouble}") > -1)) || (str_Style.IndexOf("{CH#PageTitle_textsinge}") > -1)) || (str_Style.IndexOf("{CH#PageTitle_textcols}") > -1))
                {
                    string str10 = input;
                    string str11 = string.Empty;
                    string str12 = string.Empty;
                    if ((str10.IndexOf("[FS:PAGE=") > -1) && (str10.IndexOf("$]") > -1))
                    {
                        string str13 = @"\[FS:PAGE=(?<p>[\s\S]+?)\$\]";
                        Regex regex2 = new Regex(str13, RegexOptions.Compiled);
                        for (Match match2 = regex2.Match(str10); match2.Success; match2 = match2.NextMatch())
                        {
                            str12 = str12 + match2.Groups["p"].Value + "###";
                        }
                        input = regex2.Replace(input, "[FS:PAGE]");
                        if (str_Style.IndexOf("{CH#PageTitle_select}") > -1)
                        {
                            str11 = this.GetPageTitleStyle(cHInfo.ID.ToString(), cHInfo.FileName, "", str12, 0, cHInfo.isDelPoint, ChID);
                            str_Style = str_Style.Replace("{#PageTitle_select}", str11);
                        }
                        if (str_Style.IndexOf("{CH#PageTitle_textdouble}") > -1)
                        {
                            str11 = this.GetPageTitleStyle(cHInfo.ID.ToString(), cHInfo.FileName, "", str12, 1, cHInfo.isDelPoint, ChID);
                            str_Style = str_Style.Replace("{#PageTitle_textdouble}", str11);
                        }
                        if (str_Style.IndexOf("{CH#PageTitle_textsinge}") > -1)
                        {
                            str11 = this.GetPageTitleStyle(cHInfo.ID.ToString(), cHInfo.FileName, "", str12, 2, cHInfo.isDelPoint, ChID);
                            str_Style = str_Style.Replace("{#PageTitle_textsinge}", str11);
                        }
                        if (str_Style.IndexOf("{CH#PageTitle_textcols}") > -1)
                        {
                            str11 = this.GetPageTitleStyle(cHInfo.ID.ToString(), cHInfo.FileName, "", str12, 3, cHInfo.isDelPoint, ChID);
                            str_Style = str_Style.Replace("{CH#PageTitle_textcols}", str11);
                        }
                    }
                    else
                    {
                        str_Style = str_Style.Replace("{CH#PageTitle_select}", "");
                        str_Style = str_Style.Replace("{CH#PageTitle_textdouble}", "");
                        str_Style = str_Style.Replace("{CH#PageTitle_textsinge}", "");
                        str_Style = str_Style.Replace("{CH#PageTitle_textcols}", "");
                    }
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#PageTitle_select}", "");
                    str_Style = str_Style.Replace("{CH#PageTitle_textdouble}", "");
                    str_Style = str_Style.Replace("{CH#PageTitle_textsinge}", "");
                    str_Style = str_Style.Replace("{CH#PageTitle_textcols}", "");
                }
                if (Public.readparamConfig("collectTF") == "1")
                {
                    input = input.Replace("<div", "<!--source from " + Public.readparamConfig("siteDomain") + "--><div");
                }
                str_Style = str_Style.Replace("{CH#Content$" + str7 + "}", "<!-FS:STAR=" + input + "FS:END->");
            }
            if (str_Style.IndexOf("{CH#Date}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date}", cHInfo.CreatTime.ToString() ?? "");
            }
            if (str_Style.IndexOf("{CH#DateShort}") > -1)
            {
                str_Style = str_Style.Replace("{CH#DateShort}", cHInfo.CreatTime.ToShortDateString().ToString() ?? "");
            }
            if (str_Style.IndexOf("{CH#Date:Year02}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date:Year02}", cHInfo.CreatTime.Year.ToString().Remove(0, 2));
            }
            if (str_Style.IndexOf("{CH#Date:Year04}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date:Year04}", cHInfo.CreatTime.Year.ToString());
            }
            if (str_Style.IndexOf("{CH#Date:Month}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date:Month}", cHInfo.CreatTime.Month.ToString());
            }
            if (str_Style.IndexOf("{CH#Date:Day}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date:Day}", cHInfo.CreatTime.Day.ToString());
            }
            if (str_Style.IndexOf("{CH#Date:Hour}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date:Hour}", cHInfo.CreatTime.Hour.ToString());
            }
            if (str_Style.IndexOf("{CH#Date:Minute}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date:Minute}", cHInfo.CreatTime.Minute.ToString());
            }
            if (str_Style.IndexOf("{CH#Date:Second}") > -1)
            {
                str_Style = str_Style.Replace("{CH#Date:Second}", cHInfo.CreatTime.Second.ToString());
            }
            if (str_Style.IndexOf("{CH#Click}") > -1)
            {
                if (NewsTF == 0)
                {
                    str_Style = str_Style.Replace("{CH#Click}", cHInfo.Click.ToString());
                }
                else
                {
                    object obj2 = string.Concat(new object[] { "<span id=\"click_CH_", ChID, "_", cHInfo.ID, "\"></span><script language=\"javascript\" type=\"text/javascript\">" });
                    string str14 = string.Concat(new object[] { obj2, "pubajax('", CommonData.SiteDomain, "/click.aspx','id=", cHInfo.ID, "&ChID=", ChID, "','click_CH_", ChID, "_", cHInfo.ID, "');" }) + "</script>";
                    str_Style = str_Style.Replace("{CH#Click}", str14);
                }
            }
            if (str_Style.IndexOf("{CH#Source}") > -1)
            {
                if (cHInfo.Souce != string.Empty)
                {
                    str_Style = str_Style.Replace("{CH#Source}", cHInfo.Souce);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#Source}", "");
                }
            }
            if (str_Style.IndexOf("{CH#Editor}") > -1)
            {
                if (cHInfo.Editor != "")
                {
                    str_Style = str_Style.Replace("{CH#Editor}", string.Concat(new object[] { "<a href=\"", CommonData.SiteDomain, "/search.html?type=edit&tags=", Input.URLEncode(cHInfo.Editor), "&ChID=", ChID, "\" title=\"查看此编辑的所有新闻\" target=\"_blank\">", cHInfo.Editor, "</a>" }));
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#Editor}", "");
                }
            }
            if (str_Style.IndexOf("{CH#Author}") > -1)
            {
                if (cHInfo.Author != "")
                {
                    if (cHInfo.isConstr == 1)
                    {
                        str_Style = str_Style.Replace("{CH#Author}", "<a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + cHInfo.Author + UIConfig.extensions + "\" title=\"查看他的资料\">" + cHInfo.Author + "</a> <a href=\"" + CommonData.SiteDomain + "/search.html?type=author&tags=" + Input.URLEncode(cHInfo.Author) + "\" title=\"此看此作者所有的文章\" target=\"_blank\">发表的文章</a>");
                    }
                    else
                    {
                        str_Style = str_Style.Replace("{CH#Author}", string.Concat(new object[] { "<a href=\"", CommonData.SiteDomain, "/search.html?type=author&tags=", Input.URLEncode(cHInfo.Author), "&ChID=", ChID, "\" title=\"此看此作者所有的文章\" target=\"_blank\">", cHInfo.Author, "</a>" }));
                    }
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#Author}", "");
                }
            }
            if (str_Style.IndexOf("{CH#MetaKeywords}") > -1)
            {
                if (cHInfo.Metakeywords != "")
                {
                    str_Style = str_Style.Replace("{CH#MetaKeywords}", cHInfo.Metakeywords);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#MetaKeywords}", string.Empty);
                }
            }
            if (str_Style.IndexOf("{CH#Metadesc}") > -1)
            {
                if (cHInfo.Metadesc != "")
                {
                    str_Style = str_Style.Replace("{CH#Metadesc}", cHInfo.Metadesc);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#Metadesc}", "");
                }
            }
            if (str_Style.IndexOf("{CH#Picture}") > -1)
            {
                if (cHInfo.PicURL != "")
                {
                    str_Style = str_Style.Replace("{CH#Picture}", this.RelpacePicPath(cHInfo.PicURL));
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#Picture}", "");
                }
            }
            if (str_Style.IndexOf("{CH#NaviContent$") > -1)
            {
                string str15 = string.Empty;
                int num2 = 0;
                str8 = @"\{CH\#NaviContent\$(?<p>[\s\S]+?)\}";
                Match match3 = new Regex(str8, RegexOptions.Compiled).Match(str_Style);
                if (match3.Success)
                {
                    str15 = match3.Groups["p"].Value;
                }
                if (Input.IsInteger(str15) && (str15.Trim() != "0"))
                {
                    num2 = int.Parse(str15);
                }
                if (NewsTF == 1)
                {
                    str_Style = str_Style.Replace("{CH#NaviContent$" + str15 + "}", cHInfo.naviContent);
                }
                else if (cHInfo.naviContent != "")
                {
                    if (num2 == 0)
                    {
                        str_Style = str_Style.Replace("{CH#NaviContent$" + str15 + "}", Input.GetSubString(cHInfo.naviContent, 200));
                    }
                    else
                    {
                        str_Style = str_Style.Replace("{CH#NaviContent$" + str15 + "}", Input.GetSubString(cHInfo.naviContent, num2));
                    }
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#NaviContent$" + str15 + "}", "");
                }
            }
            if (str_Style.IndexOf("{CH#Tags}") > -1)
            {
                if (cHInfo.Tags != "")
                {
                    string tags = cHInfo.Tags;
                    string str17 = "";
                    if (tags.IndexOf("|") > -1)
                    {
                        string[] strArray = tags.Split(new char[] { '|' });
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            string str22 = str17;
                            str17 = str22 + "<a target=\"_blank\" href=\"" + CommonData.SiteDomain + "/Search.html?type=tag&tags=" + HttpUtility.UrlEncode(strArray[i], Encoding.UTF8) + "\">" + strArray[i] + "</a>  ";
                        }
                    }
                    else
                    {
                        str17 = "<a target=\"_blank\" href=\"" + CommonData.SiteDomain + "/Search.html?type=tag&tags=" + HttpUtility.UrlEncode(tags, Encoding.UTF8) + "\">" + tags + "</a>";
                    }
                    str_Style = str_Style.Replace("{CH#Tags}", str17);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#Tags}", "");
                }
            }
            if (str_Style.IndexOf("{CH#CommForm}") > -1)
            {
                str_Style = str_Style.Replace("{CH#CommForm}", this.GetCommForm(cHInfo.ID.ToString(), NewsTF, ChID));
            }
            if (str_Style.IndexOf("{CH#CommCount}") > -1)
            {
                str_Style = str_Style.Replace("{CH#CommCount}", this.GetCommCount(cHInfo.ID.ToString(), NewsTF, 0, ChID));
            }
            if (str_Style.IndexOf("{CH#LastCommCount}") > -1)
            {
                str_Style = str_Style.Replace("{CH#LastCommCount}", this.GetCommCount(cHInfo.ID.ToString(), NewsTF, 1, ChID));
            }
            if (str_Style.IndexOf("{CH#LastComm}") > -1)
            {
                str_Style = str_Style.Replace("{CH#LastComm}", this.GetLastComm(cHInfo.ID.ToString(), NewsTF, ChID));
            }
            if (str_Style.IndexOf("{CH#SendInfo}") > -1)
            {
                str_Style = str_Style.Replace("{#SendInfo}", this.GetSendInfo(cHInfo.ID.ToString(), ChID));
            }
            if (str_Style.IndexOf("{CH#Collection}") > -1)
            {
                str_Style = str_Style.Replace("{#Collection}", this.GetCollection(cHInfo.ID.ToString(), ChID));
            }
            if (str_Style.IndexOf("{CH#PrePage}") > -1)
            {
                str_Style = str_Style.Replace("{CH#PrePage}", this.GetPrePage(cHInfo.ID.ToString(), DTable, cHInfo.ClassID.ToString(), 1, ChID, 0));
            }
            if (str_Style.IndexOf("{CH#NextPage}") > -1)
            {
                str_Style = str_Style.Replace("{CH#NextPage}", this.GetPrePage(cHInfo.ID.ToString(), DTable, cHInfo.ClassID.ToString(), 0, ChID, 0));
            }
            if (str_Style.IndexOf("{CH#PrePageTitle}") > -1)
            {
                str_Style = str_Style.Replace("{CH#PrePageTitle}", this.GetPrePage(cHInfo.ID.ToString(), DTable, cHInfo.ClassID.ToString(), 1, ChID, 1));
            }
            if (str_Style.IndexOf("{CH#NextPageTitle}") > -1)
            {
                str_Style = str_Style.Replace("{CH#NextPageTitle}", this.GetPrePage(cHInfo.ID.ToString(), DTable, cHInfo.ClassID.ToString(), 0, ChID, 1));
            }
            if (str_Style.IndexOf("{CH#class_Name}") > -1)
            {
                if (cHClassById != null)
                {
                    str_Style = str_Style.Replace("{CH#class_Name}", cHClassById.classCName);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#class_Name}", "");
                }
            }
            if (str_Style.IndexOf("{CH#class_EName}") > -1)
            {
                if (cHClassById != null)
                {
                    str_Style = str_Style.Replace("{CH#class_EName}", cHClassById.classEName);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#class_EName}", "");
                }
            }
            if (str_Style.IndexOf("{CH#class_Path}") > -1)
            {
                if (cHClassById != null)
                {
                    str_Style = str_Style.Replace("{CH#class_Path}", this.getCHClassURL(ChID, cHClassById.isDelPoint, cHClassById.Id, cHClassById.SavePath, cHClassById.FileName));
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#class_Path}", "");
                }
            }
            if (str_Style.IndexOf("{CH#class_Navi}") > -1)
            {
                if (cHClassById != null)
                {
                    str_Style = str_Style.Replace("{CH#class_Navi}", cHClassById.NaviContent);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#class_Navi}", "");
                }
            }
            if (str_Style.IndexOf("{CH#class_NaviPic}") > -1)
            {
                if (cHClassById != null)
                {
                    str_Style = str_Style.Replace("{CH#class_NaviPic}", cHClassById.PicURL);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#class_NaviPic}", "");
                }
            }
            if (str_Style.IndexOf("{CH#class_Keywords}") > -1)
            {
                if (cHClassById != null)
                {
                    str_Style = str_Style.Replace("{CH#class_Keywords}", cHClassById.MetaKeywords);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#class_Keywords}", "");
                }
            }
            if (str_Style.IndexOf("{CH#class_Descript}") > -1)
            {
                if (cHClassById != null)
                {
                    str_Style = str_Style.Replace("{CH#class_Descript}", cHClassById.MetaDescript);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#class_Descript}", "");
                }
            }
            if (str_Style.IndexOf("{CH#special_Name}") > -1)
            {
                if (cHSpecial != null)
                {
                    str_Style = str_Style.Replace("{CH#special_Name}", cHSpecial.specialCName);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#special_Name}", "");
                }
            }
            if (str_Style.IndexOf("{CH#special_Ename}") > -1)
            {
                if (cHSpecial != null)
                {
                    str_Style = str_Style.Replace("{CH#special_Ename}", cHSpecial.specialEName);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#special_Ename}", "");
                }
            }
            if (str_Style.IndexOf("{CH#special_Path}") > -1)
            {
                if (cHSpecial != null)
                {
                    str_Style = str_Style.Replace("{CH#special_Path}", this.getCHSpecialURL(ChID, 0, cHSpecial.Id, cHSpecial.savePath, cHSpecial.filename));
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#special_Path}", "");
                }
            }
            if (str_Style.IndexOf("{CH#special_NaviWords}") > -1)
            {
                if (cHSpecial != null)
                {
                    str_Style = str_Style.Replace("{CH#special_NaviWords}", cHSpecial.navicontent);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#special_NaviWords}", "");
                }
            }
            if (str_Style.IndexOf("{CH#special_NaviPic}") > -1)
            {
                if (cHSpecial != null)
                {
                    str_Style = str_Style.Replace("{CH#special_NaviPic}", cHSpecial.PicURL);
                }
                else
                {
                    str_Style = str_Style.Replace("{CH#special_NaviPic}", "");
                }
            }
            string pattern = @"\{CH\$(?<dname>[^\}]+)}";
            Regex regex4 = new Regex(pattern, RegexOptions.Compiled);
            for (Match match4 = regex4.Match(str_Style); match4.Success; match4 = match4.NextMatch())
            {
                string dfcolumn = match4.Groups["dname"].Value;
                string str20 = CommonData.DalPublish.GetCHDefinedValue(cHInfo.ID, dfcolumn, DTable);
                str_Style = str_Style.Replace("{CH$" + dfcolumn + "}", str20);
            }
            if (StyleID.Equals(string.Empty))
            {
                return str_Style;
            }
            return this.Mass_Inserted.Replace("[#FS:StyleID=" + StyleID + "]", str_Style);
        }

        public string Analyse_ClassInfoList()
        {
            int num3;
            DataTable table;
            string styleByID = this.Mass_Inserted;
            if (styleByID.StartsWith("[#FS:StyleID="))
            {
                string str2 = styleByID.Replace("[#FS:StyleID=", "").Replace("]", "");
                if (!string.IsNullOrEmpty(str2))
                {
                    styleByID = LabelStyle.GetStyleByID(str2);
                }
            }
            if (string.IsNullOrEmpty(styleByID))
            {
                return "";
            }
            string paramValue = this.GetParamValue("FS:ClassID");
            string str4 = this.GetParamValue("FS:Number");
            string str5 = this.GetParamValue("FS:Desc");
            string str6 = this.GetParamValue("FS:DescType");
            string str7 = this.GetParamValue("FS:TitleNumer");
            string str8 = this.GetParamValue("FS:NaviNumber");
            int result = 0;
            int num2 = 0;
            if (!string.IsNullOrEmpty(str7))
            {
                int.TryParse(str7, out result);
            }
            if (!string.IsNullOrEmpty(str8))
            {
                int.TryParse(str8, out num2);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            if (!(string.IsNullOrEmpty(str4) || !int.TryParse(str4, out num3)))
            {
                builder.Append("TOP " + str4);
            }
            builder.Append(" * FROM " + DBConfig.TableNamePrefix + "news_Class WHERE isRecyle=0 AND isLock=0");
            if (string.IsNullOrEmpty(paramValue))
            {
                paramValue = "0";
            }
            else if (paramValue == "0")
            {
                if (!string.IsNullOrEmpty(this.Param_CurrentClassID))
                {
                    paramValue = this.Param_CurrentClassID;
                    IList<PubClassInfo> newsClass = CommonData.NewsClass;
                    int num4 = 0;
                    PubClassInfo info = null;
                    for (int i = 0; i < newsClass.Count; i++)
                    {
                        if (newsClass[i].ParentID == paramValue)
                        {
                            num4++;
                        }
                        if (newsClass[i].ClassID == paramValue)
                        {
                            info = newsClass[i];
                        }
                    }
                    if ((num4 == 0) && (info != null))
                    {
                        paramValue = info.ParentID;
                    }
                }
            }
            else if (paramValue == "1")
            {
                if (!string.IsNullOrEmpty(this.Param_CurrentClassID))
                {
                    PubClassInfo classById = CommonData.GetClassById(this.Param_CurrentClassID);
                    if (classById != null)
                    {
                        paramValue = classById.ParentID;
                    }
                    else
                    {
                        paramValue = this.Param_CurrentClassID;
                    }
                }
            }
            else if (paramValue == "-1")
            {
                paramValue = "";
            }
            if (!string.IsNullOrEmpty(paramValue))
            {
                builder.Append(" AND ParentID='" + paramValue + "'");
            }
            if (string.IsNullOrEmpty(str6))
            {
                goto Label_035C;
            }
            string str10 = str6;
            if (str10 != null)
            {
                if (!(str10 == "OrderID"))
                {
                    if (str10 == "CreatTime")
                    {
                        builder.Append(" ORDER BY CreatTime ");
                        goto Label_0339;
                    }
                }
                else
                {
                    builder.Append(" ORDER BY OrderID ");
                    goto Label_0339;
                }
            }
            builder.Append(" ORDER BY id ");
        Label_0339:
            builder.Append((str5 == "desc") ? "desc" : "asc");
        Label_035C:
            table = CommonData.DalPublish.ExecuteSql(builder.ToString());
            StringBuilder builder2 = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                builder2.Append(this.FillClassInfoStyle(styleByID, row, result, num2));
            }
            return builder2.ToString();
        }

        public string Analyse_ClassList()
        {
            int num;
            string str35;
            string input = this.Mass_Inserted;
            string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (!id.Equals(string.Empty))
            {
                input = LabelStyle.GetStyleByID(id);
            }
            if (input.Trim().Equals(string.Empty))
            {
                return string.Empty;
            }
            string paramValue = this.GetParamValue("FS:LabelType");
            string str4 = this.GetParamValue("FS:ListType");
            string str5 = this.GetParamValue("FS:isSub");
            string str6 = this.GetParamValue("FS:SubNews");
            if (!int.TryParse(this.GetParamValue("FS:Cols"), out num))
            {
                num = 1;
            }
            if (num < 1)
            {
                num = 1;
            }
            string str7 = this.GetParamValue("FS:Desc");
            string str8 = this.GetParamValue("FS:DescType");
            string isDiv = this.GetParamValue("FS:isDiv");
            string str10 = this.GetParamValue("FS:TabCSS");
            string ulID = this.GetParamValue("FS:ulID");
            string ulClass = this.GetParamValue("FS:ulClass");
            string str13 = this.GetParamValue("FS:bfStr");
            string str14 = this.GetParamValue("FS:isPic");
            string str15 = this.GetParamValue("FS:NaviNumber");
            string str16 = this.GetParamValue("FS:TitleNumer");
            string str17 = this.GetParamValue("FS:ContentNumber");
            string showNavi = this.GetParamValue("FS:ShowNavi");
            string naviCSS = this.GetParamValue("FS:NaviCSS");
            string str20 = this.GetParamValue("FS:ColbgCSS");
            string str21 = this.GetParamValue("FS:PageLinksCSS");
            string naviPic = this.GetParamValue("FS:NaviPic");
            string str23 = this.GetParamValue("FS:PageStyle");
            int num2 = 0;
            int num3 = 100;
            string str24 = "";
            string str25 = "";
            if (((str13 != string.Empty) && (str13 != null)) && (str13.IndexOf("|") > -1))
            {
                string[] strArray = str13.Split(new char[] { '|' });
                num2 = int.Parse(strArray[0].ToString());
                num3 = int.Parse(strArray[1].ToString());
                str24 = strArray[2].ToString();
                switch (num2)
                {
                    case 0:
                        str25 = "<span class=\"" + str24 + "\" style=\"width:100%\"></span>";
                        break;

                    case 1:
                        str25 = "<img src=\"" + str24 + "\" border=\"0\" />";
                        break;

                    case 2:
                        str25 = str24;
                        break;
                }
            }
            bool flag = false;
            if ((str6 != null) && (str6 == "true"))
            {
                flag = true;
            }
            string publicType = verConfig.PublicType;
            string str27 = "";
            if (publicType == "1")
            {
                str27 = str27 + " And datediff(day,CreatTime ,getdate())=0";
            }
            if (str4 == "News")
            {
                if (str5 == "true")
                {
                    str27 = str27 + " and ClassID in (" + this.getChildClassID(this.Param_CurrentClassID) + ")";
                }
                else
                {
                    str27 = str27 + " and ClassID='" + this.Param_CurrentClassID + "'";
                }
            }
            else
            {
                string str45;
                if (str5 == "true")
                {
                    if ((this.Param_CurrentSpecialID != "") && (this.Param_CurrentSpecialID != null))
                    {
                        str45 = str27;
                        str27 = str45 + " And NewsID In (Select NewsID From " + DBConfig.TableNamePrefix + "special_news Where SpecialID In (" + this.getChildSpecialID(this.Param_CurrentSpecialID) + "))";
                    }
                }
                else
                {
                    str45 = str27;
                    str27 = str45 + " And NewsID In (Select NewsID From " + DBConfig.TableNamePrefix + "special_news Where SpecialID='" + this.Param_CurrentSpecialID + "')";
                }
            }
            string str28 = " id ";
            string str29 = DBConfig.TableNamePrefix + "News Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "'" + str27;
            switch (str14)
            {
                case "true":
                    str29 = str29 + " And [NewsType]=1";
                    break;

                case "false":
                    str29 = str29 + " And ([NewsType]=0 or [NewsType]=2) ";
                    break;
            }
            string str30 = "{$FS:P0}{Page:0$$}";
            int num4 = 30;
            if (publicType == "0")
            {
                num4 = 30;
                string str31 = "0";
                string str32 = "";
                string str33 = "";
                if ((str23 != string.Empty) && (str23 != null))
                {
                    string[] strArray2 = str23.Split(new char[] { '$' });
                    str31 = strArray2[0].ToString();
                    num4 = int.Parse(strArray2[2].ToString());
                    str32 = strArray2[1].ToString();
                    str33 = strArray2[3].ToString();
                }
                str30 = "{$FS:P0}{Page:" + str31 + "$" + str32 + "$" + str33 + "}";
            }
            string str34 = string.Empty;
            if (paramValue == "Last")
            {
                str34 = str34 + " order by ID Desc";
            }
            else
            {
                if ((str7 != null) && (str7.ToLower() == "asc"))
                {
                    str34 = str34 + " asc";
                }
                else
                {
                    str34 = str34 + " Desc";
                }
                string str46 = str8;
                if (str46 == null)
                {
                    goto Label_06E1;
                }
                if (!(str46 == "id"))
                {
                    if (str46 == "date")
                    {
                        str34 = " Order By [CreatTime] " + str34 + ",id " + str34;
                        goto Label_0728;
                    }
                    if (str46 == "click")
                    {
                        str34 = " Order By [Click] " + str34 + ",id " + str34;
                        goto Label_0728;
                    }
                    if (str46 == "pop")
                    {
                        str34 = " Order By [OrderID]" + str34 + ",id " + str34;
                        goto Label_0728;
                    }
                    if (str46 == "digg")
                    {
                        str34 = " Order By [TopNum]" + str34 + ",id " + str34;
                        goto Label_0728;
                    }
                    goto Label_06E1;
                }
                str34 = " Order By id " + str34;
            }
            goto Label_0728;
        Label_06E1:
            if (paramValue == "Hot")
            {
                str34 = " Order By [Click] " + str34 + ",id " + str34;
            }
            else
            {
                str34 = " Order By [CreatTime] " + str34 + ",id " + str34;
            }
        Label_0728:
            str35 = "";
            if (str4 == "News")
            {
                if (Public.readparamConfig("classlistNumber", "refresh") != "0")
                {
                    str35 = " top " + Public.readparamConfig("classlistNumber", "refresh") + " ";
                }
            }
            else if (Public.readparamConfig("specialNumber", "refresh") != "0")
            {
                str35 = " top " + Public.readparamConfig("specialNumber", "refresh") + " ";
            }
            string sql = "select " + str35 + str28 + " from " + str29 + str34;
            DataTable table = CommonData.DalPublish.ExecuteSql(sql);
            int count = table.Rows.Count;
            int num6 = 0;
            if ((table.Rows.Count % 100) == 0)
            {
                num6 = table.Rows.Count / 100;
            }
            else
            {
                num6 = (table.Rows.Count / 100) + 1;
            }
            if ((table == null) || (table.Rows.Count < 1))
            {
                return string.Empty;
            }
            string str37 = string.Empty;
            int titleNumer = 30;
            int contentNumber = 200;
            int naviNumber = 200;
            if ((str16 != null) && Input.IsInteger(str16))
            {
                titleNumer = int.Parse(str16);
            }
            if ((str17 != null) && Input.IsInteger(str17))
            {
                contentNumber = int.Parse(str17);
            }
            if ((str15 != null) && Input.IsInteger(str15))
            {
                naviNumber = int.Parse(str15);
            }
            str37 = "{Foosun:NewsLIST}" + this.News_List_Head(isDiv, ulID, ulClass, "class=\"" + str10 + "\"");
            string str38 = "";
            int num10 = 0;
            string newValue = "";
            for (int i = 1; i <= num6; i++)
            {
                int num12 = num10 + 100;
                if ((num10 + 100) > table.Rows.Count)
                {
                    num12 = table.Rows.Count;
                }
                string str40 = "";
                for (int j = num10; j < num12; j++)
                {
                    str40 = str40 + table.Rows[j][0] + ",";
                }
                str40 = str40.Substring(0, str40.Length - 1);
                sql = "select * from " + DBConfig.TableNamePrefix + "news where id in(" + str40 + ")" + str34;
                DataTable table2 = CommonData.DalPublish.ExecuteSql(sql);
                CommonData.NewsInfoList = table2;
                int num14 = 0;
                for (int k = 0; k < table2.Rows.Count; k++)
                {
                    Foosun.Model.News news;
                    int num16 = (num10 % num4) + 1;
                    string str41 = string.Empty;
                    if (num16 <= 3)
                    {
                        str41 = "<span class=\"Num No" + num16.ToString() + "\">\r\n" + num16.ToString() + "</span>";
                    }
                    else
                    {
                        str41 = "<span class=\"Num\">\r\n" + num16.ToString() + "</span>";
                    }
                    string str42 = string.Empty;
                    if (!string.IsNullOrEmpty(str20))
                    {
                        string[] strArray3 = str20.Split(new char[] { '|' });
                        if ((num14 % 2) == 0)
                        {
                            str42 = "class=\"" + strArray3[0] + "\"";
                            newValue = strArray3[0];
                        }
                        else
                        {
                            str42 = "class=\"" + ((strArray3.Length == 2) ? strArray3[1] : "") + "\"";
                            newValue = strArray3[1];
                        }
                    }
                    if (((num != 1) && (k == 0)) && (isDiv != "true"))
                    {
                        str37 = str37 + "<tr " + str42 + ">\r\n";
                        num14++;
                    }
                    if ((((num10 % num4) == 0) && (isDiv != "true")) && (k != 0))
                    {
                        str37 = str37 + "<tr " + str42 + ">\r\n";
                        num14++;
                    }
                    if (((num14 + 1) % num3) == 0)
                    {
                        str38 = str25;
                    }
                    else
                    {
                        str38 = "";
                    }
                    if (isDiv == "true")
                    {
                        str37 = str37 + this.getNavi(showNavi, naviCSS, naviPic, k);
                        if (num == 1)
                        {
                            str37 = str37 + this.Analyse_ReadNews((int) table2.Rows[k][0], titleNumer, contentNumber, naviNumber, input, id, 1, 1, 0).Replace("{#Index}", str41).Replace("{#ParityName}", newValue) + str38;
                            num14++;
                        }
                        else
                        {
                            str37 = str37 + this.Analyse_ReadNews((int) table2.Rows[k][0], titleNumer, contentNumber, naviNumber, input, id, 1, 1, 0).Replace("{#Index}", str41).Replace("{#ParityName}", newValue) + str38;
                            num14++;
                            if ((((num10 + 1) % num) == 0) && ((num10 + 1) < count))
                            {
                                str37 = str37 + "\r\n";
                            }
                        }
                        if (flag)
                        {
                            news = new Foosun.Model.News();
                            news = this.getNewsInfo((int) table2.Rows[k][0], null);
                            str37 = str37 + this.GetSubSTR(news.NewsID, string.Empty);
                        }
                    }
                    else
                    {
                        isDiv = "false";
                        string str43 = this.getNavi(showNavi, naviCSS, naviPic, k) + this.Analyse_ReadNews((int) table2.Rows[k][0], titleNumer, contentNumber, naviNumber, input, id, 1, 1, 0).Replace("{#Index}", str41).Replace("{#ParityName}", newValue);
                        if (flag)
                        {
                            news = new Foosun.Model.News();
                            news = this.getNewsInfo((int) table2.Rows[k][0], null);
                            str43 = str43 + this.GetSubSTR(news.NewsID, string.Empty);
                        }
                        if (num == 1)
                        {
                            str43 = str43 + str38;
                        }
                        if (num == 1)
                        {
                            str37 = (str37 + "<tr " + str42 + ">\r\n") + "\r\n<td>\r\n" + str43 + "\r\n</td>\r\n</tr>\r\n";
                        }
                        else
                        {
                            str43 = string.Concat(new object[] { "<td width=\"", 100 / num, "%\">\r\n", str43, "\r\n</td>\r\n" });
                            if ((((num10 + 1) % num) == 0) && ((num10 + 1) < count))
                            {
                                str43 = str43 + "</tr>\r\n";
                                if (((num10 + 1) % num4) > 0)
                                {
                                    str43 = str43 + "<tr " + str42 + ">\r\n";
                                    num14++;
                                }
                            }
                            str37 = str37 + str43;
                        }
                    }
                    if ((publicType == "0") && ((((num10 + 1) % num4) == 0) && ((num10 + 1) < count)))
                    {
                        str37 = str37 + this.News_List_End(isDiv) + str30 + this.News_List_Head(isDiv, ulID, ulClass, "class=\"" + str10 + "\"");
                        num14 = 0;
                    }
                    if ((num10 + 1) == count)
                    {
                        if (num != 1)
                        {
                            str37 = str37 + "</tr>\r\n";
                        }
                        str37 = str37 + this.News_List_End(isDiv) + "\r\n";
                    }
                    num10++;
                }
                table2.Clear();
                table2.Dispose();
            }
            table.Clear();
            table.Dispose();
            if (publicType == "1")
            {
                str37 = str37 + "{$FS:P1}";
            }
            if (!string.IsNullOrEmpty(str21) && (str21.Split(new char[] { '|' }).Length == 2))
            {
                str37 = str37 + "{FS:PageLinksStyle=" + str21 + "}";
            }
            return (str37 + "{/Foosun:NewsLIST}");
        }

        public string Analyse_ClassNavi()
        {
            string parentID;
            string paramValue = this.GetParamValue("FS:ClassID");
            string str2 = this.GetParamValue("FS:NaviCSS");
            string str3 = this.GetParamValue("FS:NaviChar");
            string str4 = this.GetParamValue("FS:Mapp");
            if (str2 != null)
            {
                str2 = "class=\"" + str2 + "\"";
            }
            string str5 = "0";
            if (paramValue == "0")
            {
                if (!string.IsNullOrEmpty(this.Param_CurrentClassID))
                {
                    str5 = this.Param_CurrentClassID;
                }
                else
                {
                    str5 = "0";
                }
                if (CommonData.GetClassByParentId(this.Param_CurrentClassID) == null)
                {
                    parentID = CommonData.GetClassById(this.Param_CurrentClassID).ParentID;
                    if (string.IsNullOrEmpty(parentID))
                    {
                        str5 = this.Param_CurrentClassID;
                    }
                    else
                    {
                        str5 = parentID;
                    }
                }
            }
            else if (paramValue == "1")
            {
                if (!string.IsNullOrEmpty(this.Param_CurrentClassID))
                {
                    parentID = CommonData.GetClassById(this.Param_CurrentClassID).ParentID;
                    if (string.IsNullOrEmpty(parentID))
                    {
                        str5 = this.Param_CurrentClassID;
                    }
                    else
                    {
                        str5 = parentID;
                    }
                }
            }
            else if (paramValue == "-1")
            {
                str5 = "-1";
            }
            else if (!string.IsNullOrEmpty(paramValue))
            {
                str5 = paramValue;
            }
            else
            {
                str5 = "0";
            }
            string str7 = "";
            IList<PubClassInfo> newsClass = CommonData.NewsClass;
            if (newsClass != null)
            {
                foreach (PubClassInfo info2 in newsClass)
                {
                    if (info2.NaviShowtf == 1)
                    {
                        string uRLaddress;
                        string str10;
                        if (info2.IsURL == 1)
                        {
                            if ((str5 == "-1") && (info2.SiteID == this.Param_SiteID))
                            {
                                uRLaddress = info2.URLaddress;
                                str10 = str7;
                                str7 = str10 + "   <li>" + str3 + " <a href=\"" + uRLaddress + "\" " + str2 + ">\r\n";
                                str7 = str7 + "   " + info2.ClassCName + "</a>";
                                str7 = str7 + "   </li>\r\n";
                            }
                            else if ((info2.ParentID == str5) && (info2.SiteID == this.Param_SiteID))
                            {
                                uRLaddress = info2.URLaddress;
                                str10 = str7;
                                str7 = str10 + "   <li>" + str3 + " <a href=\"" + uRLaddress + "\" " + str2 + ">\r\n";
                                str7 = str7 + "   " + info2.ClassCName + "</a>";
                                str7 = str7 + "   </li>\r\n";
                            }
                        }
                        else if ((str5 == "-1") && (info2.SiteID == this.Param_SiteID))
                        {
                            uRLaddress = this.GetClassURL(info2.Domain, info2.isDelPoint, info2.ClassID, info2.SavePath, info2.SaveClassframe, info2.ClassSaveRule, info2.IsURL, info2.URLaddress, info2.isPage);
                            str10 = str7;
                            str7 = str10 + "   <li>" + str3 + " <a href=\"" + uRLaddress + "\" " + str2 + ">\r\n";
                            str7 = str7 + "   " + info2.ClassCName + "</a>";
                            str7 = str7 + "   </li>\r\n";
                        }
                        else if ((info2.ParentID == str5) && (info2.SiteID == this.Param_SiteID))
                        {
                            uRLaddress = this.GetClassURL(info2.Domain, info2.isDelPoint, info2.ClassID, info2.SavePath, info2.SaveClassframe, info2.ClassSaveRule, info2.IsURL, info2.URLaddress, info2.isPage);
                            str10 = str7;
                            str7 = str10 + "   <li>" + str3 + " <a href=\"" + uRLaddress + "\" " + str2 + ">\r\n";
                            str7 = str7 + "   " + info2.ClassCName + "</a>";
                            str7 = str7 + "   </li>\r\n";
                        }
                    }
                }
            }
            return str7;
        }

        public string Analyse_ClassNaviRead()
        {
            string str8;
            string str = this.GetParamValue("FS:ClassID") ?? "0";
            string paramValue = this.GetParamValue("FS:ClassTitleNumber");
            string s = this.GetParamValue("FS:ClassNaviTitleNumber");
            string classId = "";
            if (str != "0")
            {
                classId = str;
            }
            else if (this.Param_CurrentClassID != null)
            {
                classId = this.Param_CurrentClassID;
            }
            string str5 = "";
            if (!(classId != ""))
            {
                return str5;
            }
            PubClassInfo classById = CommonData.GetClassById(classId);
            if (classById == null)
            {
                return str5;
            }
            string str6 = this.GetClassURL(classById.Domain, classById.isDelPoint, classById.ClassID, classById.SavePath, classById.SaveClassframe, classById.ClassSaveRule, classById.IsURL, classById.URLaddress, classById.isPage);
            str5 = str5 + "<div>\r\n";
            if (paramValue != null)
            {
                str8 = str5;
                str5 = str8 + "   <a href=\"" + str6 + "\" style=\"font-weight:bold;\">" + Input.GetSubString(classById.ClassCName, int.Parse(paramValue)) + "</a>";
            }
            else
            {
                str8 = str5;
                str5 = str8 + "   <a href=\"" + str6 + "\" style=\"font-weight:bold;\">" + classById.ClassCName + "</a>";
            }
            str5 = str5 + "</div>\r\n" + "<div>\r\n";
            if (s != null)
            {
                str8 = str5;
                str5 = str8 + "   " + Input.GetSubString(classById.NaviContent, int.Parse(s)) + "<a href=\"" + str6 + "\">[详情]</a>";
            }
            else
            {
                str8 = str5;
                str5 = str8 + "   " + classById.NaviContent + "<a href=\"" + str6 + "\">[详情]</a>";
            }
            return (str5 + "</div>\r\n");
        }

        public string Analyse_ConstrNews()
        {
            return this.Analyse_List(null, "1");
        }

        public string Analyse_CopyRight()
        {
            string copyright = UIConfig.copyright;
            IDataReader sysParam = CommonData.DalPublish.GetSysParam();
            if (sysParam.Read())
            {
                copyright = sysParam["CopyRight"].ToString();
            }
            sysParam.Close();
            return copyright;
        }

        public string Analyse_CorrNews()
        {
            string tags = null;
            if ((this.Param_CurrentNewsID != null) && (this.Param_CurrentNewsID != string.Empty))
            {
                tags = CommonData.getNewsInfoById(this.Param_CurrentNewsID).Tags;
                if ((tags != null) && (tags != ""))
                {
                    return this.Analyse_List(tags, null);
                }
                return string.Empty;
            }
            return string.Empty;
        }

        public string Analyse_FlashFilt()
        {
            string str = "暂无幻灯新闻";
            string paramValue = this.GetParamValue("FS:FlashType");
            string classID = this.GetParamValue("FS:ClassID");
            string str4 = this.GetParamValue("FS:Flashweight");
            string str5 = this.GetParamValue("FS:Flashheight");
            string str6 = this.GetParamValue("FS:FlashBG");
            string str7 = this.GetParamValue("FS:ShowTitle");
            string str8 = this.GetParamValue("FS:isSub");
            string s = this.GetParamValue("FS:TitleNumber");
            if (str4 == null)
            {
                str4 = "200";
            }
            if (str5 == null)
            {
                str5 = "150";
            }
            if (str6 == null)
            {
                str6 = "FFF";
            }
            string str10 = " Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "' And ([NewsType]=1 or [NewsType]=2 or [NewsType]=3) And SubString([NewsProperty],7,1)='1'";
            if (UIConfig.WebDAL.ToLower() == "foosun.accessdal")
            {
                str10 = " Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "' And ([NewsType]=1 or [NewsType]=2 or [NewsType]=3) And mid([NewsProperty],7,1)='1'";
            }
            string str11 = " Order By [CreatTime] Desc";
            DataTable table = null;
            string sql = string.Empty;
            if (classID == null)
            {
                sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News]", str10, str11 });
            }
            else
            {
                string str18 = classID;
                if (str18 != null)
                {
                    if (!(str18 == "0"))
                    {
                        if (str18 == "-1")
                        {
                            sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News]", str10, str11 });
                            goto Label_0313;
                        }
                    }
                    else
                    {
                        if (str8 == "true")
                        {
                            str10 = str10 + " And [ClassID] In (" + this.getChildClassID(this.Param_CurrentClassID) + ")";
                        }
                        sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str10, str11 });
                        goto Label_0313;
                    }
                }
                if (str8 == "true")
                {
                    str10 = str10 + " And [ClassID] In(" + this.getChildClassID(classID) + ")";
                }
                else
                {
                    str10 = str10 + " And [ClassID] ='" + classID + "'";
                }
                sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News]", str10, str11 });
            }
        Label_0313:
            table = CommonData.DalPublish.ExecuteSql(sql);
            string input = "";
            string str14 = "";
            string str15 = "";
            if ((table != null) && (table.Rows.Count > 0))
            {
                int result = 10;
                int num2 = 0;
                if ((s != "") && (s != null))
                {
                    num2 = 1;
                    if (!int.TryParse(s, out result))
                    {
                        result = 10;
                    }
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    PubClassInfo classById = CommonData.GetClassById(table.Rows[i]["ClassID"].ToString());
                    input = input + table.Rows[i]["PicURL"].ToString() + "|";
                    str14 = str14 + this.GetNewsURL(table.Rows[i]["isDelPoint"].ToString(), table.Rows[i]["newsID"].ToString(), table.Rows[i]["SavePath"].ToString(), classById.SavePath + "/" + classById.SaveClassframe, table.Rows[i]["FileName"].ToString(), table.Rows[i]["FileEXName"].ToString(), table.Rows[i]["NewsType"].ToString(), table.Rows[i]["URLaddress"].ToString()) + "|";
                    if (num2 == 1)
                    {
                        str15 = str15 + Input.GetSubString(table.Rows[i]["NewsTitle"].ToString(), result) + "|";
                    }
                    else
                    {
                        str15 = str15 + table.Rows[i]["NewsTitle"].ToString() + "|";
                    }
                }
            }
            table.Clear();
            table.Dispose();
            input = Input.CutComma(input, "|");
            input = this.RelpacePicPath(input);
            str14 = Input.CutComma(str14, "|");
            str15 = Input.CutComma(str15, "|").Replace('"', ' ');
            if ((!(input != string.Empty) || !(str14 != string.Empty)) || !(str15 != string.Empty))
            {
                return str;
            }
            string[] strArray = input.Split(new char[] { '|' });
            string[] strArray2 = str14.Split(new char[] { '|' });
            string[] strArray3 = str15.Split(new char[] { '|' });
            if ((strArray.Length != strArray2.Length) || (strArray.Length != strArray3.Length))
            {
                return str;
            }
            if (strArray.Length < 2)
            {
                return "flash幻灯至少要两条以上才可以显示";
            }
            string str16 = CommonData.SiteDomain + "/Flash.swf";
            str = "<script language=\"javascript\" type=\"text/javascript\">\r\n";
            str = ((str + "<!--\r\n") + "var Flash_Width = " + str4 + ";\r\n") + "var Flash_Height = " + str5 + ";\r\n";
            if (str7 == "true")
            {
                str = str + "var Txt_Height = 20;\r\n";
            }
            else
            {
                str = str + "var Txt_Height = 0;\r\n";
            }
            string str19 = ((((str + "var Swf_Height = parseInt(Flash_Height + Txt_Height);\r\n") + "var Pics_ = '" + input + "';\r\n") + "var Links_ = '" + str14 + "';\r\n") + "var Texts_ = '" + str15 + "';\r\n") + "document.write('<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"'+ Flash_Width +'\" height=\"'+ Swf_Height +'\">');\r\n";
            str19 = (str19 + "document.write('<param name=\"allowScriptAccess\" value=\"sameDomain\"><param name=\"movie\" value=\"" + str16 + "\"><param name=\"quality\" value=\"high\"><param name=\"bgcolor\" value=\"#" + str6 + "\">');\r\n") + "document.write('<param name=\"menu\" value=\"false\"><param name=\"wmode\" value=\"opaque\">');\r\n" + "document.write('<param name=\"FlashVars\" value=\"pics='+Pics_+'&links='+Links_+'&texts='+Texts_+'&borderwidth='+Flash_Width+'&borderheight='+Flash_Height+'&textheight='+Txt_Height+'\">');\r\n";
            return (((str19 + "document.write('<embed src=\"" + str16 + "\" wmode=\"opaque\" FlashVars=\"pics='+Pics_+'&links='+Links_+'&texts='+Texts_+'&borderwidth='+Flash_Width+'&borderheight='+Flash_Height+'&textheight='+Txt_Height+'\" menu=\"false\" bgcolor=\"#" + str6 + "\" quality=\"high\" width=\"'+ Flash_Width +'\" height=\"'+ Swf_Height +'\" allowScriptAccess=\"sameDomain\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />');\r\n") + "document.write('</object>');\r\n") + "//-->\r\n" + "</script>\r\n");
        }

        public string Analyse_FormList()
        {
            int pageCount = 0;
            int recordCount = 0;
            string input = this.Mass_Inserted;
            string paramValue = this.GetParamValue("FS:PageSize");
            string tablename = this.GetParamValue("FS:FormTableName");
            string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (!id.Equals(string.Empty))
            {
                string str5 = string.Empty;
                input = LabelStyle.GetStyleByID(id);
                str5 = this.getControl(input, tablename, paramValue.ToString(), out recordCount, out pageCount, 1);
                string str6 = id + "." + tablename + "." + paramValue + ".";
                return ("<div id=\"" + str6 + "\"></div><script src=\"/customform/CustomFormList.aspx?divid=" + str6 + "&pageindex=1\" type=\"text/javascript\" id=\"" + str6 + "_script\"></script>");
            }
            pageCount = 0;
            recordCount = 0;
            return "";
        }

        public string Analyse_FormList(int pageindex, string context)
        {
            int num;
            int num2;
            string[] strArray = context.Split(new char[] { '.' });
            if (strArray.Length != 4)
            {
                num = 0;
                num2 = 0;
                return "";
            }
            string mystyle = "";
            string tablename = strArray[1];
            string pagesize = strArray[2];
            string id = strArray[0];
            if (!id.Equals(string.Empty))
            {
                object obj2;
                int num3 = 0;
                if ((pageindex % 5) == 0)
                {
                    num3 = (((pageindex / 5) - 1) * 5) + 1;
                }
                else
                {
                    num3 = ((pageindex / 5) * 5) + 1;
                }
                string str5 = string.Empty;
                mystyle = LabelStyle.GetStyleByID(id);
                str5 = this.getControl(mystyle, tablename, pagesize, out num2, out num, pageindex);
                string str6 = "<div class=\"foosun_customform_list\">" + str5 + "</div>";
                if (num <= 1)
                {
                    return str6;
                }
                str6 = str6 + "<div style=\"padding-top:15px;\" class=\"foosun_pagebox\">";
                if (pageindex < 6)
                {
                    str6 = str6 + "<span class=\"foosun_pagebox_num\">上五页</span>";
                }
                else
                {
                    obj2 = str6;
                    str6 = string.Concat(new object[] { obj2, "<a href=\"javascript:JsReloader('", context, "_script','/customform/CustomFormList.aspx?divid=", context, "&pageindex=", num3 - 5, "' );void(0);\">上五页</a>" });
                }
                if (pageindex > 1)
                {
                    obj2 = str6;
                    str6 = string.Concat(new object[] { obj2, "<a href=\"javascript:JsReloader('", context, "_script','/customform/CustomFormList.aspx?divid=", context, "&pageindex=", pageindex - 1, "' );void(0);\">上一页</a>" });
                }
                else
                {
                    str6 = str6 + "<span class=\"foosun_pagebox_num\">上一页</span>";
                }
                for (int i = num3; i < (((num3 + 5) > num) ? (num + 1) : (num3 + 5)); i++)
                {
                    if (pageindex == i)
                    {
                        obj2 = str6;
                        str6 = string.Concat(new object[] { obj2, "<span class=\"foosun_pagebox_num_nonce\">", i, "</span>" });
                    }
                    else
                    {
                        obj2 = str6;
                        str6 = string.Concat(new object[] { obj2, "<a href=\"javascript:JsReloader('", context, "_script','/customform/CustomFormList.aspx?divid=", context, "&pageindex=", i, "' );void(0);\">", i, "</a>" });
                    }
                }
                if (pageindex >= num)
                {
                    str6 = str6 + "<span class=\"foosun_pagebox_num\">下一页</span>";
                }
                else
                {
                    obj2 = str6;
                    str6 = string.Concat(new object[] { obj2, "<a href=\"javascript:JsReloader('", context, "_script','/customform/CustomFormList.aspx?divid=", context, "&pageindex=", pageindex + 1, "' );void(0);\">下一页</a>" });
                }
                if (pageindex > (num - 5))
                {
                    str6 = str6 + "<span class=\"foosun_pagebox_num\">下五页</span>";
                }
                else
                {
                    obj2 = str6;
                    str6 = string.Concat(new object[] { obj2, "<a href=\"javascript:JsReloader('", context, "_script','/customform/CustomFormList.aspx?divid=", context, "&pageindex=", num3 + 5, "');void(0);\">下五页</a>" });
                }
                return (str6 + "</div>");
            }
            num = 0;
            num2 = 0;
            return "";
        }

        public string Analyse_freeJS()
        {
            string paramValue = this.GetParamValue("FS:JSID");
            string str2 = "";
            if (paramValue != null)
            {
                str2 = this.validateCatch(paramValue);
            }
            return str2;
        }

        public string Analyse_FrindList()
        {
            int number = this.Param_Loop;
            string paramValue = this.GetParamValue("FS:Cols");
            string input = this.GetParamValue("FS:FType");
            string str3 = this.GetParamValue("FS:isAdmin");
            string str4 = this.GetParamValue("FS:isDiv");
            string classId = this.GetParamValue("FS:TypeClassID");
            if (!((paramValue != null) && Input.IsInteger(paramValue)))
            {
                paramValue = "10";
            }
            if (!((input != null) && Input.IsInteger(input)))
            {
                input = "0";
            }
            if (str4 == null)
            {
                str4 = "true";
            }
            if (!((str3 != null) && Input.IsInteger(str3)))
            {
                str3 = "3";
            }
            string str6 = string.Empty;
            if (str4 != "true")
            {
                str6 = str6 + "<table style=\"width:100%\" border=\"0\"><tr>";
            }
            int num2 = 0;
            IDataReader reader = CommonData.DalPublish.GetFriend(int.Parse(input), number, int.Parse(str3), classId);
            string str7 = Foosun.DALFactory.DataAccess.CreateFrindLink().ParamStart().Rows[0]["ArrSize"].ToString();
            if (string.IsNullOrEmpty(str7))
            {
                str7 = "80,30";
            }
            string[] strArray = str7.Split(new char[] { ',' });
            string str8 = strArray[0];
            string str9 = strArray[1];
            while (reader.Read())
            {
                if ((reader["ClassID"].ToString() != null) && reader["ClassID"].ToString().Equals(classId))
                {
                    object obj2;
                    if (str4 == "true")
                    {
                        if (input == "0")
                        {
                            obj2 = str6;
                            str6 = string.Concat(new object[] { obj2, "<li><a border='0' href=\"", reader["Url"], "\" target=\"", UIConfig.Linktagertimg, "\"><img border='0' width=\"", str8, "\" height=\"", str9, "\" src=\"", reader["PicURL"].ToString().ToLower().Replace("{@dirfile}", UIConfig.dirFile), "\" alt=\"", reader["Name"].ToString(), "\" /></a></li>\r\n" });
                        }
                        else
                        {
                            obj2 = str6;
                            str6 = string.Concat(new object[] { obj2, "<li><a border='0' href=\"", reader["Url"], "\" alt=\"", reader["Name"].ToString(), "\" target=\"", UIConfig.Linktagert, "\">", reader["Name"].ToString(), "</a></li>\r\n" });
                        }
                    }
                    else
                    {
                        if (input == "0")
                        {
                            obj2 = str6;
                            str6 = string.Concat(new object[] { obj2, "<td><a border='0' href=\"", reader["Url"], "\" title=\"", reader["Content"].ToString(), "\" target=\"", UIConfig.Linktagertimg, "\"><img border='0' width=\"", str8, "\" height=\"", str9, "\" src=\"", reader["PicURL"].ToString().ToLower().Replace("{@dirfile}", UIConfig.dirFile), "\" alt=\"", reader["Name"].ToString(), "\" /></a></td>\r\n" });
                        }
                        else
                        {
                            obj2 = str6;
                            str6 = string.Concat(new object[] { obj2, "<td><a border='0' href=\"", reader["Url"], "\" title=\"", reader["Content"].ToString(), "\" target=\"", UIConfig.Linktagert, "\">", reader["Name"].ToString(), "</a></td>\r\n" });
                        }
                        if (((num2 + 1) % int.Parse(paramValue)) == 0)
                        {
                            str6 = str6 + "</tr>\r\n<tr>\r\n";
                        }
                    }
                    num2++;
                }
            }
            reader.Close();
            if (str4 != "true")
            {
                str6 = str6 + "</tr>\r\n</table>\r\n";
            }
            return str6;
        }

        public string Analyse_GroupMember()
        {
            int num;
            string str = string.Empty;
            if (!int.TryParse(this.GetParamValue("FS:Cols"), out num))
            {
                num = 1;
            }
            if (num < 1)
            {
                num = 1;
            }
            string paramValue = this.GetParamValue("FS:GroupType");
            string isDiv = this.GetParamValue("FS:isDiv");
            if (isDiv == null)
            {
                isDiv = "true";
            }
            string str4 = this.GetParamValue("FS:CSS");
            string ulID = this.GetParamValue("FS:ulID");
            string ulClass = this.GetParamValue("FS:ulClass");
            string str7 = this.GetParamValue("FS:TitleNumer");
            string str8 = this.GetParamValue("FS:ShowM");
            string showNavi = this.GetParamValue("FS:ShowNavi");
            string naviPic = this.GetParamValue("FS:NaviPic");
            string naviCSS = this.GetParamValue("FS:NaviCSS");
            string str12 = "";
            string str17 = paramValue;
            if (str17 != null)
            {
                if (!(str17 == "hot"))
                {
                    if (str17 == "click")
                    {
                        str12 = "Browsenumber";
                        goto Label_013A;
                    }
                    if (str17 == "Mmore")
                    {
                        str12 = "Cnt1";
                        goto Label_013A;
                    }
                    if (str17 == "Last")
                    {
                        str12 = "Creatime";
                        goto Label_013A;
                    }
                }
                else
                {
                    str12 = "Cnt1";
                    goto Label_013A;
                }
            }
            str12 = "Creatime";
        Label_013A:
            if (str4 != null)
            {
                str4 = " class=\"" + str4 + "\"";
            }
            string dirUser = UIConfig.dirUser;
            int i = 0;
            IDataReader discussInfo = CommonData.DalPublish.GetDiscussInfo(paramValue, this.Param_Loop);
            while (discussInfo.Read())
            {
                string str14 = "";
                string subString = discussInfo["Cname"].ToString();
                if (str7 != null)
                {
                    subString = Input.GetSubString(subString, Convert.ToInt32(str7));
                }
                if (str8 == "true")
                {
                    str14 = this.getNavi(showNavi, naviCSS, naviPic, i) + "<a href=\"" + CommonData.SiteDomain + "/" + dirUser + "/index.aspx?urls=discuss/discussTopi_list.aspx?DisID=" + discussInfo["DisID"].ToString() + "\" " + str4 + ">" + subString + "</a> " + discussInfo[str12].ToString();
                }
                else
                {
                    str14 = this.getNavi(showNavi, naviCSS, naviPic, i) + "<a href=\"" + CommonData.SiteDomain + "/" + dirUser + "/index.aspx?urls=discuss/discussTopi_list.aspx?DisID=" + discussInfo["DisID"].ToString() + "\" " + str4 + ">" + subString + "</a>";
                }
                if (isDiv == "true")
                {
                    str = (str + "<li>\r\n") + str14 + "</li>\r\n";
                }
                else
                {
                    isDiv = "false";
                    if (num == 1)
                    {
                        str = str + "<tr>\r\n<td>\r\n" + str14 + "\r\n</td>\r\n</tr>\r\n";
                    }
                    else
                    {
                        str14 = string.Concat(new object[] { "<td width=\"", 100 / num, "%\">\r\n", str14, "\r\n</td>\r\n" });
                        if ((i > 0) && (((i + 1) % num) == 0))
                        {
                            str14 = "</tr>\r\n<tr>\r\n";
                        }
                        str = str + str14;
                    }
                }
                i++;
            }
            discussInfo.Close();
            if (i == 0)
            {
                return str;
            }
            if (!(isDiv == "fasle"))
            {
                return str;
            }
            if ((str != string.Empty) && (num > 1))
            {
                str = "<tr>\r\n" + str;
                if ((i % num) != 0)
                {
                    int num3 = num - i;
                    if (num3 < 0)
                    {
                        num3 = num - (i % num);
                    }
                    for (int j = 0; j < num3; j++)
                    {
                        object obj2 = str;
                        str = string.Concat(new object[] { obj2, "<td width=\"", 100 / num, "%\">\r\n </td>\r\n" });
                    }
                }
                str = str + "</tr>\r\n";
            }
            return (this.News_List_Head(isDiv, ulID, ulClass, "") + str + this.News_List_End(isDiv));
        }

        public string Analyse_History()
        {
            string paramValue = this.GetParamValue("FS:IsDate");
            string str2 = this.GetParamValue("FS:ShowDate");
            string saveIndexPage = "";
            IDataReader sysParam = CommonData.DalPublish.GetSysParam();
            if (sysParam.Read() && (sysParam["SaveIndexPage"] != DBNull.Value))
            {
                saveIndexPage = sysParam["SaveIndexPage"].ToString();
            }
            sysParam.Close();
            if (str2 == "true")
            {
                return this.getDateForm(saveIndexPage);
            }
            return this.getDateJs(saveIndexPage);
        }

        public string Analyse_HistoryIndex()
        {
            object obj2;
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            for (int i = 0x7d5; i <= DateTime.Now.Year; i++)
            {
                if (i == DateTime.Now.Year)
                {
                    obj2 = str2;
                    str2 = string.Concat(new object[] { obj2, "<option selected value=\"", i, "\">", i, "</option>\r" });
                }
                else
                {
                    obj2 = str2;
                    str2 = string.Concat(new object[] { obj2, "<option value=\"", i, "\">", i, "</option>\r" });
                }
            }
            for (int j = 1; j <= 12; j++)
            {
                if (j == DateTime.Now.Month)
                {
                    obj2 = str3;
                    str3 = string.Concat(new object[] { obj2, "<option selected value=\"", j, "\">", j, "</option>\r" });
                }
                else
                {
                    obj2 = str3;
                    str3 = string.Concat(new object[] { obj2, "<option value=\"", j, "\">", j, "</option>\r" });
                }
            }
            for (int k = 1; k <= 0x1f; k++)
            {
                if (k == (DateTime.Now.Day - 1))
                {
                    obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, "<option selected value=\"", k, "\">", k, "</option>\r" });
                }
                else
                {
                    obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, "<option value=\"", k, "\">", k, "</option>\r" });
                }
            }
            return (((((((((str + "<div id=\"index_historyindexdiv\"><form method=\"POST\" id=\"index_historyindex1\"><select name=\"h_year\" id=\"h_year1\">" + str2 + "</select>年&nbsp;") + "<select name=\"h_month\" id=\"h_month1\">" + str3 + "</select>月&nbsp;") + "<select name=\"h_day\" id=\"h_day1\">" + str4 + "</select>日&nbsp;") + "<input type=\"image\" name=\"imageFields\" src=\"" + CommonData.SiteDomain + "/sysimages/folder/buttonreview.gif\" onclick=\"s_getHistoryindex();return false;\" /></form></div>\r\n") + "<script language=\"javascript\">\r\n" + "function s_getHistoryindex()\r\n") + "{\r\n" + "   var syear = index_historyindex1.h_year.options[index_historyindex1.h_year.selectedIndex].value;;\r\n") + "   var smonth = index_historyindex1.h_month.options[index_historyindex1.h_month.selectedIndex].value;\r\n" + "   var sday = index_historyindex1.h_day.options[index_historyindex1.h_day.selectedIndex].value;\r\n") + "   window.open('" + CommonData.SiteDomain + "/history.aspx?year='+syear+'&month=' + smonth + '&day=' + sday +'','_blank');return false;\r\n") + "}\r\n" + "</script>");
        }

        public string Analyse_HotTag()
        {
            return string.Empty;
        }

        public string Analyse_LastComm()
        {
            string str = "";
            string paramValue = this.GetParamValue("FS:ShowNavi");
            string str3 = this.GetParamValue("FS:CSS");
            string str4 = this.GetParamValue("FS:ShowDate");
            string naviPic = this.GetParamValue("FS:NaviPic");
            string naviCSS = this.GetParamValue("FS:NaviCSS");
            string str7 = this.GetParamValue("FS:TitleNumer");
            if (str3 != null)
            {
                str3 = str3 + " class=\"" + str3 + "\"";
            }
            int num = 20;
            if (str7 != null)
            {
                num = Convert.ToInt32(str7);
            }
            DataTable apiComm = CommonData.DalPublish.GetApiComm(this.Param_Loop);
            str = "<ul>\r\n";
            if (apiComm != null)
            {
                for (int i = 0; i < apiComm.Rows.Count; i++)
                {
                    string str11;
                    string subString = Input.GetSubString(apiComm.Rows[i]["Content"].ToString(), num);
                    string str9 = CommonData.SiteDomain + "/Comment.aspx?CommentType=getlist&id=" + apiComm.Rows[i]["InfoID"].ToString();
                    if (str4 == "right")
                    {
                        str11 = str;
                        str = str11 + "<li style=\"list-style:none;\"><span style=\"float:left\">" + this.getNavi(paramValue, naviCSS, naviPic, i) + " <a href=\"" + str9 + "\" " + str3 + ">" + subString + "</a></span> <span style=\"float:right\">" + apiComm.Rows[i]["creatTime"].ToString() + "</span></li>\r\n";
                    }
                    else if (str4 == "left")
                    {
                        str11 = str;
                        str = str11 + "<li style=\"list-style:none;\"><span style=\"float:left\">" + this.getNavi(paramValue, naviCSS, naviPic, i) + " <a href=\"" + str9 + "\" " + str3 + ">" + subString + "</a></span> <span>" + apiComm.Rows[i]["creatTime"].ToString() + "</span></li>\r\n";
                    }
                    else
                    {
                        str11 = str;
                        str = str11 + "<li style=\"list-style:none;\"><span style=\"float:left\">" + this.getNavi(paramValue, naviCSS, naviPic, i) + " <a href=\"" + str9 + "\" " + str3 + ">" + subString + "</a></span></li>\r\n";
                    }
                }
            }
            return (str + "</ul>\r\n");
        }

        public string Analyse_List(string Tags, string isConstr)
        {
            int num;
            string str33;
            string str43;
            string input = this.Mass_Inserted;
            string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (!id.Equals(string.Empty))
            {
                input = LabelStyle.GetStyleByID(id);
            }
            if (input.Trim().Equals(string.Empty))
            {
                return string.Empty;
            }
            string paramValue = this.GetParamValue("FS:NewsType");
            string str4 = this.GetParamValue("FS:SubNews");
            string classID = this.GetParamValue("FS:ClassID");
            string str6 = this.GetParamValue("FS:SpecialID");
            if (!int.TryParse(this.GetParamValue("FS:Cols"), out num))
            {
                num = 1;
            }
            if (num < 1)
            {
                num = 1;
            }
            string str7 = this.GetParamValue("FS:Desc");
            string str8 = this.GetParamValue("FS:DescType");
            string str9 = this.GetParamValue("FS:isDiv");
            if (str9 == null)
            {
                str9 = "true";
            }
            string str10 = this.GetParamValue("FS:TabCSS");
            string str11 = this.GetParamValue("FS:isPic");
            string str12 = this.GetParamValue("FS:TitleNumer");
            string str13 = this.GetParamValue("FS:ContentNumber");
            string str14 = this.GetParamValue("FS:NaviNumber");
            string str15 = this.GetParamValue("FS:ClickNumber");
            string str16 = this.GetParamValue("FS:ShowDateNumer");
            string str17 = this.GetParamValue("FS:isSub");
            string str18 = this.GetParamValue("FS:ShowNavi");
            string str19 = this.GetParamValue("FS:NaviCSS");
            string str20 = this.GetParamValue("FS:ColbgCSS");
            string str21 = this.GetParamValue("FS:NaviPic");
            string str22 = this.GetParamValue("FS:HashNaviContent");
            string str23 = this.GetParamValue("FS:ClassStyleID");
            string str24 = this.GetParamValue("FS:ColumnNumber");
            string str25 = this.GetParamValue("FS:ColumnCss");
            string str26 = this.GetParamValue("FS:ColumnNewsCss");
            string str27 = this.GetParamValue("FS:More");
            string str28 = " [ID],ClassID";
            string str29 = DBConfig.TableNamePrefix + "News Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "'";
            if (str22 != null)
            {
                if (str22 == "false")
                {
                    str29 = str29 + " and  NaviContent=''";
                }
                else if (str22 == "true")
                {
                    str29 = str29 + " and NaviContent<>''";
                }
            }
            switch (paramValue)
            {
                case "Rec":
                    str29 = str29 + " And NewsProperty like '1%'";
                    break;

                case "Hot":
                    str29 = str29 + " And NewsProperty like '____1%'";
                    break;

                case "Tnews":
                    str29 = str29 + " And NewsProperty like '________1%'";
                    break;

                case "ANN":
                    str29 = str29 + " And NewsProperty like '__________1%'";
                    break;

                case "MarQuee":
                    str29 = str29 + " And NewsProperty like '__1%'";
                    break;

                case "Special":
                    if (str6 != null)
                    {
                        str43 = str29;
                        str29 = str43 + " And [NewsID] In (Select [NewsID] From [" + DBConfig.TableNamePrefix + "special_news] Where [SpecialID]='" + str6 + "')";
                    }
                    else if (this.Param_CurrentSpecialID != null)
                    {
                        str43 = str29;
                        str29 = str43 + " And [NewsID] In (Select [NewsID] From [" + DBConfig.TableNamePrefix + "special_news] Where [SpecialID]='" + this.Param_CurrentSpecialID + "')";
                    }
                    else
                    {
                        str29 = str29 + " And [NewsID] In (Select [NewsID] From [" + DBConfig.TableNamePrefix + "special_news])";
                    }
                    break;

                case "SubNews":
                    if (this.Param_CurrentClassID == null)
                    {
                        return "";
                    }
                    return this.getSubNewsList(input, id, num, str7, str8, str9, "", "", str11, str12, str13, str14, str15, str16, str18, str19, str20, str21, str4, str23, str24, str25, str26, str10);

                case "Jnews":
                    str29 = str29 + " And NewsProperty like '______________1%'";
                    break;
            }
            switch (str11)
            {
                case "true":
                    str29 = str29 + " And [NewsType]=1";
                    break;

                case "false":
                    str29 = str29 + " And ([NewsType]=0 Or [NewsType]=2)";
                    break;
            }
            if ((str15 != null) && (str15 != string.Empty))
            {
                str29 = str29 + " And [Click] >= " + int.Parse(str15);
            }
            if ((str16 != null) && (str16 != ""))
            {
                if (UIConfig.WebDAL.ToLower() == "foosun.accessdal")
                {
                    str29 = str29 + " And DateDiff('d',[CreatTime] ,Now()) < " + int.Parse(str16);
                }
                else
                {
                    str29 = str29 + " And DateDiff(day,[CreatTime] ,GetDate()) < " + int.Parse(str16);
                }
            }
            if (!string.IsNullOrEmpty(Tags))
            {
                string str30 = "";
                string[] strArray = Tags.Split(new char[] { '|' });
                string str31 = null;
                for (int j = 0; j < strArray.Length; j++)
                {
                    str31 = strArray[j];
                    if (j == 0)
                    {
                        str30 = "[Tags] like '%" + str31 + "%'";
                    }
                    else
                    {
                        str30 = str30 + "or [Tags] like '%" + str31 + "%'";
                    }
                }
                str43 = str29;
                str29 = str43 + " And (" + str30 + ") and [NewsID] <>'" + this.Param_CurrentNewsID + "'";
            }
            if (isConstr == "1")
            {
                str29 = str29 + " And [isConstr]=1";
            }
            string str32 = string.Empty;
            if ((str7 != null) && (str7.ToLower() == "asc"))
            {
                str32 = str32 + " asc";
            }
            else
            {
                str32 = str32 + " desc";
            }
            string str42 = str8;
            if (str42 != null)
            {
                if (!(str42 == "id"))
                {
                    if (str42 == "date")
                    {
                        str32 = " Order By [CreatTime] " + str32 + ",id " + str32;
                        goto Label_0829;
                    }
                    if (str42 == "click")
                    {
                        str32 = " Order By [Click] " + str32 + ",id " + str32;
                        goto Label_0829;
                    }
                    if (str42 == "pop")
                    {
                        str32 = " Order By [OrderID]" + str32 + ",id " + str32;
                        goto Label_0829;
                    }
                    if (str42 == "digg")
                    {
                        str32 = " Order By [TopNum]" + str32 + ",id " + str32;
                        goto Label_0829;
                    }
                }
                else
                {
                    str32 = " Order By id " + str32;
                    goto Label_0829;
                }
            }
            if (paramValue == "Hot")
            {
                str32 = " Order By [Click] " + str32 + ",id " + str32;
            }
            else
            {
                str32 = " Order By [CreatTime] " + str32 + ",id " + str32;
            }
        Label_0829:
            str33 = string.Empty;
            bool flag = false;
            if ((str4 != null) && (str4 == "true"))
            {
                flag = true;
                if (this.GetParamValue("FS:SubNaviCSS") != null)
                {
                    str33 = this.GetParamValue("FS:SubNaviCSS");
                }
            }
            string sql = string.Empty;
            if ((classID == null) || (classID == "0"))
            {
                if ((this._TemplateType == TempType.Class) || (this._TemplateType == TempType.News))
                {
                    if (str17 == "true")
                    {
                        str29 = str29 + " And [ClassID] In (" + this.getChildClassID(this.Param_CurrentClassID) + ")";
                    }
                    else
                    {
                        str29 = str29 + " And [ClassID]='" + this.Param_CurrentClassID + "'";
                    }
                    sql = string.Concat(new object[] { "select top ", this.Param_Loop, "  ", str28, " from ", str29, " ", str32 });
                }
                else
                {
                    sql = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str28, " from ", str29, str32 });
                }
            }
            else if (classID == "-1")
            {
                sql = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str28, " from ", str29, str32 });
            }
            else
            {
                if ((str17 == "true") || (classID.IndexOf("|") > -1))
                {
                    if (str17 == "true")
                    {
                        str29 = str29 + " And [ClassID] In (" + this.getChildClassID(classID) + ")";
                    }
                    else
                    {
                        str29 = str29 + " And [ClassID] In ('" + classID.Replace("|", "','") + "')";
                    }
                }
                else
                {
                    str29 = str29 + " And [ClassID] ='" + classID + "'";
                }
                sql = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str28, " from ", str29, str32 });
            }
            DataTable table = CommonData.DalPublish.ExecuteSql(sql);
            if ((table == null) || (table.Rows.Count < 1))
            {
                return string.Empty;
            }
            string str35 = string.Empty;
            int titleNumer = 30;
            int contentNumber = 200;
            int naviNumber = 200;
            if ((str12 != null) && Input.IsInteger(str12))
            {
                titleNumer = int.Parse(str12);
            }
            if ((str13 != null) && Input.IsInteger(str13))
            {
                contentNumber = int.Parse(str13);
            }
            if ((str14 != null) && Input.IsInteger(str14))
            {
                naviNumber = int.Parse(str14);
            }
            int count = table.Rows.Count;
            string[] strArray2 = null;
            bool flag2 = false;
            if (str20 != null)
            {
                strArray2 = str20.Split(new char[] { '|' });
                flag2 = true;
            }
            string str36 = "";
            string str37 = string.Empty;
            string newValue = "";
            int i = 0;
            while (i < count)
            {
                Foosun.Model.News news;
                PubClassInfo classById = CommonData.GetClassById(table.Rows[i]["ClassID"].ToString());
                int num8 = i + 1;
                string str39 = string.Empty;
                if (num8 <= 3)
                {
                    str39 = "<span class=\"Num No" + num8.ToString() + "\">" + num8.ToString() + "</span>\r\n";
                }
                else
                {
                    str39 = "<span class=\"Num\">" + num8.ToString() + "</span>\r\n";
                }
                if (classById != null)
                {
                    str37 = this.GetClassURL(classById.Domain, classById.isDelPoint, classById.ClassID, classById.SavePath, classById.SaveClassframe, classById.ClassSaveRule, classById.IsURL, classById.URLaddress, classById.isPage);
                }
                str20 = "";
                if (flag2)
                {
                    if ((i % 2) == 0)
                    {
                        str20 = " class=\"" + strArray2[0].ToString() + "\"";
                        newValue = strArray2[0];
                    }
                    else
                    {
                        str20 = " class=\"" + strArray2[1].ToString() + "\"";
                        newValue = strArray2[1];
                    }
                }
                if (str9 == "true")
                {
                    str35 = str35 + this.getNavi(str18, str19, str21, i) + this.Analyse_ReadNews((int) table.Rows[i][0], titleNumer, contentNumber, naviNumber, input, id, 1, 1, 0).Replace("{#Index}", str39).Replace("{#ParityName}", newValue);
                    if (flag)
                    {
                        news = new Foosun.Model.News();
                        news = this.getNewsInfo((int) table.Rows[i][0], null);
                        str35 = str35 + this.GetSubSTR(news.NewsID, str33);
                    }
                }
                else
                {
                    str9 = "false";
                    str36 = this.getNavi(str18, str19, str21, i) + " " + this.Analyse_ReadNews((int) table.Rows[i][0], titleNumer, contentNumber, naviNumber, input, id, 1, 1, 0).Replace("{#Index}", str39).Replace("{#ParityName}", newValue);
                    if (flag)
                    {
                        news = new Foosun.Model.News();
                        news = this.getNewsInfo((int) table.Rows[i][0], null);
                        str36 = str36 + this.GetSubSTR(news.NewsID, str33);
                    }
                    if (num == 1)
                    {
                        str43 = str35;
                        str35 = str43 + "<tr" + str20 + ">\r\n<td>\r\n" + str36 + "\r\n</td>\r\n</tr>\r\n";
                    }
                    else
                    {
                        str36 = string.Concat(new object[] { "<td width=\"", 100 / num, "%\">\r\n", str36, "\r\n</td>\r\n" });
                        if (((i > 0) && (((i + 1) % num) == 0)) && ((i + 1) != count))
                        {
                            str36 = str36 + "</tr>\r\n<tr" + str20 + ">\r\n";
                        }
                        str35 = str35 + str36;
                    }
                }
                i++;
            }
            table.Clear();
            table.Dispose();
            if ((str9 == "false") && ((str35 != string.Empty) && (num > 1)))
            {
                if (strArray2 != null)
                {
                    str35 = "<tr class=\"" + strArray2[0] + "\">\r\n" + str35;
                }
                else
                {
                    str35 = "<tr>\r\n" + str35;
                }
                if ((i % num) != 0)
                {
                    int num9 = num - i;
                    if (num9 < 0)
                    {
                        num9 = num - (i % num);
                    }
                    for (int k = 0; k < num9; k++)
                    {
                        object obj2 = str35;
                        str35 = string.Concat(new object[] { obj2, "<td width=\"", 100 / num, "%\">\r\n </td>\r\n" });
                    }
                }
                str35 = str35 + "</tr>\r\n";
            }
            if (str35.EndsWith("<tr></tr>"))
            {
                str35 = str35.Substring(0, str35.Length - "<tr></tr>".Length);
            }
            str35 = this.News_List_Head(str9, "", "", "class=\"" + str10 + "\"") + str35;
            if (!string.IsNullOrEmpty(str27))
            {
                string dirDumm = UIConfig.dirDumm;
                if (dirDumm.Trim() != string.Empty)
                {
                    dirDumm = "/" + dirDumm;
                }
                if (str27.EndsWith(".gif") || str27.EndsWith(".jpg"))
                {
                    str27 = str27.ToLower().Replace("{@dirfile}", UIConfig.dirFile);
                    str43 = str35;
                    str35 = str43 + "<div style=\"width:100%;\" align=\"right\"><a href=\"" + str37 + "\" target=\"_blank\"><img src=\"" + str27 + "\" border=\"0\"></img></a></div>";
                }
                else
                {
                    str43 = str35;
                    str35 = str43 + "<div style=\"width:100%;\" align=\"right\"><a href=\"" + str37 + "\" target=\"_blank\">" + str27 + "</a></div>";
                }
            }
            return (str35 + this.News_List_End(str9));
        }

        public string Analyse_Meta(int Num, int ChID)
        {
            string paramValue = this.GetParamValue("FS:MetaContent");
            switch (this.TemplateType.ToString())
            {
                case "Index":
                    return "首页,新闻,CMS";

                case "News":
                    return (this.GetMetaContent(this.Param_CurrentNewsID, "News", Num) + "," + paramValue);

                case "Class":
                    return (this.GetMetaContent(this.Param_CurrentClassID, "Class", Num) + "," + paramValue);

                case "Special":
                    return (this.GetMetaContent(this.Param_CurrentSpecialID, "Special", Num) + "," + paramValue);

                case "ChIndex":
                    return CommonData.DalPublish.GetCHMeta(0, Num, ChID, "ChIndex");

                case "ChClass":
                    return CommonData.DalPublish.GetCHMeta(this.Param_CurrentCHClassID, Num, ChID, "ChClass");

                case "ChNews":
                    return CommonData.DalPublish.GetCHMeta(this.Param_CurrentCHNewsID, Num, ChID, "ChNews");

                case "ChSpecial":
                    return CommonData.DalPublish.GetCHMeta(this.Param_CurrentCHSpecialID, Num, ChID, "ChSpecial");
            }
            return "";
        }

        public string Analyse_NewUser()
        {
            string paramValue = this.GetParamValue("FS:ShowNavi");
            string naviPic = this.GetParamValue("FS:NaviPic");
            string naviCSS = this.GetParamValue("FS:NaviCSS");
            string str4 = this.GetParamValue("FS:CSS");
            string str5 = this.GetParamValue("FS:ShowDate");
            string str6 = "";
            if (str4 != null)
            {
                str6 = " class=\"" + str4 + "\"";
            }
            string str7 = "<ul>\r\n";
            DataTable sysUser = CommonData.DalPublish.GetSysUser(this.Param_Loop);
            if (sysUser != null)
            {
                for (int i = 0; i < sysUser.Rows.Count; i++)
                {
                    string str10;
                    string str8 = this.getNavi(paramValue, naviCSS, naviPic, i);
                    if (str5 == "right")
                    {
                        str10 = str7;
                        str7 = str10 + "<li style=\"list-style:none;\"><span style=\"float:left\">" + str8 + " <a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + sysUser.Rows[i]["UserName"].ToString() + UIConfig.extensions + "\" " + str6 + ">" + sysUser.Rows[i]["UserName"].ToString() + "</a></span><span style=\"float:right\">" + sysUser.Rows[i]["RegTime"].ToString() + "</a></span></li>\r\n";
                    }
                    else if (str5 == "left")
                    {
                        str10 = str7;
                        str7 = str10 + "<li style=\"list-style:none;\"><span style=\"float:left\">" + str8 + " <a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + sysUser.Rows[i]["UserName"].ToString() + UIConfig.extensions + "\" " + str6 + ">" + sysUser.Rows[i]["UserName"].ToString() + "</a></span> <span>" + sysUser.Rows[i]["RegTime"].ToString() + "</a></span></li>\r\n";
                    }
                    else
                    {
                        str10 = str7;
                        str7 = str10 + "<li style=\"list-style:none;\"><span>" + str8 + "<a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + sysUser.Rows[i]["UserName"].ToString() + UIConfig.extensions + "\" " + str6 + ">" + sysUser.Rows[i]["UserName"].ToString() + "</a></span></li>\r\n";
                    }
                }
                sysUser.Clear();
                sysUser.Dispose();
            }
            else
            {
                str7 = str7 + "<div><!--找不到记录--></div>\r\n";
            }
            return (str7 + "</ul>\r\n");
        }

        public string Analyse_NorFilt()
        {
            string str = "";
            string paramValue = this.GetParamValue("FS:ClassID");
            string str3 = this.GetParamValue("FS:isSub");
            string str4 = this.GetParamValue("FS:TitleNumer");
            string str5 = this.GetParamValue("FS:WCSS");
            string str6 = this.GetParamValue("FS:ShowTitle");
            string str7 = this.GetParamValue("FS:FlashSize");
            string str8 = this.GetParamValue("FS:Target");
            string str9 = " Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "' And [NewsType]=1 And SubString([NewsProperty],7,1)='1'";
            if (UIConfig.WebDAL.ToLower() == "foosun.accessdal")
            {
                str9 = " Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "' And [NewsType]=1 And mid([NewsProperty],7,1)='1'";
            }
            string str10 = " Order By [CreatTime] Desc";
            DataTable table = null;
            string sql = string.Empty;
            switch (paramValue)
            {
                case null:
                case "-1":
                    if (this._TemplateType == TempType.Class)
                    {
                        if (str3 == "true")
                        {
                            str9 = str9 + " And [ClassID] In (" + this.getChildClassID(this.Param_CurrentClassID) + ")";
                        }
                        sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str9, " And ClassID='", this.Param_CurrentClassID, "' ", str10 });
                    }
                    else
                    {
                        sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str9, str10 });
                    }
                    break;

                default:
                    if (paramValue == "0")
                    {
                        sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News]", str9, str10 });
                    }
                    else
                    {
                        if (str3 == "true")
                        {
                            str9 = str9 + " And [ClassID] In (" + this.getChildClassID(paramValue) + ")";
                        }
                        else
                        {
                            str9 = str9 + "And [ClassID] = '" + paramValue + "'";
                        }
                        sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News]", str9, str10 });
                    }
                    break;
            }
            table = CommonData.DalPublish.ExecuteSql(sql);
            if (table != null)
            {
                string str22;
                if (table.Rows.Count < 2)
                {
                    return "至少需要两条幻灯新闻才能正确显示幻灯效果";
                }
                string str12 = " width='200'";
                string str13 = " height='100'";
                if (str7 != null)
                {
                    string[] strArray = str7.Split(new char[] { '|' });
                    str12 = " width='" + strArray[0].ToString() + "'";
                    str13 = " height='" + strArray[1].ToString() + "'";
                }
                if (str5 != null)
                {
                    str5 = " class='" + str5 + "'";
                }
                if (str8 != null)
                {
                    str8 = " target='" + str8 + "'";
                }
                string str14 = "";
                string str15 = "";
                string str16 = "";
                string str17 = "";
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    PubClassInfo classById = CommonData.GetClassById(table.Rows[i]["ClassID"].ToString());
                    string str18 = this.RelpacePicPath(table.Rows[i]["PicURL"].ToString());
                    string str19 = this.GetNewsURL(table.Rows[i]["isDelPoint"].ToString(), table.Rows[i]["NewsID"].ToString(), table.Rows[i]["SavePath"].ToString(), classById.SavePath + "/" + classById.SaveClassframe, table.Rows[i]["FileName"].ToString(), table.Rows[i]["FileEXName"].ToString(), table.Rows[i]["NewsType"].ToString(), table.Rows[i]["URLaddress"].ToString());
                    string subString = table.Rows[i]["NewsTitle"].ToString();
                    if (str4 != null)
                    {
                        subString = Input.GetSubString(subString, Convert.ToInt32(str4));
                    }
                    if ((str18 != "") && (str18 != null))
                    {
                        if (str14 == "")
                        {
                            str14 = str14 + str18;
                            str15 = str15 + str19;
                            str22 = str16;
                            str16 = str22 + "<a href='" + str19 + "' " + str8 + " " + str5 + ">" + subString + "</a>";
                            str17 = str16;
                        }
                        else
                        {
                            str14 = str14 + "," + str18;
                            str15 = str15 + "," + str19;
                            str22 = str16;
                            str16 = str22 + ",<a href='" + str19 + "' " + str8 + " " + str5 + ">" + subString + "</a>";
                        }
                    }
                }
                str = ((((((((((((((((((((str + "<script language=\"vbscript\">\r\n" + "Dim FileList,FileListArr,TxtList,TxtListArr,LinkList,LinkArr\r\n") + "FileList = \"" + str14 + "\"\r\n") + "LinkList = \"" + str15 + "\"\r\n") + "TxtList = \"" + str16 + "\"\r\n") + "FileListArr = Split(FileList,\",\")\r\n" + "LinkArr = Split(LinkList,\",\")\r\n") + "TxtListArr = Split(TxtList,\",\")\r\n" + "Dim CanPlay\r\n") + "CanPlay = CInt(Split(Split(navigator.appVersion,\";\")(1),\" \")(2))>5\r\n" + "Dim FilterStr\r\n") + "FilterStr = \"RevealTrans(duration=2,transition=23)\"\r\n" + "FilterStr = FilterStr + \";BlendTrans(duration=2)\"\r\n") + "If CanPlay Then\r\n" + "FilterStr = FilterStr + \";progid:DXImageTransform.Microsoft.Fade(duration=2,overlap=0)\"\r\n") + "FilterStr = FilterStr + \";progid:DXImageTransform.Microsoft.Wipe(duration=3,gradientsize=0.25,motion=reverse)\"\r\n" + "Else\r\n") + "Msgbox \"幻灯片播放具有多种动态图片切换效果，但此功能需要您的浏览器为IE5.5或以上版本，否则您将只能看到部分的切换效果。\",64\r\n" + "End If\r\n") + "Dim FilterArr\r\n" + "FilterArr = Split(FilterStr,\";\")\r\n") + "Dim PlayImg_M\r\n" + "PlayImg_M = 5 * 1000  \r\n") + "Dim I\r\n" + "I = 1\r\n") + "Sub ChangeImg\r\n" + "Do While FileListArr(I)=\"\"\r\n") + "I = I + 1\r\n" + "If I>UBound(FileListArr) Then I = 0\r\n") + "Loop\r\n" + "Dim J\r\n") + "If I>UBound(FileListArr) Then I = 0\r\n" + "Randomize\r\n") + "J = Int((UBound(FilterArr)+1))\r\n" + "Img.style.filter = FilterArr(J)\r\n") + "Img.filters(0).Apply\r\n" + "Img.Src = FileListArr(I)\r\n") + "Img.filters(0).play\r\n" + "Link.Href = LinkArr(I)\r\n";
                if (str6 == "true")
                {
                    str = (str + "Txt.filters(0).Apply\r\n") + "Txt.innerHTML = TxtListArr(I)\r\n" + "Txt.filters(0).play\r\n";
                }
                str22 = (((((str + "I = I + 1\r\n") + "If I>UBound(FileListArr) Then I = 0\r\n" + "TempImg.Src = FileListArr(I)\r\n") + "TempLink.Href = LinkArr(I)\r\n" + "SetTimeout \"ChangeImg\", PlayImg_M,\"VBScript\"\r\n") + "End Sub\r\n" + "</SCRIPT>\r\n") + "<TABLE WIDTH=\"100%\" height=\"100%\" BORDER=\"0\" CELLSPACING=\"0\" CELLPADDING=\"0\">\r\n" + "<TR ID=\"NoScript\">\r\n") + "<TD Align=\"Center\" Style=\"Color:White\">对不起，图片浏览功能需脚本支持，但您的浏览器已经设置了禁止脚本运行。请您在浏览器设置中调整有关安全选项。</TD>\r\n" + "</TR>\r\n";
                str = (str22 + "<TR Style=\"Display:none\" ID=\"CanRunScript\"><TD HEIGHT=\"100%\" Align=\"Center\" vAlign=\"Center\"><a id=\"Link\" " + str8 + "><Img ID=\"Img\" " + str12 + " " + str13 + " Border=\"0\" ></a>\r\n") + "</TD></TR><TR Style=\"Display:none\"><TD><a id=TempLink ><Img ID=\"TempImg\" Border=\"0\"></a></TD></TR>\r\n";
                if (str6 == "true")
                {
                    str = ((str + "<TR><TD HEIGHT=\"100%\" Align=\"Center\" vAlign=\"Top\">\r\n") + "<div ID=\"Txt\" style=\"PADDING-LEFT: 5px; Z-INDEX: 1; FILTER: progid:DXImageTransform.Microsoft.Fade(duration=1,overlap=0); POSITION:\">" + str17 + "</div>\r\n") + "</TD></TR>\r\n";
                }
                str = (((str + "</TABLE>\r\n" + "<Script Language=\"VBScript\">\r\n") + "NoScript.Style.Display = \"none\"\r\n" + "CanRunScript.Style.Display = \"\"\r\n") + "Img.Src = FileListArr(0)\r\n" + "Link.Href = LinkArr(0)\r\n") + "SetTimeout \"ChangeImg\", PlayImg_M,\"VBScript\"\r\n" + "</Script>\r\n";
                table.Clear();
                table.Dispose();
                return str;
            }
            return "没有幻灯片";
        }

        public string Analyse_OtherJS()
        {
            return "";
        }

        public string Analyse_PageTitle(int ChID)
        {
            string paramValue = this.GetParamValue("FS:prefix");
            string str3 = "0";
            string str4 = "";
            if (paramValue.IndexOf("$") > -1)
            {
                string[] strArray = paramValue.Split(new char[] { '$' });
                str3 = strArray[0];
                str4 = strArray[1];
            }
            switch (this.TemplateType.ToString())
            {
                case "Index":
                    if (!(str3 == "0"))
                    {
                        return (this.GetSiteName() + str4);
                    }
                    return (str4 + this.GetSiteName());

                case "News":
                    if (!(str3 == "0"))
                    {
                        return (this.GetPageTitle(this.Param_CurrentNewsID, "News", 0) + str4);
                    }
                    return (str4 + this.GetPageTitle(this.Param_CurrentNewsID, "News", 0));

                case "Class":
                    if (!(str3 == "0"))
                    {
                        return (this.GetPageTitle(this.Param_CurrentClassID, "Class", 0) + str4);
                    }
                    return (str4 + this.GetPageTitle(this.Param_CurrentClassID, "Class", 0));

                case "Special":
                    if (!(str3 == "0"))
                    {
                        return (this.GetPageTitle(this.Param_CurrentSpecialID, "Special", 0) + str4);
                    }
                    return (str4 + this.GetPageTitle(this.Param_CurrentSpecialID, "Special", 0));

                case "ChIndex":
                    if (!(str3 == "0"))
                    {
                        return (this.GetPageTitle("0", "ChIndex", ChID) + str4);
                    }
                    return (str4 + this.GetPageTitle("0", "ChIndex", ChID));

                case "ChNews":
                    if (!(str3 == "0"))
                    {
                        return (this.GetPageTitle(this.Param_CurrentCHNewsID.ToString(), "ChNews", ChID) + str4);
                    }
                    return (str4 + this.GetPageTitle(this.Param_CurrentCHNewsID.ToString(), "ChNews", ChID));

                case "ChClass":
                    if (!(str3 == "0"))
                    {
                        return (this.GetPageTitle(this.Param_CurrentCHClassID.ToString(), "ChClass", ChID) + str4);
                    }
                    return (str4 + this.GetPageTitle(this.Param_CurrentCHClassID.ToString(), "ChClass", ChID));

                case "ChSpecial":
                    if (!(str3 == "0"))
                    {
                        return (this.GetPageTitle(this.Param_CurrentCHSpecialID.ToString(), "ChSpecial", ChID) + str4);
                    }
                    return (str4 + this.GetPageTitle(this.Param_CurrentCHSpecialID.ToString(), "ChSpecial", ChID));
            }
            return "";
        }

        public string Analyse_Position(int ChID)
        {
            string classID;
            string str = string.Empty;
            string paramValue = this.GetParamValue("FS:DynChar");
            if (paramValue == null)
            {
                paramValue = " >> ";
            }
            string readType = Public.readparamConfig("ReviewType");
            switch (this.TemplateType.ToString())
            {
                case "Index":
                    return ("<a href=\"" + CommonData.SiteDomain + "/\">首页</a>");

                case "News":
                {
                    classID = null;
                    Foosun.Model.News news = CommonData.getNewsInfoById(this.Param_CurrentNewsID);
                    if (news != null)
                    {
                        classID = news.ClassID;
                        break;
                    }
                    classID = "";
                    break;
                }
                case "Class":
                {
                    PubClassInfo info2 = CommonData.GetClassById(this.Param_CurrentClassID);
                    if ((info2.isDelPoint == 0) && !(readType == "1"))
                    {
                        return info2.NaviPosition;
                    }
                    if (info2.NaviShowtf == 1)
                    {
                        str = "<a href=\"" + CommonData.SiteDomain + "/\">首页</a>" + paramValue + this.GetPositionSTR(paramValue, this.Param_CurrentClassID, 0) + "列表";
                    }
                    return str;
                }
                case "Special":
                    return CommonData.GetSpecial(this.Param_CurrentSpecialID).NaviPosition;

                case "ChIndex":
                {
                    IDataReader reader = CommonData.DalPublish.GetPositionNavi(0, "ChIndex", ChID);
                    if (reader.Read())
                    {
                        if (!(readType == "1"))
                        {
                            string str5 = ("/" + reader["htmldir"].ToString() + "/" + reader["indexFileName"].ToString()).Replace("//", "/").Replace("{@dirHTML}", UIConfig.dirHtml);
                            str = "<a href=\"" + CommonData.SiteDomain + "/\">首页</a>" + paramValue + "<a href=\"" + CommonData.SiteDomain + str5 + "\">" + reader["channelName"].ToString() + "</a>";
                        }
                        else
                        {
                            str = string.Concat(new object[] { "<a href=\"", CommonData.SiteDomain, "/\">首页</a>", paramValue, "<a href=\"", CommonData.SiteDomain, "/default.aspx?ChID=", ChID, "\">", reader["channelName"].ToString(), "</a>" });
                        }
                    }
                    reader.Close();
                    return str;
                }
                case "ChNews":
                    return (this.GetIndexPath(readType, ChID, paramValue) + paramValue + this.GetCHPositionSTR(paramValue, this.Param_CurrentCHNewsID, "ChNews", ChID));

                case "ChClass":
                    return (this.GetIndexPath(readType, ChID, paramValue) + paramValue + this.GetCHPositionSTR(paramValue, this.Param_CurrentCHClassID, "ChClass", ChID) + "列表");

                case "ChSpecial":
                    return (this.GetIndexPath(readType, ChID, paramValue) + paramValue + this.GetCHPositionSTR(paramValue, this.Param_CurrentCHSpecialID, "ChSpecial", ChID));

                default:
                    return str;
            }
            PubClassInfo classById = CommonData.GetClassById(classID);
            if (classById != null)
            {
                if ((classById.isDelPoint != 0) || (readType == "1"))
                {
                    return ("<a href=\"" + CommonData.SiteDomain + "/\">首页</a>" + paramValue + this.GetPositionSTR(paramValue, classID, 0) + "正文");
                }
                return classById.NewsPosition;
            }
            return string.Empty;
        }

        public string Analyse_ReadClass()
        {
            string paramValue = this.GetParamValue("FS:ClassID");
            string classId = "";
            if (paramValue != null)
            {
                classId = paramValue;
            }
            else if (this.Param_CurrentClassID != null)
            {
                classId = this.Param_CurrentClassID;
            }
            string input = string.Empty;
            if (!(classId != ""))
            {
                return input;
            }
            input = this.Mass_Inserted;
            string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (id != string.Empty)
            {
                input = LabelStyle.GetStyleByID(id);
            }
            if (input.Trim() == string.Empty)
            {
                return string.Empty;
            }
            PubClassInfo classById = CommonData.GetClassById(classId);
            if (classById == null)
            {
                return input;
            }
            if (input.IndexOf("{#class_Name}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_Name}", classById.ClassCName);
                }
                else
                {
                    input = input.Replace("{#class_Name}", "");
                }
            }
            if (input.IndexOf("{#class_EName}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_EName}", classById.ClassEName);
                }
                else
                {
                    input = input.Replace("{#class_EName}", "");
                }
            }
            if (input.IndexOf("{#class_ID}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_ID}", classById.ClassID);
                }
                else
                {
                    input = input.Replace("{#class_ID}", "");
                }
            }
            if (input.IndexOf("{#class_Path}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_Path}", this.GetClassURL(classById.Domain, classById.isDelPoint, classById.ClassID, classById.SavePath, classById.SaveClassframe, classById.ClassSaveRule, classById.IsURL, classById.URLaddress, classById.isPage));
                }
                else
                {
                    input = input.Replace("{#class_Path}", "");
                }
            }
            if (input.IndexOf("{#class_Navi}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_Navi}", classById.NaviContent);
                }
                else
                {
                    input = input.Replace("{#class_Navi}", "");
                }
            }
            if (input.IndexOf("{#class_NaviPic}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_NaviPic}", classById.NaviPIC);
                }
                else
                {
                    input = input.Replace("{#class_NaviPic}", "");
                }
            }
            if (input.IndexOf("{#class_Keywords}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_Keywords}", classById.MetaKeywords);
                }
                else
                {
                    input = input.Replace("{#class_Keywords}", "");
                }
            }
            if (input.IndexOf("{#class_Descript}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#class_Descript}", classById.MetaDescript);
                }
                else
                {
                    input = input.Replace("{#class_Descript}", "");
                }
            }
            if (input.IndexOf("{#NaviPosition}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#NaviPosition}", classById.NaviPosition);
                }
                else
                {
                    input = input.Replace("{#NaviPosition}", "");
                }
            }
            if (input.IndexOf("{#NewsPosition}") > -1)
            {
                if (classById != null)
                {
                    input = input.Replace("{#NewsPosition}", classById.NewsPosition);
                }
                else
                {
                    input = input.Replace("{#NewsPosition}", "");
                }
            }
            if (input.IndexOf("{#parentClass_Name}") <= -1)
            {
                return input;
            }
            if (classById != null)
            {
                PubClassInfo info2 = CommonData.GetClassById(classById.ParentID);
                if (info2 != null)
                {
                    input = input.Replace("{#parentClass_Name}", info2.ClassCName);
                }
                else
                {
                    input = input.Replace("{#parentClass_Name}", "");
                }
                return input;
            }
            return input.Replace("{#parentClass_Name}", "");
        }

        public string Analyse_ReadNews(int id, int TitleNumer, int ContentNumber, int NaviNumber, string str_Style, string StyleID, int currentPageNum, int EndPageNum, int NewsTF)
        {
            string str44;
            Foosun.Model.News news = new Foosun.Model.News();
            news = this.getNewsInfo(id, this.Param_CurrentNewsID);
            string str = "";
            if (dimmDir.Trim() != string.Empty)
            {
                str = "/" + dimmDir;
            }
            if (NewsTF == 1)
            {
                str_Style = this.Mass_Inserted;
                string str2 = Regex.Match(str_Style, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
                if (str2 != string.Empty)
                {
                    str_Style = LabelStyle.GetStyleByID(str2);
                }
                if (str_Style.Trim() == string.Empty)
                {
                    return string.Empty;
                }
            }
            if (news == null)
            {
                return "";
            }
            if (TitleNumer <= 0)
            {
                TitleNumer = 15;
            }
            if (ContentNumber <= 0)
            {
                ContentNumber = 15;
            }
            if (NaviNumber <= 0)
            {
                NaviNumber = 15;
            }
            if (!(!string.IsNullOrEmpty(news.ClassID) || string.IsNullOrEmpty(this.Param_CurrentClassID)))
            {
                news.ClassID = this.Param_CurrentClassID;
            }
            PubClassInfo classById = CommonData.GetClassById(news.ClassID);
            if (classById == null)
            {
                classById = new PubClassInfo();
            }
            PubSpecialInfo specialForNewsID = new PubSpecialInfo();
            if (news.NewsID != string.Empty)
            {
                specialForNewsID = CommonData.GetSpecialForNewsID(news.NewsID);
            }
            if (str_Style.IndexOf("{#Title}") > -1)
            {
                string newsTitle = news.NewsTitle;
                string str4 = "";
                if (NewsTF == 0)
                {
                    if ((news.CommLinkTF == 1) && (news.CommTF == 1))
                    {
                        int newsType = news.NewsType;
                        str4 = " <a href=\"" + this.GetNewsURL(news.isDelPoint.ToString(), news.NewsID, news.SavePath, classById.SavePath + "/" + classById.SaveClassframe, news.FileName, news.FileEXName, newsType.ToString(), news.URLaddress) + "#commList\">[评]</a>";
                    }
                    newsTitle = this.GetStyle(Input.GetSubString(newsTitle, TitleNumer), news.TitleColor, news.TitleITF, news.TitleBTF.Value);
                }
                string titlenew = UIConfig.titlenew;
                string str6 = "";
                string str7 = "";
                string[] strArray = titlenew.Split(new char[] { '|' });
                if ((strArray.Length >= 4) && (strArray[0] == "1"))
                {
                    string s = strArray[3];
                    int num = 10;
                    if (!int.TryParse(s, out num))
                    {
                        num = 10;
                    }
                    if (DateTime.Now.Date.Subtract(news.CreatTime).Days < num)
                    {
                        if (strArray[1] == "1")
                        {
                            str7 = "&nbsp;<img border=\"0\" src=\"" + strArray[2] + "\">";
                            str6 = "";
                        }
                        else
                        {
                            str6 = "<span class=\"" + strArray[2] + "\">";
                            str7 = "</span>";
                        }
                    }
                }
                str_Style = str_Style.Replace("{#Title}", str6 + newsTitle + str7 + str4);
            }
            if (str_Style.IndexOf("{#NewsID}") > -1)
            {
                str_Style = str_Style.Replace("{#NewsID}", news.NewsID);
            }
            if (str_Style.IndexOf("{#uTitle}") > -1)
            {
                if (NewsTF == 1)
                {
                    str_Style = str_Style.Replace("{#uTitle}", news.NewsTitle);
                }
                else
                {
                    str_Style = str_Style.Replace("{#uTitle}", this.GetStyle(news.NewsTitle, news.TitleColor, news.TitleITF, news.TitleBTF.Value));
                }
            }
            if (str_Style.IndexOf("{#sTitle}") > -1)
            {
                if (news.sNewsTitle != "")
                {
                    str_Style = str_Style.Replace("{#sTitle}", news.sNewsTitle);
                }
                else
                {
                    str_Style = str_Style.Replace("{#sTitle}", "");
                }
            }
            if (str_Style.IndexOf("{#URL}") > -1)
            {
                string newValue = "";
                if (news.NewsType == 2)
                {
                    newValue = news.URLaddress;
                }
                else if (news.FileEXName != "")
                {
                    newValue = this.GetNewsURL(news.isDelPoint.ToString(), news.NewsID, news.SavePath, classById.SavePath + "/" + classById.SaveClassframe, news.FileName, news.FileEXName, news.NewsType.ToString(), news.URLaddress);
                }
                str_Style = str_Style.Replace("{#URL}", newValue);
            }
            if (str_Style.IndexOf("{#Content}") > -1)
            {
                string content = news.Content;
                string str11 = content;
                if (NewsTF == 0)
                {
                    string str12 = Input.LostHTML(str11);
                    if ((str12.IndexOf("[FS:PAGE") > -1) && (str12.IndexOf("$]") > -1))
                    {
                        str12 = Input.LostPage(str12);
                    }
                    if ((str12.IndexOf("[FS:unLoop") > -1) && (str12.IndexOf("[/FS:unLoop]") > -1))
                    {
                        str12 = Input.LostVoteStr(str12);
                    }
                    content = Input.GetSubString(str12, ContentNumber) + "...";
                    str_Style = str_Style.Replace("{#Content}", content.Replace("[FS:PAGE]", "").Replace("[FS:PAGE", "").Replace("$]", ""));
                }
                else if (NewsTF == 1)
                {
                    string str13 = "";
                    if (news.ContentPicTF != 1)
                    {
                        str11 = content;
                    }
                    else
                    {
                        string contentPicURL = news.ContentPicURL;
                        string[] strArray2 = news.ContentPicSize.Split(new char[] { '|' });
                        string str16 = strArray2[1].ToString();
                        string str17 = strArray2[0].ToString();
                        string dirFile = UIConfig.dirFile;
                        string str19 = Public.readparamConfig("InsertPicPosition");
                        int startIndex = 200;
                        string str20 = "left";
                        if (str19.IndexOf("|") > -1)
                        {
                            str20 = str19.Split(new char[] { '|' })[1];
                            startIndex = Convert.ToInt32(str19.Split(new char[] { '|' })[0]);
                        }
                        int num3 = 0;
                        switch (contentPicURL.Substring(contentPicURL.Length - 4).ToLower())
                        {
                            case ".jpg":
                                num3 = 0;
                                break;

                            case ".gif":
                                num3 = 0;
                                break;

                            case ".jpeg":
                                num3 = 0;
                                break;

                            case ".png":
                                num3 = 0;
                                break;

                            case ".bmp":
                                num3 = 0;
                                break;

                            case ".swf":
                                num3 = 1;
                                break;

                            case ".flv":
                                num3 = 2;
                                break;

                            default:
                                num3 = 3;
                                break;
                        }
                        if ((num3 != 3) && (contentPicURL.IndexOf("http://") == -1))
                        {
                            contentPicURL = CommonData.SiteDomain + contentPicURL;
                        }
                        contentPicURL = contentPicURL.ToLower().Replace("{@dirfile}", dirFile);
                        switch (num3)
                        {
                            case 0:
                                str44 = (str13 + "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" align=\"" + str20 + "\">\r\n") + "<tr>\r\n" + "<td>\r\n";
                                str13 = ((str44 + "<img border=\"0\" src=\"" + contentPicURL + "\" height=\"" + str16 + "\" width=\"" + str17 + "\">\r\n") + "</td>\r\n") + "</tr>\r\n" + "</table>\r\n";
                                break;

                            case 1:
                                str13 = ((((((((((((str13 + "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" align=\"" + str20 + "\">\r\n") + "<tr>\r\n" + "<td>\r\n") + "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=" + "\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" ") + "width=\"" + str17 + "\" ") + "height=\"" + str16 + "\" >\r\n") + "<param name=\"movie\" value=\"" + contentPicURL + "\">\r\n") + "<param name=\"quality\" value=\"high\">\r\n") + "<embed src=\"" + contentPicURL + "\" quality=\"high\" ") + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" ") + "width=\"" + str17 + "\" ") + "height=\"" + str16 + "\" >") + "</embed></object>\r\n" + "</td>\r\n") + "</tr>\r\n" + "</table>\r\n";
                                break;

                            case 2:
                                str44 = (str13 + "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" align=\"" + str20 + "\">\r\n") + "<tr>\r\n" + "<td>\r\n";
                                str13 = ((str44 + "<embed src=\"" + CommonData.SiteDomain + "/FlvPlayer.swf?id=" + contentPicURL + "\" type=\"application/x-shockwave-flash\" wmode=\"transparent\" quality=\"high\" height=\"" + str16 + "\" width=\"" + str17 + "\" autostart=\"true\"></embed>\r\n") + "</td>\r\n") + "</tr>\r\n" + "</table>\r\n";
                                break;

                            default:
                                str44 = str13;
                                str13 = ((((str44 + "<table border=\"0\" cellspacing=\"2\" height=\"" + str16 + "\" width=\"" + str17 + "\" cellpadding=\"2\" align=\"" + str20 + "\">\r\n") + "<tr>\r\n" + "<td>\r\n") + contentPicURL + "\r\n") + "</td>\r\n") + "</tr>\r\n" + "</table>\r\n";
                                break;
                        }
                        if (content.Length < startIndex)
                        {
                            str11 = str11 + str13;
                        }
                        else
                        {
                            str11 = content.Substring(0, startIndex - 1) + str13 + content.Substring(startIndex);
                        }
                    }
                    if (NewsTF == 1)
                    {
                        if ((((str_Style.IndexOf("{#PageTitle_select}") > -1) || (str_Style.IndexOf("{#PageTitle_textdouble}") > -1)) || (str_Style.IndexOf("{#PageTitle_textsinge}") > -1)) || (str_Style.IndexOf("{#PageTitle_textcols}") > -1))
                        {
                            string input = str11;
                            string str23 = string.Empty;
                            string str24 = string.Empty;
                            if ((input.IndexOf("[FS:PAGE=") > -1) && (input.IndexOf("$]") > -1))
                            {
                                string str25 = @"\[FS:PAGE(?<p>[\s\S]*?)\]";
                                Regex regex = new Regex(str25, RegexOptions.Compiled);
                                Match match = regex.Match(input);
                                int num4 = 1;
                                while (match.Success)
                                {
                                    string str26 = match.Groups["p"].Value.Replace("=", "").Replace("$", "");
                                    if (str26 != "")
                                    {
                                        str24 = str24 + str26 + "###";
                                    }
                                    else
                                    {
                                        str24 = str24 + "第" + num4.ToString() + "页###";
                                    }
                                    match = match.NextMatch();
                                    num4++;
                                }
                                if (str24 != "")
                                {
                                    str24 = str24 + "第" + num4.ToString() + "页###";
                                }
                                str11 = regex.Replace(str11, "[FS:PAGE]");
                                if (str_Style.IndexOf("{#PageTitle_select}") > -1)
                                {
                                    str23 = this.GetPageTitleStyle(news.NewsID, news.FileName, news.FileEXName, str24, 0, news.isDelPoint, 0);
                                    str_Style = str_Style.Replace("{#PageTitle_select}", str23);
                                }
                                if (str_Style.IndexOf("{#PageTitle_textdouble}") > -1)
                                {
                                    str23 = this.GetPageTitleStyle(news.NewsID, news.FileName, news.FileEXName, str24, 1, news.isDelPoint, 0);
                                    str_Style = str_Style.Replace("{#PageTitle_textdouble}", str23);
                                }
                                if (str_Style.IndexOf("{#PageTitle_textsinge}") > -1)
                                {
                                    str23 = this.GetPageTitleStyle(news.NewsID, news.FileName, news.FileEXName, str24, 2, news.isDelPoint, 0);
                                    str_Style = str_Style.Replace("{#PageTitle_textsinge}", str23);
                                }
                                if (str_Style.IndexOf("{#PageTitle_textcols}") > -1)
                                {
                                    str23 = this.GetPageTitleStyle(news.NewsID, news.FileName, news.FileEXName, str24, 3, news.isDelPoint, 0);
                                    str_Style = str_Style.Replace("{#PageTitle_textcols}", str23);
                                }
                            }
                            else
                            {
                                str_Style = str_Style.Replace("{#PageTitle_select}", "");
                                str_Style = str_Style.Replace("{#PageTitle_textdouble}", "");
                                str_Style = str_Style.Replace("{#PageTitle_textsinge}", "");
                                str_Style = str_Style.Replace("{#PageTitle_textcols}", "");
                            }
                        }
                        else
                        {
                            str_Style = str_Style.Replace("{#PageTitle_select}", "");
                            str_Style = str_Style.Replace("{#PageTitle_textdouble}", "");
                            str_Style = str_Style.Replace("{#PageTitle_textsinge}", "");
                            str_Style = str_Style.Replace("{#PageTitle_textcols}", "");
                        }
                    }
                    if (Public.readparamConfig("collectTF") == "1")
                    {
                        str11 = str11.Replace("<div", "<!--source from " + Public.readparamConfig("siteDomain") + "--><div");
                    }
                    str_Style = str_Style.Replace("{#Content}", "<!-FS:STAR=" + str11 + "FS:END->");
                }
            }
            if (str_Style.IndexOf("{#Date}") > -1)
            {
                str_Style = str_Style.Replace("{#Date}", news.CreatTime.ToString("yyyy-MM-dd HH:mm:ss") ?? "");
            }
            if (str_Style.IndexOf("{#DateShort}") > -1)
            {
                string str27 = news.CreatTime.Year.ToString();
                string str28 = news.CreatTime.Month.ToString();
                str28 = (str28.Length < 2) ? ("0" + str28) : str28;
                string str29 = news.CreatTime.Day.ToString();
                str29 = (str29.Length < 2) ? ("0" + str29) : str29;
                str_Style = str_Style.Replace("{#DateShort}", str27 + "-" + str28 + "-" + str29);
            }
            if (str_Style.IndexOf("{#Date:Year02}") > -1)
            {
                str_Style = str_Style.Replace("{#Date:Year02}", news.CreatTime.Year.ToString().Remove(0, 2));
            }
            if (str_Style.IndexOf("{#Date:Year04}") > -1)
            {
                str_Style = str_Style.Replace("{#Date:Year04}", news.CreatTime.Year.ToString("D2"));
            }
            if (str_Style.IndexOf("{#Date:Month}") > -1)
            {
                str_Style = str_Style.Replace("{#Date:Month}", news.CreatTime.Month.ToString("D2"));
            }
            if (str_Style.IndexOf("{#Date:Day}") > -1)
            {
                str_Style = str_Style.Replace("{#Date:Day}", news.CreatTime.Day.ToString("D2"));
            }
            if (str_Style.IndexOf("{#Date:Hour}") > -1)
            {
                str_Style = str_Style.Replace("{#Date:Hour}", news.CreatTime.Hour.ToString("D2"));
            }
            if (str_Style.IndexOf("{#Date:Minute}") > -1)
            {
                str_Style = str_Style.Replace("{#Date:Minute}", news.CreatTime.Minute.ToString("D2"));
            }
            if (str_Style.IndexOf("{#Date:Second}") > -1)
            {
                str_Style = str_Style.Replace("{#Date:Second}", news.CreatTime.Second.ToString("D2"));
            }
            if (str_Style.IndexOf("{#Click}") > -1)
            {
                if (NewsTF == 0)
                {
                    str_Style = str_Style.Replace("{#Click}", news.Click.ToString());
                }
                else
                {
                    str44 = "<span id=\"click_" + news.NewsID + "\"></span><script language=\"javascript\" type=\"text/javascript\">";
                    string str30 = (str44 + "pubajax('" + CommonData.SiteDomain + "/click.aspx','id=" + news.NewsID + "','click_" + news.NewsID + "');") + "</script>";
                    str_Style = str_Style.Replace("{#Click}", str30);
                }
            }
            if (str_Style.IndexOf("{#Source}") > -1)
            {
                if (news.Souce != "")
                {
                    str_Style = str_Style.Replace("{#Source}", news.Souce);
                }
                else
                {
                    str_Style = str_Style.Replace("{#Source}", "");
                }
            }
            if (str_Style.IndexOf("{#Editor}") > -1)
            {
                if (news.Editor != "")
                {
                    str_Style = str_Style.Replace("{#Editor}", "<a href=\"" + CommonData.SiteDomain + "/search.html?type=edit&tags=" + Input.URLEncode(news.Editor) + "\" title=\"查看此编辑的所有新闻\" target=\"_blank\">" + news.Editor + "</a>");
                }
                else
                {
                    str_Style = str_Style.Replace("{#Editor}", "");
                }
            }
            if (str_Style.IndexOf("{#Author}") > -1)
            {
                if (news.Author != "")
                {
                    if (news.isConstr == 1)
                    {
                        str_Style = str_Style.Replace("{#Author}", "<a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + news.Author + ".aspx\" title=\"查看他的资料\">" + news.Author + "</a> <a href=\"" + CommonData.SiteDomain + "/search.html?type=author&tags=" + Input.URLEncode(news.Author) + "\" title=\"查看此作者所有的文章\" target=\"_blank\">发表的文章</a>");
                    }
                    else
                    {
                        str_Style = str_Style.Replace("{#Author}", "<a href=\"" + CommonData.SiteDomain + "/search.html?type=author&tags=" + Input.URLEncode(news.Author) + "\" title=\"查看此作者所有的文章\" target=\"_blank\">" + news.Author + "</a>");
                    }
                }
                else
                {
                    str_Style = str_Style.Replace("{#Author}", "");
                }
            }
            if (str_Style.IndexOf("{#MetaKeywords}") > -1)
            {
                if (news.Metakeywords != "")
                {
                    str_Style = str_Style.Replace("{#MetaKeywords}", news.Metakeywords);
                }
                else
                {
                    str_Style = str_Style.Replace("{#MetaKeywords}", "");
                }
            }
            if (str_Style.IndexOf("{#Metadesc}") > -1)
            {
                if (news.Metadesc != "")
                {
                    str_Style = str_Style.Replace("{#Metadesc}", news.Metadesc);
                }
                else
                {
                    str_Style = str_Style.Replace("{#Metadesc}", "");
                }
            }
            if (str_Style.IndexOf("{#Picture}") > -1)
            {
                if (news.PicURL != "")
                {
                    str_Style = str_Style.Replace("{#Picture}", this.RelpacePicPath(news.PicURL));
                }
                else
                {
                    str_Style = str_Style.Replace("{#Picture}", "");
                }
            }
            if (str_Style.IndexOf("{#sPicture}") > -1)
            {
                if (news.SPicURL != "")
                {
                    str_Style = str_Style.Replace("{#sPicture}", this.RelpacePicPath(news.SPicURL));
                }
                else
                {
                    str_Style = str_Style.Replace("{#sPicture}", "");
                }
            }
            if ((str_Style.IndexOf("{$NaviContent[") > -1) && (str_Style.IndexOf("]}") > -1))
            {
                int index = str_Style.IndexOf("{$NaviContent[");
                int length = str_Style.IndexOf("]}") - (index + 14);
                string oldValue = str_Style.Substring(index + 14, length);
                string str32 = string.Empty;
                if (oldValue.IndexOf("{#NaviContent}") > -1)
                {
                    if (NewsTF == 1)
                    {
                        str32 = oldValue.Replace("{#NaviContent}", news.naviContent);
                    }
                    else if (news.naviContent != "")
                    {
                        str32 = oldValue.Replace("{#NaviContent}", Input.GetSubString(news.naviContent, NaviNumber));
                    }
                    else
                    {
                        str32 = oldValue.Replace("{#NaviContent}", "");
                    }
                }
                if (news.naviContent != string.Empty)
                {
                    str_Style = str_Style.Replace(oldValue, str32).Replace("{$NaviContent[", "").Replace("]}", "");
                }
                else
                {
                    str_Style = str_Style.Replace("{#NaviContent}", "").Replace("{$NaviContent[" + str32 + "]}", "");
                }
            }
            if (str_Style.IndexOf("{$#NaviContent}") > -1)
            {
                if (NewsTF == 1)
                {
                    str_Style = str_Style.Replace("{$#NaviContent}", news.naviContent);
                }
                else if (news.naviContent != string.Empty)
                {
                    str_Style = str_Style.Replace("{$#NaviContent}", Input.GetSubString(news.naviContent, NaviNumber));
                }
                else
                {
                    str_Style = str_Style.Replace("{$#NaviContent}", "");
                }
            }
            if (str_Style.IndexOf("{#vote}") > -1)
            {
                if (news.VoteTF == 1)
                {
                    str_Style = str_Style.Replace("{#vote}", this.GetVoteItem(news.NewsID, NewsTF));
                }
                else
                {
                    str_Style = str_Style.Replace("{#vote}", "");
                }
            }
            if (str_Style.IndexOf("{#Tags}") > -1)
            {
                if (news.Tags != "")
                {
                    string tags = news.Tags;
                    string str34 = "";
                    if (tags.IndexOf("|") > -1)
                    {
                        string[] strArray3 = tags.Split(new char[] { '|' });
                        for (int i = 0; i < strArray3.Length; i++)
                        {
                            str44 = str34;
                            str34 = str44 + "<a href=\"" + CommonData.SiteDomain + "/Search.html?type=tag&tags=" + Input.URLEncode(strArray3[i]) + "\">" + strArray3[i] + "</a>&nbsp;&nbsp;";
                        }
                    }
                    else
                    {
                        str34 = "<a href=\"" + CommonData.SiteDomain + "/Search.html?type=tag&tags=" + Input.URLEncode(tags) + "\">" + tags + "</a>";
                    }
                    str_Style = str_Style.Replace("{#Tags}", str34);
                }
                else
                {
                    str_Style = str_Style.Replace("{#Tags}", "");
                }
            }
            if ((str_Style.IndexOf("{#CommForm}") > -1) && (news.CommTF == 1))
            {
                str_Style = str_Style.Replace("{#CommForm}", this.GetCommForm(news.NewsID, NewsTF, 0));
            }
            else
            {
                str_Style = str_Style.Replace("{#CommForm}", "");
            }
            if (str_Style.IndexOf("{#CommCount}") > -1)
            {
                str_Style = str_Style.Replace("{#CommCount}", this.GetCommCount(news.NewsID, NewsTF, 0, 0));
            }
            if (str_Style.IndexOf("{#LastCommCount}") > -1)
            {
                str_Style = str_Style.Replace("{#LastCommCount}", this.GetCommCount(news.NewsID, NewsTF, 1, 0));
            }
            if (str_Style.IndexOf("{#LastComm}") > -1)
            {
                str_Style = str_Style.Replace("{#LastComm}", this.GetLastComm(news.NewsID, NewsTF, 0));
            }
            if (str_Style.IndexOf("{#GroupCount}") > -1)
            {
                str_Style = str_Style.Replace("{#GroupCount}", "");
            }
            if (str_Style.IndexOf("{#SendInfo}") > -1)
            {
                str_Style = str_Style.Replace("{#SendInfo}", this.GetSendInfo(news.NewsID, 0));
            }
            if (str_Style.IndexOf("{#Collection}") > -1)
            {
                str_Style = str_Style.Replace("{#Collection}", this.GetCollection(news.NewsID, 0));
            }
            if (str_Style.IndexOf("{#PrePage}") > -1)
            {
                str_Style = str_Style.Replace("{#PrePage}", this.GetPrePage(news.Id.ToString(), news.DataLib, news.ClassID, 1, 0, 0));
            }
            if (str_Style.IndexOf("{#NextPage}") > -1)
            {
                str_Style = str_Style.Replace("{#NextPage}", this.GetPrePage(news.Id.ToString(), news.DataLib, news.ClassID, 0, 0, 0));
            }
            if (str_Style.IndexOf("{#PrePageTitle}") > -1)
            {
                str_Style = str_Style.Replace("{#PrePageTitle}", this.GetPrePage(news.Id.ToString(), news.DataLib, news.ClassID, 1, 0, 1));
            }
            if (str_Style.IndexOf("{#NextPageTitle}") > -1)
            {
                str_Style = str_Style.Replace("{#NextPageTitle}", this.GetPrePage(news.Id.ToString(), news.DataLib, news.ClassID, 0, 0, 1));
            }
            if (str_Style.IndexOf("{#TopNum}") > -1)
            {
                str_Style = str_Style.Replace("{#TopNum}", this.GetTopNum(news.NewsID, NewsTF, news.TopNum.ToString(), news.FileName + Rand.Number(5)));
            }
            if (str_Style.IndexOf("{#TopURL}") > -1)
            {
                str_Style = str_Style.Replace("{#TopURL}", this.GetTopURL(news.NewsID, NewsTF, news.FileName + Rand.Number(5)));
            }
            if (str_Style.IndexOf("{#undigs}") > -1)
            {
                str_Style = str_Style.Replace("{#undigs}", this.Getundigs(news.NewsID, NewsTF, news.TopNum.ToString(), news.FileName + Rand.Number(5)));
            }
            if (str_Style.IndexOf("{#undigsURL}") > -1)
            {
                str_Style = str_Style.Replace("{#undigsURL}", this.Getundigurl(news.NewsID, NewsTF, news.FileName + Rand.Number(5)));
            }
            if (str_Style.IndexOf("{#NewsFiles}") > -1)
            {
                str_Style = str_Style.Replace("{#NewsFiles}", this.GetNewsFiles(news.NewsID, NewsTF));
            }
            if (str_Style.IndexOf("{#NewsvURL") > -1)
            {
                Match match2 = new Regex(@"\{\#NewsvURL,(?<x>[^,]+),(?<y>[^\}]+)\}", RegexOptions.Compiled).Match(str_Style);
                string heightstr = "400";
                string widthstr = "400";
                string str37 = "";
                if (match2.Success)
                {
                    str37 = match2.Value;
                    heightstr = match2.Groups["x"].Value;
                    widthstr = match2.Groups["y"].Value;
                    if (news.vURL.Length > 5)
                    {
                        str_Style = str_Style.Replace(str37, this.GetNewsvURL(news.NewsID, NewsTF, news.vURL, heightstr, widthstr));
                    }
                    else
                    {
                        str_Style = str_Style.Replace(str37, "");
                    }
                }
            }
            if (str_Style.IndexOf("{#class_Name}") > -1)
            {
                if (classById != null)
                {
                    str_Style = str_Style.Replace("{#class_Name}", classById.ClassCName);
                }
                else
                {
                    str_Style = str_Style.Replace("{#class_Name}", "");
                }
            }
            if (str_Style.IndexOf("{#class_EName}") > -1)
            {
                if (classById != null)
                {
                    str_Style = str_Style.Replace("{#class_EName}", classById.ClassEName);
                }
                else
                {
                    str_Style = str_Style.Replace("{#class_EName}", "");
                }
            }
            if (str_Style.IndexOf("{#class_Path}") > -1)
            {
                if (classById != null)
                {
                    str_Style = str_Style.Replace("{#class_Path}", this.GetClassURL(classById.Domain, classById.isDelPoint, classById.ClassID, classById.SavePath, classById.SaveClassframe, classById.ClassSaveRule, classById.IsURL, classById.URLaddress, classById.isPage));
                }
                else
                {
                    str_Style = str_Style.Replace("{#class_Path}", "");
                }
            }
            if (str_Style.IndexOf("{#class_Navi}") > -1)
            {
                if (classById != null)
                {
                    str_Style = str_Style.Replace("{#class_Navi}", classById.NaviContent);
                }
                else
                {
                    str_Style = str_Style.Replace("{#class_Navi}", "");
                }
            }
            if (str_Style.IndexOf("{#class_NaviPic}") > -1)
            {
                if (classById != null)
                {
                    str_Style = str_Style.Replace("{#class_NaviPic}", classById.NaviPIC);
                }
                else
                {
                    str_Style = str_Style.Replace("{#class_NaviPic}", "");
                }
            }
            if (str_Style.IndexOf("{#class_Keywords}") > -1)
            {
                if (classById != null)
                {
                    str_Style = str_Style.Replace("{#class_Keywords}", classById.MetaKeywords);
                }
                else
                {
                    str_Style = str_Style.Replace("{#class_Keywords}", "");
                }
            }
            if (str_Style.IndexOf("{#class_Descript}") > -1)
            {
                if (classById != null)
                {
                    str_Style = str_Style.Replace("{#class_Descript}", classById.MetaDescript);
                }
                else
                {
                    str_Style = str_Style.Replace("{#class_Descript}", "");
                }
            }
            if (str_Style.IndexOf("{#special_Name}") > -1)
            {
                if (specialForNewsID != null)
                {
                    str_Style = str_Style.Replace("{#special_Name}", specialForNewsID.SpecialCName);
                }
                else
                {
                    str_Style = str_Style.Replace("{#special_Name}", "");
                }
            }
            if (str_Style.IndexOf("{#special_Ename}") > -1)
            {
                if (specialForNewsID != null)
                {
                    str_Style = str_Style.Replace("{#special_Ename}", specialForNewsID.specialEName);
                }
                else
                {
                    str_Style = str_Style.Replace("{#special_Ename}", "");
                }
            }
            if (str_Style.IndexOf("{#special_Path}") > -1)
            {
                if (specialForNewsID != null)
                {
                    str_Style = str_Style.Replace("{#special_Path}", this.GetSpeacilURL(specialForNewsID.isDelPoint.ToString(), specialForNewsID.SpecialID, specialForNewsID.SavePath, specialForNewsID.saveDirPath, specialForNewsID.FileName, specialForNewsID.FileEXName));
                }
                else
                {
                    str_Style = str_Style.Replace("{#special_Path}", "");
                }
            }
            if (str_Style.IndexOf("{#special_NaviWords}") > -1)
            {
                if (specialForNewsID != null)
                {
                    str_Style = str_Style.Replace("{#special_NaviWords}", specialForNewsID.NaviContent);
                }
                else
                {
                    str_Style = str_Style.Replace("{#special_NaviWords}", "");
                }
            }
            if (str_Style.IndexOf("{#special_NaviPic}") > -1)
            {
                if (specialForNewsID != null)
                {
                    str_Style = str_Style.Replace("{#special_NaviPic}", specialForNewsID.NaviPicURL);
                }
                else
                {
                    str_Style = str_Style.Replace("{#special_NaviPic}", "");
                }
            }
            string pattern = @"\{\#FS:define=(?<dname>[^\}]+)}";
            int result = 0;
            string str39 = "";
            Regex regex3 = new Regex(pattern, RegexOptions.Compiled);
            for (Match match3 = regex3.Match(str_Style); match3.Success; match3 = match3.NextMatch())
            {
                string dfcolumn = match3.Groups["dname"].Value;
                str39 = dfcolumn;
                if (dfcolumn.IndexOf(",") >= 0)
                {
                    string[] strArray4 = dfcolumn.Split(new char[] { ',' });
                    dfcolumn = strArray4[0];
                    if (!int.TryParse(strArray4[1], out result))
                    {
                        result = 0;
                    }
                }
                string definedValue = CommonData.DalPublish.GetDefinedValue(news.NewsID, dfcolumn);
                if (result > 0)
                {
                    definedValue = Input.GetSubString(definedValue, result);
                }
                str_Style = str_Style.Replace("{#FS:define=" + str39 + "}", definedValue);
            }
            if (StyleID.Equals(string.Empty))
            {
                return str_Style;
            }
            return this.Mass_Inserted.Replace("[#FS:StyleID=" + StyleID + "]", str_Style);
        }

        public string Analyse_ReadSpecial()
        {
            string paramValue = this.GetParamValue("FS:SpecialID");
            string specialid = "";
            if (paramValue != null)
            {
                specialid = paramValue;
            }
            else if (this.Param_CurrentSpecialID != null)
            {
                specialid = this.Param_CurrentSpecialID;
            }
            string input = string.Empty;
            if (specialid != "")
            {
                input = this.Mass_Inserted;
                string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
                if (id != string.Empty)
                {
                    input = LabelStyle.GetStyleByID(id);
                }
                if (input.Trim() == string.Empty)
                {
                    return string.Empty;
                }
                PubSpecialInfo special = CommonData.GetSpecial(specialid);
                if (special == null)
                {
                    return input;
                }
                if (input.IndexOf("{#special_Name}") > -1)
                {
                    if (special != null)
                    {
                        input = input.Replace("{#special_Name}", special.SpecialCName);
                    }
                    else
                    {
                        input = input.Replace("{#special_Name}", "");
                    }
                }
                if (input.IndexOf("{#special_Ename}") > -1)
                {
                    if (special != null)
                    {
                        input = input.Replace("{#special_Ename}", special.specialEName);
                    }
                    else
                    {
                        input = input.Replace("{#special_Ename}", "");
                    }
                }
                if (input.IndexOf("{#special_Path}") > -1)
                {
                    if (special != null)
                    {
                        input = input.Replace("{#special_Path}", this.GetSpeacilURL(special.isDelPoint.ToString(), special.SpecialID, special.SavePath, special.saveDirPath, special.FileName, special.FileEXName));
                    }
                    else
                    {
                        input = input.Replace("{#special_Path}", "");
                    }
                }
                if (input.IndexOf("{#special_NaviWords}") > -1)
                {
                    if (special != null)
                    {
                        input = input.Replace("{#special_NaviWords}", special.NaviContent);
                    }
                    else
                    {
                        input = input.Replace("{#special_NaviWords}", "");
                    }
                }
                if (input.IndexOf("{#special_NaviPic}") > -1)
                {
                    if (special != null)
                    {
                        input = input.Replace("{#special_NaviPic}", special.NaviPicURL);
                    }
                    else
                    {
                        input = input.Replace("{#special_NaviPic}", "");
                    }
                }
            }
            return input;
        }

        public string Analyse_RSS()
        {
            string str5;
            string str = "";
            string paramValue = this.GetParamValue("FS:ClassID");
            string classId = "";
            bool flag = false;
            if (paramValue == null)
            {
                if (this.Param_CurrentClassID == null)
                {
                    flag = true;
                }
                else
                {
                    classId = this.Param_CurrentClassID;
                }
            }
            else if (paramValue == "0")
            {
                classId = this.Param_CurrentClassID;
            }
            else if (paramValue == "-1")
            {
                flag = true;
            }
            else
            {
                classId = paramValue;
            }
            if (flag)
            {
                str5 = str;
                return (str5 + "<a title=\"订阅本站所有信息\" href=\"" + CommonData.SiteDomain + "/xml/content/all/news.xml\" target=\"blank\"><img src=\"" + CommonData.SiteDomain + "/sysImages/Label/preview/RSS.gif\" border=\"0\" alt=\"RSS图片\"></a>");
            }
            PubClassInfo classById = CommonData.GetClassById(classId);
            if (((classById != null) && (classById.IsURL == 0)) && (classById.SiteID == this.Param_SiteID))
            {
                str5 = str;
                str = str5 + "<a title=\"订阅" + classById.ClassEName + "信息\" href=\"" + CommonData.SiteDomain + "/xml/content/" + classById.ClassEName + ".xml\" target=\"blank\"><img src=\"" + CommonData.SiteDomain + "/sysImages/Label/preview/RSS.gif\" border=\"0\" alt=\"RSS图片\"></a>";
            }
            return str;
        }

        public string Analyse_SClassNavi()
        {
            PubClassInfo classByParentId;
            string parentID;
            string paramValue = this.GetParamValue("FS:ClassID");
            string str2 = this.GetParamValue("FS:NaviCSS");
            string str3 = this.GetParamValue("FS:NaviChar");
            string str4 = this.GetParamValue("FS:Mapp");
            if (str2 != null)
            {
                str2 = "class=\"" + str2 + "\"";
            }
            string classID = "";
            string str6 = "0";
            string str7 = "0";
            if (paramValue == "0")
            {
                if (!string.IsNullOrEmpty(this.Param_CurrentClassID))
                {
                    str6 = this.Param_CurrentClassID;
                }
                else
                {
                    str6 = "0";
                }
                classByParentId = CommonData.GetClassByParentId(this.Param_CurrentClassID);
                if (classByParentId == null)
                {
                    classByParentId = CommonData.GetClassById(this.Param_CurrentClassID);
                    parentID = classByParentId.ParentID;
                    if (string.IsNullOrEmpty(parentID))
                    {
                        str6 = this.Param_CurrentClassID;
                    }
                    else
                    {
                        str6 = parentID;
                    }
                }
                else
                {
                    str7 = "1";
                }
                classID = classByParentId.ClassID;
            }
            else if (paramValue == "1")
            {
                if (!string.IsNullOrEmpty(this.Param_CurrentClassID))
                {
                    classByParentId = CommonData.GetClassById(this.Param_CurrentClassID);
                    classID = classByParentId.ClassID;
                    parentID = classByParentId.ParentID;
                    if (string.IsNullOrEmpty(parentID))
                    {
                        str6 = this.Param_CurrentClassID;
                    }
                    else
                    {
                        str6 = parentID;
                    }
                }
            }
            else if (paramValue == "-1")
            {
                str6 = "-1";
            }
            else if (!string.IsNullOrEmpty(paramValue))
            {
                str6 = paramValue;
            }
            else
            {
                str6 = "0";
            }
            string str9 = "";
            string str10 = "";
            IList<PubClassInfo> newsClass = CommonData.NewsClass;
            if (newsClass != null)
            {
                foreach (PubClassInfo info2 in newsClass)
                {
                    if (info2.NaviShowtf == 1)
                    {
                        string uRLaddress;
                        string str13;
                        if (info2.IsURL == 1)
                        {
                            if ((str6 == "-1") && (info2.SiteID == this.Param_SiteID))
                            {
                                uRLaddress = info2.URLaddress;
                                if (classID == info2.ClassID)
                                {
                                    str13 = str9;
                                    str9 = str13 + "<li " + str2 + ">" + str3;
                                    str9 = str9 + info2.ClassCName;
                                    str9 = str9 + "</li>\r\n";
                                }
                                else
                                {
                                    str13 = str9;
                                    str9 = str13 + "<li>" + str3 + "<a href=\"" + uRLaddress + "\">";
                                    str9 = str9 + info2.ClassCName + "</a>";
                                    str9 = str9 + "</li>\r\n";
                                }
                            }
                            else if ((info2.ParentID == str6) && (info2.SiteID == this.Param_SiteID))
                            {
                                uRLaddress = info2.URLaddress;
                                if (classID == info2.ClassID)
                                {
                                    str13 = str9;
                                    str9 = str13 + "<li " + str2 + ">" + str3;
                                    str9 = str9 + info2.ClassCName;
                                    str9 = str9 + "</li>\r\n";
                                }
                                else
                                {
                                    str13 = str9;
                                    str9 = str13 + "<li>" + str3 + "<a href=\"" + uRLaddress + "\">";
                                    str9 = str9 + info2.ClassCName + "</a>";
                                    str9 = str9 + "</li>\r\n";
                                }
                            }
                        }
                        else if ((str6 == "-1") && (info2.SiteID == this.Param_SiteID))
                        {
                            uRLaddress = this.GetClassURL(info2.Domain, info2.isDelPoint, info2.ClassID, info2.SavePath, info2.SaveClassframe, info2.ClassSaveRule, info2.IsURL, info2.URLaddress, info2.isPage);
                            if (classID == info2.ClassID)
                            {
                                str13 = str9;
                                str9 = str13 + "<li " + str2 + ">" + str3;
                                str9 = str9 + info2.ClassCName;
                                str9 = str9 + "</li>\r\n";
                            }
                            else
                            {
                                str13 = str9;
                                str9 = str13 + "<li>" + str3 + "<a href=\"" + uRLaddress + "\">";
                                str9 = str9 + info2.ClassCName + "</a>";
                                str9 = str9 + "</li>\r\n";
                            }
                        }
                        else if ((paramValue != "1") && (info2.ClassID == str6))
                        {
                            if (str9.IndexOf(str2) > -1)
                            {
                                uRLaddress = this.GetClassURL(info2.Domain, info2.isDelPoint, info2.ClassID, info2.SavePath, info2.SaveClassframe, info2.ClassSaveRule, info2.IsURL, info2.URLaddress, info2.isPage);
                                str13 = str10;
                                str10 = str13 + "<li>" + str3 + "<a href=\"" + uRLaddress + "\">";
                                str10 = str10 + info2.ClassCName + "</a>";
                                str10 = str10 + "</li>\r\n";
                            }
                            else
                            {
                                str13 = str10;
                                str10 = str13 + "<li " + str2 + ">" + str3;
                                str10 = str10 + info2.ClassCName;
                                str10 = str10 + "</li>\r\n";
                            }
                        }
                        else if ((info2.ParentID == str6) && (info2.SiteID == this.Param_SiteID))
                        {
                            if ((classID == info2.ClassID) && (str7 == "0"))
                            {
                                str13 = str9;
                                str9 = str13 + "<li " + str2 + ">" + str3;
                                str9 = str9 + info2.ClassCName;
                                str9 = str9 + "</li>\r\n";
                            }
                            else
                            {
                                uRLaddress = this.GetClassURL(info2.Domain, info2.isDelPoint, info2.ClassID, info2.SavePath, info2.SaveClassframe, info2.ClassSaveRule, info2.IsURL, info2.URLaddress, info2.isPage);
                                str13 = str9;
                                str9 = str13 + "<li>" + str3 + "<a href=\"" + uRLaddress + "\">";
                                str9 = str9 + info2.ClassCName + "</a>";
                                str9 = str9 + "</li>\r\n";
                            }
                        }
                    }
                }
            }
            return (str10 + str9);
        }

        public string Analyse_Search()
        {
            string str = "";
            string str2 = Rand.Number(5);
            string paramValue = this.GetParamValue("FS:SearchType");
            string str4 = this.GetParamValue("FS:ShowDate");
            string str5 = this.GetParamValue("FS:ShowClass");
            str = (str + "<form id=\"Search_Form\" name=\"Search_Form\" method=\"get\" action=\"search.html\">\r\n") + "<input name=\"tags\" id=\"tags\" type=\"text\" maxlength=\"20\" onkeydown=\"javascript:if(event.keyCode==13){SearchGo" + str2 + "(this.form);}\" />";
            if (paramValue == "true")
            {
                if (str4 == "true")
                {
                    str4 = " <select name=\"Date\" id=\"Date\">\r\n";
                    str4 = (((str4 + "<option value=\"0\">不限制</otpion>\r\n") + "<option value=\"1\">最近一天</otpion>\r\n" + "<option value=\"3\">最近三天</otpion>\r\n") + "<option value=\"7\">最近一周</otpion>\r\n" + "<option value=\"30\">最近一月</otpion>\r\n") + "<option value=\"180\">最近半年</otpion>\r\n" + "</select>\r\n";
                }
                else
                {
                    str4 = "";
                }
                if (str5 == "true")
                {
                    IList<PubClassInfo> newsClass = CommonData.NewsClass;
                    if (newsClass != null)
                    {
                        str5 = " <select name=\"ClassID\"><option vlaue=\"\">所有栏目</option>\r\n" + this.ChildList(newsClass, "0", "├") + "</select>";
                    }
                    else
                    {
                        str5 = " <select name=\"ClassID\"><option vlaue=\"\">所有栏目</option></select>";
                    }
                }
                else
                {
                    str5 = "";
                }
                str = str + str4 + str5;
            }
            str = (((str + " <input name=\"buttongo\" id=\"buttongo\" type=\"button\" value=\"搜索\" onclick=\"javascript:SearchGo" + str2 + "(this.form);\" />") + "</form>\r\n" + "<script type=\"text/javascript\">\r\n") + "function SearchGo" + str2 + "(obj)\r\n") + "{\r\n";
            int num = 0;
            int num2 = 20;
            string str6 = Public.readparamConfig("LenSearch");
            num = int.Parse(str6.Split(new char[] { '|' })[0]);
            num2 = int.Parse(str6.Split(new char[] { '|' })[1]);
            object obj2 = str;
            obj2 = string.Concat(new object[] { obj2, "if(obj.tags.value.length<", num, "||obj.tags.value.length>", num2, ")\r\n" }) + "{\r\n";
            str = ((string.Concat(new object[] { obj2, " alert('搜索最小长度", num, "字符，最大长度", num2, "字符。');return false;\r\n" }) + "}\r\n") + "if(obj.tags.value=='')\r\n" + "{\r\n") + " alert('请填写关键字');return false;\r\n" + "}\r\n";
            if (paramValue == "true")
            {
                str = str + "window.location.href='" + CommonData.SiteDomain + "/Search.html?type=news";
                if (str4 == "true")
                {
                    str = str + "&Date='+obj.Date.value+'";
                }
                if (str5 == "true")
                {
                    str = str + "&ClassID='+obj.ClassID.value+'";
                }
                str = str + "&tags='+encodeURIComponent(obj.tags.value)+'';\r\n";
            }
            else
            {
                str = str + "window.location.href='" + CommonData.SiteDomain + "/Search.html?type=news&tags='+encodeURIComponent(obj.tags.value)+'';\r\n";
            }
            return (str + "}\r\n" + "</script>\r\n");
        }

        public string Analyse_Sitemap()
        {
            string dirFile = UIConfig.dirFile;
            string dirDumm = UIConfig.dirDumm;
            if (dirDumm.Trim() != string.Empty)
            {
                dirDumm = "/" + dirDumm;
            }
            if (Convert.ToInt32(this.GetParamValue("FS:isSubCols")) < 1)
            {
            }
            string paramValue = this.GetParamValue("FS:MapTitleCSS");
            if (paramValue != null)
            {
                paramValue = " class=\"" + paramValue + "\"";
            }
            string str4 = this.GetParamValue("FS:SubCSS");
            if (str4 != null)
            {
                str4 = " class=\"" + str4 + "\"";
            }
            string str5 = this.GetParamValue("FS:Mapp");
            if (str5 == null)
            {
                str5 = "true";
            }
            string brStr = "";
            if (str5 == "true")
            {
                brStr = "&nbsp;&nbsp;";
            }
            else
            {
                brStr = "<br />";
            }
            string str7 = this.GetParamValue("FS:MapNavi");
            string str8 = this.GetParamValue("FS:MapNaviPic");
            string str9 = this.GetParamValue("FS:MapsubNavi");
            string str10 = this.GetParamValue("FS:MapsubNaviText");
            string str11 = this.GetParamValue("FS:MapsubNaviPic");
            if ((str8 == "true") && (str8 != null))
            {
                str8 = "<img src=\"" + str8 + "\" border=\"0\" />".Replace("{@dirfile}", dirDumm + dirFile);
            }
            string str12 = this.GetParamValue("FS:MapNaviText");
            if ((str9 == "true") && (str11 != null))
            {
                str11 = "<img src=\"" + str11 + "\" border=\"0\" />".Replace("{@dirfile}", dirDumm + dirFile);
            }
            string str13 = "";
            PubClassInfo info = null;
            foreach (PubClassInfo info2 in CommonData.NewsClass)
            {
                if (info2.ParentID.Equals("0"))
                {
                    info = info2;
                    string str15 = str13;
                    str13 = str15 + str8 + str12 + "<a " + paramValue + " href=\"" + this.GetClassURL(info.Domain, info.isDelPoint, info.ClassID, info.SavePath, info.SaveClassframe, info.ClassSaveRule, info.IsURL, info.URLaddress, info.isPage) + "\">" + info.ClassCName + "</a>" + brStr;
                    this.Analyse_SitemapString = string.Empty;
                    this.Recursion_Sitemap(info.ClassID, brStr, str4, str10, str11);
                    str13 = str13 + this.Analyse_SitemapString;
                }
            }
            return str13;
        }

        public string Analyse_SiteNavi()
        {
            string str = "";
            string paramValue = this.GetParamValue("FS:NaviCSS");
            string str3 = this.GetParamValue("FS:NaviChar");
            string str4 = this.GetParamValue("FS:isDiv");
            string str5 = str3;
            int num = 0;
            if (str4 == null)
            {
                str4 = "true";
            }
            if ((paramValue != null) && (paramValue != string.Empty))
            {
                paramValue = " class=\"" + paramValue + "\"";
            }
            IList<PubClassInfo> newsClass = CommonData.NewsClass;
            foreach (PubClassInfo info in newsClass)
            {
                if ((info.ParentID == "0") && (info.NaviShowtf == 1))
                {
                    string str8;
                    string str6 = "";
                    if ((info.ClassCName != string.Empty) && (info.SavePath != string.Empty))
                    {
                        str6 = this.GetClassURL(info.Domain, info.isDelPoint, info.ClassID, info.SavePath, info.SaveClassframe, info.ClassSaveRule, info.IsURL, info.URLaddress, info.isPage);
                    }
                    else if ((info.ClassSaveRule != string.Empty) && (info.isPage == 1))
                    {
                        str6 = CommonData.SiteDomain + "/" + info.SavePath;
                    }
                    if (num == 0)
                    {
                        str5 = "";
                    }
                    else
                    {
                        str5 = str3;
                    }
                    if (str4 == "true")
                    {
                        str8 = str;
                        str = str8 + "<li " + paramValue + ">" + str5 + " <a href=\"" + str6 + "\">" + info.ClassCName + "</a></li>";
                    }
                    else
                    {
                        str8 = str;
                        str = str8 + str5 + " <a href=\"" + str6 + "\" " + paramValue + ">" + info.ClassCName + "</a> ";
                    }
                }
                num++;
            }
            return str;
        }

        public string Analyse_SpecialNavi()
        {
            string paramValue = this.GetParamValue("FS:SpecialID");
            string str2 = this.GetParamValue("FS:NaviCSS");
            string str3 = this.GetParamValue("FS:NaviChar");
            if (str2 != null)
            {
                str2 = "class=\"" + str2 + "\"";
            }
            string str4 = "0";
            if (paramValue == "0")
            {
                if (!string.IsNullOrEmpty(this.Param_CurrentSpecialID))
                {
                    str4 = this.Param_CurrentSpecialID;
                }
                else
                {
                    str4 = "0";
                }
                if (CommonData.GetSpecialByParentId(this.Param_CurrentSpecialID) == null)
                {
                    string parentID = CommonData.GetSpecial(this.Param_CurrentSpecialID).ParentID;
                    if (string.IsNullOrEmpty(parentID))
                    {
                        str4 = this.Param_CurrentSpecialID;
                    }
                    else
                    {
                        str4 = parentID;
                    }
                }
            }
            else if (paramValue == "-1")
            {
                str4 = "-1";
            }
            else if (!string.IsNullOrEmpty(paramValue))
            {
                str4 = paramValue;
            }
            else
            {
                str4 = "0";
            }
            string str6 = "";
            IList<PubSpecialInfo> newsSpecial = CommonData.NewsSpecial;
            if (newsSpecial != null)
            {
                foreach (PubSpecialInfo info2 in newsSpecial)
                {
                    string str7;
                    string str9;
                    if ((str4 == "-1") && (info2.SiteID == this.Param_SiteID))
                    {
                        str7 = this.GetSpeacilURL(info2.isDelPoint.ToString(), info2.SpecialID, info2.SavePath, info2.saveDirPath, info2.FileName, info2.FileEXName);
                        str9 = str6;
                        str6 = str9 + "   <li>" + str3 + " <a href=\"" + str7 + "\" " + str2 + ">\r\n";
                        str6 = str6 + "   " + info2.SpecialCName + "</a>";
                        str6 = str6 + "   </li>\r\n";
                    }
                    else if ((info2.ParentID == str4) && (info2.SiteID == this.Param_SiteID))
                    {
                        str7 = this.GetSpeacilURL(info2.isDelPoint.ToString(), info2.SpecialID, info2.SavePath, info2.saveDirPath, info2.FileName, info2.FileEXName);
                        str9 = str6;
                        str6 = str9 + "   <li>" + str3 + " <a href=\"" + str7 + "\" " + str2 + ">\r\n";
                        str6 = str6 + "   " + info2.SpecialCName + "</a>";
                        str6 = str6 + "   </li>\r\n";
                    }
                }
            }
            return str6;
        }

        public string Analyse_SpeicalNaviRead()
        {
            string str = "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            string paramValue = this.GetParamValue("FS:SpecialID");
            string s = this.GetParamValue("FS:SpecialTitleNumber");
            string str4 = this.GetParamValue("FS:SpecialNaviTitleNumber");
            string specialid = "";
            if (paramValue != null)
            {
                specialid = paramValue;
            }
            else if (this.Param_CurrentSpecialID != null)
            {
                specialid = this.Param_CurrentSpecialID;
            }
            if (specialid != "")
            {
                PubSpecialInfo special = CommonData.GetSpecial(specialid);
                if (special != null)
                {
                    string str8;
                    string str6 = this.GetSpeacilURL(special.isDelPoint.ToString(), special.SpecialID, special.SavePath, special.saveDirPath, special.FileName, special.FileEXName);
                    str = str + "<div>\r\n";
                    if (s != null)
                    {
                        str8 = str;
                        str = str8 + "   <a href=\"" + str6 + "\" style=\"font-weight:bold;\">" + Input.GetSubString(special.SpecialCName, int.Parse(s));
                    }
                    else
                    {
                        str8 = str;
                        str = str8 + "   <a href=\"" + str6 + "\" style=\"font-weight:bold;\">" + special.SpecialCName;
                    }
                    str = str + "</div>\r\n" + "<div>\r\n";
                    if (str4 != null)
                    {
                        str8 = str;
                        str = str8 + "   " + Input.GetSubString(special.NaviContent, int.Parse(str4)) + "...<a href=\"" + str6 + "\">[详情]</a>";
                    }
                    else
                    {
                        str8 = str;
                        str = str8 + "   " + special.NaviContent + "...<a href=\"" + str6 + "\">[详情]</a>";
                    }
                    str = str + "</div>\r\n";
                }
                else
                {
                    str = str + "<tr><td><!--未找到此专题--></td></tr>\r\n";
                }
            }
            else
            {
                str = str + "<tr><td><!--未找到此专题--></td></tr>\r\n";
            }
            return (str + "</table>");
        }

        public string Analyse_Stat()
        {
            return "";
        }

        public string Analyse_statJS()
        {
            string paramValue = this.GetParamValue("FS:JSID");
            string str2 = this.GetParamValue("FS:statShowType");
            string str3 = "";
            if (paramValue != null)
            {
                str3 = "<script language=\"javascript\" src=\"" + CommonData.SiteDomain + "/stat/mystat.aspx?code=" + str2 + "&id=" + paramValue + "\"></script>";
            }
            return str3;
        }

        public string Analyse_SubForm()
        {
            string input = this.Mass_Inserted;
            string paramValue = this.GetParamValue("FS:FormID");
            string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (!id.Equals(string.Empty))
            {
                input = LabelStyle.GetStyleByID(id);
                return this.parse(input, paramValue);
            }
            return "";
        }

        public string Analyse_surveyJS()
        {
            string paramValue = this.GetParamValue("FS:JSID");
            string str2 = paramValue + "_" + Rand.Number(5);
            string str3 = "";
            if (paramValue != null)
            {
                str3 = "<script src=\"" + CommonData.SiteDomain + "/survey/VoteJs.aspx?TID=" + paramValue + "&PicW=60&ajaxid=Vote_HTML_ID_" + str2 + "\" language=\"JavaScript\"></script><span id=\"Vote_HTML_ID_" + str2 + "\">正在加载...</span>";
            }
            return str3;
        }

        public string Analyse_sysJS()
        {
            string paramValue = this.GetParamValue("FS:JSID");
            string str2 = "";
            if (paramValue != null)
            {
                str2 = this.validateCatch(paramValue);
            }
            return str2;
        }

        public string Analyse_TodayPic()
        {
            string str = string.Empty;
            string paramValue = this.GetParamValue("FS:TodayPicID");
            string str3 = this.GetParamValue("FS:TCHECK");
            string s = this.GetParamValue("FS:TNUM");
            int topNum = 3;
            if (s != null)
            {
                topNum = int.Parse(s);
            }
            string str5 = this.GetParamValue("FS:TSCHAR");
            string str6 = this.GetParamValue("FS:TECHAR");
            DataTable topLine = CommonData.DalPublish.GetTopLine(paramValue);
            if ((topLine != null) && (topLine.Rows.Count > 0))
            {
                IDataReader newsSavePath = CommonData.DalPublish.GetNewsSavePath(topLine.Rows[0]["NewsID"].ToString());
                if (newsSavePath.Read())
                {
                    string str7 = this.GetNewsURL1(newsSavePath["ClassID"].ToString(), newsSavePath["isDelPoint"].ToString(), newsSavePath["NewsID"].ToString(), newsSavePath["SavePath"].ToString(), newsSavePath["FileName"].ToString(), newsSavePath["FileEXName"].ToString());
                    string str12 = str;
                    str = str12 + "<div style=\"text-align:center;width:100%\"><a href=\"" + str7 + "\"><img src=\"" + CommonData.SiteDomain + this.RelpacePicPath(topLine.Rows[0]["tl_SavePath"].ToString()) + "\" style=\"border:0px;\" /></a></div>\r\n";
                }
                newsSavePath.Close();
                topLine.Clear();
                topLine.Dispose();
            }
            if (str3 == "true")
            {
                DataTable textSubNews = CommonData.DalPublish.GetTextSubNews(topNum, paramValue);
                if (textSubNews == null)
                {
                    return str;
                }
                string str8 = "1";
                for (int i = 0; i < textSubNews.Rows.Count; i++)
                {
                    DataRow row = textSubNews.Rows[i];
                    Foosun.Model.News news = CommonData.getNewsInfoById(row["getNewsID"].ToString());
                    PubClassInfo classById = CommonData.GetClassById(news.ClassID);
                    string str9 = this.GetNewsURL(news.isDelPoint.ToString(), news.NewsID, news.SavePath, classById.SavePath + "/" + classById.SaveClassframe, news.FileName, news.FileEXName, news.NewsType.ToString(), news.URLaddress);
                    string str10 = "";
                    if (!string.IsNullOrEmpty(row["TitleCss"].ToString()))
                    {
                        str10 = " class=\"" + row["TitleCss"].ToString() + "\"";
                    }
                    if (row["colsNum"].ToString() != str8)
                    {
                        str = str + "<br/>";
                    }
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, str5, "<a href=\"", str9, "\"", str10, ">", row["NewsTitle"], "</a>", str6, "&nbsp;" });
                    str8 = row["colsNum"].ToString();
                }
                textSubNews.Clear();
                textSubNews.Dispose();
            }
            return str;
        }

        public string Analyse_TodayWord()
        {
            string str = "";
            string paramValue = this.GetParamValue("FS:ClassID");
            string str3 = this.GetParamValue("FS:isBIGT");
            string str4 = this.GetParamValue("FS:BigCSS");
            string str5 = this.GetParamValue("FS:TSCHAR");
            string str6 = this.GetParamValue("FS:TECHAR");
            string input = this.GetParamValue("FS:bigTitleNumber");
            if (str5 != null)
            {
                str5 = str5.Replace("$#", "[").Replace("#$", "]");
            }
            if (str6 != null)
            {
                str6 = str6.Replace("$#", "[").Replace("#$", "]");
            }
            string str8 = this.GetParamValue("FS:isSub");
            string s = this.GetParamValue("FS:Cols");
            string str10 = this.GetParamValue("FS:TitleNumer");
            string str11 = this.GetParamValue("FS:ContentNumber");
            string str12 = this.GetParamValue("FS:WNum");
            int num = 5;
            if ((str12 != null) && Input.IsInteger(str12))
            {
                num = int.Parse(str12);
            }
            string str13 = this.GetParamValue("FS:WCSS");
            string str14 = " Where substring(NewsProperty,9,1)='1' and islock=0 and isRecyle=0";
            if (UIConfig.WebDAL.ToLower() == "foosun.accessdal")
            {
                str14 = " Where mid(NewsProperty,9,1)='1' and islock=0 and isRecyle=0";
            }
            string str15 = " order by EditTime desc,id desc";
            DataTable table = null;
            string sql = string.Empty;
            switch (paramValue)
            {
                case null:
                case "-1":
                    if (this._TemplateType == TempType.Class)
                    {
                        if (str8 == "true")
                        {
                            str14 = str14 + " And [ClassID] In('" + this.getChildClassID(this.Param_CurrentClassID) + "')";
                        }
                        sql = string.Concat(new object[] { "select top ", num, " * from [", DBConfig.TableNamePrefix, "News]", str14, " And ClassID='", this.Param_CurrentClassID, "' ", str15 });
                    }
                    else
                    {
                        sql = string.Concat(new object[] { "select top ", num, " * from [", DBConfig.TableNamePrefix, "News]", str14, str15 });
                    }
                    break;

                default:
                    if (paramValue == "0")
                    {
                        sql = string.Concat(new object[] { "select top ", num, " * from [", DBConfig.TableNamePrefix, "News]", str14, str15 });
                    }
                    else
                    {
                        if (str8 == "true")
                        {
                            str14 = str14 + " And [ClassID] In(" + this.getChildClassID(paramValue) + ")";
                        }
                        sql = string.Concat(new object[] { "select top ", num, " * from [", DBConfig.TableNamePrefix, "News]", str14, str15 });
                    }
                    break;
            }
            table = CommonData.DalPublish.ExecuteSql(sql);
            int num2 = 11;
            if (str12 != null)
            {
                num2 = int.Parse(str12);
            }
            string titleNum = "30";
            if (str10 != null)
            {
                titleNum = str10;
            }
            bool flag = false;
            if (str3 == "true")
            {
                flag = true;
            }
            string str18 = "";
            string str19 = "";
            int num3 = 1;
            if (s != null)
            {
                num3 = int.Parse(s);
            }
            int count = table.Rows.Count;
            if ((table != null) && (count > 0))
            {
                for (int i = 0; i < count; i++)
                {
                    string str22;
                    if (flag)
                    {
                        if (i == 0)
                        {
                            if (flag)
                            {
                                string str20 = "20";
                                if (Input.IsInteger(input))
                                {
                                    str20 = input;
                                }
                                if (str4 != null)
                                {
                                    str18 = " class=\"" + str4 + "\"";
                                }
                                str22 = str;
                                str = str22 + "<div style=\"width:100%;text-align:center;\"><a href=\"" + this.GetNewsURL1(table.Rows[i]) + "\"" + str18 + ">" + this.GetNewstitleStyle(table.Rows[i], 1, str20) + "</a></div>\r\n";
                            }
                        }
                        else
                        {
                            if (str13 != null)
                            {
                                str19 = " class=\"" + str13 + "\"";
                            }
                            str22 = str;
                            str = str22 + "<a href=\"" + this.GetNewsURL1(table.Rows[i]) + "\"" + str19 + ">" + str5 + this.GetNewstitleStyle(table.Rows[i], 1, titleNum) + str6 + "</a>&nbsp;";
                            if (((i % num3) == 0) && (i != count))
                            {
                                str = str + "<br />";
                            }
                        }
                    }
                    else
                    {
                        if (str13 != null)
                        {
                            str19 = " class=\"" + str13 + "\"";
                        }
                        str22 = str;
                        str = str22 + "<a href=\"" + this.GetNewsURL1(table.Rows[i]) + "\"" + str19 + ">" + str5 + this.GetNewstitleStyle(table.Rows[i], 1, titleNum) + str6 + "</a>&nbsp;";
                        if ((((i + 1) % num3) == 0) && (i != count))
                        {
                            str = str + "<br />";
                        }
                    }
                }
                table.Clear();
                table.Dispose();
                return str;
            }
            return "无文字头条";
        }

        public string Analyse_TopNews()
        {
            string str = "";
            str = ((((((((str + "masscontent=" + HttpUtility.UrlEncode(this.Mass_Content)) + "&currentclassid=" + this.Param_CurrentClassID) + "&currentspecialid=" + this.Param_CurrentSpecialID) + "&currentnewsid=" + this.Param_CurrentNewsID) + "&ChID=" + this.Param_ChID) + "&currentchclassid=" + this.Param_CurrentCHClassID) + "&currentchspecialid=" + this.Param_CurrentCHSpecialID) + "&currentchnewsid=" + this.Param_CurrentCHNewsID) + "&TemplateType=" + ((int) this.TemplateType);
            return (((((((((("<div id=\"Div_TopNewsList\"><img src=\"" + CommonData.SiteDomain + "/sysimages/folder/loading.gif\" border=\"0\" />新闻排行内容加载中...</div>\r\n") + "<script language=\"javascript\" type=\"text/javascript\">\r\n") + "function GetTopNewsList()\r\n" + "{\r\n") + "   var Action='" + str + "';") + "   jQuery.get('" + CommonData.SiteDomain + "/TopNews.aspx?no-cache='+Math.random() + '&' + Action,  function(returnvalue){\r\n") + "                      var arrreturnvalue=returnvalue.split('$$$'); \r\n") + "                      if (arrreturnvalue[0]==\"ERR\") \r\n" + "                          document.getElementById(\"Div_TopNewsList\").innerHTML='加载内容失败!'; \r\n") + "                      else \r\n" + "                          document.getElementById(\"Div_TopNewsList\").innerHTML=arrreturnvalue[1]; \r\n") + "    });\r\n" + "}\r\n") + "GetTopNewsList();\r\n" + "</script>\r\n");
        }

        public string Analyse_TopNews1()
        {
            int num;
            string input = this.Mass_Inserted;
            string id = Regex.Match(input, @"\[\#FS:StyleID=(?<sid>[^\]]+)]", RegexOptions.Compiled).Groups["sid"].Value.Trim();
            if (!id.Equals(string.Empty))
            {
                input = LabelStyle.GetStyleByID(id);
            }
            if (input.Trim().Equals(string.Empty))
            {
                return string.Empty;
            }
            string paramValue = this.GetParamValue("FS:TopNewsType");
            string str4 = this.GetParamValue("FS:SubNews");
            string classID = this.GetParamValue("FS:ClassID");
            if (!int.TryParse(this.GetParamValue("FS:Cols"), out num))
            {
                num = 1;
            }
            if (num < 1)
            {
                num = 1;
            }
            string isDiv = this.GetParamValue("FS:isDiv");
            string ulID = this.GetParamValue("FS:ulID");
            string ulClass = this.GetParamValue("FS:ulClass");
            string str9 = this.GetParamValue("FS:isPic");
            string str10 = this.GetParamValue("FS:TitleNumer");
            string str11 = this.GetParamValue("FS:ContentNumber");
            string str12 = this.GetParamValue("FS:NaviNumber");
            string str13 = this.GetParamValue("FS:isSub");
            bool flag = false;
            if ((str4 != null) && (str4 == "true"))
            {
                flag = true;
            }
            string str14 = " Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "'";
            switch (str9)
            {
                case "true":
                    str14 = str14 + " And [NewsType]=1";
                    break;

                case "false":
                    str14 = str14 + " And([NewsType]=0 Or [NewsType]=2) ";
                    break;
            }
            string str15 = string.Empty;
            switch (paramValue)
            {
                case "Hour":
                    if (!(UIConfig.WebDAL == "foosun.accessdal"))
                    {
                        str15 = str15 + " And DateDiff(Day,[CreatTime] ,Getdate())=0 Order By [Click] desc, [CreatTime]";
                        break;
                    }
                    str15 = str15 + " And DateDiff('d',[CreatTime] ,now())=0 Order By [Click] desc, [CreatTime]";
                    break;

                case "YesDay":
                    if (!(UIConfig.WebDAL == "foosun.accessdal"))
                    {
                        str15 = str15 + " And DateDiff(Day,[CreatTime] ,Getdate())=1 Order By [Click] desc, [CreatTime]";
                        break;
                    }
                    str15 = str15 + " And DateDiff('d',[CreatTime] ,now())=1 Order By [Click] desc, [CreatTime]";
                    break;

                case "Week":
                    if (!(UIConfig.WebDAL == "foosun.accessdal"))
                    {
                        str15 = str15 + " And DateDiff(Week,[CreatTime] ,Getdate())=0 Order By [Click] desc, [CreatTime]";
                        break;
                    }
                    str15 = str15 + " And DateDiff('ww',[CreatTime] ,now())=0 Order By [Click] desc, [CreatTime]";
                    break;

                case "Month":
                    if (!(UIConfig.WebDAL == "foosun.accessdal"))
                    {
                        str15 = str15 + " And DateDiff(Month,[CreatTime] ,Getdate())=0 Order By [Click] desc, [CreatTime]";
                        break;
                    }
                    str15 = str15 + " And DateDiff('m',[CreatTime] ,now())=0 Order By [Click] desc, [CreatTime]";
                    break;

                case "Comm":
                {
                    string str21 = str15;
                    str15 = str21 + " Order By (Select Count(ID) From [" + DBConfig.TableNamePrefix + "api_commentary] Where [" + DBConfig.TableNamePrefix + "api_commentary].[InfoID]=[" + DBConfig.TableNamePrefix + "News].[NewsID])";
                    break;
                }
                case "disc":
                    str15 = str15 + " Order By [Click] desc, [CreatTime]";
                    break;

                default:
                    str15 = str15 + " Order By [Click] desc, [CreatTime]";
                    break;
            }
            str15 = str15 + " Desc,[ID] Desc";
            string sql = string.Empty;
            if ((classID == null) || (classID == "0"))
            {
                if (this._TemplateType == TempType.Class)
                {
                    if (str13 == "true")
                    {
                        str14 = str14 + " And [ClassID] In(" + this.getChildClassID(this.Param_CurrentClassID) + ")";
                    }
                    else
                    {
                        str14 = str14 + " And [ClassID] In('" + this.Param_CurrentClassID + "')";
                    }
                    sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str14, str15 });
                }
                else
                {
                    sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str14, str15 });
                }
            }
            else if (classID == "-1")
            {
                sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str14, str15 });
            }
            else
            {
                if (str13 == "true")
                {
                    str14 = str14 + " And [ClassID] In(" + this.getChildClassID(classID) + ")";
                }
                else
                {
                    str14 = str14 + " And [ClassID] In('" + classID + "')";
                }
                sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str14, str15 });
            }
            int titleNumer = 30;
            int contentNumber = 200;
            int naviNumber = 200;
            if ((str10 != null) && Input.IsInteger(str10))
            {
                titleNumer = int.Parse(str10);
            }
            if ((str11 != null) && Input.IsInteger(str11))
            {
                contentNumber = int.Parse(str11);
            }
            if ((str12 != null) && Input.IsInteger(str12))
            {
                naviNumber = int.Parse(str12);
            }
            DataTable table = null;
            try
            {
                table = CommonData.DalPublish.ExecuteSql(sql);
            }
            catch
            {
                sql = string.Concat(new object[] { "select top ", this.Param_Loop, " * from [", DBConfig.TableNamePrefix, "News] ", str14, " Order By [Click] desc, [NewsID] Desc,[ID] Desc" });
                table = CommonData.DalPublish.ExecuteSql(sql);
            }
            if ((table == null) || (table.Rows.Count < 1))
            {
                return string.Empty;
            }
            string str17 = string.Empty;
            int num5 = 0;
            while (num5 < table.Rows.Count)
            {
                Foosun.Model.News news;
                if (isDiv == "true")
                {
                    str17 = str17 + this.Analyse_ReadNews((int) table.Rows[num5][0], titleNumer, contentNumber, naviNumber, input, id, 1, 1, 0);
                    if (flag)
                    {
                        news = new Foosun.Model.News();
                        news = this.getNewsInfo((int) table.Rows[num5][0], null);
                        str17 = str17 + this.GetSubSTR(news.NewsID, string.Empty);
                    }
                }
                else
                {
                    isDiv = "false";
                    string str18 = this.Analyse_ReadNews((int) table.Rows[num5][0], titleNumer, contentNumber, naviNumber, input, id, 1, 1, 0);
                    if (flag)
                    {
                        news = new Foosun.Model.News();
                        news = this.getNewsInfo((int) table.Rows[num5][0], null);
                        str18 = str18 + this.GetSubSTR(news.NewsID, string.Empty);
                    }
                    if (num == 1)
                    {
                        str17 = str17 + "<tr>\r\n<td>\r\n" + str18 + "\r\n</td>\r\n</tr>\r\n";
                    }
                    else
                    {
                        str18 = string.Concat(new object[] { "<td width=\"", 100 / num, "%\">\r\n", str18, "\r\n</td>\r\n" });
                        if ((num5 > 0) && (((num5 + 1) % num) == 0))
                        {
                            str18 = "</tr>\r\n<tr>\r\n";
                        }
                        str17 = str17 + str18;
                    }
                }
                num5++;
            }
            table.Clear();
            table.Dispose();
            if ((str17 != string.Empty) && (num > 1))
            {
                str17 = "<tr>\r\n" + str17;
                if ((num5 % num) != 0)
                {
                    int num6 = num - num5;
                    if (num6 < 0)
                    {
                        num6 = num - (num5 % num);
                    }
                    for (int i = 0; i < num6; i++)
                    {
                        object obj2 = str17;
                        str17 = string.Concat(new object[] { obj2, "<td width=\"", 100 / num, "%\">\r\n </td>\r\n" });
                    }
                }
                str17 = str17 + "</tr>\r\n";
            }
            return (this.News_List_Head(isDiv, ulID, ulClass, "") + str17 + this.News_List_End(isDiv));
        }

        public string Analyse_TopUser()
        {
            IDataReader reader;
            string paramValue = this.GetParamValue("FS:TopUserType");
            string showNavi = this.GetParamValue("FS:ShowNavi");
            string naviCSS = this.GetParamValue("FS:NaviCSS");
            string naviPic = this.GetParamValue("FS:NaviPic");
            string str5 = this.GetParamValue("FS:CSS");
            string str6 = this.GetParamValue("FS:PointParam");
            string str7 = "";
            if (str5 != null)
            {
                str7 = " class=\"" + str5 + "\"";
            }
            string str8 = "";
            string orderfld = "";
            string str11 = paramValue;
            if (str11 != null)
            {
                if (!(str11 == "inter"))
                {
                    if (str11 == "gpoint")
                    {
                        orderfld = "gPoint";
                        goto Label_00EE;
                    }
                    if (str11 == "click")
                    {
                        orderfld = "ePoint";
                        goto Label_00EE;
                    }
                    if (str11 == "info")
                    {
                        orderfld = "Cnt";
                        goto Label_00EE;
                    }
                }
                else
                {
                    orderfld = "iPoint";
                    goto Label_00EE;
                }
            }
            orderfld = "RegTime";
        Label_00EE:
            reader = CommonData.DalPublish.GetTopUser(this.Param_Loop, orderfld);
            int i = 0;
            while (reader.Read())
            {
                string str12;
                if (str6 == "right")
                {
                    str12 = str8;
                    str8 = str12 + "<li style=\"list-style:none;\"><span style=\"float:left\">" + this.getNavi(showNavi, naviCSS, naviPic, i) + " <a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + reader["UserName"].ToString() + UIConfig.extensions + "\" " + str7 + " title=\"昵称：" + reader["NickName"].ToString() + "\" target=\"_blank\">" + reader["UserName"].ToString() + "</a></span><span style=\"float:right\">" + reader[orderfld].ToString() + "</span></li>\r\n";
                }
                else if (str6 == "left")
                {
                    str12 = str8;
                    str8 = str12 + "<li style=\"list-style:none;\">" + this.getNavi(showNavi, naviCSS, naviPic, i) + " <a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + reader["UserName"].ToString() + UIConfig.extensions + "\" title=\"昵称：" + reader["NickName"].ToString() + "\" " + str7 + " target=\"_blank\">" + reader["UserName"].ToString() + "</a> " + reader[orderfld].ToString() + "</li>\r\n";
                }
                else
                {
                    str12 = str8;
                    str8 = str12 + "<li style=\"list-style:none;\">" + this.getNavi(showNavi, naviCSS, naviPic, i) + " <a href=\"" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/showuser-" + reader["UserName"].ToString() + UIConfig.extensions + "\" title=\"昵称：" + reader["NickName"].ToString() + "\" " + str7 + " target=\"_blank\">" + reader["UserName"].ToString() + "</a></li>\r\n";
                }
                i++;
            }
            if (i < 1)
            {
                str8 = str8 + "<li>找不到记录!</li>\r\n";
            }
            reader.Close();
            return str8;
        }

        public string Analyse_unRule()
        {
            string str = string.Empty;
            string paramValue = this.GetParamValue("FS:RuleID");
            string str3 = this.GetParamValue("FS:STitle");
            string inputStr = this.GetParamValue("FS:unNavi");
            string str5 = string.Empty;
            string unID = "0";
            if (inputStr != null)
            {
                str5 = Input.isPicStr(inputStr);
            }
            if (paramValue != null)
            {
                unID = paramValue;
            }
            DataTable unRule = CommonData.DalPublish.GetUnRule(unID, this.Param_SiteID);
            if ((unRule != null) && (unRule.Rows.Count > 0))
            {
                string str11;
                string str7 = "";
                int num = 0;
                int num2 = 1;
                if (str3 == "true")
                {
                    str7 = unRule.Rows[0]["TitleCSS"].ToString();
                    if (!string.IsNullOrEmpty(str7))
                    {
                        str7 = " class=\"" + str7 + "\"";
                    }
                    str11 = str + "<div>\r\n";
                    str = (str11 + "<span" + str7 + ">" + unRule.Rows[0]["unName"].ToString() + "</span>") + "</div>\r\n";
                }
                str = str + "<div>\r\n";
                for (int i = 0; i < unRule.Rows.Count; i++)
                {
                    string str8 = unRule.Rows[i]["SubCSS"].ToString();
                    if (!string.IsNullOrEmpty(str8))
                    {
                        str8 = " class=\"" + str8 + "\"";
                    }
                    num = int.Parse(unRule.Rows[i]["Rows"].ToString());
                    Foosun.Model.News news = CommonData.getNewsInfoById(unRule.Rows[i]["ONewsID"].ToString());
                    string uRLaddress = "";
                    if (news != null)
                    {
                        PubClassInfo classById = CommonData.GetClassById(news.ClassID);
                        if ((((classById != null) && (news.SavePath != null)) && (news.FileName != null)) && (news.FileEXName != null))
                        {
                            if (news.NewsType == 2)
                            {
                                uRLaddress = news.URLaddress;
                            }
                            else
                            {
                                uRLaddress = this.GetNewsURL(news.isDelPoint.ToString(), news.NewsID, news.SavePath, classById.SavePath + "/" + classById.SaveClassframe, news.FileName, news.FileEXName, news.NewsType.ToString(), news.URLaddress);
                            }
                        }
                        else
                        {
                            uRLaddress = "javascript:void(0);";
                        }
                        if (num == num2)
                        {
                            if (i == 0)
                            {
                                str11 = str;
                                str = str11 + str5 + "<a target=\"_blank\" href=\"" + uRLaddress + "\"" + str8 + ">" + unRule.Rows[i]["unTitle"].ToString() + "</a>&nbsp;";
                            }
                            else
                            {
                                str11 = str;
                                str = str11 + "<a target=\"_blank\" href=\"" + uRLaddress + "\"" + str8 + ">" + unRule.Rows[i]["unTitle"].ToString() + "</a>&nbsp;";
                            }
                        }
                        else
                        {
                            num2++;
                            str11 = str;
                            str = str11 + "<br />" + str5 + "<a target=\"_blank\" href=\"" + uRLaddress + "\"" + str8 + ">" + unRule.Rows[i]["unTitle"].ToString() + "</a>&nbsp;";
                        }
                    }
                }
                str = str + "</div>\r\n";
                unRule.Clear();
                unRule.Dispose();
            }
            return str;
        }

        public string Analyse_UserLogin()
        {
            APIConfig config = APIConfigs.GetConfig();
            string paramValue = this.GetParamValue("FS:LoginP");
            string str2 = this.GetParamValue("FS:FormCSS");
            string str3 = this.GetParamValue("FS:LoginCSS");
            string input = this.GetParamValue("FS:RegCSS");
            string str5 = this.GetParamValue("FS:PassCSS");
            string str6 = this.GetParamValue("FS:StyleID");
            string str7 = Rand.Number(5);
            string str8 = ("<div id=\"Div_UserInfo" + str7 + "\">正在加载中...\r\n") + "</div>\r\n";
            if (paramValue == null)
            {
                paramValue = "true";
            }
            string str10 = (str8 + "<script type=\"text/javascript\">\r\n" + "var hiddenValues;\r\n") + "function getLoginForm()\r\n" + "{\r\n";
            str10 = str10 + "      var Action='Type=getLoginForm&RandNum=" + str7 + "&LoginP=" + paramValue + "&FormCSS=" + str2 + "&LoginCSS=" + str3 + "&RegCSS=" + Input.URLEncode(input) + "&PassCSS=" + Input.URLEncode(str5) + "&StyleID=" + Input.URLEncode(str6) + "';\r\n";
            str8 = ((((((str10 + "      jQuery.get('" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/UserLoginajax.aspx?no-cache='+Math.random() + '&' + Action, function(responseText){\r\n") + "                      if (responseText.indexOf(\"??\")>-1) \r\n") + "                          alert('未知错误!请联系系统管理员'); \r\n" + "                      else \r\n") + "                          document.getElementById(\"Div_UserInfo" + str7 + "\").innerHTML=responseText; \r\n") + "           });" + "}\r\n") + "function LoginSubmit(obj)\r\n" + "{\r\n") + "      if(obj.UserNum.value==\"\"){alert('帐号不能为空');return false;}\r\n" + "      if(obj.UserPwd.value==\"\"){alert('密码不能为空');return false;}\r\n";
            if (config.Enable)
            {
                str10 = (str8 + "      hiddenValues = obj.UserNum.value;\r\n") + "      var adaptAction='username='+escape(obj.UserNum.value)+'&password='+escape(obj.UserPwd.value)+'&tag=login&StyleID=" + Input.URLEncode(str6) + "';\r\n";
                str8 = (str10 + "      jQuery.get('" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/ConformityInterface.aspx?no-cache='+Math.random() + '&' + adaptAction, function(transport){\r\n") + "                       sendInterface(transport);\r\n" + "      });";
            }
            str10 = str8;
            str10 = str10 + "      var Action='UserNum='+escape(obj.UserNum.value)+'&UserPwd='+escape(obj.UserPwd.value)+'&Type=Login&RandNum=" + str7 + "&LoginP=" + paramValue + "&StyleID=" + Input.URLEncode(str6) + "';\r\n";
            str8 = ((((str10 + "      jQuery.get('" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/UserLoginajax.aspx?no-cache='+Math.random() + '&' + Action, function(returnvalue){\r\n") + "                      var returnvaluearr=returnvalue.split('$$$'); \r\n" + "                      if (returnvaluearr[0]==\"ERR\") \r\n") + "                          alert(returnvaluearr[1]); \r\n" + "                      else \r\n") + "                          document.getElementById(\"Div_UserInfo" + str7 + "\").innerHTML=returnvaluearr[1]; \r\n") + "      });\r\n" + "}\r\n";
            if (config.Enable)
            {
                str8 = ((((((((((((((((str8 + "function sendInterface(xmlObj)\r\n" + "{") + "xmlObj = xmlObj.responseXML.getElementsByTagName('www');\r\n" + "\tfor(var i = 0;i<xmlObj.length;i++)\r\n") + "\t{\r\n" + "\tvar url = xmlObj[i].childNodes[0].firstChild.nodeValue + 'nocache=' + Math.random();\r\n") + "\tvar username = xmlObj[i].childNodes[1].firstChild.nodeValue;\r\n" + "\tvar syskey = xmlObj[i].childNodes[2].firstChild.nodeValue;\r\n") + "\tvar password = xmlObj[i].childNodes[3].firstChild.nodeValue;\r\n" + "\tvar savecookie = xmlObj[i].childNodes[4].firstChild.nodeValue;\r\n") + "\tvar adaptAction='username='+ username +'&syskey=' + syskey + '&password=' + password + '&savecookie=' + savecookie;\r\n" + "url=url +'&'+ adaptAction;\r\n") + "var oScript = document.createElement('script');\r\n" + "oScript.src = url;\r\n") + "oScript.charset = \"GB2312\";\r\n" + "document.getElementsByTagName(\"head\")[0].appendChild(oScript);\r\n") + "\t}\r\n" + "}\r\n") + "function sendLoginOutInterFace(xmlObj)\r\n" + "{\r\n") + "\txmlObj = xmlObj.responseXML.getElementsByTagName('www');\r\n" + "\tfor(var i = 0;i<xmlObj.length;i++)\r\n") + "\t{\r\n" + "\t\tvar url = xmlObj[i].childNodes[0].firstChild.nodeValue + 'nocache=' + Math.random();\r\n") + "\tvar username = xmlObj[i].childNodes[1].firstChild.nodeValue;\r\n" + "\t\tvar syskey = xmlObj[i].childNodes[2].firstChild.nodeValue;\r\n") + "\t\tvar adaptAction='username='+ username +'&syskey=' + syskey;\r\n" + "url=url +'&'+ adaptAction;\r\n") + "var oScript = document.createElement('script');\r\n" + "oScript.src = url;\r\n") + "oScript.charset = \"GB2312\";\r\n" + "document.getElementsByTagName(\"head\")[0].appendChild(oScript);\r\n") + "\t}\r\n" + "}\r\n";
            }
            str8 = str8 + "function LoginOut()\r\n" + "{\r\n";
            if (config.Enable)
            {
                str10 = str8 + "      var adaptAction='tag=logout&userName='+escape(hiddenValues)+'&StyleID=" + Input.URLEncode(str6) + "';\r\n";
                str8 = (str10 + "      jQuery.get('" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/ConformityInterface.aspx?no-cache='+Math.random() + '&' + adaptAction,function(transport){\r\n") + "                        sendLoginOutInterFace(transport);\r\n" + "});\r\n";
            }
            str10 = str8;
            str10 = str10 + "      var Action='Type=LoginOut&LoginP=" + paramValue + "&StyleID=" + Input.URLEncode(str6) + "';\r\n";
            return ((((((str10 + "      jQuery.get('" + CommonData.SiteDomain + "/" + UIConfig.dirUser + "/UserLoginajax.aspx?no-cache='+Math.random() + '&' + Action, function(returnvalue){\r\n") + "                      if (returnvalue.indexOf(\"??\")>-1) \r\n") + "                          alert('未知错误!请联系管理员'); \r\n" + "                      else \r\n") + "                          document.getElementById(\"Div_UserInfo" + str7 + "\").innerHTML=returnvalue; \r\n") + "      });\r\n" + "}\r\n") + "getLoginForm();\r\n" + "</script>\r\n");
        }

        protected string ChildList(IList<PubClassInfo> list, string Classid, string sign)
        {
            string str = "";
            sign = sign + "─";
            foreach (PubClassInfo info in list)
            {
                if ((info.ParentID == Classid) && (info.SiteID == this.Param_SiteID))
                {
                    string classID = info.ClassID;
                    string classCName = info.ClassCName;
                    string str5 = str;
                    str = str5 + "<option value=\"" + classID + "\">" + sign + classCName + "</option>\r\n";
                    str = str + this.ChildList(list, classID, sign);
                }
            }
            return str;
        }

        public string FillClassInfoStyle(string classStyle, DataRow classInfo, int titleWords, int naviWords)
        {
            if (classStyle.IndexOf("{#class_Name}") > -1)
            {
                if (classInfo["ClassCName"] != DBNull.Value)
                {
                    classStyle = classStyle.Replace("{#class_Name}", (titleWords == 0) ? classInfo["ClassCName"].ToString() : Input.GetSubString(classInfo["ClassCName"].ToString(), titleWords));
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_Name}", "");
                }
            }
            if (classStyle.IndexOf("{#class_EName}") > -1)
            {
                if (classInfo["ClassEName"] != DBNull.Value)
                {
                    classStyle = classStyle.Replace("{#class_EName}", classInfo["ClassEName"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_EName}", "");
                }
            }
            if (classStyle.IndexOf("{#class_Path}") > -1)
            {
                classStyle = classStyle.Replace("{#class_Path}", this.GetClassURL(classInfo["Domain"].ToString(), Convert.ToInt32(classInfo["isDelPoint"]), classInfo["ClassID"].ToString(), classInfo["SavePath"].ToString(), classInfo["SaveClassframe"].ToString(), classInfo["ClassSaveRule"].ToString(), Convert.ToInt32(classInfo["IsURL"]), classInfo["URLaddress"].ToString(), 0));
            }
            if (classStyle.IndexOf("{#class_Navi}") > -1)
            {
                if (classInfo["NaviContent"] != DBNull.Value)
                {
                    classStyle = classStyle.Replace("{#class_Navi}", (naviWords == 0) ? classInfo["NaviContent"].ToString() : Input.GetSubString(classInfo["NaviContent"].ToString(), naviWords));
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_Navi}", "");
                }
            }
            if (classStyle.IndexOf("{#class_NaviPic}") > -1)
            {
                if (classInfo["NaviPIC"] != DBNull.Value)
                {
                    classStyle = classStyle.Replace("{#class_NaviPic}", classInfo["NaviPIC"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_NaviPic}", "");
                }
            }
            if (classStyle.IndexOf("{#class_Keywords}") > -1)
            {
                if (classInfo["MetaKeywords"] != DBNull.Value)
                {
                    classStyle = classStyle.Replace("{#class_Keywords}", classInfo["MetaKeywords"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_Keywords}", "");
                }
            }
            if (classStyle.IndexOf("{#class_Descript}") > -1)
            {
                if (classInfo["MetaDescript"] != DBNull.Value)
                {
                    classStyle = classStyle.Replace("{#class_Descript}", classInfo["MetaDescript"].ToString());
                    return classStyle;
                }
                classStyle = classStyle.Replace("{#class_Descript}", "");
            }
            return classStyle;
        }

        public string getCHClassURL(int ChID, int isDelPoint, int id, string ClassSavePath, string FileName)
        {
            string str = string.Empty;
            int num = int.Parse(Public.readCHparamConfig("isHTML", ChID));
            string str2 = Public.readCHparamConfig("bdomain", ChID);
            string str3 = Public.readparamConfig("linkTypeConfig");
            string str4 = Public.readCHparamConfig("htmldir", ChID);
            string dirDumm = UIConfig.dirDumm;
            if (dirDumm.Trim() != string.Empty)
            {
                dirDumm = "/" + dirDumm;
            }
            if ((num != 0) && (isDelPoint == 0))
            {
                string str6 = string.Empty;
                if (str2 == string.Empty)
                {
                    str = ("/" + str4 + "/" + ClassSavePath + "/" + FileName).Replace("//", "/");
                    str = CommonData.SiteDomain + str;
                }
                else if (str3 == "1")
                {
                    if (str2.IndexOf("http://") > -1)
                    {
                        str6 = str2;
                    }
                    else
                    {
                        str6 = "http://" + str2;
                    }
                    str = str6 + "/" + ClassSavePath + "/" + FileName;
                }
                else
                {
                    str = "/" + ClassSavePath + "/" + FileName;
                }
            }
            else
            {
                str = CommonData.SiteDomain + "/list-" + id.ToString() + "-" + ChID.ToString() + "-1" + UIConfig.extensions;
            }
            return str.ToLower().Replace("{@dirhtml}", UIConfig.dirHtml);
        }

        protected string GetChildClass(string ParentID)
        {
            string str = string.Empty;
            IList<PubClassInfo> newsClass = CommonData.NewsClass;
            if ((newsClass != null) && (newsClass.Count > 0))
            {
                foreach (PubClassInfo info in newsClass)
                {
                    if ((((info.IsURL == 0) && (info.SiteID == this.Param_SiteID)) && (info.ParentID != null)) && (info.ParentID == ParentID))
                    {
                        string str3 = str;
                        str = str3 + ",'" + info.ClassID + "'" + this.GetChildClass(info.ClassID);
                    }
                }
            }
            return str;
        }

        protected string getChildClassID(string ClassID)
        {
            string str = "";
            if (ClassID.IndexOf('|') > -1)
            {
                string[] strArray = ClassID.Split(new char[] { '|' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (str == "")
                    {
                        str = "'" + ClassID + "'" + this.GetChildClass(ClassID);
                    }
                    else
                    {
                        string str3 = str;
                        str = str3 + ",'" + ClassID + "'" + this.GetChildClass(ClassID);
                    }
                }
                return str;
            }
            return ("'" + ClassID + "'" + this.GetChildClass(ClassID));
        }

        protected string GetChildSpecial(string ParentID)
        {
            string str = string.Empty;
            IList<PubSpecialInfo> newsSpecial = CommonData.NewsSpecial;
            if ((newsSpecial != null) && (newsSpecial.Count > 0))
            {
                foreach (PubSpecialInfo info in newsSpecial)
                {
                    if ((info.SiteID.ToLower().Trim() == this.Param_SiteID.ToLower().Trim()) && (info.ParentID == ParentID))
                    {
                        string str3 = str;
                        str = str3 + ",'" + info.SpecialID + "'" + this.GetChildSpecial(info.SpecialID);
                    }
                }
            }
            return str;
        }

        protected string getChildSpecialID(string SpecialID)
        {
            return ("'" + SpecialID + "'" + this.GetChildSpecial(SpecialID));
        }

        protected ChContentParam GetCHInfo(int ID, string DTable)
        {
            ChContentParam param = new ChContentParam();
            IDataReader cHDetail = CommonData.DalPublish.GetCHDetail(ID, DTable);
            if (cHDetail.Read())
            {
                param.ID = Convert.ToInt32(cHDetail["ID"]);
                param.OrderID = Convert.ToByte(cHDetail["OrderID"]);
                param.Title = Convert.ToString(cHDetail["Title"]);
                if (cHDetail["TitleColor"] == DBNull.Value)
                {
                    param.TitleColor = "";
                }
                else
                {
                    param.TitleColor = Convert.ToString(cHDetail["TitleColor"]);
                }
                if (cHDetail["TitleITF"] == DBNull.Value)
                {
                    param.TitleITF = 0;
                }
                else
                {
                    param.TitleITF = Convert.ToByte(cHDetail["TitleITF"]);
                }
                if (cHDetail["TitleBTF"] == DBNull.Value)
                {
                    param.TitleBTF = 0;
                }
                else
                {
                    param.TitleBTF = Convert.ToByte(cHDetail["TitleBTF"]);
                }
                if (cHDetail["PicURL"] == DBNull.Value)
                {
                    param.PicURL = "";
                }
                else
                {
                    param.PicURL = Convert.ToString(cHDetail["PicURL"]);
                }
                param.ClassID = Convert.ToInt32(cHDetail["ClassID"].ToString());
                if (cHDetail["SpecialID"] == DBNull.Value)
                {
                    param.SpecialID = "";
                }
                else
                {
                    param.SpecialID = Convert.ToString(cHDetail["SpecialID"]);
                }
                if (cHDetail["Author"] == DBNull.Value)
                {
                    param.Author = "";
                }
                else
                {
                    param.Author = Convert.ToString(cHDetail["Author"]);
                }
                if (cHDetail["Souce"] == DBNull.Value)
                {
                    param.Souce = "";
                }
                else
                {
                    param.Souce = Convert.ToString(cHDetail["Souce"]);
                }
                if (cHDetail["Tags"] == DBNull.Value)
                {
                    param.Tags = "";
                }
                else
                {
                    param.Tags = Convert.ToString(cHDetail["Tags"]);
                }
                if (cHDetail["ContentProperty"] == DBNull.Value)
                {
                    param.ContentProperty = "0|0|0|0|0";
                }
                else
                {
                    param.ContentProperty = Convert.ToString(cHDetail["ContentProperty"]);
                }
                if (cHDetail["Templet"] == DBNull.Value)
                {
                    param.Templet = "";
                }
                else
                {
                    param.Templet = Convert.ToString(cHDetail["Templet"]);
                }
                if (cHDetail["Content"] == DBNull.Value)
                {
                    param.Content = "";
                }
                else
                {
                    param.Content = Convert.ToString(cHDetail["Content"]);
                }
                if (cHDetail["Metakeywords"] == DBNull.Value)
                {
                    param.Metakeywords = "";
                }
                else
                {
                    param.Metakeywords = Convert.ToString(cHDetail["Metakeywords"]);
                }
                if (cHDetail["Metadesc"] == DBNull.Value)
                {
                    param.Metadesc = "";
                }
                else
                {
                    param.Metadesc = Convert.ToString(cHDetail["Metadesc"]);
                }
                if (cHDetail["NaviContent"] == DBNull.Value)
                {
                    param.naviContent = "";
                }
                else
                {
                    param.naviContent = Convert.ToString(cHDetail["NaviContent"]);
                }
                if (cHDetail["Click"] == DBNull.Value)
                {
                    param.Click = 0;
                }
                else
                {
                    param.Click = Convert.ToInt32(cHDetail["Click"].ToString());
                }
                if (cHDetail["CreatTime"] == DBNull.Value)
                {
                    param.CreatTime = DateTime.Now;
                }
                else
                {
                    param.CreatTime = Convert.ToDateTime(cHDetail["CreatTime"].ToString());
                }
                if (cHDetail["SavePath"] == DBNull.Value)
                {
                    param.SavePath = "";
                }
                else
                {
                    param.SavePath = Convert.ToString(cHDetail["SavePath"]);
                }
                if (cHDetail["FileName"] == DBNull.Value)
                {
                    param.FileName = "";
                }
                else
                {
                    param.FileName = Convert.ToString(cHDetail["FileName"]);
                }
                if (cHDetail["isDelPoint"] == DBNull.Value)
                {
                    param.isDelPoint = 0;
                }
                else
                {
                    param.isDelPoint = Convert.ToInt32(cHDetail["isDelPoint"].ToString());
                }
                if (cHDetail["Gpoint"] == DBNull.Value)
                {
                    param.Gpoint = 0;
                }
                else
                {
                    param.Gpoint = Convert.ToInt32(cHDetail["Gpoint"].ToString());
                }
                if (cHDetail["iPoint"] == DBNull.Value)
                {
                    param.iPoint = 0;
                }
                else
                {
                    param.iPoint = Convert.ToInt32(cHDetail["iPoint"].ToString());
                }
                if (cHDetail["GroupNumber"] == DBNull.Value)
                {
                    param.GroupNumber = "";
                }
                else
                {
                    param.GroupNumber = Convert.ToString(cHDetail["GroupNumber"]);
                }
                if (cHDetail["isLock"] == DBNull.Value)
                {
                    param.isLock = 0;
                }
                else
                {
                    param.isLock = Convert.ToByte(cHDetail["isLock"]);
                }
                if (cHDetail["ChID"] == DBNull.Value)
                {
                    param.ChID = 0;
                }
                else
                {
                    param.ChID = Convert.ToInt32(cHDetail["ChID"].ToString());
                }
                if (cHDetail["Editor"] == DBNull.Value)
                {
                    param.Editor = "";
                }
                else
                {
                    param.Editor = Convert.ToString(cHDetail["Editor"]);
                }
                if (cHDetail["isHtml"] == DBNull.Value)
                {
                    param.isHtml = 0;
                }
                else
                {
                    param.isHtml = Convert.ToByte(cHDetail["isHtml"]);
                }
                if (cHDetail["isConstr"] == DBNull.Value)
                {
                    param.isConstr = 0;
                }
                else
                {
                    param.isConstr = Convert.ToByte(cHDetail["isConstr"]);
                }
            }
            cHDetail.Close();
            return param;
        }

        public string getCHInfoURL(int ChID, int isDelPoint, int id, string ClassSavePath, string SavePath, string FileName)
        {
            string str = string.Empty;
            int num = int.Parse(Public.readCHparamConfig("isHTML", ChID));
            string str2 = Public.readCHparamConfig("bdomain", ChID);
            string str3 = Public.readparamConfig("linkTypeConfig");
            string str4 = Public.readCHparamConfig("htmldir", ChID);
            string dirDumm = UIConfig.dirDumm;
            if (dirDumm.Trim() != string.Empty)
            {
                dirDumm = "/" + dirDumm;
            }
            if ((num != 0) && (isDelPoint == 0))
            {
                string str6 = string.Empty;
                if (str2 == string.Empty)
                {
                    str = ("/" + str4 + "/" + ClassSavePath + "/" + SavePath + "/" + FileName).Replace("//", "/");
                    str = CommonData.SiteDomain + str;
                }
                else if (str3 == "1")
                {
                    if (str2.IndexOf("http://") > -1)
                    {
                        str6 = str2;
                    }
                    else
                    {
                        str6 = "http://" + str2;
                    }
                    str = str6 + "/" + ClassSavePath + "/" + SavePath + "/" + FileName;
                }
                else
                {
                    str = "/" + ClassSavePath + "/" + SavePath + "/" + FileName;
                }
            }
            else
            {
                str = CommonData.SiteDomain + "/Content-" + id.ToString() + "-" + ChID.ToString() + "-1" + UIConfig.extensions;
            }
            return str.ToLower().Replace("{@dirhtml}", UIConfig.dirHtml);
        }

        public string GetCHPositionSTR(string DynStr, int ID, string Str, int ChID)
        {
            if (dimmDir.Trim() != string.Empty)
            {
                dimmDir = "/" + dimmDir;
            }
            string str = string.Empty;
            string str3 = Str;
            if (str3 != null)
            {
                if (!(str3 == "ChClass"))
                {
                    if (str3 == "ChNews")
                    {
                        IDataReader reader2 = CommonData.DalPublish.GetCHPosition(ID, 1, ChID);
                        if (reader2.Read())
                        {
                            str = "<a href=\"" + this.getCHClassURL(ChID, int.Parse(reader2["isDelPoint"].ToString()), int.Parse(reader2["id"].ToString()), reader2["SavePath"].ToString(), reader2["FileName"].ToString()) + "\">" + reader2["classCName"].ToString() + "</a>" + DynStr;
                            if (reader2["ParentID"].ToString() != "0")
                            {
                                str = this.GetCHPositionSTR(DynStr, int.Parse(reader2["ParentID"].ToString()), Str, ChID) + str;
                            }
                        }
                        str = str + "正文";
                        reader2.Close();
                        return str;
                    }
                    if (str3 == "ChSpecial")
                    {
                        IDataReader reader3 = CommonData.DalPublish.GetCHPosition(ID, 2, ChID);
                        if (reader3.Read())
                        {
                            str = "<a href=\"" + this.getCHSpecialURL(ChID, 0, int.Parse(reader3["id"].ToString()), reader3["SavePath"].ToString(), reader3["FileName"].ToString()) + "\">" + reader3["specialCName"].ToString() + "</a>" + DynStr;
                            if (reader3["ParentID"].ToString() != "0")
                            {
                                str = this.GetCHPositionSTR(DynStr, int.Parse(reader3["ParentID"].ToString()), Str, ChID) + str;
                            }
                        }
                        str = str + "专题报道";
                        reader3.Close();
                    }
                    return str;
                }
                IDataReader reader = CommonData.DalPublish.GetCHPosition(ID, 0, ChID);
                if (reader.Read())
                {
                    str = "<a href=\"" + this.getCHClassURL(ChID, int.Parse(reader["isDelPoint"].ToString()), int.Parse(reader["id"].ToString()), reader["SavePath"].ToString(), reader["FileName"].ToString()) + "\">" + reader["classCName"].ToString() + "</a>" + DynStr;
                    if (reader["ParentID"].ToString() != "0")
                    {
                        str = this.GetCHPositionSTR(DynStr, int.Parse(reader["ParentID"].ToString()), Str, ChID) + str;
                    }
                }
                reader.Close();
            }
            return str;
        }

        public string getCHSpecialURL(int ChID, int isDelPoint, int id, string SpecialSavePath, string FileName)
        {
            string str = string.Empty;
            int num = int.Parse(Public.readCHparamConfig("isHTML", ChID));
            string str2 = Public.readCHparamConfig("bdomain", ChID);
            string str3 = Public.readparamConfig("linkTypeConfig");
            string str4 = Public.readCHparamConfig("htmldir", ChID);
            string dirDumm = UIConfig.dirDumm;
            if (dirDumm.Trim() != string.Empty)
            {
                dirDumm = "/" + dirDumm;
            }
            if (num != 0)
            {
                string str6 = string.Empty;
                if (str2 == string.Empty)
                {
                    str = ("/" + str4 + "/" + SpecialSavePath + "/" + FileName).Replace("//", "/");
                    str = CommonData.SiteDomain + str;
                }
                else if (str3 == "1")
                {
                    if (str2.IndexOf("http://") > -1)
                    {
                        str6 = str2;
                    }
                    else
                    {
                        str6 = "http://" + str2;
                    }
                    str = str6 + "/" + SpecialSavePath + "/" + FileName;
                }
                else
                {
                    str = "/" + SpecialSavePath + "/" + FileName;
                }
            }
            else
            {
                str = CommonData.SiteDomain + "/special-" + id.ToString() + "-" + ChID.ToString() + "-1" + UIConfig.extensions;
            }
            return str.ToLower().Replace("{@dirhtml}", UIConfig.dirHtml);
        }

        protected string GetClassURL(string Domain, int isDelPoint, string ClassID, string SavePath, string SaveClassframe, string ClassSaveRule, int IsURL, string URLaddress, int isPage)
        {
            if (IsURL == 1)
            {
                return URLaddress;
            }
            string str = "";
            if (isPage == 0)
            {
                if (Domain.Length > 5)
                {
                    if (Public.readparamConfig("ReviewType") == "1")
                    {
                        str = "/list-" + ClassID + UIConfig.extensions;
                        return (CommonData.SiteDomain + str.Replace("//", "/").Replace("//", "/"));
                    }
                    if (isDelPoint != 0)
                    {
                        str = "/list-" + ClassID + UIConfig.extensions;
                        return (CommonData.SiteDomain + str.Replace("//", "/").Replace("//", "/"));
                    }
                    str = "/" + ClassSaveRule;
                    return (Domain + str.Replace("//", "/").Replace("//", "/"));
                }
                if (Public.readparamConfig("ReviewType") == "1")
                {
                    str = "/list-" + ClassID + UIConfig.extensions;
                }
                else if (isDelPoint != 0)
                {
                    str = "/list-" + ClassID + UIConfig.extensions;
                }
                else
                {
                    if (!((SavePath == null) || SavePath.Equals("")))
                    {
                        str = "/" + SavePath;
                    }
                    if (!((SaveClassframe == null) || SaveClassframe.Equals("")))
                    {
                        str = str + "/" + SaveClassframe;
                    }
                    if (!((ClassSaveRule == null) || ClassSaveRule.Equals("")))
                    {
                        str = str + "/" + ClassSaveRule;
                    }
                }
                return (CommonData.SiteDomain + str.Replace("//", "/").Replace("//", "/"));
            }
            if (Domain.Length > 5)
            {
                if (Public.readparamConfig("ReviewType") == "1")
                {
                    str = "/page-" + ClassID + UIConfig.extensions;
                    return (CommonData.SiteDomain + str.Replace("//", "/").Replace("//", "/"));
                }
                if (isDelPoint != 0)
                {
                    str = "/page-" + ClassID + UIConfig.extensions;
                    return (CommonData.SiteDomain + str.Replace("//", "/").Replace("//", "/"));
                }
                str = "/" + ClassSaveRule;
                return (Domain + str.Replace("//", "/").Replace("//", "/"));
            }
            if (Public.readparamConfig("ReviewType") == "1")
            {
                str = "/page-" + ClassID + UIConfig.extensions;
            }
            else if (isDelPoint != 0)
            {
                str = "/page-" + ClassID + UIConfig.extensions;
            }
            else
            {
                if (!((SavePath == null) || SavePath.Equals("")))
                {
                    str = "/" + SavePath;
                }
                if (!((SaveClassframe == null) || SaveClassframe.Equals("")))
                {
                    str = str + "/" + SaveClassframe;
                }
                if (!((ClassSaveRule == null) || ClassSaveRule.Equals("")))
                {
                    str = str + "/" + ClassSaveRule;
                }
            }
            return (CommonData.SiteDomain + str.Replace("//", "/").Replace("//", "/"));
        }

        protected string GetCollection(string NewsID, int ChID)
        {
            return string.Concat(new object[] { CommonData.SiteDomain, "/", UIConfig.dirUser, "/index.aspx?urls=info/collection.aspx?ChID=", ChID, "|Add|", NewsID });
        }

        protected string GetCommCount(string NewsID, int NewsTF, int td, int ChID)
        {
            string str = "";
            if (NewsTF == 1)
            {
                string str2 = Rand.Number(3);
                object obj2 = str;
                obj2 = string.Concat(new object[] { obj2, "<a href=\"", CommonData.SiteDomain, "/Comment.aspx?CommentType=getlist&id=", NewsID, "&ChID=", ChID, "\"><span id=\"gCount", NewsID, str2, td, "\"></span></a>\r\n" }) + "<script language=\"javascript\" type=\"text/javascript\">";
                return (string.Concat(new object[] { obj2, "pubajax('", CommonData.SiteDomain, "/comment.aspx','id=", NewsID, "&commCount=1&ChID=", ChID, "&Today=", td, "','gCount", NewsID, str2, td, "');" }) + "</script>");
            }
            return CommonData.DalPublish.GetCommCount(NewsID, td, ChID).ToString();
        }

        protected string GetCommForm(string NewsID, int NewsTF, int ChID)
        {
            if (NewsTF == 1)
            {
                object obj2 = (("<a name=\"commList\"></a><div id=\"Div_CommentForm\"><img src=\"" + CommonData.SiteDomain + "/sysimages/folder/loading.gif\" border=\"0\" />评论表单加载中...</div>\r\n") + "<script language=\"javascript\" type=\"text/javascript\">\r\n") + "function GetAddCommentForm()\r\n" + "{\r\n";
                return (((((((((((((((((((((((((((((((string.Concat(new object[] { obj2, "   var Action='id=", NewsID, "&ChID=", ChID, "&CommentType=GetAddCommentForm';" }) + "   jQuery.get('" + CommonData.SiteDomain + "/comment.aspx?no-cache='+Math.random() + '&' + Action, function(returnvalue){\r\n") + "                      var arrreturnvalue=returnvalue.split('$$$'); \r\n") + "                      if (arrreturnvalue[0]==\"ERR\") \r\n" + "                          document.getElementById(\"Div_CommentForm\").innerHTML='加载评论表单失败!'; \r\n") + "                      else \r\n" + "                          document.getElementById(\"Div_CommentForm\").innerHTML=arrreturnvalue[1]; \r\n") + "   });\r\n" + "}\r\n") + "GetAddCommentForm();\r\n" + "function CommandSubmit(obj)\r\n") + "{\r\n" + "    if(obj.UserNum.value==\"\")\r\n") + "    {\r\n" + "        alert('帐号不能为空');\r\n") + "        return false;\r\n" + "    }\r\n") + "    if(obj.Content.value==\"\")\r\n" + "    {\r\n") + "        alert('评论内容不能为空');\r\n" + "        return false;\r\n") + "    }\r\n" + "    var r = obj.commtype; \r\n") + "    var commtypevalue = '2'; \r\n" + "    for(var i=0;i<r.length;i++) \r\n") + "    {\r\n" + "        if(r[i].checked)\r\n") + "           commtypevalue=r[i].value;\r\n" + "    }\r\n") + "    var Action='CommentType=AddComment&UserNum='+escape(obj.UserNum.value)+'&UserPwd='+escape(obj.UserPwd.value)+'&commtype='+escape(commtypevalue)+'&Content='+escape(obj.Content.value)+'&IsQID='+escape(obj.IsQID.value)+'&id=" + NewsID + "';\r\n") + "   jQuery.get('" + CommonData.SiteDomain + "/comment.aspx?no-cache='+Math.random() + '&' + Action, function(returnvalue){\r\n") + "                        var arrreturnvalue=returnvalue.split('$$$'); \r\n") + "                        if (arrreturnvalue[0]==\"ERR\") \r\n" + "                        { \r\n") + "                           alert(arrreturnvalue[1]); \r\n" + "                           GetAddCommentForm(); \r\n") + "                        } \r\n" + "                        else \r\n") + "                        { \r\n" + "                           alert('发表评论成功!'); \r\n") + "                           document.getElementById(\"Div_CommentList\").innerHTML=arrreturnvalue[1]; \r\n" + "                           GetAddCommentForm(); \r\n") + "                        } \r\n" + "   });\r\n") + "}\r\n" + "function CommentLoginOut()\r\n") + "{\r\n" + "    var Action='CommentType=LoginOut';\r\n") + "   jQuery.get('" + CommonData.SiteDomain + "/comment.aspx?no-cache='+Math.random() + '&' + Action, function(returnvalue){\r\n") + "                      var arrreturnvalue=returnvalue.split('$$$'); \r\n" + "                      if (arrreturnvalue[0]==\"ERR\") \r\n") + "                          alert('未知错误!'); \r\n" + "                      else \r\n") + "                          document.getElementById(\"Div_CommentForm\").innerHTML=arrreturnvalue[1]; \r\n" + "   });\r\n") + "}\r\n" + "</script>\r\n");
            }
            return "";
        }

        public string getControl(string mystyle, string tablename, string pagesize, out int recordCount, out int pageCount, int pageindex)
        {
            if (((mystyle == null) || (mystyle == string.Empty)) || (mystyle == ""))
            {
                recordCount = 0;
                pageCount = 0;
                return null;
            }
            MatchCollection matchs = Regex.Matches(mystyle, @"\{#form_item_([^\}]+)\}", RegexOptions.Compiled);
            foreach (Match match in matchs)
            {
                mystyle = mystyle.Replace(match.Value, "");
            }
            MatchCollection matchs2 = Regex.Matches(mystyle, @"\{#form_ctr_([^\}]+)\}", RegexOptions.Compiled);
            foreach (Match match in matchs2)
            {
                mystyle = mystyle.Replace(match.Value, "");
            }
            MatchCollection formValues = Regex.Matches(mystyle, @"\{#form_value_([^\}]+)\}", RegexOptions.Compiled);
            mystyle = this.searchValues(tablename, Convert.ToInt32(pagesize), pageindex, out recordCount, out pageCount, mystyle, formValues);
            return mystyle;
        }

        public string getDateForm(string SaveIndexPage)
        {
            object obj2;
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            for (int i = 0x7d2; i <= DateTime.Now.Year; i++)
            {
                if (i == DateTime.Now.Year)
                {
                    obj2 = str2;
                    str2 = string.Concat(new object[] { obj2, "<option selected value=\"", i, "\">", i, "</option>\r" });
                }
                else
                {
                    obj2 = str2;
                    str2 = string.Concat(new object[] { obj2, "<option value=\"", i, "\">", i, "</option>\r" });
                }
            }
            for (int j = 1; j <= 12; j++)
            {
                if (j == DateTime.Now.Month)
                {
                    obj2 = str3;
                    str3 = string.Concat(new object[] { obj2, "<option selected value=\"", j, "\">", j, "</option>\r" });
                }
                else
                {
                    obj2 = str3;
                    str3 = string.Concat(new object[] { obj2, "<option value=\"", j, "\">", j, "</option>\r" });
                }
            }
            for (int k = 1; k <= 0x1f; k++)
            {
                if (k == DateTime.Now.Day)
                {
                    obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, "<option selected value=\"", k, "\">", k, "</option>\r" });
                }
                else
                {
                    obj2 = str4;
                    str4 = string.Concat(new object[] { obj2, "<option value=\"", k, "\">", k, "</option>\r" });
                }
            }
            return ((((((((((((((str + "<div id=\"index_historydiv\"><form method=\"POST\" id=\"index_history1\"><select name=\"h_year\" id=\"h_year1\">" + str2 + "</select>年&nbsp;") + "<select name=\"h_month\" id=\"h_month1\">" + str3 + "</select>月&nbsp;") + "<select name=\"h_day\" id=\"h_day1\">" + str4 + "</select>日&nbsp;") + "<input type=\"image\" name=\"imageFields\" src=\"" + CommonData.SiteDomain + "/sysimages/folder/buttonreview.gif\" onclick=\"s_getHistory();return false;\" /></form></div>\r\n") + "<script language=\"javascript\">\r\n") + "function s_getHistory()\r\n" + "{\r\n") + "   var syear = index_history1.h_year.options[index_history1.h_year.selectedIndex].value;;\r\n" + "   var smonth = index_history1.h_month.options[index_history1.h_month.selectedIndex].value;\r\n") + "   var sday = index_history1.h_day.options[index_history1.h_day.selectedIndex].value;\r\n" + "\r\n") + "   var sgetParam=\"" + SaveIndexPage + "\";\r\n") + "   var content=sgetParam;\r\n") + "   content=content.replace(\"{@year04}\",syear);\r\n" + "   content=content.replace(\"{@year02}\",syear.substring(2,4));\r\n") + "   content=content.replace(\"{@month}\",smonth);\r\n" + "   content=content.replace(\"{@day}\",sday);\r\n") + "   window.open('" + CommonData.SiteDomain + "/history.aspx?year='+syear+'&month=' + smonth + '&day=' + sday +'','_blank');return false;\r\n") + "}\r\n" + "</script>");
        }

        public string getDateJs(string SaveIndexPage)
        {
            return ("<iframe src=\"" + CommonData.SiteDomain + "/configuration/historyjs.html?startDate=" + UIConfig.dirPigeDate + "&param=history/" + SaveIndexPage + "\" width=\"143px\" height=\"165px\" frameborder=\"0\" scrolling=\"no\"></iframe>");
        }

        protected string GetGroupCount(string NewsID)
        {
            return "";
        }

        public string GetIndexPath(string ReadType, int ChID, string str_DynChar)
        {
            string str = string.Empty;
            IDataReader reader = CommonData.DalPublish.GetPositionNavi(0, "ChIndex", ChID);
            if (reader.Read())
            {
                if (ReadType == "1")
                {
                    str = string.Concat(new object[] { "<a href=\"", CommonData.SiteDomain, "/\">首页</a>", str_DynChar, "<a href=\"", CommonData.SiteDomain, "/default.aspx?ChID=", ChID, "\">", reader["channelName"].ToString(), "</a>" });
                }
                else
                {
                    string str2 = ("/" + reader["htmldir"].ToString() + "/" + reader["indexFileName"].ToString()).Replace("//", "/").Replace("{@dirHTML}", UIConfig.dirHtml);
                    str = "<a href=\"" + CommonData.SiteDomain + "/\">首页</a>" + str_DynChar + "<a href=\"" + CommonData.SiteDomain + str2 + "\">" + reader["channelName"].ToString() + "</a>";
                }
            }
            reader.Close();
            return str;
        }

        protected string GetLastComm(string NewsID, int NewsTF, int ChID)
        {
            string str = "";
            string str2 = Rand.Number(5);
            if (NewsTF == 1)
            {
                str = (((((((str + "<a name=\"commList\"></a><div id=\"Div_CommentList\" class=\"Comment\">正在加载评论列表...</div>\r\n" + "<script language=\"javascript\" type=\"text/javascript\">\r\n") + "function GetCommentList(page)\r\n" + "{\r\n") + "   $.get('/comment.aspx?no-cache=' + Math.random() + '&id=" + NewsID + "&ChID=0&CommentType=GetCommentList&page='+page, function(returnvalue){\r\n") + "  if (returnvalue.indexOf('??')>-1) {\r\n" + "                  document.getElementById(\"Div_CommentList\").innerHTML='加载评论列表失败'; \r\n") + "                  }\r\n" + "                  else {\r\n") + "                  document.getElementById(\"Div_CommentList\").innerHTML=returnvalue;  \r\n" + "                      } \r\n") + "                      });\r\n" + "}\r\n") + "GetCommentList(1);\r\n" + "</script>\r\n";
            }
            return str;
        }

        protected string GetMetaContent(string id, string Str, int num)
        {
            string str = "";
            Foosun.Model.News news = null;
            string str3 = Str;
            if (str3 == null)
            {
                return str;
            }
            if (!(str3 == "News"))
            {
                if (str3 != "Class")
                {
                    if (str3 != "Special")
                    {
                        return str;
                    }
                    return CommonData.GetSpecial(id).SpecialCName;
                }
            }
            else
            {
                news = CommonData.getNewsInfoById(id);
                if (num == 0)
                {
                    return news.Metakeywords;
                }
                return news.Metadesc;
            }
            PubClassInfo classById = CommonData.GetClassById(id);
            if (num == 0)
            {
                return classById.MetaKeywords;
            }
            return classById.MetaDescript;
        }

        protected string getNavi(string ShowNavi, string NaviCSS, string NaviPic, int i)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            if ((NaviCSS != null) && (NaviCSS != ""))
            {
                str2 = "<span class=\"" + NaviCSS + "\">";
                str3 = "</span>\r\n";
            }
            string str5 = ShowNavi;
            if (str5 != null)
            {
                if (!(str5 == "1"))
                {
                    if (str5 == "2")
                    {
                        if (i <= 0x1a)
                        {
                            char ch = (char) (i + 0x41);
                            str = str2 + ch.ToString() + str3;
                        }
                    }
                    else if (str5 == "3")
                    {
                        if (i <= 0x1a)
                        {
                            str = str2 + ((char) (i + 0x61)).ToString() + str3;
                        }
                    }
                    else if (str5 == "4")
                    {
                        str = "<img border=\"0\" src=\"" + this.RelpacePicPath(NaviPic) + "\" />";
                    }
                }
                else
                {
                    i++;
                    str = str2 + i.ToString() + str3;
                }
            }
            return (str + " ");
        }

        protected string GetNewsDomain(string NewsID)
        {
            string domain = null;
            Foosun.Model.News news = CommonData.getNewsInfoById(NewsID);
            if (news != null)
            {
                PubClassInfo classById = CommonData.GetClassById(news.ClassID);
                if (classById != null)
                {
                    domain = classById.Domain;
                }
                else
                {
                    domain = "";
                }
            }
            if ((domain != null) && (domain == ""))
            {
                return CommonData.SiteDomain;
            }
            if (domain.StartsWith("http://"))
            {
                return domain;
            }
            return ("http://" + domain);
        }

        protected string GetNewsFiles(string NewsID, int NewsTF)
        {
            string str = "";
            IDataReader newsFiles = CommonData.DalPublish.GetNewsFiles(NewsID);
            while (newsFiles.Read())
            {
                string str3 = str;
                str = str3 + "<a href=\"" + CommonData.SiteDomain + "/down-" + newsFiles["id"].ToString() + UIConfig.extensions + "\">" + newsFiles["URLName"].ToString() + "</a>";
            }
            newsFiles.Close();
            return str;
        }

        protected Foosun.Model.News getNewsInfo(int ID, string NewsID)
        {
            if ((ID == 0) && string.IsNullOrEmpty(NewsID))
            {
                return new Foosun.Model.News();
            }
            if (ID > 0)
            {
                return CommonData.getNewsInfoById(ID);
            }
            return CommonData.getNewsInfoById(NewsID);
        }

        protected string GetNewstitleStyle(DataRow dr, int StyleTf, string TitleNum)
        {
            int num = 0;
            if ((TitleNum != string.Empty) && (TitleNum != null))
            {
                num = int.Parse(TitleNum);
            }
            string subString = dr["NewsTitle"].ToString();
            if (num != 0)
            {
                subString = Input.GetSubString(subString, num);
            }
            if (StyleTf == 1)
            {
                string str2 = dr["TitleColor"].ToString();
                string str3 = dr["TitleITF"].ToString();
                string str4 = dr["TitleBTF"].ToString();
                if ((str2 != "") && (str2 != null))
                {
                    subString = "<span style=\"color:" + str2 + ";\">" + subString + "</span>";
                }
                if (str3.Equals("1"))
                {
                    subString = "<em>" + subString + "</em>";
                }
                if (str4.Equals("1"))
                {
                    subString = "<strong>" + subString + "</strong>";
                }
            }
            return subString;
        }

        protected string GetNewsURL(string isDelPoint, string NewsID, string SavePath, string SaveClassframe, string FileName, string FileEXName)
        {
            string str = "";
            if (Public.readparamConfig("ReviewType") == "1")
            {
                str = "/content-" + NewsID + UIConfig.extensions;
            }
            else if (isDelPoint != "0")
            {
                str = "/content-" + NewsID + UIConfig.extensions;
            }
            else
            {
                str = "/" + SaveClassframe + "/" + SavePath + "/" + FileName + FileEXName;
            }
            return (this.GetNewsDomain(NewsID) + str.Replace("//", "/").Replace("//", "/"));
        }

        protected string GetNewsURL(string isDelPoint, string NewsID, string SavePath, string SaveClassframe, string FileName, string FileEXName, string NewsType, string URLaddress)
        {
            if (NewsType == "2")
            {
                return URLaddress;
            }
            return this.GetNewsURL(isDelPoint, NewsID, SavePath, SaveClassframe, FileName, FileEXName);
        }

        protected string GetNewsURL1(DataRow r)
        {
            PubClassInfo classById = CommonData.GetClassById(r["ClassID"].ToString());
            return this.GetNewsURL(r["isDelPoint"].ToString(), r["NewsID"].ToString(), r["SavePath"].ToString(), classById.SavePath + "/" + classById.SaveClassframe, r["FileName"].ToString(), r["FileExName"].ToString());
        }

        protected string GetNewsURL1(string ClassID, string isDelPoint, string NewsID, string SavePath, string FileName, string FileExName)
        {
            PubClassInfo classById = CommonData.GetClassById(ClassID);
            return this.GetNewsURL(isDelPoint, NewsID, SavePath, classById.SavePath + "/" + classById.SaveClassframe, FileName, FileExName);
        }

        protected string GetNewsvURL(string NewsID, int NewsTF, string vURL, string heightstr, string widthstr)
        {
            string str = "";
            int startIndex = vURL.LastIndexOf(".");
            string str2 = "";
            int num2 = 0;
            if (startIndex > -1)
            {
                str2 = vURL.Substring(startIndex);
            }
            switch (str2.ToLower())
            {
                case ".flv":
                    num2 = 2;
                    break;

                case ".rm":
                    num2 = 1;
                    break;

                case ".rmvb":
                    num2 = 1;
                    break;

                case ".mp3":
                    num2 = 1;
                    break;

                case ".swf":
                    num2 = 3;
                    break;
            }
            vURL = this.RelpacePicPath(vURL);
            if (NewsTF == 0)
            {
                return ("<script>ck({f:'" + vURL + "'},'" + widthstr + "','" + heightstr + "');</script>");
            }
            switch (num2)
            {
                case 0:
                    return ((((("<object id=\"nstv\" classid=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" width=\"" + heightstr + "\" height=\"" + widthstr + "\" codebase=\"http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#\" Version=\"5,1,52,701standby=Loading Microsoft? Windows Media? Player components...\" type=\"application/x-oleobject\">\r\n") + "<param name=\"URL\" value=\"" + vURL + "\">\r\n") + "<PARAM NAME=\"UIMode\" value=\"full\">\r\n" + "<PARAM NAME=\"AutoStart\" value=\"true\">\r\n") + "<PARAM NAME=\"Enabled\" value=\"true\">\r\n" + "<PARAM NAME=\"enableContextMenu\" value=\"false\">\r\n") + "<param name=\"WindowlessVideo\" value=\"true\">\r\n" + "</object>\r\n");

                case 1:
                    return (((((((((((((((((("<object id=\"player\" name=\"player\" classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\" width=\"" + widthstr + "\" height=\"" + heightstr + "\">\r\n") + "<param name=_ExtentX value=18415>\r\n" + "<param name=_ExtentY value=9102>\r\n") + "<param name=AUTOSTART value=-1>\r\n" + "<param name=SHUFFLE value=0>\r\n") + "<param name=PREFETCH value=0>\r\n" + "<param name=NOLABELS value=-1>\r\n") + "<param name=SRC value=" + vURL + ">\r\n") + "<param name=CONTROLS value=Imagewindow>\r\n") + "<param name=CONSOLE value=clip1>\r\n" + "<param name=LOOP value=0>\r\n") + "<param name=NUMLOOP value=0>\r\n" + "<param name=CENTER value=0>\r\n") + "<param name=MAINTAINASPECT value=0>\r\n" + "<param name=BACKGROUNDCOLOR value=#000000>\r\n") + "</object><br>\r\n" + "<object ID=RP2 CLASSID=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA WIDTH=400 HEIGHT=50>\r\n") + "<param name=_ExtentX value=18415>\r\n" + "<param name=_ExtentY value=1005>\r\n") + "<param name=AUTOSTART value=-1>\r\n" + "<param name=SHUFFLE value=0>\r\n") + "<param name=PREFETCH value=0>\r\n" + "<param name=NOLABELS value=-1>\r\n") + "<param name=SRC value=" + vURL + ">\r\n") + "<PARAM NAME=CONTROLS VALUE=ControlPanel,StatusBar>\r\n" + "<param name=CONSOLE value=clip1>\r\n") + "<param name=LOOP value=0>\r\n" + "<param name=NUMLOOP value=0>\r\n") + "<param name=CENTER value=0>\r\n" + "<param name=MAINTAINASPECT value=0>\r\n") + "<param name=BACKGROUNDCOLOR value=#000000>\r\n" + "</object>\r\n");

                case 2:
                    return ("<script>ck({f:'" + vURL + "'},'" + widthstr + "','" + heightstr + "');</script>");

                case 3:
                    str = "<embed src=\"" + vURL + "?bgcolor=000000\" quality=\"high\" pluginspage=\"http://www.adobe.com/support/documentation/zh-CN/flashplayer/help/settings_manager04a.html\" type=\"application/x-shockwave-flash\" width=\"" + widthstr + "\" height=\"" + heightstr + "\" id=\"cfplay\"></embed>";
                    break;
            }
            return str;
        }

        protected string GetPageTitle(string id, string Str, int ChID)
        {
            Foosun.Model.News news = null;
            string classCName = string.Empty;
            if (((Str != "News") && (Str != "Class")) && !(Str == "Special"))
            {
                return CommonData.DalPublish.GetCHPageTitle(int.Parse(id), Str, ChID);
            }
            string str3 = Str;
            if (str3 != null)
            {
                if (!(str3 == "News"))
                {
                    if (str3 == "Class")
                    {
                        PubClassInfo classById = CommonData.GetClassById(id);
                        if (classById != null)
                        {
                            classCName = classById.ClassCName;
                        }
                        return classCName;
                    }
                    if (str3 == "Special")
                    {
                        PubSpecialInfo special = CommonData.GetSpecial(id);
                        if (special != null)
                        {
                            classCName = special.SpecialCName;
                        }
                        return classCName;
                    }
                }
                else
                {
                    news = CommonData.getNewsInfoById(id);
                    if (news != null)
                    {
                        classCName = news.NewsTitle;
                    }
                }
            }
            return classCName;
        }

        protected string GetPageTitleStyle(string NewsID, string FileName, string FileEXName, string Content, int PageNum, int isPop, int ChID)
        {
            string[] strArray2;
            int num7;
            object obj2;
            string str = "";
            string[] strArray = null;
            string str2 = Public.readparamConfig("ReviewType");
            string str3 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            if (ChID != 0)
            {
                str5 = "-" + ChID.ToString();
            }
            if (Content.IndexOf("###") <= -1)
            {
                return Content;
            }
            switch (PageNum)
            {
                case 0:
                    strArray = Content.Split(new string[] { "###" }, StringSplitOptions.None);
                    str = str + "<form name=\"getPageform1\" id=\"getPageform1\"><select name=\"PageSelectOption\"  id=\"PageSelectOption\"  onChange=\"javascript:window.location=this.options[this.selectedIndex].value;\">\r\n";
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].Trim() == string.Empty)
                        {
                            break;
                        }
                        if ((str2 == "1") || (isPop != 0))
                        {
                            if (i < 1)
                            {
                                str4 = "content-" + NewsID + str5 + "-1" + UIConfig.extensions;
                            }
                            else
                            {
                                strArray2 = new string[6];
                                strArray2[0] = "content-";
                                strArray2[1] = NewsID;
                                strArray2[2] = str5;
                                strArray2[3] = "-";
                                num7 = i + 1;
                                strArray2[4] = num7.ToString();
                                strArray2[5] = UIConfig.extensions;
                                str4 = string.Concat(strArray2);
                            }
                            str3 = str4;
                        }
                        else
                        {
                            if (i < 1)
                            {
                                str4 = "";
                            }
                            else
                            {
                                num7 = i + 1;
                                str4 = "_" + num7.ToString();
                            }
                            str3 = FileName + str4 + FileEXName;
                        }
                        obj2 = str;
                        str = string.Concat(new object[] { obj2, "<option value=\"", str3, "\">第", i + 1, "页:", strArray[i], "</option>\r\n" });
                    }
                    break;

                case 1:
                    strArray = Content.Split(new string[] { "###" }, StringSplitOptions.None);
                    str = str + "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r<tr>\r";
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j].Trim() == string.Empty)
                        {
                            break;
                        }
                        if ((str2 == "1") || (isPop != 0))
                        {
                            if (j < 1)
                            {
                                str4 = "content-" + NewsID + str5 + "-1" + UIConfig.extensions;
                            }
                            else
                            {
                                strArray2 = new string[6];
                                strArray2[0] = "content-";
                                strArray2[1] = NewsID;
                                strArray2[2] = str5;
                                strArray2[3] = "-";
                                num7 = j + 1;
                                strArray2[4] = num7.ToString();
                                strArray2[5] = UIConfig.extensions;
                                str4 = string.Concat(strArray2);
                            }
                            str3 = str4;
                        }
                        else
                        {
                            if (j < 1)
                            {
                                str4 = "";
                            }
                            else
                            {
                                num7 = j + 1;
                                str4 = "_" + num7.ToString();
                            }
                            str3 = FileName + str4 + FileEXName;
                        }
                        obj2 = str;
                        str = string.Concat(new object[] { obj2, "<td style=\"padding-right:30px;\"><a href=\"", str3, "\">第", j + 1, "页:", strArray[j], "</a></td>\r\r\n" });
                        if (((j + 1) % 2) == 0)
                        {
                            str = str + "</tr><tr>";
                        }
                    }
                    return (str + "</tr>\r</table>\r");

                case 2:
                    strArray = Content.Split(new string[] { "###" }, StringSplitOptions.None);
                    for (int k = 0; k < strArray.Length; k++)
                    {
                        if (strArray[k].Trim() == string.Empty)
                        {
                            return str;
                        }
                        if ((str2 == "1") || (isPop != 0))
                        {
                            if (k < 1)
                            {
                                str4 = "content-" + NewsID + str5 + "-1" + UIConfig.extensions;
                            }
                            else
                            {
                                strArray2 = new string[6];
                                strArray2[0] = "content-";
                                strArray2[1] = NewsID;
                                strArray2[2] = str5;
                                strArray2[3] = "-";
                                num7 = k + 1;
                                strArray2[4] = num7.ToString();
                                strArray2[5] = UIConfig.extensions;
                                str4 = string.Concat(strArray2);
                            }
                            str3 = str4;
                        }
                        else
                        {
                            if (k < 1)
                            {
                                str4 = "";
                            }
                            else
                            {
                                num7 = k + 1;
                                str4 = "_" + num7.ToString();
                            }
                            str3 = FileName + str4 + FileEXName;
                        }
                        obj2 = str;
                        str = string.Concat(new object[] { obj2, "<div><a href=\"", str3, "\">第", k + 1, "页:", strArray[k], "</a></div>\r\n" });
                    }
                    return str;

                default:
                    strArray = Content.Split(new string[] { "###" }, StringSplitOptions.None);
                    for (int m = 0; m < strArray.Length; m++)
                    {
                        if (strArray[m].Trim() == string.Empty)
                        {
                            return str;
                        }
                        if ((str2 == "1") || (isPop != 0))
                        {
                            if (m < 1)
                            {
                                str4 = "content-" + NewsID + str5 + "-1" + UIConfig.extensions;
                            }
                            else
                            {
                                strArray2 = new string[6];
                                strArray2[0] = "content-";
                                strArray2[1] = NewsID;
                                strArray2[2] = str5;
                                strArray2[3] = "-";
                                num7 = m + 1;
                                strArray2[4] = num7.ToString();
                                strArray2[5] = UIConfig.extensions;
                                str4 = string.Concat(strArray2);
                            }
                            str3 = str4;
                        }
                        else
                        {
                            if (m < 1)
                            {
                                str4 = "";
                            }
                            else
                            {
                                str4 = "_" + ((m + 1)).ToString();
                            }
                            str3 = FileName + str4 + FileEXName;
                        }
                        obj2 = str;
                        str = string.Concat(new object[] { obj2, "<a href=\"", str3, "\">第", m + 1, "页:", strArray[m], "</a>&nbsp;&nbsp;\r\n" });
                    }
                    return str;
            }
            str = str + "</select></form>\r\n" + "<script  language=\"javascript\" type=\"text/javascript\">\r\n";
            int num2 = 0;
            if ((str2 == "1") || (isPop != 0))
            {
                num2 = 1;
            }
            obj2 = str;
            return (string.Concat(new object[] { obj2, "window.getPageInfoURLFileName('", num2, "')\r\n" }) + "</script>\r\n");
        }

        private string GetParamValue(string ParamName)
        {
            string lPValue = string.Empty;
            if (this._LblParams == null)
            {
                return null;
            }
            int length = this._LblParams.Length;
            for (int i = 0; i < length; i++)
            {
                LabelParameter parameter = this._LblParams[i];
                if (parameter.LPName.Equals(ParamName))
                {
                    lPValue = parameter.LPValue;
                    break;
                }
            }
            return (lPValue.Equals(string.Empty) ? null : lPValue);
        }

        public string GetPositionSTR(string DynStr, string ClassID, int Num)
        {
            DataTable position;
            if (dimmDir.Trim() != string.Empty)
            {
                dimmDir = "/" + dimmDir;
            }
            string str = string.Empty;
            if (Num == 0)
            {
                position = CommonData.DalPublish.GetPosition(ClassID, 0);
                if ((position != null) && (position.Rows.Count > 0))
                {
                    str = "<a href=\"" + this.GetClassURL(position.Rows[0]["Domain"].ToString(), int.Parse(position.Rows[0]["isDelPoint"].ToString()), ClassID, position.Rows[0]["savePath"].ToString(), position.Rows[0]["saveClassFrame"].ToString(), position.Rows[0]["ClassSaveRule"].ToString(), Convert.ToInt16(position.Rows[0]["IsURL"].ToString()), position.Rows[0]["URLaddress"].ToString(), 0) + "\">" + position.Rows[0]["ClassCName"].ToString() + "</a>" + DynStr;
                    if (position.Rows[0]["ParentID"].ToString() != "0")
                    {
                        str = this.GetPositionSTR(DynStr, position.Rows[0]["ParentID"].ToString(), 0) + str;
                    }
                    position.Clear();
                    position.Dispose();
                }
                return str;
            }
            position = CommonData.DalPublish.GetPosition(ClassID, 1);
            if ((position != null) && (position.Rows.Count > 0))
            {
                str = "<a href=\"" + this.GetSpeacilURL(position.Rows[0]["isDelPoint"].ToString(), position.Rows[0]["SpecialID"].ToString(), position.Rows[0]["savePath"].ToString(), position.Rows[0]["saveDirPath"].ToString(), position.Rows[0]["FileName"].ToString(), position.Rows[0]["FileEXName"].ToString()) + "\">" + position.Rows[0]["SpecialCName"].ToString() + "</a>" + DynStr;
                if (position.Rows[0]["ParentID"].ToString() != "0")
                {
                    str = this.GetPositionSTR(DynStr, position.Rows[0]["ParentID"].ToString(), 1) + str;
                }
                position.Clear();
                position.Dispose();
            }
            return str;
        }

        protected string GetPrePage(string id, string DataLib, string ClassID, int Num, int ChID, int isTitle)
        {
            string str = "";
            if (ChID == 0)
            {
                IDataReader reader = CommonData.DalPublish.GetPrePage(int.Parse(id), DataLib, Num, ClassID, ChID);
                if (reader.Read())
                {
                    if (isTitle == 0)
                    {
                        str = this.GetNewsURL(reader["isDelPoint"].ToString(), reader["NewsID"].ToString(), reader["savePath"].ToString(), reader["savePath1"].ToString() + "/" + reader["saveClassFrame"].ToString(), reader["FileName"].ToString(), reader["FileEXName"].ToString(), reader["NewsType"].ToString(), reader["URLaddress"].ToString());
                    }
                    else
                    {
                        str = reader["NewsTitle"].ToString();
                    }
                }
                else if (isTitle == 0)
                {
                    str = "javascript:;";
                }
                else
                {
                    str = "没有了";
                }
                reader.Close();
                return str;
            }
            IDataReader reader2 = CommonData.DalPublish.GetPrePage(int.Parse(id), DataLib, Num, ClassID, ChID);
            if (reader2.Read())
            {
                if (isTitle == 0)
                {
                    str = this.getCHInfoURL(ChID, int.Parse(reader2["isDelPoint"].ToString()), int.Parse(reader2["id"].ToString()), reader2["savePath1"].ToString(), reader2["savePath"].ToString(), reader2["FileName"].ToString());
                }
                else
                {
                    str = reader2["Title"].ToString();
                }
            }
            else if (isTitle == 0)
            {
                str = "javascript:;";
            }
            else
            {
                str = "没有了";
            }
            reader2.Close();
            return str;
        }

        protected string GetSendInfo(string NewsID, int ChID)
        {
            return string.Concat(new object[] { CommonData.SiteDomain, "/SendMail.aspx?ChID=", ChID, "&id=", NewsID });
        }

        protected string GetSiteName()
        {
            string str = "";
            IDataReader sysParam = CommonData.DalPublish.GetSysParam();
            if (sysParam.Read() && (sysParam["SiteName"] != DBNull.Value))
            {
                str = sysParam["SiteName"].ToString();
            }
            sysParam.Close();
            return str;
        }

        protected string GetSpeacilURL(string isDelPoint, string SpecialID, string SavePath, string SaveDirPath, string FileName, string FileEXName)
        {
            string str = "";
            if ((Public.readparamConfig("ReviewType") == "1") || (isDelPoint != "0"))
            {
                str = "/special-" + SpecialID + UIConfig.extensions;
            }
            else
            {
                str = "/" + SavePath + "/" + SaveDirPath + "/" + FileName + FileEXName;
            }
            return (CommonData.SiteDomain + str.Replace("//", "/").Replace("//", "/"));
        }

        protected string GetStyle(string Title, string sColor, int Istr, int Bstr)
        {
            string str = Title;
            if (sColor.Trim() != string.Empty)
            {
                str = "<span style=\"color:#" + sColor + ";\">" + str + "</span>";
            }
            if (Istr == 1)
            {
                str = "<em>" + str + "</em>";
            }
            if (Bstr == 1)
            {
                str = "<strong>" + str + "</strong>";
            }
            return str;
        }

        protected string getSubNewsList(string mystyle, string StyleID, int n_Cols, string str_Desc, string str_DescType, string str_isDiv, string str_ulID, string str_ulClass, string str_isPic, string str_TitleNumer, string str_ContentNumber, string str_NaviNumber, string str_ClickNumber, string str_ShowDateNumer, string str_ShowNavi, string str_NaviCSS, string str_ColbgCSS, string str_NaviPic, string str_SubNews, string str_ClassStyleID, string str_ColumnNumber, string str_ColumnCss, string str_ColumnNewsCss, string str_tabCSS)
        {
            int num;
            string str = " [ID] ";
            string str2 = DBConfig.TableNamePrefix + "News Where [isRecyle]=0 And [isLock]=0 And [SiteID]='" + this.Param_SiteID + "'";
            if (str_isPic == "true")
            {
                str2 = str2 + " And [NewsType]=1";
            }
            else if (str_isPic == "false")
            {
                str2 = str2 + " And ([NewsType]=0 Or [NewsType]=2)";
            }
            if ((str_ClickNumber != null) && (str_ClickNumber != ""))
            {
                str2 = str2 + " And [Click] > " + int.Parse(str_ClickNumber);
            }
            if ((str_ShowDateNumer != null) && (str_ShowDateNumer != ""))
            {
                if (UIConfig.WebDAL.ToLower() == "foosun.accessdal")
                {
                    str2 = str2 + " And DateDiff('d',[CreatTime] ,now()) < " + int.Parse(str_ShowDateNumer);
                }
                else
                {
                    str2 = str2 + " And DateDiff(Day,[CreatTime] ,Getdate()) < " + int.Parse(str_ShowDateNumer);
                }
            }
            string str3 = string.Empty;
            if ((str_Desc != null) && (str_Desc.ToLower() == "asc"))
            {
                str3 = str3 + " asc";
            }
            else
            {
                str3 = str3 + " Desc";
            }
            string str15 = str_DescType;
            if (str15 != null)
            {
                if (!(str15 == "id"))
                {
                    if (str15 == "date")
                    {
                        str3 = " Order By [CreatTime] " + str3 + ",id " + str3;
                        goto Label_0211;
                    }
                    if (str15 == "click")
                    {
                        str3 = " Order By [Click] " + str3 + ",id " + str3;
                        goto Label_0211;
                    }
                    if (str15 == "pop")
                    {
                        str3 = " Order By [OrderID]" + str3 + ",id " + str3;
                        goto Label_0211;
                    }
                    if (str15 == "digg")
                    {
                        str3 = " Order By [TopNum]" + str3 + ",id " + str3;
                        goto Label_0211;
                    }
                }
                else
                {
                    str3 = " Order By id " + str3;
                    goto Label_0211;
                }
            }
            str3 = " Order By [CreatTime] " + str3 + ",id " + str3;
        Label_0211:
            num = 30;
            int contentNumber = 200;
            int naviNumber = 200;
            if ((str_TitleNumer != null) && Input.IsInteger(str_TitleNumer))
            {
                num = int.Parse(str_TitleNumer);
            }
            if ((str_ContentNumber != null) && Input.IsInteger(str_ContentNumber))
            {
                contentNumber = int.Parse(str_ContentNumber);
            }
            if ((str_NaviNumber != null) && Input.IsInteger(str_NaviNumber))
            {
                naviNumber = int.Parse(str_NaviNumber);
            }
            string paramValue = string.Empty;
            string newValue = "";
            bool flag = false;
            if ((str_SubNews != null) && (str_SubNews == "true"))
            {
                flag = true;
                if (this.GetParamValue("FS:SubNaviCSS") != null)
                {
                    paramValue = this.GetParamValue("FS:SubNaviCSS");
                }
            }
            string[] strArray = null;
            bool flag2 = false;
            if (str_ColbgCSS != null)
            {
                strArray = str_ColbgCSS.Split(new char[] { '|' });
                flag2 = true;
            }
            string str6 = "";
            string sql = "";
            if ((str_ColumnNumber == "") || (str_ColumnNumber == null))
            {
                sql = " Select [IsURL],[URLaddress],[ClassID],[ClassCName],[SavePath],[SaveClassframe],[ClassSaveRule],[ClassSaveRule],[isDelPoint] ,[Domain] From [" + DBConfig.TableNamePrefix + "news_Class] Where [ParentID]='" + this.Param_CurrentClassID + "' And [isRecyle]=0 And [isLock]=0 And [IsURL]=0";
            }
            else
            {
                sql = " Select Top " + str_ColumnNumber + " [IsURL],[URLaddress],[ClassID],[ClassCName],[SavePath],[SaveClassframe],[ClassSaveRule],[ClassSaveRule],[isDelPoint] ,[Domain] From [" + DBConfig.TableNamePrefix + "news_Class] Where [ParentID]='" + this.Param_CurrentClassID + "' And [isRecyle]=0 And [isLock]=0 And [IsURL]=0";
            }
            DataTable table = CommonData.DalPublish.ExecuteSql(sql);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            string styleByID = LabelStyle.GetStyleByID(str_ClassStyleID);
            string str9 = "";
            if (str_isDiv == "true")
            {
                if (this.GetParamValue("FS:ColumnCss") != null)
                {
                    str9 = " class=\"" + this.GetParamValue("FS:ColumnCss") + "\"";
                }
                else
                {
                    str9 = " class=\"" + str_tabCSS + "\"";
                }
            }
            else if (this.GetParamValue("FS:ColumnCss") != null)
            {
                str9 = " class=\"" + this.GetParamValue("FS:ColumnCss") + "\"";
            }
            else
            {
                str9 = " class=\"" + str_tabCSS + "\"";
            }
            string columnNewsCssValue = "";
            if (this.GetParamValue("FS:ColumnNewsCss") != null)
            {
                columnNewsCssValue = " class=\"" + this.GetParamValue("FS:ColumnNewsCss") + "\"";
            }
            if (str_isDiv == "false")
            {
                builder.AppendLine("<table" + str9 + " border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">\r\n");
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str11 = this.PlaceClassStyle(styleByID, table.Rows[i]);
                if (str_isDiv == "true")
                {
                    builder.AppendLine("<div" + str9 + ">");
                    builder.AppendLine(str11);
                }
                else
                {
                    builder.AppendLine("<tr>");
                    builder.AppendLine("<td>");
                    builder.AppendLine(str11);
                    builder.AppendLine("</td>");
                    builder.AppendLine("</tr>");
                    builder.AppendLine("<tr>");
                    builder.AppendLine("<td>");
                }
                string str12 = string.Concat(new object[] { "select top ", this.Param_Loop, " ", str, " from ", str2, " And [ClassID]='", table.Rows[i]["ClassID"].ToString(), "'", str3 });
                DataTable table2 = CommonData.DalPublish.ExecuteSql(str12);
                if (table2 != null)
                {
                    builder.Append(this.News_List_Head(str_isDiv, str_ulID, str_ulClass, columnNewsCssValue));
                    int count = table2.Rows.Count;
                    if ((str_isDiv == "true") && ((str_ColumnNewsCss != null) && (str_ColumnNewsCss != "")))
                    {
                        builder.Append("<div" + columnNewsCssValue + ">\r\n<ul>");
                    }
                    if (table2.Rows.Count == 0)
                    {
                        builder.Append("<li class=\"listnone\">本栏目暂无数据！</li>");
                    }
                    else
                    {
                        int num6 = 0;
                        for (int j = 0; j < table2.Rows.Count; j++)
                        {
                            Foosun.Model.News news;
                            int num8 = j + 1;
                            string str13 = string.Empty;
                            if (num8 <= 3)
                            {
                                str13 = "<span class=\"Num No" + num8.ToString() + "\">" + num8.ToString() + "</span>\r\n";
                            }
                            else
                            {
                                str13 = "<span class=\"Num\">" + num8.ToString() + "</span>\r\n";
                            }
                            str_ColbgCSS = "";
                            if (flag2)
                            {
                                if ((num6 % 2) == 0)
                                {
                                    str_ColbgCSS = " class=\"" + strArray[0].ToString() + "\"";
                                    newValue = strArray[0];
                                }
                                else
                                {
                                    str_ColbgCSS = " class=\"" + strArray[1].ToString() + "\"";
                                    newValue = strArray[1];
                                }
                            }
                            if (str_isDiv == "true")
                            {
                                builder.Append(this.getNavi(str_ShowNavi, str_NaviCSS, str_NaviPic, j));
                                builder.AppendLine(this.Analyse_ReadNews((int) table2.Rows[j][0], num, contentNumber, naviNumber, mystyle, StyleID, 1, 1, 0)).Replace("{#Index}", str13).Replace("{#ParityName}", newValue);
                                if (flag)
                                {
                                    news = new Foosun.Model.News();
                                    news = this.getNewsInfo((int) table2.Rows[j][0], null);
                                    builder.Append(this.GetSubSTR(news.NewsID, paramValue));
                                }
                                num6++;
                            }
                            else
                            {
                                str_isDiv = "false";
                                str6 = this.getNavi(str_ShowNavi, str_NaviCSS, str_NaviPic, j) + " " + this.Analyse_ReadNews((int) table2.Rows[j][0], num, contentNumber, naviNumber, mystyle, StyleID, 1, 1, 0).Replace("{#Index}", str13);
                                if (flag)
                                {
                                    news = new Foosun.Model.News();
                                    news = this.getNewsInfo((int) table2.Rows[j][0], null);
                                    str6 = str6 + this.GetSubSTR(news.NewsID, paramValue);
                                }
                                if (n_Cols == 1)
                                {
                                    builder.AppendLine("<tr" + str_ColbgCSS + ">");
                                    builder.AppendLine("<td>");
                                    builder.AppendLine(str6);
                                    builder.AppendLine("</td>");
                                    builder.AppendLine("</tr>");
                                }
                                else
                                {
                                    if (num6 == 0)
                                    {
                                        builder.AppendLine("<tr" + str_ColbgCSS + ">");
                                        num6++;
                                    }
                                    builder.AppendLine("<td width=\"" + (100 / n_Cols) + "%\">");
                                    builder.AppendLine(str6);
                                    builder.AppendLine("</td>");
                                    if ((j > 0) && ((((j + 1) % n_Cols) == 0) && ((j + 1) != table2.Rows.Count)))
                                    {
                                        builder.AppendLine("</tr>");
                                        builder.AppendLine("<tr" + str_ColbgCSS + ">");
                                        num6++;
                                    }
                                }
                            }
                        }
                    }
                    if (!(!(str_isDiv == "true") || string.IsNullOrEmpty(str_ColumnNewsCss)))
                    {
                        builder.Append("</ul>\r\n</div>");
                    }
                    table2.Clear();
                    table2.Dispose();
                    if (((str_isDiv != "true") && (count > 0)) && (n_Cols > 1))
                    {
                        if ((count % n_Cols) != 0)
                        {
                            int num9 = n_Cols - count;
                            if (num9 < 0)
                            {
                                num9 = n_Cols - (count % n_Cols);
                            }
                            for (int k = 0; k < num9; k++)
                            {
                                builder.AppendLine("<td width=\"" + (100 / n_Cols) + "%\">");
                                builder.AppendLine("</td>");
                            }
                        }
                        builder.AppendLine("</tr>");
                    }
                    builder.Append(this.News_List_End(str_isDiv));
                }
                if (str_isDiv == "false")
                {
                    builder.AppendLine("</td>");
                    builder.AppendLine("</tr>");
                }
                else
                {
                    builder.AppendLine("</div>");
                }
            }
            table.Clear();
            table.Dispose();
            if (str_isDiv == "false")
            {
                builder.AppendLine("</table>");
            }
            return builder.ToString();
        }

        public string GetSubSTR(string NewsID, string str_SubNaviCSS)
        {
            string str = string.Empty;
            int num = 0;
            int num2 = 1;
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (str_SubNaviCSS != string.Empty)
            {
                str3 = Input.ToshowTxt(Input.isPicStr(str_SubNaviCSS));
            }
            DataTable subUnRule = CommonData.DalPublish.GetSubUnRule(NewsID);
            if ((subUnRule == null) || (subUnRule.Rows.Count <= 0))
            {
                return str;
            }
            str = str + "<div>";
            for (int i = 0; i < subUnRule.Rows.Count; i++)
            {
                str2 = subUnRule.Rows[i]["TitleCSS"].ToString();
                if ((str2 != null) && (str2 != string.Empty))
                {
                    str2 = " class=\"" + str2 + "\"";
                }
                else
                {
                    str2 = string.Empty;
                }
                num = int.Parse(subUnRule.Rows[i]["colsNum"].ToString());
                IDataReader newsSavePath = CommonData.DalPublish.GetNewsSavePath(subUnRule.Rows[i]["getNewsID"].ToString());
                string str4 = string.Empty;
                if (newsSavePath.Read())
                {
                    string str6;
                    PubClassInfo classById = CommonData.GetClassById(newsSavePath["ClassID"].ToString());
                    if ((classById != null) && (newsSavePath["SavePath"] != DBNull.Value))
                    {
                        str4 = this.GetNewsURL(newsSavePath["isDelPoint"].ToString(), newsSavePath["NewsID"].ToString(), newsSavePath["SavePath"].ToString(), classById.SavePath + "/" + classById.SaveClassframe, newsSavePath["FileName"].ToString(), newsSavePath["FileEXName"].ToString(), newsSavePath["NewsType"].ToString(), newsSavePath["URLaddress"].ToString());
                    }
                    else
                    {
                        str4 = "javascript:void(0);";
                    }
                    if (num == num2)
                    {
                        if (i == 0)
                        {
                            str6 = str;
                            str = str6 + str3 + "<a href=\"" + str4 + "\" target=\"_blank\" " + str2 + ">" + subUnRule.Rows[i]["NewsTitle"].ToString() + "</a>&nbsp;\r";
                        }
                        else
                        {
                            str6 = str;
                            str = str6 + "<a href=\"" + str4 + "\" target=\"_blank\" " + str2 + ">" + subUnRule.Rows[i]["NewsTitle"].ToString() + "</a>&nbsp;\r";
                        }
                    }
                    else
                    {
                        num2++;
                        str6 = str;
                        str = str6 + "<br />" + str3 + "<a href=\"" + str4 + "\" target=\"_blank\" " + str2 + ">" + subUnRule.Rows[i]["NewsTitle"].ToString() + "</a>&nbsp;\r";
                    }
                }
                newsSavePath.Close();
            }
            subUnRule.Clear();
            subUnRule.Dispose();
            return (str + "</div>\r");
        }

        protected string GetTopNum(string NewsID, int NewsTF, string TopNum, string filename)
        {
            string str3;
            string str = "";
            if (NewsTF == 1)
            {
                str3 = (str + "<span id=\"n_" + NewsID + "\"></span>") + "<script language=\"javascript\" type=\"text/javascript\">";
                return ((str3 + "pubajax('" + CommonData.SiteDomain + "/digg.aspx','newsid=" + NewsID + "&spanid=n_" + NewsID + "&getNum=0','n_" + NewsID + "');") + "</script>");
            }
            str3 = str;
            str3 = (str3 + "<span id=\"l_" + NewsID + filename + "\"></span>") + "<script language=\"javascript\" type=\"text/javascript\">";
            return ((str3 + "pubajax('" + CommonData.SiteDomain + "/digg.aspx','newsid=" + NewsID + "&spanid=l_" + NewsID + filename + "&getNum=0','l_" + NewsID + filename + "');") + "</script>");
        }

        protected string GetTopURL(string NewsID, int NewsTF, string filename)
        {
            if (NewsTF == 1)
            {
                return ("javascript:getTopNum('" + CommonData.SiteDomain + "/digg.aspx','" + NewsID + "',1,'n_" + NewsID + "');");
            }
            return ("javascript:getTopNum('" + CommonData.SiteDomain + "/digg.aspx','" + NewsID + "',1,'l_" + NewsID + filename + "');");
        }

        protected string Getundigs(string NewsID, int NewsTF, string undigs, string filename)
        {
            string str3;
            string str = "";
            if (NewsTF == 1)
            {
                str3 = (str + "<span id=\"nu_" + NewsID + "\"></span>") + "<script language=\"javascript\" type=\"text/javascript\">";
                return ((str3 + "pubajax('" + CommonData.SiteDomain + "/digg.aspx','newsid=" + NewsID + "&spanid=nu_" + NewsID + "&getundig=0','nu_" + NewsID + "');") + "</script>");
            }
            str3 = str;
            str3 = (str3 + "<span id=\"lu_" + NewsID + filename + "\"></span>") + "<script language=\"javascript\" type=\"text/javascript\">";
            return ((str3 + "pubajax('" + CommonData.SiteDomain + "/digg.aspx','newsid=" + NewsID + "&spanid=lu_" + NewsID + filename + "&getundig=0','lu_" + NewsID + filename + "');") + "</script>");
        }

        protected string Getundigurl(string NewsID, int NewsTF, string filename)
        {
            if (NewsTF == 1)
            {
                return ("javascript:getundig('" + CommonData.SiteDomain + "/digg.aspx','" + NewsID + "',1,'nu_" + NewsID + "');");
            }
            return ("javascript:getundig('" + CommonData.SiteDomain + "/digg.aspx','" + NewsID + "',1,'lu_" + NewsID + filename + "');");
        }

        public string GetVoteItem(string NewsID, int NewsTF)
        {
            string str = "";
            if (NewsTF == 1)
            {
                string str2 = Rand.Number(5);
                string str4 = str;
                str4 = (str4 + "<div id=\"vote" + NewsID + str2 + "\">投票加载中...</div>\r\n") + "<script language=\"javascript\" type=\"text/javascript\">";
                return ((str4 + "pubajax('" + CommonData.SiteDomain + "/vote.aspx','NewsID=" + NewsID + "','vote" + NewsID + str2 + "');") + "</script>");
            }
            return "";
        }

        private bool hasvalidate(int formid)
        {
            Foosun.CMS.Label label = new Foosun.CMS.Label();
            return label.hasValidate(formid);
        }

        private string makeControl(string type, string size, string name, string selectitem, string defaultvalue)
        {
            int num;
            string str4;
            char[] separator = "\r\n".ToCharArray();
            string str = string.Empty;
            switch (type)
            {
                case "SingleLineText":
                    str4 = str;
                    return (str4 + "<input id=\"CF_" + name + "\" name=\"CF_" + name + "\" type=\"text\" maxlength=\"" + size + "\" value=\"" + defaultvalue + "\" />");

                case "MultiLineText":
                    if ((size != "0") && !(size == ""))
                    {
                        str4 = str;
                        return (str4 + "<textarea id=\"CF_" + name + "\" name=\"CF_" + name + "\" cols=\"" + size + "\">" + defaultvalue + "</textarea>");
                    }
                    str4 = str;
                    return (str4 + "<textarea id=\"CF_" + name + "\" name=\"CF_" + name + "\">" + defaultvalue + "</textarea>");

                case "MultiLineEdit":
                    str = str + "<script type=\"text/javascript\" src=\"/editor/fckeditor.js\"></script>";
                    if ((size != "0") && !(size == ""))
                    {
                        str4 = str;
                        str = str4 + "<textarea name=\"CF_" + name + "\" id=\"CF_" + name + "\"  cols=\"" + size + "\" rows=\"10\" style=\"display:none\">" + defaultvalue + "</textarea>";
                        break;
                    }
                    str4 = str;
                    str = str4 + "<textarea name=\"CF_" + name + "\" id=\"CF_" + name + "\"  style=\"display:none\">" + defaultvalue + "</textarea>";
                    break;

                case "PassWordText":
                    str4 = str;
                    return (str4 + "<input id=\"CF_" + name + "\" name=\"CF_" + name + "\" type=\"password\" maxlength=\"" + size + "\" />");

                case "DateTime":
                    str4 = str;
                    return (str4 + "<script language=\"javascript\" type=\"text/javascript\" src=\"/configuration/datecontrol/WdatePicker.js\"></script><input class=\"Wdate\" id=\"CF_" + name + "\" name=\"CF_" + name + "\" type=\"text\"  value=\"" + defaultvalue + "\" onClick=\"WdatePicker()\"/>");

                case "RadioBox":
                {
                    string[] strArray = selectitem.Split(separator);
                    for (num = 0; num < strArray.Length; num++)
                    {
                        if (strArray[num] != "")
                        {
                            if (strArray[num] == defaultvalue)
                            {
                                str4 = str;
                                str = str4 + "<input checked=\"checked\" type=\"radio\" name=\"CF_" + name + "\" value=\"" + strArray[num] + "\" />" + strArray[num] + "&nbsp;";
                            }
                            else
                            {
                                str4 = str;
                                str = str4 + "<input type=\"radio\" name=\"CF_" + name + "\" value=\"" + strArray[num] + "\" />" + strArray[num] + "&nbsp;";
                            }
                        }
                    }
                    return str;
                }
                case "CheckBox":
                {
                    string[] strArray2 = selectitem.Split(separator);
                    for (num = 0; num < strArray2.Length; num++)
                    {
                        if (strArray2[num] != "")
                        {
                            str4 = str;
                            str = str4 + "<input type=\"checkbox\" name=\"CF_" + name + "\" value=\"" + strArray2[num] + "\" />" + strArray2[num] + "&nbsp;";
                        }
                    }
                    return str;
                }
                case "Numberic":
                    str4 = str;
                    return (str4 + "<input id=\"CF_" + name + "\" name=\"CF_" + name + "\"  value=\"" + defaultvalue + "\" type=\"text\" maxlength=\"" + size + "\" />");

                case "UploadFile":
                    str4 = str;
                    return (str4 + "<input name=\"CF_" + name + "\"  value=\"" + defaultvalue + "\" type=\"file\" id=\"CF_" + name + "\" maxlength=\"" + size + "\" />");

                case "DropList":
                {
                    str4 = str;
                    str = str4 + "<select name=\"CF_" + name + "\" id=\"CF_" + name + "\">";
                    string[] strArray3 = selectitem.Split(separator);
                    for (num = 0; num < strArray3.Length; num++)
                    {
                        if (strArray3[num] != "")
                        {
                            if (strArray3[num] == defaultvalue)
                            {
                                str4 = str;
                                str = str4 + "<option value=\"" + strArray3[num] + "\" selected=\"selected\">" + strArray3[num] + "</option>";
                            }
                            else
                            {
                                str4 = str;
                                str = str4 + "<option value=\"" + strArray3[num] + "\">" + strArray3[num] + "</option>";
                            }
                        }
                    }
                    return (str + "</select>");
                }
                case "List":
                {
                    str4 = str;
                    str = str4 + "<select size=\"5\" name=\"CF_" + name + "\" id=\"CF_" + name + "\">";
                    string[] strArray4 = selectitem.Split(separator);
                    for (num = 0; num < strArray4.Length; num++)
                    {
                        if (strArray4[num] != "")
                        {
                            if (strArray4[num] == defaultvalue)
                            {
                                str4 = str;
                                str = str4 + "<option value=\"" + strArray4[num] + "\" selected=\"selected\">" + strArray4[num] + "</option>";
                            }
                            else
                            {
                                str4 = str;
                                str = str4 + "<option value=\"" + strArray4[num] + "\">" + strArray4[num] + "</option>";
                            }
                        }
                    }
                    return (str + "</select>");
                }
                default:
                    return str;
            }
            return ((str + "<script type=\"text/javascript\">(function () {") + "var sBasePath = \"/editor/\";var oFCKeditor = new FCKeditor('CF_" + name + "');oFCKeditor.BasePath = sBasePath;oFCKeditor.Width = '100%';oFCKeditor.Height = '300px';oFCKeditor.ReplaceTextarea();})();</script>");
        }

        public string NewParse()
        {
            if (!this.FormatValid)
            {
                return "";
            }
            switch (this.Param_LabelType)
            {
                case EnumLabelType.List:
                    return this.Analyse_List(null, null);

                case EnumLabelType.GroupMember:
                    return this.Analyse_GroupMember();

                case EnumLabelType.ConstrNews:
                    return this.Analyse_ConstrNews();

                case EnumLabelType.NewUser:
                    return this.Analyse_NewUser();

                case EnumLabelType.TopUser:
                    return this.Analyse_TopUser();

                case EnumLabelType.UserLogin:
                    return this.Analyse_UserLogin();

                case EnumLabelType.OtherJS:
                    return this.Analyse_OtherJS();

                case EnumLabelType.statJS:
                    return this.Analyse_statJS();

                case EnumLabelType.surveyJS:
                    return this.Analyse_surveyJS();

                case EnumLabelType.adJS:
                    return this.Analyse_adJS();

                case EnumLabelType.sysJS:
                    return this.Analyse_sysJS();

                case EnumLabelType.freeJS:
                    return this.Analyse_freeJS();

                case EnumLabelType.LastComm:
                    return this.Analyse_LastComm();

                case EnumLabelType.TopNews:
                    return this.Analyse_TopNews();

                case EnumLabelType.RSS:
                    return this.Analyse_RSS();

                case EnumLabelType.SpeicalNaviRead:
                    return this.Analyse_SpeicalNaviRead();

                case EnumLabelType.SpecialNavi:
                    return this.Analyse_SpecialNavi();

                case EnumLabelType.ClassNaviRead:
                    return this.Analyse_ClassNaviRead();

                case EnumLabelType.SiteNavi:
                    return this.Analyse_SiteNavi();

                case EnumLabelType.Frindlink:
                    return this.Analyse_FrindList();

                case EnumLabelType.ClassInfoList:
                    return this.Analyse_ClassInfoList();

                case EnumLabelType.History:
                    return this.Analyse_History();

                case EnumLabelType.CorrNews:
                    return this.Analyse_CorrNews();

                case EnumLabelType.Sitemap:
                    return this.Analyse_Sitemap();

                case EnumLabelType.NorFilt:
                    return this.Analyse_NorFilt();

                case EnumLabelType.FlashFilt:
                    return this.Analyse_FlashFilt();

                case EnumLabelType.Stat:
                    return this.Analyse_Stat();

                case EnumLabelType.Search:
                    return this.Analyse_Search();

                case EnumLabelType.unRule:
                    return this.Analyse_unRule();

                case EnumLabelType.ClassList:
                    return this.Analyse_ClassList();

                case EnumLabelType.TodayPic:
                    return this.Analyse_TodayPic();

                case EnumLabelType.TodayWord:
                    return this.Analyse_TodayWord();

                case EnumLabelType.HistoryIndex:
                    return this.Analyse_HistoryIndex();

                case EnumLabelType.HotTag:
                    return this.Analyse_HotTag();

                case EnumLabelType.CopyRight:
                    return this.Analyse_CopyRight();

                case EnumLabelType.ReadClass:
                    return this.Analyse_ReadClass();

                case EnumLabelType.ReadSpecial:
                    return this.Analyse_ReadSpecial();

                case EnumLabelType.TopNews1:
                    return this.Analyse_TopNews1();

                case EnumLabelType.FormList:
                    return this.Analyse_FormList();

                case EnumLabelType.SubForm:
                    return this.Analyse_SubForm();
            }
            return string.Empty;
        }

        protected string News_List_End(string isDiv)
        {
            if (isDiv == "true")
            {
                return "\r\n";
            }
            return "</table>\r\n";
        }

        protected string News_List_Head(string isDiv, string ulID, string ulClass, string ColumnNewsCssValue)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(isDiv) || (isDiv == "false"))
            {
                return (str + "<table" + ColumnNewsCssValue + ">\r\n");
            }
            return (str + "\r\n");
        }

        private string parse(string mystyle, string formid)
        {
            string str2;
            string str3;
            if (((mystyle == null) || (mystyle == string.Empty)) || (mystyle == ""))
            {
                return null;
            }
            if ((mystyle.IndexOf("{#form_ctr_Validate}") > -1) && this.hasvalidate(Convert.ToInt32(formid)))
            {
                string newValue = "<input type=\"text\" id=\"CFValidate\" name=\"CFValidate\" />\r\n<img id=\"IMGValidCode\" width=\"70\" onClick=\"this.src+=Math.random()\" alt=\"图片看不清？点击重新得到验证码\" style=\"cursor:pointer;\" height=\"23\" hspace=\"4\" />\r\n <script type=\"text/javascript\" language=\"JavaScript\">\r\n document.getElementById('IMGValidCode').src='/comm/Image.aspx?k='+ Math.random();\r\n </script>\r\n";
                mystyle = mystyle.Replace("{#form_ctr_Validate}", newValue);
            }
            MatchCollection matchs = Regex.Matches(mystyle, @"\{#form_item_([^\}]+)\}", RegexOptions.Compiled);
            foreach (Match match in matchs)
            {
                str2 = match.Groups[1].Value;
                str3 = this.searchitemname(str2, formid);
                mystyle = mystyle.Replace(match.Value, str3);
            }
            MatchCollection matchs2 = Regex.Matches(mystyle, @"\{#form_ctr_([^\}]+)\}", RegexOptions.Compiled);
            foreach (Match match in matchs2)
            {
                str2 = match.Groups[1].Value;
                string[] strArray = this.searchControl(str2, formid);
                str3 = this.makeControl(strArray[0], strArray[1], str2, strArray[2], strArray[3]);
                mystyle = mystyle.Replace(match.Value, str3);
            }
            MatchCollection matchs3 = Regex.Matches(mystyle, @"\{#form_value_([^\}]+)\}", RegexOptions.Compiled);
            foreach (Match match in matchs3)
            {
                mystyle = mystyle.Replace(match.Value, "");
            }
            mystyle = "<form id = \"Form" + formid + "\" name = \"Form" + formid + "\" method=\"post\" action=\"/customform/CustomFormSubmit.aspx\" enctype=\"multipart/form-data\"> <input id=\"CustomFormID\" name=\"CustomFormID\" type=\"hidden\" value=\"" + formid + "\" /> " + mystyle + "</form>";
            return mystyle;
        }

        public string Parse()
        {
            if (!this.FormatValid)
            {
                return "";
            }
            switch (this.Param_LabelType)
            {
                case EnumLabelType.List:
                    return this.Analyse_List(null, null);

                case EnumLabelType.GroupMember:
                    return this.Analyse_GroupMember();

                case EnumLabelType.ConstrNews:
                    return this.Analyse_ConstrNews();

                case EnumLabelType.NewUser:
                    return this.Analyse_NewUser();

                case EnumLabelType.TopUser:
                    return this.Analyse_TopUser();

                case EnumLabelType.UserLogin:
                    return this.Analyse_UserLogin();

                case EnumLabelType.OtherJS:
                    return this.Analyse_OtherJS();

                case EnumLabelType.statJS:
                    return this.Analyse_statJS();

                case EnumLabelType.surveyJS:
                    return this.Analyse_surveyJS();

                case EnumLabelType.adJS:
                    return this.Analyse_adJS();

                case EnumLabelType.sysJS:
                    return this.Analyse_sysJS();

                case EnumLabelType.freeJS:
                    return this.Analyse_freeJS();

                case EnumLabelType.LastComm:
                    return this.Analyse_LastComm();

                case EnumLabelType.TopNews:
                    return this.Analyse_TopNews();

                case EnumLabelType.RSS:
                    return this.Analyse_RSS();

                case EnumLabelType.SpeicalNaviRead:
                    return this.Analyse_SpeicalNaviRead();

                case EnumLabelType.SpecialNavi:
                    return this.Analyse_SpecialNavi();

                case EnumLabelType.ClassNaviRead:
                    return this.Analyse_ClassNaviRead();

                case EnumLabelType.ClassNavi:
                    return this.Analyse_ClassNavi();

                case EnumLabelType.SClassNavi:
                    return this.Analyse_SClassNavi();

                case EnumLabelType.SiteNavi:
                    return this.Analyse_SiteNavi();

                case EnumLabelType.Metakey:
                    return this.Analyse_Meta(0, this.Param_ChID);

                case EnumLabelType.MetaDesc:
                    return this.Analyse_Meta(1, this.Param_ChID);

                case EnumLabelType.Frindlink:
                    return this.Analyse_FrindList();

                case EnumLabelType.ClassInfoList:
                    return this.Analyse_ClassInfoList();

                case EnumLabelType.History:
                    return this.Analyse_History();

                case EnumLabelType.CorrNews:
                    return this.Analyse_CorrNews();

                case EnumLabelType.Sitemap:
                    return this.Analyse_Sitemap();

                case EnumLabelType.NorFilt:
                    return this.Analyse_NorFilt();

                case EnumLabelType.FlashFilt:
                    return this.Analyse_FlashFilt();

                case EnumLabelType.Stat:
                    return this.Analyse_Stat();

                case EnumLabelType.Search:
                    return this.Analyse_Search();

                case EnumLabelType.Position:
                    return this.Analyse_Position(this.Param_ChID);

                case EnumLabelType.PageTitle:
                    return this.Analyse_PageTitle(this.Param_ChID);

                case EnumLabelType.unRule:
                    return this.Analyse_unRule();

                case EnumLabelType.ReadNews:
                    return this.Analyse_ReadNews(0, 0, 0, 0, "", "", 0, 0, 1);

                case EnumLabelType.ClassList:
                    return this.Analyse_ClassList();

                case EnumLabelType.TodayPic:
                    return this.Analyse_TodayPic();

                case EnumLabelType.TodayWord:
                    return this.Analyse_TodayWord();

                case EnumLabelType.HistoryIndex:
                    return this.Analyse_HistoryIndex();

                case EnumLabelType.HotTag:
                    return this.Analyse_HotTag();

                case EnumLabelType.CopyRight:
                    return this.Analyse_CopyRight();

                case EnumLabelType.ReadClass:
                    return this.Analyse_ReadClass();

                case EnumLabelType.ReadSpecial:
                    return this.Analyse_ReadSpecial();

                case EnumLabelType.TopNews1:
                    return this.Analyse_TopNews1();

                case EnumLabelType.FormList:
                    return this.Analyse_FormList();

                case EnumLabelType.SubForm:
                    return this.Analyse_SubForm();
            }
            return string.Empty;
        }

        public string Parse(int ChID)
        {
            if (!this.FormatValid)
            {
                return "";
            }
            switch (this.Param_LabelType)
            {
                case EnumLabelType.ChannelList:
                    return this.Analyse_ChannellList("", ChID);

                case EnumLabelType.ChannelClassList:
                    return this.Analyse_ChannelClassList(ChID);

                case EnumLabelType.ChannelContent:
                    return this.Analyse_ChannelContent(ChID);

                case EnumLabelType.ChannelSearch:
                    return this.Analyse_ChannelSearch(ChID);

                case EnumLabelType.ChannelRSS:
                    return this.Analyse_ChannelRSS(ChID);

                case EnumLabelType.ChannelFlash:
                    return this.Analyse_ChannelFlash(ChID);
            }
            return string.Empty;
        }

        public void ParseContent()
        {
            int index = this.Mass_Content.IndexOf(']');
            int num2 = this.Mass_Content.LastIndexOf('[');
            int num3 = this.Mass_Content.IndexOf("[");
            if (((this.Mass_Content.Length > 0) && (index > 1)) && (num2 > 1))
            {
                this.Mass_Primary = this.Mass_Content.Substring(num3 + 1, index - 1);
                int length = (num2 - index) - 1;
                if (length > 0)
                {
                    this.Mass_Inserted = this.Mass_Content.Substring(index + 1, length);
                }
            }
            this.ParsePrimary();
        }

        private void ParsePrimary()
        {
            if (this.Mass_Primary.IndexOf(",") > 0)
            {
                string[] strArray = this.Mass_Primary.Split(new char[] { ',' });
                if (strArray[0].Equals("FS:Loop"))
                {
                    this.Param_Loop = 1;
                }
                else if (strArray[0].Equals("FS:unLoop"))
                {
                    this.Param_Loop = 0;
                }
                else
                {
                    this.FormatValid = false;
                    this.InvalidInfo = "标签内容不是以[FS:unLoop或[FS:Loop开始";
                }
                int length = strArray.Length;
                IList<LabelParameter> list = new List<LabelParameter>();
                list.Clear();
                for (int i = 1; i < length; i++)
                {
                    LabelParameter parameter;
                    if (!this.FormatValid)
                    {
                        break;
                    }
                    string str = strArray[i];
                    int index = str.IndexOf('=');
                    if (index >= 0)
                    {
                        parameter.LPName = str.Substring(0, index).Trim();
                        parameter.LPValue = str.Substring(index + 1).Trim();
                        string lPName = parameter.LPName;
                        if (lPName == null)
                        {
                            goto Label_01FB;
                        }
                        if (!(lPName == "FS:Number"))
                        {
                            if (lPName == "FS:SiteID")
                            {
                                goto Label_01AB;
                            }
                            if (lPName == "FS:LabelType")
                            {
                                goto Label_01BA;
                            }
                            if (lPName == "FS:Root")
                            {
                                continue;
                            }
                            goto Label_01FB;
                        }
                        if (this.Param_Loop.Equals(1))
                        {
                            try
                            {
                                this.Param_Loop = int.Parse(parameter.LPValue);
                            }
                            catch
                            {
                                this.FormatValid = false;
                                this.InvalidInfo = "FS:Number的值不是有效的数字";
                            }
                        }
                        this.AddParameter(parameter, ref list);
                    }
                    continue;
                Label_01AB:
                    this.Param_SiteID = parameter.LPValue;
                    continue;
                Label_01BA:
                    try
                    {
                        this.Param_LabelType = (EnumLabelType) Enum.Parse(typeof(EnumLabelType), parameter.LPValue);
                    }
                    catch
                    {
                        this.FormatValid = false;
                        this.InvalidInfo = "FS:LabelType指定的类型不存在";
                    }
                    continue;
                Label_01FB:
                    this.AddParameter(parameter, ref list);
                }
                int count = list.Count;
                if (this.FormatValid && (count > 0))
                {
                    this._LblParams = new LabelParameter[count];
                    list.CopyTo(this._LblParams, 0);
                }
            }
        }

        protected string PlaceClassStyle(string classStyle, DataRow classInfo)
        {
            if (classStyle.IndexOf("{#class_Name}") > -1)
            {
                if (classInfo != null)
                {
                    classStyle = classStyle.Replace("{#class_Name}", classInfo["ClassCName"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_Name}", "");
                }
            }
            if (classStyle.IndexOf("{#class_EName}") > -1)
            {
                if (classInfo != null)
                {
                    classStyle = classStyle.Replace("{#class_EName}", classInfo["ClassEName"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_EName}", "");
                }
            }
            if (classStyle.IndexOf("{#class_ID}") > -1)
            {
                if (classInfo != null)
                {
                    classStyle = classStyle.Replace("{#class_ID}", classInfo["ClassID"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_ID}", "");
                }
            }
            if (classStyle.IndexOf("{#class_Path}") > -1)
            {
                if (classInfo != null)
                {
                    classStyle = classStyle.Replace("{#class_Path}", this.GetClassURL(classInfo["Domain"].ToString(), Convert.ToInt32(classInfo["isDelPoint"]), classInfo["ClassID"].ToString(), classInfo["SavePath"].ToString(), classInfo["SaveClassframe"].ToString(), classInfo["ClassSaveRule"].ToString(), Convert.ToInt32(classInfo["IsURL"]), classInfo["URLaddress"].ToString(), 0));
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_Path}", "");
                }
            }
            if (classStyle.IndexOf("{#class_Navi}") > -1)
            {
                if (classInfo != null)
                {
                    classStyle = classStyle.Replace("{#class_Navi}", classInfo["NaviContent"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_Navi}", "");
                }
            }
            if (classStyle.IndexOf("{#class_Keywords}") > -1)
            {
                if (classInfo != null)
                {
                    classStyle = classStyle.Replace("{#class_Keywords}", classInfo["MetaKeywords"].ToString());
                }
                else
                {
                    classStyle = classStyle.Replace("{#class_Keywords}", "");
                }
            }
            if (classStyle.IndexOf("{#class_Descript}") > -1)
            {
                if (classInfo != null)
                {
                    classStyle = classStyle.Replace("{#class_Descript}", classInfo["MetaDescript"].ToString());
                    return classStyle;
                }
                classStyle = classStyle.Replace("{#class_Descript}", "");
            }
            return classStyle;
        }

        protected void Recursion_Sitemap(string ParentID, string brStr, string s_SubCSS, string s_MapsubNaviText, string s_MapsubNavi)
        {
            string str = "";
            PubClassInfo info = null;
            foreach (PubClassInfo info2 in CommonData.NewsClass)
            {
                if (info2.ParentID.Equals(ParentID))
                {
                    info = info2;
                    string str2 = str;
                    str = str2 + brStr + s_MapsubNaviText + s_MapsubNavi + "<a " + s_SubCSS + " href=\"" + this.GetClassURL(info.Domain, info.isDelPoint, info.ClassID, info.SavePath, info.SaveClassframe, info.ClassSaveRule, info.IsURL, info.URLaddress, info.isPage) + "\">" + info.ClassCName + "</a>";
                }
            }
            if (info != null)
            {
                this.Analyse_SitemapString = str;
                this.Recursion_Sitemap(info.ClassID, str, s_SubCSS, s_MapsubNaviText, s_MapsubNavi);
            }
        }

        protected string RelpacePicPath(string PicPath)
        {
            return PicPath.ToLower().Replace("{@dirfile}", UIConfig.dirFile);
        }

        private string[] searchControl(string fieldname, string formid)
        {
            Foosun.CMS.Label label = new Foosun.CMS.Label();
            return label.searchControlinfo(fieldname, formid);
        }

        private string searchitemname(string fieldname, string formid)
        {
            Foosun.CMS.Label label = new Foosun.CMS.Label();
            return label.searchiteminfo(fieldname, formid);
        }

        private string searchValues(string tablename, int pagesize, int pageindex, out int recordCount, out int pageCount, string mystyle, MatchCollection formValues)
        {
            DataTable table = new Foosun.CMS.Label().searchValues(tablename, pageindex, pagesize, out recordCount, out pageCount);
            string str = string.Empty;
            for (int i = 0; i < pagesize; i++)
            {
                string str2 = mystyle;
                if (table.Rows.Count <= i)
                {
                    return str;
                }
                foreach (Match match in formValues)
                {
                    if (table.Columns.Contains(match.Groups[1].Value))
                    {
                        str2 = str2.Replace(match.Value, table.Rows[i][match.Groups[1].Value].ToString());
                    }
                    else
                    {
                        str2 = str2.Replace(match.Value, "");
                    }
                }
                str = str + str2;
            }
            return str;
        }

        private string validateCatch(string jsID)
        {
            DataRow[] rowArray = CommonData.NewsJsList.Select("JsID='" + jsID + "'");
            IDataReader jsPath = null;
            DataRow row = null;
            if (rowArray.Length == 0)
            {
                jsPath = CommonData.DalPublish.GetJsPath(jsID);
                if (jsPath.Read())
                {
                    row = CommonData.NewsJsList.NewRow();
                    row["JsID"] = jsPath.GetString(2);
                    row["jssavepath"] = jsPath.GetString(0);
                    row["jsfilename"] = jsPath.GetString(1);
                }
                jsPath.Close();
                CommonData.NewsJsList.Rows.Add(row);
            }
            else
            {
                row = rowArray[0];
            }
            string str = CommonData.SiteDomain + (row["jssavepath"] + "/" + row["jsfilename"]).Replace("//", "/") + ".js";
            return ("<script language=\"javascript\" src=\"" + str + "\"></script>");
        }

        public string Content
        {
            get
            {
                return this.Mass_Content;
            }
        }

        public string FormatInvalidMsg
        {
            get
            {
                return this.InvalidInfo;
            }
        }

        public TempType TemplateType
        {
            get
            {
                return this._TemplateType;
            }
            set
            {
                this._TemplateType = value;
            }
        }

        protected enum EnumLabelType
        {
            List,
            GroupMember,
            ConstrNews,
            NewUser,
            TopUser,
            UserLogin,
            OtherJS,
            statJS,
            surveyJS,
            adJS,
            sysJS,
            freeJS,
            LastComm,
            TopNews,
            RSS,
            SpeicalNaviRead,
            SpecialNavi,
            ClassNaviRead,
            ClassNavi,
            SClassNavi,
            SiteNavi,
            Metakey,
            MetaDesc,
            Frindlink,
            ClassInfoList,
            History,
            CorrNews,
            Sitemap,
            NorFilt,
            FlashFilt,
            Stat,
            Search,
            Position,
            PageTitle,
            unRule,
            ReadNews,
            ClassList,
            TodayPic,
            TodayWord,
            HistoryIndex,
            HotTag,
            CopyRight,
            ChannelList,
            ChannelClassList,
            ChannelContent,
            ChannelSearch,
            ChannelRSS,
            ChannelFlash,
            ReadClass,
            ReadSpecial,
            TopNews1,
            FormList,
            SubForm
        }
    }
}


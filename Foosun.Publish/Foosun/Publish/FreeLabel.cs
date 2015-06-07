namespace Foosun.Publish
{
    using Common;
    using Foosun.Config;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public class FreeLabel : Label
    {
        private string LabelSQL;
        private string LabelStyle;

        public FreeLabel(string labelname, LabelType labeltype) : base(labelname, labeltype)
        {
            this.LabelSQL = string.Empty;
            this.LabelStyle = string.Empty;
        }

        public override void GetContentFromDB()
        {
            IDataReader freeLabelContent = CommonData.DalPublish.GetFreeLabelContent(base._LabelName);
            if (freeLabelContent.Read())
            {
                this.LabelSQL = freeLabelContent.GetString(0);
                if (!freeLabelContent.IsDBNull(1))
                {
                    this.LabelStyle = freeLabelContent.GetString(1);
                }
            }
            freeLabelContent.Close();
        }

        public override void MakeHtmlCode()
        {
            if (this.LabelStyle == string.Empty)
            {
                base._FinalHtmlCode = string.Empty;
            }
            else
            {
                Match match2;
                int num2;
                string name;
                string str9;
                string labelStyle = this.LabelStyle;
                string pattern = @"\[\$[^\$]+\$\]";
                Regex regex = new Regex(pattern, RegexOptions.Compiled);
                Match match = regex.Match(labelStyle);
                DateTime now = DateTime.Now;
                while (match.Success)
                {
                    string str3;
                    string input = str3 = match.Value;
                    input = Regex.Replace(input, @"^\[\$|\$\]$", "").Replace("YY02", now.Year.ToString().Remove(0, 2)).Replace("YY04", now.Year.ToString()).Replace("MM", now.Month.ToString()).Replace("DD", now.Day.ToString()).Replace("HH", now.Hour.ToString()).Replace("MI", now.Minute.ToString()).Replace("SS", now.Second.ToString());
                    labelStyle = labelStyle.Replace(str3, input);
                    match = regex.Match(labelStyle);
                }
                IList<StParam> list = this.ParseFields(labelStyle);
                DataTable table = CommonData.DalPublish.ExecuteSql(this.LabelSQL);
                List<int> list2 = new List<int>();
                string str5 = @"\{\*(?<n>\d+)(?<c>[\S\s]*?)\*\}";
                Regex regex2 = new Regex(str5, RegexOptions.Compiled);
                for (match2 = regex2.Match(labelStyle); match2.Success; match2 = match2.NextMatch())
                {
                    string oldValue = match2.Value;
                    string str7 = match2.Groups["c"].Value.Trim();
                    int num = Convert.ToInt32(match2.Groups["n"].Value);
                    list2.Add(num - 1);
                    if (list != null)
                    {
                        num2 = 0;
                        while (num2 < list.Count)
                        {
                            name = list[num2].name;
                            str9 = string.Empty;
                            if (((table != null) && (table.Rows.Count >= num)) && (table.Rows[num - 1][list[num2].pos] != DBNull.Value))
                            {
                                str9 = table.Rows[num - 1][list[num2].pos].ToString();
                            }
                            str7 = this.ReplaceField(str7, name, str9);
                            num2++;
                        }
                    }
                    labelStyle = labelStyle.Replace(oldValue, str7);
                }
                str5 = @"\{\#[\s\S]*?\#\}";
                Regex regex3 = new Regex(str5, RegexOptions.Compiled);
                for (match2 = regex3.Match(labelStyle); match2.Success; match2 = match2.NextMatch())
                {
                    string str10 = match2.Value;
                    string str11 = str10.Substring(2, str10.Length - 4);
                    string newValue = string.Empty;
                    if (table != null)
                    {
                        for (num2 = 0; num2 < table.Rows.Count; num2++)
                        {
                            if (!list2.Contains(num2))
                            {
                                list2.Add(num2);
                                string str13 = str11;
                                if (list != null)
                                {
                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        name = list[i].name;
                                        str9 = string.Empty;
                                        if (table.Rows[num2][list[i].pos] != DBNull.Value)
                                        {
                                            str9 = table.Rows[num2][list[i].pos].ToString();
                                        }
                                        str13 = this.ReplaceField(str13, name, str9);
                                    }
                                }
                                newValue = newValue + str13;
                            }
                        }
                    }
                    labelStyle = labelStyle.Replace(str10, newValue);
                }
                list.Clear();
                table.Clear();
                table.Dispose();
                base._FinalHtmlCode = labelStyle;
            }
        }

        private IList<StParam> ParseFields(string Input)
        {
            string str = Regex.Match(this.LabelSQL, @"^select\ +(top\ +\d+\ +)?(?<flds>.+)\ +from\ +.+", (RegexOptions)9).Groups["flds"].Value.Trim();
            if (str.Equals(string.Empty))
            {
                return null;
            }
            string[] strArray = null;
            if (str.IndexOf(",") > 0)
            {
                strArray = str.Trim().Split(new char[] { ',' });
            }
            else
            {
                strArray = new string[] { str };
            }
            string pattern = @"\[\*(?<fld>[\s\S]+?)\*\]";
            IList<StParam> list = new List<StParam>();
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            for (Match match = regex.Match(Input); match.Success; match = match.NextMatch())
            {
                StParam param;
                param.name = match.Groups["fld"].Value;
                param.pos = -1;
                bool flag = false;
                foreach (StParam param2 in list)
                {
                    if (param2.name.Equals(param.name))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].Trim().Equals(param.name.Trim()))
                        {
                            param.pos = i;
                            list.Add(param);
                            break;
                        }
                    }
                }
            }
            return list;
        }

        protected string ReplaceField(string Input, string FieldName, string FieldValue)
        {
            FieldValue = FieldValue.Replace("{@dirfile}", UIConfig.dirFile);
            if ((Input == null) || (Input.Trim() == string.Empty))
            {
                return string.Empty;
            }
            string str = Input;
            string pattern = @"\(\#[Ll][Ee][Ff][Tt]\(\[\*" + Regex.Escape(FieldName) + @"\*\]\,(?<n>\d+)\)\#\)";
            Match match = new Regex(pattern, RegexOptions.Compiled).Match(Input);
            if (match.Success)
            {
                int num = int.Parse(match.Groups["n"].Value);
                FieldValue = Common.Input.GetSubString(FieldValue, num);
                str = Regex.Replace(Input, pattern, FieldValue);
            }
            else
            {
                string str4;
                string str5;
                string str3 = this.testTable(FieldName);
                if (str3 == "fs_news_class")
                {
                    str4 = CommonData.getClassURL(FieldValue);
                    str5 = "<a href=\"" + str4 + "\">" + FieldName + "</a>";
                    return Input.Replace("[*" + FieldName + "*]", str4);
                }
                if (str3 == "fs_news")
                {
                    str4 = CommonData.getNewsURLFormID(FieldValue, DBConfig.CmsConString);
                    str5 = "<a href=\"" + str4 + "\">" + FieldName + "</a>";
                    str = Input.Replace("[*" + FieldName + "*]", str4);
                }
                else
                {
                    str = Input.Replace("[*" + FieldName + "*]", FieldValue);
                }
            }
            return str;
        }

        protected string testTable(string FieldName)
        {
            string str = "";
            string pattern = "";
            string str3 = FieldName;
            string[] strArray = null;
            if (FieldName.IndexOf('.') != -1)
            {
                strArray = FieldName.Split(new char[] { '.' });
                str = strArray[0];
                str3 = strArray[1];
            }
            else
            {
                pattern = "fs_news_class";
                Regex regex = new Regex(pattern, RegexOptions.Compiled);
                if (regex.Match(this.LabelSQL).Success)
                {
                    str = "fs_news_class";
                }
                else
                {
                    pattern = "fs_news";
                    regex = new Regex(pattern, RegexOptions.Compiled);
                    if (regex.Match(this.LabelSQL).Success)
                    {
                        str = "fs_news";
                    }
                }
            }
            str = str.ToLower();
            str3 = str3.ToLower();
            if ((str == "fs_news_class") && (str3 == "classid"))
            {
                return "fs_news_class";
            }
            if ((str == "fs_news") && (str3 == "newsid"))
            {
                return "fs_news";
            }
            return "";
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct StParam
        {
            public string name;
            public int pos;
        }
    }
}


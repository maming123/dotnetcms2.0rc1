namespace Foosun.Publish
{
    using Common;
    using Foosun.Config;
    using Foosun.IDAL;
    using Foosun.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class CommonData
    {
        public static IList<PubCHClassInfo> CHClass = new List<PubCHClassInfo>();
        public static IList<PubCHSpecialInfo> CHSpecial = new List<PubCHSpecialInfo>();
        public static IPublish DalPublish = Foosun.DALFactory.DataAccess.CreatePublish();
        public static IList<PubClassInfo> NewsClass = new List<PubClassInfo>();
        public static DataTable NewsInfoList = new DataTable();
        public static DataTable NewsJsList = null;
        public static IList<PubSpecialInfo> NewsSpecial = new List<PubSpecialInfo>();
        public static string SiteDomain = Public.GetSiteDomain();

        private static void _SetDataTableFrame()
        {
            if (NewsInfoList == null)
            {
                NewsInfoList = new DataTable();
            }
            if (NewsInfoList.Columns.Count == 0)
            {
                NewsInfoList.Columns.Add("Id");
                NewsInfoList.Columns.Add("NewsID");
                NewsInfoList.Columns.Add("NewsType");
                NewsInfoList.Columns.Add("OrderID");
                NewsInfoList.Columns.Add("NewsTitle");
                NewsInfoList.Columns.Add("sNewsTitle");
                NewsInfoList.Columns.Add("TitleColor");
                NewsInfoList.Columns.Add("TitleITF");
                NewsInfoList.Columns.Add("TitleBTF");
                NewsInfoList.Columns.Add("CommLinkTF");
                NewsInfoList.Columns.Add("SubNewsTF");
                NewsInfoList.Columns.Add("URLaddress");
                NewsInfoList.Columns.Add("PicURL");
                NewsInfoList.Columns.Add("SPicURL");
                NewsInfoList.Columns.Add("ClassID");
                NewsInfoList.Columns.Add("SpecialID");
                NewsInfoList.Columns.Add("Author");
                NewsInfoList.Columns.Add("Souce");
                NewsInfoList.Columns.Add("Tags");
                NewsInfoList.Columns.Add("NewsProperty");
                NewsInfoList.Columns.Add("NewsPicTopline");
                NewsInfoList.Columns.Add("Templet");
                NewsInfoList.Columns.Add("Content");
                NewsInfoList.Columns.Add("Metakeywords");
                NewsInfoList.Columns.Add("Metadesc");
                NewsInfoList.Columns.Add("naviContent");
                NewsInfoList.Columns.Add("Click");
                NewsInfoList.Columns.Add("CreatTime");
                NewsInfoList.Columns.Add("EditTime");
                NewsInfoList.Columns.Add("SavePath");
                NewsInfoList.Columns.Add("FileName");
                NewsInfoList.Columns.Add("FileEXName");
                NewsInfoList.Columns.Add("isDelPoint");
                NewsInfoList.Columns.Add("Gpoint");
                NewsInfoList.Columns.Add("iPoint");
                NewsInfoList.Columns.Add("GroupNumber");
                NewsInfoList.Columns.Add("ContentPicTF");
                NewsInfoList.Columns.Add("ContentPicURL");
                NewsInfoList.Columns.Add("ContentPicSize");
                NewsInfoList.Columns.Add("CommTF");
                NewsInfoList.Columns.Add("DiscussTF");
                NewsInfoList.Columns.Add("TopNum");
                NewsInfoList.Columns.Add("VoteTF");
                NewsInfoList.Columns.Add("CheckStat");
                NewsInfoList.Columns.Add("isLock");
                NewsInfoList.Columns.Add("isRecyle");
                NewsInfoList.Columns.Add("SiteID");
                NewsInfoList.Columns.Add("DataLib");
                NewsInfoList.Columns.Add("DefineID");
                NewsInfoList.Columns.Add("isVoteTF");
                NewsInfoList.Columns.Add("Editor");
                NewsInfoList.Columns.Add("isHtml");
                NewsInfoList.Columns.Add("isConstr");
                NewsInfoList.Columns.Add("isFiles");
                NewsInfoList.Columns.Add("vURL");
            }
        }

        private static void _setNewsInfoDataRow(IDataReader rd)
        {
            if ((NewsInfoList == null) || (NewsInfoList.Columns.Count == 0))
            {
                NewsInfoList = DalPublish.GetNewsListByAll("'" + rd["NewsID"].ToString() + "'");
            }
            DataRow row = NewsInfoList.NewRow();
            row["ID"] = Convert.ToInt32(rd["Id"]);
            row["NewsID"] = Convert.ToString(rd["NewsID"]);
            row["NewsType"] = Convert.ToByte(rd["NewsType"]);
            row["OrderID"] = Convert.ToByte(rd["OrderID"]);
            row["NewsTitle"] = Convert.ToString(rd["NewsTitle"]);
            if (rd["sNewsTitle"] == DBNull.Value)
            {
                row["sNewsTitle"] = "";
            }
            else
            {
                row["sNewsTitle"] = Convert.ToString(rd["sNewsTitle"]);
            }
            if (rd["TitleColor"] == DBNull.Value)
            {
                row["TitleColor"] = "";
            }
            else
            {
                row["TitleColor"] = Convert.ToString(rd["TitleColor"]);
            }
            row["TitleITF"] = Convert.ToByte(rd["TitleITF"]);
            if (rd["TitleBTF"] == DBNull.Value)
            {
                row["TitleBTF"] = 0;
            }
            else
            {
                row["TitleBTF"] = Convert.ToByte(rd["TitleBTF"]);
            }
            if (rd["CommLinkTF"] == DBNull.Value)
            {
                row["CommLinkTF"] = 0;
            }
            else
            {
                row["CommLinkTF"] = Convert.ToByte(rd["CommLinkTF"]);
            }
            if (rd["SubNewsTF"] == DBNull.Value)
            {
                row["SubNewsTF"] = 0;
            }
            else
            {
                row["SubNewsTF"] = Convert.ToByte(rd["SubNewsTF"]);
            }
            if (rd["URLaddress"] == DBNull.Value)
            {
                row["URLaddress"] = "";
            }
            else
            {
                row["URLaddress"] = Convert.ToString(rd["URLaddress"]);
            }
            if (rd["PicURL"] == DBNull.Value)
            {
                row["PicURL"] = "";
            }
            else
            {
                row["PicURL"] = Convert.ToString(rd["PicURL"]);
            }
            if (rd["SPicURL"] == DBNull.Value)
            {
                row["SPicURL"] = "";
            }
            else
            {
                row["SPicURL"] = Convert.ToString(rd["SPicURL"]);
            }
            row["ClassID"] = Convert.ToString(rd["ClassID"]);
            if (rd["SpecialID"] == DBNull.Value)
            {
                row["SpecialID"] = "";
            }
            else
            {
                row["SpecialID"] = Convert.ToString(rd["SpecialID"]);
            }
            if (rd["Author"] == DBNull.Value)
            {
                row["Author"] = "";
            }
            else
            {
                row["Author"] = Convert.ToString(rd["Author"]);
            }
            if (rd["Souce"] == DBNull.Value)
            {
                row["Souce"] = "";
            }
            else
            {
                row["Souce"] = Convert.ToString(rd["Souce"]);
            }
            if (rd["Tags"] == DBNull.Value)
            {
                row["Tags"] = "";
            }
            else
            {
                row["Tags"] = Convert.ToString(rd["Tags"]);
            }
            row["NewsProperty"] = Convert.ToString(rd["NewsProperty"]);
            row["NewsPicTopline"] = Convert.ToByte(rd["NewsPicTopline"]);
            if (rd["Templet"] == DBNull.Value)
            {
                row["Templet"] = "";
            }
            else
            {
                row["Templet"] = Convert.ToString(rd["Templet"]);
            }
            if (rd["Content"] == DBNull.Value)
            {
                row["Content"] = "";
            }
            else
            {
                row["Content"] = Convert.ToString(rd["Content"]);
            }
            if (rd["Metakeywords"] == DBNull.Value)
            {
                row["Metakeywords"] = "";
            }
            else
            {
                row["Metakeywords"] = Convert.ToString(rd["Metakeywords"]);
            }
            if (rd["Metadesc"] == DBNull.Value)
            {
                row["Metadesc"] = "";
            }
            else
            {
                row["Metadesc"] = Convert.ToString(rd["Metadesc"]);
            }
            if (rd["naviContent"] == DBNull.Value)
            {
                row["naviContent"] = "";
            }
            else
            {
                row["naviContent"] = Convert.ToString(rd["naviContent"]);
            }
            row["Click"] = Convert.ToInt32(rd["Click"]);
            row["CreatTime"] = Convert.ToDateTime(rd["CreatTime"]);
            if (rd["EditTime"] == DBNull.Value)
            {
                row["EditTime"] = Convert.ToDateTime(rd["CreatTime"]);
            }
            else
            {
                row["EditTime"] = Convert.ToDateTime(rd["EditTime"]);
            }
            if (rd["SavePath"] == DBNull.Value)
            {
                row["SavePath"] = "";
            }
            else
            {
                row["SavePath"] = Convert.ToString(rd["SavePath"]);
            }
            row["FileName"] = Convert.ToString(rd["FileName"]);
            row["FileEXName"] = Convert.ToString(rd["FileEXName"]);
            row["isDelPoint"] = Convert.ToByte(rd["isDelPoint"]);
            row["Gpoint"] = Convert.ToInt32(rd["Gpoint"]);
            row["iPoint"] = Convert.ToInt32(rd["iPoint"]);
            if (rd["GroupNumber"] == DBNull.Value)
            {
                row["GroupNumber"] = "";
            }
            else
            {
                row["GroupNumber"] = Convert.ToString(rd["GroupNumber"]);
            }
            row["ContentPicTF"] = Convert.ToByte(rd["ContentPicTF"]);
            if (rd["ContentPicURL"] == DBNull.Value)
            {
                row["ContentPicURL"] = "";
            }
            else
            {
                row["ContentPicURL"] = Convert.ToString(rd["ContentPicURL"]);
            }
            if (rd["ContentPicSize"] == DBNull.Value)
            {
                row["ContentPicSize"] = "";
            }
            else
            {
                row["ContentPicSize"] = Convert.ToString(rd["ContentPicSize"]);
            }
            row["CommTF"] = Convert.ToByte(rd["CommTF"]);
            row["DiscussTF"] = Convert.ToByte(rd["DiscussTF"]);
            row["TopNum"] = Convert.ToInt32(rd["TopNum"]);
            row["VoteTF"] = Convert.ToByte(rd["VoteTF"]);
            if (rd["CheckStat"] == DBNull.Value)
            {
                row["CheckStat"] = "";
            }
            else
            {
                row["CheckStat"] = Convert.ToString(rd["CheckStat"]);
            }
            row["isLock"] = Convert.ToByte(rd["isLock"]);
            row["isRecyle"] = Convert.ToByte(rd["isRecyle"]);
            row["SiteID"] = Convert.ToString(rd["SiteID"]);
            row["DataLib"] = Convert.ToString(rd["DataLib"]);
            if (rd["DefineID"] == DBNull.Value)
            {
                row["DefineID"] = 0;
            }
            else
            {
                row["DefineID"] = Convert.ToByte(rd["DefineID"]);
            }
            row["isVoteTF"] = Convert.ToByte(rd["isVoteTF"]);
            if (rd["Editor"] == DBNull.Value)
            {
                row["Editor"] = "";
            }
            else
            {
                row["Editor"] = Convert.ToString(rd["Editor"]);
            }
            row["isHtml"] = Convert.ToByte(rd["isHtml"]);
            row["isConstr"] = Convert.ToByte(rd["isConstr"]);
            if (rd["isFiles"] == DBNull.Value)
            {
                row["isFiles"] = 0;
            }
            else
            {
                row["isFiles"] = Convert.ToByte(rd["isFiles"]);
            }
            if (rd["vURL"] == DBNull.Value)
            {
                row["vURL"] = "";
            }
            else
            {
                row["vURL"] = Convert.ToString(rd["vURL"]);
            }
            NewsInfoList.Rows.Add(row);
        }

        private static News _setNewsInfos(DataRowView rd)
        {
            News news = new News();
            if (rd != null)
            {
                news.Id = Convert.ToInt32(rd["ID"]);
                news.NewsID = Convert.ToString(rd["NewsID"]);
                news.NewsType = Convert.ToByte(rd["NewsType"]);
                news.OrderID = Convert.ToByte(rd["OrderID"]);
                news.NewsTitle = Convert.ToString(rd["NewsTitle"]);
                if (rd["sNewsTitle"] == DBNull.Value)
                {
                    news.sNewsTitle = "";
                }
                else
                {
                    news.sNewsTitle = Convert.ToString(rd["sNewsTitle"]);
                }
                if (rd["TitleColor"] == DBNull.Value)
                {
                    news.TitleColor = "";
                }
                else
                {
                    news.TitleColor = Convert.ToString(rd["TitleColor"]);
                }
                news.TitleITF = Convert.ToByte(rd["TitleITF"]);
                if (rd["TitleBTF"] == DBNull.Value)
                {
                    news.TitleBTF = 0;
                }
                else
                {
                    news.TitleBTF = new int?(Convert.ToByte(rd["TitleBTF"]));
                }
                if (rd["CommLinkTF"] == DBNull.Value)
                {
                    news.CommLinkTF = 0;
                }
                else
                {
                    news.CommLinkTF = new int?(Convert.ToByte(rd["CommLinkTF"]));
                }
                if (rd["SubNewsTF"] == DBNull.Value)
                {
                    news.SubNewsTF = 0;
                }
                else
                {
                    news.SubNewsTF = new int?(Convert.ToByte(rd["SubNewsTF"]));
                }
                if (rd["URLaddress"] == DBNull.Value)
                {
                    news.URLaddress = "";
                }
                else
                {
                    news.URLaddress = Convert.ToString(rd["URLaddress"]);
                }
                if (rd["PicURL"] == DBNull.Value)
                {
                    news.PicURL = "";
                }
                else
                {
                    news.PicURL = Convert.ToString(rd["PicURL"]);
                }
                if (rd["SPicURL"] == DBNull.Value)
                {
                    news.SPicURL = "";
                }
                else
                {
                    news.SPicURL = Convert.ToString(rd["SPicURL"]);
                }
                news.ClassID = Convert.ToString(rd["ClassID"]);
                if (rd["SpecialID"] == DBNull.Value)
                {
                    news.SpecialID = "";
                }
                else
                {
                    news.SpecialID = Convert.ToString(rd["SpecialID"]);
                }
                if (rd["Author"] == DBNull.Value)
                {
                    news.Author = "";
                }
                else
                {
                    news.Author = Convert.ToString(rd["Author"]);
                }
                if (rd["Souce"] == DBNull.Value)
                {
                    news.Souce = "";
                }
                else
                {
                    news.Souce = Convert.ToString(rd["Souce"]);
                }
                if (rd["Tags"] == DBNull.Value)
                {
                    news.Tags = "";
                }
                else
                {
                    news.Tags = Convert.ToString(rd["Tags"]);
                }
                news.NewsProperty = Convert.ToString(rd["NewsProperty"]);
                news.NewsPicTopline = Convert.ToByte(rd["NewsPicTopline"]);
                if (rd["Templet"] == DBNull.Value)
                {
                    news.Templet = "";
                }
                else
                {
                    news.Templet = Convert.ToString(rd["Templet"]);
                }
                if (rd["Content"] == DBNull.Value)
                {
                    news.Content = "";
                }
                else
                {
                    news.Content = Convert.ToString(rd["Content"]);
                }
                if (rd["Metakeywords"] == DBNull.Value)
                {
                    news.Metakeywords = "";
                }
                else
                {
                    news.Metakeywords = Convert.ToString(rd["Metakeywords"]);
                }
                if (rd["Metadesc"] == DBNull.Value)
                {
                    news.Metadesc = "";
                }
                else
                {
                    news.Metadesc = Convert.ToString(rd["Metadesc"]);
                }
                if (rd["naviContent"] == DBNull.Value)
                {
                    news.naviContent = "";
                }
                else
                {
                    news.naviContent = Convert.ToString(rd["naviContent"]);
                }
                news.Click = Convert.ToInt32(rd["Click"]);
                news.CreatTime = Convert.ToDateTime(rd["CreatTime"]);
                if (rd["EditTime"] == DBNull.Value)
                {
                    news.EditTime = new DateTime?(Convert.ToDateTime(rd["CreatTime"]));
                }
                else
                {
                    news.EditTime = new DateTime?(Convert.ToDateTime(rd["EditTime"]));
                }
                if (rd["SavePath"] == DBNull.Value)
                {
                    news.SavePath = "";
                }
                else
                {
                    news.SavePath = Convert.ToString(rd["SavePath"]);
                }
                news.FileName = Convert.ToString(rd["FileName"]);
                news.FileEXName = Convert.ToString(rd["FileEXName"]);
                news.isDelPoint = Convert.ToByte(rd["isDelPoint"]);
                news.Gpoint = Convert.ToInt32(rd["Gpoint"]);
                news.iPoint = Convert.ToInt32(rd["iPoint"]);
                if (rd["GroupNumber"] == DBNull.Value)
                {
                    news.GroupNumber = "";
                }
                else
                {
                    news.GroupNumber = Convert.ToString(rd["GroupNumber"]);
                }
                news.ContentPicTF = Convert.ToByte(rd["ContentPicTF"]);
                if (rd["ContentPicURL"] == DBNull.Value)
                {
                    news.ContentPicURL = "";
                }
                else
                {
                    news.ContentPicURL = Convert.ToString(rd["ContentPicURL"]);
                }
                if (rd["ContentPicSize"] == DBNull.Value)
                {
                    news.ContentPicSize = "";
                }
                else
                {
                    news.ContentPicSize = Convert.ToString(rd["ContentPicSize"]);
                }
                news.CommTF = Convert.ToByte(rd["CommTF"]);
                news.DiscussTF = Convert.ToByte(rd["DiscussTF"]);
                news.TopNum = Convert.ToInt32(rd["TopNum"]);
                news.VoteTF = Convert.ToByte(rd["VoteTF"]);
                if (rd["CheckStat"] == DBNull.Value)
                {
                    news.CheckStat = "";
                }
                else
                {
                    news.CheckStat = Convert.ToString(rd["CheckStat"]);
                }
                news.isLock = Convert.ToByte(rd["isLock"]);
                news.isRecyle = Convert.ToByte(rd["isRecyle"]);
                news.SiteID = Convert.ToString(rd["SiteID"]);
                news.DataLib = Convert.ToString(rd["DataLib"]);
                if (rd["DefineID"] == DBNull.Value)
                {
                    news.DefineID = 0;
                }
                else
                {
                    news.DefineID = new int?(Convert.ToByte(rd["DefineID"]));
                }
                news.isVoteTF = Convert.ToByte(rd["isVoteTF"]);
                if (rd["Editor"] == DBNull.Value)
                {
                    news.Editor = "";
                }
                else
                {
                    news.Editor = Convert.ToString(rd["Editor"]);
                }
                news.isHtml = Convert.ToByte(rd["isHtml"]);
                news.isConstr = Convert.ToByte(rd["isConstr"]);
                if (rd["isFiles"] == DBNull.Value)
                {
                    news.isFiles = 0;
                }
                else
                {
                    news.isFiles = new int?(Convert.ToByte(rd["isFiles"]));
                }
                if (rd["vURL"] == DBNull.Value)
                {
                    news.vURL = "";
                    return news;
                }
                news.vURL = Convert.ToString(rd["vURL"]);
            }
            return news;
        }

        private static News _setNewsInfos(IDataReader rd)
        {
            News news = new News();
            news.Id = Convert.ToInt32(rd["ID"]);
            news.NewsID = Convert.ToString(rd["NewsID"]);
            news.NewsType = Convert.ToByte(rd["NewsType"]);
            news.OrderID = Convert.ToByte(rd["OrderID"]);
            news.NewsTitle = Convert.ToString(rd["NewsTitle"]);
            if (rd["sNewsTitle"] == DBNull.Value)
            {
                news.sNewsTitle = "";
            }
            else
            {
                news.sNewsTitle = Convert.ToString(rd["sNewsTitle"]);
            }
            if (rd["TitleColor"] == DBNull.Value)
            {
                news.TitleColor = "";
            }
            else
            {
                news.TitleColor = Convert.ToString(rd["TitleColor"]);
            }
            news.TitleITF = Convert.ToByte(rd["TitleITF"]);
            if (rd["TitleBTF"] == DBNull.Value)
            {
                news.TitleBTF = 0;
            }
            else
            {
                news.TitleBTF = new int?(Convert.ToByte(rd["TitleBTF"]));
            }
            if (rd["CommLinkTF"] == DBNull.Value)
            {
                news.CommLinkTF = 0;
            }
            else
            {
                news.CommLinkTF = new int?(Convert.ToByte(rd["CommLinkTF"]));
            }
            if (rd["SubNewsTF"] == DBNull.Value)
            {
                news.SubNewsTF = 0;
            }
            else
            {
                news.SubNewsTF = new int?(Convert.ToByte(rd["SubNewsTF"]));
            }
            if (rd["URLaddress"] == DBNull.Value)
            {
                news.URLaddress = "";
            }
            else
            {
                news.URLaddress = Convert.ToString(rd["URLaddress"]);
            }
            if (rd["PicURL"] == DBNull.Value)
            {
                news.PicURL = "";
            }
            else
            {
                news.PicURL = Convert.ToString(rd["PicURL"]);
            }
            if (rd["SPicURL"] == DBNull.Value)
            {
                news.SPicURL = "";
            }
            else
            {
                news.SPicURL = Convert.ToString(rd["SPicURL"]);
            }
            news.ClassID = Convert.ToString(rd["ClassID"]);
            if (rd["SpecialID"] == DBNull.Value)
            {
                news.SpecialID = "";
            }
            else
            {
                news.SpecialID = Convert.ToString(rd["SpecialID"]);
            }
            if (rd["Author"] == DBNull.Value)
            {
                news.Author = "";
            }
            else
            {
                news.Author = Convert.ToString(rd["Author"]);
            }
            if (rd["Souce"] == DBNull.Value)
            {
                news.Souce = "";
            }
            else
            {
                news.Souce = Convert.ToString(rd["Souce"]);
            }
            if (rd["Tags"] == DBNull.Value)
            {
                news.Tags = "";
            }
            else
            {
                news.Tags = Convert.ToString(rd["Tags"]);
            }
            news.NewsProperty = Convert.ToString(rd["NewsProperty"]);
            news.NewsPicTopline = Convert.ToByte(rd["NewsPicTopline"]);
            if (rd["Templet"] == DBNull.Value)
            {
                news.Templet = "";
            }
            else
            {
                news.Templet = Convert.ToString(rd["Templet"]);
            }
            if (rd["Content"] == DBNull.Value)
            {
                news.Content = "";
            }
            else
            {
                news.Content = Convert.ToString(rd["Content"]);
            }
            if (rd["Metakeywords"] == DBNull.Value)
            {
                news.Metakeywords = "";
            }
            else
            {
                news.Metakeywords = Convert.ToString(rd["Metakeywords"]);
            }
            if (rd["Metadesc"] == DBNull.Value)
            {
                news.Metadesc = "";
            }
            else
            {
                news.Metadesc = Convert.ToString(rd["Metadesc"]);
            }
            if (rd["naviContent"] == DBNull.Value)
            {
                news.naviContent = "";
            }
            else
            {
                news.naviContent = Convert.ToString(rd["naviContent"]);
            }
            news.Click = Convert.ToInt32(rd["Click"]);
            news.CreatTime = Convert.ToDateTime(rd["CreatTime"]);
            if (rd["EditTime"] == DBNull.Value)
            {
                news.EditTime = new DateTime?(Convert.ToDateTime(rd["CreatTime"]));
            }
            else
            {
                news.EditTime = new DateTime?(Convert.ToDateTime(rd["EditTime"]));
            }
            if (rd["SavePath"] == DBNull.Value)
            {
                news.SavePath = "";
            }
            else
            {
                news.SavePath = Convert.ToString(rd["SavePath"]);
            }
            news.FileName = Convert.ToString(rd["FileName"]);
            news.FileEXName = Convert.ToString(rd["FileEXName"]);
            news.isDelPoint = Convert.ToByte(rd["isDelPoint"]);
            news.Gpoint = Convert.ToInt32(rd["Gpoint"]);
            news.iPoint = Convert.ToInt32(rd["iPoint"]);
            if (rd["GroupNumber"] == DBNull.Value)
            {
                news.GroupNumber = "";
            }
            else
            {
                news.GroupNumber = Convert.ToString(rd["GroupNumber"]);
            }
            news.ContentPicTF = Convert.ToByte(rd["ContentPicTF"]);
            if (rd["ContentPicURL"] == DBNull.Value)
            {
                news.ContentPicURL = "";
            }
            else
            {
                news.ContentPicURL = Convert.ToString(rd["ContentPicURL"]);
            }
            if (rd["ContentPicSize"] == DBNull.Value)
            {
                news.ContentPicSize = "";
            }
            else
            {
                news.ContentPicSize = Convert.ToString(rd["ContentPicSize"]);
            }
            news.CommTF = Convert.ToByte(rd["CommTF"]);
            news.DiscussTF = Convert.ToByte(rd["DiscussTF"]);
            news.TopNum = Convert.ToInt32(rd["TopNum"]);
            news.VoteTF = Convert.ToByte(rd["VoteTF"]);
            if (rd["CheckStat"] == DBNull.Value)
            {
                news.CheckStat = "";
            }
            else
            {
                news.CheckStat = Convert.ToString(rd["CheckStat"]);
            }
            news.isLock = Convert.ToByte(rd["isLock"]);
            news.isRecyle = Convert.ToByte(rd["isRecyle"]);
            news.SiteID = Convert.ToString(rd["SiteID"]);
            news.DataLib = Convert.ToString(rd["DataLib"]);
            if (rd["DefineID"] == DBNull.Value)
            {
                news.DefineID = 0;
            }
            else
            {
                news.DefineID = new int?(Convert.ToByte(rd["DefineID"]));
            }
            news.isVoteTF = Convert.ToByte(rd["isVoteTF"]);
            if (rd["Editor"] == DBNull.Value)
            {
                news.Editor = "";
            }
            else
            {
                news.Editor = Convert.ToString(rd["Editor"]);
            }
            news.isHtml = Convert.ToByte(rd["isHtml"]);
            news.isConstr = Convert.ToByte(rd["isConstr"]);
            if (rd["isFiles"] == DBNull.Value)
            {
                news.isFiles = 0;
            }
            else
            {
                news.isFiles = new int?(Convert.ToByte(rd["isFiles"]));
            }
            if (rd["vURL"] == DBNull.Value)
            {
                news.vURL = "";
            }
            else
            {
                news.vURL = Convert.ToString(rd["vURL"]);
            }
            rd.Close();
            return news;
        }

        public static void DisposeSystemCatch()
        {
            NewsClass.Clear();
            NewsSpecial.Clear();
            CHClass.Clear();
            CHSpecial.Clear();
            CustomLabel._lableTableInfo.Clear();
            if (NewsInfoList != null)
            {
                NewsInfoList.Clear();
                NewsInfoList.Dispose();
            }
        }

        public static PubCHClassInfo GetCHClassById(int ID)
        {
            CHClass = (CHClass.Count == 0) ? DalPublish.GetCHClassList() : CHClass;
            foreach (PubCHClassInfo info in CHClass)
            {
                if (info.Id.Equals(ID))
                {
                    return info;
                }
            }
            return null;
        }

        public static PubCHSpecialInfo GetCHSpecial(int ID)
        {
            CHSpecial = (CHSpecial.Count == 0) ? DalPublish.GetCHSpecialList() : CHSpecial;
            foreach (PubCHSpecialInfo info in CHSpecial)
            {
                if (info.Id.Equals(ID))
                {
                    return info;
                }
            }
            return null;
        }

        public static PubClassInfo GetClassById(string ClassId)
        {
            NewsClass = (NewsClass.Count == 0) ? DalPublish.GetClassList() : NewsClass;
            foreach (PubClassInfo info2 in NewsClass)
            {
                if (info2.ClassID.Equals(ClassId))
                {
                    return info2;
                }
            }
            return null;
        }

        public static PubClassInfo GetClassByParentId(string parentId)
        {
            NewsClass = (NewsClass.Count == 0) ? DalPublish.GetClassList() : NewsClass;
            foreach (PubClassInfo info2 in NewsClass)
            {
                if (info2.ParentID.Equals(parentId))
                {
                    return info2;
                }
            }
            return null;
        }

        public static string getClassURL(string ClassID)
        {
            Initialize();
            PubClassInfo classById = GetClassById(ClassID);
            string str = "";
            try
            {
                return getClassURL(classById.Domain, classById.isDelPoint, classById.ClassID, classById.SavePath, classById.SaveClassframe, classById.ClassSaveRule);
            }
            catch (Exception)
            {
                return str;
            }
        }

        public static string getClassURL(string Domain, int isDelPoint, string ClassID, string SavePath, string SaveClassframe, string ClassSaveRule)
        {
            Initialize();
            string str = "";
            if (Domain.Length > 5)
            {
                if (Public.readparamConfig("ReviewType") == "1")
                {
                    str = "/list-" + ClassID + UIConfig.extensions;
                    return (SiteDomain + str.Replace("//", "/"));
                }
                if (isDelPoint != 0)
                {
                    str = "/list-" + ClassID + UIConfig.extensions;
                    return (SiteDomain + str.Replace("//", "/"));
                }
                str = "/" + ClassSaveRule;
                return (Domain + str.Replace("//", "/"));
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
                str = "/" + SavePath + "/" + SaveClassframe + "/" + ClassSaveRule;
            }
            return (SiteDomain + str.Replace("//", "/")).TrimEnd(new char[] { '/' });
        }

        public static News getNewsInfoById(int id)
        {
            if ((NewsInfoList == null) || (NewsInfoList.Columns.Count == 0))
            {
                _SetDataTableFrame();
            }
            lock (NewsInfoList)
            {
                DataView view = new DataView(NewsInfoList, "ID='" + id + "'", "ID", DataViewRowState.CurrentRows);
                if (view.Count == 0)
                {
                    IDataReader newsDetail = DalPublish.GetNewsDetail(id, "");
                    newsDetail.Read();
                    _setNewsInfoDataRow(newsDetail);
                    return _setNewsInfos(newsDetail);
                }
                DataRowView rd = view[0];
                return _setNewsInfos(rd);
            }
        }

        public static News getNewsInfoById(string newsID)
        {
            if ((NewsInfoList == null) || (NewsInfoList.Columns.Count == 0))
            {
                _SetDataTableFrame();
            }
            lock (NewsInfoList)
            {
                DataView view = new DataView(NewsInfoList, "NewsID='" + newsID + "'", "NewsID", DataViewRowState.CurrentRows);
                if (view.Count == 0)
                {
                    IDataReader newsDetail = DalPublish.GetNewsDetail(0, newsID);
                    newsDetail.Read();
                    _setNewsInfoDataRow(newsDetail);
                    return _setNewsInfos(newsDetail);
                }
                DataRowView rd = view[0];
                return _setNewsInfos(rd);
            }
        }

        public static string getNewsURL(string isDelPoint, string NewsID, string SavePath, string SaveClassframe, string FileName, string FileEXName)
        {
            Initialize();
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
            return (SiteDomain + str.Replace("//", "/"));
        }

        public static string getNewsURLFormID(string NewsID, string DataLib)
        {
            string str = "";
            string str2 = Public.readparamConfig("ReviewType");
            IDataReader newsInfoAndClassInfo = DalPublish.GetNewsInfoAndClassInfo(NewsID, DataLib);
            if (newsInfoAndClassInfo.Read())
            {
                if (newsInfoAndClassInfo["NewsType"].ToString() == "2")
                {
                    str = newsInfoAndClassInfo["URLaddress"].ToString();
                }
                else
                {
                    if (newsInfoAndClassInfo["isDelPoint"].ToString() != "0")
                    {
                        str = "/Content-" + NewsID + UIConfig.extensions;
                    }
                    else if (str2 == "1")
                    {
                        str = "/Content-" + NewsID + UIConfig.extensions;
                    }
                    else
                    {
                        str = string.Concat(new object[] { newsInfoAndClassInfo["SavePath1"].ToString(), "/", newsInfoAndClassInfo["SaveClassframe"], "/", newsInfoAndClassInfo["SavePath"].ToString(), "/", newsInfoAndClassInfo["FileName"].ToString(), newsInfoAndClassInfo["FileEXName"].ToString() });
                    }
                    str = str.Replace("//", "/");
                    str = SiteDomain + str;
                }
            }
            newsInfoAndClassInfo.Close();
            return str;
        }

        public static PubSpecialInfo GetSpecial(string specialid)
        {
            NewsSpecial = (NewsSpecial.Count == 0) ? DalPublish.GetSpecialList() : NewsSpecial;
            if (string.IsNullOrEmpty(specialid))
            {
                return new PubSpecialInfo();
            }
            string[] strArray = specialid.Split(new char[] { ',' });
            PubSpecialInfo info = null;
            bool flag = false;
            foreach (PubSpecialInfo info2 in NewsSpecial)
            {
                foreach (string str in strArray)
                {
                    if (info2.SpecialID.Equals(str))
                    {
                        info = info2;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    return info;
                }
            }
            return info;
        }

        public static PubSpecialInfo GetSpecialByParentId(string parentId)
        {
            NewsSpecial = (NewsSpecial.Count == 0) ? DalPublish.GetSpecialList() : NewsSpecial;
            foreach (PubSpecialInfo info2 in NewsSpecial)
            {
                if (info2.ParentID.Equals(parentId))
                {
                    return info2;
                }
            }
            return null;
        }

        public static PubSpecialInfo GetSpecialForNewsID(string NewsID)
        {
            return DalPublish.GetSpecialForNewsID(NewsID);
        }

        public static void Initialize()
        {
            NewsClass.Clear();
            NewsClass = (NewsClass.Count == 0) ? DalPublish.GetClassList() : NewsClass;
            NewsSpecial = (NewsSpecial.Count == 0) ? DalPublish.GetSpecialList() : NewsSpecial;
            NewsInfoList = ((NewsInfoList == null) || (NewsInfoList.Rows.Count == 0)) ? DalPublish.GetNewsListByAll("''") : NewsInfoList;
            if (NewsJsList == null)
            {
                NewsJsList = new DataTable();
                NewsJsList.Columns.Add("JsID", typeof(string));
                NewsJsList.Columns.Add("jssavepath", typeof(string));
                NewsJsList.Columns.Add("jsfilename", typeof(string));
            }
        }
    }
}


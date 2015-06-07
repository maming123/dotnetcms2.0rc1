using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Foosun.Config;
using Foosun.IDAL;
using Foosun.DALProfile;
using Foosun.Model;

namespace Foosun.SQLServerDAL
{
    public class Publish : DbBase, IPublish, IDisposable
    {
        public IDataReader GetSysParam()
        {
            string Sql = "select top 1 LinkType,SiteDomain,SaveIndexPage,SiteName,CopyRight from " + Pre + "sys_param order by id desc";
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        public IList<PubClassInfo> GetClassList()
        {
            IList<PubClassInfo> list = new List<PubClassInfo>();
            string Sql = "select Id,ClassID,ClassCName,ClassEName,ParentID,[Domain],IsURL,URLaddress,ClassTemplet,SavePath,SaveClassframe,ClassSaveRule";
            Sql += ",ClassIndexRule,SiteID,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,NaviShowtf,NaviPosition,NewsPosition,isPage,PageContent";
            Sql += " from " + Pre + "news_Class where isRecyle=0 and isLock=0 order by OrderID desc,id desc";
            IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            while (rd.Read())
            {
                PubClassInfo info = new PubClassInfo();
                info.Id = (int)rd["Id"];
                info.ClassID = rd["ClassID"].ToString();
                if (rd["ClassCName"] != DBNull.Value) info.ClassCName = rd["ClassCName"].ToString();
                if (rd["ClassEName"] != DBNull.Value) info.ClassEName = rd["ClassEName"].ToString();
                if (rd["ParentID"] != DBNull.Value) info.ParentID = rd["ParentID"].ToString();
                if (rd["IsURL"] != DBNull.Value) info.IsURL = Convert.ToInt32(rd["IsURL"].ToString());
                if (rd["URLaddress"] != DBNull.Value) info.URLaddress = rd["URLaddress"].ToString();
                if (rd["ClassTemplet"] != DBNull.Value) info.ClassTemplet = rd["ClassTemplet"].ToString();
                if (rd["SavePath"] != DBNull.Value) info.SavePath = rd["SavePath"].ToString();
                if (rd["Domain"] != DBNull.Value) info.Domain = rd["Domain"].ToString();
                if (rd["SaveClassframe"] != DBNull.Value) info.SaveClassframe = rd["SaveClassframe"].ToString();
                if (rd["ClassSaveRule"] != DBNull.Value) info.ClassSaveRule = rd["ClassSaveRule"].ToString();
                if (rd["ClassIndexRule"] != DBNull.Value) info.ClassIndexRule = rd["ClassIndexRule"].ToString();
                if (rd["SiteID"] != DBNull.Value) info.SiteID = rd["SiteID"].ToString();
                if (rd["NaviPIC"] != DBNull.Value) info.NaviPIC = rd["NaviPIC"].ToString();
                if (rd["NaviContent"] != DBNull.Value) info.NaviContent = rd["NaviContent"].ToString();
                if (rd["MetaKeywords"] != DBNull.Value) info.MetaKeywords = rd["MetaKeywords"].ToString();
                if (rd["MetaDescript"] != DBNull.Value) info.MetaDescript = rd["MetaDescript"].ToString();
                if (rd["isDelPoint"] != DBNull.Value) info.isDelPoint = Convert.ToInt32(rd["isDelPoint"].ToString());
                if (rd["Gpoint"] != DBNull.Value) info.Gpoint = Convert.ToInt32(rd["Gpoint"].ToString());
                if (rd["iPoint"] != DBNull.Value) info.iPoint = Convert.ToInt32(rd["iPoint"].ToString());
                if (rd["GroupNumber"] != DBNull.Value) info.GroupNumber = rd["GroupNumber"].ToString();
                if (rd["NaviPosition"] != DBNull.Value) info.NaviPosition = rd["NaviPosition"].ToString();
                if (rd["NewsPosition"] != DBNull.Value) info.NewsPosition = rd["NewsPosition"].ToString();
                if (rd["isPage"] != DBNull.Value) info.isPage = Convert.ToInt32(rd["isPage"].ToString());
                if (rd["NaviShowtf"] != DBNull.Value) info.NaviShowtf = Convert.ToInt32(rd["NaviShowtf"].ToString());
                if (rd["PageContent"] != DBNull.Value) info.PageContent = rd["PageContent"].ToString();
                list.Add(info);
            }
            rd.Close();
            return list;
        }
        /// <summary>
        /// 获取某个栏目的信息
        /// </summary>
        /// <param name="ClassID">栏目编号</param>
        /// <returns>栏目的信息</returns>
        public PubClassInfo GetClassById(string ClassID)
        {
            try
            {
                string Sql = "select Id,ClassID,ClassCName,ClassEName,ParentID,[Domain],IsURL,URLaddress,ClassTemplet,SavePath,SaveClassframe,ClassSaveRule";
                Sql += ",ClassIndexRule,SiteID,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,NaviShowtf,NaviPosition,NewsPosition,isPage";
                Sql += " from " + Pre + "news_Class where isRecyle=0 and isLock=0 and ClassID='" + ClassID + "'";
                IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);

                PubClassInfo info = new PubClassInfo();
                if (rd.Read())
                {
                    info.Id = (int)rd["Id"];
                    info.ClassID = rd["ClassID"].ToString();
                    if (rd["ClassCName"] != DBNull.Value) info.ClassCName = rd["ClassCName"].ToString();
                    if (rd["ClassEName"] != DBNull.Value) info.ClassEName = rd["ClassEName"].ToString();
                    if (rd["ParentID"] != DBNull.Value) info.ParentID = rd["ParentID"].ToString();
                    if (rd["IsURL"] != DBNull.Value) info.IsURL = Convert.ToInt32(rd["IsURL"].ToString());
                    if (rd["URLaddress"] != DBNull.Value) info.URLaddress = rd["URLaddress"].ToString();
                    if (rd["ClassTemplet"] != DBNull.Value) info.ClassTemplet = rd["ClassTemplet"].ToString();
                    if (rd["SavePath"] != DBNull.Value) info.SavePath = rd["SavePath"].ToString();
                    if (rd["Domain"] != DBNull.Value) info.Domain = rd["Domain"].ToString();
                    if (rd["SaveClassframe"] != DBNull.Value) info.SaveClassframe = rd["SaveClassframe"].ToString();
                    if (rd["ClassSaveRule"] != DBNull.Value) info.ClassSaveRule = rd["ClassSaveRule"].ToString();
                    if (rd["ClassIndexRule"] != DBNull.Value) info.ClassIndexRule = rd["ClassIndexRule"].ToString();
                    if (rd["SiteID"] != DBNull.Value) info.SiteID = rd["SiteID"].ToString();
                    if (rd["NaviPIC"] != DBNull.Value) info.NaviPIC = rd["NaviPIC"].ToString();
                    if (rd["NaviContent"] != DBNull.Value) info.NaviContent = rd["NaviContent"].ToString();
                    if (rd["MetaKeywords"] != DBNull.Value) info.MetaKeywords = rd["MetaKeywords"].ToString();
                    if (rd["MetaDescript"] != DBNull.Value) info.MetaDescript = rd["MetaDescript"].ToString();
                    if (rd["isDelPoint"] != DBNull.Value) info.isDelPoint = Convert.ToInt32(rd["isDelPoint"].ToString());
                    if (rd["Gpoint"] != DBNull.Value) info.Gpoint = Convert.ToInt32(rd["Gpoint"].ToString());
                    if (rd["iPoint"] != DBNull.Value) info.iPoint = Convert.ToInt32(rd["iPoint"].ToString());
                    if (rd["GroupNumber"] != DBNull.Value) info.GroupNumber = rd["GroupNumber"].ToString();
                    if (rd["NaviPosition"] != DBNull.Value) info.NaviPosition = rd["NaviPosition"].ToString();
                    if (rd["NewsPosition"] != DBNull.Value) info.NewsPosition = rd["NewsPosition"].ToString();
                    if (rd["isPage"] != DBNull.Value) info.isPage = Convert.ToInt32(rd["isPage"].ToString());
                    if (rd["NaviShowtf"] != DBNull.Value) info.NaviShowtf = Convert.ToInt32(rd["NaviShowtf"].ToString());
                }
                rd.Close();
                return info;
            }
            catch
            {
                return null;
            }
        }
        public IList<PubCHClassInfo> GetCHClassList()
        {
            IList<PubCHClassInfo> list = new List<PubCHClassInfo>();
            string Sql = "select Id,ClassCName,ClassEName,ParentID,Templet,SavePath,FileName";
            Sql += ",ChID,PicURL,NaviContent,KeyMeta,DescMeta,isDelPoint,Gpoint,iPoint,GroupNumber,ClassNavi,ContentNavi,isPage";
            Sql += " from " + Pre + "sys_channelclass where isLock=0";
            IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            while (rd.Read())
            {
                PubCHClassInfo info = new PubCHClassInfo();
                info.Id = (int)rd["Id"];
                if (rd["classCName"] != DBNull.Value) info.classCName = rd["classCName"].ToString();
                if (rd["classEName"] != DBNull.Value) info.classEName = rd["classEName"].ToString();
                if (rd["ParentID"] != DBNull.Value) info.ParentID = Convert.ToInt32(rd["ParentID"].ToString());
                if (rd["Templet"] != DBNull.Value) info.Templet = rd["Templet"].ToString();
                if (rd["SavePath"] != DBNull.Value) info.SavePath = rd["SavePath"].ToString();
                if (rd["FileName"] != DBNull.Value) info.FileName = rd["FileName"].ToString();
                if (rd["ChID"] != DBNull.Value) info.ChID = Convert.ToInt32(rd["ChID"].ToString());
                if (rd["PicURL"] != DBNull.Value) info.PicURL = rd["PicURL"].ToString();
                if (rd["NaviContent"] != DBNull.Value) info.NaviContent = rd["NaviContent"].ToString();
                if (rd["KeyMeta"] != DBNull.Value) info.MetaKeywords = rd["KeyMeta"].ToString();
                if (rd["DescMeta"] != DBNull.Value) info.MetaDescript = rd["DescMeta"].ToString();
                if (rd["isDelPoint"] != DBNull.Value) info.isDelPoint = Convert.ToInt32(rd["isDelPoint"].ToString());
                if (rd["Gpoint"] != DBNull.Value) info.Gpoint = Convert.ToInt32(rd["Gpoint"].ToString());
                if (rd["iPoint"] != DBNull.Value) info.iPoint = Convert.ToInt32(rd["iPoint"].ToString());
                if (rd["GroupNumber"] != DBNull.Value) info.GroupNumber = rd["GroupNumber"].ToString();
                if (rd["ClassNavi"] != DBNull.Value) info.ClassNavi = rd["ClassNavi"].ToString();
                if (rd["ContentNavi"] != DBNull.Value) info.ContentNavi = rd["ContentNavi"].ToString();
                if (rd["isPage"] != DBNull.Value) info.isPage = Convert.ToInt32(rd["isPage"].ToString());
                list.Add(info);
            }
            rd.Close();
            return list;
        }

        public IList<PubSpecialInfo> GetSpecialList()
        {
            IList<PubSpecialInfo> list = new List<PubSpecialInfo>();
            string Sql = "select Id,SpecialID,SpecialCName,specialEName,ParentID,isDelPoint,saveDirPath,SavePath,FileName,FileEXName,NaviPicURL,";
            Sql += "NaviContent,SiteID,Templet,NaviPosition,Gpoint,iPoint,GroupNumber";
            Sql += " from " + Pre + "news_special where isRecyle=0 and isLock=0";
            IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            while (rd.Read())
            {
                PubSpecialInfo info = new PubSpecialInfo();
                info.Id = (int)rd["Id"];
                info.SpecialID = rd["SpecialID"].ToString();
                if (rd["SpecialCName"] != DBNull.Value) info.SpecialCName = rd["SpecialCName"].ToString();
                if (rd["specialEName"] != DBNull.Value) info.specialEName = rd["specialEName"].ToString();
                if (rd["ParentID"] != DBNull.Value) info.ParentID = rd["ParentID"].ToString();
                if (rd["isDelPoint"] != DBNull.Value) info.isDelPoint = Convert.ToInt32(rd["isDelPoint"].ToString());
                if (rd["Gpoint"] != DBNull.Value) info.Gpoint = Convert.ToInt32(rd["Gpoint"].ToString());
                if (rd["iPoint"] != DBNull.Value) info.iPoint = Convert.ToInt32(rd["iPoint"].ToString());
                if (rd["GroupNumber"] != DBNull.Value) info.GroupNumber = rd["GroupNumber"].ToString();
                if (rd["saveDirPath"] != DBNull.Value) info.saveDirPath = rd["saveDirPath"].ToString();
                if (rd["SavePath"] != DBNull.Value) info.SavePath = rd["SavePath"].ToString();
                if (rd["FileName"] != DBNull.Value) info.FileName = rd["FileName"].ToString();
                if (rd["FileEXName"] != DBNull.Value) info.FileEXName = rd["FileEXName"].ToString();
                if (rd["NaviPicURL"] != DBNull.Value) info.NaviPicURL = rd["NaviPicURL"].ToString();
                if (rd["NaviContent"] != DBNull.Value) info.NaviContent = rd["NaviContent"].ToString();
                if (rd["SiteID"] != DBNull.Value) info.SiteID = rd["SiteID"].ToString();
                if (rd["Templet"] != DBNull.Value) info.Templet = rd["Templet"].ToString();
                if (rd["NaviPosition"] != DBNull.Value) info.NaviPosition = rd["NaviPosition"].ToString();
                list.Add(info);
            }
            rd.Close();
            return list;
        }
        public PubSpecialInfo GetSpecialForNewsID(string NewsID)
        {
            try
            {
                string Sql = "select a.Id,a.SpecialID,SpecialCName,specialEName,ParentID,isDelPoint,saveDirPath,SavePath,FileName,FileEXName,NaviPicURL,";
                Sql += "NaviContent,SiteID,Templet,NaviPosition,Gpoint,iPoint,GroupNumber";
                Sql += " from " + Pre + "news_special as a,fs_special_news as b where b.SpecialID=a.SpecialID and isRecyle=0 and isLock=0 and b.NewsID='" + NewsID + "'";
                PubSpecialInfo info = new PubSpecialInfo();
                IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
                if (rd.Read())
                {
                    info.Id = (int)rd["Id"];
                    info.SpecialID = rd["SpecialID"].ToString();
                    if (rd["SpecialCName"] != DBNull.Value) info.SpecialCName = rd["SpecialCName"].ToString();
                    if (rd["specialEName"] != DBNull.Value) info.specialEName = rd["specialEName"].ToString();
                    if (rd["ParentID"] != DBNull.Value) info.ParentID = rd["ParentID"].ToString();
                    if (rd["isDelPoint"] != DBNull.Value) info.isDelPoint = Convert.ToInt32(rd["isDelPoint"].ToString());
                    if (rd["Gpoint"] != DBNull.Value) info.Gpoint = Convert.ToInt32(rd["Gpoint"].ToString());
                    if (rd["iPoint"] != DBNull.Value) info.iPoint = Convert.ToInt32(rd["iPoint"].ToString());
                    if (rd["GroupNumber"] != DBNull.Value) info.GroupNumber = rd["GroupNumber"].ToString();
                    if (rd["saveDirPath"] != DBNull.Value) info.saveDirPath = rd["saveDirPath"].ToString();
                    if (rd["SavePath"] != DBNull.Value) info.SavePath = rd["SavePath"].ToString();
                    if (rd["FileName"] != DBNull.Value) info.FileName = rd["FileName"].ToString();
                    if (rd["FileEXName"] != DBNull.Value) info.FileEXName = rd["FileEXName"].ToString();
                    if (rd["NaviPicURL"] != DBNull.Value) info.NaviPicURL = rd["NaviPicURL"].ToString();
                    if (rd["NaviContent"] != DBNull.Value) info.NaviContent = rd["NaviContent"].ToString();
                    if (rd["SiteID"] != DBNull.Value) info.SiteID = rd["SiteID"].ToString();
                    if (rd["Templet"] != DBNull.Value) info.Templet = rd["Templet"].ToString();
                    if (rd["NaviPosition"] != DBNull.Value) info.NaviPosition = rd["NaviPosition"].ToString();
                }
                rd.Close();
                return info;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 取得专题信息
        /// </summary>
        /// <param name="specialID">专题ID</param>
        /// <returns></returns>
        public PubSpecialInfo GetSpecial(string specialID)
        {
            try
            {
                string Sql = "select Id,SpecialID,SpecialCName,specialEName,ParentID,isDelPoint,saveDirPath,SavePath,FileName,FileEXName,NaviPicURL,";
                Sql += "NaviContent,SiteID,Templet,NaviPosition,Gpoint,iPoint,GroupNumber";
                Sql += " from " + Pre + "news_special where isRecyle=0 and isLock=0 and SpecialID='" + specialID + "'";
                PubSpecialInfo info = new PubSpecialInfo();
                IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
                if (rd.Read())
                {
                    info.Id = (int)rd["Id"];
                    info.SpecialID = rd["SpecialID"].ToString();
                    if (rd["SpecialCName"] != DBNull.Value) info.SpecialCName = rd["SpecialCName"].ToString();
                    if (rd["specialEName"] != DBNull.Value) info.specialEName = rd["specialEName"].ToString();
                    if (rd["ParentID"] != DBNull.Value) info.ParentID = rd["ParentID"].ToString();
                    if (rd["isDelPoint"] != DBNull.Value) info.isDelPoint = Convert.ToInt32(rd["isDelPoint"].ToString());
                    if (rd["Gpoint"] != DBNull.Value) info.Gpoint = Convert.ToInt32(rd["Gpoint"].ToString());
                    if (rd["iPoint"] != DBNull.Value) info.iPoint = Convert.ToInt32(rd["iPoint"].ToString());
                    if (rd["GroupNumber"] != DBNull.Value) info.GroupNumber = rd["GroupNumber"].ToString();
                    if (rd["saveDirPath"] != DBNull.Value) info.saveDirPath = rd["saveDirPath"].ToString();
                    if (rd["SavePath"] != DBNull.Value) info.SavePath = rd["SavePath"].ToString();
                    if (rd["FileName"] != DBNull.Value) info.FileName = rd["FileName"].ToString();
                    if (rd["FileEXName"] != DBNull.Value) info.FileEXName = rd["FileEXName"].ToString();
                    if (rd["NaviPicURL"] != DBNull.Value) info.NaviPicURL = rd["NaviPicURL"].ToString();
                    if (rd["NaviContent"] != DBNull.Value) info.NaviContent = rd["NaviContent"].ToString();
                    if (rd["SiteID"] != DBNull.Value) info.SiteID = rd["SiteID"].ToString();
                    if (rd["Templet"] != DBNull.Value) info.Templet = rd["Templet"].ToString();
                    if (rd["NaviPosition"] != DBNull.Value) info.NaviPosition = rd["NaviPosition"].ToString();
                }
                rd.Close();
                return info;
            }
            catch
            {
                return null;
            }

        }
        public IList<PubCHSpecialInfo> GetCHSpecialList()
        {
            IList<PubCHSpecialInfo> list = new List<PubCHSpecialInfo>();
            string Sql = "select Id,ChID,specialCName,specialEName,ParentID,binddomain,navicontent,savePath,filename,templet,";
            Sql += "islock,isRec,PicURL,OrderID,SiteID";
            Sql += " from " + Pre + "sys_channelspecial where isLock=0";
            IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            while (rd.Read())
            {
                PubCHSpecialInfo info = new PubCHSpecialInfo();
                info.Id = (int)rd["Id"];
                info.ChID = Convert.ToInt32(rd["ChID"].ToString());
                if (rd["specialCName"] != DBNull.Value) info.specialCName = rd["specialCName"].ToString();
                if (rd["specialEName"] != DBNull.Value) info.specialEName = rd["specialEName"].ToString();
                if (rd["ParentID"] != DBNull.Value) info.ParentID = Convert.ToInt32(rd["ParentID"].ToString());
                if (rd["binddomain"] != DBNull.Value) info.binddomain = rd["binddomain"].ToString();
                if (rd["navicontent"] != DBNull.Value) info.navicontent = rd["navicontent"].ToString();
                if (rd["savePath"] != DBNull.Value) info.savePath = rd["savePath"].ToString();
                if (rd["filename"] != DBNull.Value) info.filename = rd["filename"].ToString();
                if (rd["templet"] != DBNull.Value) info.templet = rd["templet"].ToString();
                if (rd["islock"] != DBNull.Value) info.islock = Convert.ToInt32(rd["islock"].ToString());
                if (rd["isRec"] != DBNull.Value) info.isRec = Convert.ToInt32(rd["isRec"].ToString());
                if (rd["PicURL"] != DBNull.Value) info.PicURL = rd["PicURL"].ToString();
                if (rd["OrderID"] != DBNull.Value) info.OrderID = Convert.ToInt32(rd["OrderID"].ToString());
                if (rd["SiteID"] != DBNull.Value) info.SiteID = rd["SiteID"].ToString();
                list.Add(info);
            }
            rd.Close();
            return list;
        }

        public DataTable GetLastNews(int topnum, string classid)
        {
            SqlParameter Param = null;
            string Sql = "select top " + topnum + " a.NewsID,a.NewsType,a.isDelPoint, a.NewsTitle,a.sNewsTitle,a.URLaddress,a.Content,a.CreatTime,a.SavePath,a.FileName,a.FileEXName,";
            Sql += "b.savepath as savepath1,b.SaveClassframe,b.ClassEName,b.ClassCName,b.ClassSaveRule from " + Pre + "news a," + Pre + "news_class b";
            Sql += " where a.islock=0  and a.ClassID=b.ClassID and a.isRecyle=0 and b.isPage!=1 and b.islock=0";
            if (classid != "0")
            {
                Sql += " and b.ClassID=@ClassID";
                Param = new SqlParameter("@ClassID", classid);
            }
            Sql += " order by a.id desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
        }
        public DataTable GetTodayNews(string siteid, string classid)
        {
            string Sql = "select NewsType,NewsTitle,URLaddress,SavePath,FileName,FileEXName from " + Pre + "news where ClassID=@ClassID";
            Sql += " And DateDiff(Day,[creatTime] ,Getdate()) = 0 and islock=0 and isRecyle=0 and SiteID=@SiteID order by id desc";
            SqlParameter[] Param = new SqlParameter[]{
                new SqlParameter("@ClassID",classid),
            new SqlParameter("@SiteID",siteid)};
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
        }
        public IDataReader GetSinglePageClass(string classid)
        {
            string Sql = "select ClassTemplet,ClassCName,SavePath,PageContent,MetaKeywords,MetaDescript from " + Pre + "news_class";
            Sql += " where ClassID=@ClassID and isLock=0 and isRecyle=0 and isPage=1";
            SqlParameter Param = new SqlParameter("@ClassID", classid);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }
        public IDataReader GetNewsSavePath(string newsid)
        {
            string Sql = "select a.NewsType,a.URLaddress,a.templet,a.classid,a.datalib,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.NewsID,a.isDelPoint,a.CheckStat from " + Pre + "news a, ";
            Sql += Pre + "news_class b where a.classid=b.classid and a.newsid=@newsid";
            SqlParameter Param = new SqlParameter("@newsid", newsid);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }
        public string GetSysLabelContent(string labelname)
        {
            string Sql = "select Label_Content from " + Pre + "sys_Label where Label_Name=@Label_Name and isBack=0 and isRecyle=0";
            SqlParameter Param = new SqlParameter("@Label_Name", labelname);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }

        /// <summary>
        /// 获取所有标签内容
        /// </summary>
        /// <returns></returns>
        public IDataReader GetSysLabelContentByAll()
        {
            string Sql = "select * from " + Pre + "sys_Label where isBack=0 and isRecyle=0";
            return DbHelper.ExecuteReader(CommandType.Text, Sql);
        }

        /// <summary>
        ///从频道标签库中获取数据
        /// </summary>
        /// <param name="labelname"></param>
        /// <returns></returns>
        public string GetChannelSysLabelContent(string labelname)
        {
            string Sql = "select LabelContent from " + Pre + "sys_channellabel where LabelName=@LabelName and isLock=0";
            SqlParameter Param = new SqlParameter("@LabelName", labelname);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }

        public IDataReader GetFreeLabelContent(string labelname)
        {
            string Sql = "select LabelSQL,StyleContent from " + Pre + "sys_LabelFree where LabelName=@LabelName";
            SqlParameter Param = new SqlParameter("@LabelName", labelname);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }

        public DataTable ExecuteSql(string sql)
        {
            return DbHelper.ExecuteTable(CommandType.Text, sql, null);
        }
        public IDataReader GetTemplatePath()
        {
            string Sql = "select IndexTemplet,IndexFileName,ReadNewsTemplet,ClassListTemplet,SpecialTemplet from " + Pre + "sys_param";
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        #region 选择发布选项部分
        public IDataReader GetPublishSpecial(string spid, out int ncount)
        {
            string SqlCondition = " where isLock=0 and isRecyle=0";
            if (spid != null && spid.Trim() != "")
            {
                SqlCondition = " where specialID in (" + spid + ")";
            }
            string SqlCount = "select count(id) from " + Pre + "news_special" + SqlCondition;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            string Sql = "select specialID,Templet,SavePath,saveDirPath,FileName,FileEXName from " + Pre + "news_special" + SqlCondition;
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        public IDataReader GetPublishClass(string siteid, string classid, bool isflag, out int ncount)
        {
            string SqlCondition = "";
            if (classid.Trim() == "")
            {
                if (isflag)
                {
                    SqlCondition = " where isunHTML !=1 and isPage!=1 and isLock=0 and isRecyle=0 and IsURL=0 and SiteID='" + siteid + "'";
                }
                else
                {
                    SqlCondition = " where isLock=0 and isRecyle=0 and IsURL=0 and isPage!=1 and isLock=0 and SiteID='" + siteid + "'";
                }
            }
            else
            {
                SqlCondition = " where classID in (" + classid + ")";
            }
            string SqlCount = "select count(id) from " + Pre + "news_class" + SqlCondition;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            string Sql = "select Datalib,classtemplet,classid,SavePath,SaveClassframe,ClassSaveRule from " + Pre + "news_class" + SqlCondition;
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        #region 发布新闻
        /// <summary>
        /// 选择发布所有新闻时，取得所有新闻
        /// </summary> 
        /// <param name="strParams">页面信息字符串</param>
        /// <returns>取得符合条件的所有新闻的查询结果</returns>
        public IDataReader GetPublishNewsAll(out int ncount)
        {
            string TopParam = "";
            int refreshNum = int.Parse(Common.Public.readparamConfig("infoNumber", "refresh"));
            if (refreshNum != 0)
            {
                TopParam = "top " + Common.Public.readparamConfig("infoNumber", "refresh") + "";
            }
            string Sql = "select " + TopParam + " a.CommTF,a.templet,a.classid,a.datalib,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.NewsID,a.isDelPoint from " + Pre + "news a left join " + Pre + "news_class b on a.ClassID=b.ClassID where a.isRecyle=0 and a.isLock=0 and a.isDelPoint=0 and a.NewsType!=2";
            string SqlCount = "select count(ID) from " + Pre + "news where isRecyle=0 and isLock=0 and isDelPoint=0 and NewsType!=2";
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            if (refreshNum != 0)
            {
                if (refreshNum < ncount)
                {
                    ncount = refreshNum;
                }
            }
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 选择发布最新时，取得所有新闻
        /// </summary>
        /// <param name="strParams">页面信息字符串</param>
        /// <returns>取得符合条件的所有新闻的查询结果</returns>
        public IDataReader GetPublishNewsLast(int topnum, bool unpublish, out int ncount)
        {
            string Sql = "select top " + topnum + "  a.CommTF,a.templet,a.classid,a.datalib,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.NewsID,a.isDelPoint  from " + Pre + "news a left join " + Pre + "news_class b on a.ClassID=b.ClassID where a.isRecyle=0 and a.isLock=0 and a.isDelPoint=0 and a.NewsType!=2";
            string SqlCount = "select count(ID) from " + Pre + "news where isRecyle=0 and isLock=0 and isDelPoint=0 and NewsType!=2";
            if (unpublish)
            {
                Sql += " and a.isHtml=0";
                SqlCount += " and isHtml=0";
            }
            Sql += " order by a.id desc";
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        #region 根据栏目选择发布的新闻
        /// <summary>
        /// 根据栏目发布新闻
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="unpublish"></param>
        /// <param name="isdesc"></param>
        /// <param name="condition"></param>
        /// <param name="ncount"></param>
        /// <returns></returns>
        public IDataReader GetPublishNewsByClass(string classid, bool unpublish, bool isdesc, string condition, out int ncount)
        {
            string SqlCondition = " where a.isRecyle=0 and a.isLock=0 and a.isDelPoint=0 and a.NewsType!=2 and a.ClassID in (" + classid + ")";
            string SqlOrder = "";
            if (unpublish)
            {
                //只发布未发布的
                SqlCondition += " and a.isHtml=0 ";
            }
            switch (condition)
            {
                #region 条件判断
                case "0":
                    SqlOrder = " order by a.newsID ";
                    break;
                case "1":
                    SqlOrder = " order by a.Click ";
                    break;
                case "2":
                    SqlOrder = " order by a.OrderID ";
                    break;
                case "3":
                    SqlOrder = " order by a.CreatTime ";
                    break;
                case "4":
                    SqlCondition += " and substring(NewsProperty,1,1)='1'";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "5":
                    SqlCondition += " and substring(NewsProperty,3,1)='1'";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "6":
                    SqlCondition += " and substring(NewsProperty,5,1)='1'";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "7":
                    SqlCondition += " and substring(NewsProperty,7,1)='1'";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "8":
                    SqlCondition += " and substring(NewsProperty,9,1)='1'";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "9":
                    SqlCondition += " and substring(NewsProperty,11,1)='1'";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "10":
                    SqlCondition += " and substring(NewsProperty,15,1)='1'";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "11":
                    SqlCondition += " and author!=''";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "12":
                    SqlCondition += " and Souce!=''";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "13":
                    SqlCondition += " and tags!=''";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "14":
                    SqlCondition += " and newstype=1";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "15":
                    SqlCondition += " and isFiles=1";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "16":
                    SqlCondition += " and vURL!=''";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "17":
                    SqlCondition += " and ContentPicTF=1";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "18":
                    SqlCondition += " and VoteTF=1";
                    SqlOrder = " order by a.newsID ";
                    break;
                case "19":
                    SqlCondition += " and (select count(c.id) from " + Pre + "api_commentary c where c.InfoID=a.newsid)>0";
                    SqlOrder = " order by a.newsID";
                    break;
                default:
                    break;
                #endregion 条件判断
            }
            if (isdesc)
            {
                //倒序
                SqlOrder += " desc ";
            }
            string Sql = "select a.CommTF,a.templet,a.classid,a.datalib,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.NewsID,a.isDelPoint from fs_news a left join " + Pre + "news_class b on a.ClassID=b.ClassID " + SqlCondition + SqlOrder;
            string SqlCount = "select count(a.ID) from " + Pre + "news a " + SqlCondition;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        #endregion 根据栏目选择发布的新闻
        /// <summary>
        /// 选择按照日期发布时，取得所有新闻
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="ncount"></param>
        /// <returns></returns>
        public IDataReader GetPublishNewsByTime(DateTime starttime, DateTime endtime, out int ncount)
        {
            string Sql = "select a.CommTF,a.templet,a.classid,a.datalib,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.NewsID,a.isDelPoint from " + Pre + "news a left join " + Pre + "news_class b on a.ClassID=b.ClassID where a.creattime between '" + starttime + "' and '" + endtime + "' and a.isRecyle=0 and a.isLock=0 and a.isDelPoint=0 and a.NewsType!=2";
            string SqlCount = "select count(ID) from " + Pre + "news where creattime between '" + starttime + "' and '" + endtime + "' and isRecyle=0 and isLock=0 and isDelPoint=0 and NewsType!=2";
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 选择按照ID发布时，取得所有新闻
        /// </summary>
        /// <param name="minid"></param>
        /// <param name="maxid"></param>
        /// <param name="ncount"></param>
        /// <returns></returns>
        public IDataReader GetPublishNewsByID(int minid, int maxid, out int ncount)
        {
            string Sql = "select a.CommTF,a.templet,a.classid,a.datalib,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.NewsID,a.isDelPoint  from " + Pre + "news a left join " + Pre + "news_class b on a.ClassID=b.ClassID where a.isRecyle=0 and a.isLock=0 and a.isDelPoint=0 and a.NewsType!=2 and a.id between " + minid + " and " + maxid;
            string SqlCount = "select count(id) from " + Pre + "news where isRecyle=0 and isLock=0 and isDelPoint=0 and NewsType!=2 and id between " + minid + " and " + maxid;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        #endregion 发布新闻
        #endregion 选择发布选项部分
        /*
        public string GetClassIDByAdID(string adid)
        {
            string Sql = "Select [ClassID] From [" + Pre + "ads] Where [AdID]=@AdID";
            SqlParameter Param = new SqlParameter("@AdID", adid);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }*/
        public IDataReader GetJsPath(string jsid)
        {
            string Sql = "Select [jssavepath],[jsfilename],[JsID] From [" + Pre + "news_js] Where [JsID]=@JsID";
            SqlParameter Param = new SqlParameter("@JsID", jsid);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }
        public IDataReader GetsClassInfo(string ClassID)
        {
            SqlParameter param = new SqlParameter("@ClassID", ClassID);
            string sql = "select ID,isDelPoint,ClassID,SavePath,SaveClassFrame,ClassSaveRule,[Domain] from " + Pre + "news_class where ClassID=@ClassID and islock=0 and isRecyle=0";
            return DbHelper.ExecuteReader(CommandType.Text, sql, param);
        }
        public DataTable GetSysUser(int topnum)
        {
            string Sql = "Select Top " + topnum + " [UserName],[RegTime] From [" + Pre + "sys_User] Where [isLock]=0 Order By [RegTime] Desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }
        public DataTable GetApiComm(int LoopNumber)
        {
            string Sql = "Select top " + LoopNumber + " [InfoID],[Commid],[Content],[creatTime],[DataLib] From [" + Pre + "API_commentary] Where [isRecyle]=0 And [islock]=0 And [isCheck]=0 Order By [creatTime] Desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }
        public string GetNewsTag(string newsid)
        {
            string Sql = "Select [Tags] From [" + Pre + "News] Where [NewsID]=@NewsID";
            SqlParameter Param = new SqlParameter("@NewsID", newsid);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }
        public void UpdateNewsIsHtml(string tablename, string ishtml, string idfield, IList<string> succeedlist)
        {
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("@tableName", SqlDbType.VarChar, 30);
            sqlParams[0].Value = tablename;
            sqlParams[1] = new SqlParameter("@filedname", SqlDbType.VarChar, 30);
            sqlParams[1].Value = ishtml;
            sqlParams[2] = new SqlParameter("@idtype", SqlDbType.VarChar, 30);
            sqlParams[2].Value = idfield;
            for (int i = 0; i < succeedlist.Count; i++)
            {
                sqlParams[3] = new SqlParameter("@newsID", SqlDbType.VarChar, 12);
                sqlParams[3].Value = succeedlist[i];
                DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "fs_publish_updateishtml", sqlParams);
            }
        }

        public void UpdateCHNewsIsHtml(string tablename, string ishtml, string idfield, IList<string> succeedlist)
        {
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("@tableName", SqlDbType.VarChar, 30);
            sqlParams[0].Value = tablename;
            sqlParams[1] = new SqlParameter("@filedname", SqlDbType.VarChar, 30);
            sqlParams[1].Value = ishtml;
            sqlParams[2] = new SqlParameter("@idtype", SqlDbType.VarChar, 30);
            sqlParams[2].Value = idfield;
            for (int i = 0; i < succeedlist.Count; i++)
            {
                sqlParams[3] = new SqlParameter("@ID", SqlDbType.Int, 4);
                sqlParams[3].Value = int.Parse(succeedlist[i]);
                DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "fs_publish_CHupdateishtml", sqlParams);
            }
        }

        public IDataReader GetDiscussInfo(string grouptype, int TopNumber)
        {
            string Sql;
            switch (grouptype)
            {
                case "hot":
                    Sql = "Select top " + TopNumber + " [DisID],[Cname],[Creatime],((Select Count([Id]) From [" + Pre + "User_DiscussMember] Where [" + Pre + "User_DiscussMember].[DisID]=[" + Pre + "User_Discuss].[DisID])+Browsenumber) As Cnt1 From [" + Pre + "User_Discuss] Order By Cnt1 Desc";
                    break;
                case "click":
                    Sql = "Select top " + TopNumber + "  [DisID],[Cname],[Creatime],[Browsenumber] From [" + Pre + "User_Discuss] Order By [Browsenumber] Desc";
                    break;
                case "Mmore":
                    Sql = "Select top " + TopNumber + "  [DisID],[Cname],[Creatime],(Select Count([Id]) From [" + Pre + "User_DiscussMember] Where [" + Pre + "User_DiscussMember].[DisID]=[" + Pre + "User_Discuss].[DisID]) As Cnt1 From [" + Pre + "User_Discuss] Order By Cnt1 Desc";
                    break;
                case "Last":
                    Sql = "Select top " + TopNumber + "  [DisID],[Cname],[Creatime] From [" + Pre + "User_Discuss] Order By [Creatime] Desc";
                    break;
                default:
                    Sql = "Select top " + TopNumber + "  [DisID],[Cname],[Creatime] From [" + Pre + "User_Discuss] Order By [Creatime] Desc";
                    break;
            }
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }
        public string GetMetaContent(string id, string Str, int num)
        {
            string Sql = "";
            //DataRow rowObj = null;
            switch (Str)
            {
                case "News":
                    if (num == 0)
                    {
                        Sql = "select top 1 Metakeywords from " + Pre + "news where NewsID=@ID";
                    }
                    else
                        Sql = "select top 1 Metadesc from " + Pre + "news where NewsID=@ID";
                    break;
                case "Class":
                    if (num == 0)
                        Sql = "select top 1 MetaKeywords from " + Pre + "news_class where ClassID=@ID";
                    else
                        Sql = "select top 1 MetaDescript from " + Pre + "news_class where ClassID=@ID";
                    break;
                case "Special":
                    Sql = "select top 1 SpecialCName from " + Pre + "news_special where SpecialID=@ID";
                    break;
            }
            if (Sql != "")
            {
                SqlParameter Param = new SqlParameter("@ID", id);
                return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
            }
            else
                return "";
        }
        public string GetPageTitle(string id, string Str)
        {
            string Sql = "";
            switch (Str)
            {
                case "News":
                    Sql = "select top 1 NewsTitle from " + Pre + "news where NewsID=@ID";
                    break;
                case "Class":
                    Sql = "select top 1 ClassCName from " + Pre + "news_class where ClassID=@ID";
                    break;
                case "Special":
                    Sql = "select top 1 SpecialCName from " + Pre + "news_special where SpecialID=@ID";
                    break;
            }
            if (Sql != "")
            {
                SqlParameter Param = new SqlParameter("@ID", id);
                return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
            }
            else
                return "";
        }
        public IDataReader GetNewsFiles(string newsid)
        {
            string Sql = "select id,URLName,FileURL from " + Pre + "news_URL where [NewsID]=@NewsID order by orderid desc";
            SqlParameter Param = new SqlParameter("@NewsID", newsid);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }
        public IDataReader GetPrePage(int id, string datalib, int num, string classid, int ChID)
        {
            if (ChID == 0)
            {
                string Sql = "select top 1 a.NewsType,a.URLaddress,a.newsID,a.NewsTitle,a.SavePath,a.FileName,a.FileEXName,b.savepath as savepath1,b.SaveClassframe,a.isDelPoint from " + Pre + "news a," + Pre + "news_class b where a.id";
                if (num == 0)
                    Sql += ">";
                else
                    Sql += "<";
                Sql += id + " and a.CLassID=@ClassID and a.ClassID=b.ClassID and a.NewsType<>2 and a.islock=0 and a.isRecyle=0 order by a.id";
                if (num == 0)
                    Sql += " asc";
                else
                    Sql += " desc";
                SqlParameter Param = new SqlParameter("@ClassID", classid);
                return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
            }
            else
            {
                string csql = "select top 1 a.NewsType,a.URLaddress,a.id,a.Title,a.SavePath,a.FileName,b.SavePath as savepath1,a.isDelPoint from " + datalib + " a," + Pre + "sys_channelclass b where a.id";
                if (num == 0)
                    csql += ">";
                else
                    csql += "<";
                csql += id + " and a.CLassID=@ID and a.ClassID=b.id and a.islock=0 order by a.id";
                if (num == 0)
                    csql += " asc";
                else
                    csql += " desc";
                SqlParameter Param1 = new SqlParameter("@ID", int.Parse(classid));
                return DbHelper.ExecuteReader(CommandType.Text, csql, Param1);
            }
        }

        public IDataReader GetNewsInfoAndClassInfo(string NewsID, string DataLib)
        {
            string Sql = "select a.SavePath,a.FileName,a.FileEXName,a.NewsType,a.URLaddress,a.isDelPoint,b.SavePath as SavePath1,b.SaveClassframe from " + Pre + "news a," + Pre + "news_class b where a.NewsID=@NewsID and a.ClassID=b.ClassID and a.isLock=0 and a.isRecyle=0";
            SqlParameter Param = new SqlParameter("@NewsID", NewsID);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }

        public int GetCommCount(string newsid, int td, int ChID)
        {
            string WhereStr = string.Empty;
            if (ChID != 0)
            {
                WhereStr = " and ChID=" + ChID + "";
            }
            string Sql = "Select Count(ID) From [" + Pre + "api_commentary] Where [InfoID]=@NewsID and islock=0" + WhereStr;
            if (td == 1)
            {
                Sql += " And DateDiff(Day,[creatTime] ,Getdate())=0";
            }
            SqlParameter Param = new SqlParameter("@NewsID", newsid);
            return Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }
        public string GetStyleContent(string styleid)
        {
            string Sql = "select [Content] from " + Pre + "sys_LabelStyle where styleID=@styleID and isRecyle=0";
            SqlParameter Param = new SqlParameter("@styleID", styleid);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }

        public string GetCHStyleContent(int ID, int ChID)
        {
            string Sql = "select [styleContent] from " + Pre + "sys_channelstyle where id=@ID and isLock=0 and ChID=" + ChID + "";
            SqlParameter Param = new SqlParameter("@ID", ID);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }

        public IDataReader GetNaviShowClass(string parentid)
        {
            string Sql = "select [ClassID],[ClassCName],[ParentID],[ClassSaveRule],[SaveClassFrame],[SavePath],[isDelPoint],[Domain] from " + Pre + "News_Class where ParentID=@ParentID and isLock=0 and isRecyle=0 and NaviShowtf=1 order by orderid desc,id desc";
            SqlParameter Param = new SqlParameter("@ParentID", parentid);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }

        public DataTable Gethistory(int Numday)
        {
            string Sql = "select * from " + Pre + "old_news where DateDiff(Day,[oldtime] ,Getdate()) = " + Numday + " and isLock=0 and isRecyle=0 order by orderid desc,id desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        public DataTable Gethistory(string Strday)
        {
            string Sql = "select * from " + Pre + "old_news where DateDiff(Day,[oldtime],'" + Convert.ToDateTime(Strday) + "')=0  and isLock=0 and isRecyle=0 order by orderid desc,id desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        public DataTable GetHistoryContent(string historyId)
        {
            string sqlText = "select * from " + Pre + "old_news where NewsID=@NewsID and isRecyle=0 and isLock=0";
            return DbHelper.ExecuteTable(CommandType.Text, sqlText, new SqlParameter { ParameterName = "NewsID", Value = historyId });
        }

        public DataTable GetTopLine(string newsid)
        {
            SqlParameter Param = null;
            string Sql = "select top 1 NewsID,tl_SavePath from " + DBConfig.TableNamePrefix + "news_topline ";
            if (newsid != null && newsid != "")
            {
                Sql += " where NewsID=@NewsID";
                Param = new SqlParameter("@NewsID", newsid);
            }
            else
            {
                Sql += " order by Id desc";
            }
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);

        }

        public DataTable GetPosition(string ID, int Num)
        {
            SqlParameter param = new SqlParameter("@ID", ID);
            string sql = string.Empty;
            if (Num == 0)
            {
                sql = "select * from " + Pre + "news_class where ClassID=@ID";
            }
            else
            {
                sql = "select * from " + Pre + "news_special where SpecialID=@ID";
            }
            return DbHelper.ExecuteTable(CommandType.Text, sql, param);
        }



        public IDataReader GetNewsDetail(int id, string newsid)
        {
            SqlParameter Param = null;
            string Sql = "Select [Id],[NewsID],[NewsType],[OrderID],[NewsTitle],[sNewsTitle],[TitleColor],[TitleITF],[TitleBTF],[CommLinkTF],";
            Sql += "[SubNewsTF],[URLaddress],[PicURL],[SPicURL],[ClassID],[SpecialID],[Author],[Souce],[Tags],[NewsProperty],[NewsPicTopline],";
            Sql += "[Templet],[Content],[Metakeywords],[Metadesc],[naviContent],[Click],[CreatTime],[EditTime],[SavePath],[FileName],";
            Sql += "[FileEXName],[isDelPoint],[Gpoint],[iPoint],[GroupNumber],[ContentPicTF],[ContentPicURL],[ContentPicSize],[CommTF],";
            Sql += "[DiscussTF],[TopNum],[VoteTF],[CheckStat],[isLock],[isRecyle],[SiteID],[DataLib],[DefineID],[isVoteTF],[Editor],[isHtml],";
            Sql += "[isConstr],[isFiles],[vURL] From [" + Pre + "News]";
            if (id > 0)
            {
                Sql += " Where ID=" + id;
            }
            else
            {
                Sql += " Where [NewsID]=@NewsID";
                Param = new SqlParameter("@NewsID", newsid);
            }
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }

        public string GetClassIDByNewsID(string newsid)
        {
            string Sql = "Select [ClassID] From " + DBConfig.TableNamePrefix + "news Where [NewsID]=@NewsID";
            SqlParameter Param = new SqlParameter("@NewsID", newsid);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }

        public IDataReader GetTopUser(int topnum, string orderfld)
        {
            string Sql = "Select Top " + topnum + " [NickName],[UserName],[iPoint],[gPoint],[ePoint],[RegTime],(Select Count(*) From [" + Pre + "User_Constr] Where [" + Pre + "sys_User].UserNum=[" + Pre + "User_Constr].UserNum) Cnt From [" + Pre + "sys_User] Where [isLock]=0";
            switch (orderfld)
            {
                case "iPoint":
                    Sql += " Order By [iPoint] Desc,[ID] Desc";
                    break;
                case "gPoint":
                    Sql += " Order By [gPoint] Desc,[ID] Desc";
                    break;
                case "ePoint":
                    Sql += " Order By [ePoint] Desc,[ID] Desc";
                    break;
                case "Cnt":
                    Sql += "Order By [Cnt] Desc,[ID] Desc";
                    break;
                default:
                    Sql += " Order By [RegTime] Desc,[ID] Desc";
                    break;
            }
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }

        public DataTable GetUnRule(string UnID, string SiteID)
        {
            string Sql = string.Empty;
            if (UnID != "0")
            {
                Sql = "Select [unName],[TitleCSS],[SubCSS],[ONewsID],[Rows],[unTitle],[NewsTable] From [" + Pre + "news_unNews] Where [UnID]=@UnID And [SiteID]=@SiteID Order By [Rows] Asc,[ID] asc";
            }
            else
            {
                Sql = "Select [unName],[TitleCSS],[SubCSS],[ONewsID],[Rows],[unTitle],[NewsTable] From [" + Pre + "news_unNews] Where [UnID] in (select top 1 UnID from [" + Pre + "news_unNews] order by id desc) [SiteID]=@SiteID Order By [Rows] Asc,[ID] asc";
            }
            SqlParameter[] Param = new SqlParameter[] { new SqlParameter("@UnID", UnID), new SqlParameter("@SiteID", SiteID) };
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
        }

        public DataTable GetSubUnRule(string NewsID)
        {
            string Sql = "Select ID,getNewsID,NewsTitle,DataLib,TitleCSS,colsNum,SiteID,CreatTime From [" + Pre + "news_sub] Where [NewsID]=@NewsID Order By [colsNum] Asc,[ID] asc";
            SqlParameter[] Param = new SqlParameter[] { new SqlParameter("@NewsID", NewsID) };
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
        }

        public DataTable GetSubClass(string ClassID, int isParent, string OrderBy, string Desc)
        {
            SqlParameter Param = new SqlParameter("@ClassID", ClassID);
            string Sql = string.Empty;
            if (isParent == 1)
            {
                Sql = "Select ClassID From [" + Pre + "news_class] Where [ParentID]=@ClassID and isLock=0 and isRecyle=0 and isPage=0 order by " + OrderBy + " " + Desc + ",id " + Desc + "";
            }
            else
            {
                Sql = "Select ClassID,IsURL,URLaddress,SavePath,SaveClassframe,ClassSaveRule,ClassIndexRule From [" + Pre + "news_class] Where [ClassID]=@ClassID and isLock=0 and isRecyle=0 and isPage=0";
            }
            //SqlParameter[] Param = new SqlParameter[] { new SqlParameter("@NewsID", NewsID) };
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
        }
        public string GetDefinedValue(string dfid, string dfcolumn)
        {
            string Sql = "Select [dsContent] From [" + Pre + "define_save] Where [DsNewsID]=@defineInfoId And [DsEName]=@defineColumns";
            SqlParameter[] Param = new SqlParameter[]{
                new SqlParameter("@defineInfoId", dfid),
                new SqlParameter("@defineColumns", dfcolumn)
            };
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }

        public string GetCHDefinedValue(int ID, string dfcolumn, string DTalbe)
        {
            string Sql = "Select " + dfcolumn + " From [" + DTalbe + "] Where ID=@ID";
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@defineColumns", dfcolumn)
            };
            string ReturnValue = Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
            return ReturnValue;
        }
        /// <summary>
        /// 文字副新闻
        /// </summary>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        public DataTable GetTextSubNews(int TopNum, string newsid)
        {
            string Sql = "Select top " + TopNum + " NewsID,NewsTitle,getNewsID,colsNum,DataLib,titleCSS From [" + Pre + "news_Sub] where NewsID='" + newsid + "'" + Common.Public.getSessionStr() + " order by colsNum ASC";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }


        #region 频道开始
        public string GetCHDatable(int ChID)
        {
            SqlParameter param = new SqlParameter("@ChID", ChID);
            string sql = "select DataLib from " + Pre + "sys_channel Where ID=@ChID";
            string ChTable = Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, sql, param));
            if (ChTable != string.Empty)
            {
                return ChTable;
            }
            else
            {
                return "#";
            }
        }


        public IDataReader GetCHDetail(int id, string DTable)
        {
            string Sql = "Select [Id],[OrderID],[Title],[TitleColor],[TitleITF],[TitleBTF],";
            Sql += "[PicURL],[ClassID],[SpecialID],[Author],[Souce],[Tags],[ContentProperty],";
            Sql += "[Templet],[Content],[Metakeywords],[Metadesc],[naviContent],[Click],[CreatTime],[SavePath],[FileName],";
            Sql += "[isDelPoint],[Gpoint],[iPoint],[GroupNumber],";
            Sql += "[isLock],[ChID],[Editor],[isHtml],[isConstr] From [" + DTable + "]";
            Sql += " Where [ID]=@ID";
            SqlParameter Param = new SqlParameter("@ID", id);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }


        /// <summary>
        /// 选择发布频道所有新闻时，取得所有新闻
        /// </summary> 
        /// <param name="strParams">页面信息字符串</param>
        /// <returns>取得符合条件的所有新闻的查询结果</returns>
        public IDataReader GetPublishCHNewsAll(string DTable, out int ncount)
        {
            string Sql = "select ID,Templet,classID,SavePath,FileName from " + DTable + " where isLock=0 and isDelPoint=0";
            string SqlCount = "select count(ID) from " + DTable + " where isLock=0 and isDelPoint=0";
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 选择发布频道最新时，取得所有新闻
        /// </summary>
        /// <param name="strParams">页面信息字符串</param>
        /// <returns>取得符合条件的所有新闻的查询结果</returns>
        public IDataReader GetPublishCHNewsLast(string DTable, int topnum, bool unpublish, out int ncount)
        {
            string Sql = "select top " + topnum + " ID,Templet,classID,SavePath,FileName from " + DTable + " where isLock=0 and isDelPoint=0";
            string SqlCount = "select count(ID) from " + DTable + " where isLock=0 and isDelPoint=0";
            if (unpublish)
            {
                Sql += " and isHtml=0";
                SqlCount += " and isHtml=0";
            }
            Sql += " order by id desc";
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }


        /// <summary>
        /// 根据栏目发布新闻
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="unpublish"></param>
        /// <param name="isdesc"></param>
        /// <param name="condition"></param>
        /// <param name="ncount"></param>
        /// <returns></returns>
        public IDataReader GetPublishCHNewsByClass(string DTable, string classid, bool unpublish, bool isdesc, string condition, out int ncount)
        {
            string SqlCondition = " where isLock=0 and isDelPoint=0 and ClassID in (" + classid + ")";
            string SqlOrder = "";
            if (unpublish)
            {
                //只发布未发布的
                SqlCondition += " and isHtml=0 ";
            }
            string Sql = "select ID,Templet,classID,SavePath,FileName from " + DTable + " a " + SqlCondition + SqlOrder;
            string SqlCount = "select count(a.ID) from " + DTable + " a " + SqlCondition;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }


        /// <summary>
        /// 选择按照日期发布时，取得所有新闻
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="ncount"></param>
        /// <returns></returns>
        public IDataReader GetPublishCHNewsByTime(string DTable, DateTime starttime, DateTime endtime, out int ncount)
        {
            string Sql = "select ID,Templet,classID,SavePath,FileName from " + DTable + " where creattime between '" + starttime + "' and '" + endtime + "' and isLock=0 and isDelPoint=0";
            string SqlCount = "select count(ID) from " + DTable + " where creattime between '" + starttime + "' and '" + endtime + "' and isLock=0 and isDelPoint=0";
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 选择按照ID发布时，取得所有新闻
        /// </summary>
        /// <param name="minid"></param>
        /// <param name="maxid"></param>
        /// <param name="ncount"></param>
        /// <returns></returns>
        public IDataReader GetPublishCHNewsByID(string DTable, int minid, int maxid, out int ncount)
        {
            string Sql = "select ID,Templet,classID,SavePath,FileName from " + DTable + " where isLock=0 and isDelPoint=0 and id between " + minid + " and " + maxid;
            string SqlCount = "select count(id) from " + DTable + " where isLock=0 and isDelPoint=0 and id between " + minid + " and " + maxid;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }


        public IDataReader GetPublishCHClass(string classid, int ChID, out int ncount)
        {
            string SqlCondition = string.Empty;
            if (classid.Trim() == "")
            {
                SqlCondition = " where isLock=0 and isPage!=1 and isDelPoint=0 and ChID=" + ChID + "";
            }
            else
            {
                SqlCondition = " where  isLock=0 and isPage!=1 and isDelPoint=0 classID in (" + classid + ")";
            }
            string SqlCount = "select count(id) from " + Pre + "sys_channelclass" + SqlCondition;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            string Sql = "select id,Templet,SavePath,FileName from " + Pre + "sys_channelclass" + SqlCondition;
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }

        public IDataReader GetPublishCHSpecial(int ChID, string spid, out int ncount)
        {
            string SqlCondition = " where isLock=0 and ChID=" + ChID + "";
            if (spid != null && spid.Trim() != "")
            {
                SqlCondition = " where isLock=0 and id in (" + spid + ")  and ChID=" + ChID + "";
            }
            string SqlCount = "select count(id) from " + Pre + "sys_channelspecial" + SqlCondition;
            ncount = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, SqlCount, null));
            string Sql = "select id,templet,savePath,filename from " + Pre + "sys_channelspecial" + SqlCondition;
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }

        public string GetCHPageTitle(int id, string Str, int ChID)
        {
            string Sql = string.Empty;
            switch (Str)
            {
                case "ChIndex":
                    Sql = "select channelName from " + Pre + "sys_channel where id=@ID";
                    break;
                case "ChNews":
                    Sql = "select Title from " + GetCHDatable(ChID) + " where id=@ID";
                    break;
                case "ChClass":
                    Sql = "select classCName from " + Pre + "sys_channelclass where id=@ID and ChID=" + ChID + "";
                    break;
                case "ChSpecial":
                    Sql = "select specialCName from " + Pre + "sys_channelspecial where id=@ID and ChID=" + ChID + "";
                    break;
                default:
                    return string.Empty;
            }
            SqlParameter Param = null;
            if (Str == "ChIndex")
            {
                Param = new SqlParameter("@ID", ChID);
            }
            else
            {
                Param = new SqlParameter("@ID", id);
            }
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }

        public IDataReader GetPositionNavi(int id, string Str, int ChID)
        {
            string Sql = "select id,channelName,htmldir,indexFileName from " + Pre + "sys_channel where id=@ChID";
            SqlParameter param = new SqlParameter("@ChID", ChID);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, param);
        }


        public IDataReader GetFieldName(int ChID)
        {
            string sql = "select CName,EName from " + Pre + "sys_channelvalue where ChID=@ChID and isLock=0 and isSearch=1";
            SqlParameter param = new SqlParameter("@ChID", ChID);
            return DbHelper.ExecuteReader(CommandType.Text, sql, param);
        }

        public string GetCHMeta(int id, int Num, int ChID, string Str)
        {
            string sql = string.Empty;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            param[0].Value = id;
            param[1] = new SqlParameter("@ChID", SqlDbType.Int, 4);
            param[1].Value = ChID;
            switch (Str)
            {
                case "ChIndex":
                    sql = "select channelName from " + Pre + "sys_channel where ID=" + ChID + "";
                    return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, sql, null));
                case "ChClass":
                    if (Num == 0)
                    {
                        sql = "select KeyMeta from " + Pre + "sys_channelclass where ID=@ID and ChID=@ChID";
                    }
                    else
                    {
                        sql = "select DescMeta from " + Pre + "sys_channelclass where ID=@ID and ChID=@ChID";
                    }
                    return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, sql, param));
                case "ChNews":
                    if (Num == 0)
                    {
                        sql = "select Metakeywords from " + GetCHDatable(ChID) + " where ID=@ID and ChID=@ChID";
                    }
                    else
                    {
                        sql = "select Metadesc from " + GetCHDatable(ChID) + " where ID=@ID and ChID=@ChID";
                    }
                    return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, sql, param));
                case "ChSpecial":
                    if (Num == 0)
                    {
                        sql = "select specialCName from " + Pre + "sys_channelspecial where ID=@ID and ChID=@ChID";
                    }
                    else
                    {
                        sql = "select navicontent from " + Pre + "sys_channelspecial where ID=@ID and ChID=@ChID";
                    }
                    return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, sql, param));
                default:
                    return string.Empty;
            }
        }

        public IDataReader GetCHPosition(int ID, int Num, int ChID)
        {
            SqlParameter param = new SqlParameter("@ID", ID);
            string sql = string.Empty;
            switch (Num)
            {
                case 0:
                    sql = "select id,SavePath,FileName,isDelPoint,classCName,ParentID from " + Pre + "sys_channelclass where id=@ID and ChID=" + ChID + "";
                    break;
                case 1:
                    sql = "select b.id,b.SavePath,b.FileName,b.isDelPoint,classCName,b.ParentID from " + GetCHDatable(ChID) + " a," + Pre + "sys_channelclass b where a.id=@ID and a.ClassID=b.ID";
                    break;
                case 2:
                    sql = "select id,parentID,SavePath,filename,specialCName from " + Pre + "sys_channelspecial where id=@ID and ChID=" + ChID + "";
                    break;
            }
            return DbHelper.ExecuteReader(CommandType.Text, sql, param);
        }

        public IDataReader GetSingleCHPageClass(int classid)
        {
            string Sql = "select Templet,classCName,SavePath,PageContent,KeyMeta,DescMeta,FileName from " + Pre + "sys_channelclass";
            Sql += " where ID=@ClassID and isLock=0 and isPage=1";
            SqlParameter Param = new SqlParameter("@ClassID", classid);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }

        public IDataReader GetCHNewsSavePath(int newsid, int ChID)
        {
            string Sql = "select a.templet,a.classid,a.SavePath,a.FileName,b.SavePath as SavePath1,b.FileName as FileName1,a.id,a.isDelPoint from " + GetCHDatable(ChID) + " a, ";
            Sql += Pre + "sys_channelclass b where a.classid=b.id and a.id=@newsid";
            SqlParameter Param = new SqlParameter("@newsid", newsid);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }


        public DataTable GetLastCHNews(int topnum, int classid, int ChID)
        {
            SqlParameter Param = null;
            string Sql = "select top " + topnum + " a.Title,a.Content,a.CreatTime,a.SavePath,a.FileName,";
            Sql += "b.savepath as savepath1,b.ClassEName,b.ClassCName,b.id as id1 from " + GetCHDatable(ChID) + " a," + Pre + "sys_channelclass b";
            Sql += " where a.islock=0  and a.ClassID=b.id and b.isPage!=1 and b.islock=0";
            if (classid != 0)
            {
                Sql += " and b.id=@ClassID";
                Param = new SqlParameter("@ClassID", classid);
            }
            Sql += " order by a.id desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
        }

        public IDataReader GetFriend(int Type, int Number, int IsAdmin, string classId)
        {
            string sql = string.Empty;
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Type", Type);
            param[1] = new SqlParameter("@ClassID", classId);
            if (IsAdmin == 3)
            {
                sql = "select top " + Number + " Name,Url,PicUrl,Content,ClassID from " + Pre + "friend_link where Type=@Type and classID=@ClassID and Lock=0 order by id desc";
            }
            else
            {
                param[2] = new SqlParameter("@IsAdmin", IsAdmin);
                sql = "select top " + Number + " Name,Url,PicUrl,Content,ClassID from " + Pre + "friend_link where Type=@Type and classID=@ClassID and isUser=@IsAdmin and Lock=0 order by id desc";
            }
            return DbHelper.ExecuteReader(CommandType.Text, sql, param);
        }

        /// <summary>
        /// 根据新闻ID获取域名
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public string getNewsDomain(string NewsID)
        {
            string sql = "select [DoMain] from " + Pre + "news_class where classid=(select classid from " + Pre + "news where newsid='" + NewsID + "')";
            string result = null;
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, sql, null);
            if (dr.Read())
            {
                result = dr[0] == null ? "" : dr[0].ToString();
            }
            dr.Close();
            return result;
        }


        /// <summary>
        /// 释放资源
        /// </summary>
        void IDisposable.Dispose()
        {
            DbHelper.CloseConn();
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// 更改新闻是否生成静态页面状态（wxh 20008-6-23）
        /// </summary>
        /// <param name="newsID"></param>
        /// <returns></returns>
        public int updateIsHtmlState(string newsID)
        {
            string sql = string.Format("update {0}news set isHtml = 1 where NewsID = '{1}'", Pre, newsID);
            return DbHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 获取所有新闻
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewsListByAll(string idList)
        {
            string Sql = "Select [Id],[NewsID],[NewsType],[OrderID],[NewsTitle],[sNewsTitle],[TitleColor],[TitleITF],[TitleBTF],[CommLinkTF],";
            Sql += "[SubNewsTF],[URLaddress],[PicURL],[SPicURL],[ClassID],[SpecialID],[Author],[Souce],[Tags],[NewsProperty],[NewsPicTopline],";
            Sql += "[Templet],[Content],[Metakeywords],[Metadesc],[naviContent],[Click],[CreatTime],[EditTime],[SavePath],[FileName],";
            Sql += "[FileEXName],[isDelPoint],[Gpoint],[iPoint],[GroupNumber],[ContentPicTF],[ContentPicURL],[ContentPicSize],[CommTF],";
            Sql += "[DiscussTF],[TopNum],[VoteTF],[CheckStat],[isLock],[isRecyle],[SiteID],[DataLib],[DefineID],[isVoteTF],[Editor],[isHtml],";
            Sql += "[isConstr],[isFiles],[vURL] From [" + Pre + "News] where [NewsID] in (" + idList + ")";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            //IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, Sql, null);

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Id");
            //dt.Columns.Add("NewsID");
            //dt.Columns.Add("NewsType");
            //dt.Columns.Add("OrderID");
            //dt.Columns.Add("NewsTitle");
            //dt.Columns.Add("sNewsTitle");
            //dt.Columns.Add("TitleColor");
            //dt.Columns.Add("TitleITF");
            //dt.Columns.Add("TitleBTF");
            //dt.Columns.Add("CommLinkTF");
            //dt.Columns.Add("SubNewsTF");
            //dt.Columns.Add("URLaddress");
            //dt.Columns.Add("PicURL");
            //dt.Columns.Add("SPicURL");
            //dt.Columns.Add("ClassID");
            //dt.Columns.Add("SpecialID");
            //dt.Columns.Add("Author");
            //dt.Columns.Add("Souce");
            //dt.Columns.Add("Tags");
            //dt.Columns.Add("NewsProperty");
            //dt.Columns.Add("NewsPicTopline");
            //dt.Columns.Add("Templet");
            //dt.Columns.Add("Content");
            //dt.Columns.Add("Metakeywords");
            //dt.Columns.Add("Metadesc");
            //dt.Columns.Add("naviContent");
            //dt.Columns.Add("Click");
            //dt.Columns.Add("CreatTime");
            //dt.Columns.Add("EditTime");
            //dt.Columns.Add("SavePath");
            //dt.Columns.Add("FileName");
            //dt.Columns.Add("FileEXName");
            //dt.Columns.Add("isDelPoint");
            //dt.Columns.Add("Gpoint");
            //dt.Columns.Add("iPoint");
            //dt.Columns.Add("GroupNumber");
            //dt.Columns.Add("ContentPicTF");
            //dt.Columns.Add("ContentPicURL");
            //dt.Columns.Add("ContentPicSize");
            //dt.Columns.Add("CommTF");
            //dt.Columns.Add("DiscussTF");
            //dt.Columns.Add("TopNum");
            //dt.Columns.Add("VoteTF");
            //dt.Columns.Add("CheckStat");
            //dt.Columns.Add("isLock");
            //dt.Columns.Add("isRecyle");
            //dt.Columns.Add("SiteID");
            //dt.Columns.Add("DataLib");
            //dt.Columns.Add("DefineID");
            //dt.Columns.Add("isVoteTF");
            //dt.Columns.Add("Editor");
            //dt.Columns.Add("isHtml");
            //dt.Columns.Add("isConstr");
            //dt.Columns.Add("isFiles");
            //dt.Columns.Add("vURL");
            //DataRow dr = null;

            //while (rd.Read()) {
            //    dr = dt.NewRow();
            //    dr["ID"] = Convert.ToInt32(rd["ID"]);

            //    dr["NewsID"] = Convert.ToString(rd["NewsID"]);
            //    dr["NewsType"] = Convert.ToByte(rd["NewsType"]);
            //    dr["OrderID"] = Convert.ToByte(rd["OrderID"]);
            //    dr["NewsTitle"] = Convert.ToString(rd["NewsTitle"]);

            //    if (rd["sNewsTitle"] == DBNull.Value) { dr["sNewsTitle"] = ""; } else { dr["sNewsTitle"] = Convert.ToString(rd["sNewsTitle"]); }
            //    if (rd["TitleColor"] == DBNull.Value) { dr["TitleColor"] = ""; } else { dr["TitleColor"] = Convert.ToString(rd["TitleColor"]); }
            //    dr["TitleITF"] = Convert.ToByte(rd["TitleITF"]);
            //    if (rd["TitleBTF"] == DBNull.Value) { dr["TitleBTF"] = 0; } else { dr["TitleBTF"] = Convert.ToByte(rd["TitleBTF"]); }
            //    if (rd["CommLinkTF"] == DBNull.Value) { dr["CommLinkTF"] = 0; } else { dr["CommLinkTF"] = Convert.ToByte(rd["CommLinkTF"]); }
            //    if (rd["SubNewsTF"] == DBNull.Value) { dr["SubNewsTF"] = 0; } else { dr["SubNewsTF"] = Convert.ToByte(rd["SubNewsTF"]); }
            //    if (rd["URLaddress"] == DBNull.Value) { dr["URLaddress"] = ""; } else { dr["URLaddress"] = Convert.ToString(rd["URLaddress"]); }
            //    if (rd["PicURL"] == DBNull.Value) { dr["PicURL"] = ""; } else { dr["PicURL"] = Convert.ToString(rd["PicURL"]); }
            //    if (rd["SPicURL"] == DBNull.Value) { dr["SPicURL"] = ""; } else { dr["SPicURL"] = Convert.ToString(rd["SPicURL"]); }
            //    dr["ClassID"] = Convert.ToString(rd["ClassID"]);
            //    if (rd["SpecialID"] == DBNull.Value) { dr["SpecialID"] = ""; } else { dr["SpecialID"] = Convert.ToString(rd["SpecialID"]); }
            //    if (rd["Author"] == DBNull.Value) { dr["Author"] = ""; } else { dr["Author"] = Convert.ToString(rd["Author"]); }
            //    if (rd["Souce"] == DBNull.Value) { dr["Souce"] = ""; } else { dr["Souce"] = Convert.ToString(rd["Souce"]); }
            //    if (rd["Tags"] == DBNull.Value) { dr["Tags"] = ""; } else { dr["Tags"] = Convert.ToString(rd["Tags"]); }
            //    dr["NewsProperty"] = Convert.ToString(rd["NewsProperty"]);
            //    dr["NewsPicTopline"] = Convert.ToByte(rd["NewsPicTopline"]);
            //    if (rd["Templet"] == DBNull.Value) { dr["Templet"] = ""; } else { dr["Templet"] = Convert.ToString(rd["Templet"]); }
            //    if (rd["Content"] == DBNull.Value) { dr["Content"] = ""; } else { dr["Content"] = Convert.ToString(rd["Content"]); }
            //    if (rd["Metakeywords"] == DBNull.Value) { dr["Metakeywords"] = ""; } else { dr["Metakeywords"] = Convert.ToString(rd["Metakeywords"]); }
            //    if (rd["Metadesc"] == DBNull.Value) { dr["Metadesc"] = ""; } else { dr["Metadesc"] = Convert.ToString(rd["Metadesc"]); }
            //    if (rd["naviContent"] == DBNull.Value) { dr["naviContent"] = ""; } else { dr["naviContent"] = Convert.ToString(rd["naviContent"]); }
            //    dr["Click"] = Convert.ToInt32(rd["Click"]);
            //    dr["CreatTime"] = Convert.ToDateTime(rd["CreatTime"]);
            //    if (rd["EditTime"] == DBNull.Value) { dr["EditTime"] = Convert.ToDateTime(rd["CreatTime"]); } else { dr["EditTime"] = Convert.ToDateTime(rd["EditTime"]); }
            //    if (rd["SavePath"] == DBNull.Value) { dr["SavePath"] = ""; } else { dr["SavePath"] = Convert.ToString(rd["SavePath"]); }
            //    dr["FileName"] = Convert.ToString(rd["FileName"]);
            //    dr["FileEXName"] = Convert.ToString(rd["FileEXName"]);
            //    dr["isDelPoint"] = Convert.ToByte(rd["isDelPoint"]);
            //    dr["Gpoint"] = Convert.ToInt32(rd["Gpoint"]);
            //    dr["iPoint"] = Convert.ToInt32(rd["iPoint"]);
            //    if (rd["GroupNumber"] == DBNull.Value) { dr["GroupNumber"] = ""; } else { dr["GroupNumber"] = Convert.ToString(rd["GroupNumber"]); }
            //    dr["ContentPicTF"] = Convert.ToByte(rd["ContentPicTF"]);
            //    if (rd["ContentPicURL"] == DBNull.Value) { dr["ContentPicURL"] = ""; } else { dr["ContentPicURL"] = Convert.ToString(rd["ContentPicURL"]); }
            //    if (rd["ContentPicSize"] == DBNull.Value) { dr["ContentPicSize"] = ""; } else { dr["ContentPicSize"] = Convert.ToString(rd["ContentPicSize"]); }
            //    dr["CommTF"] = Convert.ToByte(rd["CommTF"]);
            //    dr["DiscussTF"] = Convert.ToByte(rd["DiscussTF"]);
            //    dr["TopNum"] = Convert.ToInt32(rd["TopNum"]);
            //    dr["VoteTF"] = Convert.ToByte(rd["VoteTF"]);
            //    if (rd["CheckStat"] == DBNull.Value) { dr["CheckStat"] = ""; } else { dr["CheckStat"] = Convert.ToString(rd["CheckStat"]); }
            //    dr["isLock"] = Convert.ToByte(rd["isLock"]);
            //    dr["isRecyle"] = Convert.ToByte(rd["isRecyle"]);
            //    dr["SiteID"] = Convert.ToString(rd["SiteID"]);
            //    dr["DataLib"] = Convert.ToString(rd["DataLib"]);
            //    if (rd["DefineID"] == DBNull.Value) { dr["DefineID"] = 0; } else { dr["DefineID"] = Convert.ToByte(rd["DefineID"]); }
            //    dr["isVoteTF"] = Convert.ToByte(rd["isVoteTF"]);
            //    if (rd["Editor"] == DBNull.Value) { dr["Editor"] = ""; } else { dr["Editor"] = Convert.ToString(rd["Editor"]); }
            //    dr["isHtml"] = Convert.ToByte(rd["isHtml"]);
            //    dr["isConstr"] = Convert.ToByte(rd["isConstr"]);
            //    if (rd["isFiles"] == DBNull.Value) { dr["isFiles"] = 0; } else { dr["isFiles"] = Convert.ToByte(rd["isFiles"]); }
            //    if (rd["vURL"] == DBNull.Value) { dr["vURL"] = ""; } else { dr["vURL"] = Convert.ToString(rd["vURL"]); }

            //    dt.Rows.Add(dr);
            //}
            //rd.Close();
            //return dt;
        }
    }
}

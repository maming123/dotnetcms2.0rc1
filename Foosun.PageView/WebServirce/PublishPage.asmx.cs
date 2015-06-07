using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;
using Foosun.Model;
using Foosun.PageBasic;
using System.IO;
using System.Data;
using Foosun.Publish;

namespace Foosun.PageView.WebServirce
{
    /// <summary>
    /// PublishPage 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class PublishPage : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        public static bool logined = true;
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [WebMethod]
        public bool Login(string userName, string passWord)
        {
            Foosun.CMS.UserLogin ul = new CMS.UserLogin();
            GlobalUserInfo info;
            EnumLoginState state = ul.AdminLogin(userName, passWord, out info);
            if (state == EnumLoginState.Succeed)
            {
                logined = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 发布首页
        /// </summary>
        [WebMethod]
        public string PublishIndex(bool BakIndex)
        {
            if (logined)
            {
                Foosun.Publish.UltiPublishServirce puli = new Foosun.Publish.UltiPublishServirce(true);

                puli.ultiPublishIndex();
                if (BakIndex == true)
                {
                    string sourceFile = "~/" + Common.Public.readparamConfig("IndexFileName");
                    string str_dirPige = Foosun.Config.UIConfig.dirPige;
                    if (File.Exists(Server.MapPath(sourceFile)))
                    {
                        string TagetFile = "~/" + str_dirPige + "/index/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".shtml";
                        string hfile = "~/" + str_dirPige;
                        string TagetDir = "~/" + str_dirPige + "/index";
                        sourceFile = sourceFile.Replace("//", "/").Replace(@"\\", @"\");
                        TagetFile = TagetFile.Replace("//", "/").Replace(@"\\", @"\");
                        TagetDir = TagetDir.Replace("//", "/").Replace(@"\\", @"\");
                        hfile = hfile.Replace("//", "/").Replace(@"\\", @"\");
                        if (!Directory.Exists(Server.MapPath(hfile))) { Directory.CreateDirectory(Server.MapPath(hfile)); }
                        if (!Directory.Exists(Server.MapPath(TagetDir))) { Directory.CreateDirectory(Server.MapPath(TagetDir)); }
                        if (File.Exists(Server.MapPath(TagetFile))) { File.Delete(Server.MapPath(TagetFile)); }
                        File.Move(Server.MapPath(sourceFile), Server.MapPath(TagetFile));
                    }
                }
                puli.StartPublish();
                return "发布完成!";
            }
            return "你还没有登录!";
        }

        /// <summary>
        /// 获取全部新闻信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetNewsAll(out int nNewsCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            nNewsCount = 0;
            return GetNewsDataTable(publish.GetPublishNewsAll(out nNewsCount));
        }

        /// <summary>
        /// 获取全部栏目信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetClassAll(out int nClassCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            nClassCount = 0;
            return GetClassDataTable(publish.GetClassAll(out nClassCount));
        }
        /// <summary>
        /// 获取选中的栏目信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetClassByClassId(string classid, out int nClassCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            nClassCount = 0;
            return GetClassDataTable(publish.GetPublishClass(classid, out nClassCount));
        }

        /// <summary>
        /// 获取最新新闻
        /// </summary>
        /// <param name="type">新闻数量</param>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetNewsLast(int lastNum, out int nNewsCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            int ncount = 0;
            IDataReader rd = publish.GetPublishNewsLast(lastNum, false, out ncount);
            nNewsCount = lastNum;
            if (ncount < nNewsCount)
            {
                nNewsCount = ncount;
            }
            return GetNewsDataTable(rd);
        }

        /// <summary>
        /// 获取未发布的新闻
        /// </summary>
        /// <param name="type">新闻数量</param>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetNewsUnHtml(int topNum, out int nNewsCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            int ncount = 0;
            IDataReader rd = publish.GetPublishNewsLast(topNum, true, out ncount);
            nNewsCount = topNum;
            if (ncount < nNewsCount)
            {
                nNewsCount = ncount;
            }
            return GetNewsDataTable(rd);
        }

        /// <summary>
        /// 获取时间段内的新闻
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetNewsByCreateTime(DateTime beginTime, DateTime endTime, out int nNewsCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            nNewsCount = 0;
            return GetNewsDataTable(publish.GetNewsByCreateTime(beginTime, endTime, out nNewsCount));
        }
        /// <summary>
        /// 根据栏目获取新闻
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetNewsByClassID(string classID, out int nNewsCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            bool IsHtml = false;//还没有起作用
            bool IsDesc = false;//还没有起作用
            nNewsCount = 0;
            return GetNewsDataTable(publish.GetPublishNewsByClass(classID, IsHtml, IsDesc, "1", out nNewsCount));
        }

        private DataTable GetNewsDataTable(IDataReader rd)
        {
            DataTable dts = new DataTable();
            dts.TableName = "tmp";
            DataRow dr = null;
            dts.Columns.Add("newsID");
            dts.Columns.Add("datalib");
            dts.Columns.Add("classID");
            dts.Columns.Add("SavePath");
            dts.Columns.Add("FileName");
            dts.Columns.Add("FileEXName");
            dts.Columns.Add("templet");
            dts.Columns.Add("isDelPoint");
            dts.Columns.Add("SavePath1");
            dts.Columns.Add("SaveClassframe");
            dts.Columns.Add("CommTF");
            while (rd.Read())
            {
                dr = dts.NewRow();
                dr["newsID"] = rd["newsID"];
                dr["datalib"] = rd["datalib"];
                dr["classID"] = rd["classID"];
                dr["SavePath"] = rd["SavePath"];
                dr["FileName"] = rd["FileName"];
                dr["FileEXName"] = rd["FileEXName"];
                dr["templet"] = rd["templet"];
                dr["isDelPoint"] = rd["isDelPoint"];
                dr["SavePath1"] = rd["SavePath1"];
                dr["SaveClassframe"] = rd["SaveClassframe"];
                dr["CommTF"] = rd["CommTF"];
                dts.Rows.Add(dr);
            }
            return dts;
        }

        private DataTable GetClassDataTable(IDataReader rd)
        {
            DataTable dts = new DataTable();
            dts.TableName = "tmp";
            DataRow dr = null;
            dts.Columns.Add("classtemplet");
            dts.Columns.Add("savePath");
            dts.Columns.Add("SaveClassframe");
            dts.Columns.Add("ClassSaveRule");
            dts.Columns.Add("classid");
            dts.Columns.Add("Datalib");
            while (rd.Read())
            {
                dr = dts.NewRow();
                dr["classtemplet"] = rd["classtemplet"];
                dr["savePath"] = rd["savePath"];
                dr["SaveClassframe"] = rd["SaveClassframe"];
                dr["ClassSaveRule"] = rd["ClassSaveRule"];
                dr["classid"] = rd["classid"];
                dr["Datalib"] = rd["Datalib"];
                dts.Rows.Add(dr);
            }
            return dts;
        }

        private DataTable GetSpecialDataTable(IDataReader rd)
        {
            DataTable dts = new DataTable();
            dts.TableName = "tmp";
            DataRow dr = null;
            dts.Columns.Add("Templet");
            dts.Columns.Add("SavePath");
            dts.Columns.Add("saveDirPath");
            dts.Columns.Add("FileName");
            dts.Columns.Add("FileEXName");
            dts.Columns.Add("specialID");
            while (rd.Read())
            {
                dr = dts.NewRow();
                dr["Templet"] = rd["Templet"];
                dr["SavePath"] = rd["SavePath"];
                dr["saveDirPath"] = rd["saveDirPath"];
                dr["FileName"] = rd["FileName"];
                dr["FileEXName"] = rd["FileEXName"];
                dr["specialID"] = rd["specialID"];
                dts.Rows.Add(dr);
            }
            return dts;
        }

        /// <summary>
        /// 发布一条新闻
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="classID"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PublishSingNews(string newsID, string classID, string templet, string isDelPoint, string SavePath1, string SaveClassframe, string SavePath, string FileName, string FileEXName, string CommTF)
        {
            UltiPublishServirce publish = new UltiPublishServirce(true);
            return publish.publishSingleNews(newsID, classID, templet, isDelPoint, SavePath1, SaveClassframe, SavePath, FileName, FileEXName, CommTF);
        }

        /// <summary>
        /// 发布一个栏目
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="classID"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PublishSingClass(string classID, string datalib, string saveClassPath)
        {
            UltiPublishServirce publish = new UltiPublishServirce(true);
            return publish.publishSingleClass(classID, datalib, saveClassPath);
        }

        /// <summary>
        /// 发布一个专题
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="classID"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PublishSingSpecial(string special, string savePath)
        {
            UltiPublishServirce publish = new UltiPublishServirce(true);
            return publish.publishSingleSpecial(special, savePath);
        }

        /// <summary>
        /// 获得专题列表信息
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="classID"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetSpecialAll(string spid, out int nSpecialCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            nSpecialCount = 0;
            return GetSpecialDataTable(publish.GetSpecialAll(spid, out nSpecialCount));
        }

        /// <summary>
        /// 获得单页列表信息
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="classID"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetPageAll(string classId, out int nClassCount)
        {
            Foosun.CMS.Publish publish = new CMS.Publish();
            nClassCount = 0;
            return GetClassDataTable(publish.GetPageAll(classId, out nClassCount));
        }

        /// <summary>
        /// 发布一个单页
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="classID"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PublishSingPage(string classID)
        {
            return General.PublishPage(classID);
        }

        /// <summary>
        /// 获取发布结果
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetPublishResult()
        {
            string result = "首页:" + Foosun.Publish.UltiPublishServirce.indexCount + "|" + "新闻:" + Foosun.Publish.UltiPublishServirce.newsCount + "|" + "栏目:" + Foosun.Publish.UltiPublishServirce.classCount + "|" + "专题:" + Foosun.Publish.UltiPublishServirce.specialCount + "|" + "单页:" + Foosun.Publish.UltiPublishServirce.pageCount;
            return result;
        }

        /// <summary>
        /// 获取栏目信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetNewsList()
        {
            if (logined)
            {
                Foosun.CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
                DataTable DataClassTable = NewsClassCMS.GetList("isRecyle<>1 and isPage = 0 and SiteID='" + Foosun.Global.Current.SiteID + "' and isLock=0");
                return DataClassTable;
            }
            return null;
        }

        /// <summary>
        /// 获取专题列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetSpecialList()
        {
            if (logined)
            {
                Foosun.CMS.NewsSpecial SpecialCMS = new CMS.NewsSpecial();
                DataTable dataSpecialTable = SpecialCMS.GetList("isRecyle<>1 and SiteID='" + Foosun.Global.Current.SiteID + "' and isLock=0");
                return dataSpecialTable;
            }
            return null;
        }

        /// <summary>
        /// 获取单页列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataTable GetPageList()
        {
            if (logined)
            {
                Foosun.CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
                DataTable dataIspageTable = NewsClassCMS.GetList("isRecyle<>1 and isPage=1 and isLock=0");
                return dataIspageTable;
            }
            return null;
        }
    }
}

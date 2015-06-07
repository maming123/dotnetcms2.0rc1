using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
using System.IO;
using System.Web;
namespace Foosun.CMS
{
    /// <summary>
    /// News
    /// </summary>
    public partial class News
    {
        private readonly INews dal = DataAccess.CreateNews();
        public News()
        { }
        #region  新闻
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Foosun.Model.News model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.News model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 复制新闻
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="sOrgNews"></param>
        /// <param name="NewsID"></param>
        /// <param name="FileName"></param>
        public void Copy_news(string ClassID, string sOrgNews, string NewsID, string FileName)
        {
             dal.Copy_news(ClassID, sOrgNews, NewsID, FileName);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Id)
        {

            return dal.Delete(Id);
        }
          /// <summary>
        /// 彻底删除新闻
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int DelNew(string where)
        {
            return dal.DelNew(where);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.News GetModel(string Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.News GetModelByCache(string Id)
        {

            string CacheKey = "NewsModel-" + Id;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.News)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.News> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        public List<Foosun.Model.News> GetPageByClass(string where, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            DataTable ds = dal.GetPageByClass(where,PageIndex,PageSize,out RecordCount,out PageCount);
            return DataTableToList(ds);
        }
        public List<Foosun.Model.News> GetModelList(int top, string strWhere, string filedOrder)
        {
            DataTable ds = dal.GetList(top,strWhere,filedOrder);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.News> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.News> modelList = new List<Foosun.Model.News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.News();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["NewsID"] != null && dt.Rows[n]["NewsID"].ToString() != "")
                    {
                        model.NewsID = dt.Rows[n]["NewsID"].ToString();
                    }
                    if (dt.Rows[n]["NewsType"] != null && dt.Rows[n]["NewsType"].ToString() != "")
                    {
                        model.NewsType = int.Parse(dt.Rows[n]["NewsType"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["NewsTitle"] != null && dt.Rows[n]["NewsTitle"].ToString() != "")
                    {
                        model.NewsTitle = dt.Rows[n]["NewsTitle"].ToString();
                    }
                    if (dt.Rows[n]["sNewsTitle"] != null && dt.Rows[n]["sNewsTitle"].ToString() != "")
                    {
                        model.sNewsTitle = dt.Rows[n]["sNewsTitle"].ToString();
                    }
                    if (dt.Rows[n]["TitleColor"] != null && dt.Rows[n]["TitleColor"].ToString() != "")
                    {
                        model.TitleColor = dt.Rows[n]["TitleColor"].ToString();
                    }
                    if (dt.Rows[n]["TitleITF"] != null && dt.Rows[n]["TitleITF"].ToString() != "")
                    {
                        model.TitleITF = int.Parse(dt.Rows[n]["TitleITF"].ToString());
                    }
                    if (dt.Rows[n]["TitleBTF"] != null && dt.Rows[n]["TitleBTF"].ToString() != "")
                    {
                        model.TitleBTF = int.Parse(dt.Rows[n]["TitleBTF"].ToString());
                    }
                    if (dt.Rows[n]["CommLinkTF"] != null && dt.Rows[n]["CommLinkTF"].ToString() != "")
                    {
                        model.CommLinkTF = int.Parse(dt.Rows[n]["CommLinkTF"].ToString());
                    }
                    if (dt.Rows[n]["SubNewsTF"] != null && dt.Rows[n]["SubNewsTF"].ToString() != "")
                    {
                        model.SubNewsTF = int.Parse(dt.Rows[n]["SubNewsTF"].ToString());
                    }
                    if (dt.Rows[n]["URLaddress"] != null && dt.Rows[n]["URLaddress"].ToString() != "")
                    {
                        model.URLaddress = dt.Rows[n]["URLaddress"].ToString();
                    }
                    if (dt.Rows[n]["PicURL"] != null && dt.Rows[n]["PicURL"].ToString() != "")
                    {
                        model.PicURL = dt.Rows[n]["PicURL"].ToString();
                    }
                    if (dt.Rows[n]["SPicURL"] != null && dt.Rows[n]["SPicURL"].ToString() != "")
                    {
                        model.SPicURL = dt.Rows[n]["SPicURL"].ToString();
                    }
                    if (dt.Rows[n]["ClassID"] != null && dt.Rows[n]["ClassID"].ToString() != "")
                    {
                        model.ClassID = dt.Rows[n]["ClassID"].ToString();
                    }
                    if (dt.Rows[n]["SpecialID"] != null && dt.Rows[n]["SpecialID"].ToString() != "")
                    {
                        model.SpecialID = dt.Rows[n]["SpecialID"].ToString();
                    }
                    if (dt.Rows[n]["Author"] != null && dt.Rows[n]["Author"].ToString() != "")
                    {
                        model.Author = dt.Rows[n]["Author"].ToString();
                    }
                    if (dt.Rows[n]["Souce"] != null && dt.Rows[n]["Souce"].ToString() != "")
                    {
                        model.Souce = dt.Rows[n]["Souce"].ToString();
                    }
                    if (dt.Rows[n]["Tags"] != null && dt.Rows[n]["Tags"].ToString() != "")
                    {
                        model.Tags = dt.Rows[n]["Tags"].ToString();
                    }
                    if (dt.Rows[n]["NewsProperty"] != null && dt.Rows[n]["NewsProperty"].ToString() != "")
                    {
                        model.NewsProperty = dt.Rows[n]["NewsProperty"].ToString();
                    }
                    if (dt.Rows[n]["NewsPicTopline"] != null && dt.Rows[n]["NewsPicTopline"].ToString() != "")
                    {
                        model.NewsPicTopline = int.Parse(dt.Rows[n]["NewsPicTopline"].ToString());
                    }
                    if (dt.Rows[n]["Templet"] != null && dt.Rows[n]["Templet"].ToString() != "")
                    {
                        model.Templet = dt.Rows[n]["Templet"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = dt.Rows[n]["Content"].ToString();
                    }
                    if (dt.Rows[n]["Metakeywords"] != null && dt.Rows[n]["Metakeywords"].ToString() != "")
                    {
                        model.Metakeywords = dt.Rows[n]["Metakeywords"].ToString();
                    }
                    if (dt.Rows[n]["Metadesc"] != null && dt.Rows[n]["Metadesc"].ToString() != "")
                    {
                        model.Metadesc = dt.Rows[n]["Metadesc"].ToString();
                    }
                    if (dt.Rows[n]["naviContent"] != null && dt.Rows[n]["naviContent"].ToString() != "")
                    {
                        model.naviContent = dt.Rows[n]["naviContent"].ToString();
                    }
                    if (dt.Rows[n]["Click"] != null && dt.Rows[n]["Click"].ToString() != "")
                    {
                        model.Click = int.Parse(dt.Rows[n]["Click"].ToString());
                    }
                    if (dt.Rows[n]["CreatTime"] != null && dt.Rows[n]["CreatTime"].ToString() != "")
                    {
                        model.CreatTime = DateTime.Parse(dt.Rows[n]["CreatTime"].ToString());
                    }
                    if (dt.Rows[n]["EditTime"] != null && dt.Rows[n]["EditTime"].ToString() != "")
                    {
                        model.EditTime = DateTime.Parse(dt.Rows[n]["EditTime"].ToString());
                    }
                    if (dt.Rows[n]["SavePath"] != null && dt.Rows[n]["SavePath"].ToString() != "")
                    {
                        model.SavePath = dt.Rows[n]["SavePath"].ToString();
                    }
                    if (dt.Rows[n]["FileName"] != null && dt.Rows[n]["FileName"].ToString() != "")
                    {
                        model.FileName = dt.Rows[n]["FileName"].ToString();
                    }
                    if (dt.Rows[n]["FileEXName"] != null && dt.Rows[n]["FileEXName"].ToString() != "")
                    {
                        model.FileEXName = dt.Rows[n]["FileEXName"].ToString();
                    }
                    if (dt.Rows[n]["isDelPoint"] != null && dt.Rows[n]["isDelPoint"].ToString() != "")
                    {
                        model.isDelPoint = int.Parse(dt.Rows[n]["isDelPoint"].ToString());
                    }
                    if (dt.Rows[n]["Gpoint"] != null && dt.Rows[n]["Gpoint"].ToString() != "")
                    {
                        model.Gpoint = int.Parse(dt.Rows[n]["Gpoint"].ToString());
                    }
                    if (dt.Rows[n]["iPoint"] != null && dt.Rows[n]["iPoint"].ToString() != "")
                    {
                        model.iPoint = int.Parse(dt.Rows[n]["iPoint"].ToString());
                    }
                    if (dt.Rows[n]["GroupNumber"] != null && dt.Rows[n]["GroupNumber"].ToString() != "")
                    {
                        model.GroupNumber = dt.Rows[n]["GroupNumber"].ToString();
                    }
                    if (dt.Rows[n]["ContentPicTF"] != null && dt.Rows[n]["ContentPicTF"].ToString() != "")
                    {
                        model.ContentPicTF = int.Parse(dt.Rows[n]["ContentPicTF"].ToString());
                    }
                    if (dt.Rows[n]["ContentPicURL"] != null && dt.Rows[n]["ContentPicURL"].ToString() != "")
                    {
                        model.ContentPicURL = dt.Rows[n]["ContentPicURL"].ToString();
                    }
                    if (dt.Rows[n]["ContentPicSize"] != null && dt.Rows[n]["ContentPicSize"].ToString() != "")
                    {
                        model.ContentPicSize = dt.Rows[n]["ContentPicSize"].ToString();
                    }
                    if (dt.Rows[n]["CommTF"] != null && dt.Rows[n]["CommTF"].ToString() != "")
                    {
                        model.CommTF = int.Parse(dt.Rows[n]["CommTF"].ToString());
                    }
                    if (dt.Rows[n]["DiscussTF"] != null && dt.Rows[n]["DiscussTF"].ToString() != "")
                    {
                        model.DiscussTF = int.Parse(dt.Rows[n]["DiscussTF"].ToString());
                    }
                    if (dt.Rows[n]["TopNum"] != null && dt.Rows[n]["TopNum"].ToString() != "")
                    {
                        model.TopNum = int.Parse(dt.Rows[n]["TopNum"].ToString());
                    }
                    if (dt.Rows[n]["VoteTF"] != null && dt.Rows[n]["VoteTF"].ToString() != "")
                    {
                        model.VoteTF = int.Parse(dt.Rows[n]["VoteTF"].ToString());
                    }
                    if (dt.Rows[n]["CheckStat"] != null && dt.Rows[n]["CheckStat"].ToString() != "")
                    {
                        model.CheckStat = dt.Rows[n]["CheckStat"].ToString();
                    }
                    if (dt.Rows[n]["isLock"] != null && dt.Rows[n]["isLock"].ToString() != "")
                    {
                        model.isLock = int.Parse(dt.Rows[n]["isLock"].ToString());
                    }
                    if (dt.Rows[n]["isRecyle"] != null && dt.Rows[n]["isRecyle"].ToString() != "")
                    {
                        model.isRecyle = int.Parse(dt.Rows[n]["isRecyle"].ToString());
                    }
                    if (dt.Rows[n]["SiteID"] != null && dt.Rows[n]["SiteID"].ToString() != "")
                    {
                        model.SiteID = dt.Rows[n]["SiteID"].ToString();
                    }
                    if (dt.Rows[n]["DataLib"] != null && dt.Rows[n]["DataLib"].ToString() != "")
                    {
                        model.DataLib = dt.Rows[n]["DataLib"].ToString();
                    }
                    if (dt.Rows[n]["DefineID"] != null && dt.Rows[n]["DefineID"].ToString() != "")
                    {
                        model.DefineID = int.Parse(dt.Rows[n]["DefineID"].ToString());
                    }
                    if (dt.Rows[n]["isVoteTF"] != null && dt.Rows[n]["isVoteTF"].ToString() != "")
                    {
                        model.isVoteTF = int.Parse(dt.Rows[n]["isVoteTF"].ToString());
                    }
                    if (dt.Rows[n]["Editor"] != null && dt.Rows[n]["Editor"].ToString() != "")
                    {
                        model.Editor = dt.Rows[n]["Editor"].ToString();
                    }
                    if (dt.Rows[n]["isHtml"] != null && dt.Rows[n]["isHtml"].ToString() != "")
                    {
                        model.isHtml = int.Parse(dt.Rows[n]["isHtml"].ToString());
                    }
                    if (dt.Rows[n]["isConstr"] != null && dt.Rows[n]["isConstr"].ToString() != "")
                    {
                        model.isConstr = int.Parse(dt.Rows[n]["isConstr"].ToString());
                    }
                    if (dt.Rows[n]["isFiles"] != null && dt.Rows[n]["isFiles"].ToString() != "")
                    {
                        model.isFiles = int.Parse(dt.Rows[n]["isFiles"].ToString());
                    }
                    if (dt.Rows[n]["vURL"] != null && dt.Rows[n]["vURL"].ToString() != "")
                    {
                        model.vURL = dt.Rows[n]["vURL"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="SpecialID">专题编号</param>
        /// <param name="Editor">作者</param>
        /// <param name="NewsDbTbs">表名</param>
        /// <param name="ClassID">栏目</param>
        /// <param name="sKeywrd">关键字</param>
        /// <param name="DdlKwdType">关键字类型</param>
        /// <param name="sChooses">提交的类型</param>
        /// <param name="SiteID">站点</param>
        /// <param name="TablePrefix">表扩展名</param>
        /// <param name="PageIndex">每页数量</param>
        /// <param name="PageSize">每页数量</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="PageCount"></param>
        /// <param name="SqlCondition">SQL</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetPage(string SpecialID, string Editor, string ClassID, string sKeywrd, string DdlKwdType, string sChooses, string SiteID, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            return dal.GetPage(SpecialID, Editor, ClassID, sKeywrd, DdlKwdType, sChooses, SiteID, PageIndex, PageSize, out RecordCount, out PageCount);
        }
        /// <summary>
        /// 子新闻列表
        /// </summary>       
        public DataTable GetPageiframe(string DdlClass, string sKeywrds, string sChoose, string DdlKwdType, int pageindex, int PageSize, out int RecordCount, out int PageCount)
        {
            return dal.GetPageiframe(DdlClass, sKeywrds, sChoose, DdlKwdType, pageindex, PageSize, out RecordCount, out PageCount);
        }
          /// <summary>
        /// 不规则新闻分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <param name="SqlCondition"></param>
        /// <returns></returns>
        public DataTable GetPages(int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition)
        {
            return dal.GetPages(PageIndex, PageSize, out RecordCount, out PageCount, SqlCondition);
        }
         /// <summary>
        /// 通用更新新闻方法
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        public int UpdateNews(string NewsID, int type, string value, string field)
        {
             return dal.UpdateNews(NewsID, type, value, field);
        }
         /// <summary>
        /// 批量更新新闻
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="num">条件字段：0为NewsID,1为ClassID</param>
        /// <param name="type">字段类型：0为字符串，1为整型</param>
        /// <param name="field">要更新的字段名</param>
        /// <param name="value">字段值</param>
        public int UpdateNews(string NewsID, int num, int type, string field, string value)
        {
            return dal.UpdateNews(NewsID, num, type, field, value);
        }
        /// <summary>
        /// 设置新闻属性
        /// </summary>
        public int UpdateNews(int CommTF, int DiscussTF, string NewsProperty, string Templet, string OrderID, int CommLinkTF, string Click, string FileEXName, string Tags, string Souce, string where)
        {
           return dal.UpdateNews(CommTF, DiscussTF, NewsProperty, Templet, OrderID, CommLinkTF, Click, FileEXName, Tags, Souce, where);
        }
         /// <summary>
        /// 获取新闻页面的静态页面路径
        /// </summary>
        /// <param name="NewsID">新闻的NewsID</param>
        /// <returns></returns>
        public DataTable GetDeleteNewsContent(string NewsID)
        {
            return dal.GetDeleteNewsContent(NewsID);
        
        }
        /// <summary>
        /// 删除新闻的静态页面
        /// </summary>
        /// <param name="NewsID">新闻的NewsID</param>
        /// <returns></returns>
        public bool DeleteNewsHtmlFile(string NewsID)
        {
            DataTable dt = dal.GetDeleteNewsContent(NewsID);
            if (dt.Rows.Count > 0)
            {
                string _NewsType = dt.Rows[0]["NewsType"].ToString();
                if (_NewsType != "2")
                {
                    string _FileName = dt.Rows[0]["FileName"].ToString();
                    string _FileEXName = dt.Rows[0]["FileEXName"].ToString();
                    string _NewsSavePath = dt.Rows[0]["NewsSavePath"].ToString();
                    string _ClassSavePath = dt.Rows[0]["ClassSavePath"].ToString();
                    string _SaveClassframe = dt.Rows[0]["SaveClassframe"].ToString();
                    string _DeletePath = "/" + Foosun.Config.UIConfig.dirDumm + "/" + _ClassSavePath + "/" + _SaveClassframe + "/" + _NewsSavePath + "/" + _FileName + _FileEXName;
                    _DeletePath = HttpContext.Current.Server.MapPath(_DeletePath.Replace("//", "/").Replace("//", "/"));
                    bool _FileIsExisted = File.Exists(_DeletePath);
                    int i = 1;
                    while (_FileIsExisted)
                    {
                        File.Delete(_DeletePath);
                        i++;
                        _DeletePath = "/" + Foosun.Config.UIConfig.dirDumm + "/" + _ClassSavePath + "/" + _SaveClassframe + "/" + _NewsSavePath + "/" + _FileName + "_" + i.ToString() + _FileEXName;
                        _DeletePath = HttpContext.Current.Server.MapPath(_DeletePath.Replace("//", "/").Replace("//", "/"));
                        _FileIsExisted = File.Exists(_DeletePath);
                    }
                }
            }
            return true;
        }
         /// <summary>
        /// 彻底删除新闻并删除附件、自定义字段、所属专题、子新闻、不规则新闻
       /// </summary>
       /// <param name="NewsID">新闻的NewsID</param>
        public void DelNews(string NewsID)
        {
            dal.DelNews(NewsID);
        }
        /// <summary>
        /// 终极审核
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        public void AllCheck(string NewsID)
        {
            dal.AllCheck(NewsID);
        }
         /// <summary>
        /// 按等级审核
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="levelsID">审核等级</param>
        public void UpCheckStat(string NewsID, int levelsID)
        {
            dal.UpCheckStat(NewsID, levelsID);
        }
         /// <summary>
        /// 得到指定新闻的IDataReader
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public IDataReader GetNewsID(string NewsID)
        {
            return dal.GetNewsID(NewsID);
        }
        /// <summary>
        /// 得到子新闻
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetUNews(string NewsID)
        {
            return dal.GetUNews(NewsID);
        }
         /// <summary>
        /// 删除不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
        public void DelSubID(string UnID)
        {
            dal.DelSubID(UnID);
        }
         /// <summary>
        /// 插入子新闻
        /// </summary>
        /// <param name="unNewsid">编号</param>
        /// <param name="Arr_OldNewsId">新闻ID</param>
        /// <param name="NewsRow">行</param>
        /// <param name="NewsTitle">标题</param>
        /// <param name="NewsTable">新闻表</param>
        /// <param name="SiteID">站点ID</param>
        /// <returns></returns>
        public int Add_SubNews(string unNewsid, string Arr_OldNewsId, string NewsRow, string NewsTitle, string NewsTable, string SiteID, string titleCSS)
        {
            return dal.Add_SubNews(unNewsid, Arr_OldNewsId, NewsRow, NewsTitle, NewsTable, SiteID, titleCSS);
        }
        /// <summary>
        /// 取得专题与新闻的对应表
        /// </summary>
        /// <param name="NewsID">新闻编号</param>
        /// <returns></returns>
        public DataTable GetSpecialNews(string NewsID)
        {
            return dal.GetSpecialNews(NewsID);
        }
         /// <summary>
        /// 得到某条新闻的附件列表
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataTB"></param>
        /// <returns></returns>
        public DataTable GetFileList(string NewsID, string DataTB)
        {
            return dal.GetFileList(NewsID, DataTB);
        }
          /// <summary>
        /// 根据id删除附件
        /// </summary>
        /// <param name="ids">多个id用，隔开</param>
        public void DeleteNewsFileByID(string ids)
        {
            dal.DeleteNewsFileByID(ids);
        }
         /// <summary>
        /// 根据newsid删除附件
        /// </summary>
        /// <param name="newsid"></param>
        public void DeleteNewsFileByNewsID(string NewsID)
        {
            dal.DeleteNewsFileByNewsID(NewsID);
        }
        /// <summary>
        /// 更新附件文件地址
        /// </summary>
        /// <param name="URLName"></param>
        /// <param name="DataLib"></param>
        /// <param name="FileURL"></param>
        /// <param name="OrderID"></param>
        /// <param name="ID"></param>
        public void UpdateFileURL(string URLName, string DataLib, string FileURL, int OrderID, int ID)
        {
            dal.UpdateFileURL(URLName, DataLib, FileURL, OrderID, ID);
        }
         /// <summary>
        /// 插入附件
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataLib"></param>
        /// <param name="FileURL"></param>
        /// <param name="OrderID"></param>
        public void InsertFileURL(string URLName, string NewsID, string DataLib, string FileURL, int OrderID)
        {
            dal.InsertFileURL(URLName, NewsID, DataLib, FileURL, OrderID);
        }
         /// <summary>
        /// 检查新闻标题
        /// </summary>
        /// <param name="NewsTitle"></param>
        /// <param name="tb"></param>
        /// <returns></returns>
        public int NewsTitletf(string NewsTitle, string dtable, string EditAction, string NewsID)
        {
            return dal.NewsTitletf(NewsTitle, dtable, EditAction, NewsID);
        }
         /// <summary>
        /// 通用获取新闻内容
        /// </summary>
        /// <param name="field">要查询的字段名，多个字段用，隔开</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataTable GetNewsConent(string field, string where,string order)
        {
            return dal.GetNewsConent(field, where,order);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="uc2"></param>
        public void UpdateNewsContent(Foosun.Model.News uc)
        {
            dal.UpdateNewsContent(uc);
        }
        /// <summary>
        /// 插入新记录
        /// </summary>
        /// <param name="uc2"></param>
        public void InsertNewsContent(Foosun.Model.News uc)
        {
            dal.InsertNewsContent(uc);
        }
         /// <summary>
        /// 得到不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
        /// <returns></returns>
        public DataTable GetUnNews(string UnID)
        {
            return dal.GetUnNews(UnID);
        }
        /// <summary>
        /// 删除不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
        public void DelUnNews(string UnID)
        {
            dal.DelUnNews(UnID);
        }
        /// <summary>
        /// 插入不规则新闻
        /// </summary>
        /// <param name="unName"></param>
        /// <param name="titleCSS"></param>
        /// <param name="SubCSS"></param>
        /// <param name="unNewsid"></param>
        /// <param name="Arr_OldNewsId"></param>
        /// <param name="NewsRow"></param>
        /// <param name="NewsTitle"></param>
        /// <param name="NewsTable"></param>
        /// <param name="SiteID"></param>
        /// <returns></returns>
        public int AddUnNews(string unName, string titleCSS, string SubCSS, string unNewsid, string Arr_OldNewsId, string NewsRow, string NewsTitle, string NewsTable, string SiteID)
        {
            return dal.AddUnNews(unName, titleCSS, SubCSS, unNewsid, Arr_OldNewsId, NewsRow, NewsTitle, NewsTable, SiteID);
        }
        /// <summary>
        /// 管理员发布新闻统计
        /// </summary>
        /// <param name="stime">开始时间</param>
        /// <param name="etime">结束时间</param>
        /// <param name="top">查询多少条</param>
        /// <returns></returns>
        public DataTable GetNewsStat(string stime, string etime, int top)
        {
            return dal.GetNewsStat(stime, etime, top);

        }
        /// <summary>
        /// 新闻点击排行
        /// </summary>
        /// <param name="stime">开始时间</param>
        /// <param name="etime">结束时间</param>
        /// <param name="top">查询多少条</param>
        /// <returns></returns>
        public DataTable GetNewsClick(string stime, string etime, int top)
        {
            return dal.GetNewsClick(stime, etime, top);
        }
        #endregion  新闻
        #region 自定义字段
        /// <summary>
        /// 得到自定义字段类型
        /// </summary>
        /// <param name="ClassID">栏目的ClassID</param>
        /// <returns></returns>
        public DataTable GetdefineEditTable(string ClassID)
        {
            return dal.GetdefineEditTable(ClassID);
        }
         /// <summary>
        /// 得到某个自定义字段的值
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetdefineEditTablevalue(int ID)
        {
            return dal.GetdefineEditTablevalue(ID);
        }
          /// <summary>
        /// 去得自定义字段的默认值
        /// </summary>
        /// <param name="defineColumns">英文名称</param>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="DataLib">数据库表</param>
        /// <param name="DsApiID">apiid</param>
        /// <returns></returns>
        public DataTable ModifyNewsDefineValue(string defineColumns, string NewsID, string DataLib, string DsApiID)
        {
            return dal.ModifyNewsDefineValue(defineColumns, NewsID, DataLib, DsApiID);
        }
         /// <summary>
        /// 插入/修改自定义字段
        /// </summary>
        /// <param name="DsNewsID"></param>
        /// <param name="DsEName"></param>
        /// <param name="DsNewsTable"></param>
        /// <param name="DsType"></param>
        /// <param name="DsContent"></param>
        /// <param name="DsApiID"></param>
        public void SetDefineSign(string DsNewsID, string DsEName, string DsNewsTable, int DsType, string DsContent, string DsApiID)
        {
            dal.SetDefineSign(DsNewsID, DsEName, DsNewsTable, DsType, DsContent, DsApiID);
        }
        #endregion 自定义字段
        #region tag
        /// <summary>
        /// 得到最新的tag
        /// </summary>
        /// <returns></returns>
        public DataTable GetTagsList()
        {
            return dal.GetTagsList();
        }
        #endregion tag
            /// <summary>
        /// 得到头条(NewsID)
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataLib"></param>
        /// <returns></returns>
        public DataTable GetTopline(string NewsID, string DataLib, int NewsTFNum)
        {
            return dal.GetTopline(NewsID, DataLib, NewsTFNum);
        }
          /// <summary>
        /// 插入头条
        /// </summary>
        /// <param name="uc2"></param>
        public void IntsertTT(Foosun.Model.NewsContentTT uc)
        {
            dal.IntsertTT(uc);
        }
        /// <summary>
        /// 更新头条
        /// </summary>
        /// <param name="uc2"></param>
        public void UpdateTT(Foosun.Model.NewsContentTT uc)
        {
            dal.UpdateTT(uc);
        }
        #region 归档新闻
        /// <summary>
        /// 批量删除归档新闻
        /// </summary>
        /// <param name="idlist">归档新闻id列表</param>
        /// <returns></returns>
        public int DelOld(string idlist)
        {
            return dal.DelOld(idlist);
        }
        /// <summary>
        /// 删除全部归档新闻
        /// </summary>
        /// <returns></returns>
        public int DelOld()
        {
            return dal.DelOld();
        }
        /// <summary>
        /// 通用更新归档新闻方法
        /// </summary>
        /// <param name="NewsID">新闻ID</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        public int UpdateOld(string idlist, int type, string value, string field)
        {
            return dal.UpdateOld(idlist, type, value, field);
        }
          /// <summary>
        /// 插入归档新闻
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Add_old_News(string where)
        {
            return dal.Add_old_News(where);
        }
        #endregion
        /// <summary>
        /// 得到继承栏目的DataTable
        /// </summary>      
        /// <returns></returns>
        public DataTable GetSysParam()
        {
            return dal.GetSysParam();
        }
        /// <summary>
        /// 插入常规
        /// </summary>
        /// <param name="_TempStr"></param>
        /// <param name="_URL"></param>
        /// <param name="_EmailURL"></param>
        /// <param name="_num"></param>
        public void IGen(string _TempStr, string _URL, string _EmailURL, int _num)
        {
            dal.IGen(_TempStr, _URL, _EmailURL, _num);
        }
         /// <summary>
        /// 得到内部连接地址
        /// </summary>
        /// <returns></returns>
        public DataTable GetGenContent()
        {
            return dal.GetGenContent();
        }
         /// <summary>
        /// 添加专题新闻
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="SpecialID"></param>
        public void AddSpecial(string NewsID, string SpecialID)
        {
            dal.AddSpecial(NewsID, SpecialID);
        }

        public DataTable GetLastFormTB()
        {
            return dal.GetLastFormTB();
        }

        public string GetNewsReview(string ID, string gType)
        {
            return dal.GetNewsReview(ID, gType);
        }

        /// <summary>
        /// 得到评论数量
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="Todays"></param>
        /// <returns></returns>
        public string GetCommCounts(string NewsID, string Todays)
        {
            return dal.GetCommCounts(NewsID, Todays);
        }

        /// <summary>
        /// 得到评论列表
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetCommentList(string NewsID)
        {
            return dal.GetCommentList(NewsID);
        }

        public string GetChannelTable(int ChID)
        {
            return dal.GetChannelTable(ChID);
        }

        public IDataReader GetNewsInfo(string NewsID, int ChID)
        {
            return dal.GetNewsInfo(NewsID, ChID);
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public int AddComment(Foosun.Model.Comment ci)
        {
            return dal.AddComment(ci);
        }

        /// <summary>
        /// 得到评论数
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="num"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int returncomment(string infoID, int num, int type)
        {
            return dal.returncomment(infoID, num, type);
        }

        /// <summary>
        /// 得到评论观点
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int returnCommentGD(string infoID, int num)
        {
            return dal.returnCommentGD(infoID, num);
        }

        /// <summary>
        /// 更新新闻状态
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="NewsID"></param>
        public void UpdateNewsHTML(int Num, string NewsID)
        {
            dal.UpdateNewsHTML(Num, NewsID);
        }

        /// <summary>
        /// 根据ID获取NewsID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNewsIDfromID1(string id)
        {
            return dal.GetNewsIDfromID1(id);
        }

        /// <summary>
        /// 添加新闻点击
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public int AddNewsClick(string NewsID)
        {
            return dal.AddNewsClick(NewsID);
        }

        /// <summary>
        /// 得到新闻的DIG数
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="getNum"></param>
        /// <returns></returns>
        public int GetTopNum(string NewsID, string getNum)
        {
            return dal.GetTopNum(NewsID, getNum);
        }

        /// <summary>
        /// 得到新闻的UNDIG数
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="Undigs"></param>
        /// <returns></returns>
        public int GetUndigs(string NewsID, string Undigs)
        {
            return dal.GetUndigs(NewsID, Undigs);
        }
        /// <summary>
        /// 获得省份或城市的信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetProvinceOrCityList(string pid)
        {
            return dal.GetProvinceOrCityList(pid);
        }

        public string GetNewsAccessory(int id)
        {
            return dal.GetNewsAccessory(id);
        }

        /// <summary>
        /// 获取新闻投票
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetVote(string NewsID)
        {
            return dal.GetVote(NewsID);
        }
    }
}


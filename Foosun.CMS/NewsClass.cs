using System;
using System.Collections.Generic;
using System.Text;
using Foosun.DALFactory;
using Foosun.IDAL;
using System.Data;

namespace Foosun.CMS
{
    /// <summary>
    /// 栏目逻辑类
    /// </summary>
    public partial class NewsClass
    {
        private readonly Foosun.IDAL.INewsClass dal = DataAccess.CreateNewsClass();

        public NewsClass()
        { }

        #region  实现方式
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public int ExistsByClassId(string Id)
        {
            return dal.ExistsByClassId(Id);
        }
        /// <summary>
        /// 是否存在该记录(EName)
        /// </summary>
        public int ExistsByClassEName(string eName)
        {
            return dal.ExistsByClassEName(eName);
        }
        /// <summary>
        /// 通用判断是否存在该记录
        /// </summary>
        public int Exists(string where)
        {
            return dal.Exists(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Foosun.Model.NewsClass model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsClass model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsClass GetModel(string ClassID)
        {

            return dal.GetModel(ClassID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.NewsClass GetModelByCache(string ClassID)
        {

            string CacheKey = "NewsClassModel-" + ClassID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ClassID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.NewsClass)objModel;
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
        public List<Foosun.Model.NewsClass> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.NewsClass> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.NewsClass> modelList = new List<Foosun.Model.NewsClass>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.NewsClass model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.NewsClass();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["ClassID"] != null && dt.Rows[n]["ClassID"].ToString() != "")
                    {
                        model.ClassID = dt.Rows[n]["ClassID"].ToString();
                    }
                    if (dt.Rows[n]["ClassCName"] != null && dt.Rows[n]["ClassCName"].ToString() != "")
                    {
                        model.ClassCName = dt.Rows[n]["ClassCName"].ToString();
                    }
                    if (dt.Rows[n]["ClassEName"] != null && dt.Rows[n]["ClassEName"].ToString() != "")
                    {
                        model.ClassEName = dt.Rows[n]["ClassEName"].ToString();
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = dt.Rows[n]["ParentID"].ToString();
                    }
                    if (dt.Rows[n]["IsURL"] != null && dt.Rows[n]["IsURL"].ToString() != "")
                    {
                        model.IsURL = int.Parse(dt.Rows[n]["IsURL"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["URLaddress"] != null && dt.Rows[n]["URLaddress"].ToString() != "")
                    {
                        model.URLaddress = dt.Rows[n]["URLaddress"].ToString();
                    }
                    if (dt.Rows[n]["Domain"] != null && dt.Rows[n]["Domain"].ToString() != "")
                    {
                        model.Domain = dt.Rows[n]["Domain"].ToString();
                    }
                    if (dt.Rows[n]["ClassTemplet"] != null && dt.Rows[n]["ClassTemplet"].ToString() != "")
                    {
                        model.ClassTemplet = dt.Rows[n]["ClassTemplet"].ToString();
                    }
                    if (dt.Rows[n]["ReadNewsTemplet"] != null && dt.Rows[n]["ReadNewsTemplet"].ToString() != "")
                    {
                        model.ReadNewsTemplet = dt.Rows[n]["ReadNewsTemplet"].ToString();
                    }
                    if (dt.Rows[n]["SavePath"] != null && dt.Rows[n]["SavePath"].ToString() != "")
                    {
                        model.SavePath = dt.Rows[n]["SavePath"].ToString();
                    }
                    if (dt.Rows[n]["SaveClassframe"] != null && dt.Rows[n]["SaveClassframe"].ToString() != "")
                    {
                        model.SaveClassframe = dt.Rows[n]["SaveClassframe"].ToString();
                    }
                    if (dt.Rows[n]["Checkint"] != null && dt.Rows[n]["Checkint"].ToString() != "")
                    {
                        model.Checkint = int.Parse(dt.Rows[n]["Checkint"].ToString());
                    }
                    if (dt.Rows[n]["ClassSaveRule"] != null && dt.Rows[n]["ClassSaveRule"].ToString() != "")
                    {
                        model.ClassSaveRule = dt.Rows[n]["ClassSaveRule"].ToString();
                    }
                    if (dt.Rows[n]["ClassIndexRule"] != null && dt.Rows[n]["ClassIndexRule"].ToString() != "")
                    {
                        model.ClassIndexRule = dt.Rows[n]["ClassIndexRule"].ToString();
                    }
                    if (dt.Rows[n]["NewsSavePath"] != null && dt.Rows[n]["NewsSavePath"].ToString() != "")
                    {
                        model.NewsSavePath = dt.Rows[n]["NewsSavePath"].ToString();
                    }
                    if (dt.Rows[n]["NewsFileRule"] != null && dt.Rows[n]["NewsFileRule"].ToString() != "")
                    {
                        model.NewsFileRule = dt.Rows[n]["NewsFileRule"].ToString();
                    }
                    if (dt.Rows[n]["PicDirPath"] != null && dt.Rows[n]["PicDirPath"].ToString() != "")
                    {
                        model.PicDirPath = dt.Rows[n]["PicDirPath"].ToString();
                    }
                    if (dt.Rows[n]["ContentPicTF"] != null && dt.Rows[n]["ContentPicTF"].ToString() != "")
                    {
                        model.ContentPicTF = int.Parse(dt.Rows[n]["ContentPicTF"].ToString());
                    }
                    if (dt.Rows[n]["ContentPICurl"] != null && dt.Rows[n]["ContentPICurl"].ToString() != "")
                    {
                        model.ContentPICurl = dt.Rows[n]["ContentPICurl"].ToString();
                    }
                    if (dt.Rows[n]["ContentPicSize"] != null && dt.Rows[n]["ContentPicSize"].ToString() != "")
                    {
                        model.ContentPicSize = dt.Rows[n]["ContentPicSize"].ToString();
                    }
                    if (dt.Rows[n]["InHitoryDay"] != null && dt.Rows[n]["InHitoryDay"].ToString() != "")
                    {
                        model.InHitoryDay = int.Parse(dt.Rows[n]["InHitoryDay"].ToString());
                    }
                    if (dt.Rows[n]["DataLib"] != null && dt.Rows[n]["DataLib"].ToString() != "")
                    {
                        model.DataLib = dt.Rows[n]["DataLib"].ToString();
                    }
                    if (dt.Rows[n]["SiteID"] != null && dt.Rows[n]["SiteID"].ToString() != "")
                    {
                        model.SiteID = dt.Rows[n]["SiteID"].ToString();
                    }
                    if (dt.Rows[n]["NaviShowtf"] != null && dt.Rows[n]["NaviShowtf"].ToString() != "")
                    {
                        model.NaviShowtf = int.Parse(dt.Rows[n]["NaviShowtf"].ToString());
                    }
                    if (dt.Rows[n]["NaviPIC"] != null && dt.Rows[n]["NaviPIC"].ToString() != "")
                    {
                        model.NaviPIC = dt.Rows[n]["NaviPIC"].ToString();
                    }
                    if (dt.Rows[n]["NaviContent"] != null && dt.Rows[n]["NaviContent"].ToString() != "")
                    {
                        model.NaviContent = dt.Rows[n]["NaviContent"].ToString();
                    }
                    if (dt.Rows[n]["MetaKeywords"] != null && dt.Rows[n]["MetaKeywords"].ToString() != "")
                    {
                        model.MetaKeywords = dt.Rows[n]["MetaKeywords"].ToString();
                    }
                    if (dt.Rows[n]["MetaDescript"] != null && dt.Rows[n]["MetaDescript"].ToString() != "")
                    {
                        model.MetaDescript = dt.Rows[n]["MetaDescript"].ToString();
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
                    if (dt.Rows[n]["FileName"] != null && dt.Rows[n]["FileName"].ToString() != "")
                    {
                        model.FileName = dt.Rows[n]["FileName"].ToString();
                    }
                    if (dt.Rows[n]["isLock"] != null && dt.Rows[n]["isLock"].ToString() != "")
                    {
                        model.isLock = int.Parse(dt.Rows[n]["isLock"].ToString());
                    }
                    if (dt.Rows[n]["isRecyle"] != null && dt.Rows[n]["isRecyle"].ToString() != "")
                    {
                        model.isRecyle = int.Parse(dt.Rows[n]["isRecyle"].ToString());
                    }
                    if (dt.Rows[n]["NaviPosition"] != null && dt.Rows[n]["NaviPosition"].ToString() != "")
                    {
                        model.NaviPosition = dt.Rows[n]["NaviPosition"].ToString();
                    }
                    if (dt.Rows[n]["NewsPosition"] != null && dt.Rows[n]["NewsPosition"].ToString() != "")
                    {
                        model.NewsPosition = dt.Rows[n]["NewsPosition"].ToString();
                    }
                    if (dt.Rows[n]["isComm"] != null && dt.Rows[n]["isComm"].ToString() != "")
                    {
                        model.isComm = int.Parse(dt.Rows[n]["isComm"].ToString());
                    }
                    if (dt.Rows[n]["Defineworkey"] != null && dt.Rows[n]["Defineworkey"].ToString() != "")
                    {
                        model.Defineworkey = dt.Rows[n]["Defineworkey"].ToString();
                    }
                    if (dt.Rows[n]["CreatTime"] != null && dt.Rows[n]["CreatTime"].ToString() != "")
                    {
                        model.CreatTime = DateTime.Parse(dt.Rows[n]["CreatTime"].ToString());
                    }
                    if (dt.Rows[n]["isPage"] != null && dt.Rows[n]["isPage"].ToString() != "")
                    {
                        model.isPage = int.Parse(dt.Rows[n]["isPage"].ToString());
                    }
                    if (dt.Rows[n]["PageContent"] != null && dt.Rows[n]["PageContent"].ToString() != "")
                    {
                        model.PageContent = dt.Rows[n]["PageContent"].ToString();
                    }
                    if (dt.Rows[n]["ModelID"] != null && dt.Rows[n]["ModelID"].ToString() != "")
                    {
                        model.ModelID = dt.Rows[n]["ModelID"].ToString();
                    }
                    if (dt.Rows[n]["isunHTML"] != null && dt.Rows[n]["isunHTML"].ToString() != "")
                    {
                        model.isunHTML = int.Parse(dt.Rows[n]["isunHTML"].ToString());
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
            return GetList("");
        }

         /// <summary>
        /// 通用更新栏目方法
        /// </summary>
        /// <param name="ClassID">栏目的classid</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        /// <returns></returns>
        public int UpdateClass(string ClassID, int type, string value, string field)
        {
            return dal.UpdateClass(ClassID, type, value, field);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 复位栏目(复位选中栏目)
        /// </summary>
        /// <param name="ids">栏目编号</param>
        /// <returns></returns>
        public int ResetClass(string ids)
        {
            return dal.ResetClass(ids);
        }
        /// <summary>
        /// 合并栏目
        /// </summary>
        /// <param name="sourceClassId">源栏目编号</param>
        /// <param name="targetClassId">目标栏目编号</param>
        /// <returns></returns>
        public int MergerClass(string sourceClassId, string targetClassId)
        {
            return dal.MergerClass(sourceClassId, targetClassId);
        }
        /// <summary>
        /// 栏目转移
        /// </summary>
        /// <param name="sourceClassId">源栏目编号</param>
        /// <param name="targetClassId">目标栏目编号</param>
        /// <returns></returns>
        public int TransferClass(string sourceClassId, string targetClassId)
        {
            return dal.TransferClass(sourceClassId, targetClassId);
        }
        /// <summary>
        /// 初始化栏目
        /// </summary>
        /// <returns></returns>
        public int InitializeClass()
        {
            return dal.InitializeClass();
        }
        /// <summary>
        /// 设置栏目属性
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <param name="classTemplet">栏目列表模版</param>
        /// <param name="readNewTemplet">新闻浏览模版</param>
        /// <param name="isUpdate">是否更新栏目下的新闻模版</param>
        /// <returns></returns>
        public int SetClassAttribute(string classId, string classTemplet, string readNewTemplet, bool isUpdate)
        {
            return dal.SetClassAttribute(classId, classTemplet, readNewTemplet, isUpdate);
        }
        /// <summary>
        /// 锁定/解锁栏目
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int SetLock(string classId)
        {
            return dal.SetLock(classId);
        }
        /// <summary>
        /// 放入\还原回收站
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int SetRecyle(string classId)
        {
            return dal.SetRecyle(classId);
        }
        /// <summary>
        /// 清空栏目
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int ClearNews(string classId)
        {
            return dal.ClearNews(classId);
        }
        /// <summary>
        /// 设置栏目权重
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <param name="orderId">权重</param>
        /// <returns></returns>
        public int SetOrder(string classId, int orderId)
        {
            return dal.SetOrder(classId, orderId);
        }
        /// <summary>
        /// 得到导航内容
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public IDataReader GetNaviClass(string classID)
        {
            return dal.GetNaviClass(classID);
        }
        /// <summary>
        /// 更新导航
        /// </summary>
        /// <param name="classID"></param>
        public void UpdateReplaceNavi(string classID)
        {
            dal.UpdateReplaceNavi(classID);
        }
        /// <summary>
        /// 得到该栏目新闻的数据表名
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public string GetDataLib(string ClassID)
        {
            return dal.GetDataLib(ClassID);
        }
        /// <summary>
        /// 通用获取栏目的内容
        /// </summary>
        /// <param name="field">要获取的字段名，多个字段用，隔开</param>
        /// <param name="where">查询的条件</param>
        /// <returns></returns>
        public DataTable GetContent(string field, string where, string order)
        {
            return dal.GetContent(field, where, order);
        }

        /// <summary>
        /// 新闻栏目分页
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public DataTable GetPage(string siteId, int pageSize, int pageIndex, out int recordCount, out int pageCount)
        {
            return dal.GetPage(siteId, pageSize, pageIndex, out recordCount, out pageCount);
        }

        /// <summary>
        /// 查询该栏目下是否有子栏目
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int ExistsChild(string classId)
        {
            return dal.ExistsChild(classId);
        }

        /// <summary>
        /// 获取该栏目下的新闻条数
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataTable GetNewsCount()
        {
            return dal.GetNewsCount();
        }

        /// <summary>
        /// 得到栏目下的子栏目
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataTable GetChildList(string parentID)
        {
            return dal.GetChildList(parentID);
        }

        /// <summary>
        /// 得到源栏目列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetSouceClass()
        {
            return dal.GetSouceClass();
        }

        /// <summary>
        /// 删除源栏目
        /// </summary>
        /// <param name="classID"></param>
        public void DelSouce(string classID)
        {
            dal.DelSouce(classID);
        }

        /// <summary>
        /// 更新源栏目
        /// </summary>
        /// <param name="sClassID"></param>
        /// <param name="tClassID"></param>
        public void UpdateSouce(string sClassID, string tClassID)
        {
            dal.UpdateSouce(sClassID, tClassID);
        }
        /// <summary>
        /// 更改目标下新闻
        /// </summary>
        /// <param name="sClassID"></param>
        /// <param name="tClassID"></param>
        public void ChangeParent(string sClassID, string tClassID)
        {
            dal.ChangeParent(sClassID, tClassID);
        }

        /// <summary>
        /// 得到栏信息（批量设置属性）
        /// </summary>
        /// <returns></returns>
        public DataTable GetClassInfoTemplet()
        {
            return dal.GetClassInfoTemplet();
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="strUpdate"></param>
        /// <param name="str"></param>
        public void UpdateClassInfo(string strUpdate, string str)
        {
            dal.UpdateClassInfo(strUpdate, str);
        }
        /// <summary>
        /// 更新所有的表
        /// </summary>
        /// <param name="templet"></param>
        /// <param name="str"></param>
        public void UpdateClassNewsInfo(string templet, string str)
        {
            dal.UpdateClassNewsInfo(templet, str);
        }

        /// <summary>
        /// 得到栏目列表的子类
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public DataTable GetLock(string classID)
        {
            return dal.GetLock(classID);
        }

        /// <summary>
        /// 得到栏目下的子类并删除到回收站
        /// </summary>
        /// <param name="parentID"></param>
        public void SetChildClassRecyle(string parentID)
        {
            dal.SetChildClassRecyle(parentID);
        }

        /// <summary>
        /// 彻底删除子栏目下的栏目
        /// </summary>
        /// <param name="parentID"></param>
        public void DelChildClass(string parentID)
        {
            dal.DelChildClass(parentID);
        }

        /// <summary>
        /// 得到栏目是否是单页
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public int GetClassPage(string classID)
        {
            return dal.GetClassPage(classID);
        }

        /// <summary>
        /// 更改栏目状态
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="ClassID"></param>
        public void UpdateClassStat(int Num, string ClassID)
        {
            dal.UpdateClassStat(Num, ClassID);
        }
        /// <summary>
        /// 得到父类是否合法
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public DataTable GetParentClass(string classID)
        {
            return dal.GetParentClass(classID);
        }
        /// <summary>
        /// 得到自定义字段类型（修改）
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public DataTable GetDefineEditTable(string classId)
        {
            return dal.GetDefineEditTable(classId);
        }

        /// <summary>
        /// 得到栏目信息
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public DataTable GetClassContent(string classID)
        {
            return dal.GetClassContent(classID);
        }

        /// <summary>
        /// 得到栏目中文名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetNewsClassCName(string classId)
        {
            return dal.GetNewsClassCName(classId);
        }

        /// <summary>
        /// 更新单页面
        /// </summary>
        /// <param name="NewsClassModel"></param>
        public void UpdatePage(Foosun.Model.NewsClass NewsClassModel)
        {
            dal.UpdatePage(NewsClassModel);
        }

        /// <summary>
        /// 更新单页面
        /// </summary>
        /// <param name="NewsClassModel"></param>
        public void InsertPage(Foosun.Model.NewsClass NewsClassModel)
        {
            dal.InsertPage(NewsClassModel);
        }
        #endregion  Method
    }
}

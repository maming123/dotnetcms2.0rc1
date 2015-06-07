using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// NewsSpecial
    /// </summary>
    public partial class NewsSpecial
    {
        private readonly INewsSpecial dal = DataAccess.CreateNewsSpecial();
        public NewsSpecial()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SpecialID)
        {
            return dal.Exists(SpecialID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Foosun.Model.NewsSpecial model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsSpecial model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SpecialID)
        {

            return dal.Delete(SpecialID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SpecialIDlist)
        {
            return dal.DeleteList(SpecialIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsSpecial GetModel(string SpecialID)
        {

            return dal.GetModel(SpecialID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.NewsSpecial GetModelByCache(string SpecialID)
        {

            string CacheKey = "NewsSpecialModel-" + SpecialID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SpecialID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.NewsSpecial)objModel;
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
        public List<Foosun.Model.NewsSpecial> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.NewsSpecial> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.NewsSpecial> modelList = new List<Foosun.Model.NewsSpecial>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.NewsSpecial model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.NewsSpecial();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["SpecialID"] != null && dt.Rows[n]["SpecialID"].ToString() != "")
                    {
                        model.SpecialID = dt.Rows[n]["SpecialID"].ToString();
                    }
                    if (dt.Rows[n]["SpecialCName"] != null && dt.Rows[n]["SpecialCName"].ToString() != "")
                    {
                        model.SpecialCName = dt.Rows[n]["SpecialCName"].ToString();
                    }
                    if (dt.Rows[n]["specialEName"] != null && dt.Rows[n]["specialEName"].ToString() != "")
                    {
                        model.specialEName = dt.Rows[n]["specialEName"].ToString();
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = dt.Rows[n]["ParentID"].ToString();
                    }
                    if (dt.Rows[n]["Domain"] != null && dt.Rows[n]["Domain"].ToString() != "")
                    {
                        model.Domain = dt.Rows[n]["Domain"].ToString();
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
                    if (dt.Rows[n]["saveDirPath"] != null && dt.Rows[n]["saveDirPath"].ToString() != "")
                    {
                        model.saveDirPath = dt.Rows[n]["saveDirPath"].ToString();
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
                    if (dt.Rows[n]["NaviPicURL"] != null && dt.Rows[n]["NaviPicURL"].ToString() != "")
                    {
                        model.NaviPicURL = dt.Rows[n]["NaviPicURL"].ToString();
                    }
                    if (dt.Rows[n]["NaviContent"] != null && dt.Rows[n]["NaviContent"].ToString() != "")
                    {
                        model.NaviContent = dt.Rows[n]["NaviContent"].ToString();
                    }
                    if (dt.Rows[n]["SiteID"] != null && dt.Rows[n]["SiteID"].ToString() != "")
                    {
                        model.SiteID = dt.Rows[n]["SiteID"].ToString();
                    }
                    if (dt.Rows[n]["Templet"] != null && dt.Rows[n]["Templet"].ToString() != "")
                    {
                        model.Templet = dt.Rows[n]["Templet"].ToString();
                    }
                    if (dt.Rows[n]["isLock"] != null && dt.Rows[n]["isLock"].ToString() != "")
                    {
                        model.isLock = int.Parse(dt.Rows[n]["isLock"].ToString());
                    }
                    if (dt.Rows[n]["isRecyle"] != null && dt.Rows[n]["isRecyle"].ToString() != "")
                    {
                        model.isRecyle = int.Parse(dt.Rows[n]["isRecyle"].ToString());
                    }
                    if (dt.Rows[n]["CreatTime"] != null && dt.Rows[n]["CreatTime"].ToString() != "")
                    {
                        model.CreatTime = DateTime.Parse(dt.Rows[n]["CreatTime"].ToString());
                    }
                    if (dt.Rows[n]["NaviPosition"] != null && dt.Rows[n]["NaviPosition"].ToString() != "")
                    {
                        model.NaviPosition = dt.Rows[n]["NaviPosition"].ToString();
                    }
                    if (dt.Rows[n]["ModelID"] != null && dt.Rows[n]["ModelID"].ToString() != "")
                    {
                        model.ModelID = dt.Rows[n]["ModelID"].ToString();
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
        /// 分页获取数据列表
        /// </summary>
        //public DataTable GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        /// <summary>
        /// 根据中文名称查询专题信息
        /// </summary>
        /// <param name="specialCName"></param>
        /// <returns></returns>
        public DataTable GetSpecialByCName(string specialCName)
        {
            return dal.GetSpecialByCName(specialCName);
        }

        /// <summary>
        /// 专题分页
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
        /// 得到子专题
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public DataTable GetChildList(string classid)
        {
            return dal.GetChildList(classid);
        }

        /// <summary>
        /// 锁定/解锁专题
        /// </summary>
        /// <param name="specialID"></param>
        /// <returns></returns>
        public int SetLock(string specialID)
        {
            return dal.SetLock(specialID);
        }

        /// <summary>
        /// 撤回/放入回收站
        /// </summary>
        /// <param name="specialId"></param>
        /// <returns></returns>
        public int SetRecyle(string specialId)
        {
            return dal.SetRecyle(specialId);
        }

        /// <summary>
        /// 获取专题下的新闻总数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetSpicaelNewsCount(string id)
        {
            return dal.GetSpicaelNewsCount(id);
        }

        /// <summary>
        /// 根据父ID获取专题信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public IDataReader GetSpecialByParentId(string parentID)
        {
            return dal.GetSpecialByParentId(parentID);
        }

        /// <summary>
        /// 更新专题模板
        /// </summary>
        /// <param name="specialID"></param>
        /// <param name="templet"></param>
        public void UpdateTemplet(string specialID, string templet)
        {
             dal.UpdateTemplet(specialID, templet);
        }

        /// <summary>
        /// 通用获取专题信息
        /// </summary>
        /// <param name="field"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataTable GetContent(string field, string where, string order)
        {
            return dal.GetContent(field, where, order);
        }
        #endregion  Method
    }
}


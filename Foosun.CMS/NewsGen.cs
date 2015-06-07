using System;
using System.Data;
using System.Collections.Generic;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// NewsGen
    /// </summary>
    public partial class NewsGen
    {
        private readonly INewsGen dal = DataAccess.CreateNewsGen();
        public NewsGen()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Foosun.Model.NewsGen model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsGen model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsGen GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.NewsGen GetModelByCache(int id)
        {

            string CacheKey = "NewsGenModel-" + id;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.NewsGen)objModel;
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
        public DataTable GetList(int top, string strWhere, string filedOrder)
        {
            return dal.GetList(top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.NewsGen> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.NewsGen> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.NewsGen> modelList = new List<Foosun.Model.NewsGen>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.NewsGen model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.NewsGen();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["Cname"] != null && dt.Rows[n]["Cname"].ToString() != "")
                    {
                        model.Cname = dt.Rows[n]["Cname"].ToString();
                    }
                    if (dt.Rows[n]["gType"] != null && dt.Rows[n]["gType"].ToString() != "")
                    {
                        model.gType = int.Parse(dt.Rows[n]["gType"].ToString());
                    }
                    if (dt.Rows[n]["URL"] != null && dt.Rows[n]["URL"].ToString() != "")
                    {
                        model.URL = dt.Rows[n]["URL"].ToString();
                    }
                    if (dt.Rows[n]["EmailURL"] != null && dt.Rows[n]["EmailURL"].ToString() != "")
                    {
                        model.EmailURL = dt.Rows[n]["EmailURL"].ToString();
                    }
                    if (dt.Rows[n]["isLock"] != null && dt.Rows[n]["isLock"].ToString() != "")
                    {
                        model.isLock = int.Parse(dt.Rows[n]["isLock"].ToString());
                    }
                    if (dt.Rows[n]["SiteID"] != null && dt.Rows[n]["SiteID"].ToString() != "")
                    {
                        model.SiteID = dt.Rows[n]["SiteID"].ToString();
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
        public DataTable GetListByPage(string gType, int pageSize, int pageIndex, out int recordCount, out int pageCount)
        {
            return dal.GetList(gType, pageSize, pageIndex, out recordCount, out pageCount);
        }

        #endregion  Method
    }
}


using System;
using System.Data;
using System.Collections.Generic;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// DefineData
    /// </summary>
    public partial class DefineData
    {
        private readonly IDefineData dal = DataAccess.CreateDefineData();
        public DefineData()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string defineInfoId)
        {
            return dal.Exists(defineInfoId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.DefineData model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.DefineData model)
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
        public bool DeleteList(string defineInfoIdlist)
        {
            return dal.DeleteList(defineInfoIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.DefineData GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.DefineData GetModelByCache(int id)
        {

            string CacheKey = "DefineDataModel-" + id;
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
            return (Foosun.Model.DefineData)objModel;
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
        public List<Foosun.Model.DefineData> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.DefineData> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.DefineData> modelList = new List<Foosun.Model.DefineData>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.DefineData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.DefineData();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["defineInfoId"] != null && dt.Rows[n]["defineInfoId"].ToString() != "")
                    {
                        model.defineInfoId = dt.Rows[n]["defineInfoId"].ToString();
                    }
                    if (dt.Rows[n]["defineCname"] != null && dt.Rows[n]["defineCname"].ToString() != "")
                    {
                        model.defineCname = dt.Rows[n]["defineCname"].ToString();
                    }
                    if (dt.Rows[n]["defineColumns"] != null && dt.Rows[n]["defineColumns"].ToString() != "")
                    {
                        model.defineColumns = dt.Rows[n]["defineColumns"].ToString();
                    }
                    if (dt.Rows[n]["defineType"] != null && dt.Rows[n]["defineType"].ToString() != "")
                    {
                        model.defineType = int.Parse(dt.Rows[n]["defineType"].ToString());
                    }
                    if (dt.Rows[n]["IsNull"] != null && dt.Rows[n]["IsNull"].ToString() != "")
                    {
                        model.IsNull = int.Parse(dt.Rows[n]["IsNull"].ToString());
                    }
                    if (dt.Rows[n]["defineValue"] != null && dt.Rows[n]["defineValue"].ToString() != "")
                    {
                        model.defineValue = dt.Rows[n]["defineValue"].ToString();
                    }
                    if (dt.Rows[n]["defineExpr"] != null && dt.Rows[n]["defineExpr"].ToString() != "")
                    {
                        model.defineExpr = dt.Rows[n]["defineExpr"].ToString();
                    }
                    if (dt.Rows[n]["definedvalue"] != null && dt.Rows[n]["definedvalue"].ToString() != "")
                    {
                        model.definedvalue = dt.Rows[n]["definedvalue"].ToString();
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
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetPage(string defid, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            return dal.GetPage(defid, PageIndex, PageSize, out RecordCount, out PageCount);
        }

        /// <summary>
        /// 根据中文名判断是否重复
        /// </summary>
        /// <param name="cname"></param>
        /// <returns></returns>
        public int ExistsByCName(string cname)
        {
            return dal.ExistsByCName(cname);
        }

        /// <summary>
        /// 根据英文名判断是否重复
        /// </summary>
        /// <param name="ename"></param>
        /// <returns></returns>
        public int ExistsByEName(string ename)
        {
            return dal.ExistsByEName(ename);
        }

        #endregion  Method
    }
}


using System;
using System.Data;
using System.Collections.Generic;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// DefineClass
    /// </summary>
    public partial class DefineClass
    {
        private readonly IDefineClass dal = DataAccess.CreateDefineClass();
        public DefineClass()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public int ExistsByDefineName(string defineName)
        {
            return dal.ExistsByDefineName(defineName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.DefineClass model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.DefineClass model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string defineInfoId)
        {

            return dal.Delete(defineInfoId);
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
        public Foosun.Model.DefineClass GetModel(string defineInfoId)
        {

            return dal.GetModel(defineInfoId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.DefineClass GetModelByCache(string defineInfoId)
        {

            string CacheKey = "DefineClassModel-" + defineInfoId;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(defineInfoId);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.DefineClass)objModel;
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
        public List<Foosun.Model.DefineClass> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.DefineClass> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.DefineClass> modelList = new List<Foosun.Model.DefineClass>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.DefineClass model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.DefineClass();
                    if (dt.Rows[n]["DefineId"] != null && dt.Rows[n]["DefineId"].ToString() != "")
                    {
                        model.DefineId = int.Parse(dt.Rows[n]["DefineId"].ToString());
                    }
                    if (dt.Rows[n]["defineInfoId"] != null && dt.Rows[n]["defineInfoId"].ToString() != "")
                    {
                        model.DefineInfoId = dt.Rows[n]["defineInfoId"].ToString();
                    }
                    if (dt.Rows[n]["DefineName"] != null && dt.Rows[n]["DefineName"].ToString() != "")
                    {
                        model.DefineName = dt.Rows[n]["DefineName"].ToString();
                    }
                    if (dt.Rows[n]["ParentInfoId"] != null && dt.Rows[n]["ParentInfoId"].ToString() != "")
                    {
                        model.ParentInfoId = dt.Rows[n]["ParentInfoId"].ToString();
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
            return dal.GetPage(defid, PageIndex, PageSize,out RecordCount,out PageCount);
        }

        /// <summary>
        /// 获取自定义字段分类信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDefineClassInfo()
        {
            return dal.GetDefineClassInfo();
        }

        /// <summary>
        /// 根据父ID获取自定义字段分类信息
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public DataTable GetDefineClassByParentId(string PID)
        {
            return dal.GetDefineClassByParentId(PID);
        }

        /// <summary>
        /// 判断DefineInfoId是否重复
        /// </summary>
        /// <param name="defineInfoId"></param>
        /// <returns></returns>
        public int ExistsByDefineInfoId(string defineInfoId)
        {
            return dal.ExistsByDefineInfoId(defineInfoId);
        }

        #endregion  Method
    }
}


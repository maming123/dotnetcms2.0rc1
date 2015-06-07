using System;
using System.Data;
using System.Collections.Generic;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// Navi
    /// </summary>
    public partial class Navi
    {
        private readonly INavi dal = DataAccess.CreateNavi();
        public Navi()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string am_ID)
        {
            return dal.Exists(am_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.Navi model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(string am_ChildrenID, string am_ClassID)
        {
            return dal.Update(am_ChildrenID, am_ClassID);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.Navi model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string am_ID)
        {

            return dal.Delete(am_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string am_IDlist)
        {
            return dal.DeleteList(am_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.Navi GetModel(string am_ID)
        {

            return dal.GetModel(am_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.Navi GetModelByCache(string am_ID)
        {

            string CacheKey = "NaviModel-" + am_ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(am_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.Navi)objModel;
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
        public List<Foosun.Model.Navi> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.Navi> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.Navi> modelList = new List<Foosun.Model.Navi>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.Navi model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.Navi();
                    if (dt.Rows[n]["am_ID"] != null && dt.Rows[n]["am_ID"].ToString() != "")
                    {
                        model.am_ID = int.Parse(dt.Rows[n]["am_ID"].ToString());
                    }
                    if (dt.Rows[n]["am_ClassID"] != null && dt.Rows[n]["am_ClassID"].ToString() != "")
                    {
                        model.am_ClassID = dt.Rows[n]["am_ClassID"].ToString();
                    }
                    if (dt.Rows[n]["am_Name"] != null && dt.Rows[n]["am_Name"].ToString() != "")
                    {
                        model.am_Name = dt.Rows[n]["am_Name"].ToString();
                    }
                    if (dt.Rows[n]["am_FilePath"] != null && dt.Rows[n]["am_FilePath"].ToString() != "")
                    {
                        model.am_FilePath = dt.Rows[n]["am_FilePath"].ToString();
                    }
                    if (dt.Rows[n]["am_ChildrenID"] != null && dt.Rows[n]["am_ChildrenID"].ToString() != "")
                    {
                        model.am_ChildrenID = dt.Rows[n]["am_ChildrenID"].ToString();
                    }
                    if (dt.Rows[n]["am_creatTime"] != null && dt.Rows[n]["am_creatTime"].ToString() != "")
                    {
                        model.am_creatTime = DateTime.Parse(dt.Rows[n]["am_creatTime"].ToString());
                    }
                    if (dt.Rows[n]["am_orderID"] != null && dt.Rows[n]["am_orderID"].ToString() != "")
                    {
                        model.am_orderID = int.Parse(dt.Rows[n]["am_orderID"].ToString());
                    }
                    if (dt.Rows[n]["isSys"] != null && dt.Rows[n]["isSys"].ToString() != "")
                    {
                        model.isSys = int.Parse(dt.Rows[n]["isSys"].ToString());
                    }
                    if (dt.Rows[n]["siteID"] != null && dt.Rows[n]["siteID"].ToString() != "")
                    {
                        model.siteID = dt.Rows[n]["siteID"].ToString();
                    }
                    if (dt.Rows[n]["userNum"] != null && dt.Rows[n]["userNum"].ToString() != "")
                    {
                        model.userNum = dt.Rows[n]["userNum"].ToString();
                    }
                    if (dt.Rows[n]["popCode"] != null && dt.Rows[n]["popCode"].ToString() != "")
                    {
                        model.popCode = dt.Rows[n]["popCode"].ToString();
                    }
                    if (dt.Rows[n]["imgPath"] != null && dt.Rows[n]["imgPath"].ToString() != "")
                    {
                        model.imgPath = dt.Rows[n]["imgPath"].ToString();
                    }
                    if (dt.Rows[n]["imgwidth"] != null && dt.Rows[n]["imgwidth"].ToString() != "")
                    {
                        model.imgwidth = dt.Rows[n]["imgwidth"].ToString();
                    }
                    if (dt.Rows[n]["imgheight"] != null && dt.Rows[n]["imgheight"].ToString() != "")
                    {
                        model.imgheight = dt.Rows[n]["imgheight"].ToString();
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

        public IDataReader GetNavilist()
        {
            return dal.GetNavilist();
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataTable GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}


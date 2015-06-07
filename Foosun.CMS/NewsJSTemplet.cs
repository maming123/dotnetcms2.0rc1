using System;
using System.Data;
using System.Collections.Generic;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// NewsJSTemplet
    /// </summary>
    public partial class NewsJSTemplet
    {
        private readonly INewsJSTemplet dal = DataAccess.CreateNewsJSTemplet();
        public NewsJSTemplet()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string templetID)
        {
            return dal.Exists(templetID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.NewsJSTemplet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsJSTemplet model)
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
        public bool DeleteList(string templetIDlist)
        {
            return dal.DeleteList(templetIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsJSTemplet GetModel(string templetID)
        {

            return dal.GetModel(templetID);
        }

        public Foosun.Model.NewsJSTemplet GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.NewsJSTemplet GetModelByCache(string templetID)
        {

            string CacheKey = "NewsJSTempletModel-" + templetID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(templetID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.NewsJSTemplet)objModel;
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
        public List<Foosun.Model.NewsJSTemplet> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return  DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.NewsJSTemplet> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.NewsJSTemplet> modelList = new List<Foosun.Model.NewsJSTemplet>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.NewsJSTemplet model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.NewsJSTemplet();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["TempletID"] != null && dt.Rows[n]["TempletID"].ToString() != "")
                    {
                        model.TempletID = dt.Rows[n]["TempletID"].ToString();
                    }
                    if (dt.Rows[n]["CName"] != null && dt.Rows[n]["CName"].ToString() != "")
                    {
                        model.CName = dt.Rows[n]["CName"].ToString();
                    }
                    if (dt.Rows[n]["JSClassid"] != null && dt.Rows[n]["JSClassid"].ToString() != "")
                    {
                        model.JSClassid = dt.Rows[n]["JSClassid"].ToString();
                    }
                    if (dt.Rows[n]["JSTType"] != null && dt.Rows[n]["JSTType"].ToString() != "")
                    {
                        model.JSTType = int.Parse(dt.Rows[n]["JSTType"].ToString());
                    }
                    if (dt.Rows[n]["JSTContent"] != null && dt.Rows[n]["JSTContent"].ToString() != "")
                    {
                        model.JSTContent = dt.Rows[n]["JSTContent"].ToString();
                    }
                    if (dt.Rows[n]["CreatTime"] != null && dt.Rows[n]["CreatTime"].ToString() != "")
                    {
                        model.CreatTime = DateTime.Parse(dt.Rows[n]["CreatTime"].ToString());
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
        /// js模型分页
        /// </summary>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="RecordCount">总条数</param>
        /// <param name="PageCount">总页</param>
        /// <param name="ParentID">父id</param>
        /// <returns></returns>
        public DataTable GetPage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, string ParentID)
        {
            return dal.GetPage(PageIndex, PageSize, out RecordCount, out PageCount, ParentID);
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


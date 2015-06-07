using System;
using System.Data;
using System.Collections.Generic;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// NewsJS
    /// </summary>
    public partial class NewsJS
    {
        private readonly INewsJS dal = DataAccess.CreateNewsJS();
        public NewsJS()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string jsID)
        {
            return dal.Exists(jsID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Foosun.Model.NewsJS model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Foosun.Model.NewsJS model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {
            dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string jsIDlist)
        {
            return dal.DeleteList(jsIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsJS GetModel(string jsID)
        {

            return dal.GetModel(jsID);
        }
        public Foosun.Model.NewsJS GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.NewsJS GetModelByCache(string jsID)
        {

            string CacheKey = "NewsJSModel-" + jsID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(jsID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Foosun.Model.NewsJS)objModel;
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
        public List<Foosun.Model.NewsJS> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.NewsJS> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.NewsJS> modelList = new List<Foosun.Model.NewsJS>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.NewsJS model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.NewsJS();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["JsID"] != null && dt.Rows[n]["JsID"].ToString() != "")
                    {
                        model.JsID = dt.Rows[n]["JsID"].ToString();
                    }
                    if (dt.Rows[n]["jsType"] != null && dt.Rows[n]["jsType"].ToString() != "")
                    {
                        model.jsType = int.Parse(dt.Rows[n]["jsType"].ToString());
                    }
                    if (dt.Rows[n]["JSName"] != null && dt.Rows[n]["JSName"].ToString() != "")
                    {
                        model.JSName = dt.Rows[n]["JSName"].ToString();
                    }
                    if (dt.Rows[n]["JsTempletID"] != null && dt.Rows[n]["JsTempletID"].ToString() != "")
                    {
                        model.JsTempletID = dt.Rows[n]["JsTempletID"].ToString();
                    }
                    if (dt.Rows[n]["jsNum"] != null && dt.Rows[n]["jsNum"].ToString() != "")
                    {
                        model.jsNum = int.Parse(dt.Rows[n]["jsNum"].ToString());
                    }
                    if (dt.Rows[n]["jsLenTitle"] != null && dt.Rows[n]["jsLenTitle"].ToString() != "")
                    {
                        model.jsLenTitle = int.Parse(dt.Rows[n]["jsLenTitle"].ToString());
                    }
                    if (dt.Rows[n]["jsLenNavi"] != null && dt.Rows[n]["jsLenNavi"].ToString() != "")
                    {
                        model.jsLenNavi = int.Parse(dt.Rows[n]["jsLenNavi"].ToString());
                    }
                    if (dt.Rows[n]["jsLenContent"] != null && dt.Rows[n]["jsLenContent"].ToString() != "")
                    {
                        model.jsLenContent = int.Parse(dt.Rows[n]["jsLenContent"].ToString());
                    }
                    if (dt.Rows[n]["jsContent"] != null && dt.Rows[n]["jsContent"].ToString() != "")
                    {
                        model.jsContent = dt.Rows[n]["jsContent"].ToString();
                    }
                    if (dt.Rows[n]["SiteID"] != null && dt.Rows[n]["SiteID"].ToString() != "")
                    {
                        model.SiteID = dt.Rows[n]["SiteID"].ToString();
                    }
                    if (dt.Rows[n]["jsColsNum"] != null && dt.Rows[n]["jsColsNum"].ToString() != "")
                    {
                        model.jsColsNum = int.Parse(dt.Rows[n]["jsColsNum"].ToString());
                    }
                    if (dt.Rows[n]["CreatTime"] != null && dt.Rows[n]["CreatTime"].ToString() != "")
                    {
                        model.CreatTime = DateTime.Parse(dt.Rows[n]["CreatTime"].ToString());
                    }
                    if (dt.Rows[n]["jsfilename"] != null && dt.Rows[n]["jsfilename"].ToString() != "")
                    {
                        model.jsfilename = dt.Rows[n]["jsfilename"].ToString();
                    }
                    if (dt.Rows[n]["jssavepath"] != null && dt.Rows[n]["jssavepath"].ToString() != "")
                    {
                        model.jssavepath = dt.Rows[n]["jssavepath"].ToString();
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
        /// 获取模版内容 
        /// </summary>
        /// <param name="jsTmpid"></param>
        /// <returns></returns>
        public string GetJsTmpContent(string jsTmpid)
        {
            return dal.GetJsTmpContent(jsTmpid);
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
        /// 新闻JS管理分页
        /// </summary>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="RecordCount">总条数</param>
        /// <param name="PageCount">总页数</param>
        /// <param name="JsType"></param>
        /// <returns></returns>
        public DataTable GetPage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, int JsType)
        {
            return dal.GetPage(PageIndex, PageSize, out RecordCount, out PageCount, JsType);
        }

        public DataTable GetJSFiles(string jsid)
        {
            return dal.GetJSFiles(jsid);
        }
        public DataTable GetJSNum(string jsid)
        {
            return dal.GetJSNum(jsid);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}


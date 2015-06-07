using System;
using System.Data;
using System.Collections.Generic;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.IDAL;
namespace Foosun.CMS
{
    /// <summary>
    /// NewsJSFile
    /// </summary>
    public partial class NewsJSFile
    {
        private readonly INewsJSFile dal = DataAccess.CreateNewsJSFile();
        public NewsJSFile()
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
        public bool Add(Foosun.Model.NewsJSFile model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsJSFile model)
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
        public bool DeleteList(string jsIDlist)
        {
            return dal.DeleteList(jsIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsJSFile GetModel(string jsID)
        {

            return dal.GetModel(jsID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Foosun.Model.NewsJSFile GetModelByCache(string jsID)
        {

            string CacheKey = "NewsJSFileModel-" + jsID;
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
            return (Foosun.Model.NewsJSFile)objModel;
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
        public List<Foosun.Model.NewsJSFile> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Foosun.Model.NewsJSFile> DataTableToList(DataTable dt)
        {
            List<Foosun.Model.NewsJSFile> modelList = new List<Foosun.Model.NewsJSFile>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Foosun.Model.NewsJSFile model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Foosun.Model.NewsJSFile();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["JsID"] != null && dt.Rows[n]["JsID"].ToString() != "")
                    {
                        model.JsID = dt.Rows[n]["JsID"].ToString();
                    }
                    if (dt.Rows[n]["Njf_title"] != null && dt.Rows[n]["Njf_title"].ToString() != "")
                    {
                        model.Njf_title = dt.Rows[n]["Njf_title"].ToString();
                    }
                    if (dt.Rows[n]["NewsId"] != null && dt.Rows[n]["NewsId"].ToString() != "")
                    {
                        model.NewsId = dt.Rows[n]["NewsId"].ToString();
                    }
                    if (dt.Rows[n]["NewsTable"] != null && dt.Rows[n]["NewsTable"].ToString() != "")
                    {
                        model.NewsTable = dt.Rows[n]["NewsTable"].ToString();
                    }
                    if (dt.Rows[n]["PicPath"] != null && dt.Rows[n]["PicPath"].ToString() != "")
                    {
                        model.PicPath = dt.Rows[n]["PicPath"].ToString();
                    }
                    if (dt.Rows[n]["ClassId"] != null && dt.Rows[n]["ClassId"].ToString() != "")
                    {
                        model.ClassId = dt.Rows[n]["ClassId"].ToString();
                    }
                    if (dt.Rows[n]["SiteID"] != null && dt.Rows[n]["SiteID"].ToString() != "")
                    {
                        model.SiteID = dt.Rows[n]["SiteID"].ToString();
                    }
                    if (dt.Rows[n]["CreatTime"] != null && dt.Rows[n]["CreatTime"].ToString() != "")
                    {
                        model.CreatTime = DateTime.Parse(dt.Rows[n]["CreatTime"].ToString());
                    }
                    if (dt.Rows[n]["TojsTime"] != null && dt.Rows[n]["TojsTime"].ToString() != "")
                    {
                        model.TojsTime = DateTime.Parse(dt.Rows[n]["TojsTime"].ToString());
                    }
                    if (dt.Rows[n]["ReclyeTF"] != null && dt.Rows[n]["ReclyeTF"].ToString() != "")
                    {
                        model.ReclyeTF = int.Parse(dt.Rows[n]["ReclyeTF"].ToString());
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
        /// JS新闻列表分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetJSFilePage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, int id)
        {
            return dal.GetJSFilePage(PageIndex, PageSize, out RecordCount, out PageCount, id);
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


using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层NewsJSTempletClass
    /// </summary>
    public interface INewsJSTempletClass
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string classID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Foosun.Model.NewsJSTempletClass model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.NewsJSTempletClass model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string id);
        bool DeleteList(string classIDlist);
         /// <summary>
        /// 删除分类下所有数据
        /// </summary>
        /// <param name="id"></param>
        void ClassDelete(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.NewsJSTempletClass GetModel(string classID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataTable GetList(int top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataTable GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}

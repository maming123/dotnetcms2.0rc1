using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层NewsJSFile
    /// </summary>
    public interface INewsJSFile
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string jsID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Foosun.Model.NewsJSFile model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.NewsJSFile model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int id);
        bool DeleteList(string jsIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.NewsJSFile GetModel(string jsID);
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
        /// JS新闻列表分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        DataTable GetJSFilePage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, int id);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataTable GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}

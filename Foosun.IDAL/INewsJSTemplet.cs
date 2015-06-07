using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层NewsJSTemplet
    /// </summary>
    public interface INewsJSTemplet
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string templetID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Foosun.Model.NewsJSTemplet model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.NewsJSTemplet model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int id);
        bool DeleteList(string templetIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.NewsJSTemplet GetModel(string templetID);
        Foosun.Model.NewsJSTemplet GetModel(int id);
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
        /// js模型分页
        /// </summary>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="RecordCount">总条数</param>
        /// <param name="PageCount">总页</param>
        /// <param name="ParentID">父id</param>
        /// <returns></returns>
        DataTable GetPage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, string ParentID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataTable GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}

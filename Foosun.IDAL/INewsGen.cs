using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层NewsGen
    /// </summary>
    public interface INewsGen
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Foosun.Model.NewsGen model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.NewsGen model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int id);
        bool DeleteList(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.NewsGen GetModel(int id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataTable GetList(int top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        DataTable GetList(string gType, int pageSize, int pageIndex, out int recordCount, out int pageCount);
        #endregion  成员方法
    }
}

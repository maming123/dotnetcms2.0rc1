using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层DefineSave
    /// </summary>
    public interface IDefineSave
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string DsNewsID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Foosun.Model.DefineSave model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.DefineSave model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string DsNewsID);
        bool DeleteList(string DsNewsIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.DefineSave GetModel(string DsNewsID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataTable GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataTable GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}

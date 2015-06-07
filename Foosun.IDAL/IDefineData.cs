using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层DefineData
    /// </summary>
    public interface IDefineData
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string defineInfoId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Foosun.Model.DefineData model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.DefineData model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int id);
        bool DeleteList(string defineInfoIdlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.DefineData GetModel(int defineInfoId);
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
        DataTable GetPage(string defid, int PageIndex, int PageSize, out int RecordCount, out int PageCount);

        /// <summary>
        /// 根据英文名判断是否重复
        /// </summary>
        /// <param name="ename"></param>
        /// <returns></returns>
        int ExistsByEName(string ename);
        /// <summary>
        /// 根据中文名判断是否重复
        /// </summary>
        /// <param name="cname"></param>
        /// <returns></returns>
        int ExistsByCName(string cname);
        #endregion  成员方法
    }
}

using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层DefineClass
    /// </summary>
    public interface IDefineClass
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        int ExistsByDefineName(string defineName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Foosun.Model.DefineClass model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.DefineClass model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string defineInfoId);
        bool DeleteList(string defineInfoIdlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.DefineClass GetModel(string defineInfoId);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
        /// <summary>
        /// 获取自定义字段分类信息
        /// </summary>
        /// <returns></returns>
        DataTable GetDefineClassInfo();
        DataTable GetDefineClassByParentId(string PID);
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
        /// 判断DefineInfoId是否重复
        /// </summary>
        /// <param name="defineInfoId"></param>
        /// <returns></returns>
        int ExistsByDefineInfoId(string defineInfoId);
        #endregion  成员方法
    }
}

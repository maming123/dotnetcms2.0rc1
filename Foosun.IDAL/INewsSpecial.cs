using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层NewsSpecial
    /// </summary>
    public interface INewsSpecial
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string SpecialID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        string Add(Foosun.Model.NewsSpecial model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.NewsSpecial model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string SpecialID);
        bool DeleteList(string SpecialIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.NewsSpecial GetModel(string SpecialID);
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
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);

        /// <summary>
        /// 根据中文名称查询专题信息
        /// </summary>
        /// <param name="specialCName"></param>
        /// <returns></returns>
        DataTable GetSpecialByCName(string specialCName);

        /// <summary>
        /// 专题分页
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        DataTable GetPage(string siteId, int pageSize, int pageIndex, out int recordCount, out int pageCount);

        /// <summary>
        /// 得到子专题
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        DataTable GetChildList(string classid);

        /// <summary>
        /// 锁定/解锁专题
        /// </summary>
        /// <param name="specialID"></param>
        /// <returns></returns>
        int SetLock(string specialID);

        /// <summary>
        /// 撤回/放入回收站
        /// </summary>
        /// <param name="specialId"></param>
        /// <returns></returns>
        int SetRecyle(string specialId);

        /// <summary>
        /// 获取专题下的新闻总数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetSpicaelNewsCount(string id);

        /// <summary>
        /// 根据父ID获取专题信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        IDataReader GetSpecialByParentId(string parentID);
        /// <summary>
        /// 更新专题模板
        /// </summary>
        /// <param name="specialID"></param>
        /// <param name="templet"></param>
        void UpdateTemplet(string specialID, string templet);

        /// <summary>
        /// 通用获取专题信息
        /// </summary>
        /// <param name="field"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        DataTable GetContent(string field, string where, string order);
        #endregion  成员方法
    }
}

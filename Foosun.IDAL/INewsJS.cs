using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层NewsJS
    /// </summary>
    public interface INewsJS
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string jsID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        string Add(Foosun.Model.NewsJS model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        string Update(Foosun.Model.NewsJS model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string id);
        bool DeleteList(string jsIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.NewsJS GetModel(string jsID);

        Foosun.Model.NewsJS GetModel(int id);

        /// <summary>
        /// 获取模板内容
        /// </summary>
        /// <param name="jsTmpid"></param>
        /// <returns></returns>
        string GetJsTmpContent(string jsTmpid);
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
        /// 新闻JS管理分页
        /// </summary>        
        DataTable GetPage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, int JsType);
        DataTable GetJSFiles(string jsid);
        DataTable GetJSNum(string jsid);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}

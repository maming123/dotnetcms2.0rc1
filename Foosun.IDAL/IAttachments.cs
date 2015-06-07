using System;
using System.Data;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层Attachments
    /// </summary>
    public interface IAttachments
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Foosun.Model.Attachments model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int Id);
        bool DeleteList(string Idlist);

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataTable GetPage(string fileType,string beginDate, string endDate, int PageIndex, int PageSize, out int RecordCount, out int PageCount);
        #endregion  成员方法
    }
}

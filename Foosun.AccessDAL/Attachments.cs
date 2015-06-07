using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;
using System.Data.OleDb;

namespace Foosun.AccessDAL
{
    public class Attachments : DbBase, IAttachments
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Attachments model)
        {
            string Sql = "insert into " + Pre + "Attachments(FileName,FileType,UploadDate,FileSize,FilePath)values('" + model.FileName + "','" +
                model.FileType + "','" + model.UploadDate + "','" + model.FileSize + "','" + model.FilePath + "')";
            object obj = DbHelper.ExecuteScalar(CommandType.Text, Sql, null);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "Attachments ");
            strSql.Append(" where Id=@Id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
            parameters[0].Value = Id;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="Idlist"></param>
        /// <returns></returns>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "Attachments ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="defid"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataTable GetPage(string fileType, string beginDate, string endDate, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            string where = "where 1=1 ";
            OleDbParameter param = null;
            if (fileType == null || fileType == string.Empty)
            {
                where = "";
            }
            else
            {
                where += "  and fileType=@fileType";
                param = new OleDbParameter("@fileType", fileType);
            }
            if (beginDate == null || beginDate == string.Empty)
            {
                where += "";
            }
            else
            {
                where += "  and UploadDate>=@UploadDate";
                param = new OleDbParameter("@UploadDate", beginDate);
            }
            if (endDate == null || endDate == string.Empty)
            {
                where += "";
            }
            else
            {
                where += "  and UploadDate<=@UploadDate";
                param = new OleDbParameter("@UploadDate", endDate);
            }

            string AllFields = "Id,FileName,FileType,UploadDate,FileSize,FilePath";
            string Condition = "" + Pre + "Attachments " + where + "";
            string IndexField = "Id";
            string OrderFields = "order by Id Desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, PageIndex, PageSize, out RecordCount, out PageCount, param);
        }
    }
}

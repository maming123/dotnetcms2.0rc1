using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;

namespace Foosun.SQLServerDAL
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fs_Attachments(");
            strSql.Append("FileName,FileType,UploadDate,FileSize,FilePath)");
            strSql.Append(" values (");
            strSql.Append("@FileName,@FileType,@UploadDate,@FileSize,@FilePath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FileName", SqlDbType.VarChar,50),
					new SqlParameter("@FileType", SqlDbType.VarChar,50),
					new SqlParameter("@UploadDate", SqlDbType.DateTime),
					new SqlParameter("@FileSize", SqlDbType.VarChar,50),
					new SqlParameter("@FilePath", SqlDbType.VarChar,200)};
            parameters[0].Value = model.FileName;
            parameters[1].Value = model.FileType;
            parameters[2].Value = model.UploadDate;
            parameters[3].Value = model.FileSize;
            parameters[4].Value = model.FilePath;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
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
            strSql.Append("delete from fs_Attachments ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
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
            strSql.Append("delete from fs_Attachments ");
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
        public DataTable GetPage(string fileType,string beginDate, string endDate, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            string where = "where 1=1 ";
            SqlParameter param = null;
            if (fileType == null || fileType == string.Empty)
            {
                where = "";
            }
            else
            {
                where += "  and fileType=@fileType";
                param = new SqlParameter("@fileType", fileType);
            }
            if (beginDate == null || beginDate == string.Empty)
            {
                where += "";
            }
            else
            {
                where += "  and UploadDate>=@UploadDate";
                param = new SqlParameter("@UploadDate", beginDate);
            }
            if (endDate == null || endDate == string.Empty)
            {
                where += "";
            }
            else
            {
                where += "  and UploadDate<=@UploadDate";
                param = new SqlParameter("@UploadDate", endDate);
            }

            string AllFields = "Id,FileName,FileType,UploadDate,FileSize,FilePath";
            string Condition = "" + Pre + "Attachments " + where + "";
            string IndexField = "Id";
            string OrderFields = "order by Id Desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, PageIndex, PageSize, out RecordCount, out PageCount, param);
        }
    }
}

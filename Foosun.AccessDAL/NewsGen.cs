using System;
using System.Data;
using System.Text;
using Foosun.IDAL;
using Foosun.DALProfile;
using System.Data.OleDb;//Please add references
namespace Foosun.AccessDAL
{
    /// <summary>
    /// 数据访问类:NewsGen
    /// </summary>
    public partial class NewsGen : DbBase,INewsGen
    {
        public NewsGen()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fs_news_Gen");
            strSql.Append(" where Id=@Id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Foosun.Model.NewsGen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fs_news_Gen(");
            strSql.Append("Cname,gType,URL,EmailURL,isLock,SiteID)");
            strSql.Append(" values (");
            strSql.Append("@Cname,@gType,@URL,@EmailURL,@isLock,@SiteID)");
            strSql.Append(";select @@IDENTITY");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Cname", OleDbType.VarChar,100),
					new OleDbParameter("@gType", OleDbType.TinyInt,1),
					new OleDbParameter("@URL", OleDbType.VarChar,200),
					new OleDbParameter("@EmailURL", OleDbType.VarChar,200),
					new OleDbParameter("@isLock", OleDbType.TinyInt,1),
					new OleDbParameter("@SiteID", OleDbType.VarChar,12)};
            parameters[0].Value = model.Cname;
            parameters[1].Value = model.gType;
            parameters[2].Value = model.URL;
            parameters[3].Value = model.EmailURL;
            parameters[4].Value = model.isLock;
            parameters[5].Value = model.SiteID;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsGen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fs_news_Gen set ");
            strSql.Append("Cname=@Cname,");
            strSql.Append("gType=@gType,");
            strSql.Append("URL=@URL,");
            strSql.Append("EmailURL=@EmailURL,");
            strSql.Append("isLock=@isLock,");
            strSql.Append("SiteID=@SiteID");
            strSql.Append(" where Id=@Id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Cname", OleDbType.VarChar,100),
					new OleDbParameter("@gType", OleDbType.TinyInt,1),
					new OleDbParameter("@URL", OleDbType.VarChar,200),
					new OleDbParameter("@EmailURL", OleDbType.VarChar,200),
					new OleDbParameter("@isLock", OleDbType.TinyInt,1),
					new OleDbParameter("@SiteID", OleDbType.VarChar,12),
					new OleDbParameter("@Id", OleDbType.Integer,4)};
            parameters[0].Value = model.Cname;
            parameters[1].Value = model.gType;
            parameters[2].Value = model.URL;
            parameters[3].Value = model.EmailURL;
            parameters[4].Value = model.isLock;
            parameters[5].Value = model.SiteID;
            parameters[6].Value = model.Id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fs_news_Gen ");
            strSql.Append(" where Id=@Id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fs_news_Gen ");
            strSql.Append(" where Id in (" + idlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsGen GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Cname,gType,URL,EmailURL,isLock,SiteID from fs_news_Gen ");
            strSql.Append(" where Id=@Id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            Foosun.Model.NewsGen model = new Foosun.Model.NewsGen();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["Cname"] != null && ds.Rows[0]["Cname"].ToString() != "")
                {
                    model.Cname = ds.Rows[0]["Cname"].ToString();
                }
                if (ds.Rows[0]["gType"] != null && ds.Rows[0]["gType"].ToString() != "")
                {
                    model.gType = int.Parse(ds.Rows[0]["gType"].ToString());
                }
                if (ds.Rows[0]["URL"] != null && ds.Rows[0]["URL"].ToString() != "")
                {
                    model.URL = ds.Rows[0]["URL"].ToString();
                }
                if (ds.Rows[0]["EmailURL"] != null && ds.Rows[0]["EmailURL"].ToString() != "")
                {
                    model.EmailURL = ds.Rows[0]["EmailURL"].ToString();
                }
                if (ds.Rows[0]["isLock"] != null && ds.Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Rows[0]["isLock"].ToString());
                }
                if (ds.Rows[0]["SiteID"] != null && ds.Rows[0]["SiteID"].ToString() != "")
                {
                    model.SiteID = ds.Rows[0]["SiteID"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Cname,gType,URL,EmailURL,isLock,SiteID ");
            strSql.Append(" FROM fs_news_Gen ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" Id,Cname,gType,URL,EmailURL,isLock,SiteID ");
            strSql.Append(" FROM fs_news_Gen ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM fs_news_Gen ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
        public DataTable GetList(string gType, int pageSize, int pageIndex, out int recordCount, out int pageCount)
		{
            OleDbParameter param = null;
            string where = "";
            if (gType == null || gType == string.Empty)
            {
                where = "";
            }
            else
            {
                where = "  where gType=@gType";
                param = new OleDbParameter("@gType", gType);
            }
            string AllFields = "*";
            string Condition = "" + Pre + "News_Gen " + where + "";
            string IndexField = "id";
            string OrderFields = "order by id Desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, pageIndex, pageSize, out recordCount, out pageCount, param);
		}
        #endregion  Method
    }
}


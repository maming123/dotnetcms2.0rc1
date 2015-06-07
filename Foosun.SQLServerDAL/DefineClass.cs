using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;//Please add references
namespace Foosun.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:DefineClass
    /// </summary>
    public partial class DefineClass : DbBase, IDefineClass
    {
        public DefineClass()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public int ExistsByDefineName(string defineName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(DefineId) from " + Pre + "define_class");
            strSql.Append(" where DefineName=@DefineName ");
            SqlParameter[] parameters = {
					new SqlParameter("@DefineName", SqlDbType.NVarChar,12)			
                                        };
            parameters[0].Value = defineName;

            return (int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.DefineClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Pre + "define_class(");
            strSql.Append("DefineInfoId,DefineName,ParentInfoId,SiteID)");
            strSql.Append(" values (");
            strSql.Append("@DefineInfoId,@DefineName,@ParentInfoId,@SiteID)");
            SqlParameter[] parameters = {
					new SqlParameter("@DefineInfoId", SqlDbType.NVarChar,12),
					new SqlParameter("@DefineName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentInfoId", SqlDbType.NVarChar,12),
					new SqlParameter("@SiteID", SqlDbType.NVarChar,12)};
            parameters[0].Value = model.DefineInfoId;
            parameters[1].Value = model.DefineName;
            parameters[2].Value = model.ParentInfoId;
            parameters[3].Value = model.SiteID;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.DefineClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "define_class set ");
            strSql.Append("DefineInfoId=@DefineInfoId,");
            strSql.Append("DefineName=@DefineName,");
            strSql.Append("ParentInfoId=@ParentInfoId,");
            strSql.Append("SiteID=@SiteID");
            strSql.Append(" where DefineInfoId=@DefineInfoId ");
            SqlParameter[] parameters = {
					new SqlParameter("@DefineInfoId", SqlDbType.NVarChar,12),
					new SqlParameter("@DefineName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentInfoId", SqlDbType.NVarChar,12),
					new SqlParameter("@SiteID", SqlDbType.NVarChar,12),
					new SqlParameter("@DefineId", SqlDbType.Int,4)};
            parameters[0].Value = model.DefineInfoId;
            parameters[1].Value = model.DefineName;
            parameters[2].Value = model.ParentInfoId;
            parameters[3].Value = model.SiteID;
            parameters[4].Value = model.DefineId;

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
        public bool Delete(string defineInfoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "define_class ");
            strSql.Append(" where DefineInfoId=@DefineInfoId ");
            SqlParameter[] parameters = {
					new SqlParameter("@DefineInfoId", SqlDbType.NVarChar,12)			};
            parameters[0].Value = defineInfoId;

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
        public bool DeleteList(string defineInfoIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "define_class ");
            strSql.Append(" where DefineInfoId in (" + defineInfoIdlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.DefineClass GetModel(string defineInfoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DefineId,DefineInfoId,DefineName,ParentInfoId,SiteID from " + Pre + "define_class ");
            strSql.Append(" where DefineInfoId=@DefineInfoId ");
            SqlParameter[] parameters = {
					new SqlParameter("@DefineInfoId", SqlDbType.NVarChar,12)			};
            parameters[0].Value = defineInfoId;

            Foosun.Model.DefineClass model = new Foosun.Model.DefineClass();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["DefineId"] != null && ds.Rows[0]["DefineId"].ToString() != "")
                {
                    model.DefineId = int.Parse(ds.Rows[0]["DefineId"].ToString());
                }
                if (ds.Rows[0]["DefineInfoId"] != null && ds.Rows[0]["DefineInfoId"].ToString() != "")
                {
                    model.DefineInfoId = ds.Rows[0]["DefineInfoId"].ToString();
                }
                if (ds.Rows[0]["DefineName"] != null && ds.Rows[0]["DefineName"].ToString() != "")
                {
                    model.DefineName = ds.Rows[0]["DefineName"].ToString();
                }
                if (ds.Rows[0]["ParentInfoId"] != null && ds.Rows[0]["ParentInfoId"].ToString() != "")
                {
                    model.ParentInfoId = ds.Rows[0]["ParentInfoId"].ToString();
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
            strSql.Append("select DefineId,DefineInfoId,DefineName,ParentInfoId,SiteID ");
            strSql.Append(" FROM " + Pre + "define_class ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 获取字段以字段分类信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDefineClassInfo()
        {
            string Sql = "Select DefineInfoId,DefineName,ParentInfoId From " + Pre + "define_class where SiteID='" + Foosun.Global.Current.SiteID + "'";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 根据父ID获取自定义字段分类信息
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public DataTable GetDefineClassByParentId(string PID)
        {
            SqlParameter param = new SqlParameter("@ParentInfoId", PID);
            string Sql = "Select DefineInfoId,DefineName,ParentInfoId From " + Pre + "define_class where ParentInfoId=@ParentInfoId and SiteID='" + Foosun.Global.Current.SiteID + "'";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
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
            strSql.Append(" DefineId,DefineInfoId,DefineName,ParentInfoId,SiteID ");
            strSql.Append(" FROM " + Pre + "define_class ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + Pre + "define_class ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), null);
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
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.DefineInfoId desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "define_class T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        public DataTable GetPage(string defid, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            string where = "";
            SqlParameter param = null;
            if (defid == null || defid == string.Empty)
            {
                where = "";
            }
            else
            {
                where = "  where defineInfoId=@defineInfoId";
                param = new SqlParameter("@defineInfoId", defid);
            }
            
            string AllFields = "DefineId,defineInfoId,defineName,ParentInfoId,SiteId";
            string Condition = "" + Pre + "Define_Class " + where + "";
            string IndexField = "DefineId";
            string OrderFields = "order by DefineId Desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, PageIndex, PageSize, out RecordCount, out PageCount, param);
        }

        public int ExistsByDefineInfoId(string defineInfoId)
        {
            SqlParameter param = new SqlParameter("@DefineInfoId", defineInfoId);
            string Sql = "Select count(DefineId) From " + Pre + "Define_Class Where DefineInfoId=@DefineInfoId";
            return (int)DbHelper.ExecuteScalar(CommandType.Text, Sql, param);
        }

        #endregion  Method
    }
}


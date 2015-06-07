using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;//Please add references
namespace Foosun.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:DefineData
    /// </summary>
    public partial class DefineData :DbBase, IDefineData
    {
        public DefineData()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string defineInfoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "define_data");
            strSql.Append(" where defineInfoId=@defineInfoId ");
            SqlParameter[] parameters = {
					new SqlParameter("@defineInfoId", SqlDbType.NVarChar,12)			
                                        };
            parameters[0].Value = defineInfoId;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.DefineData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Pre + "define_data(");
            strSql.Append("defineInfoId,defineCname,defineColumns,defineType,IsNull,defineValue,defineExpr,definedvalue,SiteID)");
            strSql.Append(" values (");
            strSql.Append("@defineInfoId,@defineCname,@defineColumns,@defineType,@IsNull,@defineValue,@defineExpr,@definedvalue,@SiteID)");
            SqlParameter[] parameters = {
					new SqlParameter("@defineInfoId", SqlDbType.NVarChar,12),
					new SqlParameter("@defineCname", SqlDbType.NVarChar,50),
					new SqlParameter("@defineColumns", SqlDbType.NVarChar,50),
					new SqlParameter("@defineType", SqlDbType.Int,4),
					new SqlParameter("@IsNull", SqlDbType.TinyInt,1),
					new SqlParameter("@defineValue", SqlDbType.NText),
					new SqlParameter("@defineExpr", SqlDbType.NVarChar,200),
					new SqlParameter("@definedvalue", SqlDbType.NVarChar,200),
					new SqlParameter("@SiteID", SqlDbType.NVarChar,12)};
            parameters[0].Value = model.defineInfoId;
            parameters[1].Value = model.defineCname;
            parameters[2].Value = model.defineColumns;
            parameters[3].Value = model.defineType;
            parameters[4].Value = model.IsNull;
            parameters[5].Value = model.defineValue;
            parameters[6].Value = model.defineExpr;
            parameters[7].Value = model.definedvalue;
            parameters[8].Value = model.SiteID;

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
        public bool Update(Foosun.Model.DefineData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "define_data set ");
            strSql.Append("defineInfoId=@defineInfoId,");
            strSql.Append("defineCname=@defineCname,");
            strSql.Append("defineColumns=@defineColumns,");
            strSql.Append("defineType=@defineType,");
            strSql.Append("IsNull=@IsNull,");
            strSql.Append("defineValue=@defineValue,");
            strSql.Append("defineExpr=@defineExpr,");
            strSql.Append("definedvalue=@definedvalue,");
            strSql.Append("SiteID=@SiteID");
            strSql.Append(" where defineInfoId=@defineInfoId ");
            SqlParameter[] parameters = {
					new SqlParameter("@defineInfoId", SqlDbType.NVarChar,12),
					new SqlParameter("@defineCname", SqlDbType.NVarChar,50),
					new SqlParameter("@defineColumns", SqlDbType.NVarChar,50),
					new SqlParameter("@defineType", SqlDbType.Int,4),
					new SqlParameter("@IsNull", SqlDbType.TinyInt,1),
					new SqlParameter("@defineValue", SqlDbType.NText),
					new SqlParameter("@defineExpr", SqlDbType.NVarChar,200),
					new SqlParameter("@definedvalue", SqlDbType.NVarChar,200),
					new SqlParameter("@SiteID", SqlDbType.NVarChar,12),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.defineInfoId;
            parameters[1].Value = model.defineCname;
            parameters[2].Value = model.defineColumns;
            parameters[3].Value = model.defineType;
            parameters[4].Value = model.IsNull;
            parameters[5].Value = model.defineValue;
            parameters[6].Value = model.defineExpr;
            parameters[7].Value = model.definedvalue;
            parameters[8].Value = model.SiteID;
            parameters[9].Value = model.id;

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
            strSql.Append("delete from " + Pre + "define_data ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int)			};
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
        public bool DeleteList(string defineInfoIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "define_data ");
            strSql.Append(" where defineInfoId in (" + defineInfoIdlist + ")  ");
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
        public Foosun.Model.DefineData GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,defineInfoId,defineCname,defineColumns,defineType,IsNull,defineValue,defineExpr,definedvalue,SiteID from " + Pre + "define_data ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@defineInfoId", SqlDbType.Int)			};
            parameters[0].Value = id;

            Foosun.Model.DefineData model = new Foosun.Model.DefineData();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["id"] != null && ds.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Rows[0]["id"].ToString());
                }
                if (ds.Rows[0]["defineInfoId"] != null && ds.Rows[0]["defineInfoId"].ToString() != "")
                {
                    model.defineInfoId = ds.Rows[0]["defineInfoId"].ToString();
                }
                if (ds.Rows[0]["defineCname"] != null && ds.Rows[0]["defineCname"].ToString() != "")
                {
                    model.defineCname = ds.Rows[0]["defineCname"].ToString();
                }
                if (ds.Rows[0]["defineColumns"] != null && ds.Rows[0]["defineColumns"].ToString() != "")
                {
                    model.defineColumns = ds.Rows[0]["defineColumns"].ToString();
                }
                if (ds.Rows[0]["defineType"] != null && ds.Rows[0]["defineType"].ToString() != "")
                {
                    model.defineType = int.Parse(ds.Rows[0]["defineType"].ToString());
                }
                if (ds.Rows[0]["IsNull"] != null && ds.Rows[0]["IsNull"].ToString() != "")
                {
                    model.IsNull = int.Parse(ds.Rows[0]["IsNull"].ToString());
                }
                if (ds.Rows[0]["defineValue"] != null && ds.Rows[0]["defineValue"].ToString() != "")
                {
                    model.defineValue = ds.Rows[0]["defineValue"].ToString();
                }
                if (ds.Rows[0]["defineExpr"] != null && ds.Rows[0]["defineExpr"].ToString() != "")
                {
                    model.defineExpr = ds.Rows[0]["defineExpr"].ToString();
                }
                if (ds.Rows[0]["definedvalue"] != null && ds.Rows[0]["definedvalue"].ToString() != "")
                {
                    model.definedvalue = ds.Rows[0]["definedvalue"].ToString();
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
            strSql.Append("select id,defineInfoId,defineCname,defineColumns,defineType,IsNull,defineValue,defineExpr,definedvalue,SiteID ");
            strSql.Append(" FROM " + Pre + "define_data where 1=1 and SiteId='" + Foosun.Global.Current.SiteID + "'");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,defineInfoId,defineCname,defineColumns,defineType,IsNull,defineValue,defineExpr,definedvalue,SiteID ");
            strSql.Append(" FROM " + Pre + "define_data ");
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
            strSql.Append("select count(1) FROM " + Pre + "define_data ");
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
                strSql.Append("order by T.defineInfoId desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "define_data T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetPage(string defid, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            string where = "";
            if (defid == null && defid == string.Empty)
            {
                where = "";
            }
            else
            {
                where = "  where defineInfoId=@defineInfoId";
            }
            SqlParameter param = new SqlParameter("@defineInfoId", defid);
            string AllFields = "id,defineInfoId,defineCname,defineType,[IsNull]";
            string Condition = "" + Pre + "Define_Data " + where + "";
            string IndexField = "id";
            string OrderFields = "order by id Desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, PageIndex, PageSize, out RecordCount, out PageCount, param);
        }

        /// <summary>
        /// 根据英文名判断是否重复
        /// </summary>
        /// <param name="ename"></param>
        /// <returns></returns>
        public int ExistsByEName(string ename)
        {
            SqlParameter param = new SqlParameter("@defineColumns", ename);
            string Sql = "Select count(id) From " + Pre + "Define_Data  Where defineColumns=@defineColumns";
            return (int)DbHelper.ExecuteScalar(CommandType.Text, Sql, param);
        }

        /// <summary>
        /// 根据中文名判断是否重复
        /// </summary>
        /// <param name="cname"></param>
        /// <returns></returns>
        public int ExistsByCName(string cname)
        {
            SqlParameter param = new SqlParameter("@DefineCname", cname);
            string Sql = "Select count(id) From " + Pre + "Define_Data  Where DefineCname=@DefineCname";
            return (int)DbHelper.ExecuteScalar(CommandType.Text, Sql, param);
        }


        #endregion  Method
    }
}


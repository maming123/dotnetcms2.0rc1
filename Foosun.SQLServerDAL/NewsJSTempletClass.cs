using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;
using Foosun.Global;
using Foosun.Config;
using System.Collections.Generic;//Please add references
namespace Foosun.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:NewsJSTempletClass
    /// </summary>
    public partial class NewsJSTempletClass : DbBase, INewsJSTempletClass
    {
        public NewsJSTempletClass()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string classID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_JST_Class");
            strSql.Append(" where ClassID=@ClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.NVarChar,12)			};
            parameters[0].Value = classID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.NewsJSTempletClass model)
        {
            return ClassEdit(0, model.CName, model.ParentID, model.Description);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsJSTempletClass model)
        {
            return ClassEdit(model.id, model.CName, model.ParentID, model.Description);
        }

        private bool ClassEdit(int id, string CName, string ParentID, string Description)
        {
            string Sql = "select count(*) from " + Pre + "news_JST_Class where SiteID='" + Current.SiteID + "' and CName=@CName";
            if (id > 0)
                Sql += " and id<>" + id;
            SqlParameter parm = new SqlParameter("@CName", SqlDbType.NVarChar, 50);
            parm.Value = CName;
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                cn.Open();
                int n = Convert.ToInt32(DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, parm));
                if (n > 0)
                    throw new Exception("JS模型分类名称不能重复,该分类名称已存在!");
                if (id > 0)
                {
                    Sql = "update " + Pre + "news_JST_Class set CName=@CName,ParentID=@ParentID,Description=@Description where SiteID=@SiteID and id=" + id;
                }
                else
                {
                    string CLID = Common.Rand.Str(12);
                    if (Convert.ToInt32(DbHelper.ExecuteScalar(cn, CommandType.Text, "select count(*) from " + Pre + "news_JST_Class where ClassID='" + CLID + "'")) > 0)
                    {
                        CLID = Common.Rand.Str(12, true);
                    }
                    Sql = "insert into " + Pre + "news_JST_Class (ClassID,CName,ParentID,Description,CreatTime,SiteID) values ";
                    Sql += "('" + CLID + "',@CName,@ParentID,@Description,'" + DateTime.Now + "',@SiteID)";
                }
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@CName", SqlDbType.NVarChar, 50);
                param[0].Value = CName;
                param[1] = new SqlParameter("@ParentID", SqlDbType.NVarChar, 12);
                param[1].Value = ParentID;
                param[2] = new SqlParameter("@Description", SqlDbType.NVarChar, 500);
                param[2].Value = Description.Equals("") ? DBNull.Value : (object)Description;
                param[3] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
                param[3].Value = Current.SiteID;
                return DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, param) == 1;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {

            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                if (id.IndexOf("'") >= 0) id = id.Replace("'", "''");
                IList<string> lstid = new List<string>();
                cn.Open();
                DataTable tb = DbHelper.ExecuteTable(cn, CommandType.Text, "select ClassID,ParentID from " + Pre + "news_JST_Class where SiteID='" + Current.SiteID + "'", null);
                FindChildren(tb, id, ref lstid);
                string ids = "'" + id + "'";
                foreach (string x in lstid)
                {
                    ids += ",'" + x + "'";
                }
                SqlTransaction tran = cn.BeginTransaction();
                try
                {
                    string Sql = "delete from " + Pre + "news_JSTemplet where SiteID='" + Current.SiteID + "' and JSClassid in (" + ids + ")";
                    DbHelper.ExecuteNonQuery(tran, CommandType.Text, Sql, null);
                    Sql = "delete from " + Pre + "news_JST_Class where SiteID='" + Current.SiteID + "' and ClassID in (" + ids + ")";
                    DbHelper.ExecuteNonQuery(tran, CommandType.Text, Sql, null);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        private void FindChildren(DataTable tb, string PID, ref IList<string> list)
        {
            DataRow[] row = tb.Select("ParentID='" + PID + "'");
            if (row.Length < 1)
                return;
            else
            {
                foreach (DataRow r in row)
                {
                    list.Add(r["ClassID"].ToString());
                    FindChildren(tb, r["ClassID"].ToString(), ref list);
                }
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string classIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_JST_Class ");
            strSql.Append(" where ClassID in (" + classIDlist + ")  ");
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
        /// 删除分类下所有数据
        /// </summary>
        /// <param name="id"></param>
        public void ClassDelete(string id)
        {
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                if (id.IndexOf("'") >= 0) id = id.Replace("'", "''");
                IList<string> lstid = new List<string>();
                cn.Open();
                DataTable tb = DbHelper.ExecuteTable(cn, CommandType.Text, "select ClassID,ParentID from " + Pre + "news_JST_Class where SiteID='" + Current.SiteID + "'", null);
                FindChildren(tb, id, ref lstid);
                string ids = "'" + id + "'";
                foreach (string x in lstid)
                {
                    ids += ",'" + x + "'";
                }
                SqlTransaction tran = cn.BeginTransaction();
                try
                {
                    string Sql = "delete from " + Pre + "news_JSTemplet where SiteID='" + Current.SiteID + "' and JSClassid in (" + ids + ")";
                    DbHelper.ExecuteNonQuery(tran, CommandType.Text, Sql, null);
                    Sql = "delete from " + Pre + "news_JST_Class where SiteID='" + Current.SiteID + "' and ClassID in (" + ids + ")";
                    DbHelper.ExecuteNonQuery(tran, CommandType.Text, Sql, null);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.NewsJSTempletClass GetModel(string classID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ClassID,CName,ParentID,Description,CreatTime,SiteID from " + Pre + "news_JST_Class ");
            strSql.Append(" where ClassID=@ClassID and SiteID='@SiteID'");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.NVarChar,12),
                    new SqlParameter("@SiteID", SqlDbType.VarChar, 12)};
            parameters[0].Value = classID;
            parameters[1].Value = Current.SiteID;

            Foosun.Model.NewsJSTempletClass model = new Foosun.Model.NewsJSTempletClass();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["id"] != null && ds.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Rows[0]["id"].ToString());
                }
                if (ds.Rows[0]["ClassID"] != null && ds.Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = ds.Rows[0]["ClassID"].ToString();
                }
                if (ds.Rows[0]["CName"] != null && ds.Rows[0]["CName"].ToString() != "")
                {
                    model.CName = ds.Rows[0]["CName"].ToString();
                }
                if (ds.Rows[0]["ParentID"] != null && ds.Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = ds.Rows[0]["ParentID"].ToString();
                }
                if (ds.Rows[0]["Description"] != null && ds.Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Rows[0]["Description"].ToString();
                }
                if (ds.Rows[0]["CreatTime"] != null && ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
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

        public Foosun.Model.NewsJSTempletClass GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ClassID,CName,ParentID,Description,CreatTime,SiteID from " + Pre + "news_JST_Class ");
            strSql.Append(" where id=@id and SiteID='@SiteID'");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,12),
                    new SqlParameter("@SiteID", SqlDbType.VarChar, 12)};
            parameters[0].Value = id;
            parameters[1].Value = Current.SiteID;

            Foosun.Model.NewsJSTempletClass model = new Foosun.Model.NewsJSTempletClass();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["id"] != null && ds.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Rows[0]["id"].ToString());
                }
                if (ds.Rows[0]["ClassID"] != null && ds.Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = ds.Rows[0]["ClassID"].ToString();
                }
                if (ds.Rows[0]["CName"] != null && ds.Rows[0]["CName"].ToString() != "")
                {
                    model.CName = ds.Rows[0]["CName"].ToString();
                }
                if (ds.Rows[0]["ParentID"] != null && ds.Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = ds.Rows[0]["ParentID"].ToString();
                }
                if (ds.Rows[0]["Description"] != null && ds.Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Rows[0]["Description"].ToString();
                }
                if (ds.Rows[0]["CreatTime"] != null && ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
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
            string Sql = "select * from " + Pre + "News_JST_Class where SiteID='" + Current.SiteID + "'"+strWhere;
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
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
            strSql.Append(" id,ClassID,CName,ParentID,Description,CreatTime,SiteID ");
            strSql.Append(" FROM " + Pre + "news_JST_Class ");
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
            strSql.Append("select count(1) FROM " + Pre + "news_JST_Class ");
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
                strSql.Append("order by T.ClassID desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "news_JST_Class T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "" + Pre + "news_JST_Class";
            parameters[1].Value = "ClassID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;
using System.Data.OleDb;//Please add references
namespace Foosun.AccessDAL
{
    /// <summary>
    /// 数据访问类:DefineSave
    /// </summary>
    public partial class DefineSave :DbBase, IDefineSave
    {
        public DefineSave()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DsNewsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "define_save");
            strSql.Append(" where DsNewsID=@DsNewsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@DsNewsID", OleDbType.VarWChar,12)			
                                       };
            parameters[0].Value = DsNewsID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.DefineSave model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Pre + "define_save(");
            strSql.Append("DsNewsID,DsEname,DsNewsTable,DsType,DsContent,DsApiID,SiteID)");
            strSql.Append(" values (");
            strSql.Append("@DsNewsID,@DsEname,@DsNewsTable,@DsType,@DsContent,@DsApiID,@SiteID)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@DsNewsID", OleDbType.VarWChar,12),
					new OleDbParameter("@DsEname", OleDbType.VarWChar,50),
					new OleDbParameter("@DsNewsTable", OleDbType.VarWChar,50),
					new OleDbParameter("@DsType", OleDbType.TinyInt,1),
					new OleDbParameter("@DsContent", OleDbType.VarWChar),
					new OleDbParameter("@DsApiID", OleDbType.VarWChar,30),
					new OleDbParameter("@SiteID", OleDbType.VarWChar,12)};
            parameters[0].Value = model.DsNewsID;
            parameters[1].Value = model.DsEname;
            parameters[2].Value = model.DsNewsTable;
            parameters[3].Value = model.DsType;
            parameters[4].Value = model.DsContent;
            parameters[5].Value = model.DsApiID;
            parameters[6].Value = model.SiteID;

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
        public bool Update(Foosun.Model.DefineSave model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "define_save set ");
            strSql.Append("DsNewsID=@DsNewsID,");
            strSql.Append("DsEname=@DsEname,");
            strSql.Append("DsNewsTable=@DsNewsTable,");
            strSql.Append("DsType=@DsType,");
            strSql.Append("DsContent=@DsContent,");
            strSql.Append("DsApiID=@DsApiID,");
            strSql.Append("SiteID=@SiteID");
            strSql.Append(" where DsNewsID=@DsNewsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@DsNewsID", OleDbType.VarWChar,12),
					new OleDbParameter("@DsEname", OleDbType.VarWChar,50),
					new OleDbParameter("@DsNewsTable", OleDbType.VarWChar,50),
					new OleDbParameter("@DsType", OleDbType.TinyInt,1),
					new OleDbParameter("@DsContent", OleDbType.VarWChar),
					new OleDbParameter("@DsApiID", OleDbType.VarWChar,30),
					new OleDbParameter("@SiteID", OleDbType.VarWChar,12),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.DsNewsID;
            parameters[1].Value = model.DsEname;
            parameters[2].Value = model.DsNewsTable;
            parameters[3].Value = model.DsType;
            parameters[4].Value = model.DsContent;
            parameters[5].Value = model.DsApiID;
            parameters[6].Value = model.SiteID;
            parameters[7].Value = model.id;

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
        public bool Delete(string DsNewsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "define_save ");
            strSql.Append(" where DsNewsID=@DsNewsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@DsNewsID", OleDbType.VarWChar,12)			};
            parameters[0].Value = DsNewsID;

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
        public bool DeleteList(string DsNewsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "define_save ");
            strSql.Append(" where DsNewsID in (" + DsNewsIDlist + ")  ");
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
        public Foosun.Model.DefineSave GetModel(string DsNewsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,DsNewsID,DsEname,DsNewsTable,DsType,DsContent,DsApiID,SiteID from " + Pre + "define_save ");
            strSql.Append(" where DsNewsID=@DsNewsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@DsNewsID", OleDbType.VarWChar,12)			};
            parameters[0].Value = DsNewsID;

            Foosun.Model.DefineSave model = new Foosun.Model.DefineSave();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["id"] != null && ds.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Rows[0]["id"].ToString());
                }
                if (ds.Rows[0]["DsNewsID"] != null && ds.Rows[0]["DsNewsID"].ToString() != "")
                {
                    model.DsNewsID = ds.Rows[0]["DsNewsID"].ToString();
                }
                if (ds.Rows[0]["DsEname"] != null && ds.Rows[0]["DsEname"].ToString() != "")
                {
                    model.DsEname = ds.Rows[0]["DsEname"].ToString();
                }
                if (ds.Rows[0]["DsNewsTable"] != null && ds.Rows[0]["DsNewsTable"].ToString() != "")
                {
                    model.DsNewsTable = ds.Rows[0]["DsNewsTable"].ToString();
                }
                if (ds.Rows[0]["DsType"] != null && ds.Rows[0]["DsType"].ToString() != "")
                {
                    model.DsType = int.Parse(ds.Rows[0]["DsType"].ToString());
                }
                if (ds.Rows[0]["DsContent"] != null && ds.Rows[0]["DsContent"].ToString() != "")
                {
                    model.DsContent = ds.Rows[0]["DsContent"].ToString();
                }
                if (ds.Rows[0]["DsApiID"] != null && ds.Rows[0]["DsApiID"].ToString() != "")
                {
                    model.DsApiID = ds.Rows[0]["DsApiID"].ToString();
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
            strSql.Append("select id,DsNewsID,DsEname,DsNewsTable,DsType,DsContent,DsApiID,SiteID ");
            strSql.Append(" FROM " + Pre + "define_save ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString());
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
            strSql.Append(" id,DsNewsID,DsEname,DsNewsTable,DsType,DsContent,DsApiID,SiteID ");
            strSql.Append(" FROM " + Pre + "define_save ");
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
            strSql.Append("select count(1) FROM " + Pre + "define_save ");
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
                strSql.Append("order by T.DsNewsID desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "define_save T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString());
        }

        #endregion  Method
    }
}


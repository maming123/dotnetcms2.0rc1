using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;
using Foosun.Global;
using Foosun.Config;//Please add references
namespace Foosun.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:NewsJSTemplet
    /// </summary>
    public partial class NewsJSTemplet : DbBase, INewsJSTemplet
    {
        public NewsJSTemplet()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string templetID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_JSTemplet");
            strSql.Append(" where TempletID=@TempletID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TempletID", SqlDbType.NVarChar,12)			};
            parameters[0].Value = templetID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.NewsJSTemplet model)
        {
            return Edit(0, model.CName, model.JSClassid, model.JSTType, model.JSTContent);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsJSTemplet model)
        {
           return Edit(model.Id, model.CName, model.JSClassid, -1, model.JSTContent);
        }

        private bool Edit(int id, string CName, string JSClassid, int JSTType, string JSTContent)
        {
            string Sql = "select count(*) from " + Pre + "news_JSTemplet where SiteID='" + Current.SiteID + "' and CName=@CName";
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
                    throw new Exception("JS模型名称不能重复,该JS模型名称已存在!");
                if (id > 0)
                {
                    Sql = "update " + Pre + "news_JSTemplet set CName=@CName,JSClassid=@JSClassid,JSTContent=@JSTContent where SiteID=@SiteID and id=" + id;
                }
                else
                {
                    string JsTID = Common.Rand.Str(12);
                    if (Convert.ToInt32(DbHelper.ExecuteScalar(cn, CommandType.Text, "select count(*) from " + Pre + "news_JSTemplet where TempletID='" + JsTID + "'")) > 0)
                    {
                        JsTID = Common.Rand.Str(12, true);
                    }
                    Sql = "insert into " + Pre + "news_JSTemplet (TempletID,CName,JSClassid,JSTType,JSTContent,CreatTime,SiteID) values ";
                    Sql += "('" + JsTID + "',@CName,@JSClassid," + JSTType + ",@JSTContent,'" + DateTime.Now + "',@SiteID)";
                }
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@CName", SqlDbType.NVarChar, 50);
                param[0].Value = CName;
                param[1] = new SqlParameter("@JSClassid", SqlDbType.NVarChar, 12);
                param[1].Value = JSClassid;
                param[2] = new SqlParameter("@JSTContent", SqlDbType.NText);
                param[2].Value = JSTContent;
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
        public bool Delete(int id)
        {

            string Sql = "delete from " + Pre + "news_JSTemplet where SiteID='" + Current.SiteID + "' and id=" + id;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null) == 1;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string templetIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_JSTemplet ");
            strSql.Append(" where TempletID in (" + templetIDlist + ")  ");
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
        public Foosun.Model.NewsJSTemplet GetModel(string templetID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,TempletID,CName,JSClassid,JSTType,JSTContent,CreatTime,SiteID from " + Pre + "news_JSTemplet ");
            strSql.Append(" where TempletID=@TempletID and SiteID='@SiteID'");
            SqlParameter[] parameters = {
					new SqlParameter("@TempletID", SqlDbType.NVarChar,12),
                    new SqlParameter("@SiteID", SqlDbType.VarChar,12)
                                        };
            parameters[0].Value = templetID;
            parameters[1].Value = Current.SiteID;

            Foosun.Model.NewsJSTemplet model = new Foosun.Model.NewsJSTemplet();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["TempletID"] != null && ds.Rows[0]["TempletID"].ToString() != "")
                {
                    model.TempletID = ds.Rows[0]["TempletID"].ToString();
                }
                if (ds.Rows[0]["CName"] != null && ds.Rows[0]["CName"].ToString() != "")
                {
                    model.CName = ds.Rows[0]["CName"].ToString();
                }
                if (ds.Rows[0]["JSClassid"] != null && ds.Rows[0]["JSClassid"].ToString() != "")
                {
                    model.JSClassid = ds.Rows[0]["JSClassid"].ToString();
                }
                if (ds.Rows[0]["JSTType"] != null && ds.Rows[0]["JSTType"].ToString() != "")
                {
                    model.JSTType = int.Parse(ds.Rows[0]["JSTType"].ToString());
                }
                if (ds.Rows[0]["JSTContent"] != null && ds.Rows[0]["JSTContent"].ToString() != "")
                {
                    model.JSTContent = ds.Rows[0]["JSTContent"].ToString();
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
        /// 根据ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Foosun.Model.NewsJSTemplet GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,TempletID,CName,JSClassid,JSTType,JSTContent,CreatTime,SiteID from " + Pre + "news_JSTemplet ");
            strSql.Append(" where Id=@Id and SiteID='@SiteID'");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,12),
                    new SqlParameter("@SiteID", SqlDbType.VarChar,12)
                                        };
            parameters[0].Value = id;
            parameters[1].Value = Current.SiteID;

            Foosun.Model.NewsJSTemplet model = new Foosun.Model.NewsJSTemplet();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["TempletID"] != null && ds.Rows[0]["TempletID"].ToString() != "")
                {
                    model.TempletID = ds.Rows[0]["TempletID"].ToString();
                }
                if (ds.Rows[0]["CName"] != null && ds.Rows[0]["CName"].ToString() != "")
                {
                    model.CName = ds.Rows[0]["CName"].ToString();
                }
                if (ds.Rows[0]["JSClassid"] != null && ds.Rows[0]["JSClassid"].ToString() != "")
                {
                    model.JSClassid = ds.Rows[0]["JSClassid"].ToString();
                }
                if (ds.Rows[0]["JSTType"] != null && ds.Rows[0]["JSTType"].ToString() != "")
                {
                    model.JSTType = int.Parse(ds.Rows[0]["JSTType"].ToString());
                }
                if (ds.Rows[0]["JSTContent"] != null && ds.Rows[0]["JSTContent"].ToString() != "")
                {
                    model.JSTContent = ds.Rows[0]["JSTContent"].ToString();
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
            string Sql = "select TempletID,CName,JSTType,JSClassid,JSTContent from " + Pre + "news_JSTemplet where SiteID='" + Current.SiteID + "'" + strWhere;
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int top, string strWhere, string filedOrder)
        {
            string Sql = "select top " + top + " TempletID,CName,JSTType from " + Pre + "news_JSTemplet where SiteID='" + Current.SiteID + "' order by " + filedOrder;
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + Pre + "news_JSTemplet ");
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
                strSql.Append("order by T.TempletID desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "news_JSTemplet T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// js模型分页
        /// </summary>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="RecordCount">总条数</param>
        /// <param name="PageCount">总页</param>
        /// <param name="ParentID">父id</param>
        /// <returns></returns>
        public DataTable GetPage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, string ParentID)
        {
            RecordCount = 0;
            PageCount = 0;
            if (ParentID.IndexOf("'") >= 0) ParentID = ParentID.Replace("'", "");
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                string Sql = "select count(*) from " + Pre + "news_JST_Class where SiteID='" + Current.SiteID + "' and ParentID='" + ParentID + "'";
                int m = Convert.ToInt32(DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, null));
                Sql = "select count(*) from " + Pre + "news_JSTemplet where SiteID='" + Current.SiteID + "' and JSClassid='" + ParentID + "'";
                int n = Convert.ToInt32(DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, null));
                RecordCount = m + n;
                if (RecordCount % PageSize == 0)
                    PageCount = RecordCount / PageSize;
                else
                    PageCount = RecordCount / PageSize + 1;
                if (PageIndex > PageCount)
                    PageIndex = PageCount;
                if (PageIndex < 1)
                    PageIndex = 1;
                Sql = "(SELECT a.id, 255 AS JSTType, a.ClassID AS TmpID, a.CName, a.CreatTime, COUNT(b.id) AS NumCLS,(SELECT COUNT(*) FROM " + Pre + "news_JSTemplet WHERE JSClassid = a.ClassID) AS NumTMP FROM " + Pre + "news_JST_Class a LEFT OUTER JOIN " + Pre + "news_JST_Class b ON a.ClassID = b.ParentID where a.ParentID='" + ParentID + "' and a.SiteID='" + Current.SiteID + "' GROUP BY a.id, a.CName, a.CreatTime, a.ClassID) union ";
                Sql += "(select id,JSTType,TempletID as TmpID,CName,CreatTime,NumCLS=0,NumTMP=0 from " + Pre + "news_JSTemplet where JSClassid='" + ParentID + "' and SiteID='" + Current.SiteID + "')";
                SqlDataAdapter ap = new SqlDataAdapter(Sql, cn);
                DataSet st = new DataSet();
                ap.Fill(st, (PageIndex - 1) * PageSize, PageSize, "RESULT");
                return st.Tables[0];
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
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
            parameters[0].Value = "" + Pre + "news_JSTemplet";
            parameters[1].Value = "TempletID";
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


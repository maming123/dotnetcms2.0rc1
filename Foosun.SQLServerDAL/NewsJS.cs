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
    /// 数据访问类:NewsJS
    /// </summary>
    public partial class NewsJS : DbBase, INewsJS
    {
        public NewsJS()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string jsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_JS");
            strSql.Append(" where JsID=@JsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JsID", SqlDbType.NVarChar,12)			};
            parameters[0].Value = jsID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Foosun.Model.NewsJS model)
        {
            return Edit(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Foosun.Model.NewsJS model)
        {
            return Edit(model);
        }

        private string Edit(Foosun.Model.NewsJS info)
        {
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                string RetVal = info.JsID;
                string Sql = "select JSName,jsfilename,jssavepath from " + Pre + "News_JS where SiteID='" + Current.SiteID + "' and (JSName=@JSName or (jsfilename=@jsfilename and jssavepath=@jssavepath))";
                if (info.Id > 0)
                    Sql += " and Id<>" + info.Id;
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@JSName", SqlDbType.NVarChar, 50);
                parm[0].Value = info.JSName;
                parm[1] = new SqlParameter("@jsfilename", SqlDbType.NVarChar, 50);
                parm[1].Value = info.jsfilename;
                parm[2] = new SqlParameter("@jssavepath", SqlDbType.NVarChar, 200);
                parm[2].Value = info.jssavepath;
                IDataReader rd = DbHelper.ExecuteReader(cn, CommandType.Text, Sql, parm);
                if (rd.Read())
                {
                    string nm = rd.GetString(0);
                    rd.Close();
                    if (nm.Equals(info.JSName))
                    {
                        throw new Exception("JS名称不能重复,该名称已经存在!");
                    }
                    else
                    {
                        rd.Close();
                        throw new Exception("已存在相同的路径和文件名的JS!");
                    }
                }
                if (!rd.IsClosed)
                    rd.Close();
                if (info.Id > 0)
                {
                    Sql = "update " + Pre + "News_JS set JSName=@JSName,JsTempletID=@JsTempletID,jsNum=@jsNum,jsLenTitle=@jsLenTitle,jsLenNavi=@jsLenNavi,";
                    Sql += "jsLenContent=@jsLenContent,jsContent=@jsContent,jsColsNum=@jsColsNum,jsfilename=@jsfilename,jssavepath=@jssavepath where SiteID=@SiteID and Id=" + info.Id;
                }
                else
                {
                    string jsid = Common.Rand.Number(12);
                    while (Convert.ToInt32(DbHelper.ExecuteScalar(cn, CommandType.Text, "select count(*) from " + Pre + "News_JS where JsID='" + jsid + "'", null)) > 0)
                    {
                        jsid = Common.Rand.Number(12, true);
                    }
                    RetVal = jsid;
                    Sql = "insert into " + Pre + "News_JS (JsID,jsType,JSName,JsTempletID,jsNum,jsLenTitle,jsLenNavi,jsLenContent,jsContent,SiteID,jsColsNum,CreatTime,jsfilename,jssavepath) ";
                    Sql += "values ('" + jsid + "'," + info.jsType + ",@JSName,@JsTempletID,@jsNum,@jsLenTitle,@jsLenNavi,@jsLenContent,@jsContent,@SiteID,@jsColsNum,'" + DateTime.Now + "',@jsfilename,@jssavepath)";
                }
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@JSName", SqlDbType.NVarChar, 50);
                param[0].Value = info.JSName;
                param[1] = new SqlParameter("@JsTempletID", SqlDbType.NVarChar, 12);
                param[1].Value = info.JsTempletID;
                param[2] = new SqlParameter("@jsNum", SqlDbType.Int);
                param[2].Value = info.jsNum;
                param[3] = new SqlParameter("@jsLenTitle", SqlDbType.Int);
                param[3].Value = info.jsLenTitle < 0 ? DBNull.Value : (object)info.jsLenTitle;
                param[4] = new SqlParameter("@jsLenNavi", SqlDbType.Int);
                param[4].Value = info.jsLenNavi < 0 ? DBNull.Value : (object)info.jsLenNavi;
                param[5] = new SqlParameter("@jsLenContent", SqlDbType.Int);
                param[5].Value = info.jsLenContent < 0 ? DBNull.Value : (object)info.jsLenContent;
                param[6] = new SqlParameter("@jsContent", SqlDbType.NText);
                param[6].Value = info.jsContent.Equals("") ? DBNull.Value : (object)info.jsContent;
                param[7] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
                param[7].Value = Current.SiteID;
                param[8] = new SqlParameter("@jsColsNum", SqlDbType.Int);
                param[8].Value = info.jsColsNum < 0 ? DBNull.Value : (object)info.jsColsNum;
                param[9] = new SqlParameter("@jsfilename", SqlDbType.NVarChar, 50);
                param[9].Value = info.jsfilename;
                param[10] = new SqlParameter("@jssavepath", SqlDbType.NVarChar, 200);
                param[10].Value = info.jssavepath;
                DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, param);
                if (info.Id < 1)
                {
                    Sql = "select Id from " + Pre + "news_JS where JsID='" + RetVal + "'";
                    RetVal = DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, null).ToString();
                }
                return RetVal;
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
            if (id.IndexOf("'") >= 0)
                throw new Exception("编号中有非法字符'");
            string Sql = "delete from " + Pre + "news_JS where SiteID='" + Current.SiteID + "' and id in (" + id + ")";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string jsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_JS ");
            strSql.Append(" where JsID in (" + jsIDlist + ")  ");
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
        public Foosun.Model.NewsJS GetModel(string jsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,JsID,jsType,JSName,JsTempletID,jsNum,jsLenTitle,jsLenNavi,jsLenContent,jsContent,SiteID,jsColsNum,CreatTime,jsfilename,jssavepath from " + Pre + "news_JS ");
            strSql.Append(" where JsID=@JsID and SiteID='@SiteID'");
            SqlParameter[] parameters = {
					new SqlParameter("@JsID", SqlDbType.NVarChar,12),
                    new SqlParameter("@SiteID", SqlDbType.VarChar, 12)};
            parameters[0].Value = jsID;
            parameters[1].Value = Current.SiteID;

            Foosun.Model.NewsJS model = new Foosun.Model.NewsJS();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["JsID"] != null && ds.Rows[0]["JsID"].ToString() != "")
                {
                    model.JsID = ds.Rows[0]["JsID"].ToString();
                }
                if (ds.Rows[0]["jsType"] != null && ds.Rows[0]["jsType"].ToString() != "")
                {
                    model.jsType = int.Parse(ds.Rows[0]["jsType"].ToString());
                }
                if (ds.Rows[0]["JSName"] != null && ds.Rows[0]["JSName"].ToString() != "")
                {
                    model.JSName = ds.Rows[0]["JSName"].ToString();
                }
                if (ds.Rows[0]["JsTempletID"] != null && ds.Rows[0]["JsTempletID"].ToString() != "")
                {
                    model.JsTempletID = ds.Rows[0]["JsTempletID"].ToString();
                }
                if (ds.Rows[0]["jsNum"] != null && ds.Rows[0]["jsNum"].ToString() != "")
                {
                    model.jsNum = int.Parse(ds.Rows[0]["jsNum"].ToString());
                }
                if (ds.Rows[0]["jsLenTitle"] != null && ds.Rows[0]["jsLenTitle"].ToString() != "")
                {
                    model.jsLenTitle = int.Parse(ds.Rows[0]["jsLenTitle"].ToString());
                }
                if (ds.Rows[0]["jsLenNavi"] != null && ds.Rows[0]["jsLenNavi"].ToString() != "")
                {
                    model.jsLenNavi = int.Parse(ds.Rows[0]["jsLenNavi"].ToString());
                }
                if (ds.Rows[0]["jsLenContent"] != null && ds.Rows[0]["jsLenContent"].ToString() != "")
                {
                    model.jsLenContent = int.Parse(ds.Rows[0]["jsLenContent"].ToString());
                }
                if (ds.Rows[0]["jsContent"] != null && ds.Rows[0]["jsContent"].ToString() != "")
                {
                    model.jsContent = ds.Rows[0]["jsContent"].ToString();
                }
                if (ds.Rows[0]["SiteID"] != null && ds.Rows[0]["SiteID"].ToString() != "")
                {
                    model.SiteID = ds.Rows[0]["SiteID"].ToString();
                }
                if (ds.Rows[0]["jsColsNum"] != null && ds.Rows[0]["jsColsNum"].ToString() != "")
                {
                    model.jsColsNum = int.Parse(ds.Rows[0]["jsColsNum"].ToString());
                }
                if (ds.Rows[0]["CreatTime"] != null && ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
                }
                if (ds.Rows[0]["jsfilename"] != null && ds.Rows[0]["jsfilename"].ToString() != "")
                {
                    model.jsfilename = ds.Rows[0]["jsfilename"].ToString();
                }
                if (ds.Rows[0]["jssavepath"] != null && ds.Rows[0]["jssavepath"].ToString() != "")
                {
                    model.jssavepath = ds.Rows[0]["jssavepath"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public Foosun.Model.NewsJS GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,JsID,jsType,JSName,JsTempletID,jsNum,jsLenTitle,jsLenNavi,jsLenContent,jsContent,SiteID,jsColsNum,CreatTime,jsfilename,jssavepath from " + Pre + "news_JS ");
            strSql.Append(" where Id=@Id and SiteID=@SiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,12),
                    new SqlParameter("@SiteID", SqlDbType.VarChar, 12)};
            parameters[0].Value = id;
            parameters[1].Value = Current.SiteID;

            Foosun.Model.NewsJS model = new Foosun.Model.NewsJS();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["JsID"] != null && ds.Rows[0]["JsID"].ToString() != "")
                {
                    model.JsID = ds.Rows[0]["JsID"].ToString();
                }
                if (ds.Rows[0]["jsType"] != null && ds.Rows[0]["jsType"].ToString() != "")
                {
                    model.jsType = int.Parse(ds.Rows[0]["jsType"].ToString());
                }
                if (ds.Rows[0]["JSName"] != null && ds.Rows[0]["JSName"].ToString() != "")
                {
                    model.JSName = ds.Rows[0]["JSName"].ToString();
                }
                if (ds.Rows[0]["JsTempletID"] != null && ds.Rows[0]["JsTempletID"].ToString() != "")
                {
                    model.JsTempletID = ds.Rows[0]["JsTempletID"].ToString();
                }
                if (ds.Rows[0]["jsNum"] != null && ds.Rows[0]["jsNum"].ToString() != "")
                {
                    model.jsNum = int.Parse(ds.Rows[0]["jsNum"].ToString());
                }
                if (ds.Rows[0]["jsLenTitle"] != null && ds.Rows[0]["jsLenTitle"].ToString() != "")
                {
                    model.jsLenTitle = int.Parse(ds.Rows[0]["jsLenTitle"].ToString());
                }
                if (ds.Rows[0]["jsLenNavi"] != null && ds.Rows[0]["jsLenNavi"].ToString() != "")
                {
                    model.jsLenNavi = int.Parse(ds.Rows[0]["jsLenNavi"].ToString());
                }
                if (ds.Rows[0]["jsLenContent"] != null && ds.Rows[0]["jsLenContent"].ToString() != "")
                {
                    model.jsLenContent = int.Parse(ds.Rows[0]["jsLenContent"].ToString());
                }
                if (ds.Rows[0]["jsContent"] != null && ds.Rows[0]["jsContent"].ToString() != "")
                {
                    model.jsContent = ds.Rows[0]["jsContent"].ToString();
                }
                if (ds.Rows[0]["SiteID"] != null && ds.Rows[0]["SiteID"].ToString() != "")
                {
                    model.SiteID = ds.Rows[0]["SiteID"].ToString();
                }
                if (ds.Rows[0]["jsColsNum"] != null && ds.Rows[0]["jsColsNum"].ToString() != "")
                {
                    model.jsColsNum = int.Parse(ds.Rows[0]["jsColsNum"].ToString());
                }
                if (ds.Rows[0]["CreatTime"] != null && ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
                }
                if (ds.Rows[0]["jsfilename"] != null && ds.Rows[0]["jsfilename"].ToString() != "")
                {
                    model.jsfilename = ds.Rows[0]["jsfilename"].ToString();
                }
                if (ds.Rows[0]["jssavepath"] != null && ds.Rows[0]["jssavepath"].ToString() != "")
                {
                    model.jssavepath = ds.Rows[0]["jssavepath"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取模版内容
        /// </summary>
        /// <param name="jsTmpid"></param>
        /// <returns></returns>
        public string GetJsTmpContent(string jsTmpid)
        {
            string Sql = "select JSTContent from " + Pre + "news_JSTemplet where TempletID=@TempletID";
            SqlParameter param = new SqlParameter("@TempletID", jsTmpid);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, param));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,JsID,jsType,JSName,JsTempletID,jsNum,jsLenTitle,jsLenNavi,jsLenContent,jsContent,SiteID,jsColsNum,CreatTime,jsfilename,jssavepath ");
            strSql.Append(" FROM " + Pre + "news_JS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
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
            strSql.Append(" Id,JsID,jsType,JSName,JsTempletID,jsNum,jsLenTitle,jsLenNavi,jsLenContent,jsContent,SiteID,jsColsNum,CreatTime,jsfilename,jssavepath ");
            strSql.Append(" FROM " + Pre + "news_JS ");
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
            strSql.Append("select count(1) FROM " + Pre + "news_JS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), null);
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
                strSql.Append("order by T.JsID desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "news_JS T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 新闻JS管理分页
        /// </summary>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="RecordCount">总条数</param>
        /// <param name="PageCount">总页数</param>
        /// <param name="JsType"></param>
        /// <returns></returns>
        public DataTable GetPage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, int JsType)
        {
            string SqlWhere = Pre + "news_JS where SiteID='" + Current.SiteID + "'";
            if (JsType >= 0)
                SqlWhere += " and jsType=" + JsType;
            return DbHelper.ExecutePage("id,JSid,JSName,jsType,CreatTime,jsNum", SqlWhere, "id", "order by id desc", PageIndex, PageSize, out RecordCount, out PageCount, null);
        }

        public DataTable GetJSFiles(string jsid)
        {
            string Sql = "select NewsId from " + Pre + "news_JSFile where JsID=@JsID";
            SqlParameter param = new SqlParameter("@JsID", jsid);
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }

        public DataTable GetJSNum(string jsid)
        {
            string Sql = "select jsnum from " + Pre + "news_JS where JsID=@JsID";
            SqlParameter param = new SqlParameter("@JsID", jsid);
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }
        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
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
            parameters[0].Value = "" + Pre + "news_JS";
            parameters[1].Value = "JsID";
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


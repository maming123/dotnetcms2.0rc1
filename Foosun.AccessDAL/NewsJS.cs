using System;
using System.Data;
using System.Text;
using Foosun.IDAL;
using Foosun.DALProfile;
using Foosun.Global;
using Foosun.Config;
using System.Data.OleDb;//Please add references
namespace Foosun.AccessDAL
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@JsID", OleDbType.VarChar,12)			};
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
            OleDbConnection cn = new OleDbConnection(Database.FoosunConnectionString);
            try
            {
                string RetVal = info.JsID;
                string Sql = "select JSName,jsfilename,jssavepath from " + Pre + "News_JS where SiteID='" + Current.SiteID + "' and (JSName=@JSName or (jsfilename=@jsfilename and jssavepath=@jssavepath))";
                if (info.Id > 0)
                    Sql += " and Id<>" + info.Id;
                OleDbParameter[] parm = new OleDbParameter[3];
                parm[0] = new OleDbParameter("@JSName", OleDbType.VarWChar, 50);
                parm[0].Value = info.JSName;
                parm[1] = new OleDbParameter("@jsfilename", OleDbType.VarWChar, 50);
                parm[1].Value = info.jsfilename;
                parm[2] = new OleDbParameter("@jssavepath", OleDbType.VarWChar, 200);
                parm[2].Value = info.jssavepath;
                IDataReader rd = DbHelper.ExecuteReader(cn, CommandType.Text, Sql, Database.getNewParam(parm, "JSName,jsfilename,jssavepath"));
                if (rd.Read() && info.Id <= 0)
                {
                    string nm = rd.GetString(0);
                    rd.Close();
                    if (nm.Equals(info.JSName))
                    {
                        rd.Close();
                        return "JS名称不能重复,该名称已经存在!";
                    }
                    else
                    {
                        rd.Close();
                        return "已存在相同的路径和文件名的JS!";
                    }
                }
                if (!rd.IsClosed)
                    rd.Close();

                OleDbParameter[] param = new OleDbParameter[11];
                param[0] = new OleDbParameter("@JSName", OleDbType.VarWChar, 50);
                param[0].Value = info.JSName;
                param[1] = new OleDbParameter("@JsTempletID", OleDbType.VarWChar, 12);
                param[1].Value = info.JsTempletID;
                param[2] = new OleDbParameter("@jsNum", OleDbType.Integer);
                param[2].Value = info.jsNum;
                param[3] = new OleDbParameter("@jsLenTitle", OleDbType.Integer);
                param[3].Value = info.jsLenTitle < 0 ? DBNull.Value : (object)info.jsLenTitle;
                param[4] = new OleDbParameter("@jsLenNavi", OleDbType.Integer);
                param[4].Value = info.jsLenNavi < 0 ? DBNull.Value : (object)info.jsLenNavi;
                param[5] = new OleDbParameter("@jsLenContent", OleDbType.Integer);
                param[5].Value = info.jsLenContent < 0 ? DBNull.Value : (object)info.jsLenContent;
                param[6] = new OleDbParameter("@jsContent", OleDbType.VarWChar);
                param[6].Value = info.jsContent.Equals("") ? DBNull.Value : (object)info.jsContent;
                param[7] = new OleDbParameter("@SiteID", OleDbType.VarWChar, 12);
                param[7].Value = Current.SiteID;
                param[8] = new OleDbParameter("@jsColsNum", OleDbType.Integer);
                param[8].Value = info.jsColsNum < 0 ? DBNull.Value : (object)info.jsColsNum;
                param[9] = new OleDbParameter("@jsfilename", OleDbType.VarWChar, 50);
                param[9].Value = info.jsfilename;
                param[10] = new OleDbParameter("@jssavepath", OleDbType.VarWChar, 200);
                param[10].Value = info.jssavepath;

                if (info.Id > 0)
                {
                    Sql = "update " + Pre + "News_JS set " + Database.GetModifyParam(param) + " where Id=" + info.Id;
                }
                else
                {
                    string jsid = Common.Rand.Number(12);
                    while (Convert.ToInt32(DbHelper.ExecuteScalar(cn, CommandType.Text, "select count(*) from " + Pre + "News_JS where JsID='" + jsid + "'", null)) > 0)
                    {
                        jsid = Common.Rand.Number(12, true);
                    }
                    RetVal = jsid;
                    Sql = "insert into " + Pre + "News_JS (JsID,jsType," + Database.GetParam(param) + ",CreatTime) ";
                    Sql += "values ('" + jsid + "'," + info.jsType + "," + Database.GetAParam(param) + ",#" + DateTime.Now + "#)";
                }
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@JsID", OleDbType.VarChar,12),
                    new OleDbParameter("@SiteID", OleDbType.VarChar, 12)};
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.VarChar,12),
                    new OleDbParameter("@SiteID", OleDbType.VarChar, 12)};
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
            OleDbParameter param = new OleDbParameter("@TempletID", jsTmpid);
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
            return DbHelper.ExecutePage("id,JSid,JSName,jsType,CreatTime,jsNum", SqlWhere, "id", "order by id desc", PageIndex, PageSize, out RecordCount, out PageCount,null);
        }

        public DataTable GetJSFiles(string jsid)
        {
            string Sql = "select NewsId from " + Pre + "news_JSFile where JsID=@JsID";
            OleDbParameter param = new OleDbParameter("@JsID", jsid);
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }

        public DataTable GetJSNum(string jsid)
        {
            string Sql = "select jsnum from " + Pre + "news_JS where JsID=@JsID";
            OleDbParameter param = new OleDbParameter("@JsID", jsid);
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }

        #endregion  Method
    }
}


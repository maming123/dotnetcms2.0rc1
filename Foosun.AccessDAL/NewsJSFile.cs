using System;
using System.Data;
using System.Text;
using Foosun.IDAL;
using Foosun.DALProfile;
using Foosun.Global;
using System.Data.OleDb;
namespace Foosun.AccessDAL
{
    /// <summary>
    /// 数据访问类:NewsJSFile
    /// </summary>
    public partial class NewsJSFile :DbBase, INewsJSFile
    {
        public NewsJSFile()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string jsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_JSFile");
            strSql.Append(" where JsID=@JsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@JsID", OleDbType.VarChar,12)			};
            parameters[0].Value = jsID;

            return DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.NewsJSFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Pre + "news_JSFile(");
            strSql.Append("JsID,Njf_title,NewsId,NewsTable,PicPath,ClassId,SiteID,CreatTime,TojsTime,ReclyeTF)");
            strSql.Append(" values (");
            strSql.Append("@JsID,@Njf_title,@NewsId,@NewsTable,@PicPath,@ClassId,@SiteID,@CreatTime,@TojsTime,@ReclyeTF)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@JsID", OleDbType.VarChar,12),
					new OleDbParameter("@Njf_title", OleDbType.VarChar,100),
					new OleDbParameter("@NewsId", OleDbType.VarChar,12),
					new OleDbParameter("@NewsTable", OleDbType.VarChar,20),
					new OleDbParameter("@PicPath", OleDbType.VarChar,200),
					new OleDbParameter("@ClassId", OleDbType.VarChar,12),
					new OleDbParameter("@SiteID", OleDbType.VarChar,12),
					new OleDbParameter("@CreatTime", OleDbType.Date),
					new OleDbParameter("@TojsTime", OleDbType.Date),
					new OleDbParameter("@ReclyeTF", OleDbType.TinyInt,1)};
            parameters[0].Value = model.JsID;
            parameters[1].Value = model.Njf_title;
            parameters[2].Value = model.NewsId;
            parameters[3].Value = Pre+"News";
            parameters[4].Value = model.PicPath;
            parameters[5].Value = model.ClassId;
            parameters[6].Value = model.SiteID;
            parameters[7].Value = model.CreatTime;
            parameters[8].Value = model.TojsTime;
            parameters[9].Value = model.ReclyeTF;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
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
        public bool Update(Foosun.Model.NewsJSFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "news_JSFile set ");
            strSql.Append("JsID=@JsID,");
            strSql.Append("Njf_title=@Njf_title,");
            strSql.Append("NewsId=@NewsId,");
            strSql.Append("NewsTable=@NewsTable,");
            strSql.Append("PicPath=@PicPath,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("SiteID=@SiteID,");
            strSql.Append("CreatTime=@CreatTime,");
            strSql.Append("TojsTime=@TojsTime,");
            strSql.Append("ReclyeTF=@ReclyeTF");
            strSql.Append(" where JsID=@JsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@JsID", OleDbType.VarChar,12),
					new OleDbParameter("@Njf_title", OleDbType.VarChar,100),
					new OleDbParameter("@NewsId", OleDbType.VarChar,12),
					new OleDbParameter("@NewsTable", OleDbType.VarChar,20),
					new OleDbParameter("@PicPath", OleDbType.VarChar,200),
					new OleDbParameter("@ClassId", OleDbType.VarChar,12),
					new OleDbParameter("@SiteID", OleDbType.VarChar,12),
					new OleDbParameter("@CreatTime", OleDbType.Date),
					new OleDbParameter("@TojsTime", OleDbType.Date),
					new OleDbParameter("@ReclyeTF", OleDbType.TinyInt,1),
					new OleDbParameter("@Id", OleDbType.Integer,4)};
            parameters[0].Value = model.JsID;
            parameters[1].Value = model.Njf_title;
            parameters[2].Value = model.NewsId;
            parameters[3].Value = model.NewsTable;
            parameters[4].Value = model.PicPath;
            parameters[5].Value = model.ClassId;
            parameters[6].Value = model.SiteID;
            parameters[7].Value = model.CreatTime;
            parameters[8].Value = model.TojsTime;
            parameters[9].Value = model.ReclyeTF;
            parameters[10].Value = model.Id;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
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

            string Sql = "delete from " + Pre + "News_JSFile where SiteID='" + Current.SiteID + "' and ID=" + id;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null) == 1;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string jsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_JSFile ");
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
        public Foosun.Model.NewsJSFile GetModel(string jsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,JsID,Njf_title,NewsId,NewsTable,PicPath,ClassId,SiteID,CreatTime,TojsTime,ReclyeTF from " + Pre + "news_JSFile ");
            strSql.Append(" where JsID=@JsID and SiteID='@SiteID'");
            OleDbParameter[] parameters = {
					new OleDbParameter("@JsID", OleDbType.VarChar,12),
                    new OleDbParameter("@SiteID", OleDbType.VarChar, 12)};
            parameters[0].Value = jsID;
            parameters[1].Value = Current.SiteID;

            Foosun.Model.NewsJSFile model = new Foosun.Model.NewsJSFile();
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
                if (ds.Rows[0]["Njf_title"] != null && ds.Rows[0]["Njf_title"].ToString() != "")
                {
                    model.Njf_title = ds.Rows[0]["Njf_title"].ToString();
                }
                if (ds.Rows[0]["NewsId"] != null && ds.Rows[0]["NewsId"].ToString() != "")
                {
                    model.NewsId = ds.Rows[0]["NewsId"].ToString();
                }
                if (ds.Rows[0]["NewsTable"] != null && ds.Rows[0]["NewsTable"].ToString() != "")
                {
                    model.NewsTable = ds.Rows[0]["NewsTable"].ToString();
                }
                if (ds.Rows[0]["PicPath"] != null && ds.Rows[0]["PicPath"].ToString() != "")
                {
                    model.PicPath = ds.Rows[0]["PicPath"].ToString();
                }
                if (ds.Rows[0]["ClassId"] != null && ds.Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = ds.Rows[0]["ClassId"].ToString();
                }
                if (ds.Rows[0]["SiteID"] != null && ds.Rows[0]["SiteID"].ToString() != "")
                {
                    model.SiteID = ds.Rows[0]["SiteID"].ToString();
                }
                if (ds.Rows[0]["CreatTime"] != null && ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
                }
                if (ds.Rows[0]["TojsTime"] != null && ds.Rows[0]["TojsTime"].ToString() != "")
                {
                    model.TojsTime = DateTime.Parse(ds.Rows[0]["TojsTime"].ToString());
                }
                if (ds.Rows[0]["ReclyeTF"] != null && ds.Rows[0]["ReclyeTF"].ToString() != "")
                {
                    model.ReclyeTF = int.Parse(ds.Rows[0]["ReclyeTF"].ToString());
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
            strSql.Append("select Id,JsID,Njf_title,NewsId,NewsTable,PicPath,ClassId,SiteID,CreatTime,TojsTime,ReclyeTF ");
            strSql.Append(" FROM " + Pre + "news_JSFile ");
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
            strSql.Append(" Id,JsID,Njf_title,NewsId,NewsTable,PicPath,ClassId,SiteID,CreatTime,TojsTime,ReclyeTF ");
            strSql.Append(" FROM " + Pre + "news_JSFile ");
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
            strSql.Append("select count(1) FROM " + Pre + "news_JSFile ");
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
                strSql.Append("order by T.JsID desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "news_JSFile T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// JS新闻列表分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetJSFilePage(int PageIndex, int PageSize, out int RecordCount, out int PageCount, int id)
        {
            return DbHelper.ExecutePage("a.ID,a.Njf_title", Pre + "News_JSFile a inner join " + Pre + "News_JS b on a.JsID=b.JsID where a.SiteID='" + Current.SiteID + "' and b.id=" + id, "a.id", "order by a.id", PageIndex, PageSize, out RecordCount, out PageCount, null);
        }

        #endregion  Method
    }
}


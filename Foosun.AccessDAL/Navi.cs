using System;
using System.Data;
using System.Text;
using Foosun.IDAL;
using Foosun.DALProfile;
using System.Data.OleDb;
namespace Foosun.AccessDAL
{
    /// <summary>
    /// 数据访问类:Navi
    /// </summary>
    public partial class Navi : DbBase, INavi
    {
        public Navi()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string am_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "api_Navi");
            strSql.Append(" where am_ClassID=@am_ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@am_ID", OleDbType.VarChar,20)			};
            parameters[0].Value = am_ID;

            return DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Foosun.Model.Navi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Pre + "api_Navi(");
            strSql.Append("am_ID,am_ClassID,am_Name,am_FilePath,am_ChildrenID,am_creatTime,am_orderID,isSys,siteID,userNum,popCode,imgPath,imgwidth,imgheight)");
            strSql.Append(" values (");
            strSql.Append("@am_ID,@am_ClassID,@am_Name,@am_FilePath,@am_ChildrenID,@am_creatTime,@am_orderID,@isSys,@siteID,@userNum,@popCode,@imgPath,@imgwidth,@imgheight)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@am_ID", OleDbType.Integer,4),
					new OleDbParameter("@am_ClassID", OleDbType.VarWChar,12),
					new OleDbParameter("@am_Name", OleDbType.VarWChar,20),
					new OleDbParameter("@am_FilePath", OleDbType.VarWChar,200),
					new OleDbParameter("@am_ChildrenID", OleDbType.VarWChar),
					new OleDbParameter("@am_creatTime", OleDbType.Date),
					new OleDbParameter("@am_orderID", OleDbType.Integer,4),
					new OleDbParameter("@isSys", OleDbType.TinyInt,1),
					new OleDbParameter("@siteID", OleDbType.VarWChar,12),
					new OleDbParameter("@userNum", OleDbType.VarWChar,15),
					new OleDbParameter("@popCode", OleDbType.VarWChar,50),
					new OleDbParameter("@imgPath", OleDbType.VarWChar,200),
					new OleDbParameter("@imgwidth", OleDbType.VarWChar,10),
					new OleDbParameter("@imgheight", OleDbType.VarWChar,10)};
            parameters[0].Value = model.am_ID;
            parameters[1].Value = model.am_ClassID;
            parameters[2].Value = model.am_Name;
            parameters[3].Value = model.am_FilePath;
            parameters[4].Value = model.am_ChildrenID;
            parameters[5].Value = model.am_creatTime;
            parameters[6].Value = model.am_orderID;
            parameters[7].Value = model.isSys;
            parameters[8].Value = model.siteID;
            parameters[9].Value = model.userNum;
            parameters[10].Value = model.popCode;
            parameters[11].Value = model.imgPath;
            parameters[12].Value = model.imgwidth;
            parameters[13].Value = model.imgheight;

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
        public int Update(string am_ChildrenID,string am_ClassID)
        {
            string sql = "update " + Pre + "api_Navi set am_ChildrenID='" + am_ChildrenID + "' where am_ClassID='" + am_ClassID + "'";
            return DbHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.Navi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "api_Navi set ");
            strSql.Append("am_ClassID=@am_ClassID,");
            strSql.Append("am_Name=@am_Name,");
            strSql.Append("am_FilePath=@am_FilePath,");
            strSql.Append("am_ChildrenID=@am_ChildrenID,");
            strSql.Append("am_creatTime=@am_creatTime,");
            strSql.Append("am_orderID=@am_orderID,");
            strSql.Append("isSys=@isSys,");
            strSql.Append("siteID=@siteID,");
            strSql.Append("userNum=@userNum,");
            strSql.Append("popCode=@popCode,");
            strSql.Append("imgPath=@imgPath,");
            strSql.Append("imgwidth=@imgwidth,");
            strSql.Append("imgheight=@imgheight");
            strSql.Append(" where am_ID=@am_ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@am_ClassID", OleDbType.VarWChar,12),
					new OleDbParameter("@am_Name", OleDbType.VarWChar,20),
					new OleDbParameter("@am_FilePath", OleDbType.VarWChar,200),
					new OleDbParameter("@am_ChildrenID", OleDbType.VarWChar),
					new OleDbParameter("@am_creatTime", OleDbType.Date),
					new OleDbParameter("@am_orderID", OleDbType.Integer,4),
					new OleDbParameter("@isSys", OleDbType.TinyInt,1),
					new OleDbParameter("@siteID", OleDbType.VarWChar,12),
					new OleDbParameter("@userNum", OleDbType.VarWChar,15),
					new OleDbParameter("@popCode", OleDbType.VarWChar,50),
					new OleDbParameter("@imgPath", OleDbType.VarWChar,200),
					new OleDbParameter("@imgwidth", OleDbType.VarWChar,10),
					new OleDbParameter("@imgheight", OleDbType.VarWChar,10),
					new OleDbParameter("@am_ID", OleDbType.Integer,4)};
            parameters[0].Value = model.am_ClassID;
            parameters[1].Value = model.am_Name;
            parameters[2].Value = model.am_FilePath;
            parameters[3].Value = model.am_ChildrenID;
            parameters[4].Value = model.am_creatTime;
            parameters[5].Value = model.am_orderID;
            parameters[6].Value = model.isSys;
            parameters[7].Value = model.siteID;
            parameters[8].Value = model.userNum;
            parameters[9].Value = model.popCode;
            parameters[10].Value = model.imgPath;
            parameters[11].Value = model.imgwidth;
            parameters[12].Value = model.imgheight;
            parameters[13].Value = model.am_ID;

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
        public bool Delete(string am_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "api_Navi ");
            strSql.Append(" where am_ClassId=@am_ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@am_ID", OleDbType.VarChar, 20)			};
            parameters[0].Value = am_ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string am_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "api_Navi ");
            strSql.Append(" where am_ID in (" + am_IDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString());
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
        public Foosun.Model.Navi GetModel(string am_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 am_ID,am_ClassID,am_Name,am_FilePath,am_ChildrenID,am_creatTime,am_orderID,isSys,siteID,userNum,popCode,imgPath,imgwidth,imgheight from " + Pre + "api_Navi ");
            strSql.Append(" where am_ClassId=@am_ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@am_ID", OleDbType.Integer,4)			};
            parameters[0].Value = am_ID;

            Foosun.Model.Navi model = new Foosun.Model.Navi();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["am_ID"] != null && ds.Rows[0]["am_ID"].ToString() != "")
                {
                    model.am_ID = int.Parse(ds.Rows[0]["am_ID"].ToString());
                }
                if (ds.Rows[0]["am_ClassID"] != null && ds.Rows[0]["am_ClassID"].ToString() != "")
                {
                    model.am_ClassID = ds.Rows[0]["am_ClassID"].ToString();
                }
                if (ds.Rows[0]["am_Name"] != null && ds.Rows[0]["am_Name"].ToString() != "")
                {
                    model.am_Name = ds.Rows[0]["am_Name"].ToString();
                }
                if (ds.Rows[0]["am_FilePath"] != null && ds.Rows[0]["am_FilePath"].ToString() != "")
                {
                    model.am_FilePath = ds.Rows[0]["am_FilePath"].ToString();
                }
                if (ds.Rows[0]["am_ChildrenID"] != null && ds.Rows[0]["am_ChildrenID"].ToString() != "")
                {
                    model.am_ChildrenID = ds.Rows[0]["am_ChildrenID"].ToString();
                }
                if (ds.Rows[0]["am_creatTime"] != null && ds.Rows[0]["am_creatTime"].ToString() != "")
                {
                    model.am_creatTime = DateTime.Parse(ds.Rows[0]["am_creatTime"].ToString());
                }
                if (ds.Rows[0]["am_orderID"] != null && ds.Rows[0]["am_orderID"].ToString() != "")
                {
                    model.am_orderID = int.Parse(ds.Rows[0]["am_orderID"].ToString());
                }
                if (ds.Rows[0]["isSys"] != null && ds.Rows[0]["isSys"].ToString() != "")
                {
                    model.isSys = int.Parse(ds.Rows[0]["isSys"].ToString());
                }
                if (ds.Rows[0]["siteID"] != null && ds.Rows[0]["siteID"].ToString() != "")
                {
                    model.siteID = ds.Rows[0]["siteID"].ToString();
                }
                if (ds.Rows[0]["userNum"] != null && ds.Rows[0]["userNum"].ToString() != "")
                {
                    model.userNum = ds.Rows[0]["userNum"].ToString();
                }
                if (ds.Rows[0]["popCode"] != null && ds.Rows[0]["popCode"].ToString() != "")
                {
                    model.popCode = ds.Rows[0]["popCode"].ToString();
                }
                if (ds.Rows[0]["imgPath"] != null && ds.Rows[0]["imgPath"].ToString() != "")
                {
                    model.imgPath = ds.Rows[0]["imgPath"].ToString();
                }
                if (ds.Rows[0]["imgwidth"] != null && ds.Rows[0]["imgwidth"].ToString() != "")
                {
                    model.imgwidth = ds.Rows[0]["imgwidth"].ToString();
                }
                if (ds.Rows[0]["imgheight"] != null && ds.Rows[0]["imgheight"].ToString() != "")
                {
                    model.imgheight = ds.Rows[0]["imgheight"].ToString();
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
            strSql.Append("select am_ID,am_ClassID,am_Name,am_FilePath,am_ChildrenID,am_creatTime,am_orderID,isSys,siteID,userNum,popCode,imgPath,imgwidth,imgheight ");
            strSql.Append(" FROM " + Pre + "api_Navi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteTable(CommandType.Text,strSql.ToString());
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
            strSql.Append(" am_ID,am_ClassID,am_Name,am_FilePath,am_ChildrenID,am_creatTime,am_orderID,isSys,siteID,userNum,popCode,imgPath,imgwidth,imgheight ");
            strSql.Append(" FROM " + Pre + "api_Navi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteTable(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + Pre + "api_Navi ");
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
                strSql.Append("order by T.am_ID desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "api_Navi T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        public IDataReader GetNavilist()
        {
            string getS = "";
            string SQLTF = "select am_ID from " + Pre + "api_Navi where am_position='99999' and siteID='" + Foosun.Global.Current.SiteID + "' ";
            object obj = DbHelper.ExecuteScalar(CommandType.Text, SQLTF, null);
            if (obj != null)
            {
                getS = " and SiteID='" + Foosun.Global.Current.SiteID + "'";
            }
            else
            {
                getS = " and SiteID='0'";
            }
            string Sql = "select am_ID,am_ClassID,Am_position,am_Name,am_FilePath,am_target,am_type,siteID,userNum,isSys,mainURL From " + Pre + "api_Navi where Am_position='00000' " + getS + " order by am_orderID asc,am_ID desc";
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }

        #endregion  Method
    }
}


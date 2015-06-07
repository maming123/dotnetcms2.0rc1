using System;
using System.Data;
using System.Text;
using Foosun.IDAL;
using Foosun.DALProfile;
using System.Collections.Generic;
using System.Data.OleDb;
namespace Foosun.AccessDAL
{
    /// <summary>
    /// 数据访问类:NewsSpecial
    /// </summary>
    public partial class NewsSpecial : DbBase, INewsSpecial
    {
        public NewsSpecial()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SpecialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_special");
            strSql.Append(" where SpecialID=@SpecialID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@SpecialID", OleDbType.VarChar,12)			};
            parameters[0].Value = SpecialID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Foosun.Model.NewsSpecial model)
        {
            int result = 0;
            string SpecialID = "";
            string checkSql = "";
            int recordCount = 0;
            SpecialID = Common.Rand.Number(12);
            while (true)
            {
                checkSql = "select count(*) from " + Pre + "news_special where SpecialID='" + SpecialID + "'";
                recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, checkSql, null);
                if (recordCount < 1)
                    break;
                else
                    SpecialID = Common.Rand.Number(12, true);
            }
            checkSql = "select count(*) from " + Pre + "news_special where specialEName='" + model.specialEName + "'";
            recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, checkSql, null);
            if (recordCount > 0)
            {
                return "专题英文名称重复,请重新添加!";
            }
            OleDbParameter[] param = GetSpecialParameters(model);
            string str_Sql = "Insert Into " + Pre + "news_special(" + Database.GetParam(param) + ") Values(" + Database.GetAParam(param) + ")";

            result = Convert.ToInt32(DbHelper.ExecuteNonQuery(CommandType.Text, str_Sql, param));
            return result + "|" + SpecialID;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsSpecial sci)
        {
            string Sql = "Update " + Pre + "news_special Set SpecialCName='" + sci.SpecialCName + "'," +
             "[Domain]='" + sci.Domain + "',isDelPoint=" + sci.isDelPoint + ",Gpoint=" + sci.Gpoint + ",iPoint=" + sci.iPoint + "," +
             "GroupNumber='" + sci.GroupNumber + "',saveDirPath='" + sci.saveDirPath + "',SavePath='" + sci.SavePath + "'," +
             "FileName='" + sci.FileName + "',FileEXName='" + sci.FileEXName + "',NaviPicURL='" + sci.NaviPicURL + "'," +
             "NaviContent='" + sci.NaviContent + "',Templet='" + sci.Templet + "',NaviPosition='" + sci.NaviPosition + "' " +
             "Where SpecialID='" + sci.SpecialID + "'";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SpecialID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_special ");
            strSql.Append(" where SpecialID=@SpecialID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@SpecialID", OleDbType.VarChar,12)			};
            parameters[0].Value = SpecialID;

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
        public bool DeleteList(string SpecialIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_special ");
            strSql.Append(" where SpecialID in (" + SpecialIDlist + ")  ");
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
        public Foosun.Model.NewsSpecial GetModel(string SpecialID)
        {

            string str_Sql = "Select Id,SpecialID,SpecialCName,specialEName,ParentID,[Domain],isDelPoint,Gpoint,iPoint,GroupNumber,FileName," +
                             "FileEXName,NaviPicURL,NaviContent,Templet,isLock,isRecyle,SavePath,saveDirPath,NaviPosition,SiteID,CreatTime From " +
                             Pre + "news_special Where SiteID='" + Foosun.Global.Current.SiteID + "' And SpecialID='" + SpecialID + "'";
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);

            Foosun.Model.NewsSpecial model = new Foosun.Model.NewsSpecial();
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["SpecialID"] != null && ds.Rows[0]["SpecialID"].ToString() != "")
                {
                    model.SpecialID = ds.Rows[0]["SpecialID"].ToString();
                }
                if (ds.Rows[0]["SpecialCName"] != null && ds.Rows[0]["SpecialCName"].ToString() != "")
                {
                    model.SpecialCName = ds.Rows[0]["SpecialCName"].ToString();
                }
                if (ds.Rows[0]["specialEName"] != null && ds.Rows[0]["specialEName"].ToString() != "")
                {
                    model.specialEName = ds.Rows[0]["specialEName"].ToString();
                }
                if (ds.Rows[0]["ParentID"] != null && ds.Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = ds.Rows[0]["ParentID"].ToString();
                }
                if (ds.Rows[0]["Domain"] != null && ds.Rows[0]["Domain"].ToString() != "")
                {
                    model.Domain = ds.Rows[0]["Domain"].ToString();
                }
                if (ds.Rows[0]["isDelPoint"] != null && ds.Rows[0]["isDelPoint"].ToString() != "")
                {
                    model.isDelPoint = int.Parse(ds.Rows[0]["isDelPoint"].ToString());
                }
                if (ds.Rows[0]["Gpoint"] != null && ds.Rows[0]["Gpoint"].ToString() != "")
                {
                    model.Gpoint = int.Parse(ds.Rows[0]["Gpoint"].ToString());
                }
                if (ds.Rows[0]["iPoint"] != null && ds.Rows[0]["iPoint"].ToString() != "")
                {
                    model.iPoint = int.Parse(ds.Rows[0]["iPoint"].ToString());
                }
                if (ds.Rows[0]["GroupNumber"] != null && ds.Rows[0]["GroupNumber"].ToString() != "")
                {
                    model.GroupNumber = ds.Rows[0]["GroupNumber"].ToString();
                }
                if (ds.Rows[0]["saveDirPath"] != null && ds.Rows[0]["saveDirPath"].ToString() != "")
                {
                    model.saveDirPath = ds.Rows[0]["saveDirPath"].ToString();
                }
                if (ds.Rows[0]["SavePath"] != null && ds.Rows[0]["SavePath"].ToString() != "")
                {
                    model.SavePath = ds.Rows[0]["SavePath"].ToString();
                }
                if (ds.Rows[0]["FileName"] != null && ds.Rows[0]["FileName"].ToString() != "")
                {
                    model.FileName = ds.Rows[0]["FileName"].ToString();
                }
                if (ds.Rows[0]["FileEXName"] != null && ds.Rows[0]["FileEXName"].ToString() != "")
                {
                    model.FileEXName = ds.Rows[0]["FileEXName"].ToString();
                }
                if (ds.Rows[0]["NaviPicURL"] != null && ds.Rows[0]["NaviPicURL"].ToString() != "")
                {
                    model.NaviPicURL = ds.Rows[0]["NaviPicURL"].ToString();
                }
                if (ds.Rows[0]["NaviContent"] != null && ds.Rows[0]["NaviContent"].ToString() != "")
                {
                    model.NaviContent = ds.Rows[0]["NaviContent"].ToString();
                }
                if (ds.Rows[0]["SiteID"] != null && ds.Rows[0]["SiteID"].ToString() != "")
                {
                    model.SiteID = ds.Rows[0]["SiteID"].ToString();
                }
                if (ds.Rows[0]["Templet"] != null && ds.Rows[0]["Templet"].ToString() != "")
                {
                    model.Templet = ds.Rows[0]["Templet"].ToString();
                }
                if (ds.Rows[0]["isLock"] != null && ds.Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Rows[0]["isLock"].ToString());
                }
                if (ds.Rows[0]["isRecyle"] != null && ds.Rows[0]["isRecyle"].ToString() != "")
                {
                    model.isRecyle = int.Parse(ds.Rows[0]["isRecyle"].ToString());
                }
                if (ds.Rows[0]["CreatTime"] != null && ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
                }
                if (ds.Rows[0]["NaviPosition"] != null && ds.Rows[0]["NaviPosition"].ToString() != "")
                {
                    model.NaviPosition = ds.Rows[0]["NaviPosition"].ToString();
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
            strSql.Append("select Id,SpecialID,SpecialCName,specialEName,ParentID,[Domain],isDelPoint,Gpoint,iPoint,GroupNumber,saveDirPath,SavePath,FileName,FileEXName,NaviPicURL,NaviContent,SiteID,Templet,isLock,isRecyle,CreatTime,NaviPosition,ModelID ");
            strSql.Append(" FROM " + Pre + "news_special ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append(" Id,SpecialID,SpecialCName,specialEName,ParentID,Domain,isDelPoint,Gpoint,iPoint,GroupNumber,saveDirPath,SavePath,FileName,FileEXName,NaviPicURL,NaviContent,SiteID,Templet,isLock,isRecyle,CreatTime,NaviPosition,ModelID ");
            strSql.Append(" FROM " + Pre + "news_special ");
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
            strSql.Append("select count(1) FROM " + Pre + "news_special ");
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
                strSql.Append("order by T.SpecialID desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "news_special T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        public DataTable GetSpecialByCName(string specialCName)
        {
            string SQL = "Select id,SpecialID,SpecialCName,isLock,CreatTime from " + Pre + "news_special where SpecialCName like '%" + specialCName + "%' order by Id Desc";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, SQL, null);
            return dt;
        }

        public DataTable GetPage(string siteId, int pageSize, int pageIndex, out int recordCount, out int pageCount)
        {
            string where = "";
            OleDbParameter param = null;
            if (siteId == null || siteId == string.Empty)
            {
                where = "";
            }
            else
            {
                where = "  where isRecyle=0 and ParentID='0' and SiteId=@SiteId";
                param = new OleDbParameter("@SiteId", siteId);
            }

            string AllFields = "id,SpecialID,SpecialCName,isLock,CreatTime";
            string Condition = "" + Pre + "news_special " + where + "";
            string IndexField = "id";
            string OrderFields = "order by id desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, pageIndex, pageSize, out recordCount, out pageCount, param);
        }
        /// <summary>
        /// 得到子专题
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public DataTable GetChildList(string classid)
        {
            string str_Sql = "Select Id,SpecialID,SpecialCName,CreatTime,isLock From " + Pre + "news_special " +
                             "Where isRecyle=0 and ParentID='" + classid + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            return dt;
        }

        /// <summary>
        /// 锁定/解锁专题
        /// </summary>
        /// <param name="specialID"></param>
        public int SetLock(string specialID)
        {
            string idstr = Common.Input.CutComma(GetChildId(specialID));
            string str_sql = "Update " + Pre + "news_special Set isLock=iif(isLock=1,0,1) where SpecialID In(" + idstr + ")";
            return DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, null);
        }

        /// <summary>
        /// 放入/撤回回收站
        /// </summary>
        /// <param name="specialId"></param>
        /// <returns></returns>
        public int SetRecyle(string specialId)
        {
            string sqlArray = "update " + Pre + "news_special set isRecyle=iif(isRecyle=1,0,1) where SpecialID in (" + specialId + ") and SiteID='" + Foosun.Global.Current.SiteID + "'";
            return DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
        }

        /// <summary>
        /// 获取专题下的新闻总数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetSpicaelNewsCount(string id)
        {
            string str_Sql = "Select Count(Id) From " + Pre + "special_news Where SpecialID='" + id + "'";
            return DbHelper.ExecuteScalar(CommandType.Text, str_Sql, null);
        }

        /// <summary>
        /// 根据父ID获取专题信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public IDataReader GetSpecialByParentId(string parentID)
        {
            OleDbParameter param = new OleDbParameter("@ParentID", parentID);
            string sql = "select ID,SpecialID,SpecialCName,ParentID,Templet from " + Pre + "news_special where ParentID=@ParentID and isLock=0 and isRecyle=0 order by id desc";
            return DbHelper.ExecuteReader(CommandType.Text, sql, param);
        }
        /// <summary>
        /// 跟新专题模板 
        /// </summary>
        /// <param name="specialID"></param>
        /// <param name="templet"></param>
        public void UpdateTemplet(string specialID, string templet)
        {
            string sql = "update " + Pre + "news_special set Templet='" + templet + "' where SpecialID in (" + specialID + ")";
            DbHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 通用获取专题的内容
        /// </summary>
        /// <param name="field">要获取的字段名，多个字段用，隔开</param>
        /// <param name="where">查询的条件</param>
        /// <returns></returns>
        public DataTable GetContent(string field, string where, string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + field);
            strSql.Append(" FROM " + Pre + "news_special ");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            if (order.Trim() != "")
            {
                strSql.Append(" order by " + order);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        private OleDbParameter[] GetSpecialParameters(Foosun.Model.NewsSpecial sc)
        {
            OleDbParameter[] param = new OleDbParameter[21];
            param[0] = new OleDbParameter("@SpecialID", OleDbType.VarWChar, 12);
            param[0].Value = sc.SpecialID;
            param[1] = new OleDbParameter("@SpecialCName", OleDbType.VarWChar, 50);
            param[1].Value = sc.SpecialCName;
            param[2] = new OleDbParameter("@specialEName", OleDbType.VarWChar, 50);
            param[2].Value = sc.specialEName;

            param[3] = new OleDbParameter("@ParentID", OleDbType.VarWChar, 12);
            if (string.IsNullOrEmpty(sc.ParentID.ToString()))
            {
                param[3].Value = 0;
            }
            else
            {
                param[3].Value = sc.ParentID;
            }
            param[4] = new OleDbParameter("@Domain", OleDbType.VarWChar, 100);
            param[4].Value = sc.Domain;
            param[5] = new OleDbParameter("@isDelPoint", OleDbType.Integer, 1);
            param[5].Value = sc.isDelPoint;

            param[6] = new OleDbParameter("@Gpoint", OleDbType.Integer, 8);
            param[6].Value = sc.Gpoint;
            param[7] = new OleDbParameter("@iPoint", OleDbType.Integer, 8);
            param[7].Value = sc.iPoint;
            param[8] = new OleDbParameter("@GroupNumber", OleDbType.VarWChar, 200);
            param[8].Value = sc.GroupNumber;

            param[9] = new OleDbParameter("@saveDirPath", OleDbType.VarWChar, 100);
            param[9].Value = sc.saveDirPath;
            param[10] = new OleDbParameter("@SavePath", OleDbType.VarWChar, 100);
            param[10].Value = sc.SavePath;
            param[11] = new OleDbParameter("@FileName", OleDbType.VarWChar, 100);
            param[11].Value = sc.FileName;

            param[12] = new OleDbParameter("@FileEXName", OleDbType.VarWChar, 6);
            param[12].Value = sc.FileEXName;
            param[13] = new OleDbParameter("@NaviPicURL", OleDbType.VarWChar, 200);
            param[13].Value = sc.NaviPicURL;
            param[14] = new OleDbParameter("@NaviContent", OleDbType.VarWChar, 255);
            param[14].Value = sc.NaviContent;

            param[15] = new OleDbParameter("@SiteID", OleDbType.VarWChar, 12);
            param[15].Value = sc.SiteID;
            param[16] = new OleDbParameter("@Templet", OleDbType.VarWChar, 200);
            param[16].Value = sc.Templet;
            param[17] = new OleDbParameter("@isLock", OleDbType.Integer, 1);
            param[17].Value = sc.isLock;

            param[18] = new OleDbParameter("@isRecyle", OleDbType.Integer, 1);
            param[18].Value = sc.isRecyle;
            param[19] = new OleDbParameter("@CreatTime", OleDbType.Date, 8);
            param[19].Value = sc.CreatTime;
            param[20] = new OleDbParameter("@NaviPosition", OleDbType.VarWChar, 255);
            param[20].Value = sc.NaviPosition;
            return param;
        }
        protected string GetChildId(string id)
        {
            string str_Sql = "Select SpecialID,ParentID From " + Pre + "news_special Where SiteID='" + Foosun.Global.Current.SiteID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            string idstr = "'" + id + "'," + GetRecursion(dt, id);
            return idstr;
        }

        protected string GetRecursion(DataTable dt, string PID)
        {
            DataRow[] row = null;
            string idstr = "";
            row = dt.Select("ParentID='" + PID + "'");
            if (row.Length < 1)
                return idstr;
            else
            {
                foreach (DataRow r in row)
                {
                    idstr += "'" + r[0].ToString() + "',";
                    idstr += GetRecursion(dt, r[0].ToString());
                }
            }
            return idstr;
        }
        #endregion  Method
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Foosun.IDAL;
using Foosun.DALProfile;
using System.Collections.Generic;
namespace Foosun.SQLServerDAL
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
            SqlParameter[] parameters = {
					new SqlParameter("@SpecialID", SqlDbType.NVarChar,12)			};
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
            string str_Sql = "Insert Into " + Pre + "news_special(SpecialID,SpecialCName,specialEName,ParentID," +
                      "[Domain],isDelPoint,Gpoint,iPoint,GroupNumber,saveDirPath,SavePath,FileName,FileEXName," +
                      "NaviPicURL,NaviContent,SiteID,Templet,isLock,isRecyle,CreatTime,NaviPosition" +
                      ") Values('" + SpecialID + "',@SpecialCName,@specialEName,@ParentID,@Domain," +
                      "@isDelPoint,@Gpoint,@iPoint,@GroupNumber,@saveDirPath,@SavePath,@FileName,@FileEXName," +
                      "@NaviPicURL,@NaviContent,@SiteID,@Templet,@isLock,@isRecyle,@CreatTime,@NaviPosition)";
            SqlParameter[] param = new SqlParameter[21];
            param[0] = new SqlParameter("@SpecialID", SqlDbType.NVarChar, 12);
            param[0].Value = model.SpecialID;
            param[1] = new SqlParameter("@SpecialCName", SqlDbType.NVarChar, 50);
            param[1].Value = model.SpecialCName;
            param[2] = new SqlParameter("@specialEName", SqlDbType.NVarChar, 50);
            param[2].Value = model.specialEName;
            param[3] = new SqlParameter("@ParentID", SqlDbType.NVarChar, 12);
            param[3].Value = model.ParentID;
            param[4] = new SqlParameter("@Domain", SqlDbType.NVarChar, 100);
            param[4].Value = model.Domain;
            param[5] = new SqlParameter("@isDelPoint", SqlDbType.TinyInt, 1);
            param[5].Value = model.isDelPoint;
            param[6] = new SqlParameter("@Gpoint", SqlDbType.Int, 4);
            param[6].Value = model.Gpoint;
            param[7] = new SqlParameter("@iPoint", SqlDbType.Int, 4);
            param[7].Value = model.iPoint;
            param[8] = new SqlParameter("@GroupNumber", SqlDbType.NText);
            param[8].Value = model.GroupNumber;
            param[9] = new SqlParameter("@saveDirPath", SqlDbType.NVarChar, 100);
            param[9].Value = model.saveDirPath;
            param[10] = new SqlParameter("@SavePath", SqlDbType.NVarChar, 100);
            param[10].Value = model.SavePath;
            param[11] = new SqlParameter("@FileName", SqlDbType.NVarChar, 100);
            param[11].Value = model.FileName;
            param[12] = new SqlParameter("@FileEXName", SqlDbType.NVarChar, 6);
            param[12].Value = model.FileEXName;
            param[13] = new SqlParameter("@NaviPicURL", SqlDbType.NVarChar, 200);
            param[13].Value = model.NaviPicURL;
            param[14] = new SqlParameter("@NaviContent", SqlDbType.NVarChar, 255);
            param[14].Value = model.NaviContent;
            param[15] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
            param[15].Value = model.SiteID;
            param[16] = new SqlParameter("@Templet", SqlDbType.NVarChar, 200);
            param[16].Value = model.Templet;
            param[17] = new SqlParameter("@isLock", SqlDbType.TinyInt, 1);
            param[17].Value = model.isLock;
            param[18] = new SqlParameter("@isRecyle", SqlDbType.TinyInt, 1);
            param[18].Value = model.isRecyle;
            param[19] = new SqlParameter("@CreatTime", SqlDbType.DateTime, 8);
            param[19].Value = model.CreatTime;
            param[20] = new SqlParameter("@NaviPosition", SqlDbType.NVarChar, 255);
            param[20].Value = model.NaviPosition;
            result = Convert.ToInt32(DbHelper.ExecuteNonQuery(CommandType.Text, str_Sql, param));
            return result + "|" + SpecialID;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsSpecial model)
        {
            int result = 0;
            string checkSql = "";
            int recordCount = 0;
            checkSql = "select count(*) from " + Pre + "news_special Where SpecialID!='" + model.SpecialID + "' " +
                       " And SpecialCName='" + model.SpecialCName + "'";
            recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, checkSql, null);
            if (recordCount > 0)
            {
                throw new Exception("专题中文名称重复,请重新修改!");
            }

            string Sql = "Update " + Pre + "news_special Set SpecialCName=@SpecialCName," +
                         "[Domain]=@Domain,isDelPoint=@isDelPoint,Gpoint=@Gpoint,iPoint=@iPoint," +
                         "GroupNumber=@GroupNumber,saveDirPath=@saveDirPath,SavePath=@SavePath," +
                         "FileName=@FileName,FileEXName=@FileEXName,NaviPicURL=@NaviPicURL," +
                         "NaviContent=@NaviContent,Templet=@Templet,NaviPosition=@NaviPosition " +
                         "Where SpecialID=@SpecialID";
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@SpecialID", SqlDbType.NVarChar, 12);
            param[0].Value = model.SpecialID;
            param[1] = new SqlParameter("@SpecialCName", SqlDbType.NVarChar, 50);
            param[1].Value = model.SpecialCName;
            param[2] = new SqlParameter("@specialEName", SqlDbType.NVarChar, 50);
            param[2].Value = model.specialEName;
            param[3] = new SqlParameter("@ParentID", SqlDbType.NVarChar, 12);
            param[3].Value = model.ParentID;
            param[4] = new SqlParameter("@Domain", SqlDbType.NVarChar, 100);
            param[4].Value = model.Domain;
            param[5] = new SqlParameter("@isDelPoint", SqlDbType.TinyInt, 1);
            param[5].Value = model.isDelPoint;
            param[6] = new SqlParameter("@Gpoint", SqlDbType.Int, 4);
            param[6].Value = model.Gpoint;
            param[7] = new SqlParameter("@iPoint", SqlDbType.Int, 4);
            param[7].Value = model.iPoint;
            param[8] = new SqlParameter("@GroupNumber", SqlDbType.NText);
            param[8].Value = model.GroupNumber;
            param[9] = new SqlParameter("@saveDirPath", SqlDbType.NVarChar, 100);
            param[9].Value = model.saveDirPath;
            param[10] = new SqlParameter("@SavePath", SqlDbType.NVarChar, 100);
            param[10].Value = model.SavePath;
            param[11] = new SqlParameter("@FileName", SqlDbType.NVarChar, 100);
            param[11].Value = model.FileName;
            param[12] = new SqlParameter("@FileEXName", SqlDbType.NVarChar, 6);
            param[12].Value = model.FileEXName;
            param[13] = new SqlParameter("@NaviPicURL", SqlDbType.NVarChar, 200);
            param[13].Value = model.NaviPicURL;
            param[14] = new SqlParameter("@NaviContent", SqlDbType.NVarChar, 255);
            param[14].Value = model.NaviContent;
            param[15] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
            param[15].Value = model.SiteID;
            param[16] = new SqlParameter("@Templet", SqlDbType.NVarChar, 200);
            param[16].Value = model.Templet;
            param[17] = new SqlParameter("@isRecyle", SqlDbType.TinyInt, 1);
            param[17].Value = model.isRecyle;
            param[18] = new SqlParameter("@CreatTime", SqlDbType.DateTime, 8);
            param[18].Value = model.CreatTime;
            param[19] = new SqlParameter("@NaviPosition", SqlDbType.NVarChar, 255);
            param[19].Value = model.NaviPosition;
            result = Convert.ToInt32(DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param));
            return result == 1;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SpecialID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_special ");
            strSql.Append(" where SpecialID=@SpecialID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SpecialID", SqlDbType.NVarChar,12)			};
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,SpecialID,SpecialCName,specialEName,ParentID,Domain,isDelPoint,Gpoint,iPoint,GroupNumber,saveDirPath,SavePath,FileName,FileEXName,NaviPicURL,NaviContent,SiteID,Templet,isLock,isRecyle,CreatTime,NaviPosition,ModelID from " + Pre + "news_special ");
            strSql.Append(" where SpecialID=@SpecialID and SiteID='" + Foosun.Global.Current.SiteID + "'");
            SqlParameter[] parameters = {
					new SqlParameter("@SpecialID", SqlDbType.NVarChar,12)			};
            parameters[0].Value = SpecialID;

            Foosun.Model.NewsSpecial model = new Foosun.Model.NewsSpecial();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
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
                if (ds.Rows[0]["ModelID"] != null && ds.Rows[0]["ModelID"].ToString() != "")
                {
                    model.ModelID = ds.Rows[0]["ModelID"].ToString();
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
            strSql.Append("select Id,SpecialID,SpecialCName,specialEName,ParentID,Domain,isDelPoint,Gpoint,iPoint,GroupNumber,saveDirPath,SavePath,FileName,FileEXName,NaviPicURL,NaviContent,SiteID,Templet,isLock,isRecyle,CreatTime,NaviPosition,ModelID ");
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
            SqlParameter param = null;
            if (siteId == null || siteId == string.Empty)
            {
                where = "";
            }
            else
            {
                where = "  where isRecyle=0 and ParentID='0' and SiteId=@SiteId";
                param = new SqlParameter("@SiteId", siteId);
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
            List<string> SqlArray = new List<string>();
            if (specialID.IndexOf(",") > -1)
            {
                string[] IdArray = specialID.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in IdArray)
                {
                    SqlArray.Add("update " + Pre + "news_special set isLock=(case isLock when 1 then 0 when 0 then 1 end) where SpecialID=" + id + " and SiteID=" + Foosun.Global.Current.SiteID);
                }
            }
            else
            {
                SqlArray.Add("update " + Pre + "news_special set isLock=(case isLock when 1 then 0 when 0 then 1 end) where SpecialID=" + specialID + " and SiteID=" + Foosun.Global.Current.SiteID);
            }
            return DbHelper.ExecuteSqlTran(SqlArray);
        }

        /// <summary>
        /// 放入/撤回回收站
        /// </summary>
        /// <param name="specialId"></param>
        /// <returns></returns>
        public int SetRecyle(string specialId)
        {
            List<string> sqlArray = new List<string>();
            if (specialId.IndexOf(",") > -1)
            {
                string[] classIds = specialId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray.Add("update " + Pre + "news_special set isRecyle=(case isRecyle when 1 then 0 when 0 then 1 end) where SpecialID=" + id.Replace("'", "") + " and SiteID=" + Foosun.Global.Current.SiteID);
                }
            }
            else
            {
                sqlArray.Add("update " + Pre + "news_special set isRecyle=(case isRecyle when 1 then 0 when 0 then 1 end) where SpecialID=" + specialId + " and SiteID=" + Foosun.Global.Current.SiteID);
            }
            return DbHelper.ExecuteSqlTran(sqlArray);
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
            SqlParameter param = new SqlParameter("@ParentID", parentID);
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
        #endregion  Method
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using Foosun.IDAL;
using System.Data;
using Foosun.DALProfile;
using Foosun.Config;
using System.Data.OleDb;

namespace Foosun.AccessDAL
{
    /// <summary>
    /// 数据访问类:NewsClass
    /// </summary>
    public partial class NewsClass : DbBase, INewsClass
    {
        public NewsClass()
        { }
        #region  实现方法
        /// <summary>
        /// 是否存在该记录(ClassID)
        /// </summary>
        public int ExistsByClassId(string ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_Class");
            strSql.Append(" where ");
            strSql.Append(" ClassID = @ClassID  ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ClassID", OleDbType.VarWChar,12)			};
            parameters[0].Value = ClassID;

            return (int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录(EName)
        /// </summary>
        public int ExistsByClassEName(string eName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_Class");
            strSql.Append(" where ");
            strSql.Append(" ClassEName = @ClassEName  ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ClassEName", OleDbType.VarWChar)			};
            parameters[0].Value = eName;

            return (int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 通用判断是否存在该记录
        /// </summary>
        public int Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "news_Class");
            strSql.Append(" where ");
            strSql.Append(where);
            return (int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 更新导航
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public void UpdateReplaceNavi(string classID)
        {
            OleDbConnection cn = new OleDbConnection(DBConfig.CmsConString);
            try
            {
                cn.Open();
                string NewsPosition = "";
                string url = "";
                string dim = Foosun.Config.UIConfig.dirDumm;
                if (dim.Trim() != string.Empty)
                {
                    dim = "/" + dim;
                }
                string sql = "select ClassID,SavePath,SaveClassframe,ClassSaveRule,NaviPosition,NewsPosition from " + Pre + "news_class where ClassID=@ClassID";
                OleDbParameter Prm = new OleDbParameter("@ClassID", classID);
                IDataReader rd = DbHelper.ExecuteReader(cn, CommandType.Text, sql, Prm);
                if (rd.Read())
                {
                    NewsPosition = rd["NewsPosition"].ToString();
                    url = dim + "/" + rd["SavePath"].ToString() + "/" + rd["SaveClassframe"].ToString() + "/" + rd["ClassSaveRule"].ToString();
                    NewsPosition = NewsPosition.Replace("{@ClassURL}", url).Replace("//", "/");
                }
                rd.Close();
                string Usql = "update " + Pre + "news_class set NewsPosition=@NewsPosition where ClassID=@ClassID";
                OleDbParameter[] Param = new OleDbParameter[]
            {
                new OleDbParameter("@NewsPosition",NewsPosition),new OleDbParameter("@ClassID",classID)
            };
                DbHelper.ExecuteNonQuery(cn, CommandType.Text, Usql, Param);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Foosun.Model.NewsClass model)
        {
            OleDbParameter[] parm = GetNewsClassParameter(model);
            string Sql = "insert into " + Pre + "News_Class(";
            Sql += Database.GetParam(parm) + ",isPage,ModelID,isunHTML,DataLib";
            Sql += ") values (";
            Sql += "" + Database.GetAParam(parm) + ",0,'0',0,'" + Pre + "News')";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm);
        }

        /// <summary>
        /// 获取ClassContent构造
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        private OleDbParameter[] GetNewsClassParameter(Foosun.Model.NewsClass uc)
        {
            OleDbParameter[] param = new OleDbParameter[40];
            param[0] = new OleDbParameter("@Defineworkey", OleDbType.VarWChar, 255);
            param[0].Value = uc.Defineworkey;
            param[1] = new OleDbParameter("@ClassID", OleDbType.VarWChar, 12);
            param[1].Value = uc.ClassID;
            param[2] = new OleDbParameter("@ClassCName", OleDbType.VarWChar, 50);
            param[2].Value = uc.ClassCName;
            param[3] = new OleDbParameter("@ClassEName", OleDbType.VarWChar, 50);
            param[3].Value = uc.ClassEName;
            param[4] = new OleDbParameter("@ParentID", OleDbType.VarWChar, 12);
            param[4].Value = uc.ParentID;
            param[5] = new OleDbParameter("@IsURL", OleDbType.Integer, 1);
            param[5].Value = uc.IsURL;
            param[6] = new OleDbParameter("@OrderID", OleDbType.Integer, 1);
            param[6].Value = uc.OrderID;
            param[7] = new OleDbParameter("@URLaddress", OleDbType.VarWChar, 200);
            param[7].Value = uc.URLaddress;
            param[8] = new OleDbParameter("@Domain", OleDbType.VarWChar, 150);
            param[8].Value = uc.Domain;
            param[9] = new OleDbParameter("@ClassTemplet", OleDbType.VarWChar, 200);
            param[9].Value = uc.ClassTemplet;
            param[10] = new OleDbParameter("@ReadNewsTemplet", OleDbType.VarWChar, 200);
            param[10].Value = uc.ReadNewsTemplet;
            param[11] = new OleDbParameter("@SavePath", OleDbType.VarWChar, 50);
            param[11].Value = uc.SavePath;
            param[12] = new OleDbParameter("@SaveClassframe", OleDbType.VarWChar, 200);
            param[12].Value = uc.SaveClassframe;
            param[13] = new OleDbParameter("@Checkint", OleDbType.Integer, 1);
            param[13].Value = uc.Checkint;
            param[14] = new OleDbParameter("@ClassSaveRule", OleDbType.VarWChar, 200);
            param[14].Value = uc.ClassSaveRule;
            param[15] = new OleDbParameter("@ClassIndexRule", OleDbType.VarWChar, 50);
            param[15].Value = uc.ClassIndexRule;
            param[16] = new OleDbParameter("@NewsSavePath", OleDbType.VarWChar, 50);
            param[16].Value = uc.NewsSavePath;
            param[17] = new OleDbParameter("@NewsFileRule", OleDbType.VarWChar, 200);
            param[17].Value = uc.NewsFileRule;
            param[18] = new OleDbParameter("@PicDirPath", OleDbType.VarWChar, 50);
            param[18].Value = uc.PicDirPath;
            param[19] = new OleDbParameter("@ContentPicTF", OleDbType.Integer, 1);
            param[19].Value = uc.ContentPicTF;
            param[20] = new OleDbParameter("@ContentPICurl", OleDbType.VarWChar, 200);
            param[20].Value = uc.ContentPICurl;
            param[21] = new OleDbParameter("@ContentPicSize", OleDbType.VarWChar, 15);
            param[21].Value = uc.ContentPicSize;
            param[22] = new OleDbParameter("@InHitoryDay", OleDbType.Integer, 8);
            param[22].Value = uc.InHitoryDay;
            param[23] = new OleDbParameter("@SiteID", OleDbType.VarWChar, 12);
            param[23].Value = uc.SiteID;
            param[24] = new OleDbParameter("@NaviShowtf", OleDbType.Integer, 1);
            param[24].Value = uc.NaviShowtf;
            param[25] = new OleDbParameter("@NaviPIC", OleDbType.VarWChar, 200);
            param[25].Value = uc.NaviPIC;
            param[26] = new OleDbParameter("@NaviContent", OleDbType.VarWChar, 255);
            param[26].Value = uc.NaviContent;
            param[27] = new OleDbParameter("@MetaKeywords", OleDbType.VarWChar, 200);
            param[27].Value = uc.MetaKeywords;
            param[28] = new OleDbParameter("@MetaDescript", OleDbType.VarWChar, 200);
            param[28].Value = uc.MetaDescript;
            param[29] = new OleDbParameter("@isDelPoint", OleDbType.Integer, 1);
            param[29].Value = uc.isDelPoint;
            param[30] = new OleDbParameter("@Gpoint", OleDbType.Integer, 4);
            param[30].Value = uc.Gpoint;
            param[31] = new OleDbParameter("@iPoint", OleDbType.Integer, 4);
            param[31].Value = uc.iPoint;
            param[32] = new OleDbParameter("@GroupNumber", OleDbType.VarWChar, 255);
            param[32].Value = uc.GroupNumber;
            param[33] = new OleDbParameter("@FileName", OleDbType.VarWChar, 6);
            param[33].Value = uc.FileName;
            param[34] = new OleDbParameter("@isLock", OleDbType.Integer, 1);
            param[34].Value = uc.isLock;
            param[35] = new OleDbParameter("@isRecyle", OleDbType.Integer, 1);
            param[35].Value = uc.isRecyle;
            param[36] = new OleDbParameter("@NaviPosition", OleDbType.VarChar, 8000);
            param[36].Value = uc.NaviPosition;
            param[37] = new OleDbParameter("@NewsPosition", OleDbType.VarChar, 8000);
            param[37].Value = uc.NewsPosition;
            param[38] = new OleDbParameter("@isComm", OleDbType.Integer, 1);
            param[38].Value = uc.isComm;
            param[39] = new OleDbParameter("@CreatTime", OleDbType.Date, 8);
            param[39].Value = uc.CreatTime;

            return param;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsClass model)
        {
            OleDbParameter[] parm = GetNewsClassParameter(model);
            string Sql = "Update " + Pre + "News_Class set " + Database.GetModifyParam(parm) + ",ModelID='0' where ClassID='" + model.ClassID.ToString() + "' " + Common.Public.getSessionStr() + "";

            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_Class ");
            strSql.Append(" where Id=@Id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_Class ");
            strSql.Append(" where Id in (" + idlist + ")  ");
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
        public Foosun.Model.NewsClass GetModel(string ClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [Id],[ClassCName],[ClassEName],[ParentID],IsURL,OrderID,URLaddress,[Domain],ClassTemplet,ReadNewsTemplet,[SavePath],SaveClassframe,Checkint,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,[SiteID],NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isLock,isRecyle,NaviPosition,NewsPosition,isComm,Defineworkey,CreatTime,isPage,PageContent,ModelID,isunHTML from " + Pre + "news_Class ");
            strSql.Append(" where ClassID=@ClassID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ClassID", OleDbType.VarWChar,12)
			};
            parameters[0].Value = ClassID;

            Foosun.Model.NewsClass model = new Foosun.Model.NewsClass();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["ClassCName"] != null && ds.Rows[0]["ClassCName"].ToString() != "")
                {
                    model.ClassCName = ds.Rows[0]["ClassCName"].ToString();
                }
                if (ds.Rows[0]["ClassEName"] != null && ds.Rows[0]["ClassEName"].ToString() != "")
                {
                    model.ClassEName = ds.Rows[0]["ClassEName"].ToString();
                }
                if (ds.Rows[0]["ParentID"] != null && ds.Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = ds.Rows[0]["ParentID"].ToString();
                }
                if (ds.Rows[0]["IsURL"] != null && ds.Rows[0]["IsURL"].ToString() != "")
                {
                    model.IsURL = int.Parse(ds.Rows[0]["IsURL"].ToString());
                }
                if (ds.Rows[0]["OrderID"] != null && ds.Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Rows[0]["OrderID"].ToString());
                }
                if (ds.Rows[0]["URLaddress"] != null && ds.Rows[0]["URLaddress"].ToString() != "")
                {
                    model.URLaddress = ds.Rows[0]["URLaddress"].ToString();
                }
                if (ds.Rows[0]["Domain"] != null && ds.Rows[0]["Domain"].ToString() != "")
                {
                    model.Domain = ds.Rows[0]["Domain"].ToString();
                }
                if (ds.Rows[0]["ClassTemplet"] != null && ds.Rows[0]["ClassTemplet"].ToString() != "")
                {
                    model.ClassTemplet = ds.Rows[0]["ClassTemplet"].ToString();
                }
                if (ds.Rows[0]["ReadNewsTemplet"] != null && ds.Rows[0]["ReadNewsTemplet"].ToString() != "")
                {
                    model.ReadNewsTemplet = ds.Rows[0]["ReadNewsTemplet"].ToString();
                }
                if (ds.Rows[0]["SavePath"] != null && ds.Rows[0]["SavePath"].ToString() != "")
                {
                    model.SavePath = ds.Rows[0]["SavePath"].ToString();
                }
                if (ds.Rows[0]["SaveClassframe"] != null && ds.Rows[0]["SaveClassframe"].ToString() != "")
                {
                    model.SaveClassframe = ds.Rows[0]["SaveClassframe"].ToString();
                }
                if (ds.Rows[0]["Checkint"] != null && ds.Rows[0]["Checkint"].ToString() != "")
                {
                    model.Checkint = int.Parse(ds.Rows[0]["Checkint"].ToString());
                }
                if (ds.Rows[0]["ClassSaveRule"] != null && ds.Rows[0]["ClassSaveRule"].ToString() != "")
                {
                    model.ClassSaveRule = ds.Rows[0]["ClassSaveRule"].ToString();
                }
                if (ds.Rows[0]["ClassIndexRule"] != null && ds.Rows[0]["ClassIndexRule"].ToString() != "")
                {
                    model.ClassIndexRule = ds.Rows[0]["ClassIndexRule"].ToString();
                }
                if (ds.Rows[0]["NewsSavePath"] != null && ds.Rows[0]["NewsSavePath"].ToString() != "")
                {
                    model.NewsSavePath = ds.Rows[0]["NewsSavePath"].ToString();
                }
                if (ds.Rows[0]["NewsFileRule"] != null && ds.Rows[0]["NewsFileRule"].ToString() != "")
                {
                    model.NewsFileRule = ds.Rows[0]["NewsFileRule"].ToString();
                }
                if (ds.Rows[0]["PicDirPath"] != null && ds.Rows[0]["PicDirPath"].ToString() != "")
                {
                    model.PicDirPath = ds.Rows[0]["PicDirPath"].ToString();
                }
                if (ds.Rows[0]["ContentPicTF"] != null && ds.Rows[0]["ContentPicTF"].ToString() != "")
                {
                    model.ContentPicTF = int.Parse(ds.Rows[0]["ContentPicTF"].ToString());
                }
                if (ds.Rows[0]["ContentPICurl"] != null && ds.Rows[0]["ContentPICurl"].ToString() != "")
                {
                    model.ContentPICurl = ds.Rows[0]["ContentPICurl"].ToString();
                }
                if (ds.Rows[0]["ContentPicSize"] != null && ds.Rows[0]["ContentPicSize"].ToString() != "")
                {
                    model.ContentPicSize = ds.Rows[0]["ContentPicSize"].ToString();
                }
                if (ds.Rows[0]["InHitoryDay"] != null && ds.Rows[0]["InHitoryDay"].ToString() != "")
                {
                    model.InHitoryDay = int.Parse(ds.Rows[0]["InHitoryDay"].ToString());
                }
                if (ds.Rows[0]["DataLib"] != null && ds.Rows[0]["DataLib"].ToString() != "")
                {
                    model.DataLib = ds.Rows[0]["DataLib"].ToString();
                }
                if (ds.Rows[0]["SiteID"] != null && ds.Rows[0]["SiteID"].ToString() != "")
                {
                    model.SiteID = ds.Rows[0]["SiteID"].ToString();
                }
                if (ds.Rows[0]["NaviShowtf"] != null && ds.Rows[0]["NaviShowtf"].ToString() != "")
                {
                    model.NaviShowtf = int.Parse(ds.Rows[0]["NaviShowtf"].ToString());
                }
                if (ds.Rows[0]["NaviPIC"] != null && ds.Rows[0]["NaviPIC"].ToString() != "")
                {
                    model.NaviPIC = ds.Rows[0]["NaviPIC"].ToString();
                }
                if (ds.Rows[0]["NaviContent"] != null && ds.Rows[0]["NaviContent"].ToString() != "")
                {
                    model.NaviContent = ds.Rows[0]["NaviContent"].ToString();
                }
                if (ds.Rows[0]["MetaKeywords"] != null && ds.Rows[0]["MetaKeywords"].ToString() != "")
                {
                    model.MetaKeywords = ds.Rows[0]["MetaKeywords"].ToString();
                }
                if (ds.Rows[0]["MetaDescript"] != null && ds.Rows[0]["MetaDescript"].ToString() != "")
                {
                    model.MetaDescript = ds.Rows[0]["MetaDescript"].ToString();
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
                if (ds.Rows[0]["FileName"] != null && ds.Rows[0]["FileName"].ToString() != "")
                {
                    model.FileName = ds.Rows[0]["FileName"].ToString();
                }
                if (ds.Rows[0]["isLock"] != null && ds.Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Rows[0]["isLock"].ToString());
                }
                if (ds.Rows[0]["isRecyle"] != null && ds.Rows[0]["isRecyle"].ToString() != "")
                {
                    model.isRecyle = int.Parse(ds.Rows[0]["isRecyle"].ToString());
                }
                if (ds.Rows[0]["NaviPosition"] != null && ds.Rows[0]["NaviPosition"].ToString() != "")
                {
                    model.NaviPosition = ds.Rows[0]["NaviPosition"].ToString();
                }
                if (ds.Rows[0]["NewsPosition"] != null && ds.Rows[0]["NewsPosition"].ToString() != "")
                {
                    model.NewsPosition = ds.Rows[0]["NewsPosition"].ToString();
                }
                if (ds.Rows[0]["isComm"] != null && ds.Rows[0]["isComm"].ToString() != "")
                {
                    model.isComm = int.Parse(ds.Rows[0]["isComm"].ToString());
                }
                if (ds.Rows[0]["Defineworkey"] != null && ds.Rows[0]["Defineworkey"].ToString() != "")
                {
                    model.Defineworkey = ds.Rows[0]["Defineworkey"].ToString();
                }
                if (ds.Rows[0]["CreatTime"] != null && ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
                }
                if (ds.Rows[0]["isPage"] != null && ds.Rows[0]["isPage"].ToString() != "")
                {
                    model.isPage = int.Parse(ds.Rows[0]["isPage"].ToString());
                }
                if (ds.Rows[0]["PageContent"] != null && ds.Rows[0]["PageContent"].ToString() != "")
                {
                    model.PageContent = ds.Rows[0]["PageContent"].ToString();
                }
                if (ds.Rows[0]["ModelID"] != null && ds.Rows[0]["ModelID"].ToString() != "")
                {
                    model.ModelID = ds.Rows[0]["ModelID"].ToString();
                }
                if (ds.Rows[0]["isunHTML"] != null && ds.Rows[0]["isunHTML"].ToString() != "")
                {
                    model.isunHTML = int.Parse(ds.Rows[0]["isunHTML"].ToString());
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
            strSql.Append("select Id,ClassID,ClassCName,ClassEName,ParentID,IsURL,OrderID,URLaddress,[Domain],ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,Checkint,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,SiteID,NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isLock,isRecyle,NaviPosition,NewsPosition,isComm,Defineworkey,CreatTime,isPage,PageContent,ModelID,isunHTML,ClassId ");
            strSql.Append(" FROM " + Pre + "news_Class ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by OrderID desc,id desc");
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
            strSql.Append(" Id,ClassCName,ClassEName,ParentID,IsURL,OrderID,URLaddress,[Domain],ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,Checkint,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,SiteID,NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isLock,isRecyle,NaviPosition,NewsPosition,isComm,Defineworkey,CreatTime,isPage,PageContent,ModelID,isunHTML ");
            strSql.Append(" FROM " + Pre + "news_Class ");
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
            strSql.Append("select count(1) FROM " + Pre + "news_Class ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from " + Pre + "news_Class T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 复位栏目
        /// </summary>
        /// <param name="ids">栏目编号</param>
        /// <returns></returns>
        public int ResetClass(string ids)
        {
            string sql = "update " + Pre + "news_class set ParentID=0 ";
            if (ids != "")
            {
                sql += " where ClassID in (" + ids + ")";
            }
            return DbHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 合并栏目
        /// </summary>
        /// <param name="sourceClassId">源栏目编号</param>
        /// <param name="targetClassId">目标栏目编号</param>
        /// <returns></returns>
        public int MergerClass(string sourceClassId, string targetClassId)
        {
            int row = 0;
            string sqlArray = "";
            if (sourceClassId.IndexOf(",") > -1)
            {
                string[] sourceClassIds = sourceClassId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string classId in sourceClassIds)
                {
                    sqlArray = "update " + Pre + "news set ClassID='" + targetClassId + "' where ClassID='" + classId + "'";
                    DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
                    sqlArray = "delete from " + Pre + "news_class where ClassID='" + classId + "'";
                    DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
                }
            }
            else
            {
                sqlArray = "update " + Pre + "news set ClassID='" + targetClassId + "' where ClassID='" + sourceClassId + "'";
                DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
                sqlArray = "delete from " + Pre + "news_class where ClassID='" + sourceClassId + "'";
                DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
            }
            return row;
        }

        /// <summary>
        /// 转移栏目
        /// </summary>
        /// <param name="sourceClassId">源栏目编号</param>
        /// <param name="targetClassId">目标栏目编号</param>
        /// <returns></returns>
        public int TransferClass(string sourceClassId, string targetClassId)
        {
            string sql = "update " + Pre + "news_class set ParentId='" + targetClassId + "' where ClassId='" + sourceClassId + "'";
            return DbHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 初始化栏目
        /// </summary>
        /// <returns></returns>
        public int InitializeClass()
        {
            int row = 0;
            string Sql = "delete from " + Pre + "news where SiteID='" + Foosun.Global.Current.SiteID + "'";
            row += DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
            Sql = "delete from " + Pre + "news_class where SiteID='" + Foosun.Global.Current.SiteID + "'";
            row += DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
            return row;
        }

        /// <summary>
        /// 设置栏目属性
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <param name="classTemplet">栏目列表模版</param>
        /// <param name="readNewTemplet">新闻浏览模版</param>
        /// <param name="isUpdate">是否更新栏目下的新闻模版</param>
        /// <returns></returns>
        public int SetClassAttribute(string classId, string classTemplet, string readNewTemplet, bool isUpdate)
        {
            int row = 0;
            string sqlArray;
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray = "update " + Pre + "news_class set ClassTemplet='" + classTemplet + "',ReadNewsTemplet='" + readNewTemplet + "' where ClassId='" + id + "' and SiteID=" + Foosun.Global.Current.SiteID + "'";
                    DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
                }
            }
            else
            {
                sqlArray = "update " + Pre + "news_class set ClassTemplet='" + classTemplet + "',ReadNewsTemplet='" + readNewTemplet + "' where ClassId='" + classId + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
                DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
            }
            return row;
        }

        /// <summary>
        /// 锁定/解锁栏目
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int SetLock(string classId)
        {
            string sqlArray = "";
            int row = 0;
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray = "update " + Pre + "news_class set isLock=iif(isLock=1,0,1) where ClassId='" + id + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
                    DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
                }
            }
            else
            {
                sqlArray = "update " + Pre + "news_class set isLock=iif(isLock=1,0,1) where ClassId='" + classId + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
                DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
            }
            return row;
        }

        /// <summary>
        /// 放入\还原回收站
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int SetRecyle(string classId)
        {
            
            string sqlArray = "";
            int row = 0;
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray = "update " + Pre + "news_class set isRecyle=iif(isRecyle=1,0,1) where ClassId='" + id + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
                    DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
                }
            }
            else
            {
                sqlArray = "update " + Pre + "news_class set isRecyle=iif(isRecyle=1,0,1) where ClassId='" + classId + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
                DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
            }
            return row;
        }

        /// <summary>
        /// 得到栏目下的子类并删除到回收站
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public void SetChildClassRecyle(string parentID)
        {
            string Sql = "select ClassID from " + Pre + "news_Class where ParentID = '" + parentID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    SetRecyle(dt.Rows[0]["ClassID"].ToString());
                    SetChildClassRecyle(dt.Rows[0]["ClassID"].ToString());
                }
                dt.Clear(); dt.Dispose();
            }
        }

        /// <summary>
        /// 清空栏目
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int ClearNews(string classId)
        {
            int row = 0;
            string sqlArray = "";
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray = "delete from " + Pre + "news where ClassId='" + id + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
                    DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
                }
            }
            else
            {
                sqlArray = "delete from " + Pre + "news where ClassId='" + classId + "' and SiteID=" + Foosun.Global.Current.SiteID + "'";
                DbHelper.ExecuteNonQuery(CommandType.Text, sqlArray, null);
            }
            return row;
        }

        /// <summary>
        /// 设置栏目权重
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <param name="orderId">权重</param>
        /// <returns></returns>
        public int SetOrder(string classId, int orderId)
        {
            string sql = "update " + Pre + "news_class set OrderID=" + orderId + " where ClassId='" + classId + "'";
            return DbHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 得到导航内容
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public IDataReader GetNaviClass(string ClassID)
        {
            string Sql = "select ClassCName,ClassEName,ParentID,ClassID,DataLib,SavePath,SaveClassframe,ClassSaveRule from " + Pre + "news_class where ClassID=@ClassID " + Common.Public.getSessionStr() + "";
            OleDbParameter Param = new OleDbParameter("@ClassID", ClassID);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }

        /// <summary>
        /// 得到栏目信息
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public DataTable GetClassContent(string classID)
        {
            string Sql = "Select ClassID,ClassCName,ClassEName,ParentID,IsURL,Checkint,OrderID,Urladdress,[Domain],ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,SiteID,NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isComm,NaviPosition,NewsPosition,Defineworkey From " + Pre + "news_class where ClassID='" + classID + "' " + Common.Public.getSessionStr() + "";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 更新栏目状态
        /// </summary>
        /// <param name="Num">1为已生成，0表示未生成</param>
        public void UpdateClassStat(int Num, string ClassID)
        {
            string str_sql = "update " + Pre + "news_Class set isunHTML=" + Num + " where ClassId='" + ClassID + "' " + Common.Public.getSessionStr() + "";
            DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, null);
        }

        /// <summary>
        /// 得到父类型是否合法
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public DataTable GetParentClass(string classID)
        {
            string Sql = "Select ClassID From " + Pre + "News_Class Where ClassID='" + classID + "' " + Common.Public.getSessionStr() + "";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到该栏目新闻的数据表名
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public string GetDataLib(string ClassID)
        {
            string Sql = "select DataLib from " + Pre + "news_Class where ClassID=@ClassID";
            OleDbParameter Param = new OleDbParameter("@ClassID", ClassID);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }
        /// <summary>
        /// 通用获取栏目的内容
        /// </summary>
        /// <param name="field">要获取的字段名，多个字段用，隔开</param>
        /// <param name="where">查询的条件</param>
        /// <returns></returns>
        public DataTable GetContent(string field, string where, string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + field);
            strSql.Append(" FROM " + Pre + "news_Class ");
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
        /// <summary>
        /// 通用更新栏目方法
        /// </summary>
        /// <param name="ClassID">栏目的classid</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        /// <returns></returns>
        public int UpdateClass(string ClassID, int type, string value, string field)
        {
            string _value = value;
            if (type == 0)
            {
                _value = "'" + value + "'";
            }
            string Sql = "update " + Pre + "news_Class Set " + field + "=" + _value + " where ClassID ='" + ClassID + "' " + Common.Public.getSessionStr() + "";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
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
                where = "  where isRecyle<>1 and ParentID='0' and SiteId=@SiteId";
                param = new OleDbParameter("@SiteId", siteId);
            }

            string AllFields = "id,ClassID,ClassCName,ClassEname,ParentID,OrderID,IsURL,IsLock,[Domain],NaviShowtf,isPage,classtemplet,ReadNewsTemplet,SiteID";
            string Condition = "" + Pre + "News_Class " + where + "";
            string IndexField = "id";
            string OrderFields = "order by OrderID Desc,id desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, pageIndex, pageSize, out recordCount, out pageCount, param);
        }

        /// <summary>
        /// 查询该栏目下是否有子栏目
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int ExistsChild(string classId)
        {
            string sql = "select count(Id) from " + Pre + "news_Class where ParentId=@ParentId";
            OleDbParameter param = new OleDbParameter("@ParentId", OleDbType.VarWChar, 12);
            param.Value = classId;
            return (int)DbHelper.ExecuteScalar(CommandType.Text, sql, param);
        }

        /// <summary>
        /// 获取该栏目下的新闻条数
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataTable GetNewsCount()
        {
            string sql = "select count(Id),classID from " + Pre + "news where isRecyle=0 group by ClassID";
            return DbHelper.ExecuteTable(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 得到栏目下的子栏目
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataTable GetChildList(string parentID)
        {
            string Sql = "Select id,ClassID,ClassCName,ClassEname,ParentID,OrderID,IsURL,IsLock,[Domain],NaviShowtf,isPage,ClassTemplet,ReadNewsTemplet From " + Pre + "News_Class Where isRecyle<>1 and ParentID='" + parentID + "' order by OrderId desc,id desc";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到源栏目列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetSouceClass()
        {
            string Sql = "Select ClassID,ClassCName,ParentID From " + Pre + "news_Class where SiteID='" + Foosun.Global.Current.SiteID + "' and IsURL=0";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 删除源栏目
        /// </summary>
        /// <param name="classID"></param>
        public void DelSouce(string classID)
        {
            string str_sql = "Delete From " + Pre + "news_Class Where ClassID='" + classID + "' and SiteID = '" + Foosun.Global.Current.SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, null);
        }

        /// <summary>
        /// 得到栏目下的子类并彻底删除
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public void DelChildClass(string parentID)
        {
            string Sql = "select ClassID from " + Pre + "news_Class where ParentID = '" + parentID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DelSouce(dt.Rows[0]["ClassID"].ToString());
                    DelChildClass(dt.Rows[0]["ClassID"].ToString());
                }
                dt.Clear(); dt.Dispose();
            }
        }

        /// <summary>
        /// 更新目标栏目
        /// </summary>
        /// <param name="ClassID"></param>
        public void UpdateSouce(string sClassID, string tClassID)
        {
            string usql = "update " + Pre + "news_class set ParentID='" + tClassID + "' where ParentID='" + sClassID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, usql, null);
            string str_sql = "Update " + Pre + "News Set ClassID='" + tClassID + "' Where ClassID='" + sClassID + "' and SiteID = '" + Foosun.Global.Current.SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, null);
        }

        /// <summary>
        /// 更新目标下新闻
        /// </summary>
        /// <param name="ClassID"></param>
        public void ChangeParent(string sClassID, string tClassID)
        {
            string str_sql = "Update " + Pre + "News_Class Set ParentID='" + tClassID + "' Where ClassID='" + sClassID + "'  and SiteID = '" + Foosun.Global.Current.SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, null);
        }

        /// <summary>
        /// 得到栏信息（批量设置属性）
        /// </summary>
        /// <returns></returns>
        public DataTable GetClassInfoTemplet()
        {
            string Sql = "Select ClassID,ClassCname,ParentID From " + Pre + "News_Class where SiteID='" + Foosun.Global.Current.SiteID + "' order by OrderID desc,id desc";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="strUpdate"></param>
        /// <param name="str"></param>
        public void UpdateClassInfo(string strUpdate, string str)
        {
            string Sql = "update " + Pre + "News_Class Set " + strUpdate + " where ClassID in (" + str + ") " + Common.Public.getSessionStr() + "";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 更新所有的表
        /// </summary>
        /// <param name="templet"></param>
        /// <param name="str"></param>
        public void UpdateClassNewsInfo(string templet, string str)
        {
            string Sql = "update " + Pre + "news Set Templet = '" + templet + "' where ClassID in (" + str + ") " + Common.Public.getSessionStr() + "";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 得到栏目列表的子类
        /// </summary>
        /// <returns></returns>
        public DataTable GetLock(string classID)
        {
            string Sql = "Select isLock From " + Pre + "news_Class Where ClassID='" + classID + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到栏目是否是单页面
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public int GetClassPage(string classID)
        {
            string sql = "select isPage from " + Pre + "news_class where ClassID=@ClassID";
            OleDbParameter Param = new OleDbParameter("@ClassID", classID);
            return Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, sql, Param));
        }

        /// <summary>
        /// 得到自定义字段类型（修改）
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public DataTable GetDefineEditTable(string ClassID)
        {
            string Sql = "Select Defineworkey From " + Pre + "News_Class where ClassID='" + ClassID + "'";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到栏目中文名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetNewsClassCName(string classId)
        {
            string strflg = "根栏目";
            OleDbParameter param = new OleDbParameter("@ClassID", classId);
            string Sql = "Select ClassCName From " + Pre + "news_class where ClassID=@ClassID";
            object obj = DbHelper.ExecuteScalar(CommandType.Text, Sql, param);
            if (obj != null)
            {
                if (obj != DBNull.Value)
                    strflg = obj.ToString();
                else
                    strflg = string.Empty;
            }
            return strflg;
        }

        /// <summary>
        /// 更新单页面
        /// </summary>
        /// <param name="NewsClassModel"></param>
        public void UpdatePage(Foosun.Model.NewsClass NewsClassModel)
        {
            OleDbParameter[] parm = GetNewsClassParameter(NewsClassModel);
            string Sql = "Update " + Pre + "News_Class set " + Database.GetModifyParam(parm) + ",[PageContent]='" + NewsClassModel.PageContent + "',InHitoryDay=0,ContentPicTF=0,Checkint=0,ModelID='0' where ClassID='" + NewsClassModel.ClassID + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm);
        }

        /// <summary>
        /// 添加单页面
        /// </summary>
        /// <param name="NewsClassModel"></param>
        public void InsertPage(Foosun.Model.NewsClass NewsClassModel)
        {
            OleDbParameter[] parm = GetPageContentParameters(NewsClassModel);
            string Sql = "insert into " + Pre + "News_Class(";
            Sql += "ClassID,ClassCName,ClassEName,ParentID,IsURL,OrderID,ClassTemplet,SavePath,SiteID,NaviShowtf,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,CreatTime,isPage,isLock,isRecyle,InHitoryDay,ContentPicTF,Checkint,ModelID,isunHTML,DataLib,PageContent";
            Sql += ") values (";
            Sql += "@ClassID,@ClassCName,@ClassEName,@ParentID,@IsURL,@OrderID,@ClassTemplet,@SavePath,@SiteID,@NaviShowtf,@MetaKeywords,@MetaDescript,@isDelPoint,@Gpoint,@iPoint,@GroupNumber,@CreatTime,@isPage,0,0,0,0,0,'0',0,'" + Pre + "news','" + NewsClassModel.PageContent + "')";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm);
        }

        /// <summary>
        /// 获取PageContent构造
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        private OleDbParameter[] GetPageContentParameters(Foosun.Model.NewsClass uc)
        {
            OleDbParameter[] param = new OleDbParameter[18];
            param[0] = new OleDbParameter("@ClassID", OleDbType.VarWChar);
            param[0].Value = uc.ClassID;
            param[1] = new OleDbParameter("@ClassCName", OleDbType.VarWChar);
            param[1].Value = uc.ClassCName;
            param[2] = new OleDbParameter("@ClassEName", OleDbType.VarWChar);
            param[2].Value = uc.ClassEName;
            param[3] = new OleDbParameter("@ParentID", OleDbType.VarWChar);
            param[3].Value = uc.ParentID;
            param[4] = new OleDbParameter("@IsURL", OleDbType.Integer);
            param[4].Value = uc.IsURL;
            param[5] = new OleDbParameter("@OrderID", OleDbType.Integer);
            param[5].Value = uc.OrderID;
            param[6] = new OleDbParameter("@ClassTemplet", OleDbType.VarWChar);
            param[6].Value = uc.ClassTemplet;
            param[7] = new OleDbParameter("@SavePath", OleDbType.VarWChar);
            param[7].Value = uc.SavePath;
            param[8] = new OleDbParameter("@SiteID", OleDbType.VarWChar);
            param[8].Value = uc.SiteID;
            param[9] = new OleDbParameter("@NaviShowtf", OleDbType.Integer);
            param[9].Value = uc.NaviShowtf;
            param[10] = new OleDbParameter("@MetaKeywords", OleDbType.VarWChar);
            param[10].Value = uc.MetaKeywords;
            param[11] = new OleDbParameter("@MetaDescript", OleDbType.VarWChar);
            param[11].Value = uc.MetaDescript;
            param[12] = new OleDbParameter("@isDelPoint", OleDbType.Integer);
            param[12].Value = uc.isDelPoint;
            param[13] = new OleDbParameter("@Gpoint", OleDbType.Integer);
            param[13].Value = uc.Gpoint;
            param[14] = new OleDbParameter("@iPoint", OleDbType.Integer);
            param[14].Value = uc.iPoint;
            param[15] = new OleDbParameter("@GroupNumber", OleDbType.VarWChar);
            param[15].Value = uc.GroupNumber;
            param[16] = new OleDbParameter("@CreatTime", OleDbType.Date);
            param[16].Value = uc.CreatTime.ToString();
            param[17] = new OleDbParameter("@isPage", OleDbType.Integer);
            param[17].Value = uc.isPage;
            return param;
        }

        #endregion  Method
    }
}

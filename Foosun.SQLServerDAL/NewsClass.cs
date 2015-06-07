using System;
using System.Collections.Generic;
using System.Text;
using Foosun.IDAL;
using System.Data.SqlClient;
using System.Data;
using Foosun.DALProfile;
using Foosun.Config;

namespace Foosun.SQLServerDAL
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
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.NVarChar,12)			};
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
            SqlParameter[] parameters = {
					new SqlParameter("@ClassEName", SqlDbType.NVarChar)			};
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
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
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
                SqlParameter Prm = new SqlParameter("@ClassID", classID);
                IDataReader rd = DbHelper.ExecuteReader(cn, CommandType.Text, sql, Prm);
                if (rd.Read())
                {
                    NewsPosition = rd["NewsPosition"].ToString();
                    url = dim + "/" + rd["SavePath"].ToString() + "/" + rd["SaveClassframe"].ToString() + "/" + rd["ClassSaveRule"].ToString();
                    NewsPosition = NewsPosition.Replace("{@ClassURL}", url).Replace("//", "/");
                }
                rd.Close();
                string Usql = "update " + Pre + "news_class set NewsPosition=@NewsPosition where ClassID=@ClassID";
                SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@NewsPosition",NewsPosition),new SqlParameter("@ClassID",classID)
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
            string Sql = "insert into " + Pre + "News_Class(";
            Sql += "ClassID,ClassCName,ClassEName,URLaddress,ParentID,IsURL,OrderID,NaviShowtf,NaviContent,NaviPIC,MetaKeywords,MetaDescript,SiteID,isLock,isRecyle,NaviPosition,Domain,ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,Checkint,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isComm,NewsPosition,Defineworkey,CreatTime,isPage,ModelID,isunHTML,DataLib";
            Sql += ") values (";
            Sql += "@ClassID,@ClassCName,@ClassEName,@URLaddress,@ParentID,@IsURL,@OrderID,@NaviShowtf,@NaviContent,@NaviPIC,@MetaKeywords,@MetaDescript,@SiteID,@isLock,@isRecyle,@NaviPosition,@Domain,@ClassTemplet,@ReadNewsTemplet,@SavePath,@SaveClassframe,@Checkint,@ClassSaveRule,@ClassIndexRule,@NewsSavePath,@NewsFileRule,@PicDirPath,@ContentPicTF,@ContentPICurl,@ContentPicSize,@InHitoryDay,@isDelPoint,@Gpoint,@iPoint,@GroupNumber,@FileName,@isComm,@NewsPosition,@Defineworkey,@CreatTime,0,'0',0,'" + Pre + "News')";
            SqlParameter[] param = new SqlParameter[41];
            param[0] = new SqlParameter("@Defineworkey", SqlDbType.NVarChar, 255);
            param[0].Value = model.Defineworkey;
            param[1] = new SqlParameter("@ClassID", SqlDbType.NVarChar, 12);
            param[1].Value = model.ClassID;
            param[2] = new SqlParameter("@ClassCName", SqlDbType.NVarChar, 50);
            param[2].Value = model.ClassCName;
            param[3] = new SqlParameter("@ClassEName", SqlDbType.NVarChar, 50);
            param[3].Value = model.ClassEName;
            param[4] = new SqlParameter("@ParentID", SqlDbType.NVarChar, 12);
            param[4].Value = model.ParentID;
            param[5] = new SqlParameter("@IsURL", SqlDbType.TinyInt, 1);
            param[5].Value = model.IsURL;
            param[6] = new SqlParameter("@OrderID", SqlDbType.Int, 4);
            param[6].Value = model.OrderID;
            param[7] = new SqlParameter("@URLaddress", SqlDbType.NVarChar, 200);
            param[7].Value = model.URLaddress;
            param[8] = new SqlParameter("@Domain", SqlDbType.NVarChar, 150);
            param[8].Value = model.Domain;
            param[9] = new SqlParameter("@ClassTemplet", SqlDbType.NVarChar, 200);
            param[9].Value = model.ClassTemplet;
            param[10] = new SqlParameter("@ReadNewsTemplet", SqlDbType.NVarChar, 200);
            param[10].Value = model.ReadNewsTemplet;
            param[11] = new SqlParameter("@SavePath", SqlDbType.NVarChar, 50);
            param[11].Value = model.SavePath;
            param[12] = new SqlParameter("@SaveClassframe", SqlDbType.NVarChar, 200);
            param[12].Value = model.SaveClassframe;
            param[13] = new SqlParameter("@Checkint", SqlDbType.TinyInt, 1);
            param[13].Value = model.Checkint;
            param[14] = new SqlParameter("@ClassSaveRule", SqlDbType.NVarChar, 200);
            param[14].Value = model.ClassSaveRule;
            param[15] = new SqlParameter("@ClassIndexRule", SqlDbType.NVarChar, 50);
            param[15].Value = model.ClassIndexRule;
            param[16] = new SqlParameter("@NewsSavePath", SqlDbType.NVarChar, 50);
            param[16].Value = model.NewsSavePath;
            param[17] = new SqlParameter("@NewsFileRule", SqlDbType.NVarChar, 200);
            param[17].Value = model.NewsFileRule;
            param[18] = new SqlParameter("@PicDirPath", SqlDbType.NVarChar, 50);
            param[18].Value = model.PicDirPath;
            param[19] = new SqlParameter("@ContentPicTF", SqlDbType.TinyInt, 1);
            param[19].Value = model.ContentPicTF;
            param[20] = new SqlParameter("@ContentPICurl", SqlDbType.NVarChar, 200);
            param[20].Value = model.ContentPICurl;
            param[21] = new SqlParameter("@ContentPicSize", SqlDbType.NVarChar, 15);
            param[21].Value = model.ContentPicSize;
            param[22] = new SqlParameter("@InHitoryDay", SqlDbType.Int, 4);
            param[22].Value = model.InHitoryDay;
            param[24] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
            param[24].Value = model.SiteID;
            param[25] = new SqlParameter("@NaviShowtf", SqlDbType.TinyInt, 1);
            param[25].Value = model.NaviShowtf;
            param[26] = new SqlParameter("@NaviPIC", SqlDbType.NVarChar, 200);
            param[26].Value = model.NaviPIC;
            param[27] = new SqlParameter("@NaviContent", SqlDbType.NVarChar, 255);
            param[27].Value = model.NaviContent;
            param[28] = new SqlParameter("@MetaKeywords", SqlDbType.NVarChar, 200);
            param[28].Value = model.MetaKeywords;
            param[29] = new SqlParameter("@MetaDescript", SqlDbType.NVarChar, 200);
            param[29].Value = model.MetaDescript;
            param[30] = new SqlParameter("@isDelPoint", SqlDbType.TinyInt, 1);
            param[30].Value = model.isDelPoint;
            param[31] = new SqlParameter("@Gpoint", SqlDbType.Int, 4);
            param[31].Value = model.Gpoint;
            param[32] = new SqlParameter("@iPoint", SqlDbType.Int, 4);
            param[32].Value = model.iPoint;
            param[33] = new SqlParameter("@GroupNumber", SqlDbType.NVarChar, 255);
            param[33].Value = model.GroupNumber;
            param[34] = new SqlParameter("@FileName", SqlDbType.NVarChar, 6);
            param[34].Value = model.FileName;
            param[35] = new SqlParameter("@isLock", SqlDbType.TinyInt, 1);
            param[35].Value = model.isLock;
            param[36] = new SqlParameter("@isRecyle", SqlDbType.TinyInt, 1);
            param[36].Value = model.isRecyle;
            param[37] = new SqlParameter("@NaviPosition", SqlDbType.NText);
            param[37].Value = model.NaviPosition;
            param[38] = new SqlParameter("@NewsPosition", SqlDbType.NText);
            param[38].Value = model.NewsPosition;
            param[39] = new SqlParameter("@isComm", SqlDbType.TinyInt, 1);
            param[39].Value = model.isComm;
            param[40] = new SqlParameter("@CreatTime", SqlDbType.DateTime, 8);
            param[40].Value = model.CreatTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, Sql, param);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.NewsClass model)
        {
            string Sql = "Update " + Pre + "News_Class set ClassCName=@ClassCName,ClassEName=@ClassEName,URLaddress=@URLaddress,ParentID=@ParentID,IsURL=@IsURL,OrderID=@OrderID,NaviShowtf=@NaviShowtf,NaviContent=@NaviContent,NaviPIC=@NaviPIC,MetaKeywords=@MetaKeywords,MetaDescript=@MetaDescript,isLock=@isLock,isRecyle=@isRecyle,NaviPosition=@NaviPosition,Domain=@Domain,ClassTemplet=@ClassTemplet,ReadNewsTemplet=@ReadNewsTemplet,SavePath=@SavePath,SaveClassframe=@SaveClassframe,Checkint=@Checkint,ClassSaveRule=@ClassSaveRule,ClassIndexRule=@ClassIndexRule,NewsSavePath=@NewsSavePath,NewsFileRule=@NewsFileRule,PicDirPath=@PicDirPath,ContentPicTF=@ContentPicTF,ContentPICurl=@ContentPICurl,ContentPicSize=@ContentPicSize,InHitoryDay=@InHitoryDay,isDelPoint=@isDelPoint,Gpoint=@Gpoint,iPoint=@iPoint,GroupNumber=@GroupNumber,FileName=@FileName,isComm=@isComm,NewsPosition=@NewsPosition,Defineworkey=@Defineworkey,isPage=0,ModelID='0' where ClassID='" + model.ClassID.ToString() + "' " + Common.Public.getSessionStr() + "";

            SqlParameter[] param = new SqlParameter[41];
            param[0] = new SqlParameter("@Defineworkey", SqlDbType.NVarChar, 255);
            param[0].Value = model.Defineworkey;
            param[1] = new SqlParameter("@ClassID", SqlDbType.NVarChar, 12);
            param[1].Value = model.ClassID;
            param[2] = new SqlParameter("@ClassCName", SqlDbType.NVarChar, 50);
            param[2].Value = model.ClassCName;
            param[3] = new SqlParameter("@ClassEName", SqlDbType.NVarChar, 50);
            param[3].Value = model.ClassEName;
            param[4] = new SqlParameter("@ParentID", SqlDbType.NVarChar, 12);
            param[4].Value = model.ParentID;
            param[5] = new SqlParameter("@IsURL", SqlDbType.TinyInt, 1);
            param[5].Value = model.IsURL;
            param[6] = new SqlParameter("@OrderID", SqlDbType.Int, 4);
            param[6].Value = model.OrderID;
            param[7] = new SqlParameter("@URLaddress", SqlDbType.NVarChar, 200);
            param[7].Value = model.URLaddress;
            param[8] = new SqlParameter("@Domain", SqlDbType.NVarChar, 150);
            param[8].Value = model.Domain;
            param[9] = new SqlParameter("@ClassTemplet", SqlDbType.NVarChar, 200);
            param[9].Value = model.ClassTemplet;
            param[10] = new SqlParameter("@ReadNewsTemplet", SqlDbType.NVarChar, 200);
            param[10].Value = model.ReadNewsTemplet;
            param[11] = new SqlParameter("@SavePath", SqlDbType.NVarChar, 50);
            param[11].Value = model.SavePath;
            param[12] = new SqlParameter("@SaveClassframe", SqlDbType.NVarChar, 200);
            param[12].Value = model.SaveClassframe;
            param[13] = new SqlParameter("@Checkint", SqlDbType.TinyInt, 1);
            param[13].Value = model.Checkint;
            param[14] = new SqlParameter("@ClassSaveRule", SqlDbType.NVarChar, 200);
            param[14].Value = model.ClassSaveRule;
            param[15] = new SqlParameter("@ClassIndexRule", SqlDbType.NVarChar, 50);
            param[15].Value = model.ClassIndexRule;
            param[16] = new SqlParameter("@NewsSavePath", SqlDbType.NVarChar, 50);
            param[16].Value = model.NewsSavePath;
            param[17] = new SqlParameter("@NewsFileRule", SqlDbType.NVarChar, 200);
            param[17].Value = model.NewsFileRule;
            param[18] = new SqlParameter("@PicDirPath", SqlDbType.NVarChar, 50);
            param[18].Value = model.PicDirPath;
            param[19] = new SqlParameter("@ContentPicTF", SqlDbType.TinyInt, 1);
            param[19].Value = model.ContentPicTF;
            param[20] = new SqlParameter("@ContentPICurl", SqlDbType.NVarChar, 200);
            param[20].Value = model.ContentPICurl;
            param[21] = new SqlParameter("@ContentPicSize", SqlDbType.NVarChar, 15);
            param[21].Value = model.ContentPicSize;
            param[22] = new SqlParameter("@InHitoryDay", SqlDbType.Int, 4);
            param[22].Value = model.InHitoryDay;
            param[24] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
            param[24].Value = model.SiteID;
            param[25] = new SqlParameter("@NaviShowtf", SqlDbType.TinyInt, 1);
            param[25].Value = model.NaviShowtf;
            param[26] = new SqlParameter("@NaviPIC", SqlDbType.NVarChar, 200);
            param[26].Value = model.NaviPIC;
            param[27] = new SqlParameter("@NaviContent", SqlDbType.NVarChar, 255);
            param[27].Value = model.NaviContent;
            param[28] = new SqlParameter("@MetaKeywords", SqlDbType.NVarChar, 200);
            param[28].Value = model.MetaKeywords;
            param[29] = new SqlParameter("@MetaDescript", SqlDbType.NVarChar, 200);
            param[29].Value = model.MetaDescript;
            param[30] = new SqlParameter("@isDelPoint", SqlDbType.TinyInt, 1);
            param[30].Value = model.isDelPoint;
            param[31] = new SqlParameter("@Gpoint", SqlDbType.Int, 4);
            param[31].Value = model.Gpoint;
            param[32] = new SqlParameter("@iPoint", SqlDbType.Int, 4);
            param[32].Value = model.iPoint;
            param[33] = new SqlParameter("@GroupNumber", SqlDbType.NVarChar, 255);
            param[33].Value = model.GroupNumber;
            param[34] = new SqlParameter("@FileName", SqlDbType.NVarChar, 6);
            param[34].Value = model.FileName;
            param[35] = new SqlParameter("@isLock", SqlDbType.TinyInt, 1);
            param[35].Value = model.isLock;
            param[36] = new SqlParameter("@isRecyle", SqlDbType.TinyInt, 1);
            param[36].Value = model.isRecyle;
            param[37] = new SqlParameter("@NaviPosition", SqlDbType.NText);
            param[37].Value = model.NaviPosition;
            param[38] = new SqlParameter("@NewsPosition", SqlDbType.NText);
            param[38].Value = model.NewsPosition;
            param[39] = new SqlParameter("@isComm", SqlDbType.TinyInt, 1);
            param[39].Value = model.isComm;
            param[40] = new SqlParameter("@CreatTime", SqlDbType.DateTime, 8);
            param[40].Value = model.CreatTime;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "news_Class ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
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
            strSql.Append("select  top 1 Id,ClassCName,ClassEName,ParentID,IsURL,OrderID,URLaddress,Domain,ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,Checkint,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,SiteID,NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isLock,isRecyle,NaviPosition,NewsPosition,isComm,Defineworkey,CreatTime,isPage,PageContent,ModelID,isunHTML from " + Pre + "news_Class ");
            strSql.Append(" where ClassID=@ClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.NVarChar,12)
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
            strSql.Append("select ClassID,Id,ClassCName,ClassEName,ParentID,IsURL,OrderID,URLaddress,Domain,ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,Checkint,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,SiteID,NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isLock,isRecyle,NaviPosition,NewsPosition,isComm,Defineworkey,CreatTime,isPage,PageContent,ModelID,isunHTML,ClassId ");
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
            strSql.Append(" Id,ClassID,ClassCName,ClassEName,ParentID,IsURL,OrderID,URLaddress,Domain,ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,Checkint,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,SiteID,NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isLock,isRecyle,NaviPosition,NewsPosition,isComm,Defineworkey,CreatTime,isPage,PageContent,ModelID,isunHTML ");
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
            List<string> sqlArray = new List<string>();
            if (sourceClassId.IndexOf(",") > -1)
            {
                string[] sourceClassIds = sourceClassId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string classId in sourceClassIds)
                {
                    sqlArray.Add("update " + Pre + "news set ClassID='" + targetClassId + "' where ClassID='" + classId + "'");
                    sqlArray.Add("delete from " + Pre + "news_class where ClassID='" + classId + "'");
                }
            }
            else
            {
                sqlArray.Add("update " + Pre + "news set ClassID='" + targetClassId + "' where ClassID='" + sourceClassId + "'");
                sqlArray.Add("delete from " + Pre + "news_class where ClassID='" + sourceClassId + "'");
            }
            return DbHelper.ExecuteSqlTran(sqlArray);
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
            List<string> sqlArray = new List<string>();
            sqlArray.Add("delete from " + Pre + "news where SiteID=" + Foosun.Global.Current.SiteID);
            sqlArray.Add("delete from " + Pre + "news_class where SiteID=" + Foosun.Global.Current.SiteID);
            return DbHelper.ExecuteSqlTran(sqlArray);
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
            List<string> sqlArray = new List<string>();
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray.Add("update " + Pre + "news_class set ClassTemplet='" + classTemplet + "',ReadNewsTemplet='" + readNewTemplet + "' where ClassId='" + id + "' and SiteID=" + Foosun.Global.Current.SiteID);
                }
            }
            else
            {
                sqlArray.Add("update " + Pre + "news_class set ClassTemplet='" + classTemplet + "',ReadNewsTemplet='" + readNewTemplet + "' where ClassId='" + classId + "' and SiteID=" + Foosun.Global.Current.SiteID);
            }
            return DbHelper.ExecuteSqlTran(sqlArray);
        }

        /// <summary>
        /// 锁定/解锁栏目
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int SetLock(string classId)
        {
            List<string> sqlArray = new List<string>();
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray.Add("update " + Pre + "news_class set isLock=(case isLock when 1 then 0 when 0 then 1 end) where ClassId='" + id + "' and SiteID=" + Foosun.Global.Current.SiteID);
                }
            }
            else
            {
                sqlArray.Add("update " + Pre + "news_class set isLock=(case isLock when 1 then 0 when 0 then 1 end) where ClassId='" + classId + "' and SiteID=" + Foosun.Global.Current.SiteID);
            }
            return DbHelper.ExecuteSqlTran(sqlArray);
        }

        /// <summary>
        /// 放入\还原回收站
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        public int SetRecyle(string classId)
        {
            List<string> sqlArray = new List<string>();
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray.Add("update " + Pre + "news_class set isRecyle=(case isRecyle when 1 then 0 when 0 then 1 end) where ClassId='" + id + "' and SiteID=" + Foosun.Global.Current.SiteID);
                }
            }
            else
            {
                sqlArray.Add("update " + Pre + "news_class set isRecyle=(case isRecyle when 1 then 0 when 0 then 1 end) where ClassId='" + classId + "' and SiteID=" + Foosun.Global.Current.SiteID);
            }
            return DbHelper.ExecuteSqlTran(sqlArray);
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
            List<string> sqlArray = new List<string>();
            if (classId.IndexOf(",") > -1)
            {
                string[] classIds = classId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in classIds)
                {
                    sqlArray.Add("delete from " + Pre + "news where ClassId='" + id + "' and SiteID=" + Foosun.Global.Current.SiteID);
                }
            }
            else
            {
                sqlArray.Add("delete from " + Pre + "news where ClassId='" + classId + "' and SiteID=" + Foosun.Global.Current.SiteID);
            }
            return DbHelper.ExecuteSqlTran(sqlArray);
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
            SqlParameter Param = new SqlParameter("@ClassID", ClassID);
            return DbHelper.ExecuteReader(CommandType.Text, Sql, Param);
        }

        /// <summary>
        /// 得到栏目信息
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public DataTable GetClassContent(string classID)
        {
            string Sql = "Select ClassID,ClassCName,ClassEName,ParentID,IsURL,Checkint,OrderID,Urladdress,Domain,ClassTemplet,ReadNewsTemplet,SavePath,SaveClassframe,ClassSaveRule,ClassIndexRule,NewsSavePath,NewsFileRule,PicDirPath,ContentPicTF,ContentPICurl,ContentPicSize,InHitoryDay,DataLib,SiteID,NaviShowtf,NaviPIC,NaviContent,MetaKeywords,MetaDescript,isDelPoint,Gpoint,iPoint,GroupNumber,FileName,isComm,NaviPosition,NewsPosition,Defineworkey From " + Pre + "news_class where ClassID='" + classID + "' " + Common.Public.getSessionStr() + "";
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
            SqlParameter Param = new SqlParameter("@ClassID", ClassID);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, Param));
        }
        /// <summary>
        /// 通用获取栏目的内容
        /// </summary>
        /// <param name="field">要获取的字段名，多个字段用，隔开</param>
        /// <param name="where">查询的条件</param>
        /// <returns></returns>
        public DataTable GetContent(string field, string where,string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+field);
            strSql.Append(" FROM " + Pre + "news_Class ");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            if (order.Trim()!="")
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
            SqlParameter param = null;
            if (siteId == null || siteId == string.Empty)
            {
                where = "";
            }
            else
            {
                where = "  where isRecyle<>1 and ParentID='0' and SiteId=@SiteId";
                param = new SqlParameter("@SiteId", siteId);
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
            SqlParameter param = new SqlParameter("@ParentId", SqlDbType.NVarChar, 12);
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
            SqlParameter Param = new SqlParameter("@ClassID", classID);
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
            SqlParameter param = new SqlParameter("@ClassID", classId);
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
            string Sql = "Update " + Pre + "News_Class set ClassCName=@ClassCName,ParentID=@ParentID,IsURL=@IsURL,OrderID=@OrderID,NaviShowtf=@NaviShowtf,MetaKeywords=@MetaKeywords,MetaDescript=@MetaDescript,ClassTemplet=@ClassTemplet,SavePath=@SavePath,isDelPoint=@isDelPoint,Gpoint=@Gpoint,iPoint=@iPoint,GroupNumber=@GroupNumber,isPage=@isPage,PageContent=@Content,InHitoryDay=0,ContentPicTF=0,Checkint=0,ModelID='0' where ClassID='" + NewsClassModel.ClassID + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";

            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@ClassID", SqlDbType.NVarChar, 12);
            param[0].Value = NewsClassModel.ClassID;
            param[1] = new SqlParameter("@ClassCName", SqlDbType.NVarChar, 50);
            param[1].Value = NewsClassModel.ClassCName;
            param[2] = new SqlParameter("@ClassEName", SqlDbType.NVarChar, 50);
            param[2].Value = NewsClassModel.ClassEName;
            param[3] = new SqlParameter("@ParentID", SqlDbType.NVarChar, 12);
            param[3].Value = NewsClassModel.ParentID;
            param[4] = new SqlParameter("@IsURL", SqlDbType.TinyInt, 1);
            param[4].Value = NewsClassModel.IsURL;
            param[5] = new SqlParameter("@OrderID", SqlDbType.Int, 4);
            param[5].Value = NewsClassModel.OrderID;
            param[6] = new SqlParameter("@Content", SqlDbType.NText);
            param[6].Value = NewsClassModel.PageContent;
            param[7] = new SqlParameter("@ClassTemplet", SqlDbType.NVarChar, 200);
            param[7].Value = NewsClassModel.ClassTemplet;
            param[8] = new SqlParameter("@SavePath", SqlDbType.NVarChar, 50);
            param[8].Value = NewsClassModel.SavePath;
            param[9] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
            param[9].Value = NewsClassModel.SiteID;
            param[10] = new SqlParameter("@NaviShowtf", SqlDbType.TinyInt, 1);
            param[10].Value = NewsClassModel.NaviShowtf;
            param[11] = new SqlParameter("@MetaKeywords", SqlDbType.NVarChar, 200);
            param[11].Value = NewsClassModel.MetaKeywords;
            param[12] = new SqlParameter("@MetaDescript", SqlDbType.NVarChar, 200);
            param[12].Value = NewsClassModel.MetaDescript;
            param[13] = new SqlParameter("@isDelPoint", SqlDbType.TinyInt, 1);
            param[13].Value = NewsClassModel.isDelPoint;
            param[14] = new SqlParameter("@Gpoint", SqlDbType.Int, 4);
            param[14].Value = NewsClassModel.Gpoint;
            param[15] = new SqlParameter("@iPoint", SqlDbType.Int, 4);
            param[15].Value = NewsClassModel.iPoint;
            param[16] = new SqlParameter("@GroupNumber", SqlDbType.NVarChar, 250);
            param[16].Value = NewsClassModel.GroupNumber;
            param[17] = new SqlParameter("@CreatTime", SqlDbType.DateTime, 8);
            param[17].Value = NewsClassModel.CreatTime;
            param[18] = new SqlParameter("@isPage", SqlDbType.TinyInt, 1);
            param[18].Value = NewsClassModel.isPage;
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param);
        }

        /// <summary>
        /// 添加单页面
        /// </summary>
        /// <param name="NewsClassModel"></param>
        public void InsertPage(Foosun.Model.NewsClass NewsClassModel)
        {
            string Sql = "insert into " + Pre + "News_Class(";
            Sql += "ClassID,ClassCName,ClassEName,ParentID,IsURL,OrderID,NaviShowtf,MetaKeywords,MetaDescript,SiteID,isLock,isRecyle,ClassTemplet,SavePath,isDelPoint,Gpoint,iPoint,GroupNumber,CreatTime,isPage,PageContent,InHitoryDay,ContentPicTF,Checkint,ModelID,isunHTML,DataLib";
            Sql += ") values (";
            Sql += "@ClassID,@ClassCName,@ClassEName,@ParentID,@IsURL,@OrderID,@NaviShowtf,@MetaKeywords,@MetaDescript,@SiteID,0,0,@ClassTemplet,@SavePath,@isDelPoint,@Gpoint,@iPoint,@GroupNumber,@CreatTime,@isPage,@Content,0,0,0,'0',0,'" + Pre + "news')";
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@ClassID", SqlDbType.NVarChar, 12);
            param[0].Value = NewsClassModel.ClassID;
            param[1] = new SqlParameter("@ClassCName", SqlDbType.NVarChar, 50);
            param[1].Value = NewsClassModel.ClassCName;
            param[2] = new SqlParameter("@ClassEName", SqlDbType.NVarChar, 50);
            param[2].Value = NewsClassModel.ClassEName;
            param[3] = new SqlParameter("@ParentID", SqlDbType.NVarChar, 12);
            param[3].Value = NewsClassModel.ParentID;
            param[4] = new SqlParameter("@IsURL", SqlDbType.TinyInt, 1);
            param[4].Value = NewsClassModel.IsURL;
            param[5] = new SqlParameter("@OrderID", SqlDbType.Int, 4);
            param[5].Value = NewsClassModel.OrderID;
            param[6] = new SqlParameter("@Content", SqlDbType.NText);
            param[6].Value = NewsClassModel.PageContent;
            param[7] = new SqlParameter("@ClassTemplet", SqlDbType.NVarChar, 200);
            param[7].Value = NewsClassModel.ClassTemplet;
            param[8] = new SqlParameter("@SavePath", SqlDbType.NVarChar, 50);
            param[8].Value = NewsClassModel.SavePath;
            param[9] = new SqlParameter("@SiteID", SqlDbType.NVarChar, 12);
            param[9].Value = NewsClassModel.SiteID;
            param[10] = new SqlParameter("@NaviShowtf", SqlDbType.TinyInt, 1);
            param[10].Value = NewsClassModel.NaviShowtf;
            param[11] = new SqlParameter("@MetaKeywords", SqlDbType.NVarChar, 200);
            param[11].Value = NewsClassModel.MetaKeywords;
            param[12] = new SqlParameter("@MetaDescript", SqlDbType.NVarChar, 200);
            param[12].Value = NewsClassModel.MetaDescript;
            param[13] = new SqlParameter("@isDelPoint", SqlDbType.TinyInt, 1);
            param[13].Value = NewsClassModel.isDelPoint;
            param[14] = new SqlParameter("@Gpoint", SqlDbType.Int, 4);
            param[14].Value = NewsClassModel.Gpoint;
            param[15] = new SqlParameter("@iPoint", SqlDbType.Int, 4);
            param[15].Value = NewsClassModel.iPoint;
            param[16] = new SqlParameter("@GroupNumber", SqlDbType.NVarChar, 250);
            param[16].Value = NewsClassModel.GroupNumber;
            param[17] = new SqlParameter("@CreatTime", SqlDbType.DateTime, 8);
            param[17].Value = NewsClassModel.CreatTime;
            param[18] = new SqlParameter("@isPage", SqlDbType.TinyInt, 1);
            param[18].Value = NewsClassModel.isPage;
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param);
        }
        #endregion  Method
    }
}

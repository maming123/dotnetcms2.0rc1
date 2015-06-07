using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Foosun.DALProfile;
using Foosun.Config;
using Foosun.IDAL;

namespace Foosun.SQLServerDAL
{
    public class Search : DbBase, ISearch
    {
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页显示多少条</param>
        /// <param name="RecordCount">记录总数</param>
        /// <param name="PageCount">页数</param>
        /// <param name="si">实体类</param>
        /// <returns>返回数据表</returns>
        public DataTable SearchGetPage(string DTable,int PageIndex, int PageSize, out int RecordCount, out int PageCount, Foosun.Model.Search si)
        {
            string allFields = "*";
            string tablesAndWhere = " " + Pre + "News Where isLock=0 And isRecyle=0";
            if (DTable != string.Empty)
            {
                tablesAndWhere = " " + DTable + " Where isLock=0";
            }
            string indexField = "ID";
            string orderField = "Order By ID Desc";

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Key", SqlDbType.NVarChar, 100);
            if (si.tags != null && si.tags != "")
            {
                param[0].Value = "%" + si.tags + "%";
                if (si.type == "tag")
                {
                    tablesAndWhere += " And Tags Like CONVERT(Nvarchar(100), @Key)";
                }
                else if (si.type == "edit")
                {
                    tablesAndWhere += " And editor Like CONVERT(Nvarchar(18), @Key)";
                }
                else if (si.type == "author")
                {
                    tablesAndWhere += " And author Like CONVERT(Nvarchar(100), @Key)";
                }
                else
                {
                    if (DTable != string.Empty)
                    {
                        tablesAndWhere += " And ((Title Like CONVERT(Nvarchar(100), @Key)) Or (Author Like CONVERT(Nvarchar(100), @Key)) Or (Souce Like CONVERT(Nvarchar(100), @Key)) Or (Tags Like CONVERT(Nvarchar(100), @Key)) Or (Content Like CONVERT(Nvarchar(100), @Key)))";
                    }
                    else
                    {
                        tablesAndWhere += " And ((NewsTitle Like CONVERT(Nvarchar(100), @Key)) Or (sNewsTitle Like CONVERT(Nvarchar(100), @Key)) Or (Author Like CONVERT(Nvarchar(100), @Key)) Or (Souce Like CONVERT(Nvarchar(100), @Key)) Or (Tags Like CONVERT(Nvarchar(100), @Key)) Or (Content Like CONVERT(Nvarchar(100), @Key)))";
                    }
                }
            }
            else
            {
                param[0].Value = "";
            }

            param[1] = new SqlParameter("@Pdate", SqlDbType.Int, 4);
            if (si.date != null && si.date != "" && si.date != "0")
            {
                param[1].Value = int.Parse(si.date);
                tablesAndWhere += " And DateDiff(Day,CreatTime ,getdate())<@Pdate";
            }
            else
            {
                param[1].Value = 0;
            }

            param[2] = new SqlParameter("@classid", SqlDbType.NVarChar, 12);
            if (si.classid != null && si.classid != "")
            {
                param[2].Value = si.classid;
                tablesAndWhere += " And ClassID=@classid";
            }
            else
            {
                param[2].Value = "";
            }

            return DbHelper.ExecutePage(allFields, tablesAndWhere, indexField, orderField, PageIndex, PageSize, out RecordCount, out PageCount, param);
        }

        /// <summary>
        /// 取得栏目参数中的新闻保存路径
        /// </summary>
        /// <param name="ClassID">栏目编号</param>
        /// <returns>返回新闻保存路径</returns>
        public string GetSaveClassframe(string ClassID)
        {
            string path = "";
            SqlParameter param = new SqlParameter("@ClassID", ClassID);
            string Sql = "Select SaveClassframe,SavePath From " + Pre + "news_Class Where ClassID=@ClassID";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, Sql, param);
            if (dr.Read())
            {
                path = dr.GetString(1) + "/" + dr.GetString(0);

            }
            dr.Close(); 
            dr.Dispose();
            return path;
        }

        /// <summary>
        /// 得到浏览新闻的参数
        /// </summary>
        /// <param name="NewsID"></param>
        /// 
        /// <returns></returns>
        public string GetNewsReview(string ID, string gType)
        {
            string newspath = string.Empty;
            string newspath1 = string.Empty;
            string sql = string.Empty;
            string dim = Foosun.Config.UIConfig.dirDumm.Trim();
            string ReadType = Common.Public.readparamConfig("ReviewType");
            if (dim != string.Empty) { dim = "/" + dim; }
            SqlParameter param = new SqlParameter("@ID", ID);
            if (gType != "special")
            {
                if (gType == "class")
                {
                    sql = "select IsURL,URLaddress,SavePath,SaveClassframe,ClassSaveRule,isDelPoint,ClassID,isPage from " + Pre + "news_class where ClassID=@ID";
                    IDataReader dt = DbHelper.ExecuteReader(CommandType.Text, sql, param);
                    while (dt.Read())
                    {
                        if (dt["isURL"].ToString() == "1")
                        {
                            if (dt["URLaddress"].ToString().IndexOf("http://") > -1)
                            {
                                newspath = dt["URLaddress"].ToString();
                            }
                            else
                            {
                                newspath = "http://" + dt["URLaddress"].ToString();
                            }
                        }
                        else
                        {
                            if (dt["isDelPoint"].ToString() != "0")
                            {
                                newspath1 = dim + "/list-" + dt["ClassID"].ToString() + ".aspx";
                            }
                            else
                            {
                                if (ReadType == "1")
                                {
                                    if (dt["isPage"].ToString() == "1")
                                    {
                                        newspath1 = dim + "/page-" + dt["ClassID"].ToString() + ".aspx";
                                    }
                                    else
                                    {
                                        newspath1 = dim + "/list-" + dt["ClassID"].ToString() + ".aspx";
                                    }
                                }
                                else
                                {
                                    if (dt["isPage"].ToString() == "1")
                                    {
                                        newspath1 = dim + "/" + dt["SavePath"].ToString();
                                    }
                                    else
                                    {
                                        newspath1 = dim + "/" + dt["SavePath"].ToString() + "/" + dt["SaveClassframe"].ToString() + "/" + dt["ClassSaveRule"].ToString();
                                    }
                                }
                            }
                            newspath = newspath1.Replace("//", "/").Replace(@"\\", @"\").Replace("//", "/");
                        }
                    }
                    dt.Close();
                }
                else
                {
                    sql = "select a.newsid,a.URLaddress,a.NewsType,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.isDelPoint from " + Pre + "news a," + Pre + "news_class b where a.classid=b.classid and a.NewsID=@ID";
                    IDataReader dt = DbHelper.ExecuteReader(CommandType.Text, sql, param);
                    while (dt.Read())
                    {
                        if (dt["NewsType"].ToString() != "2")
                        {
                            if (dt["isDelPoint"].ToString() != "0")
                            {
                                newspath1 = dim + "/content.aspx?id=" + dt["NewsID"].ToString() + "";
                            }
                            else
                            {
                                if (ReadType == "1")
                                {
                                    newspath1 = dim + "/content.aspx?id=" + dt["NewsID"].ToString() + "";
                                }
                                else
                                {
                                    newspath1 = dim + "/" + dt["SavePath1"].ToString() + "/" + dt["SaveClassframe"].ToString() + "/" + dt["SavePath"].ToString() + "/" + dt["FileName"].ToString() + dt["FileEXName"].ToString();
                                }
                            }
                            newspath = newspath1.Replace("//", "/").Replace(@"\\", @"\");
                        }
                        else
                        {
                            if (dt["URLaddress"].ToString().IndexOf("http://") > -1)
                            {
                                newspath = dt["URLaddress"].ToString();
                            }
                            else
                            {
                                newspath = "http://" + dt["URLaddress"].ToString();
                            }
                        }
                    }
                    dt.Close();
                }

            }
            else
            {
                //专题地址
                sql = "select SpecialID,SavePath,saveDirPath,FileName,FileEXName,isDelPoint from " + Pre + "news_special where SpecialID=@ID";
                IDataReader dt = DbHelper.ExecuteReader(CommandType.Text, sql, param);
                while (dt.Read())
                {
                    if (dt["isDelPoint"].ToString() != "0")
                    {
                        newspath1 = dim + "/special-" + dt["SpecialID"].ToString() + ".aspx";
                    }
                    else
                    {
                        if (ReadType == "1")
                        {
                            newspath1 = dim + "/special-" + dt["SpecialID"].ToString() + ".aspx";
                        }
                        else
                        {
                            newspath1 = dim + "/" + dt["SavePath"].ToString() + "/" + dt["saveDirPath"].ToString() + "/" + dt["FileName"].ToString() + dt["FileEXName"].ToString();
                        }
                    }
                    newspath = newspath1.Replace("//", "/").Replace(@"\\", @"\");
                }
                dt.Close();
            }
            return newspath;
        }
    }
}

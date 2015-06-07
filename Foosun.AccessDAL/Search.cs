using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Foosun.DALProfile;
using Foosun.Config;
using Foosun.IDAL;

namespace Foosun.AccessDAL
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

            if (si.tags != null && si.tags != "")
            {
                string key = "'%" + si.tags + "%'";
                if (si.type == "tag")
                {
                    tablesAndWhere += " And Tags Like "+key+"";
                }
                else if (si.type == "edit")
                {
                    tablesAndWhere += " And editor Like "+key+"";
                }
                else if (si.type == "author")
                {
                    tablesAndWhere += " And author Like "+key+"";
                }
                else
                {
                    if (DTable != string.Empty)
                    {
                        tablesAndWhere += " And ((Title Like "+key+") Or (Author Like "+key+") Or (Souce Like "+key+") Or (Tags Like "+key+") Or (Content Like "+key+"))";
                    }
                    else
                    {
                        tablesAndWhere += " And ((NewsTitle Like "+key+") Or (sNewsTitle Like "+key+") Or (Author Like "+key+") Or (Souce Like "+key+") Or (Tags Like "+key+") Or (Content Like "+key+"))";
                    }
                }
            }


            if (si.date != null && si.date != "" && si.date != "0")
            {
                tablesAndWhere += " And DateDiff('d',CreatTime ,Now())<#"+si.date+"#";
            }


            if (si.classid != null && si.classid != "")
            {
                tablesAndWhere += " And ClassID='" + si.classid + "'";
            }


            return DbHelper.ExecutePage(allFields, tablesAndWhere, indexField, orderField, PageIndex, PageSize, out RecordCount, out PageCount, null);
        }

        /// <summary>
        /// 取得栏目参数中的新闻保存路径
        /// </summary>
        /// <param name="ClassID">栏目编号</param>
        /// <returns>返回新闻保存路径</returns>
        public string GetSaveClassframe(string ClassID)
        {
            string path = "";
            OleDbParameter param = new OleDbParameter("@ClassID", ClassID);
            string Sql = "Select SaveClassframe,SavePath From " + Pre + "news_Class Where ClassID=@ClassID";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, Sql, param);
            if (dr.Read())
            {
                path = dr.GetString(1) + "/" + dr.GetString(0);

            }
            dr.Close(); dr.Dispose();
            return path;
        }

        public string GetNewsReview(string ID, string gType)
        {
            string newspath = string.Empty;
            string newspath1 = string.Empty;
            string sql = string.Empty;
            string dim = Foosun.Config.UIConfig.dirDumm.Trim();
            string ReadType = Common.Public.readparamConfig("ReviewType");
            if (dim != string.Empty) { dim = "/" + dim; }
            OleDbParameter param = new OleDbParameter("@ID", ID);
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
                            newspath = newspath1.Replace("//", "/").Replace(@"\\", @"\");
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

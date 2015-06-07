using System;
using System.Collections.Generic;
using System.Text;
using Foosun.IDAL;
using Foosun.DALProfile;
using System.Data;

namespace Foosun.SQLServerDAL
{
    public class DropTemplet : DbBase, IDropTemplet
    {
        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="templet"></param>
        /// <returns></returns>
        public int AddTemplet(string classId, string templet, string readNewsTemplet, string type)
        {
            string Sql = "insert into " + Pre + "classdroptemplet(ClassId,Templet,ReadNewsTemplet) values ('" + classId + "','"
                + templet + "','" + readNewsTemplet + "')";//默认为栏目
            if (type == "2")//专题
            {
                Sql = "insert into " + Pre + "specialdroptemplet (SpecialId,Templet) values ('" + classId + "','"
                    + templet + "')";
            }
            else if (type == "3")//新闻
            {
                Sql = "insert into " + Pre + "newsdroptemplet (NewsId,Templet) values ('" + classId + "','"
                    + templet + "')";
            }
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 删除模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="templet"></param>
        /// <returns></returns>
        public int DeleteTemplet(string classId, string type)
        {
            string Sql = "delete from " + Pre + "classdroptemplet where ClassId='" + classId + "'";
            if (type == "2")
            {
                Sql = "delete from " + Pre + "specialdroptemplet where SpecialId='" + classId + "'";
            }
            else if (type == "3")
            {
                Sql = "delete from " + Pre + "newsdroptemplet where NewsId='" + classId + "'";
            }
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 获取新闻模版
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public string GetNewsTemplet(string newsId)
        {
            string Sql = "select Templet from " + Pre + "newsdroptemplet where NewsId='" + newsId + "'";
            string result = "";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            if (dr.Read())
            {
                result = dr[0].ToString();
            }
            dr.Close();
            return result;
        }

        /// <summary>
        /// 获取栏目下的新闻模版
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetReadNewsTemplet(string classId)
        {
            string Sql = "select ReadNewsTemplet from " + Pre + "classdroptemplet where ClassId='" + classId + "'";
            string result = "";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            if (dr.Read())
            {
                result = dr[0].ToString();
            }
            dr.Close();
            return result;
        }

        /// <summary>
        /// 修改模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="tmeplet"></param>
        /// <param name="readNewsTemplet"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateTemplet(string classId, string templet, string readNewsTemplet, string type)
        {
            string Sql = "update " + Pre + "classdroptemplet set Templet='" + templet + "',ReadNewsTemplet='"
                + readNewsTemplet + "' where ClassId='" + classId + "'";
            if (type == "2")
            {
                Sql = "update " + Pre + "specialdroptemplet set Templet='" + templet + "' where SpecialId='" + classId + "'";
            }
            else if (type == "3")
            {
                Sql = "update " + Pre + "newsdroptemplet set Templet='" + templet + "' where NewsId='" + classId + "'";
            }
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 修改新闻模版
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="templet"></param>
        public void UpdateNewsTemplet(string classID, string templet)
        {
            string sql = "select NewsID from " + Pre + "news where ClassID in (" + classID + ")";
            DataTable dtNews = DbHelper.ExecuteTable(CommandType.Text, sql, null);
            if (dtNews != null)
            {
                foreach (DataRow dr in dtNews.Rows)
                {
                    if (ExeistsNewsID(dr["NewsID"].ToString(), "3"))
                    {
                        UpdateTemplet(dr["NewsID"].ToString(), templet, "", "3");
                    }
                    else
                    {
                        AddTemplet(dr["NewsID"].ToString(), templet, "", "3");
                    }
                }
            }
        }

        /// <summary>
        /// 修改栏目模版
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="templet"></param>
        /// <param name="readNewsTemplet"></param>
        public void UpdateClassTemplet(string classID, string templet, string readNewsTemplet)
        {
            if (ExeistsNewsID(classID, "1"))
            {
                UpdateTemplet(classID, templet, readNewsTemplet, "1");
            }
            else
            {
                AddTemplet(classID, templet, readNewsTemplet, "1");
            }
        }

        private bool ExeistsNewsID(string newsID, string type)
        {
            string sql = "select count(ID) from " + Pre + "newsdroptemplet where NewsID='" + newsID + "'";
            if (type == "1")
            {
                sql = "select count(ID) from " + Pre + "classdroptemplet where ClassID='" + newsID + "'";
            }
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, sql, null);
            int row = 0;
            if (dr.Read())
            {
                row = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            if (row == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取栏目模版
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetClassTemplet(string classId)
        {
            string Sql = "select Templet from " + Pre + "classdroptemplet where ClassId='" + classId + "'";
            string result = "";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            if (dr.Read())
            {
                result = dr[0].ToString();
            }
            dr.Close();
            return result;
        }

        /// <summary>
        /// 获取专题模版 
        /// </summary>
        /// <param name="specialId"></param>
        /// <returns></returns>
        public string GetSpecialTemplet(string specialId)
        {
            string Sql = "select Templet from " + Pre + "specialdroptemplet where SpecialId='" + specialId + "'";
            string result = "";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, Sql, null);
            if (dr.Read())
            {
                result = dr[0].ToString();
            }
            dr.Close();
            return result;
        }
    }
}

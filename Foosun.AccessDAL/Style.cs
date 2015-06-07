using System;
using System.Collections.Generic;
using System.Data;
using Foosun.Model;
using Foosun.IDAL;
using Foosun.DALProfile;
using Foosun.Config;
using System.Data.OleDb;

namespace Foosun.AccessDAL
{
    public class Style : DbBase, IStyle
    {
        private string SiteID;
        public Style()
        {
            SiteID = Foosun.Global.Current.SiteID;
        }
        public int SytleClassAdd(Foosun.Model.StyleClassInfo sc)
        {
            int result = 0;

            OleDbConnection Conn = new OleDbConnection(DBConfig.CmsConString);
            Conn.Open();
            try
            {
                string checkSql = "";
                int recordCount = 0;
                string ClassID = Common.Rand.Number(12);
                while (true)
                {
                    checkSql = "select count(*) from " + Pre + "sys_styleclass where ClassID='" + ClassID + "'";
                    recordCount = (int)DbHelper.ExecuteScalar(Conn, CommandType.Text, checkSql, null);
                    if (recordCount < 1)
                        break;
                    else
                        ClassID = Common.Rand.Number(12, true);
                }
                checkSql = "select count(*) from " + Pre + "sys_styleclass where Sname='" + sc.Sname + "'";
                recordCount = (int)DbHelper.ExecuteScalar(Conn, CommandType.Text, checkSql, null);
                if (recordCount > 0)
                {
                    throw new Exception("样式分类名称重复,如果不存在，回收站中也可能存在此样式分类!");
                }
                string Sql = "insert into " + Pre + "sys_styleclass (";
                Sql += "ClassID,Sname,CreatTime,SiteID,isRecyle";
                Sql += ") values ('" + ClassID + "',";
                Sql += "@Sname,@CreatTime,'" + SiteID + "',@isRecyle)";
                OleDbParameter[] param = GetstyleClassParameters(sc);
                result = Convert.ToInt32(DbHelper.ExecuteNonQuery(Conn, CommandType.Text, Sql, param));
            }
            finally
            {
                if (Conn != null && Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return result;
        }

        public int StyleNametf(string CName)
        {
            string checkSql = "select count(*) from " + Pre + "sys_LabelStyle Where StyleName='" + CName + "' and isRecyle=0";
            int recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, checkSql, null);
            return recordCount;
        }
        public int StyleClassEdit(Foosun.Model.StyleClassInfo sc)
        {
            int result = 0;
            OleDbConnection Conn = new OleDbConnection(DBConfig.CmsConString);
            Conn.Open();
            try
            {
                string checkSql = "";
                int recordCount = 0;
                checkSql = "select count(*) from " + Pre + "sys_styleclass Where ClassID<>'" + sc.ClassID + "' And Sname='" + sc.Sname + "' and isRecyle=0";
                recordCount = (int)DbHelper.ExecuteScalar(Conn, CommandType.Text, checkSql, null);
                if (recordCount > 0)
                {
                    throw new Exception("样式分类名称重复!");
                }
                string Sql = "Update " + Pre + "sys_styleclass Set Sname='" + sc.Sname + "'";
                Sql += " Where ClassID='" + sc.ClassID + "'";
                OleDbParameter[] param = GetstyleClassParameters(sc);
                result = Convert.ToInt32(DbHelper.ExecuteNonQuery(Conn, CommandType.Text, Sql, param));
            }
            finally
            {
                if (Conn != null && Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return result;
        }
        public void StyleClassDel(string id)
        {
            OleDbConnection Conn = new OleDbConnection(DBConfig.CmsConString);
            Conn.Open();
            OleDbTransaction tran = Conn.BeginTransaction();
            try
            {
                string str_style = "Delete From " + Pre + "sys_styleclass Where ClassID='" + id + "' And SiteID='" + SiteID + "'";
                DbHelper.ExecuteNonQuery(tran, CommandType.Text, str_style, null);
                string str_styleClass = "Delete From " + Pre + "sys_LabelStyle Where ClassID='" + id + "' And SiteID='" + SiteID + "'";
                DbHelper.ExecuteNonQuery(tran, CommandType.Text, str_styleClass, null);
                tran.Commit();
                Conn.Close();
            }
            catch (OleDbException e)
            {
                tran.Rollback();
                Conn.Close();
                throw e;
            }
        }
        public void StyleClassRDel(string id)
        {
            OleDbConnection Conn = new OleDbConnection(DBConfig.CmsConString);
            Conn.Open();
            OleDbTransaction tran = Conn.BeginTransaction();
            try
            {
                string str_style = "Update " + Pre + "sys_LabelStyle Set isRecyle=1 Where ClassID='" + id + "' And SiteID='" + SiteID + "'";
                DbHelper.ExecuteNonQuery(tran, CommandType.Text, str_style, null);
                string str_styleClass = "Update " + Pre + "sys_styleclass Set isRecyle=1 Where ClassID='" + id + "' And SiteID='" + SiteID + "'";
                DbHelper.ExecuteNonQuery(tran, CommandType.Text, str_styleClass, null);
                tran.Commit();
                Conn.Close();
            }
            catch (OleDbException e)
            {
                tran.Rollback();
                Conn.Close();
                throw e;
            }
        }
        public int StyleAdd(Foosun.Model.StyleInfo sc)
        {
            int result = 0;
            OleDbConnection Conn = new OleDbConnection(DBConfig.CmsConString);
            Conn.Open();
            try
            {
                string checkSql = "";
                int recordCount = 0;
                string styleID = Common.Rand.Number(12);
                while (true)
                {
                    checkSql = "select count(*) from " + Pre + "sys_LabelStyle where styleID='" + styleID + "'";
                    recordCount = (int)DbHelper.ExecuteScalar(Conn, CommandType.Text, checkSql, null);
                    if (recordCount < 1)
                        break;
                    else
                        styleID = Common.Rand.Number(12, true);
                }
                checkSql = "select count(*) from " + Pre + "sys_LabelStyle where StyleName='" + sc.StyleName + "' and isRecyle=0";
                recordCount = (int)DbHelper.ExecuteScalar(Conn, CommandType.Text, checkSql, null);
                if (recordCount > 0)
                {
                    throw new Exception("样式名称重复!");
                }
                string Sql = "insert into " + Pre + "sys_LabelStyle (";
                Sql += "styleID,ClassID,StyleName,Content,Description,CreatTime,isRecyle,SiteID";
                Sql += ") values ('" + styleID + "',";
                Sql += "@ClassID,@StyleName,@Content,@Description,@CreatTime,@isRecyle,'" + SiteID + "')";
                OleDbParameter[] param = GetstyleParameters(sc);
                result = Convert.ToInt32(DbHelper.ExecuteNonQuery(Conn, CommandType.Text, Sql, param));
            }
            finally
            {
                if (Conn != null && Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return result;
        }
        public int StyleEdit(Foosun.Model.StyleInfo sc)
        {
            int result = 0;
            OleDbConnection Conn = new OleDbConnection(DBConfig.CmsConString);
            Conn.Open();
            try
            {
                string checkSql = "";
                int recordCount = 0;
                checkSql = "select count(*) from " + Pre + "sys_LabelStyle Where styleID<>'" + sc.styleID + "' And styleName='" + sc.StyleName + "'";
                recordCount = (int)DbHelper.ExecuteScalar(Conn, CommandType.Text, checkSql, null);
                if (recordCount > 0)
                {
                    throw new Exception("样式名称重复,请重新修改!");
                }
                string Sql = "Update " + Pre + "sys_LabelStyle Set ClassID=@ClassID,StyleName=@StyleName,Content=@Content,Description=@Description";
                Sql += " Where styleID='" + sc.styleID + "'";
                OleDbParameter[] param = GetstyleParameters(sc);
                result = Convert.ToInt32(DbHelper.ExecuteNonQuery(Conn, CommandType.Text, Sql, param));
            }
            finally
            {
                if (Conn != null && Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return result;
        }
        public void StyleDel(string id)
        {
            OleDbParameter param = new OleDbParameter("@id", id);
            string str_sql = "Delete From " + Pre + "sys_LabelStyle Where styleID=@id And SiteID='" + SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, param);
        }
        public void StyleRdel(string id)
        {
            OleDbParameter param = new OleDbParameter("@id", id);
            string str_sql = "Update " + Pre + "sys_LabelStyle Set isRecyle=1 Where ID=@id And SiteID='" + SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, param);
        }
        public DataTable GetstyleClassInfo(string id)
        {
            string str_Sql = "Select Sname From " + Pre + "sys_styleclass Where ClassID='" + id + "' And SiteID='" + SiteID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            return dt;
        }
        public DataTable GetstyleInfo(string id)
        {
            string str_Sql = "Select ClassID,StyleName,Content,Description From " + Pre + "sys_LabelStyle Where SiteID='" + SiteID + "' And styleID='" + id + "' order by id desc";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            return dt;
        }
        public DataTable GetLabelStyle()
        {
            string str_Sql = "Select StyleId,ClassID,StyleName,Content,Description From " + Pre + "sys_LabelStyle Where SiteID='" + SiteID + "' and isRecyle=0";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            return dt;
        }
        public DataTable Styledefine()
        {
            string str_Sql = "Select defineCname,defineColumns From " + Pre + "define_data Where SiteID='" + SiteID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            return dt;
        }
        public DataTable StyleClassList()
        {
            string str_Sql = "Select ClassID,Sname From " + Pre + "sys_styleclass Where SiteID='" + SiteID + "' And isRecyle=0 order by  id desc";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            return dt;
        }

        private OleDbParameter[] GetstyleParameters(Foosun.Model.StyleInfo sc)
        {
            OleDbParameter[] param = new OleDbParameter[6];
            param[0] = new OleDbParameter("@ClassID", OleDbType.VarChar, 12);
            param[0].Value = sc.ClassID;
            param[1] = new OleDbParameter("@StyleName", OleDbType.VarChar, 30);
            param[1].Value = sc.StyleName;
            param[2] = new OleDbParameter("@Content", OleDbType.VarChar);
            param[2].Value = sc.Content;
            param[3] = new OleDbParameter("@Description", OleDbType.VarChar, 200);
            param[3].Value = sc.Description;
            param[4] = new OleDbParameter("@CreatTime", OleDbType.Date, 8);
            param[4].Value = sc.CreatTime;
            param[5] = new OleDbParameter("@isRecyle", OleDbType.TinyInt, 1);
            param[5].Value = sc.isRecyle;
            return param;
        }

        private OleDbParameter[] GetstyleClassParameters(Foosun.Model.StyleClassInfo sc)
        {
            OleDbParameter[] param = new OleDbParameter[3];
            param[0] = new OleDbParameter("@Sname", OleDbType.VarChar, 30);
            param[0].Value = sc.Sname;
            param[1] = new OleDbParameter("@CreatTime", OleDbType.Date, 8);
            param[1].Value = sc.CreatTime;
            param[2] = new OleDbParameter("@isRecyle", OleDbType.TinyInt, 1);
            param[2].Value = sc.isRecyle;
            return param;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using Foosun.Model;
using Foosun.DALFactory;
using Foosun.DALProfile;
using Foosun.Config;
using System.Data.OleDb;

namespace Foosun.AccessDAL
{
    public class AdminGroup : DbBase, IAdminGroup
    {
        private string SiteID;
        public AdminGroup()
        {
            SiteID = Foosun.Global.Current.SiteID;
        }
        /// <summary>
        /// 增加管理员组
        /// </summary>
        /// <param name="agci">构造参数</param>
        /// <returns></returns>
        public int Add(Foosun.Model.AdminGroup agci)
        {
            string checkSql = "";
            int recordCount = 0;
            string AdminGruopNum = Common.Rand.Number(8);
            while (true)
            {
                checkSql = "select count(*) from " + Pre + "sys_AdminGroup where adminGroupNumber='" + AdminGruopNum + "'";
                recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, checkSql, null);
                if (recordCount < 1)
                    break;
                else
                    AdminGruopNum = Common.Rand.Number(12, true);
            }
            checkSql = "select count(*) from " + Pre + "sys_AdminGroup where GroupName='" + agci.GroupName + "'";
            recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, checkSql, null);
            if (recordCount > 0)
            {
                throw new Exception("管理员组名称重复,请重新添加!");
            }
            OleDbParameter[] param = GetAdminGroupParameters(agci);
            OleDbParameter[] parm = Database.getNewParam(param, "GroupName,ClassList,channelList,SpecialList,CreatTime,SiteID");
            string Sql = "insert into " + Pre + "sys_AdminGroup (";
            Sql += "adminGroupNumber,GroupName,ClassList,channelList,SpecialList,CreatTime,SiteID";
            Sql += ") values ('" + AdminGruopNum + "',";
            Sql += "@GroupName,@ClassList,@channelList,@SpecialList,@CreatTime,@SiteID)";

            return Convert.ToInt32(DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm));
        }

        public int Edit(Foosun.Model.AdminGroup model)
        {
            OleDbParameter[] param = GetAdminGroupParameters(model);
            OleDbParameter[] parm = Database.getNewParam(param, "ClassList,SpecialList,channelList");

            string Sql = "Update " + Pre + "sys_AdminGroup Set ClassList='" + model.ClassList + "',SpecialList='" + model.SpecialList + "',";
            Sql += "channelList='" + model.channelList + "' Where adminGroupNumber='" + model.AdminGroupNumber + "'";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param);
        }

        public void Del(string id)
        {
            string Sql = "Delete From  " + Pre + "sys_AdminGroup where adminGroupNumber='" + id + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }

        public DataTable getInfo(string id)
        {
            string Sql = "Select adminGroupNumber,GroupName,ClassList,SpecialList,channelList From " + Pre + "sys_AdminGroup Where SiteID='" + SiteID + "' and adminGroupNumber='" + id + "'";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        public DataTable getClassList(string col, string TbName, string sqlselect)
        {
            if (TbName == "news_Class")
            {
                string str_Sql = "Select " + col + " From " + Pre + TbName + " " + sqlselect + " Order by OrderID desc,Id desc";
                return DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            }
            else
            {
                string str_Sql = "Select " + col + " From " + Pre + TbName + " " + sqlselect + " Order by Id desc";
                return DbHelper.ExecuteTable(CommandType.Text, str_Sql, null);
            }
        }

        public DataTable getColCname(string colname, string TbName, string classid, string id)
        {
            string Sql = "Select " + colname + " From " + Pre + TbName + " Where " + classid + "='" + id + "'";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        private OleDbParameter[] GetAdminGroupParameters(Foosun.Model.AdminGroup model)
        {
            OleDbParameter[] param = new OleDbParameter[7];
            param[0] = new OleDbParameter("@adminGroupNumber", OleDbType.VarWChar, 8);
            param[0].Value = model.AdminGroupNumber;
            param[1] = new OleDbParameter("@GroupName", OleDbType.VarWChar, 20);
            param[1].Value = model.GroupName;
            param[2] = new OleDbParameter("@ClassList", OleDbType.VarWChar);
            param[2].Value = model.ClassList;
            param[3] = new OleDbParameter("@SpecialList", OleDbType.VarWChar);
            param[3].Value = model.SpecialList;

            param[4] = new OleDbParameter("@channelList", OleDbType.VarWChar);
            param[4].Value = model.channelList;
            param[5] = new OleDbParameter("@CreatTime", OleDbType.Date, 8);
            param[5].Value = model.CreatTime;
            param[6] = new OleDbParameter("@SiteID", OleDbType.VarWChar, 12);
            param[6].Value = model.SiteID;
            return param;
        }
    }
}

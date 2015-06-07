using System;
using System.Text;
using System.Data;
using Foosun.DALFactory;
using Foosun.Model;
using Foosun.IDAL;

namespace Foosun.CMS
{
    public class UserList
    {
        private IUserList dal;
        public UserList()
        {
            dal = Foosun.DALFactory.DataAccess.CreateUserList();
        }

        public string getGroupName(string strGroupNumber)
        {
            return dal.GetGroupName(strGroupNumber);
        }
        public int Dels(string id)
        {
            return dal.Dels(id);
        }

        public DataTable GroupList()
        {
            DataTable dt = dal.GroupList();
            return dt;
        }
        public int Update(string id, string field, string value)
        {
            return dal.Update(id, field, value);
        }
        public DataTable GetPage(string UserName, string RealName, string UserNum, string Sex,  string siPoint, string biPoint, string sgPoint,string bgPoint,string _userlock,string _group,string _iscerts,string _SiteID, int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition)
        {
            return dal.GetPage(UserName, RealName, UserNum, Sex, siPoint, biPoint, sgPoint, bgPoint, _userlock, _group, _iscerts, _SiteID, PageIndex, PageSize, out RecordCount, out PageCount, SqlCondition);
        }

    }
}

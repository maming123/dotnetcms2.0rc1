using System;
using System.Data;
using System.Reflection;
using Foosun.Model;

namespace Foosun.IDAL
{
    public interface IUserList
    {
        string GetGroupName(string GroupNumber);
        int Dels(string id);
        DataTable GroupList();
        int Update(string id, string field, string value);
        DataTable GetPage(string UserName, string RealName, string UserNum, string Sex, string siPoint, string biPoint, string sgPoint, string bgPoint, string _userlock, string _group, string _iscerts, string _SiteID, int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition);
    }
}

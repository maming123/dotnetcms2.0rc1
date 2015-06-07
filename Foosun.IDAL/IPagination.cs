using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Foosun.Model;
using System.Reflection;

namespace Foosun.IDAL
{
    public interface IPagination
    {
        DataTable GetPage(string PageName, int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition);
    }
}

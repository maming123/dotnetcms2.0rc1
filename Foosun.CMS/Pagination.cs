//===========================================================
//==     (c)2013 Foosun Inc. by dotNETCMS 2.0              ==
//==             Forum:bbs.foosun.net                      ==
//==            website:www.foosun.net                     ==
//===========================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Foosun.Model;
using Foosun.IDAL;
using Foosun.DALFactory;

namespace Foosun.CMS
{
    public class Pagination
    {
        public static DataTable GetPage(string PageName, int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition)
        {
            IPagination dal = DataAccess.CreatePagination();
            return dal.GetPage(PageName, PageIndex, PageSize, out RecordCount, out PageCount, SqlCondition);
        }
    }
}

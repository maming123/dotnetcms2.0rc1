using System;
using System.Collections.Generic;
using System.Data;
using Foosun.DALFactory;
using Foosun.IDAL;

namespace Foosun.CMS
{
    public class Search
    {
        public static DataTable SearchGetPage(string DTable,int PageIndex, int PageSize, out int RecordCount, out int PageCount, Foosun.Model.Search si)
        {
            ISearch dal = DataAccess.CreateSearch();
            return dal.SearchGetPage(DTable,PageIndex, PageSize, out RecordCount, out PageCount, si);
        }
        public static string GetSaveClassframe(string ClassID)
        {
            ISearch dal = DataAccess.CreateSearch();

            return dal.GetSaveClassframe(ClassID);
        }

        public static string GetNewsReview(string Id, string type)
        {
            ISearch dal = DataAccess.CreateSearch();

            return dal.GetNewsReview(Id, type);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Foosun.IDAL
{
    public interface ISearch
    {
        DataTable SearchGetPage(string DTable, int PageIndex, int PageSize, out int RecordCount, out int PageCount, Foosun.Model.Search si);
        string GetSaveClassframe(string ClassID);
        string GetNewsReview(string ID, string gType);
    }
}

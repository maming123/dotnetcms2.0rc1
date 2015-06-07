using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using Foosun.Model;

namespace Foosun.IDAL
{
    public interface IFreeLabel
    {
        IList<FreeLablelDBInfo> GetTables();
        IList<FreeLablelDBInfo> GetFields(string TableName);
        bool IsNameRepeat(int id, string Name);
        bool Add(FreeLabelInfo info);
        bool Update(FreeLabelInfo info);
        bool Delete(int id);
        FreeLabelInfo GetSingle(int id);
        DataTable TestSQL(string Sql);
    }
}

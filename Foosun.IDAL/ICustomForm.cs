using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Foosun.Model;

namespace Foosun.DALFactory
{
    public interface ICustomForm
    {
        void Edit(CustomFormInfo info);
        CustomFormInfo GetInfo(int id);
        void DeleteForm(int id);
        string GetFormName(int id);
        CustomFormItemInfo GetFormItemInfo(int itemid);
        int GetItemCount(int formid);
        void EditFormItem(CustomFormItemInfo info);
        void DeleteFormItem(int itemid);
        IList<CustomFormItemInfo> GetAllInfo(int formid, out CustomFormInfo FormInfo);
        void AddRecord(int formid, SQLConditionInfo[] data);
		DataTable GetSubmitData(int formid, out string formname, out string tablename);
		DataTable GetSubmitData(int formid, out string formname, out string tablename, int pageIndex, int pageSize, out int recordCount, out int pageCount);
        void TruncateTable(int formid);
		StringBuilder GetFromData();
		DataTable GetFormDefined(int formid, out string formname, out string tablename);
		int EditFormManage(int customID,int formid, string MagerContent, bool ishow);
        bool isnotnull(int formid, string filedname);
    }
}

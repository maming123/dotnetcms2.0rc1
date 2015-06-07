using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Foosun.DALFactory
{
    public interface IRecyle
    {
        DataTable GetList(string type);
        void RallNCList();
        void RallNList(string classid);
        void RallCList();
        void RallSList();
        void RallLCList();
        void RallLList(string classid);
        void RallStCList();
        void RallStList(string classid);
        void RallPSFList();

        void DallNCList();
        void DallNList();
        void DallCList();
        void DallSList();
        void DallLCList();
        void DallLList();
        void DallStCList();
        void DallStList();
        void DallPSFList();

        void PRNCList(string idstr);
        void PRNList(string classid, string idstr);
        void PRCList(string idstr);
        void PRSList(string idstr);
        void PRStCList(string idstr);
        void PRStList(string classid, string idstr);
        void PRLCList(string idstr);
        void PRLList(string classid, string idstr);
        void PRPSFList(string idstr);

        void PDNCList(string idstr);
        void PDNList(string idstr);
        void PDCList(string idstr);
        void PDSList(string idstr);
        void PDStCList(string idstr);
        void PDStList(string idstr);
        void PDLCList(string idstr);
        void PDLList(string idstr);
        void PDPSFList(string idstr);

        DataTable GetNewsTable();
        DataTable GetNewsClass(string idstr);
        DataTable GetNews(string classid ,string tbname);
        DataTable GetSpeaciList(string idstr);
        DataTable GetSite(string idstr);
        void RaDComment(string NewsID, bool isDel);
    }
}

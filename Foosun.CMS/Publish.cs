//===========================================================
//==     (c)2013 Foosun Inc. by dotNETCMS 2.0              ==
//==             Forum:bbs.foosun.net                      ==
//==            website:www.foosun.net                     ==
//===========================================================
using System;
using System.Text;
using System.Data;
using Foosun.DALFactory;
using Foosun.Model;

namespace Foosun.CMS
{
    public class Publish
    {
        Foosun.IDAL.IPublish DalPublish = DataAccess.CreatePublish();
        public Publish()
        { }

        public IDataReader GetPublishNewsAll(out int nNewsCount)
        {
            return DalPublish.GetPublishNewsAll(out nNewsCount);
        }

        public IDataReader GetPublishNewsLast(int lastNum, bool unpublish, out int nNewsCount)
        {
            return DalPublish.GetPublishNewsLast(lastNum, unpublish, out nNewsCount);
        }

        public IDataReader GetNewsByCreateTime(DateTime beginTime, DateTime endTime, out int nNewsCount)
        {
            return DalPublish.GetPublishNewsByTime(beginTime, endTime, out nNewsCount);
        }

        public IDataReader GetPublishNewsByClass(string classid, bool unpublish, bool isdesc, string condition, out int ncount)
        {
            return DalPublish.GetPublishNewsByClass(classid, unpublish, isdesc, condition, out ncount);
        }

        public IDataReader GetClassAll(out int nClassCount)
        {
            return DalPublish.GetPublishClass(Foosun.Global.Current.SiteID, "", true, out nClassCount);
        }

        public IDataReader GetPublishClass(string classid, out int nClassCount)
        {
            return DalPublish.GetPublishClass("", classid, true, out nClassCount);
        }

        public IDataReader GetSpecialAll(string spid, out int nSpecialCount)
        {
            return DalPublish.GetPublishSpecial(spid, out nSpecialCount);
        }

        public IDataReader GetPageAll(string classid, out int nClassCount)
        {
            return DalPublish.GetPublishClass("", classid, true, out nClassCount);
        }
    }
}

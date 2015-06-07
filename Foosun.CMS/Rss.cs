using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Foosun.DALFactory;
using Foosun.Model;
using Foosun.IDAL;

namespace Foosun.CMS
{
    public class Rss
    {
        private IRss dal;
        public Rss()
        {
            dal = Foosun.DALFactory.DataAccess.CreateRss();
        }
        public int sel(string ClassID)
        {
            return dal.sel(ClassID);
        }

        public DataTable getxmllist(string ClassID)
        {
            DataTable dt = dal.getxmllist(ClassID);
            return dt;
        }

    }
}

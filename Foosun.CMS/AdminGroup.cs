//===========================================================
//==     (c)2011 Foosun Inc. by dotNETCMS 1.0              ==
//==             Forum:bbs.foosun.net                      ==
//==            website:www.foosun.net                     ==
//===========================================================
using System;
using System.Collections.Generic;
using System.Data;
using Foosun.Model;
using Foosun.DALFactory;

namespace Foosun.CMS
{
    public class AdminGroup
    {
        private IAdminGroup dal;
        public AdminGroup()
        {
            dal = DataAccess.CreateAdminGroup();
        }

        public int add(Foosun.Model.AdminGroup model)
        {
            int result = dal.Add(model);
            return result;
        }

        public int Edit(Foosun.Model.AdminGroup agci)
        {
            int result = dal.Edit(agci);
            return result;
        }

        public void Del(string id)
        {
            dal.Del(id);
        }

        public DataTable getInfo(string id)
        {
            DataTable dt = dal.getInfo(id);
            return dt;
        }

        public DataTable getClassList(string col, string TbName, string sqlselect)
        {
            DataTable dt = dal.getClassList(col, TbName, sqlselect);
            return dt;
        }

        public DataTable getColCname(string colname, string TbName, string classid, string id)
        {
            DataTable dt = dal.getColCname(colname, TbName, classid, id);
            return dt;
        }
    }
}

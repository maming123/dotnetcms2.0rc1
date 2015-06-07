using System;
using System.Collections.Generic;
using System.Data;
using Foosun.Model;
using Foosun.DALFactory;

namespace Foosun.CMS
{
    public class Admin
    {
        private IAdmin ac;
        public Admin()
        {
            ac = DataAccess.CreateAdmin();
        }
        public void Lock(string id)
        {
            ac.Lock(id);
        }
        public void UnLock(string id)
        {
            ac.UnLock(id);
        }
        public void Del(string id)
        {
            ac.Del(id);
        }
        public DataTable GetAdminGroupList()
        {
            DataTable dt = ac.GetAdminGroupList();
            return dt;
        }
        public DataTable GetSiteList()
        {
            DataTable dt = ac.GetSiteList();
            return dt;
        }
        public int Add(Foosun.Model.AdminInfo aci)
        {
            int result = ac.Add(aci);
            return result;
        }
        public int Edit(Foosun.Model.AdminInfo aci)
        {
            return ac.Edit(aci);
        }
        public DataTable GetAdminInfo(string id)
        {
            DataTable dt = ac.GetAdminInfo(id);
            return dt;
        }

        /// <summary>
        /// 得到管理员的权限列表
        /// </summary>
        /// <param name="UserNum"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetAdminPopList(string UserNum,int Id)
        {
            return ac.GetAdminPopList(UserNum, Id);
        }

        public void UpdatePOPlist(string UserNum, int Id, string PopLIST)
        {
            ac.UpdatePOPlist(UserNum, Id, PopLIST);
        }

        /// <summary>
        /// 得到左右管理员列表
        /// </summary>
        /// <returns></returns>
        public DataTable getAdmininfoList()
        {
            return ac.getAdmininfoList();
        }
    }
}

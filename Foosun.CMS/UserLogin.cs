using System;
using System.Collections.Generic;
using System.Text;
using Foosun.DALFactory;
using Foosun.Model;
using Foosun.IDAL;

namespace Foosun.CMS
{
    public class UserLogin
    {
        private IUserLogin dal;

        public UserLogin()
        {
            dal = DataAccess.CreateUserLogin();
        }
        /// <summary>
        /// 检查普通会员登录状态
        /// </summary>
        /// <param name="userNum"></param>
        /// <param name="isCert"></param>
        /// <param name="LimitedIP"></param>
        /// <returns></returns>
        public EnumLoginState CheckUserLogin(string userNum, bool isCert)
        {
            return dal.CheckUserLogin(userNum, isCert);
        }
        /// <summary>
        /// 检查管理员登录状态
        /// </summary>
        /// <param name="userNum"></param>
        /// <param name="LimitedIP"></param>
        /// <returns></returns>
        public EnumLoginState CheckAdminLogin(string userNum)
        {
            return dal.CheckAdminLogin(userNum);
        }
        /// <summary>
        /// 检查管理员权限
        /// </summary>
        /// <param name="popCode"></param>
        /// <param name="classID"></param>
        /// <param name="specialID"></param>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public EnumLoginState CheckAdminAuthority(string popCode, string classID, string specialID, string siteID, string adminLogined)
        {
            return dal.CheckAdminAuthority(popCode, classID, specialID, siteID, adminLogined);
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public EnumLoginState AdminLogin(string userName, string passWord, out GlobalUserInfo info)
        {
            return dal.AdminLogin(userName, passWord, out info);
        }
        /// <summary>
        /// 个人用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public EnumLoginState PersonLogin(string userName, string passWord, out GlobalUserInfo info)
        {
            return dal.PersonLogin(userName, passWord, out info);
        }
        public int GetLoginSpan()
        {
            return dal.GetLoginSpan();
        }
        public string GetAdminGroupClassList()
        {
            return dal.GetAdminGroupClassList();
        }
        public string GetAdminGroupSpecialList()
        {
            return dal.GetAdminGroupSpecialList();
        }
    }
}

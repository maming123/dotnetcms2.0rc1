using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Foosun.Config;
using Foosun.DALProfile;
using Foosun.Model;
using Foosun.IDAL;

namespace Foosun.SQLServerDAL
{
    public class UserLogin : DbBase, IUserLogin
    {
        protected struct AdminDataInfo
        {
            public byte isSuper;
            public string adminGroupNumber;
            public int ID;
            public byte isChannel;
            public string LimitedIP;
            public bool bisLock;
            public bool flag;
        }
        protected struct UserLoginSucceedInfo
        {
            public string userNum;
            public string IP;
            public int IPoint;
            public int GPoint;
            public int CPoint;
            public int APoint;
        }
        private static readonly string SQL_SYS = "select islock,EmailATF,isMobile,isIDcard,UserGroupNumber from " + DBConfig.TableNamePrefix + "sys_User where UserNum=@UserNum";
        private static readonly string SQL_PRAM = "select top 1 IPLimt,returnemail,returnmobile,LoginLock,cPointParam,aPointparam from " + DBConfig.TableNamePrefix + "sys_PramUser";
        private static readonly string SQL_ADMIN = "select Iplimited,isLock,isSuper,adminGroupNumber,[ID],[isChannel] from " + DBConfig.TableNamePrefix + "sys_admin where UserNum=@UserNum";
        private static readonly string SQL_USERGROUP = "select IsCert,LoginPoint,Rtime from " + DBConfig.TableNamePrefix + "user_Group where GroupNumber=@GroupNumber";
        private static readonly string SQL_DEFUSERGROUP = "select top 1 a.IsCert,a.LoginPoint,a.Rtime from " + DBConfig.TableNamePrefix + "user_Group a inner join " + DBConfig.TableNamePrefix + "sys_PramUser b on a.GroupNumber=b.RegGroupNumber";

        EnumLoginState IUserLogin.CheckUserLogin(string userNum, bool isCert)
        {
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                cn.Open();
                return CheckUserLogin(cn, userNum, isCert);
            }
            catch
            {
                return EnumLoginState.Err_DbException;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        protected EnumLoginState CheckUserLogin(SqlConnection cn, string userNum, bool isCert)
        {
            #region 局部变量
            string LimitedIP = string.Empty;
            bool bisLock = true;
            bool bEmailATF = false;
            bool bisMobile = false;
            string sUserGroupNumber = string.Empty;
            bool bisIDcard = false;
            #endregion 局部变量
            bool flag = true;
            IDataReader rd = this.GetSysUser(cn, userNum);
            if (rd.Read())
            {
                #region 取值
                if (!rd.IsDBNull(0) && rd.GetByte(0) == 0X0)
                    bisLock = false;
                if (!rd.IsDBNull(1) && rd.GetByte(1) != 0X0)
                    bEmailATF = true;
                if (!rd.IsDBNull(2) && rd.GetByte(2) != 0X0)
                    bisMobile = true;
                if (!rd.IsDBNull(3) && rd.GetByte(3) != 0X0)
                    bisIDcard = true;
                if (!rd.IsDBNull(4))
                    sUserGroupNumber = rd.GetString(4);
                flag = false;
                #endregion 取值
            }
            rd.Close();
            if (flag)
                return EnumLoginState.Err_UserNumInexistent;
            if (bisLock)
                return EnumLoginState.Err_Locked;
            if (LimitedIP.Trim() != string.Empty && !Common.PageValidate.ValidateIP(LimitedIP))
                return EnumLoginState.Err_IPLimited;
            bool bReturnEmail = false;
            bool bReturnMobile = false;
            rd = GetParamUser(cn);
            if (rd.Read())
            {
                if (!rd.IsDBNull(0))
                    LimitedIP = rd.GetString(0);
                if (!rd.IsDBNull(1) && rd.GetByte(1) != 0X00)
                    bReturnEmail = true;
                if (!rd.IsDBNull(2) && rd.GetByte(2) != 0X00)
                    bReturnMobile = true;
            }
            rd.Close();
            if (bReturnEmail && !bEmailATF)
                return EnumLoginState.Err_UnEmail;
            if (bReturnMobile && !bisMobile)
                return EnumLoginState.Err_UnMobile;
            if (isCert)
            {
                rd = GetUserGroupInfo(cn, sUserGroupNumber);
                if (rd.Read())
                {
                    if (!bisIDcard && rd["IsCert"] != DBNull.Value && Convert.ToInt32(rd["IsCert"]) != 0X00)
                    {
                        rd.Close();
                        return EnumLoginState.Err_UnCert;
                    }
                }
                rd.Close();
                return EnumLoginState.Succeed;
            }
            else
            {
                return EnumLoginState.Succeed;
            }
        }
        protected struct userinfo
        {
            public bool bisLock;
            public bool flag;
        }
        protected EnumLoginState CheckAdminLogin(SqlConnection cn, string userNum, out AdminDataInfo info)
        {
            info.adminGroupNumber = string.Empty;
            info.ID = 0;
            info.isChannel = 0;
            info.isSuper = 0;
            info.bisLock = true;
            info.flag = true;
            info.LimitedIP = "";
            string LimitedIP = string.Empty;
            bool bisLock = true;
            bool flag = true;
            IDataReader rd;
            string CacheKeys = "userinfo-" + userNum;
            object objModels = Common.DataCache.GetCache(CacheKeys);
            userinfo uinfo;
            if (objModels == null)
            {
                try
                {
                    rd = GetSysUser(cn, userNum);
                    uinfo.bisLock = true;
                    uinfo.flag = true;
                    if (rd.Read())
                    {
                        if (!rd.IsDBNull(0) && rd.GetByte(0) == 0X0)
                            uinfo.bisLock = false;
                        uinfo.flag = false;
                    }
                    rd.Close();
                    objModels = uinfo;
                    if (objModels != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKeys, objModels, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            uinfo = (userinfo)objModels;
            bisLock = uinfo.bisLock;
            flag = uinfo.flag;
            if (flag)
                return EnumLoginState.Err_UserNumInexistent;
            if (bisLock)
                return EnumLoginState.Err_Locked;
            flag = true;
            bisLock = true;
            string CacheKey = "AdminDataInfo-" + userNum;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    rd = DbHelper.ExecuteReader(cn, CommandType.Text, SQL_ADMIN, new SqlParameter("@UserNum", userNum));
                    if (rd.Read())
                    {
                        if (!rd.IsDBNull(0)) info.LimitedIP = rd.GetString(0);
                        if (!rd.IsDBNull(1) && rd.GetByte(1) == 0X0)
                            info.bisLock = false;
                        if (!rd.IsDBNull(2))
                            info.isSuper = rd.GetByte(2);
                        if (!rd.IsDBNull(3))
                            info.adminGroupNumber = rd.GetString(3);
                        info.ID = rd.GetInt32(4);
                        if (!rd.IsDBNull(5))
                            info.isChannel = rd.GetByte(5);
                        info.flag = false;
                    }
                    rd.Close();
                    objModel = info;
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            info = (AdminDataInfo)objModel;
            flag = info.flag;
            bisLock = info.bisLock;
            LimitedIP = info.LimitedIP;
            if (flag)
            {
                return EnumLoginState.Err_AdminNumInexistent;
            }
            if (bisLock)
                return EnumLoginState.Err_AdminLocked;
            if (LimitedIP.Trim() != string.Empty && !Common.PageValidate.ValidateIP(LimitedIP))
                return EnumLoginState.Err_IPLimited;
            return EnumLoginState.Succeed;
        }

        EnumLoginState IUserLogin.CheckAdminLogin(string userNum)
        {
            SqlConnection cn = new SqlConnection(Foosun.Config.DBConfig.CmsConString);
            try
            {
                cn.Open();
                AdminDataInfo info;
                return CheckAdminLogin(cn, userNum, out info);
            }
            catch
            {
                return EnumLoginState.Err_DbException;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        protected IDataReader GetParamUser(SqlConnection cn)
        {
            return DbHelper.ExecuteReader(cn, CommandType.Text, SQL_PRAM, null);
        }
        protected IDataReader GetSysUser(SqlConnection cn, string userNum)
        {
            SqlParameter Param = new SqlParameter("@UserNum", userNum);
            return DbHelper.ExecuteReader(cn, CommandType.Text, SQL_SYS, Param);
        }
        protected IDataReader GetUserGroupInfo(SqlConnection cn, string groupNum)
        {
            SqlParameter Param = new SqlParameter("@GroupNumber", groupNum);
            SqlDataReader rd = (SqlDataReader)DbHelper.ExecuteReader(cn, CommandType.Text, SQL_USERGROUP, Param);
            if (!rd.HasRows)
            {
                rd.Close();
                return (SqlDataReader)DbHelper.ExecuteReader(cn, CommandType.Text, SQL_DEFUSERGROUP, null);
            }
            return rd;
        }
        protected string GetAdminPopList(SqlConnection cn, int id)
        {
            string Sql = "select PopList from " + Pre + "sys_Admin where [ID]=" + id;
            return Convert.ToString(DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, null));
        }
        protected IDataReader GetAdminGroupList(SqlConnection cn, string groupNum)
        {
            string Sql = "select ClassList,SpecialList,channelList from " + Pre + "sys_admingroup where adminGroupNumber=@adminGroupNumber";
            SqlParameter Param = new SqlParameter("@adminGroupNumber", groupNum);
            return DbHelper.ExecuteReader(cn, CommandType.Text, Sql, Param);
        }
        /// <summary>
        /// 权限处理
        /// </summary>
        /// <param name="popCode">权限代码</param>
        /// <param name="classID">栏目ID</param>
        /// <param name="specialID">专题ID</param>
        /// <param name="siteID">频道ID</param>
        /// <returns></returns>
        EnumLoginState IUserLogin.CheckAdminAuthority(string popCode, string classID, string specialID, string siteID, string adminLogined)
        {
            string UserNum = Foosun.Global.Current.UserNum;
            string adminLoginED = Foosun.Global.Current.adminLogined;
            if (adminLoginED != "1")
            {
                return EnumLoginState.Err_AdminLogined;
            }
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                cn.Open();
                AdminDataInfo info;
                EnumLoginState state = CheckAdminLogin(cn, UserNum, out info);
                if (state != EnumLoginState.Succeed)
                    return state;
                if (info.isSuper == 0X01)
                    return EnumLoginState.Succeed;
                string PopList = GetAdminPopList(cn, info.ID);
                if (!string.IsNullOrEmpty(popCode))
                {
                    popCode = "," + popCode + ",";
                }
                if (!string.IsNullOrEmpty(PopList))
                {
                    PopList = "," + PopList + ",";
                }
                if (PopList.IndexOf(popCode) < 0)
                    return EnumLoginState.Err_NoAuthority;
                string ClassList = string.Empty;
                string SpecialList = string.Empty;
                string SiteList = string.Empty;
                IDataReader rd = GetAdminGroupList(cn, info.adminGroupNumber);
                if (rd.Read())
                {
                    if (!rd.IsDBNull(0))
                        ClassList = rd.GetString(0);
                    if (!rd.IsDBNull(1))
                        SpecialList = rd.GetString(1);
                    if (!rd.IsDBNull(2))
                        SiteList = rd.GetString(2);
                }
                rd.Close();
                if (ClassList.IndexOf(classID) >= 0 && SpecialList.IndexOf(specialID) >= 0 && SiteList.IndexOf(siteID) >= 0)
                    return EnumLoginState.Succeed;
                else
                    return EnumLoginState.Err_NoAuthority;
            }
            catch
            {
                return EnumLoginState.Err_DbException;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        EnumLoginState IUserLogin.PersonLogin(string userName, string passWord, out GlobalUserInfo info)
        {
            info = new GlobalUserInfo(string.Empty, string.Empty, string.Empty, string.Empty);
            if (userName == null || userName.Trim() == string.Empty || passWord == null || passWord.Trim() == string.Empty)
            {
                return EnumLoginState.Err_NameOrPwdError;

            }
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                string LogIP = Common.Computer.GetIP();
                DateTime Now = DateTime.Now;
                cn.Open();
                #region 基本信息表
                string UserNum = string.Empty;
                string SiteID = string.Empty;
                string PWD = string.Empty;
                byte IsLock = 0X01;
                int ipnt = 0;
                int gpnt = 0;
                int cpnt = 0;
                int apnt = 0;
                string sUserGroup = string.Empty;
                DateTime dtUserRegDate = DateTime.Now;
                SqlParameter Param = new SqlParameter("@UserName", userName);
                string Sql = "select UserPassword,UserNum,islock,SiteID,UserGroupNumber,RegTime,iPoint,gPoint,cPoint,aPoint from " + Pre + "sys_User where UserName=@UserName";
                bool bexist = false;
                IDataReader rd = DbHelper.ExecuteReader(cn, CommandType.Text, Sql, Param);
                if (rd.Read())
                {
                    PWD = rd.GetString(0);
                    UserNum = rd.GetString(1);
                    IsLock = rd.GetByte(2);
                    if (!rd.IsDBNull(3))
                        SiteID = rd.GetString(3);
                    sUserGroup = rd.GetString(4);
                    dtUserRegDate = rd.GetDateTime(5);
                    ipnt = rd.GetInt32(6);
                    gpnt = rd.GetInt32(7);
                    cpnt = rd.GetInt32(8);
                    apnt = rd.GetInt32(9);
                    bexist = true;
                }
                rd.Close();
                if (!bexist)
                    return EnumLoginState.Err_NameOrPwdError;
                #endregion
                #region 对登录错误的检查和处理
                //连续登录错误锁定
                string sCPParam = string.Empty;
                string sAPParam = string.Empty;
                string LoginLock = string.Empty;
                rd = GetParamUser(cn);
                if (rd.Read())
                {
                    if (rd["LoginLock"] != DBNull.Value)
                        LoginLock = rd["LoginLock"].ToString();
                    if (rd["cPointParam"] != DBNull.Value)
                        sCPParam = rd["cPointParam"].ToString();
                    if (rd["aPointparam"] != DBNull.Value)
                        sAPParam = rd["aPointparam"].ToString();
                }
                rd.Close();
                //int nErrorNum = 0;
                string pattern = @"^(?<n>\d+)\|(?<t>\d+)";
                Regex reg = new Regex(pattern, RegexOptions.Compiled);
                Match m = reg.Match(LoginLock);
                if (m.Success)
                {
                    int number = int.Parse(m.Groups["n"].Value);
                    int time = int.Parse(m.Groups["t"].Value);
                    rd = GetErrorLogInfo(cn, UserNum, LogIP);
                    if (rd.Read())
                    {
                        int num = rd.GetInt32(0);
                        DateTime dtLast = rd.GetDateTime(1);
                        if (num >= number && dtLast.AddMinutes(time) > Now)
                        {
                            rd.Close();
                            return EnumLoginState.Err_DurativeLogError;
                        }
                    }
                    rd.Close();
                }
                #endregion
                if (PWD != Common.StringPlus.MD5(passWord))
                {
                    //记录错误
                    UpdateErrorNum(cn, UserNum, LogIP);
                    return EnumLoginState.Err_NameOrPwdError;
                }
                else
                {
                    ClearErrorNum(cn, UserNum, LogIP);
                }
                if (IsLock != 0X00)
                {
                    return EnumLoginState.Err_Locked;
                }
                EnumLoginState state = CheckUserLogin(cn, UserNum, true);
                //加入未认证写数据
                if (state == EnumLoginState.Succeed || state == EnumLoginState.Err_UnCert)
                {
                    info.SiteID = SiteID;
                    info.UserName = userName;
                    info.UserNum = UserNum;
                    info.adminLogined = "0";
                    if (state == EnumLoginState.Succeed)
                    {
                        info.uncert = false;
                    }
                    else
                    {
                        info.uncert = true;
                        return EnumLoginState.Succeed;
                    }
                }
                else
                {
                    return state;
                }
                #region 会员组超时
                int nGroupExp = 0;
                bool bgrp = false;
                string LogPoint = string.Empty;
                rd = GetUserGroupInfo(cn, sUserGroup);
                if (rd.Read())
                {
                    if (rd["Rtime"] != DBNull.Value)
                        nGroupExp = Convert.ToInt32(rd["Rtime"]);
                    if (rd["LoginPoint"] != DBNull.Value)
                        LogPoint = rd["LoginPoint"].ToString();
                    bgrp = true;
                }
                rd.Close();
                if (!bgrp)
                    return state;
                if (nGroupExp != 0 && dtUserRegDate.AddDays(nGroupExp) <= Now)
                {
                    LockUser(cn, UserNum);
                    return EnumLoginState.Err_GroupExpire;
                }
                #endregion
                #region 积分计算
                m = reg.Match(LogPoint);
                if (m.Success)
                {
                    int ci = int.Parse(m.Groups["n"].Value);
                    int cg = int.Parse(m.Groups["t"].Value);
                    ipnt += ci;
                    gpnt += cg;
                }

                string p = @"^(?<n>\d+)\|";
                Regex r = new Regex(p, RegexOptions.Compiled);
                Match match = r.Match(sCPParam);
                if (match.Success)
                {
                    int cc = int.Parse(m.Groups["n"].Value);
                    cpnt += cc;
                }
                match = r.Match(sAPParam);
                if (match.Success)
                {
                    int ca = int.Parse(m.Groups["n"].Value);
                    apnt += ca;
                }
                UserLoginSucceedInfo ul;
                ul.userNum = UserNum;
                ul.IP = LogIP;
                ul.IPoint = ipnt;
                ul.GPoint = gpnt;
                ul.APoint = apnt;
                ul.CPoint = cpnt;
                UpdateUserLogin(cn, ul);
                return EnumLoginState.Succeed;
                #endregion
            }
            catch
            {
                return EnumLoginState.Err_DbException;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        EnumLoginState IUserLogin.AdminLogin(string userName, string passWord, out GlobalUserInfo info)
        {
            info = new GlobalUserInfo(string.Empty, string.Empty, string.Empty, string.Empty);
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            try
            {
                cn.Open();
                string UserNum = string.Empty;
                string SiteID = string.Empty;
                #region 基本信息表
                SqlParameter Param = new SqlParameter("@UserName", userName);
                string Sql = "select UserPassword,UserNum,isAdmin,islock,SiteID from " + Pre + "sys_User where UserName=@UserName";
                EnumLoginState state = EnumLoginState.Succeed;
                IDataReader rd = DbHelper.ExecuteReader(cn, CommandType.Text, Sql, Param);
                if (rd.Read())
                {
                    string pwd = rd.GetString(0);
                    UserNum = rd.GetString(1);
                    byte isAdmin = rd.GetByte(2);
                    byte isLock = rd.GetByte(3);
                    if (!rd.IsDBNull(4))
                        SiteID = rd.GetString(4);
                    if (pwd != Common.StringPlus.MD5(passWord))
                        state = EnumLoginState.Err_NameOrPwdError;
                    else if (isAdmin != 0X01)
                        state = EnumLoginState.Err_NotAdmin;
                    else if (isLock != 0X00)
                        state = EnumLoginState.Err_Locked;
                }
                else
                {
                    state = EnumLoginState.Err_NameOrPwdError;
                }
                rd.Close();
                if (state != EnumLoginState.Succeed)
                    return state;
                #endregion
                //检查管理员表
                AdminDataInfo adinfo;
                state = CheckAdminLogin(cn, UserNum, out adinfo);
                if (state == EnumLoginState.Succeed)
                {
                    info.SiteID = SiteID;
                    info.UserName = userName;
                    info.UserNum = UserNum;
                    info.adminLogined = "1";
                }
                try
                {
                    Sql = "update " + Pre + "SYS_USER set LastLoginTime='" + DateTime.Now + "',LastIP='" + Common.Computer.GetIP() + "',LoginNumber=LoginNumber+1 where UserNum='" + UserNum + "'";
                    DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, Param);
                    RootPublic rtp = new RootPublic();
                    rtp.SaveUserAdminLogs(cn, 1, 1, userName, "登录成功", "用户名：" + userName);
                }
                catch { }
                return state;
            }
            catch
            {
                return EnumLoginState.Err_DbException;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        /// <summary>
        /// 查找错误的登录记录
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="userNum"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        protected IDataReader GetErrorLogInfo(SqlConnection cn, string userNum, string IP)
        {
            string Sql = "select ErrorNum,LastErrorTime from " + Pre + "user_Guser where UserNum=@UserNum and IP=@IP order by LastErrorTime desc";
            SqlParameter[] Param = new SqlParameter[] { new SqlParameter("@UserNum", userNum), new SqlParameter("@IP", IP) };
            return DbHelper.ExecuteReader(cn, CommandType.Text, Sql, Param);
        }
        /// <summary>
        /// 更新或添加错误登录记录
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="userNum"></param>
        /// <param name="IP"></param>
        protected void UpdateErrorNum(SqlConnection cn, string userNum, string IP)
        {
            string Sql = "select top 1 id from " + Pre + "user_Guser where UserNum=@UserNum and IP=@IP order by LastErrorTime desc";
            SqlParameter[] Param = new SqlParameter[] { new SqlParameter("@UserNum", userNum), new SqlParameter("@IP", IP) };
            object obj = DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, Param);
            if (obj != null && obj != DBNull.Value)
            {
                Sql = "update " + Pre + "user_Guser set ErrorNum=ErrorNum+1,LastErrorTime='" + DateTime.Now + "' where id=" + obj;
                DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, null);
            }
            else
            {
                Sql = "insert into " + Pre + "user_Guser (UserNum,CreatTime,ErrorNum,IP,LastErrorTime) values (@UserNum,'" + DateTime.Now + "'";
                Sql += ",1,@IP,'" + DateTime.Now + "')";
                DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, Param);
            }
        }
        /// <summary>
        /// 清除错误登录记录
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="userNum"></param>
        /// <param name="IP"></param>
        protected void ClearErrorNum(SqlConnection cn, string userNum, string IP)
        {
            string Sql = "delete from " + Pre + "user_Guser where UserNum=@UserNum and IP=@IP";
            SqlParameter[] Param = new SqlParameter[] { new SqlParameter("@UserNum", userNum), new SqlParameter("@IP", IP) };
            DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, Param);
        }
        protected void LockUser(SqlConnection cn, string UserNum)
        {
            string Sql = "update " + Pre + "SYS_USER set isLock=1 where UserNum=@UserNum";
            SqlParameter Param = new SqlParameter("@UserNum", UserNum);
            DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, Param);
        }
        protected void UpdateUserLogin(SqlConnection cn, UserLoginSucceedInfo info)
        {
            try
            {
                string Sql = "select top 1 GroupNumber from " + Pre + "user_Group where Gpoint>=" + info.GPoint + " and iPoint>=" + info.IPoint;
                Sql += " order by Gpoint Desc,iPoint Desc";
                string newGroup = Convert.ToString(DbHelper.ExecuteScalar(cn, CommandType.Text, Sql, null));
                Sql = "update " + Pre + "SYS_USER set LastLoginTime='" + DateTime.Now + "',LastIP=@LastIP,iPoint=" + info.IPoint;
                Sql += ",gPoint=" + info.GPoint + ",cPoint=" + info.CPoint + ",aPoint=" + info.APoint + ",LoginNumber=LoginNumber+1";
                if (newGroup != string.Empty)
                    Sql += ",UserGroupNumber=@UserGroupNumber";
                Sql += " where UserNum=@UserNum";
                SqlParameter[] Param = new SqlParameter[3];
                Param[0] = new SqlParameter("@LastIP", SqlDbType.NVarChar, 15);
                Param[0].Value = info.IP;
                Param[1] = new SqlParameter("@UserGroupNumber", SqlDbType.NVarChar, 20);
                Param[1].Value = newGroup;
                Param[2] = new SqlParameter("@UserNum", SqlDbType.NVarChar, 20);
                Param[2].Value = info.userNum;
                DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, Param);
            }
            catch
            {
            }
        }
        int IUserLogin.GetLoginSpan()
        {
            string Sql = "select top 1 LoginLock from " + Pre + "sys_PramUser";
            string s = Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, null));
            string pattern = @"^\d+\|(?<n>\d+)$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled);
            Match m = reg.Match(s);
            if (m.Success)
            {
                return Convert.ToInt32(m.Groups["n"].Value);
            }
            return 0;
        }
        public string GetAdminGroupClassList()
        {
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            string UserNum = Foosun.Global.Current.UserNum;
            string ClassList = string.Empty;
            try
            {
                cn.Open();
                AdminDataInfo info;
                CheckAdminLogin(cn, UserNum, out info);
                if (info.isSuper==0X001)
                {
                    if (cn.State==ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    return "isSuper";
                }
                IDataReader rd = GetAdminGroupList(cn, info.adminGroupNumber);
                if (rd.Read())
                {
                    if (!rd.IsDBNull(0))
                        ClassList = rd.GetString(0);
                }
                rd.Close();
            }
            catch
            {
                return "";
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            ClassList = (ClassList == null ? "" : ClassList);
            string _RClassList = "";
            char[] _Split = { ',' };
            string[] _ClassArray = ClassList.Split(_Split, StringSplitOptions.RemoveEmptyEntries);
            DataTable _ClassLists = DbHelper.ExecuteTable(cn, CommandType.Text, "Select * from "+Pre+"news_Class", null);
            for (int i = 0; i < _ClassArray.Length; i++)
            {
                string _ClassID = _ClassArray[i].Trim();
                if (_ClassID != "")
                {
                    DataRow[] _SDR = _ClassLists.Select("ClassID='" + _ClassID + "'");
                    while (_SDR.Length > 0)
                    {
                        string _ParentID = _SDR[0]["ParentID"].ToString().Trim();
                        if (_ParentID != "0")
                        {
                            _RClassList += _ParentID + ",";
                        }
                        _SDR = _ClassLists.Select("ClassID='" + _ParentID + "'");
                    }
                    _RClassList += _ClassID + ",";
                }
            }
            _RClassList = _RClassList.TrimEnd(',');
            return _RClassList;
        }
        public string GetAdminGroupSpecialList()
        {
            SqlConnection cn = new SqlConnection(DBConfig.CmsConString);
            string UserNum = Foosun.Global.Current.UserNum;
            string SpecialList = string.Empty;
            try
            {
                cn.Open();
                AdminDataInfo info;
                CheckAdminLogin(cn, UserNum, out info);
                if (info.isSuper == 0X001)
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    return "isSuper";
                }
                IDataReader rd = GetAdminGroupList(cn, info.adminGroupNumber);
                if (rd.Read())
                {
                    if (!rd.IsDBNull(1))
                        SpecialList = rd.GetString(1);
                }
                rd.Close();
            }
            catch
            {
                return "";
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            SpecialList = (SpecialList == null ? "" : SpecialList);
            string _RClassList = "";
            char[] _Split = { ',' };
            string[] _ClassArray = SpecialList.Split(_Split, StringSplitOptions.RemoveEmptyEntries);
            DataTable _ClassLists = DbHelper.ExecuteTable(cn, CommandType.Text, "Select * from " + Pre + "news_special", null);
            for (int i = 0; i < _ClassArray.Length; i++)
            {
                string _ClassID = _ClassArray[i].Trim();
                if (_ClassID != "")
                {
                    DataRow[] _SDR = _ClassLists.Select("SpecialID='" + _ClassID + "'");
                    while (_SDR.Length > 0)
                    {
                        string _ParentID = _SDR[0]["ParentID"].ToString().Trim();
                        if (_ParentID != "0")
                        {
                            _RClassList += _ParentID + ",";
                        }
                        _SDR = _ClassLists.Select("SpecialID='" + _ParentID + "'");
                    }
                    _RClassList += _ClassID + ",";
                }
            }
            _RClassList = _RClassList.TrimEnd(',');
            return _RClassList;
        }
    }
}
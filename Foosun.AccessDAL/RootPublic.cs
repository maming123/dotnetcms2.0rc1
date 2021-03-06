﻿//===========================================================
//==     (c)2013 Foosun Inc. by dotNETCMS 2.0              ==
//==             Forum:bbs.foosun.net                      ==
//==            website:www.foosun.net                     ==
//===========================================================
using System;
using System.Data;
using Foosun.Model;
using System.Text.RegularExpressions;
using System.Text;
using System.Reflection;
using Foosun.DALProfile;
using Foosun.Config;
using Foosun.IDAL;
using System.Data.OleDb;

namespace Foosun.AccessDAL
{
    public class RootPublic : DbBase, IRootPublic
    {
        /// <summary>
        /// 获得站点ID是否存在
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public int GetSiteID(string siteID)
        {
            int intflg = 0;
            OleDbParameter param = new OleDbParameter("@SiteID", siteID);
            string Sql = "Select id From " + Pre + "news_site Where ChannelID=@SiteID and isRecyle=0 and isLock=0";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    intflg = 1;
                }
                rdr.Clear(); rdr.Dispose();
            }
            return intflg;
        }

        /// <summary>
        /// 获取会员名称
        /// </summary>
        /// <param name="userNum">传入的会员编号</param>
        /// <returns>返回名称</returns>
        public string GetUserName(string userNum)
        {
            string uflg = "找不到用户";
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string Sql = "Select id,UserName From " + Pre + "sys_user Where UserNum=@UserNum";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    uflg = rdr.Rows[0]["UserName"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return uflg;
        }


        /// <summary>
        /// 获取会员名称
        /// </summary>
        public int GetUserNameByUId(string userNum)
        {
            int uflg = 0;
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string Sql = "Select id From " + Pre + "sys_user Where UserNum=@UserNum";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    uflg = int.Parse(rdr.Rows[0]["id"].ToString());
                }
                rdr.Clear(); rdr.Dispose();
            }
            return uflg;
        }

        /// <summary>
        /// 根据ID获取会员编号
        /// </summary>
        /// <param name="UserNum">传入的会员ID</param>
        /// <returns>返回名称</returns>
        public string GetUidUserNum(int uId)
        {
            string uflg = "找不到用户";
            OleDbParameter param = new OleDbParameter("@Uid", uId);
            string Sql = "Select id,UserNum From " + Pre + "sys_user Where id=@Uid";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    uflg = rdr.Rows[0]["UserNum"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return uflg;
        }

        /// <summary>
        /// 根据用户名获得用户编号
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetUserNameUserNum(string userName)
        {
            string uflg = "0";
            OleDbParameter param = new OleDbParameter("@UserName", userName);
            string Sql = "Select UserNum From " + Pre + "sys_user Where UserName=@UserName";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    uflg = rdr.Rows[0]["UserNum"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return uflg;
        }

        /// <summary>
        /// 根据会员组ID获取编号
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public string GetGidGroupNumber(int gid)
        {
            string uflg = "0";
            OleDbParameter param = new OleDbParameter("@Gid", gid);
            string Sql = "Select GroupNumber From " + Pre + "user_Group Where Id=@Gid";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    uflg = rdr.Rows[0]["GroupNumber"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return uflg;
        }

        /// <summary>
        /// 获取会员组名称
        /// </summary>
        /// <param name="groupNumber">传入的会员组编号</param>
        /// <returns></returns>
        public string GetGroupName(string groupNumber)
        {
            string uflg = "不属于任何组";
            OleDbParameter param = new OleDbParameter("@GroupNumber", groupNumber);
            string Sql = "Select id,GroupName From " + Pre + "user_Group Where GroupNumber=@GroupNumber";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    uflg = rdr.Rows[0]["GroupName"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return uflg;
        }
        /// <summary>
        /// 根据用户编号获得用户组编号
        /// </summary>
        /// <param name="strUserNum"></param>
        /// <returns></returns>
        public string GetUserGroupNumber(string userNum)
        {
            string USQL = "Select UserGroupNumber From " + Pre + "sys_user Where UserNum=@UserNum and SiteID='" + Foosun.Global.Current.SiteID + "'";
            OleDbParameter Param = new OleDbParameter("@UserNum", userNum);
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, USQL, Param));
        }

        /// <summary>
        /// 根据用户组获得用户标志
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public string GetGroupNameFlag(string userNum)
        {
            string uflg = string.Empty;
            OleDbParameter Param = new OleDbParameter("@UserNum", userNum);
            string USQL = "Select UserGroupNumber From " + Pre + "sys_user Where UserNum=@UserNum and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, USQL, Param);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    string Sql = "Select UserFlag From " + Pre + "user_Group Where GroupNumber='" + dt.Rows[0]["UserGroupNumber"].ToString() + "'";
                    DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
                    if (rdr != null)
                    {
                        if (rdr.Rows.Count > 0)
                        {
                            uflg = rdr.Rows[0]["UserFlag"].ToString();
                        }
                    }
                    rdr.Dispose();
                }
                dt.Clear(); dt.Dispose();
            }
            return uflg;
        }

        /// <summary>
        /// 通过用户编号获取会员组名称
        /// </summary>
        /// <param name="userNum">传入的会员编号</param>
        /// <returns></returns>
        public string GetUserGroupName(string userNum)
        {
            string uflg = "找不到用户";
            OleDbParameter Param = new OleDbParameter("@UserNum", userNum);
            string Sql = "Select id,UserGroupNumber From " + Pre + "sys_User Where UserNum=@UserNum";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    string SQL1 = "Select id,GroupName From " + Pre + "user_Group Where GroupNumber='" + rdr.Rows[0]["UserGroupNumber"].ToString() + "'";
                    DataTable gdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
                    if (gdr != null)
                    {
                        if (gdr.Rows.Count > 0) { uflg = gdr.Rows[0]["GroupName"].ToString(); }
                        else { uflg = "找不到会员组"; }
                        gdr.Dispose();
                    }
                    else { uflg = "找不到会员组"; }
                }
                else { uflg = "找不到会员组"; }
            }
            rdr.Dispose();
            return uflg;
        }
        /// <summary>
        /// 通过用户猪编号获取会员组ID
        /// </summary>
        /// <param name="UserNum">传入的会员编号</param>
        /// <returns></returns>
        public string GetIDGroupNumber(string groupNumber)
        {
            string uflg = "0";
            OleDbParameter GroupNumberParam = new OleDbParameter("@GroupNumber", groupNumber);
            string Sql = "Select id From " + Pre + "user_Group Where GroupNumber=@GroupNumber and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, GroupNumberParam);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    uflg = rdr.Rows[0]["Id"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return uflg;
        }


        /// <summary>
        /// 得到G币名称
        /// </summary>
        /// <returns></returns>
        public string GetgPointName()
        {
            string gflg = "风讯币";
            string Sql = "Select GpointName From " + Pre + "sys_PramUser";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["GpointName"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到站点名称
        /// </summary>
        public string SiteName()
        {
            string gflg = "风讯网站内容管理系统";
            string Sql = "Select SiteName From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["SiteName"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到前台版权信息
        /// </summary>
        /// <returns></returns>
        public string SiteCopyRight()
        {
            string gflg = "(c)2011 Foosun Inc. by DotNetCMS v1.0 SP5 Build 110408";
            string Sql = "Select CopyRight From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["CopyRight"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到站点域名
        /// </summary>
        /// <returns></returns>
        public string SiteDomain()
        {
            string gflg = "你没填写域名";
            string Sql = "Select SiteDomain From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["SiteDomain"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }


        /// <summary>
        /// 得到主页模板
        /// </summary>
        /// <returns></returns>
        public string IndexTempletFile()
        {
            string gflg = "/{@dirTemplet}/index.html|index.html";
            string Sql = "Select IndexTemplet,IndexFileName From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["IndexTemplet"].ToString() + "|" + rdr.Rows[0]["IndexFileName"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }



        /// <summary>
        /// 得到其他模板（栏目，内容）
        /// </summary>
        /// <returns></returns>
        public string AllTemplet()
        {
            string gflg = "/{@dirTemplet}/Content/news.html|/{@dirTemplet}/Content/class.html|/{@dirTemplet}/Content/special.html|html";
            string Sql = "Select ReadNewsTemplet,ClassListTemplet,SpecialTemplet,FileEXName From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["ReadNewsTemplet"].ToString() + "|" + rdr.Rows[0]["ClassListTemplet"].ToString() + "|" + rdr.Rows[0]["SpecialTemplet"].ToString() + "|" + rdr.Rows[0]["FileEXName"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到生成方式
        /// </summary>
        /// <returns></returns>
        public int ReadType()
        {
            int gflg = 0;
            string Sql = "Select ReadType From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = int.Parse(rdr.Rows[0]["ReadType"].ToString());
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到站点Email
        /// </summary>
        /// <returns></returns>
        public string SiteEmail()
        {
            string gflg = "service@foosun.cn";
            string Sql = "Select Email From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["Email"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到连接方式
        /// </summary>
        /// <returns></returns>
        public int LinkType()
        {
            int gflg = 0;
            string Sql = "Select LinkType From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = int.Parse(rdr.Rows[0]["LinkType"].ToString());
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 获取审核机制
        /// </summary>
        /// <returns></returns>
        public int CheckInt()
        {
            int gflg = 0;
            string Sql = "Select CheckInt From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = int.Parse(rdr.Rows[0]["CheckInt"].ToString());
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }


        public int CheckNewsTitle()
        {
            int gflg = 0;
            string Sql = "Select CheckNewsTitle From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = int.Parse(rdr.Rows[0]["CheckNewsTitle"].ToString());
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到会员所在组的折扣率
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public double GetDiscount(string userNum)
        {
            double discout = 1;
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string Sql = "Select UserGroupNumber From " + Pre + "sys_user where UserNum=@UserNum";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    string SQL_1 = "Select Discount from " + Pre + "user_Group where GroupNumber='" + rdr.Rows[0]["UserGroupNumber"] + "'";
                    DataTable dt = DbHelper.ExecuteTable(CommandType.Text, SQL_1, null);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            discout = double.Parse(dt.Rows[0]["Discount"].ToString());
                        }
                        dt.Clear(); dt.Dispose();
                    }
                }
                rdr.Clear(); rdr.Dispose();
            }
            return discout;
        }


        public DataTable GetWaterInfo()
        {
            string Sql = "Select PrintWord,Printfontsize,Printfontfamily,Printfontcolor,PrintBTF,PintPicURL,PrintPicsize,PintPictrans,PrintPosition From " + Pre + "sys_parmPrint";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }


        /// <summary>
        /// 得到签名
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public string GetUserChar(string userNum)
        {
            string _STR = "";
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string Sql = "Select Userinfo From " + Pre + "sys_user where UserNum=@UserNum";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    _STR = rdr.Rows[0]["Userinfo"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return _STR;
        }

        /// <summary>
        /// 获取栏目保存路径
        /// </summary>
        /// <returns></returns>
        public string SaveClassFilePath(string siteId)
        {
            string gflg = "/html";
            if (siteId == "0")
            {
                string Sql = "Select SaveClassFilePath From " + Pre + "sys_param";
                DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
                if (rdr != null && rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["SaveClassFilePath"].ToString();
                    rdr.Clear(); rdr.Dispose();
                }
            }
            else
            {
                OleDbParameter param = new OleDbParameter("@siteid", siteId);
                string sqls = "select SaveDirPath,EName from " + Pre + "news_site where ChannelID=@siteid";
                DataTable rdrs = DbHelper.ExecuteTable(CommandType.Text, sqls, param);
                if (rdrs != null && rdrs.Rows.Count > 0)
                {
                    gflg = rdrs.Rows[0]["SaveDirPath"].ToString() + "/" + rdrs.Rows[0]["EName"].ToString() + "/" + Foosun.Config.UIConfig.dirHtml;
                    rdrs.Clear(); rdrs.Dispose();
                }
            }
            return gflg;
        }

        /// <summary>
        /// 获取索引页规则
        /// </summary>
        /// <returns></returns>
        public string SaveIndexPage()
        {
            string gflg = "{@year04}/{@month}-{@day}";
            string Sql = "Select SaveIndexPage From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["SaveIndexPage"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 生成新闻的文件保存路径
        /// </summary>
        /// <returns></returns>
        public string SaveNewsDirPath()
        {
            string gflg = "{@year04}/{@month}-{@day}";
            string Sql = "Select SaveNewsDirPath From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["SaveNewsDirPath"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 生成新闻的文件保存路径
        /// </summary>
        /// <returns></returns>
        public string SaveNewsFilePath()
        {
            string gflg = "{@year04}{@month}{@day}{@hour}{@minute}{@second}";
            string Sql = "Select SaveNewsFilePath From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["SaveNewsFilePath"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到会员默认注册会员组
        /// </summary>
        /// <returns></returns>
        public string GetRegGroupNumber()
        {
            string gflg = "0";
            string Sql = "Select RegGroupNumber From " + Pre + "sys_PramUser";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["RegGroupNumber"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 图片域名服务器
        /// </summary>
        /// <returns></returns>
        public string PicServerDomain()
        {
            string gflg = "";
            string Sql = "Select PicServerDomain From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["PicServerDomain"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 是否独立图片域名服务器
        /// </summary>
        /// <returns></returns>
        public int PicServerTF()
        {
            int gflg = 0;
            string Sql = "Select PicServerTF From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = int.Parse(rdr.Rows[0]["PicServerTF"].ToString());
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 是否允许投稿
        /// </summary>
        /// <returns></returns>
        public int ConstrTF()
        {
            int gflg = 0;
            string Sql = "Select ConstrTF From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = int.Parse(rdr.Rows[0]["ConstrTF"].ToString());
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 得到上传的扩展名
        /// </summary>
        /// <returns></returns>
        public string UpfileType()
        {
            string gflg = "jpg,gif,bmp,ico,rar,zip,jpeg,png,swf|500";
            string Sql = "Select UpfilesType,UpFilesSize From " + Pre + "sys_param";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0)
                {
                    gflg = rdr.Rows[0]["UpfilesType"].ToString() + "|" + rdr.Rows[0]["UpFilesSize"].ToString();
                }
                rdr.Clear(); rdr.Dispose();
            }
            return gflg;
        }

        /// <summary>
        /// 保存日志入库及日志文件
        /// </summary>
        /// <param name="num">标识，0表示写入数据库，1表示写入数据同时写入日志文件</param>
        /// <param name="_num">用户标志，0表示用户，1表示管理员</param>
        /// <param name="userNum">传入的用户编号</param>
        /// <param name="title">日志标题</param>
        /// <param name="content">日志描述</param>
        public void SaveUserAdminLogs(int num, int _num, string userNum, string title, string content)
        {
            using (OleDbConnection cn = new OleDbConnection(DBConfig.CmsConString))
            {
                cn.Open();
                SaveUserAdminLogs(cn, num, _num, userNum, title, content);
            }
        }
        /// <summary>
        /// 保存日志入库及日志文件
        /// </summary>
        /// <param name="cn">已打开的数据库连接对象</param>
        /// <param name="num">标识，0表示写入数据库，1表示写入数据同时写入日志文件</param>
        /// <param name="_num">用户标志，0表示用户，1表示管理员</param>
        /// <param name="userNum">传入的用户编号</param>
        /// <param name="title">日志标题</param>
        /// <param name="content">日志描述</param>
        public void SaveUserAdminLogs(OleDbConnection cn, int num, int _num, string userNum, string title, string content)
        {
            OleDbParameter[] param = new OleDbParameter[4];
            param[3] = new OleDbParameter("@_num", OleDbType.Integer, 4);
            param[3].Value = _num;
            param[2] = new OleDbParameter("@UserNum", OleDbType.VarChar, 15);
            param[2].Value = userNum;
            param[0] = new OleDbParameter("@Title", OleDbType.VarChar, 50);
            param[0].Value = title;
            param[1] = new OleDbParameter("@Content", OleDbType.VarChar);
            param[1].Value = content;

            //string _UserNum = UserNum.Replace("'", "‘");
            //string _Title = Title.Replace("'", "‘");
            //string _Content = Content.Replace("'", "‘");
            string Sql = "insert into " + Pre + "sys_logs (";
            Sql += "title,content,creatTime,IP,usernum,SiteID,ismanage";
            Sql += ") values (";
            Sql += "@Title,@Content,'" + System.DateTime.Now + "','" + Common.Computer.GetIP() + "',@UserNum,'0',@_num )";
            DbHelper.ExecuteNonQuery(cn, CommandType.Text, Sql, param);
            if (num == 1)
            {
                Common.MultipartForm.SaveLogFiles(_num, userNum, title, content);
            }
        }

        /// <summary>
        /// 得到会员组DataTable
        /// </summary>
        /// <returns></returns>
        public IDataReader GetGroupList()
        {
            string Sql = "select id,GroupNumber,GroupName from " + Pre + "user_Group where SiteID='" + Foosun.Global.Current.SiteID + "'";
            return DbHelper.ExecuteReader(CommandType.Text, Sql, null);
        }

        /// <summary>
        /// 得到帮助ID
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public DataTable GetHelpId(string helpId)
        {
            OleDbParameter param = new OleDbParameter("@helpId", helpId);
            string Sql = "Select TitleCN,ContentCN From " + Pre + "sys_Help where HelpID=@helpId";
            DataTable rdr = DbHelper.ExecuteTable(DBConfig.HelpConString, CommandType.Text, Sql, param);
            return rdr;
        }

        /// <summary>
        /// 得到站点列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetselectNewsList()
        {
            string Sql = "Select id,ChannelID,ParentID,CName from " + Pre + "news_site where isRecyle=0 and isLock=0 and IsURL =0 and ParentID='" + Foosun.Global.Current.SiteID + "' order by id desc";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到标签风格
        /// </summary>
        /// <returns></returns>
        public DataTable GetselectLabelList()
        {
            string Sql = "Select id,ClassID,Sname,(Select Count(id) from " + Pre + "sys_LabelStyle where a.ClassId=ClassID and isRecyle=0 and siteID='" + Foosun.Global.Current.SiteID + "') as HasSub  from " + Pre + "sys_styleclass a where isRecyle=0 and siteID='" + Foosun.Global.Current.SiteID + "' order by id desc";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到单个样式的内容
        /// </summary>
        /// <param name="styleID"></param>
        /// <returns></returns>
        public string GetSingleLableStyle(string styleID)
        {
            string Sql = "Select Content from " + Pre + "sys_LabelStyle where styleid='" + styleID + "'";
            try
            {
                return DbHelper.ExecuteScalar(CommandType.Text, Sql, null).ToString();
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 得到标签风格
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public DataTable GetselectLabelList1(string classID)
        {
            OleDbParameter param = new OleDbParameter("@ClassID", classID);
            string Sql = "select ID,styleID,ClassID,StyleName,Description,Content from " + Pre + "sys_LabelStyle where ClassId=@ClassID and siteID='" + Foosun.Global.Current.SiteID + "' order by id desc";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            return rdr;
        }

        /// <summary>
        /// 得到栏目
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IDataReader GetAjaxsNewsList(string parentId)
        {
            OleDbParameter param = new OleDbParameter("@ParentId", parentId);
            string Sql = "Select ClassID,ClassCName,(Select Count(id) from " + Pre + "news_Class where ParentID=a.ClassID and isRecyle=0 and isUrl=0 and isPage=0 and islock=0) as HasSub from " + Pre + "news_Class a where ParentID=@ParentId and isRecyle=0 and isUrl=0 and SiteID='" + Foosun.Global.Current.SiteID + "' and isPage=0 and islock=0 order by OrderID desc,id desc";
            return DbHelper.ExecuteReader(CommandType.Text, Sql, param);
        }

        /// <summary>
        /// 根据栏目得到SiteID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public string GetSiteIDFromClass(string classID)
        {
            string SiteID = "0";
            OleDbParameter param = new OleDbParameter("@ClassID", classID);
            string Sql = "Select SiteID from " + Pre + "news_Class where ClassID=@ClassID";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null && rdr.Rows.Count > 0)
            {
                SiteID = rdr.Rows[0]["SiteID"].ToString();
                rdr.Clear(); rdr.Dispose();
            }
            return SiteID;
        }

        /// <summary>
        /// 得到新闻表
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewsTableIndex()
        {
            string Sql = "select TableName from " + Pre + "sys_NewsIndex";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到专题列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IDataReader GetajaxsspecialList(string parentId)
        {
            OleDbParameter param = new OleDbParameter("@ParentId", parentId);
            string Sql = "Select SpecialID,SpecialCName,(Select Count(id) from " + Pre + "news_special where ParentID=a.SpecialID and isRecyle=0) as HasSub from " + Pre + "news_special a where ParentID=@ParentId and isRecyle=0 and SiteID='" + Foosun.Global.Current.SiteID + "' order by id desc";
            return DbHelper.ExecuteReader(CommandType.Text, Sql, param);
        }


        /// <summary>
        /// 得到栏目列表
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataTable GetClassListPublic(string parentID)
        {
            OleDbParameter param = new OleDbParameter("@ParentID", parentID);
            string Sql = "Select ClassID,ClassCName,ParentID from " + Pre + "news_class where isURL=0 and isLock=0 and isRecyle=0 and isPage<>1 and ParentID=@ParentID and SiteID ='" + Foosun.Global.Current.SiteID + "' order by OrderID desc,Id desc";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            return rdr;
        }

        /// <summary>
        /// 得到专题列表
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataTable GetSpecialListPublic(string parentID)
        {
            OleDbParameter param = new OleDbParameter("@ParentID", parentID);
            string Sql = "Select SpecialID,SpecialCName,ParentID from " + Pre + "news_special where isLock=0 and isRecyle=0 and ParentID=@ParentID and SiteID ='" + Foosun.Global.Current.SiteID + "' order by Id desc";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            return rdr;
        }

        public DataTable GetUploadInfo()
        {
            string Sql = "Select UpfilesType,UpFilesSize From " + Pre + "sys_param";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return dt;
        }

        public DataTable GetGroupUpInfo(string UserNum)
        {
            string UserGroupNumber = "0";
            OleDbParameter param = new OleDbParameter("@UserNum", UserNum);
            string USQL = "select UserGroupNumber from " + Pre + "sys_User where UserNum=@UserNum";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, USQL, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                UserGroupNumber = dt.Rows[0]["UserGroupNumber"].ToString();
                dt.Clear(); dt.Dispose();
            }
            OleDbParameter paramType = new OleDbParameter("@UserGroupNumber", UserGroupNumber);
            string Sql = "select upfileType,upfileSize from " + Pre + "user_Group where GroupNumber=@UserGroupNumber";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, paramType);
        }

        /// <summary>
        /// 得到站点中文名称
        /// </summary>
        /// <param name="siteID">传入的站点编号</param>
        /// <returns>站点名称</returns>
        public string GetChName(string siteID)
        {
            string _Str = "";
            OleDbParameter param = new OleDbParameter("@SiteID", siteID);
            string SQL = "select CName from " + Pre + "news_site where ChannelID=@SiteID";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, SQL, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                _Str = dt.Rows[0]["CName"].ToString();
            }
            return _Str;
        }

        /// <summary>
        /// 得到站点参数
        /// </summary>
        /// <param name="SiteID"></param>
        /// <returns></returns>
        public DataTable GetSiteParam(string SiteID)
        {
            string Sql = "select ClassTemplet,ReadNewsTemplet,SaveFileRule,SaveDirPath,SaveDirRule,PicSavePath,DataLib from " + Pre + "news_site where IsURL=0 and isRecyle=0 and isLock=0 and ChannelID=@ChannelID";
            OleDbParameter Param = new OleDbParameter("@ChannelID", SiteID);
            return DbHelper.ExecuteTable(CommandType.Text, Sql, Param);
        }

        public string GetResultPage(string content, DateTime dateTime, string classID, string eName)
        {
            string _Str = "";
            if (content != string.Empty)
            {
                _Str = content.ToLower();
                //string year02 = ((_DateTime.Year).ToString()).PadRight(2);
                string year02 = dateTime.Year.ToString().Remove(0, 2);
                string year04 = (dateTime.Year).ToString();
                string month = (dateTime.Month).ToString();
                if (dateTime.Month < 10)
                {
                    month = "0" + month;
                }
                string day = (dateTime.Day).ToString();
                if (dateTime.Day < 10)
                {
                    day = "0" + day;
                }
                string hour = (dateTime.Hour).ToString();
                string minute = (dateTime.Minute).ToString();
                string second = (dateTime.Second).ToString();
                _Str = _Str.Replace("{@year02}", year02);
                _Str = _Str.Replace("{@year04}", year04);
                _Str = _Str.Replace("{@month}", month);
                _Str = _Str.Replace("{@day}", day);
                _Str = _Str.Replace("{@second}", second);
                _Str = _Str.Replace("{@minute}", minute);
                _Str = _Str.Replace("{@hour}", hour);
                if (classID == "0") { _Str = _Str.Replace("{@ename}", eName); }
                else { _Str = _Str.Replace("{@ename}", GetClassEName(classID)); }
                if (_Str.IndexOf("{@ram", 0) != -1)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        _Str = _Str.Replace("{@ram" + i + "_0}", Common.Rand.Number(i));
                        _Str = _Str.Replace("{@ram" + i + "_1}", Common.Rand.Str_char(i));
                        _Str = _Str.Replace("{@ram" + i + "_2}", Common.Rand.Str(i));
                    }
                }
            }
            return _Str;
        }

        /// <summary>
        /// 得到英文名称
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public string GetClassEName(string classID)
        {
            string _STR = "";
            OleDbParameter param = new OleDbParameter("@ClassID", classID);
            string Sql = "Select ClassEName From " + Pre + "news_class where ClassID=@ClassID and SiteID ='" + Foosun.Global.Current.SiteID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    _STR = dt.Rows[0]["ClassEName"].ToString();
                }
                dt.Clear(); dt.Dispose();
            }
            return _STR;
        }
        #region 用户登录
        public int GetUserLoginCode()
        {
            string Sql = "Select UserLoginCodeTF From " + Pre + "sys_PramUser";
            object obj = DbHelper.ExecuteScalar(CommandType.Text, Sql, null);
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 得到会员用户积分和G币
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public string GetGIPoint(string userNum)
        {
            string flg = "0|0";
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string Sql = "Select iPoint,gPoint From " + Pre + "sys_User where UserNum=@UserNum";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    flg = dt.Rows[0]["iPoint"].ToString() + "|" + dt.Rows[0]["gPoint"].ToString();
                }
                dt.Clear(); dt.Dispose();
            }
            return flg;
        }
        /// <summary>
        /// 得到魅力值
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public int GetcPoint(string userNum)
        {
            int flg = 0;
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string Sql = "Select cPoint From " + Pre + "sys_User where UserNum=@UserNum";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    flg = int.Parse(dt.Rows[0]["cPoint"].ToString());
                }
                dt.Clear(); dt.Dispose();
            }
            return flg;
        }

        /// <summary>
        /// 得到用户是否允许签名
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public int GetUserUserInfo(string userNum)
        {
            int intflg = 0;
            string UserGroupNumber = "";
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string Usql = "select UserGroupNumber from " + Pre + "sys_User where UserNum=@UserNum";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Usql, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                UserGroupNumber = dt.Rows[0]["UserGroupNumber"].ToString();
                dt.Clear(); dt.Dispose();
            }
            OleDbParameter paramGroup = new OleDbParameter("@UserGroupNumber", UserGroupNumber);
            string SQL = "select CharTF from " + Pre + "user_Group where GroupNumber=@UserGroupNumber";
            DataTable dts = DbHelper.ExecuteTable(CommandType.Text, SQL, paramGroup);
            if (dts != null && dts.Rows.Count > 0)
            {
                intflg = int.Parse(dts.Rows[0]["CharTF"].ToString());
                dts.Clear(); dts.Dispose();
            }
            return intflg;
        }

        #endregion 用户登录

        #region 删除所有用户信息

        public void DelUserAllInfo(string userNum)
        {
            //删除投稿
            OleDbParameter param = new OleDbParameter("@UserNum", userNum);
            string consql = "delete from " + Pre + "user_Constr where UserNum = @UserNum and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, consql, param);
            //投稿分类
            OleDbParameter paramClass = new OleDbParameter("@UserNum", userNum);
            string concsql = "delete from " + Pre + "user_ConstrClass where UserNum = @UserNum";
            DbHelper.ExecuteNonQuery(CommandType.Text, concsql, paramClass);
            //支付记录
            OleDbParameter paramPay = new OleDbParameter("@UserNum", userNum);
            string constrPaysql = "delete from " + Pre + "user_constrPay where UserNum =@UserNum";
            DbHelper.ExecuteNonQuery(CommandType.Text, constrPaysql, paramPay);
        }
        #endregion

        #region 删除所有的频道资料
        public void DelSiteAllInfo(string siteID)
        {

        }
        #endregion 删除所有的频道资料

        #region 删除所有的新闻/静态文件
        public void DelNewsAllInfo(string siteID)
        {

        }
        #endregion 删除所有的新闻
    }
}

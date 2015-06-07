using System;
using System.Collections.Generic;
using System.Text;
using Foosun.IDAL;
using Foosun.DALFactory;
using System.Data;

namespace Foosun.CMS
{
    public class RootPublic
    {
        private readonly IRootPublic dal = DataAccess.CreaterootPublic();

        public RootPublic()
        {
           
        }
        /// <summary>
        /// 得到站点ID是否存在
        /// </summary>
        /// <returns></returns>
        public int GetSiteID(string SiteID)
        {
            return dal.GetSiteID(SiteID);
        }

        /// <summary>
        /// 根据用户编号获取用户名
        /// </summary>
        /// <param name="strUserNum"></param>
        /// <returns></returns>
        public string GetUserName(string strUserNum)
        {
            return dal.GetUserName(strUserNum);
        }

        /// <summary>
        /// 根据用户编号获取用户自动编号
        /// </summary>
        /// <param name="strUserNum"></param>
        /// <returns></returns>
        public int GetUserNameByUId(string strUserNum)
        {
            return dal.GetUserNameByUId(strUserNum);
        }

        /// <summary>
        /// 根据用户ID获取用户编号
        /// </summary>
        /// <param name="strUserNum"></param>
        /// <returns></returns>
        public string GetUidUserNum(int Uid)
        {
            return dal.GetUidUserNum(Uid);
        }

        /// <summary>
        /// 根据用户名获取用户编号
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public string GetUserNameUserNum(string UserName)
        {
            return dal.GetUserNameUserNum(UserName);
        }

        public string GetGidGroupNumber(int gid)
        {
            return dal.GetGidGroupNumber(gid);
        }

        /// <summary>
        /// 根据会员组编号获取会员组名称
        /// </summary>
        /// <param name="strGroupNumber"></param>
        /// <returns></returns>
        public string GetGroupName(string strGroupNumber)
        {
            return dal.GetGroupName(strGroupNumber);
        }

        /// <summary>
        /// 获取会员组的标志
        /// </summary>
        /// <param name="strGroupNumber"></param>
        /// <returns></returns>
        public string GetGroupNameFlag(string UserNum)
        {
            return dal.GetGroupNameFlag(UserNum);
        }
        /// <summary>
        /// 根据会员编号获取会员组名称
        /// </summary>
        /// <param name="strUserNum"></param>
        /// <returns></returns>
        public string GetUserGroupName(string strUserNum)
        {
            return dal.GetUserGroupName(strUserNum);
        }

        /// <summary>
        /// 根据用户编号获得用户组编号
        /// </summary>
        /// <param name="strUserNum"></param>
        /// <returns></returns>
        public string GetUserGroupNumber(string strUserNum)
        {
            return dal.GetUserGroupNumber(strUserNum);
        }

        /// <summary>
        /// 根据会员组编号获取会员组ID
        /// </summary>
        /// <param name="strUserNum"></param>
        /// <returns></returns>
        public string GetIDGroupNumber(string GroupNumber)
        {
            return dal.GetIDGroupNumber(GroupNumber);
        }

        /// <summary>
        /// 获取G币名称
        /// </summary>
        /// <returns></returns>
        public string GetgPointName()
        {
            return dal.GetgPointName();
        }

        /// <summary>
        /// 获取站点名称
        /// </summary>
        /// <returns></returns>
        public string SiteName()
        {
            return dal.SiteName();
        }

        /// <summary>
        /// 获取版权信息
        /// </summary>
        /// <returns></returns>
        public string SiteCopyRight()
        {
            return dal.SiteCopyRight();
        }

        /// <summary>
        /// 获取站点域名
        /// </summary>
        /// <returns></returns>
        public string SiteDomain()
        {
            return dal.SiteDomain();
        }

        /// <summary>
        /// 获取站点首页模板,首页文件名
        /// </summary>
        /// <returns></returns>
        public string IndexTempletFile()
        {
            return dal.IndexTempletFile();
        }

        /// <summary>
        /// 获取默认的默认模板及扩展名
        /// </summary>
        /// <returns></returns>
        public string allTemplet()
        {
            return dal.AllTemplet();
        }

        /// <summary>
        /// 前台页面显示方式，0为静态，1为动态
        /// </summary>
        /// <returns></returns>
        public int ReadType()
        {
            return dal.ReadType();
        }

        /// <summary>
        /// 获得站点电子邮件
        /// </summary>
        /// <returns></returns>
        public string SiteEmail()
        {
            return dal.SiteEmail();
        }

        /// <summary>
        /// 获取连接方式 0相对路径，1绝对路径
        /// </summary>
        /// <returns></returns>
        public int LinkType()
        {
            return dal.LinkType();
        }

        /// <summary>
        /// 栏目保存路径
        /// </summary>
        /// <returns></returns>
        public string SaveClassFilePath(string siteid)
        {
            return dal.SaveClassFilePath(siteid);
        }

        /// <summary>
        /// 生成索引页规则
        /// </summary>
        /// <returns></returns>
        public string SaveIndexPage()
        {
            return dal.SaveIndexPage();
        }

        /// <summary>
        /// 生成新闻的命名规则
        /// </summary>
        /// <returns></returns>
        public string SaveNewsFilePath()
        {
            return dal.SaveNewsFilePath();
        }

        /// <summary>
        /// 生成新闻的文件保存路径
        /// </summary>
        /// <returns></returns>
        public string SaveNewsDirPath()
        {
            return dal.SaveNewsDirPath();
        }

        public string GetRegGroupNumber()
        {
            return dal.GetRegGroupNumber();
        }

        /// <summary>
        /// 是否独立图片服务器域名
        /// </summary>
        /// <returns></returns>
        public int PicServerTF()
        {
            return dal.PicServerTF();
        }

        /// <summary>
        /// 图片服务器域名
        /// </summary>
        /// <returns></returns>
        public string PicServerDomain()
        {
            return dal.PicServerDomain();
        }

        /// <summary>
        /// 是否允许投稿
        /// </summary>
        /// <returns></returns>
        public int ConstrTF()
        {
            return dal.ConstrTF();
        }

        /// <summary>
        /// 获取审核机制
        /// </summary>
        /// <returns></returns>
        public int CheckInt()
        {
            return dal.CheckInt();
        }

        /// <summary>
        /// 新闻标题是否允许重复
        /// </summary>
        /// <returns></returns>
        public int CheckNewsTitle()
        {
            return dal.CheckNewsTitle();
        }

        /// <summary>
        /// 得到上传扩展名
        /// </summary>
        /// <returns></returns>
        public string UpfileType()
        {
            return dal.UpfileType();
        }
        /// <summary>
        /// 得到会员所在组的折扣率
        /// </summary>
        /// <param name="UserNum"></param>
        /// <returns></returns>
        public double GetDiscount(string UserNum)
        {
            return dal.GetDiscount(UserNum);
        }

        /// <summary>
        /// 得到水印信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetWaterInfo()
        {
            return dal.GetWaterInfo();
        }

        public string GetUserChar(string UserNum)
        {
            return dal.GetUserChar(UserNum);
        }
        /// <summary>
        /// 保存日志入库及日志文件
        /// </summary>
        /// <param name="num">标识，0表示写入数据库，1表示写入数据同时写入日志文件</param>
        /// <param name="_num">用户标志，0表示用户，1表示管理员</param>
        /// <param name="UserNum">传入的用户编号</param>
        /// <param name="Title">日志标题</param>
        /// <param name="Content">日志描述</param>
        public void SaveUserAdminLogs(int num, int _num, string UserNum, string Title, string Content)
        {
            dal.SaveUserAdminLogs(num, _num, UserNum, Title, Content);
        }
        /// <summary>
        /// 取得用户组列表
        /// </summary>
        /// <returns></returns>
        public IDataReader GetGroupList()
        {
            return dal.GetGroupList();
        }


        /// <summary>
        /// 得到Help信息
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public DataTable GetHelpId(string helpId)
        {
            DataTable dt = dal.GetHelpId(helpId);
            return dt;
        }


        /// <summary>
        /// 选择频道
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public DataTable GetselectNewsList()
        {
            DataTable dt = dal.GetselectNewsList();
            return dt;
        }

        /// <summary>
        /// 选择标签样式分类
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public DataTable GetselectLabelList()
        {
            DataTable dt = dal.GetselectLabelList();
            return dt;
        }
        /// <summary>
        /// 得到单个样式内容
        /// </summary>
        /// <param name="StyleID"></param>
        /// <returns></returns>
        public string GetSingleLableStyle(string StyleID)
        {
            string str = dal.GetSingleLableStyle(StyleID);
            return str;
        }
        /// <summary>
        /// 选择标签样式
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public DataTable GetselectLabelList1(string ClassID)
        {
            DataTable dt = dal.GetselectLabelList1(ClassID);
            return dt;
        }

        /// <summary>
        /// 使用ajax获取栏目
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public IDataReader GetAjaxsNewsList(string ParentID)
        {
            return dal.GetAjaxsNewsList(ParentID);
        }


        /// <summary>
        /// 得到新闻表
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public DataTable GetNewsTableIndex()
        {
            DataTable dt = dal.GetNewsTableIndex();
            return dt;
        }

        /// <summary>
        /// 使用ajax获取专题
        /// </summary>
        /// <param name="helpId"></param>
        /// <returns></returns>
        public IDataReader GetajaxsspecialList(string ParentID)
        {
            return dal.GetajaxsspecialList(ParentID);
        }

        /// <summary>
        /// 根据栏目得到SiteID
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public string GetSiteIDFromClass(string ClassID)
        {
            return dal.GetSiteIDFromClass(ClassID);
        }

        /// <summary>
        /// 得到栏目列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetClassListPublic(string ParentID)
        {
            DataTable dt = dal.GetClassListPublic(ParentID);
            return dt;
        }

        /// <summary>
        /// 得到专题列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetSpecialListPublic(string ParentID)
        {
            DataTable dt = dal.GetSpecialListPublic(ParentID);
            return dt;
        }

        public string GetResultPage(string _Content, DateTime _DateTime, string ClassID, string EName)
        {
            return dal.GetResultPage(_Content, _DateTime, ClassID, EName);
        }

        /// <summary>
        /// 得到某个栏目的英文名称
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public string GetClassEName(string ClassID)
        {
            return dal.GetClassEName(ClassID);
        }

        #region 会员登陆
        /// <summary>
        /// 判断登陆是否需要验证码.
        /// </summary>
        /// <returns></returns>
        public int GetUserLoginCode()
        {
            return dal.GetUserLoginCode();
        }

        /// <summary>
        /// 得到会员用户积分和G币
        /// </summary>
        /// <param name="UserNum"></param>
        /// <returns></returns>
        public string GetGIPoint(string UserNum)
        {
            return dal.GetGIPoint(UserNum);
        }
        /// <summary>
        /// 得到用户魅力值
        /// </summary>
        /// <param name="UserNum"></param>
        /// <returns></returns>
        public int GetcPoint(string UserNum)
        {
            return dal.GetcPoint(UserNum);
        }

        /// <summary>
        /// 得到会员的上传信息
        /// </summary>
        /// <param name="UserNum"></param>
        /// <returns></returns>
        public DataTable GetGroupUpInfo(string UserNum)
        {
            DataTable dt = dal.GetGroupUpInfo(UserNum);
            return dt;
        }

        /// <summary>
        /// 得到用户签名
        /// </summary>
        /// <param name="UserNum"></param>
        /// <returns></returns>
        public int GetUserUserInfo(string UserNum)
        {
            return dal.GetUserUserInfo(UserNum);
        }

        #endregion 会员登陆

        public DataTable GetUploadInfo()
        {
            DataTable dt = dal.GetUploadInfo();
            return dt;
        }
        /// <summary>
        /// 得到站点中文名称
        /// </summary>
        /// <param name="SiteID">传入的站点编号</param>
        /// <returns>站点名称</returns>
        public string GetChName(string siteId)
        {
            return dal.GetChName(siteId);
        }

        public DataTable GetSiteParam(string SiteID)
        {
            return dal.GetSiteParam(SiteID);
        }
    }
}

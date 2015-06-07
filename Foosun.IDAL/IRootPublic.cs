using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Foosun.IDAL
{
    public interface IRootPublic
    {
        #region 接口函数
        int GetSiteID(string SiteID);
        string GetUserName(string UserNum);
        int GetUserNameByUId(string UserNum);
        string GetUserNameUserNum(string UserName);
        string GetGroupName(string GroupNumber);
        string GetUserGroupName(string UserNum);
        string GetIDGroupNumber(string GroupNumber);
        string GetRegGroupNumber();
        string GetgPointName();
        string SiteName();
        string SiteCopyRight();
        string SiteDomain();
        string IndexTempletFile();
        string AllTemplet();
        int ReadType();
        string SiteEmail();
        string GetGidGroupNumber(int Gid);
        int LinkType();
        int CheckInt();
        int CheckNewsTitle();
        string SaveClassFilePath(string siteid);
        string SaveIndexPage();
        int PicServerTF();
        string SaveNewsFilePath();
        string SaveNewsDirPath();
        string PicServerDomain();
        string GetUidUserNum(int Uid);
        string GetGroupNameFlag(string UserNum);
        double GetDiscount(string UserNum);
        string GetUserChar(string UserNum);
        int ConstrTF();
        string UpfileType();
        IDataReader GetGroupList();
        DataTable GetHelpId(string helpId);
        DataTable GetselectNewsList();
        DataTable GetselectLabelList();
        string GetSingleLableStyle(string StyleID);
        DataTable GetselectLabelList1(string ClassID);
        IDataReader GetAjaxsNewsList(string ParentID);
        string GetSiteIDFromClass(string ClassID);
        DataTable GetNewsTableIndex();
        IDataReader GetajaxsspecialList(string ParentID);
        DataTable GetClassListPublic(string ParentID);
        DataTable GetSpecialListPublic(string ParentID);
        DataTable GetUploadInfo();
        DataTable GetGroupUpInfo(string UserNum);
        DataTable GetWaterInfo();
        void SaveUserAdminLogs(int num, int _num, string UserNum, string Title, string Content);
        string GetResultPage(string _Content, DateTime _DateTime, string ClassID, string EName);
        string GetClassEName(string ClassID);
        string GetUserGroupNumber(string strUserNum);
        int GetUserLoginCode();
        string GetGIPoint(string UserNum);
        int GetcPoint(string UserNum);
        string GetChName(string SiteID);
        int GetUserUserInfo(string UserNum);
        void DelUserAllInfo(string UserNum);
        void DelSiteAllInfo(string SiteID);
        void DelNewsAllInfo(string NewsID);
        DataTable GetSiteParam(string SiteID);
        #endregion 接口函数
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Foosun.Model;

public partial class comment : Foosun.PageBasic.BasePage
{
    protected string newLine = "\r\n";
    protected string str_dirMana = Foosun.Config.UIConfig.dirDumm;
    protected string str_Templet = Foosun.Config.UIConfig.dirTemplet;  //获取模板路径
    public static string InstallDir = "{$InstallDir}";
    public static string TempletDir = "{$TempletDir}";
    private static string HiddenNewsID = null;
    Foosun.CMS.News news = new Foosun.CMS.News();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        string GetRount = Request.QueryString["commCount"];
        string sNewsID = Request.QueryString["id"];
        string Todays = Request.QueryString["Today"];

        if (GetRount != null && GetRount != string.Empty && sNewsID != null && sNewsID != string.Empty)
        {
            Foosun.CMS.News rd = new Foosun.CMS.News();
            Response.Write(rd.GetCommCounts(sNewsID.ToString(), Todays.ToString()));
            Response.End();
        }
        else
        {
            CommentOp();
        }
    }

    /// <summary>
    /// 操作列表
    /// </summary>
    protected void CommentOp()
    {
        string CommentType = Request.QueryString["CommentType"];

        switch (CommentType)
        {
            case "AddComment":
                AddComment(0);
                break;
            case "GetCommentList":
                GetCommentList(0, 0);
                break;
            case "GetAddCommentForm":
                Response.Write("Suc$$$" + GetAddCommentForm(CommentType));
                Response.End();
                break;
            case "LoginOut":
                LoginOut();
                break;
            case "getlist":
                GetCommentList(1, 1);
                break;
        }
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="NewsID"></param>

    /// <summary>
    /// 添加评论
    /// </summary>
    protected void AddComment(int num)
    {
        string str_UserNum = Request.QueryString["UserNum"];
        string str_UserPwd = Request.QueryString["UserPwd"];
        string str_NewsID = Common.Input.Filter(Request.QueryString["id"]);
        if (string.IsNullOrEmpty(str_NewsID))
        {
            str_NewsID = HiddenNewsID;
        }
        string str_IsQID = Common.Input.Filter(Request.QueryString["IsQID"]);
        string str_Content = Common.Input.ToHtml(Request.QueryString["Content"]).Replace("?", "？").Replace("$$$", "");
        string SiteID = "0";
        string gChID = Request.QueryString["ChID"];
        int ChID = 0;
        if (gChID != string.Empty && gChID != null)
        {
            ChID = int.Parse(gChID.ToString());
        }
        Foosun.CMS.sys sys = new Foosun.CMS.sys();
        if (str_Content.Length > 200 || str_Content.Length < 2)
        {
            Response.Write("ERR$$$评论内容不能大于200字符，小于2个字符!");
            Response.End();
        }
        string str_commtype = Request.QueryString["commtype"];
        if (str_UserNum == "Guest")
        {
            str_UserNum = "匿名";
            DataTable dt = sys.UserPram();
            if (dt != null)
            {
                if (dt.Rows[0]["UnRegCommTF"].ToString() != "1")
                {
                    Response.Write("ERR$$$系统不允许匿名评论!");
                    Response.End();
                }
            }
            else
            {
                Response.Write("ERR$$$系统参数错误,!");
                Response.End();
            }
        }
        else
        {
            if (str_UserNum.ToLower() != "guest" || str_UserNum != "匿名")
            {
                if (Validate_Session())
                {
                    str_UserNum = Foosun.Global.Current.UserName;
                    SiteID = Foosun.Global.Current.SiteID;
                }
                else
                {
                    GlobalUserInfo info;
                    EnumLoginState state = _UserLogin.PersonLogin(str_UserNum, str_UserPwd, out info);
                    if (state == Foosun.Model.EnumLoginState.Succeed)
                    {
                        Foosun.Global.Current.Set(info);
                        str_UserNum = Foosun.Global.Current.UserName;
                        SiteID = Foosun.Global.Current.SiteID;
                    }
                    else
                    {
                        Response.Write("ERR$$$帐号或密码错误!");
                        Response.End();
                    }
                }
            }
            else
            {
                if (Validate_Session())
                {
                    str_UserNum = Foosun.Global.Current.UserName;
                    SiteID = Foosun.Global.Current.SiteID;
                }
            }
        }
        Foosun.Model.Comment ci = new Foosun.Model.Comment();
        ci.Id = 0;
        ci.Commid = "";
        ci.InfoID = str_NewsID;
        ci.APIID = "0";
        ci.DataLib = Foosun.Config.UIConfig.dataRe + "news";
        ci.Title = "";
        ci.Content = str_Content;
        ci.creatTime = DateTime.Now;
        ci.IP = Request.ServerVariables["REMOTE_ADDR"];
        ci.ChID = ChID;
        if (str_IsQID != null && str_IsQID != "")
            ci.QID = str_IsQID;
        else
            ci.QID = "";
        ci.UserNum = str_UserNum;
        ci.isRecyle = 0;
        int islocks = 0;
        DataTable isl = sys.UserPram();
        if (isl != null && isl.Rows.Count > 0)
        {
            if (Common.Input.IsInteger(isl.Rows[0]["CommCheck"].ToString()))
            {
                islocks = int.Parse(isl.Rows[0]["CommCheck"].ToString());
            }
            isl.Clear(); isl.Dispose();
        }
        ci.islock = islocks;
        ci.OrderID = 0;
        ci.GoodTitle = 0;
        ci.isCheck = 0;
        ci.SiteID = SiteID;
        ci.commtype = int.Parse(str_commtype.ToString());

        Foosun.CMS.News news = new Foosun.CMS.News();
        if (news.AddComment(ci) == 1)
        {
            if (islocks == 1)
            {
                Response.Write("ERR$$$发表评论成功，但需要审核!");
            }
            else
            {
                string gCommentType = Request.QueryString["CommentType"];
                if (gCommentType == "getlist")
                {
                    Response.Write("Suc$$$" + CommentList(num, 1));
                }
                else
                {
                    Response.Write("Suc$$$" + CommentList(num, 0));
                }
            }
        }
        else
        {
            Response.Write("ERR$$$发表评论失败!");
        }
        Response.End();
    }

    /// <summary>
    /// 退出登录
    /// </summary>
    protected void LoginOut()
    {
        Logout();
        Response.Write("Suc$$$" + GetAddCommentForm(Request.QueryString["CommentType"]));
        Response.End();
    }

    /// <summary>
    /// 输出评论列表
    /// </summary>
    protected void GetCommentList(int num, int isList)
    {
        if (!string.IsNullOrEmpty(Common.Input.Filter(Request.QueryString["id"])))
            HiddenNewsID = Common.Input.Filter(Request.QueryString["id"]);
        Response.Write(CommentList(num, isList));
        Response.End();
    }

    /// <summary>
    /// 取得评论列表
    /// </summary>
    /// <returns></returns>
    protected string CommentList(int num, int isList)
    {
        string NewsID = Common.Input.Filter(Request.QueryString["id"]);
        if (string.IsNullOrEmpty(NewsID))
            NewsID = HiddenNewsID;
        string showdiv = Request.QueryString["showdiv"];
        string gChID = Request.QueryString["ChID"];
        int ChID = 0;
        if (gChID != string.Empty && gChID != null)
        {
            ChID = int.Parse(gChID.ToString());
        }
        string CommentTemplet = Foosun.Publish.General.ReadHtml(GetCommentTemplet());
        string str_Clist = "";
        string str_ClistPage = "";
        if (num == 1)
        {
            CommentTemplet = Foosun.Publish.General.ReadHtml(getCommentContentTemplet());
        }
        if (NewsID != "" && NewsID != null)
        {

            DataTable dt = news.GetCommentList(NewsID);

            if (dt != null && dt.Rows.Count > 0)
            {
                string curPage = Request.QueryString["page"];    //当前页码
                int pageSize = 10;

                if (Common.Input.IsInteger(Foosun.Config.UIConfig.commperPageNum))
                {
                    pageSize = int.Parse(Foosun.Config.UIConfig.commperPageNum);
                }

                int page = 0;                     //每页显示数


                if (curPage == "" || curPage == null || curPage == string.Empty) { page = 1; }
                else
                {
                    try { page = int.Parse(curPage); }
                    catch
                    {
                        page = 0;
                    }
                }
                int i, j;
                int Cnt = dt.Rows.Count;

                int pageCount = Cnt / pageSize;
                if (Cnt % pageSize != 0) { pageCount++; }
                if (page > pageCount) { page = pageCount; }
                if (page < 1) { page = 1; }

                bool b_T = false; bool b_P = true; bool b_title = false; bool b_stat = false; bool b_post = false; bool p_list = false;
                if (CommentTemplet.IndexOf("{#Page_CommTitle}") > -1) { b_T = true; }
                if (num == 1)
                {
                    if (CommentTemplet.IndexOf("{#Page_PageTitle}") > -1) { b_title = true; }
                    if (CommentTemplet.IndexOf("{#Page_CommStat}") > -1) { b_stat = true; }
                    if (CommentTemplet.IndexOf("{#Page_PostComm}") > -1) { b_post = true; }
                    if (CommentTemplet.IndexOf("{#Page_NewsURL}") > -1) { p_list = true; }
                }
                #region 循环条件
                string goodTitle = "";
                for (i = (page - 1) * pageSize, j = 1; i < Cnt && j <= pageSize; i++, j++)
                {
                    int k = Cnt;
                    int k1 = 0;
                    string kfool = "";
                    if (page == 1)
                        k = i + 1;
                    else
                        k = ((page - 1) * pageSize) + j;
                    if (k < 10)
                    {
                        k1 = 0 + (Cnt - k);
                    }
                    else
                    {
                        k1 = (Cnt - k);
                    }
                    if ((k1 + 1) < 10)
                    {
                        kfool = "0" + (k1 + 1).ToString();
                    }
                    else
                    {
                        kfool = (k1 + 1).ToString();
                    }
                    if (b_T)//显示标题
                    {
                        string str_UserName = dt.Rows[i]["UserNum"].ToString();
                        string IPstr = dt.Rows[i]["IP"].ToString();
                        string TmpIP1 = "";
                        string TmpIP = (IPstr.Remove(IPstr.LastIndexOf(".")));
                        TmpIP1 = "ip：" + TmpIP.Remove(TmpIP.LastIndexOf(".")) + ".*.*";
                        if (dt.Rows[i]["GoodTitle"].ToString() == "1")
                        {
                            goodTitle = "<img alt=\"精华评论\" src=\"" + Common.Public.GetSiteDomain() + "/sysImages/normal/best.jpg\" border=\"0\" />&nbsp;";
                        }
                        string commtypes = commtypes = "<img alt=\"中立\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/zhichi.gif\" border=\"0\">";
                        string commtype = dt.Rows[i]["commtype"].ToString();
                        switch (commtype)
                        {
                            case "0":
                                commtypes = "<img alt=\"支持\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/zhichi.gif\" border=\"0\">";
                                break;
                            case "1":
                                commtypes = "<img alt=\"高兴\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/gaoxing.gif\" border=\"0\">";
                                break;
                            case "2":
                                commtypes = "<img alt=\"震惊\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/zhenjing.gif\" border=\"0\">";
                                break;
                            case "3":
                                commtypes = "<img alt=\"愤怒\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/fennu.gif\" border=\"0\">";
                                break;
                            case "4":
                                commtypes = "<img alt=\"无聊\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/wuliao.gif\" border=\"0\">";
                                break;
                            case "5":
                                commtypes = "<img alt=\"无奈\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/wunai.gif\" border=\"0\">";
                                break;
                            case "6":
                                commtypes = "<img alt=\"谎言\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/huangyan.gif\" border=\"0\">";
                                break;
                            case "7":
                                commtypes = "<img alt=\"枪稿\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/qianggao.gif\" border=\"0\">";
                                break;
                            case "8":
                                commtypes = "<img alt=\"不解\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/bujie.gif\" border=\"0\">";
                                break;
                            case "9":
                                commtypes = "<img alt=\"标题党\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/biaotidang.gif\" border=\"0\">";
                                break;
                        }

                        if (str_UserName != "匿名")
                        {
                            str_UserName = "" + commtypes + "<a href=\"" + Common.Public.GetSiteDomain() + "/" + Foosun.Config.UIConfig.dirUser + "/showuser-" + dt.Rows[i]["UserNum"].ToString() + ".aspx\" target=\"_blank\">" + dt.Rows[i]["UserNum"].ToString() + "</a>";
                        }
                        else
                        {
                            str_UserName = "" + commtypes + "<span class=\"comuser\">网 友</span>";
                        }
                        str_Clist += "<li>" + "<div class=\"com\">" + "<em>" + kfool + "楼</em>" + str_UserName;
                        string content = "";
                        if (!dt.Rows[i].IsNull("QID") && dt.Rows[i]["QID"].ToString() != "")
                        {
                            content += GetQIDInfo(dt, dt.Rows[i]["Commid"].ToString(), dt.Rows[i]["UserNum"].ToString());
                        }
                        else
                        {
                            string str_Content = goodTitle + dt.Rows[i]["Content"].ToString();
                            string Commfiltrchar = "";
                            Foosun.CMS.sys sd = new Foosun.CMS.sys();
                            DataTable sds = sd.UserPram();
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                Commfiltrchar = sds.Rows[0]["Commfiltrchar"].ToString();
                                if (Commfiltrchar.IndexOf(",") > -1)
                                {
                                    string[] CommfiltrcharARR = Commfiltrchar.Split(',');
                                    for (int m = 0; m < CommfiltrcharARR.Length; m++)
                                    {
                                        str_Content = str_Content.Replace(CommfiltrcharARR[m], "***");
                                    }
                                }
                                sds.Clear(); sds.Dispose();
                            }
                            content += "<p>" + str_Content + "</p>\r";
                        }
                        str_Clist += "<span class=\"data\">" + dt.Rows[i]["creatTime"].ToString() + "</span>" + newLine + "<span class=\"ip\">" + TmpIP1 + "</span>" + newLine + "</div>" + "<div class=\"con\">" + content + "</div></li>" + newLine;

                    }
                }
                #endregion 循环条件
                string str_CPage = "";
                if (b_P) //显示分页
                {
                    str_CPage += "<div class=\"pagecon\">";
                    if (num == 1)
                    {
                        str_CPage += ShowPageContent(NewsID, Common.Public.GetSiteDomain(), page, Cnt, pageCount) + newLine;
                    }
                    else
                    {
                        str_CPage += ShowPage(NewsID, page, Cnt, pageCount) + newLine;
                    }
                    str_CPage += "</div>\r";
                }

                CommentTemplet = CommentTemplet.Replace("{#Page_Commidea}", "");
                str_ClistPage = "<div class=\"commcon\"><ul>" + str_Clist + "</ul>" + "</div>";
                CommentTemplet = CommentTemplet.Replace("{#Page_CommTitle}", "<div id=\"CommentlistPage\" class=\"Commentlist\">" + newLine + str_ClistPage + newLine + newLine + "</div>");
                CommentTemplet = CommentTemplet.Replace("{#Page_CommPages}", str_CPage);
                string str_PageTitle = "";
                string str_PageTitle1 = "";
                if (num == 1)
                {
                    if (b_title || p_list)
                    {
                        IDataReader nd = news.GetNewsInfo(NewsID, ChID);
                        string NewsUrl = "";
                        if (nd.Read())
                        {
                            IDataReader CD = news.GetNewsInfo(nd["ClassID"].ToString(), ChID);
                            if (CD.Read())
                            {
                                if (p_list)
                                {
                                    if (ChID != 0)
                                    {
                                        NewsUrl = getCHInfoURL(ChID, int.Parse(nd["isDelPoint"].ToString()), int.Parse(nd["id"].ToString()), CD["SavePath"].ToString(), nd["SavePath"].ToString(), nd["FileName"].ToString());
                                        str_PageTitle += "<a href=\"" + NewsUrl + "\">" + nd["Title"].ToString() + "</a>";
                                    }
                                    else
                                    {
                                        NewsUrl = getNewsURL(nd["isDelPoint"].ToString(), nd["NewsID"].ToString(), nd["savePath"].ToString(), CD["SavePath"].ToString() + "/" + CD["SaveClassframe"].ToString(), nd["FileName"].ToString(), nd["FileEXName"].ToString());
                                        str_PageTitle += "<a href=\"" + NewsUrl + "\">" + nd["NewsTitle"].ToString() + "</a>";
                                    }
                                    CommentTemplet = CommentTemplet.Replace("{#Page_NewsURL}", str_PageTitle);
                                }
                                if (ChID != 0)
                                {
                                    str_PageTitle1 += nd["Title"].ToString();
                                }
                                else
                                {
                                    str_PageTitle1 += nd["NewsTitle"].ToString();
                                }
                                CommentTemplet = CommentTemplet.Replace("{#Page_PageTitle}", str_PageTitle1);
                            }
                            else
                            {
                                CommentTemplet = CommentTemplet.Replace("{#Page_NewsURL}", nd["NewsTitle"].ToString());
                                CommentTemplet = CommentTemplet.Replace("{#Page_PageTitle}", nd["NewsTitle"].ToString());
                            }
                            CD.Close();
                        }
                        else
                        {
                            CommentTemplet = CommentTemplet.Replace("{#Page_NewsURL}", "");
                            CommentTemplet = CommentTemplet.Replace("{#Page_PageTitle}", "");
                        }
                        nd.Close();
                    }
                    if (b_stat)
                    {
                        CommentTemplet = CommentTemplet.Replace("{#Page_CommStat}", "共" + Cnt + "条 显示" + pageSize + "条 ");
                    }
                    if (b_post)
                    {
                        if (num == 1)
                        {
                            string PostCommstr = GetAddCommentForm(Request.QueryString["CommentType"]);
                            CommentTemplet = CommentTemplet.Replace("{#Page_PostComm}", PostCommstr);
                        }
                        else
                        {
                            CommentTemplet = CommentTemplet.Replace("{#Page_PostComm}", "");
                        }
                    }
                }
                dt.Clear(); dt.Dispose();
            }
            else
            {
                string returnstr = "";
                if (num == 1)
                {
                    returnstr = ",<a href=\"javascript:history.back();\">返回</a>";
                }
                CommentTemplet = "<div id=\"CommentlistPage\" class=\"Commentlist\">当前没有评论信息" + returnstr + "</div>";
            }
        }
        else
        {
            CommentTemplet = "<div style=\"width:100%;\">错误的参数</div>\r";
        }
        string getajaxJS = "<script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.Public.GetSiteDomain() + "/Scripts/jquery.js\"></script>\r\n";
        getajaxJS += "<script language=\"javascript\" type=\"text/javascript\" src=\"" + Common.Public.GetSiteDomain() + "/Scripts/jspublick.js\"></script>\r\n";
        getajaxJS += "\r\n<!--Created by " + Foosun.Config.verConfig.Productversion + " For Foosun Inc. Published at " + DateTime.Now + "-->\r\n";
        string getContent = string.Empty;
        if (isList == 1)
        {
            if (Regex.Match(CommentTemplet, @"\</head\>[\s\S]*\<body", RegexOptions.IgnoreCase | RegexOptions.Compiled).Success)
            {
                getContent = Regex.Replace(CommentTemplet, "<body", getajaxJS + "<body", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            }
            else
            {
                getContent = getajaxJS + CommentTemplet;
            }
        }
        else
        {
            getContent = CommentTemplet;
        }
        if (showdiv != null && showdiv != string.Empty)
        {
            getContent = str_ClistPage;
        }
        getContent = (getContent.Replace(InstallDir, Common.Public.GetSiteDomain())).Replace(TempletDir, str_Templet);
        return getContent;
    }

    /// <summary>
    /// 获取引用的评论
    /// </summary>
    /// <param name="dt">数据表</param>
    /// <param name="Commid">评论编号</param>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    protected string GetQIDInfo(DataTable dt, string Commid, string UserName)
    {
        string str_QID = "";
        DataRow[] row = dt.Select("Commid='" + Commid + "'");
        if (row.Length == 1)
        {
            str_QID += "<span>" + UserName + "引用了：" + dt.Rows[0]["UserNum"].ToString() + "</span>\r";
            str_QID += "<br />\r";
            str_QID += "<span>" + dt.Rows[0]["Content"].ToString() + "</span>\r";
        }
        return str_QID;
    }

    /// <summary>
    /// 得到评论表单
    /// </summary>
    protected string GetAddCommentForm(string tmstr)
    {
        Foosun.CMS.sys sys = new Foosun.CMS.sys();
        string NewsID = Common.Input.Filter(Request.QueryString["id"]);
        if (string.IsNullOrEmpty(NewsID))
            NewsID = HiddenNewsID;
        string UserName = "Guest";
        string UserExit = "";

        if (Validate_Session())
        {
            UserName = Foosun.Global.Current.UserName;
            if (tmstr == "getlist")
            {
                UserExit = "<span id=\"loginOutB\"><a href=\"javascript:CommentLoginOut(this.form,'" + Common.Public.GetSiteDomain() + "');\">注销帐户</a></span>&nbsp;&nbsp;<a hrefs=\"" + Common.Public.GetSiteDomain() + "/" + Foosun.Config.UIConfig.dirUser + "/index.aspx?url=info/mycom.aspx\">我的评论</a>";
            }
            else
            {
                UserExit = "<a href=\"javascript:CommentLoginOut();\">注销帐户</a>&nbsp;&nbsp;<a href=\"" + Common.Public.GetSiteDomain() + "/" + Foosun.Config.UIConfig.dirUser + "/index.aspx?urls=info/mycom.aspx\">我的评论</a>";
            }
        }
        else
        {
            DataTable dt = sys.UserPram();
            if (dt != null)
            {
                if (dt.Rows[0]["UnRegCommTF"].ToString() != "1")
                {
                    UserName = "";
                    UserExit = "没帐户？<a href=\"" + Common.Public.GetSiteDomain() + "/" + Foosun.Config.UIConfig.dirUser + "/register.aspx\">这里注册</a>";
                }
                else
                {
                    UserExit = "<span id=\"isGuest\"><input class=\"checkbox\" type=\"checkbox\" onclick=\"if(this.checked){document.getElementsByName('UserNum')[0].value='Guest';}\">匿名用户评论</span>";
                }
                dt.Clear(); dt.Dispose();
            }
        }
        string str_CommForm = "<div class=\"usergt\">\r";
        str_CommForm += "<form action=\"\" method=\"post\" id=\"CommandForm\" name=\"CommandForm\">\r";
        if (Validate_Session())
        {
            str_CommForm += "<div class=\"comlogin\">用户名<span class=\"cuser\">" + UserName + "</span>" + " <span style=\"display:none;\"><input name=\"UserNum\" size=\"12\" type=\"text\" value=\"" + UserName + "\"></span>";
            str_CommForm += "<span style=\"display:none;\">密 码<input class=\"userpwd\" name=\"UserPwd\" size=\"12\" type=\"password\"></span> " + UserExit + " </div>\r";
        }
        else
        {
            str_CommForm += "<div class=\"comlogin\">用户名<input class=\"usernum\" name=\"UserNum\" size=\"12\" type=\"text\" value=\"\">";
            str_CommForm += "密 码<input class=\"userpwd\" name=\"UserPwd\" size=\"12\" type=\"password\"> " + UserExit + " </div>\r";
        }
        str_CommForm += "<div class=\"mood\"><div class=\"layout\"><span>已经有 <font color=\"red\" id=\"vote_total\">" + news.returncomment(NewsID, 0, 0) + "</font> 人表态：</span><ul><li><em>" + news.returncomment(NewsID, 0, 1) + "</em><div class=\"mood_bar\"><div  class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 0)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 1, 1) + "</em><div class=\"mood_bar\"><div  class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 1)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 2, 1) + "</em><div class=\"mood_bar\"> <div class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 2)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 3, 1) + "</em><div class=\"mood_bar\"><div  class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 3)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 4, 1) + "</em><div class=\"mood_bar\"><div class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 4)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 5, 1) + "</em><div class=\"mood_bar\"><div class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 5)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 6, 1) + "</em><div class=\"mood_bar\"><div class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 6)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 7, 1) + "</em>  <div class=\"mood_bar\"><div class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 7)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 8, 1) + "</em><div class=\"mood_bar\"><div class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 8)) + "%; width:24px;\"/></div></div></li><li><em>" + news.returncomment(NewsID, 9, 1) + "</em><div class=\"mood_bar\"><div class=\"mood_bar_in\"><img src=\"/sysimages/commface/moodbg.gif\" style=\"height: " + (100 - news.returnCommentGD(NewsID, 9)) + "%; width:24px;\"/></div></div></li></ul></div><ul><li><a href=\"#\"><img title=\"支持\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/zhichi.gif\"></a><br>支持<br><input type=\"radio\" name=\"commtype\" checked=\"checked\" value=\"0\"></li><li><a href=\"#\"><img title=\"高兴\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/gaoxing.gif\"></a><br>  高兴<br><input type=\"radio\"  name=\"commtype\" value=\"1\"></li><li><a href=\"#\"><img title=\"震惊\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/zhenjing.gif\"></a><br>震惊<br><input type=\"radio\"  name=\"commtype\" value=\"2\"></li><li><a href=\"#\"><img title=\"愤怒\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/fennu.gif\"></a><br>愤怒<br><input type=\"radio\"  name=\"commtype\" value=\"3\"></li><li><a href=\"#\"><img title=\"无聊\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/wuliao.gif\"></a><br>无聊<br><input type=\"radio\" name=\"commtype\" value=\"4\"></li><li><a href=\"#\"><img title=\"无奈\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/wunai.gif\"></a><br>无奈<br><input type=\"radio\"  name=\"commtype\" value=\"5\"></li><li><a href=\"#\"><img title=\"谎言\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/huangyan.gif\"></a><br>谎言<br><input type=\"radio\"  name=\"commtype\" value=\"6\"></li><li><a href=\"#\"><img title=\"枪稿\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/qianggao.gif\"></a><br>枪稿<br><input type=\"radio\"  name=\"commtype\" value=\"7\"></li><li><a href=\"#\"><img title=\"不解\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/bujie.gif\"></a><br>不解<br><input type=\"radio\"  name=\"commtype\" value=\"8\"></li><li><a href=\"#\"><img title=\"标题党\" src=\"" + Common.Public.GetSiteDomain() + "/sysimages/commface/biaotidang.gif\"></a><br>标题党<br><input type=\"radio\"  name=\"commtype\" value=\"9\"></li></ul></div>\r";
        str_CommForm += "<div class=\"textarea\">\r";
        if (tmstr == "getlist")
        {
            str_CommForm += "<textarea name=\"Content\" class=\"context\" rows=\"6\" onkeydown=\"javascript:if(event.ctrlKey&&event.keyCode==13){CommandSubmitContent(this.form,'" + Common.Public.GetSiteDomain() + "','" + NewsID + "');}\"></textarea>\r";
        }
        else
        {
            str_CommForm += "<textarea name=\"Content\" class=\"context\" rows=\"6\" onkeydown=\"javascript:if(event.ctrlKey&&event.keyCode==13){CommandSubmit(this.form);}\"></textarea>\r";
        }
        str_CommForm += "</div>\r";
        str_CommForm += "<div class=\"contxt\">" + newLine;
        if (tmstr == "getlist")
        {
            str_CommForm += "<input name=\"B_CommandSubmit\" type=\"button\" value=\"发表评论\" onclick=\"javascript:CommandSubmitContent(this.form,'" + Common.Public.GetSiteDomain() + "','" + NewsID + "');\">\r";
        }
        else
        {
            str_CommForm += "<input name=\"B_CommandSubmit\" type=\"button\" value=\"发表评论\" onclick=\"javascript:CommandSubmit(this.form);\">\r";
        }
        str_CommForm += "<input type=\"reset\" name=\"B_CommandReset\" value=\"重新填写\">&nbsp;<span style=\"Color:Red;\">Ctrl+回车</span>&nbsp;提交评论.\r";
        str_CommForm += "<input name=\"IsQID\" type=\"hidden\" value=\"\">\r";
        str_CommForm += "</div>\r";
        str_CommForm += "<div class=\"conexplain\">请自觉遵守互联网相关政策法规,评论字数2-200字.请不要发广告。您发表的问题不代表本站观点。一切后果由发表者负责</div>\r";
        str_CommForm += "</form>\r";
        str_CommForm += "</div>\r";

        return str_CommForm;
    }

    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="page">当前页码</param>
    /// <param name="Cnt">总记录数</param>
    /// <param name="pageCount">最大页数</param>
    /// <returns></returns>
    protected string ShowPage(string NewsID, int page, int Cnt, int pageCount)
    {
        string urlstr = "";
        int startIndex = 1, endIndex = 5;
        if (pageCount == 0)
        {
            return "";
        }
        if (page <= 5)
        {
            if (page == 1)
            {
                urlstr += "<a class=\"disabled\">首  页</a>";
            }
            else
            {
                urlstr += "<a href=\"javascript:GetCommentList('1');\" title=\"首页\">首  页</a>";
            }
            startIndex = 1;
            endIndex = 5;
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentList('1');\" title=\"首页\">首  页</a>";
            if ((page + 1) % 5 == 0)
            {
                startIndex = page - 3;
            }
            else if (page % 5 == 0)
            {
                startIndex = page - 4;
            }
            else
            {
                startIndex = (page + 1) - ((page + 1) % 5) + 1;
            }
            endIndex = startIndex + 4;
            if (endIndex > pageCount)
            {
                endIndex = pageCount;
            }
        }
        if (page < 6)
        {
            urlstr += "<a class=\"disabled\">上五页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentList('" + (startIndex - 5) + "');\" title=\"上五页\">上五页</a>";
        }
        if ((page - 1) < 1)
        {
            urlstr += "<a class=\"disabled\">上一页</a>";
        }
        else
        {
            urlstr += " <a href=\"javascript:GetCommentList('" + (page - 1) + "');\" title=\"上一页\">上一页</a> ";
        }
        if (pageCount < 6)
        {
            endIndex = pageCount;
        }
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (page == i)
            {
                urlstr += "<a class=\"current\" href=\"javascript:GetCommentList('" + i + "');\">" + i + "</a>";
            }
            else
            {
                urlstr += "<a href=\"javascript:GetCommentList('" + i + "');\">" + i + "</a>";
            }
        }
        if (page >= pageCount || pageCount < 6)
        {
            urlstr += "<a class=\"disabled\">下一页</a><a class=\"disabled\">下五页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentList('" + (endIndex + 1) + "');\" title=\"下五页\">下五页</a><a href=\"javascript:GetCommentList('" + (page + 1) + "');\" title=\"下一页\">下一页</a>";
        }
        if (page == pageCount)
        {
            urlstr += "<a class=\"disabled\">尾  页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentList('" + pageCount + "');\" title=\"尾页\">尾页</a>";
        }
        urlstr += "总数：<span style=\"color:red\">" + Cnt.ToString() + "</span>条，共<span style=\"color:red\">" + pageCount.ToString() + "</span>页";
        string gChID = Request.QueryString["ChID"];
        int ChID = 0;
        if (gChID != string.Empty && gChID != null)
        {
            ChID = int.Parse(gChID.ToString());
        }
        return urlstr = urlstr + "<div class=\"comall\"><a href=\"" + Common.Public.GetSiteDomain() + "/Comment.aspx?CommentType=getlist&id=" + NewsID + "&ChID=" + ChID.ToString() + "\">查看全部</a></div>";
    }


    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="page">当前页码</param>
    /// <param name="Cnt">总记录数</param>
    /// <param name="pageCount">最大页数</param>
    /// <returns></returns>

    protected string ShowPageContent(string NewsID, string URLdomain, int page, int Cnt, int pageCount)
    {
        string urlstr = "";
        int startIndex = 1, endIndex = 5;
        if (pageCount == 0)
        {
            return "";
        }
        if (page <= 5)
        {
            if (page == 1)
            {
                urlstr += "<a class=\"disabled\">首页</a>";
            }
            else
            {
                urlstr += "<a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','1');\" title=\"首页\">首 页</a>";
            }
            startIndex = 1;
            endIndex = 5;
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','1');\" title=\"首页\">首 页</a>";
            if ((page + 1) % 5 == 0)
            {
                startIndex = page - 3;
            }
            else if (page % 5 == 0)
            {
                startIndex = page - 4;
            }
            else
            {
                startIndex = (page + 1) - ((page + 1) % 5) + 1;
            }
            endIndex = startIndex + 4;
            if (endIndex > pageCount)
            {
                endIndex = pageCount;
            }
        }
        if (page < 6)
        {
            urlstr += "<a class=\"disabled\">上五页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','" + (startIndex - 5) + "');\" title=\"上五页\">上五页</a>";
        }
        if ((page - 1) < 1)
        {
            urlstr += "<a class=\"disabled\">上一页</a>";
        }
        else
        {
            urlstr += " <a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','" + (page - 1) + "');\" title=\"上一页\">上一页</a> ";
        }
        if (pageCount < 6)
        {
            endIndex = pageCount;
        }
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (page == i)
            {
                urlstr += "<a class=\"current\" href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','" + i + "');\">" + i + "</a>";
            }
            else
            {
                urlstr += "<a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','" + i + "');\">" + i + "</a>";
            }
        }
        if (page >= pageCount || pageCount < 6)
        {
            urlstr += "<a class=\"disabled\">下一页</a><a class=\"disabled\">下五页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','" + (endIndex + 1) + "');\" title=\"下五页\">下五页</a><a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','" + (page + 1) + "');\" title=\"下一页\">下一页</a>";
        }
        if (page == pageCount)
        {
            urlstr += "<a class=\"disabled\">尾 页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetCommentListContent('" + URLdomain + "','" + NewsID + "','" + pageCount + "');\" title=\"尾页\">尾 页</a>";
        }
        urlstr += "总数：<span style=\"color:red\">" + Cnt.ToString() + "</span>条，共<span style=\"color:red\">" + pageCount.ToString() + "</span>页";
        return urlstr;
    }

    /// <summary>
    /// 获取新闻页面评论模板路径
    /// </summary>
    /// <returns>返回评论模板路径</returns>
    protected string GetCommentTemplet()
    {

        if (str_dirMana != "" && str_dirMana != null && str_dirMana != string.Empty)//判断虚拟路径是否为空,如果不是则加上//
            str_dirMana = "//" + str_dirMana;
        string str_FilePath = Server.MapPath(str_dirMana + "\\" + str_Templet + "\\Content\\CommentPage.html");
        return str_FilePath;
    }

    /// <summary>
    /// 获得新闻独立评论页面模板路径
    /// </summary>
    /// <returns>返回评论模板路径</returns>
    protected string getCommentContentTemplet()
    {
        if (str_dirMana != "" && str_dirMana != null && str_dirMana != string.Empty)//判断虚拟路径是否为空,如果不是则加上//
            str_dirMana = "//" + str_dirMana;
        string str_FilePath = Server.MapPath(str_dirMana + "\\" + str_Templet + "\\Content\\CommentList.html");
        return str_FilePath;
    }

    /// <summary>
    /// 得到新闻地址
    /// </summary>
    /// <param name="isDelPoint"></param>
    /// <param name="NewsID"></param>
    /// <param name="SavePath"></param>
    /// <param name="SaveClassframe"></param>
    /// <param name="FileName"></param>
    /// <param name="FileEXName"></param>
    /// <returns></returns>
    protected string getNewsURL(string isDelPoint, string NewsID, string SavePath, string SaveClassframe, string FileName, string FileEXName)
    {
        string str_temppath = "";
        if (Common.Public.readparamConfig("ReviewType") == "0")
        {
            if (isDelPoint != "0")
            {
                str_temppath = "/content.aspx?id=" + NewsID + "";
            }
            else
            {
                str_temppath = "/" + SaveClassframe + "/" + SavePath + "/" + FileName + FileEXName;
            }
        }
        else
        {
            str_temppath = "/content.aspx?id=" + NewsID + "";
        }
        str_temppath = Common.Public.GetSiteDomain() + str_temppath.Replace("//", "/");
        return str_temppath;
    }

    /// <summary>
    /// 频道信息地址
    /// </summary>
    public string getCHInfoURL(int ChID, int isDelPoint, int id, string ClassSavePath, string SavePath, string FileName)
    {
        string urls = string.Empty;
        int ishtml = int.Parse(Common.Public.readCHparamConfig("isHTML", ChID));
        string Domain = Common.Public.readCHparamConfig("bdomain", ChID);
        string linkType = Common.Public.readparamConfig("linkTypeConfig");
        string htmldir = Common.Public.readCHparamConfig("htmldir", ChID);
        string dirdumm = Foosun.Config.UIConfig.dirDumm;
        if (dirdumm.Trim() != string.Empty)
        {
            dirdumm = "/" + dirdumm;
        }
        if (ishtml != 0 && isDelPoint == 0)
        {
            string flg = string.Empty;
            if (Domain != string.Empty)
            {
                if (linkType == "1")
                {
                    if (Domain.IndexOf("http://") > -1) { flg = Domain; }
                    else { flg = "http://" + Domain; }
                    urls = flg + "/" + ClassSavePath + "/" + SavePath + "/" + FileName;
                }
                else
                {
                    urls = "/" + ClassSavePath + "/" + SavePath + "/" + FileName;
                }
            }
            else
            {
                urls = "/" + htmldir + "/" + ClassSavePath + "/" + SavePath + "/" + FileName;
                urls = urls.Replace("//", "/");
                urls = Common.Public.GetSiteDomain() + urls;
            }
        }
        else
        {
            urls = Common.Public.GetSiteDomain() + "/Content.aspx?Id=" + id.ToString() + "&ChID=" + ChID.ToString() + "";
        }
        return urls.ToLower().Replace("{@dirhtml}", Foosun.Config.UIConfig.dirHtml);
    }
}

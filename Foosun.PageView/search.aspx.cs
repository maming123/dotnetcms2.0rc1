using System;
using System.Data;
using Foosun.CMS;
using System.Web;

public partial class search : Foosun.PageBasic.BasePage
{
    private string newLine = "\r\n";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        string tags = Request.QueryString["tags"];
        if (string.IsNullOrEmpty(tags))
        {
            Response.Write("请填写关键字");
            Response.End();
        }
        else
        {
            tags = tags.Trim();
            SearchOp();
        }
    }

    protected void SearchOp()
    {
        Response.Write(SearchLoad());
        Response.End();
    }

    protected string SearchLoad()
    {
        string SearchTemplet = Foosun.Publish.General.ReadHtml(GetSearchTemplet());

        bool b_C = false;
        bool b_P = false;

        if (SearchTemplet.IndexOf("{#Page_SearchContent}") > -1)
            b_C = true;
        if (SearchTemplet.IndexOf("{#Page_SearchPages}") > -1)
            b_P = true;

        string type = Request.QueryString["type"];
        string tags = Request.QueryString["tags"];
        string cid = Request.QueryString["ChID"];
        int ChID = 0;
        if (cid != null && cid != string.Empty)
        {
            ChID = int.Parse(cid.ToString());
        }
        if (type == string.Empty && type == null)
        {
            Response.Write("请选择搜索类型");
            Response.End();
        }
        string date = Request.QueryString["Date"];
        string classid = Request.QueryString["ClassID"];
        string editor = Request.QueryString["editor"];
        string str_List = "<div class=\"search_big_top_ru\"><b>搜索<font color=\"red\"><b>" + tags + "</b></font>结果如下：</b></div>" + newLine;
        str_List += "<div class=\"search_big_top_lie\">";
        str_List += "<ul>";
        Foosun.Model.Search si = new Foosun.Model.Search();

        si.type = type;
        si.tags = tags;
        si.date = date;
        si.classid = classid;

        string curPage = Request.QueryString["page"];
        int page = 0;

        if (curPage == "" || curPage == null || curPage == string.Empty) { page = 1; }
        else
        {
            try { page = int.Parse(curPage); }
            catch
            {
                page = 1;
            }
        }

        int i, j;
        string DTable = string.Empty;
        try
        {
            DataTable dt = Foosun.CMS.Search.SearchGetPage(DTable, page, 5, out i, out j, si);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    str_List += getRow(dt.Rows[k], ChID);
                }
                dt.Clear();
                dt.Dispose();
            }
            else
            {
                str_List += "<li>" + newLine + "<div class=\"sear_xiao\">" + newLine + "<p class=\"sear_xiao_p\">没有找到相关的记录</p>" + newLine + "</div>" + newLine + "</li>";
            }
            str_List += "</ul>" + newLine + "</div>" + newLine;
            string str_Page = "<div class=\"fanye\">" + ShowPage(page, i, j) + "</div>";


            if (b_C)
            {
                SearchTemplet = SearchTemplet.Replace("{#Page_SearchContent}", str_List);
            }
            if (b_P)
            {
                SearchTemplet = SearchTemplet.Replace("{#Page_SearchPages}", str_Page);
            }
        }

        catch
        {
            SearchTemplet = SearchTemplet.Replace("{#Page_SearchContent}", "没有找到相关的记录");
            SearchTemplet = SearchTemplet.Replace("{#Page_SearchPages}", "");
        }
        return SearchTemplet;
    }

    protected string getRow(DataRow dr, int ChID)
    {
        string str_Row = "";
        string stags = Request.QueryString["tags"];
        string FavNewsUrl = string.Empty;
        string dim = Foosun.Config.UIConfig.dirDumm;
        if (dim.Trim() != string.Empty)
        {
            dim = "/" + Foosun.Config.UIConfig.dirDumm;
        }
        string NewsUrl = "";
        string NewsUrl1 = "";

        FavNewsUrl = Foosun.Config.UIConfig.dirUser + "/info/collection.aspx?Type=Add&id=" + dr["NewsID"].ToString();
        string SaveClassframe = Foosun.CMS.Search.GetSaveClassframe(dr["ClassID"].ToString());
        switch (dr["NewsType"].ToString()) //0普通，1图片，2标题
        {
            case "0":
                NewsUrl = Foosun.CMS.Search.GetNewsReview(dr["NewsID"].ToString(), "news");
                NewsUrl = NewsUrl.Replace("//", "/");
                NewsUrl1 = "http://" + Request.ServerVariables["SERVER_NAME"] + dim + NewsUrl;

                str_Row += "<li>" + newLine;
                str_Row += "<div class=\"sear_xiao\">" + newLine;
                str_Row += "<div class=\"search_right1\">" + newLine;
                str_Row += "<p class=\"sear_xiao_p\">" + newLine;
                str_Row += "<a href=\"" + NewsUrl + "\" target=\"_blank\">" + dr["NewsTitle"].ToString().Replace(stags, "<span style=\"color:red\">" + stags + "</span>") + "</a>" + newLine;
                str_Row += "<span class=\"date\">" + dr["CreatTime"].ToString() + "</span>" + newLine;
                str_Row += "</p>" + newLine;
                str_Row += "<p>" + Common.Input.GetSubString(Common.Input.FilterHTML((dr["Content"].ToString()).Replace("?", "？")), 200).Replace(stags, "<span style=\"color:red\">" + stags + "</span>") + "</p>" + newLine;
                str_Row += "<p><a href=\"" + NewsUrl + "\" class=\"a1\" target=\"_blank\">" + NewsUrl + "</a></p>" + newLine;
                str_Row += "<p><a class=\"a2\" href=\"" + FavNewsUrl.Replace("//", "/") + "\" target=\"_blank\">收藏</a><a href=\"javascript:void(0);\" class=\"a2\" onclick=\"sendfriend('" + NewsUrl1 + "','" + dr["NewsTitle"].ToString() + "');\">推荐给朋友</a></p>" + newLine;
                str_Row += "</div>" + newLine;
                str_Row += "</div>" + newLine;
                str_Row += "</li>" + newLine;

                break;

            case "1":
                NewsUrl = Foosun.CMS.Search.GetNewsReview(dr["NewsID"].ToString(), "news");
                NewsUrl = NewsUrl.Replace("//", "/");
                NewsUrl1 = "http://" + Request.ServerVariables["SERVER_NAME"] + dim + NewsUrl;
                string imgr = dim + dr["PicURL"].ToString().ToLower().Replace("{@dirfile}", Foosun.Config.UIConfig.dirFile);

                str_Row += "<li>" + newLine;
                str_Row += "<div class=\"sear_xiao\">" + newLine;
                str_Row += "<img src=\"" + imgr + "\" style=\"width:120px; height:120px; padding:8px; float:left;\"/>" + newLine;
                str_Row += "<div class=\"search_right\">" + newLine;
                str_Row += "<p class=\"sear_xiao_p\">" + newLine;
                str_Row += "<a href=\"" + NewsUrl + "\" target=\"_blank\">" + dr["NewsTitle"].ToString().Replace(stags, "<span style=\"color:red\">" + stags + "</span>") + "</a>" + newLine;
                str_Row += "<span class=\"date\">" + dr["CreatTime"].ToString() + "</span>" + newLine;
                str_Row += "</p>" + newLine;
                str_Row += "<p>" + Common.Input.GetSubString(Common.Input.FilterHTML((dr["Content"].ToString()).Replace("?", "？")), 200).Replace(stags, "<span style=\"color:red\">" + stags + "</span>") + "</p>" + newLine;
                str_Row += "<p><a href=\"" + NewsUrl + "\" class=\"a1\" target=\"_blank\">" + NewsUrl + "</a></p>" + newLine;
                str_Row += "<p><a class=\"a2\" href=\"" + FavNewsUrl.Replace("//", "/") + "\" target=\"_blank\">收藏</a><a href=\"javascript:void(0);\" class=\"a2\" onclick=\"sendfriend('" + NewsUrl1 + "','" + dr["NewsTitle"].ToString() + "');\">推荐给朋友</a></p>" + newLine;
                str_Row += "</div>" + newLine;
                str_Row += "</div>" + newLine;
                str_Row += "</li>" + newLine;

                break;

            case "2":
                NewsUrl = dr["URLaddress"].ToString();

                str_Row += "<li>" + newLine;
                str_Row += "<div class=\"sear_xiao\">" + newLine;
                str_Row += "<div class=\"search_right\">" + newLine;
                str_Row += "<p class=\"sear_xiao_p\">" + newLine;
                str_Row += "<a href=\"" + NewsUrl + "\" target=\"_blank\">" + dr["NewsTitle"].ToString().Replace(stags, "<span style=\"color:red\">" + stags + "</span>") + "</a>" + newLine;
                str_Row += "<span class=\"date\">" + dr["CreatTime"].ToString() + "</span>" + newLine;
                str_Row += "</p>" + newLine;
                str_Row += "<p><a href=\"" + NewsUrl + "\" class=\"a1\" target=\"_blank\">" + NewsUrl + "</a></p>" + newLine;
                str_Row += "<p><a class=\"a2\" href=\"" + FavNewsUrl.Replace("//", "/") + "\" target=\"_blank\">收藏</a><a href=\"javascript:void(0);\" class=\"a2\" onclick=\"sendfriend('" + NewsUrl1 + "','" + dr["NewsTitle"].ToString() + "');\">推荐给朋友</a></p>" + newLine;
                str_Row += "</div>" + newLine;
                str_Row += "</div>" + newLine;
                str_Row += "</li>" + newLine;

                break;
        }
        return str_Row;
    }

    /// <summary>
    /// 获取搜索模板路径
    /// </summary>
    /// <returns>搜索模板路径</returns>
    protected string GetSearchTemplet()
    {
        string str_dirMana = Foosun.Config.UIConfig.dirDumm;
        string str_Templet = Foosun.Config.UIConfig.dirTemplet;  //获取模板路径

        if (str_dirMana != "" && str_dirMana != null && str_dirMana != string.Empty)//判断虚拟路径是否为空,如果不是则加上//
            str_dirMana = "//" + str_dirMana;
        string str_FilePath = Server.MapPath(str_dirMana + "\\" + str_Templet + "\\Content\\search.html");
        return str_FilePath;
    }

    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="page">当前页码</param>
    /// <param name="Cnt">总记录数</param>
    /// <param name="pageCount">最大页数</param>
    /// <returns></returns>
    protected string ShowPage(int page, int Cnt, int pageCount)
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
                urlstr += "<a href=\"javascript:GetSearchList('1');\" title=\"首页\">首页</a>";
            }
            startIndex = 1;
            endIndex = 5;
        }
        else
        {
            urlstr += "<a href=\"javascript:GetSearchList('1');\" title=\"首页\">首页</a>";
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
            urlstr += "<a href=\"javascript:GetSearchList('" + (startIndex - 5) + "');\" title=\"上五页\">上五页</a>";
        }
        if ((page - 1) < 1)
        {
            urlstr += "<a class=\"disabled\">上一页</a>";
        }
        else
        {
            urlstr += " <a href=\"javascript:GetSearchList('" + (page - 1) + "');\" title=\"上一页\">上一页</a> ";
        }
        if (pageCount < 6)
        {
            endIndex = pageCount;
        }
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (page == i)
            {
                urlstr += "<a class=\"current\" href=\"javascript:GetSearchList('" + i + "');\">" + i + "</a>";
            }
            else
            {
                urlstr += "<a href=\"javascript:GetSearchList('" + i + "');\">" + i + "</a>";
            }
        }
        if (page >= pageCount || pageCount < 6)
        {
            urlstr += "<a class=\"disabled\">下一页</a><a class=\"disabled\">下五页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetSearchList('" + (endIndex + 1) + "');\" title=\"下五页\">下五页</a><a href=\"javascript:GetSearchList('" + (page + 1) + "');\" title=\"下一页\">下一页</a>";
        }
        if (page == pageCount)
        {
            urlstr += "<a class=\"disabled\">尾页</a>";
        }
        else
        {
            urlstr += "<a href=\"javascript:GetSearchList('" + pageCount + "');\" title=\"尾页\">尾页</a>";
        }
        urlstr += "总数：<span style=\"color:red\">" + Cnt.ToString() + "</span>，共<span style=\"color:red\">" + pageCount.ToString() + "条</span>页";
        return urlstr;
    }
}

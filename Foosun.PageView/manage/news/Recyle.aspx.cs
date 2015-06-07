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

public partial class Recyle : Foosun.PageBasic.ManagePage
{
    public Recyle()
    {
        Authority_Code = "Q027";
    }
    Foosun.CMS.Recyle RecyleCMS = new Foosun.CMS.Recyle();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";                        //设置页面无缓存
        if (!IsPostBack)
        {
            //copyright.InnerHtml = CopyRight;              //获取版权信息
        }
        string str_Type = Request.QueryString["Type"];
        if (str_Type != "" && str_Type != null)
        {
            GetList(str_Type);
        }
    }

    /// <summary>
    /// 取得列表
    /// </summary>
    /// <param name="type">当前显示的类型</param>
    /// <returns>取得列表</returns>
    protected void GetList(string type)
    {
        string curPage = Request.QueryString["page"];    //当前页码
        string TempStr = GetMenu(type);
        ReOp(type);
        int pageSize = 20, page = 0;                     //每页显示数

        if (curPage == "" || curPage == null || curPage == string.Empty) { page = 1; }
        else
        {
            try { page = int.Parse(curPage); }
            catch (Exception e)
            {
                PageError("参数错误！<li>" + e.ToString() + "</li>", "");
            }
        }
        if (type == "APIList")
        {
            Response.Write("<table class=\"jstable\"><tr><td align=\"left\">API</td></tr></table>");
            Response.End();
        }
        DataTable dt = RecyleCMS.getList(type);

        if (dt != null)
        {
            int Cnt = dt.Rows.Count;

            //获得当前分页数-----------------------------------------------------
            int pageCount = Cnt / pageSize;
            if (Cnt % pageSize != 0) { pageCount++; }

            if (page > pageCount) { page = pageCount; }
            if (page < 1) { page = 1; }

            TempStr = TempStr + "<table class=\"jstable\">";
            TempStr = TempStr + "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
            TempStr = TempStr + "<th>编号</th>";

            switch (type)
            {
                case "NCList":      //新闻栏目列表
                    TempStr = TempStr + GetPageInfo(dt, "栏目中文名", page, pageSize, Cnt, pageCount, type);
                    break;
                case "NList":       //新闻列表
                    TempStr = TempStr + GetPageInfo(dt, "新闻标题", page, pageSize, Cnt, pageCount, type);
                    break;
                case "CList":       //频道列表
                    TempStr = TempStr + GetPageInfo(dt, "频道中文名", page, pageSize, Cnt, pageCount, type);
                    break;
                case "SList":       //专题列表
                    TempStr = TempStr + GetPageInfo(dt, "专题中文名", page, pageSize, Cnt, pageCount, type);
                    break;
                case "LCList":      //标签栏目列表
                    TempStr = TempStr + GetPageInfo(dt, "标签栏目名称", page, pageSize, Cnt, pageCount, type);
                    break;
                case "LList":       //标签列表
                    TempStr = TempStr + GetPageInfo(dt, "标签名称", page, pageSize, Cnt, pageCount, type);
                    break;
                case "StCList":     //样式栏目列表
                    TempStr = TempStr + GetPageInfo(dt, "样式栏目名称", page, pageSize, Cnt, pageCount, type);
                    break;
                case "StList":     //样式列表
                    TempStr = TempStr + GetPageInfo(dt, "样式名称", page, pageSize, Cnt, pageCount, type);
                    break;
                default:
                    TempStr = "参数错误!";
                    break;
            }
            dt.Clear();
            dt.Dispose();
        }
        //List.InnerHtml = TempStr;
        Response.Write(TempStr);
        Response.End();
    }

    /// <summary>
    /// 获得前台功能菜单
    /// </summary>
    /// <param name="type">当前显示的类型</param>
    /// <returns>获得前台功能菜单</returns>
    protected string GetMenu(string type)
    {
        string TempClassstr = "";
        string TempStr = "<div class=\"trash\">\r";
        TempStr += "<a href=\"javascript:RAll('" + type + "');\" >全部恢复</a>&nbsp;┊&nbsp;\r";
        TempStr += "<a href=\"javascript:DAll('" + type + "');\" >全部删除</a>&nbsp;┊&nbsp;\r";
        TempStr += "<a href=\"javascript:PR('" + type + "');\" >批量恢复</a>&nbsp;┊&nbsp;\r";
        TempStr += "<a href=\"javascript:PD('" + type + "');\">批量删除</a> \r";

        Foosun.CMS.AdminGroup ac = new Foosun.CMS.AdminGroup();
        if (type == "NList")
        {
            DataTable dt = ac.getClassList("ClassID,ClassCName,ParentID", "news_Class", "Where isRecyle=0 And SiteID='" + SiteID + "'");
            TempClassstr = "请指定一个新闻栏目(<span class=\"helpstyle\" style=\"cursor:help;\" title=\"点击显示帮助\" onclick=\"Help('H_Recyle_001',this)\">帮助</span> ) <select name=\"className\" id=\"className\" style=\"width:200px;padding-bottom:0;padding-left:0;padding-right:0;padding-top:0;\" class=\"form\"><option value=\"\">请选择要恢复到那个栏目</option>" + listShow(dt, "0", 0) + "</select>\r";
        }
        if (type == "StList")
        {
            DataTable dt = ac.getClassList("ClassID,Sname", "sys_styleclass", "Where isRecyle=0 And SiteID='" + SiteID + "'");
            TempClassstr = "请指定一个样式栏目(<span class=\"helpstyle\" style=\"cursor:help;\" title=\"点击显示帮助\" onclick=\"Help('H_Recyle_002',this)\">帮助</span> ) " + GetSClist(dt) + "\r";
        }
        if (type == "LList")
        {
            DataTable dt = ac.getClassList("ClassID,ClassName", "sys_LabelClass", "Where isRecyle=0 And SiteID='" + SiteID + "'");
            TempClassstr = "请指定一个标签栏目(<span class=\"helpstyle\" style=\"cursor:help;\" title=\"点击显示帮助\" onclick=\"Help('H_Recyle_003',this)\">帮助</span> ) " + GetSClist(dt) + "\r";
        }
        TempStr += TempClassstr;
        TempStr += "</div>\r";
        return TempStr;
    }


    /// <summary>
    /// 返回列表
    /// </summary>
    /// <param name="tempdt">DataTable</param>
    /// <param name="PID">父类编号</param>
    /// <param name="Layer">层次</param>
    protected string listShow(DataTable tempdt, string PID, int Layer)
    {
        string list = "";
        DataRow[] row = null;
        row = tempdt.Select("ParentID='" + PID + "'");
        if (row.Length < 1)
            return list;
        else
        {
            foreach (DataRow r in row)
            {
                string strText = "┝";
                for (int j = 0; j < Layer; j++)
                {
                    strText += "┉";
                }
                list += "<option value=\"" + r[0].ToString() + "\">" + strText + r[1].ToString() + "</option>";
                if (r[0].ToString() != "0")
                    list += listShow(tempdt, r[0].ToString(), Layer + 1);
            }
        }
        return list;
    }

    /// <summary>
    /// 显示分页
    /// </summary>
    /// <param name="page">当前页数</param>
    /// <param name="pageSize">每页显示多少条</param>
    /// <param name="Cnt">总记录数</param>
    /// <param name="url">链接地址</param>
    /// <param name="pageCount">分页总数</param>
    /// <param name="type">当前显示的类型</param>
    /// <returns>显示分页</returns>
    protected string ShowPage(int page, int pageSize, int Cnt, string url, int pageCount, string type)
    {
        string urlstr = "共" + Cnt.ToString() + "条记录,共" + pageCount.ToString() + "页,当前第" + page.ToString() + "页   ";
        urlstr += "<a href=\"javascript:GetList('" + type + "',1)\" title=\"首页\">首页</a> ";
        if ((page - 1) < 1)
            urlstr += " <a href=\"javascript:GetList('" + type + "',1)\" title=\"上一页\">上一页</a> ";
        else
            urlstr += " <a href=\"javascript:GetList('" + type + "'," + (page - 1) + ")\" title=\"上一页\">上一页</a> ";
        if ((page + 1) < pageCount)
            urlstr += " <a href=\"javascript:GetList('" + type + "'," + (page + 1) + ")\" title=\"下一页\">下一页</a> ";
        else
            urlstr += " <a href=\"javascript:GetList('" + type + "'," + pageCount + ")\" title=\"下一页\">下一页</a> ";
        urlstr += " <a href=\"javascript:GetList('" + type + "'," + pageCount + ")\" title=\"尾页\">尾页</a> ";
        return urlstr;
    }

    /// <summary>
    /// 分页公共部份
    /// </summary>
    /// <param name="dt">要显示列表的数据表</param>
    /// <param name="cm">列表要显示的中文名称</param>
    /// <param name="page">当前页数</param>
    /// <param name="pageSize">每页显示多少条</param>
    /// <param name="cnt">总记录数</param>
    /// <param name="pageCount">分页总数</param>
    /// <param name="type">当前显示的类型</param>
    /// <returns>分页公共部份</returns>
    protected string GetPageInfo(DataTable dt, string cm, int page, int pageSize, int cnt, int pageCount, string type)
    {
        string TempStr = "";
        int i = 0;
        int j = 0;
        TempStr = TempStr + "<th>" + cm + "</th>";
        TempStr = TempStr + "<th>操作 <input type=\"checkbox\" value=\"'-1'\" name=\"ID\" id=\"ID\" onclick=\"javascript:selectAll(this.form,this.checked)\" /></th>";
        TempStr = TempStr + "</tr>";
        for (i = (page - 1) * pageSize, j = 1; i < cnt && j <= pageSize; i++, j++)
        {
            string ID = dt.Rows[i][1].ToString();
            string CName = dt.Rows[i][2].ToString();
            string Op = "<input type=\"checkbox\" value=\"'" + ID + "'\" id=\"ID\" name=\"ID\" />";

            TempStr = TempStr + "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
            TempStr = TempStr + "<td>" + ID + "</td>";
            TempStr = TempStr + "<td>" + CName + "</td>";
            TempStr = TempStr + "<td>" + Op + "</td>";
            TempStr = TempStr + "</tr>";
        }
        string url = "Recyle.aspx?Type=" + type + "&page=";
        TempStr = TempStr + "<tr align=\"right\"><td colspan=\"3\">" + ShowPage(page, pageSize, cnt, url, pageCount, type) + "</td></tr>";
        TempStr = TempStr + "</table>";
        return TempStr;
    }

    /// <summary>
    /// 操作
    /// </summary>
    /// <param name="type">要操作的类型</param>
    /// <returns>操作</returns>
    protected void ReOp(string type)
    {
        string Optype = Request.QueryString["Op"];
        string IdList = Request.QueryString["idlist"];
        if (Optype != null && Optype != "")
        {
            switch (Optype)
            {
                case "RAll"://全部恢复
                    this.Authority_Code = "Q027";
                    this.CheckAdminAuthority();
                    RAll(type);
                    break;
                case "DAll"://全部删除
                    this.Authority_Code = "Q027";
                    this.CheckAdminAuthority();
                    DAll(type);
                    break;
                case "PR":  //批量恢复
                    this.Authority_Code = "Q027";
                    this.CheckAdminAuthority();
                    PR(type, Common.Input.CutComma(CheckID(IdList)));
                    break;
                case "PD":  //批量删除
                    this.Authority_Code = "Q027";
                    this.CheckAdminAuthority();
                    PD(type, Common.Input.CutComma(CheckID(IdList)));
                    break;
            }
        }
    }

    /// <summary>
    /// 检测ID是否合法
    /// </summary>
    /// <param name="idlist">要检测的ID</param>
    /// <returns>检测ID是否合法</returns>
    protected string CheckID(string idlist)
    {
        idlist = Common.Input.Losestr(idlist);
        if (idlist == "IsNull")
            Common.MessageBox.Show(this, "请选择要批量操作的内容!");
        return idlist;
    }

    /// <summary>
    /// 全部恢复
    /// </summary>
    /// <param name="type">要恢复的类型</param>
    /// <returns>全部恢复</returns>
    protected void RAll(string type)
    {
        switch (type)
        {
            case "NCList":      //新闻栏目
                RallNCList();
                break;
            case "NList":       //新闻
                RallNList();
                break;
            case "CList":       //频道
                RallCList();
                break;
            case "SList":       //专题
                RallSList();
                break;
            case "LCList":     //标签栏目
                RallLCList();
                break;
            case "LList":       //标签
                RallLList();
                break;
            case "StCList":     //样式栏目
                RallStCList();
                break;
            case "StList":     //样式
                RallStList();
                break;
        }
    }

    /// <summary>
    /// 全部删除
    /// </summary>
    /// <param name="type">全部删除的类型</param>
    /// <returns>全部删除</returns>
    protected void DAll(string type)
    {
        switch (type)
        {
            case "NCList":      //新闻栏目
                DallNCList();
                break;
            case "NList":       //新闻
                DallNList();
                break;
            case "CList":       //频道
                DallCList();
                break;
            case "SList":       //专题
                DallSList();
                break;
            case "StCList":     //样式栏目
                DallStCList();
                break;
            case "StList":     //样式
                DallStList();
                break;
            case "LCList":     //标签栏目
                DallLCList();
                break;
            case "LList":       //标签
                DallLList();
                break;
        }
    }

    /// <summary>
    /// 批量恢复
    /// </summary>
    /// <param name="type">批量恢复的类型</param>
    /// <param name="idlist">批量恢复的ID</param>
    /// <returns>批量恢复</returns>
    protected void PR(string type, string idlist)
    {
        switch (type)
        {
            case "NCList":      //新闻栏目
                PRNCList(idlist);
                break;
            case "NList":       //新闻
                PRNList(idlist);
                break;
            case "CList":       //频道
                PRCList(idlist);
                break;
            case "SList":       //专题
                PRSList(idlist);
                break;
            case "StCList":     //样式栏目
                PRStCList(idlist);
                break;
            case "StList":     //样式
                PRStList(idlist);
                break;
            case "LCList":     //标签栏目
                PRLCList(idlist);
                break;
            case "LList":       //标签
                PRLList(idlist);
                break;
        }
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="type">批量删除的类型</param>
    /// <param name="idlist">批量删除的ID</param>
    /// <returns>批量删除</returns>
    protected void PD(string type, string idlist)
    {
        switch (type)
        {
            case "NCList":      //新闻栏目
                PDNCList(idlist);
                break;
            case "NList":       //新闻
                PDNList(idlist);
                break;
            case "CList":       //频道
                PDCList(idlist);
                break;
            case "SList":       //专题
                PDSList(idlist);
                break;
            case "LCList":     //标签栏目
                PDLCList(idlist);
                break;
            case "LList":       //标签
                PDLList(idlist);
                break;
            case "StCList":     //样式栏目
                PDStCList(idlist);
                break;
            case "StList":     //样式
                PDStList(idlist);
                break;
        }
    }


    /// <summary>
    /// 恢复全部新闻栏目
    /// </summary>
    /// <returns>恢复全部新闻栏目</returns>
    protected void RallNCList()
    {
        Foosun.CMS.Recyle rc = new Foosun.CMS.Recyle();
        rc.RallNCList();
        Common.MessageBox.Show(this, "恢复全部新闻栏目成功!");
    }

    /// <summary>
    /// 恢复全部新闻
    /// </summary>
    /// <returns>恢复全部新闻</returns>
    protected void RallNList()
    {
        string ClassID = Request.QueryString["className"];
        if (ClassID == "" || ClassID == null || ClassID == string.Empty)
            PageError("请指定一个栏目!", "");
        else
        {
            RecyleCMS.RallNList(ClassID);
            PageRight("恢复全部新闻成功!", "");
        }
    }

    /// <summary>
    /// 恢复全部频道
    /// </summary>
    /// <returns>恢复全部频道</returns>
    protected void RallCList()
    {
        RecyleCMS.RallCList();
        Common.MessageBox.Show(this, "恢复全部频道成功!");
    }

    /// <summary>
    /// 恢复全部专题
    /// </summary>
    /// <returns>恢复全部专题</returns>
    protected void RallSList()
    {
        RecyleCMS.RallSList();
        Common.MessageBox.Show(this, "恢复全部专题成功!");
    }

    /// <summary>
    /// 恢复全部标签栏目
    /// </summary>
    /// <returns>恢复全部标签栏目</returns>
    protected void RallLCList()
    {
        RecyleCMS.RallLCList();
        Common.MessageBox.Show(this, "恢复全部标签栏目成功!");
    }

    /// <summary>
    /// 恢复全部标签
    /// </summary>
    /// <returns>恢复全部标签</returns>
    protected void RallLList()
    {
        string ClassID = Request.QueryString["className"];
        if (ClassID == "" || ClassID == null || ClassID == string.Empty)
            Common.MessageBox.Show(this, "请选择要将标签恢复到那个栏目!");
        else
        {
            RecyleCMS.RallLList(ClassID);
            Common.MessageBox.Show(this, "恢复全部标签成功!");
        }
    }

    /// <summary>
    /// 恢复全部样式栏目
    /// </summary>
    /// <returns>恢复全部样式栏目</returns>
    protected void RallStCList()
    {
        RecyleCMS.RallStCList();
        Common.MessageBox.Show(this, "恢复全部样式栏目成功!");
    }

    /// <summary>
    /// 恢复全部样式
    /// </summary>
    /// <returns>恢复全部样式</returns>
    protected void RallStList()
    {
        string ClassID = Request.QueryString["className"];
        if (ClassID == "" || ClassID == null || ClassID == string.Empty)
            Common.MessageBox.Show(this, "请选择要将样式恢复到那个栏目!");
        else
        {
            RecyleCMS.RallStList(ClassID);
            Common.MessageBox.Show(this, "恢复全部样式成功!");
        }
    }

    /// <summary>
    /// 删除全部新闻栏目
    /// </summary>
    /// <returns>删除全部新闻栏目</returns>
    protected void DallNCList()
    {
        Foosun.CMS.Recyle rc = new Foosun.CMS.Recyle();
        rc.DallNCList();
        Common.MessageBox.Show(this, "删除全部新闻栏目成功!");
    }


    /// <summary>
    /// 删除全部新闻
    /// </summary>
    /// <returns>删除全部新闻</returns>


    protected void DallNList()
    {
        RecyleCMS.DallNList();
        Common.MessageBox.Show(this, "删除全部新闻成功!");
    }

    /// <summary>
    /// 删除全部频道
    /// </summary>
    /// <returns>删除全部频道</returns>


    protected void DallCList()
    {
        RecyleCMS.DallCList();
        Common.MessageBox.Show(this, "删除全部频道成功!");
    }

    /// <summary>
    /// 删除全部专题
    /// </summary>
    /// <returns>删除全部专题</returns>
    protected void DallSList()
    {
        RecyleCMS.DallSList();
        Common.MessageBox.Show(this, "删除全部专题成功!");
    }

    /// <summary>
    /// 删除全部标签栏目
    /// </summary>
    /// <returns>删除全部标签栏目</returns>


    protected void DallLCList()
    {
        RecyleCMS.DallLCList();
        Common.MessageBox.Show(this, "删除全部标签栏目成功!");
    }


    /// <summary>
    /// 删除全部标签
    /// </summary>
    /// <returns>删除全部标签</returns>


    protected void DallLList()
    {
        RecyleCMS.DallLList();
        Common.MessageBox.Show(this, "删除全部标签成功!");
    }


    /// <summary>
    /// 删除全部样式栏目
    /// </summary>
    /// <returns>删除全部样式栏目</returns>


    protected void DallStCList()
    {
        RecyleCMS.DallStCList();
        Common.MessageBox.Show(this, "删除全部样式栏目成功!");
    }


    /// <summary>
    /// 删除全部样式
    /// </summary>
    /// <returns>删除全部样式</returns>


    protected void DallStList()
    {
        RecyleCMS.DallStList();
        Common.MessageBox.Show(this, "删除全部样式成功!");
    }

    /// <summary>
    /// 批量恢复新闻栏目
    /// </summary>
    /// <param name="idlist">新闻栏目编号</param>
    /// <returns>批量恢复新闻栏目</returns>


    protected void PRNCList(string idlist)
    {
        RecyleCMS.PRNCList(idlist);
        Common.MessageBox.Show(this, "批量恢复新闻栏目成功!");
    }

    /// <summary>
    /// 批量恢复新闻
    /// </summary>
    /// <param name="idlist">新闻编号</param>
    /// <returns>批量恢复新闻</returns>


    protected void PRNList(string idlist)
    {
        string ClassID = Request.QueryString["className"];
        if (ClassID == "" || ClassID == null || ClassID == string.Empty)
            Common.MessageBox.Show(this, "请选择要将新闻恢复到那个栏目!");
        else
        {
            RecyleCMS.PRNList(ClassID, idlist);
            Common.MessageBox.Show(this, "批量恢复新闻成功!");
        }
    }

    /// <summary>
    /// 批量恢复频道
    /// </summary>
    /// <param name="idlist">频道编号</param>
    /// <returns>批量恢复频道</returns>


    protected void PRCList(string idlist)
    {
        RecyleCMS.PRCList(idlist);
        Common.MessageBox.Show(this, "批量恢复频道成功!");
    }

    /// <summary>
    /// 批量恢复专题
    /// </summary>
    /// <param name="idlist">专题编号</param>
    /// <returns>批量恢复专题</returns>


    protected void PRSList(string idlist)
    {
        RecyleCMS.PRSList(idlist);
        Common.MessageBox.Show(this, "批量恢复专题成功!");
    }

    /// <summary>
    /// 批量恢复样式栏目
    /// </summary>
    /// <param name="idlist">样式栏目编号</param>
    /// <returns>批量恢复样式栏目</returns>


    protected void PRStCList(string idlist)
    {
        RecyleCMS.PRStCList(idlist);
        Common.MessageBox.Show(this, "批量恢复样式栏目成功!");
    }

    /// <summary>
    /// 批量恢复样式
    /// </summary>
    /// <param name="idlist">样式编号</param>
    /// <returns>批量恢复样式</returns>


    protected void PRStList(string idlist)
    {
        string ClassID = Request.QueryString["className"];
        if (ClassID == "" || ClassID == null || ClassID == string.Empty)
            Common.MessageBox.Show(this, "请选择要将样式恢复到那个栏目!");
        else
        {
            RecyleCMS.PRStList(ClassID, idlist);
            Common.MessageBox.Show(this, "批量恢复样式成功!");
        }
    }

    /// <summary>
    /// 批量恢复标签栏目
    /// </summary>
    /// <param name="idlist">标签栏目编号</param>
    /// <returns>批量恢复标签栏目</returns>


    protected void PRLCList(string idlist)
    {
        RecyleCMS.PRLCList(idlist);
        Common.MessageBox.Show(this, "批量恢复标签栏目成功!");
    }

    /// <summary>
    /// 批量恢复标签
    /// </summary>
    /// <param name="idlist">标签编号</param>
    /// <returns>批量恢复标签</returns>



    protected void PRLList(string idlist)
    {
        string ClassID = Request.QueryString["className"];
        if (ClassID == "" || ClassID == null || ClassID == string.Empty)
            Common.MessageBox.Show(this, "请选择要将标签恢复到那个栏目!");
        else
        {
            RecyleCMS.PRLList(ClassID, idlist);
            Common.MessageBox.Show(this, "批量恢复标签成功!");
        }
    }

    /// <summary>
    /// 批量删除新闻栏目
    /// </summary>
    /// <param name="idlist">新闻栏目编号</param>
    /// <returns>批量删除新闻栏目</returns>


    protected void PDNCList(string idlist)
    {
        RecyleCMS.PDNCList(idlist);
        Common.MessageBox.Show(this, "批量删除新闻栏目成功!");
    }


    /// <summary>
    /// 批量删除新闻
    /// </summary>
    /// <param name="idlist">新闻编号</param>
    /// <returns>批量删除新闻</returns>



    protected void PDNList(string idlist)
    {
        RecyleCMS.PDNList(idlist);
        Common.MessageBox.Show(this, "批量删除新闻成功!");
    }

    /// <summary>
    /// 批量删除频道
    /// </summary>
    /// <param name="idlist">频道编号</param>
    /// <returns>批量删除频道</returns>


    protected void PDCList(string idlist)
    {
        RecyleCMS.PDCList(idlist);
        Common.MessageBox.Show(this, "批量删除频道成功!");
    }

    /// <summary>
    /// 批量删除专题
    /// </summary>
    /// <param name="idlist">专题编号</param>
    /// <returns>批量删除专题</returns>


    protected void PDSList(string idlist)
    {
        RecyleCMS.PDSList(idlist);
        Common.MessageBox.Show(this, "批量删除专题成功!");
    }


    /// <summary>
    /// 批量删除样式栏目
    /// </summary>
    /// <param name="idlist">样式栏目编号</param>
    /// <returns>批量删除样式栏目</returns>


    protected void PDStCList(string idlist)
    {
        RecyleCMS.PDStCList(idlist);
        Common.MessageBox.Show(this, "批量删除样式栏目成功!");
    }

    /// <summary>
    /// 批量删除样式
    /// </summary>
    /// <param name="idlist">样式编号</param>
    /// <returns>批量删除样式</returns>


    protected void PDStList(string idlist)
    {
        RecyleCMS.PDStList(idlist);
        Common.MessageBox.Show(this, "批量删除样式成功!");
    }


    /// <summary>
    /// 批量删除标签栏目
    /// </summary>
    /// <param name="idlist">标签栏目编号</param>
    /// <returns>批量删除标签栏目</returns>


    protected void PDLCList(string idlist)
    {
        RecyleCMS.PDLCList(idlist);
        Common.MessageBox.Show(this, "批量删除标签栏目成功");
    }


    /// <summary>
    /// 批量删除标签
    /// </summary>
    /// <param name="idlist">标签编号</param>
    /// <returns>批量删除标签</returns>
    protected void PDLList(string idlist)
    {
        RecyleCMS.PDLList(idlist);
        Common.MessageBox.Show(this, "批量删除标签成功");
    }

    /// <summary>
    /// 取得样式栏目列表
    /// </summary>
    /// <returns>返回样式栏目下拉列表框</returns>
    protected string GetSClist(DataTable dt)
    {
        string TempStr = "<select name=\"className\" id=\"className\" style=\"width:200px;padding-bottom:0;padding-left:0;padding-right:0;padding-top:0;\" class=\"form\">";
        TempStr = TempStr + "<option value=\"\">请选择要恢复到那个栏目</option>";
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() != "99999999")
                    TempStr = TempStr + "<option value=\"" + dt.Rows[i][0] + "\">" + dt.Rows[i][1] + "</option>";
            }
            dt.Clear();
            dt.Dispose();
        }
        TempStr = TempStr + "</select>";
        return TempStr;
    }
}

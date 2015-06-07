using System;
using System.Data;
using Foosun.Model;

public partial class SpecialList : Foosun.PageBasic.ManagePage
{
    public SpecialList()
    {
        Authority_Code = "C038";
    }
    Foosun.CMS.NewsSpecial NewsSpecialCMS = new Foosun.CMS.NewsSpecial();
    protected void Page_Load(object sender, EventArgs e)
    {
        //清除缓存

        Response.CacheControl = "no-cache";                        //设置页面无缓存

        string Type = Request.QueryString["Type"];  //取得操作类型
        string ID = Request.QueryString["ID"];  //取得需要操作的专题ID
        string Mode = Request.QueryString["Mode"];
        switch (Type)
        {
            case "Lock":            //锁定专题
                this.Authority_Code = "C041";
                this.CheckAdminAuthority();
                Lock(Common.Input.checkID(ID));
                break;
            case "UnLock":          //解锁专题
                this.Authority_Code = "C041";
                this.CheckAdminAuthority();
                UnLock(Common.Input.checkID(ID));
                break;
            case "PDel":            //批量删除专题
                this.Authority_Code = "C040";
                this.CheckAdminAuthority();
                PDel(Mode);
                break;
            case "PUnlock":         //批量解锁专题
                this.Authority_Code = "C041";
                this.CheckAdminAuthority();
                PUnlock();
                break;
            case "Plock":           //批量锁定专题
                this.Authority_Code = "C041";
                this.CheckAdminAuthority();
                Plock();
                break;
            case "Publish":
                Publish();
                break;
            default:
                if (!IsPostBack)
                {
                    //copyright.InnerHtml = CopyRight;            //获取版权信息
                    StartLoad(1, false);
                }
                break;
        }
        this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
    }


    /// <summary>
    /// 分页
    /// </summary>
    /// <returns>分页</returns>
    protected void PageNavigator1_PageChange(object sender, int PageIndex)
    {
        StartLoad(PageIndex, false);
    }
    protected void StartLoad(int PageIndex, bool IsSearch)
    {
        int RecordCount = 0;
        int PageCount = 0;
        string site = Request.QueryString["SiteID"];
        if (site != "" && site != null)
        {
            site = Request.QueryString["SiteID"].ToString();
        }
        else
        {
            if (SiteID != "0")
            {
                site = SiteID;
            }
            else
            {
                site = "0";
            }
        }
        DataTable dt;
        if (IsSearch)
        {
            dt = NewsSpecialCMS.GetSpecialByCName(search_SpecialCName.Text);
            RecordCount = dt.Rows.Count;
            PageCount = 1;
            PageIndex = 1;
        }
        else
        {
            dt = NewsSpecialCMS.GetPage(Foosun.Global.Current.SiteID, Foosun.Config.UIConfig.GetPageSize(), PageIndex, out RecordCount, out PageCount);
        }

        this.PageNavigator1.PageCount = PageCount;
        this.PageNavigator1.PageIndex = PageIndex;
        this.PageNavigator1.RecordCount = RecordCount;
        if (dt != null)
        {
            dt.Columns.Add("Op", typeof(string));
            dt.Columns.Add("Look", typeof(string));
            dt.Columns.Add("Lock", typeof(string));
            dt.Columns.Add("Colum", typeof(string));
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                string strchar = null;
                //取出子类
                dt.Rows[k]["Op"] = "<a href=\"javascript:Update('" + dt.Rows[k]["SpecialID"] + "');\" class=\"xa3\">" +
                                   "修改</a>" +
                                   "<a href=\"javascript:Lock('" + dt.Rows[k]["SpecialID"] + "');\" class=\"xa3\">" +
                                   "锁定</a>" +
                                   "<a href=\"javascript:UnLock('" + dt.Rows[k]["SpecialID"] + "');\" class=\"xa3\">" +
                                   "解锁</a>" +
                                   "<a href=\"javascript:AddChild('" + dt.Rows[k]["SpecialID"] + "');\" class=\"xa3\">" +
                                   "添加子专题</a>" +
                                   "<a href=\"NewsPreview.aspx?ID=" + dt.Rows[k]["SpecialID"] + "&type=special\" target=\"_blank\" class=\"xa3\">预览</a>" +
                                   "<input type=\"checkbox\" value=\"'" + dt.Rows[k]["SpecialID"] + "'\" id=\"S_ID\" name=\"S_ID\" />";
                strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                strchar += "<td title=\"专题ID：" + dt.Rows[k]["SpecialID"] + "\">" + dt.Rows[k]["SpecialCName"] + "</td>";
                strchar += "<td align=\"center\" >" + dt.Rows[k]["CreatTime"] + "</td>";
                if (dt.Rows[k]["isLock"].ToString() == "1")
                    dt.Rows[k]["Lock"] = "<font color=\"red\">锁定</a>";
                else
                    dt.Rows[k]["Lock"] = "正常";
                strchar += "<td align=\"center\" >" + dt.Rows[k]["Lock"] + "</td>";
                dt.Rows[k]["Look"] = "<a href=\"NewsList.aspx?specialID=" + dt.Rows[k]["SpecialID"] + "\" class=\"xa3\">" +
                                     "<img src=\"../imges/review.gif\" border=\"0\" alt=\"查看所属此专题的所有新闻\" /></a>" +
                                     "(" + GetSpicaelNewsNum(dt.Rows[k]["SpecialID"].ToString()) + ")";
                strchar += "<td align=\"center\" >" + dt.Rows[k]["Look"] + "</td>";
                strchar += "<td align=\"left\" >" + dt.Rows[k]["Op"] + "</td>";
                strchar += "</tr>";
                if (!IsSearch) strchar += ChileList(dt.Rows[k]["SpecialID"].ToString(), "├");
                dt.Rows[k]["Colum"] = strchar;
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
            dt.Clear();
            dt.Dispose();
        }
    }

    //递归
    protected string ChileList(string Classid, string sign)
    {
        string strchar = null;
        DataTable dv = NewsSpecialCMS.GetChildList(Classid);
        sign += "─";
        if (dv != null)
        {
            dv.Columns.Add("Op", typeof(string));
            dv.Columns.Add("Look", typeof(string));
            dv.Columns.Add("Lock", typeof(string));
            for (int pi = 0; pi < dv.Rows.Count; pi++)
            {
                dv.Rows[pi]["Op"] = "<a href=\"javascript:Update('" + dv.Rows[pi]["SpecialID"] + "');\" class=\"xa3\">修改</a>" +
                                    "<a href=\"javascript:Lock('" + dv.Rows[pi]["SpecialID"] + "');\" class=\"xa3\">锁定</a>" +
                                    "<a href=\"javascript:UnLock('" + dv.Rows[pi]["SpecialID"] + "');\" class=\"xa3\">解锁</a>" +
                                    "<a href=\"javascript:AddChild('" + dv.Rows[pi]["SpecialID"] + "');\" class=\"xa3\">添加子专题</a>" +
                                    "<a href=\"NewsPreview.aspx?ID=" + dv.Rows[pi]["SpecialID"] + "&type=special\" target=\"_blank\" class=\"xa3\">预览</a>" +
                                    "<input type=\"checkbox\" value=\"'" + dv.Rows[pi]["SpecialID"] + "'\" id=\"S_ID\" name=\"S_ID\" />";
                strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                strchar += "<td>" + sign + dv.Rows[pi]["SpecialCName"] + "</td>";
                strchar += "<td align=\"center\" >" + dv.Rows[pi]["CreatTime"] + "</td>";
                if (dv.Rows[pi]["isLock"].ToString() == "1")
                    dv.Rows[pi]["Lock"] = "<font color=\"red\">锁定</a>";
                else
                    dv.Rows[pi]["Lock"] = "正常";
                strchar += "<td align=\"center\">" + dv.Rows[pi]["Lock"] + "</td>";
                dv.Rows[pi]["Look"] = "<a href=\"NewsList.aspx?Type=special&specialID=" + dv.Rows[pi]["SpecialID"] + "\" class=\"xa3\" " +
                                      " title=\"查看所属此专题的所有新闻\"><img src=\"../imges/review.gif\" border=\"0\" " +
                                      " alt=\"查看所属此专题的所有新闻\" /></a>(" + GetSpicaelNewsNum(dv.Rows[pi]["SpecialID"].ToString()) + ")";
                strchar += "<td align=\"center\" >" + dv.Rows[pi]["Look"] + "</td>";
                strchar += "<td align=\"left\" >" + dv.Rows[pi]["Op"] + "</td>";
                strchar += "</tr>";
                strchar += ChileList(dv.Rows[pi]["SpecialID"].ToString(), sign);
            }
            dv.Clear();
            dv.Dispose();
        }
        return strchar;
    }


    /// <summary>
    /// 锁定专题
    /// </summary>
    /// <param name="ID">专题编号</param>
    /// <returns>锁定专题</returns>
    protected void Lock(string ID)
    {
        NewsSpecialCMS.SetLock(ID);
        Common.MessageBox.ShowAndRedirect(this, "锁定专题成功!", "SpecialList.aspx");

    }

    /// <summary>
    /// 解锁专题
    /// </summary>
    /// <param name="ID">专题编号</param>
    /// <returns>解锁专题</returns>
    protected void UnLock(string ID)
    {
        NewsSpecialCMS.SetLock(ID);
        Common.MessageBox.ShowAndRedirect(this, "解锁专题成功!", "SpecialList.aspx");
    }

    /// <summary>
    /// 批量删除专题
    /// </summary>
    /// <param name="mode">详细的操作,如果参数值是"Re",则就删除到回收站,否则就为彻底删除</param>
    /// <returns>批量删除专题</returns>
    protected void PDel(string mode)
    {
        if (Request.Form["S_ID"] == null || Request.Form["S_ID"] == "")
            Common.MessageBox.ShowAndRedirect(this, "请选择要批量删除的专题!", "SpecialList.aspx");
        string SpecialID = Request.Form["S_ID"];
        SpecialID = Common.Input.Losestr(SpecialID);
        if (SpecialID == "IsNull")
            Common.MessageBox.ShowAndRedirect(this, "请选择要批量删除的专题!", "SpecialList.aspx");

        if (mode == "Re")
        {
            NewsSpecialCMS.SetRecyle(SpecialID);
            Common.MessageBox.ShowAndRedirect(this, "将专题删除到回收站成功!", "SpecialList.aspx");
        }
        else
        {
            this.Authority_Code = "C0401";
            this.CheckAdminAuthority();
            NewsSpecialCMS.DeleteList(SpecialID);
            Common.MessageBox.ShowAndRedirect(this, "彻底删除成功!", "SpecialList.aspx");
        }
    }

    /// <summary>
    /// 批量锁定专题
    /// </summary>
    /// <returns>批量锁定专题</returns>
    protected void Plock()
    {
        string str_SID = Request.Form["S_ID"];
        str_SID = Common.Input.Losestr(str_SID);
        if (str_SID == "IsNull")
            Common.MessageBox.ShowAndRedirect(this, "请选择要批量锁定的专题!", "SpecialList.aspx");
        NewsSpecialCMS.SetLock(str_SID);
        Common.MessageBox.ShowAndRedirect(this, "批量锁定成功!", "SpecialList.aspx");
    }

    /// <summary>
    /// 批量解锁专题
    /// </summary>
    /// <returns>批量解锁专题</returns>
    protected void PUnlock()
    {
        string SpecialId = Request.Form["S_ID"];
        SpecialId = Common.Input.Losestr(SpecialId);
        if (SpecialId == "IsNull")
            Common.MessageBox.ShowAndRedirect(this, "请选择要批量解锁的专题!", "SpecialList.aspx");

        NewsSpecialCMS.SetLock(SpecialId);
        Common.MessageBox.ShowAndRedirect(this, "批量解锁成功!\n如果批量选中的专题还有未解锁的,请先解锁此专题的父专题!", "SpecialList.aspx");
    }


    protected void Publish()
    {
        string str_SID = Request.Form["S_ID"];
        str_SID = Common.Input.Losestr(str_SID);
        if (str_SID == "IsNull")
            Common.MessageBox.ShowAndRedirect(this, "请选择要生成的专题!", "SpecialList.aspx");

        string[] arr_SID = str_SID.Split(',');

        Common.HProgressBar.Start();
        Foosun.Publish.General PG = new Foosun.Publish.General();
        Foosun.CMS.sys param = new Foosun.CMS.sys();
        string publishType = param.GetParamBase("publishType");
        try
        {
            Common.HProgressBar.Roll("正在发布专题", 0);
            int j = 0;
            int m = arr_SID.Length;
            for (int i = 0; i < m; i++)
            {
                if (publishType == "0")
                {
                    if (PG.PublishSingleSpecial(arr_SID[i].ToString().Replace("'", "")))
                        j++;
                }
                else
                {
                    DataTable dt = NewsSpecialCMS.GetContent("ID,SpecialID,SpecialCName,SpecialEName,ParentID,Domain,SavePath,FileName,FileEXName,SaveDirPath", " SpecialID='" + arr_SID[i].ToString().Replace("'", "") + "'", "");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Foosun.Publish.DropPublish dp = new Foosun.Publish.DropPublish();
                        if (dp.publish(dt.Rows[0], "special"))
                            j++;
                    }
                }
                Common.HProgressBar.Roll("共生成" + m + "个专题，正在发布" + (i + 1) + "个。", ((i + 1) * 100 / m));
            }
            Common.HProgressBar.Roll("发布专题成功,成功" + j + "个,<a href=\"../Publish/error/geterror.aspx?\">失败" + (arr_SID.Length - j) + "个(可能有专题有浏览权限)</a>. &nbsp;<a href=\"speciallist.aspx\">返回</a>", 100);
        }
        catch (Exception ex)
        {
            Common.Public.savePublicLogFiles("□□□发布专题", "【错误描述：】\r\n" + ex.ToString(), UserName);
            Common.HProgressBar.Roll("发布专题失败。<a href=\"../publish/error/geterror.aspx?\">查看日志</a>", 0);
        }
        Response.End();
        
    }


    protected void makeHTML(object sender, EventArgs e)
    {
        string Str = Request.Form["Checkbox1"];
        if (Str == null || Str == String.Empty)
        {
            PageError("请至少选择一项!", "");
        }
        else
        {

        }
    }

    /// <summary>
    /// 获得当前专题下面的新闻数目
    /// </summary>
    /// <param name="ID">专题编号</param>
    /// <returns>获得当前专题下面的新闻数目</returns>
    protected string GetSpicaelNewsNum(string SID)
    {
        return NewsSpecialCMS.GetSpicaelNewsCount(SID).ToString();
    }

    protected void search_button_Click(object sender, EventArgs e)
    {
        if (search_SpecialCName.Text == "") StartLoad(1, false);
        else StartLoad(1, true);
    }
}

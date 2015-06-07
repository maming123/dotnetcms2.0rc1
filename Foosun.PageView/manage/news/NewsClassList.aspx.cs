using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.news
{
    public partial class NewsClassList : Foosun.PageBasic.ManagePage
    {
        public NewsClassList()
        {
            Authority_Code = "C019";
        }
        Foosun.CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
        Foosun.CMS.RootPublic RootPublicCMS = new CMS.RootPublic();
        Foosun.CMS.UserLogin _UL = new Foosun.CMS.UserLogin();
        public static string _AllPopClassList;
        public static DataTable dtcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            if (!IsPostBack)
            {
                dtcount = NewsClassCMS.GetNewsCount();
                string stat = Request.QueryString["Stat"];
                if (stat != "" && stat != null)
                {
                    this.Authority_Code = "C029";
                    this.CheckAdminAuthority();
                    string Classid = Common.Input.Filter(Request.QueryString["id"]);
                    NewsClassCMS.SetLock(Classid);
                    RootPublicCMS.SaveUserAdminLogs(0, 1, UserNum, "锁定/解锁操作", "锁定/解锁操作栏目.ClassID:" + Request.Form["Checkbox1"] + "");
                    Common.MessageBox.ShowAndRedirect(this, "锁定/解锁操作栏目成功!", "NewsClassList.aspx");
                }
                _AllPopClassList = _UL.GetAdminGroupClassList();
                string getSiteID = Request.QueryString["SiteID"];
                if (SiteID == "0")
                {
                    if (getSiteID != null && getSiteID != "")
                    {
                        channelList.InnerHtml = "&nbsp;&nbsp;" + SiteList(getSiteID.ToString());
                    }
                    else
                    {
                        channelList.InnerHtml = "&nbsp;&nbsp;" + SiteList(SiteID);
                    }
                }
                StartLoad(1);
            }

            if (Request.QueryString["Type"] == "orderAction")
            {
                this.Authority_Code = "C097";
                this.CheckAdminAuthority();
                string ClassId = Common.Input.Filter(Request.QueryString["ClassId"].ToString());
                int orderId = int.Parse(Request.QueryString["OrderId"].ToString());
                UpdateOrder(ClassId, orderId);
            }
        }

        //更新权重
        protected void UpdateOrder(string ClassID, int OrderID)
        {
            NewsClassCMS.SetOrder(ClassID, OrderID);
            RootPublicCMS.SaveUserAdminLogs(0, 1, UserNum, "更新权重", "ClassID:" + ClassID + "");
            Common.MessageBox.ShowAndRedirect(this, "更新权重成功!", "NewsClassList.aspx");
        }
        //数据初始化
        protected void StartLoad(int pageIndex)
        {
            string SiteID = Request.QueryString["SiteID"] == null ? "0" : Request.QueryString["SiteID"];
            int RecordCount = 0;
            int PageCount = 0;
            DataTable dt = NewsClassCMS.GetPage(SiteID, Foosun.Config.UIConfig.GetPageSize(), pageIndex, out RecordCount, out PageCount);
            if (dt != null)
            {
                dt.Columns.Add("st", typeof(string));
                dt.Columns.Add("pop", typeof(string));
                dt.Columns.Add("Colum", typeof(string));
                dt.Columns.Add("ClassCNames", typeof(string));

                this.PageNavigator1.PageCount = PageCount;
                this.PageNavigator1.PageIndex = pageIndex;
                this.PageNavigator1.RecordCount = RecordCount;

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    this.ClassID = dt.Rows[k]["classid"].ToString();
                    string count = dtcount.Select("ClassID='" + dt.Rows[k]["ClassID"].ToString() + "'").Length == 0 ? "0" : dtcount.Select("ClassID='" + dt.Rows[k]["ClassID"].ToString() + "'")[0][0].ToString();
                    if (_AllPopClassList != "isSuper" && _AllPopClassList.IndexOf(dt.Rows[k]["classid"].ToString()) < 0)
                    {
                        dt.Rows[k]["Colum"] ="";
                    }
                    else
                    {
                        string strchar = "";
                        //取出子类
                        if (dt.Rows[k]["isPage"].ToString() == "1")
                        {
                            dt.Rows[k]["ClassCNames"] = "<a href=\"NewsPage.aspx?Number=" + Server.UrlEncode(Convert.ToString(dt.Rows[k]["ClassID"])) + "&Action=Edit\" class=\"xa3\" title=\"点击修改单页面\">" + dt.Rows[k]["ClassCName"] + "</a>";
                        }
                        else
                        {
                            dt.Rows[k]["ClassCNames"] = "<a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(dt.Rows[k]["ClassCName"])) + "&Acation=Add," + dt.Rows[k]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"xa3\" title=\"点击修改栏目&#13;栏目模板：" + dt.Rows[k]["ClassTemplet"].ToString() + "&#13;内容模板：" + dt.Rows[k]["ReadNewsTemplet"].ToString() + "\">" + dt.Rows[k]["ClassCName"] + "[" + dt.Rows[k]["ClassEname"] + "]</a>";
                        }
                        if (dt.Rows[k]["IsURL"].ToString() == "1")
                        {
                            dt.Rows[k]["st"] = "<font color=blue>外部</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            dt.Rows[k]["st"] = "<font color=red>系统</font>&nbsp;&nbsp;";
                        }
                        if (dt.Rows[k]["isPage"].ToString() == "1")
                        {
                            dt.Rows[k]["st"] += "<font color=\"#FF9900\">单页</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            dt.Rows[k]["st"] += "普通&nbsp;&nbsp;";
                        }

                        if (dt.Rows[k]["IsLock"].ToString() == "1")
                        {
                            dt.Rows[k]["st"] += "<a href=\"?Stat=Change&id=" + dt.Rows[k]["ClassID"] + "\" title=\"点击正常\" class=\"a1\">锁定</a> ";
                        }
                        else
                        {
                            dt.Rows[k]["st"] += "<a href=\"?Stat=Change&id=" + dt.Rows[k]["ClassID"] + "\" title=\"点击锁定\" class=\"a1\"><font color=\"#00FF00\">正常</font></a> ";
                        }

                        if (dt.Rows[k]["Domain"].ToString().Length > 5)
                        {
                            dt.Rows[k]["st"] += "<font color=\"blue\">域</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            dt.Rows[k]["st"] += "<font color=\"#999999\">域</font>&nbsp;&nbsp;";
                        }
                        if (dt.Rows[k]["NaviShowtf"].ToString() == "1")
                        {
                            dt.Rows[k]["st"] += "<font color=\"red\">显示</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            dt.Rows[k]["st"] += "隐藏&nbsp;&nbsp;";
                        }

                        string _TempStr = "";
                        if (dt.Rows[k]["IsURL"].ToString() == "0")
                        {
                            if (dt.Rows[k]["isPage"].ToString() == "0")
                            {
                                _TempStr = "<a class=\"xa3\" title=\"添加新闻\" href=\"NewsAdd.aspx?ClassID=" + dt.Rows[k]["ClassID"].ToString() + "&EditAction=add\">添加新闻</a><a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(dt.Rows[k]["ClassCName"])) + "&Number=" + dt.Rows[k]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"xa3\">添加子类</a><a href=\"NewsPage.aspx?Number=" + dt.Rows[k]["ClassID"] + "\" class=\"xa3\">添加单页面</a>";
                            }
                        }
                        if (dt.Rows[k]["isPage"].ToString() == "1")
                        {
                            dt.Rows[k]["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" class=\"xcheckbox1\" value=" + dt.Rows[k]["ClassID"] + " />&nbsp;&nbsp;<a href=\"NewsPage.aspx?Number=" + dt.Rows[k]["ClassID"] + "&Action=Edit\" class=\"xa3\">修改</a><a href=\"NewsPreview.aspx?ID=" + dt.Rows[k]["ClassID"] + "&type=class\" class=\"xa3\" target=\"_blank\">浏览</a>" + _TempStr + "";
                        }
                        else
                        {
                            dt.Rows[k]["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" class=\"xcheckbox1\" value=" + dt.Rows[k]["ClassID"] + " />&nbsp;&nbsp;<a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(dt.Rows[k]["ClassCName"])) + "&Acation=Add," + dt.Rows[k]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"xa3\">修改</a><a href=\"NewsPreview.aspx?ID=" + dt.Rows[k]["ClassID"] + "&type=class\" class=\"xa3\" target=\"_blank\">浏览</a>" + _TempStr + "";
                        }
                        if (this.CheckAuthority())
                        {
                            strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                            strchar += "<td  align=\"center\" valign=\"middle\" height=20>" + dt.Rows[k]["id"] + "</td>";
                            int IsChild = NewsClassCMS.ExistsChild(dt.Rows[k]["ClassId"].ToString());
                            if (IsChild > 0)
                                strchar += "<td  align=\"left\" valign=\"middle\" ><img id=\"img_parentid_" + dt.Rows[k]["ClassID"] + "\" src=\"../../sysImages/normal/b.gif\" style=\"cursor:hand\" onClick=\"javascript:SwitchImg(this,'" + dt.Rows[k]["ClassID"] + "');\"  border=\"0\">&nbsp;" + dt.Rows[k]["ClassCNames"] + "<span style=\"font-size:10px;color:red\" title=\"新闻数\">(" + count+ ")</span></td>";
                            else
                                strchar += "<td  align=\"left\" valign=\"middle\" ><img src=\"../../sysImages/normal/s.gif\" style=\"cursor:pointer;\" alt=\"没有子栏目\"  border=\"0\" class=\"LableItem\" />&nbsp;" + dt.Rows[k]["ClassCNames"] + "<span style=\"font-size:10px;color:red\" title=\"新闻数\">(" + count+ ")</span></td>";
                            strchar += "<td  align=\"center\" valign=\"middle\" ><a class=\"xa3\" href=\"javascript:orderAction('" + dt.Rows[k]["ClassID"] + "'," + dt.Rows[k]["OrderID"] + ");\" title=\"点击排序\"><strong>" + dt.Rows[k]["OrderID"] + "</a></strong></td>";
                            strchar += "<td  align=\"center\" valign=\"middle\" >" + dt.Rows[k]["st"] + "</td>";
                            strchar += "<td valign=\"middle\" >" + dt.Rows[k]["pop"] + "</td>";
                            strchar += "</tr>";
                            strchar += "<tr class=\"TR_BG_list\"><td colspan=\"5\"><div id=\"Parent" + dt.Rows[k]["ClassID"].ToString() + "\" style=\" display:none;\"></div></td></tr>";
                        }
                        else
                        {
                            strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                            strchar += "<td  align=\"center\" valign=\"middle\" height=20>" + dt.Rows[k]["id"] + "</td>";
                            int IsChild = NewsClassCMS.ExistsChild(dt.Rows[k]["ClassId"].ToString());
                            if (IsChild > 0)
                                strchar += "<td  align=\"left\" valign=\"middle\" ><img id=\"img_parentid_" + dt.Rows[k]["ClassID"] + "\" src=\"../../sysImages/normal/b.gif\" style=\"cursor:hand\" onClick=\"javascript:SwitchImg(this,'" + dt.Rows[k]["ClassID"] + "');\"  border=\"0\">&nbsp;" + dt.Rows[k]["ClassCName"] + "<span style=\"font-size:10px;color:red\" title=\"新闻数\">(" + count+ ")</span></td>";
                            else
                                strchar += "<td  align=\"left\" valign=\"middle\" ><img src=\"../../sysImages/normal/s.gif\" style=\"cursor:pointer;\" alt=\"没有子栏目\"  border=\"0\" class=\"LableItem\" />&nbsp;" + dt.Rows[k]["ClassCNames"] + "<span style=\"font-size:10px;color:red\" title=\"新闻数\">(" + count+ ")</span></td>";
                            strchar += "<td  align=\"center\" valign=\"middle\" ><a class=\"xa3\" href=\"javascript:orderAction('" + dt.Rows[k]["ClassID"] + "'," + dt.Rows[k]["OrderID"] + ");\" title=\"点击排序\"><strong>" + dt.Rows[k]["OrderID"] + "</a></strong></td>";
                            strchar += "<td  align=\"center\" valign=\"middle\"></td>";
                            strchar += "<td valign=\"middle\"></td>";
                            strchar += "</tr>";
                            strchar += "<tr class=\"TR_BG_list\"><td colspan=\"5\"><div id=\"Parent" + dt.Rows[k]["ClassID"].ToString() + "\" style=\" display:none;\"></div></td></tr>";
                        }

                        //strchar += getchildClassList(dt.Rows[k]["ClassID"].ToString(), "┝");
                        dt.Rows[k]["Colum"] = strchar;
                    }
                }
            }
            rpt_list.DataSource = dt;
            rpt_list.DataBind();
        }

        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            StartLoad(PageIndex);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //权限管理
            this.Authority_Code = "C024";
            this.CheckAdminAuthority();

            string str_ClassID = Request.Form["Checkbox1"];
            if (str_ClassID != null && str_ClassID != "")
                str_ClassID = "'" + str_ClassID.Replace(",", "','") + "'";
            else
                PageError("没有选择任何栏目！", "NewsClassList.aspx");
            NewsClassCMS.ResetClass(str_ClassID);
            Common.MessageBox.ShowAndRedirect(this, "操作成功,此操作对锁定栏目无效!", "NewsClassList.aspx");
        }

        /// <summary>
        /// 初始化栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void del_allClass(object sender, EventArgs e)
        {
            //权限管理
            this.Authority_Code = "C027";
            this.CheckAdminAuthority();
            NewsClassCMS.InitializeClass();
            RootPublicCMS.SaveUserAdminLogs(1, 1, UserNum, "初始化栏", "删除了所有栏目及内容信息");
            //此处进行静态文件的删除
            Common.MessageBox.ShowAndRedirect(this, "初始化栏成功!", "NewsClassList.aspx");
        }

        //批量锁定/解锁数据
        protected void Lock_Click(object sender, EventArgs e)
        {
            this.Authority_Code = "C029";
            this.CheckAdminAuthority();
            string Str = Request.Form["Checkbox1"];
            if (Str == null || Str == string.Empty)
            {
                Common.MessageBox.Show(this, "请至少选择一项!");
            }
            else
            {
                string[] Checkbox = (Str.ToString()).Split(',');
                for (int i = 0; i < Checkbox.Length; i++)
                {
                    NewsClassCMS.SetLock(Checkbox[i]);
                }
                RootPublicCMS.SaveUserAdminLogs(0, 1, UserNum, "锁定/解锁操作", "锁定/解锁操作栏目.ClassID:" + Request.Form["Checkbox1"] + "");
                //此处进行静态文件的删除
                Common.MessageBox.ShowAndRedirect(this, "锁定/解锁操作栏目成功,请返回继续操作!", "NewsClassList.aspx");
            }
        }

        //放入回收站
        protected void AllDel_Click(object sender, EventArgs e)
        {
            this.Authority_Code = "CE01";
            this.CheckAdminAuthority();
            String Str = Request.Form["Checkbox1"];
            if (Str == null || Str == String.Empty)
            {
                Common.MessageBox.Show(this, "请先选择删除项!");
            }
            else
            {
                String[] Checkbox = Str.Split(',');
                Str = null;
                for (int i = 0; i < Checkbox.Length; i++)
                {
                    //如果此栏目下有新闻则不删除
                    if (dtcount.Select("ClassID='" + Checkbox[i].ToString() + "'").Length== 0)
                    {
                        DataTable dt = NewsClassCMS.GetChildList(Checkbox[i]);
                        if (dt.Rows.Count == 0)
                        {
                            NewsClassCMS.SetRecyle(Checkbox[i]);
                            NewsClassCMS.SetChildClassRecyle(Checkbox[i]);
                        }
                        else
                        {
                            Common.MessageBox.ShowAndRedirect(this, "删除数据到回收站失败!此栏目下有子栏目,不能删除!", "NewsClassList.aspx");
                        }
                    }
                    else
                    {
                        Common.MessageBox.ShowAndRedirect(this, "删除数据到回收站失败!栏目下的新闻不能删除!", "NewsClassList.aspx");
                    }
                }
                RootPublicCMS.SaveUserAdminLogs(1, 1, UserNum, "删除栏目", "删除栏目到回收站.ClassID:" + Request.Form["Checkbox1"] + "");
                Common.MessageBox.ShowAndRedirect(this, "删除数据到回收站成功,请返回继续操作!", "NewsClassList.aspx");
            }
        }

        //彻底批量删除数据
        protected void Selected_del_Click(object sender, EventArgs e)
        {
            this.Authority_Code = "C030";
            this.CheckAdminAuthority();
            String Str = Request.Form["Checkbox1"];
            if (Str == null || Str == String.Empty)
            {
                Common.MessageBox.Show(this, "请先选择删除项!");
            }
            else
            {
                String[] Checkbox = Str.Split(',');
                Str = null;
                for (int i = 0; i < Checkbox.Length; i++)
                {
                    //如果此栏目下有新闻则不删除
                    if (dtcount.Select("ClassID='" + Checkbox[i].ToString() + "'").Length == 0)
                    {
                        DataTable dt = NewsClassCMS.GetChildList(Checkbox[i]);
                        if (dt.Rows.Count == 0)
                        {
                            NewsClassCMS.DelSouce(Checkbox[i]);
                            NewsClassCMS.DelChildClass(Checkbox[i]);
                        }
                        else
                        {
                            Common.MessageBox.ShowAndRedirect(this, "删除数据到回收站失败!此栏目下有子栏目,不能删除!", "NewsClassList.aspx");
                        }
                    }
                    else
                    {
                        Common.MessageBox.ShowAndRedirect(this, "彻底删除栏目失败!原因:此栏目下有新闻!", "NewsClassList.aspx");
                    }
                }
                RootPublicCMS.SaveUserAdminLogs(1, 1, UserNum, "删除栏目", "彻底删除栏目.ClassID:" + Request.Form["Checkbox1"] + "");
                //此处进行静态文件的删除
                Common.MessageBox.ShowAndRedirect(this, "彻底删除栏目成功!", "NewsClassList.aspx");
            }
        }

        /// <summary>
        /// 生成XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MakeXML(object sender, EventArgs e)
        {
            this.Authority_Code = "C031";
            this.CheckAdminAuthority();
            string Str = Request.Form["Checkbox1"];
            if (Str == null || Str == String.Empty)
            {
                Common.MessageBox.Show(this, "请至少选择一项!");
            }
            else
            {
                string[] Checkbox = Str.Split(',');
                Str = null;
                int j = 0;
                for (int i = 0; i < Checkbox.Length; i++)
                {
                    if (Foosun.Publish.General.PublishXML(Checkbox[i]))
                    {
                        j++;
                    }
                }
                Common.MessageBox.ShowAndRedirect(this, "生成" + j + "个XML成功!", "NewsClassList.aspx");
            }
        }

        /// <summary>
        /// 生成HTML,生成静态文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MakeHTML(object sender, EventArgs e)
        {
            this.Authority_Code = "C032";
            this.CheckAdminAuthority();
            string Str = Request.Form["Checkbox1"];
            if (Str == null || Str == String.Empty)
            {
                Common.MessageBox.Show(this, "请至少选择一项!");
            }
            else
            {
                Common.HProgressBar.Start();
                Foosun.Publish.General PG = new Foosun.Publish.General();
                try
                {
                    Common.HProgressBar.Roll("正在发布栏目", 0);
                    string[] Checkboxs = Str.Split(',');
                    Str = null;
                    int j = 0;
                    int m = Checkboxs.Length;
                    for (int i = 0; i < m; i++)
                    {
                        Foosun.CMS.sys param = new CMS.sys();
                        string publishType = param.GetParamBase("publishType");
                        if (NewsClassCMS.GetClassPage(Checkboxs[i]) == 0)
                        {
                            if (publishType == "0")
                            {
                                if (PG.PublishSingleClass(Checkboxs[i].ToString()))
                                {
                                    j++;
                                }
                            }
                            else
                            {
                                DataTable dt = NewsClassCMS.GetContent("ID,ClassID,ClassCName,ClassEName,ParentID,SavePath,FileName,ClassSaveRule,MetaDescript,MetaKeywords", " ClassID='" + Checkboxs[i].ToString() + "'", "");
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    Foosun.Publish.DropPublish dp = new Foosun.Publish.DropPublish();
                                    if (dp.publish(dt.Rows[0], "class"))
                                    {
                                        j++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (publishType == "0")
                            {
                                if (Foosun.Publish.General.PublishPage(Checkboxs[i].ToString()))
                                {
                                    j++;
                                }
                            }
                            else
                            {
                                DataTable dt = NewsClassCMS.GetContent("ID,ClassID,ClassCName,ClassEName,ParentID,SavePath,FileName,ClassSaveRule,MetaDescript,MetaKeywords", " ClassID='" + Checkboxs[i].ToString() + "'", "");
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    Foosun.Publish.DropPublish dp = new Foosun.Publish.DropPublish();
                                    if (dp.publish(dt.Rows[0], "page"))
                                    {
                                        j++;
                                    }
                                }
                            }
                        }
                        Common.HProgressBar.Roll("共生成" + m + "个栏目，正在发布" + (i + 1) + "个。", ((i + 1) * 100 / m));
                    }
                    Common.HProgressBar.Roll("发布栏目成功,成功" + j + "个,<a href=\"../Publish/error/geterror.aspx?\">失败" + (Checkboxs.Length - j) + "个(可能有栏目有浏览权限)</a>. &nbsp;<a href=\"NewsClassList.aspx\">返回</a>", 100);
                }
                catch (Exception ex)
                {
                    Common.Public.savePublicLogFiles("□□□发布栏目", "【错误描述：】\r\n" + ex.ToString(), UserName);
                    Common.HProgressBar.Roll("发布栏目失败。<a href=\"../publish/error/geterror.aspx?\">查看日志</a>", 0);
                }
                Response.End();
            }
        }

        protected void MakeClassIndex(object sender, EventArgs e)
        {
            string Str = Request.Form["Checkbox1"];
            if (Str == null || Str == String.Empty)
            {
                Common.MessageBox.Show(this, "请至少选择一项!");
            }
            else
            {
                string[] Checkboxs = Str.Split(',');
                Str = null;
                int j = 0;
                int m = 0;
                for (int i = 0; i < Checkboxs.Length; i++)
                {
                    if (NewsClassCMS.GetClassPage(Checkboxs[i]) == 0)
                    {
                        if (Foosun.Publish.General.PublishClassIndex(Checkboxs[i]))
                        {
                            j++;
                        }
                        else
                        {
                            m++;
                        }
                    }
                }
                PageRight("共生成" + j + "个栏目!失败" + m + "个栏目。\n如果生成有差异，可能是您选择了单页面", "NewsClassList.aspx");
            }
        }

        /// <summary>
        /// 清除数据
        /// 清空栏目数据 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ClearNewsInfo(object sender, EventArgs e)
        {
            this.Authority_Code = "C033";
            this.CheckAdminAuthority();
            String Str = Request.Form["Checkbox1"];
            if (Str == null || Str == String.Empty)
            {
                Common.MessageBox.Show(this, "请至少选择一项!");
            }
            else
            {
                String[] Checkbox = Str.Split(',');
                Str = null;
                for (int i = 0; i < Checkbox.Length; i++)
                {
                    NewsClassCMS.ClearNews(Checkbox[i]);
                }
                RootPublicCMS.SaveUserAdminLogs(1, 1, UserNum, "清除数据", "清除数据.ClassID:" + Request.Form["Checkbox1"] + "");
                Common.MessageBox.ShowAndRedirect(this, "清除数据成功!", "NewsClassList.aspx");
            }
        }

        protected void CustomShow_Click(object sender, EventArgs e)
        {
            StartLoadCustom(1);
        }
        DataTable NewsClassTable = new DataTable();

        //数据初始化
        protected void StartLoadCustom(int PageIndex)
        {
            string SiteId = Request.QueryString["SiteID"];
            if (SiteId != null && SiteId != string.Empty)
            {
                NewsClassTable = NewsClassCMS.GetList("isRecyle<>1 and SiteID='" + SiteId + "'");
            }
            else
            {
                NewsClassTable = NewsClassCMS.GetList("isRecyle<>1 and SiteID='0'");
            }
            if (NewsClassTable != null)
            {
                NewsClassTable.Columns.Add("st", typeof(string));
                NewsClassTable.Columns.Add("pop", typeof(string));
                NewsClassTable.Columns.Add("Colum", typeof(string));
                NewsClassTable.Columns.Add("ClassCNames", typeof(string));
                for (int k = 0; k < NewsClassTable.Rows.Count; k++)
                {
                    this.ClassID = NewsClassTable.Rows[k]["ClassId"].ToString();
                    string count = dtcount.Select("ClassID='" + NewsClassTable.Rows[k]["ClassID"].ToString() + "'").Length == 0 ? "0" : dtcount.Select("ClassID='" + NewsClassTable.Rows[k]["ClassID"].ToString() + "'")[0][0].ToString();
                    string strchar = "";
                    //取出子类
                    if (NewsClassTable.Rows[k]["isPage"].ToString() == "1")
                    {
                        NewsClassTable.Rows[k]["ClassCNames"] = "<a href=\"NewsPage.aspx?Number=" + NewsClassTable.Rows[k]["ClassID"] + "&Action=Edit\" class=\"xa3\" title=\"点击修改单页面\">" + NewsClassTable.Rows[k]["ClassCName"] + "</a>";
                    }
                    else
                    {
                        NewsClassTable.Rows[k]["ClassCNames"] = "<a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(NewsClassTable.Rows[k]["ClassCName"])) + "&Acation=Add," + NewsClassTable.Rows[k]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"xa3\" title=\"点击修改栏目&#13;栏目模板：" + NewsClassTable.Rows[k]["ClassTemplet"].ToString() + "&#13;内容模板：" + NewsClassTable.Rows[k]["ReadNewsTemplet"].ToString() + "\">" + NewsClassTable.Rows[k]["ClassCName"] + "[" + NewsClassTable.Rows[k]["ClassEname"] + "]</a>";
                    }
                    if (NewsClassTable.Rows[k]["IsURL"].ToString() == "1")
                    {
                        NewsClassTable.Rows[k]["st"] = "<font color=blue>外部</font>&nbsp;&nbsp;";
                    }
                    else
                    {
                        NewsClassTable.Rows[k]["st"] = "<font color=red>系统</font>&nbsp;&nbsp;";
                    }
                    if (NewsClassTable.Rows[k]["isPage"].ToString() == "1")
                    {
                        NewsClassTable.Rows[k]["st"] += "<font color=\"#FF9900\">单页</font>&nbsp;&nbsp;";
                    }
                    else
                    {
                        NewsClassTable.Rows[k]["st"] += "普通&nbsp;&nbsp;";
                    }

                    if (NewsClassTable.Rows[k]["IsLock"].ToString() == "1")
                    {
                        NewsClassTable.Rows[k]["st"] += "<a href=\"?Stat=Change&id=" + NewsClassTable.Rows[k]["ClassID"] + "\" title=\"点击正常\" class=\"xa3\">锁定</a> ";
                    }
                    else
                    {
                        NewsClassTable.Rows[k]["st"] += "<a href=\"?Stat=Change&id=" + NewsClassTable.Rows[k]["ClassID"] + "\" title=\"点击锁定\" class=\"xa3\"><font color=\"#00FF00\">正常</font></a> ";
                    }

                    if (NewsClassTable.Rows[k]["Domain"].ToString().Length > 5)
                    {
                        NewsClassTable.Rows[k]["st"] += "<font color=\"blue\">域</font>&nbsp;&nbsp;";
                    }
                    else
                    {
                        NewsClassTable.Rows[k]["st"] += "<font color=\"#999999\">域</font>&nbsp;&nbsp;";
                    }
                    if (NewsClassTable.Rows[k]["NaviShowtf"].ToString() == "1")
                    {
                        NewsClassTable.Rows[k]["st"] += "<font color=\"red\">显示</font>&nbsp;&nbsp;";
                    }
                    else
                    {
                        NewsClassTable.Rows[k]["st"] += "隐藏&nbsp;&nbsp;";
                    }

                    string _TempStr = "";
                    if (NewsClassTable.Rows[k]["IsURL"].ToString() == "0")
                    {
                        if (NewsClassTable.Rows[k]["isPage"].ToString() == "0")
                        {
                            _TempStr = "<a title=\"添加新闻\" class=\"xa3\" href=\"NewsAdd.aspx?ClassID=" + NewsClassTable.Rows[k]["ClassID"].ToString() + "&EditAction=add\">添加新闻</a><a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(NewsClassTable.Rows[k]["ClassCName"])) + "&Number=" + NewsClassTable.Rows[k]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"xa3\">添加子类</a><a href=\"NewsPage.aspx?Number=" + NewsClassTable.Rows[k]["ClassID"] + "\" class=\"xa3\">添加单页面</a>";
                        }
                    }
                    if (NewsClassTable.Rows[k]["isPage"].ToString() == "1")
                    {
                        NewsClassTable.Rows[k]["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" value=" + NewsClassTable.Rows[k]["ClassID"] + " />&nbsp;&nbsp;<a href=\"NewsPage.aspx?Number=" + NewsClassTable.Rows[k]["ClassID"] + "&Action=Edit\" class=\"xa3\">修改</a><a href=\"NewsPreview.aspx?ID=" + NewsClassTable.Rows[k]["ClassID"] + "&type=class\" class=\"xa3\" target=\"_blank\">浏览</a>" + _TempStr + "";
                    }
                    else
                    {
                        NewsClassTable.Rows[k]["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" value=" + NewsClassTable.Rows[k]["ClassID"] + " />&nbsp;&nbsp;<a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(NewsClassTable.Rows[k]["ClassCName"])) + "&Acation=Add," + NewsClassTable.Rows[k]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"a1\">修改</a><a href=\"NewsPreview.aspx?ID=" + NewsClassTable.Rows[k]["ClassID"] + "&type=class\" class=\"a1\" target=\"_blank\">浏览</a>" + _TempStr + "";
                    }

                    if (!this.CheckAuthority())
                    {
                        NewsClassTable.Rows[k]["ClassCNames"] = NewsClassTable.Rows[k]["ClassCName"];
                        strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                        strchar += "<td  align=\"center\" valign=\"middle\" height=20>" + NewsClassTable.Rows[k]["id"] + "</td>";
                        strchar += "<td  align=\"left\" valign=\"middle\" ><img src=\"../../sysImages/normal/s.gif\" border=\"0\">&nbsp;" + NewsClassTable.Rows[k]["ClassCNames"] + "<span style=\"font-size:10px;color:red\" title=\"新闻数\">(" + count+ ")</span></td>";
                        strchar += "<td  align=\"center\" valign=\"middle\" ><strong>" + NewsClassTable.Rows[k]["OrderID"] + "</strong></td>";
                        strchar += "<td  align=\"center\" valign=\"middle\" ></td>";
                        strchar += "<td valign=\"middle\" >" + "无权限" + "</td>";
                        strchar += "</tr>";
                    }
                    else
                    {
                        strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                        strchar += "<td  align=\"center\" valign=\"middle\" height=20>" + NewsClassTable.Rows[k]["id"] + "</td>";
                        strchar += "<td  align=\"left\" valign=\"middle\" ><img src=\"../../sysImages/normal/s.gif\" border=\"0\">&nbsp;" + NewsClassTable.Rows[k]["ClassCNames"] + "<span style=\"font-size:10px;color:red\" title=\"新闻数\">(" + count + ")</span></td>";
                        strchar += "<td  align=\"center\" valign=\"middle\" ><a class=\"xa3\" href=\"javascript:orderAction('" + NewsClassTable.Rows[k]["ClassID"] + "'," + NewsClassTable.Rows[k]["OrderID"] + ");\" title=\"点击排序\"><strong>" + NewsClassTable.Rows[k]["OrderID"] + "</a></strong></td>";
                        strchar += "<td  align=\"center\" valign=\"middle\" >" + NewsClassTable.Rows[k]["st"] + "</td>";
                        strchar += "<td valign=\"middle\" >" + NewsClassTable.Rows[k]["pop"] + "</td>";
                        strchar += "</tr>";
                    }
                    strchar += GetChildClassList(NewsClassTable.Rows[k]["ClassID"].ToString(), "┝");
                    NewsClassTable.Rows[k]["Colum"] = strchar;
                }
            }
            DataView dv = new DataView(NewsClassTable, "ParentID='0'", "OrderID Desc,id desc", DataViewRowState.CurrentRows);
            rpt_list.DataSource = dv;
            rpt_list.DataBind();
            NewsClassTable.Clear();
            NewsClassTable.Dispose();
            NewsClassTable = null;
        }

        protected void treeShow_Click(object sender, EventArgs e)
        {
            this.HiddenField_ParentID.Value = "";
            Session["__ParentIDList"] = null;
            this.StartLoad(1);
        }

        /// <summary>
        /// 得到站点列表
        /// </summary>
        /// <param name="SessionSiteID">内存总的SiteID</param>
        /// <returns>返回列表</returns>
        protected string SiteList(string SessionSiteID)
        {
            string siteStr = "<select name=\"SiteID\" id=\"SiteID\" onChange=\"getchanelInfo(this)\">\r";
            Foosun.CMS.UserMisc rd = new Foosun.CMS.UserMisc();
            DataTable crs = rd.getSiteList();
            if (crs != null)
            {
                for (int i = 0; i < crs.Rows.Count; i++)
                {
                    string getSiteID = SessionSiteID;
                    string SiteID1 = crs.Rows[i]["ChannelID"].ToString();
                    if (getSiteID != SiteID1)
                    {
                        siteStr += "<option value=\"" + crs.Rows[i]["ChannelID"] + "\">" + crs.Rows[i]["CName"] + "</option>\r";
                    }
                    else
                    {
                        siteStr += "<option value=\"" + crs.Rows[i]["ChannelID"] + "\"  selected=\"selected\">" + crs.Rows[i]["CName"] + "</option>\r";
                    }
                }
            }
            //}
            siteStr += "</select>\r";
            return siteStr;
        }

        //递归
        string GetChildClassList(string Classid, string sign)
        {
            string strchar = "";

            sign += " ┉ ";
            if (NewsClassTable != null)
            {
                if (NewsClassTable.Rows.Count > 0)
                {

                    DataRow[] rows = NewsClassTable.Select(string.Format("ParentID='{0}'", Classid.Replace("'", "''")), "OrderID Desc,id desc");
                    foreach (DataRow row in rows)
                    {
                        this.ClassID = row["classid"].ToString();
                        string count = dtcount.Select("ClassID='" + row["ClassID"].ToString() + "'").Length == 0 ? "0" : dtcount.Select("ClassID='" + row["ClassID"].ToString() + "'")[0][0].ToString();
                        if (row["isPage"].ToString() == "1")
                        {
                            row["ClassCNames"] = "<a href=\"NewsPage.aspx?Number=" + row["ClassID"] + "&Action=Edit\" title=\"点击修改单页面\">" + row["ClassCName"] + "</a>";
                        }
                        else
                        {
                            row["ClassCNames"] = "<a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(row["ClassCName"])) + "&Acation=Add," + row["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" title=\"点击修改栏目\">" + row["ClassCName"] + "[" + row["ClassEname"] + "]</a>";
                        }
                        if (row["IsURL"].ToString() == "1")
                        {
                            row["st"] = "<font color=\"blue\">外部</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            row["st"] = "<font color=\"red\">系统</font>&nbsp;&nbsp;";
                        }
                        if (row["isPage"].ToString() == "1")
                        {
                            row["st"] += "<font color=\"#FF9900\">单页</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            row["st"] += "普通&nbsp;&nbsp;";
                        }
                        if (row["IsLock"].ToString() == "1")
                        {
                            row["st"] += "<a href=\"?Stat=Change&id=" + row["ClassID"] + "\" title=\"点击正常\" class=\"xa3\">锁定</a> ";
                        }
                        else
                        {
                            row["st"] += "<a href=\"?Stat=Change&id=" + row["ClassID"] + "\" title=\"点击锁定\" class=\"xa3\"><font color=\"#00FF00\">正常</font></a> ";
                        }
                        if (row["Domain"].ToString().Length > 5)
                        {
                            row["st"] += "<font color=\"blue\">域</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            row["st"] += "<font color=\"#999999\">域</font>&nbsp;&nbsp;";
                        }
                        if (row["NaviShowtf"].ToString() == "1")
                        {
                            row["st"] += "<font color=\"red\">显示</font>&nbsp;&nbsp;";
                        }
                        else
                        {
                            row["st"] += "隐藏&nbsp;&nbsp;";
                        }

                        string _TempStr = "";
                        if (row["IsURL"].ToString() == "0")
                        {
                            if (row["isPage"].ToString() == "0")
                            {
                                _TempStr = "<a title=\"添加新闻\" href=\"NewsAdd.aspx?ClassID=" + row["ClassID"].ToString() + "&EditAction=add\" class=\"xa3\">添加新闻</a><a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(row["ClassCName"])) + "&Number=" + row["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"xa3\">添加子类</a><a href=\"NewsPage.aspx?Number=" + row["ClassID"] + "\" class=\"xa3\">添加单页面</a>";
                            }
                        }
                        //操作
                        if (row["isPage"].ToString() == "1")
                        {
                            row["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" class=\"xcheckbox1\" value=" + row["ClassID"] + " />&nbsp;&nbsp;<a href=\"NewsPage.aspx?Number=" + row["ClassID"] + "&Action=Edit\" class=\"xa3\">修改</a><a href=\"NewsPreview.aspx?ID=" + row["ClassID"] + "&type=class\" class=\"xa3\" target=\"_blank\">浏览</a>" + _TempStr + "";
                        }
                        else
                        {
                            row["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" class=\"xcheckbox1\" value=" + row["ClassID"] + " />&nbsp;&nbsp;<a href=\"NewsClassAdd.aspx?Cname=" + Server.UrlEncode(Convert.ToString(row["ClassCName"])) + "&Acation=Add," + row["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "\" class=\"xa3\">修改</a><a href=\"NewsPreview.aspx?ID=" + row["ClassID"] + "&type=class\" class=\"xa3\" target=\"_blank\">浏览</a>" + _TempStr + "";
                        }

                        if (this.CheckAuthority())
                        {
                            strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                            strchar += "<td align=\"center\" valign=\"middle\" height=20>" + row["id"] + "</td>";
                            strchar += "<td align=\"left\" valign=\"middle\" >" + sign + row["ClassCNames"] + "<span style=\"font-size:10px;color:red;\" title=\"新闻数\">(" + count + ")</span></td>";
                            strchar += "<td align=\"center\" valign=\"middle\" ><a class=\"xa3\" href=\"javascript:orderAction('" + row["ClassID"] + "'," + row["OrderID"] + ");\" title=\"点击排序\"><strong>" + row["OrderID"] + "</strong></a></td>";
                            strchar += "<td align=\"center\" valign=\"middle\" >" + row["st"] + "</td>";
                            strchar += "<td valign=\"middle\" >" + row["pop"] + "</td>";
                            strchar += "</tr>";
                        }
                        else
                        {                           
                            strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                            strchar += "<td  align=\"center\" valign=\"middle\" height=20>" + row["id"] + "</td>";
                            strchar += "<td  align=\"left\" valign=\"middle\" ><img src=\"../../sysImages/normal/s.gif\" border=\"0\">&nbsp;" + row["ClassCName"] + "<span style=\"font-size:10px;color:red\" title=\"新闻数\">(" + count + ")</span></td>";
                            strchar += "<td  align=\"center\" valign=\"middle\" ><strong>" + row["OrderID"] + "</strong></td>";
                            strchar += "<td  align=\"center\" valign=\"middle\" ></td>";
                            strchar += "<td valign=\"middle\" >" + "无权限" + "</td>";
                            strchar += "</tr>";
                        }
                        strchar += GetChildClassList(row["ClassID"].ToString(), sign);
                        row["Colum"] = strchar;
                    }

                }
            }
            return strchar;
        }
    }
}
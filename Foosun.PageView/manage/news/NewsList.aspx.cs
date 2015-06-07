using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Common;

namespace Foosun.PageView.manage.news
{
    public partial class NewsList : Foosun.PageBasic.ManagePage
    {
        public NewsList()
        {
            Authority_Code = "C000";
        }
        Foosun.CMS.News cNews = new CMS.News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["type"] != null && Request.Form["idlist"] != null)
            {
                string idlist = Request.Form["idlist"];
                Response.Clear();
                switch (Request.Form["type"])
                {
                    case "Recycle":
                        this.Authority_Code = "C003";
                        this.CheckAdminAuthority();
                        Option_Recyle(idlist);
                        break;
                    case "Delete":
                        this.Authority_Code = "C003";
                        this.CheckAdminAuthority();
                        Option_Delete(idlist);
                        break;
                    case "CheckStat":
                        Option_CheckStat(idlist);
                        break;
                    case "AllCheckStat":
                        this.Authority_Code = "C096";
                        this.CheckAdminAuthority();
                        Option_AllCheck(idlist);
                        break;
                    case "Lock":
                        this.Authority_Code = "C008";
                        this.CheckAdminAuthority();
                        Option_Lock(idlist, 1);
                        break;
                    case "UNLock":
                        this.Authority_Code = "C008";
                        this.CheckAdminAuthority();
                        Option_Lock(idlist, 0);
                        break;
                    case "ResetOrder":
                        this.Authority_Code = "C007";
                        this.CheckAdminAuthority();
                        Option_ResetOrder(idlist);
                        break;
                    case "SetTop":
                        this.Authority_Code = "C011";
                        this.CheckAdminAuthority();
                        Option_SetTop(idlist, "10");
                        break;
                    case "UnSetTop":
                        this.Authority_Code = "C011";
                        this.CheckAdminAuthority();
                        Option_SetTop(idlist, "0");
                        break;
                    case "ToOldNewsClass":
                        this.Authority_Code = "C013";
                        this.CheckAdminAuthority();
                        Option_ToOld(idlist, 1);
                        break;
                    case "ToOldNews":
                        this.Authority_Code = "C012";
                        this.CheckAdminAuthority();
                        Option_ToOld(idlist, 0);
                        break;
                    case "DelClassNews":
                        this.Authority_Code = "C014";
                        this.CheckAdminAuthority();
                        Option_delNumber(idlist);
                        break;
                    case "makeFilesHTML":
                        this.Authority_Code = "C016";
                        this.CheckAdminAuthority();
                        Option_makeFilesHTML(idlist);
                        break;
                    case "XMLRefresh":
                        this.Authority_Code = "C017";
                        this.CheckAdminAuthority();
                        Option_XMLRefresh(idlist);
                        break;
                    default:
                        break;
                }
                Response.End();
            }
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            if (!IsPostBack)
            {
                string _TClassID = Request.QueryString["ClassID"];
                if (_TClassID != null)
                {
                    if (Foosun.Config.verConfig.PublicType != "1")
                    {
                        ClassNewsIndex.InnerHtml = "<span title=\"门户版功能\" style=\"color:#999999\">索引</span>";
                    }
                    else
                    {
                        ClassNewsIndex.InnerHtml = "<a href=\"javascript:makeClassIndex('" + _TClassID + "')\" title=\"生成此栏目的索引文件\" class=\"topnavichar\">索引</a>";
                    }
                    XMLFile.InnerHtml = "<a href=\"javascript:XMLRefresh('" + _TClassID + "')\" title=\"生成此栏目的XML文件\" class=\"topnavichar\">XML</a>";
                    naviClassName.InnerHtml = getNaviClassName(Request.QueryString["ClassID"].ToString()) + ">>新闻列表";
                    deltable.InnerHtml = "<a href=\"javascript:delSelectedNum()\">清空数据</a>";
                }
                else
                {
                    ClassNewsIndex.InnerHtml = "<span title=\"选择了栏目才能生成栏目索引\" style=\"color:#999999\">索引</span>";
                    XMLFile.InnerHtml = "<span title=\"选择了栏目才能生成栏目的XML文件\" style=\"color:#999999\">XML</span>";
                    deltable.InnerHtml = "<span style=\"color:#999999\" title=\"需要选择栏目\">清空数据</span>";
                    naviClassName.InnerHtml = " >>全部内容";
                }
                Foosun.CMS.UserMisc rd = new Foosun.CMS.UserMisc();
                DataTable SiteTB = rd.getSiteList();
                if (SiteTB != null)
                {
                    this.DdlSite.DataSource = SiteTB;
                    this.DdlSite.DataTextField = "CName";
                    this.DdlSite.DataValueField = "ChannelID";
                    this.DdlSite.DataBind();
                    if (Request.QueryString["ClassID"] != null && Request.QueryString["ClassID"] != "")
                    {
                        string _SiteID = "0";
                        Foosun.CMS.NewsClass cclass = new CMS.NewsClass();
                        DataTable dtsite = cclass.GetContent("SiteID", "ClassID='" + Request.QueryString["ClassID"].ToString() + "'", "");
                        if (dtsite.Rows.Count > 0)
                        {
                            _SiteID = dtsite.Rows[0][0].ToString();
                        }
                        DdlSite.SelectedValue = _SiteID;
                    }
                }

                if (SiteID != "0")
                {
                    this.DdlSite.Visible = false;
                }
                ListDataBind(1);
            }
        }
        /// <summary>
        /// 得到导航位置
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        string getNaviClassName(string ClassID)
        {
            string _Str = "";
            Foosun.CMS.NewsClass cclass = new CMS.NewsClass();
            IDataReader dr = cclass.GetNaviClass(ClassID);
            if (dr.Read())
            {
                _Str += ">><a href=\"Newslist.aspx?ClassID=" + dr["ClassID"].ToString() + "\" >" + dr["ClassCName"] + "</a>";
                if (dr["ParentID"] != DBNull.Value && dr["ParentID"].ToString() != "0")
                {
                    IDataReader dr2 = cclass.GetNaviClass(dr["ParentID"].ToString());
                    while (dr2.Read())
                    {
                        _Str = "<a href=\"Newslist.aspx?ClassID=" + dr2["ClassID"].ToString() + "\">" + dr2["ClassCName"] + "</a>" + _Str;
                        _Str = getNaviClassName(dr2["ParentID"].ToString()) + ">>" + _Str;
                    }
                    dr2.Close();
                }
            }
            dr.Close();
            return _Str;
        }
        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            ListDataBind(PageIndex);
        }
        void ListDataBind(int PageIndex)
        {
            string ClassID = "";
            string SpecialID = Input.Filter(Request.QueryString["SpecialID"]) ?? "";

            this.HiddenSpecialID.Value = SpecialID;

            if (Request.QueryString["ClassID"] != null && Request.QueryString["ClassID"].Trim() != "")
            {
                ClassID = Request.QueryString["ClassID"].ToString();
            }
            if (!string.IsNullOrEmpty(this._ClassID.Value))
            {
                ClassID = _ClassID.Value;
                this.keyWorks.Text = string.Empty;
            }
            string sKeywrd = Input.Filter(this.TxtKeywords.Text.Trim());
            string DdlKwdType = this.DdlKwdType.SelectedValue;
            string sChooses = this.LblChoose.Text.Trim();
            string site = "0";
            if (this.DdlSite.Visible == false)
            {
                site = SiteID;
            }
            else
            {
                site = this.DdlSite.SelectedValue;
            }
            int i = 0, j = 0;
            string Editor = "";
            if (Request.QueryString["Editor"] != null)
            {
                Editor = Request.QueryString["Editor"].ToString();
            }
            this.ClassID = ClassID;
            this.SpecailID = SpecialID;
            this.CheckAdminAuthority();
            int num = 20;
            DataTable dt = cNews.GetPage(SpecialID, Editor, ClassID, sKeywrd, DdlKwdType, sChooses, site, PageIndex, num, out i, out j);
            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = i;
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Columns.Add("op", typeof(string));
                dt.Columns.Add("htmllock", typeof(string));
                dt.Columns.Add("NewsTitles", typeof(string));
                dt.Columns.Add("CheckStats", typeof(string));
                dt.Columns.Add("isConstrs", typeof(string));
                dt.Columns.Add("CommNum", typeof(string));
                dt.Columns.Add("LblProperty", typeof(string));
                dt.Columns.Add("ImgOrder", typeof(string));
                dt.Columns.Add("Imgtype", typeof(string));
                ArrayList arrNotPop = new ArrayList();//存放没有权限的新闻下标
                for (int k = 0; dt.Rows.Count > k; k++)
                {
                    this.ClassID = dt.Rows[k]["ClassID"].ToString();
                    this.SpecailID = dt.Rows[k]["SpecialID"].ToString();
                    bool ispop = this.CheckAuthority();
                    if (!ispop)
                    {//如果没有权限,则将下标添加到集合中
                        arrNotPop.Add(dt.Rows[k]);
                        continue;
                    }
                    string _imgype = "";
                    switch (dt.Rows[k]["NewsType"].ToString())
                    {
                        case "0":
                            _imgype = "<img class=\"na1\" src=\"../imges/lie_49.gif\" title=\"普通内容\"/>";
                            break;
                        case "1":
                            _imgype = "<img class=\"na1\" src=\"../imges/news_img.gif\" title=\"图片信息,点击更改图片\"/>";
                            break;
                        case "2":
                            _imgype = "<img class=\"na1\" src=\"../imges/news_outer.gif\" title=\"标题信息\"/>";
                            break;
                        default:
                            _imgype = "<img class=\"na1\" src=\"../imges/lie_49.gif\" title=\"普通内容\"/>";
                            break;
                    }
                    dt.Rows[k]["Imgtype"] = _imgype;
                    string _ImgOrder = "";
                    if (dt.Rows[k]["OrderID"].ToString().Equals("10"))
                    {
                        _ImgOrder = "<img class=\"na1\" src=\"../imges/lie_47.gif\" align=\"middle\" onclick=\"ShowDetail(this)\" title=\"总置顶新闻,点击查看简洁内容\"/>";
                    }
                    else
                    {
                        _ImgOrder = "<img class=\"na1\" src=\"../imges/news_common.gif\" align=\"middle\" onclick=\"ShowDetail(this)\" title=\"普通新闻,点击查看简洁内容\"/>";
                    }
                    dt.Rows[k]["ImgOrder"] = _ImgOrder;
                    string _LblProperty = "";
                    string txt = dt.Rows[k]["NewsProperty"].ToString();
                    if (txt.Length >= 1 && txt.Substring(0, 1).Equals("1"))
                    {
                        _LblProperty = "推荐";
                    }
                    if (txt.Length >= 3 && txt.Substring(2, 1).Equals("1"))
                    {
                        if (!_LblProperty.Equals("")) _LblProperty += " | ";
                        _LblProperty += "滚动";
                    }
                    if (txt.Length >= 5 && txt.Substring(4, 1).Equals("1"))
                    {
                        if (!_LblProperty.Equals("")) _LblProperty += " | ";
                        _LblProperty += "热点";
                    }
                    if (txt.Length >= 7 && txt.Substring(6, 1).Equals("1"))
                    {
                        if (!_LblProperty.Equals("")) _LblProperty += " | ";
                        _LblProperty += "幻灯";
                    }
                    if (txt.Length >= 9 && txt.Substring(8, 1).Equals("1"))
                    {
                        if (!_LblProperty.Equals("")) _LblProperty += " | ";
                        _LblProperty += "头条";
                    }
                    if (txt.Length >= 11 && txt.Substring(10, 1).Equals("1"))
                    {
                        if (!_LblProperty.Equals("")) _LblProperty += " | ";
                        _LblProperty += "公告";
                    }
                    if (txt.Length >= 13 && txt.Substring(12, 1).Equals("1"))
                    {
                        if (!_LblProperty.Equals("")) _LblProperty += " | ";
                        _LblProperty += "WAP";
                    }
                    if (txt.Length >= 15 && txt.Substring(14, 1).Equals("1"))
                    {
                        if (!_LblProperty.Equals("")) _LblProperty += " | ";
                        _LblProperty += "精彩";
                    }
                    if (_LblProperty.Equals("")) _LblProperty = "未设置";
                    dt.Rows[k]["LblProperty"] = _LblProperty;
                    string _ishtml1 = "";
                    if (dt.Rows[k]["ishtml"].ToString() != "1") { _ishtml1 = "&nbsp;<img class=\"na1\" src=\"../imges/unhtml.gif\" border=\"0\" title=\"未生成静态页面\">"; }
                    string titleB = "";
                    string titleB1 = "";
                    string titleI = "";
                    string titleI1 = "";
                    string titleC = "";
                    string titleC1 = "";
                    if (dt.Rows[k]["TitleBTF"].ToString() == "1") { titleB = "<strong>"; titleB1 = "</strong>"; }
                    if (dt.Rows[k]["TitleITF"].ToString() == "1") { titleI = "<i>"; titleI1 = "</i>"; }
                    if (dt.Rows[k]["TitleColor"].ToString().Length > 2) { titleC = "<font color=\"" + dt.Rows[k]["TitleColor"].ToString() + "\">"; titleC1 = "</font>"; }
                    int intItitle = dt.Rows[k]["NewsTitle"].ToString().Length;
                    string titleStr = dt.Rows[k]["NewsTitle"].ToString();
                    if (intItitle > 26)
                    {
                        titleStr = titleStr.Substring(0, 26) + "...";
                    }
                    dt.Rows[k]["NewsTitles"] = titleC + titleI + titleB + titleStr + titleB1 + titleI1 + titleC1 + _ishtml1;
                    string[] CheckStat = dt.Rows[k]["CheckStat"].ToString().Split('|');
                    string _strCheck = "";
                    if (CheckStat[0] == "1") { _strCheck = "<img class=\"na1\" style=\"cursor:pointer;\" src=\"../imges/no1.gif\" title=\"一级审核的新闻\">"; }
                    if (CheckStat[0] == "2") { _strCheck = "<img class=\"na1\" style=\"cursor:pointer;\" src=\"../imges/no2.gif\" title=\"二级审核的新闻\">"; }
                    if (CheckStat[0] == "3") { _strCheck = "<img class=\"na1\" style=\"cursor:pointer;\" src=\"../imges/no3.gif\" title=\"三级审核的新闻\">"; }
                    if (CheckStat[0] == "0") { _strCheck = "<img class=\"na1\" style=\"cursor:pointer;\" src=\"../imges/no0.gif\" title=\"不需要审核的新闻\">"; }
                    if (CheckStat[1] == "0" && CheckStat[2] == "0" && CheckStat[3] == "0") { _strCheck += "<img class=\"na1\" src=\"../imges/lie_61.gif\" title=\"已审核\">"; }
                    if (CheckStat[1] != "0" || CheckStat[2] != "0" || CheckStat[3] != "0") { _strCheck += "<img class=\"na1\" src=\"../imges/no.gif\" title=\"未通过最终审核\">"; }

                    //无需审核
                    if (CheckStat[0] == "0") { _strCheck += "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"不需要审核\"></a>&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"不需要审核\"></a>&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"不需要审核\"></a>"; }

                    //一级审核
                    if (CheckStat[0] == "1" && CheckStat[1] == "1") { _strCheck += "&nbsp;┊&nbsp;<a href=\"javascript:CheckStat('" + dt.Rows[k]["NewsID"].ToString() + "|1')\" ><img class=\"na1\" border=\"0\" src=\"../imges/cno1.gif\" title=\"需要审核\"></a></a>&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"不需要审核\"></a>&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"不需要审核\"></a>"; }
                    if (CheckStat[0] == "1" && CheckStat[1] == "0") { _strCheck += "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"已审核\"></a>&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"不需要审核\"></a>&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"不需要审核\"></a>"; }

                    //二级审核
                    if (CheckStat[0] == "2")
                    {
                        string __strCheck2_1 = "";
                        string __strCheck2_2 = "";
                        if (CheckStat[1] == "1") { __strCheck2_1 += "&nbsp;┊&nbsp;<a href=\"javascript:CheckStat('" + dt.Rows[k]["NewsID"].ToString() + "|1')\" ><img class=\"na1\" border=\"0\" src=\"../imges/cno1.gif\" title=\"需要审核\"></a>"; }
                        else { __strCheck2_1 += "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"已审核\"></a>"; }

                        if (CheckStat[2] == "1") { __strCheck2_2 += "&nbsp;┊&nbsp;<a href=\"javascript:CheckStat('" + dt.Rows[k]["NewsID"].ToString() + "|2')\" ><img class=\"na1\" border=\"0\" src=\"../imges/cno1.gif\" title=\"需要审核\"></a></a>"; }
                        else { __strCheck2_2 += "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"已审核\"></a>"; }
                        _strCheck += __strCheck2_1 + __strCheck2_2 + "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"非三级审核\"></a>";
                    }

                    //三级审核
                    if (CheckStat[0] == "3")
                    {
                        string _strCheck1 = "";
                        string _strCheck2 = "";
                        string _strCheck3 = "";
                        if (CheckStat[1] == "1") { _strCheck1 += "&nbsp;┊&nbsp;<a href=\"javascript:CheckStat('" + dt.Rows[k]["NewsID"].ToString() + "|1')\" ><img class=\"na1\" border=\"0\" src=\"../imges/cno1.gif\" title=\"需要审核\"></a></a>"; }
                        else { _strCheck1 += "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"已审核\"></a>"; }

                        if (CheckStat[2] == "1") { _strCheck2 += "&nbsp;┊&nbsp;<a href=\"javascript:CheckStat('" + dt.Rows[k]["NewsID"].ToString() + "|2')\" ><img class=\"na1\" border=\"0\" src=\"../imges/cno1.gif\" title=\"需要审核\"></a></a>"; }
                        else { _strCheck2 += "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"已审核\"></a>"; }

                        if (CheckStat[3] == "1") { _strCheck3 += "&nbsp;┊&nbsp;<a href=\"javascript:CheckStat('" + dt.Rows[k]["NewsID"].ToString() + "|3')\" ><img class=\"na1\" border=\"0\" src=\"../imges/cno1.gif\" title=\"需要审核\"></a></a>"; }
                        else { _strCheck3 += "&nbsp;┊&nbsp;<img class=\"na1\" border=\"0\" src=\"../imges/cno0.gif\" title=\"已审核\"></a>"; }
                        _strCheck += _strCheck1 + _strCheck2 + _strCheck3;
                    }
                    dt.Rows[k]["CheckStats"] = _strCheck;
                    dt.Rows[k]["isConstrs"] = "";
                    if (dt.Rows[k]["isConstr"].ToString() == "1")
                    {
                        dt.Rows[k]["isConstrs"] = "&nbsp;<img class=\"na1\" style=\"cursor:pointer;\" src=\"../imges/isConstr.gif\" title=\"此文章为用户投稿\" />";
                    }
                    string SetTop = null;
                    if (dt.Rows[k]["OrderID"].ToString() != "10")
                    {
                        SetTop = "<a href=\"javascript:SetTop('" + dt.Rows[k]["NewsID"].ToString() + "')\" class=\"caoz\">固顶</a>";
                    }
                    else
                    {
                        SetTop = "<a href=\"javascript:UnSetTop('" + dt.Rows[k]["NewsID"].ToString() + "')\" class=\"caoz\">解固</a>";
                    }
                    string _islock = "";
                    if (dt.Rows[k]["islock"].ToString() == "0")
                    {
                        _islock = "<a href=\"javascript:Lock('" + dt.Rows[k]["NewsID"].ToString() + "')\"><img class=\"na1\" src=\"../imges/lie_61.gif\" alt=\"正常的新闻&#13;点击锁定\" border=\"0\" /></a>";
                    }
                    else
                    {
                        _islock = "<a href=\"javascript:UNLock('" + dt.Rows[k]["NewsID"].ToString() + "')\"><img class=\"na1\" src=\"../imges/no.gif\" alt=\"已被锁定的新闻&#13;点击取消锁定\" border=\"0\" /></a>";
                    }
                    dt.Rows[k]["htmllock"] = _islock;
                    //int CommNumber = rd.infoIDNum(dt.Rows[k]["NewsID"].ToString(), "0", dt.Rows[k]["DataLib"].ToString());
                    //if (CommNumber > 0)
                    //{
                    //    dt.Rows[k]["CommNum"] = "&nbsp;<a title=\"此新闻有" + CommNumber + "条评论\" href=\"../user/Usermycom.aspx?iID=" + dt.Rows[k]["NewsID"].ToString() + "&aID=0&TB=" + dt.Rows[k]["DataLib"].ToString() + "\" style=\"font-size:10px;\">(" + CommNumber + ")</a>";
                    //}
                    //else
                    //{
                    //    dt.Rows[k]["CommNum"] = "";
                    //}
                    if (!ispop)
                    {
                        dt.Rows[k]["op"] = "无权限";
                    }
                    else
                    {
                        dt.Rows[k]["op"] = "<a href=\"Newsadd.aspx?ClassID=" + dt.Rows[k]["ClassID"].ToString() + "&NewsID=" + dt.Rows[k]["NewsID"].ToString() + "&EditAction=Edit\" class=\"caoz\">修改</a>&nbsp;<a href=\"news_review.aspx?ID=" + dt.Rows[k]["NewsID"].ToString() + "\" target=\"_blank\" class=\"caoz\">预览</a>&nbsp;" + SetTop + "&nbsp;<a href=\"javascript:AddToJS('" + dt.Rows[k]["NewsID"].ToString() + "')\"  class=\"caoz\">JS</a>&nbsp;<a href=\"javascript:Recycle('" + dt.Rows[k]["NewsID"].ToString() + "')\" class=\"caoz\"><img class=\"na1\" src=\"../imges/lie_63.gif\" alt=\"删除到回收站\" /></a>&nbsp;<a href=\"javascript:Delete('" + dt.Rows[k]["NewsID"].ToString() + "')\" class=\"caoz\"><img class=\"na1\" src=\"../imges/lie_65.gif\" alt=\"彻底删除\" border=\"0\" /></a><input name=\"Checkbox1\" type=\"checkbox\" value=" + dt.Rows[k]["NewsID"].ToString() + "  runat=\"server\" />";
                    }
                }

                //从行中移出没有权限的新闻
                for (int m = 0; m < arrNotPop.Count; m++)
                {
                    dt.Rows.Remove((DataRow)arrNotPop[m]);
                }
                DataList1.Visible = true;
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        protected void LnkBtnAll_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "";
            ListDataBind(1);
        }
        protected void LnkBtnAuditing_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Auditing";
            ListDataBind(1);
        }
        protected void LnkBtnUnAuditing_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "UnAuditing";
            ListDataBind(1);
        }
        protected void LnkBtnContribute_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Contribute";
            ListDataBind(1);
        }
        protected void LnkBtnCommend_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Commend";
            ListDataBind(1);
        }
        protected void LnkBtnLock_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Lock";
            ListDataBind(1);
        }
        protected void LnkBtnUnLock_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "UnLock";
            ListDataBind(1);
        }
        protected void LnkBtnTop_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Top";
            ListDataBind(1);
        }
        protected void LnkBtnHot_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Hot";
            ListDataBind(1);
        }
        protected void LnkBtnPic_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Pic";
            ListDataBind(1);
        }
        protected void LnkBtnSplendid_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Splendid";
            ListDataBind(1);
        }
        protected void LnkBtnHeadline_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Headline";
            ListDataBind(1);
        }
        protected void LnkBtnSlide_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "Slide";
            ListDataBind(1);
        }
        protected void LnkBtnmy_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "my";
            ListDataBind(1);
        }
        protected void LnkBtnisHtml_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "isHtml";
            ListDataBind(1);
        }
        protected void LnkBtnunisHtml_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "unisHtml";
            ListDataBind(1);
        }
        protected void LnkBtnundiscuzz_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "discuzz";
            ListDataBind(1);
        }
        protected void LnkBtnuncommat_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "commat";
            ListDataBind(1);
        }
        protected void LnkBtnunvoteTF_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "voteTF";
            ListDataBind(1);
        }
        protected void LnkBtnuncontentPicTF_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "contentPicTF";
            ListDataBind(1);
        }
        protected void LnkBtnunPOPTF_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "POPTF";
            ListDataBind(1);
        }
        protected void LnkBtnunFilesURL_Click(object sender, EventArgs e)
        {
            this.LblChoose.Text = "FilesURL";
            ListDataBind(1);
        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            ListDataBind(1);
        }
        protected void DdlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListDataBind(1);
        }
        protected void DdlNewsTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListDataBind(1);
        }
        //删除到回收站
        private void Option_Recyle(string NewsID)
        {
            string id = "'" + NewsID.Replace(",", "','") + "'";
            int n = cNews.UpdateNews(id, 0, 1, "isRecyle", "1");

            Response.Write("成功将" + n + "条内容放入回收站中！");

        }
        //锁定内容
        private void Option_Lock(string NewsID, int NUMS)
        {
            string id = "'" + NewsID.Replace(",", "','") + "'";
            int n = cNews.UpdateNews(id, 0, 0, "isLock", NUMS.ToString());

            Response.Write("成功操作" + n + "条新闻！");

        }
        //重置权重
        private void Option_ResetOrder(string NewsID)
        {
            string id = "'" + NewsID.Replace(",", "','") + "'";
            int n = cNews.UpdateNews(id, 0, 0, "OrderID", "0");

            Response.Write("成功操作" + n + "条新闻！");

        }
        //彻底删除新闻
        private void Option_Delete(string NewsID)
        {
            string[] id = NewsID.Split(',');
            int n = 0;
            foreach (string item in id)
            {
                try
                {
                    if (cNews.DeleteNewsHtmlFile(item))
                    {
                        cNews.DelNews(item);
                    }
                    n++;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            Response.Write("成功删除" + n + "条新闻！");

        }
        //审核新闻
        private void Option_CheckStat(string NewsID)
        {

            string[] tID = NewsID.Split('|');
            string getID = tID[0];
            string levelID = tID[1];
            switch (levelID)
            {
                case "1":
                    this.Authority_Code = "C004";
                    this.CheckAdminAuthority();
                    cNews.UpCheckStat(getID, 1);
                    break;
                case "2":
                    this.Authority_Code = "C005";
                    this.CheckAdminAuthority();
                    cNews.UpCheckStat(getID, 2);
                    break;
                case "3":
                    this.Authority_Code = "C006";
                    this.CheckAdminAuthority();
                    cNews.UpCheckStat(getID, 3);
                    break;
            }
            Response.Write("成功审核您选择的新闻！");
        }
        //终极审核
        private void Option_AllCheck(string NewsID)
        {
            string id = "'" + NewsID.Replace(",", "','") + "'";
            cNews.AllCheck(id);

            Response.Write("成功审核您选择的新闻！");
        }
        //归档新闻
        private void Option_ToOld(string sid, int type)
        {
            string where;
            if (type == 1)
            {
                where = " ClassID='" + Request.Form["ClassID"] + "'";
            }
            else
            {
                string id = "'" + sid.Replace(",", "','") + "'";
                DateTime oldtimes = DateTime.Now;
                where = " NewsID in(" + id + ")";
            }
            if (cNews.Add_old_News(where) != 0 && cNews.DelNew(where) != 0)
                Response.Write("归档成功!");
            else
                Response.Write("归档失败！");
        }
        //生成xml
        private void Option_XMLRefresh(string sid)
        {
            if (Foosun.Publish.General.PublishXML(sid))
            {

                Response.Write("成功此栏目XML成功！");
            }
            else
            {

                Response.Write("生成XML失败！\n可能是你选择的栏目没有新闻");
            }
        }

        //生成静态
        private void Option_makeFilesHTML(string sid)
        {
            string ReadType = Common.Public.readparamConfig("ReviewType");
            if (ReadType == "1")
            {
                Response.Write("动态调用不能生成静态！");
            }
            Foosun.CMS.sys param = new CMS.sys();
            string publishType = param.GetParamBase("publishType");
            string id = sid;
            if (id.IndexOf(",") == -1)
            {
                string[] ARR1 = cNews.GetNewsIDfromID1(id).Split('|');
                string NewsID_1 = ARR1[0];
                string ClassID_1 = ARR1[1];
                if (publishType == "0")
                {
                    if (Foosun.Publish.General.PublishSingleNews(NewsID_1, ClassID_1))
                    {
                        cNews.UpdateNewsHTML(1, NewsID_1);
                        Response.Write("成功生成1条新闻！");
                    }
                    else
                    {
                        Response.Write("生成失败！如果有浏览权限，也不会生成");
                    }
                }
                else
                {
                    DataTable dt = cNews.GetNewsConent("ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", " NewsID='" + NewsID_1 + "'", "");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Foosun.Publish.DropPublish dp = new Foosun.Publish.DropPublish();
                        if (dp.publish(dt.Rows[0], "new"))
                        {
                            cNews.UpdateNewsHTML(1, NewsID_1);
                            Response.Write("成功生成1条新闻！");
                        }
                        else
                        {
                            Response.Write("生成失败！如果有浏览权限，也不会生成");
                        }
                    }
                }
            }
            else
            {
                string sNewsID = "";
                string sClassID = "";
                string[] idARR = id.Split(',');
                int j = 0;
                int m = 0;
                for (int i = 0; i < idARR.Length; i++)
                {
                    string[] ARR2 = cNews.GetNewsIDfromID1(idARR[i].ToString()).Split('|');
                    sNewsID = ARR2[0];
                    sClassID = ARR2[1];
                    if (publishType == "0")
                    {
                        if (Foosun.Publish.General.PublishSingleNews(sNewsID, sClassID))
                        {
                            cNews.UpdateNewsHTML(1, sNewsID);
                            j++;
                        }
                        else
                        {
                            m++;
                        }
                    }
                    else
                    {
                        DataTable dt = cNews.GetNewsConent("ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", " NewsID='" + sNewsID + "'", "");
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            Foosun.Publish.DropPublish dp = new Foosun.Publish.DropPublish();
                            if (dp.publish(dt.Rows[0], "new"))
                            {
                                cNews.UpdateNewsHTML(1, sNewsID);
                                j++;
                            }
                            else
                            {
                                m++;
                            }
                        }
                    }
                }

                Response.Write(j + "%成功生成" + j + "条新闻！失败" + m + "条新闻(可能有浏览权限。)");
            }
        }

        //private void allCheck(string sid)
        //{
        //    string[] idARR = sid.Split(',');
        //    int[] nid = new int[idARR.Length];
        //    int i = 0;
        //    foreach (string s in idARR)
        //    {
        //        nid[i++] = int.Parse(s);
        //    }
        //    rd.allCheck(nid);
        //    Response.Write("1%成功操作" + (idARR.Length) + "条新闻！");
        //}
        //固顶|解固
        private void Option_SetTop(string NewsID, string value)
        {
            int n = cNews.UpdateNews(NewsID, 1, value, "OrderID");

            if (n > 0)
            {
                Response.Write("成功将所选新闻固顶!");

            }
            else
            {
                Response.Write("固顶错误");

            }
        }
        //清空数据
        private void Option_delNumber(string ClassID)
        {

            if (ClassID != null && ClassID != "")
            {
                DataTable dt = cNews.GetNewsConent("NewsID", "ClassID='" + ClassID + "'", "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            if (cNews.DeleteNewsHtmlFile(item["NewsID"].ToString()))
                            {
                                cNews.DelNews(item["NewsID"].ToString());
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    Response.Write("成功当前栏目下的新闻！");

                }
            }
            else
            {

                Response.Write("当前位置没有在任何栏目下！删除失败！");

            }

        }
        //private void Option_clearFiles(string ID)
        //{
        //    if (ID == "foosun")
        //    {
        //        rd.deleteFilesurl(1, "");
        //    }
        //    else
        //    {
        //        string[] sID = ID.Split(',');
        //        for (int i = 0; i < sID.Length; i++)
        //        {
        //            rd.deleteFilesurl(0, sID[i]);
        //        }
        //    }
        //    Response.Write("1%附件清理成功!");
        //}

    }
}
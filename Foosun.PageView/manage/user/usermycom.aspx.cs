using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.user
{
    public partial class usermycom : Foosun.PageBasic.ManagePage
    {
        public usermycom()
        {
            Authority_Code = "U034";
        }
        Mycom my = new Mycom();
        UserList UL = new UserList();
        UserMisc rd = new UserMisc();
        RootPublic pd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region   初始化
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            Response.CacheControl = "no-cache";
            //copyright.InnerHtml = CopyRight;
            if (SiteID == "0")
            {
                string getSiteID = Request.QueryString["SiteID"];
                if (getSiteID != null && getSiteID != "")
                {
                    channelList.InnerHtml = SiteList(getSiteID);
                }
                else
                {
                    channelList.InnerHtml = SiteList(SiteID);
                }
            }
            string GoodTitle = Request.QueryString["GoodTitle"];
            if (!Page.IsPostBack)
                StartLoad(1, GoodTitle, "", "", "", "", "", "", "");
            string Type = Request.QueryString["Type"];  //取得操作类型
            string ID = "";
            if (Request.QueryString["ID"] != null)
            {
                ID = Common.Input.Filter(Request.QueryString["ID"]);  //取得需要操作的稿件ID
            }
            switch (Type)
            {
                case "del":          //删除
                    this.Authority_Code = "U035";
                    this.CheckAdminAuthority();
                    del(ID);
                    break;
                case "PDel":            //批量删除
                    this.Authority_Code = "U035";
                    this.CheckAdminAuthority();
                    PDel();
                    break;
                default:
                    break;
            }
            #endregion
        }
        string SiteList(string SessionSiteID)
        {
            string siteStr = "<select class=\"xselect1\" name=\"SiteID\" id=\"SiteID\" onChange=\"getchanelInfo(this)\">\r";
            DataTable crs = rd.getSiteList();
            if (crs != null)
            {
                for (int i = 0; i < crs.Rows.Count; i++)
                {
                    string getSiteID = SessionSiteID;
                    string SiteID1 = crs.Rows[i]["ChannelID"].ToString();
                    if (getSiteID != SiteID1)
                    {
                        siteStr += "<option value=\"" + crs.Rows[i]["ChannelID"] + "\">==" + crs.Rows[i]["CName"] + "==</option>\r";
                    }
                    else
                    {
                        siteStr += "<option value=\"" + crs.Rows[i]["ChannelID"] + "\"  selected=\"selected\">==" + crs.Rows[i]["CName"] + "==</option>\r";
                    }
                }
            }
            siteStr += "</select>\r";
            return siteStr;
        }

        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            string GoodTitle = Request.QueryString["GoodTitle"];
            StartLoad(PageIndex, GoodTitle, null, null, null, null, null, null, null);
        }

        #region  数据绑定

        protected void StartLoad(int PageIndex, string GoodTitle2, string UserID, string title, string Um, string dtm1, string dtm2, string isCheck, string islock)
        {
            string UserNum2 = "";
            if (Request.QueryString["UserNum"] != null && Request.QueryString["UserNum"] != "")
            {
                UserNum2 = Request.QueryString["UserNum"].ToString();
            }
            string RequestSiteId = Request.QueryString["SiteID"];
            string infoID = Request.QueryString["iID"];
            if (infoID != "" && infoID != null) { infoID = infoID.ToString(); }
            string ApiID = Request.QueryString["aID"];
            if (ApiID != "" && ApiID != null) { ApiID = ApiID.ToString(); }
            string DTable = Request.QueryString["TB"];
            if (DTable != "" && DTable != null) { DTable = DTable.ToString(); }
            int i, j;
            DataTable dt = my.GetPage(UserNum2, GoodTitle2, UserID, title, Um, dtm1, dtm2, isCheck, islock, RequestSiteId, infoID, ApiID, DTable, PageIndex, 10, out i, out j, null);
            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = i;
            no.InnerHtml = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Columns.Add("GoodTitles", typeof(string));
                dt.Columns.Add("OrderIDs", typeof(string));
                dt.Columns.Add("islocks", typeof(string));
                dt.Columns.Add("InfoTitle", typeof(string));
                dt.Columns.Add("APIIDTitle", typeof(string));
                dt.Columns.Add("Operation", typeof(string));
                dt.Columns.Add("isChecks", typeof(string));
                dt.Columns.Add("Titles", typeof(string));
                dt.Columns.Add("UserNames", typeof(string));
                foreach (DataRow h in dt.Rows)
                {
                    if (h["GoodTitle"].ToString() == "1")
                    {
                        h["GoodTitles"] = "<img src=\"../imges/best.jpg.gif\" border=\"0\" alt=\"精华帖\" />";
                    }
                    else
                    {
                        h["GoodTitles"] = "";
                    }
                    if (h["UserNum"].ToString() != "匿名")
                    {
                        h["UserNames"] = "<a href=\"../../" + Foosun.Config.UIConfig.dirUser + "/showuser-" + h["UserNum"].ToString() + ".aspx\" target=\"_blank\" title=\"查看此用户信息\">" + h["UserNum"].ToString() + "</a>";
                    }
                    else
                    {
                        h["UserNames"] = h["UserNum"].ToString();
                    }
                    if (h["OrderID"].ToString() == "2")
                    {
                        h["OrderIDs"] = "<img src=\"../imges/lie_47.gif\" border=\"0\" alt=\"固顶\" />";
                    }
                    else
                    {
                        h["OrderIDs"] = "<img src=\"../imges/news_common.gif\" border=\"0\"/>";
                    }
                    if (h["islock"].ToString() == "0")
                    {
                        h["islocks"] = "<img src=\"../imges/lie_61.gif\" border=\"0\" title=\"正常\" />";
                    }
                    else
                    {
                        h["islocks"] = "<img src=\"../imges/lie_65.gif\" border=\"0\" title=\"锁定\" />";
                    }
                    if (h["APIID"].ToString() == "0")
                    {
                        h["InfoTitle"] = my.sel_2(h["InfoID"].ToString(), h["DataLib"].ToString());
                        h["APIIDTitle"] = "新闻";
                    }
                    if (h["isCheck"].ToString() == "0")
                    {
                        h["isChecks"] = "<img src=\"../imges/lie_65.gif\" border=\"0\" title=\"未通过\" />";
                    }
                    else
                    {
                        h["isChecks"] = "<img src=\"../imges/lie_61.gif\" border=\"0\" title=\"已通过\" />";
                    }
                    h["Titles"] = "<a href=\"usermycom_Look.aspx?Commid=" + h["Commid"].ToString() + "\" class=\"list_link\">" + h["Title"].ToString() + "</a>";
                    string delEdit = null;
                    delEdit = "<a href=\"usermycomupdate.aspx?Commid=" + h["Commid"].ToString() + "\">修改</a><a href=\"#\" onclick=\"javascript:del('" + h["Commid"].ToString() + "');\" >删除</a><input name=\"Checkbox1\" type=\"checkbox\" value=" + h["Commid"].ToString() + "  runat=\"server\" />";
                    h["Operation"] = delEdit;
                }
                DataList1.Visible = true;
                DataList1.DataSource = dt;
                DataList1.DataBind();
                DataList1.Dispose();
            }
            else
            {
                no.InnerHtml = show_no();
                this.PageNavigator1.Visible = false;
                TopTitle1.Visible = false;
                TopTitle12.Visible = false;
                GoodTitle.Visible = false;
                UNGoodTitle.Visible = false;
                CheckTtile.Visible = false;
                OCTF1.Visible = false;
                OCTF2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
            }
        }
        #endregion
        string show_no()
        {
            string nos = "<table border=0 width='98%' align=center cellpadding=5 cellspacing=1>";
            nos = nos + "<tr>";
            nos = nos + "<td>没有数据</td>";
            nos = nos + "</tr>";
            nos = nos + "</table>";
            DataList1.Visible = false;
            return nos;
        }
        #region  删除
        protected void PDel()
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要删除的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    my.Delete(chSplit[i]);
                }
                PageRight("批量删除成功", "usermycom.aspx");
            }

        }

        protected void del(string ID)
        {
            my.Delete(ID);
            PageRight("删除成功!", "usermycom.aspx");
        }
        #endregion
        #region 操作
        protected void Button8_ServerClick(object sender, EventArgs e)
        {
            string ReqUserID = "";
            if (Request.Form["UserNumbox"] != null && Request.Form["UserNumbox"] != "")
            {
                ReqUserID = pd.GetUserNameUserNum(Request.Form["UserNumbox"].ToString());
            }
            string title = Request.Form["Title1"];
            string Um = Request.Form["InfoTitle1"];
            string dtm1 = Request.Form["creatTime1"];
            string dtm2 = Request.Form["creatTime2"];
            string isCheck = this.isCheck1.SelectedValue;
            string islock = this.islock1.SelectedValue;
            string GoodTitle1 = Request.QueryString["GoodTitle"];
            StartLoad(1, GoodTitle1, ReqUserID, title, Um, dtm1, dtm2, isCheck, islock);
        }
        #endregion
        /// <summary>
        /// 固顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region  固顶
        protected void TopTitle1_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要固顶的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        if (my.Update_1(2, chSplit[i]) == 0)
                        {
                            PageError("固顶失败", "usermycom.aspx");
                            break;
                        }
                    }
                }
                PageRight("成功固顶", "usermycom.aspx");
            }
        }
        #endregion
        /// <summary>
        /// 解固
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region   解固
        protected void TopTitle12_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要解固的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        if (my.Update_1(0, chSplit[i]) == 0)
                        {
                            PageError("解固失败", "usermycom.aspx");
                            break;
                        }
                    }
                }
                PageRight("成功解固", "usermycom.aspx");
            }
        }
        #endregion
        /// <summary>
        /// 设置精华帖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region  设置精华帖
        protected void GoodTitle_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要设置的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        my.Update_2(1, chSplit[i]);
                    }
                }
                PageRight("设置精华帖成功", "usermycom.aspx");
            }
        }


        protected void unGoodTitle_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要设置的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        my.Update_2(0, chSplit[i]);
                    }
                }
                PageRight("设置精华帖成功", "usermycom.aspx");
            }
        }
        #endregion
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region   审核
        protected void CheckTtile_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要审核的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        if (my.Update_3(chSplit[i], 1) == 0)
                        {
                            PageError("审核失败", "usermycom.aspx");
                            break;
                        }
                    }
                }
                PageRight("审核成功", "usermycom.aspx");
            }
        }

        protected void unCheckTtile_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要审核的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        if (my.Update_3(chSplit[i], 0) == 0)
                        {
                            PageError("审核失败", "usermycom.aspx");
                            break;
                        }
                    }
                }
                PageRight("取消审核成功", "usermycom.aspx");
            }
        }
        #endregion
        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region 锁定
        protected void OCTF1_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要锁定的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        int islock = 1;
                        if (my.Update_4(islock, chSplit[i]) == 0)
                        {
                            PageError("锁定失败", "usermycom.aspx");
                            break;
                        }
                    }
                }
                PageRight("锁定成功", "usermycom.aspx");
            }
        }
        #endregion
        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region 解锁
        protected void OCTF2_Click(object sender, EventArgs e)
        {
            string checkboxq = Request.Form["Checkbox1"];
            if (checkboxq == null || checkboxq == String.Empty)
            {
                PageError("请先选择要解锁的评论!", "usermycom.aspx");
            }
            else
            {
                string[] chSplit = checkboxq.Split(',');
                for (int i = 0; i < chSplit.Length; i++)
                {
                    if (chSplit[i] != "on")
                    {
                        int islock = 0;
                        if (my.Update_4(islock, chSplit[i]) == 0)
                        {
                            PageError("解锁失败", "usermycom.aspx");
                            break;
                        }
                    }
                }
                PageRight("解锁成功", "usermycom.aspx");
            }
        }
        #endregion

    }
}
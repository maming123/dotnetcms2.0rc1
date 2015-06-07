using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.news
{
    public partial class UnnewsEdit : Foosun.PageBasic.ManagePage
    {
        public UnnewsEdit()
        {
            Authority_Code = "C050";
        }
        protected String UnNewsJsArray = "";
        protected String unNewsid = "";
        protected String fs_PicInfo = "";
        Foosun.CMS.News cnews = new CMS.News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UnID"] != null)
            {
                unNewsid = Request.QueryString["UnID"];
            }
            else if (Request.Form["UnID"] != null)
            {
                unNewsid = Request.Form["UnID"];
            }
            if (unNewsid == null)
                unNewsid = "";
            if (!IsPostBack)
            {
                GetunNewsData();
            }
            else
            {
                SaveunNewsData();
            }
        }
        protected void GetunNewsData()
        {
            String For_string;
            int For_number;
            if (unNewsid != "")
            {
                #region 编辑不规则新闻
                unNewsid = Common.Input.Filter(unNewsid);
                DataTable DT = cnews.GetUnNews(unNewsid);
                if (DT != null && DT.Rows.Count > 0)
                {
                    DataTable DTNews = null;
                    this.unName.Text = DT.Rows[0]["unName"].ToString();
                    this.titleCSS.Text = DT.Rows[0]["titleCSS"].ToString();
                    for (For_number = 0; For_number < DT.Rows.Count; For_number++)
                    {
                        DTNews =cnews.GetNewsConent("NewsTitle"," NewsID='"+ DT.Rows[For_number]["ONewsID"].ToString()+"'" ,"");
                        if (DTNews != null && DTNews.Rows.Count > 0)
                        {
                            For_string = "'" + DT.Rows[For_number]["ONewsID"] + "','" + DTNews.Rows[0][0] + "','" + DT.Rows[For_number]["unTitle"] + "'," + DT.Rows[For_number]["Rows"] + ",'" + DT.Rows[For_number]["NewsTable"] + "','" + DT.Rows[For_number]["SubCSS"] + "'";
                            For_string = "[" + For_string + "]";
                            if (UnNewsJsArray == "")
                            {
                                UnNewsJsArray = For_string;
                            }
                            else
                            {
                                UnNewsJsArray += "," + For_string;
                            }
                        }
                    }
                    if (DTNews != null)
                        DTNews.Dispose();
                    DT.Dispose();

                    if (UnNewsJsArray != "")
                    {
                        UnNewsJsArray = "[" + UnNewsJsArray + "]";
                    }
                    else
                    {
                        UnNewsJsArray = "new Array()";
                    }
                    
                }
                else
                {
                    PageError("找不到记录!", "");
                }
                #endregion 编辑不规则新闻
            }
            else
            {
                unNewsid = "";
                UnNewsJsArray = "new Array()";
            }
        }

        //保存数据
        protected bool SaveunNewsData()
        {
            String OldNewsId = Common.Input.Filter(Request.Form["NewsID"]);
            String[] Arr_OldNewsId;
            String NewsID, NewsTitle, NewsRow, NewsTable, SubCSS;

            NewsID = Request.Form["TopNewsID"];
            string unName = Common.Input.Filter(this.unName.Text);
            string titleCSS = this.titleCSS.Text;
            #region 判断数据是否合法
            if (this.unName.Text.Trim() == "")
            {
                PageError("请填写不规则的标题", "");
            }
            if (NewsID == null && OldNewsId == null)
            {
                PageError("不规则新闻为空", "unNews.aspx");
                return false;
            }
            #endregion 判断数据是否合法

            #region 获取普通新闻数据
            if (OldNewsId != null)
            {
                OldNewsId = OldNewsId.Replace(" ", "");
                Arr_OldNewsId = OldNewsId.Split(',');
            }
            else
            {
                OldNewsId = "";
                Arr_OldNewsId = OldNewsId.Split(new char[] { ',' });
            }
            string unNewsids = Common.Rand.Number(12);
            if (Request.Form["UnID"].Trim() != "")
            {
                unNewsids = Request.Form["UnID"];
                cnews.DelUnNews(Request.Form["UnID"]);
            }
            for (int For_Num = 0; For_Num < Arr_OldNewsId.Length; For_Num++)
            {
                NewsTitle = Common.Input.Filter(Request.Form["NewsTitle" + Arr_OldNewsId[For_Num]]);
                NewsRow = Common.Input.Filter(Request.Form["Row" + Arr_OldNewsId[For_Num]]);
                NewsTable = Common.Input.Filter(Request.Form["NewsTable" + Arr_OldNewsId[For_Num]]);
                SubCSS = Common.Input.Filter(Request.Form["SubCSS" + Arr_OldNewsId[For_Num]]);
                if (cnews.AddUnNews(unName, titleCSS, SubCSS, unNewsids, Arr_OldNewsId[For_Num], NewsRow, NewsTitle, NewsTable, SiteID) == 0)
                {
                    PageError("保存不规则新闻失败!", "unNews.aspx");
                }
            }
            PageRight("保存不规则新闻成功!", "unNews.aspx");
            #endregion
            return true;
        }
    }
}
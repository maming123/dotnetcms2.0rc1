using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Foosun.PageView.manage.news
{
    public partial class NewsManage : Foosun.PageBasic.ManagePage
    {
        Foosun.CMS.News td = new CMS.News();
        private DataTable TbClass;
        private string OriginalType;
        private string sOrgNews = "";
        Foosun.CMS.sys csys = new CMS.sys();
        Foosun.CMS.NewsClass cClass = new CMS.NewsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int flag = 0;
                this.Panel1.Visible = this.Panel2.Visible = false;
                if (Request.QueryString["Option"] != null && Request.QueryString["dbtab"] != null && !Request.QueryString["dbtab"].Trim().Equals(""))
                {
                    this.LblNewsTable.Text = Request.QueryString["dbtab"].Trim();
                    string sssss = Request.QueryString["dbtab"].Trim();
                    switch (Request.QueryString["Option"])
                    {
                        case "BnProperty":
                            this.Authority_Code = "C015";
                            this.CheckAdminAuthority();
                            this.LblNarrate.Text = "批量设置";
                            this.BtnOK.Text = "确定按照以上方式开始设置";
                            this.BtnOK.CommandName = "set";
                            this.Panel2.Visible = true;
                            flag = 0;
                            break;
                        case "BnMove":
                            this.Authority_Code = "C009";
                            this.CheckAdminAuthority();
                            this.LblNarrate.Text = "移动到 >>";
                            this.BtnOK.Text = "确定开始移动";
                            this.BtnOK.CommandName = "move";
                            this.Panel1.Visible = true;
                            flag = 1;
                            break;
                        case "BnCopy":
                            this.Authority_Code = "C010";
                            this.CheckAdminAuthority();
                            this.LblNarrate.Text = "复制到 >>";
                            this.BtnOK.Text = "确定开始复制";
                            this.BtnOK.CommandName = "copy";
                            this.Panel1.Visible = true;
                            flag = 2;
                            break;
                        default:
                            PageError("没有参数或是参数无效！", "");
                            return;
                    }
                }
                else
                {
                    PageError("没有参数或是参数无效！", "");
                    return;
                }
                if (Request.QueryString["ids"] != null && !Request.QueryString["ids"].Trim().Equals(""))
                {
                    this.LblIDs.Text = Request.QueryString["ids"];
                    this.DdlType.SelectedValue = "0";
                    BindNews();
                }
                else
                {
                    this.DdlType.SelectedValue = "1";
                    BindClass();
                    this.DdlType.Enabled = false;
                }
                if (flag == 1 || flag == 2)
                {
                    this.LstTarget.Items.Clear();
                    ClassRender(this.LstTarget, "0", 0);
                }
                this.Templet.Text = csys.GetParamBase("ReadNewsTemplet");
            }

        }
        private void BindNews()
        {
            this.LstOriginal.Items.Clear();
            string id = Common.Input.Filter(this.LblIDs.Text.Trim());
            if (!id.Equals(""))
            {
                string s = Common.Input.Filter(this.LblIDs.Text);
                s = "'" + s.Replace(",", "','") + "'";
                DataTable tb = null;
                tb = td.GetNewsConent("Id,NewsID,NewsTitle", "NewsID in("+s+")", "");
                if (tb != null)
                {
                    foreach (DataRow r in tb.Rows)
                    {
                        ListItem it = new ListItem();
                        it.Value = r[1].ToString();
                        it.Text = r[2].ToString();
                        this.LstOriginal.Items.Add(it);
                    }
                    tb.Dispose();
                    this.LstOriginal.Enabled = false;
                }
            }
        }
        private void BindClass()
        {
            TbClass = cClass.GetContent("ClassID,ClassCName,ParentID", "isURL=0 and isLock=0 and isRecyle=0 and SiteID='" + Foosun.Global.Current.SiteID + "'", "");
            this.LstOriginal.Items.Clear();
            ClassRender(this.LstOriginal, "0", 0);
            this.LstOriginal.Enabled = true;
        }
        private void ClassRender(ListBox lst, string PID, int Layer)
        {
            Foosun.CMS.RootPublic rp = new Foosun.CMS.RootPublic();
            DataTable dts = rp.GetClassListPublic(PID);
            if (dts.Rows.Count < 1)
                return;
            else
            {
                foreach (DataRow r in dts.Rows)
                {
                    ListItem it = new ListItem();
                    string stxt = "";
                    it.Value = r["ClassID"].ToString();
                    if (Layer > 0)
                        stxt = "┝";
                    for (int i = 1; i < Layer; i++)
                    {
                        stxt += "┉";
                    }
                    it.Text = stxt + r["ClassCName"].ToString();
                    lst.Items.Add(it);
                    ClassRender(lst, r["ClassID"].ToString(), Layer + 1);
                }
            }
        }
        protected void DdlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DdlType.SelectedValue.Equals("0"))
            {
                this.BindNews();
            }
            else
            {
                this.BindClass();
            }
        }
        protected void BtnOK_Click(object sender, EventArgs e)
        {
            OriginalType = this.DdlType.SelectedValue;
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
            switch (this.BtnOK.CommandName)
            {
                case "set":
                    if (OriginalType.Equals("0"))
                        NewsSet();
                    else if (OriginalType.Equals("1"))
                        ClassSet();
                    break;
                case "copy":
                    if (this.LstTarget.SelectedValue.Trim().Equals(""))
                    {
                        PageError("请选择要复制到的栏目!", "NewsList.aspx");
                        return;
                    }
                    if (OriginalType.Equals("1") && this.LstOriginal.SelectedValue.Trim().Equals(this.LstTarget.SelectedValue.Trim()))
                    {
                        PageError("要进行操作的栏目和目标栏目不能相同!", "NewsList.aspx");
                        return;
                    }
                    if (OriginalType.Equals("0"))
                        NewsCopy();
                    else if (OriginalType.Equals("1"))
                        ClassCopy();
                    break;
                case "move":
                    if (this.LstTarget.SelectedValue.Trim().Equals(""))
                    {
                        PageError("请选择要移动到的栏目!", "NewsList.aspx");
                        return;
                    }
                    if (OriginalType.Equals("1") && this.LstOriginal.SelectedValue.Trim().Equals(this.LstTarget.SelectedValue.Trim()))
                    {
                        PageError("要进行操作的栏目和目标栏目不能相同!", "NewsList.aspx");
                        return;
                    }
                    if (OriginalType.Equals("0"))
                        NewsMove();
                    else if (OriginalType.Equals("1"))
                        ClassMove();
                    break;
            }
        }
        /// <summary>
        /// 对选中新闻复制
        /// </summary>
        /// 
        #region 对选中新闻复制
        protected void NewsCopy()
        {
            string sclassid = this.LstTarget.SelectedValue.Trim();
            string sclasstext =cClass .GetNewsClassCName(sclassid);           
            bool flag = CheckClass(sclassid);
            if (flag)
            {
                PageError("不能将新闻复制到外部栏目或者单页栏目!", "NewsList.aspx");
                return;
            }
            string[] sNews = sOrgNews.Split(',');
            for (int i = 0; i < sNews.Length; i++)
            {
            ID:
                string NewsID = Common.Rand.Number(12);
            if (td.Exists(NewsID)) { goto ID; }
            string _FileName = Common.Rand.Number(5);
            DataTable dt = td.GetNewsConent("FileName", "NewsID =" + sNews[i] + "", "");
            if (dt!=null&&dt.Rows.Count>0)
            {
                _FileName = dt.Rows[0][0].ToString() + "_1";
            }
            dt.Clear();
            dt.Dispose();
                td.Copy_news(sclassid, sNews[i], NewsID, _FileName);
            }
            PageRight("成功将条新闻复制到&nbsp;<font color=red>" + sclasstext + "</font>&nbsp;栏目中!", "NewsList.aspx");
        }
        #endregion
        /// <summary>
        /// 对选中栏目复制
        /// </summary>
        /// 
        #region 对选中栏目复制
        protected void ClassCopy()
        {
            string str = "";
            for (int l = 0; l < this.LstOriginal.Items.Count; l++)
            {
                if (this.LstOriginal.Items[l].Selected)
                {
                    str += this.LstOriginal.Items[l].Value + ",";
                }
            }
            string[] soclass = Common.Public.Lost(str).Split(',');
            string stclass = this.LstTarget.SelectedValue.Trim();
            string sclasstext = cClass.GetNewsClassCName(stclass);           
            for (int k = 0; k < soclass.Length; k++)
            {
                bool flag = CheckClass(soclass[k]);
                if (flag)
                {
                    PageError("不能复制外部栏目或者单页栏目的新闻!", "NewsList.aspx");
                }
                bool flag1 = CheckClass(stclass);
                if (flag1)
                {
                    PageError("不能将栏目的所有新闻复制到外部栏目或者单页栏目!", "NewsList.aspx");
                }

                DataTable dts6 = td.GetNewsConent("id,NewsID", "ClassID='" + soclass[k] + "'", "");
                for (int i = 0; i < dts6.Rows.Count; i++)
                {
                ID:
                    string NewsID = Common.Rand.Number(12);
                if (td.Exists(NewsID)) { goto ID; }
                string _FileName = Common.Rand.Number(5);
                    DataTable dt = td.GetNewsConent("FileName", "NewsID ='" + dts6.Rows[i]["NewsID"].ToString() + "'", "");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _FileName = dt.Rows[0][0].ToString() + "_1";
                    }
                    td.Copy_news(stclass, dts6.Rows[i]["NewsID"].ToString(), NewsID, _FileName);
                }
            }
            PageRight("成功将新闻复制到&nbsp;<font color=red>" + sclasstext + "</font>&nbsp;栏目中!", "");
        }
        #endregion
        /// <summary>
        /// 对选中新闻转移
        /// </summary>
        /// 
        #region 对选中新闻转移
        protected void NewsMove()
        {
            string sclassid = this.LstTarget.SelectedValue.Trim();
            string sclasstext =  cClass.GetNewsClassCName(sclassid);
            string sTb = this.LblNewsTable.Text.Trim();
            bool flag = CheckClass(sclassid);
            if (flag)
            {
                PageError("不能将新闻移动到外部栏目或者单页栏目!", "NewsList.aspx");
                return;
            }           
            string[] sNews = sOrgNews.Split(',');
            for (int i = 0; i < sNews.Length; i++)
            {
            ID:
                string NewsID = Common.Rand.Number(12);
                if (td.Exists(NewsID)) { goto ID; }              
                td.Copy_news(sclassid, sNews[i], NewsID, "");
                if (!td.Delete(sNews[i].Substring(1,sNews[i].Length-2)))
                {
                    PageError("新闻转移到目标栏目失败", "NewsList.aspx");
                }
            }
            PageRight("成功将新闻转移到<font color=red>" + sclasstext + "</font>栏目中!", "NewsList.aspx");
        }
        #endregion
        /// <summary>
        /// 对选中栏目转移
        /// </summary>
        /// 
        #region 对选中栏目转移
        protected void ClassMove()
        {
            string str = "";
            for (int l = 0; l < this.LstOriginal.Items.Count; l++)
            {
                if (this.LstOriginal.Items[l].Selected == true)
                {
                    str += this.LstOriginal.Items[l].Value + ",";
                }
            }
            string[] soclass = Common.Public.Lost(str).Split(',');
            string stclass = this.LstTarget.SelectedValue.Trim();
            string sclasstext =  cClass.GetNewsClassCName(stclass);
            for (int k = 0; k < soclass.Length; k++)
            {
                bool flag = CheckClass(soclass[k]);
                if (flag)
                {
                    PageError("不能移动外部栏目或者单页栏目的新闻!", "NewsList.aspx");
                }
                flag = CheckClass(stclass);
                if (flag)
                {
                    PageError("不能将栏目的所有新闻移动到外部栏目或者单页栏目!", "NewsList.aspx");
                }
                DataTable dts1 = td.GetNewsConent("id,NewsID", "ClassID='" + soclass[k] + "'", ""); ;
                for (int i = 0; i < dts1.Rows.Count; i++)
                {
                ID:
                    string NewsID = Common.Rand.Number(12);
                    if (td.Exists(NewsID)) { goto ID; }
                    td.Copy_news(stclass, dts1.Rows[i]["Newsid"].ToString(), NewsID, "");
                    if (!td.Delete(dts1.Rows[i]["Newsid"].ToString()))
                    {
                        PageError("将新闻转移到目标栏目失败!", "");
                    }
                }
            }
            PageRight("成功将新闻转移到<font color=red>" + sclasstext + "</font>栏目中!", "");
        }
        #endregion
        /// <summary>
        /// 对选中新闻设置
        /// </summary>
        /// 
        #region 对选中新闻进行设置
        protected void NewsSet()
        {
            string Templet = "";
            string OrderID = "";
            int CommLinkTF = 0;
            int CommTF = 0;
            int DiscussTF = 0;
            string Tags = this.Tags.Text;
            string Click = "";
            string FileEXName = "";
            string NewsProperty = "";
            string sclassid = this.LstOriginal.SelectedValue.Trim();
            string sTb = this.LblNewsTable.Text.Trim();
            string souce = this.Souce.Text;
            if (!this.NewsProperty_CommTF1.Checked || !this.NewsProperty_DiscussTF1.Checked || this.NewsProperty_RECTF1.Checked || this.NewsProperty_MARTF1.Checked || this.NewsProperty_HOTTF1.Checked || this.NewsProperty_FILTTF1.Checked || this.NewsProperty_TTTF1.Checked || this.NewsProperty_ANNTF1.Checked || this.NewsProperty_JCTF1.Checked || this.NewsProperty_WAPTF1.Checked)
            {
                NewsProperty = Newsty();
            }
            if (this.Templet.Text != "")
            {
                Templet = this.Templet.Text;
            }
            if (this.OrderIDDropDownList.SelectedValue != string.Empty)
            {
                OrderID = this.OrderIDDropDownList.SelectedValue;
            }
            if (!this.CommLinkTF.Checked)
            {
                CommLinkTF = 1;
            }
            if (this.Click.Text != "")
            {
                Click = int.Parse(this.Click.Text).ToString();
            }
            if (this.NewsProperty_CommTF1.Checked) { CommTF = 1; }
            if (this.NewsProperty_DiscussTF1.Checked) { DiscussTF = 1; }
            if (this.FileEXName.SelectedValue != "")
            {
                FileEXName = this.FileEXName.SelectedValue;
            }
            if (td.UpdateNews(CommTF, DiscussTF, NewsProperty, Templet, OrderID, CommLinkTF, Click, FileEXName, Tags, souce, "NewsID in (" + sOrgNews + ")") != 0)
            {
                PageRight("设置新闻属性成功!", "NewsList.aspx");
            }
            else
            {
                PageRight("设置新闻属性失败!", "NewsList.aspx");
            }
        }
        #endregion
        /// <summary>
        /// 对选中栏目设置
        /// </summary>
        /// 
        #region 对选中栏目设置
        protected void ClassSet()
        {
            string Templet = "";
            string OrderID = "";
            int CommLinkTF = 0;
            string Tags = "";
            string souce = "";
            string Click = "";
            string FileEXName = "";
            string NewsProperty = "";
            string str = "";
            int CommTF = 0;
            int DiscussTF = 0;
            if (this.NewsProperty_CommTF1.Checked) { CommTF = 1; }
            if (this.NewsProperty_DiscussTF1.Checked) { DiscussTF = 1; }
            for (int l = 0; l < this.LstOriginal.Items.Count; l++)
            {
                if (this.LstOriginal.Items[l].Selected == true)
                {
                    str += this.LstOriginal.Items[l].Value + ",";
                }
            }
            string[] soclass = Common.Public.Lost(str).Split(',');

            Tags = this.Tags.Text;
            souce = this.Souce.Text;
          
                if (!this.NewsProperty_CommTF1.Checked || !this.NewsProperty_DiscussTF1.Checked || this.NewsProperty_RECTF1.Checked || this.NewsProperty_MARTF1.Checked || this.NewsProperty_HOTTF1.Checked || this.NewsProperty_FILTTF1.Checked || this.NewsProperty_TTTF1.Checked || this.NewsProperty_ANNTF1.Checked || this.NewsProperty_JCTF1.Checked || this.NewsProperty_WAPTF1.Checked)
                {
                    NewsProperty = Newsty();
                }
                if (this.Templet.Text != "")
                {
                    Templet = this.Templet.Text;
                }
                if (this.OrderIDDropDownList.SelectedValue.Trim() != "")
                {
                    OrderID = this.OrderIDDropDownList.SelectedValue;
                }
                if (!this.CommLinkTF.Checked)
                {
                    CommLinkTF = 1;
                }
                if (this.Click.Text != "")
                {
                    Click = int.Parse(this.Click.Text).ToString ();
                }
                if (this.FileEXName.SelectedValue.Trim() != "")
                {
                    FileEXName = this.FileEXName.SelectedValue;
                }
                for (int s = 0; s < soclass.Length; s++)
                {
                    bool flags = CheckClass(soclass[s]);
                    if (flags)
                    {
                        PageError("不能设置外部栏目的新闻!", "NewsList.aspx");
                        return;
                    }
                    try
                    {                        
                        td.UpdateNews(CommTF, DiscussTF, NewsProperty, Templet, OrderID, CommLinkTF, Click, FileEXName, Tags, souce, "ClassID='" + soclass[s] + "'");
                    }
                    catch
                    {
                        PageRight("设置新闻属性失败!", "NewsList.aspx");
                    }
                }
                PageRight("设置新闻属性成功!", "NewsList.aspx");
        }
        #endregion

        #region 获得新闻属性
        protected string Newsty()
        {
            string NewsProperty_RECTF1 = "";
            string NewsProperty_MARTF1 = "";
            string NewsProperty_HOTTF1 = "";
            string NewsProperty_FILTTF1 = "";
            string NewsProperty_TTTF1 = "";
            string NewsProperty_ANNTF1 = "";
            string NewsProperty_JCTF1 = "";
            string NewsProperty_WAPTF1 = "";
            string NewsProperty = "";
            NewsProperty_RECTF1 = "0";
            if (this.NewsProperty_RECTF1.Checked) { NewsProperty_RECTF1 = "1"; }
            NewsProperty_MARTF1 = "0";
            if (this.NewsProperty_MARTF1.Checked) { NewsProperty_MARTF1 = "1"; }
            NewsProperty_HOTTF1 = "0";
            if (this.NewsProperty_HOTTF1.Checked) { NewsProperty_HOTTF1 = "1"; }
            NewsProperty_FILTTF1 = "0";
            if (this.NewsProperty_FILTTF1.Checked) { NewsProperty_FILTTF1 = "1"; }
            NewsProperty_TTTF1 = "0";
            if (this.NewsProperty_TTTF1.Checked) { NewsProperty_TTTF1 = "1"; }
            NewsProperty_ANNTF1 = "0";
            if (this.NewsProperty_ANNTF1.Checked) { NewsProperty_ANNTF1 = "1"; }
            NewsProperty_JCTF1 = "0";
            if (this.NewsProperty_JCTF1.Checked) { NewsProperty_JCTF1 = "1"; }
            NewsProperty_WAPTF1 = "0";
            if (this.NewsProperty_WAPTF1.Checked) { NewsProperty_WAPTF1 = "1"; }
            return NewsProperty = NewsProperty_RECTF1 + "," + NewsProperty_MARTF1 + "," + NewsProperty_HOTTF1 + "," + NewsProperty_FILTTF1 + "," + NewsProperty_TTTF1 + "," + NewsProperty_ANNTF1 + "," + NewsProperty_WAPTF1 + "," + NewsProperty_JCTF1;
        }
        #endregion
        /// <summary>
        /// 检查目标栏目是否外部栏目
        /// </summary>
        /// <returns></returns>
        /// 
        protected bool CheckClass(string cid)
        {
            bool ckTF = false;
            // int n = td.sel_newsclass(cid);
            int n =cClass.Exists("(IsURL=1 OR IsPage=1) and ClassID='"+cid+"'");
            if (n > 0) { ckTF = true; }
            else { ckTF = false; }
            return ckTF;
        }

        /// <summary>
        /// 更新属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void pro_click(object sender, EventArgs e)
        {
            OriginalType = this.DdlType.SelectedValue;
            string Prostr = Newsty();
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 0, "NewsProperty", Prostr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 0, "NewsProperty", Prostr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
        /// <summary>
        /// 更新模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void templet_click(object sender, EventArgs e)
        {
            OriginalType = this.DdlType.SelectedValue;
            string templetstr = this.Templet.Text;
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 0, "Templet", templetstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 0, "Templet", templetstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
        /// <summary>
        /// 更新权重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void order_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OrderIDDropDownList.SelectedValue))
            {
                PageError("权重值没有选择!", "NewsList.aspx");
            }
            OriginalType = this.DdlType.SelectedValue;
            string orderstr = this.OrderIDDropDownList.SelectedValue;
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 1, "OrderID", orderstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 1, "OrderID", orderstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
        /// <summary>
        /// 更新评论连接　
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void comm_click(object sender, EventArgs e)
        {
            OriginalType = this.DdlType.SelectedValue;
            string commTF = "0";
            if (this.CommLinkTF.Checked)
            {
                commTF = "1";
            }
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 1, "CommLinkTF", commTF);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 1, "CommLinkTF", commTF);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
        /// <summary>
        /// 更新ＴＡＧ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tag_click(object sender, EventArgs e)
        {
            OriginalType = this.DdlType.SelectedValue;
            string tagstr = this.Tags.Text;
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 0, "Tags", tagstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 0, "Tags", tagstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
        /// <summary>
        /// 更新点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void click_click(object sender, EventArgs e)
        {
            bool isMatch = Regex.IsMatch(Click.Text.Trim(), @"\d+");
            if (string.IsNullOrEmpty(Click.Text.Trim()) || !isMatch)
            {
                PageError("点击数填写不正确!", "NewsList.aspx");
                return;
            }
            OriginalType = this.DdlType.SelectedValue;
            string Clickstr = this.Click.Text;
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 1, "Click", Clickstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 1, "Click", Clickstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
        /// <summary>
        /// 更新来源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void source_click(object sender, EventArgs e)
        {
            OriginalType = this.DdlType.SelectedValue;
            string Soucestr = this.Souce.Text;
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 0, "Souce", Soucestr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 0, "Souce", Soucestr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
        /// <summary>
        /// 更新扩展名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void exname_click(object sender, EventArgs e)
        {
            OriginalType = this.DdlType.SelectedValue;
            string FileEXstr = this.FileEXName.SelectedValue;
            if (OriginalType.Equals("0"))//对选中的新闻进行操作
            {
                if (this.LstOriginal.Items.Count < 1)
                {
                    PageError("没有要进行操作的新闻!", "NewsList.aspx");
                    return;
                }
                for (int i = 0; i < this.LstOriginal.Items.Count; i++)
                {
                    if (i > 0) sOrgNews += ",";
                    sOrgNews += "'" + this.LstOriginal.Items[i].Value + "'";
                }
                td.UpdateNews(sOrgNews, 0, 0, "FileEXName", FileEXstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else if (OriginalType.Equals("1"))//对选中的栏目进行操作
            {
                if (this.LstOriginal.SelectedValue.Trim().Equals(""))
                {
                    PageError("请选择要进行操作的栏目!", "NewsList.aspx");
                    return;
                }
                string str = "";
                for (int l = 0; l < this.LstOriginal.Items.Count; l++)
                {
                    if (this.LstOriginal.Items[l].Selected == true)
                    {
                        str += "'" + this.LstOriginal.Items[l].Value + "',";
                    }
                }
                string soclass = Common.Public.Lost(str);
                td.UpdateNews(soclass, 1, 0, "FileEXName", FileEXstr);
                PageRight("更新成功", "NewsList.aspx");
            }
            else
            {
                PageError("错误的原始数据类型!", "NewsList.aspx");
                return;
            }
        }
    }
}
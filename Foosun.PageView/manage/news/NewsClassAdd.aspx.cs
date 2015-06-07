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
using Foosun.CMS;

public partial class NewsClassAdd : Foosun.PageBasic.ManagePage
{
    /// <summary>
    /// 权限设置
    /// </summary>
    public NewsClassAdd()
    {
        Authority_Code = "C021";
    }
    RootPublic RootPublicCMS = new RootPublic();
    Foosun.CMS.NewsClass NewsClassCMS = new NewsClass();
    Foosun.CMS.DefineData DefineDataCMS = new DefineData();
    public string dirm = Foosun.Config.UIConfig.dirDumm;
    Foosun.CMS.sys param = new Foosun.CMS.sys();
    Foosun.CMS.DropTemplet DropTempletCMS = new DropTemplet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //清除缓存
        Response.CacheControl = "no-cache";
        if (!IsPostBack)
        {
            #region 模版加载
            string publishType = param.GetParamBase("publishType");
            if (publishType == "0")
            {
                labelTemplet.Style.Add("display", "block");
                labelNewsTemplet.Style.Add("display", "block");
                dropTemplet.Style.Add("display", "none");
                dropNewsTemplet.Style.Add("display", "none");
            }
            else
            {
                labelTemplet.Style.Add("display", "none");
                labelNewsTemplet.Style.Add("display", "none");
                dropTemplet.Style.Add("display", "block");
                dropNewsTemplet.Style.Add("display", "block");
            }
            #endregion
            string GetSiteID = Request.QueryString["SiteID"];
            if (GetSiteID == null)
            {
                Common.MessageBox.Show(this, "错误的参数,请先选择频道!");
            }
            if (dirm.Trim() != string.Empty) { dirm = "/" + dirm; }
            //SiteCopyRight.InnerHtml = CopyRight;
            string Action = Request.QueryString["Acation"];
            string Cname = Request.QueryString["Cname"];
            String Pram = Request.QueryString["Number"];    //获取查看是否父类
            if (Action != null && Action != "")
            {
                string[] StrNum = Action.Split(',');
                if (StrNum[0] == "Add")
                {
                    //权限管理
                    this.Authority_Code = "C022";
                    this.CheckAdminAuthority();
                    ChangeStatic(StrNum[1]);
                    DefineRows_div.InnerHtml = DefineRowslist(StrNum[1]);
                }
                else
                {
                    Common.MessageBox.ShowAndRedirect(this, "参数不正确,请返回正确操作!", "NewsClassList.aspx");
                }
            }
            else
            {
                if (Request.QueryString["Number"] != string.Empty)
                {
                    if (Request.QueryString["SiteID"] == string.Empty || Request.QueryString["SiteID"] == null)
                    {
                        if (SiteID != "0")
                        {
                            sitelabel.InnerHtml = RootPublicCMS.GetChName(SiteID);
                        }
                        else
                        {
                            sitelabel.InnerHtml = RootPublicCMS.GetChName("0");
                        }
                    }
                    else
                    {
                        sitelabel.InnerHtml = RootPublicCMS.GetChName(Request.QueryString["SiteID"].ToString()); ;
                    }
                }
                if (Pram == null || Pram == "")
                    Pram = "foosun";
                SatratData(Pram);
                TParentId.Enabled = false;
                DefineRows_div.InnerHtml = DefineRowslist("");
            }
            lblParentName.Text = NewsClassCMS.GetNewsClassCName(TParentId.Text);
        }
    }

    /// <summary>
    /// 获得已经选择的自定义
    /// </summary>
    /// <param name="classID"></param>
    /// <returns></returns>
    protected string DefineRowslist(string classID)
    {
        string Str = "<select disabled style=\"height:129px;width:131px;\" name=\"DefineRows\" id=\"DefineRows\"  multiple=\"multiple\">";
        if (classID != "")
        {
            DataTable dte = NewsClassCMS.GetDefineEditTable(classID);
            if (dte != null)
            {
                string TmpDefineworkey = dte.Rows[0]["Defineworkey"].ToString();
                if (TmpDefineworkey.Trim() != string.Empty)
                {
                    string[] TmpDefineworkeyARR = TmpDefineworkey.Split(',');
                    for (int m = 0; m < TmpDefineworkeyARR.Length; m++)
                    {
                        DataTable dt = DefineDataCMS.GetList("id=" + TmpDefineworkeyARR[m]);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Str += "<option value=" + dt.Rows[0]["id"].ToString() + ">" + dt.Rows[0]["defineCname"].ToString() + "</option>\r";
                            }
                            dt.Clear(); dt.Dispose();
                        }
                    }
                }
                dte.Clear(); dte.Dispose();
            }
        }
        Str += "</select>";
        return Str;
    }
    /// <summary>
    /// 绑定用户选择,保存新闻数据表
    /// </summary>
    protected void UserNewsTable(string str)
    {
        string Str = str;
        if (SiteID != "0")
        {
            DataTable DtSite = RootPublicCMS.GetSiteParam(SiteID);
            if (DtSite != null)
            {
                if (DtSite.Rows.Count > 0)
                {
                    Str = DtSite.Rows[0]["DataLib"].ToString().ToUpper();
                }
                DtSite.Clear(); DtSite.Dispose();
            }
        }
    }

    //修改初始化
    protected void ChangeStatic(string classId)
    {
        //检查是否数据表里有数据
        DataTable dt = NewsClassCMS.GetClassContent(classId);
        if (dt != null && dt.Rows.Count > 0)
        {
            TCname.Text = dt.Rows[0]["ClassCName"].ToString();
            TEname.Text = dt.Rows[0]["ClassEName"].ToString();
            //栏目英文不可写
            //TEname.Enabled = false;
            modifynote.InnerHtml = "&nbsp;<span class=\"reshow\">修改后可能产生垃圾文件</span>";
            TParentId.Text = dt.Rows[0]["ParentID"].ToString();
            //父编号不可写
            TParentId.Enabled = false;
            ProjectStatic(dt.Rows[0]["IsURL"].ToString());
            TOrder.Text = dt.Rows[0]["OrderID"].ToString();
            TAddress.Text = dt.Rows[0]["Urladdress"].ToString();
            THoustAddress.Text = dt.Rows[0]["Domain"].ToString();
            THoustAddress.Enabled = false;

            FProjTemplets.Text = dt.Rows[0]["ClassTemplet"].ToString();
            FListTemplets.Text = dt.Rows[0]["ReadNewsTemplet"].ToString();
            dTemplet.Text = DropTempletCMS.GetClassTemplet(classId);
            dListTemplets.Text = DropTempletCMS.GetReadNewsTemplet(classId);
            TPath.Text = dt.Rows[0]["SavePath"].ToString();
            DirData1.Text = dt.Rows[0]["SaveClassframe"].ToString();
            DirData2.Text = dt.Rows[0]["ClassSaveRule"].ToString();
            DirData3.Text = dt.Rows[0]["ClassIndexRule"].ToString();
            NewsSave.Text = dt.Rows[0]["NewsSavePath"].ToString();
            NewsDisplay.Text = dt.Rows[0]["NewsFileRule"].ToString();
            ImageUpload.Text = dt.Rows[0]["PicDirPath"].ToString();
            sitelabel.InnerHtml = RootPublicCMS.GetChName(dt.Rows[0]["SiteID"].ToString());
            ClassID.Value = dt.Rows[0]["ClassID"].ToString();
            this.UserPop1.AuthorityType = int.Parse(dt.Rows[0]["isDelPoint"].ToString());
            this.UserPop1.Point = int.Parse(dt.Rows[0]["iPoint"].ToString());
            this.UserPop1.Gold = int.Parse(dt.Rows[0]["Gpoint"].ToString());
            this.UserPop1.MemberGroup = dt.Rows[0]["GroupNumber"].ToString().Split(',');
            if (dt.Rows[0]["FileName"].ToString() == ".html")
                ExDropDownList.Items[0].Selected = true;
            if (dt.Rows[0]["FileName"].ToString() == ".htm")
                ExDropDownList.Items[1].Selected = true;
            if (dt.Rows[0]["FileName"].ToString() == ".shtml")
                ExDropDownList.Items[2].Selected = true;
            if (dt.Rows[0]["FileName"].ToString() == ".shtm")
                ExDropDownList.Items[3].Selected = true;
            if (dt.Rows[0]["FileName"].ToString() == ".aspx")
                ExDropDownList.Items[4].Selected = true;


            if (dt.Rows[0]["Checkint"].ToString() == "0")
                Auditing.Items[0].Selected = true;
            if (dt.Rows[0]["Checkint"].ToString() == "1")
                Auditing.Items[1].Selected = true;
            if (dt.Rows[0]["Checkint"].ToString() == "2")
                Auditing.Items[2].Selected = true;
            if (dt.Rows[0]["Checkint"].ToString() == "3")
                Auditing.Items[3].Selected = true;

            //检测是否允许画中画
            if (dt.Rows[0]["ContentPicTF"].ToString() == "1" && dt.Rows[0]["IsURL"].ToString() != "1")
            {
                draw.Checked = true;
                Page.RegisterStartupScript("", "<Script>document.getElementById(\"ClssStyle_21\").style.display = \"\";document.getElementById(\"ClssStyle_22\").style.display = \"\";</script>");
                //画中画地址
                drawUrl.Text = dt.Rows[0]["ContentPICurl"].ToString();
                //检测参数设置是否有值
                if (dt.Rows[0]["ContentPicSize"].ToString() != null && dt.Rows[0]["ContentPicSize"].ToString() != String.Empty)
                {
                    string[] wh = dt.Rows[0]["ContentPicSize"].ToString().Split('|');
                    drawWith.Text = wh[0].ToString();
                    drawHeight.Text = wh[1].ToString();
                }
            }
            else
            {
                draw.Checked = false;
                Page.RegisterStartupScript("", "<script>document.getElementById(\"ClssStyle_21\").style.display = \"none\";document.getElementById(\"ClssStyle_22\").style.display = \"none\";</script>");
            }
            ClassIDNum.Value = dt.Rows[0]["ClassID"].ToString();
            Pigeonhole.Text = dt.Rows[0]["InHitoryDay"].ToString();

            UserNewsTable(dt.Rows[0]["DataLib"].ToString());
            //SiteID.Text = dt.Rows[0]["SiteID"].ToString();
            //SiteID.Enabled = false;
            //是否在导航中显示
            if (dt.Rows[0]["NaviShowtf"].ToString() == "1")
            {
                NaviShowtf.Checked = true;
            }
            else
            {
                NaviShowtf.Checked = false;
            }

            //导航文字/图片
            fontText.Text = dt.Rows[0]["NaviContent"].ToString();
            fileLoad.Text = dt.Rows[0]["NaviPIC"].ToString();
            KeyMeata.Text = dt.Rows[0]["MetaKeywords"].ToString();
            BeWrite.Text = dt.Rows[0]["MetaDescript"].ToString();

            //是否允许评论
            if (dt.Rows[0]["isComm"].ToString() == "1")
            {
                Saying.Checked = true;
            }
            else
                Saying.Checked = false;
            HtmlPhrasing.Text = Common.Input.ToTxt(dt.Rows[0]["NaviPosition"].ToString());
            NewsHtmlPhrasing.Text = Common.Input.ToTxt(dt.Rows[0]["NewsPosition"].ToString());
            Hidden.Value = "Add";
            this.HiddenDefine.Value = dt.Rows[0]["Defineworkey"].ToString();

            //处理提交信息
            btnClick.Text = "保存数据";
            #region 输出自定义自段
            DataTable dts = DefineDataCMS.GetAllList();
            if (dts != null)
            {
                DefineColumns.DataTextField = "defineCname";
                DefineColumns.DataValueField = "Id";
                DefineColumns.DataSource = dts;
                DefineColumns.DataBind();
                dts.Clear();
                dts.Dispose();
            }
            #endregion

        }
        else
        {
            Common.MessageBox.ShowAndRedirects(this, "参数不正确,请正确操作!", "NewsClassList.aspx");
        }

    }

    /// <summary>
    /// 检测是否外部栏目
    /// </summary>
    /// <param name="Str"></param>
    protected void ProjectStatic(string Str)
    {
        if (Str == "1")
            CProject.Checked = true;
        else
        {
            CProject.Checked = false;
        }
        csHiden.Value = "1";
    }

    /// <summary>
    /// 数据初始化
    /// </summary>
    /// <param name="Pram"></param>
    protected void SatratData(string Pram)
    {
        UserNewsTable("0");
        //检查参数是父类ID是否有效
        if (Pram != "foosun")
        {
            DataTable dt = NewsClassCMS.GetParentClass(Pram);
            if (dt != null)
            {
                if (dt.Rows.Count > 0) { TParentId.Text = Pram; }
                else
                {
                    Common.MessageBox.ShowAndRedirects(this, "传入的参数不正确!", "NewsClassList.aspx");
                }
            }
            else
            {
                Common.MessageBox.ShowAndRedirects(this, "传入的参数不正确!", "NewsClassList.aspx");
            }
        }
        else
        {
            TParentId.Text = "0";
        }

        #region 输出自定义自段
        DataTable dts = DefineDataCMS.GetAllList();
        if (dts != null)
        {
            DefineColumns.DataTextField = "defineCname";
            DefineColumns.DataValueField = "Id";
            DefineColumns.DataSource = dts;
            DefineColumns.DataBind();
            dts.Clear();
            dts.Dispose();
        }
        #endregion
        //继承参数设置
        DirData2.Text = "{@EName}/index.html";
        DirData3.Text = RootPublicCMS.SaveIndexPage().ToString();
        TOrder.Text = "10";
        Pigeonhole.Text = "180";
        string tmSite = "0";
        string gSiteID = Request.QueryString["SiteID"];
        if (SiteID == "0")
        {
            if (gSiteID != null)
            {
                if (gSiteID.Trim() != string.Empty)
                {
                    tmSite = gSiteID.ToString();
                }
            }
            TPath.Text = RootPublicCMS.SaveClassFilePath(tmSite); //栏目保存路径
            ClassID.Value = "";
            NewsDisplay.Text = RootPublicCMS.SaveNewsFilePath().ToString();
            NewsSave.Text = RootPublicCMS.SaveNewsDirPath().ToString();
            if (RootPublicCMS.CheckInt().ToString() == "0")
                Auditing.Items[0].Selected = true;
            if (RootPublicCMS.CheckInt().ToString() == "1")
                Auditing.Items[1].Selected = true;
            if (RootPublicCMS.CheckInt().ToString() == "2")
                Auditing.Items[2].Selected = true;
            if (RootPublicCMS.CheckInt().ToString() == "3")
                Auditing.Items[3].Selected = true;

            if (RootPublicCMS.PicServerTF().ToString() == "1")
            {
                ImageUpload.Text = RootPublicCMS.PicServerDomain().ToString();
            }
            else
            {
                ImageUpload.Text = "/{@dirFile}";
            }

        }
        else
        {
            tmSite = SiteID;
        }
        this.FProjTemplets.Text = param.GetParamBase("ClasslistTemplet");
        this.dTemplet.Text = param.GetParamBase("ClasslistTemplet");
        this.FListTemplets.Text = param.GetParamBase("ReadNewsTemplet");
        this.dListTemplets.Text = param.GetParamBase("ReadNewsTemplet");
        this.TPath.Text = RootPublicCMS.SaveClassFilePath(tmSite);
        this.NewsDisplay.Text = param.GetParamBase("SaveNewsFilePath");
        this.NewsSave.Text = param.GetParamBase("SaveNewsDirPath");


    }

    protected void btnClick_Click(object sender, EventArgs e)
    {
        #region
        if (Page.IsValid)
        {
            //取得隐藏控件取
            String VclassId = Hidden.Value.ToString().Trim();
            switch (VclassId)
            {
                case "0":
                    SaveData(0);
                    break;
                case "Add":
                    SaveData(1);    //修改数据
                    break;
                default:
                    Common.MessageBox.ShowAndRedirects(this, "参数不正确,请重新正确操作!", "NewsClassList.aspx");
                    break;
            }
        }
        #endregion
        //清除缓存
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="interChar"></param>
    protected void SaveData(int interChar)
    {
        if (Page.IsValid)                       //判断是否验证成功
        {
            #region 得到表单值

            string ClassID = "";
            if (interChar == 0)
            {
                ClassID = Common.Rand.Number(12);
                while (NewsClassCMS.ExistsByClassId(ClassID) > 0)
                {
                    ClassID = Common.Rand.Number(12);
                }
                if (NewsClassCMS.ExistsByClassEName(TEname.Text.Trim()) > 0)
                {
                    Common.MessageBox.Show(this, "栏目的英文名称在站点中已经存在!");
                    return;
                }
            }
            else
            {
                ClassID = this.ClassID.Value;
                NewsClassCMS.UpdateClassStat(0, ClassID);
            }

            Foosun.Model.NewsClass NewsClassModel = new Foosun.Model.NewsClass();
            NewsClassModel.ClassCName = TCname.Text.Trim();
            NewsClassModel.ClassEName = TEname.Text.Trim();
            NewsClassModel.ParentID = TParentId.Text;
            NewsClassModel.IsURL = 0;
            if (this.CProject.Checked)
            {
                NewsClassModel.IsURL = 1;
            }
            NewsClassModel.OrderID = int.Parse(this.TOrder.Text);
            NewsClassModel.URLaddress = TAddress.Text;
            if (NewsClassModel.IsURL == 1)
            {
                if (NewsClassModel.URLaddress.Length < 5)
                {
                    Common.MessageBox.Show(this, "请正确外部连接地址!");
                    return;
                }
            }
            NewsClassModel.Domain = THoustAddress.Text;
            if (NewsClassModel.Domain != null && NewsClassModel.Domain != "")
            {
                if (NewsClassModel.Domain.Length < 5)
                {
                    Common.MessageBox.Show(this, "请正确填写域名地址!");
                    return;
                }
            }
            NewsClassModel.ClassTemplet = FProjTemplets.Text;
            NewsClassModel.ReadNewsTemplet = FListTemplets.Text;
            NewsClassModel.SavePath = TPath.Text;
            NewsClassModel.SaveClassframe = DirData1.Text;
            NewsClassModel.Checkint = int.Parse(this.Auditing.SelectedValue);
            NewsClassModel.ClassSaveRule = DirData2.Text;
            if (NewsClassModel.ClassSaveRule.IndexOf(".") == -1)
            {
                Common.MessageBox.Show(this, "文件名规则必须填写文件名!");
                return;
            }
            NewsClassModel.ClassIndexRule = DirData3.Text;
            NewsClassModel.NewsSavePath = NewsSave.Text;
            NewsClassModel.NewsFileRule = NewsDisplay.Text;
            NewsClassModel.PicDirPath = ImageUpload.Text;
            NewsClassModel.ContentPicTF = 0;
            if (this.draw.Checked == true)
            {
                NewsClassModel.ContentPicTF = 1;
                if (((this.drawUrl.Text).ToString()).Length < 5)
                {
                    Common.MessageBox.Show(this, "请正确填写画中画内容!");
                    return;
                }
                if (((this.drawWith.Text).ToString()).Length < 1)
                {
                    Common.MessageBox.Show(this, "请正确填写画中画图片(Flash)，代码的宽度!");
                    return;
                }
                if (((this.drawHeight.Text).ToString()).Length < 1)
                {
                    Common.MessageBox.Show(this, "请正确填写画中画图片(Flash),代码的高度!");
                    return;
                }
            }
            NewsClassModel.ContentPICurl = drawUrl.Text;
            NewsClassModel.ContentPicSize = drawHeight.Text + "|" + drawWith.Text;
            NewsClassModel.InHitoryDay = int.Parse(Pigeonhole.Text);
            NewsClassModel.SiteID = "0";
            if (SiteID == "0")
            {
                if (Request.QueryString["SiteID"] != string.Empty && Request.QueryString["SiteID"] != null)
                {
                    NewsClassModel.SiteID = Request.QueryString["SiteID"];
                }
            }
            else
            {
                NewsClassModel.SiteID = SiteID;
            }
            NewsClassModel.NaviShowtf = 0;
            if (this.NaviShowtf.Checked)
            {
                NewsClassModel.NaviShowtf = 1;
            }
            NewsClassModel.NaviPIC = fileLoad.Text;
            NewsClassModel.NaviContent = fontText.Text;
            NewsClassModel.MetaDescript = BeWrite.Text;
            NewsClassModel.MetaKeywords = KeyMeata.Text;
            #region 获得权限开始
            NewsClassModel.isDelPoint = this.UserPop1.AuthorityType;
            NewsClassModel.Gpoint = this.UserPop1.Gold;
            NewsClassModel.iPoint = this.UserPop1.Point;
            string[] _GroupNumber = this.UserPop1.MemberGroup;
            NewsClassModel.GroupNumber = "";
            foreach (string gnum in _GroupNumber)
            {
                if (NewsClassModel.GroupNumber != "")
                    NewsClassModel.GroupNumber += ",";
                NewsClassModel.GroupNumber += gnum;
            }
            #endregion 获得权限结束
            NewsClassModel.FileName = Request.Form["ExDropDownList"];
            NewsClassModel.isLock = 0;
            NewsClassModel.isRecyle = 0;
            NewsClassModel.NaviPosition = ReplaceNavi(HtmlPhrasing.Text.Trim(), TParentId.Text);
            NewsClassModel.NewsPosition = ReplaceNavi(NewsHtmlPhrasing.Text, TParentId.Text);
            NewsClassModel.isComm = 0;
            if (this.Saying.Checked)
            {
                NewsClassModel.isComm = 1;
            }
            NewsClassModel.Defineworkey = HiddenDefine.Value;
            NewsClassModel.ClassID = ClassID;
            NewsClassModel.CreatTime = DateTime.Now;
            Common.Public.SaveClassXML(NewsClassModel.ClassEName);
            if (interChar == 0)
            {
                NewsClassCMS.Add(NewsClassModel);
                NewsClassCMS.UpdateReplaceNavi(ClassID);
                DropTempletCMS.AddTemplet(ClassID, dTemplet.Text, dListTemplets.Text, "1");
                Common.MessageBox.ShowAndRedirect(this, "添加栏目成功!", "NewsClassList.aspx");
            }
            else
            {
                NewsClassCMS.Update(NewsClassModel);
                NewsClassCMS.UpdateReplaceNavi(ClassID);
                DropTempletCMS.DeleteTemplet(ClassID, "1");
                DropTempletCMS.AddTemplet(ClassID, dTemplet.Text, dListTemplets.Text, "1");
                Common.MessageBox.ShowAndRedirect(this, "修改栏目成功!", "NewsClassList.aspx");
            }
            #endregion 得到表单值

        }
    }

    /// <summary>
    /// 替换导航
    /// </summary>
    /// <param name="Content"></param>
    /// <param name="classID"></param>
    /// <returns></returns>
    protected string ReplaceNavi(string contents, string classID)
    {
        string GetResult = "";
        GetResult = contents.Replace("{@ParentClassStr}", GetNaviClassName(classID));
        return GetResult;
    }

    protected string GetNaviClassName(string classID)
    {
        string Str = "";
        if (dirm.Trim() != string.Empty)
        {
            dirm = "/" + dirm;
        }
        string urls = "";
        IDataReader dr = NewsClassCMS.GetNaviClass(classID);
        if (dr.Read())
        {
            string tmsavebstr = dirm + "/" + dr["SavePath"].ToString() + "/" + dr["SaveClassframe"].ToString() + "/" + dr["ClassSaveRule"].ToString();
            Str += "<a href=\"" + tmsavebstr.Replace("//", "/") + "\">" + dr["ClassCName"] + "</a> >> ";
            if (dr["ParentID"] != DBNull.Value && dr["ParentID"].ToString() != "0")
            {
                IDataReader dr2 = NewsClassCMS.GetNaviClass(dr["ParentID"].ToString());
                while (dr2.Read())
                {
                    urls = dirm + "/" + dr["SavePath"].ToString() + "/" + dr2["SaveClassframe"].ToString() + "/" + dr2["ClassSaveRule"].ToString();
                    Str = "<a href=\"" + urls.Replace("//", "/") + "\">" + dr2["ClassCName"] + "</a> >> " + Str;
                    Str = GetNaviClassName(dr2["ParentID"].ToString()) + Str;
                }
                dr2.Close();
            }
        }
        dr.Close();
        return Str;
    }

    protected string GetClassSavePath()
    {
        string ClassSavePath = "";
        string str_SiteID = Request.QueryString["SiteID"];
        bool tf = false;
        if (SiteID != "0")
        {
            str_SiteID = SiteID;
            tf = true;
        }
        else
        {
            if (str_SiteID == "0")
            {
                tf = false;
            }
            else
            {
                tf = true;
            }
        }
        if (tf)
        {
            ClassSavePath = RootPublicCMS.SaveClassFilePath(str_SiteID); //栏目保存路径
        }
        else
        {
            ClassSavePath = Foosun.Config.UIConfig.dirHtml;
        }
        return ClassSavePath;
    }
}

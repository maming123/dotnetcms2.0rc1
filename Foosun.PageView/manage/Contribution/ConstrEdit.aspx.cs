using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.Contribution
{
    public partial class ConstrEdit : Foosun.PageBasic.ManagePage
    {
        Constr con = new Constr();
        private string fileURL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            this.ClassCName.Attributes["readonly"] = "true";
            if (!IsPostBack)
            {
                this.Authority_Code = "C043";
                this.CheckAdminAuthority();
                if (Request.QueryString["type"]!=null)
                {
                    ishow.Style.Add("display","none"); 
                }
                string ConIDs =Common.Input.Filter(Request.QueryString["ConID"].ToString());
                DataTable dtx = con.Sel11(ConIDs);
                content.Value = dtx.Rows[0]["Content"].ToString();
                this.Title.Text = dtx.Rows[0]["Title"].ToString();
                this.Author.Text = dtx.Rows[0]["Author"].ToString();
                this.Tags.Text = dtx.Rows[0]["Tags"].ToString();
                string picurl = dtx.Rows[0]["picURL"].ToString();
                if (string.IsNullOrEmpty(picurl))
                {
                    tr.Style.Add("display", "none");
                }
                else
                {
                    tr.Style.Add("display", "");
                    showimg.InnerHtml = "<img src='../.." + picurl + "' style='height:100;width:50;' />";
                }
                int isCheckss = int.Parse(dtx.Rows[0]["isCheck"].ToString());
                if (isCheckss == 1)
                {
                    PageError("对不起此搞已经审核不能在审核!", "");
                }               
                string classid = dtx.Rows[0]["ClassID"].ToString();
                if (!string.IsNullOrEmpty(classid))
                {
                    this.ClassID.Value = classid;
                    Foosun.CMS.NewsClass cm =new NewsClass ();
                    this.ClassCName.Text = cm.GetNewsClassCName(classid);
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RootPublic rd = new RootPublic();
                string Contents = content.Value;
                string Title = Common.Input.Filter(Request.Form["Title"].ToString());
                string Author = this.Author.Text;
                string ConIDp = Common.Input.Filter(Request.QueryString["ConID"].ToString());
                DataTable dt = con.Sel13(ConIDp);
                string Source = dt.Rows[0]["Source"].ToString();
                string PicURL = dt.Rows[0]["PicURL"].ToString();
                string site = dt.Rows[0]["SiteID"].ToString();
                string sUNum = dt.Rows[0]["UserNum"].ToString();
                string Tags = this.Tags.Text;
                string creatTime = dt.Rows[0]["creatTime"].ToString();
                string ClassID1 = Request.Form["ClassCName"].ToString();
                string ClassID = Request.Form["ClassID"].ToString();
                string DataLib = con.Sel18(ClassID);
                string NewsTemplet = "/{@dirTemplet}/Content/news.html";
                string strSavePath = "{@year04}-{@month}-{@day}";
                string strfileName = "constr-" +Common.Rand.Number(5) + "";
                string strfileexName = ".html";
                string strCheckInt = "0|0|0|0";
                int NewsType = 0;
                fileURL = dt.Rows[0]["fileURL"].ToString(); ;
                if (!string.IsNullOrEmpty(PicURL))
                {
                    NewsType = 1;
                }
                string NewsID =Common.Rand.Number(12);//产生12位随机字符
                DataTable dts = con.GetClassInfo(ClassID);
                if (dts != null)
                {
                    if (dts.Rows.Count > 0)
                    {
                        NewsTemplet = dts.Rows[0]["ReadNewsTemplet"].ToString();
                        strSavePath = dts.Rows[0]["NewsSavePath"].ToString();
                        if (strSavePath.IndexOf("{@year04}") >= 0)
                        {
                            strSavePath = strSavePath.Replace("{@year04}", DateTime.Now.ToString("yyyy"));
                        }
                        if (strSavePath.IndexOf("{@year02}") >= 0)
                        {
                            strSavePath = strSavePath.Replace("{@year02}", DateTime.Now.ToString("yy"));
                        }
                        if (strSavePath.IndexOf("{@month}") >= 0)
                        {
                            strSavePath = strSavePath.Replace("{@month}", DateTime.Now.ToString("MM"));
                        }
                        if (strSavePath.IndexOf("{@day}") >= 0)
                        {
                            strSavePath = strSavePath.Replace("{@day}", DateTime.Now.ToString("dd"));
                        }
                        strfileName = dts.Rows[0]["NewsFileRule"].ToString();
                        if (strfileName.IndexOf("{@自动编号ID}") >= 0)
                        {
                            strfileName = strfileName.Replace("{@自动编号ID}", NewsID);
                        }
                        strfileexName = dts.Rows[0]["FileName"].ToString();
                        if (dts.Rows[0]["CheckInt"].ToString() == "1") { strCheckInt = "1|1|0|0"; }
                        else if (dts.Rows[0]["CheckInt"].ToString() == "2") { strCheckInt = "2|1|1|0"; }
                        else if (dts.Rows[0]["CheckInt"].ToString() == "3") { strCheckInt = "3|1|1|1"; }
                    }
                    dts.Clear(); dts.Dispose();
                }
                DateTime CreatTime1 = DateTime.Now;
                string content4 = "稿酬";
                DataTable dt_User = con.Sel15(sUNum);
                int gPoint1 = int.Parse(dt_User.Rows[0]["gPoint"].ToString());
                int iPoint1 = int.Parse(dt_User.Rows[0]["iPoint"].ToString());
                int cPoint = int.Parse(dt_User.Rows[0]["cPoint"].ToString());
                int aPoint = int.Parse(dt_User.Rows[0]["aPoint"].ToString());
                int Money2 = int.Parse(dt_User.Rows[0]["ParmConstrNum"].ToString());
                DataTable dt4 = con.Sel16();
                string[] cPointParam = dt4.Rows[0]["cPointParam"].ToString().Split('|');
                string[] aPointparam = dt4.Rows[0]["aPointparam"].ToString().Split('|');
                int cPoint1 = int.Parse(cPointParam[1]);
                int aPoint1 = int.Parse(aPointparam[1]);
                int cPoint2 = cPoint + cPoint1;
                int aPoint2 = aPoint + aPoint1;
                int gPoint2 = 0 + gPoint1;
                int iPoint2 =int.Parse( paynum.Text) + iPoint1;
                int Money3 = int.Parse(paynum.Text) + Money2;
                string _UserID = rd.GetUserName(sUNum);
                byte isFiles = 0;
                if (!string.IsNullOrEmpty(fileURL))
                {
                    isFiles = 1;
                }
                if (con.Add3(NewsID, NewsType, Title, PicURL, ClassID, Author, _UserID, Source, Contents, creatTime, site, Tags, DataLib, NewsTemplet, strSavePath, strfileName, strfileexName, strCheckInt, isFiles) == 0 || con.Update4(ConIDp) == 0 || con.Update5(iPoint2, gPoint2, Money3, cPoint2, aPoint2, UserNum) == 0 || con.Add4(NewsID, 0, int.Parse(paynum.Text), 0, CreatTime1, UserNum, content4) == 0)
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "编辑审核投稿", "编辑审核失败");
                    PageError("审核错误", "");
                }
                else
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "编辑审核投稿", "编辑审核成功");
                    Foosun.CMS.News cm = new News ();
                    if (!string.IsNullOrEmpty(fileURL))
                        cm.InsertFileURL("附件", NewsID, DataLib, fileURL, 0);
                    PageRight("审核成功", "ConstrList.aspx");
                }
            }
        }
    }
}
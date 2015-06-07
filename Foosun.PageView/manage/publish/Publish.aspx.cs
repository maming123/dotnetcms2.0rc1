using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;

namespace Foosun.PageView.manage.publish
{
    public partial class Publish : Foosun.PageBasic.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Foosun.CMS.sys param = new CMS.sys();
                string publishType = param.GetParamBase("publishType");
                if (publishType == "0")
                {
                    LabelPublish();
                }
                else
                {
                    ReplaceTemp();
                }
            }
        }

        /// <summary>
        /// 拖拽发布
        /// </summary>
        public void ReplaceTemp()
        {
            DataTable dt = new DataTable();
            CMS.News NewsCMS = new CMS.News();
            CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
            CMS.NewsSpecial NewsSpecialCMS = new CMS.NewsSpecial();
            string type = Request.QueryString["type"];
            //发布首页
            string PublishIndex = Request.QueryString["publishIndex"];
            //备份首页
            string BakIndex = Request.QueryString["bakIndex"];

            string ptype = string.Empty;
            string where = string.Empty;
            switch (type)
            {
                case "newsall":
                    ptype = "new";
                    dt = NewsCMS.GetNewsConent("ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", "", "");
                    break;
                case "newsid":
                    ptype = "new";
                    string startId = Request.QueryString["startId"];
                    string endId = Request.QueryString["endId"];
                    dt = NewsCMS.GetNewsConent("ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", " id>=" + startId + " and id<=" + endId, "");
                    break;
                case "newslast":
                    ptype = "new";
                    string newNum = Request.QueryString["newNum"];
                    dt = NewsCMS.GetNewsConent(" top " + newNum + " ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", "", " id desc");
                    break;
                case "newsunhtml":
                    ptype = "new";
                    string unhtmlNum = Request.QueryString["unhtmlNum"];
                    dt = NewsCMS.GetNewsConent(" top " + unhtmlNum + " ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", " isHtml='0'", "");
                    break;
                case "today":
                    ptype = "new";
                    dt = NewsCMS.GetNewsConent("ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", " DateDiff(dd,EditTime,getdate())=0", "");
                    break;
                case "newsdate":
                    ptype = "new";
                    string startDate = Request.QueryString["startDate"];
                    string endDate = Request.QueryString["endDate"];
                    dt = NewsCMS.GetNewsConent("ID,NewsID,NewsTitle,SavePath,FileName,FileEXName,Metakeywords,Metadesc,ClassID", " EditTime>='" + startDate + "' and EditTime<='" + endDate + "'", "");
                    break;
                case "classclass":
                    ptype = "class";
                    string newclassids = Request.QueryString["newclassids"];
                    string unhtmlclass = Request.QueryString["unhtmlclass"];
                    where = "";
                    if (newclassids == "classall")
                    {
                        where = " 1=1";
                    }
                    else
                    {
                        where = " ClassID in ('" + newclassids.Replace("$","','") + "')";
                    }
                    if (unhtmlclass == "true")
                    {
                        where += " and isunHTML='0'";
                    }
                    dt = NewsClassCMS.GetContent("ID,ClassID,ClassCName,ClassEName,ParentID,SavePath,FileName,ClassSaveRule,MetaDescript,MetaKeywords", where, "");
                    break;
                case "special":
                    ptype = "special";
                    string specialid = Request.QueryString["specialid"];
                    where = "";
                    if (specialid == "specialall")
                    {
                        where = " 1=1";
                    }
                    else
                    {
                        where = " SpecialID in (" + specialid + ")";
                    }
                    dt = NewsSpecialCMS.GetContent("ID,SpecialID,SpecialCName,SpecialEName,ParentID,Domain,SavePath,FileName,FileEXName,SaveDirPath", where, "");
                    break;
                case "page":
                    string pageid = Request.QueryString["pageid"].Replace("$", "','");
                    ptype = "page";
                    if (pageid == "" || pageid == null)
                    {
                        Response.Write("没有要发布的单页面!");
                        break;
                    }
                    where = "isPage=1 and ClassId in ('" + pageid + "')";
                    dt = NewsClassCMS.GetContent("ID,ClassID,ClassCName,ClassEName,ParentID,SavePath,MetaDescript,MetaKeywords", where, "");
                    break;
            }

            if (BakIndex == "true")
            {
                string sourceFile = "~/" + Common.Public.readparamConfig("IndexFileName");
                string str_dirPige = Foosun.Config.UIConfig.dirPige;
                if (File.Exists(Server.MapPath(sourceFile)))
                {
                    string TagetFile = "~/" + str_dirPige + "/index/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".shtml";
                    string hfile = "~/" + str_dirPige;
                    string TagetDir = "~/" + str_dirPige + "/index";
                    sourceFile = sourceFile.Replace("//", "/").Replace(@"\\", @"\");
                    TagetFile = TagetFile.Replace("//", "/").Replace(@"\\", @"\");
                    TagetDir = TagetDir.Replace("//", "/").Replace(@"\\", @"\");
                    hfile = hfile.Replace("//", "/").Replace(@"\\", @"\");
                    if (!Directory.Exists(Server.MapPath(hfile))) { Directory.CreateDirectory(Server.MapPath(hfile)); }
                    if (!Directory.Exists(Server.MapPath(TagetDir))) { Directory.CreateDirectory(Server.MapPath(TagetDir)); }
                    if (File.Exists(Server.MapPath(TagetFile))) { File.Delete(Server.MapPath(TagetFile)); }
                    File.Move(Server.MapPath(sourceFile), Server.MapPath(TagetFile));
                }
            }
            Foosun.Publish.DropPublish dp = new Foosun.Publish.DropPublish();
            int i = 0;
            beginProgress();
            if (Convert.ToBoolean(PublishIndex))
            {
                dp.publish(null, "index");
                setProgress(1, "index", "1");
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;
                
                foreach (DataRow dr in dt.Rows)
                {
                    dp.publish(dr, ptype);
                    i++;
                    setProgress(i, ptype, count.ToString());
                }
            }
            finishProgress(ptype);
        }

        private void beginProgress()
        {
            //根据ProgressBar.htm显示进度条界面
            string templateFileName = Path.Combine(Server.MapPath("."), "ProgressBar.htm");
            StreamReader reader = new StreamReader(@templateFileName, System.Text.Encoding.GetEncoding("GB2312"));
            string html = reader.ReadToEnd();
            reader.Close();
            Response.Write(html);
            Response.Flush();
        }

        private void finishProgress(string ptype)
        {
            string jsBlock = "<script>SetCompleted('" + ptype + "');</script>";
            Response.Write(jsBlock);
            Response.Flush();
        }

        private void setProgress(int percent, string ptype, string count)
        {
            string jsBlock = "<script>SetPorgressBar('" + percent.ToString() + "', '" + ptype + "', '" + count + "'); </script>";
            Response.Write(jsBlock);
            Response.Flush();
        }

        /// <summary>
        /// 标签发布
        /// </summary>
        private void LabelPublish()
        {
            //发布首页
            string PublishIndex = Request.QueryString["publishIndex"];
            //备份首页
            string BakIndex = Request.QueryString["bakIndex"];
            //发布类型
            string PublishType = Request.QueryString["type"];

            Foosun.Publish.UltiPublish puli = new Foosun.Publish.UltiPublish(true);
            puli.newsFlag = 0;
            puli.IsPubNews = false;
            puli.strNewsParams = null;
            puli.ClassFlag = 1;
            puli.isClassIndex = false;
            puli.IsPubClass = false;
            puli.IsPubIsPage = false;
            puli.IsPublishIndex = false;
            puli.IsPubSpecial = false;
            puli.specialFlag = 1;
            puli.StrClassIsPageParam = string.Empty;
            puli.strClassParams = string.Empty;
            puli.strSpecialParams = string.Empty;
            puli.SiteRootPath = Server.MapPath("~/");
            puli.IsPublishIndex = Convert.ToBoolean(PublishIndex);
            switch (PublishType)
            {
                case "newsall"://全部新闻
                    puli.newsFlag = 0;
                    puli.IsPubNews = true;
                    puli.strNewsParams = null;
                    break;
                case "newsid"://新闻ID
                    puli.newsFlag = 5;
                    puli.IsPubNews = true;
                    puli.strNewsParams = Request.QueryString["startId"] + "$" + Request.QueryString["endId"];
                    break;
                case "newslast"://最新新闻
                    puli.newsFlag = 1;
                    puli.IsPubNews = true;
                    puli.strNewsParams = Request.QueryString["newNum"];
                    break;
                case "newsunhtml"://未生成
                    puli.newsFlag = 2;
                    puli.IsPubNews = true;
                    puli.strNewsParams = Request.QueryString["unhtmlNum"];
                    break;
                case "newstoday"://今天
                    puli.newsFlag = 4;
                    puli.IsPubNews = true;
                    puli.strNewsParams = DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "$" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                    break;
                case "newsdate"://时间
                    puli.newsFlag = 4;
                    puli.IsPubNews = true;
                    puli.strNewsParams = Request.QueryString["startDate"] + "$" + Request.QueryString["endDate"];
                    break;
                case "newsclass"://栏目
                    puli.newsFlag = 3;
                    puli.IsPubNews = true;
                    puli.strNewsParams = Request.QueryString["newclassids"];
                    break;
                case "classclass":
                    if (Request.QueryString["newclassids"] == "classall")
                    {
                        puli.IsPubClass = true;
                        puli.ClassFlag = 0;
                        if (Request.QueryString["unhtmlclass"] == "true")
                        {
                            puli.strClassParams = "#";
                        }
                    }
                    else
                    {
                        puli.ClassFlag = 1;
                        puli.strClassParams = Request.QueryString["newclassids"];
                        if (Request.QueryString["unhtmlclass"] != null)
                        {
                            puli.IsPubClass = true;
                        }
                    }
                    break;
                case "special":
                    if (Request.QueryString["specialid"] == "specialall")
                    {
                        puli.IsPubSpecial = true;
                        puli.specialFlag = 0;
                    }
                    else
                    {
                        puli.specialFlag = 1;
                        if (Request.QueryString["specialid"] != null)
                        {
                            puli.strSpecialParams = Request.QueryString["specialid"];
                            puli.IsPubSpecial = true;
                        }
                    }
                    break;
                case "page":
                    puli.IsPubIsPage = true;
                    puli.StrClassIsPageParam = Request.QueryString["pageid"];
                    break;
            }
            if (puli.IsPublishIndex)
            {
                this.Authority_Code = "P001";
                this.CheckAdminAuthority();
            }
            if (puli.IsPubNews)
            {
                this.Authority_Code = "P002";
                this.CheckAdminAuthority();
            }
            if (puli.IsPubClass)
            {
                this.Authority_Code = "P003";
                this.CheckAdminAuthority();
            }
            if (puli.IsPubSpecial)
            {
                this.Authority_Code = "P004";
                this.CheckAdminAuthority();
            }
            if (puli.IsPubIsPage)
            {
                this.Authority_Code = "P015";
                this.CheckAdminAuthority();
            }
            if (BakIndex == "true")
            {
                string sourceFile = "~/" + Common.Public.readparamConfig("IndexFileName");
                string str_dirPige = Foosun.Config.UIConfig.dirPige;
                if (File.Exists(Server.MapPath(sourceFile)))
                {
                    string TagetFile = "~/" + str_dirPige + "/index/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".shtml";
                    string hfile = "~/" + str_dirPige;
                    string TagetDir = "~/" + str_dirPige + "/index";
                    sourceFile = sourceFile.Replace("//", "/").Replace(@"\\", @"\");
                    TagetFile = TagetFile.Replace("//", "/").Replace(@"\\", @"\");
                    TagetDir = TagetDir.Replace("//", "/").Replace(@"\\", @"\");
                    hfile = hfile.Replace("//", "/").Replace(@"\\", @"\");
                    if (!Directory.Exists(Server.MapPath(hfile))) { Directory.CreateDirectory(Server.MapPath(hfile)); }
                    if (!Directory.Exists(Server.MapPath(TagetDir))) { Directory.CreateDirectory(Server.MapPath(TagetDir)); }
                    if (File.Exists(Server.MapPath(TagetFile))) { File.Delete(Server.MapPath(TagetFile)); }
                    File.Move(Server.MapPath(sourceFile), Server.MapPath(TagetFile));
                }
            }
            puli.BeganToPublish();
        }

        private void DropPublish()
        { 
            
        }

    }
}
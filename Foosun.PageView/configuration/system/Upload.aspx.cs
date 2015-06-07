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
using System.Drawing;
using System.Drawing.Imaging;
using Common;

public partial class manage_Templet_Upload : Foosun.PageBasic.DialogPage
{
    public manage_Templet_Upload()
    {
        BrowserAuthor = EnumDialogAuthority.ForAdmin;
    }
    string str_returnpath = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        string upfiletype = Request.QueryString["upfiletype"];
        if (upfiletype == "templets" || upfiletype == "droptemplets") { this.isWater.Visible = false; }

        Foosun.CMS.sys Sys = new Foosun.CMS.sys();
        DataTable dt_sys = Sys.WaterStart();
        if (!Page.IsPostBack)
        {
            //是否开启略缩图
            if (dt_sys.Rows[0]["PrintSmallTF"].ToString().Equals("10"))
                this.isDelineation.Checked = true;
            else
                this.isDelineation.Checked = false;
            //是否开启水印
            if (dt_sys.Rows[0]["PrintTF"].ToString().Equals("1"))
                this.isWater.Checked = true;
            else
                this.isWater.Checked = false;
        }

        string Type = Request.QueryString["Type"];                              //取得参数以判断是否上传文件
        if (Type == "Upload")
        {
            //判断用户上传的文件是否是图片，如果不是图片，则不使用水印等功能
            string templeImgName = ".jpe.jpeg.jpg.png.tif.tiff.bmp.gif".ToLower();
            string fileLastName = file.PostedFile.FileName.Substring(file.PostedFile.FileName.LastIndexOf('.'), file.PostedFile.FileName.Length - file.PostedFile.FileName.LastIndexOf('.'));
            fileLastName = fileLastName.ToLower();
            if (templeImgName.IndexOf(fileLastName) == -1)
            {
                this.isWater.Checked = false;
                this.isDelineation.Checked = false;
            }
            string Path = Server.UrlDecode(Request.QueryString["Path"]);                          //取得上传文件所要保存的路径
            string localSavedir = Foosun.Config.UIConfig.dirFile;
            if (string.IsNullOrEmpty(localSavedir))
            {
                localSavedir = "files";
            }
            else
            {
                if (!localSavedir.Equals("files"))
                {
                    localSavedir = "files/" + localSavedir;
                }
            }
            string localtemplet = Foosun.Config.UIConfig.dirTemplet;
            string dimmdir = Foosun.Config.UIConfig.dirDumm;
            string _Tmpdimmdir = "";
            string UDir = "";
            if (dimmdir.Trim() != "") { _Tmpdimmdir = "/" + dimmdir; }
            str_returnpath = _Tmpdimmdir + "/" + localSavedir + "/" + Path;
            switch (upfiletype)
            {
                case "templets":
                    Path = Server.MapPath(_Tmpdimmdir + "/" + localtemplet + "/" + Path);
                    break;
                case "templet":
                    Path = Server.MapPath(_Tmpdimmdir + "/" + localtemplet + "/" + Path);
                    break;
                case "files":
                    Path = Server.MapPath(_Tmpdimmdir + "/" + localSavedir + "/" + Path);
                    break;
                case "droptemplets":
                    Path = Server.MapPath(_Tmpdimmdir + "/DropTemplets/" + Path);
                    break;
                default:
                    Path = Server.MapPath(_Tmpdimmdir + "/" + localSavedir + "/" + Path);
                    break;
            }
            if (Path != "" && Path != null && Path != string.Empty)             //判断路径是否正确
            {
                Foosun.CMS.UpLoad tt = new Foosun.CMS.UpLoad();   //实例化上传类
                Foosun.CMS.RootPublic up = new Foosun.CMS.RootPublic();
                DataTable dt = up.GetUploadInfo();
                string utype = "jpg,gif,bmp,png,swf";
                int usize = 500;
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        utype = dt.Rows[0]["UpfilesType"].ToString();
                        usize = int.Parse(dt.Rows[0]["UpFilesSize"].ToString());
                    }
                    dt.Clear(); dt.Dispose();
                }
                tt.FileLength = usize;                   //为类参数赋值,此为上传文件允许的大小值,单位kb
                tt.Extension = utype;                    //为类参数赋值,此为上传文件允许上传的类型,以","号分隔
                string _Ytmp = DateTime.Now.Year + "-" + DateTime.Now.Month;
                if (this.yearDirTF.Checked) { tt.SavePath = Path + "\\" + _Ytmp + "\\"; }
                else { tt.SavePath = Path; }
                int _num = 0;
                if (this.CheckFileTF.Checked) { _num = 1; }
                tt.PostedFile = file.PostedFile;         //为类参数赋值,此为上传文件所读取的上传控件值
                //实现水印、缩图
                string[] ReturnStr = tt.Upload(_num, 1, usize).Split('$');
                //生成水印
                if (ReturnStr[1] == "1")
                {
                    string _fileNamePath = "";
                    string ResultSTR = "";
                    string s_rpath = Server.UrlDecode(Request.QueryString["Path"]);
                    string s_rppath = Server.UrlDecode(Request.QueryString["ParentPath"]);
                    s_rpath = s_rpath.Replace("\\", "\\\\");
                    s_rppath = s_rppath.Replace("\\", "\\\\");
                    if (upfiletype != "templets"&&upfiletype!="DropTemplets")
                    {
                        if (Foosun.Global.Current.SiteID != "0")
                        {
                            UDir = _Tmpdimmdir + "/" + Foosun.Config.UIConfig.dirSite + "/" + Foosun.Global.Current.SiteID + "/" + localSavedir + "/" + Server.UrlDecode(Request.QueryString["Path"]);
                        }
                        else
                        {
                            UDir = _Tmpdimmdir + "/" + localSavedir + "/" + Server.UrlDecode(Request.QueryString["Path"]);
                        }

                        UDir = UDir.Replace("//", "/");

                        _fileNamePath = UDir + "/" + ReturnStr[0];
                        if (this.yearDirTF.Checked)
                        {
                            _fileNamePath = UDir + "/" + _Ytmp + "/" + ReturnStr[0];
                        }

                        //实现水印、缩图
                        Foosun.CMS.FSImage fd = new Foosun.CMS.FSImage(0, 0, Server.MapPath(_fileNamePath));
                        //判断是否生成缩略图
                        if (this.isDelineation.Checked)
                        {
                            string[] delineaStr = ReturnStr;
                            if (this.isWater.Checked)//如果是即加水印又加缩略图,则生成一张图片进行缩略
                            {
                                delineaStr = tt.Upload(_num, 1, usize).Split('$');
                            }
                            //是否加年月文件夹
                            string udirPath = UDir;
                            if (this.yearDirTF.Checked)
                            {
                                if (UDir.IndexOf(DateTime.Now.ToString("yyyy-MM")) == -1)
                                    udirPath += "/" + _Ytmp;
                            }
                            fd.Smalstyle = dt_sys.Rows[0]["PrintSmallSizeStyle"].ToString();
                            fd.Smalsize = dt_sys.Rows[0]["PrintSmallSize"].ToString();
                            fd.Smallin = dt_sys.Rows[0]["PrintSmallinv"].ToString();
                            fd.Thumbnail(Server.MapPath(udirPath + "/" + delineaStr[0])); //生成缩略图
                        }
                        if (this.isWater.Checked)
                        {
                            if (dt_sys.Rows[0]["PrintPicTF"].ToString() == "7")
                            {
                                //实现水印、缩图
                                fd.Diaph = dt_sys.Rows[0]["PintPictrans"].ToString();
                                fd.Quality = 100;
                                fd.Title = dt_sys.Rows[0]["PrintWord"].ToString();
                                fd.FontSize = Convert.ToInt32(dt_sys.Rows[0]["Printfontsize"].ToString());
                                if (dt_sys.Rows[0]["PrintBTF"].ToString() == "1")
                                    fd.StrStyle = FontStyle.Bold;
                                fd.FontColor = ColorTranslator.FromHtml("#" + dt_sys.Rows[0]["Printfontcolor"].ToString());
                                fd.BackGroudColor = Color.White;
                                fd.FontFamilyName = dt_sys.Rows[0]["Printfontfamily"].ToString();
                                fd.Waterpos = dt_sys.Rows[0]["PrintPosition"].ToString();
                                fd.Watermark();
                            }
                            else
                            {
                                //实现水印、缩图
                                string[] PrintPicsizeStr = dt_sys.Rows[0]["PrintPicsize"].ToString().Split('|');
                                double a_picsizeHeight = Convert.ToDouble(PrintPicsizeStr[0]);
                                double a_picsizeWidth = Convert.ToDouble(PrintPicsizeStr[1]);
                                fd.Waterpos = dt_sys.Rows[0]["PrintPosition"].ToString();
                                fd.Height = Convert.ToInt32(a_picsizeHeight * 10);
                                fd.Width = Convert.ToInt32(a_picsizeWidth * 10);
                                fd.Diaph = dt_sys.Rows[0]["PintPictrans"].ToString();
                                fd.WaterPath = CreateJs.ReplaceDirfile(Server.MapPath(dimmdir + dt_sys.Rows[0]["PintPicURL"].ToString()));
                                fd.WaterPicturemark();
                            }
                        }
                        dt_sys.Clear(); dt_sys.Dispose();
                        if (this.yearDirTF.Checked) { str_returnpath += "/" + _Ytmp; }
                        //if (templeImgName.IndexOf(fileLastName) == -1)
                        //{
                        //Response.Write("<script type=\"text/javascript\">alert('文件上传成功!');window.close();</script>");
                        //}
                        //else
                        Response.Write("<script type=\"text/javascript\">try{window.opener.insertHTMLEdit('" + str_returnpath + "/" + ReturnStr[0] + "') ; }catch(err){};try{window.opener.ListGo('" + s_rpath + "','" + s_rppath + "','" + Server.UrlEncode(FormatFilePath(str_returnpath + "/" + ReturnStr[0])) + "');}catch(err){};alert('文件上传成功!');window.close();</script>");
                        Response.End();
                    }
                    else { ResultSTR = "<script type=\"text/javascript\">window.opener.ListGo('" + s_rpath + "','" + s_rppath + "','" + Server.UrlEncode(FormatFilePath(str_returnpath + "/" + ReturnStr[0])) + "');alert('" + ReturnStr[0] + "文件上传成功!');window.close();</script>"; }
                    Response.Write(ResultSTR);
                    Response.End();
                }
                else
                {
                    PageError("" + ReturnStr[0] + "<li><a href=\"javascript:history.back()\"><font color=\"red\">返回</font></a>&nbsp;&nbsp;&nbsp;<a href=\"javascript:window.close()\"><font color=\"red\">关闭窗口</font></a></li>", "");
                }
            }
        }
    }
    private string FormatFilePath(string _Path)
    {
        _Path = _Path.Replace("\\", "/");
        _Path = _Path.Replace("//", "/");
        _Path = _Path.Replace("//", "/");
        _Path = _Path.Replace("//", "/");
        return _Path;
    }
}

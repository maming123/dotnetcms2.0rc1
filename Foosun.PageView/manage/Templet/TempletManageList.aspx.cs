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
using System.IO;

public partial class TempletManageList : Foosun.PageBasic.ManagePage
{
    public TempletManageList()
    {
        Authority_Code = "T001";
    }
    private string DirMana = Foosun.Config.UIConfig.dirDumm;
    private string Templet = Foosun.Config.UIConfig.dirTemplet;  //获取模板路径
    private string FilePath = "";
    private string s_url = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!IsPostBack)                                                        //判断页面是否重载
        {
            //copyright.InnerHtml = CopyRight;                            //获取版权信息
        }
        if (DirMana.Trim() != string.Empty)//判断虚拟路径是否为空,如果不是则加上//
        {
            DirMana = "\\" + DirMana;
        }
        string type = Request.QueryString["Type"];
        FilePath = Server.MapPath(DirMana + "\\" + Templet);
        string Path = FilePath + Request.QueryString["Path"];
        string ParentPath = FilePath + Request.QueryString["ParentPath"]; //父级
        try
        {
            if (Path.IndexOf(FilePath, 0) == -1 || ParentPath.IndexOf(FilePath, 0) == -1)
                Response.End();
        }
        catch 
        {
            Common.MessageBox.Show(this, "发生异常!");
        }

        switch (type)
        {
            case "EidtDirName":     //修改文件夹名称
                this.Authority_Code = "T003";
                this.CheckAdminAuthority();
                EidtDirName(Path);
                break;
            case "EidtFileName":    //修改文件名称
                this.Authority_Code = "T007";
                this.CheckAdminAuthority();
                EidtFileName(Path);
                break;
            case "DelDir":          //删除文件夹
                this.Authority_Code = "T004";
                this.CheckAdminAuthority();
                DelDir(Path);
                break;
            case "DelFile":          //删除文件
                this.Authority_Code = "T004";
                this.CheckAdminAuthority();
                DelFile(Path);
                break;
            case "AddDir":
                this.Authority_Code = "T003";
                this.CheckAdminAuthority();
                AddDir(Path);        //添加文件夹
                break;
            default:
                break;
        }
        ShowFile(FilePath, Path, ParentPath);
        s_url = "TempletManageList.aspx?Path=" + Request.QueryString["Path"] + "&ch=" + Request.QueryString["ch"] + "&ParentPath=" + Request.QueryString["ParentPath"];
    }

    /// <summary>
    /// 显示文件列表
    /// </summary>
    /// <param name="defaultpath">默认路径</param>
    /// <param name="path">当前路径</param>
    /// <param name="parentPath">父目录路径</param>
    /// <returns>显示文件列表</returns>
    /// Code By DengXi
    protected void ShowFile(string defaultpath, string path, string parentPath)
    {

        if (path != "" && path != null && path != string.Empty)
        {
            defaultpath = path;
        }
        if (Directory.Exists(defaultpath) == false)            //判断模板目录是否存在
        {
            Common.MessageBox.Show(this, "目录不存在!");
        }
        File_List.InnerHtml = GetDirFile(defaultpath, parentPath);
    }

    /// <summary>
    /// 显示文件列表
    /// </summary>
    /// <param name="dir">当前路径</param>
    /// <param name="ParPath">父目录路径</param>
    /// <returns>显示文件列表</returns>
    protected string GetDirFile(string dir, string ParPath)
    {
        //bug修改,预览带端口不能正常显示
        string DomainAndPort = Request.ServerVariables["Server_Name"];
        if (Convert.ToString(Request.ServerVariables["Server_Port"]) != "80")
        {
            DomainAndPort += ":" + Request.ServerVariables["Server_Port"];
        }

        DirectoryInfo[] ChildDirectory;                         //子目录集
        FileInfo[] NewFileInfo;                                 //当前所有文件

        DirectoryInfo FatherDirectory = new DirectoryInfo(dir); //当前目录

        ChildDirectory = FatherDirectory.GetDirectories("*.*"); //得到子目录集

        NewFileInfo = FatherDirectory.GetFiles();               //得到文件集，可以进行操作
        //-----------获取目录以及文件列表
        string TempFileStr;
        string TempParentstr;
        string TempParentPath = dir.Replace("\\", "\\\\");      //路径转意


        //------------取得当前所在目录
        if (ParPath == "" || ParPath == null || ParPath == string.Empty || ParPath == "undefined")
        {
            TempParentstr = "当前目录:" + dir;
        }
        else
        {
            string TempletTF = "";
            if (SiteID == "0")
            {
                TempletTF = DirMana + "\\" + Templet;
            }
            else
            {
                TempletTF = DirMana + "\\" + Foosun.Config.UIConfig.dirSite + "\\" + Foosun.Global.Current.SiteID + "\\" + Templet;
            }
            if (dir == Server.MapPath(TempletTF))      //判断是否是模板目录,如果是则不显示返回上级目录
            {
                TempParentstr = "当前目录:" + TempletTF.Replace("\\", "/");
            }
            else
            {
                string Thispath = "";
                if (DirMana != null && DirMana != "")
                    Thispath = Server.MapPath(DirMana);
                else
                    Thispath = Server.MapPath("/");

                ParPath = ParPath.Replace("\\", "\\\\");
                string Str_strpath = TempParentPath.Remove(TempParentPath.LastIndexOf("\\") - 1).Replace(FilePath.Replace("\\", "\\\\"), "");//获取当前目录的上级目录
                TempParentstr = "<a href=\"javascript:ListGo('" + Str_strpath.Replace(FilePath.Replace("\\", "\\\\"), "") + "','" + TempParentPath.Replace(FilePath.Replace("\\", "\\\\"), "") + "');\" class=\"xa3\" title=\"点击回到上级目录\">返回上级目录</a>   |   当前目录:/" + dir.Replace(Thispath, "").Replace("\\", "/");
            }
        }
        ShowAddfiledir(TempParentPath.Replace(FilePath.Replace("\\", "\\\\"), "")); //调用显示创建目录,导入文件函数

        TempFileStr = "<div class=\"mo_lan\">";
        TempFileStr += TempParentstr;
        TempFileStr += "</div>";
        TempFileStr += "<div class=\"jslie_lie\">";
        TempFileStr += "<table class=\"jstable\">";
        TempFileStr += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";

        TempFileStr += "<th>名称</th>";
        TempFileStr += "<th>类型</th>";
        TempFileStr += "<th>大小(byte)</th>";
        TempFileStr += "<th>最后修改时间</th>";
        TempFileStr += "<th>操作</th>";
        //获取目录信息
        TempParentPath = TempParentPath.Replace(FilePath.Replace("\\", "\\\\"), "");

        foreach (DirectoryInfo dirInfo in ChildDirectory)       //获取此级目录下的一级目录
        {
            TempFileStr += "<tr  class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
            string TempPath = dirInfo.FullName.Replace("\\", "\\\\");

            TempPath = TempPath.Replace(FilePath.Replace("\\", "\\\\"), "");

            TempFileStr += "<td style=\"width:20%\"><img src=\"../imges/lie_32.gif\" class=\"na1\" alt=\"点击进入下级目录\"><a href=\"javascript:ListGo('" + TempPath + "','" + TempParentPath + "');\" class=\"img\" title=\"点击进入下级目录\">" + dirInfo.Name.ToString() + "</a></td>";
            TempFileStr += "<td style=\"width:15%\" align=\"center\">文件夹</td>";
            TempFileStr += "<td style=\"width:15%\" align=\"center\">-</td>";
            TempFileStr += "<td style=\"width:20%\" align=\"center\">" + dirInfo.LastWriteTime.ToString() + "</td>";
            TempFileStr += "<td style=\"width:30%\"><a href=\"javascript:EditFolder('" + TempParentPath + "','" + dirInfo.Name + "');\" >改名</a><a href=\"javascript:DelDir('" + TempPath + "');\">删除</a></td>";
            TempFileStr += "</tr>";
        }

        //获取文件信息
        foreach (FileInfo DirFile in NewFileInfo)                    //获取此级目录下的所有文件
        {
            if (SelectFile(DirFile.Extension))                       //传入文件后缀名,判断是否是被显示的文件类型,默认显示html,htm,css
            {
                TempFileStr += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                TempFileStr += "<td style=\"width:20%\"><img src=\"../imges/" + GetFileIco(DirFile.Extension.ToString()) + "\" class=\"na1\"><span class=\"span1\">" + DirFile.Name.ToString() + "</span></td>";
                TempFileStr += "<td style=\"width:15%\" align=\"center\">" + DirFile.Extension.ToString() + "文件</td>";
                TempFileStr += "<td style=\"width:15%\" align=\"center\">" + DirFile.Length.ToString() + "</td>";
                TempFileStr += "<td style=\"width:20%\" align=\"center\">" + DirFile.LastWriteTime.ToString() + "</td>";

                TempFileStr += "<td style=\"width:30%\"><a href=\"TempletEditor.aspx?dir=" + Server.UrlEncode(TempParentPath) + "&ch=" + Request.QueryString["ch"] + "&filename=" + Server.UrlEncode(DirFile.Name) + "\" class=\"xa3\">可视编辑</a><a href=\"Txteditor.aspx?dir=" + Server.UrlEncode(TempParentPath) + "&ch=" + Request.QueryString["ch"] + "&filename=" + Server.UrlEncode(DirFile.Name) + "\" class=\"xa3\">文本编辑</a><a href='http://" + DomainAndPort + DirMana + "\\" + PathPre() + "\\" + DirFile.Name + "' class=\"xa3\" target=\"_blank\">预览</a><a href=\"javascript:EditFile('" + TempParentPath + "','" + DirFile.Name + "')\" class=\"xa3\">改名</a><a href=\"javascript:DelFile('" + TempParentPath + "','" + DirFile.Name + "')\" class=\"xa3\">删除</a></td>";
                TempFileStr += "</tr>";
            }
        }
        TempFileStr += "</table>";
        TempFileStr += "</div>";
        return TempFileStr;
    }

    /// <summary>
    /// 获取上级目录
    /// </summary>
    /// <returns>获取上级目录</returns>
    string PathPre()
    {
        string Path = Common.FileAction.GetParentPathByPath(FilePath + Request.QueryString["Path"], Templet);
        return Path;
    }

    /// <summary>
    /// 判断文件后缀名,选取要列举出来的文件
    /// </summary>
    /// <param name="Extension">文件后缀名</param>
    /// <returns>如果是所列举的类型,则返回true,否则为false</returns>
    protected bool SelectFile(string Extension)
    {
        bool value = false;
        switch (Extension.ToLower())
        {
            case ".htm":
                value = true;
                break;
            case ".html":
                value = true;
                break;
            case ".shtml":
                value = true;
                break;
            case ".shtm":
                value = true;
                break;
            case ".text":
                value = true;
                break;
            case ".xsl":
                value = true;
                break;
            case ".xml":
                value = true;
                break;
            case ".css":
                value = true;
                break;
            case ".aspx":
                value = true;
                break;
            default:
                value = false;
                break;
        }
        return value;
    }

    /// <summary>
    /// 获取文件图标
    /// </summary>
    /// <param name="type">文件后缀名</param>
    /// <returns>返回与文件后缀名相匹配的ICO图标</returns>
    protected string GetFileIco(string type)
    {
        string ImgPath;
        switch (type.ToLower())
        {
            case ".htm":
                ImgPath = "lie_49.gif";
                break;
            case ".html":
                ImgPath = "lie_49.gif";
                break;
            case ".aspx":
                ImgPath = "aspx.gif";
                break;
            case ".cs":
                ImgPath = "c.gif";
                break;
            case ".asp":
                ImgPath = "asp.gif";
                break;
            case ".doc":
                ImgPath = "doc.gif";
                break;
            case ".exe":
                ImgPath = "exe.gif";
                break;
            case ".swf":
                ImgPath = "flash.gif";
                break;
            case ".gif":
                ImgPath = "gif.gif";
                break;
            case ".jpg":
                ImgPath = "jpg.gif";
                break;
            case ".jpeg":
                ImgPath = "jpg.gif";
                break;
            case ".js":
                ImgPath = "script.gif";
                break;
            case ".txt":
                ImgPath = "txt.gif";
                break;
            case ".xml":
                ImgPath = "xml.gif";
                break;
            case ".zip":
                ImgPath = "zip.gif";
                break;
            case ".rar":
                ImgPath = "zip.gif";
                break;
            default:
                ImgPath = "unknown.gif";
                break;
        }
        return ImgPath;
    }


    /// <summary>
    /// 修改文件夹名称
    /// </summary>
    /// <param name="path">文件夹路径</param>
    /// <returns>修改文件夹名称</returns>
    protected void EidtDirName(string path)
    {
        string OldName = Request.QueryString["OldFileName"];
        string NewName = Request.QueryString["NewFileName"];
        if (OldName == "" || OldName == null || OldName == string.Empty || NewName == "" || NewName == null || NewName == string.Empty)
            Common.MessageBox.Show(this, "参数传递错误!");

        int result = Common.FileAction.EidtName(path, OldName, NewName, 0);
        if (result == 1)
            Common.MessageBox.Show(this, "更改文件夹名成功!");
        else
            Common.MessageBox.Show(this, "参数传递错误!");
    }

    /// <summary>
    /// 修改文件名称
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <returns>修改文件名称</returns>
    protected void EidtFileName(string path)
    {
        string OldName = Request.QueryString["OldFileName"];
        string NewName = Request.QueryString["NewFileName"];

        if (OldName == "" || OldName == null || OldName == string.Empty || NewName == "" || NewName == null || NewName == string.Empty)
            Common.MessageBox.Show(this, "参数传递错误!");

        int result = Common.FileAction.EidtName(path, OldName, NewName, 1);
        if (result == 1)
            Common.MessageBox.Show(this, "更改文件名成功!");
        else
            Common.MessageBox.Show(this, "参数传递错误!");
    }

    /// <summary>
    /// 删除文件夹
    /// </summary>
    /// <param name="path">文件夹路径</param>
    /// <returns>删除文件夹</returns>
    protected void DelDir(string path)
    {
        int result = 0;
        result = Common.FileAction.DeleteFile(path, "", 0);
        if (result == 1)
            Common.MessageBox.Show(this, "删除文件夹成功!");
        else
            Common.MessageBox.Show(this, "参数错误!");
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <returns>删除文件</returns>
    protected void DelFile(string path)
    {
        string str_FileName = Request.QueryString["filename"];

        int result = 0;
        result = Common.FileAction.DeleteFile(path, str_FileName, 1);
        if (result == 1)
            Common.MessageBox.Show(this, "删除文件夹成功!");
        else
            Common.MessageBox.Show(this, "参数错误!");
    }

    /// <summary>
    /// 添加文件夹
    /// </summary>
    /// <param name="path">文件夹路径</param>
    /// <returns>添加文件夹</returns>
    protected void AddDir(string path)
    {
        string str_DirName = Request.QueryString["filename"];

        int result = 0;
        result = Common.FileAction.AddDir(path, str_DirName);
        if (result == 1)
            Common.MessageBox.Show(this, "添加文件夹成功!");
        else
            Common.MessageBox.Show(this, "未知错误!");
    }

    /// <summary>
    /// 显示导入文件,创建目录
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <returns>返回操作区域</returns>
    protected void ShowAddfiledir(string path)
    {
        string str_Addfiledir = "<ul>";
        str_Addfiledir += "<li><a href=\"javascript:AddDir('" + path + "');\">创建目录</a></li><li><a href=\"javascript:void(0);\" onclick=\"UpFile('" + path + "','templets');\">导入文件</a></li><li><a class=\"a2\" title=\"点击显示帮助\" onclick=\"Help('H_Templet_Note',this)\">关于模板使用说明</a></li>";
        str_Addfiledir += "</ul>";
        addfiledir.InnerHtml = str_Addfiledir;
    }
}

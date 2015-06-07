using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using LitJson;
using System.IO;
using System.Globalization;

namespace Foosun.PageView.controls.kindeditor.asp.net
{
    public partial class upload :Foosun.PageBasic.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //文件保存目录URL
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
                string dimmdir = Foosun.Config.UIConfig.dirDumm;
                string _Tmpdimmdir = "";
                if (dimmdir.Trim() != "") { _Tmpdimmdir = "/" + dimmdir; }
                String saveUrl = _Tmpdimmdir + "/" + localSavedir + "/";
                //定义允许上传的文件扩展名
                Hashtable extTable = new Hashtable();
                extTable.Add("image", "gif,jpg,jpeg,png,bmp");
                extTable.Add("flash", "swf,flv");
                extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
                extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

                //最大文件大小
                int maxSize = 1000000;
                HttpPostedFile imgFile = Request.Files["imgFile"];
                if (imgFile == null)
                {
                    showError("请选择文件。");
                }
                String dirPath = Server.MapPath(saveUrl);
                if (!Directory.Exists(dirPath))
                {
                    showError("上传目录不存在。");
                }

                String dirName = Request.QueryString["dir"];
                if (String.IsNullOrEmpty(dirName))
                {
                    dirName = "image";
                }
                if (!extTable.ContainsKey(dirName))
                {
                    showError("目录名不正确。");
                }

                String fileName = imgFile.FileName;
                String fileExt = Path.GetExtension(fileName).ToLower();

                if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
                {
                    showError("上传文件大小超过限制。");
                }

                if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
                {
                    showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
                }

                //创建文件夹
                dirPath += dirName + "/";
                saveUrl += dirName + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                dirPath += ymd + "/";
                saveUrl += ymd + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                String filePath = dirPath + newFileName;

                imgFile.SaveAs(filePath);

                String fileUrl = saveUrl + newFileName;

                Hashtable hash = new Hashtable();
                hash["error"] = 0;
                hash["url"] = fileUrl;
                Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                Response.Write(JsonMapper.ToJson(hash));
                Response.End(); 
            }
        }
        private void showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            Response.Write(JsonMapper.ToJson(hash));
            Response.End();
        }
    }
}
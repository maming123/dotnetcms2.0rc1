using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Data;

namespace Foosun.CMS
{
    public class UpLoad
    {
        private System.Web.HttpPostedFile postedFile = null;
        private string savePath = "";
        private string extension = "";
        private int fileLength = 0;

        /// <summary>
        /// 显示该组件使用的参数信息
        /// </summary>
        public System.Web.HttpPostedFile PostedFile
        {
            get
            {
                return postedFile;
            }
            set
            {
                postedFile = value;
            }
        }
        public string SavePath
        {
            get
            {
                if (savePath != "") return savePath;
                return "c:\\";
            }
            set
            {
                savePath = value;
            }
        }
        public int FileLength
        {
            get
            {
                if (fileLength != 0) return fileLength;
                return 1024;
            }
            set
            {
                fileLength = value * 1024;
            }
        }

        public string Extension
        {
            get
            {
                if (extension != "")
                    return extension;
                return "txt";
            }
            set
            {
                extension = value;
            }
        }

        public string Upload(int _num, int isAdmin, int size)
        {
            return Upload(_num, isAdmin, "", size);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public string Upload(int _num, int isAdmin, string fileType, int size)
        {
            if (PostedFile != null)
            {
                int getFileLent = 0;
                try
                {
                    //此处得到会员所在的会员组的上传信息
                    if (isAdmin != 1)
                    {
                        RootPublic pd = new RootPublic();
                        DataTable dt = pd.GetGroupUpInfo(Foosun.Global.Current.UserNum);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            Extension = dt.Rows[0]["upfileType"].ToString();
                            getFileLent = int.Parse(dt.Rows[0]["upfileSize"].ToString()) * 1024;
                        }
                    }
                    else { getFileLent = FileLength; }
                    string fileName = Path.GetFileName(PostedFile.FileName);
                    string upFileExt = Path.GetExtension(fileName);
                    //防止上传ttt;aspx.jpg这样的文件上传引起的执行aspx文件的bug
                    Foosun.CMS.Attachments AttachmentsCMS = new Attachments();
                    Foosun.Model.Attachments AttachmentsModel = new Model.Attachments();
                    
                    if (ImageSupportExtension(upFileExt))
                    {
                        try
                        {
                            //如果是图片，是否能实例化图片处理类
                            Image test = Image.FromStream(postedFile.InputStream);
                            AttachmentsModel.FileType = "2";
                        }
                        catch
                        {
                            return "你上传的文件类型不正确!$0";
                        }
                    }
                    else
                    {
                        AttachmentsModel.FileType = "1";
                    }

                    string lastFileName = "";
                    switch (fileType)
                    {
                        case "0":
                            lastFileName = fileName;
                            break;
                        case "1":
                            lastFileName = "副件" + fileName;
                            break;
                        case "2":
                            lastFileName = "1" + fileName;
                            break;
                        case "3":
                            lastFileName = string.Format("{0}{1}{2}{3}{4}{5}.{6}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), Extension);
                            break;
                        default:
                            lastFileName = fileName;
                            break;
                    }
                    AttachmentsModel.FileName = fileName;
                    AttachmentsModel.FileSize = PostedFile.ContentLength.ToString();
                    AttachmentsModel.FilePath = SavePath + @"\" + fileName;
                    AttachmentsModel.UploadDate = DateTime.Now;
                    AttachmentsCMS.Add(AttachmentsModel);

                    string _fileName = "";
                    string[] Exten = Extension.Split(',');
                    if (Exten.Length == 0) { return "你未设置上传文件类型,系统不允许进行下一步操作!$0"; }
                    else
                    {
                        for (int i = 0; i < Exten.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(Exten[i]) && "." + Exten[i].ToLower() == upFileExt.ToLower())
                            {
                                if (PostedFile.ContentLength > getFileLent) return "上传文件限制大小:" + getFileLent / 1024 + "kb！$0";
                                //实现水印、缩图 开始
                                string IsFileex = SavePath + @"\" + lastFileName;

                                if (!Directory.Exists(SavePath)) { Directory.CreateDirectory(SavePath); }
                                if (_num == 1)
                                {
                                    string _Randstr = Common.Rand.Number(6);
                                    string _tmps = DateTime.Now.Month + DateTime.Now.Day + "-" + _Randstr + "-" + fileName;
                                    if (fileType.Equals("7"))
                                    {
                                        _tmps = "small" + DateTime.Now.Month + DateTime.Now.Day + "-" + _Randstr + "-" + fileName;
                                    }
                                    if (File.Exists(IsFileex))
                                    {
                                        postedFile.SaveAs(SavePath + @"\" + _tmps);
                                        _fileName = _tmps;
                                        return _fileName + "$1";
                                    }
                                    else
                                    {
                                        PostedFile.SaveAs(IsFileex);
                                        _fileName = fileName;
                                        return _fileName + "$1";
                                    }
                                }
                                else
                                {
                                    PostedFile.SaveAs(IsFileex);
                                    _fileName = fileName;
                                    return _fileName + "$1";
                                }

                            }
                        }
                        return "只允许上传" + Extension + " 文件!$0";
                    }
                }
                catch (System.Exception exc)
                {
                    return exc.Message + "$0";
                }
            }
            else
            {
                return "上文件失败!$0";
            }
        }

        /// <summary>
        /// 判断扩展名是否是系统支持的图片文件扩展名。
        /// </summary>
        /// <param name="extensionName">要判断的扩展名可以包含“.”</param>
        /// <returns>系统是否支持该图片扩展名</returns>
        private bool ImageSupportExtension(string extensionName)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.FilenameExtension.ToLower().Contains(extensionName.ToLower())) return true;
            }
            return false;
        }
    }
}

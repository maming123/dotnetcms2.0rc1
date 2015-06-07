using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Common
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static string GetExtName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName.IndexOf('.') == -1)
            {
                throw new Exception("名称错误");
            }
            string ExtName = fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
            return ExtName;
        }
        /// <summary>
        /// 修改文件名(文件夹)名称
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="oldName">原始名称</param>
        /// <param name="newName">新名称</param>
        /// <param name="type">0为文件夹,1为文件</param>
        /// <returns>成功返回1</returns>
        public static int EidtName(string path, string oldName, string newName, int type)
        {
            int Result = 0;
            if (type == 0)
            {
                if (Directory.Exists(path + "\\" + oldName))
                {
                    try
                    {
                        Directory.Move(path + "\\" + oldName, path + "\\" + newName.Replace(".", ""));
                    }
                    catch (IOException e)
                    {
                        throw new Exception(e.ToString());
                    }
                    Result = 1;
                }
                else
                {
                    throw new Exception("参数传递错误!");
                }
            }
            else
            {
                if (File.Exists(path + "\\" + oldName))
                {
                    if (string.Compare(GetExtName(newName), GetExtName(oldName), true) != 0)
                    {
                        Result = 0;
                    }
                    else
                    {
                        try
                        {
                            File.Move(path + "\\" + oldName, path + "\\" + newName);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.ToString());
                        }
                        Result = 1;
                    }
                }
                else
                {
                    throw new Exception("参数传递错误!");
                }
            }
            return Result;
        } 

        /// <summary>
        /// 删除文件或文件夹
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">名称</param>
        /// <param name="type">0代表文件夹,1代表文件</param>
        /// <returns>返回值</returns>
        public static int DeleteFile(string path, string fileName, int type)
        {
            int Result = 0;
            if (type == 0)
            {
                if (Directory.Exists(path + "\\" + fileName))
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch (Exception e)
                    {
                        throw new IOException(e.ToString());
                    }
                    Result = 1;
                }
                else
                {
                    throw new IOException("参数错误!");
                }
            }
            else
            {
                if (File.Exists(path + "\\" + fileName))
                {
                    try
                    {
                        File.Delete(path + "\\" + fileName);
                    }
                    catch (Exception e)
                    {
                        throw new IOException(e.ToString());
                    }
                    Result = 1;
                }
                else
                {
                    throw new IOException("参数错误!");
                }
            }
            return Result;
        }

        /// <summary>
        /// 添加文件夹
        /// </summary>
        /// <param name="path">当前路径</param>
        /// <param name="fileName">文件夹名称</param>
        /// <returns></returns>

        public static int AddDir(string path, string fileName)
        {
            int Result = 0;
            if (Directory.Exists(path + "\\" + fileName))
            {
                throw new IOException("此文件夹已存在!");
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path + "\\" + fileName.Replace(".", ""));
                }
                catch (IOException e)
                {
                    throw new IOException(e.ToString());
                }
                Result = 1;
            }
            return Result;
        }
        /// <summary>
        /// 获取当前目录的父目录
        /// </summary>
        /// <param name="path">当前目录</param>
        /// <param name="tempPath">当前的模板目录</param>
        /// <returns></returns>

        public static string GetParentPathByPath(string path, string tempPath)
        {
            if (path != null)
            {
                int i, j;
                i = path.LastIndexOf(tempPath);
                j = path.Length - i;
                path = path.Substring(i, j);
            }
            else
            {
                path = tempPath;
            }
            return path;
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">需要写入的内容</param>
        /// /// <param name="fileModel">模式</param>
        public static void WriteFile(string filePath, string content, FileMode fileModel)
        {
            try
            {
                //创建目录
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }
                //判断文件是否存在
                //if (File.Exists(filePath))
                //{
                //    using (StreamWriter sw = File.CreateText(filePath))
                //    {
                //        TextWriter tw = TextWriter.Synchronized(sw);
                //        tw.Write(content);
                //        tw.Close();
                //    }
                //}
                //else
                //{
                    FileStream fs = File.Open(filePath, fileModel, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(true));
                    sw.Flush();
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                //}
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileContent">文件内容</param>
        /// <returns></returns>

        public static int SaveFile(string path, string fileContent)
        {
            int Result = 0;
            if (File.Exists(path))
            {
                try
                {
                    StreamWriter Fso = new StreamWriter(path);
                    Fso.WriteLine(fileContent);
                    Fso.Close();
                    Fso.Dispose();
                }
                catch (IOException e)
                {
                    throw new IOException(e.ToString());
                }
                Result = 1;
            }
            else
            {
                throw new Exception("文件已经被删除!");
            }
            return Result;
        }

        /// <summary>
        /// 显示文件内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string ShowFileContet(string path)
        {
            string ShowContent = "";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader ReadContent = new StreamReader(path);
                    ShowContent = ReadContent.ReadToEnd();
                    ReadContent.Close();
                    ReadContent.Dispose();
                }
                catch (IOException e)
                {
                    throw new IOException(e.ToString());
                }
            }
            else
            {
                throw new Exception("找不到相应的文件!");
            }
            return ShowContent;
        }

        /// <summary>
        /// 判断文件类型
        /// </summary>
        /// <param name="fileExtensions"></param>
        /// <returns></returns>
        public static string GetFileType(string fileExtensions)
        {
            string type = "";
            if (fileExtensions.IndexOf(".") > -1)
            {
                type = fileExtensions.Substring(fileExtensions.IndexOf("."));
            }
            else
            {
                return "未知文件";
            }
            string ImgPath = "";
            switch (type.ToLower())
            {
                case ".htm":
                    ImgPath = "HTML静态页面";
                    break;
                case ".html":
                    ImgPath = "HTML静态页面";
                    break;
                case ".aspx":
                    ImgPath = "aspx动态页面";
                    break;
                case ".cs":
                    ImgPath = "C#程序文件";
                    break;
                case ".asp":
                    ImgPath = "asp动态页面";
                    break;
                case ".doc":
                    ImgPath = "WORD文档";
                    break;
                case ".exe":
                    ImgPath = "可执行文件";
                    break;
                case ".swf":
                    ImgPath = "视频文件";
                    break;
                case ".gif":
                    ImgPath = "图片";
                    break;
                case ".jpg":
                    ImgPath = "图片";
                    break;
                case ".jpeg":
                    ImgPath = "图片";
                    break;
                case ".js":
                    ImgPath = "JS文件";
                    break;
                case ".txt":
                    ImgPath = "文本文件";
                    break;
                case ".xml":
                    ImgPath = "XML文件";
                    break;
                case ".zip":
                    ImgPath = "压缩包";
                    break;
                case ".rar":
                    ImgPath = "压缩包";
                    break;
                default:
                    ImgPath = "未知文件";
                    break;
            }
            return ImgPath;
        }
    }
}

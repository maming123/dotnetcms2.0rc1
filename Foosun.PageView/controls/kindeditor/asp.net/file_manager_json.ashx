﻿<%@ webhandler Language="C#" class="FileManager" %>
using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using LitJson;
using System.Collections.Generic;

public class FileManager : IHttpHandler
{
	public void ProcessRequest(HttpContext context)
	{
		String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

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
        String rootPath = _Tmpdimmdir + "/" + localSavedir + "/";
		
		//图片扩展名
		String fileTypes = "gif,jpg,jpeg,png,bmp";

		String currentPath = "";
		String currentUrl = "";
		String currentDirPath = "";
		String moveupDirPath = "";

		String dirPath = context.Server.MapPath(rootPath);
		String dirName = context.Request.QueryString["dir"];
		if (!String.IsNullOrEmpty(dirName)) {
			if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1) {
				context.Response.Write("Invalid Directory name.");
				context.Response.End();
			}
			dirPath += dirName + "/";
            rootPath += dirName + "/";
			if (!Directory.Exists(dirPath)) {
				Directory.CreateDirectory(dirPath);
			}
		}

		//根据path参数，设置各路径和URL
		String path = context.Request.QueryString["path"];
		path = String.IsNullOrEmpty(path) ? "" : path;
		if (path == "")
		{
			currentPath = dirPath;
            currentUrl = rootPath;
			currentDirPath = "";
			moveupDirPath = "";
		}
		else
		{
			currentPath = dirPath + path;
            currentUrl = rootPath + path;
			currentDirPath = path;
			moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
		}

		//排序形式，name or size or type
		String order = context.Request.QueryString["order"];
		order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

		//不允许使用..移动到上一级目录
		if (Regex.IsMatch(path, @"\.\."))
		{
			context.Response.Write("Access is not allowed.");
			context.Response.End();
		}
		//最后一个字符不是/
		if (path != "" && !path.EndsWith("/"))
		{
			context.Response.Write("Parameter is not valid.");
			context.Response.End();
		}
		//目录不存在或不是目录
		if (!Directory.Exists(currentPath))
		{
			context.Response.Write("Directory does not exist.");
			context.Response.End();
		}

		//遍历目录取得文件信息
		string[] dirList = Directory.GetDirectories(currentPath);
		string[] fileList = Directory.GetFiles(currentPath);

		switch (order)
		{
			case "size":
				Array.Sort(dirList, new NameSorter());
				Array.Sort(fileList, new SizeSorter());
				break;
			case "type":
				Array.Sort(dirList, new NameSorter());
				Array.Sort(fileList, new TypeSorter());
				break;
			case "name":
			default:
				Array.Sort(dirList, new NameSorter());
				Array.Sort(fileList, new NameSorter());
				break;
		}

		Hashtable result = new Hashtable();
		result["moveup_dir_path"] = moveupDirPath;
		result["current_dir_path"] = currentDirPath;
		result["current_url"] = currentUrl;
		result["total_count"] = dirList.Length + fileList.Length;
		List<Hashtable> dirFileList = new List<Hashtable>();
		result["file_list"] = dirFileList;
		for (int i = 0; i < dirList.Length; i++)
		{
			DirectoryInfo dir = new DirectoryInfo(dirList[i]);
			Hashtable hash = new Hashtable();
			hash["is_dir"] = true;
			hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
			hash["filesize"] = 0;
			hash["is_photo"] = false;
			hash["filetype"] = "";
			hash["filename"] = dir.Name;
			hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
			dirFileList.Add(hash);
		}
		for (int i = 0; i < fileList.Length; i++)
		{
			FileInfo file = new FileInfo(fileList[i]);
			Hashtable hash = new Hashtable();
			hash["is_dir"] = false;
			hash["has_file"] = false;
			hash["filesize"] = file.Length;
			hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
			hash["filetype"] = file.Extension.Substring(1);
			hash["filename"] = file.Name;
			hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
			dirFileList.Add(hash);
		}
		context.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
		context.Response.Write(JsonMapper.ToJson(result));
		context.Response.End();
	}

	public class NameSorter : IComparer
	{
		public int Compare(object x, object y)
		{
			if (x == null && y == null)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			FileInfo xInfo = new FileInfo(x.ToString());
			FileInfo yInfo = new FileInfo(y.ToString());

			return xInfo.FullName.CompareTo(yInfo.FullName);
		}
	}

	public class SizeSorter : IComparer
	{
		public int Compare(object x, object y)
		{
			if (x == null && y == null)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			FileInfo xInfo = new FileInfo(x.ToString());
			FileInfo yInfo = new FileInfo(y.ToString());

			return xInfo.Length.CompareTo(yInfo.Length);
		}
	}

	public class TypeSorter : IComparer
	{
		public int Compare(object x, object y)
		{
			if (x == null && y == null)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			FileInfo xInfo = new FileInfo(x.ToString());
			FileInfo yInfo = new FileInfo(y.ToString());

			return xInfo.Extension.CompareTo(yInfo.Extension);
		}
	}

	public bool IsReusable
	{
		get
		{
			return true;
		}
	}
}
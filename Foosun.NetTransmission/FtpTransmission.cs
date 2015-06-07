using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Foosun.NetTransmission
{
    public class FtpTransmission
    {
        public string Host { set; get; }
		public int Port { set; get; }
		public string UserName { set; get; }
		public string Password { set; get; }
		public string RootPath { set; get; }
		public List<string> FileQueue { set; get; }
		public Model.FtpConfig FtpConfg { set; get; }
		public bool IsConnected { set; get; }
		//public System.Web.HttpContext Context { set; get; }
		private FtpWebRequest request;
		public FtpTransmission(Model.FtpConfig ftpConfig)
			: this(ftpConfig.IP, ftpConfig.Port, ftpConfig.UserName, ftpConfig.Password)
		{
		}
		public FtpTransmission(string host, string username, string password)
			: this(host, 21, username, password)
		{
		}

		public FtpTransmission(string host, int port, string username, string password)
			: this(host, port, username, password, null, null)
		{

		}

        public FtpTransmission(string host, int port, string username, string password, List<string> fileQueue, Model.FtpConfig ftpConfig)
		{
			UriBuilder ftpUrl = new UriBuilder(host);
			this.Host = ftpUrl.Host;
			this.RootPath = ftpUrl.Path;
			if (!string.IsNullOrEmpty(this.RootPath) && this.RootPath[this.RootPath.Length - 1] == '/')
			{
				this.RootPath = this.RootPath.Substring(0, this.RootPath.Length - 1);
			}
			Port = port;
			UserName = username;
			Password = password;
			FileQueue = fileQueue;
			FtpConfg = ftpConfig;
			IsConnected = CanConnect();
		}

		public bool CanConnect()
		{
			bool result = true;
			UriBuilder uri = new UriBuilder(Uri.UriSchemeFtp, Host, Port);
			request = FtpWebRequest.Create(uri.Uri) as FtpWebRequest;
			request.UseBinary = true;
			request.Credentials = new NetworkCredential(UserName, Password);
			request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
			try
			{
				WebResponse response = request.GetResponse();
				response.GetResponseStream().Close();
				if (((FtpWebResponse)response).StatusCode == FtpStatusCode.PathnameCreated)
				{
					result = true;
				}
				else
				{
					Common.Public.savePublicLogFiles("FTP同步", "【错误描述：】\r\n" + ((FtpWebResponse)response).StatusCode.ToString(), FtpConfg.Operator);
					result = false;
				}
				response.Close();
			}
			catch (Exception ex)
			{
				Common.Public.savePublicLogFiles("FTP同步", "【错误描述：】\r\n" + ex.ToString(), FtpConfg.Operator);
				result = false;
			}
			return result;
		}

		public void UploadFile()
		{
			if (IsConnected)
			{
				lock (FileQueue)
				{
					FtpConfg.IsSynchronized = true;
					if (FileQueue.Count > 0)
					{
						Common.Public.savePublicLogFiles("FTP同步", "开始同步", FtpConfg.Operator);
						string siteRootPath = Common.ServerInfo.GetRootPath();
						FileQueue.Sort();
						while (FileQueue.Count > 0)
						{
							string remotePath = Path.GetDirectoryName(FileQueue[0]);
							remotePath = remotePath.Replace(siteRootPath, "").Replace("\\", "/");
							if (string.IsNullOrEmpty(remotePath) || remotePath[0] != '/')
							{
								remotePath = "/" + remotePath;
							}
							if (string.IsNullOrEmpty(remotePath) || remotePath[remotePath.Length - 1] != '/')
							{
								remotePath += "/";
							}
							remotePath = RootPath + remotePath;
							try
							{
								if (UploadFile(FileQueue[0], remotePath))
								{
									FileQueue.RemoveAt(0);
									Common.Public.SetFTPQueue(FileQueue);
								}
							}
							catch (Exception ex)
							{
								Common.Public.savePublicLogFiles("FTP同步", "【错误描述：】\r\n" + ex.ToString(), FtpConfg.Operator);
							}
						}
						Common.Public.savePublicLogFiles("FTP同步", "同步完成", FtpConfg.Operator);
					}
					FtpConfg.IsSynchronized = false;
				}
			}
			else
			{
				Common.Public.savePublicLogFiles("FTP同步", "【错误描述：】\r\n无法连接远程服务器", FtpConfg.Operator);
			}
		}

		/// <summary>
		/// 上传单个文件
		/// </summary>
		/// <param name="localFile"></param>
		/// <param name="remotePath"></param>
		/// <returns></returns>
		public bool UploadFile(string localFile, string remotePath)
		{
			bool result = true;
			if (!DirectoryExists(remotePath))
			{
				CreateDirectory(remotePath);
			}
			UriBuilder uri = new UriBuilder(Uri.UriSchemeFtp, Host, Port, remotePath + Path.GetFileName(localFile));
			request = FtpWebRequest.Create(uri.Uri) as FtpWebRequest;
			request.Credentials = new NetworkCredential(UserName, Password);
			request.UseBinary = true;
			request.Method = WebRequestMethods.Ftp.UploadFile;

			FileInfo fileInf = new FileInfo(localFile);
			request.ContentLength = fileInf.Length;
			int buffLength = 2048;
			byte[] buff = new byte[buffLength];
			int contentLen;
			try
			{
				using (FileStream fs = fileInf.OpenRead())
				{
					using (Stream strm = request.GetRequestStream())
					{
						contentLen = fs.Read(buff, 0, buffLength);
						while (contentLen != 0)
						{
							strm.Write(buff, 0, contentLen);
							contentLen = fs.Read(buff, 0, buffLength);
						}
						strm.Close();
					}
					fs.Close();
				}
				WebResponse response = request.GetResponse();
				response.GetResponseStream().Close();
				if (((FtpWebResponse)response).StatusCode == FtpStatusCode.ClosingData)
				{
					result = true;
				}
				else
				{
					result = false;
				}
				response.Close();
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		/// <summary>
		/// 判断目录是否存在
		/// </summary>
		/// <param name="remotePath"></param>
		/// <returns></returns>
		public bool DirectoryExists(string remotePath)
		{
			bool result = true;
			UriBuilder uri = new UriBuilder(Uri.UriSchemeFtp, Host, Port, remotePath);
			request = FtpWebRequest.Create(uri.Uri) as FtpWebRequest;
			request.UseBinary = true;
			request.Credentials = new NetworkCredential(UserName, Password);
			request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
			try
			{
				WebResponse response = request.GetResponse();
				response.GetResponseStream().Close();
				if (((FtpWebResponse)response).StatusCode == FtpStatusCode.ClosingData)
				{
					result = true;
				}
				else
				{
					result = false;
				}
				response.Close();
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		/// <summary>
		/// 创建目录
		/// </summary>
		/// <param name="remotePath"></param>
		/// <returns></returns>
		public bool CreateDirectory(string remotePath)
		{
			bool result = true;
			UriBuilder uri = new UriBuilder(Uri.UriSchemeFtp, Host, Port, remotePath);
			string currentPath = "";
			string[] segments = uri.Uri.Segments;
			for (int c = 0; c < segments.Length; c++)
			{
				currentPath += segments[c];
				if (currentPath == "/")
				{
					continue;
				}
				uri.Path = currentPath;
				if (!DirectoryExists(currentPath))
				{
					request = FtpWebRequest.Create(uri.Uri) as FtpWebRequest;
					request.Credentials = new NetworkCredential(UserName, Password);
					request.Method = WebRequestMethods.Ftp.MakeDirectory;
					WebResponse response = request.GetResponse();
					response.GetResponseStream().Close();
					if (((FtpWebResponse)response).StatusCode == FtpStatusCode.PathnameCreated)
					{
						result = false;
						break;
					}
					response.Close();
				}
			}
			return result;
		}
    }
}

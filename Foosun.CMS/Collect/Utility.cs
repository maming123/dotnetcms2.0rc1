using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Foosun.CMS.Collect {
	public class Utility {
		/// <summary>
		/// 取得网页的内容
		/// </summary>
		/// <param name="sUrl">url地址</param>
		/// <param name="sEncode">编码名称</param>
		/// <param name="sDocument">返回的网页内容或者是异常</param>
		/// <returns>有异常返回false</returns>
		public static string GetPageContent(Uri Url, string sEncode) {
			try {

				Encoding encoding = System.Text.Encoding.GetEncoding(sEncode);
				return GetPageContent(Url, encoding);
			}
			catch (WebException ex) {
				throw ex;
			}
			catch (Exception ex) {
				throw ex;
			}
		}
		/// <summary>
		/// 取得网页的内容
		/// </summary>
		/// <param name="sUrl">url地址</param>
		/// <param name="encoding">编码方式</param>
		/// <param name="sDocument">返回的网页内容或者是异常</param>
		/// <returns>有异常返回false</returns>
		public static string GetPageContent(Uri Url, Encoding encoding) {
			WebClient webclient = new WebClient();
			try {

				webclient.Encoding = encoding;
				return webclient.DownloadString(Url);
			}
			catch (WebException ex) {
				throw ex;
			}
			catch (Exception ex) {
				throw ex;
			}
			finally {
				webclient.Dispose();
			}
		}

		/// <summary>
		/// 处理URL地址
		/// </summary>
		/// <param name="BaseUrl">基础URL</param>
		/// <param name="BranchUrl">分支URL</param>
		/// <returns>当BranchUrl为一个绝对的URL时则返回本身，否则返回分支URL相对于基础URL的绝对URL</returns>
		public static string StickUrl(string baseUrl, string branchUrl) {
			Uri oldUrl = new Uri(baseUrl);
			Uri newUrl = new Uri(oldUrl, branchUrl);
			return newUrl.AbsoluteUri;
		}

		/// <summary>
		/// 获取一个目标的匹配结果
		/// </summary>
		/// <param name="input">要匹配的字符串</param>
		/// <param name="pattern"></param>
		/// <param name="find"></param>
		/// <returns></returns>
		public static Match GetMatch(string input, string pattern, string find) {
			string _pattn = Regex.Escape(pattern);
			_pattn = _pattn.Replace(@"\[变量]", @"[\s\S]*?");
			_pattn = Regex.Replace(_pattn, @"((\\r\\n)|(\\ ))+", @"\s*", RegexOptions.Compiled);
			if (Regex.Match(pattern.TrimEnd(), Regex.Escape(find) + "$", RegexOptions.Compiled).Success)
				_pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[\s\S]+)");
			else
				_pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[\s\S]+?)");
			Regex r = new Regex(_pattn, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			Match m = r.Match(input);
			return m;
		}
		/// <summary>
		/// 按严格的匹配方式获取一个目标的匹配结果
		/// </summary>
		/// <param name="input"></param>
		/// <param name="pattern"></param>
		/// <param name="find"></param>
		/// <returns></returns>
		public static Match GetMatchRigid(string input, string pattern, string find) {
			string _pattn = Regex.Escape(pattern);
			_pattn = _pattn.Replace(@"\[变量]", @"[\s\S]*?");
			if (Regex.Match(pattern.TrimEnd(), Regex.Escape(find) + "$", RegexOptions.Compiled).Success)
				_pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[\s\S]+)");
			else
				_pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[\s\S]+?)");
			Regex r = new Regex(_pattn, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			Match m = r.Match(input);
			return m;
		}
		/// <summary>
		/// 匹配超级链接地址
		/// </summary>
		/// <param name="input"></param>
		/// <param name="pattern"></param>
		/// <param name="find"></param>
		/// <returns></returns>
		public static Match GetMatchUrl(string input, string pattern, string find) {
			string _pattn = Regex.Escape(pattern);
			_pattn = _pattn.Replace(@"\[变量]", @"[\s\S]*?");
			if (Regex.Match(pattern.TrimEnd(), Regex.Escape(find) + "$", RegexOptions.Compiled).Success)
				_pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[^'""\ >]+)");
			else
				_pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[^'""\ >]+?)");
			Regex r = new Regex(_pattn, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			Match m = r.Match(input);
			return m;
		}
	}
	/*
   // The RequestState class passes data across async calls.
   public class RequestState
   {
	   const int BufferSize = 1024;
	   public StringBuilder RequestData;
	   public byte[] BufferRead;
	   public WebRequest Request;
	   public Stream ResponseStream;
	   // Create Decoder for appropriate enconding type.
	   public Decoder StreamDecode = Encoding.UTF8.GetDecoder();

	   public RequestState()
	   {
		   BufferRead = new byte[BufferSize];
		   RequestData = new StringBuilder(String.Empty);
		   Request = null;
		   ResponseStream = null;
	   }
   }

   // ClientGetAsync issues the async request.
   class ClientGetAsync
   {
	   public static ManualResetEvent allDone = new ManualResetEvent(false);
	   const int BUFFER_SIZE = 1024;
	   public static void BeginReq(string[] HttpURL)
	   {
		   foreach (string singleurl in HttpURL)
		   {
			   try
			   {
				   Uri httpSite = new Uri(singleurl);
				   HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(httpSite);
				   RequestState rs = new RequestState();
				   rs.Request = wreq;
				   IAsyncResult r = (IAsyncResult)wreq.BeginGetResponse(new AsyncCallback(RespCallback), rs);
				   allDone.WaitOne();
				   wreq.EndGetResponse(r);
			   }
			   catch (WebException e)
			   { }
			   catch (Exception e)
			   { }
		   }
	   }
	   private static void RespCallback(IAsyncResult ar)
	   {
		   RequestState rs = (RequestState)ar.AsyncState;
		   WebRequest req = rs.Request;
		   WebResponse resp = req.EndGetResponse(ar);
		   Stream ResponseStream = resp.GetResponseStream();
		   rs.ResponseStream = ResponseStream;
		   IAsyncResult iarRead = ResponseStream.BeginRead(rs.BufferRead, 0,
			  BUFFER_SIZE, new AsyncCallback(ReadCallBack), rs);
	   }


	   private static void ReadCallBack(IAsyncResult asyncResult)
	   {
		   RequestState rs = (RequestState)asyncResult.AsyncState;
		   Stream responseStream = rs.ResponseStream;
		   int read = responseStream.EndRead(asyncResult);
		   if (read > 0)
		   {
			   Char[] charBuffer = new Char[BUFFER_SIZE];
			   int len =
				  rs.StreamDecode.GetChars(rs.BufferRead, 0, read, charBuffer, 0);
			   String str = new String(charBuffer, 0, len);
			   rs.RequestData.Append(
				  Encoding.ASCII.GetString(rs.BufferRead, 0, read));
			   IAsyncResult ar = responseStream.BeginRead(
				  rs.BufferRead, 0, BUFFER_SIZE,
				  new AsyncCallback(ReadCallBack), rs);
		   }
		   else
		   {
			   if (rs.RequestData.Length > 0)
			   {
				   string strContent;
				   strContent = rs.RequestData.ToString();
			   }
			   responseStream.Close();
			   allDone.Set();
		   }
		   return;
	   }
   }*/

}

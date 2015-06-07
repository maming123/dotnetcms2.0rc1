using System;
using System.Text.RegularExpressions;

namespace Foosun.CMS.Collect {
	public class Page {
		protected string _Url = "";
		protected string _Encode = "utf-8";
		protected string _Doc = "";
		protected string _Error = "";
		protected string baseUrl = "";
		public Page(string url) {
			_Url = url;
			baseUrl = url;
		}
		public Page(string url, string encode) {
			_Url = url;
			baseUrl = url;
			_Encode = encode;
		}
		public bool Fetch() {
			bool flag = false;
			try {
				Uri url = new Uri(_Url);
				_Doc = Utility.GetPageContent(url, _Encode);
				Match baseUrlMatch = Regex.Match(_Doc, "\\<base .*href=\"(.*)\".*>", RegexOptions.Compiled);
				if (baseUrlMatch.Success) {
					baseUrl = baseUrlMatch.Groups[1].Value;
				}
				else {
					baseUrl = _Url;
				}
				flag = true;
			}
			catch (UriFormatException e) {
				_Error = e.ToString();
			}
			catch (System.Net.WebException e) {
				_Error = e.ToString();
			}
			catch (Exception e) {
				_Error = e.ToString();
			}
			return flag;
		}
		public string LastError {
			get { return _Error; }
		}
	}
}

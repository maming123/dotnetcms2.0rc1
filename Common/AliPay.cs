using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
namespace Common {
	/// <summary>
	/// 支付宝接口类
	/// </summary>
	public class AliPay {
		public Dictionary<string, string> Config { set; get; }
		private Dictionary<string, string> sPara = new Dictionary<string, string>();
		public string PayGetWay { set; get; }
		public string NotifyGetWay { set; get; }
		public string LogFilePath { get; set; }
		public AliPay()
			: this("") {
		}
		public AliPay(string hosturl) {
			#region 基本配置信息
			Config = new Dictionary<string, string>();
			Config["partner"] = "2088302492797137";
			Config["key"] = "ub1y7vomann13oy3rfpir7wfrplwrp6y";
			Config["seller_email"] = "admin@foosun.net";
			Config["return_url"] = hosturl + "/user/info/AlipayNotify.aspx";
			Config["notify_url"] = hosturl + "/user/info/AlipayNotify.aspx";
			Config["show_url"] = hosturl + "/user/info/history.aspx?type=2";
			Config["mainname"] = "四川风讯科技发展有限公司";
			#endregion

			#region 调试时可修改
			Config["_input_charset"] = "utf-8";
			Config["sign_type"] = "MD5";
			//服务器请求通知接口的协议类型
			Config["transport"] = "https";
			#endregion

			#region 接口参数
			PayGetWay = "https://www.alipay.com/cooperate/gateway.do";
			NotifyGetWay = "http://notify.alipay.com/trade/notify_query.do";
			#endregion
		}

		#region 通知检查
		public bool Notify(SortedDictionary<string, string> request) {
			if (Config["transport"] == "https") {
				NotifyGetWay = PayGetWay;
			}
			sPara = Para_filter(request);
			string preSignStr = DicToQueryString(sPara);
			string mysign = Build_mysign(sPara, Config["key"], Config["sign_type"], Config["_input_charset"]);
			string responseTxt = Verify(sPara["notify_id"]);
			string sWord = "responseTxt=" + responseTxt + "\n notify_url_log:sign=" + request["sign"] + "&mysign=" + mysign + "\n notify回来的参数：" + preSignStr;
			if (request["sign"] == mysign && responseTxt == "true") {
				return true;
			}
			else {
				log_result(LogFilePath, sWord);
				return false;
			}
		}

		/// <summary>
		/// 验证是否是支付宝服务器发来的请求
		/// </summary>
		/// <returns>验证结果</returns>
		private string Verify(string notify_id) {
			UriBuilder veryfy = new UriBuilder(NotifyGetWay);
			string query = "";
			if (Config["transport"] == "https") {
				query = "service=notify_verify&";
			}
			veryfy.Query = query + "partner=" + Config["partner"] + "&notify_id=" + notify_id;
			return Get_Http(veryfy.Uri.ToString(), 120000);
		}

		/// <summary>
		/// 获取远程服务器ATN结果
		/// </summary>
		/// <param name="strUrl">指定URL路径地址</param>
		/// <param name="timeout">超时时间设置</param>
		/// <returns>服务器ATN结果</returns>
		private string Get_Http(string strUrl, int timeout) {
			string strResult;
			try {
				HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
				myReq.Timeout = timeout;
				HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
				Stream myStream = HttpWResp.GetResponseStream();
				StreamReader sr = new StreamReader(myStream, Encoding.Default);
				StringBuilder strBuilder = new StringBuilder();
				while (-1 != sr.Peek()) {
					strBuilder.Append(sr.ReadLine());
				}

				strResult = strBuilder.ToString();
			}
			catch (Exception exp) {
				strResult = "错误：" + exp.Message;
			}

			return strResult;
		}

		#endregion

		#region 请求服务
		/// <summary>
		/// 构建表单提交HTML
		/// </summary>
		/// <param name="sendType">表单提交方式（GET与POST二必选一）</param>
		/// <returns>输出 表单提交HTML文本</returns>
		public string Build_Form(string sendType) {
			StringBuilder sbHtml = new StringBuilder();
			sendType = sendType.ToLower();
			if (sendType != "post") {
				sendType = "get";
			}

			sbHtml.Append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"" + PayGetWay + "_input_charset=" + Config["_input_charset"] + "\" method=\"" + sendType.ToLower() + "\">");

			foreach (KeyValuePair<string, string> temp in sPara) {
				sbHtml.Append("<input type=\"hidden\" name=\"" + temp.Key + "\" value=\"" + temp.Value + "\"/>");
			}

			sbHtml.Append("<input type=\"hidden\" name=\"sign\" value=\"" + sPara["sign"] + "\"/>");
			sbHtml.Append("<input type=\"hidden\" name=\"sign_type\" value=\"" + sPara["sign_type"] + "\"/>");

			//submit按钮控件请不要含有name属性
			sbHtml.Append("<input type=\"submit\" value=\"支付宝确认付款\"></form>");
			sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");
			return sbHtml.ToString();
		}

		/// <summary>
		/// 构建直接请求接口的URL（不推荐）
		/// </summary>
		/// <returns>请求接口的URL（包含所有参数）</returns>
		public string Build_GetUrl() {
			UriBuilder urlBuilder = new UriBuilder(PayGetWay);
			urlBuilder.Query = DicToQueryString(sPara);
			return urlBuilder.Uri.ToString();
		}

		/// <summary>
		/// 构建即时到帐接口参数
		/// </summary>
		/// <param name="out_trade_no">订单号</param>
		/// <param name="subject">标题</param>
		/// <param name="body">说明</param>
		/// <param name="total_fee">金额</param>
		public void CreateDirectPayByUser(string out_trade_no, string subject, string body, string total_fee) {
			var para = GetConfig();
			para.Add("service", "create_direct_pay_by_user");
			para.Add("payment_type", "1");
			para.Add("out_trade_no", out_trade_no);
			para.Add("subject", subject);
			para.Add("body", body);
			para.Add("total_fee", total_fee);
			//param.Add("paymethod", paymethod);
			//param.Add("defaultbank", defaultbank);
			//param.Add("anti_phishing_key", anti_phishing_key);
			//param.Add("exter_invoke_ip", exter_invoke_ip);
			//param.Add("extra_common_param", extra_common_param);
			//param.Add("buyer_email", buyer_email);
			//param.Add("royalty_type", royalty_type);
			//param.Add("royalty_parameters", royalty_parameters);
			sPara = Para_filter(para);
			sPara.Add("sign", Build_mysign(sPara, para["key"], para["sign_type"], para["_input_charset"]));
			sPara.Add("sign_type", Config["sign_type"]);
		}

		/// <summary>
		/// 构建担保交易接口参数
		/// </summary>
		/// <param name="out_trade_no">订单号</param>
		/// <param name="subject">标题</param>
		/// <param name="body">说明</param>
		/// <param name="price">金额</param>
		public void CreatePartnerTradeByBuyer(string out_trade_no, string subject, string body, string price) {
			var para = GetConfig();
			para.Add("service", "create_partner_trade_by_buyer");
			para.Add("payment_type", "1");
			para.Add("out_trade_no", out_trade_no);
			para.Add("subject", subject);
			para.Add("body", body);
			para.Add("price", price);
			sPara = Para_filter(para);
			sPara.Add("sign", Build_mysign(sPara, para["key"], para["sign_type"], para["_input_charset"]));
			sPara.Add("sign_type", Config["sign_type"]);
		}

		/// <summary>
		/// 构建双功能接口参数
		/// </summary>
		/// <param name="out_trade_no">订单号</param>
		/// <param name="subject">标题</param>
		/// <param name="body">说明</param>
		/// <param name="price">金额</param>
		public void TradeCreateByBuyer(string out_trade_no, string subject, string body, string price) {
			var para = GetConfig();
			para.Add("service", "trade_create_by_buyer");
			para.Add("payment_type", "1");
			para.Add("out_trade_no", out_trade_no);
			para.Add("subject", subject);
			para.Add("body", body);
			para.Add("price", price);
			sPara = Para_filter(para);
			sPara.Add("sign", Build_mysign(sPara, para["key"], para["sign_type"], para["_input_charset"]));
			sPara.Add("sign_type", Config["sign_type"]);
		}
		#endregion

		#region 公共方法
		/// <summary>
		/// 构建请求的排序集合
		/// </summary>
		/// <param name="request">请求</param>
		/// <returns>已排序的集合</returns>
		public SortedDictionary<string, string> RequestToDic(NameValueCollection request) {
			SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
			String[] requestItem = request.AllKeys;
			for (int i = 0; i < requestItem.Length; i++) {
				sArray.Add(requestItem[i], request[requestItem[i]]);
			}
			return sArray;
		}

		/// <summary>
		/// 对配置集合进行排序
		/// </summary>
		/// <returns>排序后的配置集合</returns>
		public SortedDictionary<string, string> GetConfig() {
			SortedDictionary<string, string> param = new SortedDictionary<string, string>();
			foreach (var item in Config) {
				param.Add(item.Key, item.Value);
			}
			return param;
		}

		/// <summary>
		/// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
		/// </summary>
		/// <param name="dicArray">需要拼接的数组</param>
		/// <returns>拼接完成以后的字符串</returns>
		public string DicToQueryString(Dictionary<string, string> dicArray) {
			StringBuilder queryBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> temp in dicArray) {
				queryBuilder.Append(temp.Key + "=" + temp.Value + "&");
			}
			string queryString = queryBuilder.ToString();
			return queryString.Substring(0, queryString.Length - 1);
		}

		/// <summary>
		/// 除去数组中的空值和签名参数
		/// </summary>
		/// <param name="dicArrayPre">过滤前的参数组</param>
		/// <returns>过滤后的参数组</returns>
		public Dictionary<string, string> Para_filter(SortedDictionary<string, string> dicArrayPre) {
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> temp in dicArrayPre) {
				if (temp.Key.ToLower() != "sign"
					&& temp.Key.ToLower() != "key"
					&& temp.Key.ToLower() != "sign_type"
					&& temp.Key.ToLower() != "transport"
					&& !string.IsNullOrEmpty(temp.Value)) {
					dicArray.Add(temp.Key.ToLower(), temp.Value);
				}
			}
			return dicArray;
		}

		/// <summary>
		/// 生成签名结果
		/// </summary>
		/// <param name="sArray">要签名的数组</param>
		/// <param name="key">安全校验码</param>
		/// <param name="sign_type">签名类型</param>
		/// <param name="_input_charset">编码格式</param>
		/// <returns>签名结果字符串</returns>
		public string Build_mysign(Dictionary<string, string> dicArray, string key, string sign_type, string _input_charset) {
			string prestr = DicToQueryString(dicArray);  //把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
			prestr = prestr + key;                      //把拼接后的字符串再与安全校验码直接连接起来
			string mysign = Sign(prestr, sign_type, _input_charset);	//把最终的字符串签名，获得签名结果
			return mysign;
		}

		/// <summary>
		/// 签名字符串
		/// </summary>
		/// <param name="prestr">需要签名的字符串</param>
		/// <param name="sign_type">签名类型</param>
		/// <param name="_input_charset">编码格式</param>
		/// <returns>签名结果</returns>
		public static string Sign(string prestr, string sign_type, string _input_charset) {
			StringBuilder sb = new StringBuilder(32);
			if (sign_type.ToUpper() == "MD5") {
				MD5 md5 = new MD5CryptoServiceProvider();
				byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
				for (int i = 0; i < t.Length; i++) {
					sb.Append(t[i].ToString("x").PadLeft(2, '0'));
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// 写日志，方便测试（看网站需求，也可以改成把记录存入数据库）
		/// </summary>
		/// <param name="sPath">日志的本地绝对路径</param>
		/// <param name="sWord">要写入日志里的文本内容</param>
		public void log_result(string sPath, string sWord) {
			StreamWriter fs = new StreamWriter(sPath, false, System.Text.Encoding.Default);
			fs.Write(sWord);
			fs.Close();
		}

		/// <summary>
		/// 用于防钓鱼，调用接口query_timestamp来获取时间戳的处理函数
		/// 注意：远程解析XML出错，与IIS服务器配置有关
		/// </summary>
		/// <returns>时间戳字符串</returns>
		public string Query_timestamp() {
			string url = "https://mapi.alipay.com/gateway.do?service=query_timestamp&partner=" + Config["partner"];
			string encrypt_key = "";

			XmlTextReader Reader = new XmlTextReader(url);
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Reader);

			encrypt_key = xmlDoc.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;

			return encrypt_key;
		}
		#endregion
	}
}

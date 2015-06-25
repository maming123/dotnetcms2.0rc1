using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web.Caching;
using System.Data.SqlClient;
using DMedia.FetionActivity.Data.DataAccess;
using System.Data;
using System.Text.RegularExpressions;
using DMedia.FetionActivity.Data;
using System.IO;

namespace DMedia.FetionActivity.Module.Utils
{
    public abstract class BaseCommon
    {
        private static object lockObject = new object();


        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration">过期时间</param>
        public static void CacheInsert(string key, object value, DateTime absoluteExpiration)
        {
            if (value != null)
            {
                HttpRuntime.Cache.Insert(key, value, null, absoluteExpiration, Cache.NoSlidingExpiration);
            }
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpiration">相对过期时间间隔</param>
        public static void CacheInsert(string key, object value, TimeSpan slidingExpiration)
        {
            if (value != null)
            {
                HttpRuntime.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, slidingExpiration);
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        public static T GetCache<T>(string key)
        {
            if (HasCache(key))
            {
                return (T)HttpRuntime.Cache[key];
            }

            return default(T);
        }

        /// <summary>
        /// 缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool HasCache(string key)
        {
            return HttpRuntime.Cache[key] != null;
        }

        /// <summary>
        /// 缓存移除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void CacheRemove(string key)
        {
            if (HttpRuntime.Cache[key] != null)
                HttpRuntime.Cache.Remove(key);
        }

        /// <summary>
        /// 对象序列化成json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            return obj == null ? "" : JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// json反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            T t = JsonConvert.DeserializeObject<T>(json);

            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="anonymousTypeObject"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType<T>(json, anonymousTypeObject);

            return t;
        }

        /// <summary>
        /// datatable to JSON
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtName"></param>
        /// <returns></returns>
        public static string DataTableToJSON(DataTable dt, string dtName)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                JsonSerializer ser = new JsonSerializer();
                jw.WriteStartObject();
                jw.WritePropertyName(dtName);
                jw.WriteStartArray();
                foreach (DataRow dr in dt.Rows)
                {
                    jw.WriteStartObject();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        jw.WritePropertyName(dc.ColumnName);
                        ser.Serialize(jw, dr[dc].ToString());
                    }

                    jw.WriteEndObject();
                }
                jw.WriteEndArray();
                jw.WriteEndObject();

                sw.Close();
                jw.Close();

            }

            return sb.ToString();
        }

        /// <summary>
        /// JsonEncode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string JsonEncode(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            value = value.Replace("\\", "\\\\");
            value = value.Replace("\"", "\\\"");

            return value;
        }



        /// <summary>
        /// 截取字符串(如超过字符串长度则显示省略号)
        /// </summary>
        /// <param name="str">字符信息</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string CutString(string str, int len)
        {
            return CutString(str, len, true);
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符信息</param>
        /// <param name="len">长度</param>
        /// <param name="isContainDots">是否包含省略号</param>
        /// <returns></returns>
        public static string CutString(string str, int len, bool isContainDots)
        {
            string dots = isContainDots ? "..." : "";
            if (string.IsNullOrEmpty(str))
                return str;
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }

            int increaseLength = 0;
            string str_cut = "";

            for (var i = 0; i < str.Length; i++)
            {
                string c = str.ToCharArray()[i].ToString();
                byte[] a = Encoding.ASCII.GetBytes(c);
                increaseLength++;

                if ((int)a[0] == 63)
                {
                    increaseLength++;
                }

                if (increaseLength == len)
                {
                    str_cut = str_cut + c;
                    if (str.Length > str_cut.Length)
                    {
                        str_cut = str_cut + dots;
                    }
                    return str_cut;
                }
                else if (increaseLength < len)
                {
                    str_cut = str_cut + c;
                }
                else
                {
                    str_cut = str_cut + dots;
                    return str_cut;
                }

            }
            return str_cut;
        }

        /// <summary>
        /// 求字符串长度
        /// </summary>
        /// <param name="str">字符串内空</param>
        /// <returns></returns>
        public static int StringLength(string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int increaseLength = 0;

            for (var i = 0; i < str.Length; i++)
            {
                string c = str.ToCharArray()[i].ToString();
                byte[] a = Encoding.ASCII.GetBytes(c);
                increaseLength++;
                if ((int)a[0] == 63)
                {
                    increaseLength++;
                }
            }

            return increaseLength;
        }

        /// <summary>
        /// 清除Html标识
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HtmlClear(string value)
        {
            Regex objRegExp = new Regex("<(.|\n)+?>");
            string strOutput = objRegExp.Replace(value, "");
            strOutput = strOutput.Replace("<", "&lt;");
            strOutput = strOutput.Replace(">", "&gt;");

            Regex r = new Regex(@"\s+");
            strOutput = r.Replace(strOutput, " ");
            strOutput.Trim();

            return strOutput;
        }

        /// <summary>
        /// 长时间格式转换成时间
        /// </summary>
        /// <param name="dateString">yyyyMMddHHmmss||yyyyMMddHHmm||yyyyMMdd</param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string dateString)
        {
            if (dateString == null)
            {
                throw new ArgumentNullException("dateString");
            }

            if (dateString.Length != 14
                && dateString.Length != 12
                && dateString.Length != 8)
            {
                throw new ArgumentOutOfRangeException("dateString");
            }

            if (dateString.Length == 14)
            {
                //yyyyMMddHHmmss
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < dateString.Length; i++)
                {
                    sb.Append(dateString[i]);
                    if (i == 3 || i == 5)
                    {
                        sb.Append("-");
                    }

                    if (i == 7)
                    {
                        sb.Append(" ");
                    }

                    if (i == 9 || i == 11)
                    {
                        sb.Append(":");
                    }
                }

                dateString = sb.ToString();
            }
            else if (dateString.Length == 12)
            {
                dateString = String.Format(
                    "{0}-{1}-{2} {3}:{4}:00",
                    dateString.Substring(0, 4),
                    dateString.Substring(4, 2),
                    dateString.Substring(6, 2),
                    dateString.Substring(8, 2),
                    dateString.Substring(10)
                    );
            }
            else
            {
                dateString = String.Format(
                    "{0}-{1}-{2}",
                    dateString.Substring(0, 4),
                    dateString.Substring(4, 2),
                    dateString.Substring(6, 2)
                    );
            }

            return Convert.ToDateTime(dateString);

        }

        /// <summary>
        /// 获取当前web用户的IP
        /// </summary>
        /// <returns></returns>
        public static string GetUserIP()
        {
            try
            {
                string ip = HttpContext.Current.Request.UserHostAddress;
                return ip;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取当前web请求地址
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetUrlQuery(string key)
        {
            try
            {
                string value = HttpContext.Current.Request[key];

                return value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 是否被刷新锁定，防止频繁重复提交
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="seconds"></param>
        /// <param name="type">分类</param>
        /// <returns></returns>
        public static bool IsUserFrequencyLock(long mobile, int seconds, string type)
        {
            string cacheKey = String.Format("CommonUserSyncLock_{0}_{1}_{2}", mobile, seconds, type);

            if (HasCache(cacheKey))
            {
                return true;
            }

            CacheInsert(cacheKey, 1, DateTime.Now.AddSeconds(seconds));
            return false;
        }

        /// <summary>
        /// 返回指定查询的结果
        /// </summary>
        /// <param name="sql">输入的sql语句</param>
        /// <param name="OPS">参数</param>
        /// <param name="connStr"> </param>
        /// <returns>返回的结果</returns>
        public static object GetObjectByPro(string sql, SqlParameter[] OPS, string connStr)
        {
            return SqlHelper.GetDataByPro(sql, OPS, connStr).Rows[0][0];
        }


        /// <summary>
        /// 客户端提示框
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="page">当前页Page对象</param>
        /// <param name="clientkey">客户端注册ID</param>
        public static void Show(string message, System.Web.UI.Page page, string clientkey)
        {
            string clientscript = "<script>";
            clientscript += "alert(\"" + message + "\");";
            clientscript += "</script>";
            page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), clientkey, clientscript);
        }

        /// <summary>
        /// 字符串 转换 整型 
        /// 转换失败返回 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ConvertInt32(string str)
        {
            int t = 0;
            try
            {
                t = Convert.ToInt32(str);
            }
            catch
            {
                t = 0;
            }
            return t;
        }



        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="encrypt">需要加密字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        private static string DesEncrypt(string encrypt, string sKey)
        {
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                memoryStream = new MemoryStream();
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                //建立加密对象的密钥和偏移量
                des.Key = Encoding.UTF8.GetBytes(sKey);
                des.IV = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

                //把字符串放到byte数组中
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encrypt);
                cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();

                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch
            {
                return "";
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Close();
                }

                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                }
            }

            //return "";
        }

        /// <summary>
        /// 跳转到指定页面（带参数）
        /// </summary>
        /// <param name="toUrl"></param>
        public static void RedirectToPage(string toUrl)
        {
            string pams = System.Web.HttpContext.Current.Request.QueryString.ToString();
            pams = string.IsNullOrEmpty(pams) ? "" : "?" + pams;
            toUrl = toUrl + pams;
            //System.Web.HttpContext.Current.Server.Transfer(toUrl, true);
            System.Web.HttpContext.Current.Response.Redirect(toUrl, true);
        }

        /// <summary>
        /// 跳转到手机小页面
        /// </summary>
        /// <param name="toUrl"></param>
        public static void RedirectToMobilePage(string toUrl)
        {
            if (IsFromMobile())
            {
                string pams = System.Web.HttpContext.Current.Request.QueryString.ToString();
                pams = string.IsNullOrEmpty(pams) ? "" : "?" + pams;
                toUrl = toUrl + pams;
                //System.Web.HttpContext.Current.Server.Transfer(toUrl, true);
                System.Web.HttpContext.Current.Response.Redirect(toUrl, true);
            }
        }

        /// <summary>
        /// 跳转到活动Web首页面
        /// </summary>
        /// <param name="toUrl"></param>
        public static void RedirectToWebPage(string toUrl)
        {
            if (!IsFromMobile())
            {
                string pams = System.Web.HttpContext.Current.Request.QueryString.ToString();
                pams = string.IsNullOrEmpty(pams) ? "" : "?" + pams;
                toUrl = toUrl + pams;
                //System.Web.HttpContext.Current.Server.Transfer(toUrl, true);
                System.Web.HttpContext.Current.Response.Redirect(toUrl, true);
            }
        }

        /// <summary>
        /// 判断访问页面的来源。页面来自手机:true  来自其他浏览器：false
        /// </summary>
        /// <returns></returns>
        public static bool IsFromMobile()
        {
            string userAgent = System.Web.HttpContext.Current.Request.UserAgent;
            if (!string.IsNullOrEmpty(userAgent))
            {
                if (userAgent.IndexOf("Windows Phone OS", StringComparison.CurrentCultureIgnoreCase) > -1
                    || userAgent.IndexOf("iPhone", StringComparison.CurrentCultureIgnoreCase) > -1
                    || userAgent.IndexOf("Android", StringComparison.CurrentCultureIgnoreCase) > -1
                    || userAgent.IndexOf("UC", StringComparison.CurrentCultureIgnoreCase) > -1
                    /*||true*/
                    )
                {
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// 记录用户UserAgent
        /// </summary>
        /// <param name="mobile"></param>
        public static void RecordUserAgent(long mobile)
        {
            //注释 by maming 20141128
            //            string userAgent = "";
            //            try
            //            {
            //                userAgent = System.Web.HttpContext.Current.Request.UserAgent;
            //                string sql = @"INSERT INTO [Common_LogForUserAgent]
            //                       ([Mobile],[UserAgent],[CreateDateTime])
            //                 VALUES
            //                       (@mobile, @UserAgent,GETDATE())";
            //                if (!string.IsNullOrEmpty(userAgent))
            //                {
            //                    SqlParameter[] paras = new SqlParameter[]
            //                        {
            //                            new SqlParameter("@mobile",mobile),
            //                            new SqlParameter("@UserAgent",userAgent)
            //                        };
            //                    SqlHelper.ExecuteSql(sql, paras, ConnectionStrings.FetionActXunBao);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                BaseCommon.CommonLogger.Info(ex, userAgent);
            //            }
        }

        /// <summary>
        /// MD5 混淆加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string MD5(string input, string key)
        {
            //key = 'bab8af935901d5b86ccb1d27c4985c32'; 
            //Tokentoken=MD5+key MD5 32key 
            //Md5(13822332274+bab8af935901d5b86ccb1d27c4985c32)  加密后字符串为 ff5f2db01bada64fdf619139518f6d87
            //string key = "bab8af935901d5b86ccb1d27c4985c32";

            byte[] result = Encoding.UTF8.GetBytes(input + "+" + key);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string r = BitConverter.ToString(output).Replace("-", "").ToLower();
            return r;
        }

        /// <summary>
        /// MD5 混淆
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] inBytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] outBytes = md5.ComputeHash(inBytes);
            string outString = "";
            for (int i = 0; i < outBytes.Length; i++)
            {
                outString += outBytes[i].ToString("x2");
            }
            return outString;
        }

        /// <summary>
        /// 随机获取字典中的Value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static T GetRandomValue<T>(Dictionary<int, T> dic)
        {
            if (dic == null || dic.Count == 0)
            {
                return default(T);
            }
            int random = (new Random()).Next(1, dic.Count + 1);
            return dic[random];
        }


    }
}
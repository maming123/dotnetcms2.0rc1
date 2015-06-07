using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;
//using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace Common
{
    public class Computer
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        //MD5加密
        public static string MD5(string code)
        {
            byte[] result = Encoding.Default.GetBytes(code);   
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            code = BitConverter.ToString(output).Replace("-", "");
            return code;
        }

        //检查网络连接
        public static bool IsConnected()
        {
            int I = 0;
            bool state = InternetGetConnectedState(out I, 0);
            return state;
        }

        public static string GetMathString(double number)
        {
            return String.Format("{0:F}", number);
        }

        public static string PostPage(string url, string date)
        {
            CookieContainer cc = new CookieContainer();
            string postData = date;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData); // 转化

            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest2.CookieContainer = cc;
            webRequest2.Method = "POST";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();

            newStream.Write(byteArray, 0, byteArray.Length);    //写入参数
            newStream.Close();

            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
            string text2 = sr2.ReadToEnd();

            return text2;
        }

        public static Double GetDouble(string code)
        {
            try
            {
                return Convert.ToDouble(code);
            }
            catch
            {
                return 0.00;
            }
        }

        public static Double GetDouble(object code)
        {
            try
            {
                return Convert.ToDouble(code);
            }
            catch
            {
                return 0.00;
            }
        }

        public static string GetIP()
        {
            string ip = "127.0.0.1";
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            if (ipEntry.AddressList.Length > 0)
            {
                ip = ipEntry.AddressList[0].ToString();
            }
            return ip;
        }

        /// <summary>
        /// 取得网站域名的根目录(绝对路径及相对路径)
        /// </summary>
        /// <returns></returns>
        public static string GetSiteDomain()
        {
            string flg = "";
            string dirdumm = Foosun.Config.UIConfig.dirDumm;

            if (dirdumm.Trim() != string.Empty)
            {
                dirdumm = "/" + dirdumm;
            }
            string linkType = Common.ConfigHelper.ReadparamConfig("linkTypeConfig");
            if (linkType == "1")
            {
                flg = GetDomainConfig() + dirdumm;
            }
            else { flg = dirdumm; }
            return flg;
        }

        public static string GetDomainConfig()
        {
            string sitedomain = Common.ConfigHelper.ReadparamConfig("siteDomain");
            if (Common.ServerInfo.ServerPort != "80" && sitedomain.IndexOf(":") < 0)
            {
                sitedomain += ":" + Common.ServerInfo.ServerPort;
            }
            if (sitedomain.IndexOf("http://") < 0)
            {
                sitedomain = "http://" + sitedomain;
            }
            return sitedomain;
        }
    }
}

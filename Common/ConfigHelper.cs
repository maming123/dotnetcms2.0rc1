using System;
using System.Configuration;
using System.Web;
using System.Xml;
using System.IO;
using System.Text;

namespace Common
{
	/// <summary>
	/// web.config操作类
    /// Copyright (C) Maticsoft
	/// </summary>
	public sealed class ConfigHelper
	{
		/// <summary>
		/// 得到AppSettings中的配置字符串信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetConfigString(string key)
		{
            string CacheKey = "AppSettings-" + key;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = ConfigurationManager.AppSettings[key]; 
                    if (objModel != null)
                    {                        
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return objModel.ToString();
		}

		/// <summary>
		/// 得到AppSettings中的配置Bool信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool GetConfigBool(string key)
		{
			bool result = false;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = bool.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}
			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置Decimal信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static decimal GetConfigDecimal(string key)
		{
			decimal result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = decimal.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置int信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static int GetConfigInt(string key)
		{
			int result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = int.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="target">接点名</param>
        /// <returns></returns>
        public static string ReadparamConfig(string target)
        {
            string rstr = "";
            string xmlPath = null;
            if (HttpContext.Current == null)
            {
                xmlPath = HttpRuntime.AppDomainAppPath + "/xml/sys/base.config";
            }
            else
            {
                xmlPath = HttpContext.Current.Server.MapPath("~/xml/sys/base.config");
            }
            FileInfo finfo = new FileInfo(xmlPath);
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName(target);
            rstr += elemList[0].InnerXml;
            return rstr;
        }

        /// <summary>
        /// 读取频道配置
        /// </summary>
        public static string ReadCHparamConfig(string target, int chID)
        {
            string rstr = "";
            string xmlPath = HttpContext.Current.Server.MapPath("~/xml/sys/Channel/ChParams/CH_" + chID.ToString() + ".config");
            FileInfo finfo = new FileInfo(xmlPath);
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName(target);
            rstr += elemList[0].InnerXml;
            return rstr;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="target">接点名</param>
        /// <returns></returns>
        public static void SaveXmlConfig(string target, string value, string source)
        {
            string xmlPath = HttpContext.Current.Server.MapPath("~/" + source);
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlPath);

            XmlTextWriter xmlWriter = new XmlTextWriter(xmlPath, Encoding.UTF8);

            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName(target);
            elemList[0].InnerXml = value;

            xmlWriter.Indentation = 1;
            xmlWriter.IndentChar = '	';
            xmlWriter.Formatting = System.Xml.Formatting.Indented;
            xdoc.Save(xmlWriter);
            xmlWriter.Close();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="target">接点名</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ReadparamConfig(string target, string type)
        {
            string rstr = "";
            if (type != null && type != string.Empty)
            {
                string xmlPath = null;
                if (HttpContext.Current == null)
                {
                    xmlPath = HttpRuntime.AppDomainAppPath + "/xml/sys/" + type + ".config";
                }
                else
                {
                    xmlPath = HttpContext.Current.Server.MapPath("~/xml/sys/" + type + ".config");
                }
                FileInfo finfo = new FileInfo(xmlPath);
                System.Xml.XmlDocument xdoc = new XmlDocument();
                xdoc.Load(xmlPath);
                XmlElement root = xdoc.DocumentElement;
                XmlNodeList elemList = root.GetElementsByTagName(target);
                rstr += elemList[0].InnerXml;
            }
            else
            {
                rstr = ReadparamConfig(target);
            }
            return rstr;
        }
	}
}

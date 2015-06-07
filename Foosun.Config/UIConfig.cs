using System;
using System.Configuration;

namespace Foosun.Config
{
	public class UIConfig
	{
		public static string WebDAL = ConfigurationManager.AppSettings["WebDAL"];
		public static string dataRe = ConfigurationManager.AppSettings["dataRe"];
		public static string mssql = ConfigurationManager.AppSettings["mssql"];
        public static string extensions = ConfigurationManager.AppSettings["extensions"];
		public static string CssPath()
		{
			return BaseConfig.GetConfigValue("manner");
		}
		public static string returnCopyRight = verConfig.isTryversion + verConfig.helpcenterStr + verConfig.ForumStr;
		public static string HeadTitle = BaseConfig.GetConfigValue("headTitle");
		public static string sHeight = BaseConfig.GetConfigValue("sHeight");
		public static string sWidth = BaseConfig.GetConfigValue("sWidth");
		public static string isLinkTF = BaseConfig.GetConfigValue("isLinkTF");
		public static string dirMana = BaseConfig.GetConfigValue("dirMana");
		public static string dirUser = BaseConfig.GetConfigValue("dirUser");
		public static string dirDumm = BaseConfig.GetConfigValue("dirDumm");
		public static string UserdirFile = BaseConfig.GetConfigValue("UserdirFile");
		public static string protPass = BaseConfig.GetConfigValue("protPass");
		public static string protRand = BaseConfig.GetConfigValue("protRand");
		public static string dirTemplet = BaseConfig.GetConfigValue("dirTemplet");
        public static string dropTemplet = BaseConfig.GetConfigValue("dropTemplet");
		public static string dirSite = BaseConfig.GetConfigValue("dirSite");
		public static string dirFile = BaseConfig.GetConfigValue("dirFile");
		public static string dirHtml = BaseConfig.GetConfigValue("dirHtml");
		public static string saveContent = BaseConfig.GetConfigValue("saveContent");
		public static string publicType = Foosun.Config.verConfig.PublicType;
		public static string indeData = BaseConfig.GetConfigValue("indeData");
		public static string Logfilename = BaseConfig.GetConfigValue("Logfilename");
		public static string dirPige = BaseConfig.GetConfigValue("dirPige");
		public static string dirPigeDate = BaseConfig.GetConfigValue("dirPigeDate");
		public static string publicfreshinfo = BaseConfig.GetConfigValue("publicfreshinfo");
		public static string constPass = BaseConfig.GetConfigValue("constPass");
		public static string filePass = BaseConfig.GetConfigValue("filePass");
		public static string filePath = BaseConfig.GetConfigValue("filePath");
		public static string sqlConnData = BaseConfig.GetConfigValue("sqlConnData");
		public static string smtpserver = BaseConfig.GetConfigValue("smtpserver");
		public static string emailuserName = BaseConfig.GetConfigValue("emailuserName");
		public static string emailuserpwd = BaseConfig.GetConfigValue("emailuserpwd");
		public static string emailfrom = BaseConfig.GetConfigValue("emailfrom");
		public static string copyright = BaseConfig.GetConfigValue("copyRight");
		public static string titlemore = BaseConfig.GetConfigValue("titlemore");
		public static string commperPageNum = BaseConfig.GetConfigValue("commperPageNum");
		public static string splitPageCount = BaseConfig.GetConfigValue("splitPageCount");
		public static string enableAutoPage = BaseConfig.GetConfigValue("enableAutoPage");
		public static string titlenew = BaseConfig.GetConfigValue("titlenew");
		public static string FTPQueueFile = BaseConfig.GetConfigValue("FTPQueue");
		public static string Linktagert = BaseConfig.GetConfigValue("Linktagert");
		public static string Linktagertimg = BaseConfig.GetConfigValue("Linktagertimg");
		public string snportpass()
		{
			return BaseConfig.GetConfigValue("portpass");
		}
		/// <summary>
		/// 取得参数配置每页显示记录多少条
		/// </summary>
		/// <returns>返回数值型</returns>
		public static int GetPageSize()
		{

			int n = Convert.ToInt32(BaseConfig.GetConfigValue("PageSize"));
			if (n < 1)
				throw new Exception("每页记录条数不能小于1!");
			return n;
		}

		#region 刷新缓存
		/// <summary>
		/// 刷新缓存
		/// </summary>
		public static void RefurbishCatch()
		{
			HeadTitle = BaseConfig.GetConfigValue("headTitle");
			sHeight = BaseConfig.GetConfigValue("sHeight");
			sWidth = BaseConfig.GetConfigValue("sWidth");
			isLinkTF = BaseConfig.GetConfigValue("isLinkTF");
			dirMana = BaseConfig.GetConfigValue("dirMana");
			dirUser = BaseConfig.GetConfigValue("dirUser");
			dirDumm = BaseConfig.GetConfigValue("dirDumm");
			UserdirFile = BaseConfig.GetConfigValue("UserdirFile");
			protPass = BaseConfig.GetConfigValue("protPass");
			protRand = BaseConfig.GetConfigValue("protRand");
			dirTemplet = BaseConfig.GetConfigValue("dirTemplet");
			dirSite = BaseConfig.GetConfigValue("dirSite");
			dirFile = BaseConfig.GetConfigValue("dirFile");
			dirHtml = BaseConfig.GetConfigValue("dirHtml");
			saveContent = BaseConfig.GetConfigValue("saveContent");
			indeData = BaseConfig.GetConfigValue("indeData");
			Logfilename = BaseConfig.GetConfigValue("Logfilename");
			dirPige = BaseConfig.GetConfigValue("dirPige");
			dirPigeDate = BaseConfig.GetConfigValue("dirPigeDate");
			publicfreshinfo = BaseConfig.GetConfigValue("publicfreshinfo");
			constPass = BaseConfig.GetConfigValue("constPass");
			filePass = BaseConfig.GetConfigValue("filePass");
			filePath = BaseConfig.GetConfigValue("filePath");
			sqlConnData = BaseConfig.GetConfigValue("sqlConnData");
			smtpserver = BaseConfig.GetConfigValue("smtpserver");
			emailuserName = BaseConfig.GetConfigValue("emailuserName");
			emailuserpwd = BaseConfig.GetConfigValue("emailuserpwd");
			emailfrom = BaseConfig.GetConfigValue("emailfrom");
			copyright = BaseConfig.GetConfigValue("copyRight");
			titlemore = BaseConfig.GetConfigValue("titlemore");
			commperPageNum = BaseConfig.GetConfigValue("commperPageNum");
			splitPageCount = BaseConfig.GetConfigValue("splitPageCount");
			enableAutoPage = BaseConfig.GetConfigValue("enableAutoPage");
			titlenew = BaseConfig.GetConfigValue("titlenew");
		}
		#endregion
	}
}

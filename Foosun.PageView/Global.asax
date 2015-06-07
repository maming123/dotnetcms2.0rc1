<%@ Application Language="C#" %>
<script RunAt="server">
	void Application_Start(object sender, EventArgs e)
	{
		// 在应用程序启动时运行的代码
		Foosun.Model.FtpConfig ftpInfo = new Foosun.Model.FtpConfig();
		try
		{
			Foosun.CMS.sys sysConfig = new Foosun.CMS.sys();
			System.Data.DataTable ftpConfig = sysConfig.FtpRss();
			ftpInfo.Enabled = Convert.ToByte(ftpConfig.Rows[0]["FtpTF"]);
			ftpInfo.IP = ftpConfig.Rows[0]["FTPIP"].ToString();
			ftpInfo.Port = Convert.ToInt32(ftpConfig.Rows[0]["Ftpport"]);
			ftpInfo.UserName = ftpConfig.Rows[0]["FtpUserName"].ToString();
			ftpInfo.Password = Common.Input.NcyString(ftpConfig.Rows[0]["FTPPASSword"].ToString());
		}
		catch
		{
			ftpInfo.Enabled = 0;
		}
		Application.Add("FTPInfo", ftpInfo);
	}

	void Application_End(object sender, EventArgs e)
	{
		//  在应用程序关闭时运行的代码

	}

	void Application_Error(object sender, EventArgs e)
	{
		Exception x = Server.GetLastError().GetBaseException();
		string errmsg = x.ToString();
		Regex re = new Regex(@"文件(.*)不存在");
		if (re.Match(errmsg).Success)
		{
			Foosun.PageBasic.WebHint.ShowError("您所浏览的页面不存在", "/", true);
		}
		else
		{
			Foosun.PageBasic.WebHint.ShowError(errmsg, "", false);
		}
	}

	void Session_Start(object sender, EventArgs e)
	{

	}

	void Session_End(object sender, EventArgs e)
	{

	}
       
</script>

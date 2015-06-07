<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FtpSync.aspx.cs" Inherits="Foosun.PageView.manage.publish.FtpSync" %>

<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>FTP同步</title>
	<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
       <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jspublic.js" type="text/javascript"></script>
</head>
<body>
	<form id="form1" runat="server">
	<div class="mian_body">
        <div class="mian_wei">
            <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>FTP同步</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>FTP同步  
              </div>
           </div>
           <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
        </div>
        <div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能：</span>
        <asp:Button ID="Button2" runat="server" Text="同步列队文件" CssClass="xsubmit1 mar" OnClick="Button2_Click" />
        <asp:Button ID="Button1" runat="server" Text="同步其他资源文件" CssClass="xsubmit1 mar" OnClick="Button1_Click" />
        <asp:Button ID="Button3" runat="server" OnClientClick="location.reload();" CssClass="xsubmit1 mar" Text="刷新" />
        <asp:Button ID="Button4" runat="server" Enabled="False" onclick="Button4_Click" CssClass="xsubmit1 mar" Text="取消" />
      </div>
      <div class="jslie_lie">
		<table class="jstable">
			<tr>
				<td>
					<div>
						FTP同步状态：
						<asp:Label ID="lblFtpEnabled" runat="server" Text="禁用"></asp:Label></div>
					<div>
						当前列队的文件数：<asp:Label ID="lblQueueCount" runat="server" Text="0"></asp:Label></div>
					<asp:Repeater ID="Repeater1" runat="server">
						<ItemTemplate>
							<div>
								<%#Container.DataItem%></div>
						</ItemTemplate>
					</asp:Repeater>
				</td>
			</tr>
		</table>
        </div>
        </div>
        </div>
	</div>
	</form>
</body>
</html>
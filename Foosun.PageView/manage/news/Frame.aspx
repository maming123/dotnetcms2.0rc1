<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame.aspx.cs" Inherits="Foosun.PageView.manage.news.Frame" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>
<body>
	<form id="form1" runat="server">
	<table  class="newzt_tab" id="Frame">
		<tr class="newzt_tab_tr" runat="server" id="js">
			<td align="center">
				JS名称
				<asp:DropDownList ID="DropDownList1" runat="server" Width="270px">
				</asp:DropDownList>
			</td>
		</tr>
		<tr class="newzt_tab_tr" runat="server" id="dspecial">
			<td align="center" valign="top">
				专题名称
				<select id="Special" name="Special" style="width: 250px; height: 150px" runat="server"  multiple>
				</select>
			</td>
		</tr>
		<tr class="newzt_tab_tr">
			<td align="center">
				<asp:Button ID="Button1" runat="server" Text="确 定" OnClick="Button1_Click" />
				&nbsp; &nbsp;&nbsp;
				<asp:Button ID="Button2" runat="server" Text="取 消" OnClientClick="javascript:window.close();" />
			</td>
		</tr>
	</table>
	</form>
</body>
</html>

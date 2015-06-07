<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_info_onlinePoint" CodeBehind="onlinePoint.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <title>在线支付</title>
</head>
<body class="main_big">
	<form id="form1" runat="server">
	<table width="100%" border="0" cellpadding="0" cellspacing="0" class="toptable">
		<tr>
			<td height="1" colspan="2">
			</td>
		</tr>
		<tr>
			<td width="57%" height="32" class="sysmain_navi" style="padding-left: 14px">
				银行冲值
			</td>
			<td width="43%" height="32" class="topnavichar" style="padding-left: 14px">
				<div align="left">
					位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" />冲值管理</div>
			</td>
		</tr>
	</table>
	<table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
		<tr>
			<td style="padding-left: 14px;">
				<a class="topnavichar" href="getPoint.aspx">点卡冲值</a>&nbsp;┊&nbsp;<a class="topnavichar" href="onlinePoint.aspx">在线银行冲值</a>&nbsp;┊&nbsp;<a href="buyCard.aspx" class="list_link">购买点卡</a>&nbsp;┊&nbsp;<a href="history.aspx" class="topnavichar">交易明晰</a>
			</td>
		</tr>
	</table>
	<table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="Tablist tab">
		<tr class="TR_BG_list">
			<td style="padding-right: 14px; width: 20%;" align="right">
				请输入冲值金额
			</td>
			<td align="left">
				<asp:TextBox MaxLength="4" CssClass="form" ID="pointNumber" runat="server">100</asp:TextBox>&nbsp;金币&nbsp;&nbsp;
				<asp:RequiredFieldValidator ID="f_pointNumber" runat="server" ControlToValidate="pointNumber" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请输入金额。必须输入正整数</span>"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="pointNumber" Display="Static" ErrorMessage="(*)格式不正确。请填写正整数.最大长度为4位" ValidationExpression="^[0-9]{0,4}"></asp:RegularExpressionValidator>
			</td>
		</tr>
		<tr class="TR_BG_list">
			<td style="padding-left: 14px; width: 20%;">
			</td>
			<td align="left">
				<asp:Button ID="Button1" runat="server" Text="开始冲值" OnClick="Button1_Click" /><span class="helpstyle" style="cursor: help" title="点击查看帮助" onclick="Help('H_onlinePoint_001',this)">如何冲值的?</span> &nbsp;<span class="helpstyle" style="cursor: help" title="点击查看帮助" onclick="Help('H_onlinePoint_002',this)">金币和冲值的金额关系?</span>
			</td>
		</tr>
	</table>
	</form>
	<br />
	<br />
	<table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
		<tr>
			<td align="center">
				<% Response.Write(CopyRight); %>
			</td>
		</tr>
	</table>
</body>
</html>

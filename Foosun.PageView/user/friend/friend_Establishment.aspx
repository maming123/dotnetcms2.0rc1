<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_friend_Establishment" Codebehind="friend_Establishment.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
	<link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body class="main_big">
<form id="form1" name="form1" method="post" action="" runat="server">
  <table width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
          <td height="1" colspan="2"></td>
        </tr>
        <tr>
          <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">好友管理</strong></td>
    <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="/sysImages/folder/navidot.gif" border="0" /><a href="friendList.aspx" class="menulist">好友管理</a><img alt="" src="/sysImages/folder/navidot.gif" border="0" />好友设置</div></td>
        </tr>
</table>
<table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
  <tr>
     <td><span class="topnavichar" style="PADDING-LEFT: 14px"><a href="friendList.aspx" class="menulist">好友管理</a>　<a href="friendmanage.aspx" class="menulist">好友分类</a>&nbsp;&nbsp; <a href="friend_add.aspx" class="menulist">添加好友</a>&nbsp;&nbsp; <a href="#" class="menulist">好友设置</a></span></td>
  </tr>
</table>

<table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" class="Tablist tab">
  
   <tr class="TR_BG_list">
    <td class="list_link" Width="20%" align="right" valign="middle">
        身份验证：</td>
      <td class="list_link" colspan="4" Width="70%"> 
          <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="90px" Width="296px" RepeatLayout="Flow">
              <asp:ListItem Value="2"><span class="span1">允许任何人把我列为好友</span></asp:ListItem>
              <asp:ListItem Value="1"><span class="span1">需要身份认证才能把我列为好友</span></asp:ListItem>
              <asp:ListItem Value="0"><span class="span1">不允许任何人把我列为好友</span></asp:ListItem>
          </asp:RadioButtonList></td>
  </tr>    
  <tr class="TR_BG_list">
    <td class="list_link"></td>
   <td class="list_link">
       &nbsp; &nbsp; &nbsp;
       <asp:Button ID="addfriend" runat="server" Text="提  交"  OnClick="addfriend_Click"  CssClass="form"/></td>   
  </tr>
</table>
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %></div></td>
  </tr>
</table>
</form>
</body>
</html>

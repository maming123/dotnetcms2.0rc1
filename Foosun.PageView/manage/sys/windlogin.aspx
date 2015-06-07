<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_Sys_windlogin" CodeBehind="windlogin.aspx.cs" %>

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

<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>配置文件管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>配置文件管理 
      </div>
   </div>
</div>
  <div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table">
    <tr>
      <td colspan="2" ><span class="span1"></span>注意：配置文件密码默认为<b style="font-weight:100; color:#F00;">foosun.net</b>,管理员请进入配置文件,修改密码。</td>
    </tr>
    <tr>
      <td align="right" width="20%">请输入配置文件管理密码：</td>
      <td>
            <asp:TextBox ID="TextBox1" runat="server"  TextMode="Password" CssClass="input8"></asp:TextBox><script>					                                                                                                        	document.getElementById('TextBox1').focus();</script>
			<asp:Button ID="Button1" runat="server"  Text="确定"  OnClick="Button1_Click" CssClass="xsubmit1" />
      </td>
    </tr>
  </table>
  </div>
  </div>
  </div>
  </div>
</div> 
</form> 
</body>
</html>

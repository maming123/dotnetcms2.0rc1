<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="FreeLabelTest" Codebehind="FreeLabelTest.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>
<body>
<form id="Form1" runat="server">
<div  class="mian_body">
         <div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>自由标签SQL语句测试</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="FreeLabelList.aspx">自由标签</a>>>自由标签SQL语句测试
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li>功能：<a class="topnavichar" href="javascript:window.close();">关闭</a></li>
         </ul>
      </div>
      <div class="lanlie_lie">
         <div class="jslie_lie">
          <asp:Label ID="LblError" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="Red"></asp:Label>
          <asp:GridView ID="GrvData" runat="server" class="fretable">
          </asp:GridView>  
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

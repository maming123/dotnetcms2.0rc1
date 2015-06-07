<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" AutoEventWireup="true" Inherits="user_arealist_cadd" EnableEventValidation="true"  Codebehind="arealist_cadd.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" name="form1" method="post" action="" runat="server">
<div class="mian_body">
    <div class="mian_wei">
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>地域管理 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="arealist.aspx">地域管理</a> >>新增/编辑地域子类
          </div>
       </div>
    </div>
<div class="mian_cont">
   <div class="nwelie">
   <div class="jslie_lan" align="left"><font color="#ff0000">功能:</font> ┊<a href="arealist.aspx" class="menulist">大类</a>|<a href="arealist_add.aspx" class="menulist">添加大类</a>|<span class="topnavichar" style="PADDING-right: 25px" id="pdel" runat="server"></span></div>
    <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table">
  <tr>
    <td width="10%" align="left" style="width: 11%; height: 29px;">
        大类名称：</td>
    <td width="90%" align="left" style="height: 29px">
         <asp:DropDownList ID="DropDownList1" runat="server" Width="167px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td>
        小类名称：</td>
    <td>
        <asp:TextBox ID="cityName" runat="server" Width="163px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cityName"
            ErrorMessage="请输入省名称"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>
        排序：</td>
    <td>
         <asp:TextBox ID="OrderID" runat="server" MaxLength="2" Width="163">0</asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="OrderID"
            ErrorMessage="请输入排序号"></asp:RequiredFieldValidator>&nbsp;数字越大，越靠前。</td>
  </tr>

  </table>

    <div class="nxb_submit">
          <asp:Button ID="but1" runat="server" Text="提  交" OnClick="but1_Click" class="xsubmit1 mar" />
        <input type="reset" name="Submit3" value="重  置" class="xsubmit1 mar" />
             </div>
    </div>
  </div>
   </div>
</div>
</div>
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %> </div></td>
  </tr>
</table>
</form>
</body>
</html>
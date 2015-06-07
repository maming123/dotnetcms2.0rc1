<%@ Page Language="C#" AutoEventWireup="true" Inherits="Navimenu_list" ResponseEncoding="utf-8" Codebehind="Navimenu_list.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
<link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3> 菜单管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a> >>菜单管理  
      </div>
   </div>
</div>
<div class="mian_cont">
    <div class="nwelie">
     <div class="jslie_lan">
        <a href="Navimenu_list.aspx?type=all">所有菜单</a>&nbsp;┊&nbsp;<a href="Navimenu.aspx">创建功能菜单</a>&nbsp;┊&nbsp;<a href="Navimenu_list.aspx?type=sys">系统菜单</a>&nbsp;┊&nbsp;<a href="Navimenu_list.aspx?type=unsys">非系统菜单</a>
      </div>
      <div class="jslie_lie">
<div id="navimenu_list" runat="server" />
</div>
</div>
</div>
</div>
</body>
</html>

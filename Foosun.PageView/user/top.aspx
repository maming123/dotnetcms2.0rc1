<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Foosun.PageView.user.top" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
    <link type="text/css" rel="stylesheet" href="css/base.css" />
    <link type="text/css" rel="stylesheet" href="css/style.css"/>
	
	<script type="text/javascript" language="javascript">
    function show(obj)
	{
        window.parent.menu.show(obj);
    }
    </script>
</head>

<body>
  <div class="top">
    <div class="top_left"><img src="images/conn_03.gif" alt="" /></div>
    <div class="top_right">
      <div class="top_right_top">
        <img src="images/conn_06.gif" alt=""/>
        您好：<strong><%=Foosun.Global.Current.UserName %></strong>！ | <a href="main.aspx" target="sys_main">用户中心</a> | 
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> | <a href="Logout.aspx" target="_parent">退出</a>
      </div>
      <div class="top_right_menu">
        <div class="top_right_menu_l"></div>
        <div class="menu">
          <ul> 
            <li><a href="main.aspx" target="sys_main">首页</a></li>
            <li><img src="images/conn_14.gif" /></li>
            <li><a href="javascript:show('list1')">控制面板</a></li>
            <li><img src="images/conn_14.gif" /></li>
            <li><a href="javascript:show('list2')">站内消息</a></li>
            <li><img src="images/conn_14.gif" /></li>
<%--            <li><a href="#">文章管理</a></li>
            <li><img src="images/conn_14.gif" /></li>--%>
            <li><a href="javascript:show('list3')">发布信息</a></li>
            <li><img src="images/conn_14.gif" /></li>
            <li><a href="javascript:show('list4')">社群/讨论</a></li>
            <li><img src="images/conn_14.gif" /></li>
            <li><a href="javascript:show('list5')">好友管理</a></li>
          </ul>
        </div>
        <div class="top_right_menu_r"></div>
      </div>
    </div>
  </div>
</body>
</html>


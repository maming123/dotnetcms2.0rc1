<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Foosun.PageView.manage.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script type="text/javascript"  language="javascript" src="/Scripts/public.js"></script>
<script type="text/javascript" language="javascript">
    if (navigator.userAgent.indexOf("MSIE 6") > -1) {
        window.attachEvent("onload", correctPNG);
    };
    function open(eid) {
        for (var i = 1; i < 8; i++) {
            $("#menu" + i.toString()).removeClass("nav_bj");
        }
        $("#menu" + eid).addClass("nav_bj");
    }

    function menuClick(id) {
            if (window.parent.sys_main.button1to2 != null) {
                window.parent.sys_main.sets(id);
            }
            else {
                window.parent.sys_main.location = "main.aspx?id=" + id;
                top.document.getElementsByTagName("*").bodyFrame.cols = '0,0,*';
            }
    }
    function logout() {
        window.parent.location = "Login.aspx";
    }
</script>
</head>
<body class="topbody">
<div class="top_body">
  <div class="top_big">
    <div class="top_left"><img src="imges/logo.png" alt="" /></div> 
    <div class="top_right">
       <ul id="menus">
         <li><a id="menu1" href="javascript:menuClick(1)" class="nav_bj"><div class="toprig"><img src="imges/lie_08.png" alt="" /><br />首页</div></a></li>
         <li><a id="menu2" href="javascript:menuClick('2')"><div class="toprig"><img src="imges/lie_07.png" alt="" /><br />快捷方式</div></a></li>
         <li><a id="menu3" href="javascript:menuClick('3')"><div class="toprig"><img src="imges/lie_06.png" alt="" /><br />内容管理</div></a></li>
         <li><a id="menu4" href="javascript:menuClick('4')"><div class="toprig"><img src="imges/lie_05.png" alt="" /><br />发布管理</div></a></li>
         <li><a id="menu5" href="javascript:menuClick('5')"><div class="toprig"><img src="imges/lie_04.png" alt="" /><br />会员管理</div></a></li>
         <li><a id="menu6" href="javascript:menuClick('6')"><div class="toprig"><img src="imges/lie_03.png" alt="" /><br />插件管理</div></a></li>
         <li><a id="menu7" href="javascript:menuClick('7')"><div class="toprig"><img src="imges/lie_02.png" alt="" /><br />控制面板</div></a></li>
       </ul>
    </div>
    <div class="clear"></div>
    
  </div>
  <div class="top_lan">
      <div class="top_lan_left">
         <div class="top_lan_admin">您好<span><%=Foosun.Global.Current.UserName %></span>
         <%--<a target="sys_main" href="sys/AdminEdit.aspx?Type=Update&ID=<%= Foosun.Global.Current.UserNum%>">[修改密码]</a>--%>
         </div>
         <div class="top_lan_date">今天是<%=dayofnow %></div>
         <div class="top_lan_tq">
        <%-- <iframe src="http://m.weather.com.cn/m/pn6/weather.htm?id=101270101T " width="160" height="32" marginwidth="0" marginheight="0" hspace="0" vspace="0" frameborder="0" scrolling="no" allowtransparency="true"></iframe>--%>
         </div>
      </div>
      <div class="top_lan_right">
         <ul>
            <li><a href="/user/index.aspx" target="_blank"><img src="imges/lie__09.gif" align="texttop" alt=""/>&nbsp;&nbsp;会员中心</a></li>
            <li><a href="javascript:history.go(-1)"><img src="imges/lie__11.gif" align="texttop" alt="" />&nbsp;&nbsp;后退</a></li>
            <li><a href="javascript:history.go(1)"><img src="imges/lie__13.gif" align="texttop" alt="" />&nbsp;&nbsp;前进</a></li>
            <li><a href="javascript:window.parent.sys_main.location.reload() "><img src="imges/lie__15.gif" align="texttop" alt="" />&nbsp;&nbsp;刷新</a></li>
            <li><a href="#" onclick="logout();"><img src="imges/lie__17.gif" align="texttop" alt="" />&nbsp;&nbsp;退出系统</a></li>
         </ul>
      </div>
   </div>
</div>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="ad_stat" Codebehind="ad_stat.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>查看统计信息</title>
     <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />

    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        //<!CDATA[
        function g(o) { return document.getElementById(o); }
        function hover_zzjs_net(n, m, k) {
            //m表示开始id，k表示结束id
            for (var i = m; i <= k; i++) {
                g('tab_zzjs_' + i).className = 'nor_zzjs';
            }
            g('tab_zzjs_' + n).className = 'hovertab_zzjs';
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
  <div class="mian_wei">
     <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
    <div class="mian_wei_min">
      <div class="mian_wei_left">
        <h3>广告管理</h3>
      </div>
      <div class="mian_wei_right">  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="AdList.aspx">广告系统</a> >>查看统计信息</div>
    </div>
    <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
  </div>
  <div class="mian_cont">
    <div class="nwelie">
      <div class="newxiu_lan">
        <ul class="tab_zzjs_" id="tab_zzjs_">
          <li id="tab_zzjs_1" class="hovertab_zzjs" onclick="x:hover_zzjs_net(1,1,6);"><a href="ad_stat.aspx?st=hour&adsID=<% =str_adsID %>" class="list_link">24小时统计</a></li>
          <li id="tab_zzjs_2" class="nor_zzjs" onclick="x:hover_zzjs_net(2,1,6);"><a href="ad_stat.aspx?st=day&adsID=<% =str_adsID %>" class="list_link">日统计</a> </li>
          <li id="tab_zzjs_3" class="nor_zzjs" onclick="x:hover_zzjs_net(3,1,6);"> <a href="ad_stat.aspx?st=week&adsID=<% =str_adsID %>" class="list_link">周统计</a></li>
          <li id="tab_zzjs_4" class="nor_zzjs" onclick="x:hover_zzjs_net(4,1,6);"><a href="ad_stat.aspx?st=month&adsID=<% =str_adsID %>" class="list_link">月统计</a> </li>
          <li id="tab_zzjs_5" class="nor_zzjs" onclick="x:hover_zzjs_net(5,1,6);"> <a href="ad_stat.aspx?st=year&adsID=<% =str_adsID %>" class="list_link">年统计</a> </li>
          <li id="tab_zzjs_6" class="nor_zzjs" onclick="x:hover_zzjs_net(6,1,6);"><a href="ad_stat.aspx?st=source&adsID=<% =str_adsID %>" class="list_link">来源统计</a></li>
        </ul>
        <div class="newxiu_bot">
          <div class="dis_zzjs_net" id="tab_zzjs_01">
            <div id="DivStat" runat="server" style="padding:0 1%;">
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
    </form>
</body>
</html>

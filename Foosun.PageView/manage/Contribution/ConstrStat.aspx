<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConstrStat.aspx.cs" Inherits="Foosun.PageView.manage.Contribution.ConstrStat" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>稿件统计</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
 
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>投稿管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="ConstrList.aspx">稿件管理</a> >>稿件统计
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span><a href="ConstrList.aspx">稿件管理</a>┊<a href="ConstrStat.aspx"> 稿件统计</a>┊<a href="ConstrList.aspx?type=cheack">所有通过审核稿件</a></span>
      </div>
      <div class="jslie_lie">
      <div id="no" runat="server"></div>
        <asp:Repeater ID="DataList1" runat="server" >
    <HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="17%">用户名</th>
               <th width="17%">投稿数</th>
               <th width="17%">已审核数</th>
               <th width="17%">上月投稿数</th>
               <th width="15%">稿酬得积分数</th>
               <th width="17%">积分总计</th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td align="center"><%#Eval("UserNames")%></td>
              <td align="center"><%#Eval("Constrnum")%></td>
              <td align="center"><%#Eval("isChecknumber")%></td>
              <td align="center"><%#Eval("MConstrnum")%></td>
              <td align="center"><%#Eval("ParmConstrNums")%></td>
              <td align="center"><%#Eval("ipoint")%></td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
         </table>
         </FooterTemplate>
         </asp:Repeater>
         <div class="fanye1">
         <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
      </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

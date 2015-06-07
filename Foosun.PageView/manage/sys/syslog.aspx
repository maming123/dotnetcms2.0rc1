<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="syslog.aspx.cs" Inherits="Foosun.PageView.manage.Sys.syslog" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
    <div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3> 操作日志</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a> >>操作日志  
      </div>
   </div>
</div>
<div class="mian_cont">
    <div class="nwelie">
    <div class="jslie_lie" style="margin-top:15px;">
<asp:Repeater ID="DataList1" runat="server">
   <HeaderTemplate>
       <table class="jstable">
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <th>标题</th>
        <th width="50%">操作内容</th>
        <th>操作时间</th>
        <th>IP地址</th>
        <th>用户</th>
      </tr>   
    </HeaderTemplate>
      <ItemTemplate>
        <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <td><span class="span1"><%#((DataRowView)Container.DataItem)["title"]%></span></td>
        <td><span class="span1"><%#((DataRowView)Container.DataItem)["content"]%></span></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["creatTime"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["IP"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["usernum"]%></td>
        </tr>
      </ItemTemplate>
      <FooterTemplate>
      </table>
     </FooterTemplate>
</asp:Repeater>

        <div class="fanye1"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>


</div>
</div>
</div>
</div>
    </form>
</body>
</html>

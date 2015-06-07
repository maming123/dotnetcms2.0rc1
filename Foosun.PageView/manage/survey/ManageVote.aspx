<%@ Page Language="C#" AutoEventWireup="true" Inherits="ManageVote" Codebehind="ManageVote.aspx.cs" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="mian_body">
  <div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>调查管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>调查管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
<div class="nwelie">
   <div class="jslie_lan">
         <span>功能：</span><label id="param_id" runat="server" /><a href="setClass.aspx">投票分类设置</a>&nbsp;┊&nbsp;<a href="setTitle.aspx">投票主题设置</a>&nbsp;┊&nbsp;<a href="setItem.aspx">投票选项设置</a>&nbsp;┊&nbsp;<a href="setSteps.aspx">多步投票管理</a>&nbsp;┊&nbsp;<a href="ManageVote.aspx">投票情况管理</a>
      </div>
  <div id="NoContent" runat="server" style="margin-left:5px"></div>
  <div class="jslie_lan" style="float:right">
  <div align="right">
            <asp:LinkButton ID="DelP" runat="server" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除</asp:LinkButton>
            |
            <asp:LinkButton ID="DelAll" runat="server" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="DelAll_Click">删除全部</asp:LinkButton></div>
  </div>
   <div class="jslie_lie">
  <asp:Repeater ID="DataList1" runat="server">
    <HeaderTemplate>
      <table class="jstable">
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <th width="4%">编号</th>
        <th width="7%">主题</th>
        <th width="7%">选项</td>
        <th width="12%">额外投票内容</th>
        <th width="10%">IP</th>
        <th width="14%">日期</th>
        <th width="6%">会员</th>
        <th width="8%">操作
          <input type="checkbox" id="vote_checkbox" value="-1" name="vote_checkbox" onclick="javascript:return selectAll(this.form,this.checked);"/></th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <td align="center"><%#((DataRowView)Container.DataItem)[0]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["title"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["item"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[3]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[4]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[5]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["usernum"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["oPerate"]%> </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      </table>
    </FooterTemplate>
  </asp:Repeater>
  <div class="fanye1">
    <uc1:PageNavigator ID="PageNavigator1" runat="server" />
  </div>
  </div>
</div>
</div>
</div>
</form>
<br />
<br />

</body>
</html>

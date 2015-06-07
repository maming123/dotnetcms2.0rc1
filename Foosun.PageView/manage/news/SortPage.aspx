<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_news_SortPage" Codebehind="SortPage.aspx.cs" %>

<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>

<body>
<form id="server" runat="server">
<div>
    
    <div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>栏目管理(帮助)</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>栏目管理
      </div>
   </div>
   <%--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>--%>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li><a href="NewsClassList.aspx">栏目首页</a></li>
         </ul>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_tablez" style="width:99%; margin:0 auto; border-style:solid;">
             <tr>
               <td width="20%"></td>
               <td width="30%">源栏目</td>
               <td width="30%">目标栏目</td>
               <td width="20%"></td>
             </tr>
             <tr>
               <td><font color="#FFFFFF">1</font></td>
               <td>
                   <asp:DropDownList ID="SourceClassID" runat="server" Width="122px"> </asp:DropDownList>
               </td>
               <td>
                   <asp:Label ID="ExprText" runat="server"></asp:Label>
                    <asp:DropDownList ID="TargetClassID" runat="server" Width="98px">
                    <asp:ListItem Value="0">根栏目</asp:ListItem>
                    </asp:DropDownList>
               </td>
               <td></td>
             </tr>
           </table>
             <div class="nxb_submit" >
               <asp:Button ID="Btc" CssClass="xsubmit3" runat="server" OnClick="Btc_Click" OnClientClick="{if(confirm('确认此操作吗?\n此操作后不可以恢复数据!')){return true;}return false;}" />
                    <asp:HiddenField ID="Randsize" runat="server" />
           </div>
        </div>
      </div>
   </div>
</div>
</div>
<table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
   <tr>
     <td align="center"><%Response.Write(CopyRight); %></td>
   </tr>
 </table>

   <asp:Repeater ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
   <HeaderTemplate>
       <table width="98%" border="0" cellpadding="4" align="center" cellspacing="1" bgcolor="#FFFFFF" class="table">
      <tr class="TR_BG_list">
        <td width="7%" align="center" valign="middle" class="sysmain_navi">ID</td>
        <td width="29%" valign="middle" class="sysmain_navi">栏目中文[英文]</td>
        <td width="9%" valign="middle" class="sysmain_navi">权重</td>
        <td width="28%" valign="middle" class="sysmain_navi"></td>
        <td width="27%" valign="middle" class="sysmain_navi">操作</td>
      </tr>   
    </HeaderTemplate>
      <ItemTemplate>
        <tr class="TR_BG_list"  onmouseover="overColor(this)" onmouseout="outColor(this)">
        <td width="7%" align="center" valign="middle" height=20><%#((DataRowView)Container.DataItem)[0]%></td>
        <td width="29%" valign="middle" ><%#((DataRowView)Container.DataItem)[2]%>[<%#((DataRowView)Container.DataItem)[3]%>]</td>
        <td width="9%" valign="middle" ><%#((DataRowView)Container.DataItem)[5]%></td>
        <td width="28%" valign="middle" >
            <asp:TextBox ID="TextBox1" runat="server" Text="10"></asp:TextBox><asp:HiddenField
                ID="HiddNum" runat="server" Value="<%#((DataRowView)Container.DataItem)[1]%>" />
        </td>
        <td width="27%" valign="middle" >
            <asp:Button ID="Button1" runat="server" Text="更改权重(排序号)" /></td>            
        </tr>
      </ItemTemplate>
      <FooterTemplate>
      </table>
      </FooterTemplate>
  </asp:Repeater>
    <div align="right" style="width:98%"><uc1:PageNavigator ID="PageNavigator1" runat="server"/></div>
</div>
</form>
<br />
<br />
 



 
</body>
</html>

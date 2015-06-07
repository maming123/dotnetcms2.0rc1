<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" AutoEventWireup="true" Inherits="user_message_Message_box" EnableEventValidation="true" Debug="true" Codebehind="Message_box.aspx.cs" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body class="main_big">
<form id="form1" name="form1" method="post" action="" runat="server">
<table width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
          <td height="1" colspan="2"></td>
        </tr>
        <tr>
          <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">短信管理</strong></td>
          <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" />短信管理</div></td>
        </tr>
</table>
      <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
        <tr>
        <td style="padding-left:14px;"><a href="Message_write.aspx" class="navi_link">写新消息</a> &nbsp; &nbsp;<a href="?Id=1" class="navi_link">收件箱</a> &nbsp; &nbsp;<a href="?Id=2" class="navi_link">发件箱</a>&nbsp; &nbsp;<a href="?Id=3" class="navi_link">草稿箱</a>&nbsp; &nbsp;<a href="?Id=4" class="navi_link">废件箱</a>
        </td>
          <td align="right" style="width: 241px"><asp:LinkButton
                  ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="navi_link">删除到废件箱</asp:LinkButton>&nbsp; &nbsp;
              <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="navi_link">彻底删除</asp:LinkButton>
              &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
          </td>
        </tr>
</table>
<div id="no" runat="server"></div>
  <asp:Repeater ID="DataList1" runat="server" >
    <HeaderTemplate>
    <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" class="liebtable">
    <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
    <th class="sys_topBg" width="30%">标题</th>
    <th class="sys_topBg" align="center">时间</th>
    <th class="sys_topBg" align="center">重要程度</th>
    <th class="sys_topBg" align="center">是否查看</th>
    <th class="sys_topBg" align="center">有无附件</th>
    <th class="sys_topBg" align="center" width="10%">操作&nbsp; &nbsp;<input type="checkbox" name="Checkbox1222" onclick="javascript:selectAll(this.form,this.checked)" /></th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
            <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
        <td width="30%"><span class="span1"><%#((DataRowView)Container.DataItem)["btf1"]%><%#((DataRowView)Container.DataItem)["titles"]%><%#((DataRowView)Container.DataItem)["btf2"]%></span></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["btf1"]%><%#((DataRowView)Container.DataItem)["Send_DateTime"]%><%#((DataRowView)Container.DataItem)["btf2"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["btf1"]%><%#((DataRowView)Container.DataItem)["LevelFlag1"]%><%#((DataRowView)Container.DataItem)["btf2"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["btf1"]%><%#((DataRowView)Container.DataItem)["isRead1"]%><%#((DataRowView)Container.DataItem)["btf2"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["btf1"]%><%#((DataRowView)Container.DataItem)["FileTF1"]%><%#((DataRowView)Container.DataItem)["btf2"]%></td> 
        <td align="center" width="10%"><%#((DataRowView)Container.DataItem)["btf1"]%><%#((DataRowView)Container.DataItem)["idc"]%><%#((DataRowView)Container.DataItem)["btf2"]%></td>            
        </tr>
     </ItemTemplate>
     <FooterTemplate>
     </table>
     </FooterTemplate>
    </asp:Repeater>
<table width="98%" border="0" align="center" cellpadding="3" cellspacing="2" style="height: 20px">
   <tr><td align="right" width="40%"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></td></tr>
</table>
<br />
<br />
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %></div></td>
  </tr>
</table>
</form>
</body>
</html>

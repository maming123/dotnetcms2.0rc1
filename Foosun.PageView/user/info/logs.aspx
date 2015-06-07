<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="utf-8" Inherits="user_manage_logs" Codebehind="logs.aspx.cs" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>
<%Response.Write(Foosun.Config.UIConfig.HeadTitle); %>
</title>
<link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body class="main_big">
<form id="form1" runat="server">
  <table width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
    <tr>
      <td height="1" colspan="2"></td>
    </tr>
    <tr>
      <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">日历管理</strong></td>
      <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" />日历管理</div></td>
    </tr>
  </table>
  <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
    <tr>
      <td style="PADDING-LEFT: 14px;"><a class="topnavichar" href="logs.aspx">管理日历</a>　<a class="topnavichar" href="logsCreat.aspx">创建日历</a></td>
    </tr>
  </table>
  <asp:Repeater ID="DataList1" runat="server">
    <HeaderTemplate>
      <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" class="liebtable">
	    <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
        <th align="center" width="30%">日历名称</th>
        <th align="center" width="40%">描  述</th>
        <th align="center" width="10%">日  期</th>
        <th align="center" width="8%">提前提醒</th>
        <th align="center" width="12%">操  作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
        <td align="left"><%#((DataRowView)Container.DataItem)["Title"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["Content"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["LogDateTime"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["dateNum"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["op"]%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      </table>
    </FooterTemplate>
  </asp:Repeater>
  <div width="98%" align="right">
    <uc1:PageNavigator ID="PageNavigator1" runat="server"  />
  </div>
  <br />
</form>
<table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
  <tr>
    <td align="center"><label id="copyright" runat="server" /></td>
  </tr>
</table>
</body>
</html>
<script language="javascript" type="text/javascript">
function del(ID)
{
    if (confirm('你确认删除此记录吗?'))
    {
        self.location="Logs.aspx?Type=del&ID="+ID;
    }
}
function edit(ID)
{
    {
        self.location="LogsCreat.aspx?Type=edit&ID="+ID;
    }
}
</script>
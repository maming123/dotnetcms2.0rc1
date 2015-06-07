<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_info_announce"  ResponseEncoding="utf-8" Codebehind="announce.aspx.cs" %>
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
  <table id="top1" width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
    <tr>
      <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">公告管理</strong></td>
      <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" />公管管理</div></td>
    </tr>
  </table>
  <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
    <tr>
      <td  style="padding-left:12px;"><a href="announce.aspx" class="topnavichar">公告列表</a></td>
    </tr>
  </table>
  <div id="no" runat="server"></div>
  <table width="100%" align="center">
  <tr>
    <td><div>
        <asp:Repeater ID="DataList1" runat="server">
          <HeaderTemplate>
            <table width="100%" border="0" align="center" cellpadding="4" cellspacing="1" class="liebtable">
            <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
              <th class="sys_topBg" width="60%">标题</th>
              <th class="sys_topBg" width="40%">发布日期</th>
            </tr>
          </HeaderTemplate>
          <ItemTemplate>
            
              <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
                <td align="left" valign="middle"><span class="span1"><%#((DataRowView)Container.DataItem)["titles"]%></span></td>
                <td align="center" valign="middle"><%#((DataRowView)Container.DataItem)["creatTimes"]%></td>
              </tr>
            <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
              <td colspan="3"><span class="span1" color="#999999"><%#((DataRowView)Container.DataItem)["contents"]%></span></td>
            </tr>
          </ItemTemplate>
          <FooterTemplate>
            </table>
          </FooterTemplate>
        </asp:Repeater>
      </div></td>
  </tr>
  <tr>
    <td align="right" style="width: 928px"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></td>
  </tr>
  </table>
  <div style="width:98px;padding-left:10px;"></div>
  <br />
  <br />
  <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
    <tr>
      <td align="center"><%Response.Write(CopyRight); %></td>
    </tr>
  </table>
</form>
</body>
</html>
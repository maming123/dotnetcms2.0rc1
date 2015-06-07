<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_info_applyads" Codebehind="applyads.aspx.cs" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
	<link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body class="main_big">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0"  class="toptable">
    <tr>
      <td width="57%" class="sysmain_navi"  style="PADDING-LEFT: 14px" Height="30"></td>
      <td width="43%"  class="topnavichar"  style="PADDING-LEFT: 14px" ><div align="left">λõ<a href="../main.aspx" target="sys_main" class="list_link">ҳ</a><img alt="" src="../images/navidot.gif" border="0" /></div></td>
    </tr>
    </table>
   <table width="100%" border="0" cellpadding="3" cellspacing="1" class="Navitable" align="center">
      <tr>
        <td style="padding-left:15px;"><a href="applyads_add.aspx" class="topnavichar"></a></td>
      </tr>
    </table>    <asp:Repeater ID="DataList1" runat="server">
       <HeaderTemplate>
        <table width="98%" border="0" align="center" cellpadding="4" cellspacing="1" class="liebtable">
            <tr class="TR_BG">
            <td class="sys_topBg"></td>
            <td class="sys_topBg"></td>
            <td class="sys_topBg"></td>
            <td class="sys_topBg">ʾ</td>
            <td class="sys_topBg">ʱ</td>
            <td class="sys_topBg">ʱ</td>
           <td class="sys_topBg">״̬</td>
            </tr>
        </HeaderTemplate>
          <ItemTemplate>
            <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
            <td align="left" valign="middle"><%#((DataRowView)Container.DataItem)[1]%></td>
            <td align="left" valign="middle"><%# GetAdsType(((DataRowView)Container.DataItem)[2].ToString())%></td>
            <td align="left" valign="middle"><%#((DataRowView)Container.DataItem)[3]%></td>
            <td align="left" valign="middle"><%#((DataRowView)Container.DataItem)[4]%></td>
            <td align="left" valign="middle"><%#((DataRowView)Container.DataItem)[5]%></td>
            <td align="left" valign="middle"><%#((DataRowView)Container.DataItem)[7]%></td>
            <td align="left" valign="middle"><%# GetAdsMode(((DataRowView)Container.DataItem)[6].ToString())%></td>
            </tr>
          </ItemTemplate>
          <FooterTemplate>
          </table>
         </FooterTemplate>
    </asp:Repeater> 
    <div style="width:98%;" align="right"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
    <br />
    <br />
    <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
       <tr>
         <td align="center"><label id="copyright" runat="server" /></td>
       </tr>
    </table>
    </form>
</body>
</html>

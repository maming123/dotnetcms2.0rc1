<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_info_url" Codebehind="url.aspx.cs" %>
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
<body class="main_big"><form id="form1" runat="server">
    <table id="top1" width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
            <tr>
              <td height="1" colspan="2"></td>
            </tr>
            <tr>
              <td width="57%" class="sysmain_navi" style="padding-left:14px;">ַղؼ</td>
              <td width="43%">λõ<a href="../main.aspx" class="list_link" target="sys_main">ҳ</a><img alt="" src="../images/navidot.gif" border="0" /><a href="url.aspx" class="list_link" target="sys_main">ַղؼ</a><img alt="" src="../images/navidot.gif" border="0" />б</td>
            </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
      <tr>
        <td  style="padding-left:12px;"><a href="url.aspx" class="topnavichar">ַб</a>   <a href="url_add.aspx" class="topnavichar">ַ</a>   <a href="url_class.aspx" class="topnavichar"></a>   <a href="javascript:void(0);" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('<%Response.Write(fURL); %>');" style="cursor:pointer;" class="topnavichar"><span style="color:Red">ַΪҳ</span></a>  <a href="../url.aspx?uid=<%Response.Write(myUID); %>" target="_blank" class="topnavichar">ҵַ</a> </td>
      </tr>
      </table>
    <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="table">
      <tr>
        <td>
        ࣺ<span id="URLClassList" runat="server" />
        </td>
      </tr>
      </table>
      <div id="no" runat="server"></div>
      
 <table width="98%" align="center">
 <tr><td>
<div>   
    <asp:Repeater ID="DataList1" runat="server">
       <HeaderTemplate>
        <table width="100%" border="0" align="center" cellpadding="4" cellspacing="1" class="liebtable">
            <tr class="TR_BG">
            <td class="sys_topBg" style="width:40%">վ</td>
            <td class="sys_topBg"></td>
            <td class="sys_topBg"></td>
            </tr>
        </HeaderTemplate>
          <ItemTemplate>
            <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
            <td align="left"><%#((DataRowView)Container.DataItem)["URLNames"]%></td>
            <td align="left"><%#((DataRowView)Container.DataItem)["CreatTime"]%></td>
            <td align="left"><%#((DataRowView)Container.DataItem)["op"]%></td>
            </tr>
          </ItemTemplate>
          <FooterTemplate>
          </table>
         </FooterTemplate>
    </asp:Repeater> 
</div>
</td></tr>
<tr><td align="right" style="width: 928px">
    <uc1:PageNavigator ID="PageNavigator1" runat="server" />
</td></tr>
</table>  
<div style="width:98px;padding-left:10px;"></div>
<br />
<br />
 <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
   <tr>
     <td align="center"><%Response.Write(CopyRight); %> </td>
   </tr>
</table>
</form>
</body>
</html>
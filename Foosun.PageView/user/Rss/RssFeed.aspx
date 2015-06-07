<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_Rss_RssFeed" Codebehind="RssFeed.aspx.cs" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    </head>
<body class="main_big">
  <form id="form1" name="form1" method="post" action="" runat="server">
<table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
  <tr>
     <td><span class="topnavichar" style="PADDING-LEFT: 5px"><a href="RSS.aspx" class="menulist">֪</a>&nbsp;&nbsp;<a href="RssFeed.aspx" class="menulist">RSS</a></span></td>
  </tr>
</table>
<div id="no" runat="server"></div>
    <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" class="liebtable">
        <tr class="TR_BG_list">
            <td align="left" style="width:20%;padding-left:10px;" colspan="2"><label id="Newsxml" runat="server" /></td>
        </tr>
    </table>
     <asp:Repeater ID="DataList1" runat="server" >
    <HeaderTemplate>
    <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" class="liebtable">
    <tr class="TR_BG">
     <th class="sys_topBg" align="left" style="width:20%; padding-left:10px;">Ŀ</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
     <tr class="TR_BG">
        <td align="left" valign="top" style="border-bottom:1px solid  #e4dfdf;padding-left:10px;">
        <%#((DataRowView)Container.DataItem)["pic"]%>&nbsp;&nbsp;<span class="sysmain_navi"><%#((DataRowView)Container.DataItem)["ClassCNames"]%></span>&nbsp;&nbsp;<a href="<%#((DataRowView)Container.DataItem)["url"]%>" target="_blank" class="list_link"><%#((DataRowView)Container.DataItem)["url"]%></a>
        <br />
        <div class="tabdiv">
            <ul>
                <%#((DataRowView)Container.DataItem)["xmllist"]%>
            </ul>
         </div>
       </td>          
        </tr>

     </ItemTemplate>
     <FooterTemplate>
     </table>
     </FooterTemplate>
    </asp:Repeater>
<table width="98%" border="0" align="center" cellpadding="3" cellspacing="2" style="height: 20px">
<tr><td align="left">
        <span style="color: #ff0000">ѣIE5.0ûͼƬRSSۺϵַFireFoxûֱӸϵַ</span></td><td align="right">
    <uc1:PageNavigator ID="PageNavigator1" runat="server" />
</td></tr>
</table> 
<br />    
<br />    
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %> </div></td>
  </tr>
</table>
</form>
</body>
<script type="text/javascript" language="JavaScript">   
function copyToClipBoard(url)
{ 
    
	var ie4=document.all&&navigator.userAgent.indexOf("Opera")==-1
	var ns6=document.getElementById&&!document.all
    if (ie4)
    {
        var clipBoardContent=url;
        window.clipboardData.setData("Text",clipBoardContent);
        alert("ַƳɹ!\nַ"+url+"");
    }
    else
    {
        alert("FireFoxûֱӸƵַ!");
    }
}
</script>
</html>

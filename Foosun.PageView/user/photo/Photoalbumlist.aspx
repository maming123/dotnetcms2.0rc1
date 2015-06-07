<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" AutoEventWireup="true" Inherits="user_photo_Photoalbumlist" Codebehind="Photoalbumlist.aspx.cs" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
	
</head>
<body class="main_big"><form id="form1" name="form1" method="post" action="" runat="server"> 
<table width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
          <td height="1" colspan="2"></td>
        </tr>
        <tr>
          <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">相册管理</strong></td>
    <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" />相册管理</div></td>
        </tr>
</table>
<table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
  <tr>
     <td><span class="topnavichar" style="PADDING-LEFT: 14px"><a href="Photoalbumlist.aspx" class="menulist">相册首页</a>&nbsp;┊&nbsp;<a href="photo_add.aspx" class="menulist">添加图片</a>&nbsp;┊&nbsp;<a href="photoclass.aspx" class="menulist">相册分类</a> &nbsp;┊&nbsp;<a href="Photoalbum.aspx" class="menulist">添加相册</a>&nbsp;┊&nbsp; <span id="sc" runat="server"></span></span>
     </td>
  </tr>
</table>
<div id="no" runat="server"></div>
  <asp:Repeater ID="Repeater1" runat="server" >
    <HeaderTemplate>
    <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" class="liebtable">
    <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
    <th class="sys_topBg" align="center" width="2%"></th>
    <th class="sys_topBg" align="center">相册名称</th>
    <th class="sys_topBg" align="center" width="16%">创建日期</th>
    <th class="sys_topBg" align="center" width="20%">拥有人</th>
    <th class="sys_topBg" align="center" width="20%">操作&nbsp; &nbsp;<input type="checkbox" name="Checkbox1_" onclick="javascript:selectAll(this.form,this.checked)" /></th>
    </tr>
    <div id="tnzlist" runat="server"></div>
    </HeaderTemplate>
    <ItemTemplate>
       <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">        
        <td align="center" width="2%"><%#((DataRowView)Container.DataItem)["Pwd"]%></td>
        <td align="center" title="点集查看相册"><%#((DataRowView)Container.DataItem)["PhotoalbumNames"]%>(<%#((DataRowView)Container.DataItem)["picnum"]%>)</td>
        <td align="center" width="16%"><%#((DataRowView)Container.DataItem)["Creatime"]%></td>
        <td align="center" width="20%"><a href="../ShowUser.aspx?uid=<%#((DataRowView)Container.DataItem)["UserNames"]%>" target="_blank" class="list_link"><%#((DataRowView)Container.DataItem)["UserNames"]%></a></td>
        <td align="center" width="20%"><%#((DataRowView)Container.DataItem)["idc2"]%></td>           
        </tr>
     </ItemTemplate>
     <FooterTemplate>
     </table>
     </FooterTemplate>
    </asp:Repeater>
<table width="98%" border="0"  align="center" cellpadding="3" cellspacing="2" style="height: 20px">
<tr><td align="right" style="width: 928px"><uc1:PageNavigator ID="PageNavigator3" runat="server" /></td></tr>
</table>
<br />
<br />
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %>  </div></td>
  </tr>
</table>
</form>
</body>
<script language="javascript" type="text/javascript">
function del(ID,DidID)
{
   if(confirm("删除此相册将删除此相册下的所有照片，你确定要删除吗?"))
   { 
        self.location="?Type=del&ID="+ID;
   }
}
function PDel()
{
    if(confirm("你确定要彻底删除吗?"))
    {
	    document.form1.action="?Type=PDel";
	    document.form1.submit();
	}
}
</script>
</html>







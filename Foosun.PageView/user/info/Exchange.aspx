<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" AutoEventWireup="true" Inherits="user_Exchange" Codebehind="Exchange.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
function Change(o)
{
     var t;
      if(o==0)
      {
        t = "确定兑换成G币吗？";
      }
      else
      {
        t = "确定兑换成积分吗？";
      }
      {if(confirm(t)){return true;}return false;}
}
</script>
</head>
<body class="main_big"><form id="form1" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
          <td height="1" colspan="2"></td>
        </tr>
        <tr>
          <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">积分兑换</strong></td>
    <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" />积分兑换</div></td>
        </tr>
</table>
      <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
        <tr>
          <td style="padding-left:14px;"><span id="scs" runat="server"></span>  <span id="sc" runat="server"></span></td>
        </tr>
</table>
<%
string types = Request.QueryString["types"];
if ((type == "G" && types == null) || (type == null && types == "G"))
{
%>
<asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
<%} %>
<% else
{ %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

<%} %>  

<br />
<br />
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %> </div></td>
  </tr>
</table>
</form>
</body>
</html>


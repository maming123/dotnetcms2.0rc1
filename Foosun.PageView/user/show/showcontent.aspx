<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_show_showcontent" Codebehind="showcontent.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <title>
<%Response.Write(Foosun.Config.UIConfig.HeadTitle); %>__文章</title>
<link href="../../sysImages/<%Response.Write(Foosun.Config.UIConfig.CssPath()); %>/css/divcss.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top:6px;">
<form id="form1" runat = "Server">
     
          <div style="line-height:30px;" class="toptable"><span id="contentClass" style="padding-left:14px;width:98%;" runat="server"></span>位置：浏览文章
          </div>
          <div  style="width:98%;padding-top:12px;height:20px;position:relative;border-right-width: 1px;border-bottom-width: 1px;border-left-width: 1px;border-right-style: none;border-bottom-style: none;border-left-style: none;"></div>
          <div id="div_title" style="padding-left:14px;height:30px;font-weight: bold;width:98%;text-align:center;font-size:16px;" runat="server"></div>
          <div id="div_other" style="padding-left:14px;height:20px;width:98%;text-align:center;font-size:12px;" runat="server"></div>
          <br /><div id="div_Content" style="padding-left:14px;width:98%;font-size:14px;line-height:25px;" runat="server"></div>
          <div id="div_tags" align="right" style="padding-left:14px;width:98%;font-size:14px;line-height:25px;" runat="server"></div>

      
</form>
     <br />
     <br />
  <table width="100%" style="height:74px;" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
    <tr>
      <td  class="list_link" align="center"><label id="copyright" runat="server" /></td>
    </tr>
  </table>
  </body>
</html>

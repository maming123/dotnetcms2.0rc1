<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showJsPath.aspx.cs" Inherits="Foosun.PageView.manage.advertisement.showJsPath" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>广告代码</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
</head>
<body class="TR_BG_list">
<form id="form1" runat="server">
  <table width="90%" border="0" align="center" cellpadding="0" cellspacing="1" class="nxb_table">
    <tr>
      <td colspan="2" class="list_link">该JS调用代码为:</td>
    </tr>
    <tr>
      <td colspan="2" class="list_link">
          <textarea name="textfield" style="width:98%;height:80px;" id="CodePath" runat="server" class="textarea4" cols="20" rows="4"></textarea>
        </td>
    </tr>
    <tr>
      <td class="list_link" style="padding-top:14px;padding-bottom:14px;"><div align="center">
          <input type="button" name="Submit" value=" 关 闭 " onClick="window.close();" class="form">
        </div></td>
      <td class="list_link" style="padding-top:14px;padding-bottom:14px;"><div align="center">
          <input type="button" name="copy" value=" 复 制 " onClick="copyToClipBoard();"  class="form">
        </div></td>
    </tr>
  </table>
</form>
</body>
<script  language="JavaScript">   
function copyToClipBoard()
{ 
    if(confirm("确定复制到剪贴板吗?\n如果你是火狐(FireFox)浏览器用户，请直接复制以上代码!"))
    {
        var clipBoardContent=document.getElementById("CodePath").value;
        window.clipboardData.setData("Text",clipBoardContent);
	}
		alert("复制成功");
}
</script>
</html>

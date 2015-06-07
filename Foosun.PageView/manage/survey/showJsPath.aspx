<%@ Page Language="C#" AutoEventWireup="true" Inherits="showJsPath" Codebehind="showJsPath.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="mian_body">
  <div class="mian_wei">
   <div class="newxiu_base">
  <table class="nxb_table">
    <tr>
      <td colspan="2">该JS调用代码为:</td>
    </tr>
    <tr>
      <td colspan="2" width="15%" align="right">
       <textarea name="textfield" style="width:98%;height:80px;" id="CodePath" runat="server" class="textarea4" cols="20" rows="4"></textarea>
        </td>
    </tr>
  </table>
    <div class="nxb_submit" >
          <input type="button" name="Submit" value=" 关 闭 " onClick="window.close();" class="xsubmit1">
          <input type="button" name="copy" value=" 复 制 " onClick="copyToClipBoard();"  class="xsubmit1">
    </div>s
  </div>
  </div>
  </div>
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

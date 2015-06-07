<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" AutoEventWireup="true" Inherits="user_discussTopi_add" EnableEventValidation="true" Codebehind="discussTopi_add.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
	<link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
     <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
        <script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea[name="ContentBox"]', {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
    });
    $(function () {
        $("#voteTime").datepicker({ changeMonth: true, changeYear: true });
    }); 
    </script>
</head>
<body class="main_big">
<form id="form1" name="form1" method="post" action="" runat="server">
<div id="sc" runat="server"></div>

<table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" class="table" id="addmanage">
  <tr class="TR_BG_list">
    <td class="list_link" Width="20%" style="text-align: right">
        讨论主题：</td>
    <td class="list_link" Width="80%">
        <asp:TextBox ID="Title" runat="server" Width="314px" CssClass="form"></asp:TextBox>&nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_discussTopi_add_0001',this)">帮助</span>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title"
            ErrorMessage="请输入讨论主题名称"></asp:RequiredFieldValidator></td>
  </tr>

    <tr class="TR_BG_list">
    <td class="list_link" Width="25%" style="text-align: right">
        讨论内容：</td>
    <td class="list_link" Width="75%">
	<textarea rows="1" cols="1" name="ContentBox" style="width:90%;height:200px;visibility:hidden;" id="ContentBox" runat="server" ></textarea>
</td>
  </tr>
    <tr class="TR_BG_list">
    <td class="list_link" Width="25%" style="text-align: right">
        来源：</td>
    <td class="list_link" Width="75%">
        <input id="source1" type="radio" onclick="DispChanges()" runat="server" checked="true"/>
        原 创 &nbsp; 
        <input id="source2" type="radio" onclick="DispChanges()" runat="server"/>
        转 载</td>
      </tr>  
    <tr class="TR_BG_list" style="display:none" id="url">
    <td class="list_link" Width="25%" style="height: 12px; text-align: right;" >
        来源地址：</td>
    <td class="list_link" Width="75%" style="height: 12px">
        <asp:TextBox ID="DtUrl" runat="server" Width="320px" CssClass="form"></asp:TextBox>&nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_discussTopi_add_0002',this)">帮助</span></td>
  </tr>
  
      <tr class="TR_BG_list">
    <td class="list_link" Width="25%" style="text-align: right">
        过期日期：</td>
    <td class="list_link" Width="75%">
        <asp:TextBox ID="voteTime" runat="server" Width="321px" CssClass="form"></asp:TextBox></td>
  </tr>
 
   <tr class="TR_BG_list">
    <td class="list_link"></td>
    <td class="list_link">
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="but1" runat="server" Text="提  交" OnClick="but1_Click" CssClass="form" />
        &nbsp; &nbsp;&nbsp;
        <input type="reset" name="Submit3" value="重  置" class="form"></td>  
   </tr>
</table>
<br />
<br />
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %></div></td>
  </tr>
</table>
</form>
</body>
</html>
<script language="javascript" type="text/javascript">
function DispChanges()
{
    var obj = document.getElementById("source1").checked;
    var objs = document.getElementById("source2").checked;
    if(objs)
    {
            document.getElementById("url").style.display="";
    }
    if(obj)
    {
            document.getElementById("url").style.display="none";
    }
}
</script>
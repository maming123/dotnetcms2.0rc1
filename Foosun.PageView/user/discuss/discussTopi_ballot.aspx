<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" AutoEventWireup="true" Inherits="user_discussTopi_ballot" EnableEventValidation="true" Codebehind="discussTopi_ballot.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
 <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<title></title>
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
<table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" class="table">
  <tr class="TR_BG_list">
    <td class="list_link" Width="20%" style="text-align: right">
        投票主题：</td>
    <td class="list_link" Width="80%">
        <asp:TextBox ID="Title" runat="server" Width="314px" CssClass="form"></asp:TextBox>&nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_discussTopi_ballot_0001',this)">帮助</span>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title"
            ErrorMessage="投票主题不能为空名称"></asp:RequiredFieldValidator></td>
  </tr>

    <tr class="TR_BG_list">
    <td class="list_link" Width="25%" style="text-align: right">
        投票内容：</td>
    <td class="list_link" Width="75%">
	<textarea rows="1" cols="1" name="ContentBox" style="width:90%;height:200px;visibility:hidden;" id="ContentBox" runat="server" ></textarea>
        </td>
  </tr>
  
    <tr class="TR_BG_list">
    <td class="list_link" Width="25%" style="text-align: right">
        投票项目：</td>
    <td class="list_link" Width="75%">
    <asp:TextBox ID="Voteitem" runat="server" Height="106px" TextMode="MultiLine" Width="316px" CssClass="form"></asp:TextBox>&nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_discussTopi_ballot_0002',this)">帮助</span>
     
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Voteitem"
            ErrorMessage="投票项目不能为空"></asp:RequiredFieldValidator></td>
  </tr>
    <tr class="TR_BG_list">
    <td class="list_link" Width="25%" style="text-align: right">
        投票类型：</td>
    <td class="list_link" Width="75%">
        <asp:RadioButtonList ID="votegenresds" runat="server" RepeatDirection="Horizontal"
            Width="321px">
            <asp:ListItem Value="0" Selected="True">单  选</asp:ListItem>
            <asp:ListItem Value="1">多  选</asp:ListItem>
        </asp:RadioButtonList></td>
      </tr>   
      <tr class="TR_BG_list">
    <td class="list_link" Width="25%" style="text-align: right">
        过期日期：</td>
    <td class="list_link" Width="75%">
        <asp:TextBox ID="voteTime" runat="server" Width="321px" CssClass="form"></asp:TextBox>&nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_discussTopi_add_0003',this)">帮助</span>
       </td>
  </tr>
 
   <tr class="TR_BG_list">
    <td class="list_link"></td>
    <td class="list_link">
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="but1" runat="server" Text="提  交" OnClick="but1_Click" CssClass="form" />
        &nbsp; &nbsp;&nbsp;
        <input type="reset" name="Submit3" value="重  置" class="form"/></td>  
   </tr>
</table>
<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
  <tr>
    <td><div align="center"><%Response.Write(CopyRight); %></div></td>
  </tr>
</table>
</form>
</body> 
</html>

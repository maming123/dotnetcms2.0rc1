<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="announceadd.aspx.cs" ValidateRequest="false" Inherits="Foosun.PageView.manage.user.announceadd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea[name="content"]', {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
    });
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>增加/修改公告</h3></div>
      <div class="mian_wei_right">
         导航：<a href="javascript:openmain('../main.aspx')">首页</a>><a href="announce.aspx">公告管理</a>>>修改/新增公告
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="20%" align="right">标题：</td>
               <td>
                  <asp:TextBox class="input8" ID="title" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                      ID="RequiredFieldValidator1" runat="server" ErrorMessage="标题不能为空"  Display="Dynamic"
                       ControlToValidate="title"></asp:RequiredFieldValidator>
                  <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_announce_add_0001',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">内容：</td>
               <td>
                   <div class="textdiv">
                      <textarea class="textarea1" id="content" name="content" runat="server"> </textarea>
                      <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_announce_add_0002',this)">帮助</span>
                   </div>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">点数/条件：</td>
               <td>
                   <asp:TextBox class="input8" ID="getPoint" runat="server" Text="0|0|0"></asp:TextBox>
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_announce_add_0003',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">会员组：</td>
               <td>
                  <label id="GroupList" runat="server" />
                  <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_announce_add_0004',this)">帮助</span>
               </td>
             </tr>
           </table>
            <div class="nxb_submit" >
                <asp:Button ID="buttons" runat="server" class="xsubmit1 mar" Text=" 确 定 "  OnClick="sumbitsave" />
                <input name="reset" type="reset" value=" 重 置 "  class="xsubmit1 mar" />
                 <asp:HiddenField ID="aId" runat="server" />
             </div>
        </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>
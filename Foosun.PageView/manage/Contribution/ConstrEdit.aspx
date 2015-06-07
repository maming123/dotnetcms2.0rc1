<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConstrEdit.aspx.cs" ValidateRequest="false" Inherits="Foosun.PageView.manage.Contribution.ConstrEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>编辑稿件</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea[name="content"]', {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
    });
    </script>
</head>

<body>
<div id="dialog-message" title="提示"></div>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>投稿管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="ConstrList.aspx">稿件管理</a> >>稿件审核
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <span><a href="ConstrList.aspx">稿件管理</a>┊<a href="ConstrStat.aspx"> 稿件统计</a>┊<a href="ConstrList.aspx?type=cheack">所有通过审核稿件</a></span>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table" id="ishow" runat="server">
             <tr>
               <td width="10%" align="right">稿件名称：</td>
                    <td>
                    <asp:TextBox ID="Title" runat="server" class="input8"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title" ErrorMessage="请输入稿件名称"></asp:RequiredFieldValidator>                      
                    </td>
             </tr>
             <tr>
                <td width="10%" align="right">稿件内容：</td>
                <td>
                    <div class="textdiv1">
                      <textarea name="content" id="content" runat="server" style="width:90%;height:200px;visibility:hidden;"></textarea>
                    </div>
                </td>
             </tr>
             <tr id="tr" runat="server">
                <td width="10%" align="right">图片：</td>
                <td>
                    <div class="textdiv"  id="showimg" runat="server">
                      
                    </div>
                </td>
             </tr>
             <tr>
                <td width="10%" align="right">作者：</td>
                <td><asp:Label ID="Author" runat="server" Width="160px"></asp:Label></td>
             </tr>
             <tr>
                <td width="10%" align="right">关 键 字：</td>
                <td><asp:TextBox ID="Tags" runat="server" class="input8"></asp:TextBox></td>
             </tr>
            
           </table>
           <table class="nxb_table">
            <tr>
                <td width="10%" align="right">栏目：</td>
                <td>
                <asp:TextBox ID="ClassCName" runat="server" class="input8"></asp:TextBox>
                   <a href="javascript:selectFile('ClassCName,ClassID','栏目选择','newsclass',400,300)"><img src="../imges/bgxiu_14.gif"  align="middle" alt=""  class="img1"  /></a><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ClassCName" ErrorMessage="栏目不能为空"></asp:RequiredFieldValidator>
				<asp:HiddenField runat="server" ID="ClassID" />
                </td>
             </tr>
              <tr>
                <td width="10%" align="right">稿酬(积分)：</td>
                <td><asp:TextBox ID="paynum" runat="server" class="input8" Text="1"></asp:TextBox> <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="积分为1-10000的必须为正整数!"
                        Type="Integer" ControlToValidate="paynum" Display="Dynamic" MaximumValue="10000" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator></td>
             </tr>
           </table>
           <div class="nxb_submit" >
               <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" class="insubt" />
               <input type="reset" name="bc" value="重置" class="insubt"/>
           </div>
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createLabelSpecial.aspx.cs" Inherits="Foosun.PageView.configuration.system.createLabelSpecial" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>专题信息类</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/popup_window.css"/>

<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea[name="UserDefined"]', {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
    });
    function CloseDiv() {
        parent.parent.$('#dialog-message').dialog("close");
    }
    function getValue(value) {
        editor.insertHtml(value);
    }
    function setValue(value) {
        if (value == "") {
            return;
        }
        editor.insertHtml('{#FS:define=' + value + '}');
    }
    function getType() {
        $("#ClassName").val("自适应");
        return;
    }
    function ReturnDivValue() {
        var CheckStr = true;
        var rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=ReadSpecial";
        if ($('#ClassId').val() != '') {
            rvalue += ",FS:SpecialID=" + $('#ClassId').val();
        }
        temproot = editor.html();
        rvalue += "]";
        rvalue += temproot;
        rvalue += "[/FS:unLoop]";

        if (CheckStr)
            parent.parent.getValue(rvalue);
    }
</script>
</head>

<body>
<div id="dialog-message" title="提示"></div>
<form id="ListLabel" runat="server">
         <div class="newxiu_base">
           <table class="nxb_table" width="99%">
             <tr>
               <td width="15%" align="right">专题ID ：</td>
               <td>
                  <div class="neitab1">
                     <input type="text" id="ClassName" name="" value="" class="input6" /><input id="ClassId" type="hidden" />
                     <a href="javascript:selectFile('ClassName,ClassId','专题信息','special','400','300');"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a>
                     调用类型：<a href="javascript:getType()" class="a2">自适应</a><br />
                     <span style="color:#00F">类型"自适应"为标签所在栏目符合条件的新闻,若选择为空或栏目不存在，则调用所有符合条件的新闻。</span>
                   </div>
               </td>
             </tr>
              <tr>
               <td width="15%" align="right"></td>
               <td>
                  <label id="style_class" runat="server" />
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">自定义样式：</td>
               <td>
                  <div class="neitab2">
                 
                   <textarea rows="1" cols="1" name="UserDefined" id="UserDefined" runat="server" style="width:90%;height:200px;visibility:hidden;"></textarea>
                  </div>
               </td>
             </tr>  
           </table>
           <div class="nxb_submit" >
               <input type="button" name="bc" onclick="javascript:ReturnDivValue()" value="确定" class="insubt"/>
               <input type="button" name="bc" onclick="CloseDiv()" value="关闭" class="insubt"/>
           </div>
         </div>
         </form>
</body>
</html>
                                
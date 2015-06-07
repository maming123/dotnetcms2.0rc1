<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createLabel_Browse.aspx.cs" Inherits="Foosun.PageView.configuration.system.createLabel_Browse" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>浏览类</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
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
    function selectRoot(type) {
        if (type == "false")
        { document.getElementById("TrStyleID").style.display = "none"; document.getElementById("TrUserDefined").style.display = ""; }
        else
        { document.getElementById("TrStyleID").style.display = ""; document.getElementById("TrUserDefined").style.display = "none"; }
    }
    function ReturnDivValue() {
        var CheckStr = true;
        if (document.ListLabel.Root.value == "true") {
            if (checkIsNull(document.ListLabel.StyleID, document.getElementById("sapnStyleID"), "请选择样式"))
                CheckStr = false;
        }
        var rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=ReadNews";
        if (document.ListLabel.Root.value == "true")
        { temproot = "[#FS:StyleID=" + document.ListLabel.StyleID.value + "]"; }
        else {
            temproot = editor.html();
        }
        rvalue += "]";
        rvalue += temproot;
        rvalue += "[/FS:unLoop]";

        if (CheckStr)
            parent.parent.getValue(rvalue);
    }
    function CloseDiv() {
        parent.parent.$('#dialog-message').dialog("close");
    }
    function checkIsNull(obj, spanobj, error) {
        if (obj.value == "") {
            spanobj.innerHTML = "<span class=reshow>(*)" + error + "</spna>";
            return true;
        }
        return false;
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
    function insertHTMLEdit(url) {
        var urls = url.replace('{@dirfile}', '<% Response.Write(Foosun.Config.UIConfig.dirFile); %>')
        editor.insertHtml("<img src=\"' + urls + '\" border=\"0\" />");
        return;
    }
    function ShowStyle() {
        if (document.getElementById("showOther").style.display == "none") {
            document.getElementById("showOther").style.display = "";
        }
    }
    function savePostStyle() {
        var saveStyle = document.getElementById("saveStyle");
        var sname = document.getElementById("StyleName");
        var StyleClassID = document.getElementById("StyleClassID");
        if (sname.value == "") {
            alert('请填写样式名称');
            sname.focus();
            return false;
        }
        if (StyleClassID.value == "") {
            alert('请选择分类，如果没有分类，请在样式中创建');
            return false;
        }
        var gtemproot = editor.html();
        var actionstr = "StyleName=" + escape(sname.value) + "&ClassID=" + escape(StyleClassID.value) + "&Content=" + escape(gtemproot) + "";
        $.ajax({
            type: "POST",
            url: "SaveStyle.aspx",
            async: false,
            //是否ajax同步       
            data: actionstr,
            success: function (data) {
                $('#sResultHTML').html(data);
            }
        });
    }
</script>
</head>

<body>
<div id="dialog-message" title="提示"></div>
 <form id="ListLabel" runat="server">
         <div class="newxiu_base">
           <table class="nxb_table" width="99%">
             <tr>
               <td width="15%" align="right">引用样式：</td>
               <td>
                  <select class="select3" id="Root" onchange="javascript:selectRoot(this.value);">
                  <option value="true">固定样式</option>
                  <option value="false">自定义样式</option>
                  </select><label id="TrStyleID">引用样式<input id="StyleID" type="text" name="" value="" class="input8" />
                  <a href="javascript:selectFile('StyleID','样式选择','style','400','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a><span id="sapnStyleID"></span></label>
               </td>
             </tr>
              <tr id="TrUserDefined" style="display: none;">
               <td width="15%" align="right">
                自定义样式：<br />
                  <input type="button" onclick="ShowStyle();"  name="hfg" value="保存样式" class="xsubmit2"/>
                  <div id="showOther" style="display: none;">
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<asp:TextBox ID="StyleName" Width="94px" runat="server"></asp:TextBox>
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<asp:DropDownList ID="StyleClassID" Width="100px" runat="server">
					</asp:DropDownList>
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<input name="saveStyle" id="saveStyle" value="保存" type="button" class="insubt2" onclick="savePostStyle();" />
					<div id="sResultHTML" class="reshow">
					</div>
				</div>
               </td>
               <td>
               <label id="style_base" runat="server" />
					<label id="style_class" runat="server" />
					<label id="style_special" runat="server" />
					<asp:DropDownList ID="define" class="select7" runat="server"  onchange="javascript:setValue(this.value);">
						<asp:ListItem Value="">自定义字段</asp:ListItem>
					</asp:DropDownList>   
                     <div class="neitab2">
                   <textarea rows="1" cols="1" name="UserDefined" id="UserDefined" runat="server" style="width:90%;height:200px;visibility:hidden;"></textarea>
                  </div>            
               </td>
             </tr>
           </table>
           <div class="nxb_submit" >
               <input type="button" name="bc" value="保存" onclick="javascript:ReturnDivValue();" class="insubt"/>
               <input type="button" name="bc" value="关闭" class="insubt" onclick="javascript:CloseDiv();" />
           </div>
         </div>
</form>
</body>
</html>

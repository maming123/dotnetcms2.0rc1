<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectLabelStyle.aspx.cs" Inherits="Foosun.PageView.configuration.system.selectLabelStyle" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>选择样式</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
		<style type="text/css">
		.LableSelectItem
		{
			background-color: highlight;
			cursor: hand;
			color: white;
			text-decoration: none;
		}
		.LableItem
		{
			cursor: hand;
		}
		.SubItems
		{
			margin-left: 12px;
		}
		.RootItem
		{
			margin-top:10px;
		}
		body
		{
			margin-left: 0px;
			margin-top: 0px;
			margin-right: 0px;
			margin-bottom: 0px;
		}
	</style>
</head>
<body ondragstart="return false;" onselectstart="return false;">
	<form name="form1">
	样式：<input type="text" id="styleID" readonly name="styleID" style="width: 50%" />&nbsp;<input type="button" class="xsubmit1" name="Submit" value="选择样式" onclick="ReturnValue(document.form1.styleID.value);" />
	<div id="styleList" runat="server" class="RootItem">
		样式加载中...
	</div>
	</form>
</body>
</html>
<script type="text/javascript">
    var SelectClass = "";
    function SwitchImg(ImgObj, ParentId) {
        var ImgSrc = "", SubImgSrc;
        ImgSrc = ImgObj.src;
        SubImgSrc = ImgSrc.substr(ImgSrc.length - 5, 12);
        if (SubImgSrc == "b.gif") {
            ImgObj.src = ImgObj.src.replace(SubImgSrc, "s.gif");
            ImgObj.alt = "点击收起子样式";
        } else {
            if (SubImgSrc == "s.gif") {
                ImgObj.src = ImgObj.src.replace(SubImgSrc, "b.gif");
                ImgObj.alt = "点击展开子样式";
            } else {
                return false;
            }
        }
    }
    function sFiles(obj) {
        document.form1.styleID.value = obj;
    }

    function ReturnValue(obj) {
        var Str = obj;
        var controlName = '<%= Request["controlName"]%>';
        parent.parent.$('#'+controlName).val(Str);
        parent.parent.$('#dialog-message').dialog("close");
    }
    function opencat(cat) {
        if (cat.style.display == "none") {
            cat.style.display = "";
        } else {
            cat.style.display = "none";
        }
    }

    function getReview1(id) {
        if (document.getElementById(id).style.display == "") {
            document.getElementById(id).style.display = "none";
        }
        else {
            document.getElementById(id).style.display = "";
        }
    }
</script>

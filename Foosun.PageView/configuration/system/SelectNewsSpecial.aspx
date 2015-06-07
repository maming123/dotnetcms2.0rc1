<%@ Page Language="C#" AutoEventWireup="true" Inherits="SelectNewsSpecial" Codebehind="SelectNewsSpecial.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>选择专题__By Foosun.net & Foosun Inc.</title>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
   <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<style  type="text/css">
.LableSelectItem {
	background-color:highlight;
	cursor: pointer;
	color: white;
	text-decoration: none;
}
.LableItem {
	cursor: pointer;
}
.SubItem {
	margin-left:15px;
}
.RootItem {
	font-size:12px;
	width:98%;
	line-height:24px;
	margin:10px 0;
}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
</style>
</head>

<body ondragstart="return false;" onselectstart="return false;">
    <form name="form1">
    地址：<input type="text" id="SpcName" readonly="readonly" name="SpcName" style="width:50%" />&nbsp;<input type="button" class="xsubmit1" name="Submit" value="确定" onclick="ReturnValue();" />
    <input type="hidden" name="SpcID" id="SpcID" />
    <div id="Parent0" class="RootItem">
    专题加载中...
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
<!--
var SelectClass="";
function SwitchImg(ImgObj,ParentId){
	var ImgSrc="",SubImgSrc;
	ImgSrc=ImgObj.src;
	SubImgSrc=ImgSrc.substr(ImgSrc.length-5,12);
	if (SubImgSrc=="b.gif"){
		ImgObj.src=ImgObj.src.replace(SubImgSrc,"s.gif");
		ImgObj.alt="点击收起子专题";
		SwitchSub(ParentId,true);
	}else{
		if (SubImgSrc=="s.gif"){
			ImgObj.src=ImgObj.src.replace(SubImgSrc,"b.gif");
			ImgObj.alt="点击展开子专题";
			SwitchSub(ParentId,false);
		}else{
			return false;
		}
	}
}
function SwitchSub(ParentId,ShowFlag){
		if (ShowFlag){
			$("#Parent"+ParentId).css("display", "block");
			if ($("#Parent"+ParentId).html()=="" || $("Parent"+ParentId).html()=="专题加载中..."){
				$("#Parent"+ParentId).html("专题加载中...");
				GetSubClass(ParentId);
			}
		}else{
			$("#Parent"+ParentId).css("display","none");
		}
}
function SelectLable(Obj)
{
	var SelectedInfo="";
	if (SelectClass!=""){
		SelectedInfo=SelectClass.split("***");
		$("#" + SelectedInfo[0]).attr("class", "LableItem");
	}
	$(Obj).attr("class", "LableSelectItem");
	SelectClass=Obj.id+"***"+Obj.innerText;
}
function GetRootClass(){
	GetSubClass("0");
}


function GetSubClass(ParentId) {
    var url = "SelectNewsSpecialAjax.aspx?ParentId=" + ParentId;
    $.get(url, function (data) {
        GetSubClassOk(data);
    });
}
function GetSubClassOk(OriginalRequest){
	var ClassInfo;
	if (OriginalRequest !="" && OriginalRequest.indexOf("|||")>-1){
		ClassInfo=OriginalRequest.split("|||");
		
		if (ClassInfo[0]=="<div id=\"spList\">Succee"){
			$("#Parent"+ClassInfo[1]).html(ClassInfo[2]);
		}else{
			$("#Parent"+ClassInfo[1]).html("<a href=\"点击重试\" onclick=\"$('#Parent"+ClassInfo[1]+"').html('专题加载中...');GetSubClass('"+ClassInfo[1]+"');return false;\">点击重试</a>");
		}
	}else{
		alert("读取专题错误.\n请联系管理员.");
		return false;
	}
}



window.onload=GetRootClass;
function ListGo(Path,ParentPath)
{
	document.Templetslist.Path.value=Path;
	document.Templetslist.ParentPath.value=ParentPath;
	document.Templetslist.submit();
}
function sFiles(sid,sname)
{
    document.getElementById('SpcID').value = sid;
    document.getElementById('SpcName').value = sname;
}

function ReturnValue()
{
	var sid = document.getElementById('SpcID').value;
	var snm = document.getElementById('SpcName').value;
	var arryret = new Array(sid,snm);
	var controls = '<%= Request["controlName"]%>';
	if (controls.indexOf(",") > -1) {
	    controlName = controls.split(",");
	    parent.parent.$("#" + controlName[0]).val(snm);
	    parent.parent.$("#" + controlName[1]).val(sid);
	}
	parent.parent.$('#dialog-message').dialog("close");
}
</script>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="configuration_system_selectuserpic" Codebehind="selectuserpic.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/popup_window.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
</head>

<body>
<form id="Templetslist" action="" runat="server" method="post">
<div id="addfiledir" runat="server"></div>
<div id="File_List" runat="server" style="line-height:24px;"></div>
 <input type="hidden" name="Type" />
 <input type="hidden" name="Path"/>
 <input type="hidden" name="ParentPath" />
 <input type="hidden" name="OldFileName" />
 <input type="hidden" name="NewFileName" />
 <input type="hidden" name="filename" />
 <input type="hidden" name="Urlx" />
</form>

</body>
</html>

<script language="javascript" type="text/javascript">
function ListGo(Path,ParentPath)
{
    //self.location='?Path='+Path+'&ParentPath='+ParentPath;
	document.Templetslist.Path.value=Path;
	document.Templetslist.ParentPath.value=ParentPath;
	document.Templetslist.submit();
}
function EditFolder(path,filename)   
{
	var ReturnValue='';
	ReturnValue=prompt('修改的名称：',filename.replace(/'|"/g,''));
	if ((ReturnValue!='') && (ReturnValue!=null))
	{
	    //self.location.href='?Type=EidtDirName&Path='+path+'&OldFileName='+filename+'&NewFileName='+ReturnValue;
	    document.Templetslist.Type.value="EidtDirName";
	    document.Templetslist.Path.value=path;
	    document.Templetslist.OldFileName.value=filename;
	    document.Templetslist.NewFileName.value=ReturnValue;
	    document.Templetslist.submit();
	}
	else
	{
	    if(ReturnValue!=null)
	    {
	        alert('请填写要更名的名称');
	    }    
	}
}
function EditFile(path,filename)   
{
	var ReturnValue='';
	ReturnValue=prompt('修改的名称：',filename.replace(/'|"/g,''));
	if ((ReturnValue!='') && (ReturnValue!=null))
	{
	    document.Templetslist.Type.value="EidtFileName";
	    document.Templetslist.Path.value=path;
	    document.Templetslist.OldFileName.value=filename;
	    document.Templetslist.NewFileName.value=ReturnValue;
	    document.Templetslist.submit();
	}
	else
	{
	    if(ReturnValue!=null)
	    {
	        alert('请填写要更名的名称');
	    }    
	}
}
function DelDir(path)
{
    if(confirm('确定删除此文件夹以及此文件夹下所有文件吗?'))
    {
	    document.Templetslist.Type.value="DelDir";
	    document.Templetslist.Path.value=path;
	    document.Templetslist.submit();
    }
}
function DelFile(path,filename)
{
    if(confirm('确定删除此文件吗?'))
    {
	    document.Templetslist.Type.value="DelFile";
	    document.Templetslist.Path.value=path;
	    document.Templetslist.filename.value=filename;
	    document.Templetslist.submit();
    }
}
function AddDir(path)
{
	var ReturnValue='';
	var filename='';
	ReturnValue=prompt('要添加的文件夹名称',filename.replace(/'|"/g,''));
	if ((ReturnValue!='') && (ReturnValue!=null))
	{
	    document.Templetslist.Type.value="AddDir";
	    document.Templetslist.Path.value=path;
	    document.Templetslist.filename.value=ReturnValue;
	    document.Templetslist.submit();
	}
	else
	{
	    if(ReturnValue!=null)
	    {
	        alert('请填写要添加的文件夹名称');
	    }    
	}
}
function sFiles(obj)
{
  document.Templetslist.sUrl.value=obj;
}

function ReturnValue(obj)
{
    var controls = '<%= Request["controlName"]%>';
    var Str = obj;
	var Edit = '<% Response.Write(Request.QueryString["Edit"]);%>'
	parent.parent.$("#" + controls).val(Str);
	parent.parent.$('#dialog-message').dialog("close");
	if (parent.parent.$('#ischange').val() == "ischange") {
	    parent.parent.setpic();
	}
}

function ReturndefineValue(obj,str)
{
	 window.opener.sdefine(obj,str);
	 window.close();
}


function UpFile(path,ParentPath)
{
    var WWidth = (window.screen.width-500)/2;
    var Wheight = (window.screen.height-150)/2;
    window.open ("Upload_user.aspx?Path="+escape(path)+"&ParentPath="+ParentPath, '文件上传', 'height=300, width=600, top='+Wheight+', left='+WWidth+', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
}

function showDiv(obj, content) {
    var pos = getPosition(obj)
    var objDiv = document.createElement("div");
    objDiv.className = "lionrong"; //For IE
    objDiv.style.position = "absolute";
    var tempheight = pos.y;
    var tempwidth1, tempheight1;
    var windowwidth = document.body.clientWidth;

    var isIE5 = (navigator.appVersion.indexOf("MSIE 5") > 0) || (navigator.appVersion.indexOf("MSIE") > 0 && parseInt(navigator.appVersion) > 4);
    var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5") > 0);
    var isIE6 = (navigator.appVersion.indexOf("MSIE 6") > 0);
    var isIE7 = (navigator.appVersion.indexOf("MSIE 7") > 0);

    if (isIE5 || isIE55 || isIE6 || isIE7) { var tempwidth = pos.x + 305; } else { var tempwidth = pos.x + 312; }
    objDiv.style.width = "300px";
    objDiv.innerHTML = content;
    if (tempwidth > windowwidth) {
        tempwidth1 = tempwidth - windowwidth
        objDiv.style.left = (pos.x - tempwidth1) + "px";
    }
    else {
        if (isIE5 || isIE55 || isIE6 || isIE7) { objDiv.style.left = (pos.x + 10) + "px"; } else { objDiv.style.left = (pos.x) + "px"; }
    }
    if (isIE5 || isIE55 || isIE6 || isIE7) { objDiv.style.top = (pos.y + 16) + "px"; } else { objDiv.style.top = (pos.y + 16) + "px"; }

    objDiv.style.display = "";
    document.onclick = function () { if (objDiv.style.display == "") { objDiv.style.display = "none"; } }
    document.body.appendChild(objDiv);
}
position = function (x, y) {
    this.x = x;
    this.y = y;
}

getPosition = function (oElement) {
    var objParent = oElement
    var oPosition = new position(0, 0);
    while (objParent.tagName != "BODY") {
        oPosition.x += objParent.offsetLeft;
        oPosition.y += objParent.offsetTop;
        objParent = objParent.offsetParent;
    }
    return oPosition;
}
function ShowDivPic(obj, Urls, exname, length) {
    var Url = Urls.replace("\\", "/");
    var pos = getPosition(obj)
    var objDiv = document.createElement("div");
    objDiv.className = "lionrong"; //For IE
    objDiv.id = "showpic_id";
    objDiv.style.position = "absolute";
    var tempheight = pos.y;
    var tempwidth1, tempheight1;
    var windowwidth = document.body.clientWidth;

    var isIE5 = (navigator.appVersion.indexOf("MSIE 5") > 0) || (navigator.appVersion.indexOf("MSIE") > 0 && parseInt(navigator.appVersion) > 4);
    var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5") > 0);
    var isIE6 = (navigator.appVersion.indexOf("MSIE 6") > 0);
    var isIE7 = (navigator.appVersion.indexOf("MSIE 7") > 0);
    switch (exname) {
        case ".jpg": case ".gif": case ".bmp": case ".ico": case ".png": case ".jpeg": case ".tif":
            if (length < 12000) {
                if (Url == "") {
                    var content = "无图片";
                }
                else {
                    var content = "<img src='" + Url + "' border='0' />";
                }
            }
            else {
                var content = "<img src='" + Url + "' border='0' width='100px'/>";
            }
            break;
        case ".swf":
            if (length < 12000) {
                var content = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\">";
                content += "<param name=\"movie\" value=\"" + Url + "\" />"
                content += "<param name=\"quality\" value=\"high\" />"
                content += "<embed src=\"" + Url + "\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\"></embed>"
                content += "</object>"
            }
            else {
                var content = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"100px\">";
                content += "<param name=\"movie\" value=\"" + Url + "\" />"
                content += "<param name=\"quality\" value=\"high\" />"
                content += "<embed src=\"" + Url + "\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"100px\"></embed>"
                content += "</object>"
            }
            break;
            break;
        case ".html": case ".htm": case ".aspx": case ".shtm": case ".shtml": case ".asp":
            var content = "Path:" + Url;
            break;
        default:
            var content = "Path:" + Url;
            break;
    }
    if (isIE5 || isIE55 || isIE6 || isIE7) { var tempwidth = pos.x + 250; } else { var tempwidth = pos.x + 250; }
    objDiv.innerHTML = content;
    if (tempwidth > windowwidth) {
        tempwidth1 = tempwidth - windowwidth
        objDiv.style.left = (pos.x - tempwidth1) + "px";
    }
    else {
        if (isIE5 || isIE55 || isIE6 || isIE7) { objDiv.style.left = (pos.x) + "px"; } else { objDiv.style.left = (pos.x) + "px"; }
    }
    if (isIE5 || isIE55 || isIE6 || isIE7) { objDiv.style.top = (pos.y + 18) + "px"; } else { objDiv.style.top = (pos.y + 18) + "px"; }

    objDiv.style.left = "250px";
    objDiv.style.top = (pos.y - 68) + "px";
    objDiv.style.display = "";
    document.onclick = function () { if (objDiv.style.display == "") { objDiv.style.display = "none"; } }
    document.body.appendChild(objDiv);
}

function hiddDivPic() {
    var objDiv = document.getElementById("showpic_id");
    if (objDiv != null && objDiv != "undefined") {
        document.body.removeChild(objDiv);
    }
}
</script>
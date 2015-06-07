<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xml.aspx.cs" Inherits="Foosun.PageView.configuration.system.xml" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title><% Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>
<body>
<form id="Templetslist" action="" runat="server" method="post">
<div id="File_List" runat="server" />
	<input type="hidden" name="Type" />
	<input type="hidden" name="Path" />
	<input type="hidden" name="ParentPath" />
	<input type="hidden" name="OldFileName" />
	<input type="hidden" name="NewFileName" />
	<input type="hidden" name="filename" />
	<input type="hidden" name="Urlx" />
	<input type="hidden" name="FilePath" />
</form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function ListGo(Path, ParentPath) {
        document.Templetslist.Path.value = Path;
        document.Templetslist.ParentPath.value = ParentPath;
        document.Templetslist.submit();
    }
    function sFiles(obj) {
        document.Templetslist.sUrl.value = obj;
    }

    function ReturnValue(obj) {
        var Str = obj;
        var controls = '<%= Request["controlName"]%>';
        parent.parent.$("#" + controls).val(Str);
        parent.parent.$('#dialog-message').dialog("close");
    }
    function EditFolder(path, filename) {
        var ReturnValue = '';
        ReturnValue = prompt('修改的名称：', filename.replace(/'|"/g, ''));
        if ((ReturnValue != '') && (ReturnValue != null)) {
            //self.location.href='?Type=EidtDirName&Path='+path+'&OldFileName='+filename+'&NewFileName='+ReturnValue;
            document.Templetslist.Type.value = "EidtDirName";
            document.Templetslist.Path.value = path;
            document.Templetslist.OldFileName.value = filename;
            document.Templetslist.NewFileName.value = ReturnValue;
            document.Templetslist.submit();
        }
        else {
            if (ReturnValue != null) {
                alert('请填写要更名的名称');
            }
        }
    }
    function EditFile(path, filename) {
        var ReturnValue = '';
        ReturnValue = prompt('修改的名称：', filename.replace(/'|"/g, ''));
        if ((ReturnValue != '') && (ReturnValue != null)) {
            //self.location.href='?Type=EidtFileName&Path='+path+'&OldFileName='+filename+'&NewFileName='+ReturnValue;
            document.Templetslist.Type.value = "EidtFileName";
            document.Templetslist.Path.value = path;
            document.Templetslist.OldFileName.value = filename;
            document.Templetslist.NewFileName.value = ReturnValue;
            document.Templetslist.submit();
        }
        else {
            if (ReturnValue != null) {
                alert('请填写要更名的名称');
            }
        }
    }
    function DelDir(path) {
        if (confirm('确定删除此文件夹以及此文件夹下所有文件吗?')) {
            document.Templetslist.Type.value = "DelDir";
            document.Templetslist.Path.value = path;
            document.Templetslist.submit();
        }
    }
    function DelFile(path, filename) {
        if (confirm('确定删除此文件吗?')) {
            document.Templetslist.Type.value = "DelFile";
            document.Templetslist.Path.value = path;
            document.Templetslist.filename.value = filename;
            document.Templetslist.submit();
        }
    }
    function AddDir(path) {
        var ReturnValue = '';
        var filename = '';
        ReturnValue = prompt('要添加的文件夹名称', filename.replace(/'|"/g, ''));
        if ((ReturnValue != '') && (ReturnValue != null)) {
            document.Templetslist.Type.value = "AddDir";
            document.Templetslist.Path.value = path;
            document.Templetslist.filename.value = ReturnValue;
            document.Templetslist.submit();
        }
        else {
            if (ReturnValue != null) {
                alert('请填写要添加的文件夹名称');
            }
        }
    }
</script>

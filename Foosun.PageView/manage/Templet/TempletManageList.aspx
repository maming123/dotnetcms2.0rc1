<%@ Page Language="C#" AutoEventWireup="true" Inherits="TempletManageList" ContentType="text/html"
    CodeBehind="TempletManageList.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
    <div class="mian_body">
        <div class="mian_wei">
            <div class="mian_wei_min">
                <div class="mian_wei_left">
                    <h3>
                        模板管理 </h3>
                </div>
                <div class="mian_wei_right">
                    导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>模板管理</div>
            </div>
        </div>
       <!-- <div class="mian_wei_2">
            <img src="../imges/lie_12.gif" alt="" /></div>-->
        <div class="mian_cont">
            <div class="nwelie">
                <div id="addfiledir" class="lanlie" runat="server">
                </div>
                <div class="molie_lie" id="File_List" runat="server">
                </div>
            </div>
        </div>
        <br />
        <form id="Templetslist" action="" runat="server" method="post">
        <input type="hidden" name="Type" />
        <input type="hidden" name="Path" />
        <input type="hidden" name="ParentPath" />
        <input type="hidden" name="OldFileName" />
        <input type="hidden" name="NewFileName" />
        <input type="hidden" name="filename" />
        <input type="hidden" name="Urlx" />
        </form>
    </div>
</body>
<script language="javascript" type="text/javascript">
function ListGo(Path,ParentPath)
{
    Path = escape(Path);
    var dir = location.href;
    var arr_dir  = dir.split("/");
    var url = "";
    var dirDumm = "<% Response.Write(Foosun.Config.UIConfig.dirDumm); %>";
    for (var i=0;i<arr_dir.length;i++)
    {
	    if(i<3)
		    url+=arr_dir[i]+"/";
    }
    //得到管理目录
    location.href='/manage/Templet/TempletManageList.aspx?Path='+Path+'&ch=<%Response.Write(Request.QueryString["ch"]); %>&ParentPath='+ParentPath;
}

function EditFolder(path,filename)   
{
	var ReturnValue='';
	ReturnValue=prompt('修改的名称：',filename.replace(/'|"/g,''));
	if ((ReturnValue!='') && (ReturnValue!=null))
	{
	    self.location.href='?Type=EidtDirName&ch=<%Response.Write(Request.QueryString["ch"]); %>&Path='+path+'&OldFileName='+filename+'&NewFileName='+ReturnValue;
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
	    self.location.href='?Type=EidtFileName&ch=<%Response.Write(Request.QueryString["ch"]); %>&Path='+path+'&OldFileName='+filename+'&NewFileName='+ReturnValue;
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
	    self.location.href='?Type=DelDir&Path='+path;
    }
}
function DelFile(path,filename)
{
    if(confirm('确定删除此文件吗?'))
    {
	    self.location.href='?Type=DelFile&ch=<%Response.Write(Request.QueryString["ch"]); %>&Path='+path+'&filename='+filename;
    }
}
function AddDir(path)
{
	var ReturnValue='';
	var filename='';
	ReturnValue=prompt('要添加的文件夹名称',filename.replace(/'|"/g,''));
	if ((ReturnValue!='') && (ReturnValue!=null))
	{
	    self.location.href='?Type=AddDir&ch=<%Response.Write(Request.QueryString["ch"]); %>&Path='+path+'&filename='+ReturnValue;
	}
	else
	{
	    if(ReturnValue!=null)
	    {
	        alert('请填写要添加的文件夹名称');
	    }    
	}
}
function UpFile(path,type)
{
    var WWidth = (window.screen.width-500)/2;
    var Wheight = (window.screen.height - 150) / 2;
    window.open ("../../configuration/system/Upload.aspx?Path="+path+"&ch=<%Response.Write(Request.QueryString["ch"]); %>&UpfilesType="+type, '文件上传', 'height=150, width=500, top='+Wheight+', left='+WWidth+', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no'); 
}
</script>
</html>

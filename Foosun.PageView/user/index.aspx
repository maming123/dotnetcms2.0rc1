<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Foosun.PageView.user.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>会员中心</title>
</head>
<frameset rows="100,*" cols="*" frameborder="no" border="0" framespacing="0">
    <frame src="top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame"
        title="topFrame" />
    <frameset cols="210,*" frameborder="no" border="0" framespacing="0" name="bodyFrame"
        id="bodyFrame">
        <frame src="left.aspx" name="menu" scrolling="yes" frameborder="0"
            noresize="noresize" id="menu" title="leftFrame" />      
        <frame src="main.aspx" name="sys_main" id="sys_main" title="mainFrame" />
    </frameset>
</frameset>
<noframes>
	<body>
	</body>
</noframes>
</html>


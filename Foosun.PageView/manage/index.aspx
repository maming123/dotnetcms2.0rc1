<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Foosun.PageView.manage.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title>
		<%Response.Write(Foosun.Config.UIConfig.HeadTitle); %>--后台管理</title>
	<script language="JavaScript" type="text/javascript">
//	    function killErrors() {
//	        return true;
//	    }
	    function selectMenus(eid) {
	        topFrame.open(eid);
	    }
//	    window.onerror = killErrors;
	</script>
</head>
<frameset rows="128,*" cols="*" frameborder="no" border="0" framespacing="0">
    <frame src="top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame"
        title="topFrame" />
            <frameset cols="0,0,*" frameborder="no" border="0" framespacing="0" name="bodyFrame"
        id="bodyFrame">
        <frame src="left.aspx" name="menu" scrolling="auto" frameborder="0"
            noresize="noresize" id="menu" name="menu" title="leftFrame" />
        <frame src="middle.aspx" name="middle" scrolling="auto" frameborder="0"
            noresize="noresize" id="middle" title="middleFrame" />            
        <frame src="main.aspx?id=1" name="sys_main" id="sys_main" title="mainFrame" />
    </frameset>
</frameset>
<noframes>
	<body>
	</body>
</noframes>
</html>

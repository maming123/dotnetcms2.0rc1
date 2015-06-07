<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassSite.aspx.cs" Inherits="Foosun.PageView.manage.news.ClassSite" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.treeview.js" type="text/javascript"></script>
    <link href="/CSS/jquery.treeview.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript">
	    $(function () {
	        $("#tree").treeview({
	            collapsed: true,
	            animated: "medium"
	        });
	    })
		
	</script>
</head>
<body>
<form id="form1" runat="server">
    <div id="navlist" runat="server"></div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Foosun.PageView.manage.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>菜单</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/jquery.treeview.js" type="text/javascript"></script>
<link href="/CSS/jquery.treeview.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
    function Newsclick() {
        $('#NewsNav').toggle('slow');
    }
    $(function () {
        var type = '<%= Request["type"]%>';
        if (type != '') {
            $('#NewsNav').show();
        }
        $("#tree").treeview({
            collapsed: true,
            animated: "medium"
        });
    })
</script>
</head>
<body class="left_body">
<div class="left_big"> 
  <div class="left_big_top"></div>
  <div class="left_big_bot">
    <div class="left_menu" id="navcontent" runat="server">        
       
    </div>
  </div>
</div>
</body>
</html>
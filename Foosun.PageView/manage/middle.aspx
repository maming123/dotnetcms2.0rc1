<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="middle.aspx.cs" Inherits="Foosun.PageView.manage.main" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script type="text/javascript">
    var preFrameW = '184,9,*';
    var FrameHide = 0;
    function hide() {   
        var addwidth = 10;
            if (FrameHide == 0) {
                top.document.getElementsByTagName("*").bodyFrame.cols = '0,9,*';
                FrameHide = 1;
                $('#photo').attr("src", "imges/lie_560.gif");              
                return;
            } else {
                top.document.getElementsByTagName("*").bodyFrame.cols = preFrameW;
                FrameHide = 0;
                $('#photo').attr("src","imges/lie_56.gif");  
                return;
            }
    }
</script>
</head>
<body class="min_body">
 <div class="min_an"><img src="imges/lie_56.gif" id="photo" alt="" onclick="hide()" /></div>
</body>
</html>

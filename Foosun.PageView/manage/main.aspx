<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Foosun.PageView.manage.main1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="/CSS/style_win8.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script type="text/javascript"  language="javascript" src="/Scripts/public.js"></script>
 <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.min.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
    if (navigator.userAgent.indexOf("MSIE 6") > -1) {
        window.attachEvent("onload", correctPNG);
    };
    function seturl(url,lefturl) {
        top.document.getElementsByTagName("*").bodyFrame.cols = '184,9,*';
        window.open(url, '_self');
        if (lefturl != "") {
            window.parent.menu.location = lefturl;
        }
    }
    var windowWidth = $(window).width();
    var windowHeight = $(window).height();
    var left1 = Math.floor((windowWidth - 960) / 2);
    function sets(id) {
        var num = Number(id) - 1;
        var nums = Number(id) + 1;
        window.parent.parent.selectMenus(id);
        $('#wrapper' + num + ' input:text').focusout();
        animDone = false;
        var lefts = Math.floor((windowWidth - 960) / 2);
        if (id != "1") {
            lefts = left1 - 1040 * (Number(id) - 1);
        }
        $('#place').animate({
            left: lefts
        }, 1000, 'circEaseOut', function () {
            $('#wrapper' + id + ' input:text').focus();
            animDone = true;
            wrapperPos = id;
        });
        if (id == "1") {
            $('#button1to2').show();
            $('#button2to1').hide();
        }
        else if (id == "7") {
            $('#button6to7').hide();
            $('#button7to6').show();
        }
        else {
            $('#button' + num + 'to' + id).hide();
            $('#button' + nums + 'to' + id).hide();
            $('#button' + id + 'to' + num).show();
            $('#button' + id + 'to' + nums).show();
        }
    }
    $(function () {
    var id=<%=Request.QueryString["id"] %>;
        sets(id);
    });
</script>
</head>
<body class="main_bg">
<div class="main_big" style="color:White">
   <div id="place">
        <div id="wrapper1">
         <div class="w1">
           <ul id="menus" runat="server">
              <%=GetMenus("000000000001")%>
           </ul>
          </div>
        </div>
        <!-- end wrapper1 -->
        <div id="button1to2">
        </div>
        <div id="button2to1">
        </div>
        <div id="wrapper2">
            <div class="w1">
           <ul id="Ul1" runat="server">
              <%=GetMenus("000000000002")%>
           </ul>
          </div>
        </div>
        <!-- end wrapper2 -->
        <div id="button2to3">
        </div>
        <div id="button3to2">
        </div>
        <div id="wrapper3">
            <div class="w1">
           <ul id="Ul2" runat="server">
              <%=GetMenus("000000000003")%>
           </ul>
          </div>
        </div>
        <!-- end wrapper3 -->
        <div id="button3to4">
        </div>
        <div id="button4to3">
        </div>
        <div id="wrapper4">
            <div class="w1">
           <ul id="Ul3" runat="server">
              <%=GetMenus("000000000004")%>
           </ul>
          </div>
        </div>
        <!-- end wrapper4 -->
        <div id="button4to5">
        </div>
        <div id="button5to4">
        </div>
        <div id="wrapper5">
            <div class="w1">
           <ul id="Ul4" runat="server">
              <%=GetMenus("000000000005")%>
           </ul>
          </div>
        </div>
        <!-- end wrapper5 -->
        <div id="button5to6">
        </div>
        <div id="button6to5">
        </div>
        <div id="wrapper6">
            <div class="w1">
           <ul id="Ul5" runat="server">
              <%=GetMenus("000000000006")%>
           </ul>
          </div>
        </div>
        <!-- end wrapper6 -->
        <div id="button6to7">
        </div>
        <div id="button7to6">
        </div>
        <div id="wrapper7">
            <div class="w1">
           <ul id="Ul6" runat="server">
              <%=GetMenus("000000000007")%>
           </ul>
          </div>
        </div>
        <!-- end wrapper7 -->
    </div>
</div>
   <div id="dialog-message" title="菜单编辑"></div>
</body>
    <script type="text/javascript" src="/Scripts/jquery.animation.easing.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.mousewheel.min.js"></script>
    <script type="text/javascript" src="/Scripts/script_scroll.js"></script>

</html>
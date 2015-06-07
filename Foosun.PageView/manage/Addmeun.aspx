<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addmeun.aspx.cs" Inherits="Foosun.PageView.manage.Addmeun" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/tan.css"/>
<script type="text/javascript"  language="javascript" src="/Scripts/public.js"></script>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<link href="jquery-ui/css/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
<script src="jquery-ui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    if (navigator.userAgent.indexOf("MSIE 6") > -1) {
        window.attachEvent("onload", correctPNG);
    };
    $(function () {
        var list = "";
        $("#meun2").children().each(function () {
            if ($(this).attr("id") != null && $(this).attr("id") != "") {
                list += $(this).attr("id") + ",";
            }
        });
        $('#meunlist').val(list);
        $("#meun2, #meun1").sortable({
            connectWith: ".gallery,.sgallery",
            items: ".movemeun",
            revert: true,
            stop: function (event, ui) {
                if ($('#meun2').height() > 400) {
                    $(this).sortable('cancel');
                    alert("超出边界！");
                }
                var list = "";
                $("#meun2").children().each(function () {
                    if ($(this).attr("id") != null && $(this).attr("id") != "") {
                        list += $(this).attr("id") + ",";
                    }
                });
                $('#meunlist').val(list);

            }
        }).disableSelection();
    });
</script>
</head>
<body class="main_bg">
<form runat="server">
<div class="main_big">
<div class="big">
   <div class="ui-gallery">
      <div class="ui-lan"><h4>已增加的快捷键方式</h4>
          <asp:Button ID="btnsave" runat="server" Text="" class="meunbtn" 
              onclick="btnsave_Click" /></div>
      <ul class="gallery" id="meun2" runat="server">
      </ul>
</div>
   <div class="yid">
  <div class="yid-lan"><h4>所有快捷键方式</h4></div>
  <div class="yid-bot">
     <ul class="sgallery" id="meun1" runat="server">
      </ul>
  </div>
</div>
</div>
</div>
<asp:HiddenField ID="meunlist" runat="server" />
</form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectspecial.aspx.cs" Inherits="Foosun.PageView.configuration.system.selectspecial" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>选择专题__By Foosun.net & Foosun Inc.</title>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
 <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <select id="Special" name="Special" style="width:250px;height:150px"  runat="server" multiple></select>
    </div>
    <div align="center"><input type="button" value=" 选定" class="xsubmit1" onclick="javascript:ReturnValue()" /> <span style="font-size:12px;">(可以多选)</span></div>
    </form>
</body>
</html>
<script language ="javascript" type="text/javascript">
    function ReturnValue() {
        var obj = document.form1.Special;
        var sid = "";
        var snm = "";
        for (var i = 0; i < obj.length; i++) {
            var value = obj.options[i].value;
            if (obj.options[i].selected == true) {
                var text = value.split('|');
                sid += text[0] + ",";
                snm += text[1] + ",";
            }
        }
        sid = sid.substring(0, sid.length - 1);
        snm = snm.substring(0, snm.length - 1);      
        var controls = '<%= Request["controlName"]%>'.split(',');
        parent.parent.$("#" + controls[0]).val(snm);
        parent.parent.$("#" + controls[1]).val(sid);
        parent.parent.$('#dialog-message').dialog("close");
    }
</script>
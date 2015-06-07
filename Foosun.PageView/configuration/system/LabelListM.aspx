<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_Templet_LabelListM"
    CodeBehind="LabelListM.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"
        rel="stylesheet" type="text/css" />
    <link href="/CSS/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="Label" action="" runat="server">
    <span class="reshow" style="padding-top: 12px; padding-left: 8px;">栏目动态标签</span>
    <div runat="server" class="lanmu" id="LabelList" />
    <span class="reshow" style="padding-top: 12px; padding-left: 8px;">专题动态标签</span>
    <div runat="server" class="lanmu" id="LabelList1" />
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function selectLabel(rvalue) {
        var controlName = '<%= Request["controlName"]%>';
        parent.parent.Insert(rvalue);
        parent.parent.$('#dialog-message').dialog("close");
    }
</script>

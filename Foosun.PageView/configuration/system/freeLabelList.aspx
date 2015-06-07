<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_Templet_freeLabelList" Codebehind="freeLabelList.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="Label" action="" runat="server">
<%--    <span id="channelList" style="padding-left:10px;" runat="server" />
--%>    <div runat="server" id="LabelList">
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function selectLabel(rvalue,type)
{
    var controlName = '<%= Request["controlName"]%>';
    parent.parent.Insert(rvalue);
    parent.parent.$('#dialog-message').dialog("close");
}
function getchanelInfo(obj)
{
   var SiteID=obj.value;
   window.location.href="freelabelList.aspx?SiteID="+SiteID+"";
}
</script>
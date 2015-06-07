<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_Templet_LabelList" Codebehind="LabelList.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
<link href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="/CSS/popup_window.css"/>
</head>
<body>
<form id="Label" action="" runat="server">
     <div style="padding:5px 5px;"><span id="channelList" runat="server" /></div>
    <div runat="server" id="LabelList" class="midtxtad"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function selectLabel(rvalue) {
        var controlName = '<%= Request["controlName"]%>';
        parent.parent.Insert(rvalue);
        parent.parent.$('#dialog-message').dialog("close");
    }
function getchanelInfo(obj)
{
   var SiteID=obj.value;
   window.location.href="labelList.aspx?SiteID="+SiteID+"";
}
</script>
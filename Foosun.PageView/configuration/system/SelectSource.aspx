<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectSource.aspx.cs" Inherits="Foosun.PageView.configuration.system.SelectSource" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>选择常规__by Foosun.net & Foosun Inc.</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/popup_window.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="gListform" action="" runat="server" method="post">
        <input type="hidden" id="returnV" name="returnV" />
    <div id="datalist" class="source_top">
        <asp:Repeater ID="rpt_list" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <%#((DataRowView)Container.DataItem)["op"]%>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="source_ye">
        <uc1:PageNavigator ID="PageNavigator1" runat="server" />
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    window.onload = function () {
        var data = $("#datalist").html();
        if (data.trim() == "") {
            $("#datalist").css("border", "none");
        }
    }
    function ReturnValue(obj) {
        var Str = obj;
        var controls = '<%= Request["controlName"]%>';
        parent.parent.$("#" + controls).val(Str);
        parent.parent.$('#dialog-message').dialog("close");
    }
</script>

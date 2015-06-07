<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectPagestyle.aspx.cs" Inherits="Foosun.PageView.configuration.system.selectPagestyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function getColorOptions() {
            var color = new Array("00", "33", "66", "99", "CC", "FF");
            for (var i = 0; i < color.length; i++) {
                for (var j = 0; j < color.length; j++) {
                    for (var k = 0; k < color.length; k++) {
                        document.write('<option style="background:#' + color[j] + color[k] + color[i] + '" value="' + color[j] + color[k] + color[i] + '"></option>');
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="PageInfo" runat="server">
        <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" style=" line-height:30px;">
          <tr>
            <td align="right" style="width: 30%" valign="top">显示方式：</td>
            <td align="left">
                <select name="PageStyle" style="width:150px;" id="PageStyle">
                    <option value="0" selected="selected" style="background-color:#CCFFCC;">前一页 后一页</option>
                    <option value="1" style="background-color:#CCFFCC;">共N页,第1页,第2页</option>
                    <option value="2" style="background-color:#CCFFCC;">共N页.1 2 3</option>
                    <option value="3" style="background-color:#CCFFCC;"> |<<  <<  <  > > >>  >>| </option>
                    <option value="4" style="background-color:#CCFFCC;"> 新浪样式</option>
                </select></td>
          </tr>
          <tr>
            <td align="right" style="width: 30%" valign="top">显示颜色：</td>
            <td align="left">
            <select name="PageColor" id="PageColor" style="width:150px;" class="form">
            <option value="">无颜色</option>
            <script language="javascript" type="text/javascript">                getColorOptions();</script></select></td>
          </tr>
          <tr>
            <td align="right" style="width: 30%" valign="top">每页数量：</td>
            <td align="left">
                <asp:TextBox ID="PageNum" runat="server" Width="150px" CssClass="form" Text="30"></asp:TextBox><span id="spanPageNum"></span></td>
          </tr>
          <tr >
            <td align="right" style="width: 30%" valign="top">分页CSS：</td>
            <td align="left"><asp:TextBox ID="PageCss" runat="server" Width="150px" CssClass="form"></asp:TextBox></td>
          </tr>
          <tr>
            <td colspan="2" align="center">&nbsp;<input class="insubt2" type="button" value=" 确 定 "  onclick="javascript:ReturnPageValue();" />&nbsp;<input class="insubt2" type="button" value=" 关 闭 "  onclick="javascript:CloseDiv();" /></td>
          </tr>
       </table>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function CloseDiv() {
        parent.parent.$('#dialog-message').dialog("close");
    }

    function ReturnPageValue() {
        var re = /^[0-9]*$$/;
        if (document.PageInfo.PageNum.value != "") {
            if (re.test(document.PageInfo.PageNum.value) == false) {
                document.getElementById("spanPageNum").innerHTML = "<span class=reshow>(*)分页数量只能为正整数</spna>";
                return false;
            }
        }
        rvalue = "";
        rvalue += "FS:PageStyle=" + document.PageInfo.PageStyle.value;
        rvalue += "$" + document.PageInfo.PageColor.value;
        rvalue += "$" + document.PageInfo.PageNum.value;
        rvalue += "$" + document.PageInfo.PageCss.value;
        parent.parent.$('#PageID').val(rvalue);
        CloseDiv();
    }
</script>
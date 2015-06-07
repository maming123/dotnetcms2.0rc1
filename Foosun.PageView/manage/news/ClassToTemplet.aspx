<%@ Page Language="C#" AutoEventWireup="true" Inherits="ClassToTemplet" CodeBehind="ClassToTemplet.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
            <div class="mian_wei_min">
                <div class="mian_wei_left">
                    <h3>
                        批量设置</h3>
                </div>
                <div class="mian_wei_right">
                    导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="NewsClassList.aspx">栏目管理</a> >>批量设置
                </div>
            </div>
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="lanlie">
                    <ul>
                        <li>功能：</li>
                        <li><a href="NewsClassList.aspx">栏目首页</a></li>
                    </ul>
                </div>
                <div class="lanlie_lie">
                    <div class="nlan_big">
                        <table width="98%" border="0" align="center" style="width:98%; margin:0 1%; display:inline;">
                            <tr>
                                <td width="25%">
                                    <div class="nlan_shux">
                                        <asp:ListBox ID="DataListBox" runat="server" Height="320px" Width="250px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <br />
                                        <br />
                                        <input name="button2" type="button" class="form1" id="B_Class2" onclick="javascript:SelectAllClass(1);"
                                            value="全选" />
                                        &nbsp;&nbsp;
                                        <input name="button22" type="button" class="xsubmit3" id="Button6" onclick="javascript:SelectAllClass(0);"
                                            value="取消选定栏目" />
                                        &nbsp;&nbsp;
                                        <input name="button22" type="button" class="form1" id="Button1" onclick="javascript:Selectflg();"
                                            value="反选" />
                                    </div>
                                </td>
                                <td valign="top">
                                    <table class="tbl" align="center">
                                        <tr>
                                            <td width="20%" align="right">
                                                栏目列表模板：
                                            </td>
                                            <td>
                                                <span runat="server" id="labelTemplet">
                                                <asp:TextBox ID="Itemtemplets" runat="server" CssClass="input"></asp:TextBox>
                                                <img src="../imges/bgxiu_14.gif"   style="cursor: pointer;" title="选择模板" onclick="selectFile('Itemtemplets','模板选择','templet',500,500);document.Itemtemplets.focus();" />
                                                </span>
                                                <span runat="server" id="dropTemplet">
                                                    <asp:TextBox ID="dTemplet" runat="server" class="input4"></asp:TextBox>                             
                                                     <a href="javascript:selectFile('dTemplet','模版选择','templet','500','350')">
                                                     <img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                                                 </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%" align="right">
                                                新闻浏览模板：
                                            </td>
                                            <td>
                                                <span id="labelNewsTemplet" runat="server">
                                                <asp:TextBox ID="displaytemplets" runat="server" CssClass="input"></asp:TextBox>
                                                <img src="../imges/bgxiu_14.gif"  style="cursor: pointer;" title="选择模板" onclick="selectFile('displaytemplets','模板选择','templet',500,500);document.displaytemplets.focus();" />
                                                </span>
                                                <span id="dropNewsTemplet" runat="server">
                                                    <asp:TextBox ID="dListTemplets" Width="40%" runat="server" CssClass="input4" /><img
                                                    src="../imges/bgxiu_14.gif" alt="选择内容模板" border="0" style="cursor: pointer;"
                                                    onclick="selectFile('dListTemplets','模版选择','templet',500,500);document.form1.FListTemplets.focus();" />
                                                </span>
                                                <asp:CheckBox ID="isContent" Text="更新栏目下的新闻模板" runat="server" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <tr>
                        </table>
                        <div class="nlan_ti">
                            <asp:Button ID="btn" CssClass="xsubmit3" runat="server" Text="批量绑定数据" OnClick="btn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
<!--    <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg"
        style="height: 76px" align="center">
        <tr>
            <td align="center">
                <%Response.Write(CopyRight); %>
            </td>
        </tr>
    </table>-->
   <div id="dialog-message" title="提示"></div>
</body>
</html>
<script language="javascript">
    function SelectAllClass(VarInt) {
        var obj = document.form1.DataListBox;
        for (var i = 0; i < obj.length; i++) {
            if (VarInt == 1)
                obj.options[i].selected = true;
            else
                obj.options[i].selected = false;
        }
    }

    function Selectflg() {
        var obj = document.form1.DataListBox;
        for (var i = 0; i < obj.length; i++) {
            if (obj.options[i].selected)
                obj.options[i].selected = false;
            else
                obj.options[i].selected = true;
        }
    }

</script>

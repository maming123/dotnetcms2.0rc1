<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublishSpecial.aspx.cs" Inherits="Foosun.PageView.manage.publish.PublishSpecial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%Response.Write(Foosun.Config.UIConfig.HeadTitle); %>专题发布</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
    <script>

        function checkform() {
            
        }
        function showdialog(msg) {
            $("#dialog-message").html("<div class=\"msgboxs\">" + msg + "</div>");
            $("#dialog-message").dialog({
                modal: true
            });
        }
        function AjaxPublish() {
            checkform();
            var url = "Publish.aspx?publishIndex=false&bakIndex=false";

            var para = "";
            var classall = document.getElementById("specialall").checked;
            var newClass = document.getElementById("DivSpecial");
            var intvalue = "";
            if (classall != true) {
                for (var i = 0; i < newClass.length; i++) {
                    if (newClass.options[i].selected) {
                        intvalue += newClass.options[i].value + "$";
                    }
                }
                if (intvalue.length > 0) {
                    intvalue = intvalue.substring(0, intvalue.length - 1);
                }
            } else {
                intvalue = "specialall";
            }
            para = "type=special&specialid=" + intvalue; 
            if (para != "") {
                url += "&" + para;
            }
            var cw = document.body.clientWidth - 400;
            var ch = $(window).height() - 100;
            if (navigator.userAgent.indexOf("MSIE") > 0) {
                ch = $(document).height() - 100;
            }
            window.open(url, 'newwindow', 'height=150, width=730, top=' + ch + ', left=' + cw + ', toolbar=no, menubar=no, scrollbars=no,resizable=no,location=no, status=no')
        }

        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dialog-message" title="提示">
    </div>
    <div class="mian_body">
        <div class="mian_wei">
            <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
            <div class="mian_wei_min">
                <div class="mian_wei_left">
                    <h3>
                        发布系统-首页栏目发布</h3>
                </div>
                <div class="mian_wei_right">
                    导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>发布管理</div>
            </div>
            <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="jslie_lan">
                    <span>功能：</span><a href="PublishIndex.aspx">首页、新闻生成设置</a>┊<a href="PublishNewsClass.aspx">栏目生成设置</a>┊<a href="PublishSpecial.aspx">专题生成设置</a>┊<a href="PublishPage.aspx">单页生成设置</a>
                </div>
                <div class="lanlie_lie">
                    <div class="newxiu_base">
                        <table class="nxb_table" id="pubspec">
				            <tr id="Tr1" runat="server">
					            <td width="15%" align="right">
						            发布专题：
					            </td>
					            <td>
						            <input type="checkbox" class="checkbox2" id="specialall" /><label for="specialall">发布所有专题</label>
						            <asp:RadioButton ID="specialselect" runat="server" GroupName="special" onclick="showSpecial1(this)" Text="选择专题" Visible="false" />
						            <br />
						            <asp:ListBox ID="DivSpecial" Width="485px" runat="server" Rows="20" SelectionMode="Multiple"
                                        Height="240px" CssClass="textarea2"></asp:ListBox>
						            <label id="div_special" style="display: none"></label>
					            </td>
				            </tr>
			            </table>
                        <div class="nxb_submit">
                            <input type="button" value="立刻发布" class="xsubmit1" onclick="AjaxPublish()" />
                            <input type="reset" value="重新选择" class="xsubmit1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublishIndex.aspx.cs" Inherits="Foosun.PageView.manage.publish.PublishIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%Response.Write(Foosun.Config.UIConfig.HeadTitle); %>首页新闻发布</title>
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
        $(function () {
            $("#startTime").datepicker({changeMonth: true,changeYear: true});
            $("#endTime").datepicker({changeMonth: true,changeYear: true});
        });

        function checkform() {
            var re = /^[0-9]*$$/;
            var newsid = document.getElementById("newsid");
            if (newsid.checked) {
                if (re.test(document.getElementById("startID").value) == false || re.test(document.getElementById("EndID").value) == false) {
                    showdialog("请正确填写开始ID和结束ID");
                    document.getElementById('startID').focus();
                    return false;
                }
            }

            var newsal = document.getElementById("newsall");
            if (newsal.checked) {
                if (!confirm('您确定要刷新所有新闻吗？\n刷新所有新闻将占用大量服务器资源\n建议按条件分批生成\n如果在参数设置中的[分组刷新]里设置了[信息每次刷新数],将按照要求生成\n确定要生成，请点[确定]')) {
                    return false;
                }
            }
            var Newss = document.getElementById("newslast");
            if (Newss.checked) {
                if (re.test(document.getElementById("NewNum").value) == false) {
                    showdialog("请正确填写发布条数");
                    document.getElementById('NewNum').focus();
                    return false;
                }
            }
            var newsdate = document.getElementById("newsdate");
            if (newsdate.checked) {
                if ($('#startTime').val() == "" || $('#endTime').val() == "") {
                    showdialog("时间不能为空!");
                    return false;
                }
                if (new Date($('#endTime').val().replace(/\-/g, "\/")) - new Date($('#startTime').val().replace(/\-/g, "\/")) < 0) {
                    showdialog("开始日期不能大于结束日期!");
                    return false;
                }
            }

            var newsclass = document.getElementById("newsclass");
            if (newsclass.checked) {
                if (document.getElementById("divClassNews").value == "") {
                    showdialog("请选择栏目发布");
                    return false;
                }
            }
        }
        function showdialog(msg) {
            $("#dialog-message").html("<div class=\"msgboxs\">" + msg + "</div>");
            $("#dialog-message").dialog({
                modal: true
            });
        }
        function AjaxPublish() {
            checkform();
            var PublishType = "";
            var RadioValues = document.getElementsByName("News");
            for (var i = 0; i < RadioValues.length; i++) {
                if (RadioValues[i].checked) {
                    PublishType = RadioValues[i].value;
                }
            }
            var PublishIndex = document.getElementById("indexTF").checked;
            var BakIndex = document.getElementById("baktf").checked;
            var OrderFile = document.getElementById("ddlOrder").options[document.getElementById("ddlOrder").options.selectedIndex].value;
            var url = "Publish.aspx?publishIndex=" + PublishIndex + "&bakIndex=" + BakIndex;
            var para = "";
            switch (PublishType) {
                case "newsall":
                    para = "type=newsall";
                    break;
                case "newsid":
                    var startId = document.getElementById("startID").value;
                    var endId = document.getElementById("EndID").value;
                    para = "type=newsid&startId=" + startId + "&endId=" + endId;
                    break;
                case "newslast":
                    var newNum = document.getElementById("NewNum").value;
                    para = "type=newslast&newNum=" + newNum;
                    break;
                case "newsunhtml":
                    var unhtmlNum = document.getElementById("unhtmlNum").value;
                    para = "type=newsunhtml&unhtmlNum=" + unhtmlNum;
                    break;
                case "newstoday":
                    para = "newstoday=1";
                    break;
                case "newsdate":
                    var startDate = document.getElementById("startTime").value;
                    var endDate = document.getElementById("endTime").value;
                    para = "type=newsdate&startDate=" + startDate + "&endDate=" + endDate;
                    break;
                case "newsclass":
                    var newClass = document.getElementById("divClassNews");
                    var intvalue = "";
                    for (var i = 0; i < newClass.length; i++) {
                        if (newClass.options[i].selected) {
                            intvalue += newClass.options[i].value + ",";
                        }
                    }
                    if (intvalue.length > 0) {
                        intvalue = intvalue.substring(0, intvalue.length - 1);
                    }
                    para = "type=newsclass&newclassids=" + intvalue + "&order=" + $("#ddlOrder").val();
                    break;
            }
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
                    <div class="jslie_lan_left"><span>功能：</span><a href="PublishIndex.aspx">首页、新闻生成设置</a>┊<a href="PublishNewsClass.aspx">栏目生成设置</a>┊<a href="PublishSpecial.aspx">专题生成设置</a>┊<a href="PublishPage.aspx">单页生成设置</a></div>
                    <div class="jslie_lan_right">
                        <input type="button" value="立刻发布" class="xsubmit1" onclick="AjaxPublish()" />
                        <input type="reset" value="重新选择" class="xsubmit1" />
                    </div>
                </div>
                <div class="lanlie_lie">
                    <div class="newxiu_base">
                        <table class="nxb_table" id="pubnews">
                            <tr>
                                <td width="15%" align="right">
                                    生成首页：
                                </td>
                                <td>
                                    <asp:CheckBox ID="indexTF" CssClass="checkbox2" Checked="true" runat="server" />
                                    &nbsp; &nbsp;
                                    <asp:CheckBox ID="baktf" CssClass="checkbox2" Checked="true" Text=" 备份首页文件" runat="server" />
                                    <span class="helpstyle" style="cursor: hand; color: #828282;" title="点击查看帮助" onclick="Help('H_site_bak',this)">
                                        帮助</span>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    发布所有新闻：
                                </td>
                                <td>
                                    <asp:RadioButton ID="newsall" GroupName="News" runat="server" CssClass="checkbox2" />
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    按照ID发布：
                                </td>
                                <td>
                                    <asp:RadioButton ID="newsid" GroupName="News" runat="server" CssClass="checkbox2" />从&nbsp;<asp:TextBox
                                        ID="startID" runat="server" Width="50px" CssClass="input1"></asp:TextBox>&nbsp;到&nbsp;<asp:TextBox
                                            ID="EndID" runat="server" Width="50px" CssClass="input1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    发布最新：
                                </td>
                                <td>
                                    <asp:RadioButton ID="newslast" GroupName="News" runat="server" CssClass="checkbox2" />
                                    <asp:TextBox ID="NewNum" runat="server" Width="50px" CssClass="input1">10</asp:TextBox>
                                    条
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    只发布未生成：
                                </td>
                                <td>
                                    <asp:RadioButton ID="newsunhtml" GroupName="News" runat="server" CssClass="checkbox2" />
                                    <asp:TextBox ID="unhtmlNum" runat="server" Width="50px" CssClass="input1">100</asp:TextBox>
                                    条
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    只发布今天：
                                </td>
                                <td>
                                    <asp:RadioButton ID="newstoday" GroupName="News" runat="server" CssClass="checkbox2" />
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    按照日期发布：
                                </td>
                                <td>
                                    <asp:RadioButton ID="newsdate" GroupName="News" runat="server" CssClass="checkbox2" />
                                    <asp:TextBox ID="startTime" runat="server" Width="100px" CssClass="input1"></asp:TextBox>
                                    -
                                    <asp:TextBox ID="endTime" runat="server" Width="100px" CssClass="input1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    按栏目生成：
                                </td>
                                <td>
                                    <asp:RadioButton ID="newsclass" GroupName="News" CssClass="checkbox2" runat="server" /><asp:CheckBox ID="unHTMLnews" CssClass="checkbox2" runat="server"
                                            Text=" 只发布未发布的" />
                                    <br />
                                    <asp:ListBox ID="divClassNews" Width="485px" runat="server" Rows="20" SelectionMode="Multiple"
                                        Height="240px" CssClass="textarea2"></asp:ListBox>
                                    <label id="div_newsclass" style="display: none;">
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    生成条件：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrder" runat="server" CssClass="checkbox2">
                                        <asp:ListItem Value="0">自动编号</asp:ListItem>
                                        <asp:ListItem Value="1">点击</asp:ListItem>
                                        <asp:ListItem Value="2">权重</asp:ListItem>
                                        <asp:ListItem Value="3">日期</asp:ListItem>
                                        <asp:ListItem Value="4">推荐</asp:ListItem>
                                        <asp:ListItem Value="5">滚动</asp:ListItem>
                                        <asp:ListItem Value="6">热点</asp:ListItem>
                                        <asp:ListItem Value="7">幻灯</asp:ListItem>
                                        <asp:ListItem Value="8">头条</asp:ListItem>
                                        <asp:ListItem Value="9">公告</asp:ListItem>
                                        <asp:ListItem Value="10">精彩</asp:ListItem>
                                        <asp:ListItem Value="11">有作者</asp:ListItem>
                                        <asp:ListItem Value="12">有来源</asp:ListItem>
                                        <asp:ListItem Value="13">有TAGS</asp:ListItem>
                                        <asp:ListItem Value="14">有图片</asp:ListItem>
                                        <asp:ListItem Value="15">有附件</asp:ListItem>
                                        <asp:ListItem Value="16">有视频</asp:ListItem>
                                        <asp:ListItem Value="17">有画中画</asp:ListItem>
                                        <asp:ListItem Value="18">有投票</asp:ListItem>
                                        <asp:ListItem Value="19">有评论</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="orderbyDesc" Checked="true" CssClass="checkbox2" runat="server"
                                        Text="倒序发布" />
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

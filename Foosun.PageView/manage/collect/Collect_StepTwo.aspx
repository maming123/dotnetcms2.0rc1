<%@ Page Language="C#" AutoEventWireup="true" Inherits="Collect_StepTwo" CodeBehind="Collect_StepTwo.aspx.cs" validateRequest="false"  %>

<%@ Register Src="CollectEditor.ascx" TagName="CollectEditor" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>FoosunCMS For .NET v1.0.0</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function ChangeCutPara(obj, flag) {
            var flag;
            if (document.getElementById('RadPageNone').checked)
                flag = 0;
            else if (document.getElementById('RadPageFlag').checked)
                flag = 1;
            else if (document.getElementById('RadPageSingle').checked)
                flag = 2;
            else if (document.getElementById('RadPageIndex').checked)
                flag = 3;
            var tb = document.getElementById('tabList');
            var n = 1;
            var sp = document.getElementById('SpanPage');
            switch (flag) {
                case 0:
                    tb.rows[n + 1].style.display = 'none';
                    tb.rows[n + 2].style.display = 'none';
                    break;
                case 1:
                    tb.rows[n + 1].style.display = '';
                    tb.rows[n + 2].style.display = 'none';
                    sp.innerText = '从当前页获取下一页的地址，再从下一页中获取下一页的地址，以此类推。例如:<a href=[其他页面]>下一页,当前页面的下一页必须咋一';
                    break;
                case 2:
                    tb.rows[n + 1].style.display = '';
                    tb.rows[n + 2].style.display = 'none';
                    sp.innerText = '从当前页获取所有分页的地址。';
                    break;
                case 3:
                    tb.rows[n + 1].style.display = 'none';
                    tb.rows[n + 2].style.display = '';
                    break;
            }
        }
        function StepBack() {
            location.href = "Collect_Add.aspx?Type=Site&ID=" + document.getElementById("HidSiteID").value;
        }
        function LoadMe(flag) {
            ChangeCutPara();
        }
    </script>
</head>
<body onload="LoadMe(Math.random())">
    <form id="Form2" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
            <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
            <div class="mian_wei_min">
                <div class="mian_wei_left">
                    <h3>
                        采集系统</h3>
                </div>
                <div class="mian_wei_right">
                    导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="Collect_List.aspx" target="sys_main">站点设置</a>
                    >>设置向导
                </div>
            </div>
            <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="jslie_lan">
                    <span>功能：</span><a href="Collect_List.aspx" class="list_link">站点列表</a>&nbsp;┊&nbsp;<a
                        class="topnavichar" href="Collect_RuleList.aspx">关键字过滤</a>&nbsp;┊&nbsp;<a class="topnavichar"
                            href="Collect_News.aspx">新闻处理</a>
                </div>
                <div class="lanlie_lie">
                    <div class="newxiu_base">
                        <table class="nxb_table" id="tabList">
                            <tr>
                                <td width="15%" align="right">
                                    列表内容：
                                </td>
                                <td>
                                    <div class="textdiv1">
                                        <uc1:CollectEditor ID="EdtList" runat="server" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    分页设置：
                                </td>
                                <td>
                                    <asp:RadioButton onclick="ChangeCutPara();" runat="server" ID="RadPageNone" GroupName="RadPageSet" Text="不分页" CssClass="radio" />
                                    <asp:RadioButton onclick="ChangeCutPara();" runat="server" ID="RadPageFlag" GroupName="RadPageSet" Text="递归分页设置" CssClass="radio" />
                                    <asp:RadioButton onclick="ChangeCutPara();" runat="server" ID="RadPageSingle" GroupName="RadPageSet" Text="单页分页设置" OnCheckedChanged="RadPageSingle_CheckedChanged"  CssClass="radio"/>
                                    <asp:RadioButton onclick="ChangeCutPara();" runat="server" ID="RadPageIndex" GroupName="RadPageSet" Text="索引分页设置" CssClass="radio" />
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    其他页面：
                                </td>
                                <td>
                                    <div style=" margin-bottom:10px; float:left; width:100%;">
                                    <uc1:CollectEditor ID="EdtPageFlag" runat="server" />
                                    <br />
                                    <span style="color: Red" id="SpanPage"></span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    索引规则：
                                </td>
                                <td>
                                    <uc1:CollectEditor ID="EdtPageIndex" runat="server" />
                                    <span style=" margin-left:10px;">页码开始：</span>
                                    <asp:TextBox runat="server" size="5" ID="TxtPageStart"/>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtPageStart"
                                        Display="Dynamic" ErrorMessage="开始页码必须是1-1000以内的整数!" MaximumValue="1000" MinimumValue="1"
                                        SetFocusOnError="True" Type="Integer" CssClass="form"></asp:RangeValidator>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 页码结束：
                                    <asp:TextBox runat="server" size="5" ID="TxtPageEnd" />
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TxtPageEnd"
                                        Display="Dynamic" ErrorMessage="结束页码必须是1-1000以内的整数!" MaximumValue="1000" MinimumValue="1"
                                        SetFocusOnError="True" Type="Integer"></asp:RangeValidator><br>
                                    <font color="#ff4500">例如:&lta href=?page=[页码]&amp;class_ID=32&gt; 注: [页码]为发生变化的页码值</font>
                                </td>
                            </tr>
                        </table>
                        <div class="nxb_submit">
                            <asp:HiddenField ID="HidSiteID" runat="server" />
                            <input type="button" value="上一步" class="xsubmit1" onclick="StepBack()" />
                            <asp:Button runat="server" ID="BtnNext" Text="下一步" CssClass="xsubmit1" OnClick="BtnNext_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

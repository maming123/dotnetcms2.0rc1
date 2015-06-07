<%@ Page Language="C#" AutoEventWireup="true" Inherits="NewsClassAdd" EnableEventValidation="false"
    CodeBehind="NewsClassAdd.aspx.cs" ValidateRequest="false" %>

<%@ Register Src="../../controls/UserPop.ascx" TagName="UserPop" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>栏目修改</title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        //<!CDATA[
        function g(o) { return document.getElementById(o); }
        function hover_zzjs_net(n, m, k) {
            //m表示开始id，k表示结束id
            for (var i = m; i <= k; i++) {
                g('tab_zzjs_' + i).className = 'nor_zzjs';
                g('tab_zzjs_0' + i).className = 'undis_zzjs_net';
            }
            g('tab_zzjs_0' + n).className = 'dis_zzjs_net';
            g('tab_zzjs_' + n).className = 'hovertab_zzjs';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div class="mian_wei">
        <div class="mian_wei_min">
            <div class="mian_wei_left">
                <h3>
                    栏目管理</h3>
            </div>
            <div class="mian_wei_right">
                导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="NewsClassList.aspx">栏目管理</a> >>添加栏目
            </div>
        </div>
<!--        <div class="mian_wei_2">
            <img src="../imges/lie_12.gif" alt="" /></div>-->
    </div>
    <div class="mian_cont">
        <div class="nwelie">
            <div class="newxiu_lan">
                <ul class="tab_zzjs_" id="tab_zzjs_">
                    <li id="tab_zzjs_1" class="hovertab_zzjs" onclick="x:hover_zzjs_net(1,1,2);">基本信息</li>
                    <li id="tab_zzjs_2" class="nor_zzjs" onclick="x:hover_zzjs_net(2,1,2);">高级属性</li>
                </ul>
                <div class="newxiu_bot">
                    <div class="dis_zzjs_net" id="tab_zzjs_01">
                        <div class="newxiu_base">
                            <table class="nxb_table">
                                <tr id="ClssStyle_1">
                                    <td width="20%" align="right">
                                        栏目中文名称：
                                    </td>
                                    <td width="80%">
                                        <asp:TextBox ID="TCname" Width="40%" runat="server" onChange="javascript:GetPY1(this);"
                                            MaxLength="50" CssClass="input4"></asp:TextBox><span class="helpstyle" style="cursor: hand; color:#828282;"
                                                title="点击查看帮助" onclick="Help('Class_Aspx_01',this)">帮助</span><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="TCname" Display="Dynamic"
                                                    ErrorMessage="<span class=reshow>(*)栏目中文名字不能为空!</span>"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_2">
                                    <td width="20%" align="right">
                                        栏目英文名称：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TEname" runat="server" MaxLength="50" CssClass="input8"></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_02',this)">
                                            帮助</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="TEname" Display="Dynamic" ErrorMessage="<span class=reshow>(*)栏目英文名字不能为空!</span>"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能包含数字,字母,下划线,及中划线。第一个字符为字母."
                                            ControlToValidate="TEname" Display="Dynamic" ValidationExpression="^[0-9a-zA-Z][a-zA-Z0-9._-]{1,50}$"></asp:RegularExpressionValidator><label id="modifynote" runat="server" />
                                    </td>
                                </tr>
                                <tr id="Tr1" style="display:none">
                                    <td width="20%" align="right">
                                        频道：
                                    </td>
                                    <td>
                                        <label id="sitelabel" runat="server" />
                                    </td>
                                </tr>
                                <tr id="ClssStyle_3">
                                    <td width="20%" align="right">
                                        父栏目：
                                    </td>
                                    <td>
                                        &nbsp;<span style="display: none;"><asp:TextBox ID="TParentId"
                                            Width="20%" runat="server" CssClass="form"></asp:TextBox></span> <span class="reshow"
                                                id="ClassCnamev">
                                                <asp:Label ID="lblParentName" runat="server" Text="Label"></asp:Label></span><span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助"
                                                    onclick="Help('Class_Aspx_03',this)">帮助</span>
                                        <asp:HiddenField ID="ClassIDNum" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="20%" align="right">
                                        是否外部栏目：
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CProject" runat="server" CssClass="checkbox2" onclick="javascript:CheckedCode();" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_04',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_4">
                                    <td width="20%" align="right">
                                        排列权重：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TOrder" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_05',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_5" style="display: none;">
                                    <td width="20%" align="right">
                                        外部地址：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TAddress" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_06',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_6" style="display:none">
                                    <td width="20%" align="right">
                                        捆绑域名：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="THoustAddress" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_08',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_7">
                                    <td width="20%" align="right">
                                        栏目模板：
                                    </td>
                                    <td>
                                        <span runat="server" id="labelTemplet"><asp:TextBox ID="FProjTemplets" Width="40%" runat="server" CssClass="input4" />
                                        <img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;"
                                            onclick="selectFile('FProjTemplets','模版选择','templet',500,500);document.form1.FProjTemplets.focus();" /></span>
                                        <span runat="server" id="dropTemplet">
                                            <asp:TextBox ID="dTemplet" runat="server" class="input4"></asp:TextBox>                             
                                             <a href="javascript:selectFile('dTemplet','模版选择','templet','500','350')">
                                             <img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                                         </span>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_09',this)">帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_8">
                                    <td width="20%" align="right">
                                        栏目内容页模板：
                                    </td>
                                    <td>
                                        <span id="labelNewsTemplet" runat="server">
                                        <asp:TextBox ID="FListTemplets" Width="40%" runat="server" CssClass="input4" /><img
                                            src="../imges/bgxiu_14.gif" alt="选择内容模板" border="0" style="cursor: pointer;"
                                            onclick="selectFile('FListTemplets','模版选择','templet',500,500);document.form1.FListTemplets.focus();" /></span>
                                        <span id="dropNewsTemplet" runat="server">
                                            <asp:TextBox ID="dListTemplets" Width="40%" runat="server" CssClass="input4" /><img
                                            src="../imges/bgxiu_14.gif" alt="选择内容模板" border="0" style="cursor: pointer;"
                                            onclick="selectFile('dListTemplets','模版选择','templet',500,500);document.form1.FListTemplets.focus();" />
                                        </span>
                                            <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_10',this)">帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_9">
                                    <td width="20%" align="right" valign="top">
                                        栏目保存路径：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TPath" runat="server" Width="40%" CssClass="input4"></asp:TextBox><img
                                            src="../imges/bgxiu_14.gif" alt="选择路径" border="0" style="cursor: pointer;" onclick="selectFile('TPath','路径选择','path|<% Response.Write(GetClassSavePath()); %>',500,500);document.form1.TPath.focus();" /><span
                                                class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_11',this)">帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_12">
                                    <td width="20%" align="right">
                                        新闻保存规则：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NewsSave" runat="server" Width="40%" CssClass="input4"> </asp:TextBox><img
                                            src="../imges/bgxiu_14.gif" alt="选择规则" border="0" style="cursor: pointer;" onclick="selectFile('NewsSave','新闻保存规则','rulesmallPram',500,200);document.form1.NewsSave.focus();" /><span
                                                class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_14',this)">帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_10">
                                    <td width="20%" align="right">
                                        在导航中显示：
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="NaviShowtf" runat="server" Checked="True" class="checkbox2" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_12',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_11">
                                    <td width="20%" align="right">
                                        审核机制：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="Auditing" runat="server" class="select3">
                                            <asp:ListItem Value="0">不审核</asp:ListItem>
                                            <asp:ListItem Value="1">一级审核</asp:ListItem>
                                            <asp:ListItem Value="2">二级审核</asp:ListItem>
                                            <asp:ListItem Value="3">三级审核</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_13',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_32">
                                    <td width="20%" align="right">
                                        栏目页面导航：
                                    </td>
                                    <td>
                                        <div class="textdiv4"><asp:TextBox ID="HtmlPhrasing" runat="server" Style="width:300px; height:50px; font-size:12px;" TextMode="MultiLine"
                                         ></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_32_02',this)">
                                            帮助</span>
                                         </div>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_35">
                                    <td width="20%" align="right">
                                        新闻页面导航：
                                    </td>
                                    <td>
                                        <div class="textdiv4"><asp:TextBox ID="NewsHtmlPhrasing" runat="server"  Style="width:300px; height:50px; font-size:12px;"
                                            TextMode="MultiLine"></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_33',this)">
                                            帮助</span>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="undis_zzjs_net" id="tab_zzjs_02">
                        <div class="newxiu_base">
                            <table class="nxb_table">
                                <tr id="ClssStyle_23">
                                    <td width="20%" align="right">
                                        多少天后归档：
                                    </td>
                                    <td width="80%">
                                        <asp:TextBox ID="Pigeonhole" runat="server" Width="40%" CssClass="input4" Text="0"></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_16',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_34">
                                    <td width="20%" align="right">
                                        自定义字段：
                                    </td>
                                    <td width="80%">
                                        <a href="javascript:clearDefine();"><font color="blue">重新填写</font></a><br />
                                        <asp:ListBox ID="DefineColumns" runat="server" Height="129px" Width="131px" SelectionMode="Multiple"
                                            onchange="getDefinedData(this);" CssClass="input4"></asp:ListBox>
                                        <label id="DefineRows_div" runat="server" />
                                        <span id="displayLoad"></span><span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助"
                                            onclick="Help('Class_Aspx_18',this)">帮助</span>
                                        <asp:HiddenField ID="HiddenDefine" runat="server" />
                                    </td>
                                </tr>
                                <tr id="ClssStyle_13">
                                    <td width="20%" align="right">
                                        保存栏目生成目录结构：
                                    </td>
                                    <td width="80%">
                                        <asp:TextBox ID="DirData1" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <img src="../imges/bgxiu_14.gif"  align="middle" alt="命名规则" border="0" style="cursor: pointer;" onclick="selectFile('DirData1','栏目生成目录结构','rulePram',500,200);document.form1.DirData1.focus();" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_19',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_14">
                                    <td width="20%" align="right">
                                        文件命名规则：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DirData2" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <img src="../imges/bgxiu_14.gif"  align="middle" alt="文件命名规则" border="0" style="cursor: pointer;"
                                            onclick="selectFile('DirData2','文件命名规则','rulePram',500,200);document.form1.DirData2.focus();" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_20',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="20%" align="right">
                                        索引页规则：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DirData3" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <img src="../imges/bgxiu_14.gif"  align="middle" alt="索引页规则" border="0" style="cursor: pointer;"
                                            onclick="selectFile('DirData3','索引页规则','rulePram',500,200);document.form1.DirData3.focus();" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_21',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_16">
                                    <td width="20%" align="right">
                                        新闻浏览文件命名规则：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NewsDisplay" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <img src="../imges/bgxiu_14.gif"  align="middle" alt="命名规则" border="0" style="cursor: pointer;" onclick="selectFile('NewsDisplay','命名规则','rulePram',500,200);document.form1.NewsDisplay.focus();" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_22',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td width="20%" align="right">
                                        图片上传目录:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ImageUpload" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_23',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_18">
                                    <td width="20%" align="right">
                                        浏览权限：
                                    </td>
                                    <td>
                                        <div class="neitab2">
                                            <uc2:UserPop ID="UserPop1" runat="server" />
                                            <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_24',this)">
                                                帮助</span></div>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_19">
                                    <td width="20%" align="right">
                                        生成文件的扩展名：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ExDropDownList" runat="server" class="select4">
                                            <asp:ListItem>.html</asp:ListItem>
                                            <asp:ListItem>.htm</asp:ListItem>
                                            <asp:ListItem>.shtml</asp:ListItem>
                                            <asp:ListItem>.shtm</asp:ListItem>
                                            <asp:ListItem>.aspx</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_25',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_20">
                                    <td width="20%" align="right">
                                        允许画中画：
                                    </td>
                                    <td>
                                        <input type="checkbox" id="draw" onclick="javascript:IsCode();" runat="server"  class="checkbox2"/>
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_26',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_21" style="display: none">
                                    <td width="20%" align="right">
                                        图片或者代码：
                                    </td>
                                    <td>
                                        <div class="textdiv">
                                            <asp:TextBox ID="drawUrl" runat="server" Width="50%" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                                            <img src="../imges/bgxiu_14.gif"  align="middle" alt="选取画中画地址" border="0" style="cursor: pointer;"
                                                onclick="selectFile('drawUrl','画中画地址','pic',280,500);document.form1.drawUrl.focus();" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_22" style="display: none">
                                    <td width="20%" align="right">
                                        画中画参数设置：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="drawHeight" runat="server" CssClass="input8"></asp:TextBox>px(高)&nbsp;&nbsp;&nbsp;&nbsp;┊
                                        <asp:TextBox ID="drawWith" runat="server" CssClass="input8"></asp:TextBox>px(宽)
                                    </td>
                                </tr>
                                <tr id="ClssStyle_26">
                                    <td width="20%" align="right">
                                        栏目导航说明：
                                    </td>
                                    <td>
                                        <div class="textdiv">
                                            <asp:TextBox ID="fontText" runat="server" Height="50px" TextMode="MultiLine" Width="40%"
                                                CssClass="textarea"></asp:TextBox>
                                            <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_27',this)">
                                                帮助</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_27">
                                    <td width="20%" align="right">
                                        栏目导航图片：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="fileLoad" runat="server" Width="40%" CssClass="input4"></asp:TextBox>
                                        <img src="../imges/bgxiu_14.gif"  align="middle" alt="选择已有图片" border="0" style="cursor: pointer;"
                                            onclick="selectFile('fileLoad','选择图片','pic',500,500);document.form1.fileLoad.focus();" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_28',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_29">
                                    <td width="20%" align="right">
                                        Meta关键字：
                                    </td>
                                    <td>
                                        <div class="textdiv">
                                            <asp:TextBox ID="KeyMeata" runat="server" Height="50px" Width="40%" TextMode="MultiLine"
                                                CssClass="textarea"></asp:TextBox>
                                            <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_30',this)">
                                                帮助</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_30">
                                    <td width="20%" align="right">
                                        Meta描述：
                                    </td>
                                    <td>
                                        <div class="textdiv">
                                            <asp:TextBox ID="BeWrite" runat="server" Width="40%" Height="50px" TextMode="MultiLine"
                                                CssClass="textarea"></asp:TextBox>
                                            <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_31',this)">
                                                帮助</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="ClssStyle_31">
                                    <td width="20%" align="right">
                                        用户可以发表言论：
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Saying" runat="server" CssClass="checkbox2" Checked="true" />
                                        <span class="helpstyle" style="cursor: hand; color:#828282;" title="点击查看帮助" onclick="Help('Class_Aspx_32',this)">
                                            帮助</span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="nxb_submit">
                        <asp:HiddenField ID="Hidden" runat="server" Value="0" />
                        <asp:HiddenField ID="ClassID" runat="server" />
                        <asp:HiddenField ID="csHiden" runat="server" />
                        <asp:Button ID="btnClick" runat="server" Text="提交数据" OnClick="btnClick_Click" CssClass="xsubmit1" />
                        <input type="reset" class="xsubmit1" value="重新填写" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dialog-message" title="提示"></div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    var aa = document.getElementById("csHiden").value;
    if (aa == 1)
        CheckedCode();

    //是否外部栏目
    function CheckedCode() {
        if (document.getElementById("CProject").checked) {
            document.getElementById("tab_zzjs_02").style.display = "none";
            document.getElementById("ClssStyle_5").style.display = "";
            document.getElementById("tab_zzjs_2").style.display = "none";
            document.getElementById("ClssStyle_6").style.display = "none";
            document.getElementById("ClssStyle_7").style.display = "none";
            document.getElementById("ClssStyle_8").style.display = "none";
            document.getElementById("ClssStyle_9").style.display = "none";
            document.getElementById("ClssStyle_12").style.display = "none";
            document.getElementById("ClssStyle_11").style.display = "none";
            document.getElementById("ClssStyle_32").style.display = "none";
            document.getElementById("ClssStyle_35").style.display = "none";

        }
        else {
            document.getElementById("tab_zzjs_02").style.display = "";
            document.getElementById("ClssStyle_5").style.display = "none";
            document.getElementById("tab_zzjs_2").style.display = "block";
            document.getElementById("ClssStyle_6").style.display = "";
            document.getElementById("ClssStyle_7").style.display = "";
            document.getElementById("ClssStyle_8").style.display = "";
            document.getElementById("ClssStyle_9").style.display = "";
            document.getElementById("ClssStyle_12").style.display = "";
            document.getElementById("ClssStyle_11").style.display = "";
            document.getElementById("ClssStyle_32").style.display = "";
            document.getElementById("ClssStyle_35").style.display = "";
        }
    }

    //是否允许显示画中画
    function IsCode() {
        var flag = document.getElementById("draw").checked;
        if (flag) {
            document.getElementById("ClssStyle_21").style.display = "";
            document.getElementById("ClssStyle_22").style.display = "";
        }
        else {
            document.getElementById("ClssStyle_21").style.display = "none";
            document.getElementById("ClssStyle_22").style.display = "none";
        }
    }
    //高级选项
    function DispChange() {
        var obj = document.getElementById("chkAdvance").checked;
        var cap = document.getElementById("captionadv");
        var tb = document.getElementById("tableSetting");
        if (obj) {
            cap.src = "../../sysImages/folder/hidead.gif";
            for (var i = 15; i < tb.rows.length; i++) {
                var obj = tb.rows[i];
                if (obj.id != null && obj.id != "")
                    document.getElementById(obj.id).style.display = "";
            }
        }
        else {
            cap.src = "../../sysImages/folder/showad.gif";
            for (var i = 15; i < tb.rows.length; i++) {
                var obj = tb.rows[i];
                if (obj.id != null && obj.id != "")
                    document.getElementById(obj.id).style.display = "none";
            }
        }
        document.getElementById("ClssStyle_33").style.display = "";
    }

    function getDefinedData(obj) {
        var c = 0;
        var define = document.getElementById("DefineRows");
        var hiddenDef = document.getElementById("HiddenDefine")
        var j = 0;
        for (var i = 0; i < obj.length; i++) {
            if (obj.options[i].selected) {
                if (!IsDisValue(obj.options[i].value)) {
                    define.options[define.options.length] = new Option(obj.options[i].text, obj.options[i].value);
                    if (j > 0 || define.length > 1) {
                        hiddenDef.value += ",";
                    }
                    hiddenDef.value += obj.options[i].value;
                    j++;
                }
                else {
                    displayLoad.innerHTML = "<font color=red>[" + obj.options[i].text + "]栏目已选择，不能重复选择！</font>"
                }
                break;
            }
        }
    }

    function clearDefine() {
        var define = document.getElementById("DefineRows");
        var hiddenDef = document.getElementById("HiddenDefine")
        hiddenDef.value = "";
        clearall(define);
    }

    function clearall(obj) {
        var testnum = obj.length;
        for (var j = testnum - 1; j >= 0; j--) {

            obj.options[j] = null;
        }
    }

    function IsDisValue(p) {
        var flg = false;
        var define = document.getElementById("DefineRows");
        if (define.value != null || define.value != "") {
            for (var i = 0; i < define.length; i++) {
                if (define.options[i].value == p) {
                    flg = true;
                    break;
                }
            }
        }
        return flg;
    }

    //function GetPositionHtml(str,str1)
    //{
    //      document.form1.HtmlPhrasing.value = "<a href=\"<%Response.Write(dirm); %>/\">首页</a> >> {@ParentClassStr} >> "+str1+"";
    //      document.form1.NewsHtmlPhrasing.value = "<a href=\"<%Response.Write(dirm); %>/\">首页</a> >> {@ParentClassStr} >> <a href=\"{@ClassURL}\">"+str1+"</a> >> 正文";
    //}

    function GetPY1(obj) {
        if (document.getElementById('ClassID').value == "") {
            var s = obj.value;
            if (s != '') {
                document.getElementById('TEname').value = GetPY(s);
                $('#DirData2').val($('#DirData2').val().replace("{@EName}",GetPY(s)));
            }
        }
        TEname_1();
    }

    
    function TEname_1() {
        if ($('#TEname').val() == '') {
            $('#HtmlPhrasing').val('');
            $('#NewsHtmlPhrasing').val('');
        }
        else {
            $('#HtmlPhrasing').val('<a href=\"<%Response.Write(dirm); %>/\">首页</a> >> {@ParentClassStr} ' + document.getElementById("TCname").value + ' ');
            $('#NewsHtmlPhrasing').val('<a href=\"<%Response.Write(dirm); %>/\">首页</a> >> {@ParentClassStr} <a href=\"{@ClassURL}\">' + document.getElementById("TCname").value + '</a> >> 正文');
        }
    }
</script>

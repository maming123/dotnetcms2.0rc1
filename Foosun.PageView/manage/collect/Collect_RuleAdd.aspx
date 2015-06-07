<%@ Page Language="C#" AutoEventWireup="true" Inherits="Collect_RuleAdd" Codebehind="Collect_RuleAdd.aspx.cs" %>

<%@ Register Src="CollectEditor.ascx" TagName="CollectEditor" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>FoosunCMS For .NET v2.0.0</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form2" runat="server">
    <div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>采集系统</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="Collect_List.aspx">采集系统</a> >><asp:Label ID="LblTitle" runat="server"></asp:Label>
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能：</span>
        <a class="topnavichar" href="Collect_List.aspx">站点设置</a>&nbsp;┊&nbsp;<a class="topnavichar"
                            href="Collect_News.aspx">新闻处理</a>&nbsp;┊&nbsp;<a class="topnavichar" href="Collect_RuleList.aspx">过滤规则列表</a>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
         <table class="nxb_table">
                <tr>
                    <td  width="15%" align="right">
                        规则名称：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtRuleName" MaxLength="50" CssClass="input4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请填写规则名称!"
                            ControlToValidate="TxtRuleName" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td  width="15%" align="right">
                        过滤字符串：
                    </td>
                    <td>
                        <uc1:CollectEditor ID="EdtOldStr" runat="server" SetMaxLength="100" />
                        <asp:CheckBox runat="server" ID="ChbCase" Text="忽略大小写" CssClass="checkbox2" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        替换为：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtNewStr" Width="58%" Height="51px" TextMode="MultiLine"
                            MaxLength="100" CssClass="textarea2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  width="15%" align="right">
                        应用到：
                    </td>
                    <td>
                        <div style="width: 520px; padding-left:10px; line-height:30px; margin-top:10px; height: 120px; overflow: auto; background-color: White; border-color: #cccccc; border-width: 1px; border-style: groove; margin-left:10px;">
                            <asp:CheckBoxList runat="server" ID="TabRuleApply" RepeatLayout="Flow"></asp:CheckBoxList>
                        </div>
                        <span style="color: #ff0033; margin-left:10px; line-height:20px; padding-bottom:8px;">注：每个站点只能应用一个规则，每个规则可以应用到多个站点;
                            <br />
                            &nbsp;&nbsp;&nbsp;灰色字表示该采集站点已经应用其他的规则。</span></td>
                </tr>
                <tr>
                    <td class="list_link" colspan="2" align="center">
                        
                    </td>
                </tr>
            </table>
            <div class="nxb_submit" >
            <asp:HiddenField ID="RID" runat="server" />
                        <asp:Button ID="BtnOK" Text=" 保 存 " runat="server" CssClass="xsubmit1" OnClick="BtnOK_Click" />
                        <asp:Button ID="Button1" Text=" 重 置 " runat="server" CssClass="xsubmit1" CausesValidation="False" />
           </div>
         </div>
      </div>
   </div>
</div>
</div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newpublish.aspx.cs" Inherits="Foosun.PageView.configuration.system.newpublish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
//<!CDATA[
function g(o) { return document.getElementById(o); }
function hover_zzjs_net(n,m,k) {
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
<form id="form1" runat="server">
<div class="mian_body">
  <div class="mian_cont">
    <div class="nwelie">
      <div class="newxiu_lan">
        <ul class="tab_zzjs_" id="tab_zzjs_">
          <li id="tab_zzjs_1" class="hovertab_zzjs" onclick="x:hover_zzjs_net(1,1,4);">首页、新闻设置 </li>
          <li id="tab_zzjs_2" class="nor_zzjs" onclick="x:hover_zzjs_net(2,1,4);">栏目设置 </li>
          <li id="tab_zzjs_3" class="nor_zzjs" onclick="x:hover_zzjs_net(3,1,4);"> 专题设置</li>
          <li id="tab_zzjs_4" class="nor_zzjs" onclick="x:hover_zzjs_net(4,1,4);">单页设置 </li>
        </ul>
        <div class="newxiu_bot">
          <div class="dis_zzjs_net" id="tab_zzjs_01">
            <div id="DivStat">
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
            </div>
          </div>
          <div class="undis_zzjs_net" id="tab_zzjs_02">
            <div id="DivStat">
              
              
            </div>
          </div>
          <div class="undis_zzjs_net" id="tab_zzjs_03">
            <div id="DivStat">
                
            </div>
          </div>
          <div class="undis_zzjs_net" id="tab_zzjs_04">
            <div id="DivStat">

            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</form>
</body>
</html>

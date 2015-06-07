<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="Foosun.PageView.manage.news.NewsManage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>

<body>
<form id="Form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>新闻管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="NewsList.aspx">新闻管理</a> >>
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie" style="margin-top:15px;">
      <div class="newxiu_base">
    <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" class="movetab">
    <tr class="TR_BG_list">
        <td class="list_link" width="30%" valign="top"  style="padding:10px; ">
            <table border="0" width="100%" cellpadding="1" cellspacing="1">
                <tr>
                    <td>
                        <asp:DropDownList ID="DdlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlType_SelectedIndexChanged" Width="100%">
                            <asp:ListItem Value="0">指定新闻</asp:ListItem>
                            <asp:ListItem Value="1">指定栏目</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                </tr>
                <tr height="231">
                    <td>
                      <asp:ListBox ID="LstOriginal" runat="server" Width="100%" Height="231" SelectionMode="Multiple"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </td>
	    <td class="list_link" width="10%" align="center"  style="padding:10px; ">
            <asp:Label ID="LblNarrate" runat="server"/><asp:Label ID="LblIDs" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblNewsTable" runat="server" Visible="False"></asp:Label></td>
	    <td class="list_link" width="60%" valign="top"  style="padding:10px; ">
	    <!--移动或是复制-->
            <asp:Panel ID="Panel1" runat="server">
                <table border="0" width="98%">
                    <tr>
                        <td>
                        </td>
                     </tr>
                     <tr>
                        <td>
                        </td>
                     </tr>
                     <tr>
                        <td><asp:ListBox ID="LstTarget" runat="server" Width="100%" Height="245"></asp:ListBox></td>
                     </tr>
                  </table>
            </asp:Panel>
            <!--批量设置属性-->
            <asp:Panel runat="server" ID="Panel2">
                <table border="0" width="100%">                    
                    <tr>
                        <td>属性：
                            <asp:CheckBox ID="NewsProperty_CommTF1" runat="server" />允许评论&nbsp;
                            <asp:CheckBox ID="NewsProperty_DiscussTF1" runat="server" />允许创建讨论组&nbsp;
                            <asp:CheckBox ID="NewsProperty_RECTF1" runat="server" />推荐&nbsp;
                            <asp:CheckBox ID="NewsProperty_MARTF1" runat="server" />滚动&nbsp;
                            <asp:CheckBox ID="NewsProperty_HOTTF1" runat="server" />热点&nbsp;
                            <asp:CheckBox ID="NewsProperty_FILTTF1" runat="server" />幻灯&nbsp;
                            <asp:CheckBox ID="NewsProperty_TTTF1"  runat="server" />头条&nbsp;
                            <asp:CheckBox ID="NewsProperty_ANNTF1" runat="server" />公告&nbsp;
                            <asp:CheckBox ID="NewsProperty_JCTF1" runat="server" />精彩&nbsp;
                            <asp:CheckBox ID="NewsProperty_WAPTF1" runat="server" />WAP&nbsp;
                            <asp:Button ID="Button9" runat="server" OnClick="pro_click" Text="设置属性" />
				        </td>
		            </tr>
		            <tr>
			            <td>模　板：
			                <asp:TextBox Width="40%" ID="Templet" runat="server"/>
			                <img src="../imges/bgxiu_14.gif"  align="middle" alt="" border="0" style="cursor:pointer;" onclick="selectFile('templet',document.Form1.Templet,250,400);document.Form1.Templet.focus();" />
                            <asp:Button ID="Button2" runat="server" OnClick="templet_click" Text="设置模板" /></td>
		            </tr>
		            <tr>
			            <td>权　重：
			              <asp:DropDownList ID="OrderIDDropDownList" runat="server">
                            <asp:ListItem Value="" Text="选择权重" />
                            <asp:ListItem Value="10" Text="10" />
                            <asp:ListItem Value="9" Text="9" />
                            <asp:ListItem Value="8" Text="8" />
                            <asp:ListItem Value="7" Text="7" />
                            <asp:ListItem Value="6" Text="6" />
                            <asp:ListItem Value="5" Text="5" />
                            <asp:ListItem Value="4" Text="4" />
                            <asp:ListItem Value="3" Text="3" />
                            <asp:ListItem Value="2" Text="2" />
                            <asp:ListItem Value="1" Text="1" />
                            <asp:ListItem Value="0" Text="0"/>
                          </asp:DropDownList>
                            <asp:Button ID="Button3" runat="server" OnClick="order_click" Text="设置权重" /></td>
		            </tr>   	
		            <tr>
			            <td>评　论：
			                <asp:CheckBox ID="CommLinkTF" runat="server"/>
				            标题后显示&quot;评论&quot;字样
                            <asp:Button ID="Button4" runat="server" OnClick="comm_click" Text="设置评论" /></td>
		            </tr>
		            <tr>
			            <td>标　签：
			            <asp:TextBox ID="Tags" runat="server" MaxLength="100" Width="40%"></asp:TextBox><img src="../imges/bgxiu_14.gif"  align="middle" alt="选择已有标签" border="0" style="cursor:pointer;" onclick="selectFile('Tag',document.Form1.Tags,220,480);document.Form1.Tags.focus();" />
                            <asp:Button ID="Button5" runat="server" OnClick="tag_click" Text="设置TAG标签" /></td>
		            </tr>
		            <tr>
			            <td>点击数：
			                <asp:TextBox ID="Click" Width="40%" runat="server"/>
                            <asp:Button ID="Button6" runat="server" OnClick="click_click" Text="设置点击" /></td>
		            </tr>
		            <tr>
			            <td>
                            来　源：
                            <asp:TextBox ID="Souce" runat="server"  Width="40%" MaxLength="100"></asp:TextBox><img src="../imges/bgxiu_14.gif"  align="middle" alt="选择已有来源" border="0" style="cursor:pointer;" onclick="selectFile('Souce',document.Form1.Souce,220,450);document.Form1.Souce.focus();" />
                            <asp:Button ID="Button7" runat="server" OnClick="source_click" Text="设置来源" /></td>
		            </tr>
		            <tr>
			            <td class="hback"> 扩展名：
			        <asp:DropDownList ID="FileEXName" runat="server" Height="21px" Width="92px">
                    <asp:ListItem Value="">选择扩展名</asp:ListItem>
                    <asp:ListItem>.html</asp:ListItem>
                    <asp:ListItem>.htm</asp:ListItem>
                    <asp:ListItem>.shtml</asp:ListItem>
                    <asp:ListItem>.shtm</asp:ListItem>
                    <asp:ListItem>.aspx</asp:ListItem>
                </asp:DropDownList>
                            <asp:Button ID="Button8" runat="server" OnClick="exname_click" Text="设置扩展名" /> 说明：如果为标题新闻，此设置不起作用</td>
		            </tr>
		            <tr>
			            <td></td>
		            </tr>
               </table>
            </asp:Panel>
	    </td>
	</tr>
	<tr class="TR_BG_list">
	    <td colspan="3" align="center" class="list_link" style=" padding:5px 0;">
	    <asp:Button runat="server" ID="BtnOK" OnClick="BtnOK_Click" CssClass="xsubmit3"/>
            <asp:Button ID="Button1" runat="server" Text=" 重置 "  CssClass="xsubmit1"/></td>
	</tr>
  </table>
       </div>
   </div>
</div>
</div>
</form>
</body>
</html>
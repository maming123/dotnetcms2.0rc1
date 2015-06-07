<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usermycom.aspx.cs" Inherits="Foosun.PageView.manage.user.usermycom" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import NameSpace="System.Data"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function del(ID) {
        if (confirm("你确定要删除吗?")) {
            self.location = "?Type=del&ID=" + ID;
        }
    }
    function PDel() {
        if (confirm("你确定要彻底删除吗?")) {
            document.form1.action = "?Type=PDel";
            document.form1.submit();
        }
    }
    function opencats() {
        if (document.getElementById("searchuserID").style.display == "none") {
            document.getElementById("searchuserID").style.display = "";
        } else {
            document.getElementById("searchuserID").style.display = "none";
        }
    }
    function getchanelInfo(obj) {
        var SiteID = obj.value;
        window.location.href = "usermycom.aspx?SiteID=" + SiteID + "";
    }
    $(function () {
        $("input[name='Checkboxc']").click(function () {
            if (this.checked) {
                $("input[name='Checkbox1']").attr('checked', true);
            }
            else {
                $("input[name='Checkbox1']").attr('checked', false);
            }
        });
    });
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>评论管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>评论管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <a href="usermycom.aspx">全部评论</a>┋<a href="usermycom.aspx?GoodTitle=1">精华帖</a>┋<a href="javascript:opencats()">搜索</a><span id="channelList" runat="server" /></span>
      </div>
      <div class="userquery">
         <table width="99%" align="center" cellpadding="0" cellspacing="0" id="searchuserID" style="display:none">
            <tr>
               <td width="25%">用户名：<asp:TextBox ID="UserNumbox" runat="server"  class="uinput"></asp:TextBox></td>
               <td width="20%">标题：<asp:TextBox ID="Title1" runat="server" class="uinput"></asp:TextBox></td>
               <td width="30%"></td>
               <td width="25%">被评论信息：<asp:TextBox ID="InfoTitle1" runat="server"  class="uinput"></asp:TextBox></td>
            </tr>
            <tr>
               <td>审核：
               <asp:DropDownList ID="isCheck1" runat="server" class="xselect1">
                <asp:ListItem Value="0">请选择</asp:ListItem>
                <asp:ListItem Value="1">否</asp:ListItem>
                <asp:ListItem Value="2">是</asp:ListItem>
            </asp:DropDownList>
               </td>
               <td>锁定：
               <asp:DropDownList ID="islock1" runat="server" class="xselect1">
                <asp:ListItem Value="0">请选择</asp:ListItem>
                <asp:ListItem Value="1">否</asp:ListItem>
                <asp:ListItem Value="2">是</asp:ListItem>
            </asp:DropDownList>
               </td>
               <td>日期：<asp:TextBox ID="creatTime1" runat="server" class="uinput"></asp:TextBox>-<asp:TextBox ID="creatTime2" runat="server" class="uinput"></asp:TextBox></td>
               <td><input type="button" value="搜索" name="" runat="server" class="xsubmit1" onserverclick="Button8_ServerClick"/></td>
            </tr>
         </table>
      </div>
      <div class="jslie_lie">
       <div id="no" runat="server"></div>  
       <asp:Repeater ID="DataList1" runat="server">
       <HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="5%"></th>
               <th width="32%">标题</th>
               <th width="8%">类型</th>
               <th width="30%">被评论信息</th>
               <th width="10%">状态</th>
               <th width="15%">操作<input type="checkbox" name="Checkboxc" value="" class="checkbox1" /></th>
            </tr>
             </HeaderTemplate>
          <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
           <td align="center" ><%#((DataRowView)Container.DataItem)["OrderIDs"]%></td>
            <td align="left"><span class="span1"></span><%#((DataRowView)Container.DataItem)["Content"]%>&nbsp;(<%#((DataRowView)Container.DataItem)["UserNames"]%>)&nbsp;<%#((DataRowView)Container.DataItem)["GoodTitles"]%>
            <span style="color:#999999;font-size:10px;"><%#((DataRowView)Container.DataItem)["creatTime"]%></span>
            </td>
            <td align="center"><%#((DataRowView)Container.DataItem)["APIIDTitle"]%></td>
            <td align="center"><%#((DataRowView)Container.DataItem)["InfoTitle"]%>
            </td>
            <td align="center"><%#((DataRowView)Container.DataItem)["islocks"]%></td>
            <td align="center"><%#((DataRowView)Container.DataItem)["Operation"]%></td>
            </tr>
       </ItemTemplate>
          <FooterTemplate>
          </table>
         </FooterTemplate>
    </asp:Repeater> 
         <div class="fanye1">
            <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
         </div>
         <div class="users">            
            <asp:Button ID="TopTitle1" runat="server" Text="固顶" class="xsubmit1" OnClick="TopTitle1_Click"/>
<asp:Button ID="TopTitle12" runat="server" Text="解固" class="xsubmit1" OnClick="TopTitle12_Click"/>
<asp:Button ID="GoodTitle" runat="server" Text="精华" class="xsubmit1" OnClick="GoodTitle_Click"/>
<asp:Button ID="UNGoodTitle" runat="server" Text="取消精华" class="xsubmit1" OnClick="unGoodTitle_Click"/>
<span style="display:none;">
<asp:Button ID="CheckTtile" runat="server" Text="审核" class="xsubmit1" OnClick="CheckTtile_Click"/>
<asp:Button ID="Button3" runat="server" Text="取消审核" class="xsubmit1" OnClick="unCheckTtile_Click"/>
</span>
<asp:Button ID="OCTF1" runat="server" Text="锁定" class="xsubmit1" OnClick="OCTF1_Click"/>
<asp:Button ID="OCTF2" runat="server" Text="解锁" class="xsubmit1" OnClick="OCTF2_Click"/>
<asp:Button ID="Button4" runat="server" Text="删除" class="xsubmit1" OnClientClick="PDel();"/>
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

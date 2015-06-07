<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pointhistory.aspx.cs" Inherits="Foosun.PageView.manage.user.pointhistory" %>
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
<script type="text/javascript" language="javascript">
    function getchanelInfo(obj) {
        var SiteID = obj.value;
        window.location.href = "?SiteID=" + SiteID + "";
    }
    function del(ID) {
        if (confirm("你确定要删除吗?")) {
            self.location = "?Types=del&ID=" + ID;
        }
    }
    function PDel() {
        if (confirm("你确定要彻底删除吗?")) {
            document.form1.action = "?Types=PDel";
            document.form1.submit();
        }
    }
    function getchanelInfo(obj) {
        var SiteID = obj.value;
        window.location.href = "?SiteID=" + SiteID + "";
    }
</script>
</head>

<body>
   <form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>充值记录</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>充值记录
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <a href="pointhistory.aspx?type=0&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar">全部交易</a>&nbsp;┋&nbsp;<a href="pointhistory.aspx?type=2&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar">在线充值</a>&nbsp;┋&nbsp;<a href="pointhistory.aspx?type=3&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar" >积分兑换</a>&nbsp;┋&nbsp;<a href="pointhistory.aspx?type=4&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar" >稿酬</a>&nbsp;┋&nbsp;<a href="pointhistory.aspx?type=5&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar" >阅读权限</a>&nbsp;┋&nbsp;<a href="pointhistory.aspx?type=1&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar" >捐献</a>&nbsp;┋&nbsp;<a href="pointhistory.aspx?type=6&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar" >登录获得</a>&nbsp;┋&nbsp;<a href="pointhistory.aspx?type=7&UserNum=<%= Request.QueryString["UserNum"]%>" class="topnavichar" >注册获得</a>&nbsp;┋&nbsp;<a href="javascript:PDel();" class="topnavichar">批量删除</a><span id="channelList" runat="server" />
      </div>
      <div class="jslie_lie">
      <div id="no" runat="server" style="padding-left:10px !important; line-height:24px;"></div>
    <asp:Repeater ID="userlists" runat="server">
       <HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="15%">用户名</th>
               <th width="10%">收入</th>
               <th width="10%">G币</th>
               <th width="10%">积分</th>
               <th width="10%">现金</th>
               <th width="10%">说明</th>
               <th width="15%">操作日期</th>
               <th width="20%">操作</th>
            </tr>
              </HeaderTemplate>
          <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
             <td align="center" valign="middle"><%#((DataRowView)Container.DataItem)["UserName"]%></td>
             <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["ghtypes"]%></td>
             <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["Gpoint"]%></td>
             <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["iPoint"]%></td>
             <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["Moneys"]%></td>
            <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["content"]%></td>
            <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["CreatTime"]%></td>
            <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["op"]%></td>
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
             用户名：<asp:TextBox ID="UserNameBox" runat="server" class="input7"></asp:TextBox>&nbsp;&nbsp;
       <asp:DropDownList ID="DropDownList1" runat="server" CssClass="xselect2">
       <asp:ListItem Value="0">全部交易</asp:ListItem>
       <asp:ListItem Value="2">在线冲值</asp:ListItem>
       <asp:ListItem Value="3">积分兑换</asp:ListItem>
       <asp:ListItem Value="4">稿酬</asp:ListItem>
       <asp:ListItem Value="5">阅读权限</asp:ListItem>
       <asp:ListItem Value="1">捐献</asp:ListItem>
       <asp:ListItem Value="6">登录获得</asp:ListItem>
       <asp:ListItem Value="7">注册获得</asp:ListItem>
       <asp:ListItem Value="8">收入</asp:ListItem>
       <asp:ListItem Value="9">支出</asp:ListItem>
   </asp:DropDownList>&nbsp;
       <asp:Button ID="selbut" runat="server" Text="搜索" OnClick="selbut_Click" class="form2"/>
            </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

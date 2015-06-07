<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="announce.aspx.cs" Inherits="Foosun.PageView.manage.user.announce" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
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
        window.location.href = "announce.aspx?SiteID=" + SiteID + "";
    }
</script>
</head>

<body>
   <form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>公告管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>公告管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <a href="announce.aspx">公告列表</a>┋<a href="announceadd.aspx">添加公告</a><span id="channelList" runat="server" />
      </div>
      <div class="jslie_lie">
    <asp:Repeater ID="announcelists" runat="server">
       <HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="60%" align="left"><span class="span1">标题</span></th>
               <th width="15%">发布日期</th>
               <th width="10%">状态</th>
               <th width="15%">操作</th>
            </tr>
              </HeaderTemplate>
          <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td><span class="span1"><%#Eval("title")%></span></td>
              <td align="center"><%#Eval("creatTime")%></td>
              <td align="center"><%#Eval("islocks")%></td>
              <td align="center">
                <%#Eval("op")%>
              </td>
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
              <asp:Button ID="Button1" class="xsubmit1" runat="server" onclick="islock" Text="批量锁定" OnClientClick="{if(confirm('确定要锁定吗？')){return true;}return false;}"  />
             <asp:Button  ID="Button2"  class="xsubmit1" runat="server" onclick="unlock" Text="批量解锁" OnClientClick="{if(confirm('确定要解锁吗？')){return true;}return false;}"  />
             <asp:Button ID="Button3"  class="xsubmit1"  runat="server" onclick="delmul" Text="批量删除" OnClientClick="{if(confirm('确定要删除吗？')){return true;}return false;}" />
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

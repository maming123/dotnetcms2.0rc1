<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlist.aspx.cs" Inherits="Foosun.PageView.manage.user.userlist" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
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
    function getFormInfo(obj) {
        var GroupNumber = obj.value;
        window.location.href = "userList.aspx?GroupNumber=" + GroupNumber + "";
    }
    function getchanelInfo(obj) {
        var SiteID = obj.value;
        window.location.href = "userList.aspx?SiteID=" + SiteID + "";
    }

    function opencats(cat) {
        if (document.getElementById(cat).style.display == "none") {
            document.getElementById(cat).style.display = "";
        } else {
            document.getElementById(cat).style.display = "none";
        }
    }
    $(function () {
        $("input[name='Checkboxc']").click(function () {
            if (this.checked) {
                $("input[name='uid']").attr('checked', true);
            }
            else {
                $("input[name='uid']").attr('checked', false);
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
      <div class="mian_wei_left"><h3>会员管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>会员管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <a href="userlist.aspx">会员首页</a>┋<a href="userAdd.aspx">添加会员</a>┋<a href="userlist.aspx?usertype=">所有会员</a>┋<a href="userlist.aspx?usertype=0">开放的会员</a>┋<a href="userlist.aspx?usertype=1">锁定的会员</a>┋<a href="userlist.aspx?iscert=1">实名认证用户</a>┋<a href="userlist.aspx?iscert=2">审核实名认证用户</a>┋<span style="cursor: hand" onclick="opencats('searchuserID');">查询</span>┋
         <span id="groupList" runat="server" /><span id="channelList" runat="server" />
      </div>
       <div class="userquery" style="display:none" id="searchuserID">
         用户名：<input type="text" name="username" value=""  class="uinput"/>姓名：<input type="text" name="realname" value=""  class="uinput"/> 
         编号：<input type="text" name="userNum" value=""  class="uinput"/>性别：<select><option value="1">男</option>
					<option value="2">女</option>
					<option value="0">保密</option>
					<option value="" selected="selected">不限制</option></select><br />
         积分：>=<input type="text" name="ipoint" value=""  class="uinput1"/><= <input type="text" name="bipoint" value=""  class="uinput1"/>
         G 币：>=<input type="text" name="gpoint" value=""  class="uinput1"/><=<input type="text" name="bgpoint" value=""  class="uinput1"/>
        <input type="button" name="Submit" value="搜索" runat="server" class="xsubmit1" id="Button8" onserverclick="Button8_ServerClick" />
      </div>
      <div class="jslie_lie">
      <asp:Repeater ID="userlists" runat="server">
		<HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="20%">用户名</th>
               <th width="10%">所属会员组</th>
               <th width="10%">点数</th>
               <th width="10%">G币</th>
               <th width="10%">状态 </th>
               <th width="20%">登陆日期 </th>
               <th width="20%">操作 <input type="checkbox" name="Checkboxc"  value=""/></th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td align="center"><%#((DataRowView)Container.DataItem)["userNames"]%></td>
              <td align="center"><%#((DataRowView)Container.DataItem)["groupname"]%></td>
              <td align="center"><%#((DataRowView)Container.DataItem)["iPoint"]%></td>
              <td align="center"><%#((DataRowView)Container.DataItem)["gPoint"]%></td>
              <td align="center"><%#((DataRowView)Container.DataItem)["lock"]%></td>
              <td align="center"><%#((DataRowView)Container.DataItem)["LastLoginTime"]%></td>
              <td align="left">
              <%#((DataRowView)Container.DataItem)["op"]%>               
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
         	    <asp:Button ID="Button1" class="xsubmit1" runat="server" OnClick="islock" Text="批量锁定" OnClientClick="{if(confirm('确定要锁定吗？')){return true;}return false;}" />&nbsp;
				<asp:Button ID="Button2" class="xsubmit1" runat="server" OnClick="unlock" Text="批量解锁" OnClientClick="{if(confirm('确定要解锁吗？')){return true;}return false;}" />&nbsp;
				<asp:Button ID="Button3" class="xsubmit1" runat="server" OnClick="dels" Text="批量删除" OnClientClick="{if(confirm('确定要删除吗？')){return true;}return false;}" />&nbsp;
				<asp:Button ID="Button4" class="xsubmit1" runat="server" OnClick="bIpoint" Text="增加点数" />&nbsp;
				<asp:Button ID="Button5" class="xsubmit1" OnClick="sIpoint" runat="server" Text="扣除点数" />&nbsp;
				<asp:Button ID="Button6" class="xsubmit1" OnClick="bGpoint" runat="server" Text="增加G币" />&nbsp;
				<asp:Button ID="Button7" class="xsubmit1" OnClick="sGpoint" runat="server" Text="扣除G币" />&nbsp;
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="Foosun.PageView.manage.sys.AdminList" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3> 管理员管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a> >>管理员管理  
      </div>
   </div>
</div>
<div class="mian_cont">
    <div class="nwelie">
        <div class="jslie_lan">
         <a href="AdminAdd.aspx" class="topnavichar">添加管理员</a>
      </div>
      <div class="jslie_lie">
<asp:Repeater ID="DataList1" runat="server">
   <HeaderTemplate>
       <table class="jstable">
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <th width="15%">用户名</th>
        <th width="15%">姓名</th>
        <th width="20%">电子邮件</th>
        <th width="10%">超级管理员</th>
        <th width="10%">状态</th>
        <th width="30%">操作</th>
      </tr>   
    </HeaderTemplate>
      <ItemTemplate>
        <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <td align="center"><%#((DataRowView)Container.DataItem)["userNames"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[2]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[3]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[7]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[9]%></td>
        <td><%#((DataRowView)Container.DataItem)["Op"]%></td>
        </tr>
      </ItemTemplate>
      <FooterTemplate>
      </table>
     </FooterTemplate>
</asp:Repeater>
        <div class="fanye1">
            <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
         </div>
</div>

    </div>
</div>
</div>
</form>
</body>
<script language="javascript" type="text/javascript">
    function Lock(ID) {
        self.location = "?Type=Lock&ID=" + ID;
    }
    function UnLock(ID) {
        self.location = "?Type=UnLock&ID=" + ID;
    }
    function Del(ID) {
        if (confirm('你确认删除此管理员吗?')) {
            self.location = "?Type=Del&ID=" + ID;
        }
    }
    function Update(ID) {
        self.location = "AdminEdit.aspx?Type=Update&ID=" + ID;
    }
    function getchanelInfo(obj) {
        var SiteID = obj.value;
        window.location.href = "AdminList.aspx?SiteID=" + SiteID + "";
    }

</script>
</html>

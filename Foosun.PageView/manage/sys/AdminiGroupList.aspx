<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminiGroupList.aspx.cs" Inherits="Foosun.PageView.manage.sys.AdminiGroupList" %>

<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
       <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
    <div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>管理员组管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>管理员组管理
      </div>
   </div>
</div> 
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <a href="AdminGroupAdd.aspx">添加管理员组</a>
      </div>
      <div class="jslie_lie">
    <asp:Repeater ID="DataList1" runat="server">
       <HeaderTemplate>
           <table class="jstable">
          <tr  class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
            <th>编号</th>
            <th>名称</th>
            <th>添加时间</th>
            <th>操作</th>
          </tr>   
        </HeaderTemplate>
          <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'" onmouseout="this.className='off'">
            <td><span class="span1"><%#((DataRowView)Container.DataItem)[1]%></span></td>
            <td align="center"><%#((DataRowView)Container.DataItem)[2]%></td>
            <td align="center"><%#((DataRowView)Container.DataItem)[3]%></td>
            <td align="center"><%#((DataRowView)Container.DataItem)[4]%></td>
            </tr>
          </ItemTemplate>
          <FooterTemplate>
          </table>
         </FooterTemplate>
    </asp:Repeater>
    <div class="fenye1"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
    </div>
    </div>
    </div>
    </div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    function Del(ID) {
        if (confirm('你确认删除此管理员组吗?')) {
            self.location = "?Type=Del&ID=" + ID;
        }
    }
    function Update(ID) {
        self.location = "AdminGroupEdit.aspx?ID=" + ID;
    }
    function SetPop(ID) {

    }
</script>
</html>


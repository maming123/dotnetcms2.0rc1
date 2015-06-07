<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usergroup.aspx.cs" Inherits="Foosun.PageView.manage.user.usergroup" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>会员组</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script type="text/javascript" language="javascript">
 
</script>
</head>

<body>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>会员管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>会员组管理
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <a href="usergroup.aspx">会员组管理</a>┋<a href="usergroupadd.aspx">创建会员组</a>
      </div>
      <div class="jslie_lie">
      <asp:Repeater ID="DataList1" runat="server">
      <HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="20%">编号</th>
               <th width="10%">折扣</th>
               <th width="10%">会员组名</th>
               <th width="10%">点数</th>
               <th width="10%">G币 </th>
               <th width="15%">创建日期 </th>
               <th width="10%">人数</th>
               <th width="15%">操作</th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td align="center"><%#Eval("GroupNumber")%></td>
              <td align="center"><%#Eval("Discounts")%></td>
              <td align="center"><%#Eval("GroupName")%></td>
              <td align="center"><%#Eval("iPoint")%> </td>
              <td align="center"><%#Eval("Gpoint")%></td>
              <td align="center"><%#Eval("CreatTime")%></td>
              <td align="center"><%#Eval("peoplenum")%></td>
              <td align="center">
                 <a href="usergroupadd.aspx?id=<%#Eval("id") %>">修改</a>
                 <a href="UserGroup.aspx?id=<%#Eval("id") %>&Action=del" onclick="{if(confirm('确定要删除吗？')){return true;}return false;}">删除</a>
              </td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
         </table>
         </FooterTemplate>
         </asp:Repeater>
      </div>
   </div>
</div>
</div>
</body>
</html>

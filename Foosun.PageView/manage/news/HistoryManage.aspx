<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryManage.aspx.cs" Inherits="Foosun.PageView.manage.news.HistoryManage" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>归档新闻</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $("input[name='Checkbox']").click(function () {
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
      <div class="mian_wei_left"><h3>新闻归档管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>归档新闻管理
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>
        <asp:LinkButton ID="SuoP" runat="server" OnClientClick="{if(confirm('确认锁定所选信息吗?')){return true;}return false;}" OnClick="Suo_ClickP">锁定</asp:LinkButton>┊
        <asp:LinkButton ID="UnsuoP" runat="server" OnClientClick="{if(confirm('确认解锁所选信息吗?')){return true;}return false;}" OnClick="Unsuo_ClickP">解锁</asp:LinkButton>┊
        <asp:LinkButton ID="index" runat="server" CssClass="topnavichar" OnClick="Index_ClickP">生成索引页</asp:LinkButton>┊
        <asp:LinkButton ID="DelP" runat="server" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="Del_ClickP">批量删除</asp:LinkButton>┊
        <asp:LinkButton ID="delall" runat="server" OnClientClick="{if(confirm('确认删除所有信息吗?')){return true;}return false;}" OnClick="DelAll_ClickP">删除全部</asp:LinkButton></span>
      </div>
      <div class="jslie_lie" id="NoContent" runat="server">      	
      <asp:Repeater ID="DataList1" runat="server">
		<HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="40%" align="left"><span class="span1">新闻标题 </span></th>
               <th width="12%">类型 </th>
               <th width="12%">所属表 </th>
               <th width="12%">状态 </th>
               <th width="12%">归档时间 </th>
               <th width="12%">操作 <input type="checkbox" name="Checkbox"  value=""/></th>
            </tr>
            </HeaderTemplate>
		<ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td><span class="span1"><%#Eval("NewsTitle") %></span></td>
              <td align="center"><%#Eval("Type")%> </td>
              <td align="center"><%#Eval("table")%> </td>
              <td align="center"><%#Eval("stat")%></td>
              <td align="center"><%#Eval("oldTime")%> </td>
              <td align="center">
                 <%#Eval("oPerate")%>
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
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

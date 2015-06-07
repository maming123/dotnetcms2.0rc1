<%@ Page Language="C#" AutoEventWireup="true" Inherits="General_manage" CodeBehind="General_manage.aspx.cs" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
 <script type="text/javascript" language="javascript">
        $(function () {
            $("input[name='general_checkboxs']").click(function () {
                if (this.checked) {
                    $("input[name='general_checkbox']").attr('checked', true);
                }
                else {
                    $("input[name='general_checkbox']").attr('checked', false);
                }
            });
        });
  </script>
</head>
<body>
<form id="form2" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3> 常规管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a> >>常规管理  
      </div>
   </div>
</div>
<div class="mian_cont">
    <div class="nwelie">
        <div class="jslie_lan">
         <a href="General_manage.aspx" class="topnavichar">管理首页</a> ┊ <a href="General_Add_Manage.aspx" class="topnavichar">添加</a> ┊ <a href="General_manage.aspx?key=0" class="topnavichar">关键字(TAG)</a> ┊ <a href="General_manage.aspx?key=2" class="topnavichar">作者</a> ┊ <a href="General_manage.aspx?key=3" class="topnavichar">内部链接</a> ┊ <a href="General_manage.aspx?key=1" class="menulist">来源</a>
				<label style="color: Red;">
					功能事件:</label>
				<a href="General_manage.aspx?type=delall" onclick="{if(confirm('确认删除全部所有添加的信息吗？')){return true;}return false;}" class="topnavichar">删除全部</a> ┊
				<asp:LinkButton ID="DelP" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="Del_ClickP">批量删除</asp:LinkButton>
				┊
				<asp:LinkButton ID="SuoP" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认锁定所选信息吗?')){return true;}return false;}" OnClick="Suo_ClickP">批量锁定</asp:LinkButton>
				┊
				<asp:LinkButton ID="UnsuoP" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认解锁所选信息吗?')){return true;}return false;}" OnClick="Unsuo_ClickP">批量解锁</asp:LinkButton>
      </div>
      <div class="jslie_lie">
      <div id="NoContent" runat="server">
	</div>
      <asp:Repeater ID="DataList1" runat="server">
		<HeaderTemplate>
		 <table class="jstable">
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
					<th width="10%">
						名称
					</th>
					<th width="15%">
						类型
					</th>
					<th width="10%">
						状态
					</th>
					<th width="12%">
						连接地址
					</th>
					<th width="25%">
						电子邮件
					</th>
					<th>
						操作
						<input type="checkbox" id="general_checkbox" value="-1" name="general_checkboxs" />
					</th>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
			 <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
				<td width="10%" align="center" valign="middle">
					<%#((DataRowView)Container.DataItem)[1]%>
				</td>
				<td width="9%" align="center" valign="middle">
					<%#((DataRowView)Container.DataItem)["Type"]%>
				</td>
				<td width="10%" align="center" valign="middle">
					<%#((DataRowView)Container.DataItem)["stat"]%>
				</td>
				<td width="12%" align="center" valign="middle">
					<%#((DataRowView)Container.DataItem)[3] %>
				</td>
				<td width="25%" align="center" valign="middle">
					<%#((DataRowView)Container.DataItem)[4] %>
				</td>
				<td width="27%" align="center" valign="middle">
					<%#((DataRowView)Container.DataItem)["oPerate"]%>
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

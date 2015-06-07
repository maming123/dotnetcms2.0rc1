<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineTableList.aspx.cs" Inherits="Foosun.PageView.manage.sys.DefineTableList" %>
<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
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
    $(function () {
        $("input[name='Checkboxc']").click(function () {
            if (this.checked) {
                $("input[name='define_checkbox']").attr('checked', true);
            }
            else {
                $("input[name='define_checkbox']").attr('checked', false);
            }
        });
    });
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>自定义自段管理</h3></div>
      <div class="mian_wei_right">
         导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="DefineTableManage.aspx">自定义字段管理</a> >>
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="flie_lan">
           <a href="DefineTableManage.aspx">分类管理</a>┊
           <a href="DefineTable.aspx">新增字段</a>┊
           <a href="DefineTableManage.aspx?action=add">新增分类</a>┊
           <asp:LinkButton ID="delall" runat="server" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="delall_Click">删除全部</asp:LinkButton>┊
           <asp:LinkButton ID="DelP" runat="server"  OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除</asp:LinkButton>┊
      </div>
      <div class="jslie_lie">
      <div id="noContent" runat="server" />
      <asp:Repeater ID="DataList1" runat="server">
			<HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="10%">编号</th>
               <th width="20%">字段名称</th>
               <th width="20%">类型</th>
               <th width="20%">是否允许为空</th>
               <th width="30%">操作 <input type="checkbox" name="Checkboxc"  value=""/></th>
            </tr>
            </HeaderTemplate>
			<ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
             
                     <td align="center"><%#DataBinder.Eval(Container.DataItem, "id")%></td>
			          <td align="center">
						<%#DataBinder.Eval(Container.DataItem, "defineCname")%>
					</td>
					<td align="center">
						<%#DataBinder.Eval(Container.DataItem, "type")%>
					</td>
					<td align="center">
						<%#DataBinder.Eval(Container.DataItem, "IsNullC")%>
					</td>
					<td align="center">
						<%#DataBinder.Eval(Container.DataItem, "operate")%>
					</td>


            </tr>
        </ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>
         <div class="fanye1">
            <div class="fanye_le"><uc1:PageNavigator ID="PageNavig" runat="server" /></div>
         </div>
      </div>
   </div>
</div>
</div>

</form>
</body>
</html>


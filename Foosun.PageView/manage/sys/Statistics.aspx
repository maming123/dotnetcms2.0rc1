<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="Foosun.PageView.manage.sys.Statistics" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3> 统计系统</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a> >>统计系统  
      </div>
   </div>
</div>
<div class="mian_cont">
    <div class="nwelie">
        <div class="jslie_lan">
            <a href="StatisticsPara.aspx">参数设置</a>&nbsp;┊&nbsp;
            <a href="StatisticsAdd.aspx?act=add" class="topnavichar">新增分类</a>&nbsp;┊&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除分类</asp:LinkButton>
                    &nbsp;┊&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="DelAll_Click">删除全部分类</asp:LinkButton>
                    &nbsp;┊&nbsp;
                    <asp:LinkButton ID="LinkButton7" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认清空所有信息吗?\n清空后将不能还原!')){return true;}return false;}" OnClick="ClearAll_Click">清空所有统计信息</asp:LinkButton>
      </div>
      <div id="ShowNavi" runat="server"/>
      <div id="NoContent" runat="server" />
      <div class="jslie_lie">
              <asp:Repeater ID="DataList2" runat="server">
                <HeaderTemplate>
                  <table class="nwelie">
                  <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                    <th>类别编号</th>
                    <th>类别名称</th>
                    <th>操作
                      <input type="checkbox" id="stat_checkbox" value="-1" name="stat_checkbox" onclick="javascript:return selectAll(this.form,this.checked);"/></th>
                  </tr>
                </HeaderTemplate>
                <ItemTemplate>
                  <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                    <td width="7%" align="center"><%#((DataRowView)Container.DataItem)[1]%></td>
                    <td width="10%" align="center"><%#((DataRowView)Container.DataItem)[2]%></td>
                    <td width="20%" align="center"><%#((DataRowView)Container.DataItem)["oPerate"]%></td>
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

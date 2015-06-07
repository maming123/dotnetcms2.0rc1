<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatisticsPara.aspx.cs" Inherits="Foosun.PageView.manage.sys.StatisticsPara" %>

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
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>统计系统参数设置 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>统计系统
          </div>
       </div>
       <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
    </div>
<div class="mian_cont">
   <div class="nwelie">
    <div class="jslie_lan">
            <a href="StatisticsPara.aspx">参数设置</a>&nbsp;┊&nbsp;
            <a href="Statistics.aspx">分类管理</a>
      </div>
    <div class="lanlie_lie">
         <div class="newxiu_base">
          <table class="nxb_table">
            <tr>
              <td width="15%" align="right"><div align="right">系统名称</div></td>
              <td><asp:TextBox ID="SystemName" runat="server" CssClass="input4"/>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0001',this)">帮助</span></td>
            </tr>
            <tr>
              <td width="15%" align="right"><div align="right">英文名称</div></td>
              <td><asp:TextBox ID="SystemNameE" runat="server" CssClass="input4"/>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0002',this)">帮助</span></td>
            </tr>
            <tr>
              <td width="15%" align="right"><div align="right">IP防刷新</div></td>
              <td class="list_link"><asp:DropDownList ID="ipCheck" runat="server" Style="position: relative" CssClass="select4">
                  <asp:ListItem Value="1">开启</asp:ListItem>
                  <asp:ListItem Value="0">不开启</asp:ListItem>
                </asp:DropDownList>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0003',this)">帮助</span></td>
            </tr>
            <tr>
              <td width="15%" align="right"><div align="right">IP防刷新时间</div></td>
              <td style="height: 32px"><asp:TextBox ID="ipTime" runat="server" CssClass="input4"/>
                <font color="red">分钟</font>&nbsp;<span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0004',this)">帮助</span></td>
            </tr>
            <tr>
              <td width="15%" align="right"><div align="right">开启在线统计</div></td>
              <td class="list_link"><asp:DropDownList ID="isOnlinestat" runat="server" Style="position: relative" CssClass="select2">
                  <asp:ListItem Value="1">开启</asp:ListItem>
                  <asp:ListItem Value="0">不开启</asp:ListItem>
                </asp:DropDownList>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0005',this)">帮助</span></td>
            </tr>
            <tr>
              <td width="15%" align="right"><div align="right">每页记录数</div></td>
              <td><asp:TextBox ID="pageNum" runat="server" CssClass="input4"/>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0006',this)">帮助</span></td>
            </tr>
            <tr>
              <td width="15%" align="right"><div align="right">Cookie时间</div></td>
              <td><asp:TextBox ID="cookies" runat="server" CssClass="input4"/>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0007',this)">帮助</span></td>
            </tr>
            <tr>
              <td width="15%" align="right"><div align="right">小数精确度</div></td>
              <td><asp:TextBox ID="pointNum" runat="server" CssClass="input4"/>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_statParam0009',this)">帮助</span></td>
            </tr>
          </table>
    <div class="nxb_submit" >
                 <input type="submit" id="savePram" name="savePram" value="保 存" class="xsubmit1 mar" runat="server" onserverclick="savePram_ServerClick" />
                 <input type="reset" name="Clearclass" value=" 重 填 " class="xsubmit1 mar" />
             </div>
    </div>
  </div>
   </div>
</div>
</div>
    </form>
</body>
</html>

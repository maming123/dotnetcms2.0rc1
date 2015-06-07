<%@ Page Language="C#" AutoEventWireup="true" Inherits="setSteps" Codebehind="setSteps.aspx.cs" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
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
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>调查管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>调查管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
<div class="nwelie">
         <div class="jslie_lan">
         <span>功能：</span><label id="param_id" runat="server" /><a href="setClass.aspx">投票分类设置</a>&nbsp;┊&nbsp;<a href="setTitle.aspx">投票主题设置</a>&nbsp;┊&nbsp;<a href="setItem.aspx">投票选项设置</a>&nbsp;┊&nbsp;<a href="setSteps.aspx">多步投票管理</a>&nbsp;┊&nbsp;<a href="ManageVote.aspx">投票情况管理</a>
      </div>
  <div id="NoContent" runat="server" style="margin-left:5px"></div>
  <%
         string type = Request.QueryString["type"];
         if(type !="add"&&type!="edit")
         {
      %>
    <div class="jslie_lan" style="float:right"><div align="right"><a href="?type=add">新增多步投票</a> |
            <asp:LinkButton ID="DelP" runat="server" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除</asp:LinkButton>
            |
            <asp:LinkButton ID="DelAll" runat="server" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="DelAll_Click">删除全部</asp:LinkButton></div>
  </div>
   <div class="jslie_lie">
  <asp:Repeater ID="DataList1" runat="server">
    <HeaderTemplate>
      <table class="jstable">
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <th width="5%">编号</th>
        <th width="27%">调查主题</th>
        <th width="7%">顺序号</th>
        <th width="12%">调用主题</th>
        <th width="12%">操作
          <input type="checkbox" id="vote_checkbox" value="-1" name="vote_checkbox" onclick="javascript:return selectAll(this.form,this.checked);"/></th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr  class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <td width="5%" align="center"><%#((DataRowView)Container.DataItem)[0]%></td>
        <td width="27%" align="center"><%#((DataRowView)Container.DataItem)["titlesearch"]%></td>
        <td width="12%" align="center"><%#((DataRowView)Container.DataItem)["num"]%></td>
        <td width="7%" align="center"><%#((DataRowView)Container.DataItem)["titleuse"]%></td>
        <td width="12%" align="center"><%#((DataRowView)Container.DataItem)["oPerate"]%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      </table>
    </FooterTemplate>
  </asp:Repeater>
    <div class="fanye1">
    <uc1:PageNavigator ID="PageNavigator1" runat="server" />
  </div>
   <div class="lanlie_shming">
   <span>多步投票查询:</span>
        &nbsp;
       <span>关键字:</span> 
        <asp:TextBox runat="server" ID="KeyWord" size="15"  CssClass="input8"/>
        &nbsp;&nbsp;
        查询类型:
        <asp:DropDownList ID="DdlKwdType" runat="server"  CssClass="select3">
          <asp:ListItem Value="choose" Text="请选择" />
          <asp:ListItem Value="nums" Text="编号"/>
          <asp:ListItem Value="titles" Text="调查主题" />
          <asp:ListItem Value="nunber" Text="顺序号" />
          <asp:ListItem Value="titleu" Text="调用主题" />
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button runat="server" ID="BtnSearch" Text=" 查询 " CssClass="xsubmit1" OnClick="BtnSearch_Click"/>
        &nbsp;<span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_searchSteps_0001',this)">帮助</span> 
  </div>
  </div>
  <%
      }
       %>
  <%
            if(type=="add")
            {
        %>
          <div class="newxiu_base">
  <table class="nxb_table" id="Addvote_Steps">
    <tr>
      <th colspan="2" align="left"><font style="font-weight:100;">新增多步投票信息</font></th>
    </tr>
    <tr>
      <td width="15%" align="right"> 调查主题：</td>
      <td><asp:DropDownList ID="vote_CNameSe" runat="server" CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_surveysteps_0001',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 顺序号：</td>
      <td><asp:TextBox ID="StepsN" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_surveysteps_0002',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 调用主题：</td>
      <td><asp:DropDownList ID="vote_CNameUse" runat="server" CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_surveysteps_0003',this)">帮助</span> </td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Savesteps" value=" 提 交 " class="xsubmit1" id="Savesteps" runat="server" onserverclick="Savesteps_ServerClick"/>
        <input type="reset" name="Clearsteps" value=" 重 填 " class="xsubmit1" id="Clearsteps" runat="server" />
  </div>
  </div>
  <%
            }
         %>
  <%
            if(type=="edit")
            {
        %>
        <div class="newxiu_base">
  <table class="nxb_table" id="voteEdit">
    <tr>
      <th colspan="2" align="left"><font style="font-weight:100;">修改多步投票信息</font></th>
    </tr>
    <tr>
      <td width="15%" align="right"> 调查主题：</td>
      <td><asp:DropDownList ID="votecnameEditse" runat="server" CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_surveysteps_0001',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 顺序号：</td>
      <td><asp:TextBox ID="NumEdit" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_surveysteps_0002',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 调用主题：</td>
      <td><asp:DropDownList ID="votecnameEditue" runat="server" CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_surveysteps_0003',this)">帮助</span> </td>
    </tr>
    <tr>
      <td align="center"  colspan="2" class="list_link"><label>
        </label>
        &nbsp;&nbsp;
        <label>
        </label></td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Savesteps" value=" 提 交 " class="xsubmit1" id="SavestepsEdit" runat="server" onserverclick="SavestepsEdit_ServerClick"/>
        <input type="reset" name="Clearsteps" value=" 重 填 " class="xsubmit1" id="Clearstepsedit" runat="server" />
  </div>
  </div>
  <%
            }
         %>
</div>
</div>
</div>
</form>
<br />

</body>
</html>

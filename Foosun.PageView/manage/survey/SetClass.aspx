<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetClass.aspx.cs" Inherits="Foosun.PageView.manage.survey.SetClass" %>

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
      <div class="mian_wei_left"><h3>调查管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>调查管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
   <div class="lanlie">
         <ul>
            <li><label id="param_id" runat="server" /><a href="setClass.aspx" class="menulist">投票分类设置</a>┊</li>
            <li><a href="setTitle.aspx" class="menulist">投票主题设置</a>┊</li>
            <li><a href="setItem.aspx" class="menulist">投票选项设置</a>┊</li>
            <li><a href="setSteps.aspx" class="menulist">多步投票管理</a>┊</li>
            <li><a href="ManageVote.aspx" class="menulist">投票情况管理</a>┊</li>
         </ul>
      </div>
  <div id="NoContent" runat="server" style="margin-left:5px"></div>
  <%
         string type = Request.QueryString["type"];
         if(type !="add"&&type!="edit")
         {
      %>
   <div class="jslie_lan" style="float:right">
   <div align="right"><a href="?type=add" class="topnavichar">新增分类</a> |
            <asp:LinkButton ID="DelP" runat="server" CssClass="xa3" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除</asp:LinkButton>
            |
            <asp:LinkButton ID="DelAll" runat="server" CssClass="xa3" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="DelAll_Click">删除全部</asp:LinkButton></div>
  </div>
  <div class="lanlie_lie">
  <asp:Repeater ID="DataList1" runat="server">
    <HeaderTemplate>
      <table class="lanlie_table">
      <tr class="TR_BG">
        <th width="7%">编号</th>
        <th width="10%">类别名称</th>
        <th width="9%">描述</th>
        <th width="27%">操作
          <input type="checkbox" id="vote_checkbox" value="-1" name="vote_checkbox" onclick="javascript:return selectAll(this.form,this.checked);"/></th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <td align="center"><%#((DataRowView)Container.DataItem)[0]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[1]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[2]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["oPerate"]%> </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      </table>
    </FooterTemplate>
  </asp:Repeater>
  <div class="fanye">
    <uc1:PageNavigator ID="PageNavigator1" runat="server" />
  </div>
  <div class="lanlie_shming">
  <span>分类查询:</span>
        &nbsp;
        <span>关键字:</span>
        <asp:TextBox runat="server" ID="KeyWord" size="15"  CssClass="input8"/>
        &nbsp;&nbsp;
        查询类型:
        <asp:DropDownList ID="DdlKwdType" runat="server"  CssClass="select3">
          <asp:ListItem Value="choose" Text="请选择" />
          <asp:ListItem Value="number" Text="编号" />
          <asp:ListItem Value="classname" Text="类名" />
          <asp:ListItem Value="description" Text="描述" />
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button runat="server" ID="BtnSearch" Text=" 查询 " CssClass="xsubmit1" OnClick="BtnSearch_Click" />
        &nbsp;<span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_searchClass_0001',this)">帮助</span> 
  </div>
  </div>
  </div>
  </div>
  <%
      }
       %>
  <%
         if(type == "add")
         {
             this.PageNavigator1.Visible = false;
             this.NoContent.Visible=false;
      %>
      <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table" id="Addvote_Class">
    <tr>
      <td colspan="2"><font>新增问卷调查分类信息</font></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 类别名称：</td>
      <td><asp:TextBox ID="ClassName" runat="server" Width="124px" CssClass="input8"/>
        <span class=reshow>(*)</span> <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surverClass_0001',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 描述：</td>
      <td><textarea ID="Description" runat="server" Width="124px" style="width: 266px; height: 99px" class="textarea4"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surverClass_0002',this)">帮助</span></td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Saveupload" value=" 提 交 " class="xsubmit1" id="SaveClass" runat="server" onserverclick="SaveClass_ServerClick"/>
        <input type="reset" name="Clearupload" value=" 重 填 " class="xsubmit1" id="ClearClass" runat="server" />
    
  </div>
  </div>
  </div>
  <%
      }
     %>
  <%
         if(type == "edit")
         {
      %>
      <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table" id="Editvote_Class">
    <tr>
      <td  colspan="2"><font>修改问卷调查分类信息</font></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 类别名称：</td>
      <td><asp:TextBox ID="ClassNameEdit" runat="server" Width="124px" CssClass="input8"/>
        <span class=reshow>(*)</span> <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surverClass_0001',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right"  class="list_link" style="width: 175px"> 描述：</td>
      <td><div class="textdiv4"><textarea ID="DescriptionE" runat="server" rows="5" Width="124px" style="width: 266px; height: 99px; font-size:12px"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surverClass_0002',this)">帮助</span></div></td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Savevote" value=" 提 交 " class="xsubmit1" id="EditSave" runat="server" onserverclick="EditSave_ServerClick"/>
        <input type="reset" name="Clearvote" value=" 重 填 " class="xsubmit1" id="EditClear" runat="server" />
  </div>
  </div>
  </div>
  <%
      }
     %>
</div>
</form>
</body>
</html>

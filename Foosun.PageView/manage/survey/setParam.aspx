<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setParam.aspx.cs" Inherits="Foosun.PageView.manage.survey.setParam" %>
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
            <li><a href="setParam.aspx" class="menulist">系统参数设置</a>┊</li>
            <li><a href="setClass.aspx" class="menulist">投票分类设置</a>┊</li>
            <li><a href="setTitle.aspx" class="menulist">投票主题设置</a>┊</li>
            <li><a href="setItem.aspx" class="menulist">投票选项设置</a>┊</li>
            <li><a href="setSteps.aspx" class="menulist">多步投票管理</a>┊</li>
            <li><a href="ManageVote.aspx" class="menulist">投票情况管理</a>┊</li>
         </ul>

     <div class="newxiu_base">
  <table class="nxb_table">
    <tr>
      <th colspan="2" align="left"><font style="font-weight:100;">问卷调查系统参数设置</font></th>
    </tr>
    <tr>
      <td width="20%" align="right"> IP时间间隔：</td>
      <td ><asp:TextBox ID="IPtime" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surverParam_0001',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 是否注册才能投票：</td>
      <td ><asp:DropDownList ID="IsReg" runat="server" CssClass="select3">
          <asp:ListItem Value="1">是</asp:ListItem>
          <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surverParam_0002',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 禁止投票的IP段：</td>
      <td ><textarea ID="IpLimit" runat="server" style="width: 251px; height: 105px" class="textarea4"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surverParam_0003',this)">帮助</span></td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Saveupload" value=" 提 交 " class="xsubmit1" id="SavePram" runat="server" onserverclick="SavePram_ServerClick"/>
        <input type="reset" name="Clearupload" value=" 重 填 " class="xsubmit1" id="ClearPram" runat="server" />
  </div>
  </div>
     </div>
  </div>
  </div>
</div>
</form>
</body>
</html>
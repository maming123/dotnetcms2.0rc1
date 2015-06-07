<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="Foosun.PageView.manage.sys.AdminAdd" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>添加管理员</title>
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
          <div class="mian_wei_left"><h3>添加管理员 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="AdminList.aspx">管理员管理</a> >>新增管理员
          </div>
       </div>
       <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
    </div>
<div class="mian_cont">
   <div class="nwelie">
    <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table">
    <tr>
      <td width="15%" align="right">用户名：</td>
      <td><asp:TextBox ID="TxtUserName" CssClass="input8" runat="server" Width="200px" MaxLength="18"></asp:TextBox><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_001',this)">帮助</span><asp:RequiredFieldValidator ID="RequireUserName" runat="server" ControlToValidate="TxtUserName" Display="Dynamic" ErrorMessage="<span class=reshow>(*)请填写用户名</spna>"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 密 码：</td>
      <td><asp:TextBox ID="UserPwd" CssClass="input8" runat="server" Width="200px" MaxLength="50" TextMode="Password"></asp:TextBox><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_002',this)">帮助</span>&nbsp;&nbsp;<span id="passvalid" style="color:#F00;">如果前台会员存在，此项将不起作用。</span></td>
    </tr>
    <tr>
      <td width="15%" align="right">确认密码：</td>
      <td><asp:TextBox ID="SecUserPwd" CssClass="input8" runat="server" Width="200px" MaxLength="50" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareSecUserPwd" runat="server" ErrorMessage="<span class=reshow>(*)两次密码不一致</span>" ControlToValidate="UserPwd" ControlToCompare="SecUserPwd" Type="String"></asp:CompareValidator></td>
    </tr>
    <tr>
      <td width="15%" align="right">是否禁用：</td>
      <td><span class="list_link">&nbsp;
        <input name="IsInvocation" type="radio" value="1" class="radio"/>
        是&nbsp;&nbsp;&nbsp;
        <input name="IsInvocation" type="radio" value="0" checked class="radio" />
        否</span><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_003',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 姓 名：</td>
      <td><span class="span1"><asp:TextBox CssClass="input8" ID="RealName" runat="server" Width="200px" MaxLength="20"></asp:TextBox><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_005',this)">帮助</span></span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 电子邮件：</td>
      <td><asp:TextBox CssClass="input8" ID="Email" runat="server" Width="200px" MaxLength="120"></asp:TextBox><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_006',this)">帮助</span><asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="<span class=reshow>(*)请填写电子邮件</span>"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionEmail" runat="server" Display="Static" ErrorMessage="<span class=reshow>邮箱格式不正确</span>" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
    </tr>
    <tr>
      <td width="15%" align="right">所属管理员组：</td>
      <td><asp:DropDownList ID="AdminGroup" runat="server" Width="200px" CssClass="select1"> </asp:DropDownList><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_007',this)">帮助</span></td>
    </tr>
    <tr style="display:none">
      <td width="15%" align="right">
          是否频道管理员：</td>
      <td><span class="list_link">&nbsp;
      <input name="isChannel" type="radio" value="1" onClick="javascript:Hide(this.value);" checked="checked" class="radio"  />
      是&nbsp;&nbsp;&nbsp;
      <input name="isChannel" type="radio" value="0" onClick="javascript:Hide(this.value);" class="radio" />
      否<span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_004',this)">帮助</span></span></td>
    </tr>
    <tr id="Tr_SiteAdmin">
      <td width="15%" align="right">频道超级管理员：</td>
      <td><span class="list_link">&nbsp;
        <input name="isChSupper" type="radio" value="1" class="radio" />
        是&nbsp;&nbsp;&nbsp;
        <input name="isChSupper" type="radio" value="0" checked="checked" class="radio"/>
        否</span><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_008',this)">帮助</span></td>
    </tr>
    <tr id="Tr_SiteList">
      <td width="15%" align="right">所属频道：</td>
      <td align="left"><span class="span1" runat="server" style="margin-left:10px;" id="Site_Span"></span><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_012',this)">帮助</span></td>
    </tr>
    <tr id="Tr1" visible="false" runat="server">
      <td width="15%" align="right">允许多人登陆：</td>
      <td><span class="list_link">&nbsp;
        <input name="MoreLogin" type="radio" value="1" class="radio"/>
        是&nbsp;&nbsp;&nbsp;
        <input name="MoreLogin" type="radio" value="0" checked="checked" class="radio" >
        否</span><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_009',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right">IP限制：</td>
      <td>
        <div class="textdiv4"><asp:TextBox ID="Iplimited" runat="server" Height="74px" TextMode="MultiLine" Width="558px"></asp:TextBox><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_adminAdd_011',this)">帮助</span></div></td>
    </tr>
  </table>

    <div class="nxb_submit" >
                 <asp:Button ID="Button1" runat="server" Text=" 确 定 " CssClass="xsubmit1 mar" OnClientClick="return ValidPass()" OnClick="Button1_Click"/>
                 <input type="reset" name="UnDo" value=" 重 填 " class="xsubmit1 mar" />
             </div>
    </div>
  </div>
   </div>
</div>
</div>
</form>
</body>
<script language="javascript" type="text/javascript">
    function Hide(value) {
        if (value == "1") {
            document.getElementById("Tr_SiteAdmin").style.display = "";
            document.getElementById("Tr_SiteList").style.display = "";
        }
        else {
            document.getElementById("Tr_SiteAdmin").style.display = "none";
            document.getElementById("Tr_SiteList").style.display = "none";
        }
    }
    function ValidPass() {
        var upwd = document.getElementById("UserPwd").value;
        if (upwd.length < 6) {
            document.getElementById("passvalid").innerHTML = "(*)密码不能少于6位";
            document.getElementById("passvalid").className = "reshow";
            return false;
        }
        return true;
    }
</script>
</html>

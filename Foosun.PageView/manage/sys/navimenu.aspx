<%@ Page Language="C#" AutoEventWireup="true" Inherits="navimenu"  ResponseEncoding="utf-8" Codebehind="navimenu.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
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
<div class="mian_body">
    <div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>管理功能菜单 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>创建功能菜单
          </div>
       </div>
       <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
    </div>
    <div class="mian_cont">
   <div class="nwelie">
    <div class="lanlie_lie">
    <div class="newxiu_base">
    <form id="form1" runat="server">
      <table class="nxb_table">
        <tr>
          <td width="15%" align="right"><div align="right">菜单名称：</div></td>
          <td><asp:TextBox ID="menuName" runat="server"  Width="250"  MaxLength="50" CssClass="input8"></asp:TextBox>
          <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_navimenu_0001',this)">帮助</span><asp:RequiredFieldValidator ID="f_menuName" runat="server" ControlToValidate="menuName" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写菜单名称，长度为20字节</span>"></asp:RequiredFieldValidator></td>
        </tr>        
        <tr>
          <td width="15%" align="right"><div align="right">系统功能：</div></td>
          <td style="height: 23px"><asp:CheckBox ID="isSys" runat="server" CssClass="checkbox2" /><span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onClick="Help('H_navimenu_0005',this)">帮助</span></td>
        </tr>
        <tr>
          <td width="15%" align="right"><div align="right">连接路径：</div></td>
          <td><asp:TextBox ID="FilePath" runat="server" Width="250" MaxLength="200" CssClass="input8"></asp:TextBox>
          <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onClick="Help('H_navimenu_0006',this)">帮助</span><asp:RequiredFieldValidator ID="f_FilePath" runat="server" ControlToValidate="FilePath" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写快捷菜单连接路径，长度为200字节</span>"></asp:RequiredFieldValidator></td>
        </tr> 
        <tr>
          <td width="15%" align="right"><div align="right">排列顺序：</div></td>
          <td>
          <asp:TextBox ID="orderID" runat="server" Text="10" Width="100" CssClass="input8" />
          <span class="helpstyle" style="cursor:help"; title="点击查看帮助"  onclick="Help('H_navimenu_0007',this)">帮助</span><asp:RequiredFieldValidator ID="f_orderID_1" runat="server" ControlToValidate="orderID" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写序号</span>"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="f_orderID" runat="server" ControlToValidate="orderID"  Display="Static" ErrorMessage="(*)排列序号不正确" ValidationExpression="^[0-9]{0,2}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
          <td width="15%" align="right"><div align="right">权限代码：</div></td>
          <td>
          <asp:TextBox ID="popCode" runat="server" MaxLength="50" Width="100" CssClass="input8" />
          <span class="helpstyle" style="cursor:help"; title="点击查看帮助"  onclick="Help('H_navimenu_pop',this)">帮助</span></td>
        </tr>
        <tr>
            <td width="15%" align="right">图片路径：</td>
            <td>
                <asp:TextBox ID="imgPath" runat="server" CssClass="input8"></asp:TextBox>
                <img src="../imges/bgxiu_14.gif"  align="middle" alt="选择已有图片" border="0" style="cursor: pointer;"
                                            onclick="selectFile('imgPath','选择图片','imgPath',500,500);document.form1.imgPath.focus();" />
                <span class="helpstyle" style="cursor:help"; title="点击查看帮助"  onclick="Help('H_navimenu_path',this)">帮助</span>
            </td>
        </tr>
        <tr>
            <td width="15%" align="right">图片大小：</td>
            <td>
                <span class="span1">宽</span><asp:TextBox ID="imgwidth" runat="server" CssClass="input1" Text="0" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"></asp:TextBox>
                <span class="span1">高</span><asp:TextBox ID="imgheight" runat="server" CssClass="input1" Text="0" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"></asp:TextBox>
            </td>
        </tr>
        </table>
<div class="nxb_submit" >
    <asp:Button ID="sumbitsave" runat="server" CssClass="xsubmit1" Text=" 确 定 " OnClick="Navisubmit" />
    <input name="reset" type="reset" value=" 重 置 "  class="xsubmit1" />
</div>
<div id="dialog-message" title="提示"></div>
</form>

</div>
</div>
</div>
</div>
 </div>
<script language="JavaScript" type="text/javascript">
function changevalue(value)
{
	if(value=='0')
	{
		form1.position.value="99999";
	}
	else
	{
		form1.position.value="88888";
	}
}
</script>

</body>
</html>
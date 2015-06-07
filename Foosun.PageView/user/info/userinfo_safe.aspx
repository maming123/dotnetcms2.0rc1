<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="utf-8" Inherits="user_info_userinfo_safe" Codebehind="userinfo_safe.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
	<link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body class="main_big">
      <form id="form1" runat="server">
      <table width="100%" border="0" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
          <td height="1" colspan="2"></td>
        </tr>
        <tr>
          <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">修改会员资料</strong></td>
    <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" /><a href="userinfo.aspx" class="list_link">我的资料</a><img alt="" src="../images/navidot.gif" border="0" />修改安全资料</div></td>
        </tr>
</table>

         <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
            <tr>
              <td style="padding-left:14px;"><a class="topnavichar" href="userinfo.aspx">我的资料</a>　<a class="topnavichar" href="userinfo_update.aspx">修改基本信息</a>　<a class="topnavichar" href="userinfo_contact.aspx">修改联系资料</a>　<a class="topnavichar" href="userinfo_safe.aspx"><font color="red">修改安全资料</font></a>　<a class="topnavichar" href="userinfo_idcard.aspx">修改实名认证</a></td>
            </tr>
    </table>

      <table width="98%" border="0" align="center" cellpadding="2" cellspacing="1" class="Tablist tab">
 
        <tr class="TR_BG_list">
          <td class="list_link" style="width: 114px"><div align="right" style="margin-right:10px;">旧密码</div></td> 
          <td class="list_link">
          <asp:TextBox CssClass="form" ID="oldPassword" runat="server"  Width="250"  MaxLength="20" TextMode="Password"></asp:TextBox>
          
          <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_safe_0005',this)">帮助</span><asp:RequiredFieldValidator ID="f_oldPassword" runat="server" ControlToValidate="oldPassword" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写旧密码，长度为3-18</span>"></asp:RequiredFieldValidator></td>
          </tr>
                 
        <tr class="TR_BG_list">
          <td class="list_link" style="width: 114px"><div align="right" style="margin-right:10px;">新密码</div></td> 
          <td class="list_link"><asp:TextBox CssClass="form" ID="newpassword" runat="server"  Width="250"  TextMode="Password" MaxLength="20"></asp:TextBox>
          <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_safe_0004',this)">帮助</span><asp:RequiredFieldValidator ID="f_newpassword" runat="server" ControlToValidate="newpassword" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写新密码，长度为3-18</span>"></asp:RequiredFieldValidator></td>
          </tr>
          
                  <tr class="TR_BG_list">
          <td class="list_link" style="width: 114px"><div align="right" style="margin-right:10px;">确认新密码</div></td> 
          <td class="list_link"><asp:TextBox CssClass="form" ID="password" runat="server"  Width="250"  TextMode="Password" MaxLength="20"></asp:TextBox>
          <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_safe_0003',this)">帮助</span><asp:RequiredFieldValidator ID="f_password" runat="server" ControlToValidate="password" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写确认密码，长度为3-18</span>"></asp:RequiredFieldValidator></td>
          </tr>

        <tr class="TR_BG_list">
          <td class="list_link" style="width: 114px"><div align="right" style="margin-right:10px;">密码问题</div></td> 
          <td class="list_link"><asp:TextBox CssClass="form" ID="PassQuestion" runat="server"  Width="250"  MaxLength="20"></asp:TextBox>
          <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_safe_0001',this)">帮助</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PassQuestion" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写密码问题</span>"></asp:RequiredFieldValidator></td>
          </tr>
          
        <tr class="TR_BG_list">
          <td class="list_link" style="width: 114px"><div align="right" style="margin-right:10px;">密码答案</div></td>
          <td class="list_link"><asp:TextBox CssClass="form" ID="PassKey" runat="server"  Width="250"></asp:TextBox>
          <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_safe_0002',this)">帮助</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PassKey" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写密码答案</span>"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="TR_BG_list">
          <td class="list_link" style="width: 114px; height: 28px;">&nbsp;</td>
          <td class="list_link" style="height: 28px">&nbsp;<asp:Button ID="sumbitsave" runat="server" CssClass="form" Text=" 确 定 "  OnClick="submitSave" />
            <input name="reset" type="reset" value=" 重 置 "  class="form" />
                     </td>
        </tr>

</table>      
      
      </form>
<br />
<br />
 <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
   <tr>
     <td align="center"><label id="copyright" runat="server" /></td>
   </tr>
 </table>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userAdd.aspx.cs" Inherits="Foosun.PageView.manage.user.userAdd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>

<body>
    <form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>新增会员 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="userlist.aspx">会员管理</a> >>新增会员
      </div>
   </div>
  <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="15%" align="right">用户名：</td>
               <td>                 
                  <asp:TextBox ID="txtUserName" class="input8"  runat="server" MaxLength="18"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<span class='reshow'>(*)用户名不能为空" ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">密　码：</td>
               <td>                   
                   <asp:TextBox ID="txtPassword" runat="server" MaxLength="18" class="input8"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<span class='reshow'>(*)密码不能为空" ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">电子邮件：</td>
               <td>
                
                   <asp:TextBox ID="txtEmail" runat="server" class="input8" MaxLength="50"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                       ControlToValidate="txtEmail" Display="Dynamic" 
                       ErrorMessage="&lt;span class='reshow'&gt;(*)电子邮件不能为空"></asp:RequiredFieldValidator>
                
               </td>
             </tr>
           </table>
            <div class="nxb_submit" >
                 <asp:Button ID="sumbitsave" runat="server" class="xsubmit1 mar" Text=" 确 定 " onclick="sumbitsave_Click" />
                 <input type="reset" name="" value="重置"  class="xsubmit1 mar"/>
                 <asp:HiddenField ID="suid" runat="server" />
             </div>
        </div>
      </div>
   </div>
</div>
</div>
    </form>
</body>
</html>

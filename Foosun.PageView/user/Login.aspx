<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Foosun.PageView.user.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<head>
	<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
    <link type="text/css" rel="stylesheet" href="css/base.css" />
    <link type="text/css" rel="stylesheet" href="css/login.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
</head>

<body>
<form id="Form1" runat="server">
<div  class="win_big">
	<div id="simTestContent" class="simScrollCont">
      <div class="login">
       <div class="login_big">
           <table class="table">
             <tbody>
              <tr>
                 <td class="tab1">&nbsp;</td>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label></td>
               </tr>
               <tr>
                 <td class="tab1">用户名：</td>
                 <td><asp:TextBox ID="TxtName" runat="server" MaxLength="18" CssClass="inpt"></asp:TextBox></td>
               </tr>
               <tr>
                  <td class="tab1">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
                  <td><asp:TextBox ID="TxtPassword"  runat="server" TextMode="Password" CssClass="inpt"></asp:TextBox></td>
               </tr>
               <tr id="safecodeTF" runat="server">
                   <td class="tab1">验证码：</td>
                   <td><asp:TextBox ID="TxtVerifyCode" runat="server" class="inp inpt"></asp:TextBox>
								<script language="JavaScript">
								    var numkey = Math.random();
								    numkey = Math.round(numkey * 10000);
								    document.write("<img src=\"../comm/Image.aspx?k=" + numkey + "\" onClick=\"this.src+=Math.random()\" alt=\"图片看不清？点击重新得到验证码\" style=\"cursor:pointer;\" width=\"70\" height=\"23\" hspace=\"4\"");
								</script></td>
               </tr>
               <tr>
                   <td class="tab1"></td>
                   <td><asp:HiddenField ID="HidUrl" runat="server" />
                       <asp:Button ID="Button1" runat="server" Text=" " class="bottom" 
                           onclick="Button1_Click"/></td>
               </tr>
               <tr>
                   <td colspan="2"><a href="info/getPassword.aspx" class="a1">忘记密码？</a>
                      <a href="Register.aspx?SiteID=<%Response.Write(SiteID); %>" class="a1">新用户注册</a>
                   </td>
               </tr>
              </tbody>
           </table>
       </div>
      </div>
	</div><!--simTestContent end-->
	
</div>
</form>	
</body>
</html>

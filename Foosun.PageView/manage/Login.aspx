<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Foosun.PageView.manage.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %>用户登录</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        if (!-[1,]&&!window.XMLHttpRequest) {
            alert("为了更好的体验，请您使用IE6+，火狐，谷歌等浏览器！");
        };
    });   
    function checkfrom() {
        if ($('#txtUserName').val() == "") {
            $('#lblinfo').html("用户名不能为空！");
            $('#txtUserName').focus();
            return false;
        }
        if ($('#txtPassword').val() == "") {
            $('#lblinfo').html("密码不能为空！");
            $('#txtPassword').focus();
            return false;
        }
        if ($('#txtVerify').val() == "") {
            $('#lblinfo').html("验证码不能为空！");
            $('#txtUserName').focus();
            return false;
        }
        $('#lblinfo').html("");
        return true;
    }
</script>
</head>
<body class="login_body">
<form id="form1" runat="server">
   <div class="login_big">
      <div class="login_go">
         <table>
            <tr>
               <td colspan="2" style="width:250px; height:27px; overflow:hidden;"><label runat="server" id="lblinfo"></label></td>
            </tr>
            <tr>
               <td width="50">用户名：</td>
               <td align="left"><asp:TextBox ID="txtUserName" runat="server" class="input1"></asp:TextBox></td>
            </tr>
            <tr>
               <td width="50">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
               <td align="left"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="input1"></asp:TextBox></td>
            </tr>
            <tr id="safeCodeVerify_1" runat="server">
               <td width="50">安全码：</td>
               <td align="left"><asp:TextBox ID="txtSafeCode" runat="server" class="input1"></asp:TextBox></td>
            </tr>
            <tr>
               <td width="50">验证码：</td>
              <td align="left">
                  <asp:TextBox ID="txtVerify" runat="server" class="input2"></asp:TextBox>
                   <script type="text/javascript" language="JavaScript">
                       var numkey = Math.random();
                       numkey = Math.round(numkey * 10000);
                       document.write("<img src=\"../comm/Image.aspx?k=" + numkey + "\" width=\"70\" onClick=\"this.src+=Math.random()\" alt=\"图片看不清？点击重新得到验证码\" style=\"cursor:pointer;\" height=\"23\" hspace=\"4\"");
        </script>
              </td>
            </tr>
            <tr>
               <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="" CausesValidation="False" OnClientClick="javascript:return checkfrom()" class="submit submit1" onclick="btnLogin_Click" />
                   <input type="reset" name="qux"  value="" class="submit submit2"/>
               </td>
            </tr>
         </table>
      </div>
      <div class="login_ban">
         <p>(c)2002-2013 Foosun Inc. By DotNetCMS v2.0 Build 130125 </p>
      </div>
</div>
    </form>
</body>
</html>
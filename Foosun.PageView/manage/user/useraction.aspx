<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="useraction.aspx.cs" Inherits="Foosun.PageView.manage.user.useraction" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>

<body>
    <form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>会员管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="userlist.aspx">会员管理</a> >>积分/G币处理
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
                  <asp:HiddenField ID="hidden_uid" runat="server" />
            <div id="actionContent" runat="server" />
               </td>
             </tr>
           </table>
        </div>
      </div>
   </div>
</div>
</div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function bIpoint(obj, obj1) {
        if (confirm('确定进行此操作吗?')) {
            self.location.href = "useraction.aspx?sPointType=bIpoint&uid=" + obj + "&point=" + obj1 + "";
        }
    }
    function sIpoint(obj, obj1) {
        if (confirm('确定进行此操作吗?')) {
            self.location.href = "useraction.aspx?sPointType=sIpoint&uid=" + obj + "&point=" + obj1 + "";
        }
    }
    function bGpoint(obj, obj1) {
        if (confirm('确定进行此操作吗?')) {
            self.location.href = "useraction.aspx?sPointType=bGpoint&uid=" + obj + "&point=" + obj1 + "";
        }
    }
    function sGpoint(obj, obj1) {
        if (confirm('确定进行此操作吗?')) {
            self.location.href = "useraction.aspx?sPointType=sGpoint&uid=" + obj + "&point=" + obj1 + "";
        }
    }
</script>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usermycomupdate.aspx.cs" Inherits="Foosun.PageView.manage.user.usermycomupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
   <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>修改评论</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="usermycom.aspx">评论管理</a>>>修改评论
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
      <div class="jslie_lan">
         <a href="usermycom.aspx">评论管理</a>
      </div>
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="20%" align="right">评论内容：</td>
               <td>
                  <div class="textdiv">
                    <asp:TextBox ID="ContentBox" runat="server" Height="120px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="评论内容不能为空" ControlToValidate="ContentBox" Display="Dynamic"></asp:RequiredFieldValidator>
                  <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('usermycom_up_0002',this)">帮助</span>
                  </div>
               </td>
             </tr>
           </table>
            <div class="nxb_submit" >
                <asp:Button ID="sumbitsave" runat="server" class="xsubmit1 mar" Text=" 确 定 "  OnClick="shortCutsubmit" />
                 <input type="reset" name="" value="重置"  class="xsubmit1 mar"/>
             </div>
        </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>
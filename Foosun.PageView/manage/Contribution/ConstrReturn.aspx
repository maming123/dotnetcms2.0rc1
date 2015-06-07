<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConstrReturn.aspx.cs" Inherits="Foosun.PageView.manage.Contribution.ConstrReturn" %>

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
      <div class="mian_wei_left"><h3>投稿管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="ConstrList.aspx">稿件管理</a> >>退稿>>
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <span><a href="ConstrList.aspx">稿件管理</a>┊<a href="ConstrStat.aspx"> 稿件统计</a>┊<a href="ConstrList.aspx?type=cheack">所有通过审核稿件</a></span>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
                <td colspan="2"> 你要把<span>我要投稿</span>退稿吗？ </td>
             </tr>
             <tr>
                <td width="10%" align="right">退稿理由：</td>
                <td>
                    <div class="textdiv1">
                     <asp:TextBox ID="passcontent" runat="server" TextMode="MultiLine" class="textarea2"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="passcontent"       ErrorMessage="退稿理由不能为空"></asp:RequiredFieldValidator>
                    </div>
                </td>
             </tr>
           </table>
           <div class="nxb_submit" >              
                <asp:Button ID="But" runat="server" Text="确定" class="insubt" OnClick="But_Click"/>
               <input type="reset" name="bc" value="重置" class="insubt"/>
           </div>
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>
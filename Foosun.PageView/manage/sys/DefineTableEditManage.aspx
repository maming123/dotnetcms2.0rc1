<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineTableEditManage.aspx.cs" Inherits="Foosun.PageView.manage.sys.DefineTableEditManage" %>
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
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>自定义字段</h3></div>
      <div class="mian_wei_right">
           导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>自定义字段管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="flie_lan">
            <a href="DefineTableManage.aspx">分类管理</a>┊
            <a href="DefineTable.aspx">新增字段</a>┊
            <a href="?action=add">新增分类</a>┊
         </div>
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
                <td colspan="2"><font>新增自定义字段分类信息</font></td>
             </tr>
             <tr>
               <td width="20%" align="right">上一级自定义字段编号：</td>
               <td> 
                  <asp:TextBox ID="PraText" runat="server" Enabled="false" class="input8"></asp:TextBox>>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">自定义字段名称：</td>
               <td>
                  <asp:TextBox ID="NewText" runat="server" class="input8"></asp:TextBox>
               </td>
             </tr>
           </table>
           <div class="nxb_submit" >
               <asp:Button ID="Button1" runat="server" Text="提交数据" class="xsubmit1" OnClick="Button1_Click" />
           </div>
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

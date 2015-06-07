<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysLabelinlabel.aspx.cs" Inherits="Foosun.PageView.manage.label.sysLabelinlabel" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>导出标签</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>

<body>
<form id="Form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>导出/导入标签</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="syslabelList.aspx">标签管理</a> >><label id="outlabel_type" runat="server" />
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li><a href="syslabelList.aspx">标签管理 </a>┊</li>
            <li><a href="syslabelbak.aspx">备份库</a>┊</li>
            <li><a href="syslabelclassadd.aspx">新建分类</a>┊</li>
            <li><a href="syslableadd.aspx">新建标签</a>┊</li>
            <li><a href="?type=out">导出标签</a><a href="#" class="a1">(如何导出?) </a>┊</li>
            <li><a href="?type=in">导入标签</a><a href="#" class="a1">(如何导入?) </a></li>
         </ul>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td><strong>选择要把标签导入的分类</strong></td>
             </tr>
             <tr>
               <td>
                  <asp:DropDownList ID="LabelClass" runat="server" Width="195px">
          </asp:DropDownList> <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_label_in_tb',this)">特别说明?</span>
          <asp:HiddenField ID="xmlPath" runat="server" />
          <asp:HiddenField ID="ATserverTF" runat="server" />
          <asp:Button ID="Button1" runat="server" Text="开始导入" CssClass="xsubmit1" OnClick="In_click" />
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


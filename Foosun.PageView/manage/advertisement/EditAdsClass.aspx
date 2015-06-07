<%@ Page Language="C#" AutoEventWireup="true" Inherits="EditAdsClass" ResponseEncoding="utf-8" Codebehind="EditAdsClass.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>修改分类信息</title>
   <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" method="post" action="EditAdsClass.aspx">
    <div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>修改分类信息</h3></div>
      <div class="mian_wei_right">
           导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="AdList.aspx">广告管理</a> >>添加分类
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="15%" align="right">分类名称：</td>
               <td>
                  <asp:TextBox ID="AdsClassName" runat="server" Width="200px" MaxLength="50" CssClass="input8"></asp:TextBox><span class="a1" style="cursor:help;" title="点击显示帮助" onclick="Help('H_AdsAdd_018',this)">帮助</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="AdsClassName" Display="Dynamic" ErrorMessage="<span class=reshow>(*)请填写分类名称</spna>"></asp:RequiredFieldValidator>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">父类编号：</td>
               <td>
                   <asp:TextBox ID="AdsParentID" runat="server" Width="200px" MaxLength="12" CssClass="input8" ReadOnly="true"></asp:TextBox><span class="a1" style="cursor:help;" title="点击显示帮助" onclick="Help('H_AdsAdd_019',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">价 格 ：</td>
               <td>
                   <asp:TextBox ID="AdsPrice" runat="server" Width="200px" MaxLength="10" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_AdsAdd_020',this)">帮助</span><span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AdsPrice" Display="Dynamic" ErrorMessage="<span class=reshow>(*)请填写价格</spna>"></asp:RequiredFieldValidator></span><span><asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="<span class=reshow>(*)价格格式不正确,只能为正整数</spna>" Type="Integer" ControlToValidate="AdsPrice" MaximumValue="1000000000" MinimumValue="0" Display="Dynamic"></asp:RangeValidator></span>
               </td>
             </tr>
           </table>
            <div class="nxb_submit" >
                <asp:Button ID="Button2" runat="server" Text=" 确 定 " CssClass="xsubmit1 mar" OnClick="Button1_Click"/>
                 <input type="reset" name="" value="重置"  class="xsubmit1 mar"/>
                 <input name="adsclassid" type="hidden" runat="server" id="adsclassid" />
             </div>
        </div>
      </div>
   </div>
</div>
</div>
    </form>
</body>
</html>


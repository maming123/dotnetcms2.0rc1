<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSTempletClass.aspx.cs" Inherits="Foosun.PageView.manage.jsmodel.JSTempletClass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>新增/修改JS模型分类</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function CheckLength(obj) {
        var val = obj.value;
        if (val.length > 500)
            obj.value = val.substr(0, 500);
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3><%=title %></h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="JSTemplet.aspx" class="navi_link">JS模型管理</a>>><%=title %>
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能：</span><a href="JSTemplet.aspx"> JS模型管理</a>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
               <tr>
                   <td colspan="2"><font></font>JS模型分类信息</td>
               </tr>
             <tr>
               <td width="20%" align="right">JS模型分类名称：</td>
                    <td>
                    <asp:TextBox ID="TxtName" runat="server" class="input8"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName"
                        Display="Dynamic" ErrorMessage="请填写分类名称!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                       (<span>*</span>)<span class="helpstyle" onclick="Help('h_jstempletclass_001',this)"
                            style="cursor: help;" title="点击查看帮助">帮助</span>
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">上级分类：</td>
               <td>
               <asp:DropDownList ID="DdlUpperClass" runat="server" class="select3">
                    <asp:ListItem Value="0">根结点</asp:ListItem>
                    </asp:DropDownList>
                 <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('h_jstempletclass_002',this)">
                        帮助</span>
               </td>
             </tr>
             <tr>
                <td width="20%" align="right">JS模型分类描述：</td>
                <td>
                    <div class="textdiv">
                    <asp:TextBox runat="server" onchange="CheckLength(this)" onkeydown="CheckLength(this)" ID="TxtDescription" MaxLength="500" TextMode="MultiLine" class="textarea"></asp:TextBox>
                       <span> 500字以内</span><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('h_jstempletclass_003',this)">
                        帮助</span>
                    </div>
                </td>
             </tr>
           </table>
           <div class="nxb_submit" >
           <asp:Button ID="BtnOK" runat="server" Text=" 保 存 "  class="insubt" OnClick="BtnOK_Click" />           
           <input type="reset" name="bc" value="取消" class="insubt"/>
           </div>
         </div>
      </div>
   </div>
</div>
</div>
<asp:HiddenField runat="server" ID="HidID" />
</form>
</body>
</html>

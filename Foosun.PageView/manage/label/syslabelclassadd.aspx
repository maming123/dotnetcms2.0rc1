<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="syslabelclassadd.aspx.cs" Inherits="Foosun.PageView.manage.label.syslabelclassadd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>标签分类</title>
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
      <div class="mian_wei_left"><h3>添加/修改标签分类 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="syslabelList.aspx">标签管理</a> >>标签分类
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="20%" align="right">分类名称：</td>
               <td>
               <asp:TextBox ID="LabelClassName" runat="server" class="input8"></asp:TextBox><asp:RequiredFieldValidator ID="RequirestyleLabelClassName" runat="server" ControlToValidate="LabelClassName" Display="Dynamic" ErrorMessage="<span class=reshow>(*)请填写标签名称</spna>"></asp:RequiredFieldValidator>                   	
                  <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_labelclassadd_001',this)">帮助</span>
               </td>
             </tr>        
             <tr>
                <td width="20%" align="right">描述信息：</td>
                <td>
                    <div class="textdiv">
                      <textarea ID="ClassContent" runat="server" class="textarea1"></textarea><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_labelclassadd_002',this)">帮助</span>
                    </div>
                </td>
             </tr>
           </table>
           <div class="nxb_submit" >
               <asp:Button ID="Button1" runat="server" Text=" 保存 " class="insubt" OnClick="Button1_Click" />              
               <input type="reset" name="bc" value="重填" class="insubt"/>
               <asp:HiddenField ID="LabelClassID" runat="server" />
           </div>
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

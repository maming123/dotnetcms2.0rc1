<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineTable.aspx.cs" Inherits="Foosun.PageView.manage.sys.DefineTable" %>

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
<script language="javascript" type="text/javascript">
    function GetPY1(obj) {
        if (obj.value != "") {
            var s = obj.value;
            if (s != '') {
                document.getElementById('DefEname').value = GetPY(s);
            }
        }
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>添加/修改自定义字段</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="DefineTableManage.aspx">自定义字段管理</a> >>
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="flie_lan">
            <a href="DefineTableManage.aspx">分类管理</a>┋<a href="DefineTable.aspx">新增字段</a>┋<a href="DefineTableManage.aspx?action=add">新增分类</a>
         </div>
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
                <td colspan="2"><font>添加/修改自定义字段信息</font></td>
             </tr>
             <tr>
               <td width="15%" align="right">选择类别：</td>
               <td> 
                  <asp:DropDownList ID="ColumnsType" runat="server"  class="select3"> </asp:DropDownList>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">字段中文名称：</td>
               <td>
                  <asp:TextBox onChange="javascript:GetPY1(this);" ID="DefName" runat="server" MaxLength="50" class="input8"></asp:TextBox><asp:RequiredFieldValidator ID="f_menuName" runat="server" ControlToValidate="DefName" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写字段中文名称,长度不能超过50个字符!</span>"></asp:RequiredFieldValidator>
               <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('Def_Table_001',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">字段名(英文名)：</td>
               <td>
                 <asp:TextBox ID="DefEname" MaxLength="50" runat="server"  class="input8"></asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="英文名称必须是英文或数字及下划线!" ControlToValidate="DefEname" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[a-zA-Z_0-9__]+$"></asp:RegularExpressionValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DefEname" Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写字段英文名称,长度不能超过50个字符!</span>"></asp:RequiredFieldValidator>
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('Def_Table_002',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">控件类型：</td>
               <td> 
                  <asp:DropDownList ID="DefType" runat="server" class="select4">
            <asp:ListItem Value="1">单行文本框(text)</asp:ListItem>
            <asp:ListItem Value="2">下拉列表(select)</asp:ListItem>
            <asp:ListItem Value="3">单选按钮(radio)</asp:ListItem>
            <asp:ListItem Value="4">复选按钮(checkbox)</asp:ListItem>
            <asp:ListItem Value="6">选择图片(img)</asp:ListItem>
            <asp:ListItem Value="7">选择文件(files)</asp:ListItem>
            <asp:ListItem Value="8">多行文本框(ntext)</asp:ListItem>
            <asp:ListItem Value="9">密码框(password)</asp:ListItem>
            <asp:ListItem Value="10">日期(DateTime)</asp:ListItem>
             <asp:ListItem Value="11">文本编辑框(textEdit)</asp:ListItem>
          </asp:DropDownList>     
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('Def_Table_003',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">是否允许为空：</td>
               <td> 
                  <asp:CheckBox ID="DefIsNull" Checked="true" class="checkbox2" runat="server" />
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('Def_Table_004',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">字段默认值：</td>
               <td>
                  <asp:TextBox ID="DefColumns" runat="server" Width="232px"  class="input8"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('Def_Table_005',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">字段选项：</td>
               <td>
                  <div class="textdiv1"> 
                     <asp:TextBox ID="definedvalue" runat="server" TextMode="MultiLine" class="textarea1"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('Def_Table_definedvalue',this)">帮助</span>
                 </div>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">字段名说明：</td>
               <td>
                  <div class="textdiv1"> 
                     <asp:TextBox ID="DefExpr" runat="server" TextMode="MultiLine"  class="textarea1"></asp:TextBox>
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('Def_Table_006',this)">帮助</span>
                 </div>
               </td>
             </tr>
           </table>
           <div class="nxb_submit" >
               <asp:Button ID="btnData" runat="server" OnClick="btnData_Click" Text="提交数据" class="xsubmit1"/>
           </div>
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

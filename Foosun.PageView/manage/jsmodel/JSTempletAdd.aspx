<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSTempletAdd.aspx.cs" validateRequest="false" Inherits="Foosun.PageView.manage.jsmodel.JSTempletAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
   <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function getValue(str) {
        document.getElementById("content").value = str;
    }
    function setValue(value) {
        document.getElementById("content").value = '{#FS:define=' + value + '}';
    }
    function Display(flag) {
        if (flag == 0) {
            $('#TR_Sys').show();
            $('#TR_Free').hide();            
        }
        else {
            $('#TR_Free').show();
            $('#TR_Sys').hide();           
        }
    }
    $(function () {      
            var f = 1;
            if (document.getElementById('RadSys').checked)
                f = 0;
            Display(f);       
    });
		</script>

</head>
<body>
<div id="dialog-message" title="提示"></div>
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
        <span>功能：</span><a href="JsTemplet.aspx"> JS模型管理</a>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
               <tr>
                   <td colspan="2"><font></font>JS模型信息</td>
               </tr>
             <tr>
               <td width="10%" align="right">名称：</td>
                    <td>
                     <asp:TextBox ID="TxtName" runat="server" class="input8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName"
                        Display="Dynamic" ErrorMessage="请填写名称!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                       (<span>*</span>)<span class="helpstyle" onclick="Help('H_jstemplet_0001',this)"
                            style="cursor: help;" title="点击查看帮助">帮助</span>
                    </td>
             </tr>
             <tr>
               <td width="10%" align="right">模型类型：</td>
               <td>
                 <div class="textdiv2">
                     <asp:RadioButton ID="RadSys" runat="server"  GroupName="JSTType" onclick="Display(0);" Checked="True" />系统JS                          <asp:RadioButton ID="RadFree" runat="server" GroupName="JSTType" onclick="Display(1);" />自由JS
                    <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0003',this)">
                        帮助</span>
                  </div>
               </td>
             </tr>
             <tr>
               <td width="10%" align="right">模型分类：</td>
               <td>
                  <asp:DropDownList ID="DdlClass" runat="server" CssClass="select5">
                    <asp:ListItem Value="0">根结点</asp:ListItem>
                    </asp:DropDownList>
                 <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jstemplet_0002',this)">
                        帮助</span>
               </td>
             </tr>
             <tr id="TR_Sys">
               <td width="10%" align="right">插入内容：</td>
               <td>
               <span id="adress"></span>
                  &nbsp;&nbsp;&nbsp;<a href="javascript:selectFile('content','系统JS模型','jsmodel','750','500');" class="a4">创建调用格式</a>
                  <span class="helpstyle"
                            style="cursor: help;" title="点击查看帮助" onclick="Help('H_jstemplet_0005',this)">帮助</span>
               </td>
             </tr>  
             <tr id="TR_Free" style="display: none">
               <td width="10%" align="right">插入内容：</td>
               <td>
                 <label id="style_base" runat="server" />
                  <label id="style_class" runat="server" />
                  <label id="style_special" runat="server" />
                  <asp:DropDownList class="select7" ID="DdlCustom" runat="server"  onchange="javascript:setValue(this.value);">
                  <asp:ListItem Value="">自定义字段</asp:ListItem>
                  </asp:DropDownList>  
               </td>
             </tr>          
             <tr>
                <td width="10%" align="right">模型内容：</td>
                <td>
                    <div class="textdiv1">
                       <textarea name="content" id="content" runat="server" style="width:90%;height:200px;"></textarea>
                    </div>
                </td>
             </tr>
           </table>
           <div class="nxb_submit" >
               <asp:Button ID="BtnOK" runat="server" Text=" 保 存 " class="insubt" OnClick="BtnOK_Click" />
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

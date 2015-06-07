<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="syslableadd.aspx.cs" Inherits="Foosun.PageView.manage.label.syslableadd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>标签添加</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function getValue(value) {
        if (value != "")
            document.getElementById("FileContent").value = value;
        $('#dialog-message').dialog("close");
    }
</script>
</head>

<body>
<div id="dialog-message" title="提示"></div>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>添加/修改标签 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="syslabelList.aspx">标签管理</a> >>添加/修改标签
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="20%" align="right">标签名称：</td>
               <td>
                   	<b class="font1">{FS_</b><input type="text" id="LabelName" runat="server" name="q" value="" class="input7" /><b style="color:#F00;">} </b>
                   <asp:DropDownList ID="LabelClass" runat="server" class="select2">
				   </asp:DropDownList><asp:RequiredFieldValidator ID="RequireLabelName" runat="server" ControlToValidate="LabelName" Display="Dynamic" ErrorMessage="<span class=reshow>(*)请填写标签名称</span>"></asp:RequiredFieldValidator>                       
                  <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_Labeladd_001',this)">帮助</span><span>注意：标签名称及标签内容区分大小写。</span>
               </td>
             </tr>
             <tr>
             <td width="20%" align="right">插入内容 ：</td>
                 <td>
                    <a href="javascript:selectFile('FileContent','列表类','List','860','550');" class="a6">列表类</a><a href="javascript:selectFile('FileContent','终极类','Ultimate','860','550');" class="a6">终极类</a>
                    <a href="javascript:selectFile('FileContent','浏览类','Browse','750','500');" class="a6">浏览类</a><a href="javascript:selectFile('FileContent','栏目信息类','ClassInfo','750','500');" class="a6"> 栏目信息类</a>
                    <a href="javascript:selectFile('FileContent','专题信息类','SpecialInfo','750','500');" class="a6">专题信息类</a><a href="javascript:selectFile('FileContent','常规扩展类','Routine','750','500');" class="a6">常规扩展类</a>
                    <a href="javascript:selectFile('FileContent','会员类','Member','750','500');" class="a6">会员类</a><a href="javascript:selectFile('FileContent','表单类','Form','750','500');" class="a6">表单类</a>
                    <a href="javascript:selectFile('FileContent','其他类','Other','750','500');" class="a6">其他类</a>
                 </td>
             </tr>
             <tr>
               <td width="20%" align="right">标签内容：</td>
               <td>
                  
                  <textarea class="textarea2" name="FileContent" style="height:200px" id="FileContent" runat="server"></textarea>
                  
               </td>
             </tr>         
             <tr>
                <td width="20%" align="right">标签描述：</td>
                <td>
                    <div class="textdiv">
                      <textarea class="textarea1" id="LabelDescription" runat="server"></textarea><span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_Labeladd_003',this)">帮助</span>
                    </div>
                </td>
             </tr>
             <tr>
                <td width="20%" align="right">放入备份库：</td>
                <td>             
                    <asp:RadioButton ID="rdbyes" runat="server" GroupName="lblback" class="radio"/>是<asp:RadioButton ID="rdbno"
                        runat="server" GroupName="lblback" Checked="True" class="radio"/>否
                </td>
             </tr>
           </table>
           <div class="nxb_submit">    
           <asp:HiddenField ID="LabelID" runat="server" />          
               <asp:Button ID="Button1" runat="server" Text="保存"  onclick="Button1_Click" CssClass="xsubmit1"/>
               <input type="reset" name="bc" value="重填" class="xsubmit1"/>
           </div>
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>
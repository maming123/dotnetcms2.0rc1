<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_Sys_General_Add_Manage" Codebehind="General_Add_Manage.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server" onsubmit="javascript:return check();">
<div class="mian_body">
    <div class="mian_wei">
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>新闻常规管理 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="General_manage.aspx">新闻常规管理</a> >>新增/编辑新闻常规
          </div>
       </div>
    </div>
<div class="mian_cont">
   <div class="nwelie">
   <div class="jslie_lan" align="left"><font color="#ff0000">功能:</font> ┊ <a href="General_manage.aspx" class="topnavichar">管理首页</a> ┊ <a href="General_Add_Manage.aspx" class="topnavichar">添加</a> ┊ <a href="General_manage.aspx?key=0" class="topnavichar" onclick=""> 关键字(TAG)</a> ┊ <a href="General_manage.aspx?key=1" class="menulist">来源</a> ┊ <a href="General_manage.aspx?key=2" class="topnavichar">作者</a> ┊ <a href="General_manage.aspx?key=3" class="topnavichar">内部链接</a> ┊ <a href="General_manage.aspx?type=delall" onclick="{if(confirm('确认删除全部所有添加的信息吗？')){return true;}return false;}" class="topnavichar">删除全部</a></div>
    <div class="lanlie_lie">
         <div class="newxiu_base">
         <table class="nxb_table" id="OM_AddNew">
   <tr>
      <td colspan="2"><font>添 加</font><font style="color:#666">注：(<span style="color:#F00">*</span>)为必填</font></td>
    </tr>
    <tr>
      <td width="15%" align="right">类型：</td>
      <td width="85%" align="left">
      <asp:DropDownList ID="Sel_Type" runat="server"  CssClass="xselect4" Width="150" onchange="SelectOpType(this.value)">
          <asp:ListItem Selected="True" Value="9">请选择</asp:ListItem>
          <asp:ListItem Value="0">关键字(TAG)</asp:ListItem>
          <asp:ListItem Value="1">来源</asp:ListItem>
          <asp:ListItem Value="2">作者</asp:ListItem>
          <asp:ListItem Value="3">内部连接</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_GenType_0001',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right">标题：</td>
      <td width="85%" align="left"><asp:TextBox ID="Txt_Name"  CssClass="input8" runat="server"/>(<span style="color:Red">*</span>)<span class="helpstyle" onclick="Help('H_GenTitle_0001',this)" style="cursor: help;" title="点击查看帮助">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right">链接地址：</td>
      <td width="85%" align="left"><asp:TextBox ID="Txt_LinkUrl" CssClass="input8"  runat="server"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_GenUrl_0001',this)">帮助</span></td>
    </tr>
    <tr>
     <td width="15%" align="right">电子邮件：</td>
      <td width="85%" align="left"><asp:TextBox ID="Txt_Email" runat="server" CssClass="input8" />
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_GenEmail_0001',this)">帮助</span> </td>
    </tr>
  </table>

    <div class="nxb_submit" id="Tr_SubMit">
    <input type="submit" id="But_AddNew" name="But_AddNew" value="保 存"  class="xsubmit1 mar" runat="server" onserverclick="But_AddNew_ServerClick" />                
      <input type="reset" name="UnDo" value=" 重 填 " class="xsubmit1 mar" />
                 
             </div>
    </div>
  </div>
   </div>
</div>
</div>
</form>
</body>
<script language="javascript" type="text/javascript">
    $(function () { 
    var key='<%=Request.QueryString["kkey"] %>';
    if (key != "") {
        SelectOpType(key);
    }
});

function SelectOpType(OpType)
{
	switch(parseInt(OpType))
		{
			case 9://默认全部不显示
				document.getElementById("Tr_Url").style.display="none";
				document.getElementById("Tr_Title").style.display="none";
				document.getElementById("Tr_Email").style.display="none";
				document.getElementById("Tr_SubMit").style.display="none";
				break;
			case 0://关键字(TAG)
				document.getElementById("Tr_Url").style.display="none";
				document.getElementById("Tr_Title").style.display="";
				document.getElementById("Tr_Email").style.display="none";
				document.getElementById("Tr_SubMit").style.display="";
				break;
			case 1://来源
				document.getElementById("Tr_Url").style.display="";
				document.getElementById("Tr_Title").style.display="";
				document.getElementById("Tr_Email").style.display="none";
				document.getElementById("Tr_SubMit").style.display="";
				break;
			case 2://作者
				document.getElementById("Tr_Url").style.display="none";
				document.getElementById("Tr_Title").style.display="";
				document.getElementById("Tr_Email").style.display="";
				document.getElementById("Tr_SubMit").style.display="";
				document.getElementById("Sel_Type").style.value="2";//控制作者
				break;	
			case 3://内部连接
				document.getElementById("Tr_Url").style.display="";
				document.getElementById("Tr_Title").style.display="";
				document.getElementById("Tr_Email").style.display="none";
				document.getElementById("Tr_SubMit").style.display="";
				break;	
		}
}
//------------------------------------------------------------------
function check()
{
    if	(document.getElementById("Txt_Name").value=="")
		{
			alert("请添加标题！");
			document.getElementById("Txt_Name").focus();
			return false;
		}
		//----------检查电子邮件-------------------
	if (document.getElementById("Sel_Type").value=="2"&&document.getElementById("Txt_Email").value=="")
		{
			alert("请输入电子邮件地址！");
			document.getElementById("Txt_Email").focus();
			return false;	
		}
	if( document.getElementById("Sel_Type").value=="2"&&document.getElementById("Txt_Email").value.length<6 || document.getElementById("Sel_Type").value=="2"&&document.getElementById("Txt_Email").value.length>36 || document.getElementById("Sel_Type").value=="2"&&!validateEmail() ) 
		{
		      alert("\请您输入正确的邮箱地址 !");
		     document.getElementById("Txt_Email").focus();
		     return false;	
	    }
	return true
}
//检查电子邮件格式
function validateEmail()
{
	var re=/^[\w-]+(\.*[\w-]+)*@([0-9a-z]+[0-9a-z-]*[0-9a-z]+\.)+[a-z]{2,3}$/i;
	if(re.test(document.getElementById("Txt_Email").value))
		return true;
	else
		return false;
}
</script>
</html>

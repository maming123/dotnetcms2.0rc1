<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomFormData_Info.aspx.cs" Inherits="Foosun.PageView.manage.Sys.CustomFormData_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
	<link href="../../sysImages/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/css.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
	<form id="form1" runat="server">
    <div class="mian_body">
    <div class="mian_wei">
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>自定义表单管理</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')" target="sys_main" class="topnavichar">首页</a>>>
                  <a href="CustomForm.aspx" class="topnavichar">自定义表单</a>>>
                  <asp:HyperLink ID="HlkManage" runat="server" class="topnavichar">数据列表</asp:HyperLink>>>
              </div>
           </div>
        </div>
        <div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
		<table runat="server" id="grddatas" class="nxb_table">
		</table>
		<div class="nxb_submit" >
			<asp:Button ID="reply" runat="server" Text="回 复" CssClass="xsubmit1 mar" OnClick="reply_Click" />
			&nbsp;<input type="button" value="返 回" onclick="history.back();" class="xsubmit1 mar" />
			<asp:HiddenField ID="hd_customID" runat="server" />
			<asp:HiddenField ID="hd_FormID" runat="server" />
			<asp:HiddenField ID="hd_isshow" runat="server" />
		</div>
	</div>
    </div>
    </div>
    </div>
    </div>
	</form>
</body>
</html>

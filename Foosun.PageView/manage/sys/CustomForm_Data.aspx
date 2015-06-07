<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomForm_Data.aspx.cs" Inherits="Foosun.PageView.manage.Sys.CustomForm_Data" %>

<%@ Register src="../../controls/PageNavigator.ascx" tagname="PageNavigator" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
	<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
       <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
	<script type="text/javascript" language="javascript">
		function TruncateTb(id, nm) {
		    if (window.confirm('你确定要清空数据表:' + nm + ' 吗?数据将不能被恢复!')) {
                jQuery.get('CustomForm_Data.aspx?Option=TruncateTb&ID=' + id, function(retv){
                    location.href=location.href;
                });
			}
		}

	</script>
</head>
<body>
	<form id="form1" runat="server">
        <div class="mian_body">
            <div class="mian_wei">
               <div class="mian_wei_min">
                  <div class="mian_wei_left"><h3>自定义表单管理</h3></div>
                  <div class="mian_wei_right">
                      导航：<a href="../main.aspx" target="sys_main" class="topnavichar">首页</a>>>
                      <a href="CustomForm.aspx" class="topnavichar">自定义表单</a>>>
                      <asp:Label runat="server" ID="LblName"></asp:Label>>>提交数据  
                  </div>
               </div>
            </div>
            <div class="mian_cont">
                <div class="nwelie">
                    <div class="jslie_lan">
                        <a href="#" id="clearTableForm" runat="server" class="topnavichar">清空该表</a>
                    </div>
	<div  class="jslie_lie">
		<table runat="server" id="grddatas" class="jstable">
		</table>
            <div class="fanye1">
         <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
      </div>
	</div>
    </div>
    </div>
	</div>
	</form>
</body>
</html>

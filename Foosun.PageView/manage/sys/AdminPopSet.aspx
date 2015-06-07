<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPopSet.aspx.cs" Inherits="Foosun.PageView.manage.sys.AdminPopSet" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>管理员权限管理</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
</head>
<body>
	<form id="form1" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>管理员权限管理 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="AdminList.aspx">管理员管理</a> >>权限设置
          </div>
       </div>
       <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
    </div>
    <div class="mian_cont">
    <div class="nwelie">
    <div class="jslie_lan">
        <span>功能：</span>套用固定权限组：<a href="javascript:getPopGroup(5)">录入员</a>&nbsp;┊&nbsp;<a href="javascript:getPopGroup(4)">编辑</a>&nbsp;┊&nbsp;<a href="javascript:getPopGroup(3)">责任编辑</a>&nbsp;┊&nbsp; <a href="javascript:getPopGroup(2)">总编辑</a>&nbsp;┊&nbsp;<a href="javascript:getPopGroup(1)">普通管理员</a>&nbsp;┊&nbsp;<a href="javascript:getPopGroup(0)">高级管理员</a>&nbsp;&nbsp;<span class="helpstyle" style="cursor: help;" title="如何使用扩展权限" onClick="Help('H_pop_ext',this)">如何使用扩展权限?</span>
				<input type="checkbox" value="-222" onClick="selectAll(this.form,this.checked);" />全选
      </div>
	<div class="lanlie_lie">
    <div class="newxiu_base">
	<table class="jstable" style="margin:0 0 10px 5px;">
		<tr>
			<th align="left" style="line-height:40px;height:40px;">
				<span class="span1">内容管理</span>&nbsp;&nbsp;<img src="/CSS/imges/bs.gif" border="0" style="cursor: pointer;" onClick="hiddenShowDiv('contentPop');" title="点击隐藏/展开" />
			</th>
		</tr>
		<tr>
			<td align="left">
				<div id="contentPop" runat="server" class="xiquax"></div>
			</td>
		</tr>
	</table>
	<table class="jstable" style="margin:0 0 10px 5px;">
		<tr>
			<th align="left" style="line-height:40px;height:40px;">
				<span class="span1">会员管理</span>&nbsp;&nbsp;<img src="/CSS/imges/bs.gif" border="0" style="cursor: pointer;" onClick="hiddenShowDiv('UserPop');" title="点击隐藏/展开" />
			</th>
		</tr>
		<tr>
			<td>
				<div id="UserPop" runat="server" class="xiquax" ></div>
			</td>
		</tr>
	</table>
	<table class="jstable" style="margin:0 0 10px 5px;">
		<tr>
			<th align="left" style="line-height:40px;height:40px;">
				<span class="span1">模板管理</span>&nbsp;&nbsp;<img src="/CSS/imges/bs.gif" border="0" style="cursor: pointer;" onClick="hiddenShowDiv('TempletPop');" title="点击隐藏/展开" />
			</th>
		</tr>
		<tr>
			<td>
				<div id="TempletPop" runat="server" class="xiquax" ></div>
			</td>
		</tr>
	</table>
	<table class="jstable" style="margin:0 0 10px 5px;">
		<tr>
			<th align="left" style="line-height:40px;height:40px;">
				<span class="span1">发布管理</span>&nbsp;&nbsp;<img src="/CSS/imges/bs.gif" border="0" style="cursor: pointer;" onClick="hiddenShowDiv('PublishPop');" title="点击隐藏/展开" />
			</th>
		</tr>
		<tr>
			<td>
				<div id="PublishPop" runat="server" class="xiquax"></div>
			</td>
		</tr>
	</table>
	<table class="jstable" style="margin:0 0 10px 5px;">
		<tr>
			<th align="left" style="line-height:40px;height:40px;">
				<span class="span1">系统插件</span>&nbsp;&nbsp;<img src="/CSS/imges/bs.gif" border="0" style="cursor: pointer;" onClick="hiddenShowDiv('sysPlusPop');" title="点击隐藏/展开" />
			</th>
		</tr>
		<tr>
			<td>
				<div id="sysPlusPop" runat="server" class="xiquax"></div>
			</td>
		</tr>
	</table>
	<table class="jstable" style="margin:0 0 10px 5px;">
		<tr>
			<th align="left" style="line-height:40px;height:40px;">
				<span class="span1">控制面板</span>&nbsp;&nbsp;<img src="/CSS/imges/bs.gif" border="0" style="cursor: pointer;" onClick="hiddenShowDiv('ControlPop');" title="点击隐藏/展开" />
			</th>
		</tr>
		<tr>
			<td>
				<div id="ControlPop" runat="server"  class="xiquax"></div>
			</td>
		</tr>
	</table>
	<table class="jstable" style="margin:0 0 10px 5px;">
		<tr>
			<th align="left" style="line-height:40px;height:40px;">
				<span class="span1">API管理</span>&nbsp;&nbsp;<img src="/CSS/imges/bs.gif" border="0" style="cursor: pointer;" onClick="hiddenShowDiv('APIPop');" title="点击隐藏/展开" />
			</th>
		</tr>
		<tr>
			<td>
				<div id="APIPop" runat="server" class="xiquax"></div>
			</td>
		</tr>
	</table>
    <div class="nxb_submit" >
                <asp:Button ID="Button1" runat="server" CssClass="xsubmit1" Text="保存权限" OnClick="Button1_Click" />
				<input type="button" name="Submit" value="重新设置" class="xsubmit1" onClick="javascript:UnDo();" />
           </div>
    </div>
    </div>
    </div>
    </div>
    </div>
	</form>
</body>
</html>
<script type="text/javascript">
    function UnDo() {
        if (confirm('你确定要取消所做的更改吗?')) {
            document.form1.reset();
        }
    }
    function getPopGroup(num) {
        var UserNum = '<%Response.Write(Request.QueryString["UserNum"]); %>';
        var id = '<%Response.Write(Request.QueryString["id"]); %>';
        window.location.href = "AdminPopSet.aspx?UserNum=" + UserNum + "&id=" + id + "&num=" + num + ""
    }
    function getPopCode(code) {
        var ie4 = document.all && navigator.userAgent.indexOf("Opera") == -1;
        var ns6 = document.getElementById && !document.all
        if (ie4) {
            var clipBoardContent = code;
            window.clipboardData.setData("Text", clipBoardContent);
            alert("代码已经复制。代码：" + code + "");
        }
        else {
            alert("FireFox浏览器用户请直接复制代码!");
        }
    }
    function hiddenShowDiv(id) {
        var objs = document.getElementById(id);
        if (objs.style.display == "block") {
            objs.style.display = "none";
        }
        else {
            objs.style.display = "block";
        }
    }
</script>

<%@ Page Language="C#" AutoEventWireup="true" Inherits="sys_Param" CodeBehind="sys_Param.aspx.cs" validateRequest="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>系统参数设置</title>
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
	<form id="SetParam" runat="server" onclick="check()">
    <div id="dialog-message" title="提示"></div>
    <div class="mian_body">
	<iframe width="260" height="165" id="colorPalette" src="../../configuration/system/selcolor.htm" style="visibility: hidden; position: absolute; border: 1px gray solid; left: 31px; top: 140px;" frameborder="0" scrolling="no"></iframe>
    <div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>系统参数设置 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="../main.aspx" class="navi_link">首页</a> >> 系统参数设置
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
    <div class="nwelie">
                <div class="lanlie_lie">
                <div class="flie_lan">
                        <span style="cursor: pointer; width: 100px;" id="td_baseinfo" onclick="javascript:ChangeDiv('baseinfo')">基本属性</span>┋<span style="cursor: pointer; width: 100px;" id="td_user" onclick="javascript:ChangeDiv('user')">会员参数</span>┋<span id="td_upload" style="cursor: pointer; width: 100px;" onclick="javascript:ChangeDiv('upload')">上传.分组刷新</span>┋<span id="td_js" style="cursor: pointer; width: 100px;" onclick="javascript:ChangeDiv('js')" title="此版本未开放">FTP设置</span>┋<span id="td_water" style="cursor: pointer; width: 100px;" onclick="javascript:ChangeDiv('water')">水印缩图</span>┋<span id="td_rssxmlwap" style="cursor: pointer; width: 100px;" onclick="javascript:ChangeDiv('rssxmlwap')">RSS.XML.WAP</span>┋<span id="td_api" style="cursor: pointer; display: none;" onclick="javascript:ChangeDiv('api')">API参数</span>
                    </div>
                    <div class="newxiu_base">
	<table border="0" cellpadding="0" align="center" cellspacing="0" style="width:100%">
		<tr>
			<td colspan="9" valign="top">
				<div id="div_baseinfo" style="display: block" align="center">
					<table class="nxb_table">
                        <tr>
                           <td colspan="2" align="left">
                                    <font style="font-size:12px;">基本参数设置</font>
                                </td>
                            </tr>
						<tr>
							<td  width="15%" align="right">
								站点名称：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="SiteName" runat="server" CssClass="input9" /><span id="SiteName_Span" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0001',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								站点域名：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="SiteDomain" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0002',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								首页模板路径：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="IndexTemplet" runat="server" CssClass="input9" />
								<label>
									<img src="../imges/bgxiu_14.gif" alt="选择内容模板" border="0" style="cursor: pointer;" onclick="selectFile('IndexTemplet','模版选择','templet',500,500);document.SetParam.IndexTemplet.focus();" />
								</label>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								首页生成的文件名：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="IndexFileName" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0003',this)">帮助</span>
							</td>
						</tr>
						<tr style="display: none;">
							<td width="20%" align="right">
								默认的扩展名为（主站）：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="FileEXName" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0004',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								默认的新闻浏览页模板：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="ReadNewsTemplet" runat="server" CssClass="input9" />
								<label>
									<img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;" onclick="selectFile('ReadNewsTemplet','模版选择','templet',500,500);document.SetParam.ReadNewsTemplet.focus();" />
								</label>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								默认的栏目浏览页模板：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="ClassListTemplet" runat="server" CssClass="input9" />
								<label>
									<img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;" onclick="selectFile('ClassListTemplet','模版选择','templet',500,500);document.SetParam.ClassListTemplet.focus();" />
								</label>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								默认的专题浏览页模板：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="SpecialTemplet" runat="server" CssClass="input9" />
								<label>
									<img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;" onclick="selectFile('SpecialTemplet','模版选择','templet',500,500);document.SetParam.SpecialTemplet.focus();" />
								</label>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								前台浏览方式：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton CssClass="radio" ID="DongTai" runat="server" Text="动态调用" GroupName="ReadType" />&nbsp;
                                <asp:RadioButton ID="JingTai" CssClass="radio" runat="server" Text="静态调用" GroupName="ReadType" />
							</td>
						</tr>
                        <tr>
                            <td width="20%" align="right">发布方式：</td>
                            <td width="80%" align="left">
                                <asp:RadioButton ID="rdLabel" Text="标签发布" runat="server" CssClass="radio" GroupName="publishType" />
                                <asp:RadioButton ID="rdDrag" runat="server" Text="拖拽发布" CssClass="radio" GroupName="publishType" />
                            </td>
                        </tr>
						<tr style="display: none;">
							<td width="20%" align="right">
								管理列表每页显示记录条数：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="Pram_Index" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0015',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								后台登陆过期时间：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="LoginTimeOut" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0005',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								管理员信箱：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="Email" runat="server" CssClass="input9" />
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								站点采用路径方式：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="JueDui" CssClass="radio" runat="server" Text="绝对路径" GroupName="LinkType" />&nbsp;<asp:RadioButton ID="XiangDui" runat="server" CssClass="radio" Text="相对路径" GroupName="LinkType" />
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								版权信息：<br />
								(支持html格式)
							</td>
							<td width="80%" align="left">
								<div class="textdiv4"><textarea width="250" id="BaseCopyRight" name="BaseCopyRight" runat="server" tabindex="0" style="width: 313px; height: 110px" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0006',this)">帮助</span></div>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								新闻后台审核机制：
							</td>
							<td width="80%" align="left">
								<asp:DropDownList ID="CheckInt" CssClass="select3" runat="server">
									<asp:ListItem Selected="True" Value="0">不审核</asp:ListItem>
									<asp:ListItem Value="1">一级审核</asp:ListItem>
									<asp:ListItem Value="2">二级审核</asp:ListItem>
									<asp:ListItem Value="3">三级审核</asp:ListItem>
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								生成归档索引生成多少天前索引：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="HistoryNum" runat="server" MaxLength="3" Text="30" CssClass="input9" /><span id="Span4" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_HistoryNum',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								画中画插入新闻内容中的位置：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="InsertPicPosition" runat="server" Text="200|left" CssClass="input9" /><span id="Span3" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_InsertPicPosition',this)">帮助</span>
							</td>
						</tr>
						<tr style="display: none;">
							<td width="20%" align="right">
								是否开启图片防盗链：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="Yes" CssClass="radio" runat="server" Text="开启" GroupName="UnLinkTF" />&nbsp;<asp:RadioButton ID="No" runat="server" CssClass="radio" Text="不开启" GroupName="UnLinkTF" />
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								搜索关键字长度：
							</td>
							<td width="80%" align="left">
								<asp:TextBox Width="250" ID="LenSearch" runat="server" CssClass="input9" /><span id="keyLength" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0007',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								添加新闻检查是否有相同标题：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="checktitle" CssClass="radio" runat="server" Text="检测" GroupName="CheckNewsTitle" />&nbsp;<asp:RadioButton ID="nochecktitle" CssClass="radio" runat="server" Text="不检测" GroupName="CheckNewsTitle" />
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								是否开启防采集：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="Ischeck" CssClass="radio" runat="server" Text="开启" GroupName="CollectTF" />&nbsp;<asp:RadioButton ID="nocheck" runat="server" Text="不开启" CssClass="radio" GroupName="CollectTF" />
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								生成栏目文件保存路径：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="SaveClassFilePath" runat="server" Width="250" CssClass="input9" />
								&nbsp; 
                                <img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;" onclick="selectFile('SaveClassFilePath','模版选择','path|<% Response.Write(Foosun.Config.UIConfig.dirHtml); %>',500,500);document.SetParam.SaveClassFilePath.focus();" />
                                 <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0008',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								生成索引页的规则：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="SaveIndexPage" runat="server" Width="250" CssClass="input9" />&nbsp;<img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;" onclick="selectFile('SaveIndexPage','模版选择','rulesmallPram',500,200);document.SetParam.SaveIndexPage.focus();" />
								 <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0009',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								生成新闻的文件命名规则：
							</td>
							<td  width="85%" align="left">
								<asp:TextBox ID="SaveNewsFilePath" runat="server" Width="250px" CssClass="input9" />
								&nbsp;
                                <img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;" onclick="selectFile('SaveNewsFilePath','模版选择','rulePram',500,200);document.SetParam.SaveNewsFilePath.focus();" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0010',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								生成新闻的文件保存路径规则：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="SaveNewsDirPath" runat="server" Width="250px" CssClass="input9" />
								&nbsp; 
                                <img src="../imges/bgxiu_14.gif" alt="选择栏目模板" border="0" style="cursor: pointer;" onclick="selectFile('SaveNewsDirPath','模版选择','rulesmallPram',500,200);document.SetParam.SaveNewsDirPath.focus();" /> 
                                <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_BaseParam_0011',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								是否开启内容自动分页：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton CssClass="radio" ID="RadioButton_autoPageSplit1" runat="server" GroupName="autoPageSplit" Text="开启" />
								<asp:RadioButton CssClass="radio" ID="RadioButton_autoPageSplit2" runat="server" GroupName="autoPageSplit" Text="不开启" />
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								内容分页字数：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="txt_pageSplitCount" CssClass="input9" runat="server" Width="250px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								内容分页样式：
							</td>
							<td width="80%" align="left">
								<select class="select1" name="PageStyle" runat="server" style="width: 200px;" id="NewsPageStyle">
									<option value="0">首页 上一页 上N页 1 2 下N页 下一页 尾页</option>
									<option value="1">上一页 1 2 下一页</option>
									<option value="2">|< << < 1 2 > >> >|</option>
									<option value="3">新浪分页样式</option>
									<option value="4" selected="selected">自定义样式</option>
								</select>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								&nbsp;分页显示链接个数：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="PageLinkCount" CssClass="input9" runat="server" Width="250px"></asp:TextBox>&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="PageLinkCount" ErrorMessage="填写2-10之间的数字" MaximumValue="10" MinimumValue="2" Type="Integer"></asp:RangeValidator>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PageLinkCount" ErrorMessage="*"></asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PageLinkCount" ErrorMessage="只能输入数字" ValidationExpression="\d+"></asp:RegularExpressionValidator>
							</td>
						</tr>
					</table>
                    <div class="nxb_submit">
                        <input type="submit" name="Savebaseinfo" value=" 提 交 " class="xsubmit1" id="SaveBaseInfo" runat="server" onserverclick="SaveBaseInfo_ServerClick" />
                        <input type="reset" name="Clearbaseinfo" value=" 重 填 " class="xsubmit1" id="ClearBaseInfo" runat="server" />
                    </div>
				</div>
				<div id="div_user" style="display: none" align="center">
					<table class="nxb_table">
                        <tr>
                                <td colspan="2" align="left">
                                    <font style="font-size:12px;">会员参数设置</font>
                                </td>
                            </tr>
						<tr>
							<td width="20%" align="right">
								会员注册默认会员组：
							</td>
							<td width="80%" align="left">
								<asp:DropDownList CssClass="select3" ID="RegGroupNumber" runat="server">
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0001',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								投稿状态：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="IsConstrTF" CssClass="radio" runat="server" Text="开启" GroupName="ConstrTF" />&nbsp;<asp:RadioButton ID="NoConstrTF" runat="server" Text="不开启"  CssClass="radio" GroupName="ConstrTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0002',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								是否允许注册：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="RegYes" runat="server" Text="允许" CssClass="radio" GroupName="RegTF" />&nbsp;<asp:RadioButton ID="RegNo" runat="server" Text="不允许" GroupName="RegTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0003',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								会员登陆是否需要验证码：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="codeyes" CssClass="radio" runat="server" Text="需要" GroupName="UserLoginCodeTF" />&nbsp;<asp:RadioButton ID="codeno" runat="server" CssClass="radio" Text="不需要" GroupName="UserLoginCodeTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0004',this)">帮助</span>
							</td>
						</tr>
						<tr style="display: none;">
							<td width="20%" align="right">
								会员评论是否需要验证码：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="dis" runat="server" CssClass="radio" Text="需要" GroupName="CommCodeTF" />&nbsp;<asp:RadioButton ID="nodis" runat="server" CssClass="radio" Text="不需要" GroupName="CommCodeTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0005',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								评论需要审核：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="CommCheck1" CssClass="radio" runat="server" Text="需要" GroupName="CommCheck" />&nbsp;<asp:RadioButton ID="CommCheck0" runat="server" CssClass="radio" Text="不需要" GroupName="CommCheck" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_CommCheck',this)">帮助</span>
							</td>
						</tr>
						<tr style="display: none;">
							<td width="20%" align="right">
								是否开启群发功能：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="sendall" CssClass="radio" runat="server" Text="开启" GroupName="SendMessageTF" />&nbsp;<asp:RadioButton ID="sendone" runat="server" CssClass="radio" Text="不开启" GroupName="SendMessageTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0006',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								是否允许匿名评论：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="yun" runat="server" CssClass="radio" Text="开启" GroupName="UnRegCommTF" />&nbsp;<asp:RadioButton ID="noyun" runat="server" CssClass="radio" Text="不开启" GroupName="UnRegCommTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0007',this)">帮助</span>
							</td>
						</tr>
						<tr style="display: none;">
							<td width="20%" align="right">
								评论是否需要加载html编辑器：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="html" CssClass="radio" runat="server" Text="需要" GroupName="CommHTMLLoad" />&nbsp;<asp:RadioButton ID="nohtml" CssClass="radio" runat="server" Text="不需要" GroupName="CommHTMLLoad" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0008',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								评论过滤字符：
							</td>
							<td width="80%" align="left">
								<div class="textdiv4"><textarea id="Commfiltrchar" runat="server" style="width: 500px; height: 96px; font-size:12px; "/>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0009',this)">帮助</span></div>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								会员IP登陆限制：
							</td>
							<td width="80%" align="left">
								<div class="textdiv4"><textarea id="IPLimt" runat="server" style="width: 500px; height: 113px; font-size:12px;" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0010',this)">帮助</span></div>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								会员G币单位：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="GpointName" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0011',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								会员注册获得的金币|积分：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="setPoint" runat="server" CssClass="input9" /><span id="Point_Span" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0012',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								魅力值增加：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="cPointParam" runat="server" CssClass="input9" /><span id="Span1" runat="server" /><span id="MeiL" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0017',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								活跃值增加：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="aPointparam" runat="server" CssClass="input9" /><span id="Span2" runat="server" /><span id="Huo" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0018',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								会员冲值类型：
							</td>
							<td width="80%" align="left">
								<asp:RadioButton ID="JiFen" CssClass="radio" runat="server" Text="冲值为积分" GroupName="MoneyType" Checked="True" />
								<asp:RadioButton ID="GB" CssClass="radio" runat="server" Text="冲值为金币" GroupName="MoneyType" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0020',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								错误登陆次数|锁定时间：
							</td>
							<td width="80%" align="left">
								<asp:TextBox ID="LoginLock" runat="server" CssClass="input9" /><span id="Login_Span" runat="server" /> <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0013',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								会员注册需知：<br />
								(支持html格式)
							</td>
							<td width="80%" align="left">
								<div class="textdiv4"><textarea id="RegContent" runat="server" style="width: 500px; height: 175px; font-size:12px; " />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_0014',this)">帮助</span></div>
							</td>
						</tr>
                        <tr>
                                <td colspan="2" align="left">
                                    <font style="font-size:12px;">会员注册设置</font>
                                </td>
                            </tr>
						<tr>
							<td class="list_link" width="20%">
								<div align="right">
									选择需要注册的参数：</div>
							</td>
							<td class="list_link" align="left" width="80%">
								<div class="textdiv4"><asp:TextBox  ID="regitemContent" runat="server" Width="500" Height="60px" Style="font-size:14px;" TextMode="MultiLine"></asp:TextBox>
								<input type="button" name="t234" value="清空" onclick="clears();" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_registerParam_0001',this)">帮助</span>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="数据不能为空" ControlToValidate="regitemContent"></asp:RequiredFieldValidator>
                                </div>
							</td>
						</tr>
						<tr>
							<td class="list_link" width="20%">
								<div align="right">
									选择参数：</div>
							</td>
							<td class="list_link" align="left" width="80%">
                              <div class="textdiv4">
                                <div class="xican_she">
								  <ul>
                                     <li><input type="checkbox" id="ChbUName" value="UserName" name="regitem" onclick="ay(this);" />
											用户名</li>
									 <li>
											<input type="checkbox" value="UserPassword" name="regitem" onclick="ay(this);" />
											密 码
                                     </li>
                                     <li>
											<input type="checkbox" value="email" name="regitem" onclick="ay(this);" />
											电子邮件
									  </li>
                                      <li>
											<input type="checkbox" value="PassQuestion" name="regitem" onclick="ay(this);" />
											密码问题
									</li>
                                    <li>
											<input type="checkbox" value="PassKey" name="regitem" onclick="ay(this);" />
											密码答案
									</li>	
                                    <li>
											<input type="checkbox" value="RealName" name="regitem" onclick="ay(this);" />
											真实姓名
                                     </li>
									<li>
											<input type="checkbox" value="NickName" name="regitem" onclick="ay(this);" />
											昵称
									</li>
									<li>
											<input type="checkbox" value="CertType" name="regitem" onclick="ay(this);" />
											证件类型
									</li>
                                    <li>
											<input type="checkbox" value="CertNumber" name="regitem" onclick="ay(this);" />
											证件号码
									</li>
                                    <li>
											<input type="checkbox" value="province" name="regitem" onclick="ay(this);" />
											省份
									</li>
                                    <li>
											<input type="checkbox" value="City" name="regitem" onclick="ay(this);" />
											城市
									</li>
                                    <li>
											<input type="checkbox" value="Address" name="regitem" onclick="ay(this);" />
											地址
									</li>
                                    <li>
											<input type="checkbox" value="Postcode" name="regitem" onclick="ay(this);" />
											邮政编码
									</li>
                                    <li>
											<input type="checkbox" value="Mobile" name="regitem" onclick="ay(this);" />
											手机
									</li>
                                    <li>
											<input type="checkbox" value="Fax" name="regitem" onclick="ay(this);" />
											传真
									</li>
                                    <li>
											<input type="checkbox" value="WorkTel" name="regitem" onclick="ay(this);" />
											工作电话
									</li>
                                    <li>
											<input type="checkbox" value="FaTel" name="regitem" onclick="ay(this);" />
											家庭电话
									</li>
                                    <li>
											<input type="checkbox" value="QQ" name="regitem" onclick="ay(this);" />
											QQ
										</li>
                                    <li>
											<input type="checkbox" value="MSN" name="regitem" onclick="ay(this);" />
											MSN
										</li>
                                     </ul>
								</div>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_registerParam_0002',this)">帮助</span>
                              </div>
							</td>
						</tr>
						<tr>
							<td class="list_link" width="20%">
								<div align="right">
									注册是否需要电子邮件验证：</div>
							</td>
							<td class="list_link" align="left" width="80%">
								<asp:DropDownList ID="returnemail" runat="server" CssClass="xselect4">
									<asp:ListItem Value="0">否</asp:ListItem>
									<asp:ListItem Value="1">是</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_registerParam_0003',this)">帮助</span>
							</td>
						</tr>
						<tr style="display:none">
							<td class="list_link" width="20%">
								<div align="right">
									注册是否需要手机认证(需要ISP接口)：</div>
							</td>
							<td class="list_link" align="left" width="80%">
								<asp:DropDownList ID="returnmobile" runat="server" CssClass="xselect4">
									<asp:ListItem Value="0">否</asp:ListItem>
									<asp:ListItem Value="1">是</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_registerParam_0004',this)">帮助</span>
							</td>
						</tr>
                        <tr>
                                <td colspan="2" align="left">
                                    <font style="font-size:12px;">会员等级设置</font>
                                    <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UserParam_levels',this)">帮助</span>
                                </td>
                            </tr>
						<tr align="left">
							<td align="center" colspan="2" class="list_link" id="LevelID">
								<p class="xip">
									1,名称：
									<asp:TextBox ID="LTitle_TextBox1" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox1" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox1" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									2,名称：
									<asp:TextBox ID="LTitle_TextBox2" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox2" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox2" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									3,名称：
									<asp:TextBox ID="LTitle_TextBox3" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox3" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox3" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									4,名称：
									<asp:TextBox ID="LTitle_TextBox4" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox4" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox4" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									5,名称：
									<asp:TextBox ID="LTitle_TextBox5" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox5" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox5" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									6,名称：
									<asp:TextBox ID="LTitle_TextBox6" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox6" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox6" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									7,名称：
									<asp:TextBox ID="LTitle_TextBox7" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox7" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox7" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									8,名称：
									<asp:TextBox ID="LTitle_TextBox8" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox8" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox8" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									9,名称：
									<asp:TextBox ID="LTitle_TextBox9" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox9" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox9" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
								<p class="xip">
									10,名称：<asp:TextBox ID="LTitle_TextBox10" runat="server" Width="90px" Height="16px" CssClass="input9" />
									&nbsp; 头像:
									<asp:TextBox ID="Lpicurl_TextBox10" runat="server" Width="90px" Height="16px" CssClass="input9" />
									需要积分:
									<asp:TextBox ID="iPoint_TextBox10" runat="server" Width="90px" Height="16px" CssClass="input9" />
								</p>
							</td>
						</tr>
					</table>
                    <div class="nxb_submit">
                        <input type="submit" name="Saveuser" value=" 提 交 " class="xsubmit1" id="SaveUser" runat="server" onserverclick="SaveUser_ServerClick" />
                        <input type="reset" name="Clearuser" value=" 重 填 " class="xsubmit1" id="ClearUser" runat="server" />
                    </div>
				</div>
				<div id="div_upload" style="display: none" align="center">
					<table class="nxb_table">
                        <tr>
                                <td colspan="2" align="left">
                                    <font style="font-size:12px;">上传分组参数设置</font>
                                </td>
                            </tr>
						<tr>
							<td width="25%" align="right">
								图片存放路径做为单独域名(此版本没开放)：
							</td>
							<td width="75%" align="left">
								<asp:RadioButton ID="picy" CssClass="radio" runat="server" onclick="SelectOpPic0(1)" Text="是" GroupName="PicServerTF" />&nbsp;<asp:RadioButton ID="picn" runat="server" onclick="SelectOpPic0(0)" Text="否" GroupName="PicServerTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0001',this)">帮助</span>
							</td>
						</tr>
						<tr id="PicDomain" style="display: none">
							<td width="25%" align="right">
								域名：
							</td>
							<td width="75%" align="left">
								<asp:TextBox ID="PicServerDomain" Width="250" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0002',this)">帮助</span>
							</td>
						</tr>
						<tr id="PicDir" style="display: none">
							<td width="25%" align="right">
								图片（附件）目录：
							</td>
							<td width="75%" align="left">
								<asp:TextBox ID="PicUpload" Width="250" runat="server" CssClass="input9" />
								&nbsp; 
                                <img src="../imges/bgxiu_14.gif" alt="选择路径" border="0" style="cursor: pointer;" onclick="selectFile('PicUpload','选择路径','path|<%Response.Write(Foosun.Config.UIConfig.dirFile); %>',500,500);document.SetParam.PicUpload.focus();" />
                                <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0003',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="25%" align="right">
								上传文件允许格式：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="UpfilesType" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0004',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="25%" align="right">
								上传文件允许大小：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="UpFilesSize" runat="server" CssClass="input9" />
								kb<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0005',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="25%" align="right">
								远程图片服务器域名启用(此版本没开放)：
							</td>
							<td width="75%" align="left">
								<asp:RadioButton ID="domainr" CssClass="radio" runat="server" onclick="SelectOpPic1(1)" Text="是" GroupName="ReMoteDomainTF" />&nbsp;<asp:RadioButton ID="domainn" runat="server" onclick="SelectOpPic1(0)" Text="否" GroupName="ReMoteDomainTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0006',this)">帮助</span>
							</td>
						</tr>
						<tr id="FarDomain" style="display: none">
							<td width="25%" align="right">
								远程图片域名：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="RemoteDomain" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0007',this)">帮助</span>
							</td>
						</tr>
						<tr id="FarDir" style="display: none">
							<td width="25%" align="right">
								远程图片保存路径：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="RemoteSavePath" runat="server" CssClass="input9" />
								&nbsp; 
                                <img src="../imges/bgxiu_14.gif" alt="选择路径" border="0" style="cursor: pointer;" onclick="selectFile('RemoteSavePath','选择路径','path|<%Response.Write(Foosun.Config.UIConfig.dirFile); %>',500,500);document.SetParam.RemoteSavePath.focus();" /><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0008',this)">帮助</span>
							</td>
						</tr>
                        <tr>
                                <td colspan="2" align="left">
                                    <font style="font-size:12px;">分组刷新设置</font>
                                </td>
                            </tr>
						<tr>
							<td width="25%" align="right">
								列表每次刷新数（终极栏目列表）：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="ClassListNum" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0009',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="25%" align="right">
								信息每次刷新数：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="NewsNum" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0011',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="25%" align="right">
								批量删除信息每次删除数：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="BatDelNum" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0012',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="25%" align="right">
								专题每次刷新数：
							</td>
							<td width="75%" align="left">
								<asp:TextBox Width="250" ID="SpecialNum" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_UploadParam_0013',this)">帮助</span>
							</td>
						</tr>
					</table>
                    <div class="nxb_submit">
                        <input type="submit" name="Saveupload" value=" 提 交 " class="xsubmit1" id="SaveUpload" runat="server" onserverclick="SaveUpload_ServerClick" />
                        <input type="reset" name="Clearupload" value=" 重 填 " class="xsubmit1" id="ClearUpload" runat="server" />
                    </div>
				</div>
				<div id="div_js" style="display: none" >
					<table class="nxb_table">
                    <tr>
                                <td colspan="2" align="left">
                                    <font style="font-size:12px;">FTP参数设置</font>
                                </td>
                            </tr>
						<tr>
							<td>
								<div class="textdiv2">远程发布功能：
								<asp:RadioButton ID="ftpy" runat="server" onclick="SelectOpPic2(1)" Text="是" GroupName="FtpTF" />&nbsp;<asp:RadioButton ID="ftpn" runat="server" onclick="SelectOpPic2(0)" Text="否" GroupName="FtpTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_JSParam_0001',this)">帮助</span></div>
							</td>
						</tr>
						<tr id="Ftp" style="display: none">
							<td colspan="2">
								<div class="textdiv2">FTP地址：
								<asp:TextBox ID="FTPIP" runat="server" CssClass="input10" Width="107px" />
								FTP端口：
								<asp:TextBox ID="Ftpport" runat="server" CssClass="input10" Width="107px" />
								FTP帐号：
								<asp:TextBox ID="FtpUserName" runat="server" CssClass="input10" Width="107px" />
								FTP密码：
								<asp:TextBox ID="FTPPASSword" runat="server" CssClass="input10" Width="107px" />
                                </div>
							</td>
						</tr>
						<tr style="display: none;">
							<td align="left" colspan="2" class="list_link">
								<strong><span style="color: #000033">JS设置</span></strong><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_JSParam_0002',this)">帮助</span>
							</td>
						</tr>
						<tr style="display: none;">
							<td>
								<p>
									热门信息显示：
									<asp:TextBox ID="JsNews1" runat="server" Height="16px" Width="90px" CssClass="input9"></asp:TextBox>
									条信息，标题截取
									<asp:TextBox ID="JsTitle1" runat="server" Height="16px" Width="90px" CssClass="input9"></asp:TextBox>
									字
									<asp:DropDownList ID="JsModel1" runat="server" Height="18px" Width="90px">
									</asp:DropDownList>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<label>
										<input type="submit" name="HotNewsJsButton" value=" 查看模型 " class="form" id="HotNewsJsButton" />
									</label>
								</p>
								<p>
									最新信息显示：
									<asp:TextBox ID="JsNews2" runat="server" Height="16px" Width="90px" CssClass="input9" />
									条信息，标题截取
									<asp:TextBox ID="JsTitle2" runat="server" Height="16px" Width="90px" CssClass="input9"></asp:TextBox>
									字
									<asp:DropDownList ID="JsModel2" runat="server" Height="18px" Width="90px">
									</asp:DropDownList>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<label>
										<input type="submit" name="LastNewsJsButton" value=" 查看模型 " class="form" id="LastNewsJsButton" />
									</label>
								</p>
								<p>
									推荐信息显示：
									<asp:TextBox ID="JsNews3" runat="server" Height="16px" Width="90px" CssClass="input9" />
									条信息，标题截取
									<asp:TextBox ID="JsTitle3" runat="server" Height="16px" Width="90px" CssClass="input9"></asp:TextBox>
									字
									<asp:DropDownList ID="JsModel3" runat="server" Height="18px" Width="90px">
									</asp:DropDownList>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<label>
										<input type="submit" name="RecNewsJSButton" value=" 查看模型 " class="form" id="RecNewsJSButton" />
									</label>
								</p>
								<p>
									热门评论显示：
									<asp:TextBox ID="JsNews4" runat="server" Height="16px" Width="90px" CssClass="input9" />
									条信息，标题截取
									<asp:TextBox ID="JsTitle4" runat="server" Height="16px" Width="90px" CssClass="input9"></asp:TextBox>
									字
									<asp:DropDownList ID="JsModel4" runat="server" Height="18px" Width="90px">
									</asp:DropDownList>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<label>
										<input type="submit" name="HotCommJSButton" value=" 查看模型 " class="form" id="HotCommJSButton" />
									</label>
								</p>
								<p>
									头条信息显示：
									<asp:TextBox ID="JsNews5" runat="server" Height="16px" Width="90px" CssClass="input9" />
									条信息，标题截取
									<asp:TextBox ID="JsTitle5" runat="server" Height="16px" Width="90px" CssClass="input9"></asp:TextBox>
									字
									<asp:DropDownList ID="JsModel5" runat="server" Height="18px" Width="90px">
									</asp:DropDownList>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<label>
										<input type="submit" name="TNewsJSButton" value=" 查看模型 " class="form" id="TNewsJSButton" />
									</label>
								</p>
							</td>
						</tr>
					</table>
                    <div class="nxb_submit">
                        <input type="submit" name="Savejs" value=" 提 交 " class="xsubmit1" id="SaveJs" runat="server" onserverclick="SaveJs_ServerClick" />
                    </div>
				</div>
				<div id="div_water" style="display: none">
					<table class="nxb_table">   
                    <tr>
                                <td colspan="2" align="left">
                                    <font style="font-size:12px;">水印缩图参数设置</font>
                                </td>
                            </tr>
						<tr>
							<td width="20%" align="right">
								是否开启水印/缩图功能：
							</td>
							<td>
								<asp:RadioButton ID="WaterY" CssClass="radio" runat="server" Text="是" GroupName="PrintTF" />&nbsp;<asp:RadioButton ID="WaterN" CssClass="radio" runat="server" Text="否" GroupName="PrintTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0001',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="15%" align="right" style="width: 214px">
								水印类型：
							</td>
							<td>
								<asp:DropDownList ID="PrintPicTF" runat="server" onchange="SelectOpPic(this.value)" CssClass="select4">
									<asp:ListItem Value="99" Selected="True">请选择</asp:ListItem>
									<asp:ListItem Value="7">文字水印</asp:ListItem>
									<asp:ListItem Value="8">图片水印</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0002',this)">帮助</span>
							</td>
						</tr>
						<tr id="Waterword" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								水印文字为：
							</td>
							<td>
								<asp:TextBox ID="PrintWord" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0003',this)">帮助</span>
							</td>
						</tr>
						<tr id="Watersize" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								水印文字大小为：
							</td>
							<td>
								<asp:TextBox ID="Printfontsize" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0004',this)">帮助</span>
							</td>
						</tr>
						<tr id="Waterfont" style="display: none">
							<td align="right" style="width: 214px">
								水印字体选择：
							</td>
							<td>
								<asp:DropDownList ID="Printfontfamily" runat="server" Width="93px">
									<asp:ListItem Selected="True" Value="0">宋体</asp:ListItem>
									<asp:ListItem Value="1">黑体</asp:ListItem>
									<asp:ListItem Value="2">楷体</asp:ListItem>
									<asp:ListItem Value="3">隶书</asp:ListItem>
									<asp:ListItem Value="4">Andale Mono</asp:ListItem>
									<asp:ListItem Value="5">Arial</asp:ListItem>
									<asp:ListItem Value="6">Book Antiqua</asp:ListItem>
									<asp:ListItem Value="7">Century Gothic</asp:ListItem>
									<asp:ListItem Value="8">Comic Sans MS</asp:ListItem>
									<asp:ListItem Value="9">Courier New</asp:ListItem>
									<asp:ListItem Value="10">Georgia</asp:ListItem>
									<asp:ListItem Value="11">Impact</asp:ListItem>
									<asp:ListItem Value="12">Tahoma</asp:ListItem>
									<asp:ListItem Value="13">Times New Roman</asp:ListItem>
									<asp:ListItem Value="13">Trebuchet MS</asp:ListItem>
									<asp:ListItem Value="13">Script MT Bold</asp:ListItem>
									<asp:ListItem Value="13">Stencil</asp:ListItem>
									<asp:ListItem Value="13">Verdana</asp:ListItem>
									<asp:ListItem Value="13">Lucida Console</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0005',this)">帮助</span>
							</td>
						</tr>
						<tr id="Watercolor" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								水印文字颜色：
							</td>
							<td>
								<asp:TextBox ID="Printfontcolor" runat="server" CssClass="input9" />
								<img src="../../sysImages/FileIcon/Rect.gif" alt="-" name="MarkFontColor_Show" width="18" height="17" border="0" align="absmiddle" id="MarkFontColor_Show" style="cursor: pointer; background-color: #<%= Printfontcolor.Text%>;" title="选取颜色" onclick="GetColor(this,'Printfontcolor');"><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0006',this)">帮助</span>
							</td>
						</tr>
						<tr id="WaterB" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								水印文字是否粗体：
							</td>
							<td>
								<asp:DropDownList ID="PrintBTF" runat="server" Width="93px">
									<asp:ListItem Selected="True" Value="1">是</asp:ListItem>
									<asp:ListItem Value="0">否</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0007',this)">帮助</span>
							</td>
						</tr>
						<tr id="Waterpicurl" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								水印图片地址为：
							</td>
							<td>
								<asp:TextBox ID="PintPicURL" runat="server" CssClass="input9" />
								&nbsp;
								<label>
                                <img src="../imges/bgxiu_14.gif" alt="选择图片" border="0" style="cursor: pointer;" onclick="selectFile('PintPicURL','选择图片','pic',500,500);document.SetParam.PintPicURL.focus();" />
								</label>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0008',this)">帮助</span>
							</td>
						</tr>
						<tr id="Waterwidth" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								水印图片比例为：
							</td>
							<td>
								<asp:TextBox ID="PrintPicsize" runat="server" CssClass="input9" Text="100|100" /><span id="print_span" runat="server" style="display: none;" />
								<input type="button" onclick="document.getElementById('PrintPicsize').value='0'" value="原图大小" class="xsubmit1" />
								<span class="helpstyle" style="cursor: help;" title="例：填写0.8表示占原图比例为80%">帮助</span>
							</td>
						</tr>
						<tr id="WaterP" style="display: none">
							<td width="15%" align="right" style="width: 214px;">
								水印图片透明度为：
							</td>
							<td>
								<asp:TextBox ID="PintPictrans" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0010',this)">帮助</span>
							</td>
						</tr>
						<tr id="WaterW" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								水印位置：
							</td>
							<td>
								<asp:DropDownList ID="PrintPosition" runat="server" Width="93px" CssClass="xselect4">
									<asp:ListItem Selected="True" Value="0">居中</asp:ListItem>
									<asp:ListItem Value="1">左上</asp:ListItem>
									<asp:ListItem Value="2">左下</asp:ListItem>
									<asp:ListItem Value="3">右上</asp:ListItem>
									<asp:ListItem Value="4">右下</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0011',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="15%" align="right" style="width: 214px">
								是否开启缩图功能：
							</td>
							<td>
								<asp:DropDownList ID="PrintSmallTF" runat="server" Width="93px" onchange="SelectOpPic(this.value)" CssClass="xselect4">
									<asp:ListItem Value="9">关闭</asp:ListItem>
									<asp:ListItem Value="10">开启</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0012',this)">帮助</span>
							</td>
						</tr>
						<tr id="smallselect" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								缩图的方式选择：
							</td>
							<td>
								<asp:DropDownList ID="PrintSmallSizeStyle" runat="server" Width="93px" onchange="SelectOpPic(this.value)" CssClass="xselect4">
									<asp:ListItem Value="13">选择</asp:ListItem>
									<asp:ListItem Value="11">大小</asp:ListItem>
									<asp:ListItem Value="12">比例</asp:ListItem>
								</asp:DropDownList>
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0013',this)">帮助</span>
							</td>
						</tr>
						<tr id="width" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								高|宽：
							</td>
							<td>
								<asp:TextBox ID="PrintSmallSize" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0014',this)">帮助</span>
							</td>
						</tr>
						<tr id="inv" style="display: none">
							<td width="15%" align="right" style="width: 214px">
								比例：
							</td>
							<td>
								<asp:TextBox ID="PrintSmallinv" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_WaterParam_0015',this)">帮助</span>
							</td>
						</tr>
					</table>
                    <div class="nxb_submit">
                        <input type="submit" name="Savewater" value=" 提 交 " class="xsubmit1" id="Savewater" runat="server" onserverclick="Savewater_ServerClick" />
                        <input type="reset" name="Clearwater" value=" 重 填 " class="xsubmit1" id="Clearwater" runat="server" />
                    </div>
				</div>
				<div id="div_rssxmlwap" style="display: none">
					<table class="nxb_table">
                        <tr>
                                <td colspan="2">
                                    <font style="font-size:12px;">RSS.XML.WAP参数设置</font>
                                </td>
                            </tr>
						<tr>
							<td width="15%" align="right" style="width: 219px">
								显示最新范围：
							</td>
							<td>
								<asp:TextBox ID="RssNum" runat="server" Width="250" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0001',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="15%" align="right" style="width: 219px">
								简介截取数：
							</td>
							<td>
								<asp:TextBox ID="RssContentNum" Width="250" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0002',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="15%" align="right" style="width: 219px">
								RSS标题：
							</td>
							<td>
								<asp:TextBox ID="RssTitle" Width="250" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0003',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="15%" align="right" style="width: 219px">
								RSS图片地址：
							</td>
							<td>
								<asp:TextBox ID="RssPicURL" Width="250" runat="server" CssClass="input9" />
                                <img src="../imges/bgxiu_14.gif" alt="选择图片" border="0" style="cursor: pointer;" onclick="selectFile('RssPicURL','选择图片','pic',500,500);document.SetParam.RssPicURL.focus();" />
								 <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0004',this)">帮助</span>
							</td>
						</tr>
						<tr>
							<td width="20%" align="right">
								新闻是否添加到wap服务器中：
							</td>
							<td>
								<asp:RadioButton ID="wapy"  CssClass="radio" Width="40" runat="server" onclick="SelectOpPic3(1)" Text="是" GroupName="WapTF" />&nbsp;<asp:RadioButton ID="wapn" runat="server" onclick="SelectOpPic3(0)" Text="否" GroupName="WapTF" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0005',this)">帮助</span>
							</td>
						</tr>
						<tr id="wapdir" style="display: none">
							<td width="15%" align="right" style="width: 219px">
								Wap文件存放路径：
							</td>
							<td>
								<asp:TextBox ID="WapPath" Width="250" runat="server" CssClass="input9" />
                                <img src="../imges/bgxiu_14.gif" alt="选择路径" border="0" style="cursor: pointer;" onclick="selectFile('WapPath','选择路径','path|xml/wap',500,500);document.SetParam.WapPath.focus();" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0006',this)">帮助</span>
							</td>
						</tr>
						<tr id="lastn" style="display: none">
							<td width="15%" align="right" style="width: 219px">
								wap显示最新数：
							</td>
							<td>
								<asp:TextBox ID="WapLastNum" Width="250" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0008',this)">帮助</span>
							</td>
						</tr>
						<tr id="wapd" style="display: none">
							<td width="15%" align="right" style="width: 219px">
								Wap捆绑域名：
							</td>
							<td>
								<asp:TextBox ID="WapDomain" Width="250" runat="server" CssClass="input9" />
								<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_rssParam_0007',this)">帮助</span>
							</td>
						</tr>
					</table>
                    <div class="nxb_submit">
                    <input type="submit" name="Saverss" value=" 提 交 " class="xsubmit1" id="Saverss" runat="server" onserverclick="Saverss_ServerClick" />
                    <input type="reset" name="Clearrss" value=" 重 填 " class="xsubmit1" id="Clearrss" runat="server" />
                </div>
				</div>
                
				<div id="div_api" style="display: none" align="center">
					<table class="nxb_table">
						<tr>
							<td align="left" colspan="2" class="list_link">
								<strong><span style="color: #000033">API参数设置</span></strong>
							</td>
						</tr>
						<tr>
							<td class="list_link">
								api
							</td>
						</tr>
					</table>
				</div>
			</td>
		</tr>
	</table>
    </div>
        </div>  
    </div>
</div>
<!--    <table border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px; width: 100%;">
		<tr>
			<td align="center">
				<label id="copyright" runat="server" />
			</td>
		</tr>
	</table>-->
    </div>
	</form>
	
</body>
<script type="text/javascript">
	function ChangeDiv(ID) {
		document.getElementById('td_baseinfo').className = '';
		document.getElementById('td_user').className = '';
		document.getElementById('td_upload').className = '';
		document.getElementById('td_js').className = '';
		document.getElementById('td_water').className = '';
		document.getElementById('td_rssxmlwap').className = '';
		document.getElementById('td_api').className = '';
		document.getElementById("td_" + ID).className = 'reshow';

		document.getElementById("div_baseinfo").style.display = "none";
		document.getElementById("div_user").style.display = "none";
		document.getElementById("div_upload").style.display = "none";
		document.getElementById("div_js").style.display = "none";
		document.getElementById("div_water").style.display = "none";
		document.getElementById("div_rssxmlwap").style.display = "none";
		document.getElementById("div_api").style.display = "none";
		document.getElementById("div_" + ID).style.display = "";
	}
	//-------PicDomain-----------------------------------
	function SelectOpPic(OpType) {
		switch (parseInt(OpType)) {
			//----------水印----------    
			case 7:
				document.getElementById("Waterword").style.display = ""; //文字
				document.getElementById("Watersize").style.display = ""; //大小
				document.getElementById("Waterfont").style.display = ""; //字体
				document.getElementById("Watercolor").style.display = ""; //颜色
				document.getElementById("WaterB").style.display = ""; //粗体？

				document.getElementById("Waterpicurl").style.display = "none"; //图片地址
				document.getElementById("Waterwidth").style.display = "none"; //高宽
				document.getElementById("WaterP").style.display = "none"; //透明度
				document.getElementById("WaterW").style.display = ""; //位置	
				break;
			case 8:
				document.getElementById("Waterword").style.display = "none";
				document.getElementById("Watersize").style.display = "none";
				document.getElementById("Waterfont").style.display = "none";
				document.getElementById("Watercolor").style.display = "none";
				document.getElementById("WaterB").style.display = "none";

				document.getElementById("Waterpicurl").style.display = "";
				document.getElementById("Waterwidth").style.display = "";
				document.getElementById("WaterP").style.display = ""; //透明度
				document.getElementById("WaterW").style.display = "";
				break;
			case 99: //文字图片都不选择
				document.getElementById("Waterword").style.display = "none"; //文字
				document.getElementById("Watersize").style.display = "none"; //大小
				document.getElementById("Waterfont").style.display = "none"; //字体
				document.getElementById("Watercolor").style.display = "none"; //颜色
				document.getElementById("WaterB").style.display = "none"; //粗体？

				document.getElementById("Waterpicurl").style.display = "none"; //图片地址
				document.getElementById("Waterwidth").style.display = "none"; //高宽
				document.getElementById("WaterP").style.display = "none"; //透明度
				document.getElementById("WaterW").style.display = "none"; //位置	
				break;


			//----------缩图-------    
			case 9:
				document.getElementById("smallselect").style.display = "none"; //开启缩图？
				document.getElementById("width").style.display = "none"; //大小
				document.getElementById("inv").style.display = "none"; //比例
				document.getElementById("PrintSmallSizeStyle").style.value = "13";
				break;
			case 10:
				document.getElementById("smallselect").style.display = "";
				document.getElementById("width").style.display = ""; //大小
				document.getElementById("inv").style.display = "none"; //比例
				break;
			case 11:
				document.getElementById("width").style.display = ""; //大小
				document.getElementById("inv").style.display = "none"; //比例
				break;
			case 12:
				document.getElementById("width").style.display = "none";
				document.getElementById("inv").style.display = "";
				break;
			case 13:
				document.getElementById("width").style.display = "none";
				document.getElementById("inv").style.display = "none";
				break;
		}
	}
	function SelectOpPic0(value) {
		switch (parseInt(value)) {
			//----------图片域名--------    
			case 0:
				document.getElementById("PicDomain").style.display = "none"; //图片域名
				document.getElementById("PicDir").style.display = "none"; //图片附件目录
				break;
			case 1:
				document.getElementById("PicDomain").style.display = "";
				document.getElementById("PicDir").style.display = "";
				break;
		}
	}
	function SelectOpPic1(value) {
		switch (parseInt(value)) {
			case 0:
				document.getElementById("FarDomain").style.display = "none"; //远程图片域名
				document.getElementById("FarDir").style.display = "none"; //远程图片保存路径
				break;
			case 1:
				document.getElementById("FarDomain").style.display = "";
				document.getElementById("FarDir").style.display = "";
				break;
		}
	}
	function SelectOpPic2(value) {
		switch (parseInt(value)) {
			//----------ftp-----------    
			case 1:
				document.getElementById("Ftp").style.display = ""; //ftp设置
				break;
			case 0:
				document.getElementById("Ftp").style.display = "none";
				break;
		}
	}
	function SelectOpPic3(value) {
		switch (parseInt(value)) {
			//-------wap------------	    
			case 0:
				document.getElementById("wapdir").style.display = "none"; //wap路径
				document.getElementById("lastn").style.display = "none"; //wap最新新闻数
				document.getElementById("wapd").style.display = "none"; //wap域名
				break;
			case 1:
				document.getElementById("wapdir").style.display = "";
				document.getElementById("lastn").style.display = "";
				document.getElementById("wapd").style.display = "";
				break;
		}
	}
	function check() {
		if (document.SetParam.SiteName.value == "") {
			document.getElementById("SiteName_Span").innerHTML = "<span class=reshow>(*)请输入站点名称</span>";
			return false;
		}
		var keywordlength = /^[0-9]{0,4}\|[0-9]{0,4}$/;
		var keytest = document.SetParam.LenSearch.value;
		var setPointest = document.SetParam.setPoint.value;
		var LoginLockest = document.SetParam.LoginLock.value;
		var PrintPicsizest = document.SetParam.PrintPicsize.value;
		var meili = document.SetParam.cPointParam.value;
		var huoyue = document.SetParam.aPointparam.value;
		if (keywordlength.test(keytest) == false) {
			document.getElementById("keyLength").innerHTML = "<span class=reshow>(*)格式不正确，请参考帮助</span>";
			return false;
		}
		if (keywordlength.test(setPointest) == false) {
			document.getElementById("Point_Span").innerHTML = "<span class=reshow>(*)格式不正确，请参考帮助</span>";
			return false;
		}
		if (keywordlength.test(LoginLockest) == false) {
			document.getElementById("Login_Span").innerHTML = "<span class=reshow>(*)格式不正确，请参考帮助</span>";
			return false;
		}
		if (keywordlength.test(PrintPicsizest) == false) {
			document.getElementById("print_span").innerHTML = "<span class=reshow>(*)格式不正确，请参考帮助</span>";
			return false;
		}
		if (keywordlength.test(meili) == false) {
			document.getElementById("MeiL").innerHTML = "<span class=reshow>(*)格式不正确，请参考帮助</span>";
			return false;
		}
		if (keywordlength.test(huoyue) == false) {
			document.getElementById("Huo").innerHTML = "<span class=reshow>(*)格式不正确，请参考帮助</span>";
			return false;
		}
	}
	function clears() {
		document.SetParam.regitemContent.value = "";
	}
	function ay(obj) {
		if (obj != '') {
			if (obj.checked) {
				if (document.SetParam.regitemContent.value.search(obj.value) == -1) {
					if (document.SetParam.regitemContent.value == '')
						document.SetParam.regitemContent.value = obj.value;
					else
						document.SetParam.regitemContent.value = document.SetParam.regitemContent.value + ',' + obj.value;
				}
			} else {
				var ep = document.SetParam.regitemContent.value;
				document.SetParam.regitemContent.value = ep.replace("," + obj.value, "");
			}
		}
	}

</script>
<% isshow(); %>
</html>

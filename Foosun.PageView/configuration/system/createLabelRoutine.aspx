<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createLabelRoutine.aspx.cs" Inherits="Foosun.PageView.configuration.system.createLabelRoutine" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
	<script type="text/javascript">
	    function getColorOptions() {
	        var color = new Array("00", "33", "66", "99", "CC", "FF");
	        for (var i = 0; i < color.length; i++) {
	            for (var j = 0; j < color.length; j++) {
	                for (var k = 0; k < color.length; k++) {
	                    if (k == 0 && j == 0 && i == 0)
	                        document.write('<option style="background:#' + color[j] + color[k] + color[i] + '" value="' + color[j] + color[k] + color[i] + '" selected>　　</option>');
	                    else
	                        document.write('<option style="background:#' + color[j] + color[k] + color[i] + '" value="' + color[j] + color[k] + color[i] + '"></option>');
	                }
	            }
	        }
	    }
	</script>
</head>
<body>
<div id="dialog-message" title="提示"></div>
	<form id="ListLabel" runat="server">
     <div class="newxiu_base">
	<table class="nxb_table" id="showCSSdivtable" style="display: none;">
		<tr>
			<td align="center">
				<span id="showCSSdiv"><img src="/CSS/imges/Label/preview/ClassInfo.gif" border="0" alt="" /></span>
			</td>
		</tr>
	</table>
	<table class="nxb_table">
		<tr>
			<td align="right" style="width: 28%">
				标签类型：
			</td>
			<td width="79%" align="left">
				<select id="LabelType" name="LabelType" class="select4" onchange="selectLabelType(this.value);">
					<optgroup label="常规标签">
						<option value="">请选择标签类型</option>
						<option value="unRule">不规则新闻</option>
						<option value="Position">位置导航</option>
						<option value="PageTitle">页面标题</option>
						<option value="Search">搜索</option>
						<option value="FlashFilt">Flash幻灯片</option>
						<option value="NorFilt">轮换幻灯片</option>
						<option value="Sitemap">站点地图</option>
						<option value="TodayPic">图片头条</option>
						<option value="TodayWord">文字头条</option>
						<option value="CorrNews">相关新闻</option>
						<option value="Metakey">Meta关键字</option>
						<option value="MetaDesc">Meta描述</option>
						<option value="CopyRight">版权信息</option>
						<option value="History">归档查询</option>
						<option value="SiteNavi">总站导航</option>
						<option value="ClassNavi">栏目导航</option>
                        <option value="SClassNavi">二级栏目导航</option>
						<option value="ClassNaviRead">栏目导读</option>
						<option value="ClassInfoList">栏目列表</option>
						<option value="SpecialNavi">专题导航</option>
						<option value="SpeicalNaviRead">专题导读</option>
						<option value="RSS">RSS</option>
						<option value="TopNews">新闻排行</option>
					</optgroup>
					<optgroup label="扩展标签">
						<option value="HistoryIndex">历史首页查询</option>
					</optgroup>
				</select>
			</td>
		</tr>
		<tr style="display: none;" id="TrRoot">
			<td align="right" style="width: 28%">
				引用样式：
			</td>
			<td width="79%" align="left">
				<select id="Root" name="Root" onchange="javascript:selectRoot(this.value);" class="select4">
					<option value="true">固定样式</option>
					<option value="false">自定义样式</option>
				</select>
			</td>
		</tr>
		<tr style="display: none;" id="TrStyleID">
			<td align="right" style="width: 28%">
				引用样式：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="StyleID" runat="server" class="input9" ReadOnly="true"></asp:TextBox>
				&nbsp;<input class="xsubmit1" type="button" value="选择样式" onclick="javascript:selectFile('StyleID','栏目列表','style','400','300');document.ListLabel.StyleID.focus();" /><span id="sapnStyleID"></span>
			</td>
		</tr>
		<tr id="TrUserDefined" style="display: none;">
			<td align="right" style="width: 28%">
				<div style="margin: 5px 0 5px 0;">
					</div>
				自定义样式：
				<div style="height: 3px; margin: 2px 0 4px 0;">
				</div>
				<input name="saveStyled" value="保存样式" class="xsubmit1" type="button" onclick="ShowStyle();" />
				<div id="showOther" style="display: none;">
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<asp:TextBox ID="StyleName" Width="94px" runat="server"></asp:TextBox>
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<asp:DropDownList ID="StyleClassID" Width="100px" runat="server">
					</asp:DropDownList>
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<input name="saveStyle" id="saveStyle" value="保存" type="button" onclick="savePostStyle();" />
					<div id="sResultHTML" class="reshow">
					</div>
				</div>
			</td>
			<td width="79%" align="left">
				<div>
					<label id="style_base" runat="server" />
					<label id="style_class" runat="server" />
					<label id="style_special" runat="server" />
					<asp:DropDownList ID="define" runat="server" class="select4" onchange="javascript:setValue(this.value);">
						<asp:ListItem Value="">自定义字段</asp:ListItem>
					</asp:DropDownList>
				</div>
				<textarea rows="1" cols="1" name="UserDefined" style="display: none" id="UserDefined"></textarea>
				<script type="text/javascript">
				    var editor;
				    KindEditor.ready(function (K) {
				        editor = K.create('textarea[name="UserDefined"]', {
				            resizeType: 1,
				            allowPreviewEmoticons: false,
				            allowImageUpload: false,
				            items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
				        });
				    });
				    function insertHTMLEdit(url) {
				        var urls = url.replace('{@dirfile}', '<% Response.Write(Foosun.Config.UIConfig.dirFile); %>')
				        editor.insertHtml("<img src=\"' + urls + '\" border=\"0\" />");
				        return;
				    }
				    function ShowStyle() {
				        if (document.getElementById("showOther").style.display == "none") {
				            document.getElementById("showOther").style.display = "";
				        }
				    }
				    function savePostStyle() {
				        var saveStyle = document.getElementById("saveStyle");
				        var sname = document.getElementById("StyleName");
				        var StyleClassID = document.getElementById("StyleClassID");
				        if (sname.value == "") {
				            alert('请填写样式名称');
				            sname.focus();
				            return false;
				        }
				        if (StyleClassID.value == "") {
				            alert('请选择分类，如果没有分类，请在样式中创建');
				            return false;
				        }
				        var gtemproot = editor.html();				       
				        var actionstr = "StyleName=" + escape(sname.value) + "&ClassID=" + escape(StyleClassID.value) + "&Content=" + escape(gtemproot) + "";
				        $.ajax({
				            type: "POST",
				            url: "SaveStyle.aspx",
				            async: false,
				            //是否ajax同步       
				            data: actionstr,
				            success: function (data) {
				                $('#sResultHTML').html(data);
				            }
				        });
				    }
				</script>
			</td>
		</tr>
		<tr style="display: none;" id="TrNumber">
			<td align="right" style="width: 28%">
				循环条数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="Number" runat="server" class="input8"></asp:TextBox>
				<span id="spanNumber"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrFlashType">
			<td align="right" style="width: 28%">
				显示样式：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="FlashType" runat="server" class="select5" onchange="javascript:flashType(this.value);">
					<asp:ListItem Value="default">默认样式</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrClassShow">
			<td align="right" style="width: 28%">
				是否显示栏目名称：
			</td>
			<td width="79%" align="left">
				<asp:CheckBox ID="ClassShow" runat="server"  class="checkbox2"/>
			</td>
		</tr>
		<tr style="display: none;" id="TRMetaContent">
			<td align="right" style="width: 28%">
				Meta附件内容：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="MetaContent" MaxLength="100" class="input8" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr style="display: none;" id="TrClassCSS">
			<td align="right" style="width: 28%">
				栏目CSS：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="ClassCSS" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr style="display: none;" id="TrMainNewsShow">
			<td align="right" style="width: 28%">
				是否显示主新闻：
			</td>
			<td width="79%" align="left">
				<asp:CheckBox ID="MainNewsShow" runat="server"  class="checkbox2"/>
			</td>
		</tr>
		<tr style="display: none;" id="TrunRuleType">
			<td align="right" style="width: 28%">
				显示条件：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="unRuleType" runat="server" class="select5">
					<asp:ListItem Value="normal">普通新闻</asp:ListItem>
					<asp:ListItem Value="rec">推荐新闻</asp:ListItem>
					<asp:ListItem Value="tt">头条新闻</asp:ListItem>
					<asp:ListItem Value="files">有附件</asp:ListItem>
					<asp:ListItem Value="vote">有投票</asp:ListItem>
					<asp:ListItem Value="picin">有画中画</asp:ListItem>
					<asp:ListItem Value="pop">权限新闻</asp:ListItem>
					<asp:ListItem Value="filt">幻灯</asp:ListItem>
					<asp:ListItem Value="pic">图片新闻</asp:ListItem>
					<asp:ListItem Value="hit">点击最高</asp:ListItem>
					<asp:ListItem Value="comm">评论最多</asp:ListItem>
					<asp:ListItem Value="marquee">滚动新闻</asp:ListItem>
					<asp:ListItem Value="announce">公告新闻</asp:ListItem>
					<asp:ListItem Value="jc">精彩新闻</asp:ListItem>
					<asp:ListItem Value="constr">投稿新闻</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrSubNews">
			<td align="right" style="width: 28%">
				调用子(副)新闻：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="SubNews" runat="server" class="select5">
					<asp:ListItem Value="">是否调用</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrClassId" style="display: none;">
			<td align="right" style="width: 28%">
				栏目ID：
			</td>
			<td align="left">
				<asp:TextBox ReadOnly="true" ID="ClassName" runat="server"  class="input9"></asp:TextBox>
				&nbsp;<input id="ClassId" type="hidden" />
				<img src="/CSS/imges/bgxiu_14.gif" align="middle" style="cursor: pointer;" title="选择栏目" alt="" onclick="javascript:selectFile('ClassName,ClassId','栏目列表','newsclass','400','300');document.ListLabel.SpecialName.focus();" id="IMG1" /> 调用类型：<a id="btnClassIdTypeAll" href="javascript:void(0);" onclick="getType(-1);" class="reshow">所有</a>&nbsp;&nbsp;<a href="javascript:void(0);" onclick="getType(0);" class="reshow">自适应</a>&nbsp;&nbsp;<a href="javascript:void(0);" id="btnClassIdTypeLevel" onclick="getType(1);" class="reshow">本级栏目</a><br />
				<span id="spanClassId"></span>
			</td>
		</tr>
		<tr id="TrSpecialID" style="display: none;">
			<td align="right" style="width: 28%">
				专题栏目：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="SpecialName" runat="server" class="input9" ReadOnly="true"></asp:TextBox><input id="SpecialID" type="hidden" />
				&nbsp;			
				<img alt="" src="/CSS/imges/bgxiu_14.gif" style="cursor: pointer;" title="选择专题" onclick="javascript:selectFile('SpecialName,SpecialID','专题信息','special','400','300');document.ListLabel.SpecialName.focus();" /> 调用类型：<a href="javascript:void(0);" onclick="getTypeS(-1);" class="reshow">所有</a>&nbsp;&nbsp;<a href="javascript:void(0);" onclick="getTypeS(0);" class="reshow">自适应</a><br />
				<span style="color: Blue;">说明：如果填写为0或者为空，调用标签所在专题的符合条件新闻,如果不在专题，则调用所有。如果为-1，则调用所有的符合条件新闻。</span>
			</td>
		</tr>
		<tr style="display: none;" id="TrBigT">
			<td align="right" style="width: 28%">
				第一行设置大标题：
			</td>
			<td width="79%" align="left">
				<asp:CheckBox ID="isBIGT" runat="server" onclick="getBigTitle();"  class="checkbox2"/>
				<span id="showBigS" style="display: none;">大标题显示字数
					<asp:TextBox ID="bigTitleNumber" Text="20" runat="server"></asp:TextBox></span>
				<script type="text/javascript">
				    function getBigTitle() {
				        if (document.getElementById("isBIGT").checked) {
				            document.getElementById("showBigS").style.display = "";
				        }
				        else {
				            document.getElementById("showBigS").style.display = "none";
				        }
				    }
				</script>
			</td>
		</tr>
		<tr style="display: none;" id="TrBigCSS">
			<td align="right" style="width: 28%">
				大标题CSS：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="BIGCSS" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr style="display: none;" id="TrCols">
			<td align="right" style="width: 28%">
				每行显示多少条：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="Cols" runat="server" class="input8"></asp:TextBox><span id="spanCols"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrDescType">
			<td align="right" style="width: 28%">
				排序方式：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="DescType" runat="server" class="select5">
					<asp:ListItem Value="">请选择排序方式</asp:ListItem>
					<asp:ListItem Value="id">自动编号</asp:ListItem>
					<asp:ListItem Value="date">添加日期</asp:ListItem>
					<asp:ListItem Value="click">点击次数</asp:ListItem>
					<asp:ListItem Value="pop">权重</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrClassDescType">
			<td align="right" style="width: 28%">
				排序方式：
			</td>
			<td width="79%" align="left">
				<select id="ClassDescType" name="ClassDescType" class="select5">
					<option value="">请选择排序方式</option>
					<option value="id">自动编号</option>
					<option value="CreatTime">添加日期</option>
					<option value="OrderID">权重</option>
				</select>
			</td>
		</tr>
		<tr style="display: none;" id="TrDesc">
			<td align="right" style="width: 28%">
				排序规则：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="Desc" runat="server" class="select5">
					<asp:ListItem Value="">请选择排序顺序</asp:ListItem>
					<asp:ListItem Value="desc">desc(降序)</asp:ListItem>
					<asp:ListItem Value="asc">asc(升序)</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrisDiv">
			<td align="right" style="width: 28%">
				输出格式：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="isDiv" runat="server" class="select5" onchange="javascript:selectisDiv(this.value);">
					<asp:ListItem Value="">请选择输出格式</asp:ListItem>
					<asp:ListItem Value="false">Table</asp:ListItem>
					<asp:ListItem Value="true">Div</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrulID" style="display: none;">
			<td align="right" style="width: 28%">
				DIV的ul属性ID：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="ulID" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrulClass" style="display: none;">
			<td align="right" style="width: 28%">
				DIV的ul属性Class：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="ulClass" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="div_daohang" style="display: none;">
			<td align="right" style="width: 28%">
				CSS：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="daohangCSS" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="div_daohangfg" style="display: none;">
			<td align="right" style="width: 28%">
				分割符：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="daohangfg" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr style="display: none;" id="TrisPic">
			<td align="right" style="width: 28%">
				调用图片：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="isPic" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否调用</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrShowNavi">
			<td align="right" style="width: 28%">
				在标题前加导航：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="ShowNavi" runat="server" class="select5" onchange="javascript:selectShowNavi(this.value);">
					<asp:ListItem Value="">请选择是否加导航</asp:ListItem>
					<asp:ListItem Value="1">数字导航(1,2,3...)</asp:ListItem>
					<asp:ListItem Value="2">字母导航(A,B,C...)</asp:ListItem>
					<asp:ListItem Value="3">字母导航(a,b,c...)</asp:ListItem>
					<asp:ListItem Value="4">自定义图片</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrShowNaviPic" style="display: none;">
			<td align="right" style="width: 28%">
				导航图片地址：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="NaviPic" runat="server" Width="120px" ReadOnly="true"></asp:TextBox>
				&nbsp;
				<input class="form" type="button" value="选择图片" onclick="javascript:selectFile('NaviPic','图片','pic','500','300');document.ListLabel.NaviPic.focus();" />
			</td>
		</tr>
		<tr id="TrShowTitle" style="display: none;">
			<td align="right" style="width: 28%">
				是否显示标题：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="ShowTitle" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否显示</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrTitleNumer">
			<td align="right" style="width: 28%">
				标题显示字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="TitleNumer" runat="server" class="input8"></asp:TextBox><span id="spanTitleNumer"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrFlashSize">
			<td align="right" style="width: 28%">
				图片高宽：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="FlashSize" runat="server" class="input8"></asp:TextBox>格式：宽|高
			</td>
		</tr>
		<tr style="display: none;" id="TrTarget">
			<td align="right" style="width: 28%">
				打开方式：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="Target" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否调用</asp:ListItem>
					<asp:ListItem Value="_blank">新开</asp:ListItem>
					<asp:ListItem Value="_self">本页</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrWNum">
			<td align="right" style="width: 28%">
				调用数量：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="WNum" runat="server" class="input8"></asp:TextBox><span id="span1"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrWCSS">
			<td align="right" style="width: 28%">
				CSS：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="WCSS" runat="server" class="input8"></asp:TextBox><span id="span2"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrContentNumber">
			<td align="right" style="width: 28%">
				内容截取字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="ContentNumber" runat="server" class="input8"></asp:TextBox><span id="spanContentNumber"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrNaviNumber">
			<td align="right" style="width: 28%">
				导航截取字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="NaviNumber" runat="server" class="input8"></asp:TextBox><span id="spanNaviNumber"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrShowDateNumer">
			<td align="right" style="width: 28%">
				显示多少天内的信息：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="ShowDateNumer" runat="server" class="input8"></asp:TextBox><span id="spanShowDateNumer"></span>
			</td>
		</tr>
		<tr style="display: none;" id="TrisSub">
			<td align="right" style="width: 28%">
				是否调用子类：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="isSub" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否调用</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr style="display: none;" id="TrSTitle">
			<td align="right" style="width: 28%">
				显示不规则新闻标题：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="STitle" runat="server" class="select5">
					<asp:ListItem Value="">显示不规则新闻标题</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrunNavi" style="display: none;">
			<td align="right" style="width: 28%">
				导航文字或图片：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="unNavi" runat="server" class="input8" Text=""></asp:TextBox>
				<img src="/CSS/imges/bgxiu_14.gif" align="middle" style="cursor: pointer;" title="选择图片" alt="" onclick="javascript:selectFile('unNavi','图片','pic','500','300');document.ListLabel.unNavi.focus();" />
				<br />
				如果为图片，请直接输入图片地址。
			</td>
		</tr>
		<tr style="display: none;" id="TrRuleID">
			<td align="right" style="width: 28%">
				不规则新闻ID：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="RuleID" runat="server" class="select5">
				</asp:DropDownList>
				<span id="spansubRuleID"></span>
			</td>
		</tr>
		<tr id="TrPositionValue" style="display: none;">
			<td align="right" style="width: 28%">
				位置导航：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="PositionValue" runat="server" class="input8" Text="[FS:unLoop,FS:SiteID=0,FS:LabelType=Position][/FS:unLoop]" ReadOnly="true"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrSearchType" style="display: none;">
			<td align="right" style="width: 28%">
				搜索类型：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="SearchType" runat="server" class="select5" onchange="javascript:showdateclass(this.value);">
					<asp:ListItem Value="">请选择搜索类型</asp:ListItem>
					<asp:ListItem Value="true">高级搜索</asp:ListItem>
					<asp:ListItem Value="false">一般搜索</asp:ListItem>
				</asp:DropDownList>
				<span id="sapnSearchType"></span>
			</td>
		</tr>
		<tr id="TrShowDate" style="display: none;">
			<td align="right" style="width: 28%">
				日期搜索：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="ShowDate" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否显示</asp:ListItem>
					<asp:ListItem Value="true">显示</asp:ListItem>
					<asp:ListItem Value="false">不显示</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrShowClass" style="display: none;">
			<td align="right" style="width: 28%">
				显示栏目：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="ShowClass" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否显示</asp:ListItem>
					<asp:ListItem Value="true">显示</asp:ListItem>
					<asp:ListItem Value="false">不显示</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrShowUser" style="display: none;">
			<td align="right" style="width: 28%">
				是否统计用户信息：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="ShowUser" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否统计</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrShowNews" style="display: none;">
			<td align="right" style="width: 28%">
				是否统计新闻数量：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="ShowNews" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否统计</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrStatShowClass" style="display: none;">
			<td align="right" style="width: 28%">
				是否统计栏目数量：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="StatShowClass" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否统计</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrShowAPI" style="display: none;">
			<td align="right" style="width: 28%">
				是否显示API统计信息：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="ShowAPI" runat="server" class="select5">
					<asp:ListItem Value="">请选择是否显示</asp:ListItem>
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrFlashweight" style="display: none;">
			<td align="right" style="width: 28%">
				Flash宽度：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="Flashweight" runat="server" class="input8"></asp:TextBox><span id="spanFlashweight"></span>
			</td>
		</tr>
		<tr id="TrFlashheight" style="display: none;">
			<td align="right" style="width: 28%">
				Flash高度：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="Flashheight" runat="server" class="input8"></asp:TextBox><span id="spanFlashheight"></span>
			</td>
		</tr>
		<tr id="TrFlashBG" style="display: none;">
			<td align="right" style="width: 28%">
				FLASH背景颜色：
			</td>
			<td width="79%" align="left">
				<select name="FlashBG" id="FlashBG" class="select5">
					<script type="text/javascript">					    getColorOptions();</script>
				</select>
			</td>
		</tr>
		<tr id="TrFlashTitleNumber" style="display: none;">
			<td align="right" style="width: 28%">
				标题字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox name="FlashTitleNumber" ID="FlashTitleNumber" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrTXTheight" style="display: none;">
			<td align="right" style="width: 28%">
				文本高度：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="TXTheight" runat="server" class="input8"></asp:TextBox><span id="spanTXTheight"></span>
			</td>
		</tr>
		<tr id="TrisSubCols" style="display: none;">
			<td align="right" style="width: 28%">
				子类每行显示数量：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="isSubCols" runat="server" class="input8"></asp:TextBox><span id="spanisSubCols"></span>
			</td>
		</tr>
		<tr id="TrMapTitleCSS" style="display: none;">
			<td align="right" style="width: 28%">
				主类CSS：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="MapTitleCSS" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrSubCSS" style="display: none;">
			<td align="right" style="width: 28%">
				子类CSS：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="SubCSS" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrMapp" style="display: none;">
			<td align="right" style="width: 28%">
				显示方式：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="Mapp" runat="server" class="select5">
					<asp:ListItem Value="">请选择显示方式</asp:ListItem>
					<asp:ListItem Value="true" Selected="true">横排</asp:ListItem>
					<asp:ListItem Value="false">竖排</asp:ListItem>
				</asp:DropDownList>
				栏目导航，这项不起作用，请在前台模板CSS中控制li的属性控制横向还是竖向
			</td>
		</tr>
		<tr id="TrMapNavi" style="display: none;">
			<td align="right" style="width: 28%">
				标题导航：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="MapNavi" runat="server" class="select5" onchange="javascript:selectMapNavi(this.value);">
					<asp:ListItem Value="">请选择标题导航</asp:ListItem>
					<asp:ListItem Value="true">文字</asp:ListItem>
					<asp:ListItem Value="false">图片</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrMapNaviText" style="display: none;">
			<td align="right" style="width: 28%">
				导航文本：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="MapNaviText" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrNaviPic" style="display: none;">
			<td align="right" style="width: 28%">
				导航图片地址：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="MapNaviPic" runat="server" class="input9" ReadOnly="true"></asp:TextBox>
				&nbsp;
				<input class="form" type="button" value="选择图片" onclick="javascript:selectFile('MapNaviPic','图片','pic','500','300');;document.ListLabel.MapNaviPic.focus();" />
			</td>
		</tr>
		<tr id="TrMapsubNavi" style="display: none;">
			<td align="right" style="width: 28%">
				子类导航：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="MapsubNavi" runat="server" class="select5" onchange="javascript:selectMapsubNavi(this.value);">
					<asp:ListItem Value="">请选择子类导航</asp:ListItem>
					<asp:ListItem Value="true">文字</asp:ListItem>
					<asp:ListItem Value="false">图片</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrMapsubNaviText" style="display: none;">
			<td align="right" style="width: 28%">
				导航文本：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="MapsubNaviText" runat="server" class="input8"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrMapsubNaviPic" style="display: none;">
			<td align="right" style="width: 28%">
				导航图片地址：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="MapsubNaviPic" runat="server" class="input9" ReadOnly="true"></asp:TextBox>
				&nbsp;
				<input class="form" type="button" value="选择图片" onclick="javascript:selectFile('MapsubNaviPic','图片','pic','500','300');;document.ListLabel.MapsubNaviPic.focus();" />
			</td>
		</tr>
		<tr id="TrIsDate" style="display: none;">
			<td align="right" style="width: 28%">
				是否日期索引查询：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="IsDate" runat="server" class="select5" onchange="javascript:IndexOrDate(this.value);">
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false">否</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrHistoryShowDate" style="display: none;">
			<td align="right" style="width: 28%">
				是否显示日期：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="HistoryShowDate" runat="server" class="select5" onchange="javascript:IndexOrDate1(this.value);">
					<asp:ListItem Value="true">是</asp:ListItem>
					<asp:ListItem Value="false" Selected="True">否</asp:ListItem>
				</asp:DropDownList>
				日期索引查询为"否"，此项才有效
			</td>
		</tr>
		<tr id="TrClassTitleNumber" style="display: none;">
			<td align="right" style="width: 28%">
				栏目名字显示字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="ClassTitleNumber" runat="server" class="input8"></asp:TextBox><span id="spanClassTitleNumber"></span>
			</td>
		</tr>
		<tr id="TrClassNaviTitleNumber" style="display: none;">
			<td align="right" style="width: 28%">
				栏目导读字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="ClassNaviTitleNumber" runat="server" class="input8"></asp:TextBox><span id="spanClassNaviTitleNumber"></span>
			</td>
		</tr>
		<tr id="TrSpecialTitleNumber" style="display: none;">
			<td align="right" style="width: 28%">
				专题名称显示字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="SpecialTitleNumber" runat="server" class="input8"></asp:TextBox><span id="spanSpecialTitleNumber"></span>
			</td>
		</tr>
		<tr id="TrSpecialNaviTitleNumber" style="display: none;">
			<td align="right" style="width: 28%">
				专题导读字数：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="SpecialNaviTitleNumber" runat="server" class="input8"></asp:TextBox><span id="spanSpecialNaviTitleNumber"></span>
			</td>
		</tr>
		<tr id="TrTopNewsTyper" style="display: none;">
			<td align="right" style="width: 28%">
				排行类型：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="TopNewsType" runat="server" class="select5">
					<asp:ListItem Value="">请选择排行类型</asp:ListItem>
					<asp:ListItem Value="Hour">24小时排行</asp:ListItem>
					<asp:ListItem Value="YesDay">昨日排行</asp:ListItem>
					<asp:ListItem Value="Week">周排行</asp:ListItem>
					<asp:ListItem Value="Month">月排行</asp:ListItem>
					<asp:ListItem Value="Comm">评论排行</asp:ListItem>
					<asp:ListItem Value="disc">讨论组</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrTopCommType" style="display: none;">
			<td align="right" style="width: 28%">
				排行类型：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="TopCommType" runat="server" class="select5">
					<asp:ListItem Value="">请选择排行类型</asp:ListItem>
					<asp:ListItem Value="Hour">24小时排行</asp:ListItem>
					<asp:ListItem Value="YesDay">昨日排行</asp:ListItem>
					<asp:ListItem Value="Week">周排行</asp:ListItem>
					<asp:ListItem Value="Month">月排行</asp:ListItem>
					<asp:ListItem Value="Comm">评论排行</asp:ListItem>
					<asp:ListItem Value="disc">讨论组</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrTodayPicID" style="display: none;">
			<td align="right" style="width: 28%">
				选择图片头条：
			</td>
			<td width="79%" align="left">
              <div class="textdiv1">
				<asp:DropDownList ID="TodayPicID" runat="server" class="select5">
				</asp:DropDownList>
				<span id="spanTodayPicID"></span>
				<br />
				<asp:CheckBox ID="TCHECK" Text="选择图片头条的副新闻" runat="server" class="checkbox2" />
				<div id="todayIDdiv">
					调用数量<asp:TextBox ID="TNUM" runat="server" class="input1"></asp:TextBox>
					<br />
				</div>
               </div>
			</td>
		</tr>
		<tr id="TrChar" style="display: none;">
			<td align="right" style="width: 28%">
				每条新闻的开始字符：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="TSCHAR" runat="server" class="input1"></asp:TextBox>结束字符：<asp:TextBox ID="TECHAR" runat="server" class="input1"></asp:TextBox>
			</td>
		</tr>
		<tr id="Trprefix" style="display: none;">
			<td align="right" style="width: 28%">
				选择前后缀类型：
			</td>
			<td width="79%" align="left">
				<asp:DropDownList ID="prefix" runat="server" class="select4">
					<asp:ListItem Value="0">前缀</asp:ListItem>
					<asp:ListItem Value="1">后缀</asp:ListItem>
				</asp:DropDownList>
				前后缀字符<asp:TextBox ID="prefixchar" runat="server" class="input9"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrDynChar" style="display: none;">
			<td align="right" style="width: 28%">
				动态调用分割号：
			</td>
			<td width="79%" align="left">
				<asp:TextBox ID="DynChar" runat="server" class="input9" Text=""></asp:TextBox>
				如果是静态调用，此项不起作用
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 28%">
			</td>
			<td width="79%" align="left">
				&nbsp;<input class="insubt3" type="button" value=" 确 定 " onclick="javascript:ReturnDivValue();" id="Button1" />&nbsp;<input class="insubt3" type="button" value=" 关 闭 " onclick="javascript:CloseDiv();" />
			</td>
		</tr>
	</table>
	<div id="showType">
	</div>
    </div>
	</form>
</body>
</html>
<script type="text/javascript">
    function AsciiToUnicode(char) {
        var result = '';
        for (var i = 0; i < char.length; i++)
            result += '&#' + char.charCodeAt(i) + ';';
        return result;
    }
    function UnicodeToAscii(codes) {
        var code = codes.match(/&#(\d+);/g);
        if (code == null) {
            return '';
        }
        var result = '';
        for (var i = 0; i < code.length; i++)
            result += String.fromCharCode(code[i].replace(/[&#;]/g, ''));
        return result;
    }

    function CloseDiv() {
        parent.parent.$('#dialog-message').dialog("close");
    }
    function selectisDiv(type) {
        if (type == "true") {
            document.getElementById("TrulID").style.display = "none";
            document.getElementById("TrulClass").style.display = "none";
        }
        else {
            document.getElementById("TrulID").style.display = "none";
            document.getElementById("TrulClass").style.display = "none";
        }
    }
    function selectShowNavi(type) {
        if (type == "4") {
            document.getElementById("TrShowNaviPic").style.display = "";
        }
        else {
            document.getElementById("TrShowNaviPic").style.display = "none";
        }
    }
    function selectRoot(type) {
        if (type == "true") {
            document.getElementById("TrStyleID").style.display = "";
            document.getElementById("TrUserDefined").style.display = "none";
        }
        else {
            document.getElementById("TrStyleID").style.display = "none";
            document.getElementById("TrUserDefined").style.display = "";
        }
    }
    function selectShowTitle(type) {
        if (type == "true") {
            document.getElementById("TrTXTheight").style.display = "";
        }
        else {
            document.getElementById("TrTXTheight").style.display = "none";
        }
    }
    function selectMapsubNavi(type) {
        document.getElementById("TrMapsubNaviText").style.display = "none";
        document.getElementById("TrMapsubNaviPic").style.display = "none";
        switch (type) {
            case "true":
                document.getElementById("TrMapsubNaviText").style.display = "";
                break;
            case "false":
                document.getElementById("TrMapsubNaviPic").style.display = "";
                break;
            case "":
                break;
        }
    }
    function selectMapNavi(type) {
        document.getElementById("TrMapNaviText").style.display = "none";
        document.getElementById("TrNaviPic").style.display = "none";
        switch (type) {
            case "true":
                document.getElementById("TrMapNaviText").style.display = "";
                break;
            case "false":
                document.getElementById("TrNaviPic").style.display = "";
                break;
            case "":
                break;
        }
    }
    function showdateclass(type) {
        switch (type) {
            case "true":
                document.getElementById("TrShowDate").style.display = "";
                document.getElementById("TrShowClass").style.display = "";
                break;
            case "false":
                document.getElementById("TrShowDate").style.display = "none";
                document.getElementById("TrShowClass").style.display = "none";
                break;
            case "":
                document.getElementById("TrShowDate").style.display = "none";
                document.getElementById("TrShowClass").style.display = "none";
                break;
        }
    }
    function IndexOrDate(type) {
        if (type == "true")
            document.ListLabel.HistoryShowDate.value = "false";
        else
            document.ListLabel.HistoryShowDate.value = "true";
    }
    function IndexOrDate1(type) {
        if (type == "true")
            document.ListLabel.IsDate.value = "false";
        else
            document.ListLabel.IsDate.value = "true";
    }

    function ReturnDivValue() {
        spanClear();
        var CheckStr = true;
        var temproot = "";
        var rvalue = "";
        switch (document.ListLabel.LabelType.value) {
            case "unRule":
                if (checkIsNull(document.ListLabel.RuleID, document.getElementById("spansubRuleID"), "请选择不规则新闻"))
                    CheckStr = false;
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=unRule";
                rvalue += ",FS:RuleID=" + document.ListLabel.RuleID.value;
                if (document.ListLabel.STitle.value != "") { rvalue += ",FS:STitle=" + document.ListLabel.STitle.value; }
                if (document.ListLabel.unNavi.value != "") { rvalue += ",FS:unNavi=" + document.ListLabel.unNavi.value; }
                rvalue += "][/FS:unLoop]";
                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "Position":
                if (document.ListLabel.DynChar.value != "") {
                    rvalue += "[FS:unLoop,FS:SiteID=0,FS:LabelType=Position,FS:DynChar=" + document.ListLabel.DynChar.value + "][/FS:unLoop]";
                }
                else {
                    rvalue = document.ListLabel.PositionValue.value;
                }
               parent.parent.getValue(rvalue);
                break;
            case "PageTitle":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=PageTitle";
                rvalue += ",FS:prefix=" + document.ListLabel.prefix.value + "$" + document.ListLabel.prefixchar.value;
                rvalue += "][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "Search":
                if (checkIsNull(document.ListLabel.SearchType, document.getElementById("sapnSearchType"), "请选择搜索类型"))
                    CheckStr = false;
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=Search";
                if (document.ListLabel.SearchType.value != "") { rvalue += ",FS:SearchType=" + document.ListLabel.SearchType.value; }
                if (document.ListLabel.ShowDate.value != "") { rvalue += ",FS:ShowDate=" + document.ListLabel.ShowDate.value; }
                if (document.ListLabel.ShowClass.value != "") { rvalue += ",FS:ShowClass=" + document.ListLabel.ShowClass.value; }
                rvalue += "][/FS:unLoop]";
                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "Stat":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=Stat";
                if (document.ListLabel.ShowUser.value != "") { rvalue += ",FS:ShowUser=" + document.ListLabel.ShowUser.value; }
                if (document.ListLabel.ShowNews.value != "") { rvalue += ",FS:ShowNews=" + document.ListLabel.ShowNews.value; }
                if (document.ListLabel.StatShowClass.value != "") { rvalue += ",FS:ShowClass=" + document.ListLabel.StatShowClass.value; }
                if (document.ListLabel.ShowAPI.value != "") { rvalue += ",FS:ShowAPI=" + document.ListLabel.ShowAPI.value; }
                rvalue += "][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "FlashFilt":
                if (parseInt(document.ListLabel.Number.value) > 6 || parseInt(document.ListLabel.Number.value) < 1) {
                    document.getElementById("spanNumber").innerText = "请输入1-6的数字";
                    CheckStr = false;
                }
                if (checkIsNull(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目不能为空"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Flashweight, document.getElementById("spanFlashweight"), "宽度只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Flashheight, document.getElementById("spanFlashheight"), "高度只能为正整数"))
                    CheckStr = false;
                if (document.ListLabel.ShowTitle.value == "true") {
                    if (checkIsNumber(document.ListLabel.TXTheight, document.getElementById("spanTXTheight"), "文本高度只能为正整数"))
                        CheckStr = false;
                }
                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=FlashFilt";
                rvalue += ",FS:FlashType=" + document.ListLabel.FlashType.value; ;
                if (document.ListLabel.Number.value != "") { rvalue += ",FS:Number=" + document.ListLabel.Number.value; }
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.Flashweight.value != "") { rvalue += ",FS:Flashweight=" + document.ListLabel.Flashweight.value; }
                if (document.ListLabel.Flashheight.value != "") { rvalue += ",FS:Flashheight=" + document.ListLabel.Flashheight.value; }
                if (document.ListLabel.FlashBG.value != "") { rvalue += ",FS:FlashBG=" + document.ListLabel.FlashBG.value; }
                if (document.ListLabel.FlashTitleNumber.value != "") { rvalue += ",FS:TitleNumber=" + document.ListLabel.FlashTitleNumber.value; }
                if (document.ListLabel.ShowTitle.value != "") { rvalue += ",FS:ShowTitle=" + document.ListLabel.ShowTitle.value; }
                if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
                if (document.ListLabel.Target.value != "") { rvalue += ",FS:Target=" + document.ListLabel.Target.value; }
                if (document.ListLabel.ShowTitle.value == "true")
                { if (document.ListLabel.TXTheight.value != "") { rvalue += ",FS:TXTheight=" + document.ListLabel.TXTheight.value; } }
                rvalue += "][/FS:Loop]";

                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "NorFilt":
                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=NorFilt";
                if (document.ListLabel.WNum.value != "") { rvalue += ",FS:Number=" + document.ListLabel.WNum.value; }
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
                if (document.ListLabel.Cols.value != "") { rvalue += ",FS:Cols=" + document.ListLabel.Cols.value; }
                if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
                if (document.ListLabel.ContentNumber.value != "") { rvalue += ",FS:ContentNumber=" + document.ListLabel.ContentNumber.value; }
                if (document.ListLabel.WCSS.value != "") { rvalue += ",FS:WCSS=" + document.ListLabel.WCSS.value; }
                if (document.ListLabel.ShowTitle.value != "") { rvalue += ",FS:ShowTitle=" + document.ListLabel.ShowTitle.value; }
                if (document.ListLabel.FlashSize.value != "") { rvalue += ",FS:FlashSize=" + document.ListLabel.FlashSize.value; }
                if (document.ListLabel.Target.value != "") { rvalue += ",FS:Target=" + document.ListLabel.Target.value; }
                rvalue += "][/FS:Loop]";
               parent.parent.getValue(rvalue);
                break;
            case "Sitemap":
                if (checkIsNumber(document.ListLabel.isSubCols, document.getElementById("spanisSubCols"), "显示数量只能为正整数"))
                    CheckStr = false;
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=Sitemap";
                if (document.ListLabel.isSubCols.value != "") { rvalue += ",FS:isSubCols=" + document.ListLabel.isSubCols.value; }
                if (document.ListLabel.MapTitleCSS.value != "") { rvalue += ",FS:MapTitleCSS=" + document.ListLabel.MapTitleCSS.value; }
                if (document.ListLabel.SubCSS.value != "") { rvalue += ",FS:SubCSS=" + document.ListLabel.SubCSS.value; }
                if (document.ListLabel.Mapp.value != "") { rvalue += ",FS:Mapp=" + document.ListLabel.Mapp.value; }
                if (document.ListLabel.MapNavi.value != "") { rvalue += ",FS:MapNavi=" + document.ListLabel.MapNavi.value; }
                if (document.ListLabel.MapNavi.value == "true")
                { if (document.ListLabel.MapNaviText.value != "") { rvalue += ",FS:MapNaviText=" + document.ListLabel.MapNaviText.value; } }
                else
                { if (document.ListLabel.MapNaviPic.value != "") { rvalue += ",FS:MapNaviPic=" + document.ListLabel.MapNaviPic.value; } }
                if (document.ListLabel.MapsubNavi.value != "") { rvalue += ",FS:MapsubNavi=" + document.ListLabel.MapsubNavi.value; }
                if (document.ListLabel.MapsubNavi.value == "true")
                { if (document.ListLabel.MapsubNaviText.value != "") { rvalue += ",FS:MapsubNaviText=" + document.ListLabel.MapsubNaviText.value; } }
                else
                { if (document.ListLabel.MapsubNaviPic.value != "") { rvalue += ",FS:MapsubNaviPic=" + document.ListLabel.MapsubNaviPic.value; } }
                rvalue += "][/FS:unLoop]";

                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "TodayPic":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=TodayPic";
                if (document.getElementById("TCHECK").checked) {
                    rvalue += ",FS:TODAYPICID=" + document.ListLabel.TodayPicID.value + ",FS:TCHECK=true";
                    if (document.ListLabel.TNUM.value != "") { rvalue += ",FS:TNUM=" + document.ListLabel.TNUM.value; }
                    if (document.ListLabel.TSCHAR.value != "") { rvalue += ",FS:TSCHAR=" + AsciiToUnicode(document.ListLabel.TSCHAR.value); }
                    if (document.ListLabel.TECHAR.value != "") { rvalue += ",FS:TECHAR=" + AsciiToUnicode(document.ListLabel.TECHAR.value); }
                }
                rvalue += "][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "TodayWord":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=TodayWord";
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.getElementById("isBIGT").checked) {
                    rvalue += ",FS:isBIGT=true";
                    rvalue += ",FS:BigCSS=" + document.ListLabel.BIGCSS.value;
                    rvalue += ",FS:bigTitleNumber=" + document.ListLabel.bigTitleNumber.value;
                }
                else {
                    rvalue += ",FS:isBIGT=false";
                }
                var vTSCHAR = AsciiToUnicode(document.ListLabel.TSCHAR.value);
                var vTECHAR = AsciiToUnicode(document.ListLabel.TECHAR.value);
                if (document.ListLabel.TSCHAR.value != "") { rvalue += ",FS:TSCHAR=" + vTSCHAR; }
                if (document.ListLabel.TECHAR.value != "") { rvalue += ",FS:TECHAR=" + vTECHAR; }
                if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
                if (document.ListLabel.Cols.value != "") { rvalue += ",FS:Cols=" + document.ListLabel.Cols.value; }
                if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
                //if(document.ListLabel.ContentNumber.value!=""){ rvalue += ",FS:ContentNumber=" + document.ListLabel.ContentNumber.value; }
                if (document.ListLabel.WNum.value != "") { rvalue += ",FS:WNum=" + document.ListLabel.WNum.value; }
                if (document.ListLabel.WCSS.value != "") { rvalue += ",FS:WCSS=" + document.ListLabel.WCSS.value; }
                rvalue += "][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "CorrNews":
                if (checkIsNull(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目不能为空"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Cols, document.getElementById("spanCols"), "每行显示条数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.ShowDateNumer, document.getElementById("spanShowDateNumer"), "显示多少天天数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.TitleNumer, document.getElementById("spanTitleNumer"), "标题显示字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.ContentNumber, document.getElementById("spanContentNumber"), "内容截取字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.NaviNumber, document.getElementById("spanNaviNumber"), "导航截取字数只能为正整数"))
                    CheckStr = false;
                if (document.ListLabel.Root.value == "true") {
                    if (checkIsNull(document.ListLabel.StyleID, document.getElementById("sapnStyleID"), "请选择样式"))
                        CheckStr = false;
                }
                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=CorrNews,FS:ClassID=-1";
                if (document.ListLabel.Number.value != "") { rvalue += ",FS:Number=" + document.ListLabel.Number.value; }
                if (document.ListLabel.Root.value == "true")
                { temproot = "[#FS:StyleID=" + document.ListLabel.StyleID.value + "]"; }
                else {
                    temproot = editor.html();
                }
                if (document.ListLabel.SubNews.value != "") { rvalue += ",FS:SubNews=" + document.ListLabel.SubNews.value; }
                if (document.ListLabel.Cols.value != "") { rvalue += ",FS:Cols=" + document.ListLabel.Cols.value; }
                if (document.ListLabel.Desc.value != "") { rvalue += ",FS:Desc=" + document.ListLabel.Desc.value; }
                if (document.ListLabel.DescType.value != "") { rvalue += ",FS:DescType=" + document.ListLabel.DescType.value; }
                if (document.ListLabel.isDiv.value != "") { rvalue += ",FS:isDiv=" + document.ListLabel.isDiv.value; }
                if (document.ListLabel.isDiv.value == "true") {
                    if (document.ListLabel.ulID.value != "") { rvalue += ",FS:ulID=" + document.ListLabel.ulID.value; }
                    if (document.ListLabel.ulClass.value != "") { rvalue += ",FS:ulClass=" + document.ListLabel.ulClass.value; }
                }
                if (document.ListLabel.isPic.value != "") { rvalue += ",FS:isPic=" + document.ListLabel.isPic.value; }
                if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
                if (document.ListLabel.ContentNumber.value != "") { rvalue += ",FS:ContentNumber=" + document.ListLabel.ContentNumber.value; }
                if (document.ListLabel.NaviNumber.value != "") { rvalue += ",FS:NaviNumber=" + document.ListLabel.NaviNumber.value; }
                if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
                if (document.ListLabel.ShowDateNumer.value != "") { rvalue += ",FS:ShowDateNumer=" + document.ListLabel.ShowDateNumer.value; }      
                rvalue += "]";
                rvalue += temproot;
                rvalue += "[/FS:Loop]";

                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "ClassInfoList":

                if (document.ListLabel.Number.value != "" && checkIsNumber(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目只能为正整数"))
                    CheckStr = false;
                if (checkIsNull(document.ListLabel.ClassId, document.getElementById("spanClassId"), "请选择栏目")) {
                    CheckStr = false;
                }
                if (checkIsNumber(document.ListLabel.TitleNumer, document.getElementById("spanTitleNumer"), "标题显示字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.NaviNumber, document.getElementById("spanNaviNumber"), "导航截取字数只能为正整数"))
                    CheckStr = false;
                if (document.ListLabel.Root.value == "true") {
                    if (checkIsNull(document.ListLabel.StyleID, document.getElementById("sapnStyleID"), "请选择样式"))
                        CheckStr = false;
                }
                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=ClassInfoList";
                if (document.ListLabel.Number.value != "") { rvalue += ",FS:Number=" + document.ListLabel.Number.value; }
                if (document.ListLabel.Root.value == "true")
                { temproot = "[#FS:StyleID=" + document.ListLabel.StyleID.value + "]"; }
                else {
                    var oEditor = FCKeditorAPI.GetInstance("UserDefined");
                    temproot = oEditor.GetXHTML(true);
                }
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.Desc.value != "") { rvalue += ",FS:Desc=" + document.ListLabel.Desc.value; }
                if (document.ListLabel.ClassDescType.value != "") { rvalue += ",FS:DescType=" + document.ListLabel.ClassDescType.value; }
                if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
                if (document.ListLabel.NaviNumber.value != "") { rvalue += ",FS:NaviNumber=" + document.ListLabel.NaviNumber.value; }
                rvalue += "]";
                rvalue += temproot;
                rvalue += "[/FS:Loop]";

                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "History":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=History";
                if (document.ListLabel.IsDate.value != "") { rvalue += ",FS:IsDate=" + document.ListLabel.IsDate.value; }
                if (document.ListLabel.HistoryShowDate.value != "") { rvalue += ",FS:ShowDate=" + document.ListLabel.HistoryShowDate.value; }
                rvalue += "][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "Metakey":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=Metakey,FS:MetaContent=" + document.ListLabel.MetaContent.value + "][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "MetaDesc":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=MetaDesc,FS:MetaContent=" + document.ListLabel.MetaContent.value + "][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "SpecialInfo":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=SpecialInfo]" + IDUserDefined.getXHTMLBody() + "[/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
            case "SiteNavi":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=SiteNavi";
                if (document.ListLabel.daohangCSS.value != "") { rvalue += ",FS:NaviCSS=" + document.ListLabel.daohangCSS.value }
                if (document.ListLabel.daohangfg.value != "") { rvalue += ",FS:NaviChar=" + document.ListLabel.daohangfg.value }
                if (document.ListLabel.isDiv.value != "") { rvalue += ",FS:isDiv=" + document.ListLabel.isDiv.value }
                rvalue += "][/FS:unLoop]"
               parent.parent.getValue(rvalue);
                break;
            case "ClassNavi":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=ClassNavi";
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.daohangCSS.value != "") { rvalue += ",FS:NaviCSS=" + document.ListLabel.daohangCSS.value }
                //if(document.ListLabel.Mapp.value!="") { rvalue += ",FS:Mapp=" + document.ListLabel.Mapp.value } 
                if (document.ListLabel.daohangfg.value != "") { rvalue += ",FS:NaviChar=" + document.ListLabel.daohangfg.value }
                rvalue += "][/FS:unLoop]"
               parent.parent.getValue(rvalue);
                break;
            case "SClassNavi":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=SClassNavi";
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.daohangCSS.value != "") { rvalue += ",FS:NaviCSS=" + document.ListLabel.daohangCSS.value }
                if (document.ListLabel.daohangfg.value != "") { rvalue += ",FS:NaviChar=" + document.ListLabel.daohangfg.value }
                rvalue += "][/FS:unLoop]"
               parent.parent.getValue(rvalue);
                break;
            case "ClassNaviRead":
                if (checkIsNumber(document.ListLabel.ClassTitleNumber, document.getElementById("spanClassTitleNumber"), "字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.ClassNaviTitleNumber, document.getElementById("spanClassNaviTitleNumber"), "字数只能为正整数"))
                    CheckStr = false;
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=ClassNaviRead";
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.ClassTitleNumber.value != "") { rvalue += ",FS:ClassTitleNumber=" + document.ListLabel.ClassTitleNumber.value; }
                if (document.ListLabel.ClassNaviTitleNumber.value != "") { rvalue += ",FS:ClassNaviTitleNumber=" + document.ListLabel.ClassNaviTitleNumber.value; }
                rvalue += "][/FS:unLoop]"
                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "SpecialNavi":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=SpecialNavi";
                if (document.ListLabel.SpecialID.value != "") { rvalue += ",FS:SpecialID=" + document.ListLabel.SpecialID.value }
                if (document.ListLabel.daohangCSS.value != "") { rvalue += ",FS:NaviCSS=" + document.ListLabel.daohangCSS.value }
                if (document.ListLabel.daohangfg.value != "") { rvalue += ",FS:NaviChar=" + document.ListLabel.daohangfg.value }
                //            if(document.ListLabel.Mapp.value!="") { rvalue += ",FS:Mapp=" + document.ListLabel.Mapp.value } 
                rvalue += "][/FS:unLoop]"
               parent.parent.getValue(rvalue);
                break;
            case "SpeicalNaviRead":
                if (checkIsNumber(document.ListLabel.SpecialTitleNumber, document.getElementById("spanSpecialTitleNumber"), "字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.SpecialNaviTitleNumber, document.getElementById("spanSpecialNaviTitleNumber"), "字数只能为正整数"))
                    CheckStr = false;
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=SpeicalNaviRead";
                if (document.ListLabel.SpecialID.value != "") { rvalue += ",FS:SpecialID=" + document.ListLabel.SpecialID.value }
                if (document.ListLabel.SpecialTitleNumber.value != "") { rvalue += ",FS:SpecialTitleNumber=" + document.ListLabel.SpecialTitleNumber.value; }
                if (document.ListLabel.SpecialNaviTitleNumber.value != "") { rvalue += ",FS:SpecialNaviTitleNumber=" + document.ListLabel.SpecialNaviTitleNumber.value; }
                rvalue += "][/FS:unLoop]"
                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "RSS":
             
                if (document.ListLabel.SpecialID.value != "" && document.ListLabel.ClassId.value != "") {
                    alert("专题和栏目只能选择一个");
                    return false;
                }
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=RSS";
                             
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
               
                rvalue += "][/FS:unLoop]"
                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "HTML":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=HTML]" + IDUserDefined.getXHTMLBody() + "[/FS:unLoop]"
               parent.parent.getValue(rvalue);
                break;
            case "HistoryIndex":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=HistoryIndex][/FS:unLoop]"
               parent.parent.getValue(rvalue);
                break;
            case "HotTag":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=HotTag][/FS:unLoop]"
               parent.parent.getValue(rvalue);
                break;
            case "TopNews":
                if (checkIsNull(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目不能为空"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Cols, document.getElementById("spanCols"), "每行显示条数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.TitleNumer, document.getElementById("spanTitleNumer"), "标题显示字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.ContentNumber, document.getElementById("spanContentNumber"), "内容截取字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.NaviNumber, document.getElementById("spanNaviNumber"), "导航截取字数只能为正整数"))
                    CheckStr = false;
                if (document.ListLabel.Root.value == "true") {
                    if (checkIsNull(document.ListLabel.StyleID, document.getElementById("sapnStyleID"), "请选择样式"))
                        CheckStr = false;
                }

                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=TopNews";
                if (document.ListLabel.Number.value != "") { rvalue += ",FS:Number=" + document.ListLabel.Number.value; }
                if (document.ListLabel.Root.value == "true")
                { temproot = "[#FS:StyleID=" + document.ListLabel.StyleID.value + "]"; }
                else {
                    var oEditor = FCKeditorAPI.GetInstance("UserDefined");
                    temproot = oEditor.GetXHTML(true);
                }
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.TopNewsType.value != "") { rvalue += ",FS:TopNewsType=" + document.ListLabel.TopNewsType.value; }
                if (document.ListLabel.SubNews.value != "") { rvalue += ",FS:SubNews=" + document.ListLabel.SubNews.value; }
                if (document.ListLabel.Cols.value != "") { rvalue += ",FS:Cols=" + document.ListLabel.Cols.value; }
                if (document.ListLabel.Desc.value != "") { rvalue += ",FS:Desc=" + document.ListLabel.Desc.value; }
                if (document.ListLabel.DescType.value != "") { rvalue += ",FS:DescType=" + document.ListLabel.DescType.value; }
                if (document.ListLabel.isDiv.value != "") { rvalue += ",FS:isDiv=" + document.ListLabel.isDiv.value; }
                if (document.ListLabel.isDiv.value == "true") {
                    if (document.ListLabel.ulID.value != "") { rvalue += ",FS:ulID=" + document.ListLabel.ulID.value; }
                    if (document.ListLabel.ulClass.value != "") { rvalue += ",FS:ulClass=" + document.ListLabel.ulClass.value; }
                }
                if (document.ListLabel.isPic.value != "") { rvalue += ",FS:isPic=" + document.ListLabel.isPic.value; }
                if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
                if (document.ListLabel.ContentNumber.value != "") { rvalue += ",FS:ContentNumber=" + document.ListLabel.ContentNumber.value; }
                if (document.ListLabel.NaviNumber.value != "") { rvalue += ",FS:NaviNumber=" + document.ListLabel.NaviNumber.value; }
                if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
               

                rvalue += "]";
                rvalue += temproot;
                rvalue += "[/FS:Loop]";

                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "TopComm":
                if (checkIsNull(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目不能为空"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.TitleNumer, document.getElementById("spanTitleNumer"), "标题显示字数只能为正整数"))
                    CheckStr = false;
                if (checkIsNumber(document.ListLabel.ContentNumber, document.getElementById("spanContentNumber"), "内容截取字数只能为正整数"))
                    CheckStr = false;
                if (document.ListLabel.Root.value == "true") {
                    if (checkIsNull(document.ListLabel.StyleID, document.getElementById("sapnStyleID"), "请选择样式"))
                        CheckStr = false;
                }

                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=TopComm";
                if (document.ListLabel.Number.value != "") { rvalue += ",FS:Number=" + document.ListLabel.Number.value; }
                if (document.ListLabel.Root.value == "true")
                { temproot = "[#FS:StyleID=" + document.ListLabel.StyleID.value + "]"; }
                else {
                    var oEditor = FCKeditorAPI.GetInstance("UserDefined");
                    temproot = oEditor.GetXHTML(true);
                }
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value }
                if (document.ListLabel.TopCommType.value != "") { rvalue += ",FS:TopCommType=" + document.ListLabel.TopCommType.value; }
                if (document.ListLabel.isDiv.value != "") { rvalue += ",FS:isDiv=" + document.ListLabel.isDiv.value; }
                if (document.ListLabel.isDiv.value == "true") {
                    if (document.ListLabel.ulID.value != "") { rvalue += ",FS:ulID=" + document.ListLabel.ulID.value; }
                    if (document.ListLabel.ulClass.value != "") { rvalue += ",FS:ulClass=" + document.ListLabel.ulClass.value; }
                }
                if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
                if (document.ListLabel.ContentNumber.value != "") { rvalue += ",FS:ContentNumber=" + document.ListLabel.ContentNumber.value; }
                if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
                rvalue += "]";
                rvalue += temproot;
                rvalue += "[/FS:Loop]";

                if (CheckStr)
                   parent.parent.getValue(rvalue);
                break;
            case "unRuleBlock":
                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=unRuleBlock";
                if (document.ListLabel.Number.value != "") { rvalue += ",FS:Number=" + document.ListLabel.Number.value; }
                if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value; }
                if (document.getElementById("ClassShow").checked) {
                    rvalue += ",FS:ClassShow=true";
                    if (document.ListLabel.ClassCSS.value != "") { rvalue += ",FS:ClassCSS=" + document.ListLabel.ClassCSS.value; }
                }
                else {
                    rvalue += ",FS:ClassShow=false";
                }
                rvalue += ",FS:unRuleType=" + document.ListLabel.unRuleType.value;
                if (document.getElementById("MainNewsShow").checked) {
                    rvalue += ",FS:MainNewsShow=true";
                }
                else {
                    rvalue += ",FS:MainNewsShow=false";
                }
                rvalue += "]";
                rvalue += "[/FS:Loop]";
               parent.parent.getValue(rvalue);
                break;
            case "CopyRight":
                rvalue = "[FS:unLoop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=CopyRight][/FS:unLoop]";
               parent.parent.getValue(rvalue);
                break;
        }
    }
    function spanClear() {
        var spanlist = "spanNumber,spanCols,spanTitleNumer,spanContentNumber,spanNaviNumber,spanShowDateNumer,sapnStyleID,spansubRuleID,spanFlashweight,spanFlashheight,spanTXTheight,spanisSubCols,spanClassTitleNumber,spanClassNaviTitleNumber,spanSpecialTitleNumber,spanSpecialNaviTitleNumber,spanTodayPicID,sapnSearchType";
        var arrlist = spanlist.split(',');
        for (var i = 0; i < arrlist.length; i++) {
            document.getElementById(arrlist[i]).innerHTML = "";
        }
    }
    function getdivstyle(obj) {
        if (obj == "") {
            showCSSdiv.innerHTML = "<img src=\"/CSS/imges/Label/preview/ClassInfo.gif\" border=\"0\">";
            document.getElementById("showCSSdivtable").style.display = "none";
        }
        else {
            showCSSdiv.innerHTML = "<img src=\"/CSS/imges/Label/preview/" + obj + ".gif\" border=\"0\">";
            document.getElementById("showCSSdivtable").style.display = "";
        }
    }
    function selectLabelType(type) {
        var spanlist = "";
        spanlist = "TrNumber,TrSubNews,TrClassId,TrSpecialID,TrCols,TrDescType,TrDesc,TrisDiv,TrulID,TrulClass,TrisPic,TrTitleNumer,TrContentNumber,TrNaviNumber,TrShowDateNumer,TrisSub,TrRoot,TrStyleID,TrUserDefined,TrRuleID,TrPositionValue,TrSearchType,TrShowDate,TrShowClass,TrShowUser,TrShowNews,TrStatShowClass,TrShowAPI,TrFlashweight,TrFlashheight,TrFlashBG,TrFlashTitleNumber,TrShowTitle,TrTXTheight,TrisSubCols,TrMapTitleCSS,TrSubCSS,TrMapp,TrMapNavi,TrMapNaviText,TrNaviPic,TrMapsubNavi,TrMapsubNaviText,TrMapsubNaviPic,TrIsDate,TrHistoryShowDate,TrClassTitleNumber,TrClassNaviTitleNumber,TrSpecialTitleNumber,TrSpecialNaviTitleNumber,TrTopNewsTyper,TrTopCommType,TrTodayPicID,div_daohang,div_daohangfg,TrWNum,TrWCSS,TrBigT,TrBigCSS,TrChar,TrFlashType,TrClassShow,TrunRuleType,TrMainNewsShow,TrClassCSS,TrFlashSize,TrTarget,Trprefix,TRMetaContent,TrSTitle,TrunNavi,TrDynChar,TrClassDescType";
        showorhide(spanlist, false);
        $('#btnClassIdTypeAll').show();
        $('#btnClassIdTypeLevel').show();
        getdivstyle(type);
        switch (type) {
            case "subList":
                spanlist = "TrNumber,TrSubNews,TrClassId,TrCols,TrDescType,TrDesc,TrisDiv,TrisPic,TrTitleNumer,TrContentNumber,TrNaviNumber,TrShowDateNumer,TrRoot,TrStyleID";
                showorhide(spanlist, true);
                break;
            case "unRule":
                spanlist = "TrRuleID,TrSTitle,TrunNavi";
                showorhide(spanlist, true);
                break;
            case "Metakey":
                spanlist = "TRMetaContent";
                showorhide(spanlist, true);
                break;
            case "MetaDesc":
                spanlist = "TRMetaContent";
                showorhide(spanlist, true);
                break;
            case "SpecialInfo":
                spanlist = "TrStyleID,TrRoot";
                showorhide(spanlist, true);
                break;
            case "Position":
                spanlist = "TrPositionValue,TrDynChar";
                showorhide(spanlist, true);
                break;
            case "PageTitle":
                spanlist = "Trprefix";
                showorhide(spanlist, true);
                break;
            case "Search":
                spanlist = "TrSearchType,TrShowDate,TrShowClass";
                showorhide(spanlist, true);
                break;
            case "Stat":
                spanlist = "TrShowUser,TrShowNews,TrStatShowClass,TrShowAPI";
                showorhide(spanlist, true);
                break;
            case "FlashFilt":
                spanlist = "TrNumber,TrClassId,TrFlashweight,TrFlashheight,TrFlashBG,TrFlashTitleNumber,TrShowTitle,TrisSub,TrFlashType";
                showorhide(spanlist, true);
                break;
            case "NorFilt":
                spanlist = "TrClassId,TrWNum,TrWCSS,TrTitleNumer,TrisSub,TrShowTitle,TrFlashSize,TrTarget";
                showorhide(spanlist, true);
                break;
            case "Sitemap":
                spanlist = "TrisSubCols,TrMapTitleCSS,TrSubCSS,TrMapp,TrMapNavi,TrMapsubNavi";
                showorhide(spanlist, true);
                break;
            case "TodayPic":
                spanlist = "TrTodayPicID,TrChar";
                showorhide(spanlist, true);
                break;
            case "TodayWord":
                spanlist = "TrClassId,TrChar,TrWNum,TrWCSS,TrCols,TrTitleNumer,TrisSub,TrBigT,TrBigCSS";
                showorhide(spanlist, true);
                break;
            case "CorrNews":
                spanlist = "TrNumber,TrSubNews,TrCols,TrDescType,TrDesc,TrisPic,TrTitleNumer,TrContentNumber,TrNaviNumber,TrisSub,TrShowDateNumer,TrRoot,TrStyleID";
                showorhide(spanlist, true);
                break;
            case "ClassInfoList":
                spanlist = "TrNumber,TrClassDescType,TrClassId,TrDesc,TrTitleNumer,TrNaviNumber,TrRoot,TrStyleID";
                showorhide(spanlist, true);
                $('#showCSSdivtable').hide();
                break;
            case "History":
                spanlist = "TrIsDate,TrHistoryShowDate";
                showorhide(spanlist, true);
                break;
            case "SiteNavi":
                spanlist = "div_daohang,div_daohangfg,TrisDiv";
                showorhide(spanlist, true);
                break;
            case "ClassNavi":
                spanlist = "div_daohang,div_daohangfg,TrClassId";
                showorhide(spanlist, true);
                break;
            case "SClassNavi":
                spanlist = "div_daohang,div_daohangfg,TrClassId";
                showorhide(spanlist, true);
                break;
            case "ClassNaviRead":
                spanlist = "TrClassId,TrClassTitleNumber,TrClassNaviTitleNumber";
                $('#btnClassIdTypeAll').hide();
                $('#btnClassIdTypeLevel').hide();
                showorhide(spanlist, true);
                break;
            case "SpecialNavi":
                spanlist = "TrSpecialID,div_daohang,div_daohangfg";
                showorhide(spanlist, true);
                break;
            case "SpeicalNaviRead":
                spanlist = "TrSpecialID,TrSpecialTitleNumber,TrSpecialNaviTitleNumber";
                showorhide(spanlist, true);
                break;
            case "RSS":
                //spanlist="TrNumber,TrClassId,TrSpecialID,TrTitleNumer";
                spanlist = "TrClassId";
                showorhide(spanlist, true);
                break;
            case "HTML":
                spanlist = "TrUserDefined";
                showorhide(spanlist, true);
                break;
            case "TopNews":
                spanlist = "TrRoot,TrClassId,TrNumber,TrSubNews,TrCols,TrisDiv,TrisPic,TrTitleNumer,TrContentNumber,TrNaviNumber,TrisSub,TrTopNewsTyper,TrStyleID";
                showorhide(spanlist, true);
                break;
            case "TopComm":
                spanlist = "TrRoot,TrTopCommType,TrClassId,TrNumber,TrisDiv,TrTitleNumer,TrContentNumber,TrisSub,TrStyleID";
                showorhide(spanlist, true);
                break;
            case "unRuleBlock":
                spanlist = "TrNumber,TrClassId,TrClassShow,TrunRuleType,TrMainNewsShow,TrClassCSS";
                showorhide(spanlist, true);
                break;
            case "CopyRight":
                spanlist = "";
                showorhide(spanlist, true);
                break;
        }
    }
    function showorhide(list, tf) {
        var arrlist = list.split(',');
        if (tf == true) {
            for (var i = 0; i < arrlist.length; i++) {
                if (arrlist[i] != "") {
                    document.getElementById(arrlist[i]).style.display = "";
                }
            }
        }
        else {
            for (var i = 0; i < arrlist.length; i++) {
                if (arrlist[i] != "") {
                    document.getElementById(arrlist[i]).style.display = "none";
                }
            }
        }
    }
    function checkIsNull(obj, spanobj, error) {
        if (obj.value == "") {
            spanobj.innerHTML = "<span class=reshow>(*)" + error + "</span>";
            return true;
        }
        return false;
    }
    function checkIsNumber(obj, spanobj, error) {
        var re = /^[0-9]*$$/;
        if (re.test(obj.value) == false) {
            spanobj.innerHTML = "<span class=reshow>(*)" + error + "</span>";
            return true;
        }
        return false;
    }
    function getValue(value) {
        editor.insertHtml(value);
    }
    function setValue(value) {
        if (value == "") {
            return;
        }
        editor.insertHtml('{#FS:define=' + value + '}');
    }
    function getType(value) {
        document.getElementById("ClassId").value = value;
        if (value == "-1")
            document.getElementById("ClassName").value = "调用所有";
        else if (value == "0")
            document.getElementById("ClassName").value = "自适应";
        else if (value == "1")
            document.getElementById("ClassName").value = "本级栏目";
    }

    function getTypeS(value) {
        document.getElementById("SpecialID").value = value;
        if (value == "-1")
            document.getElementById("SpecialName").value = "调用所有";
        else
            document.getElementById("SpecialName").value = "自适应";
    }

</script>


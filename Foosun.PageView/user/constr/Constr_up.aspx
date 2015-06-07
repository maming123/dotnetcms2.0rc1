<%@ Page Language="C#" ContentType="text/html" AutoEventWireup="true" ValidateRequest="false" Inherits="user_Constr_up" Debug="true" Codebehind="Constr_up.aspx.cs" %>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import NameSpace="System.Data"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
	<script type="text/javascript">
	    var editor;
	    KindEditor.ready(function (K) {
	        editor = K.create('textarea[name="Contentbox"]', {
	            resizeType: 1,
	            allowPreviewEmoticons: false,
	            allowImageUpload: false,
	            items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
	        });
	    });
		function ivurl() {
			var gvURL = document.getElementById("vURL");
			var gvalur = gvURL.value;
			if (gvalur != "") {
				if (gvalur.indexOf(".") > -1) {
					gvalur = gvalur.toLowerCase().replace('{@dirfile}', '<% Response.Write(Foosun.Config.UIConfig.dirFile); %>')
					var fileExstarpostion = gvalur.lastIndexOf(".");
					var fileExName = gvalur.substring(fileExstarpostion, (gvalur.length))
					var content = "";
					switch (fileExName.toLowerCase()) {
						case ".jpg": case ".gif": case ".bmp": case ".ico": case ".png": case ".jpeg": case ".tif": case ".rar": case ".doc": case ".zip": case ".txt":
							alert("错误的视频文件"); return false;
							break;
						case ".swf":
							var content = "<embed width=\"500\" height=\"400\" src=\"" + gvalur + "\" quality=\"high\" pluginspage=\"http://www.adobe.com/go/getflashplayer_cn\" align=\"middle\" play=\"true\" loop=\"true\" scale=\"showall\" wmode=\"window\" devicefont=\"false\ menu=\"true\" allowscriptaccess=\"sameDomain\" type=\"application/x-shockwave-flash\" />"
							break;
						case ".flv":
							var content = "<embed width=\"500\" height=\"400\" src=\"/FlvPlayer.swf\" quality=\"high\" pluginspage=\"http://www.adobe.com/go/getflashplayer_cn\" align=\"middle\" play=\"true\" loop=\"true\" scale=\"showall\" wmode=\"window\" devicefont=\"false\" menu=\"true\" allowfullscreen=\"true\" allowscriptaccess=\"sameDomain\" flashvars=\"vcastr_file=" + gvalur + "\" type=\"application/x-shockwave-flash\" />"
							break;
						case ".avi":
							content = "<embed  src=\"" + gvalur + "\" width=\"340\" height=\"240\"></embed>";
							break;
						case ".wmv":
							content = "<object id=\"NSPlay\" width=500  classid=\"CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95\" codebase=\"http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,5,715\" standby=\"Loading Microsoft Windows Media Player components...\" type=\"application/x-oleobject\" hspace=\"5\">\r\n" +
                            "<param name=\"AutoRewind\" value=1>\r\n" +
                            "<param name=\"FileName\" value=\"" + gvalur + "\">\r\n" +
                            "<param name=\"ShowControls\" value=\"1\">\r\n" +
                            "<param name=\"ShowPositionControls\" value=\"0\">\r\n" +
                            "<param name=\"ShowAudioControls\" value=\"1\">\r\n" +
                            "<param name=\"ShowTracker\" value=\"0\">\r\n" +
                            "<param name=\"ShowDisplay\" value=\"0\">\r\n" +
                            "<param name=\"ShowStatusBar\" value=\"0\">\r\n" +
                            "<param name=\"ShowGotoBar\" value=\"0\">\r\n" +
                            "<param name=\"ShowCaptioning\" value=\"0\">\r\n" +
                            "<param name=\"AutoStart\" value=1>\r\n" +
                            "<param name=\"Volume\" value=\"-2500\">\r\n" +
                            "<param name=\"AnimationAtStart\" value=\"0\">\r\n" +
                            "<param name=\"TransparentAtStart\" value=\"0\">\r\n" +
                            "<param name=\"AllowChangeDisplaySize\" value=\"0\">\r\n" +
                            "<param name=\"AllowScan\" value=\"0\">\r\n" +
                            "<param name=\"EnableContextMenu\" value=\"0\">\r\n" +
                            "<param name=\"ClickToPlay\" value=\"0\">\r\n" +
                            "</object>\r\n";
							break;
						case ".mpg":
							content = "<object classid=\"clsid:05589FA1-C356-11CE-BF01-00AA0055595A\" id=\"ActiveMovie1\" width=\"500\"  >\r\n" +
                            "<param name=\"Appearance\" value=\"0\">\r\n" +
                            "<param name=\"AutoStart\" value=\"-1\">\r\n" +
                            "<param name=\"AllowChangeDisplayMode\" value=\"-1\">\r\n" +
                            "<param name=\"AllowHideDisplay\" value=\"0\">\r\n" +
                            "<param name=\"AllowHideControls\" value=\"-1\">\r\n" +
                            "<param name=\"AutoRewind\" value=\"-1\">\r\n" +
                            "<param name=\"Balance\" value=\"0\">\r\n" +
                            "<param name=\"CurrentPosition\" value=\"0\">\r\n" +
                            "<param name=\"DisplayBackColor\" value=\"0\">\r\n" +
                            "<param name=\"DisplayForeColor\" value=\"16777215\">\r\n" +
                            "<param name=\"DisplayMode\" value=\"0\">\r\n" +
                            "<param name=\"Enabled\" value=\"-1\">\r\n" +
                            "<param name=\"EnableContextMenu\" value=\"-1\">\r\n" +
                            "<param name=\"EnablePositionControls\" value=\"-1\">\r\n" +
                            "<param name=\"EnableSelectionControls\" value=\"0\">\r\n" +
                            "<param name=\"EnableTracker\" value=\"-1\">\r\n" +
                            "<param name=\"Filename\" value=\"" + gvalur + "\" valuetype=\"ref\">\r\n" +
                            "<param name=\"FullScreenMode\" value=\"0\">\r\n" +
                            "<param name=\"MovieWindowSize\" value=\"0\">\r\n" +
                            "<param name=\"PlayCount\" value=\"1\">\r\n" +
                            "<param name=\"Rate\" value=\"1\">\r\n" +
                            "<param name=\"SelectionStart\" value=\"-1\">\r\n" +
                            "<param name=\"SelectionEnd\" value=\"-1\">\r\n" +
                            "<param name=\"ShowControls\" value=\"-1\">\r\n" +
                            "<param name=\"ShowDisplay\" value=\"-1\">\r\n" +
                            "<param name=\"ShowPositionControls\" value=\"0\">\r\n" +
                            "<param name=\"ShowTracker\" value=\"-1\">\r\n" +
                            "<param name=\"Volume\" value=\"-480\">\r\n" +
                            "</object>\r\n";
							break;
						default:
							content = "<OBJECT ID=video1 CLASSID=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\"   WIDTH=500>\r\n" +
                            "<param name=\"_ExtentX\" value=\"9313\">\r\n" +
                            "<param name=\"_ExtentY\" value=\"7620\">\r\n" +
                            "<param name=\"AUTOSTART\" value=\"0\">\r\n" +
                            "<param name=\"SHUFFLE\" value=\"0\">\r\n" +
                            "<param name=\"PREFETCH\" value=\"0\">\r\n" +
                            "<param name=\"NOLABELS\" value=\"0\">\r\n" +
                            "<param name=\"SRC\" value=\"" + gvalur + "\">\r\n" +
                            "<param name=\"CONTROLS\" value=\"ImageWindow\">\r\n" +
                            "<param name=\"CONSOLE\" value=\"Clip1\">\r\n" +
                            "<param name=\"LOOP\" value=\"0\">\r\n" +
                            "<param name=\"NUMLOOP\" value=\"0\">\r\n" +
                            "<param name=\"CENTER\" value=\"0\">\r\n" +
                            "<param name=\"MAINTAINASPECT\" value=\"0\">\r\n" +
                            "<param name=\"BACKGROUNDCOLOR\" value=\"#000000\">\r\n" + "<embed SRC type=\"audio/x-pn-realaudio-plugin\" CONSOLE=\"Clip1\" CONTROLS=\"ImageWindow\"   AUTOSTART=\"false\">\r\n" +
                            "</OBJECT>";
							break;
					}
					content = content.replace('{@dirfile}', '<% Response.Write(Foosun.Config.UIConfig.dirFile); %>');
					content = content.replace('{@userdirfile}', '<% Response.Write(Foosun.Config.UIConfig.UserdirFile); %>');
					editor.insertHtml(content);  
				}
				else {
					alert('错误的视频');
					return false;
				}
			}
			else {
				alert('没有视频文件');
				return false;
			}
		}	
	</script>
</head>
<body onload="DispChange('<%= ConstrTF %>')">
<div id="dialog-message"></div>
<form id="form1" name="form1" method="post" action="" runat="server"> 
<table width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
    <tr>
      <td height="1" colspan="2"></td>
    </tr>
    <tr>      
      <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">文章管理</strong></td>
    <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" /><a href="Constrlist.aspx" class="list_link">文章管理</a></div></td>
    </tr>
</table>
      <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
        <tr>
          <td style="padding-left:14px;">          
          <a href="Constr.aspx" class="menulist">发表文章</a>&nbsp; &nbsp;<a href="Constrlistpass.aspx" class="topnavichar" >所有退稿</a>&nbsp; &nbsp;<a href="Constrlist.aspx" class="menulist">文章管理</a>&nbsp; &nbsp;<a href="ConstrClass.aspx" class="menulist">分类管理</a>&nbsp; &nbsp;<a href="Constraccount.aspx" class="menulist">账号管理</a>
          </td>
        </tr>
</table>
<table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" class="table">
  <tr class="TR_BG_list">
    <td class="list_link" style="text-align: right; width: 110px;">
        文章名称：</td>
      <td class="list_link" colspan="5">
        <asp:TextBox ID="Title" runat="server" Width="325px" CssClass="form" MaxLength="100"></asp:TextBox>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_Constr_0001',this)">帮助</span>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title" ErrorMessage="请输入分类名称"></asp:RequiredFieldValidator>
      </td>   
  </tr>
  <tr class="TR_BG_list">
    <td class="list_link" style="text-align: right; width: 110px;">
        文章内容：</td>
      <td class="list_link" colspan="5" style="width: 750px;height:250px;">
      <label id="picContentTF"></label>
        <script type="text/javascript" language="JavaScript">
					function insertHTMLEdit(url) {
						var urls = url.replace('{@dirfile}', '<% Response.Write(Foosun.Config.UIConfig.dirFile); %>')
						urls = url.replace('{@userdirfile}', '<% Response.Write(Foosun.Config.UIConfig.UserdirFile); %>')
						    editor.insertHtml('<img src=\"' + urls + '\" border=\"0\" />');  
						return;
					}  
				</script>
				<textarea rows="1" cols="1" name="Contentbox" style="width:90%;height:400px;visibility:hidden;" id="Contentbox" runat="server"></textarea>
      </td>
  </tr>
 <tr class="TR_BG_list">
			<td class="list_link" style="text-align: right; width: 110px;">
				作 者：
			</td>
			<td class="list_link" colspan="5">
				<asp:TextBox ID="Author" runat="server" CssClass="form"></asp:TextBox><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_Constr_0003',this)">帮助</span> &nbsp; &nbsp; &nbsp; 关 键 字：<asp:TextBox ID="Tags" runat="server" CssClass="form"></asp:TextBox><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_Constr_0019',this)">帮助</span> &nbsp; &nbsp; &nbsp; 类 型：<asp:DropDownList ID="lxList1" runat="server" Width="146px" CssClass="form">
					<asp:ListItem>原创</asp:ListItem>
					<asp:ListItem>转载</asp:ListItem>
					<asp:ListItem>代理</asp:ListItem>
				</asp:DropDownList>
				<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_Constr_0008',this)">帮助</span>
			</td>
		</tr>
		<tr class="TR_BG_list">
			<td class="list_link" style="text-align: right; width: 110px;">
				信息级：
			</td>
			<td class="list_link" colspan="5" valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
					<tr>
						<td width="7%">
							<asp:RadioButtonList ID="inList1" runat="server" RepeatDirection="Horizontal" Width="192px">
								<asp:ListItem Selected="True" Value="0">普通</asp:ListItem>
								<asp:ListItem Value="1">优先</asp:ListItem>
								<asp:ListItem Value="2">加急</asp:ListItem>
							</asp:RadioButtonList>
						</td>
						<td width="18%" style="text-align: right; display:none;" id="site1">
							投稿给管理员：
						</td>
						<td width="75%" style="display: ;" id="site2">
							<asp:RadioButtonList ID="fbList1" runat="server" RepeatDirection="Horizontal" Width="103px">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr class="TR_BG_list">
			<td class="list_link" style="text-align: right; width: 110px;">
				频道分类：
			</td>
			<td class="list_link" colspan="5">
				&nbsp;<asp:DropDownList ID="site" runat="server" Width="147px" CssClass="form" Enabled="false">
				</asp:DropDownList>
				<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_Constr_0005',this)">帮助</span> &nbsp; &nbsp; &nbsp; 文章分类：<asp:DropDownList ID="ConstrClass" runat="server" Width="146px" CssClass="form">
				</asp:DropDownList>
				<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_Constr_0006',this)">帮助</span>
			</td>
		</tr>
		<tr class="TR_BG_list" style="display:none">
			<td class="list_link" style="text-align: right; width: 110px;">
				栏目选择：
			</td>
			<td class="list_link">
				<asp:TextBox ID="ClassCName" runat="server" Width="147px"></asp:TextBox>&nbsp; &nbsp;<input class="form" type="button" value="选择栏目" onclick="javascript:selectFile('ClassName,ClassID','栏目选择','newsclass','400','300')" />
				<asp:HiddenField runat="server" ID="ClassID" />
			</td>
		</tr>
		<tr class="TR_BG_list">
			<td class="list_link" style="text-align: right; width: 110px;">
				锁 定：
			</td>
			<td class="list_link" colspan="5" valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
					<tr>
						<td style="width: 3%">
							<asp:RadioButtonList ID="Locking" runat="server" RepeatDirection="Horizontal" Width="93px">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</td>
						<td style="text-align: right; width: 15%;">
							推 荐：
						</td>
						<td width="92%">
							<asp:RadioButtonList ID="Recommendation" runat="server" RepeatDirection="Horizontal" Width="94px">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr class="TR_BG_list">
			<td class="list_link" style="height: 32px; text-align: right; width: 110px;">
				图 片：
			</td>
			<td class="list_link" colspan="5">
				<asp:TextBox ID="photo" runat="server" Width="265px" CssClass="form"></asp:TextBox>
				<input class="form" type="button" value="选择图片" onclick="javascript:selectFile('photo','图片选择','user_pic','500','350')" /><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_Constr_0011',this)">帮助</span>
			</td>
		</tr>
		<tr class="TR_BG_list">
			<td class="list_link" style="height: 32px; text-align: right; width: 110px;">
				插入附件：
			</td>
			<td class="list_link" colspan="5">
				<asp:TextBox ID="txtFile" runat="server" Width="265px" CssClass="form"></asp:TextBox>
				<input class="form" type="button" value="选择附件" onclick="javascript:selectFile('txtFile','附件选择','user_file','500','350')" /><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_Constr_0011',this)">帮助</span>
			</td>
		</tr>
		<tr class="TR_BG_list">
			<td class="list_link" style="text-align: right; width: 110px;">
			</td>
			<td class="list_link" colspan="5">
				&nbsp;<asp:Button ID="Button1" runat="server" CssClass="form" Text="提 交" OnClick="Button1_Click" />
				&nbsp; &nbsp;&nbsp; &nbsp;<input type="reset" name="Submit3" value="重 置" class="form">
			</td>
		</tr>
	</table>
	<br />
	<br />
	<table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
		<tr>
			<td>
				<div align="center">
					<%Response.Write(CopyRight); %>
				</div>
			</td>
		</tr>
</table>
</form>
</body>
</html>
<script language="javascript">
function DispChange(contf)
{
    if(contf =="1")
    {
            document.getElementById("site1").style.display="";
            document.getElementById("site2").style.display="";
    }
}
</script>
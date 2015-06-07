<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_news_unnews_iframe" CodeBehind="unnews_iframe.aspx.cs" %>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
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
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/css/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
	<script type="text/javascript">
	    var IsMSIE = (navigator.appName == "Microsoft Internet Explorer");
	    function AddUnNewList(NewId, NewTitle) {
	        var ListLen = parent.UnNewArray.length;
	        var FindFlag = -2;
	        for (var i = 0; i < ListLen; i++) {
	            if (parent.UnNewArray[i][0] == NewId) {
	                FindFlag = i;
	                break;
	            }
	        }
	        if (FindFlag >= -1) {
	            if (confirm("确定移除吗？")) {
	                parent.UnNewArray.remove(FindFlag, 1);
	                parent.DisplayUnNews();
	                CheckUnNews();
	                parent.UnNewPreviewCh();
	            }
	        } else {
	            parent.UnNewArray[ListLen] = [NewId,NewTitle, NewTitle, (ListLen + 1), '', ''];
	            parent.DisplayUnNews();
	            CheckUnNews();	            
	        }
	    }

	    function CheckUnNews() {
	        var ListLen = parent.UnNewArray.length;
	        var FindFlag = -1;
	        var buttons = document.getElementsByTagName("button");
	        for (var j = 0; j < buttons.length; j++) {
	            FindFlag = -1;
	            for (var i = 0; i < ListLen; i++) {
	                if (("New" + parent.UnNewArray[i][0]) == buttons[j].id) {
	                    FindFlag = j;
	                    break;
	                }
	            }
	            if (FindFlag > -1) {
	                buttons[j].innerHTML = "<span style=\"color:red;font-size:12px;\">删除</span>";
	            } else {
	                buttons[j].innerHTML = "<span style=\"font-size:12px;\">加入</span>";
	            }
	        }
	    }
	    window.onload = CheckUnNews;
	</script>
</head>

<body>
<div id="dialog-message" title="提示"></div>
<form id="Form1" runat="server">
<div class="auto_bot">
   <div class="show_so">
                                  <p>筛选: <asp:LinkButton ID="LnkBtnAll" runat="server" CssClass="topnavichar" OnClick="LnkBtnAll_Click">全部新闻</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnContribute" CssClass="topnavichar" runat="server" OnClick="LnkBtnContribute_Click">投稿</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnCommend" runat="server" CssClass="topnavichar" OnClick="LnkBtnCommend_Click">推荐</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnTop" runat="server" CssClass="topnavichar" OnClick="LnkBtnTop_Click">置顶</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnHot" runat="server" CssClass="topnavichar" OnClick="LnkBtnHot_Click">热点</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnPic" runat="server" CssClass="topnavichar" OnClick="LnkBtnPic_Click">图片</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnSplendid" runat="server" CssClass="topnavichar" OnClick="LnkBtnSplendid_Click">精彩</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnHeadline" runat="server" CssClass="topnavichar" OnClick="LnkBtnHeadline_Click">头条</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnSlide" runat="server" CssClass="topnavichar" OnClick="LnkBtnSlide_Click">幻灯片</asp:LinkButton>
                                  </p><br />
                                  <p>新闻搜索：<font class="nwelie_so">栏目：</font><asp:TextBox ID="ClassName" runat="server" width="150" /><input type="hidden" id="ClassID" runat="server"/>
                                     <a href="javascript:selectFile('ClassName,ClassID','栏目选择','newsclass','400','300')"><img src="../imges/bgxiu_14.gif"  align="middle" alt=""  class="img1"  /></a> 
                                     <font class="nwelie_so">关键字：</font>
                                     <asp:TextBox runat="server" ID="TxtKeywords"  width="100" />
                                    <asp:DropDownList ID="DdlKwdType" runat="server" class="nwelie_sect">
						            <asp:ListItem Value="title" Text="标题" />
						            <asp:ListItem Value="content" Text="内容" />
						            <asp:ListItem Value="author" Text="作者" />
						            <asp:ListItem Value="editor" Text="录入者" />
					                </asp:DropDownList>
                                     <asp:Button runat="server" ID="BtnSearch" Text=" 搜索 " OnClick="BtnSearch_Click" CssClass="form1" />
                                   </p>
                               </div>
   <div class="show_tab">
                                  <table width="100%">
                                     <tr>
                                       <th width="55%">新闻标题(点击) </th>
                                       <th width="15%">所属栏目 </th>
                                       <th width="15%">编辑 </th>
                                       <th width="15%">操作</th>
                                     </tr>
                                     <asp:Repeater ID="RptNews" runat="server">
			                      	<ItemTemplate>
                                     <tr>
                                        <td><span class="input1"><%# DataBinder.Eval(Container.DataItem, "NewsTitle")%>(<%# DataBinder.Eval(Container.DataItem, "Click")%>) </span></td>
                                        <td align="center"><%# DataBinder.Eval(Container.DataItem, "ClassCName")%> </td> 
                                        <td align="center"><%# DataBinder.Eval(Container.DataItem, "UserName")%></td> 
                                        <td align="center"><button id="New<%# DataBinder.Eval(Container.DataItem, "Newsid")%>" onclick="javascript:AddUnNewList('<%# DataBinder.Eval(Container.DataItem, "Newsid")%>','<%# replacechar(DataBinder.Eval(Container.DataItem, "NewsTitle"))%>');return false;" class="form1">
								加入</button></td> 
                                     </tr>
                                     	</ItemTemplate>
			</asp:Repeater>
                                  </table>
   </div>
   <div style="width:98%;line-height:30px;" align="right">
			<uc1:PageNavigator ID="PageNavigator1" runat="server" />
		</div>
		<asp:Label runat="server" ID="LblChoose" Visible="false" Text="" />
</div>
</form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unnews.aspx.cs" Inherits="Foosun.PageView.manage.news.Unnews" %>
<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>不规则新闻</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function Del(datas) {
        PostForm(datas);
    }
    function show(datas) { 
        PostForm(datas)
    }
    function PostForm(datas) {
        $.ajax({
            type: "POST",
            url: "Unnews.aspx",
            async: false,
            //是否ajax同步       
            data: datas,
            success: function (data) {
                $("#dialog-message").html("<div class=\"msgboxs\">" + data + "</div>");
                $("#dialog-message").dialog({
                    modal: true,
                    width: 400,
                    close: function () {
                        __doPostBack('PageNavigator1$LnkBtnGoto', '');
                    }
                });
            }
        });
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div id="dialog-message" title="提示"></div>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>不规则新闻管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>不规则新闻
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能:</span><a href="UnnewsEdit.aspx" class="topnavichar">添加不规则新闻</a>
      </div>
      <div class="jslie_lie">
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="60%" align="left"><span class="span1">新闻标题</span></th>
               <th width="40%">操作</th>
            </tr>
             <asp:Repeater ID="RptunNews" runat="server">
              <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td><span class="span1"><%#Eval("UnName")%></span></td>
              <td align="center">
                 <a href="UnnewsEdit.aspx?UnID=<%#Eval("UnID") %>">[修改]</a>
                 <a href="javascript:show('type=show&UnID=<%#Eval("UnID") %>')">[预览]</a>
                 <a href="javascript:Del('type=del&UnID=<%#Eval("UnID") %>')">[删除]</a>
              </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
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

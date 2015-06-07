<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsTemplet.aspx.cs" Inherits="Foosun.PageView.manage.jsmodel.JsTemplet" %>
<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>js模型管理</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function AddTemp() {
        var obj = document.getElementById('DdlClass');
        var val = obj.options[obj.selectedIndex].value;
        location.href = 'JSTempletAdd.aspx?class=' + val;
    }
    function AddClass() {
        var obj = document.getElementById('DdlClass');
        var val = obj.options[obj.selectedIndex].value;
        location.href = 'JSTempletClass.aspx?Upper=' + val;
    }
    function DeleteClass(id) {
        if (window.confirm('您确认要删除该分类吗?该分类下所有的子分类以及JS模型都将被级联删除,数据将不能恢复!')) {
            PostForm("Option=DeleteJSTmpClass&ID=" + id);           
        }
    }
    function DeleteTmp(id) {
        if (window.confirm('您确认要删除该分JS模型吗?数据将不能恢复!')) {
            PostForm("Option=DeleteJSTemplet&ID=" + id);           
        }
    }
    function GoToClass(id) {
        var obj = document.getElementById('DdlClass');
        for (var i = 0; i < obj.options.length; i++) {
            if (obj.options[i].value == id) {
                obj.selectedIndex = i;
                form1.submit();
                break;
            }
        }
    }
    function PostForm(datas) {
        $.ajax({
            type: "POST",
            url: "JsTemplet.aspx",
            async: false,
            //是否ajax同步       
            data: datas,
            success: function (data) {
                $("#dialog-message").html("<div class=\"msgboxs\">" + data + "</div>");
                $("#dialog-message").dialog({
                    modal: true,
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
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>JS模型管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>JS模型管理
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能：</span><a href="javascript:AddClass();">新增分类</a>┊<a href="javascript:AddTemp();">新增JS模型</a>
      </div>
      <div class="jslie_lie">
      <asp:Repeater ID="DataList1" runat="server" >
			<HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="40%" align="left"><span class="span1">名称</span></th>
               <th width="20%">类型/数量</th>
               <th width="20%">创建日期</th>
               <th width="20%">操作</th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td><span class="span1"><%#Eval("CName") %></span></td>
              <td align="center"><%#Eval("type") %></td>
              <td align="center"><%#Eval("CreatTime") %></td>
              <td align="center"><%#Eval("edit") %></td>
            </tr>
            </ItemTemplate> 
            <FooterTemplate>
				</table>
			</FooterTemplate>
         </asp:Repeater>
         <div class="js_sg">
            当前JS模型分类：<asp:DropDownList runat="server" ID="DdlClass" AutoPostBack="True" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged"><asp:ListItem Value="0">根节点</asp:ListItem></asp:DropDownList>
         </div>
         <div class="fanye1">
         <div class="fanye_le"> <uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
      </div>
      </div>
   </div>
</div>
</div>
   <div id="dialog-message" title="提示"></div>
</form>
</body>
</html>

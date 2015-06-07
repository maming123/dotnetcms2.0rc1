<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSList.aspx.cs" Inherits="Foosun.PageView.manage.jsmodel.JSList" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>JS管理</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function GetJSCode(id) {
        PostForm("option=GetCode&JSID=" + id,"0");
    }
    function ShowNewsJs(id) {
        var WWidth = (window.screen.width - 500) / 2;
        var Wheight = (window.screen.height - 150) / 2 - 50;
        window.open('JSNews.aspx?JSID=' + id, '查看新闻JS', 'height=400px, width=750px,toolbar=no, menubar=no, scrollbars=yes,top=' + Wheight + ', left=' + WWidth + ', resizable=no,location=no, status=no');
    }
    $(function () {
        $("input[name='checkboxs']").click(function () {
            if (this.checked) {
                $("input[name='checkbox']").attr('checked', true);
            }
            else {
                $("input[name='checkbox']").attr('checked', false);
            }
        });
    });
    function DeleteJS(id) {
        if (confirm("你确定要删除？")) {
            PostForm("Option=DeleteJS&JSID=" + id, "1");
        }
    }
    function DeleteJSs() {
        var idlist = "";
        $('input[type="checkbox"][name="checkbox"]').each(function () {
            if (this.checked) {
                idlist += $(this).val() + ",";
            }
        });
        if (idlist.length > 0) {
            idlist = idlist.substring(0, idlist.length - 1);
        }
        else {
            $('#dialog').html("没有选择任何新闻！");
            $("#dialog").dialog({
                modal: true,
                close: function () {
                    return;
                }
            });
            return;
        }
        if (confirm("你确定要删除？")) {
            PostForm("Option=DeleteJS&JSID=" + idlist,"1");
        }
    }
    function PostForm(datas,type) {
        $.ajax({
            type: "POST",
            url: "JSList.aspx",
            async: false,
            //是否ajax同步       
            data: datas,
            success: function (data) {
                $("#dialog").html("<div class=\"msgboxs\">"+data+"</div>");
                if (type == "0") {
                    $("#dialog").dialog({
                        width: 400,
                        buttons: {
                            "复制": function () {
                                copyToClipboard($('#codecontent').val());
                                $(this).dialog("close");
                            },
                            "退出": function () {
                                $(this).dialog("close");
                            }
                        }
                    });
                }
                else {
                    $("#dialog").dialog({
                        modal: true,
                        close: function () {
                            __doPostBack('PageNavigator1$LnkBtnGoto', '');
                        }
                    }); 
                }

            }
        });
    }

    function JsPublic() {
        var stat = document.getElementById("publicStat");
        stat.innerHTML = "正在更新js...";
        var ids = GetSelected();
        if (ids == "") {
            alert("至少您要选择一条JS");
            return;
        }
        $.get("JS_Publish.aspx?ids=" + ids + "&rd=" + Math.random(), function (responseText) {
            stat.innerHTML = "";
            alert(responseText);
        });
    }



    function GetSelected() {
        var ret = '';
        var tab = document.getElementById('TabData');
        for (var i = 1; i < tab.rows.length; i++) {
            var td = tab.rows[i].cells[5];
            for (var j = 0; j < td.childNodes.length; j++) {
                var obj = td.childNodes[j];
                if (obj.type == 'checkbox') {
                    if (obj.checked) {
                        if (ret != '')
                            ret += ',';
                        ret += obj.value;
                    }
                    break;
                }
            }
        }
        return ret;
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<div id="dialog" title="代码"></div>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>JS管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>JS管理
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能：</span><a href="JSAdd.aspx">新增</a>┊
        <a href="javascript:DeleteJSs();" >删除选中</a>┊
       <asp:LinkButton ID="LnkBtnALL" runat="server" OnClick="LnkBtnALL_Click">所有JS</asp:LinkButton>┊
      <asp:LinkButton ID="LnkBtnSys" runat="server"  OnClick="LnkBtnSys_Click">系统JS</asp:LinkButton>┊
      <asp:LinkButton ID="LnkBtnFree" runat="server" OnClick="LnkBtnFree_Click">自由JS</asp:LinkButton>┊
      <a href="javascript:JsPublic();" >发布JS</a><span id="publicStat" style="color:Red;"></span>
      </div>
      <div class="jslie_lie">
      <asp:Repeater ID="rptjs" runat="server">
      <HeaderTemplate>
         <table class="jstable" id="TabData">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="30%" align="left"><span class="span1">名称</span></th>
               <th width="15%">类型</th>
               <th width="15%">代码</th>
               <th width="10%">新闻条数</th>
               <th width="15%">创建时间</th>
               <th width="15%">操作<input type="checkbox" name="checkboxs" /></th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td class="jstd"><span class="span1"><%# Eval("JSName")%></span></td>
              <td align="center"><%# Eval("type") %></td>
              <td align="center" class="jstd"><%# Eval("code") %></td>
              <td align="center"><%# Eval("number") %></td>
              <td align="center"><%# Eval("CreatTime")%></td>
              <td align="center">
                  <%# Eval("edit") %>
              </td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
         </table>  
         </FooterTemplate>   
         </asp:Repeater>   
         <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>

      </div>
   </div>
</div>
</div>
<asp:HiddenField ID="HidType" runat="server" />
</form>
</body>
</html>

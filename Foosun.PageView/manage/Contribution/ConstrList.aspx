<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConstrList.aspx.cs" Inherits="Foosun.PageView.manage.Contribution.ConstrList" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>稿件列表</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        $("input[name='checkbox']").click(function () {
            if (this.checked) {
                $("input[name='Checkbox1']").attr('checked', true);
            }
            else {
                $("input[name='Checkbox1']").attr('checked', false);
            }
        });
    });
    function del(ID) {
        $("#dialog").html("你确定要删除吗？删除后将不能恢复！");
        $("#dialog").dialog({
            width: 400,
            buttons: {
                "确定": function () {
                    PostForm("Type=del&ID=" + ID)
                    $(this).dialog("close");
                },
                "退出": function () {
                    $(this).dialog("close");
                }
            }
        }); 
    }
    function PDel() {
        var idlist = "";
        $('input[type="checkbox"][name="Checkbox1"]').each(function () {
            if (this.checked) {
                idlist += $(this).val() + ",";
            }
        });
        if (idlist.length > 0) {
            idlist = idlist.substring(0, idlist.length - 1);
        }
        else {
            $("#dialog").html("请选择要删除的稿件！");
            $("#dialog").dialog({
               
            });
            return;
        }
        $("#dialog").html("你确定要删除吗？删除后将不能恢复！");
        $("#dialog").dialog({
            width: 400,
            buttons: {
                "确定": function () {                   
                    PostForm("Type=PDel&Checkbox1=" + idlist);
                    $(this).dialog("close");
                },
                "退出": function () {
                    $(this).dialog("close");
                }
            }
        });
    }
    function PostForm(datas) {
        $.ajax({
            type: "POST",
            url: "ConstrList.aspx",
            async: false,
            //是否ajax同步       
            data: datas,
            success: function (data) {
                $("#msgdialog").html("<div class=\"msgboxs\">"+data+"</div>");
                $("#msgdialog").dialog({
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
      <div class="mian_wei_left"><h3>投稿管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>稿件管理 >>
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span><a href="ConstrList.aspx">稿件管理</a>┊<a href="ConstrStat.aspx"> 稿件统计</a>┊<a href="ConstrList.aspx?type=cheack">所有通过审核稿件</a>┊<a href="javascript:PDel()">批量删除</a></span>
      </div>
      <div class="jslie_lie">
      <div id="no" runat="server"></div>
        <asp:Repeater ID="DataList1" runat="server" >
        <HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="27%" align="left"><span class="span1">稿件标题</span></th>
               <th width="10%">投稿时间</th>
               <th width="7%">类型</th>
               <th width="7%">信息级</th>
               <th width="10%">发布者</th>
               <th width="7%">退稿</th>
               <th width="7%">状态</th>
               <th width="25%">操作 <input type="checkbox" name="checkbox"  value=""/></th>
            </tr>
          </HeaderTemplate>
          <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td><span class="span1"><%#Eval("Title") %></span></td>
              <td align="center"><%#Eval("ctim")%></td>
              <td align="center"><%#Eval("Source")%></td>
              <td align="center"><%#Eval("info")%></td>
              <td align="center"><%#Eval("Author")%></td>
              <td align="center"><%#Eval("ispassa")%></td>
              <td align="center"><%#Eval("lock")%></td>
              <td align="center">
                <%#Eval("handle")%>
              </td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
         </table>
         </FooterTemplate>
         </asp:Repeater>
         <div class="fanye1">
         <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
      </div>
      </div>
   </div>
</div>
</div>
<div id="dialog" title="提示"></div>
<div id="msgdialog" title="提示"></div>
</form>
</body>
</html>

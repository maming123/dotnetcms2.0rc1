<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSNews.aspx.cs" Inherits="Foosun.PageView.manage.jsmodel.JSNews" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>JS新闻</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/public.js"></script>
     <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
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
    function RemoveJS(id) {
        if (confirm("你确定要删除？")) {
            PostForm("Option=RemoveJS&ID=" + id);
        }
    }
    function DeleteJS() {
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
                $('#dialog-message').html("没有选择任何新闻！");
                $("#dialog-message").dialog({
                    modal: true,
                    close: function () {
                        return;
                    }
                });
                return;
            }
            if (confirm("你确定要删除？")) {
                PostForm("Option=RemoveAllJS&idList=" + idlist);
            }
    }
    function PostForm(datas) {
        $.ajax({
            type: "POST",
            url: "JSNews.aspx",
            async: false,
            //是否ajax同步       
            data: datas,
            success: function (data) {
                $("#dialog-message").html("<div class=\"msgboxs\">"+data+"</div>");
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
  <div id="dialog-message" title="提示"></div>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>JS新闻列表</h3></div>
      <div class="mian_wei_right">
        
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能： <a href="javascript:self.close();" class="topnavichar">关闭</a>┊
      <a href="javascript:DeleteJS(-1);" class="topnavichar">删除选中</a>
      </div>
      <div class="jslie_lie">
      <asp:Repeater ID="RptData" runat="server">
      <HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="80%" align="left"><span class="span1">新闻标题</span></th>
               <th width="20%">操作<input type="checkbox" name="checkboxs" /></th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
              <td class="jstd"><span class="span1"><%# Eval("Njf_title")%></span></td>
              <td align="center">
                  <a href="javascript:RemoveJS(<%# Eval("ID")%>);" class="xa3"><img src="../imges/lie_65.gif" alt="彻底删除"></a><input type="checkbox" name="checkbox" value="<%# Eval("ID")%>"/>
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
<asp:HiddenField ID="HidJsID" runat="server" />
</form>
</body>
</html>
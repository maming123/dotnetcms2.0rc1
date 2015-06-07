<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="syslabelbak.aspx.cs" Inherits="Foosun.PageView.manage.label.syslabelbak" %>
<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>标签备份库</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
 <script type="text/javascript" language="javascript">
     function Rec(id) {
         if (confirm('你确认恢复此标签吗?')) {           
             $.ajax({
                 type: "POST",
                 url: "syslabelbak.aspx",
                 async: false,
                 //是否ajax同步       
                 data: "Op=Rec&LabelID=" + id,
                 success: function (data) {
                     $("#dialog-message").html(data);
                     $("#dialog-message").dialog({
                         modal: true,
                         close: function () {
                             __doPostBack('PageNavigator1$LnkBtnGoto', '');
                         }
                     });
                 }
             });
         }
     }
 </script>
</head>
<body>
<div id="dialog-message" title="提示"></div>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>标签备份库</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="syslabelList.aspx">标签管理</a> >>标签备份库
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="jslie_lie">
         <asp:Repeater ID="DataList1" runat="server">
         <HeaderTemplate>
           <table class="jstable">
              <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                 <th width="25%">编号</th>
                 <th width="25%">分类名称</th>
                 <th width="25%">创建日期</th>
                 <th width="25%">操作</th>
              </tr>
              </HeaderTemplate>
              <ItemTemplate>
              <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                  <td><%#Eval("LabelID")%></td>
                  <td><%#Eval("Label_Name")%></td>
                  <td align="center"><%#Eval("CreatTime")%></td>
                  <td align="center">
                     <%#Eval("Op")%>
                  </td>
              </tr>
              </ItemTemplate><FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="fanye">
          <div class="bqsosuo">
            
          </div>
          <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
          </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>


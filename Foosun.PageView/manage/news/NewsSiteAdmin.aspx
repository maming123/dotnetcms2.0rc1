<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsSiteAdmin.aspx.cs" Inherits="Foosun.PageView.manage.news.NewsSiteAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>新闻统计</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#sdatepicker").datepicker({changeMonth: true,changeYear: true});
        $("#edatepicker").datepicker({changeMonth: true,changeYear: true});
    });    
    function check() {
        if (!IsNum($('#numtop').val())) {
            showdialog("条数不是整数！请检查后在搜索！");
            $('#numtop').focus();
            return false;
        }
        else {
            return true;
        }
    }
    function checktime() {
        if (check()!=true) {
            return false;
        }
        if ($('#sdatepicker').val() == "" || $('#edatepicker').val() == "") {
            showdialog("时间不能为空!");
            return false;
        }
        if (new Date($('#edatepicker').val().replace(/\-/g, "\/")) - new Date($('#sdatepicker').val().replace(/\-/g, "\/")) < 0) {
            showdialog("开始日期不能大于结束日期!");
            return false;
        }
    }
    function IsNum(num) {
        var reNum = /^\d*$/;
        return (reNum.test(num));
    }
    function showdialog(msg) {
        $("#dialog-message").html("<div class=\"msgboxs\">"+msg+"</div>");
        $("#dialog-message").dialog({
            modal: true
        });
    }
</script>
</head>

<body>
 <div id="dialog-message" title="提示"></div>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>新闻统计</h3></div>
      <div class="mian_wei_right">
          导航：<a  href="javascript:openmain('../main.aspx')">首页</a>>>新闻统计
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
       <div class="newxiu_lan">
          <ul class="tab_zzjs_" id="tab_zzjs_">
          <% if (Request.QueryString["type"] == "newsClick")
             {
                 %>
                   <li class="nor_zzjs"><a href="NewsSiteAdmin.aspx">新闻统计</a></li>
                  <li class="hovertab_zzjs"><a href="?type=newsClick">新闻点击量统计</a></li>
                 <%
              }
             else
             { %>
              <li class="hovertab_zzjs"><a href="NewsSiteAdmin.aspx">新闻统计</a></li>
             <li class="nor_zzjs"><a href="?type=newsClick">新闻点击量统计</a></li>
           <%} %>
          </ul>
          <div class="newxiu_bot">
             <div class="dis_zzjs_net">
                <div class="newxiu_base">
                   <div class="trash">
                        <asp:Label ID="lblstime" runat="server" Text=""></asp:Label>至
                        <asp:Label ID="lbletime" runat="server" Text=""></asp:Label>
                   </div>
                   <div class="jslie_lie">
                       <asp:Repeater ID="Stat" runat="server">
                     <HeaderTemplate>
                   <table class="jstable" align="center" cellspacing="1">
                      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                         <th width="60%">管理员</th>
                         <th width="40%">发布新闻数</th>
                      </tr>
                      </HeaderTemplate>
                      <ItemTemplate>
                      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                         <td align="center"><%#Eval("Editor")%></td>
                         <td align="center"><%#Eval("NewsCount")%></td>
                      </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                   </table>
                   </FooterTemplate>
                   </asp:Repeater>
                   <asp:Repeater runat="server" ID="ClickList">
                     <HeaderTemplate>
                   <table class="jstable">
                      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                         <th width="40%">新闻标题 </th>
                         <th width="20%">点击量 </th>
                         <th width="20%">发布时间 </th>
                         <th width="20%">发布人 </th>
                      </tr>
                      </HeaderTemplate>
                      <ItemTemplate>
                      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                         <td><span class="span1"> <%#Eval("NewsTitle")%></span></td>
                         <td align="center"><%#Eval("Click")%></td>
                         <td align="center"> <%#Eval("CreatTime")%></td>
                         <td align="center"><%#Eval("Editor")%></td>
                      </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                   </table>
                   </FooterTemplate>
                   </asp:Repeater>
                   </div>
                </div>
             </div>           
             <div class="newstat">
                <span>搜索前条</span><input type="text" name="" id="numtop" runat="server" value="50" class="xinput1"/>条
                <span>开始时间:</span><input type="text" id="sdatepicker" runat="server" name="" value="" readonly="readonly"/>
                <span>结束时间:</span><input type="text" id="edatepicker" runat="server" name="" value="" readonly="readonly"/>
                <asp:Button ID="btnsearch" runat="server" Text="搜索" class="xsubmit1" 
                     onclick="btnsearch_Click" CausesValidation="False" OnClientClick="javascript:return checktime()"/>
                <asp:Button ID="btnyear" runat="server" Text="本年排行" class="xsubmit1" 
                     onclick="btnyear_Click"  CausesValidation="False" OnClientClick="javascript:return check()"/>
                <asp:Button ID="btnmonth" runat="server" Text="本月排行" class="xsubmit1" 
                     onclick="btnmonth_Click" CausesValidation="False" OnClientClick="javascript:return check()"/>
                <asp:Button ID="btnweek" runat="server" Text="本周排行" class="xsubmit1" 
                     onclick="btnweek_Click" CausesValidation="False" OnClientClick="javascript:return check()"/>
                <asp:Button ID="btnday" runat="server" Text="本日排行" class="xsubmit1" 
                     onclick="btnday_Click" CausesValidation="False" OnClientClick="javascript:return check()"/>                
             </div>
          </div>
       </div>
   </div>
</div>
</div>
</form>
</body>
</html>

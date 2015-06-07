<%@ Page Language="C#" AutoEventWireup="true" Inherits="Collect_RuleList" Codebehind="Collect_RuleList.aspx.cs" %>

<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>FoosunCMS For .NET v1.0.0</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script language="javascript" type="text/javascript" src="/Scripts/jquery.js"></script> <script src="/Scripts/public.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
 function DeleteMe(id)
 {
     if (window.confirm('您确定要删除该规则吗？数据将不能再恢复！')) {
         var param = 'Option=DeleteRule&ID=' + id;
		$.get("Collect_RuleList.aspx?" + param + "&md=" + Math.random(), function (transport) {
		    OnRecv(transport);
        });
    }
 }
 function OnRecv(retv)
 {
     var n = retv.indexOf('%');
    if(parseInt(retv.substr(0,n)) > 0)
    {
        __doPostBack('PageNavigator1$LnkBtnGoto','');
    }
 }
    </script>

</head>
<body>
    <form id="Form2" runat="server">
    <div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>采集系统 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="Collect_List.aspx">采集系统</a> >>关键字过滤
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <span>功能：</span><a class="topnavichar" href="Collect_RuleAdd.aspx">新建规则</a>┋<a class="topnavichar" href="Collect_List.aspx">站点设置</a>┋<a class="topnavichar" href="Collect_News.aspx">新闻处理</a>
      </div>
      <div class="jslie_lie">
      <asp:Repeater runat="server" ID="RptRule">
                <HeaderTemplate>
                    <table class="jstable">
                        <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                           <th width="50%">规则名称</th>
                           <th width="20%">创建时间</th>
                           <th width="30%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr onmouseover="this.className='on'"onmouseout="this.className='off'">
                        <td>
                            <span class="span1"><%# DataBinder.Eval(Container.DataItem, "RuleName")%></span>
                        </td>
                        <td align="center">
                            <%# DataBinder.Eval(Container.DataItem, "AddDate")%>
                        </td>
                        <td align="center">
                            <a href="Collect_RuleAdd.aspx?RID=<%# DataBinder.Eval(Container.DataItem, "ID")%>"
                                class="xa3">修改</a> <a href="javascript:DeleteMe(<%# DataBinder.Eval(Container.DataItem, "ID")%>);"
                                    class="xa3">彻底删除</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField runat="server" ID="HidFolderID" Value="" />
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

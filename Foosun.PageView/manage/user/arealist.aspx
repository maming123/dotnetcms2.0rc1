<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="utf-8" AutoEventWireup="true" Inherits="manage_user_arealist" Codebehind="arealist.aspx.cs" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<script type="text/javascript" language="javascript">
    $(function () {
        $("input[name='Checkboxc']").click(function () {
            if (this.checked) {
                $("input[name='Checkbox1']").attr('checked', true);
            }
            else {
                $("input[name='Checkbox1']").attr('checked', false);
            }
        });
    });
</script>
</head>
<body>
<form id="form1" name="form1" method="post" action="" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>地域管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>地域管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
       <a href="arealist.aspx" class="menulist">大类</a> |<a href="arealist_add.aspx" class="menulist">添加大类</a>|<span class="topnavichar" style="PADDING-right: 25px" id="pdel" runat="server"></span>
      </div>
      <div class="jslie_lie">
      <span id="no" runat="server"></span>
     <asp:Repeater ID="DataList1" runat="server" >
		<HeaderTemplate>
         <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="20%">类别名称</th>
               <th width="20%">创建日期</th>
               <th width="40%">操作 <input type="checkbox" name="Checkboxc"  value=""/></th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
           <%#((DataRowView)Container.DataItem)["cm"]%>
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
</form>
</body>
<script language="javascript" type="text/javascript">
function del(ID)
{
   if(confirm("你确定要删除吗?"))
   { 
        self.location="?Type=del&ID="+ID;
   }
}
function PDel()
{
    if(confirm("你确定要彻底删除吗?"))
    {
	    document.form1.action="?Type=PDel";
	    document.form1.submit();
	}
}
</script>
</html>
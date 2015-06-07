<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineTableManage.aspx.cs" Inherits="Foosun.PageView.manage.sys.DefineTableManage" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
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
<script type="text/javascript" language="javascript">
    $(function () {
        $("input[name='Checkboxc']").click(function () {
            if (this.checked) {
                $("input[name='define_checkbox']").attr('checked', true);
            }
            else {
                $("input[name='define_checkbox']").attr('checked', false);
            }
        });
    });
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>自定义自段管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>自定义字段管理
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li><a href="DefineTableManage.aspx">分类管理</a>┊</li>
            <li><a href="DefineTable.aspx">新增字段</a>┊</li>
            <li><a href="?action=add">新增分类</a>┊</li>
            <li><asp:LinkButton ID="delall" runat="server" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="delall_Click">删除全部</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="DelP" runat="server"  OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除</asp:LinkButton>┊</li>
         </ul>
      </div>
      <div class="jslie_lie" id="listcontent">
        <asp:Repeater ID="DataList1" runat="server">
      <HeaderTemplate>
               <table class="jstable">
            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="35%">分类名称</th>
               <th width="20%">查看自定义字段</th>
               <th width="20%" align="center">新增自定义字段</th>
               <th width="25%">属性 <input type="checkbox" name="Checkboxc"  value=""/></th>
            </tr>
            </HeaderTemplate>
             <ItemTemplate>          
                 <%#((DataRowView)Container.DataItem)["Colum"]%> 
         </ItemTemplate>
      <FooterTemplate>
        </table>
      </FooterTemplate>
    </asp:Repeater>
      </div>
      <div class="fanye" id="listfanye">
         <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
      </div>
      <div class="newxiu_base" id="Showdisplay">
           <table class="nxb_table">
             <tr>
                <td colspan="2"><font>新增自定义字段分类信息</font></td>
             </tr>
             <tr>
               <td width="15%" align="right">上一级自定义字段编号：</td>
               <td>                 
                  <asp:TextBox ID="PraText" runat="server" Enabled="false" class="input8"></asp:TextBox>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">分类名称：</td>
               <td>                   
                   <asp:TextBox ID="NewText" runat="server" class="input8"></asp:TextBox>
               </td>
             </tr>
           </table>
            <div class="nxb_submit" >
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交数据" class="xsubmit1 mar" />
                 <input type="reset" name="" value="重置"  class="xsubmit1 mar"/>
                 <asp:HiddenField ID="suid" runat="server" />
             </div>
        </div>
   </div>
</div>
</div>
</form>
<script language="javascript" type="text/javascript">
    var url = '<%Response.Write(Request.QueryString["action"]);%>';
    if (url == "add" || url == "add_clildclass") {
        document.getElementById("Showdisplay").style.display = "";
        document.getElementById("listcontent").style.display = "none";
        document.getElementById("listfanye").style.display = "none";
    }
    else {
        document.getElementById("Showdisplay").style.display = "none";
        document.getElementById("listcontent").style.display = "";
        document.getElementById("listfanye").style.display = "";
    }
</script>

</body>
</html>

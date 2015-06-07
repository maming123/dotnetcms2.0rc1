<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_info_collection"  ResponseEncoding="utf-8" Codebehind="collection.aspx.cs" %>
<%@ Import NameSpace="System.Data"%>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
        
    <title>收藏</title>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("input[name='Checkbox2']").click(function () {
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
<body class="main_big"><form id="form1" runat="server">
    <table id="top1" width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
            <tr>
              <td height="1" colspan="2"></td>
            </tr>
            <tr>
              <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">收藏夹管理</strong></td>
             <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" class="list_link" target="sys_main">首页</a><img alt="" src="../images/navidot.gif" border="0" /><a href="#" class="list_link" target="sys_main">收藏夹管理</a><img alt="" src="../images/navidot.gif" border="0" />收藏夹列表</div></td>
            </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
      <tr>
        <td  style="padding-left:12px;"><div id="sc" runat="server"></div></td>
      </tr>
      </table>
      <div id="no" runat="server"></div>
 <table width="100%" align="center">
 <tr><td>
<div>   
    <asp:Repeater ID="DataList1" runat="server">
       <HeaderTemplate>
        <table width="100%" border="0" align="center" cellpadding="4" cellspacing="1" class="liebtable">
            <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
            <th class="sys_topBg" align="center">标题</th>
            <th class="sys_topBg" align="center">收藏日期</th>
            <th class="sys_topBg" align="center">操作<input type="checkbox" name="Checkbox2"/></th>
            </tr>
        </HeaderTemplate>
          <ItemTemplate>
            <tr onmouseout="this.className='off'" onmouseover="this.className='on'" class="off">
            <td align="center"><%#((DataRowView)Container.DataItem)["titleUrl"]%></td>
            <td align="center"><%#((DataRowView)Container.DataItem)["CreatTime"]%></td>
            <td align="center"><%#((DataRowView)Container.DataItem)["Operation"]%></td>
            </tr>
          </ItemTemplate>
          <FooterTemplate>
          </table>
         </FooterTemplate>
    </asp:Repeater> 
</div>
</td></tr>
<tr><td align="right" style="width: 928px">
    <uc1:PageNavigator ID="PageNavigator1" runat="server" />
</td></tr>
</table>  
 <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
   <tr>
     <td align="center"><%Response.Write(CopyRight); %> </td>
   </tr>
</table>
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
function API(ID)
{
    document.form1.action="?APIID="+ID;
    document.form1.submit();
}
</script>
</html>
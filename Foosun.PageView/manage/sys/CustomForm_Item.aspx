<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CustomForm_Item.aspx.cs" Inherits="Foosun.PageView.manage.Sys.CustomForm_Item" %>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
       <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
<!--
function DeleteItem(id)
{
    if (window.confirm('你确定要删除该表单项吗?数据将不能被恢复!')) {
        jQuery.get('CustomForm_Item.aspx?Option=DeleteItem&ID=' + id, function (retv) {
            location.href = location.href;
        });
    }
}
//-->
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mian_body">
            <div class="mian_wei">
            <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>自定义表单管理</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')" target="sys_main" class="topnavichar">首页</a>>>
                  <a href="CustomForm.aspx" class="topnavichar">自定义表单</a>>>
                  <asp:Literal runat="server" ID="LtrFormName"></asp:Literal>>>表单项管理
              </div>
           </div>
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="jslie_lan">
                    <asp:HyperLink ID="HlkCreate" runat="server" class="topnavichar">新建表单项</asp:HyperLink>
              </div>
                <div class="jslie_lie">
            <asp:Repeater ID="RptData" runat="server">
                <HeaderTemplate>
                    <table id="tablist" class="jstable">
                        <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                            <th width="5%">
                                顺序</th>
                            <th width="20%">
                                表单项名</th>
                            <th width="20%">
                                字段名</th>
                            <th width="20%">
                                字段类型</th>
                            <th width="20%">
                                是否必填</th>
                            <th width="15%">
                                操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "seriesnumber")%>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "itemname")%>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "fieldname")%>
                        </td>
                        <td>
                            <%# GetTypeName(DataBinder.Eval(Container.DataItem, "itemtype"))%>
                        </td>
                        <td align="center">
                            <%# DataBinder.Eval(Container.DataItem, "notnull")%>
                        </td>
                        <td align="center">
                            <a class="xa3" href="CustomForm_Item_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "id")%>">修改</a> 
                            <a class="xa3" href="javascript:DeleteItem(<%# DataBinder.Eval(Container.DataItem, "id")%>);">删除</a>
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
    </form>
</body>
</html>

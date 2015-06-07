<%@ Page Language="C#" AutoEventWireup="true" Inherits="Collect_News" CodeBehind="Collect_News.aspx.cs" %>

<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>FoosunCMS For .NET v1.0.0</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
<!--
        function GetAllChecked() {
            var retstr = "";
            var tb = document.getElementById("tablist");
            var j = 0;
            for (var i = 1; i < tb.rows.length - 1; i++) {
                var objtr = tb.rows[i];
                var objtd = objtr.cells[0];
                var objnd = objtd.childNodes[0];
                if (objnd.type == "checkbox" && objnd.checked) {
                    if (j > 0)
                        retstr += ",";
                    retstr += objnd.value;
                    j++;
                }
            }
            return retstr;
        }
        function GetAllHistoryNews()//已入库的新闻
        {
            var retstr = "";
            var tb = document.getElementById("tablist");
            var j = 0;
            for (var i = 1; i < tb.rows.length - 1; i++) {
                var objtr = tb.rows[i];
                var objtd = objtr.cells[2];
                var objtdid = objtr.cells[0];
                var objnd = objtdid.childNodes[0];
                if (objtd.innerText == "已入库") {
                    if (j > 0)
                        retstr += ",";
                    retstr += objnd.value;
                    j++;
                }
            }
            return retstr;
        }
        function Transfer(id) {
            var l;
            var m = "所有未入库";
            if (id == -1) {
                l = GetAllChecked();
                if (l == "") {
                    alert("您没有选择要入库的新闻!");
                    return;
                }
                m = "选中";
            }
            else if (id == 0) {
                l = id;
            }
            if (confirm('确定要入库' + m + '的新闻吗?')) {
                location.href = 'Store.aspx?ID=' + l;
            }
        }
        function DeleteCllNews(id) {
            var option = "DeleteNews";
            var l;
            var m = '当前';
            if (id == -1) {
                l = GetAllChecked();
                if (l == "") {
                    alert("您没有选择要删除的新闻!");
                    return;
                }
                m = "选中";
            }
            else if (id == 0) {
                m = "所有已入库";
                // l = id;
                option = "DeleteAllHistory";
                l = GetAllHistoryNews();
            }
            else {
                l = id;
            }
            if (confirm('确定要永久删除' + m + '新闻吗?数据将不能恢复!')) {
                SendAjax(option, l);
            }
        }

        function SendAjax(op, id) {
            var param = 'Option=' + op + '&NewsID=' + id + '&rd=' + Math.random();
            jQuery.get("Collect_News.aspx?" + param, function (transport) {
                location.href = location.href;
            });
        }

        function ChooseAll(obj) {
            var flag = obj.checked;
            var tb = document.getElementById("tablist");
            for (var i = 1; i < tb.rows.length - 1; i++) {
                var objtr = tb.rows[i];
                var objtd = objtr.cells[0];
                var objnd = objtd.childNodes[0];
                if (objnd.type == "checkbox")
                    objnd.checked = flag;
            }
        }
//-->
    </script>
</head>
<body>
    <form id="Form2" runat="server">
    <div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>采集系统 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="Collect_List.aspx">采集管理</a> >>采集新闻处理 
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
         <span>功能：</span>
         <a class="topnavichar" href="Collect_List.aspx">站点管理</a>┋<a class="topnavichar" href="Collect_RuleList.aspx">关键字过滤</a>
      </div>
      <div class="jslie_lie">
        <asp:Repeater ID="RptNews" runat="server" OnItemDataBound="RptNews_ItemDataBound">
            <HeaderTemplate>
                <table class="jstable" id="tablist">
                    <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                       <th width="5%"></th>
                       <th width="40%">规则名称</th>
                       <th width="10%">状态</th>
                       <th width="15%">采集站点</th>
                       <th width="15%">添加日期</th>
                       <th width="15%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr onmouseover="this.className='on'"onmouseout="this.className='off'">
                    <td align="center">
                        <input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem, "ID")%>" />
                    </td>
                    <td>
                        <span class="span1"><%# DataBinder.Eval(Container.DataItem, "Title")%></span>
                    </td>
                    <td align="center">
                        <asp:Label runat="server" ID="LblState" Text='<%# DataBinder.Eval(Container.DataItem, "History")%>' />
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "SiteName")%>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "AddDate")%>
                    </td>
                    <td align="center">
                        <a href="Collect_NewsModify.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>">修改</a> <a href="javascript:DeleteCllNews(<%# DataBinder.Eval(Container.DataItem, "ID")%>);"
                                   >
                                    <img src="../imges/lie_65.gif" border="0" alt="彻底删除" /></a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr class="TR_BG_list">
                    <td colspan="7">
                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                 <td width="5%" align="center">
                                    <input type="checkbox" onclick="ChooseAll(this)" />
                                </td>                               
                                <td width="40%" align="left">
                                    <span class="span1">选中所有</span>
                                </td>
                                <td colspan="55%" align="right" valign="top">
                                    <input type="button" class="xsubmits" name="BnRecyle" value="删除所有已入库新闻" onclick="DeleteCllNews(0);" />
                                    <input type="button" class="xsubmits" name="BnDelete" value="入库所有未入库新闻" onclick="Transfer(0);" />
                                    <input type="button" class="xsubmits" name="BnProperty" value="入库选中新闻" onclick="Transfer(-1)" />
                                    <input type="button" class="xsubmits" name="BnMove" value="删除选中新闻" onclick="DeleteCllNews(-1)" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
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

<%@ Page Language="C#" AutoEventWireup="true" Inherits="SpecialList" ResponseEncoding="utf-8"
    CodeBehind="SpecialList.aspx.cs" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="../../controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"
        rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>专题管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')" target="sys_main" class="xa3">首页</a><span id="naviClassName" runat="server" />>><label id="m_NewsChar" runat="server" /> 
      </div>
   </div>
</div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="lanlie">
                    <div class="zhlie_left">
                        <a href="SpecialAdd.aspx" class="topnavichar">添加专题</a></div>
                    <div class="zhlie_right">
                        <a href="javascript:PDel();" class="topnavichar">彻底删除</a>&nbsp;┊&nbsp;<a href="javascript:PRDel();"
                            class="topnavichar">删除到回收站</a>&nbsp;┊&nbsp;<a href="javascript:PUnlock();" class="topnavichar">批量解锁</a>&nbsp;┊&nbsp;<a
                                href="javascript:Plock();" class="topnavichar">批量锁定</a>&nbsp;┊&nbsp;<a href="javascript:Publish();"
                                    class="topnavichar">生成静态文件</a>&nbsp;┊&nbsp;<a href="SpecialTemplet.aspx" class="topnavichar">批量捆绑模板</a>
                        <span id="channelList" runat="server" style="display: none;" />
                    </div>
                </div>
                <div class="nwelie_lan2">
                    搜索专题名称：<asp:TextBox ID="search_SpecialCName" runat="server" class="xinput2"></asp:TextBox><asp:Button
                        ID="search_button" runat="server" Text="查询" OnClick="search_button_Click" class="xsubmit2" />
                </div>
                <div class="lanlie_lie">
                    <asp:Repeater ID="DataList1" runat="server">
                        <HeaderTemplate>
                            <table class="lanlie_table">
                                <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                                    <th width="30%">
                                        专题名称
                                    </th>
                                    <th width="15%">
                                        添加时间
                                    </th>
                                    <th  width="10%">
                                        状态
                                    </th>
                                    <th width="15%">
                                        专题新闻信息
                                    </th>
                                    <th width="30%">
                                        操作
                                        <input type="checkbox" value="'-1'" name="S_ID" id="S_ID" onclick="javascript:selectAll(this.form,this.checked)" />
                                    </th>
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
                <div class="fanye">
                    <div class="fanye_le">
                        <uc1:PageNavigator ID="PageNavigator1" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    function Lock(ID) {
        self.location = "?Type=Lock&ID=" + ID;
    }
    function UnLock(ID) {
        self.location = "?Type=UnLock&ID=" + ID;
    }
    function Del(ID) {
        if (confirm('你确认删除此专题\n以及此专题的子专题吗?')) {
            self.location = "?Type=Del&ID=" + ID;
        }
    }
    function Update(ID) {
        self.location = "SpecialEdit.aspx?ID=" + ID;
    }
    function AddChild(ID) {
        self.location = "SpecialAdd.aspx?parentID=" + ID;
    }

    function PDel() {
        if (confirm("你确定要彻底删除吗?\r此操作将会删除选中的专题\r以及选中专题的子专题\r删除之后将无法恢复！")) {
            document.form1.action = "?Type=PDel&Mode=Del";
            document.form1.submit();
        }
    }
    function PUnlock() {
        if (confirm("你确定要批量解锁吗?")) {
            document.form1.action = "?Type=PUnlock";
            document.form1.submit();
        }
    }
    function Plock() {
        if (confirm("你确定要批量锁定吗?\r此操作将会锁定选中的专题\r以及选中专题的子专题")) {
            document.form1.action = "?Type=Plock";
            document.form1.submit();
        }
    }
    function PRDel() {
        if (confirm("你确定要删除到回收站吗?\r此操作将会把选中的专题\r以及选中专题的子专题放入到回收站中\r删除之后可以从回收站中恢复！")) {
            document.form1.action = "?Type=PDel&Mode=Re";
            document.form1.submit();
        }
    }

    function Publish() {
        document.form1.action = "?Type=Publish";
        document.form1.submit();
    }

    function getchanelInfo(obj) {
        var SiteID = obj.value;
        window.location.href = "SpecialList.aspx?SiteID=" + SiteID + "";
    }
</script>
</html>

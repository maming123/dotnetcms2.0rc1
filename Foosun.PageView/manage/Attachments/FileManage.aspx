<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManage.aspx.cs" Inherits="Foosun.PageView.manage.Attachments.FileManage" %>
<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>附件管理</title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            $("#txtBeginDate").datepicker({changeMonth: true,changeYear: true});
            $("#txtEndDate").datepicker({changeMonth: true,changeYear: true});
        });

        function checktime() {
            if (check() != true) {
                return false;
            }
            if ($('#txtBeginDate').val() == "" || $('#txtEndDate').val() == "") {
                showdialog("时间不能为空!");
                return false;
            }
            if (new Date($('#txtEndDate').val().replace(/\-/g, "\/")) - new Date($('#txtBeginDate').val().replace(/\-/g, "\/")) < 0) {
                showdialog("开始日期不能大于结束日期!");
                return false;
            }
        }

        function PDel() {
            if (confirm("你确定要彻底删除吗?\r此操作将会删除选中的附件\r删除之后将无法恢复！")) {
                document.form1.action = "?Action=del";
                document.form1.submit();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
            <div class="mian_wei_min">
                <div class="mian_wei_left">
                    <h3>
                        附件管理</h3>
                </div>
                <div class="mian_wei_right">
                    导航：<a href="javascript:openmain('../main.aspx')">首页</a>&gt;&gt;附件管理
                </div>
            </div>
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="tugli_lan">
                    <span>搜索：</span>上传时间：<asp:TextBox ID="txtBeginDate" CssClass="input8" runat="server" ReadOnly="true"></asp:TextBox>至<asp:TextBox
                        ID="txtEndDate" CssClass="input8" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" CssClass="inpsublit" 
                        onclick="Button1_Click" OnClientClick="checktime()" /><a href="javascript:PDel();">批量删除</a>
                </div>
                <div class="jslie_lie">
                    <table class="jstable">
                        <asp:Repeater ID="rpt_list" runat="server">
                            <HeaderTemplate>
                                <tr class="off" onmouseover="this.className='on'" onmouseout="this.className='off'">
                                    <th width="20%">
                                        文件名称
                                    </th>
                                    <th width="20%">
                                        文件类型
                                    </th>
                                    <th width="20%">
                                        上传日期
                                    </th>
                                    <th width="20%">
                                        文件大小
                                    </th>
                                    <th width="20%">
                                        操作
                                        <input type="checkbox" value="'-1'" name="ids" id="ids" onclick="javascript:selectAll(this.form,this.checked)" />
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="off" onmouseover="this.className='on'" onmouseout="this.className='off'">
                                    <td align="center">
                                        <%# Eval("FileName")%>
                                    </td>
                                    <td align="center">
                                        <%# Common.FileAction.GetFileType(Eval("FileName").ToString())%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("UploadDate")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("FileSize")%>
                                    </td>
                                    <td align="center">
                                        <a href='FileManage.aspx?Action=del&ids=<%# Eval("Id")%>'>删除</a>
                                        <input type="checkbox" name="chk" id="chk" value='<%# Eval("Id")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        
                        
                    </table>
                    <div class="fanye1">
                        <div class="fanye_le">
                            <uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
                    </div>
                    
                </div>
                <div>
                    注：此处管理的附件为通过网站上传文件。
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

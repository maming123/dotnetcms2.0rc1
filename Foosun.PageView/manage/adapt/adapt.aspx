<%@ Page Language="C#" AutoEventWireup="true" Codebehind="adapt.aspx.cs" Inherits="Foosun.PageView.manage.adapt.adapt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>接口整合</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>整合接口</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>整合接口
              </div>
           </div>
        </div>
        <div class="lanlie_lie">
         <div class="newxiu_base">
        <table class="nxb_table" id="TableDis">
            <tr>
                <td width="20%" align="right">
                    <div align="right">
                        是否开启整合:</div>
                </td>
                <td style="height: 23px">
                    <asp:CheckBox ID="Api_Enable" runat="server" CssClass="checkbox2" /><span class="helpstyle" style="cursor: help;"
                        title="点击查看帮助" onclick="Help('H_navimenu_0005',this)">帮助</span></td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    <div align="right">
                        应用程序标识:</div>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAppID" runat="server" CssClass="input8" Style="width: 350px"></asp:TextBox>
                    <span class="helpstyle" style="cursor: help;" title="点击查看帮助" ">
                        <!--onclick="Help('H_navimenu_0003',this)height="32"-->
                        帮助</span></td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    <div align="right">
                        系统整合密钥:</div>
                </td>
                <td>
                    <asp:TextBox ID="Api_Key" runat="server" CssClass="input8" Style="width: 350px"></asp:TextBox>
                    <span class="helpstyle" style="cursor: help;" title="点击查看帮助" ">
                        <!--onclick="Help('H_navimenu_0003',this)height="32"-->
                        帮助</span></td>
            </tr>
        </table>
        <div class="nxb_submit" >
            <asp:Button ID="submit" runat="server" CssClass="insubt" Text=" 确 定 " OnClick="submit_Click" />
            <input name="reset" type="reset" value=" 重 置 " class="insubt">
        </div>
         </div>
        </div>
        <div class="mian_cont">
            <div class="nwelie">
            <div class="jslie_lan">
                <span>功能：</span><a href="add.aspx" class="topnavichar">添加接口应用程序</a>
            </div>
            <div class="jslie_lie">
                <asp:Repeater ID="RepeaterApplist" runat="server" OnItemDataBound="RepeaterApplist_ItemDataBound">
                    <HeaderTemplate>
                        <table class="jstable" id="TabData">
                            <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                                <th>
                                    应用程序标识</th>
                                <th>
                                    接口文件URL</th>
                                    <th>
                                    操作
                                    </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                            <td>
                                <asp:Literal ID="LiteralAppID" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="LiteralAppUrl" runat="server"></asp:Literal>
                            </td>
                            <td>
                               <asp:HyperLink ID="hpedit" runat="server" > 修改</asp:HyperLink>
                               <asp:HyperLink ID="hpdelete" runat="server" > 删除</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

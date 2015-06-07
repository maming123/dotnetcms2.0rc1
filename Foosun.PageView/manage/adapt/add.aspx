<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Foosun.PageView.manage.adapt.add" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
        <div class="mian_cont">
            <div class="nwelie">
                <div class="lanlie_lie">
                    <div class="newxiu_base">
                        <table class="nxb_table">
                            <tr>
                                <td width="20%" align="right">
                                    <div align="right">
                                        应用程序标识：</div>
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
                                        接口URL：</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="Api_Url" runat="server" CssClass="input8" Style="width: 350px"></asp:TextBox>
                                    <span class="helpstyle" style="cursor: help;" title="点击查看帮助" ">
                                        <!--onclick="Help('H_navimenu_0003',this)height="32"-->
                                        帮助</span></td>
                            </tr>
                        </table>
                        <div class="nxb_submit" >
                            <asp:Button ID="submit" runat="server" CssClass="insubt" Text=" 确 定 " OnClick="submit_Click" />
                            <input name="reset" type="reset" value=" 重 置 " class="insubt">
                            <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" ErrorMessage="应用标识已存在"
                                OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

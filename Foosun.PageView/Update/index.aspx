<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Foosun.PageView.Update.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>风讯CMSv2.0升级程序</title>
</head>
<body  bgcolor="#016AA9">
    <form id="form1" runat="server">
    <div style=" width:700px; margin:100px auto;  background:#FFF;  border: 1px solid #B5E7FF; line-height:30px; padding:3px; border-radius: 4px 4px 4px 4px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="font-size:12px; margin:20px 0;">
            <tr>
               <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" width="40%">请确认您目前所使用的版本：</td>
                <td width="60%">
                    <select>
                        <option>FoosunCMS v1.0 SP1</option>
                        <option>FoosunCMS v1.0 SP2</option>
                        <option>FoosunCMS v1.0 SP3</option>
                        <option>FoosunCMS v1.0 SP4</option>
                        <option>FoosunCMS v1.0 SP5</option>
                        <option>FoosunCMS v1.0 SP6</option>
                    </select>
                </td>
            </tr>
            <tr>
               <td align="right" width="40%">数据库地址：</td>
               <td width="60%">
                    <asp:TextBox ID="tbxServer" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" width="40%">数据库名称：</td>
                <td width="60%">
                    <asp:TextBox ID="tbxDbName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" width="40%">登录名：</td>
                <td width="60%">
                    <asp:TextBox ID="tbxLoginId" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" width="40%">登录密码：</td>
                <td width="60%">
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" width="40%">数据库前缀：</td>
                <td width="60%">
                    <asp:TextBox ID="tbx_uName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" width="40%"></td>
                <td width="60%">
                    <asp:Button ID="btn_Update" runat="server" Text="确认升级" 
                        onclick="btn_Update_Click" style="width:70px;height:21px;line-height:21px;border:medium none;margin:10px 0;padding:0; background:url(../CSS/blue/imges/subit.gif) no-repeat;" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

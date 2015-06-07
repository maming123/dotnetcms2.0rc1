<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Foosun.PageView.Install.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>

    <title><%=Foosun.Install.Config.title%></title>

           
</head>
<body bgcolor="#016AA9">
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="1"  style="margin-top:50px; background:#FFF;  border: 1px solid #B5E7FF; padding:3px; border-radius: 4px 4px 4px 4px;">
        <tr>
            <td bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" bgcolor="#333333">
                            <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                <tr>
                                    <td background="image/01.jpg">
                                        <font color="#ffffff">欢迎安装
                                            <%=Foosun.Install.Config.producename%>
                                        </font>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="180" valign="top">
                            <%=Foosun.Install.Config.logo%>
                        </td>
                        <td width="520" valign="top">
                            <br>
                            <br>
                            <table id="Table2" cellspacing="1" cellpadding="1" width="90%" align="center" border="0">
                                <tr>
                                    <td style="line-height:24px; padding-top:30px; font-size:12px">
                                        <p style="padding:0; margin:0; font-size:12px;">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 欢迎您选择安装<%=Foosun.Install.Config.producename%></p>
                                        <p style="padding:0; margin:0; font-size:12px;">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 本向导将协助您一步步的安装和初始化系统.</p>
                                        <p style="padding:0; margin:0; font-size:12px;">
                                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 强烈建议您在运行本向导前仔细阅读程序包中的《安装说明》文档, 如果您已经阅读过, 请点击下一步.</p>
                                    </td>
                                </tr>
                            </table>
                            <p>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                            </td>
                        <td>
                            <table width="90%" border="0" cellspacing="0" cellpadding="8">
                                <tr>
                                    <td align="right">
                                        <input type="button" onclick="javascript:window.location.href='step1.aspx';" value="下一步" style="width:70px;height:21px;line-height:21px;border:medium none;margin:0;padding:0; background:url(../CSS/blue/imges/subit.gif) no-repeat;"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="margin-top:10px; font-size:12px; line-height:24px; color:#FFF;"><%=Foosun.Install.Config.corpRight%></div>
</body>
</html>

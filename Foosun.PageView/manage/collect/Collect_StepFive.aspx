<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Collect_StepFive.aspx.cs" Inherits="Foosun.PageView.manage.collect.Collect_StepFive" %>

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
	function StepBack()
	{
	    history.back();
	}
    </script>

</head>
<body>
    <form id="Form2" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
            <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>采集系统</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="Collect_List.aspx" target="sys_main">站点设置</a> >>设置向导 
              </div>
           </div>
           <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="jslie_lan">
                <span>功能：</span><a href="Collect_List.aspx" class="list_link">站点列表</a>&nbsp;┊&nbsp;<a class="topnavichar"
                            href="Collect_RuleList.aspx">关键字过滤</a>&nbsp;┊&nbsp;<a class="topnavichar" href="Collect_News.aspx">新闻处理</a>
              </div>
            </div>
        </div>
        <div class="lanlie_lie">
                <div class="newxiu_base">
            <table  class="nxb_table">
                <tr>
                    <td width="30%" colspan="3" class="m_up_bg"
                         align="center">釆集结果预览
                        </td>
                </tr>
                <tr id="tr_baseinfo">
                    <td colspan="3" valign="top" align="center" class="list_link">
                        作者:<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        &nbsp; 时间:<asp:Label ID="Label2"
                            runat="server" Text=""></asp:Label>
                        &nbsp; 来源:<asp:Label ID="Label3" runat="server"
                                Text=""></asp:Label><br />
                        <div runat="server" id="showContextDiv" style="width:90%"></div></td>
                </tr>
                <tr id="tr_preview">
                    <td colspan="3" valign="top" class="list_link">
                    </td>
                </tr>
            </table>
                <div class="nxb_submit" >
                    <input type="button" value="上一步" class="xsubmit1" onclick="StepBack()" id="Button1" />&nbsp;
                        <input type="button" runat="server" class="xsubmit1" value="完  成" id="Button2" onserverclick="Button2_ServerClick" />
               </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatisticsView.aspx.cs" Inherits="Foosun.PageView.manage.sys.StatisticsView" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
    <div class="mian_wei">
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>统计系统 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>统计系统新增分类
          </div>
       </div>
    </div>
<div class="mian_cont">
    <div class="nwelie">
        <div class="jslie_lan">
            <a href="StatisticsPara.aspx">参数设置</a>&nbsp;┊&nbsp;
            <a href="Statistics.aspx">分类管理</a>
            <div id="menus" runat="server" />
      </div>
      </div>
      <div id="ShowNavi" runat="server"/>
      <div id="NoContent" runat="server" />
      <div class="jslie_lie">
        <%
          string type = Request.QueryString["type"];
          if(type=="zonghe")
          {
        %>
        <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" class="nwelie" id="ZongStatTable">
            <tr>
              <td colspan="2" class="list_link">综合统计信息显示</td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">总访问量:</div></td>
              <td style="width: 78%"><asp:Label ID="AllViewNum" runat="server" /></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">最高访问量:</div></td>
              <td style="width: 78%"><asp:Label ID="TheHightViewNum" runat="server" /></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">最高访问量日期:</div></td>
              <td style="width: 78%"><asp:Label ID="TheHightViewNumDay" runat="server" /></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">在线人数:</div></td>
              <td style="width: 78%"><asp:Label ID="OnlinePeopleNum" runat="server"/></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">开始统计于:</div></td>
              <td style="width: 78%"><asp:Label ID="StatTimeStart" runat="server" /></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">今日访问量:</div></td>
              <td style="width: 78%"><asp:Label ID="TodayViewNum" runat="server" /></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">昨日访问量:</div></td>
              <td style="width: 78%"><asp:Label ID="YesterDayViewNum" runat="server"/></td>
            </tr>
            <tr>
              <td width="22%"><div align="right">今年访问量:</div></td>
              <td style="width: 78%"><asp:Label ID="ThisYearViewNum" runat="server"/></td>
            </tr>
            <tr>
              <td><div align="right">本月访问量:</div></td>
              <td style="width: 78%"><asp:Label ID="ThisMonthViewNum" runat="server"/></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">统计天数:</div></td>
              <td style="width: 78%"><asp:Label ID="StatDaysNum" runat="server"/></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">平均日访问量:</div></td>
              <td style="width: 78%"><asp:Label ID="AverageDayViewNum" runat="server"/></td>
            </tr>
            <tr>
              <td width="22%" ><div align="right">预计今日:</div></td>
              <td style="width: 78%"><asp:Label ID="GuessTodayViewNum" runat="server"/></td>
            </tr>
          </table>
          <%
            }
         %>
          <%
            if(type=="all")
            {
         %>
          <asp:Repeater ID="DataList1" runat="server">
            <HeaderTemplate>
              <table class="nwelie" id="XiangxiStatTable">
              <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                <th>时间</th>
                <th>地区</th>
                <th>屏宽</th>
                <th>操作系统</th>
                <th>浏览器</th>
                <th>来源网页</th>
              </tr>
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td align="center" valign="middle" height=20><%#((DataRowView)Container.DataItem)[1]%></td>
                <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[2]%></td>
                <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[3]%></td>
                <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[4]%></td>
                <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[5] %>
                <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[6]%> </td>
              </tr>
            </ItemTemplate>
            <FooterTemplate>
              </table>
            </FooterTemplate>
          </asp:Repeater>
          <div class="fanye1">
            <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
         </div>
          <%
              }
               %>
          <%

            if (type == "hour")
            {
             %>
          <table width="98%" cellspacing="0" align="center"  id="HoursTable"  class="nwelie">
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 最近24小时访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="430" align="center">
                  <tr height="9">
                    <td colspan="29" class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=HourStat(0)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh1" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh2" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh3" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh4" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=HourStat(1)%>
                    <td width="10" class="list_link"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr height="5">
                    <td colspan="29" class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 所有24小时访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="430" align="center">
                  <tr height="9">
                    <td colspan="29" class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=HourStat(2)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh5" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh6" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh7" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="hour_lbhigh8" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=HourStat(3)%>
                    <td width=10 class="list_link"></td>
                    <td width=10 class="list_link"></td>
                  </tr>
                  <tr height="5">
                    <td colspan=29 class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
            }
         %>
          <%
            if (type == "day")
            {
         %>
          <table width="98%" cellspacing="0" align="center" id="DaysStatTable"  runat="server" class="nwelie">
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 最近31天访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="453" align="center">
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=DayStat(0)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh1" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh2" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh3" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh4" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=DayStat(1)%>
                    <td width="10" class="list_link"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr height="5">
                    <td></td>
                  </tr>
                </table></td>
            </tr>
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 所有月份日访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="453" align="center">
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=DayStat(2)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh5" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh6" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh7" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="day_lbhigh8" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=DayStat(3)%>
                    <td width="10" class="list_link"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr height="5">
                    <td colspan="29" class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
           }
        %>
          <%
            if(type=="week")
            {
         %>
          <table width="98%" cellspacing="0" align="center" id="WeekStatTable" runat="server" class="nwelie">
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 周访问量统计 <br>
                <table width="90%" align="center">
                  <tr>
                    <td><table border="0" cellpadding="0" cellspacing="0" width="175" align="center">
                        <tr height="9">
                          <td class="list_link"></td>
                        </tr>
                        <tr height="101">
                          <td align="right" valign="top" class="list_link"><%=WeekStat(0)%>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh1" Runat="server" />
                              </font>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh2" Runat="server" />
                              </font>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh3" Runat="server" />
                              </font>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh4" Runat="server" />
                              <br>
                              </font> </p></td>
                          <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                          <%=WeekStat(1)%>
                          <td width="10" class="list_link"></td>
                          <td width="10" class="list_link"></td>
                        </tr>
                        <tr height="5">
                          <td class="list_link"></td>
                        </tr>
                      </table></td>
                    <td class="list_link"><table border="0" cellpadding="0" cellspacing="0" width="175" align="center">
                        <tr height="9">
                          <td class="list_link"></td>
                        </tr>
                        <tr height="101">
                          <td align="right" valign="top" class="list_link"><%=WeekStat(2)%>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh5" Runat="server" />
                              </font>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh6" Runat="server" />
                              </font>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh7" Runat="server" />
                              </font>
                            <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                              <asp:Label ID="week_lbhigh8" Runat="server" />
                              <br>
                              </font> </p></td>
                          <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                          <%=WeekStat(3)%>
                          <td width=10 class="list_link"></td>
                          <td width=10 class="list_link"></td>
                        </tr>
                        <tr height="5">
                          <td colspan=29 class="list_link"></td>
                        </tr>
                      </table></td>
                  </tr>
                  <tr height="20" align="center">
                    <td>↑ 最近的一周</td>
                    <td>↑ 全部时段</td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
        }
         %>
          <%
            if(type=="month")
            {
         %>
          <table width="98%" cellspacing="0" align="center" cellpadding="0" border="0" id="MonthStatTable" runat="server" class="nwelie">
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 最近12个月访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="310" align="center">
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=MonthStat(0)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh1" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh2" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh3" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh4" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=MonthStat(1)%>
                    <td width="10" class="list_link"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr height="5">
                    <td colspan="29" class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 所有12个月访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="310" align="center">
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=MonthStat(2)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh5" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh6" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh7" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="month_lbhigh8" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=MonthStat(3)%>
                    <td width="10"></td>
                    <td width="10"></td>
                  </tr>
                  <tr height="5">
                    <td colspan="29" class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 年访问量统计 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="270" align="center">
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="10">
                    <td width="40" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_up.gif"></td>
                  </tr>
                  <%=MonthStat(4)%>
                  <tr height="10">
                    <td width="40" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_down.gif"></td>
                  </tr>
                  <tr height="5">
                    <td colspan="29" class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
        }
         %>
          <%
            if(type=="page")
            {
         %>
          <table width="98%" cellspacing="0" align="center" cellpadding="0" border="0" id="ViewPageTable" runat="server" class="nwelie">
            <tr height="30">
              <td width="1" class="backs"></td>
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align=absmiddle> &nbsp; 被访问页面及访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="450" align=center>
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="10">
                    <td width="220" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_up.gif"></td>
                  </tr>
                  <%=PageStat()%>
                  <tr height="10">
                    <td width="220" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_down.gif"></td>
                  </tr>
                  <tr height="5">
                    <td colspan=29 class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
        }
         %>
          <%

            if (type == "ip")
            {
         %>
          <table width="98%" cellspacing="0" align="center" cellpadding="0" border="0" class="nwelie" id="IPStatTable" runat="server">
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align=absmiddle> &nbsp; IP地址及访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="350" align=center>
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="10">
                    <td width="120" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_up.gif"></td>
                  </tr>
                  <%=IpStat()%>
                  <tr height="10">
                    <td width="120" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_down.gif"></td>
                  </tr>
                  <tr height="5">
                    <td colspan=29 class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
            }
          %>
          <%
            if(type=="cs")
            {
         %>
          <table width="98%" cellspacing="0" align="center" cellpadding="0" border="0" id="SoftWareTable" runat="server" class="nwelie">
            <tr height="30">
              <td style="width: 498px" colspan="2">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 浏览器及访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="385" align="center">
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=SoftStat(0)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh1" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh2" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh3" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh4" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=SoftStat(1)%>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_right.gif"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr>
                    <td align="right" class="list_link"><p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">0</font></p></td>
                    <td width="10" class="list_link"></td>
                    <%=SoftStat(2)%>
                    <td width="10" class="list_link"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr height="5">
                    <td class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
            <tr height="30">
              <td width="498" colspan="2">&nbsp; <img src="../../sysImages/folder/stat.gif" align="absMiddle"> &nbsp; 操作系统及访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="385" align="center">
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="101">
                    <td align="right" valign="top" class="list_link"><%=OsStat(0)%>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh5" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh6" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 13px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh7" Runat="server" />
                        </font>
                      <p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">
                        <asp:Label ID="soft_lbhigh8" Runat="server" />
                        <br>
                        </font> </p></td>
                    <td width="10" align="right" class="list_link"><img src="../../sysImages/StatIcon/tu_back_left.gif"></td>
                    <%=OsStat(1)%>
                    <td width="10" class="list_link"><img src="../../sysImages/StatIcon/tu_back_right.gif"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr>
                    <td align="right" class="list_link"><p style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LINE-HEIGHT: 100%; MARGIN-RIGHT: 2px"> <font face="Arial">0</font></p></td>
                    <td width="10" class="list_link"></td>
                    <%=OsStat(2)%>
                    <td width="10" class="list_link"></td>
                    <td width="10" class="list_link"></td>
                  </tr>
                  <tr height="5">
                    <td class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
            <tr height="30">
              <td width="498" colspan="2">&nbsp; <img src="../../sysImages/folder/stat.gif" align=absmiddle> &nbsp; 客户端屏幕宽度统计 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="270" align=center>
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="10">
                    <td width="40" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_up.gif"></td>
                  </tr>
                  <%=WidthStat()%>
                  <tr height="10">
                    <td width="40" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_down.gif"></td>
                  </tr>
                  <tr height="5">
                    <td colspan=29></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
        }
         %>
          <%
            if(type=="area")
            {
         %>
          <table width="98%" cellspacing="0" align="center" cellpadding="0" border="0"  id="AreaStatTable" class="nwelie" runat="server">
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align=absmiddle> &nbsp; 访问者地区及访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="350" align=center>
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="10">
                    <td width="120" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_up.gif"></td>
                  </tr>
                  <%=AreaStat()%>
                  <tr height="10">
                    <td width="120" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_down.gif"></td>
                  </tr>
                  <tr height="5">
                    <td colspan=29 class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
        }
         %>
          <%
        if(type=="come")
        {
         %>
          <table width="98%" cellspacing="0" align="center" cellpadding="0" border="0" id="ComeStatTable" runat="server" class="nwelie" >
            <tr height="30">
              <td width="498" class="list_link">&nbsp; <img src="../../sysImages/folder/stat.gif" align=absmiddle> &nbsp; 来路及访问量 <br>
                <table border="0" cellpadding="0" cellspacing="0" width="450" align=center>
                  <tr height="9">
                    <td class="list_link"></td>
                  </tr>
                  <tr height="10">
                    <td width="220" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_up.gif"></td>
                  </tr>
                  <%=ComeStat()%>
                  <tr height="10">
                    <td width="220" class="list_link"></td>
                    <td width="230" class="list_link"><img src="../../sysImages/StatIcon/tu_back_down.gif"></td>
                  </tr>
                  <tr height="5">
                    <td colspan=29 class="list_link"></td>
                  </tr>
                </table></td>
            </tr>
          </table>
          <%
        }
         %>
          <%
             if (type == "code")
             { 
          %>
          <div id="CodeUseTable" runat="server"></div>
          <%
          }
          %>
        
        </div>

    </div>
</div>
</div>
    </form>
</body>
</html>

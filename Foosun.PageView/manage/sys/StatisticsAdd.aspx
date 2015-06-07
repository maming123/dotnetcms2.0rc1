<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatisticsAdd.aspx.cs" Inherits="Foosun.PageView.manage.sys.StatisticsAdd" %>

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
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>统计系统 </h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>统计系统新增分类
          </div>
       </div>
       <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
    </div>
<div class="mian_cont">
   <div class="nwelie">
   <div class="jslie_lan">
            <a href="StatisticsPara.aspx">参数设置</a>&nbsp;┊&nbsp;
            <a href="Statistics.aspx">分类管理</a>
      </div>
    <div class="lanlie_lie">
         <div class="newxiu_base">
          <table class="nxb_table" id="AddClass">
            <tr class="TR_BG_list">
              <td width="15%" align="right"> 分类名称：</td>
              <td><asp:TextBox ID="ClassName" runat="server" Width="124px" CssClass="input4"/>
                <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_statClass_0001',this)">帮助</span></td>
            </tr>
          </table>

    <div class="nxb_submit" >
                 <input type="submit" name="Saveclass" value=" 提 交 " class="xsubmit1 mar" id="stataddclass" runat="server" onserverclick="stataddclass_ServerClick" />
                 <input type="reset" name="Clearclass" value=" 重 填 " class="xsubmit1 mar" />
             </div>
    </div>
  </div>
   </div>
</div>
</div>
    </form>
</body>
</html>

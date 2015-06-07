<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetTitle.aspx.cs" Inherits="Foosun.PageView.manage.survey.SetTitle" %>
<%@ Register Src="~/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
    <script>
        function selectItem() {
            if (document.getElementById("TypeSelect").options[document.getElementById("TypeSelect").selectedIndex].value == "1") {
                $('#MaxSelectNum').show();
            } else {
            $('#MaxSelectNum').hide();
            }
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>调查管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="#">新闻管理</a> >>调查管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
   <div class="jslie_lan">
        <span></span><label id="param_id" runat="server" /><a href="setClass.aspx">投票分类设置</a>┊<a href="setTitle.aspx">投票主题设置</a>┊
        <a href="setItem.aspx">投票选项设置</a>┊<a href="setSteps.aspx">多步投票管理</a>┊
        <a href="ManageVote.aspx">投票情况管理</a>
      </div>
  <%
         string type = Request.QueryString["type"];
         if(type !="add"&&type!="edit")
         {
      %>
    <div class="jslie_lan" style="float:right">
    <a href="?type=add" class="topnavichar">新增主题</a> |
            <asp:LinkButton ID="DelP" runat="server" CssClass="xa3" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除</asp:LinkButton>
            |
            <asp:LinkButton ID="DelAll" runat="server" CssClass="xa3" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="DelAll_Click">删除全部</asp:LinkButton>
  </div>
  <div class="jslie_lie">
  <asp:Repeater ID="DataList1" runat="server">
    <HeaderTemplate>
      <table width="98%" class="jstable">
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <th width="17%">主题</th>
        <th width="7%">类别</th>
        <th width="7%">类型</th>
        <th width="7%">选项数</th>
        <th width="7%">方式</th>
        <th width="15%">开始时间</th>
        <th width="15%">结束时间</th>
        <th width="10%">JS调用</th>
        <th width="15%">操作
          <input type="checkbox" id="vote_checkbox" value="-1" name="vote_checkbox" onclick="javascript:return selectAll(this.form,this.checked);"/></th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr onmouseover="this.className='on'"onmouseout="this.className='off'">
        <td align="left"><%#((DataRowView)Container.DataItem)[2]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["voteClass"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["type"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[4]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["displayModel"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[6]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)[7]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["js"]%></td>
        <td align="center"><%#((DataRowView)Container.DataItem)["oPerate"]%> </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      </table>
    </FooterTemplate>
  </asp:Repeater>
  <div class="fanye1">
    <uc1:PageNavigator ID="PageNavigator1" runat="server" />
  </div>
  <div class="lanlie_shming">
    <span>主题查询:</span>&nbsp;<span>关键字:</span><asp:TextBox runat="server" ID="KeyWord" size="15"  CssClass="input8"/>
    &nbsp;&nbsp;
        <span>查询类型:</span>
        <asp:DropDownList ID="DdlKwdType" runat="server"  CssClass="seclet">
          <asp:ListItem Value="choose" Text="请选择" />
          <asp:ListItem Value="title" Text="主题" />
          <asp:ListItem Value="class" Text="类别" />
          <asp:ListItem Value="num" Text="选项数" />
          <asp:ListItem Value="starttime" Text="开始时间" />
          <asp:ListItem Value="endtime" Text="结束时间" />
          <asp:ListItem Value="itemmodel" Text="排列方式" />
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button runat="server" ID="BtnSearch" Text=" 查询 " CssClass="xsubmit1" OnClick="BtnSearch_Click"/>
        &nbsp;<span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_searchTitle_0001',this)">帮助</span> 
  </div>
  </div>
  </div>
  </div>
  <%
      }
       %>
  <%
    if(type=="add")
    {
 %>
 <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table" id="Addvote_Title">
    <tr>
      <th colspan="2" align="left"><font style="font-weight:100;">新增问卷调查主题信息</font></th>
    </tr>
    <tr>
      <td width="20%" align="right"> 调查类别：</td>
      <td><asp:DropDownList ID="vote_ClassName" runat="server" CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0001',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="20%" align="right"> 调查主题：</td>
      <td><asp:TextBox ID="Title" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0002',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 项目类型：</td>
      <td><asp:DropDownList ID="TypeSelect" runat="server" CssClass="select3" onchange="selectItem();">
          <asp:ListItem Value="0" Selected="True">单选</asp:ListItem>
          <asp:ListItem Value="1">多选</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0003',this)">帮助</span> </td>
    </tr>
    <tr id="MaxSelectNum" style="display:none">
      <td width="20%" align="right"> 最多选项个数：</td>
      <td><asp:TextBox ID="MaxselectNum" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0004',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 显示方式：</td>
      <td><asp:DropDownList ID="DisModel" runat="server" CssClass="select3">
          <asp:ListItem Value="0" Selected="True">柱形图</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0005',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="20%" align="right"> 是否允许多步投票：</td>
      <td><asp:DropDownList ID="isSteps" runat="server" CssClass="select3">
          <asp:ListItem Value="1">是</asp:ListItem>
          <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0009',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="20%" align="right"> 开始时间：</td>
      <td><asp:TextBox ID="Starttime" runat="server" Width="124px" CssClass="input8"/>
        &nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0006',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 结束时间：</td>
      <td><asp:TextBox ID="Endtime" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0007',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 选项排列方式：</td>
      <td><asp:DropDownList ID="SortStyle" runat="server" CssClass="select3">
          <asp:ListItem Value="0" Selected="True">横向排列</asp:ListItem>
          <asp:ListItem Value="1">1选项/行(纵向)</asp:ListItem>
          <asp:ListItem Value="2">2选项/行</asp:ListItem>
          <asp:ListItem Value="3">3选项/行</asp:ListItem>
          <asp:ListItem Value="4">4选项/行</asp:ListItem>
          <asp:ListItem Value="5">5选项/行</asp:ListItem>
          <asp:ListItem Value="6">6选项/行</asp:ListItem>
          <asp:ListItem Value="7">7选项/行</asp:ListItem>
          <asp:ListItem Value="8">8选项/行</asp:ListItem>
          <asp:ListItem Value="9">9选项/行</asp:ListItem>
          <asp:ListItem Value="10">10选项/行</asp:ListItem>
          <asp:ListItem Value="11">11选项/行</asp:ListItem>
          <asp:ListItem Value="12">12选项/行</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0008',this)">帮助</span> </td>
    </tr>
    <tr>
      <td align="center"  colspan="2" class="list_link"><label>
        
        </label>
        &nbsp;&nbsp;
        <label>
        
        </label></td>
    </tr>
  </table>
    <div class="nxb_submit" >
        <input type="submit" name="Savetitle" value=" 提 交 " class="xsubmit1" id="Savetitle" runat="server" onserverclick="Savetitle_ServerClick"/>
        <input type="reset" name="Cleartitle" value=" 重 填 " class="xsubmit1" id="ClearTitle" runat="server" />
    </div>
  </div>
  </div>
  </div>
  <%
 }
  %>
  <%
    if(type=="edit")
    {
 %>
  <div class="newxiu_base">
  <table class="nxb_table" id="EditTitle">
    <tr>
      <th colspan="2" align="left"><font style="font-weight:100;">修改问卷调查主题信息</font></th>
    </tr>
    <tr>
      <td width="20%" align="right"> 调查类别：</td>
      <td><asp:DropDownList ID="ClassnameE" runat="server" CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0001',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="20%" align="right"> 调查主题：</td>
      <td><asp:TextBox ID="TitleE" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0002',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 项目类型：</td>
      <td><asp:DropDownList ID="TypeE" runat="server" onchange="Select(this.value)" CssClass="select3">
          <asp:ListItem Value="0" Selected="True">单选</asp:ListItem>
          <asp:ListItem Value="1">多选</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0003',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="20%" align="right"> 最多选项个数：</td>
      <td><asp:TextBox ID="MaxNumE" runat="server" Width="124px" CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0004',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 显示方式：</td>
      <td><asp:DropDownList ID="DisModelE" runat="server" CssClass="select3">
          <asp:ListItem Value="0" Selected="True">柱形图</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0005',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="20%" align="right"> 是否允许多步投票：</td>
      <td><asp:DropDownList ID="isStepsE" runat="server" CssClass="select3">
          <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
          <asp:ListItem Value="0">否</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0009',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="20%" align="right"> 开始时间：</td>
      <td><asp:TextBox ID="StartTimeE" runat="server" Width="124px" CssClass="input8"/>
        &nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0006',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 结束时间：</td>
      <td><asp:TextBox ID="EndTimeE" runat="server" Width="124px" CssClass="input8"/>
        &nbsp;
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0007',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="20%" align="right"> 选项排列方式：</td>
      <td><asp:DropDownList ID="StyleE" runat="server" CssClass="select3">
          <asp:ListItem Value="0" Selected="True">横向排列</asp:ListItem>
          <asp:ListItem Value="1">1选项/行(纵向)</asp:ListItem>
          <asp:ListItem Value="2">2选项/行</asp:ListItem>
          <asp:ListItem Value="3">3选项/行</asp:ListItem>
          <asp:ListItem Value="4">4选项/行</asp:ListItem>
          <asp:ListItem Value="5">5选项/行</asp:ListItem>
          <asp:ListItem Value="6">6选项/行</asp:ListItem>
          <asp:ListItem Value="7">7选项/行</asp:ListItem>
          <asp:ListItem Value="8">8选项/行</asp:ListItem>
          <asp:ListItem Value="9">9选项/行</asp:ListItem>
          <asp:ListItem Value="10">10选项/行</asp:ListItem>
          <asp:ListItem Value="11">11选项/行</asp:ListItem>
          <asp:ListItem Value="12">12选项/行</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveytitle_0008',this)">帮助</span> </td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Savetitle" value=" 提 交 " class="xsubmit1" id="Editsave" runat="server" onserverclick="Editsave_ServerClick"/>
        <input type="reset" name="Cleartitle" value=" 重 填 " class="xsubmit1" id="editclear" runat="server" />
    
    </div>
   </div>
  <%
 }
  %>
  </div>
</form>

<script language="javascript">
    $(function () {
        $("#Endtime").datepicker({changeMonth: true,changeYear: true});
        $("#Starttime").datepicker({changeMonth: true,changeYear: true});
        $("#EndtimeE").datepicker({changeMonth: true,changeYear: true});
        $("#StarttimeE").datepicker({changeMonth: true,changeYear: true});
    });   
    function getjsCode(jsid) {
        if (jsid != "" && !isNaN(jsid)) {
            //----------控制居中显示----------------
            var WWidth = (window.screen.width - 500) / 2;
            var Wheight = (window.screen.height - 150) / 2;
            //--------------------------------------
            window.open('showJsPath.aspx?jsid=' + jsid, '投票JS代码调用', 'height=200, width=400, top=' + Wheight + ', left=' + WWidth + ', toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no');
        }
        else {
            alert("出现错误，请联系技术人员！");
        }
    }
</script>
</html>

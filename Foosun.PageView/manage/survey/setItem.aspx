<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setItem.aspx.cs" Inherits="Foosun.PageView.manage.survey.setItem" %>
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
</head>
<body>
<form id="form1" runat="server">
  <iframe width="260" height="165" id="colorPalette" src="../../configuration/system/selcolor.htm" style="visibility:hidden; position: absolute;border:1px gray solid; left: 31px; top: 140px;" frameborder="0" scrolling="no" ></iframe>
  <div id="dialog-message" title="提示"></div>
  <div class="mian_body">
  <div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>调查管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>调查管理
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
<div class="nwelie">
<div class="jslie_lan">
         <span>功能：</span><label id="param_id" runat="server" /><a href="setClass.aspx">投票分类设置</a>&nbsp;┊&nbsp;<a href="setTitle.aspx">投票主题设置</a>&nbsp;┊&nbsp;<a href="setItem.aspx">投票选项设置</a>&nbsp;┊&nbsp;<a href="setSteps.aspx">多步投票管理</a>&nbsp;┊&nbsp;<a href="ManageVote.aspx">投票情况管理</a>
      </div>
  <div id="NoContent" runat="server" style="margin-left:5px"></div>
  <%
         string type = Request.QueryString["type"];
         if(type !="add"&&type!="edit")
         {
      %>
  <div class="jslie_lan" style="float:right">
  <div style="float:right">
  <a href="?type=add">新增选项</a> |
            <asp:LinkButton ID="DelP" runat="server" OnClientClick="{if(confirm('确认删除所选信息吗?')){return true;}return false;}" OnClick="DelP_Click">批量删除</asp:LinkButton>
            |
            <asp:LinkButton ID="DelAll" runat="server" OnClientClick="{if(confirm('确认删除全部信息吗?')){return true;}return false;}" OnClick="DelAll_Click">删除全部</asp:LinkButton></div>
  </div>
  <div class="jslie_lie">
  <asp:Repeater ID="DataList1" runat="server">
    <HeaderTemplate>
      <table class="jstable">
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <th>选项描述</th>
        <th>所属主题</th>
        <th>选项模式</th>
        <th>图片位置</th>
        <th>显示颜色</th>
        <th>票数</th>
        <th>操作
          <input type="checkbox" id="vote_checkbox" value="-1" name="vote_checkbox" onclick="javascript:return selectAll(this.form,this.checked);"/></th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
        <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[2]%></td>
        <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["title"]%></td>
        <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["ItemModel"]%></td>
        <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[5]%></td>
        <td align="center" valign="middle" style="background-color:#<%#((DataRowView)Container.DataItem)[6]%>"><%#((DataRowView)Container.DataItem)[6]%></td>
        <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)[7]%></td>
        <td align="center" valign="middle" ><%#((DataRowView)Container.DataItem)["oPerate"]%> </td>
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
  <span>选项查询:</span>
        &nbsp;
        <span>关键字:</span>
        <asp:TextBox runat="server" ID="KeyWord" size="15" CssClass="input8"/>
        &nbsp;&nbsp;
        查询类型:
        <asp:DropDownList ID="DdlKwdType" runat="server"  CssClass="select3">
          <asp:ListItem Value="choose" Text="请选择" />
          <asp:ListItem Value="title" Text="所属主题"/>
          <asp:ListItem Value="ItemNamee" Text="选项描述" />
          <asp:ListItem Value="ItemValuee" Text="项目符号" />
          <asp:ListItem Value="PicSrcc" Text="图片位置" />
          <asp:ListItem Value="DisColorr" Text="显示颜色" />
          <asp:ListItem Value="VoteCountt" Text="当前票数" />
          <asp:ListItem Value="ItemDetaill" Text="详细说明" />
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button runat="server" ID="BtnSearch" Text=" 查询 " CssClass="xsubmit1" OnClick="BtnSearch_Click"/>
        &nbsp;<span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_searchItem_0001',this)">帮助</span> 
  </div>
  </div>
  <%
      }
       %>
  <%
            if(type=="add")
            {
        %>
        <div class="newxiu_base">
  <table class="nxb_table" id="Addvote_Item">
    <tr>
      <th colspan="2" align="left"><font style="font-weight:100;">新增问卷调查选项信息</font></th>
    </tr>
    <tr>
      <td width="15%" align="right"> 所属投票：</td>
      <td><asp:DropDownList ID="vote_CTName" runat="server"  CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0001',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 选项描述：</td>
      <td><asp:TextBox ID="ItemName" runat="server" Width="124px"  CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0002',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 项目符号：</td>
      <td><asp:DropDownList ID="ItemValue" runat="server"  CssClass="select3">
          <asp:ListItem Value="0" Selected="True">1-9</asp:ListItem>
          <asp:ListItem Value="1">a-z</asp:ListItem>
          <asp:ListItem Value="2">A-Z</asp:ListItem>
          <asp:ListItem Value="3">.</asp:ListItem>
          <asp:ListItem Value="4">★</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0003',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 选项模式：</td>
      <td><asp:DropDownList ID="ItemMode" runat="server"  CssClass="select3">
          <asp:ListItem Value="1">文字描述模式</asp:ListItem>
          <asp:ListItem Value="2">自主填写模式</asp:ListItem>
          <asp:ListItem Value="3">图片模式</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0004',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 图片位置：</td>
      <td><asp:TextBox ID="PicSrc" runat="server" Width="124px"  CssClass="input8"/>
        &nbsp;
        <img src="../imges/bgxiu_14.gif"  align="middle" alt="选择已有图片" border="0" style="cursor: pointer;"
                                            onclick="selectFile('PicSrc','选择图片','pic',500,500);document.form1.PicSrc.focus();" />
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0005',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right" class="list_link" style="width: 171px"> 显示颜色：</td>
      <td><asp:TextBox ID="DisColor" runat="server"  CssClass="input8"/>
        <img src="../../sysImages/FileIcon/Rect.gif" alt="-" name="MarkFontColor_Show" width="18" height="17" border=0 align="absmiddle" id="MarkFontColor_Show" style="cursor:pointer;background-color:#<%= DisColor.Text%>;"title="选取颜色" onClick="GetColor(this,'DisColor');"><span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0006',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 当前票数：</td>
      <td><asp:TextBox ID="VoteCount" runat="server" Width="124px"  CssClass="input8" Text="0"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0007',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 选项详细说明：</td>
      <td><textarea id="ItemDetail" runat="server" style="width: 290px; height: 103px" class="textarea4"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0008',this)">帮助</span></td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Saveitem" value=" 提 交 " class="xsubmit1" id="Saveitem" runat="server" onserverclick="Saveitem_ServerClick"/>
        <input type="reset" name="Clearitem" value=" 重 填 " class="xsubmit1" id="Clearitem" runat="server" />
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
  <table  class="nxb_table" id="EditItem">
    <tr>
      <th colspan="2" align="left"><font style="font-weight:100;">修改问卷调查选项信息</font></th>
    </tr>
    <tr>
      <td width="15%" align="right"> 所属投票：</td>
      <td><asp:DropDownList ID="classnameedit" runat="server"  CssClass="select3"> </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0001',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 选项描述：</td>
      <td><asp:TextBox ID="itemnameedit" runat="server" Width="124px"  CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0002',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 项目符号：</td>
      <td><asp:DropDownList ID="valueedit" runat="server"  CssClass="select3">
          <asp:ListItem Value="0" Selected="True">1-9</asp:ListItem>
          <asp:ListItem Value="1">a-z</asp:ListItem>
          <asp:ListItem Value="2">A-Z</asp:ListItem>
          <asp:ListItem Value="3">.</asp:ListItem>
          <asp:ListItem Value="4">★</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0003',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 选项模式：</td>
      <td><asp:DropDownList ID="itemmodele" runat="server"  CssClass="select3">
          <asp:ListItem Value="1">文字描述模式</asp:ListItem>
          <asp:ListItem Value="2">自主填写模式</asp:ListItem>
          <asp:ListItem Value="3">图片模式</asp:ListItem>
        </asp:DropDownList>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0004',this)">帮助</span> </td>
    </tr>
    <tr>
      <td width="15%" align="right"> 图片位置：</td>
      <td><asp:TextBox ID="picsurl" runat="server" Width="124px"  CssClass="input8"/>
        &nbsp;
        <img src="../imges/bgxiu_14.gif"  align="middle" alt="选择已有图片" border="0" style="cursor: pointer;"
                                            onclick="selectFile('picsurl','选择图片','pic',500,500);document.form1.picsurl.focus();" />
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0005',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right" class="list_link" style="width: 171px"> 显示颜色：</td>
      <td><asp:TextBox ID="discoloredit" runat="server"  CssClass="input8"/>
        <img src="../../sysImages/FileIcon/Rect.gif" alt="-" name="MarkFontColor_Show" width="18" height="17" border=0 align="absmiddle" id="discolore" style="cursor:pointer;background-color:#<%= DisColor.Text%>;"title="选取颜色" onClick="GetColor(this,'discoloredit');"><span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0006',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 当前票数：</td>
      <td><asp:TextBox ID="pointqe" runat="server" Width="124px"  CssClass="input8"/>
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0007',this)">帮助</span></td>
    </tr>
    <tr>
      <td width="15%" align="right"> 选项详细说明：</td>
      <td><div class="textdiv4"><textarea id="discriptionitem" runat="server" style="width: 290px; height: 103px; font-size:12px" />
        <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onClick="Help('H_surveyitem_0008',this)">帮助</span></div></td>
    </tr>
  </table>
  <div class="nxb_submit" >
        <input type="submit" name="Saveitem" value=" 提 交 " class="xsubmit1" id="Editclick" runat="server" onserverclick="Editclick_ServerClick"/>
        <input type="reset" name="Clearitem" value=" 重 填 " class="xsubmit1" id="Editclear" runat="server" />
  </div>
  </div>
  <%
            }
         %>
         </div>
</div>
</div>
</form>
</body>
</html>

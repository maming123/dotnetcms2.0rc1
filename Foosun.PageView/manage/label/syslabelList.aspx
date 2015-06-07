<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="syslabelList.aspx.cs" Inherits="Foosun.PageView.manage.label.syslabelList" %>
<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>标签管理列表</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function Update(type, id) {
        switch (type) {
            case "Label":
                self.location = "syslableadd.aspx?LabelID=" + id;
                break;
            case "LabelClass":
                self.location = "syslabelclassadd.aspx?ClassID=" + id;
                break;
        }
    }
function Bak(id)
{
    if(confirm('你确认将此标签放入备份库吗?操作成功后此标签将失效!'))
    {
        self.location="?Op=Bak&ID="+id;
    }
}
function Del(type,id)
{
    switch (type)
    {
        case "Label":
            if(confirm('你确认将此标签放入回收站吗?'))
            {
                self.location="?Op=Del&type=Label&ID="+id;
            }
            break;
        case "LabelClass":
            if(confirm('你确认将此栏目放入回收站吗?\r此操作将会将此栏目以及属于此栏目的标签放入回收站.'))
            {
                self.location="?Op=Del&type=LabelClass&ID="+id;
            }
           break;
    }
}

function reload()
{
    if(confirm('您确认要重新从风讯(Foosun.net)下载 [系统内置标签] 吗?\n重新下载标签，将把您系统内置标签全部清空。\n特别注意：下载的是xml文件，把xml文件通过导入标签功能导入!\n如果您确认。请点[确定]按钮'))
    {
	    var ifm = document.getElementById("reloadfromfoosun");
	    ifm.src = "<%Response.Write(ReloadURL);%>";
    }
}

function Dels(type,id)
{
    switch (type)
    {
        case "Label":
            if(confirm('你将彻底删除此标签'))
            {
                self.location="?Op=Dels&type=Label&ID="+id;
            }
            break;
        case "LabelClass":
            if(confirm('你将彻底删除此栏目\r此操作将会彻底删除此栏目以及属于此栏目的标签'))
            {
                self.location="?Op=Dels&type=LabelClass&ID="+id;
            }    
           break;
    }
}

function getchanelInfo(obj)
{
   var SiteID=obj.value;
   window.location.href="sysLabellist.aspx?SiteID="+SiteID+"&ClassID=<%Response.Write(Request.QueryString["ClassID"]); %>";
}

function shdivlabel(id)
{
    var gid=document.getElementById(id);
    if(gid.style.display=="")
    {
        gid.style.display="none";
    }
    else
    {
        gid.style.display="";
    }
}
function getKeywords(obj)
{
    var getValue = document.getElementById("keywords");
    if(getValue.value=="")
    {
        alert('请输入关键字!');
        return false;
    }
    else
    {
       window.location.href="SysLabelList.aspx?s=1&keyword="+getValue.value+""; 
    }
}
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>标签管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>标签管理
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li><a href="syslabelbak.aspx">备份库 </a>┊</li>
            <li><a href="syslableadd.aspx"> 新建标签</a>┊</li>
            <li><a href="syslabelclassadd.aspx">新增分类</a>┊</li>
            <li><a href="sysLabelout.aspx?type=out">导出标签</a><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_label_out_001',this)">(如何导出?)</span>┊</li>
            <li><a href="sysLabelout.aspx?type=in">导入标签</a><span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_label_in_001',this)">(如何导入?)</span>┊</li>
            <li><a href="style.aspx">显示格式(样式管理)</a></li>
            <li><span id="Back" runat="server"></span>&nbsp;<span id="channelList" runat="server" /></li>
         </ul>
      </div>
      <div class="lanlie_lie">
         <div class="jslie_lie">
         <asp:Repeater ID="DataList1" runat="server">
         <HeaderTemplate>
           <table class="jstable">
              <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                 <th width="30%"><% =Cname %></th>
                 <th width="30%">创建日期</th>
                 <th width="40%">操作</th>
              </tr>
               </HeaderTemplate>
               <ItemTemplate>
              <tr class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
                  <td><span class="span1"><%#Eval("Type") %></span></td>
                  <td align="center"><%#Eval("CreatTime")%></td>
                  <td align="center">
                  <%#Eval("op")%>                 
                  </td>
              </tr>
              <tr style="display:none" class="biqi" id="<%#((System.Data.DataRowView)Container.DataItem)[1]%>">
              <td colspan="3">
              <div style="padding:10px 1%; width:98%;word-break:break-all;">
                <%#((System.Data.DataRowView)Container.DataItem)[5]%>
              </div>
              </td>
              </tr>
              </ItemTemplate>
              <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="fanye">
          <div class="bqsosuo">
             <span>搜索：</span><input type="text" id= "keywords" name=""  value="" />
             <input type="submit"  name="hfg" value="搜索标签" onclick="getKeywords(this);return false;" class="xsubmit1"/>
          </div>
          <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
          <iframe id="reloadfromfoosun" src="about:blank" border="0" height="0" width="0" style="visibility: hidden"></iframe>
          </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

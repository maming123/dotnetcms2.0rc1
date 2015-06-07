<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="style.aspx.cs" Inherits="Foosun.PageView.manage.label.style" %>
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
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function Update(type, id) {
        switch (type) {
            case "style":
                self.location = "styleadd.aspx?ClassID=<%=Request.QueryString["ClassID"] %>&styleID=" + id;
                break;
            case "styleclass":
                self.location = "styleclassadd.aspx?ClassID=" + id;
                break;
        }
    }
function Del(type,id)
{
    switch (type)
    {
        case "style":
            if(confirm('你确认将此样式放入回收站吗?'))
            {
                self.location="?Op=Del&type=style&ID="+id;
            }
            break;
        case "styleclass":
            if(confirm('你确认将此栏目放入回收站吗?\r此操作将会将此栏目以及属于此栏目的样式放入回收站.'))
            {
                self.location="?Op=Del&type=styleclass&ID="+id;
            }
           break;
    }
}

function Dels(type,id)
{
    switch (type)
    {
        case "style":
            if(confirm('你将彻底删除此样式'))
            {
                self.location="?Op=Dels&type=style&ID="+id;
            }
            break;
        case "styleclass":
            if(confirm('你将彻底删除此栏目\r此操作将会彻底删除此栏目以及属于此栏目的样式'))
            {
                self.location="?Op=Dels&type=styleclass&ID="+id;
            }    
           break;
    }
}

function getchanelInfo(obj)
{
   var SiteID=obj.value;
   window.location.href="style.aspx?SiteID="+SiteID+"&ClassID=<%Response.Write(Request.QueryString["ClassID"]); %>";
}

function getReview(id)
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
       window.location.href="style.aspx?s=1&keyword="+getValue.value+""; 
    }
}
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>样式管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>样式管理
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li><a href="styleadd.aspx">添加样式</a>┊</li>
            <li><a href="styleclassadd.aspx">添加分类</a></li>            
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
                  <td><span class="span1"><%#((System.Data.DataRowView)Container.DataItem)[6]%></span></td>
                  <td align="center"><%#((System.Data.DataRowView)Container.DataItem)[3]%></td>
                  <td align="center">
                  <%#((System.Data.DataRowView)Container.DataItem)[5]%>           
                  </td>
              </tr>
              <tr style="display:none;" id="<%#((System.Data.DataRowView)Container.DataItem)[0]%>">
              <td colspan="3">
              <%#((System.Data.DataRowView)Container.DataItem)["contents"]%>
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
          </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>
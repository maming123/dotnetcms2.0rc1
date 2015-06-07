<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usergroupadd.aspx.cs" Inherits="Foosun.PageView.manage.user.usergroupadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>会员组增加/修改</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>

<body>
<form runat="server" id="form1">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>会员组增加/修改</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="usergroup.aspx">会员组管理</a> >>会员组增加/修改
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="20%" align="right">会员组名：</td>
               <td>
                  <asp:TextBox class="input8" ID="GroupName" runat="server"></asp:TextBox>
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_usergroup_add_0001',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">需要积分：</td>
               <td>
                   <asp:TextBox ID="iPoint" runat="server" Text="0" MaxLength="4" class="input8"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_usergroup_add_0002',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">需要G币：</td>
               <td>
                  <asp:TextBox ID="gPoint" runat="server" Text="0" MaxLength="4" class="input8"></asp:TextBox>
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_usergroup_add_0003',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">有效期：</td>
               <td>
                  <asp:TextBox class="input8"  ID="Rtime" runat="server" Text="0"  MaxLength="20"></asp:TextBox>
                 <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_usergroup_add_0004',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">折扣率：</td>
               <td>
                   <asp:TextBox ID="Discount" runat="server" class="input8" MaxLength="4">1</asp:TextBox>
                  <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_usergroup_add_Discount',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">评论内容字数限制：</td>
               <td>
                   <asp:TextBox class="input8" ID="LenCommContent" runat="server" Text="500" MaxLength="4"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_0005',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">评论需要审核：</td>
               <td>
                <asp:RadioButtonList ID="CommCheckTF" runat="server"  class="radio"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected="True"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>
                   
                    <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_0006',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">允许上传格式：</td>
               <td>
               <asp:TextBox class="input8" ID="upfileType" runat="server" Text="jpg,gif,bmp,png,swf,zip,rar"></asp:TextBox>
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_0008',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">单个文件大小(kb)：</td>
               <td>
                  <asp:TextBox class="input8" ID="upfileSize" runat="server"  Text="10"></asp:TextBox>
                <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00010',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">最多允许投稿数(篇)：</td>
               <td>
                  <asp:TextBox class="input8"  ID="ContrNum" runat="server" Text="50"></asp:TextBox>
                 <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00012',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">最大发送短消息数(条)：</td>
               <td>
                   <asp:TextBox class="input8" ID="MessageNum" runat="server" Text="100"></asp:TextBox>
                 <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00016',this)">帮助</span>
               </td>
             </tr> 
             <tr>
               <td width="20%" align="right">支持群发消息：</td>
               <td>
               <asp:TextBox ID="MessageGroupNum" class="input8" Text="0|10" runat="server"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00017',this)">帮助</span>
               </td>
             </tr> 
             <tr>
               <td width="20%" align="right">注册需要实名认证：</td>
               <td>
                <asp:RadioButtonList ID="IsCert" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>                  
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00018',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">设置签名：</td>
               <td>                
                  <asp:RadioButtonList ID="CharTF" runat="server"  class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>  
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00019',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">签名使用html语法：</td>
               <td>
                <asp:RadioButtonList ID="CharHTML" runat="server" class="radio"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>                 
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00020',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">签名最大长度(字符)：</td>
               <td>
                   <asp:TextBox class="input8"  ID="CharLenContent" MaxLength="3" runat="server" Text="500"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00021',this)">帮助</span>
               </td>
             </tr> 
             <tr>
               <td width="20%" align="right">删除自己的主题：</td>
               <td>                  
                    <asp:RadioButtonList ID="DelSelfTitle" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>  
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00024',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">删除其他人的帖子：</td>
               <td>                   
                    <asp:RadioButtonList ID="DelOTitle" runat="server"  class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>   
                <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00025',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right"> 编辑自己的发言：</td>
               <td>                   
                    <asp:RadioButtonList ID="EditSelfTitle" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00026',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">编辑他人帖子：</td>
               <td>                   
                    <asp:RadioButtonList ID="EditOtitle" runat="server" class="radio"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>   
                      <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00027',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">允许浏览发言：</td>
               <td>                  
                    <asp:RadioButtonList ID="ReadTitle" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>   
                <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00028',this)">帮助</span>
               </td>
             </tr>             
              <tr>
               <td width="20%" align="right">解固/固顶帖子：</td>
               <td>                 
                    <asp:RadioButtonList ID="TopTitle" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>    
                <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00031',this)">帮助</span>
               </td>
             </tr>
              <tr>
               <td width="20%" align="right">精华帖子操作：</td>
               <td>
                    <asp:RadioButtonList ID="GoodTitle" runat="server" class="radio"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>   
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00032',this)">帮助</span>
               </td>
             </tr> 
              <tr>
               <td width="20%" align="right">锁定用户：</td>
               <td>
                   
              <asp:RadioButtonList ID="LockUser" runat="server" class="radio"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>     
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00033',this)">帮助</span>
               </td>
             </tr> 
             <tr>
               <td width="20%" align="right">用户标识：</td>
               <td>
                 <asp:TextBox  class="input8" ID="UserFlag" runat="server" Text="FS_"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00034',this)">帮助</span>
               </td>
             </tr> 
              <tr>
               <td width="20%" align="right">审核主题：</td>
               <td>                  
                   <asp:RadioButtonList ID="CheckTtile" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>   
                    <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00035',this)">帮助</span>
               </td>
             </tr>
              <tr>
               <td width="20%" align="right">对独立用户进行奖励/惩罚：</td>
               <td>                   
                    <asp:RadioButtonList ID="EncUser" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>   
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00037',this)">帮助</span>
               </td>
             </tr> 
              <tr>
               <td width="20%" align="right">锁定/解锁其它人帖子：</td>
               <td>                  
                   <asp:RadioButtonList ID="OCTF" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>  
                    <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00038',this)">帮助</span>
               </td>
             </tr>  
             <tr>
               <td width="20%" align="right"> 积分兑换金币/金币兑换积分：</td>
               <td>
                   <asp:TextBox class="input8" ID="GIChange" MaxLength="3" runat="server" Text="0|1"></asp:TextBox>
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00041',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">兑换比例：</td>
               <td>
               <asp:TextBox class="input8" ID="GTChageRate" MaxLength="30" Text="1000|1/10000" runat="server"></asp:TextBox>
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00042',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">登陆时候获得的积分|G币：</td>
               <td>
                  <asp:TextBox class="input8" ID="LoginPoint" runat="server" MaxLength="10" Text="5|0"></asp:TextBox>
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00043',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">注册时候获得的积分|G币：</td>
               <td>
                   <asp:TextBox class="input8" ID="RegPoint" runat="server" MaxLength="10" Text="2|0"></asp:TextBox>
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00048',this)">帮助</span>
               </td>
             </tr>
              <tr>
               <td width="20%" align="right">是否允许创建社群：</td>
               <td>
                    <asp:RadioButtonList ID="GroupTF" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>   
                   <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00044',this)">帮助</span>
               </td>
             </tr> 
             <tr>
               <td width="20%" align="right">社群最大允许人数：</td>
               <td>
                   <asp:TextBox class="input8" ID="GroupPerNum" Text="100" MaxLength="3" runat="server"></asp:TextBox>
                     <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00046',this)">帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">允许最大建立数量：</td>
               <td>
                   <asp:TextBox class="input8" ID="GroupCreatNum" Text="3" MaxLength="2" runat="server"></asp:TextBox>
                  <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_usergroup_add_00047',this)">帮助</span>
               </td>
             </tr>
               <tr style="display:none;">
          <td width="20%" align="right"><div align="right">发表评论间隔时间(秒)</div></td>
          <td><asp:TextBox class="input8" ID="PostCommTime" runat="server" Text="60"></asp:TextBox>
          <a href="#" class="a1">帮助1</a></td>
        </tr>  
          <tr style="display:none;">
          <td width="20%" align="right"><div align="right">上传文件个数(个)</div></td>
          <td><asp:TextBox class="input8" ID="upfileNum" runat="server" Text="10"></asp:TextBox>
          < <a href="#" class="a1">帮助1</a></td>
        </tr> 
         <tr style="display:none;">
          <td width="20%" align="right"><div align="right">每天最大上传数(个)</div></td>
          <td><asp:TextBox class="input8" ID="DayUpfilenum" runat="server" Text="3"></asp:TextBox>
           <a href="#" class="a1">帮助1</a></td>
        </tr>
         <tr style="display:none;">
          <td width="20%" align="right"><div align="right">
              允许创建讨论组</div></td>
          <td>
                <asp:RadioButtonList ID="DicussTF" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>
           <a href="#" class="a1">帮助1</a></td>
        </tr>      
        <tr style="display:none;">
          <td width="20%" align="right"><div align="right">
              查看其他会员资料</div></td>
          <td>
                <asp:RadioButtonList ID="ReadUser" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>             
           <a href="#" class="a1">帮助1</a></td>
        </tr> 
           <tr style="display:none;">
          <td width="20%" align="right"><div align="right">注册多少分钟后允许发言</div></td>
          <td><asp:TextBox class="input8" ID="RegMinute" MaxLength="3" runat="server" Text="10"></asp:TextBox>
           <a href="#" class="a1">帮助1</a></td>
        </tr> 
                 
                 
        <tr style="display:none;">
          <td width="20%" align="right"><div align="right">
              发言允许HTML编辑器</div></td>
          <td>
              <asp:RadioButtonList ID="PostTitleHTML" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>          
          <a href="#" class="a1">帮助1</a></td>
        </tr> 
         <tr style="display:none;">
          <td width="20%" align="right"><div align="right">
              移动自己的帖子</div></td>
          <td>
              <asp:RadioButtonList ID="MoveSelfTitle" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>             
           <a href="#" class="a1">帮助1</a></td>
        </tr> 
                 
        <tr style="display:none;">
          <td width="20%" align="right"><div align="right">
              移动他人帖子</div></td>
          <td>
          
              <asp:RadioButtonList ID="MoveOTitle" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>             
           <a href="#" class="a1">帮助1</a></td>
        </tr> 
         <tr style="display:none;">
        <td width="20%" align="right"><div align="right">
              限制IP访问</div></td>
          <td>
              <asp:RadioButtonList ID="IPTF" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>             
          <a href="#" class="a1">帮助1</a></td>
        </tr> 
         <tr style="display:none;">
          <td width="20%" align="right"><div align="right">允许用户选择风格</div></td>
          <td>
          
              <asp:RadioButtonList ID="StyleTF" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1"><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0" Selected=True><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>     
               <a href="#" class="a1">帮助1</a></td>
        </tr> 
        <tr style="display:none;">
          <td width="20%" align="right"><div align="right">会员上传头像最大允许(kb)</div></td>
          <td><asp:TextBox class="input8" ID="UpfaceSize" MaxLength="3" runat="server" Text="20"></asp:TextBox>
          <a href="#" class="a1">帮助1</a></td>
        </tr> 
         <tr style="display:none;">
          <td width="20%" align="right"><div align="right">
              允许发表主题</div></td>
          <td>
                <asp:RadioButtonList ID="PostTitle" runat="server" class="radio" RepeatDirection="Horizontal" RepeatLayout="Flow">
                  <asp:ListItem Value="1" Selected=True><span class="span1">是</span></asp:ListItem>
                  <asp:ListItem Value="0"><span class="span1">否</span></asp:ListItem>
              </asp:RadioButtonList>          
          <a href="#" class="a1">帮助1</a></td>
        </tr>      
        <tr style="display:none;">
          <td width="20%" align="right"><div align="right">社群空间大小(kb)</div></td>
          <td><asp:TextBox class="input8" ID="GroupSize" runat="server" Text="2000"></asp:TextBox>
           <a href="#" class="a1">帮助1</a></td>
        </tr> 
           </table>
            <div class="nxb_submit" >
            <asp:HiddenField ID="gids" runat="server" />
                <asp:Button ID="sumbitsave" runat="server" class="xsubmit1 mar" Text=" 确 定 " 
                    onclick="sumbitsave_Click"  />
                 <input type="reset" name="" value="重置"  class="xsubmit1 mar"/>
             </div>
        </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

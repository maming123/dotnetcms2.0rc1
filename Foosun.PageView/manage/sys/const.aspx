<%@ Page Language="C#" AutoEventWireup="true" Inherits="manage_Sys_const" Codebehind="const.aspx.cs" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
<form id="Form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>配置文件管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>配置文件管理 
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table">
    <tr>
      <td align="right" width="20%">后台管理目录：</td>
      <td>
         <asp:TextBox  ID="dirMana" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0001',this)">帮助</span>
         <font color="red">提示:修改目录后请立即手动修改物理文件名称(名称必须相同)</font>
      </td>
    </tr>
    <tr>
      <td align="right" width="20%">后台模版目录：</td>
      <td>
          <asp:TextBox ID="dirTemplet" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0002',this)">帮助</span>
          <font color="red">提示:修改此目录可能会对原有数据造成效大影响，请慎重修改</font>
      </td>
    </tr>
     <tr>
      <td align="right" width="20%">虚拟目录：</td>
      <td>
          <asp:TextBox ID="dirDumm" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0003',this)">帮助</span>
      </td>
    </tr>
    <tr>
      <td align="right" width="20%">开启密码保护：</td>
      <td>
       <asp:TextBox ID="protPass" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_Pass',this)">帮助</span>
      </td>
    </tr>
    <tr>
      <td align="right" width="20%">安全码：</td>
      <td>
      <asp:TextBox ID="protRand" Width="200px" runat="server" MaxLength="50" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0004',this)">帮助</span>
      </td>
    </tr>
    <tr>
      <td align="right" width="20%">文件上传目录：</td>
      <td>
    <asp:TextBox ID="dirFile" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0005',this)">帮助</span>
      </td>
    </tr>
    <tr>
      <td align="right" width="20%">统计系统是否使用独立数据库：</td>
      <td>
         <asp:RadioButton ID="stat1" runat="server" onclick="Change(1)" Text="是" GroupName="indeData"  CssClass="checkbox2"/>&nbsp;<asp:RadioButton ID="stat0" runat="server" onclick="Change(0)" Text="否" GroupName="indeData" CssClass="checkbox2" />
         <span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0009',this)">帮助</span>      </td>
    </tr>
    <tr id="stat_dis">
      <td align="right" width="20%">统计系统的数据库连接：</td>
      <td>
      <asp:TextBox ID="sqlConnData" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0014',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right" width="20%">配置文件管理密码：</td>
      <td>
      <asp:TextBox ID="constPass" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0010',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right" width="20%">资源文件管理密码：</td>
      <td>
     <asp:TextBox ID="filePass" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0010',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right" width="20%">资源文件管理目录：</td>
      <td>
      <asp:TextBox ID="filePath" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0010',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right" width="20%">归档表态文件存放目录：</td>
      <td>
    <asp:TextBox ID="dirPige" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0013',this)">帮助</span></td>
    </tr>
    <tr>
      <td align="right" width="20%">保存样式目录：</td>
      <td>
    <asp:TextBox ID="manner" Width="200px" runat="server" CssClass="input8"></asp:TextBox><span class="helpstyle" style="cursor:hand;" title="点击查看帮助" onClick="Help('H_const_0015',this)">帮助</span></td>
    </tr>
  </table>
  <div class="nxb_submit">
      <asp:Button ID="btn_const" runat="server"  OnClick="btn_const_Click" Text="提  交" OnClientClick="{if(confirm('确认要修改吗!')){return true;}return false;}" CssClass="xsubmit1"/>
  </div>
  </div>
  </div>
  </div>
  </div>
</div>
</form>
</body>
<script language="javascript">
function Change(value)
{
    switch(parseInt(value))
    {
        case 1:
        document.getElementById("stat_dis").style.display="";
        break;
        case 0:
        document.getElementById("stat_dis").style.display="none";
        break;
    }
}

</script>
<% showjs(); %>
</html>

<%@ Page Language="C#" ContentType="text/html" AutoEventWireup="true" Inherits="user_photo_add" Debug="true" Codebehind="photo_add.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
</head>
<body class="main_big">
<form id="form1" runat="server" action="" method="post">
  <table width="100%"  border="0" cellpadding="0" cellspacing="0" class="toptable">
    <tr>
      <td height="1" colspan="2"></td>
    </tr>
    <tr>
      <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">相册管理</strong></td>
      <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" /><a href="Photoalbumlist.aspx"  class="list_link">相册管理</a><img alt="" src="../images/navidot.gif" border="0" />添加图片</div></td>
    </tr>
  </table>
  <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
    <tr>
      <td><span class="topnavichar" style="PADDING-LEFT: 14px"><a href="Photoalbumlist.aspx" class="menulist">相册首页</a>&nbsp;┊&nbsp;<a href="photo_add.aspx" class="menulist">添加图片</a>&nbsp;┊&nbsp;<a href="photoclass.aspx" class="menulist">相册分类</a>&nbsp;┊&nbsp;<a href="Photoalbum.aspx" class="menulist">添加相册</a></span></td>
    </tr>
  </table>
  <table width="98%" border="0" align="center" cellpadding="5" cellspacing="1" bgcolor="#FFFFFF" class="Tablist tab" id="insert">
    <tr class="TR_BG_list">
      <td class="list_link" style="text-align: right; width: 179px;"> 相片标题：</td>
      <td class="list_link" style="width: 707px"><asp:TextBox ID="PhotoName" runat="server" Width="350px" CssClass="form"></asp:TextBox>
        &nbsp;相册：
        <asp:DropDownList ID="Photoalbum" runat="server" Width="133px"> </asp:DropDownList></td>
    </tr>
    <tr class="TR_BG_list">
      <td class="list_link" style="text-align: right; width: 179px;"> 图片：</td>
      <td class="list_link" style="width: 707px"><div style="margin:10px; width:50%; text-align:center;">
          <div align="center"><img src="../images/nopic_supply.gif" width="90" height="90" id="pic_p_1" /> </div>
          <div align="center" style="display:none"><img src="../images/nopic_supply.gif" width="90" height="90" id="pic_p_2" /></div>
          <div align="center" style="display:none"> <img src="../images/user/nopic_supply.gif" width="90" height="90" id="pic_p_3" /></div>
          <asp:TextBox ID="pic_p_1url" runat="server" Width="0px" BackColor="#F8FDFF" BorderStyle="None"></asp:TextBox>
          <asp:TextBox ID="pic_p_1ur2" runat="server" Width="0px" BackColor="#F8FDFF" BorderStyle="None"></asp:TextBox>
          <asp:TextBox ID="pic_p_1ur3" runat="server" Width="92px" BackColor="#F8FDFF" BorderStyle="None"></asp:TextBox>
          <div align="center">
            <input  class="form" type="button" value="上 传"  onclick="selectFile('user_pic',
document.form1.pic_p_1url,300,500);" />
            &nbsp;&nbsp;
            <input id="Button2" type="button" value="删 除" class="form" onClick="dels_1();"/>
          </div>
          <div align="center"  style="display:none">
            <input  class="form" type="button" value="上 传"  onclick="selectFile('user_pic',document.form1.pic_p_1ur2,300,500);" />
            &nbsp;&nbsp;
            <input id="Button3" type="button" value="删 除" class="form" onClick="dels_2();"/>
          </div>
          <div align="center" style="display:none">
            <input  class="form" type="button" value="上 传"  onclick="selectFile('user_pic',document.form1.pic_p_1ur3,300,500);" />
            &nbsp;&nbsp;
            <input id="Button4" type="button" value="删 除"  class="form" onClick="dels_3();"/>
          </div>
        </div></td>
    </tr>
    <tr class="TR_BG_list">
      <td class="list_link" style="text-align: right; width: 179px;"> 图片说明：</td>
      <td class="list_link" style="width: 707px"><asp:TextBox ID="PhotoContent" runat="server" Height="130px" TextMode="MultiLine" Width="480px" CssClass="textarea1"></asp:TextBox></td>
    </tr>
    <tr class="TR_BG_list">
      <td class="list_link" style="text-align: right; width: 179px;"></td>
      <td class="list_link" style="width: 707px"><asp:Button ID="server" runat="server" Text="保存到相册" Width="115px" OnClick="server_Click" CssClass="textarea1"/></td>
    </tr>
  </table>
  <br />
  <br />
  <table width="100%" height="74" border="0" cellpadding="0" cellspacing="0" class="copyright_bg">
    <tr>
      <td><div align="center">
          <%Response.Write(CopyRight); %>
        </div></td>
    </tr>
  </table>
</form>
</body>
</html>
<script type="text/javascript" language="javascript">
new Form.Element.Observer($('pic_p_1url'),1,pics_1);
	function pics_1()
		{
			if ($('pic_p_1url').value=='')
			{
				$('pic_p_1').src='../Images/nopic_supply.gif'
			}
			else
			{
			$('pic_p_1').src=$('pic_p_1url').value.replace('{@UserdirFile}','<% Response.Write(UdirDumm); %><% Response.Write(Foosun.Config.UIConfig.UserdirFile); %>');
			}
		} 
new Form.Element.Observer($('pic_p_1ur2'),1,pics_2);
	function pics_2()
		{
			if($('pic_p_1ur2').value=='')
			{
			$('pic_p_2').src='../Images/nopic_supply.gif'
			}
			else
			{
			$('pic_p_2').src=$('pic_p_1ur2').value.replace('{@UserdirFile}','/<% Response.Write(Foosun.Config.UIConfig.dirDumm); %>/<% Response.Write(Foosun.Config.UIConfig.UserdirFile); %>');
			}
		}
new Form.Element.Observer($('pic_p_1ur3'),1,pics_3);
	function pics_3()
		{
			if($('pic_p_1ur3').value=='')
			{
			$('pic_p_3').src='../Images/nopic_supply.gif'
			}
			else
			{
			$('pic_p_3').src=$('pic_p_1ur3').value.replace('{@UserdirFile}','/<% Response.Write(Foosun.Config.UIConfig.dirDumm); %>/<% Response.Write(Foosun.Config.UIConfig.UserdirFile); %>');
			}
		} 
		
function dels_1()
	{
		document.form1.pic_p_1url.value='../../sysImages/user/nopic_supply.gif'
	}
function dels_2()
	{
		document.form1.pic_p_1ur2.value='../../sysImages/user/nopic_supply.gif'
	}
function dels_3()
	{
		document.form1.pic_p_1ur3.value='../../sysImages/user/nopic_supply.gif'
	}
</script>
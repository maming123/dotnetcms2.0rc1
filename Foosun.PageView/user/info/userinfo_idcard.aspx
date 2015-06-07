<%@ Page Language="C#" AutoEventWireup="true" Inherits="user_info_userinfo_idcard" Codebehind="userinfo_idcard.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
	<link type="text/css" rel="stylesheet" href="../css/base.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
</head>
<body class="main_big">
<div id="dialog-message" title="提示"></div>
      <form id="form1" runat="server"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
          <td height="1" colspan="2"></td>
        </tr>
        <tr>
          <td width="57%" class="matop_tab_left"><strong  style="font-size:14px; line-height:35px; margin-left:10px;">修改会员资料</strong></td>
    <td width="43%" class="list_link"  style="PADDING-LEFT: 14px" ><div style="text-align:right; margin-right:10px;">位置导航：<a href="../main.aspx" target="sys_main" class="list_link">首页</a><img alt="" src="../images/navidot.gif" border="0" /><a href="userinfo.aspx" class="list_link">我的资料</a><img alt="" src="../images/navidot.gif" border="0" />修改安全资料</div></td>
        </tr>
</table>
      <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
        <tr>
          <td style="padding-left:14px;"><a class="topnavichar" href="userinfo.aspx">我的资料</a>　<a class="topnavichar" href="userinfo_update.aspx">修改基本信息</a>　<a class="topnavichar" href="userinfo_contact.aspx">修改联系资料</a>　<a class="topnavichar" href="userinfo_safe.aspx">修改安全资料</a>　<a class="topnavichar" href="userinfo_idcard.aspx"><font color="red">修改实名认证</font></a></td>
        </tr>
</table>

    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="Navitable">
            <tr>
              <td style="padding-left:14px;">认证状态：<span id="icardcertstat" runat="server" /></td>
            </tr>
    </table>
    <label id="isCertstat" runat="server" />
   </form>
<br />
<br />
 <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px">
   <tr>
     <td align="center"><label id="copyright" runat="server" /></td>
   </tr>
 </table>
 <input type="hidden" id="ischange" value="ischange" />
 </body>
</html>
 <script language="javascript" type="text/javascript">
    function subup()
    {
       if(document.form1.f_IDcardFiles.value==""||document.form1.f_IDcardFiles.value==null)
       {
            alert('请选择一张图片!');
            return false;
       }
       else
       {
            if(document.form1.f_IDcardFiles.value.indexOf("/")==-1)
           {
            alert('图片地址不正确!');
            return false;
           }             
            if(document.form1.f_IDcardFiles.value.length<5)
           {
            alert('图片地址不正确!');
            return false;
           }  
            if(confirm("你确定要认证吗?"))
            {
	            document.form1.action="?isCert=postICARD";
	            document.form1.submit();
	        }
       }
    }
    $(function () {
        if ($.browser.msie) {
            $("#f_IDcardFiles").bind("change", setpic);
        }
        else {
            $("#f_IDcardFiles").bind("blur", setpic)
        } 

    });
    function setpic() {  
            if ($('#f_IDcardFiles').val() == '') {
                $('#imgsrc').attr("src", '../../sysImages/normal/nopic.gif');
            }
            else {
                $('#imgsrc').attr("src", $('#f_IDcardFiles').val().toLowerCase().replace('{@userdirfile}', '<% Response.Write(Foosun.Config.UIConfig.UserdirFile); %>'));
            }
    }
  


 </script>
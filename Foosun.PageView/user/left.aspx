<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Foosun.PageView.user.left" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title><%Response.Write(Foosun.Config.UIConfig.HeadTitle); %></title>
    <link type="text/css" rel="stylesheet" href="css/base.css" />
    <link type="text/css" rel="stylesheet" href="css/style.css"/>
	<script src="/Scripts/jquery.js" type="text/javascript"></script>
	<script type="text/javascript" language="javascript">
    function show(obj)
	{
        $('.left_con_ul').hide();
        $('#' + obj).show();
    }
    </script>
</head>

<body>
    <div class="left">
      <div class="left_top"><img src="images/conn_25.gif" alt="" /></div>
      <div class="left_con">
         <dl class="left_con_ul" id="list1">
       	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/userinfo.aspx" target="sys_main">我的资料</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="photo/Photoalbumlist.aspx" target="sys_main">我的相册</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/User_ChangePassword.aspx" target="sys_main">修改密码</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/history.aspx?ghtypep=3" target="sys_main">交易明晰</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/getPoint.aspx" target="sys_main">冲值管理</a></span></dt> 
    <dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/Exchange.aspx" target="sys_main">积分兑换</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/announce.aspx" target="sys_main">公告管理</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/collection.aspx" target="sys_main">我的收藏夹</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/mycom.aspx" target="sys_main">我的评论</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/friend.aspx" target="sys_main">申请友情链接</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="info/wap.aspx" target="sys_main">WAP访问</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Rss/RSS.aspx" target="sys_main">RSS订阅</a></span></dt>       
         </dl>
         <dl class="left_con_ul" id="list2" style="display:none;">
          <dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Message/Message_write.aspx" target="sys_main">写新消息</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Message/Message_box.aspx?Id=1" target="sys_main">收件箱</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Message/Message_box.aspx?Id=2" target="sys_main">发件箱</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Message/Message_box.aspx?Id=3" target="sys_main">草稿箱</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Message/Message_box.aspx?Id=4" target="sys_main">废件箱</a></span></dt>       
         </dl>
         <dl class="left_con_ul"  id="list3" style="display:none;">
           <dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Constr/Constr.aspx" target="sys_main">发表文章</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Constr/Constrlist.aspx" target="sys_main">文章管理</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Constr/ConstrClass.aspx" target="sys_main">分类管理</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Constr/Constraccount.aspx" target="sys_main">账号管理</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="Constr/ConstrMoney.aspx" target="sys_main">稿酬记录查询</a></span></dt>        
         </dl>
           <dl class="left_con_ul" id="list4" style="display:none;">
              <dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="discuss/discussManage_list.aspx" target="sys_main">讨论组管理</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="discuss/add_discussManage.aspx" target="sys_main">创建讨论组</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="discuss/discussacti.aspx" target="sys_main">创建活动</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="discuss/discussacti_list.aspx" target="sys_main">活动管理</a></span></dt> 
         </dl>
           <dl class="left_con_ul" id="list5" style="display:none;">
             <dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="friend/friendmanage.aspx" target="sys_main">好友分类</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="friend/friendList.aspx" target="sys_main">好友管理</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="friend/friendmanage_add.aspx" target="sys_main">添加好友分类</a></span></dt> 
	<dt class="left_con_ul_dt"><%--<input type="image" value="" name="n" alt="" src="images/cc_03.gif"  class="inp"/>--%><span><a class="menu_ctr" href="friend/friend_add.aspx" target="sys_main">添加好友</a></span></dt> 
         </dl>
      </div>
      <div class="left_end"></div>
      <div class="clear"></div>
    </div>
</body>
</html>


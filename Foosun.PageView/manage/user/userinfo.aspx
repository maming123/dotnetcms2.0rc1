<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userinfo.aspx.cs" Inherits="Foosun.PageView.manage.user.userinfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<link href="/CSS/jquery-ui-1.10.2.custom.min.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function g(o) { return document.getElementById(o); }
    function hover_zzjs_net(n, m, k) {
        //m表示开始id，k表示结束id
        for (var i = m; i <= k; i++) {
            g('tab_zzjs_' + i).className = 'nor_zzjs';
            g('tab_zzjs_0' + i).className = 'undis_zzjs_net';
        }
        g('tab_zzjs_0' + n).className = 'dis_zzjs_net';
        g('tab_zzjs_' + n).className = 'hovertab_zzjs';
    }
    $(function () {
        $("#birthday").datepicker({changeMonth: true,changeYear: true});
        $("#RegTime").datepicker({ changeMonth: true, changeYear: true });
        $("#LastLoginTime").datepicker({ changeMonth: true, changeYear: true });
    });
</script>
</head>

<body>
<form id="form1" runat="server">
<div id="dialog-message" title="提示"></div>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>修改会员资料 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="userlist.aspx">会员管理</a>>>修改会员资料
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
       <div class="newxiu_lan">
          <ul class="tab_zzjs_" id="tab_zzjs_">
             <li id="tab_zzjs_1" class="hovertab_zzjs" onclick="x:hover_zzjs_net(1,1,4);">基本信息</li>
             <li id="tab_zzjs_2" class="nor_zzjs" onclick="x:hover_zzjs_net(2,1,4);">联系资料</li>
             <li id="tab_zzjs_3" class="nor_zzjs" onclick="x:hover_zzjs_net(3,1,4);">安全资料</li>
             <li id="tab_zzjs_4" class="nor_zzjs" onclick="x:hover_zzjs_net(4,1,4);">基本状态/实名认证</li>
          </ul>
          <div class="newxiu_bot">
             <div class="dis_zzjs_net" id="tab_zzjs_01">
                <div class="newxiu_base">
                   <table class="nxb_table">
                      <tr>
                         <td width="15%" align="right">昵称：</td>
                         <td>
                            <asp:TextBox ID="NickName" class="input8" runat="server"  MaxLength="20"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="f_NickName" runat="server" 
                                 ControlToValidate="NickName" Display="Dynamic" 
                                 ErrorMessage="<span class='reshow'>(*)请填写昵称，最大长度为20字符</span>" 
                                 ValidationGroup="info" SetFocusOnError="True"></asp:RequiredFieldValidator>
                           <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0001',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">真实姓名：</td>
                         <td>
                           <asp:TextBox ID="RealName" runat="server" MaxLength="20" class="input8"></asp:TextBox>
                          	<span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_update_00030',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">会员组：</td>
                         <td>
                            <label id="GroupNumber" runat="server" />
                          <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_update_group',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">性别：</td>
                         <td>
                            <label id="sex" runat="server" />
                          <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0002',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">电子邮件：</td>
                         <td>
                            <asp:TextBox class="input8" ID="email" runat="server"  MaxLength="220"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                 runat="server"                       ErrorMessage="邮件格式不正确" 
                                 ControlToValidate="email" 
                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                 ValidationGroup="info" SetFocusOnError="True"></asp:RegularExpressionValidator>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">出生日期：</td>
                         <td>
                           <asp:TextBox class="input8" ID="birthday" runat="server"  MaxLength="12"></asp:TextBox>
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0003',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">民族：</td>
                         <td>
                           <asp:TextBox class="input8" ID="Nation" runat="server" MaxLength="12"></asp:TextBox>
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0004',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">籍贯：</td>
                         <td>
                            <asp:TextBox class="input8" ID="nativeplace" runat="server" MaxLength="20"></asp:TextBox>
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0005',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">用户签名：</td>
                         <td>
                            <div class="textdiv">
                            <asp:TextBox  ID="Userinfo" runat="server" TextMode="MultiLine" MaxLength="3000" class="textarea1""></asp:TextBox>
                              <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0006',this)">帮助</span>
                            </div>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">头像：</td>
                         <td>
                           <asp:TextBox class="input8" ID="UserFace" runat="server" MaxLength="220"></asp:TextBox>
                            <a href="javascript:selectFile('UserFace','图片选择','pic','400','300');document.form1.UserFace.focus();"><img src="../imges/bgxiu_14.gif" alt="" /></a>
                            头像宽|高<asp:TextBox ID="userFacesize" runat="server"  class="input9" MaxLength="7"></asp:TextBox>
                           <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0007',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">性格：</td>
                         <td>
                            <div class="textdiv">
                            	<asp:TextBox class="textarea1" ID="character" runat="server" TextMode="MultiLine" MaxLength="3000"></asp:TextBox><span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0008',this)">帮助</span>
                            </div>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">爱好：</td>
                         <td>
                            <div class="textdiv">
                            <asp:TextBox class="textarea1" ID="UserFan" runat="server" TextMode="MultiLine" MaxLength="3000"></asp:TextBox>
                             <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0009',this)">帮助</span>
                            </div>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">组织关系：</td>
                         <td><asp:TextBox class="input8" ID="orgSch" runat="server" MaxLength="12"></asp:TextBox>
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0010',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">职业：</td>
                         <td><asp:TextBox class="input8" ID="job" runat="server" MaxLength="30"></asp:TextBox>
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0011',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">学历：</td>
                         <td>
                            <asp:TextBox class="input8" ID="education" runat="server" MaxLength="20"></asp:TextBox>
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0012',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">毕业院校：</td>
                         <td>
                            <asp:TextBox class="input8" ID="Lastschool" runat="server" MaxLength="80"></asp:TextBox>
                           <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0013',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">是否结婚：</td>
                         <td>
                         <label id="marriage" runat="server" />                          
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_0014',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right"> 对外开放联系方式：</td>
                         <td>
                         <label id="isopen" runat="server" />                         
                            <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_userinfo_manage_00015',this)">帮助</span>
                         </td>
                      </tr>
                         <tr>
                         <td width="15%" align="right"></td>
                         <td>
                         <asp:Button ID="sumbitsave" runat="server" OnClick="submitSave" CssClass="xsubmit1 mar" Text=" 确 定 " ValidationGroup="info" />
				         <input name="reset" type="reset" value=" 重 置 " class="xsubmit1 mar" />
                         </td>
                      </tr>
                   </table>
                </div>
             </div>
             <div class="undis_zzjs_net" id="tab_zzjs_02">
                 <div class="newxiu_base">
                   <table class="nxb_table">
                      <tr>
                         <td width="15%" align="right">省份：</td>
                         <td>
                            <asp:TextBox class="input8" ID="province" runat="server"   MaxLength="20"></asp:TextBox>
                             <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0002',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">城市：</td>
                         <td>
                            <asp:TextBox class="input8" ID="City" runat="server"   MaxLength="20"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_update_0003',this)">帮助</span>
                         </td>
                      </tr> 
                      <tr>
                         <td width="15%" align="right">地址：</td>
                         <td>
                            <asp:TextBox class="input8" ID="Address" runat="server" ></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0004',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">邮政编码：</td>
                         <td>
                            <asp:TextBox class="input8" ID="Postcode" runat="server"   MaxLength="10"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0005',this)">帮助</span>
                         </td>
                      </tr> 
                      <tr>
                         <td width="15%" align="right">家庭联系电话：</td>
                         <td>
                            <asp:TextBox class="input8" ID="FaTel" runat="server"   MaxLength="30"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0006',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">工作电话：</td>
                         <td>
                            <asp:TextBox class="input8" ID="WorkTel" runat="server"   MaxLength="30"></asp:TextBox> 
                             <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0007',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">传真：</td>
                         <td>
                            <asp:TextBox class="input8" ID="Fax" runat="server"   MaxLength="30"></asp:TextBox>  
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0009',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">QQ：</td>
                         <td>
                            <asp:TextBox class="input8" ID="QQ" runat="server"   MaxLength="30"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0010',this)">帮助</span>
                         </td>
                      </tr>    
                      <tr>
                         <td width="15%" align="right">MSN：</td>
                         <td>
                            <asp:TextBox class="input8" ID="MSN" runat="server"   MaxLength="30"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_update_0011',this)">帮助</span>
                         </td>
                      </tr> 
                        <tr>
                         <td width="15%" align="right"></td>
                         <td>                         
                         <asp:Button ID="btn_contact" runat="server" CssClass="xsubmit1 mar" Text=" 确 定 "  OnClick="btncontact" />
                         <input name="reset" type="reset" value=" 重 置 "  class="xsubmit1 mar" />
                         </td>
                      </tr>     
                   </table>
                </div>
             </div>
             <div class="undis_zzjs_net" id="tab_zzjs_03">
                 <div class="newxiu_base">
                   <table class="nxb_table">
                      <tr>
                         <td width="15%" align="right">新密码：</td>
                         <td>
                            <asp:TextBox class="input8" TextMode="Password" ID="oldpassword" runat="server"   MaxLength="20"></asp:TextBox>
 <asp:RequiredFieldValidator ID="f_oldpassword" runat="server" ControlToValidate="oldpassword" 
                                 Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写新密码，长度为3-18</span>" 
                                 ValidationGroup="safe"></asp:RequiredFieldValidator>
                           <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_safe_0004',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">确认新密码：</td>
                         <td>
                            <asp:TextBox class="input8" TextMode="Password" ID="password" runat="server"  MaxLength="20"></asp:TextBox>
          <asp:RequiredFieldValidator ID="f_password" runat="server" ControlToValidate="password" 
                                 Display="Dynamic" ErrorMessage="<span class='reshow'>(*)请填写确认密码，长度为3-18</span>" 
                                 ValidationGroup="safe"></asp:RequiredFieldValidator>
                                 <asp:CompareValidator ID="CompareValidator1" Display="Dynamic"
                                     runat="server" ErrorMessage="<span class='reshow'>两次密码不一样</span>" 
                                 ControlToCompare="oldpassword" ControlToValidate="password" 
                                 ValidationGroup="safe"></asp:CompareValidator>
                           <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_safe_0003',this)">帮助</span>
                         </td>
                      </tr> 
                      <tr>
                         <td width="15%" align="right">密码问题：</td>
                         <td>
                            <asp:TextBox class="input8" ID="PassQuestion" runat="server"  MaxLength="20"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                 ControlToValidate="PassQuestion" Display="Dynamic" 
                                 ErrorMessage="<span class='reshow'>(*)请填写密码问题</span>" ValidationGroup="safe"></asp:RequiredFieldValidator>
                           <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_safe_0001',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">密码答案：</td>
                         <td>
                            <asp:TextBox class="input8" ID="PassKey" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ControlToValidate="PassKey" Display="Dynamic" 
                                 ErrorMessage="<span class='reshow'>(*)请填写密码答案</span>" ValidationGroup="safe"></asp:RequiredFieldValidator>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_safe_0002',this)">帮助</span>
                         </td>
                      </tr> 
                      <tr>
                         <td width="15%" align="right"></td>
                         <td>                         
                         <asp:Button ID="btn_safe" runat="server" CssClass="xsubmit1 mar" Text=" 确 定 "  
                                 OnClick="btnsafe" ValidationGroup="safe" />
                         <input name="reset" type="reset" value=" 重 置 "  class="xsubmit1 mar" />
                         </td>
                      </tr>    
                   </table>
                </div>
             </div>
             <div class="undis_zzjs_net" id="tab_zzjs_04">
                 <div class="newxiu_base">
                   <table class="nxb_table">
                      <tr>
                         <td width="15%" align="right">锁定：</td>
                         <td><label runat="server" id="lockTF" />
                            <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_base_0001',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">管理员：</td>
                         <td>
                           <label runat="server" id="adminTF" />
                            <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_base_0002',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">会员组：</td>
                         <td>
                            <label id="GroupList" runat="server" />
                            <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_base_0003',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">证件类型：</td>
                         <td>                        
                         <select class="select3" runat="server"  ID="CertType" name="glist" onchange="document.form1.CertType.value=this.options[this.selectedIndex].text;;">
          <option value="">选择证件</option>
          <option value="身份证">身份证</option>
          <option value="军官证">军官证</option>
          <option value="学生证">学生证</option>
          <option value="其他">其他</option>
          </select>
                           <span class="helpstyle" style="cursor:help;" title="点击查看帮助" onclick="Help('H_userinfo_base_0004',this)">帮助</span>
                      </tr>
                      <tr>
                         <td width="15%" align="right">证件号码：</td>
                         <td>
                            <asp:TextBox class="input8" ID="CertNumber" runat="server"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_0005',this)">帮助</span>
                             <%--<a href="#" class="a6">认证状态:<span>未通过认证</span></a>--%>
                             <a class="list_link" href="userIDCard.aspx?id=<% Response.Write(Request.QueryString["id"]);%>">认证状态:<span id="isCerts" runat="server" /></a>
                         </td>
                      </tr> 
                      <tr>
                         <td width="15%" align="right">积分：</td>
                         <td>
                            <asp:TextBox class="input8" ID="ipoint" runat="server"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_0006',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">G币：</td>
                         <td>
                            <asp:TextBox class="input8" ID="gpoint" runat="server"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_0007',this)">帮助</span>
                         </td>
                      </tr> 
                      <tr>
                         <td width="15%" align="right">魅力值：</td>
                         <td>
                            <asp:TextBox class="input8" ID="cpoint" runat="server"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_0008',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">人气值：</td>
                         <td>
                            <asp:TextBox class="input8" ID="epoint" runat="server"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_0009',this)">帮助</span>
                         </td>
                      </tr> 
                      <tr>
                         <td width="15%" align="right">活跃值：</td>
                         <td>                            
                            <asp:TextBox class="input8" ID="apoint" runat="server"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00010',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">注册日期：</td>
                         <td>
                            <asp:TextBox class="input8" ReadOnly="true" ID="RegTime" runat="server"></asp:TextBox>
                             <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00011',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">最后登陆：</td>
                         <td>
                            <asp:TextBox class="input8"  ReadOnly="true" ID="LastLoginTime" runat="server"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00017',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">在线时间：</td>
                         <td>
                            <asp:TextBox class="input8" ID="onlineTime" runat="server"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00012',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">登陆次数：</td>
                         <td>
                            <asp:TextBox class="input8" ID="LoginNumber" runat="server"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00013',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">同一IP最大登陆次数：</td>
                         <td>
                            <asp:TextBox class="input8" ID="LoginLimtNumber" runat="server" Text="0"></asp:TextBox>
                           <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00014',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">最后登陆IP陆：</td>
                         <td>
                            <asp:TextBox class="input8" ID="lastIP" runat="server"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00015',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="15%" align="right">所属频道：</td>
                         <td>
                            <asp:TextBox class="input8" ID="TxtSite" runat="server"></asp:TextBox>
                            <span class="helpstyle" style="cursor:help;"  title="点击查看帮助" onclick="Help('H_userinfo_base_00016',this)">帮助</span>
                         </td>
                      </tr>
                     <tr>
                         <td width="15%" align="right"></td>
                         <td><span>说明：此项前台会员是不允许修改的 </span></td>
                      </tr>
                      <tr>
                         <td width="15%" align="right"></td>
                         <td>                         
                         <asp:Button ID="Button1" runat="server" CssClass="xsubmit1 mar" Text=" 确 定 "  
                                 OnClick="btnbase"/>
                         <input name="reset" type="reset" value=" 重 置 "  class="xsubmit1 mar" />
                         </td>
                      </tr>    
                   </table>
                </div>
             </div>
             <div class="nxb_submit" >
             <asp:HiddenField ID="suid" runat="server" />
                 <%--<input type="submit" name="" value="确定" class="xsubmit1 mar" />
                 <input type="reset" name="" value="重置"  class="xsubmit1 mar"/>--%>
             </div>
          </div>
       </div>
   </div>
</div>
</div>
</form>
</body>
</html>
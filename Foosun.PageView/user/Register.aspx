<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Foosun.PageView.user.Register" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>注册</title>
<link type="text/css" rel="stylesheet" href="css/base.css" />
<link type="text/css" rel="stylesheet" href="css/login.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#usernameBox").blur(function () {
            checkuser();
        });
        $("#pwdBox").blur(function () {
            checkpwd();
        });
        $('#pwdsBox').blur(function () {
            checkpwds();
        });
        $('#emailBox').blur(function () {
            checkemail();
        });
        $('#PassQuestionBox').blur(function () {
            checkqu();
        });
        $('#PassKeyBox').blur(function () {
            checkkey();
        });
        $('#RealNameBox').blur(function () {
            checkRealname();
        });
        $('#NickNameBox').blur(function () {
            checkNickName();
        });
        $('#CertNumberBox').blur(function () {
            checkCertNumber();
        });
        $('#AddressBox').blur(function () {
            checkAddress();
        });
        $('#PostcodeBox').blur(function () {
            checkPostcode();
        });
        $('#MobileBox').blur(function () {
            checkMobile();
        });
        $('#FaxBox').blur(function () {
            checkFax();
        });
        $('#WorkTelBox').blur(function () {
            checkWorkTel();
        });
        $('#FaTelBox').blur(function () {
            checkFaTel();
        });
        $('#QQBox').blur(function () {
            checkQQ();
        });
        $('#MSNBox').blur(function () {
            checkMSN();
        });
        GetSubClass($('#province').val());
    });
    function check() {
        if ($("#usernameBox").length>0) {
            if (!checkuser()) {
                $("#usernameBox").focus();
                return false;
            }
        }
        if ($("#pwdBox").length > 0) {
            if (!checkpwd()) {
                $("#pwdBox").focus();
                return false;
            }
        }
        if ($("#pwdsBox").length > 0) {
            if (!checkpwds()) {
                $("#pwdsBox").focus();
                return false;
            }
        }
        if ($('#emailBox').length > 0) {
            if (!checkemail()) {
                $("#emailBox").focus();
                return false;
            }
        }
        if ($('#PassQuestionBox').length > 0) {
            if (!checkqu()) {
                $("#PassQuestionBox").focus();
                return false;
            }
        }
        if ($('#PassKeyBox').length > 0) {
            if (!checkkey()) {
                $("#PassKeyBox").focus();
                return false;
            }
        }
        if ($('#RealNameBox').length > 0) {
            if (!checkRealname()) {
                $("#RealNameBox").focus();
                return false;
            }
        }
        if ($('#NickNameBox').length > 0) {
            if (!checkNickName()) {
                $("#NickNameBox").focus();
                return false;
            }
        }
        if ($('#CertNumberBox').length > 0) {
            if (!checkCertNumber()) {
                $("#CertNumberBox").focus();
                return false;
            }
        }
        if ($('#AddressBox').length > 0) {
            if (!checkAddress()) {
                $("#AddressBox").focus();
                return false;
            }
        }
        if ($('#PostcodeBox').length > 0) {
            if (!checkPostcode()) {
                $("#PostcodeBox").focus();
                return false;
            }
        }
        if ($('#MobileBox').length > 0) {
            if (!checkMobile()) {
                $("#MobileBox").focus();
                return false;
            }
        }
        if ($('#FaxBox').length > 0) {
            if (!checkFax()) {
                $("#FaxBox").focus();
                return false;
            }
        }
        if ($('#WorkTelBox').length > 0) {
            if (!checkWorkTel()) {
                $("#WorkTelBox").focus();
                return false;
            }
        }
        if ($('#FaTelBox').length > 0) {
            if (!checkFaTel()) {
                $("#FaTelBox").focus();
                return false;
            }
        }
        if ($('#QQBox').length > 0) {
            if (!checkQQ()) {
                $("#QQBox").focus();
                return false;
            }
        }
        if ($('#MSNBox').length > 0) {
            if (!checkMSN()) {
                $("#MSNBox").focus();
                return false;
            }
        }
        if ($('#reginfo').attr("checked") != "checked") {
            setmsg($('#reginfo'), "没有同意注册协议！", 0);
            return false;
        }
        return true;
    }
    function checknull(obj,msg) {
        if ($(obj).val() == "") {
            setmsg(obj, msg, 0);
            return false;
        }
        else {
            return true;
        }
    }
    function setmsg(obj, msg,type) {
        var objs = $(obj).parent().next().children();
        if (type == 0) {
            $(objs).attr("class", "tishi fail");
        }
        else {
            $(objs).attr("class", "tishi suecc");
        }
        $(objs).html("<span>" + msg + "<span>");
    }
    function checkuser() {
        var obj=$("#usernameBox");
        if (!checknull(obj, "用户名不能为空！")) {
            return false;
        }
        var myValue = obj.val();
        //特殊字符正则
        var spReg = new RegExp("[%`~!@#$^&*()=|{}':;'\\[\\]<>/?~！@#￥……&*（）——|{}【】‘；：”“'。，、？]|[+]|[-]", "g");
        //空格检测正则
        var blankReg = new RegExp("\\s+", "g");
        if (spReg.test(myValue)) {
            setmsg(obj, "用户名不能含有特殊字符!", 0);
            return false;
        }
        if (blankReg.test(myValue)) {
            setmsg(obj, "用户名不能含有空格",0);
            return false;
        }
        if (myValue.length > 18 || myValue.length < 4) {
            setmsg(obj, "用户名请输入4到18位字符",0);
            return false;
        }
        var rdata;
        $.ajax({
            type: "POST",
            url: "Register.aspx",
            async: false,     
            data: "Action=checkusername&username="+myValue,
            success: function (data) {
                if (data == "true") {
                    setmsg(obj, "恭喜！此用户名可以注册", 1);
                    rdata= true;
                }
                else {
                    setmsg(obj, data, 0);
                    rdata= false;
                }
            }
        });
        return rdata;
    }
    function checkpwd() {
        var obj = $('#pwdBox');
        if (!checknull(obj, "密码不能为空！")) {
            return false;
        }
        var pwd = obj.val();
        if(pwd.length<4||pwd.length>18){
            setmsg(obj, "用户名请输入4到18位字符", 0);
            return false;
        }
        var lv = 0;
        if (pwd.match(/[a-z]/ig)) { lv++; }
        if (pwd.match(/[0-9]/ig)) { lv++; }
        if (pwd.match(/(.[^a-z0-9])/ig)) { lv++; }
        if (pwd.length > 11&&pwd.length<14) {
            lv = 2;
        }
        else if(pwd.length>13){
            lv=3
        }
        switch (lv) {
            case 0:
                setmsg(obj, "弱", 0);
                break;
            case 1:
                setmsg(obj, "弱", 0);
                break;
            case 2:
                setmsg(obj, "中", 1);
                break;
            case 3:
                setmsg(obj, "强", 1);
                break;
        }
        return true;
    }
    function checkpwds() {
        var obj = $('#pwdsBox');
        if (!checknull(obj, "密码不能为空！")) {
            return false;
        }
        var pwd = obj.val();
        if (pwd.length < 4 || pwd.length > 18) {
            setmsg(obj, "用户名请输入4到18位字符", 0);
            return false;
        }
        if (pwd != $('#pwdBox').val()) {
            setmsg(obj, "两次密码不一致", 0);
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkemail() {
        var obj = $('#emailBox');
        if (!checknull(obj, "电子邮件地址不能为空！")) {
            return false;
        }
        var email = obj.val();
        if (!checkMailJs(email)) {
            setmsg(obj, "电子邮件格式错误", 0);
            return false;
        }
        var rdata;
        $.ajax({
            type: "POST",
            url: "Register.aspx",
            async: false,
            data: "Action=checkemail&email=" + email,
            success: function (data) {
                if (data == "true") {
                    setmsg(obj, "&nbsp;", 1);
                    rdata = true;
                }
                else {
                    setmsg(obj, data, 0);
                    rdata = false;
                }
            }
        });
        return rdata;
    }
    function checkqu() {
        var obj = $('#PassQuestionBox');
        if (!checknull(obj, "问题不能为空！")) {
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkkey() {
        var obj = $('#PassKeyBox');
        if (!checknull(obj, "答案不能为空！")) {
            return false;
        }
        if ($('#PassKeyBox').val() == $('#PassQuestionBox').val()) {
            setmsg(obj, "问题和答案不能相同", 0);
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkRealname() {
        var obj = $('#RealNameBox');
        if (!checknull(obj, "姓名不能为空！")) {
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkNickName() {
        var obj = $('#NickNameBox');
        if (!checknull(obj, "昵称不能为空！")) {
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkCertNumber() {
        var obj = $('#CertNumberBox');
        if (!checknull(obj, "证件号码不能为空！")) {
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkAddress() {
        var obj = $('#AddressBox');
        if (!checknull(obj, "地址不能为空！")) {
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkPostcode() {
        var obj = $('#PostcodeBox');
        if (!checknull(obj, "邮政编码不能为空！")) {
            return false;
        }
        var re = /^[1-9][0-9]{5}$/;
        if (!re.test(obj.val())) {
            setmsg(obj, "邮政编码格式不对！", 0);
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkMobile() {
        var obj = $('#MobileBox');
        if (!checknull(obj, "手机号码不能为空！")) {
            return false;
        }
//      var re = /^0?(13[0-9]|15[0-35-9]|18[0236-9]|14[57])[0-9]{8}$/;
        var re = /^0?1[0-9]{10}$/; //此处只验证11为以1开头数字，如需准确验证请修改此处正则
        if (!re.test(obj.val())) {
            setmsg(obj, "手机格式不对！", 0);
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkFax() {
        var obj = $('#FaxBox');
        if (!checknull(obj, "传真不能为空！")) {
            return false;
        }      
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkWorkTel() {
        var obj = $('#WorkTelBox');
        if (!checknull(obj, "工作电话不能为空！")) {
            return false;
        }
        var re =  /^[0-9]+(-[0-9]+){1,2}$/ ;
        if (!re.test(obj.val())) {
            setmsg(obj, "工作电话格式不对！", 0);
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkFaTel() {
        var obj = $('#FaTelBox');
        if (!checknull(obj, "家庭电话不能为空！")) {
            return false;
        }
        var re = /^[0-9]+(-[0-9]+){1,2}$/;
        if (!re.test(obj.val())) {
            setmsg(obj, "家庭电话格式不对！", 0);
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkQQ() {
        var obj = $('#QQBox');
        if (!checknull(obj, "QQ不能为空！")) {
            return false;
        }
        var re = /^[1-9][0-9]{4,}$/;
        if (!re.test(obj.val())) {
            setmsg(obj, "QQ格式不对！", 0);
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkMSN() {
        var obj = $('#MSNBox');
        if (!checknull(obj, "MSN不能为空！")) {
            return false;
        }
        setmsg(obj, "&nbsp;", 1);
        return true;
    }
    function checkMailJs(mail) {
        var filter = /^[\w-]+[\.]*[\w-]+[@][\w\-]{1,}([.]([\w\-]{1,})){1,3}$/g;
        if (filter.test(mail))
            return true;
        else {
            return false;
        }
    }
    function GetSubClass(CityId) {
        $.get("/user/City_ajax.aspx?CityId=" + CityId + "&rd=" + Math.random(), function (data) {
            $("#citydiv").html(data);
        });
    }
    function showinfo() {
        $("#dialog-message").dialog({
            modal: true,
            width:600
        });
    }
</script>
</head>
<body bgcolor="#fbfbfb">
<form id="form1" runat="server" onsubmit="javascript:return check();">
<div class="regwin_big">
  <div class="reg_top">
    <div class="reg_top">
        <img src="images/reig.gif" alt="" />
    </div>
	<div id="simTestContent" class="simScrollCont">
      <div class="register">
       <div class="register_big">
       <asp:Panel ID="Panel2" runat="server">
		<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	</asp:Panel>
       </div>
      </div>
	</div>
  </div>
</div>
<asp:HiddenField ID="SiteID" runat="server" />
</form>
<table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 38px">
		<tr>
			<td align="center">
				<label id="copyright" runat="server" />
			</td>
		</tr>
	</table>
    <div id="dialog-message" style="display:none"><%=agreement %></div>
</body>
</html>

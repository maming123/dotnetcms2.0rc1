<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="styleadd.aspx.cs" Inherits="Foosun.PageView.manage.label.styleadd" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
	<script type="text/javascript">
	    function comeform(loca_name, loca_itemname, loca_fieldname) { this.loca_name = loca_name; this.loca_itemname = loca_itemname; this.loca_fieldname = loca_fieldname; }
	</script>
</head>
<body>
<div id="dialog-message" title="提示"></div>
	<form id="Form_Style" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>添加/修改样式 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="style.aspx">样式管理</a> >>添加/修改样式
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
<div class="newxiu_lan">
         <ul  class="tab_zzjs_">
            <li class="hovertab_zzjs"  id="TD_putongstyle"><label style="cursor: pointer; width: 100px;" onclick="javascript:ChangeDiv('putongstyle')">普通样式</label></li>
            <li  class="nor_zzjs" id="TD_denglustyle" ><label style="cursor: pointer; width: 100px;" onclick="javascript:ChangeDiv('denglustyle')">登陆样式</label> </li>            
            <li  class="nor_zzjs" id="TD_biaodanstyle"><label style="cursor: pointer; width: 100px;"  onclick="javascript:ChangeDiv('biaodanstyle')">表单样式</label></li>
         </ul>      
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
	<table  class="nxb_table">
		<tr>
			<td align="right" style="width: 13%">
				样式名称：
			</td>
			<td width="90%" align="left">
				<asp:TextBox ID="styleName" runat="server" CssClass="input8" MaxLength="30"></asp:TextBox>
				<asp:DropDownList ID="styleClass" runat="server"  CssClass="select5">
				</asp:DropDownList>
				<span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_styleadd_001',this)">帮助</span><span><span><asp:RequiredFieldValidator ID="RequirestyleName" runat="server" ControlToValidate="styleName" Display="Dynamic" ErrorMessage="<span class=reshow>(*)请填写样式名称</spna>"></asp:RequiredFieldValidator></span><span></span>
			</td>
		</tr>
		<tr id="TR_putongstyle">
			<td align="right" style="width: 13%">
				插入内容：<label id="picContentTF"></label>
			</td>
			<td width="90%" align="left">
				<label id="style_base" runat="server" />
				<label id="style_class" runat="server" />
				<label id="style_special" runat="server" />
				<asp:DropDownList ID="define" runat="server" Width="150px" onchange="javascript:setValue(this.value);">
					<asp:ListItem Value="">自定义字段</asp:ListItem>
				</asp:DropDownList>
				<span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_styleadd_002',this)">帮助</span></td>
		</tr>
		<tr id="TR_denglustyle" style="display: none;">
			<td align="right" style="width: 13%">
				插入内容：<label id="Label1"></label>
			</td>
			<td width="90%" align="left">
				<div class="textdiv1"><asp:DropDownList ID="dengluqian" runat="server" Width="150px" onchange="javascript:getValue(this.value);">
					<asp:ListItem Value="">选择登陆前显示字段</asp:ListItem>
					<asp:ListItem Value="{#Login_Name}">用户名输入框(必选)</asp:ListItem>
					<asp:ListItem Value="{#Login_Password}">密码输入框(必选)</asp:ListItem>
					<asp:ListItem Value="{#Login_Submit}">登陆提交按钮(必选)</asp:ListItem>
					<asp:ListItem Value="{#Login_Reset}">登陆取消按钮</asp:ListItem>
					<asp:ListItem Value="{#Reg_LinkUrl}">注册新用户连接</asp:ListItem>
					<asp:ListItem Value="{#Get_PassLink}">取回密码连接</asp:ListItem>
					<asp:ListItem Value="{#Reg_LinkUrlAdr}">注册新用户地址</asp:ListItem>
					<asp:ListItem Value="{#Get_PassLinkAdr}">取回密码地址</asp:ListItem>
				</asp:DropDownList>
				┊
				<asp:DropDownList ID="dengluhou" runat="server" Width="150px" onchange="javascript:getValue(this.value);">
					<asp:ListItem Value="">选择登陆后显示字段</asp:ListItem>
					<asp:ListItem Value="{#User_Name}">会员姓名</asp:ListItem>
					<asp:ListItem Value="{#User_HomePage}">会员主页</asp:ListItem>
					<asp:ListItem Value="{#User_DiscussGroup}">讨论组连接</asp:ListItem>
					<asp:ListItem Value="{#User_AdminCenter}">控制面版连接</asp:ListItem>
					<asp:ListItem Value="{#User_logout}">退出连接</asp:ListItem>
					<asp:ListItem Value="{#User_HomePageAdr}">会员主页地址</asp:ListItem>
					<asp:ListItem Value="{#User_DiscussGroupAdr}">讨论组地址</asp:ListItem>
					<asp:ListItem Value="{#User_AdminCenterAdr}">控制面版地址</asp:ListItem>
					<asp:ListItem Value="{#User_logoutAdr}">退出地址</asp:ListItem>
				</asp:DropDownList>
				<span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_styleadd_002',this)">帮助</span><br />
				<span style="color: Red">可在此处利用html代码设置显示样式，更多参数在标签设置;登陆样式和显示样式以"$*$"分隔：登陆样式 $*$ 显示样式，否则会引起显示混乱</span>
                </div>
			</td>
		</tr>
		<tr id="TR_biaodanstyle" style="display: none;">
			<td align="right" style="width: 13%">
				插入内容：<label id="Label2"></label>
			</td>
			<td width="90%" align="left">
				<div class="textdiv5"><asp:DropDownList ID="biaodan_bname" runat="server" Width="150px" onchange="javascript:select();">
				</asp:DropDownList>
				┊
				<select class="xselect3" id="biaodan_itemname" onchange="getValue(this.value);">
				</select>
				┊
				<select class="xselect3" id="biaodan_fieldname" onchange="getValue(this.value);">
				</select>
				┊
				<select class="xselect3" id="biaodan_itemtype" onchange="getValue(this.value);">
				</select>
				<span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_styleadd_002',this)">帮助</span>
                </div>
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 13%">
				样式内容：
				<div style="margin-top: 10px;">
					<a style="cursor: pointer;" onclick="javascript:selectFile('ContentTextBox','选择图片','picEdit','750','500');" title="在上传的时候，请在编辑区鼠标点击，设置要上传图片的位置。"><font color="blue" style="margin-right:5px;">选择图片</font></a></div>
			</td>
			<td width="90%" align="left">
				<div class="textdiv1"><textarea rows="10" cols="100" name="ContentTextBox" runat="server" id="ContentTextBox"></textarea></div>
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 13%">
				样式描述：
			</td>
			<td width="90%" align="left">
				<div class="textdiv4"><asp:TextBox ID="Description" runat="server" Height="50px" TextMode="MultiLine" Width="400px" MaxLength="200"></asp:TextBox><span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_styleadd_003',this)">帮助</span></div></td>
		</tr>
		<tr>
			<td style="width: 10%; text-align: center; padding:5px 0;_padding:10px 0;" colspan="2">
				<label>
					<asp:Button ID="Button1" runat="server" class="insubt" onclick="Button1_Click" Text="保存" />
				</label>
				<label>
					<input type="reset" name="UnDo" class="insubt" value="重填" />
				</label>
			</td>
		</tr>
	</table>
    
    </div>
    </div>
    </div>
    </div>
    </div>
     <asp:HiddenField ID="styleID" runat="server" />
	</form>   
</body>
</html>
<script type="text/javascript">

    function ChangeDiv(ID) {
        document.getElementById("TD_putongstyle").className = 'nor_zzjs';
        document.getElementById('TD_denglustyle').className = 'nor_zzjs';
        document.getElementById('TD_biaodanstyle').className = 'nor_zzjs';
        document.getElementById('TD_' + ID).className = 'hovertab_zzjs';
        document.getElementById("TR_putongstyle").style.display = "none";
        document.getElementById("TR_denglustyle").style.display = "none";
        document.getElementById("TR_biaodanstyle").style.display = "none";
        document.getElementById("TR_" + ID).style.display = "";
    }
    function setCaret() {
        if (this.createTextRange) {
            this.caretPos = document.selection.createRange().duplicate();
        }
    }
    var contenttb = document.getElementById("ContentTextBox");
    contenttb.onclick = setCaret;
    contenttb.onselect = setCaret;
    contenttb.onkeyup = setCaret;

    function getValue(textFeildValue) {
        var txb = document.getElementById("ContentTextBox"); //根据ID获得对象
        if (txb.createTextRange && txb.caretPos) {
            var caretPos = txb.caretPos;
            caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == '' ? textFeildValue + '' : textFeildValue;
        } else if (txb.selectionStart) {
            var rangeStart = txb.selectionStart;
            var rangeEnd = txb.selectionEnd;
            var tempStr1 = txb.value.substring(0, rangeStart);
            var tempStr2 = txb.value.substring(rangeEnd);
            txb.value = tempStr1 + textFeildValue + tempStr2;
            if (txb.setSelectionRange) {
                var len = textFeildValue.length;
                txb.focus();
                txb.setSelectionRange(rangeStart + len, rangeStart + len);
                txb.blur();
            }
        } else {
            txb.value += textFeildValue;
        }
    }

    function setValue(value) {
        getValue('{#FS:define=' + value + '}');
    }
    function select() {
        with (document.Form_Style.biaodan_bname) { var loca_formname = options[selectedIndex].value; }
        for (i = 0; i < where.length; i++) {
            if (where[i].loca_name == loca_formname) {
                loca_chname = (where[i].loca_itemname).split("|");
                loca_enname = (where[i].loca_fieldname).split("|");
                for (j = 0; j < loca_chname.length; j++) {
                    with (document.Form_Style.biaodan_itemname) {
                        length = loca_chname.length;
                        if (j == 0) {
                            options[j].text = "表单项中文名";
                            options[j].value = "";
                        }
                        else {
                            options[j].text = loca_chname[j];
                            if (options[j].value != "") {
                                options[j].value = "{#form_item_" + loca_enname[j] + "}";
                            }
                        }
                    }
                    with (document.Form_Style.biaodan_fieldname) {
                        length = loca_chname.length + 3;
                        if (j == 0) {
                            options[j].text = "表单项控件";
                            options[j].value = "";
                        }
                        else {
                            options[j].text = loca_chname[j];
                            if (options[j].value != "") {
                                options[j].value = "{#form_ctr_" + loca_enname[j] + "}";
                            }
                        }
                        if (j + 1 == loca_chname.length) {
                            options[j + 1].text = "验证码";
                            options[j + 1].value = "{#form_ctr_Validate}";
                            options[j + 2].text = "提交按钮";
                            options[j + 2].value = "<input type=\"submit\" value=\"提交\" id=\"submit1\" name=\"submit1\" />";
                            options[j + 3].text = "重置按钮";
                            options[j + 3].value = "<input type=\"reset\" value=\"重置\" id=\"reset1\" name=\"reset1\"/>";
                        }

                    }
                    with (document.Form_Style.biaodan_itemtype) {
                        length = loca_chname.length;
                        if (j == 0) {
                            options[j].text = "表单项值";
                            options[j].value = "";
                        }
                        else {
                            options[j].text = loca_chname[j];
                            if (options[j].value != "") {
                                options[j].value = "{#form_value_" + loca_enname[j] + "}";
                            }
                        }
                    }
                }
                document.Form_Style.biaodan_itemtype.length += 6;
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 6].text = "系统用户名";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 6].value = "{#form_value_username}";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 5].text = "用户IP地址";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 5].value = "{#form_value_submit_ip}";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 4].text = "提交时间";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 4].value = "{#form_value_submit_time}";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 3].text = "管理员用户名";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 3].value = "{#form_value_manage_name}";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 2].text = "管理员回复内容";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 2].value = "{#form_value_manage_content}";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 1].text = "管理员回复时间";
                document.Form_Style.biaodan_itemtype.options[document.Form_Style.biaodan_itemtype.length - 1].value = "{#form_value_manage_addtime}";
                break;
            }
        }
    }
</script>

<%@ Page Language="C#" AutoEventWireup="true" Inherits="SpecialEdit" CodeBehind="SpecialEdit.aspx.cs" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head">
    <title></title><title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
</head>
<body>
    <form id="F_Speical" runat="server" method="post">
    <div class="mian_body">
        <div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>专题管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')" target="sys_main" class="xa3">首页</a><span id="naviClassName" runat="server" />>><label id="m_NewsChar" runat="server" /> 
      </div>
   </div>
</div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="lanlie_lie">
                    <div class="newxiu_base">
                        <table class="nxb_table">
                            <tr>
                                <td width="12%" align="right" class="navi_link" style="width: 13%">
                                    专题中文名：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_Cname" runat="server" class="input8" MaxLength="50"></asp:TextBox>
                                    <span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_001',this)">
                                        帮助</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldS_Cname" runat="server" ErrorMessage="<span class=reshow>(*)请填写专题中文名</spna>"
                                        ControlToValidate="S_Cname" Display="Static"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题英文名：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_Ename" runat="server" MaxLength="50" class="input8"
                                        ReadOnly="true"></asp:TextBox>
                                    <span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_002',this)">
                                        帮助</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldS_Ename" runat="server" ErrorMessage="<span class=reshow>(*)请填写专题英文名</spna>"
                                        ControlToValidate="S_Ename" Display="Static"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题父栏目：
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="S_ParentName" runat="server" MaxLength="12" ReadOnly="true"
                                        class="input8"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题父栏目：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_Parent" runat="server" MaxLength="12" class="input8"
                                        ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题域名：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_Domain" runat="server" MaxLength="100" class="input8"></asp:TextBox>
                                    <span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_004',this)">
                                        帮助</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题扩展名：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:DropDownList ID="S_FileExname" runat="server" class="select5"
                                        onchange="javascript:Hide(this.value);">
                                        <asp:ListItem Value=".html">.html</asp:ListItem>
                                        <asp:ListItem Value=".htm">.htm</asp:ListItem>
                                        <asp:ListItem Value=".shtml">.shtml</asp:ListItem>
                                        <asp:ListItem Value=".aspx">.aspx</asp:ListItem>
                                    </asp:DropDownList>
                                    <span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_008',this)">
                                        帮助</span>
                                </td>
                            </tr>
                            <tr id="Tr_Pop" style="display: none;">
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题浏览权限：
                                </td>
                                <td colspan="2" align="left">
                                   <div class="textdiv">
                                    会员组
                                    <select id="S_UserGroup" runat="server" class="form" multiple style="width: 210px;
                                        height: 100px;">
                                    </select><p>
                                        设&nbsp;&nbsp;&nbsp;置
                                        <asp:DropDownList ID="S_IsDel" runat="server" class="select3">
                                            <asp:ListItem Value="null">请选择</asp:ListItem>
                                            <asp:ListItem Value="0">都可以查看</asp:ListItem>
                                            <asp:ListItem Value="1">扣取金币</asp:ListItem>
                                            <asp:ListItem Value="2">扣取点数</asp:ListItem>
                                            <asp:ListItem Value="3">扣取金币和点数</asp:ListItem>
                                            <asp:ListItem Value="4">需要金币</asp:ListItem>
                                            <asp:ListItem Value="5">需要点数</asp:ListItem>
                                            <asp:ListItem Value="6">需要金币和点数</asp:ListItem>
                                        </asp:DropDownList>
                                        点数
                                        <asp:TextBox ID="S_Point" runat="server" MaxLength="8" Width="35px"></asp:TextBox>
                                        金币
                                        <asp:TextBox ID="S_Money" runat="server" MaxLength="8" Width="35px"></asp:TextBox>
                                        <span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_005',this)">
                                            帮助</span></p>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    生成目录规则：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_DirRule" runat="server" MaxLength="100" class="input8"></asp:TextBox>
                                    &nbsp;<img src="../imges/bgxiu_14.gif"  align="middle" style="cursor: pointer;" alt="选择规则" onclick="selectFile('S_DirRule','生成目录规则','rulesmallPramo',500,200);document.F_Speical.S_DirRule.focus();" /><span
                                            class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_006',this)">帮助</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidatorS_DirRule" runat="server" ControlToValidate="S_DirRule"
                                                Display="Static" ErrorMessage="<span class=reshow>(*)请选择目录规则</spna>"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    生成文件规则：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_FileRule" runat="server" MaxLength="100" class="input8"></asp:TextBox>
                                    &nbsp;<img src="../imges/bgxiu_14.gif"  align="middle" style="cursor: pointer;" alt="选择规则" onclick="selectFile('S_FileRule','生成文件规则','rulePram',500,200);document.F_Speical.S_FileRule.focus();" /><span
                                            class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_007',this)">帮助</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidatorS_FileRule" runat="server" ControlToValidate="S_FileRule"
                                                Display="Static" ErrorMessage="<span class=reshow>(*)请选择文件规则</spna>"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题保存路径：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_SavePath" runat="server" MaxLength="100" class="input8"></asp:TextBox>
                                    &nbsp;<img src="../imges/bgxiu_14.gif"  align="middle" style="cursor: pointer;" alt="选择路径" onclick="selectFile('S_SavePath','专题保存路径','path|html',500,500);document.F_Speical.S_SavePath.focus();" /><span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_009',this)">帮助</span><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidatorS_SavePath" runat="server" ControlToValidate="S_SavePath"
                                                Display="Static" ErrorMessage="<span class=reshow>(*)请选择专题保存路径</spna>"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题导航图片：
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="S_Pic" runat="server" MaxLength="200" class="input8"></asp:TextBox>
                                    &nbsp;<img
                                    src="../imges/bgxiu_14.gif" style="cursor: pointer;" alt="选择图片" onclick="selectFile('S_Pic','专题导航图片','pic',500,500);document.F_Speical.S_Pic.focus();" /><span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_010',this)">帮助</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题导航文字：
                                </td>
                                <td colspan="2" align="left">
                                  <div class="textdiv">
                                    <asp:TextBox ID="S_Text" runat="server" Height="100px" TextMode="MultiLine"
                                        Width="360px"></asp:TextBox><span class="helpstyle" style="color:#828282" title="点击显示帮助"
                                            onclick="Help('H_SpecialAdd_011',this)">帮助</span>
                                   </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题模板地址：
                                </td>
                                <td colspan="2" align="left">
                                    <span id="labelTemplet" runat="server">
                                <asp:TextBox ID="S_Templet" runat="server"  MaxLength="200" class="input8"></asp:TextBox>&nbsp;
                                <img src="../imges/bgxiu_14.gif"  align="middle" style="cursor: pointer;" alt="选择模板" onclick="selectFile('S_Templet','专题导航图片','templet',500,500);document.S_Templet.focus();" /></span>
                                <span id="dropTemplet" runat="server">
                                    <asp:TextBox ID="dTemplet" runat="server"  MaxLength="200" class="input8"></asp:TextBox>&nbsp;
                                    <img src="../imges/bgxiu_14.gif"  align="middle" style="cursor: pointer;" alt="选择模板" onclick="selectFile('dTemplet','专题导航图片','templet',500,500);document.S_Templet.focus();" />
                                </span>
                                <span class="helpstyle" style="color:#828282" title="点击显示帮助" onclick="Help('H_SpecialAdd_012',this)">
                                    帮助</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorS_Templet" runat="server"
                                        ControlToValidate="S_Templet" Display="Static" ErrorMessage="<span class=reshow>(*)请选择专题模板地址</spna>"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="navi_link" style="width: 13%">
                                    专题页面导航：
                                </td>
                                <td colspan="2" align="left">
                                  <div class="textdiv">
                                    <asp:TextBox ID="S_Page" runat="server" Height="100px" TextMode="MultiLine"
                                        Width="360px"></asp:TextBox><span class="helpstyle" style="color:#828282" title="点击显示帮助"
                                            onclick="Help('H_SpecialAdd_013',this)">帮助</span>
                                   </div>
                                </td>
                            </tr>
                        </table>
                        <div class="nxb_submit">
                            <asp:Button ID="Button1" runat="server" Text=" 确 定 " OnClick="Button1_Click" CssClass="xsubmit1"/>
                            <input type="submit" name="bc" value="重填" class="xsubmit1" />
                            <input type="hidden" value="0" id="SpaecilID" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dialog-message" title="提示"></div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    function Hide(value) {
        if (value == ".aspx") {
            document.getElementById("Tr_Pop").style.display = "";
            document.F_Speical.isTrue.value = "1";
        }
        else {
            document.getElementById("Tr_Pop").style.display = "none";
            document.F_Speical.isTrue.value = "0";
        }
    }
</script>
<% Show(); %>
</html>

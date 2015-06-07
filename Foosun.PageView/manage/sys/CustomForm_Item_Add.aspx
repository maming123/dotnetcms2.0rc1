<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CustomForm_Item_Add.aspx.cs" Inherits="Foosun.PageView.manage.Sys.CustomForm_Item_Add" %>

<%@ Register Src="../../controls/UserPop.ascx" TagName="UserPop" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    <!--
    function changetype(obj)
    {
        var val = obj.options[obj.selectedIndex].value;
        var f = 'none';
        if(val == 'RadioBox' || val == 'CheckBox' || val == 'DropList' || val == 'List')
            f = '';
        document.getElementById('tr_sel').style.display = f;
    }
    function LoadMe(i)
    {
        changetype(document.getElementById('DdlItemType')); 
    }
    //-->
    </script>
</head>
<body onload="LoadMe(Math.random())">
    <form id="Form1" runat="server">
        <div class="mian_body">
            <div class="mian_wei">
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>自定义表单项</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')" target="sys_main" class="topnavichar">首页</a>>>
                  <a href="CustomForm.aspx" class="topnavichar">自定义表单</a>>>
                  <asp:HyperLink ID="HlkManage" runat="server" class="topnavichar">表单项管理</asp:HyperLink>>>
                  <asp:Literal runat="server" ID="LtrCaption"></asp:Literal>
              </div>
           </div>
        </div>
        <div class="mian_cont">
           <div class="nwelie">
              <div class="lanlie_lie">
                 <div class="newxiu_base">
        <table id="tablist" class="nxb_table">
             <tr>
                <td width="20%" align="right">
                    当前表单：</td>
                <td>
                    &nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="LblFormName"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    表单项名称：</td>
                <td>
                    <asp:TextBox runat="server" ID="TxtName" Width="310px" CssClass="input8" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtName"
                        Display="Dynamic" ErrorMessage="请填写表单项名称" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    字段名：</td>
                <td>
                    <asp:TextBox runat="server" ID="TxtFieldName" Width="310px" CssClass="input8" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFieldName"
                        Display="Dynamic" ErrorMessage="请填写字段名" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtFieldName"
                        Display="Dynamic" ErrorMessage="字段名必须由英文字母或数字、下划线组成!" SetFocusOnError="True"
                        ValidationExpression="^[A-Za-z0-9_]+$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right">
                    排序序号：</td>
                <td>
                    <asp:DropDownList ID="DdlSN" runat="server" CssClass="select4">
                    </asp:DropDownList>序号越小，排在越前面</td>
            </tr>
             <tr>
                <td width="20%" align="right">
                    是否启用：</td>
                <td>
                    <asp:RadioButton runat="server" ID="RadOpenYes" CssClass="radio" GroupName="RadGrpState" Text="是" Checked="True" />
                    <asp:RadioButton runat="server" ID="RadOpenNo" CssClass="radio" GroupName="RadGrpState" Text="否" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    是否必填：</td>
                <td>
                    <asp:RadioButton ID="RadNotNullYes" runat="server" CssClass="radio" Text="是" GroupName="RadGrpNull" />
                    <asp:RadioButton ID="RadNotNullNo" runat="server" CssClass="radio" Text="否" GroupName="RadGrpNull"  /></td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    表单项类型：</td>
                <td>
                    <asp:DropDownList ID="DdlItemType" CssClass="select4" runat="server" onchange="changetype(this);">
                    </asp:DropDownList></td>
            </tr>
            <tr>
               <td align="right">
                    文本长度</td>
               <td>
                    <asp:TextBox runat="server" ID="TxtMaxSize" Width="66px" CssClass="input8" MaxLength="10">20</asp:TextBox>0表示不设置<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtMaxSize"
                       Display="Dynamic" ErrorMessage="文本长度必须是整数" MaximumValue="4000" MinimumValue="0"
                       SetFocusOnError="True" Type="Integer"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    默认值：</td>
                <td>
                    <asp:TextBox ID="TxtDefault" runat="server" MaxLength="50" CssClass="input8" Width="310px"></asp:TextBox></td>
            </tr>
            <tr id="tr_sel">
                <td width="20%" align="right">
                    选项：</td>
                <td>
                    <asp:TextBox ID="TxtSelectItem" runat="server" Height="143px" TextMode="MultiLine" CssClass="textarea4" Width="288px"></asp:TextBox>
                    每一行为一个列表选项</td>
            </tr>
            <tr>
                <td width="20%" align="right">
                    附加提示：</td>
                <td>
                    <asp:TextBox TextMode="multiLine" runat="server" ID="TxtPrompt" CssClass="textarea4" Height="140px" Width="292px"></asp:TextBox>
                    (在名称旁的提示信息，255个字符以内有效)</td>
            </tr>
        </table>
        <div class="nxb_submit" >
            <asp:Button runat="server" ID="BtnOK" Text=" 确定 " CssClass="xsubmit1 mar" OnClick="BtnOK_Click" />
                    <input type="reset" value=" 重写 " class="xsubmit1 mar" />
             </div>
        <asp:HiddenField runat="server" ID="HidItemID" />
        <asp:HiddenField runat="server" ID="HidFormID" />
        </div>
        </div>
        </div>
        </div>
        </div>
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="controls_UserPop" CodeBehind="UserPop.ascx.cs" %>
<div  class="neitab3">
<asp:DropDownList ID="DdlAuthorityType" runat="server" onchange="GetSelect(this)" Width="150">
	<asp:ListItem Value="0">未设置</asp:ListItem>
	<asp:ListItem Value="1">扣除金币</asp:ListItem>
	<asp:ListItem Value="2">扣除积分</asp:ListItem>
	<asp:ListItem Value="3">扣除金币和积分</asp:ListItem>
	<asp:ListItem Value="4">达到金币</asp:ListItem>
	<asp:ListItem Value="5">达到积分</asp:ListItem>
	<asp:ListItem Value="6">达到金币和积分</asp:ListItem>
</asp:DropDownList>
<div id="Div_AuthorityGold" style="display: inline">
金币：
	<asp:TextBox ID="TxtAuthorityGold" runat="server" class="input1">0</asp:TextBox>
    </div>
    <div id="Div_AuthorityPoint" style="display: inline">
 积分:
	<asp:TextBox ID="TxtAuthorityPoint" runat="server"  class="input1">0</asp:TextBox>
    </div>
    </div>
<div  class="neitab3" style=" margin-top:10px;"  id="Div_AuthorityGroup">请选择会员组:
	<asp:ListBox ID="LstAuthorityGroup" runat="server" SelectionMode="Multiple" Width="200"></asp:ListBox>
	<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TxtAuthorityGold" ErrorMessage="金币必须输入非负整数" MaximumValue="2147483647" MinimumValue="0" Type="Integer"></asp:RangeValidator>
	<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtAuthorityPoint" ErrorMessage="积分必须输入非负整数" MaximumValue="2147483647" MinimumValue="0" Type="Integer"></asp:RangeValidator></div>
<script type="text/javascript">
    GetSelect(document.getElementById("UserPop1_DdlAuthorityType"));
    function GetSelect(obj) {
        var selval = parseInt(obj.options[obj.selectedIndex].value);
        var divgroup = document.getElementById("Div_AuthorityGroup");
        var divpoint = document.getElementById("Div_AuthorityPoint");
        var divgold = document.getElementById("Div_AuthorityGold");

        switch (selval) {
            case 0:
                divgroup.style.display = "none";
                divpoint.style.display = "none";
                divgold.style.display = "none";
                break;
            case 1:
            case 4:
                divgroup.style.display = "";
                divgold.style.display = "inline";
                divpoint.style.display = "none";
                document.getElementById("UserPop1_TxtAuthorityPoint").value = "0";
                break;
            case 2:
            case 5:
                divgroup.style.display = "";
                divpoint.style.display = "inline";
                divgold.style.display = "none";
                document.getElementById("UserPop1_TxtAuthorityGold").value = "0";
                break;
            case 3:
            case 6:
                divgroup.style.display = "";
                divpoint.style.display = "inline";
                divgold.style.display = "inline";
                break;
        }
    }
</script>

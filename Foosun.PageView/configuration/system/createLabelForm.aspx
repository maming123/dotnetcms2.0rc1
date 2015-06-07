<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createLabelForm.aspx.cs" Inherits="Foosun.PageView.configuration.system.createLabelForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>专题信息类</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
</head>
<body>
     <form id="ListForm" runat="server">
    <div id="dialog-message" title="提示" style="border:solid 1px"></div>
      <div class="newxiu_base">
           <table class="nxb_table">
          <tr>
            <td align="right" style="width: 28%">请选择类型：</td>
            <td width="79%" align="left"><asp:DropDownList ID="FormType" runat="server" class="select5" onchange="javascript:selectLabelType(this.value);" >  
			<asp:ListItem Value="">请选择表单类型</asp:ListItem>
			<asp:ListItem Value="SubForm">提交表单</asp:ListItem>
			<asp:ListItem Value="FormList">表单列表</asp:ListItem>
              </asp:DropDownList></td>
          </tr>
          <tr style="display:none;" id="FName">
            <td align="right" style="width: 28%">选择表单：</td>
            <td width="79%" align="left"><asp:DropDownList ID="FormTableName" runat="server" class="select5">
              </asp:DropDownList><span id="spanLoginP"></span></td>
          </tr>
          <tr style="display:none;" id="FID">
            <td align="right" style="width: 28%">选择表单：</td>
            <td width="79%" align="left"><asp:DropDownList ID="FormID" runat="server" class="select5">
              </asp:DropDownList><span id="span1"></span></td>
          </tr>
          <tr style="display:none;" id="FormNumber_Tr">
            <td align="right" style="width: 28%">每页数量：</td>
            <td width="79%" align="left"><asp:TextBox ID="FormNumber" runat="server" class="input8" Text="10"></asp:TextBox><span id="spanNumber"></span></td>
          </tr>
       
          <tr id="trStyleID" style="display:none;">
            <td align="right" style="width: 28%">选择样式：</td>
            <td width="79%" align="left"><asp:TextBox ID="StyleID" runat="server" class="input9" ReadOnly="true"></asp:TextBox>
              &nbsp;
              <input class="xsubmit2" type="button" value="选择样式"  onclick="javascript:selectFile('StyleID','样式选择','style','687','414');document.ListForm.StyleID.focus();" /><span id="sapnStyleID"></span></td>
          </tr>          
          <tr>
            <td align="right" style="width: 28%"></td>
            <td width="79%" align="left">&nbsp;<input class="xsubmit2" type="button" value=" 确 定 "  onclick="javascript:ReturnDivValue();" />&nbsp;<input class="xsubmit2" type="button" value=" 关 闭 "  onclick="javascript:CloseDiv();" /></td>
          </tr> 
        </table>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function selectLabelType(type) {
        allhide();
        switch (type) {
            case "SubForm":
                document.getElementById("FName").style.display = "none";
                document.getElementById("FID").style.display = "";
                document.getElementById("trStyleID").style.display = "";
                document.getElementById("FormNumber_Tr").style.display = "none";
                break;
            case "FormList":
                document.getElementById("FName").style.display = "";
                document.getElementById("FID").style.display = "none";
                document.getElementById("trStyleID").style.display = "";
                document.getElementById("FormNumber_Tr").style.display = "";
                break;
            default:
                break;
        }
    }

    function allhide() {
        document.getElementById("FName").style.display = "none";
        document.getElementById("FID").style.display = "none";
        document.getElementById("FormNumber_Tr").style.display = "none";
        document.getElementById("trStyleID").style.display = "none";
    }
    function CloseDiv() {
        parent.parent.$('#dialog-message').dialog("close");
    }
    function checkIsNull(obj, spanobj, error) {
        if (obj.value == "") {
            spanobj.innerHTML = "<span class=reshow>(*)" + error + "</spna>";
            return true;
        }
        return false;
    }
    function ReturnDivValue() {
        var CheckStr = true;
        var rvalue = "";
        var temproot = "";
        switch (document.ListForm.FormType.value) {
            case "SubForm":
                if (document.ListForm.FormType.value == "")
                    CheckStr = false;
                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=" + document.ListForm.FormType.value;
                if (document.ListForm.FormID.value != "") { rvalue += ",FS:FormID=" + document.ListForm.FormID.value + ""; }
                if (document.ListForm.FormID.value == "")
                    CheckStr = false;
                if (document.ListForm.StyleID.value != "") {
                    temproot = "[#FS:StyleID=" + document.ListForm.StyleID.value + "]";
                }
                else {
                    CheckStr = false;
                }
                rvalue += "]";
                rvalue += temproot;
                rvalue += "[/FS:Loop]";
                if (CheckStr)
                    parent.parent.getValue(rvalue);
                else
                    checkIsNull(document.ListForm.FormID, document.getElementById("span1"), "表单不能为空！");
                break;
            case "FormList":
                if (checkIsNumber(document.ListForm.FormNumber, document.getElementById("spanNumber"), "循环数目只能为正整数"))
                    CheckStr = false;
                if (document.ListForm.FormType.value == "")
                    CheckStr = false;
                rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=" + document.ListForm.FormType.value;
                if (document.ListForm.FormNumber.value != "") { rvalue += ",FS:PageSize=" + document.ListForm.FormNumber.value + ""; }
                if (document.ListForm.FormTableName.value != "") { rvalue += ",FS:FormTableName=" + document.ListForm.FormTableName.value + ""; }
                if (document.ListForm.FormTableName.value == "")
                    CheckStr = false;
                if (document.ListForm.StyleID.value != "") {
                    temproot = "[#FS:StyleID=" + document.ListForm.StyleID.value + "]";
                }
                else {
                    temproot = "[#FS:StyleID=1]";
                }
                rvalue += "]";
                rvalue += temproot;
                rvalue += "[/FS:Loop]";
                if (CheckStr)
                    parent.parent.getValue(rvalue);
                else
                    checkIsNull(document.ListForm.FormTableName, document.getElementById("spanLoginP"), "表单不能为空！");
                break;
            default:
                parent.parent.getValue("");
                break;
        }
    }
    function checkIsNumber(obj, spanobj, error) {
        var re = /^[0-9]*$$/;
        if (re.test(obj.value) == false) {
            spanobj.innerHTML = "<span class=reshow>(*)" + error + "</spna>";
            return true;
        }
        spanobj.innerHTML = "";
        return false;
    }
</script>

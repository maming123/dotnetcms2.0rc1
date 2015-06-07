<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSAdd.aspx.cs" Inherits="Foosun.PageView.manage.jsmodel.JSAdd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=title%></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
     <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    var numkey = Math.random();
    numkey = Math.round(numkey * 10000);
    var isId = 'foosun<%Response.Write(Request.QueryString["ID"]); %>';
    function Display(flag) {
        var tab = document.getElementById('TableDis');
        for (var i = 4; i < 8; i++) {
            var tr = tab.rows[i];
            if (flag == 0)
                tr.style.display = 'none';
            else
                tr.style.display = '';
        }
        if (flag == 0) {
            document.getElementById('DdlTempSys').style.display = '';
            document.getElementById('DdlTempFree').style.display = 'none';
            if (isId == "foosun") {
                document.getElementById('TxtFileName').value = "sys_" + numkey + "";
            }
        }
        else {
            document.getElementById('DdlTempSys').style.display = 'none';
            document.getElementById('DdlTempFree').style.display = '';
            if (isId == "foosun") {
                document.getElementById('TxtFileName').value = "free_" + numkey + "";
            }
        }
    }
    function loadjsfile() {
        document.getElementById('TxtFileName').value = "sys_"
    }
    $(function () {
        var f = 1;
        if (document.getElementById('RadTypeSys').checked)
            f = 0;
        Display(f);
    });
    function Reviewtemplet() {
        var types;
        if (document.getElementById('RadTypeSys').checked) {
            types = "DdlTempSys";
        }
        else {
            types = "DdlTempFree";
        }
        $.ajax({
            type: "POST",
            url: "JSAdd.aspx",
            async: false,
            //是否ajax同步       
            data: "option=get&tid=" + $('#' + types).val(),
            success: function (data) {
                $("#dialog-message").html(data);
                $('select').hide();
                $("#dialog-message").dialog({
                    modal: true,
                    width: 800,
                    height: 300,
                    close: function () {
                        $('#'+types).show();
                    }
                });
            }
        });
    }
</script>
</head>

<body>
<form id="form1" runat="server">
 <div id="dialog-message" title="浏览模型"></div>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3><%=title%></h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="JSList.aspx">JS管理</a>>> <%=title%>
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能：</span><a href="JSList.aspx" class="topnavichar">JS管理</a>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table" id="TableDis">
               <tr>
                   <td colspan="2"><font></font>JS信息</td>
               </tr>
             <tr>
               <td width="20%" align="right">选择类型：</td>
               <td>
                <div class="textdiv2">
               <asp:RadioButton ID="RadTypeSys" runat="server" GroupName="jsType" onclick="Display(0);" Checked="True" />系统JS
                <asp:RadioButton ID="RadTypeFree" runat="server" GroupName="jsType" onclick="Display(1);" />自由JS
                 <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0003',this)">
                        帮助</span>
                </div>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">JS名称：</td>
                    <td>
                     <asp:TextBox ID="TxtName" runat="server" class="input8" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName"
                        Display="Dynamic" ErrorMessage="请填写JS名称!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                       <span class="helpstyle" style="cursor: help;" title="点击查看帮助"
                        onclick="Help('H_jsadd_0002',this)">帮助</span>
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">新闻调用数量：</td>
                    <td>
                    <asp:TextBox ID="TxtNum" runat="server" class="input8" Text="10" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请填写调用数量!" ControlToValidate="TxtNum" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="新闻调用数量必须为正整数!"
                        Type="Integer" ControlToValidate="TxtNum" Display="Dynamic" MaximumValue="2147483647" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                     <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0006',this)">
                        帮助</span>
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">新闻每行显示条数：</td>
                    <td>
                     <asp:TextBox ID="TxtColsNum" runat="server" class="input8" Text="1" />
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="新闻每行显示条数必须为正整数!"
                        Type="Integer" ControlToValidate="TxtColsNum" Display="Dynamic" MaximumValue="2147483647" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>                       
                      <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0007',this)">
                        帮助</span>
                    </td>
             </tr>             
             <tr>
               <td width="20%" align="right">新闻标题显示字数：</td>
                    <td>
                    <asp:TextBox ID="TxtLenTitle" runat="server" class="input8" Text="10" />
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="标题显示字数必须为正整数!"
                        Type="Integer" ControlToValidate="TxtLenTitle" Display="Dynamic" MaximumValue="2147483647" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>                       
                     <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0008',this)">
                        帮助</span>
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">新闻内容显示字数：</td>
               <td>
               <asp:TextBox ID="TxtLenContent" runat="server" class="input8" Text="200" />
                    <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="内容显示字数必须为正整数!"
                        Type="Integer" ControlToValidate="TxtLenContent" Display="Dynamic" MaximumValue="2147483647" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                      <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0009',this)">
                        帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">新闻导航显示字数：</td>
                    <td>
                      <asp:TextBox ID="TxtLenNavi" runat="server" class="input8" Text="5" />
                    <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="导航显示字数必须为正整数!"
                        Type="Integer" ControlToValidate="TxtLenNavi" Display="Dynamic" MaximumValue="2147483647" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>                      
                     <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0010',this)">
                        帮助</span>
                    </td>
             </tr>           
             <tr>
               <td width="20%" align="right">JS引用模型：</td>
               <td>
                <asp:DropDownList ID="DdlTempSys" runat="server" class="select3">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DdlTempFree" runat="server" class="select3">
                    </asp:DropDownList>
                    <a href="javascript:Reviewtemplet();">浏览模型</a>                 
                    <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0011',this)">
                        帮助</span>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">生成JS文件名：</td>
                    <td>
                    <asp:TextBox ID="TxtFileName" runat="server" class="input8" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtFileName"
                        Display="Dynamic" ErrorMessage="请填写JS文件名!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="生成文件名必须为字母、下划线及数字!" ControlToValidate="TxtFileName" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[a-zA-Z_0-9_.__]+$"></asp:RegularExpressionValidator>                       
                      <font color="red">(*)</font><span class="helpstyle" style="cursor: help;" title="点击查看帮助"
                        onclick="Help('H_jsadd_0004',this)">帮助</span>
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">生成的JS文件保存路径：</td>
                    <td>
                    <asp:TextBox ID="TxtSavePath" runat="server" class="input8" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtSavePath"
                        Display="Dynamic" ErrorMessage="请选择JS文件保存路径!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                       <a href="javascript:selectFile('TxtSavePath','路径选择','path|<%Response.Write(jspath); %>','500','400')">
                       <img src="../imges/bgxiu_14.gif"  align="middle" /></a>
                       <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0005',this)">
                        帮助</span>
                    </td>
             </tr>
             <tr>
                <td width="10%" align="right">描述：</td>
                <td>
                    <div class="textdiv">
                        <asp:TextBox ID="TxtContent" runat="server" TextMode="MultiLine" class="textarea"></asp:TextBox>
                         <span class="helpstyle" style="cursor: help;" title="点击查看帮助" onclick="Help('H_jsadd_0013',this)">帮助</span>
                    </div>
                </td>
             </tr>
           </table>
           <div class="nxb_submit" >
               <asp:Button runat="server" ID="BtnOK" Text=" 保存 "  class="insubt" OnClick="BtnOK_Click" />
               <input type="reset" name="bc" value="取消" class="insubt"/>
           </div>
         </div>
      </div>
   </div>
</div>
</div>
<asp:HiddenField runat="server" ID="HidID" />
<asp:HiddenField runat="server" ID="HidJsID" />
</form>
</body>
</html>


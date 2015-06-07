<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createLabelList.aspx.cs" Inherits="Foosun.PageView.configuration.system.createLabelList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
  <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
 <script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function getValue(value) {
        document.getElementById("UserDefined").value = value;
    }
    function setValue(value) {
        if (value == "") {
            return;
        }
        document.getElementById("UserDefined").value = '{#FS:define=' + value + '}'; 
    }

</script>
</head>
<body>
<form runat="server" id="form1">
<div id="dialog" title="提示"></div>
         <div class="newxiu_base">
           <table class="nxb_table">
               <tr>
                   <td colspan="2"><font></font>JS模型信息</td>
               </tr>
             <tr>
               <td width="20%" align="right">列表类型：</td>
                    <td>
                <asp:DropDownList ID="NewsType" runat="server" class="select4" onchange="javascript:selectNewsType(this.value);" >
                <asp:ListItem Value="Last">最新新闻</asp:ListItem>
                <asp:ListItem Value="Rec">推荐新闻</asp:ListItem>
                <asp:ListItem Value="Hot">热点新闻</asp:ListItem>
                <asp:ListItem Value="Tnews">头条新闻</asp:ListItem>
                <asp:ListItem Value="Jnews">精彩新闻</asp:ListItem>
                <asp:ListItem Value="ANN">公告新闻</asp:ListItem>
                <asp:ListItem Value="MarQuee">滚动新闻</asp:ListItem>
                <asp:ListItem Value="Special">专题新闻</asp:ListItem>
              </asp:DropDownList>                      
                    </td>
             </tr>
             <tr  id="TrClassId">
               <td width="20%" align="right">栏目ID：</td>
               <td>
                  <asp:TextBox ID="ClassId" runat="server"  class="input8"></asp:TextBox><asp:HiddenField ID="ClassNames" runat="server" />
                  <input type="button" onclick="javascript:selectFile('ClassNames,ClassId','栏目选择','newsclass','400','300')" name="" value="选择栏目" class="suan" /><a href="#" class="a4">不选则显示所有</a>
               </td>
             </tr>
             <tr>
               <td width="20%" align="right">引用样式：</td>
               <td>
                <asp:DropDownList ID="Root" runat="server" class="select3" onchange="javascript:selectRoot(this.value);">
                <asp:ListItem Value="true">固定样式</asp:ListItem>
                <asp:ListItem Value="false">自定义样式</asp:ListItem>
              </asp:DropDownList>
              <label id="TrStyleID">
              <asp:TextBox ID="StyleID" runat="server" class="input8" ReadOnly="true"></asp:TextBox>
               <a href="javascript:selectFile('StyleID','样式选择','style','400','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a>
              <span id="sapnStyleID"></span>
              </label>                 
               </td>
             </tr>
             <tr id="TrUserDefined" style="display:none;">
            <td width="20%" align="right">自定义样式</td>
            <td>
            <div>
              <label id="style_base" runat="server" />
              <label id="style_class" runat="server" />
              <label id="style_special" runat="server" />  
                <asp:DropDownList ID="define" runat="server" class="select3" onchange="javascript:setValue(this.value);">
                <asp:ListItem Value="">自定义字段</asp:ListItem>
                </asp:DropDownList>               
         </div>          
            <textarea rows="1" cols="1" name="UserDefined" id="UserDefined" runat="server" style="width:90%;height:200px;"></textarea>
    
     </td>
          </tr>
           <tr id="TrSpecialID" style="display:none;">
            <td width="20%" align="right">专题栏目</td>
            <td><asp:TextBox ID="SpecialID" runat="server" class="input8"></asp:TextBox>             
              <a href=""><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a><span id="spanSpecialID"></span></td>
          </tr>
             <tr>
               <td width="20%" align="right">循环条数：</td>
               <td>
               <asp:TextBox ID="Number" runat="server" class="input8" Text="10"></asp:TextBox><span id="spanNumber"></span>
               </td>
             </tr>  
             <tr>
               <td width="20%" align="right">点击大于多少：</td>
               <td>
               <asp:TextBox ID="ClickNumber" runat="server" class="input8"></asp:TextBox><span id="spanClickNumber"></span>                 
               </td>
             </tr>    
             <tr>
               <td width="20%" align="right">显示多少天内的信息：</td>
               <td>
               <asp:TextBox ID="ShowDateNumer" runat="server" class="input8"></asp:TextBox><span id="spanShowDateNumer"></span>
               </td>
             </tr> 
             <tr>
               <td width="20%" align="right">每行显示多少条：</td>
               <td>
                   <asp:TextBox ID="Cols" runat="server" class="input8"></asp:TextBox><span id="spanCols"></span>
               </td>
             </tr> 
             <tr id="TrMarqDirec" style="display:none;">
            <td width="20%" align="right">滚动方向</td>
            <td>
                <asp:DropDownList ID="MarqDirec" class="select3" runat="server">
                <asp:ListItem Value="1">请选择滚动方向</asp:ListItem>
                <asp:ListItem Value="1">上</asp:ListItem>
                <asp:ListItem Value="2">下</asp:ListItem>
                <asp:ListItem Value="3">左</asp:ListItem>
                <asp:ListItem Value="4">右</asp:ListItem>
              </asp:DropDownList></td>
          </tr>
          <tr id="TrMarqSpeed" style="display:none;">
            <td width="20%" align="right">滚动速度</td>
            <td>
                <asp:TextBox ID="MarqSpeed" runat="server" class="input8"></asp:TextBox><span id="sapnMarqSpeed"></span></td>
          </tr>
          <tr id="TrMarqwidth" style="display:none;">
            <td width="20%" align="right">宽度</td>
            <td>
                <asp:TextBox ID="Marqwidth" runat="server" class="input8"></asp:TextBox><span id="sapnMarqwidth"></span></td>
          </tr>
          <tr id="TrMarqheight" style="display:none;">
            <td width="20%" align="right">高度</td>
            <td>
                <asp:TextBox ID="Marqheight" runat="server" class="input8"></asp:TextBox><span id="sapnMarqheight"></span></td>
          </tr>
             <tr>
               <td width="20%" align="right">调用图片：</td>
                    <td>
                <asp:DropDownList ID="isPic" runat="server" class="select5">
                <asp:ListItem Value="0">请选择是否调用</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
              </asp:DropDownList>              
                      
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">按照什么排序：</td>
                    <td>
                    <asp:DropDownList ID="DescType" runat="server" class="select5">
                <asp:ListItem Value="1">请选择排序方式</asp:ListItem>
                <asp:ListItem Value="1">自动编号</asp:ListItem>
                <asp:ListItem Value="2">添加日期</asp:ListItem>
                <asp:ListItem Value="3">点击次数</asp:ListItem>
                <asp:ListItem Value="4">权重</asp:ListItem>
              </asp:DropDownList>                      
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">排序顺序：</td>
                    <td>
                    <asp:DropDownList ID="Desc" runat="server" class="select5">
                <asp:ListItem Value="0">请选择排序顺序</asp:ListItem>
                <asp:ListItem Value="0">desc(降序)</asp:ListItem>
                <asp:ListItem Value="1">asc(升序)</asp:ListItem>
              </asp:DropDownList>                      
                    </td>
             </tr>
             <tr>
               <td width="20%" align="right">在标题前加导航：</td>
                    <td>
                    <asp:DropDownList ID="ShowNavi" runat="server" class="select5" onchange="javascript:selectShowNavi(this.value);">
                <asp:ListItem Value="1">请选择是否加导航</asp:ListItem>
                <asp:ListItem Value="1">数字导航(1,2,3...)</asp:ListItem>
                <asp:ListItem Value="2">字母导航(A,B,C...)</asp:ListItem>
                <asp:ListItem Value="3">字母导航(a,b,c...)</asp:ListItem>
                <asp:ListItem Value="4">自定义图片</asp:ListItem>
              </asp:DropDownList>                       
                    </td>
             </tr>
              <tr id="TrNaviPic" style="display:none;">
            <td width="20%" align="right">导航图片地址</td>
            <td><asp:TextBox ID="NaviPic" runat="server" class="input8"></asp:TextBox>
              &nbsp;
              <a href="javascript:selectFile('NaviPic','图片选择','pic','400','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a></td>
          </tr>
             <tr>
                <td width="20%" align="right">标题显示字数 ：</td>
                <td>
                <asp:TextBox ID="TitleNumer" runat="server" class="input8" ></asp:TextBox><span id="spanTitleNumer"></span>                    
                </td>
             </tr>
             <tr>
                <td width="20%" align="right">内容截取字数：</td>
                <td>
                    <asp:TextBox ID="ContentNumber" runat="server" class="input8"></asp:TextBox><span id="spanContentNumber"></span>
                </td>
             </tr>
             <tr>
                <td width="20%" align="right">导航截取字数：</td>
                <td>
                <asp:TextBox ID="NaviNumber" runat="server" class="input8"></asp:TextBox><span id="spanNaviNumber"></span>
                </td>
             </tr>
             <tr>
               <td width="20%" align="right">是否调用子类：</td>
                    <td>
                    <asp:DropDownList ID="isSub" runat="server" class="select5">
                <asp:ListItem Value="0">请选择是否调用</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
              </asp:DropDownList>
                    </td>
             </tr>
           </table>
           <div class="nxb_submit" >
           <input class="insubt" type="button" value=" 确 定 "  runat="server" onclick="javascript:ReturnDivValue();" id="savv"/><input class="insubt" type="button" value=" 关 闭 "  onclick="javascript:CloseDiv();" />               
           </div>
         </div>
<div id="dialog-message" title="提示"></div>
         </form>
         <script language="javascript" type="text/javascript">
             function selectRoot(type) {
                 if (type == "true") {
                     document.getElementById("TrStyleID").style.display = "";
                     document.getElementById("TrUserDefined").style.display = "none";
                 }
                 else {
                     document.getElementById("TrStyleID").style.display = "none";
                     document.getElementById("TrUserDefined").style.display = "";
                 }
             }
             function selectNewsType(type) {
                 switch (type) {
                     case "Special":
                         document.getElementById("TrSpecialID").style.display = "";
                         document.getElementById("TrClassId").style.display = "none";
                         document.getElementById("TrMarqDirec").style.display = "none";
                         document.getElementById("TrMarqSpeed").style.display = "none";
                         document.getElementById("TrMarqwidth").style.display = "none";
                         document.getElementById("TrMarqheight").style.display = "none";
                         break;
                     case "ANN":
                         document.getElementById("TrMarqDirec").style.display = "";
                         document.getElementById("TrMarqSpeed").style.display = "";
                         document.getElementById("TrMarqwidth").style.display = "";
                         document.getElementById("TrMarqheight").style.display = "";
                         break;
                     default:
                         document.getElementById("TrClassId").style.display = "";
                         document.getElementById("TrSpecialID").style.display = "none";
                         document.getElementById("TrMarqDirec").style.display = "none";
                         document.getElementById("TrMarqSpeed").style.display = "none";
                         document.getElementById("TrMarqwidth").style.display = "none";
                         document.getElementById("TrMarqheight").style.display = "none";
                         break;
                 }
             }
             function selectShowNavi(type) {
                 if (type == "4") {
                     document.getElementById("TrNaviPic").style.display = "";
                 }
                 else {
                     document.getElementById("TrNaviPic").style.display = "none";
                 }
             }

             function ReturnDivValue() {
                 spanClear();
                 var CheckStr = true;
                 if ($('NewsType').val() == "Special") {
                     if (checkIsNull($('#SpecialID').val(), document.getElementById("spanSpecialID"), "请选择专题栏目"))
                         CheckStr = false;
                 }
                 if (checkIsNull($('#Number').val(), document.getElementById("spanNumber"), "循环数目不能为空"))
                     CheckStr = false;
                 if (checkIsNumber($('#Number').val(), document.getElementById("spanNumber"), "循环数目只能为正整数"))
                     CheckStr = false;
                 if (checkIsNumber($('#ClickNumber').val(), document.getElementById("spanClickNumber"), "点击次数只能为正整数"))
                     CheckStr = false;
                 if (checkIsNumber($('#ShowDateNumer').val(), document.getElementById("spanShowDateNumer"), "显示多少天天数只能为正整数"))
                     CheckStr = false;
                 if (checkIsNumber($('#Cols').val(), document.getElementById("spanCols"), "每行显示条数只能为正整数"))
                     CheckStr = false;

                 if (checkIsNumber($('#MarqSpeed').val(), document.getElementById("sapnMarqSpeed"), "滚动速度只能为正整数"))
                     CheckStr = false;
                 if (checkIsNumber($('#Marqwidth').val(), document.getElementById("sapnMarqwidth"), "滚动宽度只能为正整数"))
                     CheckStr = false;
                 if (checkIsNumber($('#Marqheight').val(), document.getElementById("sapnMarqheight"), "滚动高度只能为正整数"))
                     CheckStr = false;

                 if (checkIsNumber($('#TitleNumer').val(), document.getElementById("spanTitleNumer"), "标题显示字数只能为正整数"))
                     CheckStr = false;
                 if (checkIsNumber($('#ContentNumber').val(), document.getElementById("spanContentNumber"), "内容截取字数只能为正整数"))
                     CheckStr = false;
                 if (checkIsNumber($('#NaviNumber').val(), document.getElementById("spanNaviNumber"), "导航截取字数只能为正整数"))
                     CheckStr = false;

                 //--------------------返回标签值
                 var temproot = "";
                 var rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>";

                 rvalue += ",FS:NewsType=" + $('#NewsType').val();
                 if ($('#NewsType').val() == "Special") {
                     if ($('#SpecialID').val() != "") { rvalue += ",FS:SpecialID=" + $('#SpecialID').val(); }
                 }
                 else {
                     if ($('#ClassId').val() != "") { rvalue += ",FS:ClassID=" + $('#ClassId').val(); }
                     else { rvalue += ",FS:ClassID=-1"; }
                 }
                 if ($('#Number').val() != "") { rvalue += ",FS:Number=" + $('#Number').val(); }

                 if ($('#ClickNumber').val() != "") { rvalue += ",FS:ClickNumber=" + $('#ClickNumber').val(); }
                 else { rvalue += ",FS:ClickNumber=0"; }

                 if ($('#ShowDateNumer').val() != "") { rvalue += ",FS:ShowDateNumer=" + $('#ShowDateNumer').val(); }
                 else { rvalue += ",FS:ShowDateNumer=365"; }

                 if ($('#Cols').val() != "") { rvalue += ",FS:Cols=" + $('#Cols').val(); }
                 else { rvalue += ",FS:Cols=1"; }

                 if ($('#NewsType').val() == "MarQuee") {
                     if ($('#MarqDirec').val() != "") { rvalue += ",FS:MarqDirec=" + $('#MarqDirec').val(); }
                     else { rvalue += ",FS:MarqDirec=1"; }
                     if ($('#MarqSpeed').val() != "") { rvalue += ",FS:MarqSpeed=" + $('#MarqSpeed').val(); }
                     else { rvalue += ",FS:MarqSpeed=10"; }
                     if ($('#Marqwidth').val() != "") { rvalue += ",FS:Marqwidth=" + $('#Marqwidth').val(); }
                     else { rvalue += ",FS:Marqwidth=10"; }
                     if ($('#Marqheight').val() != "") { rvalue += ",FS:Marqheight=" + $('#Marqheight').val(); }
                     else { rvalue += ",FS:Marqheight=15"; }
                 }

                 if ($('#isPic').val() != "") { rvalue += ",FS:isPic=" + $('#isPic').val(); }
                 else { rvalue += ",FS:isPic=0"; }

                 if ($('#DescType').val() != "") { rvalue += ",FS:DescType=" + $('#DescType').val(); }
                 else { rvalue += ",FS:DescType=1"; }

                 if ($('#Desc').val() != "") { rvalue += ",FS:Desc=" +$('#Desc').val(); }
                 else { rvalue += ",FS:Desc=0"; }

                 if ($('#ShowNavi').val()!= "") { rvalue += ",FS:ShowNavi=" + $('#ShowNavi').val(); }
                 else { rvalue += ",FS:ShowNavi=0"; }
                 if ($('#NaviPic').val()!= "") { rvalue += ",FS:NaviPic=" + $('#NaviPic').val(); }
                 else { rvalue += ",FS:NaviPic=0"; }

                 if ($('#TitleNumer').val() != "") { rvalue += ",FS:TitleNumer=" + $('#TitleNumer').val(); }
                 else { rvalue += ",FS:TitleNumer=10"; }
                 if ($('#ContentNumber').val() != "") { rvalue += ",FS:ContentNumber=" + $('#ContentNumber').val(); }
                 else { rvalue += ",FS:ContentNumber=200"; }
                 if ($('#NaviNumber').val() != "") { rvalue += ",FS:NaviNumber=" + $('#NaviNumber').val(); }
                 else { rvalue += ",FS:NaviNumber=5"; }
                 if ($('#isSub').val() != "") { rvalue += ",FS:isSub=" + $('#isSub').val(); }
                 else { rvalue += ",FS:isSub=0"; }

                 rvalue += "]";
                 if ($('#Root').val()== "true") {
                     if ($('#StyleID').val() == "") {
                         alert("请选择样式");
                        return false;
                     }
                     temproot = "[#FS:StyleID=" + $('#StyleID').val() + "]";
                 }
                 else {
                     temproot = editor.html();
                 }
                 rvalue += temproot;
                 rvalue += "[/FS:Loop]";
                 if (CheckStr)

                     parent.parent.getValue(rvalue);
                 parent.parent.$('#dialog-message').dialog("close");               
             }

             function CloseDiv() {
                 parent.parent.$('#dialog-message').dialog("close");
             }

             function spanClear() {
                 document.getElementById("spanSpecialID").innerHTML = "";
                 document.getElementById("spanNumber").innerHTML = "";
                 document.getElementById("spanClickNumber").innerHTML = "";
                 document.getElementById("spanCols").innerHTML = "";
                 document.getElementById("spanShowDateNumer").innerHTML = "";
                 document.getElementById("spanTitleNumer").innerHTML = "";
                 document.getElementById("spanContentNumber").innerHTML = "";
                 document.getElementById("spanNaviNumber").innerHTML = "";
                 document.getElementById("sapnMarqSpeed").innerHTML = "";
                 document.getElementById("sapnMarqwidth").innerHTML = "";
                 document.getElementById("sapnMarqheight").innerHTML = "";
             }
             function checkIsNull(value, spanobj, error) {
                 if (value == "") {
                     spanobj.innerHTML = "<span class=reshow>(*)" + error + "</spna>";
                     return true;
                 }
                 return false;
             }
             function checkIsNumber(value, spanobj, error) {
                 var re = /^[0-9]*$$/;
                 if (re.test(value) == false) {
                     spanobj.innerHTML = "<span class=reshow>(*)" + error + "</spna>";
                     return true;
                 }
                 return false;
             }
            
</script>
</body>
</html>

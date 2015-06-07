<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createLabelLists.aspx.cs" Inherits="Foosun.PageView.configuration.system.createLabelLists" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea[name="UserDefined"]', {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            filterMode:false,
            items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
    });
    function getType(value) {
        $('#ClassId').val(value);
        if (value == "-1")
            $('#ClassName').val("调用所有");
        else
            $('#ClassName').val("自适应");
    }
    function selectNewsType(type) {
        switch (type) {
            case "Special":
                document.getElementById("TrSpecialID").style.display = "";
                document.getElementById("tr_more").style.display = "none";
                document.getElementById("TrClassId").style.display = "none";
                document.getElementById("TrSubNews_ClassStyle").style.display = "none";
                document.getElementById("TrSubNews_ColumnStyle").style.display = "none";
                document.getElementById("span_isSub").style.display = "";
                break;
            case "SubNews":
                document.getElementById("TrSpecialID").style.display = "none";
                document.getElementById("TrClassId").style.display = "none";
                document.getElementById("span_isSub").style.display = "none";
                document.getElementById("TrSubNews_ClassStyle").style.display = "";
                document.getElementById("TrSubNews_ColumnStyle").style.display = "";
                document.ListLabel.isSub.value = "";
                break;
            default:
                document.getElementById("TrClassId").style.display = "";
                document.getElementById("tr_more").style.display = "none";
                document.getElementById("TrSpecialID").style.display = "none";
                document.getElementById("TrSubNews_ClassStyle").style.display = "none";
                document.getElementById("TrSubNews_ColumnStyle").style.display = "none";
                document.getElementById("span_isSub").style.display = "";
                break;
        }
    }
    function getNaviNumber(obj) {
        if (obj == "false") {
            document.getElementById("TRNaviNumber").style.display = "none";
        }
        else {
            document.getElementById("TRNaviNumber").style.display = "";
        }
    }
    function selectisDiv(type) {
        if (type == "true") {
            document.getElementById("TrulID").style.display = "";
            document.getElementById("TrulClass").style.display = "";
        }
        else {
            document.getElementById("TrulID").style.display = "none";
            document.getElementById("TrulClass").style.display = "none";
        }
    }
    function selectShowSubNavi(type) {
        if (type == "true") {
            document.getElementById("TrSubNaviCSS").style.display = "";
        }
        else {
            document.getElementById("TrSubNaviCSS").style.display = "none";
        }
    }

    function selectShowColumnNumber(type) {
        if (type == "1") {
            document.getElementById("TrColumnNumber").style.display = "";
        }
        else {
            document.getElementById("TrColumnNumber").style.display = "none";
        }
    }

    function selectShowColumn(type) {
        if (type == "1") {
            document.getElementById("TrColumnCss").style.display = "";
        }
        else {
            document.getElementById("TrColumnCss").style.display = "none";
        }
    }
    function selectShowNavi(type) {
        if (type == "4") {
            document.getElementById("TrNaviPic").style.display = "";
            document.getElementById("TrNaviCSS").style.display = "none";
        }
        else {
            if (type == "") {
                document.getElementById("TrNaviCSS").style.display = "none";
                document.getElementById("TrNaviPic").style.display = "none";
            }
            else {
                document.getElementById("TrNaviCSS").style.display = "";
                document.getElementById("TrNaviPic").style.display = "none";
            }
        }
    }
    function selectRoot(type) {
        if (type == "true") {
            document.getElementById("TrStyleID").style.display = "";
            document.getElementById("TrUserDefined").style.display = "none";
            document.getElementById("TrUserDefineds").style.display = "none";
        }
        else {
            document.getElementById("TrStyleID").style.display = "none";
            document.getElementById("TrUserDefined").style.display = "";
            document.getElementById("TrUserDefineds").style.display = "";
        }
    }

    function ReturnDivValue() {
        spanClear();
        var CheckStr = true;
        if (document.ListLabel.NewsType.value == "Special") {
            if (checkIsNull(document.ListLabel.SpecialID, document.getElementById("spanSpecialID"), "请选择专题栏目"))
                CheckStr = false;
        }
        if (checkIsNull(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目不能为空"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.ClickNumber, document.getElementById("spanClickNumber"), "点击次数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.ShowDateNumer, document.getElementById("spanShowDateNumer"), "显示多少天天数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.Cols, document.getElementById("spanCols"), "每行显示条数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.MarqSpeed, document.getElementById("sapnMarqSpeed"), "滚动速度只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.Marqwidth, document.getElementById("sapnMarqwidth"), "滚动宽度只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.ColumnNumber, document.getElementById("SpanColumnNumber"), "条数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.TitleNumer, document.getElementById("spanTitleNumer"), "标题显示字数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.Number, document.getElementById("spanNumber"), "循环数目只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.ContentNumber, document.getElementById("spanContentNumber"), "内容截取字数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.NaviNumber, document.getElementById("spanNaviNumber"), "导读截取字数只能为正整数"))
            CheckStr = false;
        if (document.ListLabel.Root.value == "true") {
            if (checkIsNull(document.ListLabel.StyleID, document.getElementById("sapnStyleID"), "请选择样式"))
                CheckStr = false;
        }
        if (document.ListLabel.NewsType.value == "SubNews" && checkIsNull(document.ListLabel.ClassStyleID, document.getElementById("spanClassStyleID"), "请选择栏目样式"))
            CheckStr = false;
        //--------------------返回标签值
        var temproot = "";
        var rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(SiteID); %>,FS:LabelType=List";

        if (document.ListLabel.Number.value != "") { rvalue += ",FS:Number=" + document.ListLabel.Number.value; }
        if (document.ListLabel.Root.value == "true")
        { temproot = "[#FS:StyleID=" + document.ListLabel.StyleID.value + "]"; }
        else {
            temproot = editor.html();
        }
        rvalue += ",FS:NewsType=" + document.ListLabel.NewsType.value;
        if (document.ListLabel.NewsType.value == "Special")
        { rvalue += ",FS:SpecialID=" + document.ListLabel.SpecialID.value; }
        else
        { if (document.ListLabel.ClassId.value != "") { rvalue += ",FS:ClassID=" + document.ListLabel.ClassId.value } }
        if (document.ListLabel.SubNews.value != "") {
            rvalue += ",FS:SubNews=" + document.ListLabel.SubNews.value;
            if (document.ListLabel.SubNaviCSS.value != "") {
                rvalue += ",FS:SubNaviCSS=" + document.ListLabel.SubNaviCSS.value;
            }
        }
        if (document.ListLabel.Cols.value != "") { rvalue += ",FS:Cols=" + document.ListLabel.Cols.value; }
        if (document.ListLabel.Desc.value != "") { rvalue += ",FS:Desc=" + document.ListLabel.Desc.value; }
        if (document.ListLabel.DescType.value != "") { rvalue += ",FS:DescType=" + document.ListLabel.DescType.value; }
        if (document.ListLabel.isDiv.value != "") { rvalue += ",FS:isDiv=" + document.ListLabel.isDiv.value; }
        if (document.ListLabel.tabCss.value != "") { rvalue += ",FS:TabCSS=" + document.ListLabel.tabCss.value; }
        if (document.ListLabel.isDiv.value == "true") {
            if (document.ListLabel.ulID.value != "") { rvalue += ",FS:ulID=" + document.ListLabel.ulID.value; }
            if (document.ListLabel.ulClass.value != "") { rvalue += ",FS:ulClass=" + document.ListLabel.ulClass.value; }
        }
        if (document.ListLabel.isPic.value != "") { rvalue += ",FS:isPic=" + document.ListLabel.isPic.value; }
        if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
        if (document.ListLabel.HashNaviContent.value != "") { rvalue += ",FS:HashNaviContent=" + document.ListLabel.HashNaviContent.value; }
        if (document.ListLabel.ContentNumber.value != "") { rvalue += ",FS:ContentNumber=" + document.ListLabel.ContentNumber.value; }
        if (document.ListLabel.NaviNumber.value != "") { rvalue += ",FS:NaviNumber=" + document.ListLabel.NaviNumber.value; }
        if (document.ListLabel.ClickNumber.value != "") { rvalue += ",FS:ClickNumber=" + document.ListLabel.ClickNumber.value; }
        if (document.ListLabel.ShowDateNumer.value != "") { rvalue += ",FS:ShowDateNumer=" + document.ListLabel.ShowDateNumer.value; }
        if (document.ListLabel.ShowColumnNumber.value == "1") {
            if (document.ListLabel.ColumnNumber.value != "") {
                rvalue += ",FS:ColumnNumber=" + document.ListLabel.ColumnNumber.value;
            }
        }
        if (document.ListLabel.ShowColumn.value == "1") {
            if (document.ListLabel.ColumnCss.value != "") {
                rvalue += ",FS:ColumnCss=" + document.ListLabel.ColumnCss.value;
            }
            if (document.ListLabel.ColumnNewsCss.value != "") {
                rvalue += ",FS:ColumnNewsCss=" + document.ListLabel.ColumnNewsCss.value;
            }
        }
        if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
        if (document.ListLabel.ShowNavi.value != "") { rvalue += ",FS:ShowNavi=" + document.ListLabel.ShowNavi.value; }
        if (document.ListLabel.ShowNavi.value != "" && document.ListLabel.ShowNavi.value != "4") { rvalue += ",FS:NaviCSS=" + document.ListLabel.NaviCSS.value; }
        if (document.ListLabel.ShowNavi.value == "4")
        { if (document.ListLabel.NaviPic.value != "") { rvalue += ",FS:NaviPic=" + document.ListLabel.NaviPic.value; } }
        if (document.ListLabel.css1.value != "" && document.ListLabel.css2.value != "") { rvalue += ",FS:ColbgCSS=" + document.ListLabel.css1.value + "|" + document.ListLabel.css2.value; }
        if (document.ListLabel.More.value != "") {
            rvalue += ",FS:More=" + document.ListLabel.More.value;
        }
        if (document.ListLabel.NewsType.value == "SubNews") {
            rvalue += ",FS:ClassStyleID=" + document.getElementById("ClassStyleID").value;
        }
        rvalue += "]";
        rvalue += temproot;
        rvalue += "[/FS:Loop]";
        if (CheckStr) {
            parent.parent.getValue(rvalue);
        }
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
        document.getElementById("sapnStyleID").innerHTML = "";
        document.getElementById("sapnMarqSpeed").innerHTML = "";
        document.getElementById("sapnMarqwidth").innerHTML = "";
        document.getElementById("sapnMarqheight").innerHTML = "";
    }
    function checkIsNull(obj, spanobj, error) {
        if (obj.value == "") {
            spanobj.innerHTML = "<span class=reshow>(*)" + error + "</spna>";
            return true;
        }
        return false;
    }
    function checkIsNumber(obj, spanobj, error) {
        var re = /^[0-9]*$$/;
        if (re.test(obj.value) == false) {
            spanobj.innerHTML = "<span class=reshow>(*)" + error + "</spna>";
            return true;
        }
        return false;
    }
    function getValue(value) {
        editor.insertHtml(value);
    }
    function setValue(value) {
        if (value == "") {
            return;
        }
        editor.insertHtml('{#FS:define=' + value + '}');
    }
    function changetrMore(obj) {
        if (obj.value != "") {
            if (obj.value == "调用所有" || obj.value == "自适应") {
                document.getElementById("tr_more").style.display = "none";
                return;
            }
            document.getElementById("tr_more").style.display = "";
        }
        else {
            document.getElementById("tr_more").style.display = "none";
        }
    }
    function insertHTMLEdit(url) {
        var urls = url.replace('{@dirfile}', '<% Response.Write(Foosun.Config.UIConfig.dirFile); %>')
        editor.insertHtml("<img src=\"' + urls + '\" border=\"0\" />");
        return;
    }
    function ShowStyle() {
        if (document.getElementById("showOther").style.display == "none") {
            document.getElementById("showOther").style.display = "";
        }
    }
    function savePostStyle() {
        var saveStyle = document.getElementById("saveStyle");
        var sname = document.getElementById("StyleName");
        var StyleClassID = document.getElementById("StyleClassID");
        if (sname.value == "") {
            alert('请填写样式名称');
            sname.focus();
            return false;
        }
        if (StyleClassID.value == "") {
            alert('请选择分类，如果没有分类，请在样式中创建');
            return false;
        }
        var gtemproot = editor.html();
        var actionstr = "StyleName=" + escape(sname.value) + "&ClassID=" + escape(StyleClassID.value) + "&Content=" + escape(gtemproot) + "";
        $.ajax({
            type: "POST",
            url: "SaveStyle.aspx",
            async: false,
            //是否ajax同步       
            data: actionstr,
            success: function (data) {
                $('#sResultHTML').html(data);
            }
        });
    }

    function tabCssShow() {
        for (var i = 0; i < document.getElementById("isDiv").options.length; i++) {
            if (document.getElementById("isDiv").options[0].selected == true) {
                document.getElementById("tabCssSpan").style.display = "";
            } else {
                document.getElementById("tabCssSpan").style.display = "none";
            }
        }
    }
</script>
</head>
<body>
<form id="ListLabel" runat="server">
<div id="dialog-message" title="提示"></div>
         <div class="newxiu_base">
           <table class="nxb_table" width="99%">
             <tr>
               <td width="15%" align="right">列表类型：</td>
               <td>
                  <select id="NewsType" class="select5" onchange="javascript:selectNewsType(this.value);">
                    <option value="list">栏目列表(任意指定条件)</option>
                    <option value="Last">最新新闻</option>
					<option value="Rec">推荐新闻</option>
					<option value="Hot">热点新闻</option>
					<option value="Tnews">头条新闻</option>
					<option value="Jnews">精彩新闻</option>
					<option value="ANN">公告新闻</option>
					<option value="MarQuee">滚动新闻</option>
					<option value="Special">专题新闻</option>
					<option value="SubNews">子类新闻</option>
                  </select>
                  循环条数<input type="text" id="Number"  value="10" class="input1"/><span id="spanNumber"></span>
               </td>
             </tr>
             <tr id="TrClassId">
               <td width="15%" align="right">栏目：</td>
               <td>
                  <div class="neitab4">
                     <input type="text" id="ClassName" onblur="javascript:changetrMore(this);"  value="" class="input6" /><input type="hidden" id="ClassId" /><span style="color:#00F" id="getClassCname"></span>
                     <a href="javascript:selectFile('ClassName,ClassId','栏目选择','multinewsclass','400','300');"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a>
                     调用类型：<a href="javascript:getType(-1)" class="a2">所有</a><a href="javascript:getType(0)" class="a2">自适应</a><br />
                     <span style="color:#00F; line-height:18px;">类型"自适应"为标签所在栏目符合条件的新闻,若选择为空或栏目不存在，则调用所有符合条件的新闻。</span>
                   </div>
               </td>
             </tr>
              <tr id="TrSpecialID" style="display: none;">
               <td width="15%" align="right">专题栏目：</td>
               <td>
                  <div class="neitab1">
                     <input type="text" id="SpecialName" name="" value="" class="input8" /><input type="hidden" id="SpecialID" />
                     <a href="javascript:selectFile('SpecialName,SpecialID','选择专题','special','400','300');"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a><span id="spanSpecialID"></span>
                   </div>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">引用样式：</td>
               <td>
                  <select id="Root" onchange="javascript:selectRoot(this.value);" class="select3">
                  <option value="true">固定样式</option>
                  <option value="false">自定义样式</option>
                  </select>
                  <label id="TrStyleID">
                  <input type="text" name="" id="StyleID" value="" class="input8" />
                  <a href="javascript:selectFile('StyleID','样式选择','style','400','300')"><img src="/CSS/imges/bgxiu_14.gif"  alt="" /></a>
                  <span id="sapnStyleID"></span></label>
               </td>
             </tr>
             	<tr id="TrSubNews_ClassStyle" style="display:none;">
			<td width="15%" align="right">
				子栏目样式：
			</td>
			<td>
            <input type="text" name="" id="ClassStyleID" value="" class="input8" /><a href="javascript:selectFile('ClassStyleID','样式选择','style','400','300')"><img src="/CSS/imges/bgxiu_14.gif" alt="" /></a>
				<span id="spanClassStyleID"></span>
                <select id="ShowColumnNumber" class="select3" onchange="javascript:selectShowColumnNumber(this.value);">
                    <option value="">是否控制子栏目条数</option>
	                <option value="1">控制子栏目条数</option>
                </select>
                <label id="TrColumnNumber" style="display: none;">
                    子栏目条数<input type="text" id="ColumnNumber" class="input1"  /><span id="SpanColumnNumber"></span>
                </label>
			</td>
		</tr>
        <tr id="TrSubNews_ColumnStyle" style="display: none;">
    <td width="15%" align="right">
        子循环Css属性：
    </td>
    <td>
        <select id="ShowColumn" runat="server" class="select3"  onchange="javascript:selectShowColumn(this.value);">
			<option value="">是否自定义</option>
			<option value="1">自定义Css属性</option>
		</select>
        <label id="TrColumnCss" style="display: none;">
        子循环属性:
        <input type="text" id="ColumnCss" title="子类循环CSS样式<class>属性名"  class="input7" />
        栏目新闻属性：
        <input type="text" id="ColumnNewsCss" title="新闻CSS样式<class>属性名"  class="input7" />
        </label>
    </td>
</tr>
              <tr id="TrUserDefined" style="display: none;">
               <td width="15%" align="right"></td>
               <td>
               <label id="style_base" runat="server" />
					<label id="style_class" runat="server" />
					<label id="style_special" runat="server" />
					<asp:DropDownList ID="define" class="select7" runat="server"  onchange="javascript:setValue(this.value);">
						<asp:ListItem Value="">自定义字段</asp:ListItem>
					</asp:DropDownList>               
               </td>
             </tr>
             <tr id="TrUserDefineds" style="display: none;">
               <td width="15%" align="right">
                  自定义样式：<br />
                  <input type="button" onclick="ShowStyle();"  name="hfg" value="保存样式" class="xsubmit2"/>
                  <div id="showOther" style="display: none;">
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<asp:TextBox ID="StyleName" Width="94px" runat="server"></asp:TextBox>
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<asp:DropDownList ID="StyleClassID" Width="100px" runat="server">
					</asp:DropDownList>
					<div style="height: 3px; border-bottom: 1px dotted #999999; margin: 2px 0 4px 0;">
					</div>
					<input name="saveStyle" id="saveStyle" value="保存" type="button" onclick="savePostStyle();" />
					<div id="sResultHTML" class="reshow">
					</div>
				</div>
               </td>
               <td>
                  <div class="neitab2">
                   <textarea rows="1" cols="1" name="UserDefined" id="UserDefined" runat="server" style="width:90%;height:200px;visibility:hidden;"></textarea>
                  </div>
               </td>
             </tr>  
             <tr>
               <td width="15%" align="right">每行显示多少条：</td>
               <td>
                   <input type="text" id="Cols" name="" value="" class="input1" title="只对table格式有效，如果为div格式请控制<li的属性>" /><span id="spanCols"></span>点击大于
                   <input type="text" id="ClickNumber" name="" value="" class="input1" /><span id="spanClickNumber"></span>显示多少天内信息
                   <input type="text" id="ShowDateNumer" name="" value="" class="input1" /><span id="spanShowDateNumer"></span>
               </td>
             </tr>    
             <tr>
               <td width="15%" align="right">标题显示字数：</td>
               <td>
                   <input type="text" id="TitleNumer" name="" value="" class="input1" /><span id="spanTitleNumer"></span> 内容截取字数
                   <input type="text" id="ContentNumber" name="" value="" class="input1" /><span id="spanContentNumber"></span>是否有导读
                   <select class="select3" id="HashNaviContent" onchange="getNaviNumber(this.value);">
                   <option value=""> 是否有导读 </option>
                   <option value="true"> 有导读 </option>
                   <option value="false"> 无导读 </option>
                   </select>
                   <label id="TRNaviNumber">
                   导读截取字数<input type="text" name="" id="NaviNumber" value="" class="input1" /></label><span id="spanNaviNumber"></span>
               </td>
             </tr> 
             <tr>
               <td width="15%" align="right">调用子(副)新闻：</td>
               <td>
                   <select class="select3" id="SubNews"  onchange="javascript:selectShowSubNavi(this.value);">
                     <option value="">是否调用</option>
                     <option value="true">是</option>
                     <option value="false">否</option>
                   </select>
                   <label id="span_isSub">调用子类<select id="isSub" class="select3"><option value="">是否调用</option>
                     <option value="true">是</option>
                     <option value="false">否</option></select></label>
                   输出格式<select id="isDiv" class="select4" onchange="tabCssShow()">
                    <option value="false"> Table </option>
                    <option value="true"> Div(默认,请在样式里定义li或者dd) </option>
                  </select>
                  <span id="tabCssSpan" style=" width:130px;">Css样式 <input type="text" class="input1" id="tabCss" /></span>
               </td>
             </tr> 
             <tr  id="TrulID" style="display: none;">
			<td width="15%" align="right">
				DIV的ul属性ID
			</td>
			<td>
				<asp:TextBox ID="ulID" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr id="TrulClass" style="display: none;">
			<td width="15%" align="right">
				DIV的ul属性Class
			</td>
			<td>
				<asp:TextBox ID="ulClass" runat="server"></asp:TextBox>
			</td>
		</tr>
        <tr id="TrMarqDirec" style="display: none;">
			<td width="15%" align="right">
				滚动方向
			</td>
			<td>
				<asp:DropDownList ID="MarqDirec" runat="server">
					<asp:ListItem Value="">滚动方向</asp:ListItem>
					<asp:ListItem Value="up">上</asp:ListItem>
					<asp:ListItem Value="down">下</asp:ListItem>
					<asp:ListItem Value="left">左</asp:ListItem>
					<asp:ListItem Value="right">右</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr id="TrMarqSpeed" style="display: none;">
			<td width="15%" align="right">
				滚动速度
			</td>
			<td>
				<asp:TextBox ID="MarqSpeed" runat="server" Width="190px"></asp:TextBox><span id="sapnMarqSpeed"></span>
			</td>
		</tr>
		<tr id="TrMarqwidth" style="display: none;">
			<td width="15%" align="right">
				宽度
			</td>
			<td>
				<asp:TextBox ID="Marqwidth" runat="server" Width="190px"></asp:TextBox><span id="sapnMarqwidth"></span>
			</td>
		</tr>
		<tr id="TrMarqheight" style="display: none;">
			<td width="15%" align="right">
				高度
			</td>
			<td>
				<asp:TextBox ID="Marqheight" runat="server" Width="190px"></asp:TextBox><span id="sapnMarqheight"></span>
			</td>
		</tr>
        	<tr id="TrSubNaviCSS" style="display: none;">
			<td width="15%" align="right">
				副新闻导航文字或图片
			</td>
			<td>
				<input type="text" id="SubNaviCSS" class="input8"  />
				<a href="javascript:selectFile('SubNaviCSS','选择图片','pic','400','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a>
			</td>
		</tr>
             <tr>
               <td width="15%" align="right">调用图片：</td>
               <td>
                   <select id="isPic" class="select3">
                   <option value="">是否调用</option>
                   <option value="true">是</option>
                   <option value="false">否</option>
                   </select>排列方式
                   <select id="DescType" class="select3">
                   <option value="">排序方式</option>
                   <option value="id">自动编号</option>
                   <option value="date">添加日期</option>
                   <option value="click">点击次数</option>
                   <option value="pop">权重</option>
                   <option value="digg">digg(顶客)</option>
                   </select>排序顺序
                   <select id="Desc" class="select3">
                   <option value=""> 排序顺序</option>
                   <option value="desc"> desc(降序)</option>
                   <option value="asc"> asc（升序）</option>
                   </select>                    
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">在标题前加导航：</td>
               <td>
                  <select id="ShowNavi" class="select4" onchange="javascript:selectShowNavi(this.value);">
                  <option value="">是否加导航</option>
                  <option value="1">数字导航(1,2,3...)</option>
                  <option value="2">字母导航(A,B,C...)</option>
                  <option value="3">字母导航(a,b,c...)</option>
                  <option value="4">自定义图片</option>
                  </select>
                  <label id="TrNaviCSS" style="display: none;">导航CSS：<asp:TextBox ID="NaviCSS" title="如果为空，可以在前台CSS里控制<dd>的属性" Width="80" runat="server"></asp:TextBox></label>
				<label id="TrNaviPic" style="display: none;">导航图片地址：<asp:TextBox ID="NaviPic" runat="server" Width="120px" ReadOnly="true"></asp:TextBox><a href="javascript:selectFile('NaviPic','选择图片','pic','400','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a></label>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">行参数控制 ：</td>
               <td>
                  <div class="textdiv5">奇数行背景CSS： <input id="css1" type="text" name="" value="" class="input1" />
                  偶数行背景CSS：<input id="css2" type="text" name="" value="" class="input1" /></div>
               </td>
             </tr>
             <tr id="tr_more" style="display: none;">
			<td width="15%" align="right">
				更多设置：
			</td>
			<td>
            <input type="text" id="More" name="" value="" class="input1" />
				<a href="javascript:selectFile('More','样式选择','pic','400','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a>
				<span style="color:#00F">填写字符或选择更多图片</span>
			</td>
		</tr>
           </table>
           <div class="nxb_submit" >
               <input type="button" name="bc" onclick="javascript:ReturnDivValue();" value="保存" class="insubt"/>
               <input type="button" name="bc" value="取消" onclick="CloseDiv()" class="insubt"/>
           </div>
         </div>
         </form>
</body>
</html>

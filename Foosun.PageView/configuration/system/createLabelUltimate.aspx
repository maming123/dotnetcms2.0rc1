<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createLabelUltimate.aspx.cs" Inherits="Foosun.PageView.configuration.system.createLabelUltimate" %>

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
<script language="javascript" type="text/javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea[name="UserDefined"]', {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
    });
    function selectShowNavi(type) {
        if (type == "4") {
            document.getElementById("TrNaviPic").style.display = "";
            document.getElementById("TrNaviCSS").style.display = "none";
        }
        else {
            if (type == "") {
                document.getElementById("TrNaviPic").style.display = "none";
                document.getElementById("TrNaviCSS").style.display = "none";
            }
            else {
                document.getElementById("TrNaviPic").style.display = "none";
                document.getElementById("TrNaviCSS").style.display = "";
            }
        }
    }
    function selectRoot(type) {
        if (type == "false")
        { document.getElementById("TrStyleID").style.display = "none"; document.getElementById("TrUserDefined").style.display = ""; }
        else
        { document.getElementById("TrStyleID").style.display = ""; document.getElementById("TrUserDefined").style.display = "none"; }
    }
    function selectPage(type) {
        if (type == "false")
        { document.getElementById("TrPageID").style.display = "none"; }
        else
        { document.getElementById("TrPageID").style.display = ""; }
    }
    function selectTF(type) {
        if (type == "false")
        { document.getElementById("divbrtf").style.display = "none"; }
        else
        { document.getElementById("divbrtf").style.display = ""; }
    }

    function CloseDiv() {
        parent.parent.$('#dialog-message').dialog("close");
    }

    function spanClear() {
        document.getElementById("spanCols").innerHTML = "";
        document.getElementById("spanTitleNumer").innerHTML = "";
        document.getElementById("spanContentNumber").innerHTML = "";
        document.getElementById("spanNaviNumber").innerHTML = "";
        document.getElementById("sapnStyleID").innerHTML = "";
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

    function ReturnDivValue() {
        spanClear();
        var CheckStr = true;

        if (checkIsNumber(document.ListLabel.Cols, document.getElementById("spanCols"), "每行显示条数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.TitleNumer, document.getElementById("spanTitleNumer"), "标题显示字数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.ContentNumber, document.getElementById("spanContentNumber"), "内容截取字数只能为正整数"))
            CheckStr = false;
        if (checkIsNumber(document.ListLabel.NaviNumber, document.getElementById("spanNaviNumber"), "导航截取字数只能为正整数"))
            CheckStr = false;
        if (document.ListLabel.Root.value == "true") {
            if (checkIsNull(document.ListLabel.StyleID, document.getElementById("sapnStyleID"), "请选择样式"))
                CheckStr = false;
        }

        var rvalue = "[FS:Loop,FS:SiteID=<%Response.Write(APIID); %>,FS:LabelType=ClassList";
        if (document.ListLabel.Root.value == "true")
        { temproot = "[#FS:StyleID=" + document.ListLabel.StyleID.value + "]"; }
        else {
            temproot = editor.html();
        }
        rvalue += ",FS:ListType=" + document.ListLabel.ListType.value;

        if (document.ListLabel.isSub.value != "") { rvalue += ",FS:isSub=" + document.ListLabel.isSub.value; }
        if (document.ListLabel.SubNews.value != "") { rvalue += ",FS:SubNews=" + document.ListLabel.SubNews.value; }
        if (document.ListLabel.Cols.value != "") { rvalue += ",FS:Cols=" + document.ListLabel.Cols.value; }
        if (document.ListLabel.Desc.value != "") { rvalue += ",FS:Desc=" + document.ListLabel.Desc.value; }
        if (document.ListLabel.DescType.value != "") { rvalue += ",FS:DescType=" + document.ListLabel.DescType.value; }
        if (document.ListLabel.isDiv.value != "") { rvalue += ",FS:isDiv=" + document.ListLabel.isDiv.value; }
        if (document.ListLabel.tabCss.value != "") { rvalue += ",FS:TabCSS=" + document.ListLabel.tabCss.value; }
        if (document.ListLabel.brTF.value == "true") {
            rvalue += ",FS:bfStr=" + document.ListLabel.bfstr.value;
        }
        if (document.ListLabel.isPic.value != "") { rvalue += ",FS:isPic=" + document.ListLabel.isPic.value; }
        if (document.ListLabel.TitleNumer.value != "") { rvalue += ",FS:TitleNumer=" + document.ListLabel.TitleNumer.value; }
        if (document.ListLabel.ContentNumber.value != "") { rvalue += ",FS:ContentNumber=" + document.ListLabel.ContentNumber.value; }
        if (document.ListLabel.NaviNumber.value != "") { rvalue += ",FS:NaviNumber=" + document.ListLabel.NaviNumber.value; }
        if (document.ListLabel.ShowNavi.value != "") { rvalue += ",FS:ShowNavi=" + document.ListLabel.ShowNavi.value; }
        if (document.ListLabel.ShowNavi.value == "4")
        { if (document.ListLabel.NaviPic.value != "") { rvalue += ",FS:NaviPic=" + document.ListLabel.NaviPic.value; } }
        if (document.ListLabel.ShowNavi.value != "" && document.ListLabel.ShowNavi.value != "4") { rvalue += ",FS:NaviCSS=" + document.ListLabel.NaviCSS.value; }
        if (document.ListLabel.css1.value != "" && document.ListLabel.css2.value != "") { rvalue += ",FS:ColbgCSS=" + document.ListLabel.css1.value + "|" + document.ListLabel.css2.value; }
        //分页链接样式
        if (document.ListLabel.Current_txt_style.value != "" && document.ListLabel.Other_txt_style.value != "") { rvalue += ",FS:PageLinksCSS=" + document.ListLabel.Current_txt_style.value + "|" + document.ListLabel.Other_txt_style.value; }
        //if(document.ListLabel.isPage.value=="true")
        //{ 
        if (document.ListLabel.PageID.value != "") { rvalue += "," + document.ListLabel.PageID.value; }
        //}
        rvalue += "]";
        rvalue += temproot;
        rvalue += "[/FS:Loop]";

        if (CheckStr)
            parent.parent.getValue(rvalue);
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
<div id="dialog-message" title="提示"></div>
 <form id="ListLabel" runat="server">
         <div class="newxiu_base">
           <table class="nxb_table" width="99%">
             <tr>
               <td width="15%" align="right">列表类型：</td>
               <td>
                  <select class="select5" id="ListType">
                  <option value="News">新闻</option>
                  <option value="Special">专题</option>
                  </select>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">引用样式：</td>
               <td>
                  <select class="select3" id="Root" onchange="javascript:selectRoot(this.value);">
                  <option value="true">固定样式</option>
                  <option value="false">自定义样式</option>
                  </select>
                  <label id="TrStyleID">
                  引用样式<input type="text" id="StyleID" name="" value="" class="input8" />
                  <a href="javascript:selectFile('StyleID','样式选择','style','400','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a><span id="sapnStyleID"></span></label>
               </td>
             </tr>
            <tr id="TrUserDefined" style="display: none;">
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
               <label id="style_base" runat="server" />
					<label id="style_class" runat="server" />
					<label id="style_special" runat="server" />
					<asp:DropDownList ID="define" class="select7" runat="server"  onchange="javascript:setValue(this.value);">
						<asp:ListItem Value="">自定义字段</asp:ListItem>
					</asp:DropDownList>   
                     <div class="neitab2">
                   <textarea rows="1" cols="1" name="UserDefined" id="UserDefined" runat="server" style="width:90%;height:200px;visibility:hidden;"></textarea>
                  </div>            
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">调用子类：</td>
               <td>
                   <select id="isSub" class="select3">
                   <option value="">是否调用</option>
                   <option value="true">是</option>
                   <option value="false">否</option>
                   </select> 调用子新闻
                   <select class="select3" id="SubNews">
                   <option value="">是否调用</option>
                   <option value="true">是</option>
                   <option value="false">否</option>
                   </select>排列方式 
                   <select class="select3" id="DescType">
                   <option value=""> 排序顺序</option>
                   <option value="id"> 自动编号</option>
                   <option value="date"> 添加日期</option>
                   <option value="click"> 点击次数</option>
                   <option value="pop"> 权重</option>
                   <option value="digg"> digg(顶客)</option>
                   </select>                    
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">排序顺序：</td>
               <td>
                   <select class="select3" id="Desc">
                   <option value="">排序顺序</option>
                   <option value="desc">desc(降序)</option>
                   <option value="asc">asc(升序)</option>
                   </select>调用图片
                   <select class="select3" id="isPic">
                   <option value="">是否调用</option>
                   <option value="true">是</option>
                   <option value="false">否</option>
                   </select> 输出格式
                   <select id="isDiv" class="select4" onchange="tabCssShow()">
                    <option value="false"> Table </option>
                    <option value="true"> Div(默认,请在样式里定义li或者dd) </option>
                  </select>
                  <span id="tabCssSpan" style=" width:130px;">Css样式 <input type="text" class="input1" id="tabCss" /></span>
                 </td>
             </tr>
             <tr>
               <td width="15%" align="right">标题字数：</td>
               <td>
               <input type="text" id="TitleNumer" name="" value="" class="input1" /><span id="spanTitleNumer"></span>
                   内容字数<input type="text" id="ContentNumber" name="" value="" class="input1" /><span id="spanContentNumber"></span>导航字数
                   <input type="text" id="NaviNumber" name="" value="" class="input1" /><span id="spanNaviNumber"></span>每行显示数
                   <input type="text" id="Cols" name="" value="" class="input1" /><span id="spanCols"></span>
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
				<label id="TrNaviPic" style="display: none;">导航图片地址：<asp:TextBox ID="NaviPic" runat="server" Width="120px" ReadOnly="true"></asp:TextBox><a href="javascript:selectFile('NaviPic','选择图片','pic','500','300')"><img src="/CSS/imges/bgxiu_14.gif" align="middle" alt="" /></a></label>
               </td>
             </tr> 
             <tr>
               <td width="15%" align="right"><span id="spanPageID"></span>分页样式：</td>
               <td>
                  <input type="text" id="PageID" name="" value="" class="input8" />
                  <input type="button" name="" onclick="javascript:selectFile('PageID','选择样式','PageID','400','300')" value="选择分页样式" class="xsubmit3"/>
               </td>
             </tr> 
             <tr>
               <td width="15%" align="right">行参数控制 ：</td>
               <td>
                  <div class="textdiv5">奇数行背景CSS：  <input id="css1" type="text" name="" value="" class="input1" />
                  偶数行背景CSS：<input id="css2" type="text" name="" value="" class="input1" /></div>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">分页链接样式：</td>
               <td>
                  <div class="textdiv5">当前页链接CSS： <input type="text" id="Current_txt_style" name="" value="" class="input1" />
                  其它页链接CSS：<input type="text" id="Other_txt_style" name="" value="" class="input1" /></div>
               </td>
             </tr>
             <tr>
               <td width="15%" align="right">分行参数控制：</td>
               <td><select id="brTF" class="select5" onchange="javascript:selectTF(this.value);">
               <option value="">显示分行效果</option>
               <option value="true">是</option>
               <option value="false">否</option>
               </select></td>
             </tr>
             <tr id="divbrtf" style="display:none;">
            <td width="15%" align="right">定义分行参数</td>
            <td>
                <div class="textdiv">
                <input type="text" id="bfstr" name="" value="0|5|CSS" class="input6" />
                每行排列一个起作用<br />
                <span class="reshow">
                格式：0|5|css,第一个参数表示使用样式,第2个表示多少信息使用此设置,第3个参数表示具体参数<br />
                0表示使用CSS样式，如：0|5|tableCSS <br />
                1表示使用使用图片，如：1|5|/templet/br.gif <br />
                2表示使用使用文字，如：2|5|----------------
                </span>
                </div>
             </td>
          </tr>          
           </table>
           <div class="nxb_submit" >
               <input type="button" name="bc"  onclick="javascript:ReturnDivValue();" value="保存" class="insubt"/>
               <input type="button" name="bc" value="关闭" onclick="CloseDiv()" class="insubt"/>
           </div>
         </div>
         </form>
</body>
</html>

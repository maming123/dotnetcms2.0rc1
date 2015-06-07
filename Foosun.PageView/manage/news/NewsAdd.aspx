<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeBehind="NewsAdd.aspx.cs" Inherits="Foosun.PageView.manage.news.NewsAdd" %>
<%@ Register Src="../../controls/UserPop.ascx" TagName="UserPop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>新闻添加/修改</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
<link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet"
        type="text/css" />
    <link href="/controls/kindeditor/plugins/code/prettify.css" rel="stylesheet"
        type="text/css" />
    <script src="/controls/kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
<script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    UnNewArray = eval("<%= UnNewsJsArray %>");
    TopLineArray = eval("new Array()");
    var j = <%=fileid %>;
    Array.prototype.remove = function (start, deleteCount) {
        if (isNaN(start) || start > this.length || deleteCount > (this.length - start)) { return false; }
        this.splice(start, deleteCount);
    }
    function DisplayUnNews() {
        var StrUnNewsList = "";
        var ListLen = 0;
        var Str_tem = "";
        var TLPic = "";
        var PicInfo = "";
        try {
            ListLen = UnNewArray.length;
        }
        catch (e) {
            ListLen = 0;
        }
        var StrUnNewsListSub = "";
        for (var i = 0; i < ListLen; i++) {
            StrUnNewsList += "<div class=\"ContentDiv\" id=\"Arr" + i + "\"><input name=\"NewsIDs\" type=\"hidden\" id=\"NewsIDs_" + i + "\" value=\"" + UnNewArray[i][0] + "\" /><a href=\"原新闻标题\" title=\"原新闻标题:" + UnNewArray[i][1] + "\" class=\"xa3\" onclick=\"return false;\">标题</a>：<input title=\"原新闻标题:" + UnNewArray[i][1] + "\" name=\"getNewsTitle" + UnNewArray[i][0] + "\" type=\"text\" id=\"getNewsTitle_" + i + "\" value=\"" + UnNewArray[i][2] + "\" size=\"60\" onkeyup=\"UnNewModify()\"  style=\"height:18px;\" class=\"input4\" />&nbsp;CSS&nbsp;<input class=\"Contentform\" name=\"titleCSS" + UnNewArray[i][0] + "\" type=\"text\" id=\"titleCSS_" + i + "\" value=\"" + UnNewArray[i][5] + "\" size=\"10\" maxlength=\"20\" />&nbsp;放在第<input class=\"Contentform\" name=\"Row" + UnNewArray[i][0] + "\" type=\"text\" id=\"Row_" + i + "\" value=\"" + UnNewArray[i][3] + "\" size=\"2\" maxlength=\"2\" onkeyup=\"UnNewModify(this,'')\" onbeforepaste=\"clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''));\" />行&nbsp;<a class=\"xsubmits\" href=\"javascript:UnNewDel(" + i + ");\">移除</a><input type=\"hidden\"  name=\"NewsTable" + UnNewArray[i][0] + "\" id=\"Table" + i + "\" value=\"" + UnNewArray[i][4] + "\" /></div>";
        }      
        
        if (TopLineArray.length > 0) {
            if (TopLineArray[6] == 1) {
                Str_tem = " checked=\"checked\"";
                TLPic = "";
            }
            else {
                Str_tem = "";
                TLPic = " style=\"display:none\"";
            }
            PicInfo = "";
            StrUnNewsList = "" + StrUnNewsList;
        }
        $("#UnNewsList").html(StrUnNewsList);
    }
    function UnNewModify() {
        for (var i = 0; i < UnNewArray.length; i++) {
            UnNewArray[i][2] = $("#getNewsTitle_" + i).val();
            $("#Row_" + i).val($("#Row_" + i).val().replace(/[^\d]/g, ''));
            UnNewArray[i][3] = parseInt($("#Row_" + i).val());
        }
        if (TopLineArray.length > 0) {
            TopLineArray[2] = $("#getNewsTitle_Top").val();
            TopLineArray[3] = 0;
            TopLineArray[5] = $("#TTNewsCSS").val();
            TopLineArray[6] = $("#IsMakePic").val() ;
        }
    }
   
    function UnNewPreview() {
        var ListLen = UnNewArray.length;
        var Maxrow = 1;
        var PreviewStr = "";
        var PreviewRowStr = "";
        var For_string = "";
        for (var i = 0; i < ListLen; i++) {
            if (UnNewArray[i][3] > Maxrow) {
                Maxrow = UnNewArray[i][3];
            }
        }
        PreviewStr = "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
        for (i = 1; i <= Maxrow; i++) {
            FindFlag = "";
            PreviewRowStr = "";
            for (var j = 0; j < ListLen; j++) {
                if (UnNewArray[j][3] == i) {
                    if (FindFlag == "") {
                        FindFlag = j.toString(10);
                    } else {
                        FindFlag += "," + j;
                    }
                }
            }

            PreviewStr += "<tr><td>";
            if (FindFlag) {
                PreviewRowStr = FindFlag.split(",");
                for (var j = 0; j < PreviewRowStr.length; j++) {
                    For_string = "<a class=\"xa3\" href=\"" + UnNewArray[PreviewRowStr[j]][2] + "\" onclick=\"return false;\">" + UnNewArray[PreviewRowStr[j]][2] + "</a>";
                    if (j == 0) {
                        PreviewStr += For_string;
                    } else {
                        PreviewStr += "&nbsp;" + For_string;
                    }
                }
            } else {
                PreviewStr += "&nbsp;";
            }
            PreviewStr += "</td></tr>";
        }
        if (TopLineArray.length > 0) {
            PreviewStr = "<tr>\
				        <td><a class=\"" + TopLineArray[5] + "\" href=\"" + TopLineArray[2] + "\" onclick=\"return false;\">" + TopLineArray[2] + "</a></td>\
			        </tr>" + PreviewStr;
        }
        PreviewStr += "</table>";       
        $("#PreviewContent").html(PreviewStr);       
    }

    function UnNewcheck(event) {
        if ($('#SubTF').attr("checked") != "checked") {
            return true;        
        }
        var ListLen = UnNewArray.length;
        var Maxrow = 0;
        var ErrStr = "";
        for (var i = 0; i < ListLen; i++) {
            if (UnNewArray[i][3] == 0) {
                ErrStr = " 第 " + (i + 1) + "条 存放行数不能为 0";
            }
            if (isNaN(UnNewArray[i][3])) {
                ErrStr = " 第 " + (i + 1) + "条 存放行数不能为空";
            }
            if (UnNewArray[i][2] == "") {
                ErrStr = " 第 " + (i + 1) + "条 不规则标题不能为空";
            }
            if (UnNewArray[i][3] > Maxrow) {
                Maxrow = UnNewArray[i][3];
            }
        }
        var FindFlag = false;
        for (i = 1; i <= Maxrow; i++) {
            FindFlag = false;
            for (var j = 0; j < ListLen; j++) {
                if (UnNewArray[j][3] == i) {
                    FindFlag = true;
                    break;
                }
            }
            if (!FindFlag) {
                ErrStr += "\n 第 " + i + " 行中没有新闻";
            }
        }
        if (Maxrow == 0 && TopLineArray.length == 0) {
            ErrStr += "\n 还没有加入新闻";
        }
        if (ErrStr) {
            alert("发生以下错误：\n" + ErrStr);
            if (event && event.preventDefault) {
                event.preventDefault();
            }
            return false;
        } else {
            return true;
        }
    }
    function checkNews() {
        if(UnNewcheck()==false)
        {
          return false;
        }
        if ($("#ClassID").val() == "") {
            alert("填写栏目.");
            $("#baseinfo").show();
            $("#ClassName").focus();
            if (event && event.preventDefault) {
                event.preventDefault();
            }
            return false;
        }
        if ($("#NewsTitle").val() == "") {
            alert("请填写标题.");
            $("#baseinfo").show();
            $("#NewsTitle").focus();
            if (event && event.preventDefault) {
                event.preventDefault();
            }
            return false;
        }
        if ($("#sPicFromContent").attr("checked")=="checked") {
            if (editor.html().toLowerCase().indexOf("<img") == -1 && editor.html().toLowerCase().indexOf("src=")) {
                alert("您设置了把内容中第一条图片设置为图片地址\n但内容中并没有图片");
                $("#baseinfo").show();
                if (event && event.preventDefault) {
                    event.preventDefault();
                }
                return false;
            }
        }

        if ($("#at2RandButton").attr("checked") == "checked") {
            if ($("#URLaddress").val() == "") {
                alert("请填写外部连接地址.");
                $("#baseinfo").show();
                $("#URLaddress").focus();
                if (event && event.preventDefault) {
                    event.preventDefault();
                }
                return false;
            }
        }
        if ($("#RemoteTF").checked) {
            alert('您选择了新闻内容中的图片下载到本地.\n在保存新闻需要较长时间。请耐心等待，不要刷新本页面。')
            return true;
        }
        //获取文件列表
        var filesArray = new Array();
        var filesPnl = $('#filelist');
        for (var i = 0; i < $('#filelist').children().length; i++) {
            var filesItem = filesPnl.children()[i];
            filesArray.push(filesItem.children.namedItem("fm").value + "|" + filesItem.children.namedItem("adss").value + "|" + filesItem.children.namedItem("lie").value);
        }
        $('#NewsFiles').val(filesArray.join(','));       
        return true;
    }     
    function titleFlag(obj) {
        var t = $("#NewsTitle");
        if (t.val() != "" || obj == "类型") {
            if (obj == "【荐】" || obj == "【HOT】") {
                t.val(t.val() + obj);
                return;
            }
            t.val( obj + t.val());
        }
        else {
            alert("您还没有填写标题呢。");
        }
    }

    function UnNewDel(Row) {
        if (confirm("确定移除吗？")) {
            if (Row == -1) {
                TopLineArray.remove(0, 7);
            }
            else {
                UnNewArray.remove(Row, 1);
            }
            DisplayUnNews();
            window.frames["DisNews"].CheckUnNews();
        }
    }
    function g(o) { return document.getElementById(o); }
    function hover_zzjs_net(n, m, k) {
        //m表示开始id，k表示结束id
        for (var i = m; i <= k; i++) {
            g('tab_zzjs_' + i).className = 'nor_zzjs';
            g('tab_zzjs_0' + i).className = 'undis_zzjs_net';
        }
        g('tab_zzjs_0' + n).className = 'dis_zzjs_net';
        g('tab_zzjs_' + n).className = 'hovertab_zzjs';
    }
     var editor;
    KindEditor.ready(function (K) {
      editor  = K.create('#content', {
            cssPath: '../../controls/kindeditor/plugins/code/prettify.css',
            uploadJson: '../../controls/kindeditor/asp.net/upload.aspx',
            fileManagerJson: '../../controls/kindeditor/asp.net/file_manager_json.ashx',
            allowFileManager: true,
            afterCreate: function () {
                var self = this;
                K.ctrl(document, 13, function () {
                    self.sync();
                    K('form[name=example]')[0].submit();
                });
                K.ctrl(self.edit.doc, 13, function () {
                    self.sync();
                    K('form[name=example]')[0].submit();
                });
            }
        });
        K('#image1').click(function () {
            editor.loadPlugin('image', function () {
                editor.plugin.imageDialog({
                    imageUrl: K('#PicURL').val(),
                    clickFn: function (url, title, width, height, border, align) {
                        K('#PicURL').val(url);
                        editor.hideDialog();
                    }
                });
            });
        });      
        K('input[name=insertHtml]').click(function (e) {
            var str = K('#PageTitle').val();
            if (str != "") {
                editor.insertHtml('[FS:PAGE=' + str + '$]');
            }
            else {
                editor.insertHtml('[FS:PAGE]');                
            }
             K('#PageTitle').val("");
        });     
        
        prettyPrint();
    });
     //cid 为checkbox id，id为要显示|隐藏对象的id,多个id用，号隔开
     function isshow(cid, id) {
         // $('#'+id).toggle()     checkbox快速点击出现问题
         var list = id.split(',');
         if (list.length>0) {
             if ($('#' + cid).attr("checked") == "checked") {
                 for (var i = 0; i < list.length; i++) {
                     $('#' + list[i]).show();
                 }
             }
             else {
                 for (var i = 0; i < list.length; i++) {
                     $('#' + list[i]).hide();
                 }
             }
         }
     }
     function Addfiles() {
         j++;
         $('#filelist').append("<div class=\"neitab\">名称：<input type=\"text\" name=\"fm\" value=\"\" class=\"input7\"/>地址：<input type=\"text\" id=\"input" + j + "\" name=\"adss\" value=\"\" class=\"input6\"/><a href=\"javascript:selectFile('input"+j+"','附件选择','file','500','350')\"><img src=\"../imges/bgxiu_14.gif\" alt=\"\" class=\"img1\"  /></a>排序<input type=\"text\" name=\"lie\" value=\"0\" class=\"input5\" /><a href=\"javascript:\" name=\"Delfile\" class=\"a5\">删除</a></div>");
         Delfiles();
     }     
     function Delfiles() {
         $("a[name=Delfile]").unbind().click(function () {
             $(this).parent().remove();
         });
     }   
     
     $(function () {  
     Delfiles();
      DisplayUnNews(); 
        show();
         
     });
     function show()
     {
         isshow('SPicURLTF','Div_hw');
         isshow('naviContentTF','div_naviContent');
         isshow('sPicFromContent','getContentNum');
         isshow('isFiles','Addfile,isFiles_div1');
         isshow('NewsProperty_TTTF1','div_TTSE');
         isshow('PicTTTF','div_TT');
         isshow('ContentPicTF','div_ContentPicURL,div_tHight');
         isshow('ShowAdance','div_metakey,div_metadesc,div_Click,div_SavePath,div_FileName,tr_editorTime,div_FileEXName,div_CheckStat,div_UserPop1,div_ContentPicTF');       
         AddSubTF('SubTF');        
        if ($('#atRadioButton').attr("checked")=="checked") {
                ShowLink("word");

        }
        if ($('#at1RandButton').attr("checked")=="checked") {
                ShowLink("pic");

        }
        if ($('#at2RandButton').attr("checked")=="checked") {
                ShowLink("url");
        }
     }
     function ShowLink(NewsType) {    
         switch (NewsType) {
             case "word":
                 $('#div_showad').show();
                 $('#div_URLaddress').hide();
                 $('#div_PicURL').hide();
                 $('#div_Content').show();
                 $('#div_Templet').show();
                 $('#div_Souce').show();
                 $('#NewsProperty_CommTF').show();
                 $('#NewsProperty_DiscussTF').show();
                 $('#NewsProperty_FILTTF').hide();
                 $('#isFiles_div').show();                 
                 break;
             case "pic":
                 $('#div_showad').show();
                 $('#div_URLaddress').hide();
                 $('#div_PicURL').show();
                 $('#div_Content').show();
                 $('#div_Templet').show();
                 $('#div_Souce').show();
                 $('#NewsProperty_CommTF').show();
                 $('#NewsProperty_DiscussTF').show();
                 $('#NewsProperty_FILTTF').show();
                 $('#isFiles_div').show();                
                 break;
             default:
                 $('#div_showad').hide();
                 $('#div_URLaddress').show();
                 $('#div_PicURL').show();
                 $('#div_Content').hide();
                 $('#div_Templet').hide();
                 $('#div_Souce').show();
                 $('#NewsProperty_CommTF').hide();
                 $('#NewsProperty_DiscussTF').hide();
                 $('#NewsProperty_FILTTF').show();
                 $('#div_naviContent').hide();
                 $('#div_ContentPicURL').hide();
                 $('#div_tHight').hide();
                 $('#div_UserPop1').hide();               
                 $('#div_ContentPicTF').hide();
                 $('#div_Click').hide();
                 $('#div_metakey').hide();
                 $('#div_metadesc').hide();
                 $('#div_SavePath').hide();
                 $('#div_FileName').hide();
                 $('#div_FileEXName').hide();
                 $('#isFiles_div').hide();
                 $('#isFiles_div1').hide();                
         }
     }
     function AddSubTF(id) {
         if ($('#' + id).attr("checked") == "checked") {
             $('#div_SubList').show();
             $('#div_UnnewsIframe').html("<iframe id=\"Iframe1\" name=\"DisNews\" src=\"unnews_iframe.aspx\" width=\"100%\" frameborder=\"0\" height=\"400\">");            
         }
         else {
             $('#div_SubList').hide();
             $('#div_UnnewsIframe').html("");            
         }
     }
     function addSource(obj) { $("#Souce").val(obj); }

     function addAuthor(obj) { $("#Author").val(obj); }

     function addTags(obj) {
         var s = $("#Tags").val();
         if (s != "") {
             if (s.indexOf(obj) == -1) {
                 $("#Tags").val( s + "|" + obj);
             }
         }
         else {
             $("#Tags").val(obj);
         }
     }

     function AddMetaTags(obj) {
         var s = $("#Metakeywords").val();
         if (s != "") {
             if (s.indexOf(obj) == -1) {
                 $("#Metakeywords").val(s + "|" + obj);
             }
         }
         else {
             $("#Metakeywords").val(obj);
         }
     }    

     function getReview() {
            if ($("#topFontInfo").val() == "" && $("#NewsTitle").val() == "") {
                alert('请填写生成头条的文字')
                return;
            }
            var fontColor = $("#fontColor").val();
            var fontsize = $("#PagefontSize").val();
            var widhts = $("#PagePicwidth").val();
            var Imagesbgcolor = $("#Imagesbgcolor").val();
            var PageFontFamily = $("#PageFontFamily").val();
            var PageFontStyle = $("#PageFontStyle").val();
            var topFontInfo = "";
            if ($("#topFontInfo").val() != "") {
                topFontInfo = $("#topFontInfo").val();
            }
            else {
                topFontInfo = $("#NewsTitle").val();
            }

            PageFontFamily = encodeURI(PageFontFamily);
            topFontInfo = encodeURI(topFontInfo);
            if ($("#PicTTTF").attr("checked") == "checked") {
                var WWidth = (window.screen.width - 500) / 2;
                var Wheight = (window.screen.height - 150) / 2;
                window.open('news_addReviewTT.aspx?PageFontStyle=' + PageFontStyle + '&fontcolor=' + fontColor + '&fontsize=' + fontsize + '&widhts=' + widhts + '&Imagesbgcolor=' + Imagesbgcolor + '&topFontInfo=' + topFontInfo + '&PageFontFamily=' + PageFontFamily + '', 'reviewTT', 'toolbar=0,location=0,maximize=1,directories=0,status=1,menubar=0,scrollbars=1,resizable=1,top=50,left=50,width=700,height=120 top=' + Wheight + ', left=' + WWidth + ', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no', '');
            }
        }
        function ivurl() {
            var gvalur = $("#vURL").val();
            if (gvalur != "") {
                if (gvalur.indexOf(".") > -1) {
                    gvalur = gvalur.toLowerCase().replace('{@dirfile}', '<% Response.Write(Foosun.Config.UIConfig.dirFile); %>')
                    var fileExstarpostion = gvalur.lastIndexOf(".");
                    var fileExName = gvalur.substring(fileExstarpostion, (gvalur.length))
                    var content = "";
                    switch (fileExName.toLowerCase()) {
                        case ".jpg": case ".gif": case ".bmp": case ".ico": case ".png": case ".jpeg": case ".tif": case ".rar": case ".doc": case ".zip": case ".txt":
                            alert("错误的视频文件"); return false;
                            break;
                        case ".swf":
                            var content = "<embed width=\"500\" height=\"400\" src=\"" + gvalur + "\" quality=\"high\" pluginspage=\"http://www.adobe.com/go/getflashplayer_cn\" align=\"middle\" play=\"true\" loop=\"true\" scale=\"showall\" wmode=\"window\" devicefont=\"false\ menu=\"true\" allowscriptaccess=\"sameDomain\" type=\"application/x-shockwave-flash\" />"
                            break;
                        case ".flv":
                            var content = "<div id=\"flashcontent\"></div><div id=\"video\"><div id=\"a1\">" + gvalur + "</div></div><script>ck({f:'" + gvalur + "'},'600', '500');<\/\script>";
                            break;
                        default:
                            alert("视频只支持FLV、SWF视频播放!"); return false;
                            break;
                    }
                     editor.insertHtml(content);   
                }
                else {
                    alert('错误的视频');
                    return false;
                }
            }
            else {
                alert('没有视频文件');
                return false;
            }
        }
        function clear()
        {
            $('#SpecialName').val("");
            $('#SpecialID').val("");
        }
</script>
</head>

<body>
<form id="form1" runat="server">
    <iframe width="260" height="165" id="colorPalette" src="../js/selcolor.htm"
        style="visibility: hidden; position: absolute; border: 1px gray solid; left: 297px;
        top: -20px;" frameborder="0" scrolling="no"></iframe>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>新闻管理</h3></div>
      <div class="mian_wei_right">
         <div class="mian_wei_right_img" > 导航：<a href="javascript:openmain('../main.aspx')">首页</a><span id="naviClassName" runat="server" />>><label id="m_NewsChar" runat="server" /> </div>
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
       <div class="newxiu_lan">
          <ul class="tab_zzjs_" id="tab_zzjs_">
             <li id="tab_zzjs_1" class="hovertab_zzjs" onclick="x:hover_zzjs_net(1,1,3);">基本信息</li>
             <li id="tab_zzjs_2" class="nor_zzjs" onclick="x:hover_zzjs_net(2,1,3);">高级属性</li>
             <li id="tab_zzjs_3" class="nor_zzjs" onclick="x:hover_zzjs_net(3,1,3);">自定义内容</li>
          </ul>
          <div id="style_Pro" runat="server" style="display: none;">
            <asp:CheckBox ID="style_hidden" runat="server" /></div>
          <div class="newxiu_bot">
             <div class="dis_zzjs_net" id="tab_zzjs_01">
                <div class="newxiu_base">
                   <table class="nxb_table" align="center" cellspacing="0" cellpadding="0" border="0">
                      <tr>
                         <td width="10%" align="right">类型：</td>
                         <td width="90%">
                          <asp:RadioButton ID="atRadioButton" runat="server" GroupName="NewsType" onclick="show()" Checked="True" class="radio"/>普通
                          <asp:RadioButton ID="at1RandButton" runat="server" GroupName="NewsType" onclick="show()" class="radio" />图片
                          <asp:RadioButton ID="at2RandButton" runat="server" GroupName="NewsType" onclick="show()" class="radio" />标题
                            
                            <font></font><span>*</span>权重<asp:TextBox ID="OrderIDText" runat="server" Text="0" class="input1"></asp:TextBox>
                          <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_004',this)">  帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="10%" align="right"><span>*</span>标题：</td>
                         <td><asp:TextBox ID="NewsTitle" runat="server" class="input2"></asp:TextBox>
                             <asp:CheckBox Checked="true" ID="isHTML" class="checkbox1"  runat="server" Text="" />立刻发布
                             <asp:DropDownList ID="DropDownList1" CssClass="select2" onchange="javascript:titleFlag(this.value);"        runat="server">
                             <asp:ListItem>类型</asp:ListItem>
                             <asp:ListItem Value="[图文]">[图文]</asp:ListItem>
                             <asp:ListItem Value="[原创]">[原创]</asp:ListItem>
                             <asp:ListItem Value="[转载]">[转载]</asp:ListItem>
                             <asp:ListItem Value="【荐】">【荐】</asp:ListItem>
                             <asp:ListItem Value="【HOT】">【HOT】</asp:ListItem>
                             </asp:DropDownList>                            
                             <asp:HiddenField ID="TitleColor" runat="server" />
                              <img src="../imges/Rect.gif" alt="-" name="MarkFontColor_Show"
                        width="18" height="17" border="0" align="absmiddle" id="MarkFontColor_Show" style="cursor: pointer;
                        background-color: #<%= TitleColor.Value%>;" title="标题颜色选取" onclick="GetColor(this,'TitleColor');" />
                             <asp:CheckBox ID="TitleBTF" runat="server" class="checkbox2" title="是否粗体" /><strong>B</strong>
                             <asp:CheckBox ID="TitleITF" runat="server" title="是否斜体" class="checkbox2" /><i>I</i>
                             <asp:CheckBox ID="CommLinkTF" runat="server" title="评论连接" class="checkbox2" />评论链接
                             
                         </td>
                      </tr>
                      <tr>
                         <td width="10%" align="right">副标题：</td>
                         <td><asp:TextBox ID="sNewsTitle" runat="server" class="input2" /><span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_sNewsTitle',this)">帮助</span>
                             <asp:CheckBox ID="SubTF" onclick="AddSubTF('SubTF');" runat="server" class="checkbox2" title="添加子新闻"/>添加子新闻<span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_008',this)">帮助</span>
                         </td>
                      </tr>
                      <tr>
                         <td width="10%" align="right">栏目：</td>
                         <td><asp:TextBox ID="ClassName" runat="server" class="input3"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="ClassID" /><label id="showClassTF" runat="server">
                            <a href="javascript:selectFile('ClassName,ClassID','栏目选择','newsclass','400','300')"><img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a></label>
                            <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_006',this)">帮助</span>
                            专题 <asp:TextBox ID="SpecialName" runat="server" class="input3" /><asp:HiddenField runat="server" ID="SpecialID" />
                            <a href="javascript:selectFile('SpecialName,SpecialID','专题选择','newsspecial','400','300')"><img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                            <a href="javascript:clear()">清除</a>
                            <span class="helpstyle" style="cursor: help;"  title="点击显示帮助" onclick="Help('H_News_add_007',this)">帮助</span>                         
                         </td>
                      </tr>
                      <tr id="div_SubList" style="display: none;">
                        <td colspan="2">                          
                           <div class="show_big">
                               <div class="show">
                               <div class="show_top"><font>子新闻设置</font></div>
                               <div class="show_yul" id="UnNewsList">

                               </div>
                           </div>
                           <div class="show_bot" id="div_UnnewsIframe">
                          
                           </div>
                           </div>
                        </td>
                      </tr>
                      <tr id="div_URLaddress" style="display: none;">
                         <td width="10%" align="right">外部地址：</td>
                         <td>
                             <asp:TextBox ID="URLaddress" runat="server" class="input4"></asp:TextBox>                            
                           <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_URLaddress',this)">
                        帮助</span>
                         </td>
                      </tr>
                      <tr  id="div_PicURL" runat="server" style="display: none;">
                         <td width="10%" align="right">图片地址：</td>
                         <td style="_margin:5px 0; _line-height:30px;">
                             <asp:TextBox ID="PicURL" runat="server" class="input4"></asp:TextBox>                            
                             <img src="../imges/bgxiu_14.gif" alt="" id="image1" align="smiddle" class="img1"  />
                             <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_PicURL',this)">
                        帮助</span>
                          <asp:CheckBox ID="SPicURLTF" runat="server" class="checkbox2" title="是否生成小图" onclick="isshow('SPicURLTF','Div_hw');"/>自动生成小图
                         <asp:HiddenField ID="SPicURL" runat="server" />                          
                            <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_SPicURLTF',this)">
                        如何生成小图?</span><br />
                            <div id="Div_hw" style="display: none;_margin:3px 0; _line-height:30px;"">
                              &nbsp;&nbsp;&nbsp;缩图高：<asp:TextBox class="input1" ID="stHeight" runat="server"></asp:TextBox><a href="#" class="a1">高度? </a>
                            缩图宽：<asp:TextBox class="input1" ID="stWidth" runat="server"></asp:TextBox><a href="#" class="a1">宽度?</a></div>
                         </td>
                      </tr>
                      <tr>
                         <td width="10%" align="right" valign="top">
                                                    
                             导读：
                         </td>
                         <td>
                         <div class="textdiv">
                         <asp:CheckBox ID="naviContentTF" runat="server" title="为内容设置导读" onclick="javascript:isshow('naviContentTF','div_naviContent');"/></div>
                            <div class="textdiv" id="div_naviContent" style="display:none">
                                <asp:TextBox ID="naviContent" runat="server" class="textarea" TextMode="MultiLine"></asp:TextBox>
                               <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_NaviContent',this)">
                        帮助</span>
                            </div>
                         </td>
                      </tr>
                      <tr id="div_Content">
                         <td width="10%" align="right" valign="top">
                             内容 ：<br /><span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_naviContentTF',this)">帮助</span>
                         </td>
                         <td>
                            <div class="neitab">
                              <asp:CheckBox ID="RemoteTF" runat="server" title="保存图片(文件)到本地" class="checkbox2" />远程存图
                              <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_downfiles',this)">帮助</span>
                              <asp:CheckBox ID="sPicFromContent" runat="server" class="checkbox2" onclick="isshow('sPicFromContent','getContentNum');" />提取图片地址<font></font> <label id="getContentNum" style="display: none;">                             
                              提取第 <asp:TextBox ID="btngetContentNum" runat="server" Text="1" class="input5"></asp:TextBox>张</label><span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_getContentPic',this)">
                            帮助</span>
                              <asp:CheckBox ID="sNaviContentFromContent"  runat="server" class="checkbox2"/>获取导读<span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_getNaviContent',this)">帮助</span>
                            </div>
                            <div class="neitab">                              
                               <font></font>插入分页符：
                               <span>分页标题</span>
                               <asp:TextBox ID="PageTitle" Text="" runat="server" Width="200px"></asp:TextBox>
                               <input name="insertHtml" type="button" value="插入" class="form1" />
                            </div> 
                            <div class="neitab">
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" class="checkbox2" />自动分页
                             每页字数：<asp:TextBox ID="TxtPageCount" runat="server" class="input5">30000</asp:TextBox>
                            </div> 
                            <div class="neitab1">
                               <textarea name="content" id="content" runat="server" style="width:98%; height:400px;visibility:hidden;"></textarea>
                            </div>
                         </td>
                      </tr>
                           <tr id="div_vURL">
                <td width="10%" align="right">
                    视频地址：
                </td>
                <td>
                    <asp:TextBox ID="vURL" runat="server"  MaxLength="200" class="input4"></asp:TextBox>
                     <a href="javascript:selectFile('vURL','视频选择','file','500','350')"><img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a><a href="javascript:void(0);" onclick="ivurl();" style="color: Blue;">把视频添加入编辑器中</a>
                </td>
            </tr>
                      
                      <tr id="isFiles_div">
                         <td width="10%" align="right">是否有附件：</td>
                         <td> <asp:CheckBox ID="isFiles" runat="server" onclick="javascript:isshow('isFiles','Addfile,isFiles_div1')" class="checkbox2"/><label id="Addfile" style="display:none"><a href="javascript:Addfiles()">添加附件</a></label></td>
                      </tr>
                      <tr id="isFiles_div1" style="display:none">
                         <td width="10%" align="right">附件列表：<asp:HiddenField ID="NewsFiles" runat="server" /></td>
                         <td  id="filelist" runat="server">
                         <div class="neitab">名称：<input type="text" name="fm" value="" class="input7"/>地址：<input type="text" name="adss" value="" class="input6" id="input0"/><a href="javascript:selectFile('input0','附件选择','file','500','350')"><img src="../imges/bgxiu_14.gif" alt=""  class="img1"  /></a>排序<input type="text" name="lie" value="0" class="input5" /><a href="javascript:" name="Delfile"  class="a5">删除</a></div>
                         </td>
                      </tr>
                      <tr>
                         <td width="10%" align="right">属性：</td>
                         <td><label id="NewsProperty_CommTF">
                             <asp:CheckBox ID="NewsProperty_CommTF1" Checked="true" runat="server" class="checkbox2"/>允许评论</label>
                             <label id="NewsProperty_DiscussTF">
                             <asp:CheckBox ID="NewsProperty_DiscussTF1" Checked="true" runat="server"  class="checkbox2" Visible="False" /><%--允许创建讨论组--%>
                             </label>
                             <label id="NewsProperty_RECTF">
                             <asp:CheckBox ID="NewsProperty_RECTF1" runat="server"  class="checkbox2"/>推荐
                             </label>
                             <label id="NewsProperty_MARTF">
                             <asp:CheckBox ID="NewsProperty_MARTF1" runat="server"  class="checkbox2"/>滚动
                             </label>
                             <label id="NewsProperty_HOTTF">              
                             <asp:CheckBox ID="NewsProperty_HOTTF1" runat="server"  class="checkbox2"/>热点
                             </label>
                             <label id="NewsProperty_FILTTF">
                             <asp:CheckBox ID="NewsProperty_FILTTF1" runat="server"  class="checkbox2"/>幻灯
                             </label>
                             <label id="NewsProperty_TTTF">                   
                             <asp:CheckBox ID="NewsProperty_TTTF1" onclick="isshow('NewsProperty_TTTF1','div_TTSE');" runat="server" class="checkbox2" />头条
                             </label>
                             <label id="NewsProperty_ANNTF">
                             <asp:CheckBox ID="NewsProperty_ANNTF1" runat="server"  class="checkbox2"/>公告
                             </label>
                             <label id="NewsProperty_JCTF">
                             <asp:CheckBox ID="NewsProperty_JCTF1" runat="server"  class="checkbox2"/>精彩
                             </label>
                             <label id="NewsProperty_WAPTF" style="display:none">
                             <asp:CheckBox ID="NewsProperty_WAPTF1" runat="server" class="checkbox2" />WAP
                              </label>                      
                         </td>
                      </tr>
                       <tr id="div_TTSE" style="display: none;">
                         <td width="10%" align="right">头条参数 ：</td>
                         <td>
                            <asp:CheckBox ID="PicTTTF" runat="server" onclick="isshow('PicTTTF','div_TT');" class="checkbox2"/>图片头条
                           <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_TTTitle0',this)"> 帮助</span>
                         </td>
                      </tr>
                      <tr  id="div_TT" style="display: none;">
                         <td width="10%" align="right">图片头条：</td>
                         <td>
                            &nbsp;&nbsp;&nbsp;字体:
                             <asp:DropDownList ID="PageFontFamily" runat="server" class="select2">
                    </asp:DropDownList>                            
                             样式: <asp:DropDownList ID="PageFontStyle" runat="server" class="select2">
                    </asp:DropDownList>
                    <asp:HiddenField ID="fontColor" Value="000000" runat="server" />
                                 字体颜色:
                                 <img src="../imges/Rect.gif" alt="-" name="MarkFontColor_Show"
                        width="18" height="17" border="0" align="absmiddle" id="Img1" style="cursor: pointer;
                        background-color: #<%= fontColor.Value%>;" title="字体颜色选取" onclick="GetColor(this,'fontColor');" />
                        <label style="display: none;">
                        字体间距:
                        <asp:TextBox ID="fontCellpadding" MaxLength="2" runat="server" Width="20px">20</asp:TextBox>px
                        &nbsp;</label>
                                 字号: <asp:TextBox ID="PagefontSize" runat="server" class="input1">20</asp:TextBox>px
                                 图片宽度：<asp:TextBox ID="PagePicwidth" runat="server" class="input1">200</asp:TextBox>px 
                                 图片背景色: <asp:HiddenField ID="Imagesbgcolor" Value="ffffff" runat="server" /><img src="../imges/Rect.gif" alt="-" name="MarkFontColor_Show" width="18" height="17" border="0" align="absmiddle" id="Img2" style="cursor: pointer;        background-color: #<%= Imagesbgcolor.Value%>;" title="选取图片前景色" onclick="GetColor(this,'Imagesbgcolor');" /><br />
                            &nbsp;&nbsp;&nbsp;自定义标题: <asp:TextBox ID="topFontInfo" runat="server" class="input4"></asp:TextBox>
                           <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_TTTitle',this)">
                        帮助</span>
                             <asp:HiddenField ID="tl_SavePath" runat="server" />
                            <a class="a4" href="javascript:getReview();">预览图片效果</a>
                         </td>
                      </tr>                      
                      <tr id="div_Templet">
                         <td width="10%" align="right">模板：</td>
                         <td><span runat="server" id="labelTemplet">
                             <asp:TextBox ID="Templet" runat="server" class="input4"></asp:TextBox>                             
                             <a href="javascript:selectFile('Templet','模版选择','templet','500','350')">
                             <img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                             </span>
                             <span runat="server" id="dropTemplet">
                                <asp:TextBox ID="dTemplet" runat="server" class="input4"></asp:TextBox>                             
                                 <a href="javascript:selectFile('dTemplet','模版选择','templet','500','350')">
                                 <img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                             </span>
                             <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_Templet',this)">
                        帮助</span>
                         </td>
                      </tr>
                      <tr id="div_Souce">
                         <td width="10%" align="right">来源：</td>
                         <td>
                           <div class="textdiv">
                            <asp:TextBox ID="Souce" runat="server" class="input6"></asp:TextBox>                            
                            <a href="javascript:selectFile('Souce','文章来源','Source','500','350')"><img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                            <a href="javascript:addSource('本站');" class="a5">本站</a>  <a href="javascript:addSource('未知');""  class="a5">未知</a>  <a href="javascript:addSource('网络来源');""  class="a5">网络来源</a>
                            <asp:CheckBox ID="SouceTF" runat="server" title="记忆" class="checkbox2" />记忆
                            作者：<asp:TextBox ID="Author" class="input6" runat="server"></asp:TextBox>
                            <a href="javascript:selectFile('Souce','文章来源','Author','500','350')"><img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                            <a href="javascript:addAuthor('本站');" class="a5">本站</a>  <a href="javascript:addAuthor('未知');"  class="a5">未知</a>  <a href="javascript:addAuthor('网络来源');"  class="a5">网络来源</a>
                            <asp:CheckBox ID="AuthorTF" runat="server" title="记忆" class="checkbox2" />记忆<font></font>
                            </div>
                         </td>
                       </tr>
                       <tr id="div_Tags">
                          <td width="10%" align="right">标签(Tag}：</td>
                          <td>
                           <div class="textdiv">
                           <asp:TextBox ID="Tags" runat="server" class="input6"></asp:TextBox>   
                           <a href="javascript:selectFile('Tags','文章来源','Tag','500','350')">             
                             <img src="../imges/bgxiu_14.gif" alt="" align="middle" class="img1"  /></a>
                              <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_tags',this)">
                        什么是标签</span>
                            <asp:CheckBox ID="TagsTF" runat="server" title="记忆" class="checkbox2" />记忆<br />                         
                            <div id="lastTags" runat="server"></div>
                            </div>
                          </td>
                       </tr>
                   </table>                   
                </div>
             </div>
              <div class="undis_zzjs_net" id="tab_zzjs_02">
                 <div class="newxiu_base">
                   <table class="nxb_table">
                      <tr id="div_showad">
                         <td colspan="2"><h4>&nbsp;<asp:CheckBox ID="ShowAdance" Checked="true" onclick="isshow('ShowAdance','div_metakey,div_metadesc,div_Click,div_SavePath,div_FileName,tr_editorTime,div_FileEXName,div_CheckStat,div_UserPop1,div_ContentPicTF')" class="checkbox1" runat="server" />显示高级选项</h4></td>
                      </tr>                      
                      <tr id="div_metakey">
                         <td width="10%" align="right">Meta关键字：</td>
                         <td><asp:TextBox ID="Metakeywords" runat="server"  TextMode="MultiLine" class="textarea2"></asp:TextBox></td>
                      </tr>
                      <tr id="div_metadesc">
                         <td width="10%" align="right">Meta描述：</td>
                         <td><asp:TextBox ID="Metadesc" runat="server"  class="textarea2" TextMode="MultiLine"></asp:TextBox></td>
                      </tr>
                      <tr id="div_Click">
                         <td width="10%" align="right">点击：</td>
                         <td><asp:TextBox ID="Click" runat="server" class="input4">0</asp:TextBox></td>
                      </tr>
                      <tr id="div_SavePath">
                         <td width="10%" align="right">保存路径：</td>
                         <td><asp:TextBox ID="SavePath" runat="server" class="input4" onclick="selectFile('rulesmallPram',this,100,450);document.Form1.SavePath.focus();"></asp:TextBox> <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_SavePath',this)">
                        帮助</span></td>
                      </tr> 
                      <tr id="div_FileName">
                         <td width="10%" align="right">文件名：</td>
                         <td><asp:TextBox ID="FileName" class="input4" runat="server" onclick="selectFile('rulePram',this,100,650);document.Form1.FileName.focus();"></asp:TextBox><span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_FileName',this)">
                        帮助</span></td>
                      </tr>
                      <tr>
                         <td width="10%" align="right">创建时间：</td>
                         <td width="90%"> <asp:TextBox ID="txtCreateTimes" runat="server" class="input4"></asp:TextBox></td>
                      </tr>
                      <tr  id="tr_editorTime" runat="server">
                         <td width="10%" align="right">修改时间：</td>
                         <td width="90%"><asp:TextBox ID="txtEditorTime" runat="server"  class="input4"></asp:TextBox>
                         <asp:HiddenField ID="HiddenField_editTime" runat="server" /></td>
                      </tr>
                      <tr id="div_FileEXName">
                         <td width="10%" align="right">扩展名：</td>
                         <td>
                        <asp:DropDownList ID="FileEXName" runat="server" class="select3">
                        <asp:ListItem>.html</asp:ListItem>
                        <asp:ListItem>.htm</asp:ListItem>
                        <asp:ListItem>.shtml</asp:ListItem>
                        <asp:ListItem>.shtm</asp:ListItem>
                        <asp:ListItem>.aspx</asp:ListItem>
                    </asp:DropDownList>
                             <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_FileEXName_2',this)">
                        帮助</span>
                         </td>
                      </tr>
                       <tr  id="div_CheckStat">
                         <td width="10%" align="right">审核状态：</td>
                         <td>                           
                        <asp:DropDownList ID="CheckStat" runat="server" class="select3">
                        <asp:ListItem Value="0">不审核</asp:ListItem>
                        <asp:ListItem Value="1">一级审核</asp:ListItem>
                        <asp:ListItem Value="2">二级审核</asp:ListItem>
                        <asp:ListItem Value="3">三级审核</asp:ListItem>
                        </asp:DropDownList>
                           <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_FileEXName',this)">
                        帮助</span>
                         </td>                      
                       </tr> 
                       <tr id="div_UserPop1">
                          <td  width="10%" align="right">浏览权限：</td>
                          <td>                           
                          <div class="textdiv5"><uc1:UserPop ID="UserPop1" runat="server"/></div>
                          </td>
                       </tr>                         
                       <tr id="div_ContentPicTF">
                          <td  width="10%" align="right">画中画广告：</td>
                          <td><asp:CheckBox ID="ContentPicTF" class="checkbox2" runat="server" onclick="isshow('ContentPicTF','div_ContentPicURL,div_tHight');" /><span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_ContentPicTF',this)">
                        帮助</span></td>
                       </tr> 
                       <tr id="div_ContentPicURL" style="display:none;">
                          <td  width="10%" align="right">地址或代码：</td>
                          <td>
                              <div class="textdiv">
                               <asp:TextBox ID="ContentPicURL" TextMode="MultiLine" runat="server" class="textarea"></asp:TextBox><img src="../imges/bgxiu_14.gif" alt="选择图片地址" border="0" style="cursor: pointer;" onclick="selectFile('pic',document.Form1.ContentPicURL,280,500);document.Form1.ContentPicURL.focus();" />
                              <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_ContentPicURL',this)">
                        帮助</span>
                              </div>
                          </td>
                       </tr> 
                       <tr id="div_tHight" style="display:none;">
                          <td  width="10%" align="right">参数：</td>
                          <td>
                              <asp:TextBox ID="tHight" runat="server" class="input8">200</asp:TextBox>px(高)┊
                              <asp:TextBox ID="tWidth" runat="server" class="input8">200</asp:TextBox>px(宽)
                              <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_News_add_ContentPicSize',this)">
                        帮助</span>
                          </td>
                       </tr>                       
                   </table>                  
                 </div>
             </div>
             <div class="undis_zzjs_net" id="tab_zzjs_03">
                 <div class="newxiu_base">
                   <table class="nxb_table">
                         <label id="getdefined" runat="server" />
                   </table>
                   
                 </div>                      
             </div>
             <div class="nxb_submit" > <asp:HiddenField ID="EditAction" runat="server" />
                <asp:HiddenField ID="NewsID" runat="server" />
                <asp:Button ID="Button2" runat="server" class="xsubmit1" Text="保存新闻" OnClick="Buttonsave_Click" CausesValidation="False" OnClientClick="javascript:return checkNews()" />
             </div>
             <div class="clear"></div>
          </div>
       </div>
   </div>
</div>
</div>
<div id="dialog-message" title="提示"></div>
</form>
</body>
</html>
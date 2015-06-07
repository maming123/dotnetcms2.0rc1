<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="utf-8" Inherits="SelectNewsClass"
    CodeBehind="SelectNewsClass.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>选择栏目__By Foosun.net & Foosun Inc.</title>   
    <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/popup_window.css"/>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <style type="text/css">
        .LableSelectItem
        {
            background-color: highlight;
            cursor: pointer;
            color: white;
            text-decoration: none;
        }
        .LableItem
        {
            cursor: pointer;
        }
        .SubItem
        {
            margin-left: 15px;
        }
        .RootItem
        {
            font-size: 12px;
			_padding-bottom:10px;
        }
        body
        {
            margin: 0px;
        }
    </style>
    <!--[if IE 6]><style type="text/css">html{overflow:hidden;} body{height:100%;overflow:auto;}</style><![endif]-->
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
        <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SwitchImg(ImgObj, ParentId) {
            var ImgSrc = "", SubImgSrc;
            ImgSrc = ImgObj.src;
            SubImgSrc = ImgSrc.substr(ImgSrc.length - 5, 12);
            if (SubImgSrc == "b.gif") {
                ImgObj.src = ImgObj.src.replace(SubImgSrc, "s.gif");
                ImgObj.alt = "点击收起子栏目";
                SwitchSub(ParentId, true);
            } else {
                if (SubImgSrc == "s.gif") {
                    ImgObj.src = ImgObj.src.replace(SubImgSrc, "b.gif");
                    ImgObj.alt = "点击展开子栏目";
                    SwitchSub(ParentId, false);
                } else {
                    return false;
                }
            }
        }
        function SwitchSub(ParentId, ShowFlag) {
            if (ShowFlag) {
                $("#Parent" + ParentId).css("display", "block");
                if ($("#Parent" + ParentId).html() == "" || $("#Parent" + ParentId).html() == "栏目加载中...") {
                    $("#Parent" + ParentId).html("栏目加载中...");
                    GetSubClass(ParentId);
                }
            } else {
                $("#Parent" + ParentId).css("display", "none");
            }
        }
        function SelectLable(classid, classname) {
            if ($('#ClsID').val() != "") {
                $("#" + $('#ClsID').val()).attr("class", "LableItem");
            }
            $("#" + classid).attr("class", "LableSelectItem");
            $('#ClsID').val(classid);
            $('#ClsName').val(classname);
        }

        function GetSubClass(ParentId) {
            var multi = '<%= Request["multi"] %>';
            var url = 'SelectNewsClassAjax.aspx?multi=<%= Request["multi"] %>&ParentId=' + ParentId + '&controlName=<%= Request["controlName"]%>';
            if (multi == 'true') {
                $("#checked").html("<input type=\"checkbox\" class=\"checkbox2\" value=\"全选\" id=\"slall\" onclick=\"selectAll(this.form,this.checked)\"><lable for=\"slall\">&nbsp;全选</lable>&nbsp;&nbsp;&nbsp;&nbsp;");
            }
            $.get(url, function (OriginalRequest) {
                var ClassInfo;
                if (OriginalRequest != "" && OriginalRequest.indexOf("|||") > -1) {
                    ClassInfo = OriginalRequest.split("|||");
                    if (ClassInfo[0] == "Succee") {
                        $("#Parent" + ClassInfo[1]).html(ClassInfo[2]);
                    } else {
                        $("#Parent" + ClassInfo[1]).html("<a href=\"点击重试\" onclick=\"$('#Parent" + ClassInfo[1] + "').innerHTML='栏目加载中...';GetSubClass('" + ClassInfo[1] + "');return false;\">点击重试</a>");
                    }
                } else {
                    alert("读取栏目错误.\n请联系管理员.");
                    return false;
                }
            });
        }

        function ReturnValue(obj) {
            var cid = $('#ClsID').val();
            var cnm = $('#ClsName').val();
            var arryret = new Array(cid, cnm);
            try {
                if (obj.indexOf(",") > -1) {
                    var controls = obj.split(",");
                    parent.parent.$("#" + controls[0]).val(cnm);
                    parent.parent.$("#" + controls[1]).val(cid);
                }
            } catch (e) {

            }
            parent.parent.$('#dialog-message').dialog("close");
        }
        window.onload = function () {
            try {
                document.body.ondragstart = function () { return false; };
                document.body.onselectstart = function () { return false; };
            } catch (e) {
                document.body.addEventListener('selectstart', function () { return false; });
                document.body.addEventListener('dragstart', function () { return false; });
            }
            GetSubClass("0");
        };
        function SubValue() {
            var multi = '<%= Request["multi"] %>';
            var controlName = '<%= Request["controlName"]%>';
            var values = [];
            var names = [];
            if (multi == 'true') {
                for (var i = 0; i < document.form1.cbClassId.length; i++) {
                    if (document.form1.cbClassId[i].checked) {
                        values.push(document.form1.cbClassId[i].value);
                        names.push($("#" + document.form1.cbClassId[i].value).html());
                    }
                }
            }
            if (values.length == 0) {
                ReturnValue(controlName);
            } else {
                try {
                    ReturnFun(values, names, controlName);
                } catch (e) {

                }
            }
        }

        function ReturnFun(values, names, controlName) {
            if (controlName.indexOf(",") > -1) {
                controls = controlName.split(",");
                parent.parent.$("#" + controls[0]).val(names);
                parent.parent.$("#" + controls[1]).val(values);
            }
            parent.parent.$('#dialog-message').dialog("close");
        }
    </script>
</head>
<body>
    <form name="form1" action="" class="co_from">
    <div id="pnlButtons" style="position: fixed; _position: absolute; top: 10px; right: 20px;
        _right: 30px;">
        <table>
            <tr>
                <td><div id="checked"></div></td>
                <td><input type="button" onclick="SubValue()" id="btnReturn" class="insubt" name="Submit" value="确定" /></td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="ClsName" name="ClsName" value="" />
    <input type="hidden" id="ClsID" name="ClsID" value="" />
    <div id="Parent0" class="RootItem">
        栏目加载中...
    </div>
    </form>
</body>
</html>

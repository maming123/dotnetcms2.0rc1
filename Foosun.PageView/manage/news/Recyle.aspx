<%@ Page Language="C#" AutoEventWireup="true" Inherits="Recyle" ResponseEncoding="utf-8"
    CodeBehind="Recyle.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="RecList" runat="server" method="post">
    <div class="mian_body">
        <div class="mian_wei">
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>回收站</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>回收站</div>  
              </div>
           </div>
        <div class="mian_cont">
   <div class="nwelie">
       <div class="newxiu_lan">
          <ul class="tab_zzjs_" id="tab_zzjs_">
             <li id="TdNCList" class="hovertab_zzjs" onclick="ChangeDiv('NCList')">新闻栏目</li>
             <li id="TdNList" class="nor_zzjs" onclick="ChangeDiv('NList')">新闻</li>
             <li id="TdSList" class="nor_zzjs" onclick="ChangeDiv('SList')">专题</li>
             <li id="TdLCList" class="nor_zzjs" onclick="ChangeDiv('LCList')">标签栏目</li>
             <li id="TdLList" class="nor_zzjs" onclick="ChangeDiv('LList')">标签</li>
             <li id="TdStCList" class="nor_zzjs" onclick="ChangeDiv('StCList')">样式栏目</li>
             <li id="TdStList" class="nor_zzjs" onclick="ChangeDiv('StList')">样式</li>
          </ul>
          <div class="newxiu_bot">
             <div class="dis_zzjs_net" id="tab_zzjs_01">
                <div class="newxiu_base">
                   <div id="List">
                    
                   </div>
                </div>
             </div>
             <div class="undis_zzjs_net" id="tab_zzjs_02">
             </div>
             <div class="undis_zzjs_net" id="tab_zzjs_03">                  
             </div>
          </div>
       </div>
   </div>
</div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function ChangeDiv(ID) {
        Selete(ID);
        setCookie("type", ID);
        setCookie("page", 0);
        GetList(ID, 0);
    }

    function Selete(ID) {
        document.getElementById("TdNCList").className = 'nor_zzjs';
        document.getElementById("TdNList").className = 'nor_zzjs';
        document.getElementById("TdSList").className = 'nor_zzjs';
        document.getElementById("TdLList").className = 'nor_zzjs';
        document.getElementById("TdLCList").className = 'nor_zzjs';
        document.getElementById("TdStCList").className = 'nor_zzjs';
        document.getElementById("TdStList").className = 'nor_zzjs';
        document.getElementById("Td" + "" + ID + "").className = 'hovertab_zzjs';
    }

    function RAll(Type)//全部恢复
    {
        switch (Type) {
            case "NCList":
                if (confirm('你确认恢复全部的新闻栏目吗?')) { getresult(Type, "RAll", ""); }
                break;
            case "NList":
                if (confirm('你确认恢复全部的新闻吗?')) { getresult(Type, "RAll", ""); }
                break;
            case "CList":
                if (confirm('你确认恢复全部的频道吗?')) { getresult(Type, "RAll", ""); }
                break;
            case "SList":
                if (confirm('你确认恢复全部的专题吗?')) { getresult(Type, "RAll", ""); }
                break;
            case "LList":
                if (confirm('你确认恢复全部的标签吗?')) { getresult(Type, "RAll", ""); }
                break;
            case "LCList":
                if (confirm('你确认恢复全部的标签栏目吗?')) { getresult(Type, "RAll", ""); }
                break;
            case "StCList":
                if (confirm('你确认恢复全部的样式栏目吗?')) { getresult(Type, "RAll", ""); }
                break;
            case "StList":
                if (confirm('你确认恢复全部的样式吗?')) { getresult(Type, "RAll", ""); }
                break;
        }
    }
    function DAll(Type)//全部删除
    {
        switch (Type) {
            case "NCList":
                if (confirm('你确认删除回收站中的新闻栏目吗?\r此操作将彻底删除回收站中所有的栏目以及与这些栏目有关的新闻以及评论!')) { getresult(Type, "DAll", ""); }
                break;
            case "NList":
                if (confirm('你确认删除回收站中的新闻吗?\r此操作将彻底删除回收站中所有的新闻以及与这些新闻相关的评论!')) { getresult(Type, "DAll", ""); }
                break;
            case "CList":
                if (confirm('你确认删除回收站中的频道吗?\r此操作将彻底删除回收站中所有的新闻栏目,专题,新闻以及与这些新闻相关的评论!')) { getresult(Type, "DAll", ""); }
                break;
            case "SList":
                if (confirm('你确认删除回收站中的专题吗?\r此操作将彻底删除回收站中所有的专题!')) { getresult(Type, "DAll", ""); }
                break;
            case "LList":
                if (confirm('你确认删除回收站中的标签吗?\r此操作将彻底删除回收站中所有的标签!')) { getresult(Type, "DAll", ""); }
                break;
            case "LCList":
                if (confirm('你确认删除回收站中的标签栏目吗?\r此操作将彻底删除回收站中所有的标签栏目以及这些栏目下面有关的标签!')) { getresult(Type, "DAll", ""); }
                break;
            case "StCList":
                if (confirm('你确认删除回收站中的样式栏目吗?\r此操作将彻底删除回收站中所有的样式栏目以及这些栏目下面有关的样式!')) { getresult(Type, "DAll", ""); }
                break;
            case "StList":
                if (confirm('你确认删除回收站中的样式吗?\r此操作将彻底删除回收站中所有的样式!')) { getresult(Type, "DAll", ""); }
                break;
        }
    }
    function PR(Type)//批量恢复
    {
        var tempID = "";
        for (i = 0; i < document.RecList.length; i++) {
            if (document.RecList.elements[i].type == "checkbox" && document.RecList.elements[i].checked == true) {
                tempID = tempID + document.RecList.elements[i].value + ",";
            }
        }
        switch (Type) {
            case "NCList":
                if (confirm('你确认批量恢复选中的新闻栏目吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "NList":
                if (confirm('你确认批量恢复选中的新闻吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "CList":
                if (confirm('你确认批量恢复选中的频道吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "SList":
                if (confirm('你确认批量恢复选中的专题吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "LList":
                if (confirm('你确认批量恢复选中的标签吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "LCList":
                if (confirm('你确认批量恢复选中的标签栏目吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "StCList":
                if (confirm('你确认批量恢复选中的栏目样式吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "StList":
                if (confirm('你确认批量恢复选中的样式吗?')) { getresult(Type, "PR", tempID); }
                break;
            case "PSFList":
                if (confirm('你确认批量恢复选中的PSF(结点)吗?')) { getresult(Type, "PR", tempID); }
                break;
        }
    }
    function PD(Type)//批量删除
    {
        var tempID = "";
        for (i = 0; i < document.RecList.length; i++) {
            if (document.RecList.elements[i].type == "checkbox" && document.RecList.elements[i].checked == true) {
                tempID = tempID + document.RecList.elements[i].value + ",";
            }
        }
        switch (Type) {
            case "NCList":
                if (confirm('你确认批量删除选中的新闻栏目吗?\r此操作将彻底删除选中的栏目以及跟选中栏目有关的新闻,以及评论!')) { getresult(Type, "PD", tempID); }
                break;
            case "NList":
                if (confirm('你确认批量删除选中的新闻吗?')) { getresult(Type, "PD", tempID); }
                break;
            case "CList":
                if (confirm('你确认批量删除选中的频道吗?')) { getresult(Type, "PD", tempID); }
                break;
            case "SList":
                if (confirm('你确认批量删除选中的专题吗?')) { getresult(Type, "PD", tempID); }
                break;
            case "LList":
                if (confirm('你确认批量删除选中的标签吗?')) { getresult(Type, "PD", tempID); }
                break;
            case "LCList":
                if (confirm('你确认批量删除选中的标签栏目吗?\r此操作将彻底删除选中栏目以及跟选中栏目有关的标签!')) { getresult(Type, "PD", tempID); }
                break;
            case "StCList":
                if (confirm('你确认批量删除选中的样式栏目吗?\r此操作将彻底删除选中栏目以及跟选中栏目有关的样式!')) { getresult(Type, "PD", tempID); }
                break;
            case "StList":
                if (confirm('你确认批量删除选中的样式吗?')) { getresult(Type, "PD", tempID); }
                break;
            case "PSFList":
                if (confirm('你确认批量删除选中的PSF(结点)吗?')) { getresult(Type, "PD", tempID); }
                break;
        }
    }

    function getresult(Type, Op, idlist) {
        var url = "";
        switch (Type) {
            case "NList":
                url = "Recyle.aspx?className=" + escape($("#className").val()) + "&Type=" + Type + "&Op=" + Op + "&idlist=" + idlist;
                break;
            case "StList":
                url = "Recyle.aspx?className=" + escape($("#className").val()) + "&Type=" + Type + "&Op=" + Op + "&idlist=" + idlist;
                break;
            case "LList":
                url = "Recyle.aspx?className=" + escape($("#className").val()) + "&Type=" + Type + "&Op=" + Op + "&idlist=" + idlist;
                break;
            default:
                url = "Recyle.aspx?Type=" + Type + "&Op=" + Op + "&idlist=" + idlist;
                break;
        }
        $.get(url, function (returnvalue) {
            if (returnvalue.indexOf("??") > -1)
                document.getElementById("List").innerHTML = "Error";
            else
                document.getElementById("List").innerHTML = returnvalue;
        });
    }

    function GetList(Type, page) {
        setCookie("type", Type);
        setCookie("page", page);
        Selete(Type);
        $.get("Recyle.aspx?no-cache=" + Math.random() + "&Type=" + Type + "&page=" + page, function (returnvalue) {
            if (returnvalue.indexOf("??") > -1)
                document.getElementById("List").innerHTML = "Error";
            else
                document.getElementById("List").innerHTML = returnvalue;
        });
    }
    if (getCookie("type") != null && getCookie("type") != "null" && getCookie("type") != "") {
        GetList(getCookie("type"), getCookie("page"));
    }
    else {
        GetList('NCList', 0);
    }
</script>

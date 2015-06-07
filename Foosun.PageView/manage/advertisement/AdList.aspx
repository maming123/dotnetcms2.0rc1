<%@ Page Language="C#" AutoEventWireup="true" Inherits="AdList"  ResponseEncoding="utf-8" Codebehind="AdList.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>广告系统</title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
      <div class="mian_wei">
       <div class="mian_wei_min">
          <div class="mian_wei_left"><h3>广告系统</h3></div>
          <div class="mian_wei_right">
              导航：<a href="javascript:openmain('../main.aspx')">首页</a>&gt;&gt;广告系统
          </div>
       </div>
    </div>
      <div class="mian_cont">
        <div class="nwelie">
       <div class="newxiu_lan">
          <ul class="tab_zzjs_" id="tab_zzjs_">
             <li id="TdAds" class="hovertab_zzjs" onclick="javascript:ChangeDiv('Ads')">广告管理</li>
             <li id="TdClass" class="nor_zzjs" onclick="javascript:ChangeDiv('Class')">分类管理</li>
             <li id="TdStat" class="nor_zzjs" onclick="javascript:ChangeDiv('Stat')">统计管理 	</li>
          </ul>
          <div class="newxiu_bot" id="List">
             
          </div>
       </div>
   </div>
</div>
    <br />
    <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg" style="height: 76px" align="center">
      <tr>
        <td align="center"><input type="hidden" name="ads_Type" id="ads_Type" value="" /><input type="hidden" name="Show_Type" id="Show_Type" value="" /><input type="hidden" name="SiteValue" id="SiteValue" value="" /></td>
      </tr>
    </table>

    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">

document.form1.Show_Type.value = "";
function AddAdsClass(classid)
{
    self.location = "EditAdsClass.aspx?ParentID=" + classid;
}
function EditAds(type,id)
{
    switch(type)
    {
        case "Ads":
            self.location="EditAds.aspx?AdsID="+id;
            break;
        case "Class":
            self.location = "EditAdsClass.aspx?AdsClassID=" + id;
            break;
        default:
            break;
    }
}

function ShowType(type)
{
    document.form1.ads_Type.value = document.form1.adType.value;
    document.form1.Show_Type.value = "showadstype";
    GetList(getCookie("ads_type"),getCookie("ads_page"));
}
function SearchGo()
{
    document.form1.Show_Type.value = "search";
    GetList(getCookie("ads_type"),getCookie("ads_page"));
}

function changeSite(value)
{
    
    document.form1.Show_Type.value = "site";
    document.form1.SiteValue.value = document.form1.Site.value;
    GetList(getCookie("ads_type"),getCookie("ads_page"));
}

function getID()
{
   var idstr = "";
   for(i=0;i<document.form1.length;i++)
    {
	    if(document.form1.elements[i].type=="checkbox")
	    {
	        if(document.form1.elements[i].checked==true)
	        {
	            idstr = idstr + document.form1.elements[i].value + ",";
	        }
	    }
    }
    return idstr;
}
function DelAll(type)
{
    var idstr = getID();
    switch (type)
    {
        case "Ads":
            if(confirm("你确定要删除全部的广告?"))
            {
                self.location="AdList.aspx?type="+type+"&OpType=adsDelAll";
            }
            break;
        case "Class":
            if(confirm("你确定要删除全部的栏目?\r此操作将会删除全部栏目以及栏目下面的广告!"))
            {
                self.location="AdList.aspx?type="+type+"&OpType=classDelAll";
            }
            break;
        case "Stat":
            if(confirm("你确定要删除全部统计信息?"))
            {
                self.location="AdList.aspx?type="+type+"&OpType=statDelAll";
            }
            break;
    }
}
function Del(type)
{
    var idstr = getID();
    switch (type)
    {
        case "Ads":
            if(confirm("你确定要删除选中的广告?"))
            {
                self.location="AdList.aspx?type="+type+"&OpType=adsDel&ID="+idstr;
            }
            break;
        case "Class":
            if(confirm("你确定要删除选中的栏目?\r此操作将会删除选中的栏目以及选中栏目下面的广告!"))
            {
                self.location="AdList.aspx?type="+type+"&OpType=classDel&ID="+idstr;
            }
            break;
        case "Stat":
            if(confirm("你确定要删除选中的统计信息?"))
            {
                self.location="AdList.aspx?type="+type+"&OpType=statDel&ID="+idstr;
            }
            break;
    }
}

function Lock(type,ID)
{
    self.location="AdList.aspx?type="+type+"&OpType=adsLock&ID="+ID;
}
function UnLock(type,ID)
{
    self.location="AdList.aspx?type="+type+"&OpType=adsUnLock&ID="+ID;
}
function LookInfo(ID)
{
    self.location="ad_stat.aspx?adsID="+ID;
}
function ChangeDiv(ID)
{
    Selete(ID);
    if (navigator.userAgent.indexOf("MSIE 6") < 0) {
        setCookie("ads_type", ID);
        setCookie("ads_page", 0);
    }
	GetList(ID, 0);
}
function Selete(ID)
{
    document.getElementById("TdAds").className = 'nor_zzjs';
    document.getElementById("TdClass").className = 'nor_zzjs';
    document.getElementById("TdStat").className = 'nor_zzjs';
    document.getElementById("Td" + ID + "").className = 'hovertab_zzjs';
}
function GetList(Type,page) {
    if (navigator.userAgent.indexOf("MSIE 6") < 0) {
        setCookie("ads_type", Type);
        setCookie("ads_page", page);
    }
    var selecttype = "Type="+Type+"&page="+page;
    
    switch (Type)
    {
        case "Ads":
            switch (document.form1.Show_Type.value)
            {
                case "showadstype":
                    selecttype = "Type="+Type+"&page="+page+"&SiteID="+escape(document.form1.SiteValue.value)+"&showadstype="+escape(document.form1.Show_Type.value)+"&adsType="+escape(document.form1.ads_Type.value);
                    break;
                case "search":
                    selecttype = "Type="+Type+"&page="+page+"&showadstype="+escape(document.form1.Show_Type.value)+"&searchType="+escape(document.form1.SearchType.value)+"&SearchKey="+escape(document.form1.SearchKey.value);
                    break;
                case "site":
                    selecttype = "Type="+Type+"&page="+page+"&SiteID="+escape(document.form1.SiteValue.value)+"&showadstype="+escape(document.form1.Show_Type.value)+"&adsType="+escape(document.form1.ads_Type.value);
                    break;
                default:
                    selecttype = "Type="+Type+"&page="+page;
                    break;
            }        
            break;
        case "Class":
            selecttype = "Type="+Type+"&page="+page+"&SiteID="+escape(document.form1.SiteValue.value);
            break;
        case "Stat":
            selecttype = "Type="+Type+"&page="+page+"&SiteID="+escape(document.form1.SiteValue.value);
            break;
        default:
            selecttype = "Type="+Type+"&page="+page;
            break;
    }
    Selete(Type);
    $.get('AdList.aspx?' + selecttype + '&no-cache=' + Math.random(), function (transport) {
        if (transport.indexOf("??") > -1)   
            $("#List").html("Error");
        else
            $("#List").html(transport);
    });
}
if (navigator.userAgent.indexOf("MSIE 6") > -1) {
    GetList('Ads', 0);
} else { 
    if(getCookie("ads_type")!=null && getCookie("ads_type")!="null" && getCookie("ads_type")!="")
    {
        GetList(getCookie("ads_type"),getCookie("ads_page"));
    }
    else
    {
        GetList('Ads',0);
    }
}
function getCode(adsID)
{
    var WWidth = (window.screen.width-500)/2;
    var Wheight = (window.screen.height-150)/2;
    //--------------------------------------
    window.open('showJsPath.aspx?adsID='+adsID, '广告JS代码调用', 'height=200, width=400, top='+Wheight+', left='+WWidth+', toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no');
}
</script>

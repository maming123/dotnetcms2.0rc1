<%@ Page Language="C#" AutoEventWireup="true" Inherits="NewsPage" Codebehind="NewsPage.aspx.cs" validateRequest="false" %>

<%@ Register Src="../../controls/UserPop.ascx" TagName="UserPop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css"/>
    <link rel="stylesheet" type="text/css" href="/css/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/controls/kindeditor/kindeditor-min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>

    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>

    <link href="/controls/kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
        <script src="/controls/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
        <script type="text/javascript" language="javascript">
            KindEditor.ready(function (K) {
                var editor = K.create('#Content', {
                    cssPath: '../../controls/kindeditor/plugins/code/prettify.css',
                    uploadJson: '../../controls/kindeditor/asp.net/upload.aspx',
                    fileManagerJson: '../../controls/kindeditor/asp.net/file_manager_json.ashx',
                    allowFileManager: true
                });
                K('#insertPage').click(function (e) {
                    var str = document.getElementById("PageTitle");
                    if (str.value == "") {
                        editor.insertHtml("[FS:PAGE]");
                    }
                    else {
                        editor.insertHtml('[FS:PAGE=' + str.value + '$]');
                    }
                });
            });
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>单页面添加</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>添加单页面
              </div>
           </div>
<%--           <div class="mian_wei_2"><img src="../imges/lie_12.gif" alt="" /></div>--%>
        </div>
        <div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="10%" align="right">直贴源码：</td>
               <td><input type="checkbox" class="checkbox2" id="zt" name="zt" onclick="zhitie(this)" runat="server" /></td>
             </tr>
             <tr>
               <td width="10%" align="right">页面标题：</td>
               <td>
                  <asp:TextBox ID="TCname" Width="300" CssClass="input8" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TCname"
                        Display="Dynamic" ErrorMessage="<span class=reshow>(*)名字不能为空!</span>"></asp:RequiredFieldValidator>
                    <asp:CheckBox ID="NaviShowtf" Text="导航中显示" runat="server" CssClass="checkbox" />
               </td>
             </tr>
             <tr>
                 <td width="10%" align="right">父栏目：</td>
                 <td>
                    &nbsp;&nbsp;&nbsp;<span style="display: none;">
                        <asp:TextBox ID="TParentId" runat="server" MaxLength="100" Width="80" CssClass="input8"></asp:TextBox><img
                            src="../../sysImages/folder/s.gif" alt="选择栏目" border="0" style="cursor: pointer;"
                            onclick="selectFile('newsclass',document.form1.TParentId,250,500);document.form1.TParentId.focus();" /></span><span
                                id="ClassCnamev" class="reshow"><asp:Label ID="lblClassName" runat="server" Text=""></asp:Label></span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TParentId"
                        Display="Dynamic" ErrorMessage="<span class=reshow>(*)选择栏目!如果为根栏目，请填写0</span>"></asp:RequiredFieldValidator>
                    &nbsp;权重&nbsp;<asp:TextBox ID="TOrder" runat="server" Width="93" CssClass="input8"></asp:TextBox>
                    <span class="helpstyle" style="cursor: hand;" title="点击查看帮助" onclick="Help('Class_Aspx_05',this)">
                        帮助</span>
                 </td>
              </tr>
              <tr id="rows_key">
                 <td width="10%" align="right">meta关键字：</td>
                 <td><asp:TextBox ID="KeyMeata" TextMode="MultiLine" Height="50" CssClass="textarea4" Width="500"
                        runat="server"></asp:TextBox></td>
              </tr>
              <tr id="rows_meta">
                 <td width="10%" align="right">meta描述：</td>
                 <td><asp:TextBox ID="BeWrite" TextMode="MultiLine" Height="50" CssClass="textarea4" Width="500"
                        runat="server"></asp:TextBox></td>
              </tr>
              <tr id="div_Templet"> 
                  <td width="10%" align="right">模板：</td>
                  <td>
                    <span id="labelTemplet" runat="server">
                     <asp:TextBox ID="FProjTemplets" runat="server" MaxLength="200" Width="40%" CssClass="input4"></asp:TextBox>
                     <a onclick="javascript:selectFile('FProjTemplets','模版选择','templet',500,500);document.form1.FProjTemplets.focus();">
                     <img src="/css/blue/imges/bgxiu_14.gif" alt="" border="0" style="cursor: pointer;"/></a>
                     </span>
                     <span id="dropTemplet" runat="server">
                        <asp:TextBox ID="dTemplet" runat="server" MaxLength="200" Width="40%" CssClass="input4"></asp:TextBox>
                         <a onclick="javascript:selectFile('dTemplet','模版选择','templet',500,500);document.form1.FProjTemplets.focus();">
                         <img src="/css/blue/imges/bgxiu_14.gif" alt="" border="0" style="cursor: pointer;"/></a>
                     </span>
                    <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_page_add_Templet',this)">
                        帮助</span>
                  </td>
              </tr>
              <tr>
                  <td width="10%" align="right">路径及文件名：</td>
                  <td>
                     <asp:TextBox ID="TPath" runat="server" MaxLength="200" Width="40%" CssClass="input4"></asp:TextBox>
                    <span class="helpstyle" style="cursor: help;" title="点击显示帮助" onclick="Help('H_page_add_path',this)">
                        帮助</span>
                  </td>
              </tr>
              <tr id="tr_autoPageSplit">
                  <td width="10%" align="right" >分页设置：</td>
                  <td>
                     &nbsp;&nbsp;&nbsp;插入分页符：<span style="cursor: pointer; color: red">分页标题</span>
                <asp:TextBox ID="PageTitle" runat="server" Text="" Width="200px"></asp:TextBox>
                <a href="javascript:void();" id="insertPage">插入</a> &nbsp;
                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="自动分页" />
                每页字数：<asp:TextBox ID="TxtPageCount" runat="server" Height="11px"
                    Width="28px" Text="3000"></asp:TextBox>
                  </td>
              </tr>
              <tr >
                  <td width="10%" align="right" valign="top" id="contentTag">内容：</td>
                  <td>
                        <div id="editorcontent" style="margin:10px; width:95%;">
                        <textarea name="Content" id="Content" runat="server" style="width:500px;height:250px;visibility:hidden;"></textarea>
                        </div>
                        <div id="textcontent" style="display:none">
                            <asp:TextBox ID="tContent" TextMode="MultiLine" Height="250" CssClass="textarea2" Width="500"
                            runat="server"></asp:TextBox>
                        </div>
                  </td>
              </tr>
           </table>
             <div class="nxb_submit" >
               <asp:HiddenField ID="gClassID" runat="server" />
                    <asp:HiddenField ID="acc" runat="server" />
                    <asp:Button ID="Button1" runat="server" CssClass="xsubmit3" Text="保存单页面" OnClick="Buttonsave_Click" />
           </div>
        </div>
      </div>
   </div>
</div>

        <table width="98%" align="center" border="0" cellpadding="3" cellspacing="0" class="table">
            <tr>
                <td style="text-align: center;" class="TR_BG_list">
                    
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg"
            style="height: 76px">
            <tr>
                <td align="center">
                    <div runat="server" id="SiteCopyRight" />
                </td>
            </tr>
        </table>

        </div>
        <div id="dialog-message" title="提示"></div>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    function getClassCName()
    {
        var strC=document.getElementById("TParentId").value;
		$.get('/configuration/system/getClassCname.aspx?no-cache=' + Math.random() + 'Type=Class&add=1&ClassID=' + strC, function (returnvalue) { 
            if (returnvalue.indexOf("??")>-1)
                               $("#ClassCnamev").innerHTML="error!";
						    else
                               $("#ClassCnamev").innerHTML=returnvalue;
        });
    } 

function zhitie(obj)
{
    if(obj.checked)
    {
        document.getElementById("contentTag").innerHTML = "网页源码：";
        document.getElementById("rows_key").style.display = "none";
        document.getElementById("rows_meta").style.display="none";
        document.getElementById("div_Templet").style.display="none";
        document.getElementById("editorcontent").style.display="none";
        document.getElementById("textcontent").style.display="block";
        document.getElementById("tr_autoPageSplit").style.display="none";
    }
    else
    {
        document.getElementById("contentTag").innerHTML = "内容：";
        document.getElementById("rows_key").style.display = "";
        document.getElementById("rows_meta").style.display="";
        document.getElementById("div_Templet").style.display="";
        document.getElementById("editorcontent").style.display="block";
        document.getElementById("textcontent").style.display="none";
        document.getElementById("tr_autoPageSplit").style.display="";
    }
}
  function UpFile(path)
    {
        var WWidth = (window.screen.width-500)/2;
        var Wheight = (window.screen.height-150)/2;
        window.open("../../configuration/system/Upload.aspx?Path="+path+"&upfiletype=files", '文件上传', 'height=200, width=500, top='+Wheight+', left='+WWidth+', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no'); 
    }
    
    function insertHTMLEdit(url)
    {
        var urls = url.replace('{@dirfile}','<% Response.Write(Foosun.Config.UIConfig.dirFile); %>')
        var oEditor = FCKeditorAPI.GetInstance("Content");
        if (oEditor.EditMode==FCK_EDITMODE_WYSIWYG)
        {
           oEditor.InsertHtml('<img src=\"'+urls+'\" border=\"0\" />');
        }
        else
        {
            return false;
        }
        return;
    }
</script>


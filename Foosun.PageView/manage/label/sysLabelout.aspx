<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysLabelout.aspx.cs" Inherits="Foosun.PageView.manage.label.sysLabelout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>导出标签</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<script src="/Scripts/SelectAction.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function Export() {
        var ifm = document.getElementById("label_export");
        var outtype = null;
        if (document.getElementById("classID").value == "alllabel") {
            var outSystem = document.getElementById("outSystem");
            if (outSystem.checked) { outtype = "trues"; }
            else { outtype = "falses"; }
        }
        var labelID = document.getElementById("classID").value;
        ifm.src = "syslabeloutLocal.aspx?classID=" + labelID + "&outtype=" + outtype + "";
        return false;
    }

    function AtServer() {
        if (document.getElementById("ATserverTF").checked) {
            document.getElementById("serverxmlPath").style.display = "";
            document.getElementById("localxmlPath").style.display = "none";
        }
        else {
            document.getElementById("serverxmlPath").style.display = "none";
            document.getElementById("localxmlPath").style.display = "";
        }

    }
    function getvalue() {
        var xmlpath = null;
        if (document.getElementById("ATserverTF").checked) {
            xmlpath = document.getElementById("sxmlPath").value;
        }
        else {
            xmlpath = document.getElementById("xmlPath").value;
        }
        document.getElementById("xmlPath_put").value = xmlpath;
    }
</script>
</head>

<body>
<div id="dialog-message" title="提示"></div>
<form id="Form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>导出/导入标签</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="syslabelList.aspx">标签管理</a> >><label id="outlabel_type" runat="server" />
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li><a href="syslabelList.aspx">标签管理 </a>┊</li>
            <li><a href="syslabelbak.aspx">备份库</a>┊</li>
            <li><a href="syslabelclassadd.aspx">新建分类</a>┊</li>
            <li><a href="syslableadd.aspx">新建标签</a>┊</li>
            <li><a href="?type=out">导出标签</a><a href="#" class="a1">(如何导出?) </a>┊</li>
            <li><a href="?type=in">导入标签</a><a href="#" class="a1">(如何导入?) </a></li>
         </ul>
      </div>
      <div class="lanlie_lie">
         <div class="newxiu_base">
           <table class="nxb_table" runat="server" id="out_table">
             <tr>
               <td><strong>导出标签</strong><a href="#" class="a7">帮助?</a></td>
             </tr>
             <tr>
               <td>
               <asp:Button ID="Button1" runat="server" Text="清空服务器上旧的导出的标签" class="xsubmit4" OnClientClick="{if(confirm('确认要清空以前导出的标签吗？')){return true;}return false;}" OnClick="label_clear_Click" />
              </td>
             </tr>
             <tr>
               <td><div id="classShow" runat="server" class="textdiv3" /></td>
             </tr>
             <tr>
               <td>
                  <div class="bqflie1 textdiv2">
                  <asp:CheckBox ID="outSystem" Text="导出系统标签(内置标签)" runat="server" />
                  <label for="outSystem">导出系统标签(内置标签)</label>
                  <input type="button" onclick="Export();" name="" value="导出到本地" class="xsubmit5" />
                  </div>
               </td>
             </tr>
             <tr>
               <td>
                  <div class="bqflie1">
                  <asp:Button ID="label_out" runat="server" Text="导出到服务器" class="xsubmit5" OnClientClick="{if(confirm('确定要导出标签到服务器吗？')){return true;}return false;}" OnClick="label_out_Click" />
                  <asp:HiddenField ID="classID" runat="server" />
                  <span>导出标签，请保证您的/xml/label目录为可写.</span>
                  </div>
               </td>
             </tr>
           </table>
            <iframe id="label_export" src="about:blank" border="0" height="0" width="0" style="visibility: hidden"></iframe>
           <table class="nxb_table" runat="server" id="in_table">
             <tr>
               <td><strong>导入标签</strong></td>
             </tr>
             <tr>
               <td>
                   <div class="bqflie1 textdiv2"> <asp:CheckBox ID="ATserverTF" Text="选择服务器上的标签"  onclick="AtServer(this);" runat="server" />选择服务器上的标签</div>
               </td>
             </tr>
             <tr>
               <td>
                 <div id="localxmlPath" class="bqflie textdiv3">
                 <asp:FileUpload ID="xmlPath" class="input8" runat="server" />
                 </div>
               </td>
             </tr>
             <tr>
               <td>
                  <div class="bqflie1" id="serverxmlPath" style="display:none;">
                   <asp:TextBox ID="sxmlPath" class="input8" runat="server"></asp:TextBox>
                   <a href="javascript:selectFile('sxmlPath','列表类','xml','500','400');"><img src="../imges/bgxiu_14.gif"  align="middle" alt="" /></a>
                  </div>
               </td>
             </tr>
             <tr>
               <td>
                <asp:HiddenField ID="xmlPath_put" runat="server" />  
                  <div class="bqflie1">                    
                    <asp:Button ID="Button2" runat="server" Text="导入标签" class="xsubmit5" OnClientClick="getvalue();" OnClick="label_in_Click" /> 
                    <a href="#" class="a8">如何选择文件</a>
                  </div>
               </td>
             </tr>
           </table>
          
         </div>
      </div>
   </div>
</div>
</div>
</form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" Inherits="Manage_System_Data_Backup" ResponseEncoding="utf-8" Codebehind="database.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
</head>
<body>
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3> 数据库维护</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a> >>数据库维护  
      </div>
   </div>
</div>
  <div class="mian_cont">
    <div class="nwelie">
    <div class="newxiu_lan">
    <ul class="tab_zzjs_" id="tab_zzjs_">
          <li id="tab_zzjs_1" class="hovertab_zzjs" onclick="ChangeDiv(1);">执行SQL语句 </li>
          <li id="tab_zzjs_2" class="nor_zzjs" onclick="ChangeDiv(2);" style="cursor:hand;<% if (Foosun.Config.UIConfig.WebDAL == "Foosun.AccessDAL"){ Response.Write("display:none;");}%>">数据库备份 </li>
          <li id="tab_zzjs_3" class="nor_zzjs" onclick="ChangeDiv(3);"> 数据库批量替换</li>
          <li id="tab_zzjs_4" class="nor_zzjs" onclick="ChangeDiv(4);" style="cursor:hand;<% if (Foosun.Config.UIConfig.WebDAL == "Foosun.SQLServerDAL"){ Response.Write("display:none;");}%>">数据库压缩 </li>
        </ul>
        <div class="newxiu_bot">
        <div class="dis_zzjs_net" id="tab_zzjs_01">
            <div id="DivStat" style=" margin:0 5px;" >
                <form runat="server" id="FormSql" >
                  <table align="center" width="98%" cellpadding="2" border="0" style="line-height:24px;">
                    <tr>
                      <td><font size="2">执行SQL语句</font></td>
                    </tr>
                    <tr>
                      <td>说明:一次只能执行一条Sql语句,如果你对SQL不熟悉,请尽量不要使用.否则一旦出错,将是致命的.<br>
                        建议使用查询语句.如:select count(id) From Table,尽量不要使用delete,update等命令.</td>
                    </tr>
                    <tr>
                      <td align="left"><textarea name="SqlText" cols="90" rows="4" class="textarea4"><%Response.Write(Request.Form["SqlText"]); %></textarea>
                        <span id="ErrorMsg" class="reshow"></span></td>
                    </tr>
                    <tr>
                      <td style="height: 1px"><div id="ResultShow" runat="server" style="width:98%; margin-top:10px;line-height:24px;"></div></td>
                    </tr>
                  </table>
                  <div class="nxb_submit" >
                        <input type="submit" name="Excute" value=" 执 行 " class="xsubmit1" onclick="javascript:return Is_Excute();" />
                        <input type="reset" name="UnDo" value=" 重 填 " class="xsubmit1" onclick="javascript:document.getElementById('ResultShow').innerHTML='';" />
                  </div>
                </form>
            </div>
        </div>
        <% if (Foosun.Config.UIConfig.WebDAL == "Foosun.SQLServerDAL")
         { 
      %>
      <div  class="undis_zzjs_net" id="tab_zzjs_02">
        <table align="center" width="98%" cellpadding="2" border="0" style=" margin:0 auto;">
          <tr>
            <td><font size="2">数据库备份</font></td>
          </tr>
          <tr>
            <td height="40">
                <select id="Type" class="select3">
                    <option selected="selected" value="1" class="form" style="width:100px;">主数据库</option>
                    <option value="2">帮助库</option>
                    <option value="3">采集库</option>
                </select>
                <input type="button" name="DbBak" value=" 开始备份 " class="xsubmit1" onclick="javascript:BakStart();"/>
              <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_Db_002',this)">帮助</span></td>
          </tr>
          <tr>
            <td>说明:请在备份完成后,及时删除备份文件,以防止别人恶意下载数据库文件.(<span style="color:Red;">只支持网站与数据库在同一服务器</span>)</td>
          </tr>
        </table>
      </div>
      <div id="DivRar" style="display:none"></div>
      <% }
         else
         {
      %>
      <div class="undis_zzjs_net" id="tab_zzjs_04">
        <table align="center" width="98%" cellpadding="2" border="0" style=" margin:0 auto;">
          <tr>
            <td><font size="2">数据库备份(只针对Access数据库)</font></td>
          </tr>
          <tr>
            <td height="40"><select id="Type" runat="server" visible="false">
                </select><input type="button" name="DbBak" value=" 开 始 备 份 " class="xsubmit" onclick="javascript:BakStart();"/>
              <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_Db_002',this)">帮助</span></td>
          </tr>
          <tr>
            <td>说明:请在备份完成后,及时删除备份文件,以防止别人恶意下载数据库文件.</td>
          </tr>
        </table>
        <table align="center" width="98%" cellpadding="2" border="0" style=" margin:0 auto;">
          <tr>
            <td><font size="2">数据库压缩(只针对Access数据库)</font></td>
          </tr>
          <tr>
            <td height="40"><input type="button" name="DbRar" value=" 开 始 压 缩 " class="xsubmit" onclick="javascript:RarStart();"/>
              <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onClick="Help('H_Db_003',this)">帮助</span></td>
          </tr>
          <tr>
            <td>说明:压缩前请备份您的数据库,以防止万一.</td>
          </tr>
        </table>
      </div>
      <% } %>
      <div  class="undis_zzjs_net" id="tab_zzjs_03">
        <table align="center" width="98%" cellpadding="2" border="0"  style=" margin:0 auto;">
          <tr>
            <td><font size="2">数据库批量替换</font></td>
          </tr>
          <tr>
            <td>
            <div >表名 
            <select id="TableName" name="TableName" class="select3" style="width:180px;" onchange="javascript:getFieldName(this.value);">
                <option value="0">请选择</option>
                <% getTableList(); %>
            </select>
            字段名
            <span id="spanFieldName"><select id="fieldname" name="fieldname" class="select3" style="width:180px;"></select></span>
            原始字符 
            <input id="OldTxt" type="text" class="input8" style="width:110px;" value="原始字符" onfocus="javascript:this.value='';"/>    
            新字符        
            <input id="NewTxt" type="text" class="input8" style="width:110px;" value="新字符" onfocus="javascript:this.value='';"/></div> <br />  
            <div align="center">
            <input type="button" name="DbReplace" value=" 开始替换 " class="xsubmit1" onclick="javascript:ReplaceStart();"/></div> 
              </td>
          </tr>
          <tr>
            <td>说明:替换数据库里面的字符.执行操作前请备份好数据库,慎重操作.</td>
          </tr>
        </table>
      </div>
</div>
</div>
</div>
</div>
<br />
</div>
</body>
<script language="javascript" type="text/javascript">
    function ChangeDiv(ID) {
        document.getElementById("tab_zzjs_1").className = 'nor_zzjs';
        document.getElementById("tab_zzjs_2").className = 'nor_zzjs';
        document.getElementById("tab_zzjs_3").className = 'nor_zzjs';
        document.getElementById("tab_zzjs_4").className = 'nor_zzjs';
        document.getElementById("tab_zzjs_" + "" + ID + "").className = 'hovertab_zzjs';

        document.getElementById("tab_zzjs_01").className = "undis_zzjs_net";
        if (document.getElementById("tab_zzjs_02") != null) {
            document.getElementById("tab_zzjs_02").className = "undis_zzjs_net";
        }
        document.getElementById("tab_zzjs_03").className = "undis_zzjs_net";
        if (document.getElementById("tab_zzjs_04") != null) {
            document.getElementById("tab_zzjs_04").className = "undis_zzjs_net";
        }
        document.getElementById("tab_zzjs_0" + "" + ID + "").className = "dis_zzjs_net";
    }
function Is_Excute()
{
    if(document.FormSql.SqlText.value=="")
    {
        document.getElementById("ErrorMsg").innerHTML='请输入要执行的SQL语句';
        return false;
    }
    if(confirm('确定要执行SQL语句吗?\n如果操作不当将会造成意想不到的损失!'))
    {
        document.FormSql.action='?Action=Sql';  
        return true;
    }
    else
    {
        return false;
    }
}
function BakStart()
{
   // alert("bakstart");
    self.location.href='?Action=Bak&Type=1';
}
function RarStart()
{
    self.location.href='?Action=Rar';
}
function ReplaceStart()
{
    if(document.getElementById("TableName").value=="0")
    {
        alert('请选择表');
        return false;
    }
    self.location.href='?Action=Replace&TableName='+document.getElementById("TableName").value+'&FieldName='+document.getElementById("fieldname").value+'&NewTxt='+document.getElementById("NewTxt").value+'&OldTxt='+document.getElementById("OldTxt").value;
}
</script>
<%--<%  Show(); %>--%>
</html>
<script language="javascript" type="text/javascript">
function getFieldName(value)
{
    if(value=="0")
    {
        document.getElementById("spanFieldName").innerHTML="<select id=\"fieldname\" name=\"fieldname\" class=\"form\" style=\"width:180px;\"></select>";    
        return false;
    }
    $.get('database.aspx?no-cache=' + Math.random() + '&Action=getFieldName&TableName='+value, function(transport){
        var returnvalue=transport; 
                if (returnvalue.indexOf("??")>-1) 
                    alert('未知错误!请联系管理员'); 
                else 
                    document.getElementById("spanFieldName").innerHTML=returnvalue; 
    });
}
</script>
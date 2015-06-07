<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnnewsEdit.aspx.cs" Inherits="Foosun.PageView.manage.news.UnnewsEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>不规则新闻</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
<script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
<link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
UnNewArray = <%= UnNewsJsArray %>;
 Array.prototype.remove = function (start, deleteCount) {
        if (isNaN(start) || start > this.length || deleteCount > (this.length - start)) { return false; }
        this.splice(start, deleteCount);
    }
function CheckNum(obj){
    if (isNaN(obj.value) || obj.value<=0){
	    alert("您输入的不是正确的行数,\n请输入一个正整数.");
	    obj.value="";
	    obj.focus();
	    }
}
function DisplayUnNews()
{
    var StrUnNewsList="";
    var ListLen=0;
    var Str_tem="";
    var TLPic="";
    var PicInfo="";
    try{
        ListLen=UnNewArray.length;
    }
    catch(e)
    {
        ListLen=0;
    }
    var StrUnNewsListSub="";
    for (var i=0;i<ListLen;i++){
        StrUnNewsList+="<div id=\"Arr"+i+"\" class=\"textdiv3\"><input name=\"NewsID\" type=\"hidden\" id=\"NewsID_"+i+"\" value=\""+UnNewArray[i][0]+"\" /><a href=\"原新闻标题\" title=\"原新闻标题:"+UnNewArray[i][1]+"\" onclick=\"return false;\">标题</a>：<input title=\"原新闻标题:"+UnNewArray[i][1]+"\" name=\"NewsTitle"+UnNewArray[i][0]+"\" type=\"text\" id=\"NewsTitle_"+i+"\" value=\""+UnNewArray[i][2]+"\" size=\"60\" onkeyup=\"UnNewModify()\"  style=\"height:18px;\" />&nbsp;CSS&nbsp;<input name=\"SubCSS"+UnNewArray[i][0]+"\" type=\"text\" id=\"SubCSS_"+i+"\" value=\""+UnNewArray[i][5]+"\"  class=\"inputa1\" />放在第<input class=\"inputa2\" name=\"Row"+UnNewArray[i][0]+"\" type=\"text\" id=\"Row_"+i+"\" value=\""+UnNewArray[i][3]+"\" onkeyup=\"UnNewModify(this,'')\" onbeforepaste=\"clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''));\"  />&nbsp;行&nbsp;<a class=\"xsubmits\" href=\"javascript:UnNewDel("+i+");\">移除</a><input type=\"hidden\"  name=\"NewsTable"+UnNewArray[i][0]+"\" id=\"Table"+i+"\" value=\""+UnNewArray[i][4]+"\" /></div>";
    }
    document.getElementById("UnNewsList").innerHTML=StrUnNewsList;
}

    function UnNewModify() {
        for (var i = 0; i < UnNewArray.length; i++) {
            UnNewArray[i][2] = $("#NewsTitle_" + i).val();
            $("#Row_" + i).val($("#Row_" + i).val().replace(/[^\d]/g, ''));
            UnNewArray[i][3] = parseInt($("#Row_" + i).val());
        }
    }
  function UnNewDel(Row) {
        if (confirm("确定移除吗？")) {
                UnNewArray.remove(Row, 1);
            DisplayUnNews();
            window.frames["DisNews"].CheckUnNews();
        }
    }
function show(){
    var content="<table style=\"line-height:24px;\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
    content+="<tr><td>"+$('#unName').val()+"</td></tr>";
    for (var i = 0; i < UnNewArray.length; i++) {
    content+="<tr><td>"+UnNewArray[i][2]+"</td></tr>";
}
    content+="</table>";
   $('#dialog-message').html(content);
   DisNews.$("select").hide();
   $("#dialog-message").dialog({
                        modal: true,
						width:350,
                        close: function () {
                        DisNews.$("select").show();
                    }
                    });
}
function UnNewcheck()
 {
    if(document.getElementById("unName").value=="")
    {
	    alert("\n 请填写不规则新闻标题!");
	    document.getElementById("unName").focus();	   
        return;
    }
    if ($("#UnNewsList").html()=="") {
    alert("\n 没有选择不规则新闻!");
    return;
}
    var ListLen=UnNewArray.length;
    var Maxrow=0;
    var ErrStr="";
    for (var i=0;i<ListLen;i++){
	    if (UnNewArray[i][3]==0){
		    ErrStr=" -第 "+(i+1)+"条 存放行数不能为 0";
	    }
	    if (isNaN(UnNewArray[i][3])){
		    ErrStr=" -第 "+(i+1)+"条 存放行数不能为空";
	    }
	    if (UnNewArray[i][2]==""){
		    ErrStr=" -第 "+(i+1)+"条 不规则标题不能为空";
	    }
	    if (UnNewArray[i][3]>Maxrow){
		    Maxrow=UnNewArray[i][3];
	    }
    }
    var FindFlag=false;
    for (i=1;i<=Maxrow;i++){
	    FindFlag=false;
	    for (var j=0;j<ListLen;j++){
		    if (UnNewArray[j][3]==i){
			    FindFlag=true;
			    break;
		    }
	    }
	    if (!FindFlag){
		    ErrStr+="\n -第 "+i+" 行中没有新闻";
	    }
    }   
    if (ErrStr){
	    alert("发生以下错误：\n"+ErrStr);
        return;
    }else{
	      form1.submit();
    }

}
window.onload=DisplayUnNews;
</script>
</head>

<body>
<div id="dialog-message" title="不规则新闻"></div>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>不规则新闻管理 </h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="Unnews.aspx">不规则新闻管理</a> >>不规则新闻添加/编辑
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="auto">
      <table class="auto_table" align="center" cellspacing="1">
         <tr>
           <td colspan="2">
             <div class="textdiv2">
               <a href="javascript:UnNewcheck()" class="xsubmits">保存</a>
               <a href="javascript:show()" class="xsubmits">预览</a> 
               <input name="UnID" type="hidden" id="UnID" value="<%=unNewsid %>" />
               </div>
            </td>
         </tr>
         <tr>
            <td>
               <div class="textdiv2">
                不规则新闻的标题：
                <asp:TextBox class="inputa" ID="unName" runat="server"></asp:TextBox>
                CSS<asp:TextBox ID="titleCSS" class="inputa1" runat="server"></asp:TextBox>
                </div>
            </td>
         </tr>
         <tr>
            <td id="UnNewsList">
            </td>
         </tr>
      </table>
   </div>
   <iframe id="DisNews" name="DisNews" src="unnews_iframe.aspx" width="100%" frameborder="0" height="600"/>
</div>
</div>
</form>
</body>
</html>

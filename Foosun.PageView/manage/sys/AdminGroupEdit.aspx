<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGroupEdit.aspx.cs" Inherits="Foosun.PageView.manage.sys.AdminGroupEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
    <link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
</head>
<body>
<form id="F_AdminGroup" action="" runat="server" method="post">
<div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>修改管理员组</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="AdminiGroupList.aspx">管理员组管理</a>>>修改管理员组
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
  <div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie_lie">
         <div class="newxiu_base">
  <table class="nxb_table">
    <tr class="TR_BG_list">
      <td align="right" width="20%">管理员组名称：</td>
      <td align="left"><span id="Group_Name" runat="server"  style="margin-left:10px;"></span>
        <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_adminGroupEdit_001',this)"> 帮助</span><span id="errorshow" class="reshow"></span> </td>
    </tr>
    <tr>
      <td align="right" width="20%">可管理的栏目：</td>
      <td width="80%">
         <div class="admgrop_li">
            <div class="admgrop_li_taer">
               <asp:ListBox ID="NewsClassList" SelectionMode="Multiple" runat="server" Height="120px" Width="200px"></asp:ListBox>
            </div>
            <div class="admgrop_li_sub">
               <ul>
                  <li><input id="B_Class1" class="xsubmit1" name="button" onclick="javascript:Selectone(document.F_AdminGroup.NewsClassList,document.F_AdminGroup.NewsClassList2,document.getElementById('Span1'),document.F_AdminGroup.News_List);"
              type="button" value=" 选  中 " /></li>
                  <li><input id="B_Class2" class="xsubmit1" name="button2" onclick="javascript:SelectAllClass(document.F_AdminGroup.NewsClassList,document.F_AdminGroup.NewsClassList2,document.F_AdminGroup.News_List);"
              type="button" value="全部选中" /></li>
                  <li><input id="Button10" class="xsubmit1" name="button2" onclick="javascript:unSelectone(document.F_AdminGroup.NewsClassList2,document.getElementById('Span1'),document.F_AdminGroup.News_List);"
              type="button" value=" 取  消 " /></li>
                  <li><input id="Button6" class="xsubmit1" name="button2" onclick="javascript:UnSelectAllClass(document.F_AdminGroup.NewsClassList2,document.F_AdminGroup.News_List);"
              type="button" value="全部取消" /></li>
              </ul>
            </div>
            <div  class="admgrop_li_taer">
               <asp:ListBox ID="NewsClassList2" SelectionMode="Multiple" runat="server" Height="120px" Width="200px"></asp:ListBox>
            </div>
            <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_adminGroupAdd_003',this)">帮助</span>
            <div id="Span1" class="reshow"></div>
         </div>
      </td>
    </tr>
    <tr style="display:none">
      <td align="right" width="20%">可管理的频道：</td>
      <td width="80%">
         <div class="admgrop_li">
            <div class="admgrop_li_taer">
               <asp:ListBox ID="Site1" SelectionMode="Multiple" runat="server" Height="120px" Width="200px"></asp:ListBox>
            </div>
            <div class="admgrop_li_sub">
               <ul>
                  <li><input id="Button2" class="xsubmit1" name="button2" onclick="javascript:Selectone(document.F_AdminGroup.Site1,document.F_AdminGroup.Site2,document.getElementById('Span2'),document.F_AdminGroup.Site_List);"
              type="button" value=" 选  中 " /></li>
                  <li><input id="Button4" class="xsubmit1" name="button2" onclick="javascript:SelectAllClass(document.F_AdminGroup.Site1,document.F_AdminGroup.Site2,document.F_AdminGroup.Site_List);"
              type="button" value="全部选中" /></li>
                  <li><input id="Button9" class="xsubmit1" name="button2" onclick="javascript:unSelectone(document.F_AdminGroup.Site2,document.getElementById('Span2'),document.F_AdminGroup.Site_List);"
              type="button" value=" 取  消 " /></li>
                  <li><input id="Button8" class="xsubmit1" name="button2" onclick="javascript:UnSelectAllClass(document.F_AdminGroup.Site2,document.F_AdminGroup.Site_List);"
              type="button" value="全部取消" /></li>
              </ul>
            </div>
            <div  class="admgrop_li_taer">
               <asp:ListBox ID="Site2"  SelectionMode="Multiple" runat="server" Height="120px" Width="200px"></asp:ListBox>
            </div>
            <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_adminGroupAdd_002',this)">帮助</span>
            <div id="Span2" class="reshow"></div>
         </div>
      </td>
    </tr>
    <tr>
      <td align="right" width="20%">可管理的专题：</td>
      <td width="80%">
         <div class="admgrop_li">
            <div class="admgrop_li_taer">
               <asp:ListBox ID="Special1" SelectionMode="Multiple" runat="server" Height="120px" Width="200px"></asp:ListBox>
            </div>
            <div class="admgrop_li_sub">
               <ul>

                  <li><input id="Button3" class="xsubmit1" name="button2" onclick="javascript:Selectone(document.F_AdminGroup.Special1,document.F_AdminGroup.Special2,document.getElementById('Span3'),document.F_AdminGroup.Sp_List);"
              type="button" value=" 选  中 " /></li>
                  <li><input id="Button5" class="xsubmit1" name="button2" onclick="javascript:SelectAllClass(document.F_AdminGroup.Special1,document.F_AdminGroup.Special2,document.F_AdminGroup.Sp_List);"
              type="button" value="全部选中" /></li>
                  <li><input id="Button11" class="xsubmit1" name="button2" onclick="javascript:unSelectone(document.F_AdminGroup.Special2,document.getElementById('Span3'),document.F_AdminGroup.Sp_List);"
              type="button" value=" 取  消 " /></li>
                  <li><input id="Button7" class="xsubmit1" name="button2" onclick="javascript:UnSelectAllClass(document.F_AdminGroup.Special2,document.F_AdminGroup.Sp_List);"
              type="button" value="全部取消" /></li>
              </ul>
            </div>
            <div  class="admgrop_li_taer">
               <asp:ListBox ID="Special2" SelectionMode="Multiple" runat="server" Height="120px" Width="200px"></asp:ListBox>
            </div>
            <span class="helpstyle" style="cursor:help;" title="点击显示帮助" onclick="Help('H_adminGroupAdd_004',this)">帮助</span>
            <div id="Span3" class="reshow"></div>
         </div>
      </td>
    </tr>
  </table>
  <div class="nxb_submit">
    <input type="button" name="TJ" value="确 定" class="xsubmit1" onclick="javascript:Submit(this.form);" id="button1" />
    <input type="reset" name="UnDo" value="重 填" class="xsubmit1" onclick="javascript:listClear();" />
    <span id="Hidden" runat="server"></span>
  </div>
  </div>
  </div>
  </div>
  </div>
</div>
</form>
</body>
<script language="javascript" type="text/javascript">
    //-----------------------选择所有--------------------------------
    function SelectAllClass(obj, obj1, hiddenobj) {
        clearall(obj1);         //清空右边的列表框
        //---------------------正则-----------------------------
        var re = /┝/g;
        var re1 = /┉/g;
        //---------------------循环获取左边列表框值-------------
        hiddenobj.value = "";
        for (var i = 0; i < obj.length; i++) {
            var text = obj.options[i].text;
            //----------------正则替换-------------------------
            text = text.replace(re, "");
            text = text.replace(re1, "");
            hiddenobj.value = hiddenobj.value + obj.options[i].value + ","; //给隐藏域赋值
            obj1.options[i] = new Option(text, obj.options[i].value); //-添加选项到右边列表框
        }
        //---------------------循环获取左边列表框值结束---------
    }
    //---------------------选择所有结束-----------------------------
    //---------------------取消选择所有-----------------------------
    function UnSelectAllClass(obj, hiddenobj) {
        clearall(obj);
        hiddenobj.value = "";                   //给隐藏域赋值
    }
    //---------------------取消选择所有结束-------------------------
    //---------------------选择一个选项-----------------------------
    function Selectone(obj, obj1, span, hiddenobj) {
        var s = 0;
        //--------------------正则--------------------------------
        var re = /┝/g;
        var re1 = /┉/g;
        /*
        //--------------------判断是否选中选项--------------------
        for(var i=0;i<obj.length;i++){ 
        if (obj.options[i].selected){s+=1;} 
        }      
        if (s==0){   
        span.innerHTML="  (*)请选择左边列表框的项目再点选中";
        return;}  
        span.innerHTML="";
        var text = obj.options[obj.selectedIndex].text;
        text = text.replace(re,"");
        text = text.replace(re1,"");
        //--------------------判断右边列表框中否包含此项----------
        for (var i=0;i<obj1.length;i++)
        {
        if(obj1.options[i].text==text)
        {
        span.innerHTML="  (*)右边列表框的项目中已包含此项";
        return;
        }
        }
        //-------------------添加到右边选项框----------------------
        hiddenobj.value = hiddenobj.value +  obj.options[i].value + ",";//给隐藏域赋值
        obj1.options[obj1.length] = new Option(text,obj.options[obj.selectedIndex].value);
        //-------------------判断是否到最后一项,如果不是则焦点移到下一项
        if(obj.selectedIndex<obj.length)
        {
        obj.selectedIndex = obj.selectedIndex + 1; 
        }
        */
        /*
        以下js由arjun更改2008-3-6
        */
        for (var i = 0; i < obj.length; i++) {
            if (obj.options[i].selected) {
                var text = obj.options[i].text;
                text = text.replace(re, "");
                text = text.replace(re1, "");
                var wr = true;
                for (var j = 0; j < obj1.length; j++) {
                    if (obj.id == "NewsClassList")//如果是栏目，则判断栏目ID是否重复
                    {
                        if (obj1.options[j].value == obj.options[i].value) {
                            span.innerHTML = "  (*)右边列表框的项目中已包含[<font color=red>" + text + "</font>]项";
                            wr = false;
                            break;
                        }
                    }
                    else if (obj1.options[j].text == text) {
                        span.innerHTML = "  (*)右边列表框的项目中已包含[<font color=red>" + text + "</font>]项";
                        wr = false;
                        break;
                    }
                }
                if (wr) {
                    hiddenobj.value = hiddenobj.value + obj.options[i].value + ","; //给隐藏域赋值
                    obj1.options[obj1.length] = new Option(text, obj.options[i].value);
                }

            }
        }
    }
    //---------------------选择一个选项结束-------------------------
    //---------------------取消一个---------------------------------
    //change by arjun
    function unSelectone(obj, span, hiddenobj) {
        /*
        var s=0;
        //-----------------判断是否选中------------------------
        for(var i=0;i<obj.length;i++){
        if (obj.options[i].selected){s+=1;}}   
        if (s==0){
        span.innerHTML="  (*)请选择右边列表框的项目再点取消";
        return;}
        //-----------------移除选中的选项----------------------
        hiddenobj.value = hiddenobj.value.replace(obj.options[obj.selectedIndex].value + ",",""); //给隐藏域赋值
        obj.options[obj.selectedIndex]=null;
        //-----------------判断是否还有选项,如有则移到最后-----
        if(obj.length > 0)
        {
        obj.options[obj.length-1].selected=true;
        }
        */
        var ii = [];
        for (var i = 0; i < obj.length; i++) {
            if (obj.options[i].selected) {
                ii[ii.length] = i;
                hiddenobj.value = hiddenobj.value.replace(obj.options[obj.selectedIndex].value + ",", "");
            }
        }
        for (var i = ii.length - 1; i >= 0; i--) {
            obj.options[ii[i]] = null;
        }
    }
    //---------------------取消一个结束-----------------------------
    //---------------------移除右边列表框所有选项-------------------
    // change by arjun
    function clearall(obj) {
        var testnum = obj.length;
        for (var j = testnum - 1; j >= 0; j--) {
            obj.options[j] = null;
        }
    }
    //--------------------移除右边列表框所有选项结束----------------
    //--------------------提交表单信息------------------------------
    function Submit(formobj) {
        if (formobj.GroupName.value == "") {
            document.getElementById("errorshow").innerHTML = " (*)管理员组名称不能为空";
        }
        else {
            //var listStr=formobj.News_List.value;
            //var siteListStr=formobj.Site_List.value;
            //var spListStr=formobj.Sp_List.value;
            var listStr = getSelectStr(document.getElementById("NewsClassList2"), false);
            var siteListStr = getSelectStr(document.getElementById("Site2"), false);
            var spListStr = getSelectStr(document.getElementById("Special2"), false);
            var ID = '<% Response.Write(Request.QueryString["ID"]); %>';
            //alert(listStr);
            //alert(siteListStr);
            //alert(spListStr);


            formobj.News_List.value = listStr;
            formobj.Site_List.value = siteListStr;
            formobj.Sp_List.value = spListStr;
            //alert(formobj.News_List.value);
            //alert(formobj.Site_List.value);
            //alert(formobj.Sp_List.value);
            formobj.action = "?ID=" + escape(ID) + "&Type=Edit"
            //formobj.action = "?ID="+escape(ID)+"&Type=Edit&News_List="+escape(listStr)+"&Site_List="+escape(siteListStr)+"&Sp_List="+escape(spListStr);
            formobj.submit();
        }
    }

    //去除最后一个豆号 code by arjun
    function qudouhao(str) {
        var s = str;
        if (s == null) return "";
        if (s == "") return s;
        if (s.substr(s.length - 1) == ",") {
            s = s.substring(0, s.length - 1)
        }
        return s;
    }

    //取得选择框的值 code by arjun
    //sel为true时,返回选择的
    //sel为false时,返回所有
    function getSelectStr(obj, sel) {
        var returnArr = [];
        var str = "";
        for (var i = 0; i < obj.length; i++) {
            if (sel) {
                if (obj.options[i].selected) {
                    returnArr[returnArr.length] = obj.options[i].value;
                }
            }
            else {
                returnArr[returnArr.length] = obj.options[i].value;
            }
        }
        str = returnArr.join(",");
        if (str == "" || str == null) {
            str = "null";
        }
        return str;
    }

    //--------------------提交表单信息结束-------------------------
    //--------------------重置右边列表框---------------------------
    function listClear() {
        UnSelectAllClass(document.F_AdminGroup.NewsClassList2, document.F_AdminGroup.News_List);
        UnSelectAllClass(document.F_AdminGroup.Site2, document.F_AdminGroup.Site_List);
        UnSelectAllClass(document.F_AdminGroup.Special2, document.F_AdminGroup.Sp_List);
    }
    //--------------------重置右边列表框结束-----------------------
</script>
</html>


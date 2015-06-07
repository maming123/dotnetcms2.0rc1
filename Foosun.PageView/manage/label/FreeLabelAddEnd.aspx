<%@ Page Language="C#" AutoEventWireup="true" Inherits="FreeLabelAddEnd" ValidateRequest="false"
    CodeBehind="FreeLabelAddEnd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript">
        function comeform(loca_name, loca_itemname, loca_fieldname) {
            this.loca_name = loca_name;
            this.loca_itemname = loca_itemname;
            this.loca_fieldname = loca_fieldname;
        }
    </script>
    <script language="javascript" type="text/javascript">
        var start = 0;

        var end = 0;
        function savePos(textBox) {

            //如果是Firefox(1.5)的话，方法很简单

            if (typeof (textBox.selectionStart) == "number") {

                start = textBox.selectionStart;

                end = textBox.selectionEnd;
            }
            //下面是IE(6.0)的方法，麻烦得很，还要计算上'\n'

            else if (document.selection) {

                var range = document.selection.createRange();

                if (range.parentElement().id == textBox.id) {

                    // create a selection of the whole textarea

                    var range_all = document.body.createTextRange();

                    range_all.moveToElementText(textBox);

                    //两个range，一个是已经选择的text(range)，一个是整个textarea(range_all)

                    //range_all.compareEndPoints()比较两个端点，如果range_all比range更往左(further to the left)，则 //返回小于0的值，则range_all往右移一点，直到两个range的start相同。

                    // calculate selection start point by moving beginning of range_all to beginning of range

                    for (start = 0; range_all.compareEndPoints("StartToStart", range) < 0; start++)

                        range_all.moveStart('character', 1);

                    // get number of line breaks from textarea start to selection start and add them to start

                    // 计算一下\n

                    for (var i = 0; i <= start; i++) {

                        if (textBox.value.charAt(i) == '\n')

                            start++;

                    }
                    // create a selection of the whole textarea

                    var range_all = document.body.createTextRange();

                    range_all.moveToElementText(textBox);

                    // calculate selection end point by moving beginning of range_all to end of range

                    for (end = 0; range_all.compareEndPoints('StartToEnd', range) < 0; end++)

                        range_all.moveStart('character', 1);

                    // get number of line breaks from textarea start to selection end and add them to end

                    for (var i = 0; i <= end; i++) {

                        if (textBox.value.charAt(i) == '\n')

                            end++;

                    }

                }

            }
        }

        function setCaret() {
            if (this.createTextRange) {
                this.caretPos = document.selection.createRange().duplicate();
            }
        }
        var contenttb = jQuery("#EdtContent");
        contenttb.onclick = setCaret;
        contenttb.onselect = setCaret;
        contenttb.onkeyup = setCaret;

        function AddTag(textFeildValue) {
            var textBox = document.getElementById("EdtContent"); //根据ID获得对象
            var pre = textBox.value.substr(0, start);

            var post = textBox.value.substr(end);

            textBox.value = pre + textFeildValue + post;
        }
        function AddDate() {
            var str =$.trim(document.getElementById('TxtDateStyle').value);
            if (str != '') {
                str = '[$' + str + '$]'
                AddTag(str);
            }
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <div  class="mian_body">
      <div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>自由标签SQL语句测试</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="FreeLabelList.aspx">自由标签</a>>><asp:Label ID="LblCaption" runat="server" Text="添加自由标签"></asp:Label>
      </div>
   </div>
</div>
      <div class="lanlie">
         <ul>
            <li><a class="topnavichar" href="javascript:history.back();" id="PreSteps" runat="server">
                        上一步</a>┊</li>
            <li><asp:LinkButton CssClass="topnavichar" ID="LnkBtnSave" runat="server" OnClick="LnkBtnSave_Click">保存</asp:LinkButton>┊</li>
            <li><asp:LinkButton CssClass="topnavichar" ID="reviewBtn" runat="server" OnClick="reviewBtn_Click">预览</asp:LinkButton></li>
         </ul>
      </div>
        <div runat="server" id="review">
        </div>
       <div class="lanlie_lie">
         <div class="newxiu_base">
        <table width="98%" cellpadding="5" cellspacing="1" align="center" class="nxb_table">
            <tr>
                <td align="right" width="15%">
                    标签名称：
                </td>
                <td width="85%">
                    <asp:TextBox runat="server" Width="200" ID="TxtLabelName" CssClass="input8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    标签说明：
                </td>
                <td>
                    <asp:TextBox runat="server" Width="200" ID="TxtDescrpt" CssClass="select5" TextMode="MultiLine"
                        MaxLength="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    自定义：
                </td>
                <td>
                    <input type="button" value="循环内容" onclick="javascript:AddTag('{# 您要加的内容 #}')" class="xsubmit1" />
                    <input type="button" value="不循环内容" onclick="javascript:AddTag('{*记录序号 您要加的内容 *}')" class="xsubmit3" />
                    <input type="button" value="函数" onclick="javascript:AddTag('(#函数内容#)')" class="xsubmit1" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    可用字段：
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="DdlField1" onchange="AddTag(this.options[this.selectedIndex].value)" CssClass="select5">
                        <asp:ListItem Value="">请选择字段</asp:ListItem>
                    </asp:DropDownList>
                    ┆
                    <asp:DropDownList runat="server" ID="DdlField2" onchange="AddTag(this.options[this.selectedIndex].value)" CssClass="select5">
                        <asp:ListItem Value="">请选择字段</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">新闻编号和新闻栏目编号会自动替换为连接</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    日期样式：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TxtDateStyle" Text="YY02年MM月DD日" CssClass="select5"
                        MaxLength="200"></asp:TextBox>
                    <input type="button" value=" 插入 " onclick="AddDate()" class="xsubmit1" />
                    <span style="color: Red">需要选择时间字段，格式见说明 2</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    标签内容：
                </td>
                <td>
                    <span style="color: Red">由HTML代码加所选择字段、自定义函数组成，用来定义查询记录的显示样式</span>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <textarea rows="15" cols="100" style="width: 99%;" onkeydown="savePos(this)" onkeyup="savePos(this)"
                        onmousedown="savePos(this)" onmouseup="savePos(this)" onfocus="savePos(this)"
                        name="EdtContent" runat="server" id="EdtContent"></textarea>
                </td>
            </tr>
        </table>
          </div>
        </div>
        <div style="color: Red">
            <p>说  明：</p>
            <p>
                1.预定义字段需要选择各自对应编号。如新闻浏览路径需要选择新闻编号，栏目浏览路径需要选择栏目编号(注意：是新闻编号，不是编号)。</p>
            <p>
                2.日期格式:YY02代表2位的年份(如13表示2013年),YY04表示4位数的年份(2013)，MM代表月，DD代表日，HH代表小时，MI代表分，SS代表秒。</p>
            <p>
                3.自定义函数：循环内容{#...#}、不循环内容{*n...*}(n>0)代表记录序号、函数(#...#)；如(#Left([*NewsTitle*],20)#)
            </p>
        </div>
        <br />
        <table width="100%" border="0" cellpadding="8" cellspacing="0" class="copyright_bg"
            style="height: 76px">
            <tr>
                <td align="center">
                    <%Response.Write(CopyRight);%>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HidID" runat="server" />
    <asp:HiddenField ID="HidName" runat="server" />
    <asp:HiddenField ID="HidSQL" runat="server" />
    </form>
</body>
</html>

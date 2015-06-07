<%@ Page Language="C#" AutoEventWireup="true" Inherits="Collect_Add" Codebehind="Collect_Add.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>FoosunCMS For .NET v1.0.0</title>
   <link rel="stylesheet" type="text/css" href="/CSS/base.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    <!--
    function ChangeUrl()
    {
        var obj = document.getElementById("A_Preview");
        obj.href = $(obj).parent().children().eq(0).val();
    }
    function ChooseEncode(obj)
    {
        obj.parentNode.firstChild.value = obj.innerText;
    }
    //-->
    </script>

</head>
<body>
    <form id="Form2" runat="server">
    <div id="dialog-message" title="提示"></div>
    <div class="mian_body">
<div class="mian_wei">
    <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>采集系统</h3></div>
      <div class="mian_wei_right">
          导航：<a href="#">首页</a>>><a href="Collect_List.aspx">采集系统</a> >><asp:Label ID="LblTitle" runat="server"></asp:Label>
      </div>
   </div>
   <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="jslie_lan">
        <span>功能：</span><a href="Collect_List.aspx">站点列表</a>┋<a
                        class="topnavichar" href="Collect_Add.aspx?Type=Site">新建站点</a>┋<a class="topnavichar"
                            href="Collect_RuleList.aspx">关键字过滤</a>┋<a class="topnavichar" href="Collect_News.aspx">新闻处理</a>
      </div>
      <div class="lanlie_lie">
         <asp:Panel runat="server" ID="PnlFolder" Width="100%">
         <div class="newxiu_base">
           <table class="nxb_table">
             <tr>
               <td width="20%" align="right">栏目名称：</td>
                    <td>
                       <asp:TextBox runat="server" ID="TxtFolderName" Width="300px" MaxLength="40" CssClass="input8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请填写栏目名称!"
                                ControlToValidate="TxtFolderName" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
             </tr>
             <tr>
                <td width="20%" align="right">栏目说明：</td>
                <td>
                    <div class="textdiv1">
                       <asp:TextBox runat="server" ID="TxtFolderMemo" Width="400px" Height="131px" TextMode="MultiLine"
                                CssClass="textarea1"></asp:TextBox>
                    </div>
                </td>
             </tr>
           </table>
           <div class="nxb_submit" >
           <asp:HiddenField ID="HddFolderID" runat="server" />
               <asp:Button ID="BtnFolderOK" Text=" 保 存 " runat="server" CssClass="xsubmit1" OnClick="BtnFolderOK_Click" />
               <input type="submit" name="bc" value="重置" class="xsubmit1"/>
           </div>
         </div>
         </asp:Panel>

         <asp:Panel runat="server" ID="PnlSite" Width="100%">
            <div class="newxiu_base">
                <table class="nxb_table">
                    <tr>
                        <td width="20%" align="right">
                            采集站点名称：
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtSiteName" Width="300" MaxLength="40" CssClass="input8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请填写采集站点名称!"
                                ControlToValidate="TxtSiteName" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            采集站点分类：
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlSiteFolder" runat="server" CssClass="input8">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            采集对象页：
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtSiteURL" Width="300px" onchange="ChangeUrl()"
                                MaxLength="250" CssClass="input8">http://</asp:TextBox>
                            <a id="A_Preview" href="#" target="_blank" class="list_link">预览</a>

                            <script language="javascript" type="text/javascript">
                                ChangeUrl();
                            </script>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtSiteURL"
                                Display="Dynamic" ErrorMessage="请填写采集对象页!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtSiteURL"
                                Display="Dynamic" ErrorMessage="请填正确的URL格式，以http://或https://开头" SetFocusOnError="True"
                                ValidationExpression="^[hH][tT]{2}[pP][sS]?://.+"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            采集页编码方式：
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtEncode" Width="200px" MaxLength="50" Text="GB2312"
                                CssClass="input8" />
                            例如: <span style="cursor: hand" onclick="ChooseEncode(this)">GB2312</span>、<span style="cursor: hand"
                                onclick="ChooseEncode(this)">UTF-8</span>、<span style="cursor: hand" onclick="ChooseEncode(this)">BIG5</span>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            入库后所属新闻栏目：
                        </td>
                        <td>
                            <asp:TextBox ID="TxtClassName" Width="200px" runat="server" CssClass="input8"></asp:TextBox>
                            <img src="../imges/bgxiu_14.gif" alt="选择栏目" style="cursor: pointer;" onclick="selectFile('TxtClassName,HidClassID','栏目选择','newsclass','400','300')" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtClassName"
                                ErrorMessage="请选择所属新闻栏目" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="HidClassID" runat="server" Value="" />
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            审核状态：
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlAudit" runat="server" Height="21px" Width="92px" CssClass="input8">
                                <asp:ListItem Value="0">不审核</asp:ListItem>
                                <asp:ListItem Value="1">一级审核</asp:ListItem>
                                <asp:ListItem Value="2">二级审核</asp:ListItem>
                                <asp:ListItem Value="3">三级审核</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            采集参数：
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="ChbSavePic" Text="保存远程图片" CssClass="checkbox2" />
                            <asp:CheckBox runat="server" ID="ChbReverse" Text="是否倒序采集" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbPicNews" Text="内容中包含图片时设置为图片新闻" CssClass="checkbox2" />
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            过滤选项：
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="ChbHTML" Text="HTML"  CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbSTYLE" Text="STYLE" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbDIV" Text="DIV" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbA" Text="A" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbCLASS" Text="CLASS" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbFONT" Text="FONT" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbSPAN" Text="SPAN" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbOBJECT" Text="OBJECT" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbIFRAME" Text="IFRAME" CssClass="checkbox2"/>
                            <asp:CheckBox runat="server" ID="ChbSCRIPT" Text="SCRIPT" CssClass="checkbox2"/>
                        </td>
                    </tr>
                </table>
                <div class="nxb_submit" >
                    <asp:HiddenField ID="HidSiteID" runat="server" />
                            <asp:Button ID="BtnSiteOK" Text=" 保 存 " runat="server" CssClass="xsubmit1" OnClick="BtnSiteOK_Click" />
                            <asp:Button ID="BtnNext" Text="下一步" CssClass="xsubmit1" runat="server" OnClick="BtnNext_Click" />
                            <input type="reset" value=" 重 置 " class="xsubmit1" />
                </div>
            </div>
            </asp:Panel>
      </div>
   </div>
</div>
</div>
    </form>
</body>
</html>
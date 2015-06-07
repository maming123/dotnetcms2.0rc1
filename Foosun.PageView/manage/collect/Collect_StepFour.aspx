<%@ Page Language="C#" AutoEventWireup="true" Inherits="Collect_StepFour" Codebehind="Collect_StepFour.aspx.cs" validateRequest="false" %>

<%@ Register Src="CollectEditor.ascx" TagName="CollectEditor" TagPrefix="uc1" %>
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

    <script language="javascript" type="text/javascript">
    <!--
        function ChangeSet(obj) {
        var td2=jQuery(obj).parent().next();
        if (obj.checked) {
            jQuery(td2).children().first().hide();
            jQuery(td2).children().last().show();
        }
        else {
            jQuery(td2).children().first().show();
            jQuery(td2).children().last().hide();

        }
    }
    function ChangePage()
    {
        var flag;
        if(document.getElementById('RadPageNone').checked)
            flag = 0;
        else if(document.getElementById('RadPageOther').checked)
            flag = 1;
        else if(document.getElementById('RadPageCode').checked)
            flag = 2;
        var tr1 = document.getElementById("Tr_PageOther");
        var tr2 = document.getElementById("Tr_PageCode");
        switch(flag)
        {
            case 0:
                tr1.style.display = 'none';
                tr2.style.display = 'none';
                break;
            case 1:
                tr1.style.display = '';
                tr2.style.display = 'none';
                break;
            case 2:
                tr1.style.display = 'none';
                tr2.style.display = '';
                break;
        }
    }
    function ChangeDiv(ID)
    {
	    document.getElementById('td_baseinfo').className='m_up_bg';
	    document.getElementById('td_preview').className='m_up_bg';
        document.getElementById('tr_baseinfo').style.display='none';
        document.getElementById('tr_preview').style.display='none';
        document.getElementById('td_'+ ID).className='m_down_bg';
        document.getElementById('tr_'+ ID).style.display='';
	}
	function ChangeUrl(obj)
	{
	    var url = obj.options[obj.selectedIndex].value;
	    var frm = document.getElementById("PreviewArea");
	    frm.src = url;
    }
	function StepBack()
	{
	    location.href = "Collect_StepThree.aspx?ID="+ document.getElementById("HidSiteID").value;
	}
	function LoadMe(flag)
	{
	    ChangeDiv('baseinfo');
        ChangeSet(document.getElementById('ChbAuthor'));
        ChangeSet(document.getElementById('ChbSource'));
        ChangeSet(document.getElementById('ChbTime'));
        ChangePage();
    }
    //-->
    </script>

</head>
<body onload="LoadMe(Math.random())">
    <form id="Form2" runat="server">
    <div class="mian_body">
        <div class="mian_wei">
            <!--<div class="mian_wei_1"><img src="imges/lie_10.gif" alt="" /></div>-->
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>采集系统</h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="Collect_List.aspx" target="sys_main">站点设置</a> >>设置向导  
              </div>
           </div>
           <!--<div class="mian_wei_2"><img src="imges/lie_12.gif" alt="" /></div>-->
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="jslie_lan">
                    <span>功能：</span><a href="Collect_List.aspx" class="list_link">站点列表</a>&nbsp;┊&nbsp;<a class="topnavichar"
                            href="Collect_RuleList.aspx">关键字过滤</a>&nbsp;┊&nbsp;<a class="topnavichar" href="Collect_News.aspx">新闻处理</a>
                  </div>
                  <div class="lanlie_lie">
                    <div class="newxiu_base">
            <table class="nxb_table">
                <tr>
                    <td width="50%" class="m_down_bg" id="td_baseinfo" onclick="javascript:ChangeDiv('baseinfo');"
                        style="cursor: hand;" align="center">
                        基本设置</td>
                    <td width="50%" class="m_up_bg" id="td_preview" onclick="javascript:ChangeDiv('preview');"
                        style="cursor: hand;" align="center">
                        预览</td>
                </tr>
                <tr id="tr_baseinfo">
                    <td colspan="3" valign="top" class="list_link">
                        <table width="100%" align="center" cellpadding="5" cellspacing="1" style="border-collapse:collapse; border:none;">
                            <tr>
                                <td width="15%" align="right">
                                    标题：
                                </td>
                                <td>
                                    <div style=" margin-bottom:10px; float:left; width:100%;"><uc1:CollectEditor ID="EdtCaption" runat="server" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    内容：
                                </td>
                                <td>
                                    <div style=" margin-bottom:10px; float:left; width:100%;"><uc1:CollectEditor ID="EdtContent" runat="server" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    作者：<br />
                                    <span class="span1">手动<asp:CheckBox runat="server" ID="ChbAuthor" onclick="ChangeSet(this)" /></span>
                                </td>
                                <td>
                                    <div>
                                        <uc1:CollectEditor ID="EdtAuthor" Text="[变量]" runat="server" />
                                    </div>
                                    <div style="margin:10px; display:inline;">
                                        <asp:TextBox runat="server" ID="TxtAuthor" MaxLength="100" CssClass="input8" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    来源：<br />
                                    <span class="span1">手动<asp:CheckBox runat="server" ID="ChbSource" onclick="ChangeSet(this)" /></span>
                                </td>
                                <td>
                                    <div>
                                        <uc1:CollectEditor Text="[变量]" ID="EdtSource" runat="server" />
                                    </div>
                                    <div  style="margin:10px; display:inline;">
                                        <asp:TextBox runat="server" ID="TxtSource"  MaxLength="100" CssClass="input8" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" align="right">
                                    时间：<br />
                                    <span class="span1">手动<asp:CheckBox runat="server" ID="ChbTime" onclick="ChangeSet(this)" /></span>
                                </td>
                                <td>
                                    <div>
                                        <uc1:CollectEditor Text="[变量]" ID="EdtTime" runat="server" />
                                    </div>
                                    <div style="margin:10px; display:inline;">
                                        <asp:TextBox runat="server" ID="TxtTime"  MaxLength="25" CssClass="input8" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="list_link" align="center">
                                    分页方式：</td>
                                <td class="list_link">
                                    <asp:RadioButton CssClass="radio" runat="server" Checked="true" onclick="ChangePage()" ID="RadPageNone" GroupName="RadGroupPage"
                                        Text="不设置新闻分页" />
                                    <asp:RadioButton runat="server" onclick="ChangePage()" ID="RadPageOther" GroupName="RadGroupPage" CssClass="radio"
                                        Text="递归分页设置" />
                                    <asp:RadioButton runat="server" onclick="ChangePage()" ID="RadPageCode" GroupName="RadGroupPage" CssClass="radio"
                                        Text="单页获取分页设置" />
                                </td>
                            </tr>
                            <tr runat="server" id="Tr_PageOther">
                                <td width="15%" align="right">
                                    递归分页设置：
                                </td>
                                <td>
                                    <uc1:CollectEditor ID="EdtPageOther" runat="server" />
                                    <br />
                                    <span style="color: red;">例:&lt;a href="[分页新闻]"&gt;下一页 要求:下一页,必须为整个页面中唯一字符,只有第一个"[分页新闻]"有效。</span>
                                </td>
                            </tr>
                            <tr runat="server" id="Tr_PageCode">
                                <td width="15%" align="right">
                                    单页获取分页设置：
                                </td>
                                <td>
                                    <uc1:CollectEditor ID="EdtPageRule" runat="server" />
                                    <br />
                                    <span style="color: red;">例:&lt;a href="[分页新闻]"&gt;[变量]&lt;/a&gt; 要求 [分页新闻] 前字符串必须为整个页面中唯一代码</span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="tr_preview">
                    <td colspan="3" valign="top">
                        <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" style="border-collapse:collapse;border:none;">
                            <tr class="TR_BG">
                                <td class="sys_topBg" align="center">
                                    <b>采集的网页地址：</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="list_link" align="center">
                                    <asp:DropDownList runat="server" onchange="ChangeUrl(this)" ID="DdlObtUrl" Style="width: 770px; margin:8px 0;"
                                        CssClass="input8" />
                                </td>
                            </tr>
                            <tr class="TR_BG">
                                <td class="sys_topBg" align="center">
                                    <b>结果</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="list_link" align="center">
                                    <iframe frameborder="1" src="about:blank" id="PreviewArea" name="PreviewArea" marginheight="1"
                                        marginwidth="1" style="width: 770px; height: 371px; margin:10px;" scrolling="yes" class="input8">
                                    </iframe>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="list_link" align="center" colspan="3">
                        
                    </td>
                </tr>
            </table>
                        <div class="nxb_submit" >
                            <asp:HiddenField ID="HidSiteID" runat="server" />
                        <input type="button" value="上一步" class="xsubmit1" onclick="StepBack()" />
                        <asp:Button runat="server" ID="BtnNext" Text="下一步" CssClass="xsubmit1" OnClick="BtnNext_Click" />
                       </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

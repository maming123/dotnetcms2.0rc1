<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="Foosun.PageView.manage.news.NewsList" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>栏目列表</title>
<link rel="stylesheet" type="text/css" href="/CSS/base.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/style.css"/>
<link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css"/>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.bgiframe.js" type="text/javascript"></script>
     <script src="/Scripts/SelectAction.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("input[name='Checkboxc']").click(function () {
                if (this.checked) {
                    $("input[name='Checkbox1']").attr('checked', true);
                }
                else {
                    $("input[name='Checkbox1']").attr('checked', false);
                }
            });
        });
        function GetCheackNews(id) {
            var idlist = "";
            if (id < 0) {
                $('input[type="checkbox"][name="Checkbox1"]').each(function () {
                    if (this.checked) {
                        idlist += $(this).val() + ",";
                    }
                });
                if (idlist.length > 0) {
                    idlist = idlist.substring(0, idlist.length - 1);
                }
            }
            else {
                idlist = id;
            }

            return idlist;

        }
        function Recycle(id) {
            var idlist = GetCheackNews(id);
            if (idlist == "") {
                alert("您没有选择任何新闻！");
                return;
            }
            if (confirm("你确定要把所选新闻放入回收站吗？")) {
                PostForm("type=Recycle&idlist=" + idlist);
            }

        }
        function Delete(id) {
            var idlist = GetCheackNews(id);
            if (idlist == "") {
                alert("您没有选择任何新闻！");
                return;
            }
            if (confirm("你确定要删除所选新闻吗？")) {
                PostForm("type=Delete&idlist=" + idlist);
            }
        }
        function CheckStat(id) {
            if (confirm("你确定要审核所选新闻吗？")) {
                PostForm("type=CheckStat&idlist=" + id);
            }
        }
        function AllCheckStat() {
            var idlist = GetCheackNews(-1);
            if (idlist == "") {
                alert("您没有选择任何新闻！");
                return;
            }
            if (confirm("你确定要审核所选新闻吗？")) {
                PostForm("type=AllCheckStat&idlist=" + idlist);
            }
        }
        function Lock(id) {
            var idlist = GetCheackNews(id);
            if (idlist == "") {
                alert("您没有选择任何新闻！");
                return;
            }
            if (confirm("你确定要锁定选定的新闻吗？")) {
                PostForm("type=Lock&idlist=" + idlist);
            }
        }
        function UNLock(id) {
            var idlist = GetCheackNews(id);
            if (idlist == "") {
                alert("您没有选择任何新闻！");
                return;
            }
            if (confirm("你确定要解锁选定的新闻吗？")) {
                PostForm("type=UNLock&idlist=" + idlist);
            }
           
        }
        function ResetOrder() {
            var idlist = GetCheackNews(-1);
            if (idlist == "") {
                alert("您没有选择任何新闻！");
                return;
            }
            if (confirm("你确定要重置所选新闻的权重吗？")) {
                PostForm("type=ResetOrder&idlist=" + idlist);
            }
        }
        function SetTop(id) {
            if (confirm("你确定要固顶所选新闻的权重吗？")) {
                PostForm("type=SetTop&idlist="+id);
            }
        }
        function UnSetTop(id)
        {
          if (confirm("你确定要解固所选新闻的权重吗？")) {
              PostForm("type=UnSetTop&idlist=" + id);
            }  
        }
        function makeFilesHTML()
        {           
            var idlist = GetCheackNews(-1);
            if (idlist == "") {
                alert("您没有选择任何新闻！");
                return;
            }      
            if(confirm('您确定要生成选中新闻吗？'))
            {
                  PostForm("type=makeFilesHTML&idlist="+idlist);
            }
        }
                //清空数据
        function delSelectedNum()
        {       
            if(confirm('您确定清空当前栏目下的所有的新闻吗?清空后将不能被恢复!'))
            {
                  PostForm("type=DelClassNews&idlist=<%Response.Write(Request.QueryString["ClassID"]);%>");
            }
        }
        function XMLRefresh()
        {
             if(confirm('您确定要生成当前栏目的xml吗？'))
            {
                  PostForm("type=XMLRefresh&idlist=<%Response.Write(Request.QueryString["ClassID"]);%>");
            }
        }
        function PostForm(datas) {
            $.ajax({
                type: "POST",
                url: "Newslist.aspx",
                async: false,
                //是否ajax同步       
                data: datas,
                success: function (data) {
                    $("#dialog-message").html("<div class=\"msgboxs\">"+data+"</div>");
                    $("#dialog-message").dialog({
                        modal: true,
                        close: function () {
                            __doPostBack('PageNavigator1$LnkBtnGoto', '');
                        }
                    });
                }
            });
        }
        function ShowDetail(obj) {
            $('.trlist').hide();
            $(obj).parent().parent().next().toggle();
        }
        function ClickHandler(obj) {
            var strn = GetCheackNews(-1);
            location.href = "NewsManage.aspx?Option=" + obj + "&ids=" + strn + "&dbtab=<%Response.Write(Foosun.Config.UIConfig.dataRe); %>news";
        }
        
function ToOld()
{
    var list = GetCheackNews(-1);
    if (list == "") {
        if (confirm("你没有选择任何新闻，如果点击确定则归档当前栏目下的所有新闻。\n警告：此操作不可逆。\n如果您非要此操作。请按 [确定]按钮")) {
            PostForm("type=ToOldNewsClass&idlist=0&ClassID=<%Response.Write(Request.QueryString["ClassID"]); %>");
        }
    }
    else {
        if (confirm("确认归档吗？\n将归档您选择的新闻\n警告：此操作不可逆。\n如果您非要此操作。请按 [确定]按钮")) {
            PostForm("type=ToOldNews&idlist=" + list);
        }
    }
}

function AddToJS(id)
{
    var l;
    if(id < 0)
    {
        l = GetCheackNews(-1);
        if(l == "")
        {
            alert("您没有选择要加入JS的新闻!");
            return;
        }
    }
    else
    {
        l = id;
    }
	if (l!="") 
	{
	
	    window.open('Frame.aspx?NewsID=' + l,'', 'width=350, height=250, top=300,left=250,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
	}
	else alert('请选择新闻');
}

function AddToSpecial(id)
{
    var l;
    if(id < 0)
    {
        l = GetCheackNews(-1);
        if(l == "")
        {
            alert("您没有选择要加入专题的新闻!");
            return;
        }
    }
    else
    {
        l = id;
    }
	if (l!="") 
	{
	
	    window.open('Frame.aspx?Special=1&NewsID=' + l,'', 'width=350, height=250, top=300,left=250,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
	}
	else alert('请选择新闻');
}
    </script>
</head>
<body>
<form id="form1" runat="server">
<div class="mian_body">
<div class="mian_wei">
   <div class="mian_wei_min">
      <div class="mian_wei_left"><h3>新闻管理</h3></div>
      <div class="mian_wei_right">
          导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="NewsList.aspx">新闻管理</a><label id="naviClassName" runat="server" />
      </div>
   </div>
</div>
<div class="mian_cont">
   <div class="nwelie">
      <div class="nwelie_lan1">
         <ul>
            <li><a href="NewsList.aspx">全部</a>┊</li>
            <li><a href="NewsAdd.aspx">添加</a>┊</li>
            <li><asp:LinkButton ID="LnkBtnAuditing" CssClass="topnavichar" runat="server" OnClick="LnkBtnAuditing_Click">已审核</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LnkBtnUnAuditing" CssClass="topnavichar" runat="server" OnClick="LnkBtnUnAuditing_Click">未审核</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LnkBtnContribute" CssClass="topnavichar" runat="server" OnClick="LnkBtnContribute_Click">投稿</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LinkBtnLock" CssClass="topnavichar" runat="server" OnClick="LnkBtnLock_Click">锁定</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LinkBtnUnLock" CssClass="topnavichar" runat="server" OnClick="LnkBtnUnLock_Click">开放</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LnkBtnCommend" CssClass="topnavichar" runat="server" OnClick="LnkBtnCommend_Click">推荐</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LnkBtnTop" CssClass="topnavichar" runat="server" OnClick="LnkBtnTop_Click">置顶</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LnkBtnHot" CssClass="topnavichar" runat="server" OnClick="LnkBtnHot_Click">热点</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LnkBtnPic" CssClass="topnavichar" runat="server" OnClick="LnkBtnPic_Click">图片</asp:LinkButton>┊</li>
            <li><asp:LinkButton ID="LnkBtnSplendid" CssClass="topnavichar" runat="server" OnClick="LnkBtnSplendid_Click">精彩</asp:LinkButton>┊</li>
            <li><span style="cursor: pointer;" onclick="document.getElementById('opld').style.display='block';">更多</span>┊</li>
            <li>
              <asp:DropDownList ID="DdlSite" Width="88px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlSite_SelectedIndexChanged">
					</asp:DropDownList>
            </li>
         </ul>
      </div>
      <div id="opld" class="nwelie_yin">
       <iframe scrolling="no" frameborder="0" style="width:100%;position:absolute; z-index:-1;">
</iframe>      
         <div style="text-align: right; background-color:#e9f9ff; cursor: pointer;">
         <img border="0" onclick="document.getElementById('opld').style.display='none';" src="../imges/colosediv.gif" alt="关闭"/>
         </div>
         <div class="nwelie_yin_xia">
            <asp:LinkButton ID="LnkBtnHeadline" CssClass="topnavichar" runat="server" OnClick="LnkBtnHeadline_Click">头条</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnSlide" CssClass="topnavichar" runat="server" OnClick="LnkBtnSlide_Click">幻灯片</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnmy" CssClass="topnavichar" runat="server" OnClick="LnkBtnmy_Click">我的信息</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnisHtml" CssClass="topnavichar" runat="server" OnClick="LnkBtnisHtml_Click">已生成</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnunisHtml" CssClass="topnavichar" runat="server" OnClick="LnkBtnunisHtml_Click">未生成</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnundiscuzz" CssClass="topnavichar" runat="server" OnClick="LnkBtnundiscuzz_Click">允许讨论组</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnuncommat" CssClass="topnavichar" runat="server" OnClick="LnkBtnuncommat_Click">允许评论</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnunvoteTF" CssClass="topnavichar" runat="server" OnClick="LnkBtnunvoteTF_Click">允许投票</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnuncontentPicTF" CssClass="topnavichar" runat="server" OnClick="LnkBtnuncontentPicTF_Click">画中画</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnunPOPTF" CssClass="topnavichar" runat="server" OnClick="LnkBtnunPOPTF_Click">浏览权限</asp:LinkButton>┊<asp:LinkButton ID="LnkBtnunFilesURL" CssClass="topnavichar" runat="server" OnClick="LnkBtnunFilesURL_Click">有附件的</asp:LinkButton>
        </div>
      </div>
   <div class="nwelie_lan2">
         <ul>
            <li><a href="javascript:Recycle(-1)">删除</a>┊</li>
            <li><a href="javascript:Delete(-1)">彻底删除</a>┊</li>
            <li><a href="javascript:AllCheckStat()" title="审核选定的新闻">审核</a>┊</li>
            <li><a href="javascript:Lock(-1)" class="topnavichar">锁定</a>┊</li>
            <li><a href="javascript:UNLock(-1)" class="topnavichar">解锁</a>┊</li>
            <li><a href="javascript:ResetOrder()" class="topnavichar">重置权重</a>┊</li>
            <li><a href="javascript:ClickHandler('BnMove')" class="topnavichar">移动</a>┊</li>
            <li><a href="javascript:ClickHandler('BnCopy')" class="topnavichar">复制</a>┊</li>
            <li><a href="javascript:ToOld()" class="topnavichar">归档</a>┊</li>
            <li><a href="javascript:AddToJS(-1)" class="topnavichar" title="把选定的新闻加入自由JS">JS</a>┊</li>
            <li><a href="javascript:AddToSpecial(-1)" class="topnavichar" title="把选定的新闻加入专题">专题</a>┊</li>
            <li><span id="deltable" runat="server"></span>┊</li>
            <li><a href="javascript:ClickHandler('BnProperty')" class="topnavichar" title="批量设置属性">属性</a>┊</li>
            <li><a href="javascript:makeFilesHTML()" class="topnavichar" title="生成选定的新闻的静态页面">生成静态文件</a>┊</li>
            <li><label id="XMLFile" runat="server" />┊</li>
            <li><label id="ClassNewsIndex" runat="server" /></li>
         </ul>
      </div>
     <div class="nwelie_lan2">
         新闻搜索：<span class="nwelie_so">栏目：</span><asp:TextBox ID="keyWorks" runat="server" onclick="javascript:selectFile('keyWorks,_ClassID','栏目选择','newsclass','400','300')"  Width="150px"></asp:TextBox>
         <asp:HiddenField ID="_ClassID" runat="server" Value=""/>
       <span class="nwelie_so">关键字：</span><asp:TextBox runat="server" ID="TxtKeywords" width="100" />
<asp:DropDownList ID="DdlKwdType" runat="server" CssClass="xselect3">
						<asp:ListItem Value="title" Text="标题" />
						<asp:ListItem Value="content" Text="内容" />
						<asp:ListItem Value="author" Text="作者" />
						<asp:ListItem Value="editor" Text="编辑" />
						<asp:ListItem Value="souce" Text="来源" />
					</asp:DropDownList>
                 <asp:Button runat="server" ID="BtnSearch" Text=" 搜索 " CssClass="form1" 
             onclick="BtnSearch_Click" />
      </div>
      <div class="nwelie_lie">
      <asp:Repeater ID="DataList1" runat="server" >
			<HeaderTemplate>
         <table class="nwelie_table" align="center" cellspacing="1">
            <tr  class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <th width="3%"></th>
               <th width="40%">标题</th>
               <th width="7%">编辑</th>
               <th width="16%" align="center">审核操作</th>
               <th width="4%">状态</th>
               <th width="21%">操作<input name="Checkboxc" type="checkbox" /></th>
            </tr>
            	</HeaderTemplate>
			<ItemTemplate>
            <tr  class="off" onmouseover="this.className='on'"onmouseout="this.className='off'">
               <td align="center"><%#((DataRowView)Container.DataItem)["ImgOrder"]%></td>
               <td><a href="<%#((DataRowView)Container.DataItem)["URLaddress"]%>" class="na1"  target="_blank"><%#((DataRowView)Container.DataItem)["Imgtype"] %></a><a  title="<%#((DataRowView)Container.DataItem)["NewsTitle"]%>" href="Newsadd.aspx?ClassID=<%#((DataRowView)Container.DataItem)["ClassID"]%>&NewsID=<%#((DataRowView)Container.DataItem)["NewsID"]%>&EditAction=Edit"><%#((DataRowView)Container.DataItem)["NewsTitles"]%></a><%#((DataRowView)Container.DataItem)["isConstrs"]%></td>
               <td align="center"><a href="Newslist.aspx?ClassID=<%#((DataRowView)Container.DataItem)["ClassID"]%>&Editor=<%#((DataRowView)Container.DataItem)["Editor"]%>" title="查看此编辑/会员的文章" class="xa3">
							<%#((DataRowView)Container.DataItem)["Editor"]%></a><a href="../../<%Response.Write(Foosun.Config.UIConfig.dirUser); %>/showuser-<%#((DataRowView)Container.DataItem)["Editor"]%>.aspx" target="_blank">&nbsp;<img src="../imges/lie_78.gif" alt="" /></a></td>
               <td align="center">
               	<%#((DataRowView)Container.DataItem)["CheckStats"]%>                  
               </td> 
               <td align="center">
               <%#((DataRowView)Container.DataItem)["htmllock"]%>             
               </td>
               <td align="center">
               <%#((DataRowView)Container.DataItem)["op"]%>              
               </td>
            </tr>            
            <tr class="trlist" style="display:none;">
              <td colspan="6"><div class="xa3" style="padding-left:15px;">
              	所属栏目:<%#((DataRowView)Container.DataItem)["ClassCName"]%>&nbsp;┊ &nbsp;作者:<%#((DataRowView)Container.DataItem)["Author"]%>&nbsp;┊ &nbsp;新闻属性:<asp:Label runat="server" ID="LblProperty" Text='<%#((DataRowView)Container.DataItem)["LblProperty"]%>' />&nbsp;┊ &nbsp;点击：<%#((DataRowView)Container.DataItem)["Click"]%></div>             
              </td>
            </tr>
         </ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>
      </div>
      <div class="fanye">
         <div class="fanye_le"><uc1:PageNavigator ID="PageNavigator1" runat="server" /></div>
      </div>
      
   </div>
</div>
</div>
	<asp:Label ID="LblChoose" runat="server" Visible="False" Width="49px"></asp:Label>
	<input id="HiddenSpecialID" runat="server" type="hidden" />
    </form>
<div id="dialog-message" title="提示"></div>
</body>
</html>

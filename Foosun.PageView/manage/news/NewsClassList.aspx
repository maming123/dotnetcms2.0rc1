<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsClassList.aspx.cs"
    Inherits="Foosun.PageView.manage.news.NewsClassList" %>

<%@ Register Src="/controls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新闻栏目管理</title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script>
        function SwitchImg(ImgObj, ParentId) {
            var ImgSrc = "", SubImgSrc;
            ImgSrc = ImgObj.src;
            SubImgSrc = ImgSrc.substr(ImgSrc.length - 5, 12);
            if (SubImgSrc == "b.gif") {
                ImgObj.src = ImgObj.src.replace(SubImgSrc, "s.gif");
                ImgObj.alt = "点击收起子栏目";
                SwitchSub(ParentId, true);
            } else {
                if (SubImgSrc == "s.gif") {
                    ImgObj.src = ImgObj.src.replace(SubImgSrc, "b.gif");
                    ImgObj.alt = "点击展开子栏目";
                    SwitchSub(ParentId, false);
                } else {
                    return false;
                }
            }
        }
        function SwitchSub(ParentId, ShowFlag) {
            if (ShowFlag == true) {
                GetSubClass(ParentId, true);
            } else {
                $("#Parent" + ParentId).html("");
                GetSubClass(ParentId, false);
            }
        }

        function GetSubClass(ParentId, ShowFlag) {
            //得到管理目录
            var url = "NewsClassAjax.aspx?ParentId=" + ParentId + "&ShowFlag=" + ShowFlag + "&rd=" + Math.random();
            $.get(url, function (data) {
                GetSubClassOk(data);
            })
        }

        function GetSubClassOk(OriginalRequest) {

            var ClassInfo;
            ClassInfo = OriginalRequest.split("|||");
            if (ClassInfo[0] != "<table width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"4\" cellspacing=\"1\" class=\"table\"></table>") {
                $("#Parent" + ClassInfo[1]).html(ClassInfo[0]);
                $("#Parent" + ClassInfo[1]).css("display", "block");
            }
            else {
                $("#Parent" + ClassInfo[1]).html("&nbsp&nbsp&nbsp&nbsp&nbsp没有子栏目");
            }
        }

        function orderAction(id, order) {
            var ReturnValue = '';
            ReturnValue = prompt('输入权重(数字越大，排列越靠前)：', order);
            if ((ReturnValue != '') && (ReturnValue != null)) {
                location.href = 'NewsClassList.aspx?Type=orderAction&ClassId=' + id + '&OrderId=' + ReturnValue + "&rd=" + Math.random();
            }
            else {
                if (ReturnValue != null) {
                    alert('输入权重');
                }
            }
        }
        function getchanelInfo(obj) {
            var SiteID = obj.value;
            if (SiteID == "") {
                window.location.href = "NewsClassList.aspx";
            }
            else {
                window.location.href = "NewsClassList.aspx?SiteID=" + SiteID + "";
            }
        }
    </script>
</head>
<body>
    <form runat="server" id="form1">
    <div class="mian_body">
        <div class="mian_wei">
            <div class="mian_wei_min">
                <div class="mian_wei_left">
                    <h3>
                        栏目管理</h3>
                </div>
                <div class="mian_wei_right">
                    导航：<a href="javascript:openmain('../main.aspx')">首页</a>>>栏目管理
                </div>
            </div>
        </div>
        <div class="mian_cont">
            <div class="nwelie">
                <div class="lanlie">
                    <ul>
                        <li><a href="NewsClassList.aspx">首页</a>┊</li>
                        <li><a href="NewsClassAdd.aspx?SiteId=<%Response.Write(Request.QueryString["SiteID"]); %>">添加根栏目</a>┊</li>
                        <li><a href="NewsPage.aspx">添加单页面</a>┊</li>
                        <li>
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                OnClientClick="{if(confirm('警告：确认此操作吗?\n此操作将对所选择数据复位一级栏目!')){return true;}return false;}" 
                                onclick="LinkButton1_Click">复位</asp:LinkButton>┊</li>
                        <li><a href="SortPage.aspx?Acton=unite">合并</a>┊</li>
                        <li><a href="SortPage.aspx?Acton=allmove">转移</a>┊</li>
                        <li><asp:LinkButton ID="del_allClass1" runat="server"
                            CssClass="topnavichar" OnClick="del_allClass" OnClientClick="{if(confirm('警告：确认要初始化栏目?\n将删除站点中的所有栏目及内容信息!\n同时将删除所有的静态页面!')){return true;}return false;}">初始化</asp:LinkButton>┊</li>
                        <li><a href="ClassToTemplet.aspx">属性</a>┊</li>
                        <li><asp:LinkButton
                                    ID="Lock" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认批量锁定/解锁吗!')){return true;}return false;}"
                                    OnClick="Lock_Click">锁定/解锁</asp:LinkButton>┊</li>
                        <li><asp:LinkButton ID="AllDel" runat="server" CssClass="topnavichar" OnClientClick="{if(confirm('确认删除所选栏目吗?\n将删除到回收站中.\n如果要恢复，请在[控制面板]-回收站中恢复。')){return true;}return false;}"
                        OnClick="AllDel_Click">删除</asp:LinkButton>┊</li>
                        <li><asp:LinkButton ID="Selected_del" CssClass="topnavichar" runat="server" OnClick="Selected_del_Click"
                        OnClientClick="{if(confirm('警告：确认删除所选栏目信息吗?\n删除后不可以恢复!')){return true;}return false;}">彻底删除</asp:LinkButton>┊</li>
                        <li><asp:LinkButton ID="makeXML2" runat="server" CssClass="topnavichar" OnClick="MakeXML">生成XML</asp:LinkButton>┊</li>
                        <li><asp:LinkButton ID="makeHTML2" runat="server" CssClass="topnavichar" OnClick="MakeHTML">生成静态文件</asp:LinkButton>┊</li>
                        <li><asp:LinkButton
                        ID="ClassIndex" runat="server" CssClass="topnavichar" OnClick="MakeClassIndex"><span title="索引">索引</span></asp:LinkButton>┊</li>
                        <li><asp:LinkButton
                            ID="clearNewsInfo2" runat="server" CssClass="topnavichar" OnClick="ClearNewsInfo"
                            OnClientClick="{if(confirm('警告：确实清空数据吗?\n确定后将清除选顶栏目下的新闻!')){return true;}return false;}">清空</asp:LinkButton>┊</li>
                        <li><asp:LinkButton
                                ID="customShow" CssClass="topnavichar" runat="server" OnClick="CustomShow_Click">显示全部栏目</asp:LinkButton>┊</li>
                        <li><asp:LinkButton
                                    ID="treeShow" runat="server" CssClass="topnavichar" OnClick="treeShow_Click">只显示顶级栏目</asp:LinkButton></li>
                        <li>
                           <span id="channelList" runat="server" />
                        </li>
                    </ul>
                </div>
                <div class="lanlie_lie">
                    <table class="lanlie_table"  align="center" cellspacing="1">
                        <asp:Repeater ID="rpt_list" runat="server">
                            <HeaderTemplate>
                                <tr class="off" onmouseover="this.className='on'" onmouseout="this.className='off'">
                                    <th width="5%">
                                        ID
                                    </th>
                                    <th width="35%">
                                        栏目中文[英文]
                                    </th>
                                    <th width="7%">
                                        权重
                                    </th>
                                    <th width="18%" align="center">
                                        属性
                                    </th>
                                    <th width="35%">
                                        操作<input type="checkbox" name="c" value="" onclick="javascript:selectAll(this.form,this.checked);" />
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#((System.Data.DataRowView)Container.DataItem)["Colum"]%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="fanye">
                    <div class="fanye_le">
                        <uc1:PageNavigator ID="PageNavigator1" runat="server" />
                    </div>
                </div>
                <asp:HiddenField ID="HiddenField_ParentID" runat="server" />
                <div class="lanlie_shming">
                    <font>说明:</font><br />
                    <span>系统：系统目录</span>┇<span>外部：外部栏目</span>┇<span>显示：导航中显示</span>┇<span>隐藏：导航中隐藏</span>┇<span>域：捆绑了二级域名的目录</span>┇<span>单页：单页栏目</span>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

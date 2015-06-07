<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialTemplet.aspx.cs" Inherits="Foosun.PageView.manage.news.SpecialTemplet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
    <link rel="stylesheet" type="text/css" href="/css/base.css" />
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/<%Response.Write(Foosun.Config.UIConfig.CssPath());%>/css/blue.css" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/public.js" type="text/javascript"></script>
    <link href="/CSS/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/SelectAction.js" type="text/javascript"></script>

</head>
<body>
<div id="dialog-message" title="提示"></div>
    <form id="form1" runat="server">
    <div class="mian_wei">
        <div class="mian_wei">
           <div class="mian_wei_min">
              <div class="mian_wei_left"><h3>专题管理 </h3></div>
              <div class="mian_wei_right">
                  导航：<a href="javascript:openmain('../main.aspx')">首页</a>>><a href="SpecialList.aspx">专题列表</a> >>批量绑定模版 
              </div>
           </div>
        </div>
        
    <div class="mian_cont">
   <div class="nwelie">
      <div class="lanlie">
         <ul>
            <li>批量捆绑模板</li>
         </ul>
      </div>
      <div class="lanlie_lie">
         <div class="nlan_big">
            <table width="99%" border="0"> 
              <tr>
                <td align="center">
                 <div class="nlan_shux">
                   <asp:ListBox ID="splist" runat="server" SelectionMode="Multiple" CssClass="selectlie4">
        
                </asp:ListBox>
                  </div>
                </td>
               </tr>
               <tr>
                  <td>
                     <div class="zhban">
                        选择模板： <asp:TextBox ID="txt_templet" runat="server" MaxLength="200" CssClass="input"></asp:TextBox><img src="../imges/bgxiu_14.gif"  align="middle" style="cursor: pointer;" alt="选择模板" onclick="selectFile('txt_templet','专题导航图片','templet','400','300');document.templet.focus();" />
                     </div>
                  </td>
               </tr>
             </table>
             <div class="nlan_ti" >
               <asp:Button ID="Button1" CssClass="insubt" runat="server" Text="提交捆绑" OnClick="Button1_Click" />
           </div>
        </div>
      </div>
   </div>
</div>
        
        </div>

    </form>
    
</body>
</html>

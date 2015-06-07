using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Foosun.PageView.manage.news
{
    public partial class NewsClassAjax : Foosun.PageBasic.ManagePage
    {
        public NewsClassAjax()
        {
            Authority_Code = "C019";
        }
        Foosun.CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
        Foosun.CMS.UserLogin _UL = new Foosun.CMS.UserLogin();
        public static string _AllPopClassList;
        public DataTable dtcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.CacheControl = "no-cache";
                Response.Expires = 0;
                dtcount = NewsClassCMS.GetNewsCount();
                string ParentId = Request.QueryString["ParentId"];
                string ShowFlag = Request.QueryString["ShowFlag"];
                _AllPopClassList = _UL.GetAdminGroupClassList(); 
                if (ParentId == "" || ParentId == null)
                {
                    return;
                }
                SetParentIDList(ParentId, bool.Parse(ShowFlag));
                if (string.IsNullOrEmpty(ShowFlag) || bool.Parse(ShowFlag) == true)
                {
                    string text = GetChildClassList(ParentId, "");
                    text += "|||" + ParentId;
                    Response.Write(text);
                }
            }
        }

        /// <summary>
        /// 设置节点ID
        /// </summary>
        /// <param name="parentID">节点的ID</param>
        /// <param name="ShowFlag">是否展开</param>
        private void SetParentIDList(string parentID, bool ShowFlag)
        {
            ArrayList arr = null;
            //如果为空,则创建一个内容
            if (Session["__ParentIDList"] == null)
            {
                arr = new ArrayList();
                Session["__ParentIDList"] = arr;
            }
            //取出内容
            arr = (ArrayList)Session["__ParentIDList"];
            //展开节点
            if (ShowFlag)
            {
                //判断是否有此节点ID
                bool isHave = true;
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i].ToString().Equals(parentID))
                        isHave = false;
                }
                if (isHave)
                    arr.Add(parentID);
            }
            else//移出节点
            {
                ArrayList aList = new ArrayList();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (!arr[i].ToString().Equals(parentID))
                    {
                        aList.Add(arr[i]);
                    }
                }
                arr = aList;
            }
            Session["__ParentIDList"] = arr;
        }

        string GetChildClassList(string Classid, string sign)
        {
            string strchar = "<table class=\"tab\">";
            DataTable dt = NewsClassCMS.GetChildList(Classid);
            sign += " ┉┉ ";
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("st", typeof(string));
                    dt.Columns.Add("pop", typeof(string));
                    dt.Columns.Add("Colum", typeof(string));
                    dt.Columns.Add("ClassCNames", typeof(string));
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string count = dtcount.Select("ClassID='" + dt.Rows[j]["ClassID"].ToString() + "'").Length == 0 ? "0" : dtcount.Select("ClassID='" + dt.Rows[j]["ClassID"].ToString() + "'")[0][0].ToString();
                        this.ClassID = dt.Rows[j]["classid"].ToString();
                        if (_AllPopClassList != "isSuper" && _AllPopClassList.IndexOf(dt.Rows[j]["classid"].ToString()) < 0)
                        {
                            dt.Rows[j]["Colum"] = "";
                        }
                        else
                        {
                            if (dt.Rows[j]["isPage"].ToString() == "1")
                            {
                                dt.Rows[j]["ClassCNames"] = "<a href=\"newsPage.aspx?ClassID=" + dt.Rows[j]["ClassID"] + "&Action=Edit\" title=\"点击修改单页面\">" + dt.Rows[j]["ClassCName"] + "</a>";
                            }
                            else
                            {
                                string classTemple = dt.Rows[j]["ClassTemplet"] + "";
                                string ReadNewsTemplet = dt.Rows[j]["ReadNewsTemplet"] + "";
                                classTemple = string.IsNullOrEmpty(classTemple) == true ? "无" : classTemple;
                                ReadNewsTemplet = string.IsNullOrEmpty(ReadNewsTemplet) == true ? "无" : ReadNewsTemplet;
                                //显示模板
                                dt.Rows[j]["ClassCNames"] = "<a onclick=\"var cname=escape('" + dt.Rows[j]["ClassCName"] + "');window.location.href='NewsClassAdd.aspx?Cname=cname&Acation=Add," + dt.Rows[j]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "'\" href='#' title=\"点击修改栏目&#13;栏目模板：" + classTemple + "&#13;内容模板：" + ReadNewsTemplet + "\">" + dt.Rows[j]["ClassCName"] + "[" + dt.Rows[j]["ClassEname"] + "]</a>";
                            }
                            if (dt.Rows[j]["IsURL"].ToString() == "1")
                            {
                                dt.Rows[j]["st"] = "<font color=\"blue\">外部</font>&nbsp;&nbsp;";
                            }
                            else
                            {
                                dt.Rows[j]["st"] = "<font color=\"red\">系统</font>&nbsp;&nbsp;";
                            }
                            if (dt.Rows[j]["isPage"].ToString() == "1")
                            {
                                dt.Rows[j]["st"] += "<font color=\"#FF9900\">单页</font>&nbsp;&nbsp;";
                            }
                            else
                            {
                                dt.Rows[j]["st"] += "普通&nbsp;&nbsp;";
                            }
                            if (dt.Rows[j]["IsLock"].ToString() == "1")
                            {
                                dt.Rows[j]["st"] += "<a href=\"?Stat=Change&id=" + dt.Rows[j]["ClassID"] + "\" title=\"点击正常\" class=\"xa3\">锁定</a> ";
                            }
                            else
                            {
                                dt.Rows[j]["st"] += "<a href=\"?Stat=Change&id=" + dt.Rows[j]["ClassID"] + "\" title=\"点击锁定\" class=\"xa3\"><font color=\"#00FF00\">正常</font></a> ";
                            }
                            if (dt.Rows[j]["Domain"].ToString().Length > 5)
                            {
                                dt.Rows[j]["st"] += "<font color=\"blue\">域</font>&nbsp;&nbsp;";
                            }
                            else
                            {
                                dt.Rows[j]["st"] += "<font color=\"#999999\">域</font>&nbsp;&nbsp;";
                            }
                            if (dt.Rows[j]["NaviShowtf"].ToString() == "1")
                            {
                                dt.Rows[j]["st"] += "<font color=\"red\">显示</font>&nbsp;&nbsp;";
                            }
                            else
                            {
                                dt.Rows[j]["st"] += "隐藏&nbsp;&nbsp;";
                            }

                            string _TempStr = "";
                            if (dt.Rows[j]["IsURL"].ToString() == "0")
                            {
                                if (dt.Rows[j]["isPage"].ToString() == "0")
                                {
                                    _TempStr = "<a class=\"xa3\" title=\"添加新闻\" href=\"NewsAdd.aspx?ClassID=" + dt.Rows[j]["ClassID"].ToString() + "&EditAction=add\">添加新闻</a><a onclick=\"var cname='" + dt.Rows[j]["ClassCName"] + "';window.location.href='NewsClassAdd.aspx?Cname=cname&Number=" + dt.Rows[j]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "'\" href=\"#\" class=\"xa3\">添加子类</a><a href=\"newsPage.aspx?Number=" + dt.Rows[j]["ClassID"] + "\" class=\"xa3\">添加单页面</a>";
                                }
                            }

                            //操作
                            if (dt.Rows[j]["isPage"].ToString() == "1")
                            {
                                dt.Rows[j]["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" class=\"xcheckbox1\" value=" + dt.Rows[j]["ClassID"] + " />&nbsp;&nbsp;<a href=\"newsPage.aspx?Number=" + dt.Rows[j]["ClassID"] + "&Action=Edit\" class=\"xa3\">修改</a><a href=\"NewsPreview.aspx?ID=" + dt.Rows[j]["ClassID"] + "&type=class\" class=\"xa3\" target=\"_blank\">浏览</a>" + _TempStr + "";
                            }
                            else
                            {
                                dt.Rows[j]["pop"] = "<input name=\"Checkbox1\" type=\"checkbox\" class=\"xcheckbox1\" value=" + dt.Rows[j]["ClassID"] + " />&nbsp;&nbsp;<a onclick=\"var cnames=escape('" + dt.Rows[j]["ClassCName"] + "');window.location.href='NewsClassAdd.aspx?Cname=cnames&Acation=Add," + dt.Rows[j]["ClassID"] + "&SiteID=" + Request.QueryString["SiteID"] + "'\" href=\"#\" class=\"xa3\">修改</a><a href=\"NewsPreview.aspx?ID=" + dt.Rows[j]["ClassID"] + "&type=class\" class=\"xa3\" target=\"_blank\">浏览</a>" + _TempStr + "";
                            }
                            if (this.CheckAuthority())
                            {
                                strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                                strchar += "<td  width=\"5%\" align=\"center\">" + dt.Rows[j]["id"] + "</td>";
                                int Exists = NewsClassCMS.ExistsChild(dt.Rows[j]["ClassID"].ToString());
                                if (Exists > 0)
                                    strchar += "<td width=\"35%\"><img id=\"img_parentid_" + dt.Rows[j]["ClassID"] + "\" src=\"../imges/b.gif\" style=\"cursor:hand\" alt=\"点击展开子栏目\"  onClick=\"javascript:SwitchImg(this,'" + dt.Rows[j]["ClassID"] + "');\" border=\"0\">" + sign + dt.Rows[j]["ClassCNames"] + "<span style=\"font-size:10px;color:red;\" title=\"新闻数\">(" +count  + ")</span></td>";
                                else
                                    strchar += "<td width=\"35%\"><img src=\"../imges/s.gif\" style=\"cursor:pointer;\" alt=\"没有子栏目\"  border=\"0\" class=\"LableItem\" />" + sign + dt.Rows[j]["ClassCNames"] + "<span style=\"font-size:10px;color:red;\" title=\"新闻数\">(" + count + ")</span></td>";

                                strchar += "<td width=\"7%\" align=\"center\" valign=\"middle\" ><a class=\"xa3\" href=\"javascript:orderAction(" + dt.Rows[j]["ClassID"] + "," + dt.Rows[j]["OrderID"] + ");\" title=\"点击排序\"><strong>" + dt.Rows[j]["OrderID"] + "</strong></a></td>";
                                strchar += "<td width=\"18%\" align=\"center\" valign=\"middle\" >" + dt.Rows[j]["st"] + "</td>";
                                strchar += "<td width=\"35%\" valign=\"middle\" >" + dt.Rows[j]["pop"] + "</td>";
                                strchar += "</tr>";
                            }
                            else
                            {
                                strchar += "<tr class=\"off\" onmouseover=\"this.className='on'\"onmouseout=\"this.className='off'\">";
                                strchar += "<td  width=\"5%\" align=\"center\">" + dt.Rows[j]["id"] + "</td>";
                                int Exists = NewsClassCMS.ExistsChild(dt.Rows[j]["ClassID"].ToString());
                                if (Exists > 0)
                                    strchar += "<td width=\"35%\"><img id=\"img_parentid_" + dt.Rows[j]["ClassID"] + "\" src=\"../imges/b.gif\" style=\"cursor:hand\" alt=\"点击展开子栏目\"  onClick=\"javascript:SwitchImg(this,'" + dt.Rows[j]["ClassID"] + "');\" border=\"0\">" + sign + dt.Rows[j]["ClassCName"] + "<span style=\"font-size:10px;color:red;\" title=\"新闻数\">(" + count + ")</span></td>";
                                else
                                    strchar += "<td width=\"35%\"><img src=\"../imges/s.gif\" style=\"cursor:pointer;\" alt=\"没有子栏目\"  border=\"0\" class=\"LableItem\" />" + sign + dt.Rows[j]["ClassCNames"] + "<span style=\"font-size:10px;color:red;\" title=\"新闻数\">(" + count + ")</span></td>";

                                strchar += "<td width=\"7%\" align=\"center\" valign=\"middle\" ><a class=\"xa3\" href=\"javascript:orderAction(" + dt.Rows[j]["ClassID"] + "," + dt.Rows[j]["OrderID"] + ");\" title=\"点击排序\"><strong>" + dt.Rows[j]["OrderID"] + "</strong></a></td>";
                                strchar += "<td width=\"18%\" align=\"center\" valign=\"middle\" ></td>";
                                strchar += "<td width=\"35%\" valign=\"middle\" ></td>";
                                strchar += "</tr>";
                            }
                            strchar += "<tr class=\"TR_BG_list\"  ><td colspan=\"5\"><div id=\"Parent" + dt.Rows[j]["ClassID"].ToString() + "\" class=\"SubItem\" HasSub=\"True\" style=\"height:100%; display:none;\"></div></td></tr>";
                            //strchar += getchildClassList(dt.Rows[j]["ClassID"].ToString(), sign);
                            dt.Rows[j]["Colum"] = strchar;
                        }
                    }
                    dt.Clear(); dt.Dispose();
                }
            }
            strchar += "</table>";
            return strchar;
        }
    }
}
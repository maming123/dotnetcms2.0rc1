using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage
{
    public partial class Addmeun : Foosun.PageBasic.ManagePage
    {
        public Addmeun()
        {
            Authority_Code = "Q040";
        }
        CMS.Navi navi = new CMS.Navi();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request.QueryString["ClassID"] != null && Request.QueryString["ClassID"].ToString() != "")
                {
                    string ClassID = Request.QueryString["ClassID"].ToString();
                    if (ClassID.Length == 12)
                    {
                        DataTable dt = navi.GetList("am_ClassID='"+ClassID+"'");
                        if (dt!=null&&dt.Rows.Count>0)
                        {
                            DataTable dtMenus = navi.GetList("am_ChildrenID like '0' and am_ClassID not in('" + dt.Rows[0]["am_ChildrenID"].ToString().Replace(",", "','") + "')");
                            string content = "";
                            if (dtMenus != null && dtMenus.Rows.Count > 0)
                            {
                               
                                foreach (DataRow item in dtMenus.Rows)
                                {
                                    string classname = "gimg";
                                    string img = "/CSS/imges/m2.png";
                                    if (item["imgwidth"].ToString ()!="120")
                                    {
                                        classname = "limg";
                                        img = "/CSS/imges/m1.png";
                                    }                                    
                                    if (item["imgPath"]!=null&&item["imgPath"].ToString()!="")
                                    {
                                        img = item["imgPath"].ToString();
                                    }
                                    string name = item["am_Name"].ToString();
                                    //if (item["isSys"].ToString() == "0")
                                    //{
                                    //    name = "<a href=\"#\"><img src=\"imges/re.gif\"/>" + item["am_Name"] + "</a>";
                                    //}
                                    content += "<li class=\"movemeun\" id=\"" + item["am_ClassID"] + "\"><img class=\"" + classname + "\" src=\"" + img + "\" alt=\"\"/><div class=\"meunname\"><p>"+name+"</p></div></li>";
                                }
                            }
                            meun1.InnerHtml = content;
                            if (dt.Rows[0]["am_ChildrenID"].ToString()!="")
                            {
                                string[] classID = dt.Rows[0]["am_ChildrenID"].ToString().Split(',');
                                string contents = "";
                                foreach (var item in classID)
                                {
                                    dtMenus = navi.GetList(" am_ClassID='" + item + "'");  
                                    if (dtMenus != null && dtMenus.Rows.Count > 0)
                                    {
                                        string classname = "gimg";
                                        string img = "/CSS/imges/m2.png";
                                        string imgwidth = "100";
                                        if (dtMenus.Rows[0]["imgwidth"].ToString() != "120")
                                        {
                                            classname = "limg";
                                            img = "/CSS/imges/m1.png";
                                            imgwidth = "210";
                                        }
                                        if (dtMenus.Rows[0]["imgPath"] != null && dtMenus.Rows[0]["imgPath"].ToString() != "")
                                        {
                                            img = dtMenus.Rows[0]["imgPath"].ToString();
                                        }
                                        string name = dtMenus.Rows[0]["am_Name"].ToString();
                                        //if (dtMenus.Rows[0]["isSys"].ToString () == "0")
                                        //{
                                        //    name = "<a href=\"#\"><img src=\"imges/re.gif\"/>" + dtMenus.Rows[0]["am_Name"] + "</a>";
                                        //}
                                        contents += "<li class=\"movemeun\" style=\" width:" + imgwidth + "px;\" id=\"" + dtMenus.Rows[0]["am_ClassID"] + "\"><img class=\"" + classname + "\" src=\"" + img + "\"  alt=\"\"/><div class=\"meunname\"><p>" + name + "</p></div></li>";
                                    }
                                   
                                }
                                contents += "<li><img class=\"gimg\" src=\"/CSS/imges/27.png\"  alt=\"\"/></li>";
                                meun2.InnerHtml = contents; 
                               
                            }
                            
                        }                       
                    }
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string list = meunlist.Value;
            if (list != "")
            {
                list = list.Substring(0, list.Length - 1);
                if (navi.Update(list, Request.QueryString["ClassID"].ToString()) > 0)
                {
                    PageRight("修改成功！", "main.aspx?id=1");
                }
                else
                {
                    PageError("修改失败！", "main.aspx?id=1");
                }
            }
            else
            {
                Common.MessageBox.Show(this, "你没有选择任何菜单！", "提示", "");
            }
        }

    }
}
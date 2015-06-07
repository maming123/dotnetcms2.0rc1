using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Foosun.PageView.manage.label
{
    public partial class styleadd : Foosun.PageBasic.ManagePage
    {
        public styleadd()
        {
            Authority_Code = "T018";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";                        //设置页面无缓存
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CustomeFromData", "var where = [" + showFormStr() + "];", true);
                string _dirdumm = Foosun.Config.UIConfig.dirDumm;
                if (_dirdumm.Trim() != "") { _dirdumm = "/" + _dirdumm; }
                style_base.InnerHtml = Common.Public.getxmlstylelist("styleContent", _dirdumm + "/xml/cuslabeStyle/cstylebase.xml");
                style_class.InnerHtml = Common.Public.getxmlstylelist("styleContent1", _dirdumm + "/xml/cuslabeStyle/cstyleclass.xml");
                style_special.InnerHtml = Common.Public.getxmlstylelist("DropDownList2", _dirdumm + "/xml/cuslabeStyle/cstylespecial.xml");
                showInfo();
                getDefine();
                showForm(1);
                if (Request.QueryString["styleID"]!=null)
                {
                    GetStyleInfo(); 
                }              
            }
        }
        protected void GetStyleInfo()
        {
            string str_ID = Request.QueryString["styleID"];
            styleID.Value = str_ID;
            Foosun.CMS.Style.Style stClass = new Foosun.CMS.Style.Style();
            DataTable dt = stClass.GetstyleInfo(str_ID);
            if (dt != null&&dt.Rows.Count>0)
            {
                styleClass.Text = dt.Rows[0]["ClassID"].ToString();
                styleName.Text = dt.Rows[0]["StyleName"].ToString();
                ContentTextBox.Value = dt.Rows[0]["Content"].ToString();
                Description.Text = dt.Rows[0]["Description"].ToString();
                dt.Clear();
                dt.Dispose();
            }
            else
            {
                PageError("参数传递错误!", "");
            }
        }
        /// <summary>
        /// 在前台显示分类列表,以及样式列表
        /// </summary>
        /// <returns>在前台显示分类列表,以及样式列表</returns>
        protected void showInfo()
        {            
            Foosun.CMS.Style.Style stClass = new Foosun.CMS.Style.Style();
            DataTable dt = stClass.StyleClassList();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem itm = new ListItem();
                    if (dt.Rows[i]["ClassID"].ToString() == Request.QueryString["ClassID"])
                    {
                        itm.Selected = true;
                    }
                    itm.Value = dt.Rows[i]["ClassID"].ToString();
                    itm.Text = dt.Rows[i]["Sname"].ToString();
                    styleClass.Items.Add(itm);
                    itm = null;
                }
                dt.Clear();
                dt.Dispose();
            }
            ListItem itm1 = new ListItem();
            itm1.Value = "";
            itm1.Text = "请选择分类";
            styleClass.Items.Insert(0, itm1);
            itm1 = null;


        }
        /// <summary>
        /// 获得自定义字段列表
        /// </summary>

        protected void getDefine()
        {
            Foosun.CMS.Style.Style stClass = new Foosun.CMS.Style.Style();
            DataTable dt = stClass.Styledefine();

            if (dt != null)
            {
                define.DataTextField = "defineCname";
                define.DataValueField = "defineColumns";
                define.DataSource = dt;
                define.DataBind();
                dt.Clear();
                dt.Dispose();
            }
            ListItem itm = new ListItem();
            itm.Value = "";
            itm.Text = "自定义字段";
            define.Items.Insert(0, itm);
            itm = null;

        }


        /// <summary>
        /// 保存样式
        /// </summary>
        /// <returns>保存样式</returns>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.styleClass.Items.Count == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>if(confirm('您还没有任何样式分类!现在就添加吗?')==true){window.location.href='styleclassadd.aspx';}</script>");
            }
            else if (this.styleClass.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('请选择分类');</script>");
            }
            else if (Page.IsValid)
            {
                int result = 0;
                Foosun.Model.StyleInfo stClass = new Foosun.Model.StyleInfo();
                stClass.StyleName = styleName.Text;
                stClass.ClassID = styleClass.Text;
                string StContent = ContentTextBox.Value;
                if (StContent.ToLower().IndexOf("<p>") > -1 && StContent.IndexOf("</p>") > -1)
                {
                    StContent = Common.Input.RemovePor(StContent);
                }
                stClass.Content = StContent;
                stClass.Description = Description.Text;
                stClass.CreatTime = DateTime.Now;
                stClass.isRecyle = 0; 
                //清除样式缓存
                //Foosun.Publish.LabelStyle.CatchClear();
                Foosun.CMS.Style.Style style_Class = new Foosun.CMS.Style.Style();
                
                    if (Request.QueryString["styleID"] != null && Request.QueryString["styleID"].ToString() != "")
                    {
                        stClass.styleID = styleID.Value;
                      
                        try
                        {
                            result = style_Class.StyleEdit(stClass);
                        }
                        catch (Exception ex)
                        {
                            PageError(ex.Message, "styleadd.aspx");

                        }
                        if (result == 1)
                            PageRight("修改样式成功!", "style.aspx?ClassID=" + styleClass.Text);
                        else
                            PageError("修改样式失败!", "");

                    }
                    else
                    {
                        try
                        {
                            result = style_Class.StyleAdd(stClass);
                        }
                        catch (Exception ex)
                        {
                            PageError(ex.Message, "styleadd.aspx");

                        }
                        if (result == 1)
                        {
                            PageRight("添加样式成功!", "style.aspx");
                        }
                        else
                        {
                            PageError("添加样式失败!", "styleadd.aspx");
                        }
                    }
                   
               
            }
        }

        protected void showForm(int PageIndex)
        {
            int nRCount, nPCount;
            DataTable tb = Foosun.CMS.Pagination.GetPage("manage_label_style_add_aspx", PageIndex, 20, out nRCount, out nPCount);

            this.biaodan_bname.DataSource = tb;
            this.biaodan_bname.DataTextField = "formname";
            this.biaodan_bname.DataValueField = "formname";
            this.biaodan_bname.DataBind();
            this.biaodan_bname.Items.Insert(0, new ListItem("选择表单", ""));

        }

        protected StringBuilder showFormStr()
        {
            Foosun.CMS.CustomForm Customform = new Foosun.CMS.CustomForm();
            return Customform.GetFromData();
        }
    }
}
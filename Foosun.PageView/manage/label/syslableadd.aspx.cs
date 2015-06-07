using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.label
{
    public partial class syslableadd :Foosun.PageBasic.ManagePage
    {
        public syslableadd()
        {
            Authority_Code = "T011";
        }
        public string str_tempClassID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["LabelID"] != null && Request.QueryString["LabelID"].ToString() != "")
                {
                    GetLabelInfo();
                }
                else
                {
                    showInfo();
                }
            }
        }
        /// <summary>
        /// 在前台显示分类列表
        /// </summary>
        /// <returns>在前台显示分类列表</returns>
        protected void showInfo()
        {
            Foosun.CMS.Label lbc = new Foosun.CMS.Label();
            DataTable dt = lbc.GetLabelClassList();
            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem itm = new ListItem();
                    if (Request.QueryString["ClassID"] != "" && Request.QueryString["ClassID"] != null)
                    {
                        if (dt.Rows[i]["ClassID"].ToString() == Request.QueryString["ClassID"].ToString())
                        {
                            itm.Selected = true;
                        }
                    }
                    itm.Value = dt.Rows[i]["ClassID"].ToString();
                    itm.Text = dt.Rows[i]["ClassName"].ToString();
                    LabelClass.Items.Add(itm);
                    itm = null;
                }
                dt.Clear(); dt.Dispose();
            }
            ListItem itm1 = new ListItem();
            itm1.Value = "";
            itm1.Text = "请选择分类";
            LabelClass.Items.Insert(0, itm1);
        }
        protected void GetLabelInfo()
        {
            string str_ID = Common.Input.checkID(Request.QueryString["LabelID"]);
            LabelID.Value = str_ID;
            Foosun.CMS.Label lbc = new Foosun.CMS.Label();
            DataTable dt = lbc.GetLabelInfo(str_ID);
            if (dt != null)
            {
                LabelClass.Text = dt.Rows[0]["ClassID"].ToString();
                str_tempClassID = dt.Rows[0]["ClassID"].ToString();
                getClassInfo(str_tempClassID);
                if (str_tempClassID == "99999999")
                {                   
                    Button1.Enabled = false;                  
                }
                string tLabelName = dt.Rows[0]["Label_Name"].ToString();
                LabelName.Value = tLabelName.Replace("{FS_", "").Replace("}", "");
                if (dt.Rows[0]["isBack"].ToString() == "0")
                {
                    rdbno.Checked = true;
                }
                else
                {
                    rdbyes.Checked = true;
                }              
                FileContent.Value = dt.Rows[0]["Label_Content"].ToString();
                LabelDescription.Value = dt.Rows[0]["Description"].ToString();
                dt.Clear();
                dt.Dispose();
            }
            else
            {
                PageError("参数传递错误!", "");
            }
        }

        /// <summary>
        /// 取得分类列表
        /// </summary>
        /// <param name="ClassID">当前样式选中的栏目</param>
        /// <returns>在前台显示分类列表</returns>
        protected void getClassInfo(string ClassID)
        {
            string str_showstr = "";
            if (ClassID != "99999999")
            {
                Foosun.CMS.Label lbc = new Foosun.CMS.Label();
                DataTable dt = lbc.GetLabelClassList();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem itm = new ListItem();
                        if (dt.Rows[i]["ClassID"].ToString() == ClassID)
                            itm.Selected = true;
                        itm.Value = dt.Rows[i]["ClassID"].ToString();
                        itm.Text = dt.Rows[i]["ClassName"].ToString();
                        LabelClass.Items.Add(itm);
                        itm = null;
                    }
                    dt.Clear();
                    dt.Dispose();
                }
                str_showstr = "请选择分类";
            }
            else
            {
                str_showstr = "系统内置";
            }
            ListItem itm1 = new ListItem();
            itm1.Value = "";
            itm1.Text = str_showstr;
            LabelClass.Items.Insert(0, itm1);
            itm1 = null;
        }

        /// <summary>
        /// 保存标签
        /// </summary>
        /// <returns>保存标签</returns>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (LabelClass.Items.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>if(confirm('您还没有任何标签分类!现在就添加吗?')==true){window.location.href='syslabelclassadd.aspx';}</script>");
            }
            else if (this.LabelClass.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('请选择分类');</script>");
            }
            else if (Page.IsValid)
            {
                int result = 0;

                Foosun.Model.LabelInfo lbc = new Foosun.Model.LabelInfo();
                string TmplabelName = this.LabelName.Value;
                string TmplabelName_1 = "{FS_" + TmplabelName.Replace("{", "").Replace("}", "").Replace("S_", "").Replace("Page_", "") + "}";
                if (TmplabelName.ToLower().IndexOf("free_") >= 0)
                {
                    PageError("为了和自由标签区别。自定义标签请不要填写free_等字符!", "");
                }
                if (TmplabelName_1.ToLower().IndexOf("fs_dynclass") > -1 || TmplabelName.ToLower().IndexOf("fs_dynspecial") > -1)
                {
                    PageError("为了和动态标签区别。自定义标签请不要填写DynClass或Special等字符!", "");
                }
                lbc.Label_Name = TmplabelName_1;
                lbc.ClassID = LabelClass.Text;            
                if (rdbno.Checked)
                {
                    lbc.isBack = 0;
                }
                else
                {
                    lbc.isBack = 1;
                }
                lbc.Label_Content = this.FileContent.Value.Replace(TmplabelName_1, "");
                lbc.Description = LabelDescription.Value;
                lbc.isSys = 0;
                lbc.isRecyle = 0;
                lbc.CreatTime = DateTime.Now;
                lbc.SiteID = SiteID;

                Foosun.CMS.Label labelc = new Foosun.CMS.Label();

                //清除标签缓存
                lock (Foosun.Publish.CustomLabel._lableTableInfo)
                {
                    Foosun.Publish.CustomLabel._lableTableInfo.Clear();
                }
                if (Request.QueryString["LabelID"] != null && Request.QueryString["LabelID"].ToString() != "")
                {
                    lbc.LabelID = Request.QueryString["LabelID"].ToString();
                    result = labelc.LabelEdit(lbc);
                    if (result == 1)
                        PageRight("修改标签成功!", "SysLabelList.aspx?ClassID=" + Request.Form["LabelClass"]);
                    else if (result == -1)
                    {
                        Common.MessageBox.Show(this, "标签名重复！", "提示", "");
                    }
                    else
                    {
                        PageError("修改标签失败!", "");
                    }
                }
                else
                {
                    result = labelc.LabelAdd(lbc);
                    if (result == 1)
                        PageRight("添加标签成功!", "SysLabelList.aspx?ClassID=" + LabelClass.Text);
                    else if (result == -1)
                    {
                        Common.MessageBox.Show(this, "标签名重复！", "提示", "");
                    }
                    else
                    {
                        PageError("添加标签失败!", "");
                    }
                }
            }
        }
    }
}
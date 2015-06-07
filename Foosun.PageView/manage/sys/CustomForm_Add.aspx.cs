using System;
using System.Text.RegularExpressions;
using Foosun.Model;

namespace Foosun.PageView.manage.Sys
{
    public partial class CustomForm_Add : Foosun.PageBasic.ManagePage
    {
        static private readonly string FormTbPre = Config.DBConfig.TableNamePrefix + "Form_";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LblTablePre.Text = FormTbPre;
                if (Request.QueryString["id"] != null && Request.QueryString["id"].Trim() != string.Empty)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    this.HidID.Value = id.ToString();
                    this.TxtTableName.Attributes.Add("readonly", "true");
                    this.LtrCaption.Text = "修改表单";
                    Foosun.CMS.CustomForm customfm = new Foosun.CMS.CustomForm();
                    CustomFormInfo info = customfm.GetInfo(id);
                    this.TxtName.Text = info.formname;
                    this.TxtTableName.Text = Regex.Replace(info.formtablename, "^" + Regex.Escape(FormTbPre), "", RegexOptions.Compiled);
                    this.TxtFolder.Text = info.accessorypath;
                    if (info.accessorypath != string.Empty && info.accessorysize > 0)
                        this.TxtMaxSize.Text = info.accessorysize.ToString();
                    this.RadLock.Checked = info.islock;
                    this.RadNormal.Checked = !info.islock;
                    this.RadTimeLimited.Checked = info.timelimited;
                    this.RadTimeNotLmt.Checked = !info.timelimited;
                    if (info.timelimited)
                    {
                        this.TxtStartTm.Text = info.starttime.ToString();
                        this.TxtEndTm.Text = info.endtime.ToString();
                    }
                    this.ChbShowValidate.Checked = info.showvalidatecode;
                    this.TxtMemo.Text = info.memo;
                }
                else
                {
                    this.TxtStartTm.Attributes.Add("readonly", "true");
                    this.TxtEndTm.Attributes.Add("readonly", "true");
                    this.TxtFolder.Text = "/" + Foosun.Config.UIConfig.UserdirFile + "/CustomForm/";
                    this.HidID.Value = "0";
                    this.LtrCaption.Text = "新建表单";
                }
            }
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (this.RadTimeLimited.Checked && (this.TxtStartTm.Text.Trim() == string.Empty || this.TxtEndTm.Text.Trim() == string.Empty))
                {
                    PageError("开启时间限制,必须填写开始时间和结束时间!", "CustomForm.aspx");
                }
                CustomFormInfo cf = new CustomFormInfo();
                cf.id = int.Parse(this.HidID.Value);
                cf.formname = this.TxtName.Text.Trim();
                cf.formtablename = FormTbPre + this.TxtTableName.Text.Trim();
                cf.accessorypath = this.TxtFolder.Text.Trim();
                if (this.TxtMaxSize.Text.Trim() != string.Empty)
                    cf.accessorysize = int.Parse(this.TxtMaxSize.Text);
                cf.islock = this.RadLock.Checked;
                cf.timelimited = this.RadTimeLimited.Checked;
                if (cf.timelimited)
                {
                    try
                    {
                        cf.starttime = DateTime.Parse(this.TxtStartTm.Text);
                        cf.endtime = DateTime.Parse(this.TxtEndTm.Text);
                    }
                    catch
                    {
                        Response.Write("<script>window.alert(\"日期格式错误！\");window.history.go(-1);</script>");
                        Response.End();
                    }
                }
                cf.showvalidatecode = this.ChbShowValidate.Checked;
                cf.memo = this.TxtMemo.Text.Trim();
                Foosun.CMS.CustomForm customfm = new Foosun.CMS.CustomForm();
                customfm.Edit(cf);
                if (cf.id > 0)
                    PageRight("修改自定义表单成功!", "CustomForm.aspx");
                else
                    PageRight("新建自定义表单成功!", "CustomForm.aspx");

            }
        }
    }
}

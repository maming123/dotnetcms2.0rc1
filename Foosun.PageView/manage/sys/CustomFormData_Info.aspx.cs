using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Foosun.PageView.manage.Sys
{
    public partial class CustomFormData_Info : Foosun.PageBasic.ManagePage
    {
		Foosun.CMS.CustomForm cf = new Foosun.CMS.CustomForm();

        protected void Page_Load(object sender, EventArgs e)
        {
            string customID = Request.QueryString["customID"];
            string FormID = Request.QueryString["FormID"];			

			if (!IsPostBack)
			{
				CustomFormData_Op(customID, FormID);
				hd_customID.Value = customID;
				hd_FormID.Value = FormID;
			}
        }

		/// <summary>
		/// 管理员回复用户提交的信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void reply_Click(object sender, EventArgs e)
		{			
			cf.EditFormManage(Convert.ToInt32(hd_customID.Value), Convert.ToInt32(hd_FormID.Value), Request.Form["form_answer"], Convert.ToBoolean(Request.Form["IsShow"] == null ? "false" : Request.Form["IsShow"]));
			CustomFormData_Op(hd_customID.Value, hd_FormID.Value);
			Response.Write("<script>window.alert('回复成功！');window.location.href=\"CustomForm_Data.aspx?id=" + hd_FormID.Value+ "\";</script>");
			Response.End();			
		}

		protected void CustomFormData_Op(string customID, string FormID)
		{ 			
            string fname = string.Empty;
            string tablenm = string.Empty;

			string define_fname = string.Empty;
			string define_tablenm = string.Empty;

            DataTable dt = cf.GetSubmitData(Convert.ToInt32(FormID), out fname, out tablenm);
			DataTable define_dt = cf.GetFormDefined(Convert.ToInt32(FormID), out define_fname, out define_tablenm);

			DataRow[] rowList = dt.Select("用户号='" + customID + "'");            
            DataRow row = rowList[0];

			DataRow[] rowList_define = define_dt.Select("id=" + customID);
			DataRow row_define = rowList_define[0];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                HtmlTableRow dr = new HtmlTableRow();
                dr.Attributes.Add("class", "TR_BG_list");
                HtmlTableCell td = new HtmlTableCell();
                td.Attributes.Add("class", "list_link");
                td.Align = "right";
				td.Width = "20%";
                td.InnerText = dt.Columns[i].ColumnName + "：";
                dr.Controls.Add(td);
                td = new HtmlTableCell();
                td.Attributes.Add("class", "list_link");
				bool IsBoolean_isshow = false;
				if (i + 1 == dt.Columns.Count)
				{
					IsBoolean_isshow = Convert.ToBoolean(row[i]);
					hd_isshow.Value = IsBoolean_isshow.ToString();
					if (IsBoolean_isshow)
					{
						td.InnerHtml = "<input type=\"checkbox\" checked=\"checked\" id=\"IsShow\" name=\"IsShow\" Value=\"True\"/>";
					}
					else
					{
						td.InnerHtml = "<input type=\"checkbox\" id=\"IsShow\" name=\"IsShow\" Value=\"True\" />";
					}
				}
				else 
				{
					td.InnerText = row[i] + "";
				}
				
                dr.Controls.Add(td);
                this.grddatas.Controls.Add(dr);
            }

			HtmlTableRow dr_remark = new HtmlTableRow();
			dr_remark.Attributes.Add("class", "TR_BG_list");
			HtmlTableCell td_remark = new HtmlTableCell();
			td_remark.Attributes.Add("class", "list_link");
			td_remark.Align = "right";
			td_remark.InnerText = "回复内容：";
			dr_remark.Controls.Add(td_remark);
			// 判断是否已经回复   如果回复则显示并不可写  否则显示并可写
			td_remark = new HtmlTableCell();
			td_remark.Attributes.Add("class", "list_link");
			td_remark.InnerHtml = "<textarea name=\"form_answer\" id=\"form_answer\" style=\"width:60%;\" rows=\"6\" >" + row_define[define_dt.Columns.Count - 1].ToString() + "</textarea>";
			dr_remark.Controls.Add(td_remark);
			//
			this.grddatas.Controls.Add(dr_remark);

			for (int j = 1; j < define_dt.Columns.Count - 1; j++)
			{
				HtmlTableRow dr_define = new HtmlTableRow();
				dr_define.Attributes.Add("class", "TR_BG_list");
				HtmlTableCell td_define = new HtmlTableCell();
				td_define.Attributes.Add("class", "list_link");
				td_define.Align = "right";
				td_define.InnerText = define_dt.Columns[j].ColumnName + "：";
				dr_define.Controls.Add(td_define);
				td_define = new HtmlTableCell();
				td_define.Attributes.Add("class", "list_link");
				td_define.InnerText = row_define[j].ToString();//define_dt.Rows[Convert.ToInt32(customID)][j].ToString();
				dr_define.Controls.Add(td_define);
				this.grddatas.Controls.Add(dr_define);
			}
		}
	}
}

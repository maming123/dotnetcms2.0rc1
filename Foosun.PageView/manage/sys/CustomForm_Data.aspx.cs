using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Foosun.PageView.manage.Sys
{
    public partial class CustomForm_Data : Foosun.PageBasic.ManagePage
    {
        Foosun.CMS.CustomForm cf = new Foosun.CMS.CustomForm();
        protected int formid = 0;
        protected string tablenm = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChage);

            if (!Page.IsPostBack)
            {
                if (Request.Form["Option"] != null && Request.Form["ID"] != null && Request.Form["Option"] == "TruncateTb")
                {
                    try
                    {
                        int id = int.Parse(Request.Form["ID"]);
                        cf.TruncateTable(id);
                        Response.Write("1%操作成功!");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("0%" + ex.Message);
                    }
                    Response.End();
                }
                if (Request.QueryString["id"] == null)
                {
                    PageError("参数不完整!", "CustomForm.aspx");
                }
                DataListBind(1);
            }
        }

        private void PageNavigator1_PageChage(object sender, int PageIndex)
        {
            DataListBind(PageIndex);
        }

        private void DataListBind(int PageIndex)
        {
            formid = int.Parse(Request.QueryString["id"]);
            string fname;
            int nRCount, nPCount;
            DataTable dt = cf.GetSubmitData(formid, out fname, out tablenm, PageIndex, 20, out nRCount, out nPCount);
            this.PageNavigator1.PageCount = nPCount;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = nRCount;
            this.LblName.Text = fname;

            //表头
            HtmlTableRow handerRow = new HtmlTableRow();
            handerRow.Attributes.Add("class", "off");
            handerRow.Attributes.Add("onmouseover", "this.className='on'");
            handerRow.Attributes.Add("onmouseout", "this.className='off'");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                HtmlTableCell td = new HtmlTableCell();
                td.InnerText = dt.Columns[i].ColumnName;
                handerRow.Cells.Add(td);
            }
            handerRow.Cells.Add(new HtmlTableCell { InnerText = "操作" });
            this.grddatas.Controls.Add(handerRow);

            string[] cellObj = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < cellObj.Length; j++)
                {
                    cellObj[j] = dt.Rows[i][j] + "";
                }
                this.grddatas.Controls.Add(getRow(cellObj));
            }

            this.clearTableForm.HRef = "javascript:TruncateTb(" + formid + ",'" + tablenm + "');";
        }

        /// <summary>
        /// 得到一行
        /// </summary>
        /// <param name="str">列值</param>
        /// <param name="str">是否是标题</param>
        /// <returns></returns>
        private HtmlTableRow getRow(string[] str)
        {
            HtmlTableRow dr = new HtmlTableRow();
            HtmlTableCell input = null;
            dr.Attributes.Add("class", "off");
            dr.Attributes.Add("onmouseover", "this.className='on'");
            dr.Attributes.Add("onmouseout", "this.className='off'");
            for (int i = 0; i < str.Length; i++)
            {
                dr.Cells.Add(getCell(str[i]));
                if (i + 1 == str.Length)
                {
                    input = new HtmlTableCell();
                    input.InnerHtml = "<a class=\"xa3\" href=\"CustomFormData_Info.aspx?customID=" + str[0] + "&FormID=" + Request.QueryString["id"] + "\">查看并回复</a>";
                    dr.Cells.Add(input);
                }
            }
            return dr;
        }

        /// <summary>
        /// 得到一列
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private HtmlTableCell getCell(string str)
        {
            HtmlTableCell t = new HtmlTableCell();
            if (str.Length >= 30)
            {
                str = str.Substring(0, 30) + "...";
            }
            t.InnerText = str;
            return t;
        }
    }
}

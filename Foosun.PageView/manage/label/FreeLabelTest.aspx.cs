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

public partial class FreeLabelTest : Foosun.PageBasic.ManagePage
{
    public FreeLabelTest()
    {
        Authority_Code = "T008";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.ServerVariables["HTTP_REFERER"] != null && !Request.ServerVariables["HTTP_REFERER"].ToString().Equals(""))
        {
            string Path = Request.ServerVariables["HTTP_REFERER"].ToString();
            string Pg = Path.Substring(Path.LastIndexOf("/") + 1);
            if (Pg.IndexOf("?") > 0)
                Pg = Pg.Substring(0, Pg.IndexOf("?"));
            if (!Pg.Equals("FreeLabelAdd.aspx"))
            {
                Response.End();
            }
            if (Request.Form["TxtSQL"] == null)
            {
                Response.End();
            }
            string sql = Request.Form["TxtSQL"].Trim();
            if (sql.Equals(""))
            {
                this.LblError.Text = "错误,SQL语句为空!";
            }
            else
            {
                Foosun.CMS.FreeLabel fb = new Foosun.CMS.FreeLabel();
                try
                {
                    DataTable tb = fb.TestSQL(sql);
                    if (tb == null || tb.Rows.Count < 1)
                    {
                        this.LblError.Text = "记录数为0";
                    }
                    else
                    {
                        this.GrvData.DataSource = tb;
                        this.GrvData.DataBind();
                        this.LblError.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    this.LblError.Text = ex.Message;
                }
            }
        }
        else
        {
            Response.End();
        }
    }
}

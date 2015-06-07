using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.Contribution
{
    public partial class ConstrStat : Foosun.PageBasic.ManagePage
    {
        public ConstrStat()
        {
            Authority_Code = "C045";
        }
        Constr con = new Constr();
        RootPublic pd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            Response.CacheControl = "no-cache";
            if (!IsPostBack)
            {
                Showu_discusslist(1);
            }
        }
        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            Showu_discusslist(PageIndex);
        }

        protected void Showu_discusslist(int PageIndex)
        {
            int i, j;           
            DataTable dts = con.GetPage1(PageIndex, 20, out i, out j, null);
            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = i;
            if (dts != null && dts.Rows.Count != 0)
            {
                dts.Columns.Add("Constrnum", typeof(string));
                dts.Columns.Add("isChecknumber", typeof(string));
                dts.Columns.Add("MConstrnum", typeof(string));               
                dts.Columns.Add("ParmConstrNums", typeof(string));
                dts.Columns.Add("UserNames", typeof(string));
                dts.Columns.Add("ipoint", typeof(string));
                foreach (DataRow s in dts.Rows)
                {
                    int CN_cut = con.Sel26(s["UserNum"].ToString());
                    if (CN_cut > 0)
                    {
                        s["Constrnum"] = CN_cut.ToString();
                    }
                    else
                    {
                        s["Constrnum"] = "0";
                    }
                    int Check_cut = con.Sel27(s["UserNum"].ToString());
                    if (Check_cut > 0)
                    { s["isChecknumber"] = Check_cut.ToString(); }
                    else { s["isChecknumber"] = "0"; }

                    DataTable dt_dd = con.Sel28(s["UserNum"].ToString());

                    if (dt_dd.Rows.Count > 0)
                    {
                        int m1 = DateTime.Now.Month - 1;
                        int MC_cut = con.Sel29(s["UserNum"].ToString(), m1);
                        if (MC_cut > 0) { s["MConstrnum"] = MC_cut.ToString(); }
                        else { s["MConstrnum"] = "0"; }
                    }                       
                    else { s["MConstrnum"] = "0"; }
                    dt_dd.Dispose();dt_dd.Clear();
                    s["ParmConstrNums"] = con.GetParmConstrNum(s["UserNum"].ToString());
                    s["UserNames"] = pd.GetUserName(s["UserNum"].ToString());
                    dt_dd = con.Sel15(s["UserNum"].ToString());
                    if (dt_dd.Rows.Count > 0)
                    {
                        s["ipoint"] = dt_dd.Rows[0]["iPoint"].ToString();
                    }
                    
                }
                DataList1.DataSource = dts;
                DataList1.DataBind();
            }

            else
            {
                no.InnerHtml = Show_no();
                this.PageNavigator1.Visible = false;
            }

        }
        string Show_no()
        {
            string nos = "<table border=0 width='98%' align=center cellpadding=5 cellspacing=1 class='table'>";
            nos = nos + "<tr>";
            nos = nos + "<td>没有数据</td>";
            nos = nos + "</tr>";
            nos = nos + "</table>";
            return nos;
        }
    }
}
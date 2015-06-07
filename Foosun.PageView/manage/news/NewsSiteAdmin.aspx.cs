using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.news
{
    public partial class NewsSiteAdmin : Foosun.PageBasic.ManagePage
    {
        public NewsSiteAdmin()
        {
            Authority_Code = "C057";
        }
        Foosun.CMS.News cnew = new CMS.News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = Request.QueryString["type"];
                if (string.IsNullOrEmpty(type))
                {
                    type = "Stat";
                }
                string stime = DateTime.Now.AddDays(-DateTime.Now.Day + 1).ToString("yyyy-MM-dd");
                string etime =DateTime.Now.AddDays(-DateTime.Now.Day+1).AddMonths(1).ToString("yyyy-MM-dd");
                sdatepicker.Value = stime;
                edatepicker.Value = DateTime.Now.ToString("yyyy-MM-dd");
				if (type.Equals("Stat"))
				{
					this.ClickList.Visible = false;				
					//得到本月的排名
					DataTable table =cnew.GetNewsStat(stime,etime,50);
					this.Stat.DataSource = table;
					this.Stat.DataBind();
				}
				if (!string.IsNullOrEmpty(type) && type.Equals("newsClick"))
				{
					this.Stat.Visible = false;
					//得到本月的排名
                    DataTable table = cnew.GetNewsClick(stime, etime, 50);
					this.ClickList.DataSource = table;
					this.ClickList.DataBind();
				}
                lblstime.Text = stime;
                lbletime.Text = etime;
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            search(sdatepicker.Value,edatepicker.Value);
        }

        protected void btnyear_Click(object sender, EventArgs e)
        {
            search(DateTime.Now.Year + "-01-01", (DateTime.Now.Year + 1) + "-01-01");
        }

        protected void btnmonth_Click(object sender, EventArgs e)
        {

            search(DateTime.Now.AddDays(-DateTime.Now.Day+1).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(-DateTime.Now.Day+1).AddMonths(1).ToString("yyyy-MM-dd"));
        }

        protected void btnweek_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;  //当前时间
            DateTime stime = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
            DateTime etime = stime.AddDays(7);
            search(stime.ToString ("yyyy-MM-dd"), etime.ToString("yyyy-MM-dd"));
        }

        protected void btnday_Click(object sender, EventArgs e)
        {
           search(DateTime.Now.AddDays(-1).ToString ("yyyy-MM-dd"),DateTime.Now.AddDays(1).ToString ("yyyy-MM-dd"));
        }
        void search(string stime,string etime)
        {
            int tops = 0;
            int.TryParse(numtop.Value,out tops);
            if (tops==0)
            {
                tops = 50;
            }
            if (this.Stat.Visible)
            {
                DataTable table =cnew.GetNewsStat(stime, etime, tops);
                this.Stat.DataSource = table;
                this.Stat.DataBind();
            }
            else
            {
                DataTable table = cnew.GetNewsClick(stime, etime, tops);
                this.ClickList.DataSource = table;
                this.ClickList.DataBind();
            }
            lblstime.Text = stime;
            lbletime.Text = etime;
        }
    }
}
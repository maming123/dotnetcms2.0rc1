using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.configuration.system
{
    public partial class SelectSource : Foosun.PageBasic.DialogPage
    {
        public SelectSource()
        {
            BrowserAuthor = EnumDialogAuthority.ForAdmin;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            if (!IsPostBack)
            {
                Response.CacheControl = "no-cache";
                StartLoad(1);
            }
        }

        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            StartLoad(PageIndex);
        }
        protected void StartLoad(int PageIndex)
        {
            int RecordCount = 0;
            int PageCount = 0;

            string _type = Request.QueryString["type"];
            int Tmpstr = 0;
            switch (_type)
            {
                case "Source":
                    Tmpstr = 1;
                    break;
                case "Author":
                    Tmpstr = 2;
                    break;
                default:
                    Tmpstr = 0;
                    break;
            }
            DataTable dt = null;
            if (_type != null && _type != "")
            {
                Foosun.CMS.NewsGen NewsGenBLL= new CMS.NewsGen();
                dt = NewsGenBLL.GetListByPage(Tmpstr.ToString(), Config.UIConfig.GetPageSize(), PageIndex, out RecordCount, out PageCount);
            }
            this.PageNavigator1.PageCount = PageCount;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = RecordCount;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("op", typeof(string));
                    for (int k = 0; dt.Rows.Count > k; k++)
                    {
                        if (Tmpstr == 0)
                        {
                            dt.Rows[k]["op"] = "<a class=\"helpstyle\" href=\"#\" onclick=\"ReturnValue('" + dt.Rows[k]["Cname"].ToString() + "');\">" + dt.Rows[k]["Cname"] + "</a>&nbsp;&nbsp;";
                        }
                        else
                        {
                            dt.Rows[k]["op"] = "<a class=\"helpstyle\" href=\"#\" onclick=\"ReturnValue('" + dt.Rows[k]["Cname"].ToString() + "');\">" + dt.Rows[k]["Cname"] + "</a>&nbsp;&nbsp;";
                        }
                    }
                }
            }
            rpt_list.DataSource = dt;                              //设置datalist数据源
            rpt_list.DataBind();                                   //绑定数据源
        }
    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.user
{
    public partial class usergroup : Foosun.PageBasic.ManagePage
    {
        public usergroup()
        {
            Authority_Code = "U011";
        }
        Foosun.CMS.UserMisc cuser = new CMS.UserMisc();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            if (!IsPostBack)
            {
                string DelStr = Request.QueryString["Action"];
                if (DelStr == "del")
                {
                    int gId = 0;
                    try
                    {
                        gId = int.Parse(Common.Input.Filter(Request.QueryString["id"]));
                    }
                    catch (Exception gus)
                    {
                        PageError("错误的参数" + gus.ToString() + "", "");
                    }
                    dels(gId);
                }
                GroupStr();
            }

        }
        protected void dels(int gid)
        {
            this.Authority_Code = "U014";
            this.CheckAdminAuthority();
            cuser.GroupDels(gid);
            PageRight("删除会员组成功。", "UserGroup.aspx");
        }

        void GroupStr()
        {           
            DataTable dt = cuser.GroupListStr();
            dt.Columns.Add("Discounts", typeof(string));
            dt.Columns.Add("peoplenum",typeof(string));
            if (dt != null)
            {
                for (int i = 0; dt.Rows.Count > i; i++)
                {                   
                    string _Discount = "";
                    if (dt.Rows[i]["Discount"] != null && dt.Rows[i]["Discount"].ToString() != string.Empty)
                    {
                        _Discount = dt.Rows[i]["Discount"].ToString();
                    }
                    else
                    {
                        _Discount = "无折扣";
                    }
                    dt.Rows[i]["Discounts"] = _Discount;
                    string _peoplenum = "";
                    DataTable dts = cuser.GetGroupRecord(dt.Rows[i]["GroupNumber"].ToString());
                    if (dts != null)
                    {
                        _peoplenum = dts.Rows.Count.ToString()  ;
                    }
                    else
                    {
                        _peoplenum = "0";
                    }
                    dt.Rows[i]["peoplenum"] = _peoplenum;                  
                    DataList1.DataSource = dt;
                    DataList1.DataBind();
                }
                dt.Clear(); dt.Dispose();
            }
        }
    }
}
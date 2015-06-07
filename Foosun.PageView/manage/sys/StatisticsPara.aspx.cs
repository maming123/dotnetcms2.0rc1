using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using Foosun.Model;
using System.Data;

namespace Foosun.PageView.manage.sys
{
    public partial class StatisticsPara : Foosun.PageBasic.ManagePage
    {
        Stat sta = new Stat();
        RootPublic rd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParamStartLoad();
            }
        }

        void ParamStartLoad()
        {
            #region 从统计参数设置表中读出数据并初始化赋值
            DataTable dt = sta.sel();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    #region 统计参数设置
                    SystemName.Text = dt.Rows[0]["SystemName"].ToString();
                    SystemNameE.Text = dt.Rows[0]["SystemNameE"].ToString();
                    ipCheck.Text = dt.Rows[0]["ipCheck"].ToString();
                    ipTime.Text = dt.Rows[0]["ipTime"].ToString();
                    isOnlinestat.Text = dt.Rows[0]["isOnlinestat"].ToString();
                    pageNum.Text = dt.Rows[0]["pageNum"].ToString();
                    cookies.Text = dt.Rows[0]["cookies"].ToString();
                    pointNum.Text = dt.Rows[0]["pointNum"].ToString();
                    #endregion
                }
            }
            #endregion
        }

        protected void savePram_ServerClick(object sender, EventArgs e)
        {
            if (Page.IsValid)//判断页面是否通过验证
            {
                if (SiteID != "0")
                {
                    PageError("没有权限", "");
                }
                string Str_SystemNameE = Common.Input.Filter(this.SystemNameE.Text);//统计系统英文名称
                if (Str_SystemNameE == null || Str_SystemNameE == string.Empty)
                {
                    PageError("对不起，系统英文名称不能为空", "StatisticsPara.aspx");
                }
                stat_Param sp = new stat_Param();
                sp.SystemName = this.SystemName.Text;
                sp.SystemNameE = Str_SystemNameE;
                sp.ipCheck = int.Parse(this.ipCheck.Text);
                sp.ipTime = int.Parse(this.ipTime.Text);
                sp.isOnlinestat = int.Parse(this.isOnlinestat.Text);
                sp.pageNum = int.Parse(this.pageNum.Text);
                sp.pointNum = int.Parse(this.pointNum.Text);
                sp.SiteID = SiteID;
                sp.cookies = this.cookies.Text;
                sta.Str_InSql(sp);
                PageRight("统计系统参数设置成功", "StatisticsPara.aspx");
            }
        }
    }
}
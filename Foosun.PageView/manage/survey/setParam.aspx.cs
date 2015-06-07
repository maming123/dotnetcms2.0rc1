using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.survey
{
    public partial class setParam : Foosun.PageBasic.ManagePage
    {
        public setParam()
        {
            Authority_Code = "S005";
        }
        RootPublic rd = new RootPublic();
        Survey sur = new Survey();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache"; //清除缓存
            if (!IsPostBack)                                               //判断页面是否重载
            {
                //判断用户是否登录
                //copyright.InnerHtml = CopyRight;             //获取版权信息
                if (SiteID != "0")
                {
                    Common.MessageBox.Show(this, "没有权限!");
                }
                ParamStartLoad();                                   //载入初始参数设置页面数据
            }
        }

        /// <summary>
        /// 初始参数设置信息
        /// </summary>
        ///code by chenzhaohui 

        void ParamStartLoad()
        {
            DataTable dt = sur.sel_5();
            if (dt.Rows.Count > 0)
            {
                //投票参数设置
                IPtime.Text = dt.Rows[0]["IPtime"].ToString();
                IsReg.Text = dt.Rows[0]["IsReg"].ToString();
                IpLimit.Value = dt.Rows[0]["IpLimit"].ToString();
            }
        }

        /// <summary>
        /// 保存参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// code by chenzhaohui

        protected void SavePram_ServerClick(object sender, EventArgs e)
        {
            if (Page.IsValid)//判断页面是否通过验证
            {
                //取得投票参数设置添加中的表单信息
                string Str_IPtime = Common.Input.Filter(this.IPtime.Text);//Ip时间间隔
                string Str_IsReg = Common.Input.Filter(this.IsReg.Text);//是否需要注册?
                string Str_IpLimit = Common.Input.Filter(this.IpLimit.Value);//IP段
                #region 判断
                if (Str_IPtime == null || Str_IPtime == string.Empty)
                {
                    Common.MessageBox.ShowAndRedirect(this, "对不起，请填写完整!", "setParam.aspx");
                }
                #endregion
                //载入数据-刷新页面
                if (sur.Update_Str_InSqls(Str_IPtime, Str_IsReg, Str_IpLimit, SiteID) != 0)
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "投票系统参数设置", "问卷调查系统参数设置成功");
                    Common.MessageBox.ShowAndRedirect(this, "问卷调查系统参数设置成功!", "setParam.aspx");
                }
                else
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "投票系统参数设置", "意外错误");
                    Common.MessageBox.ShowAndRedirect(this, "意外错误：未知错误!", "setParam.aspx");
                }

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;

namespace Foosun.PageView.manage.sys
{
    public partial class StatisticsAdd : Foosun.PageBasic.ManagePage
    {
        Stat sta = new Stat();
        RootPublic rd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";//设置页面无缓存
            string act = Request.QueryString["act"];
            if (!IsPostBack)
            {
                if (act == "edit")
                {
                    this.Authority_Code = "S003";
                    this.CheckAdminAuthority();
                    EditClass();//修改
                }
            }
        }


        protected void stataddclass_ServerClick(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];
            this.Authority_Code = "S003";
            this.CheckAdminAuthority();
            if (Page.IsValid)//判断页面是否通过验证
            {
                //取得设置添加中的表单信息
                string Str_Classname = Common.Input.Filter(this.ClassName.Text.Trim());//类别
                #region 检查重复数据

            check: string Str_statid = Common.Rand.Number(12);
                if (sta.sel_1(Str_statid) != 0)
                    goto check;
                #endregion

                //检查是否有已经存在的类别名称
                if (sta.Str_CheckSql(Str_Classname) != 0)
                {
                    PageError("对不起，该类别已经存在", "StatisticsAdd.aspx?act=add");
                }
                //检查主题名是否为空
                if (Str_Classname == null || Str_Classname == string.Empty)
                {
                    PageError("对不起，类别名称不能为空，请返回继续添加", "StatisticsAdd.aspx?act=add");
                }
                if (act == "edit")
                {

                    string id = Request.QueryString["id"];
                    if (sta.Str_UpdateSql(Str_Classname, id) != 0)
                    {
                        rd.SaveUserAdminLogs(1, 1, UserNum, "修改统计系统分类", "修改成功");
                        PageRight("修改类别成功", "Statistics.aspx");
                    }
                }
                else if(act == "add")
                {
                    if (sta.Str_InSql_1(Str_statid, Str_Classname, SiteID) != 0)
                    {
                        rd.SaveUserAdminLogs(1, 1, UserNum, "新增统计类别", "新增类别成功");
                        PageRight("新增类别成功", "Statistics.aspx");
                    }
                }
                else
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "新增统计类别", "意外错误");
                    PageError("意外错误：未知错误", "shortcut_list.aspx");
                }

            }
        }

        void EditClass()
        {
            string id = Request.QueryString["id"].ToString();
            #region 从统计分类设置表中读出数据并初始化赋值
            ClassName.Text = sta.Str_ClassSql(id);
            #endregion
        }
    }
}
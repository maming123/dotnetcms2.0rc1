using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Foosun.CMS;

namespace Foosun.PageView.manage.sys
{
    public partial class Statistics : Foosun.PageBasic.ManagePage
    {
        Stat sta = new Stat();
        RootPublic rd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            if (!IsPostBack)
            {
                ClassList(1);
                switch (act)
                {
                    case "delone":
                        this.Authority_Code = "S003";
                        this.CheckAdminAuthority();
                        DelOne();//单个删除
                        break;
                }
            }
        }

        protected void ClassList(int PageIndex)//显示详细记录
        {
            int i, j;
            int num = sta.Stat_Sql(); ;//从参数设置里取得每页显示记录的条数
            if (num == 0)
            {
                num = 20;
            }
            DataTable dt = Foosun.CMS.Pagination.GetPage("Manage_Stat_View_1_aspx", PageIndex, num, out i, out j, null);

            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = i;
            if (dt != null)//判断如果dt里面没有内容，将不会显示
            {
                if (dt.Rows.Count > 0)
                {
                    //添加列
                    dt.Columns.Add("oPerate", typeof(String));//操作
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        int id = int.Parse(dt.Rows[k]["id"].ToString());
                        string classid = dt.Rows[k]["id"].ToString();
                        string statid = dt.Rows[k]["statid"].ToString();

                        dt.Rows[k]["ClassName"] = "<a href=\"StatisticsAdd.aspx?act=edit&id=" + statid + "\"  class=\"xa3\" title=\"点击查看详情或修改\">" + dt.Rows[k]["ClassName"].ToString() + "</a>";
                        dt.Rows[k]["oPerate"] = "<a href=\"StatisticsAdd.aspx?act=edit&id=" + statid + "\"  class=\"xa3\" title=\"点击查看详情或修改\">修改</a><a href=\"Statistics.aspx?act=delone&id=" + statid + "\"  class=\"xa3\" title=\"点击删除此项\" onclick=\"{if(confirm('确认删除吗？')){return true;}return false;}\">删除</a><a href=\"StatisticsView.aspx?type=zonghe&Navi=view&id=" + statid + "\" class=\"xa3\" title=\"查看该分类下统计信息\">查看</a><input type='checkbox' name='stat_checkbox' id='stat_checkbox' value=\"" + statid + "\"/>";

                    }
                }
                else
                {
                    NoContent.InnerHtml = Show_NoContent();
                    this.PageNavigator1.Visible = false;
                }
            }
            else
            {
                NoContent.InnerHtml = Show_NoContent();
                this.PageNavigator1.Visible = false;
            }
            DataList2.DataSource = dt;
            DataList2.DataBind();
        }

        string Show_NoContent()
        {
            string type = Request.QueryString["type"];
            string nos = "";
            if (type == "class")
            {
                nos = "<table border=0 width='98%' align=center cellpadding=5 cellspacing=1 class='table'>";
                nos = nos + "<tr class='TR_BG_list'>";
                nos = nos + "<td class='navi_link'>当前没有满足条件的分类！</td>";
                nos = nos + "</tr>";
                nos = nos + "</table>";
            }
            return nos;
        }

        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            ClassList(PageIndex);//类别页面分页查询
        }

        protected void DelP_Click(object sender, EventArgs e)
        {
            this.Authority_Code = "S003";
            this.CheckAdminAuthority();
            string stat_checkbox = Request.Form["stat_checkbox"];
            if (stat_checkbox == null || stat_checkbox == String.Empty)
            {
                PageError("请先选择批量操作的内容!", "");
            }
            else
            {
                String[] CheckboxArray = stat_checkbox.Split(',');
                stat_checkbox = null;
                for (int i = 0; i < CheckboxArray.Length; i++)
                {
                    #region 删除分类下的统计信息
                    sta.Vote_Sql(CheckboxArray[i]);
                    sta.Str_statInfo_Sql_1(CheckboxArray[i]);
                    sta.Str_statContent_Sql_1(CheckboxArray[i]);
                    #endregion
                }
                rd.SaveUserAdminLogs(1, 1, UserNum, "批量删除统计系统分类", "删除数据成功");
                PageRight("删除数据成功,请返回继续操作!", "Statistics.aspx");
            }
            rd.SaveUserAdminLogs(1, 1, UserNum, "批量删除统计系统分类", "删除数据失败");
            PageError("删除数据失败,请与管理联系!", "");
        }

        protected void DelAll_Click(object sender, EventArgs e)
        {
            this.Authority_Code = "S003";
            this.CheckAdminAuthority();
            bool s1 = sta.Str_StatSql();
            bool s2 = sta.Str_DelAllinfo_Sql();
            bool s3 = sta.Str_DelContent_Sql();
            if (s1 && s2 && s3)
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "全部删除统计系统分类", "删除数据成功");
                PageRight("删除全部成功。", "Statistics.aspx");
            }
            else
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "全部删除统计系统分类", "意外错误：未知错误");
                PageError("意外错误：未知错误", "Statistics.aspx");
            }
        }

        protected void ClearAll_Click(object sender, EventArgs e)
        {
            //更新数据
            if (sta.Str_StatSql_1() != 0 && sta.Str_StatSqlZ() != 0)
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "清空所有统计信息", "清空统计表中数据成功");
                PageRight("恭喜!清空统计表中数据成功。", "Statistics.aspx");
            }
            else
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "清空所有统计信息", "意外错误");
                PageError("意外错误：未知错误", "");
            }
        }

        void DelOne()
        {
            string ID = Request.QueryString["ID"].ToString();
            if (ID == null)
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "统计分类删除单个类别", "参数错误");
                PageError("错误的参数传递!", "Statistics.aspx");
            }
            else
            {

                bool s1 = sta.Str_classSql(ID);
                bool s2 = sta.Str_statInfo_Sql(ID);
                bool s3 = sta.Str_statContent_Sql(ID);
                if (s1)
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "统计分类删除单个类别", "删除成功");
                    PageRight("删除成功。", "Statistics.aspx");
                }
                else
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "统计分类删除单个类别", "意外错误");
                    PageError("意外错误：未知错误", "Statistics.aspx");
                }
            }
        }
    }
}
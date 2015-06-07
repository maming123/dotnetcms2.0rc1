using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Foosun.Model;
using Foosun.CMS;

namespace Foosun.PageView.manage.survey
{
    public partial class SetTitle : Foosun.PageBasic.ManagePage
    {
        public SetTitle()
        {
            Authority_Code = "S004";
        }
        Survey sur = new Survey();
        RootPublic rd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始代码
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            Response.CacheControl = "no-cache"; //清除缓存
            if (!IsPostBack)  //判断页面是否重载
            {
                //判断用户是否登录
                //copyright.InnerHtml = CopyRight;   //获取版权信息
                if (SiteID == "0")
                {
                    param_id.InnerHtml = "<a href=\"setParam.aspx\">系统参数设置</a>&nbsp;┊&nbsp;";
                }
                VoteTitleManage(1); //初始分页数据
                //选择类别(新增主题时)
                try
                {
                    DataTable dt = sur.sel_7();
                    this.vote_ClassName.DataTextField = "ClassName";
                    this.vote_ClassName.DataValueField = "VID";
                    this.vote_ClassName.DataSource = dt;
                    this.vote_ClassName.DataBind();
                    //修改
                    this.ClassnameE.DataTextField = "ClassName";
                    this.ClassnameE.DataValueField = "VID";
                    this.ClassnameE.DataSource = dt;
                    this.ClassnameE.DataBind();
                }
                catch { }

                string type = Request.QueryString["type"];
                switch (type)
                {
                    case "edit":
                        this.Authority_Code = "S005";
                        this.CheckAdminAuthority();
                        setTitleEdit();
                        break;
                    case "delone":
                        this.Authority_Code = "S005";
                        this.CheckAdminAuthority();
                        setTitleDel();
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="PageIndex"></param>

        protected void PageNavigator1_PageChange(object sender, int PageIndex)
        {
            VoteTitleManage(PageIndex);//管理页面分页查询
        }

        /// <summary>
        /// 修改初始页面信息
        /// </summary>
        ///code by chenzhaohui 

        void setTitleEdit()
        {
            try
            {
                int TID = int.Parse(Request.QueryString["ID"]);
                DataTable dt = sur.sel_8(TID);
                if (dt.Rows.Count > 0)
                {
                    this.ClassnameE.Text = dt.Rows[0]["VID"].ToString();
                    this.TitleE.Text = dt.Rows[0]["Title"].ToString();
                    this.TypeE.Text = dt.Rows[0]["Type"].ToString();
                    this.MaxNumE.Text = dt.Rows[0]["MaxNum"].ToString();
                    this.DisModelE.Text = dt.Rows[0]["DisMode"].ToString();
                    this.StartTimeE.Text = dt.Rows[0]["StartDate"].ToString();
                    this.EndTimeE.Text = dt.Rows[0]["EndDate"].ToString();
                    this.StyleE.Text = dt.Rows[0]["ItemMode"].ToString();
                    this.isStepsE.Text = dt.Rows[0]["isSteps"].ToString();
                }
                else
                {
                    Common.MessageBox.ShowAndRedirect(this, "未知错误,异常错误!", "setTitle.aspx");
                }
            }
            catch { }
        }

        /// <summary>
        /// 删除单个
        /// </summary>


        void setTitleDel()
        {
            int TID = int.Parse(Request.QueryString["ID"]);
            if (TID <= 0)
            {
                Common.MessageBox.Show(this, "错误的参数传递!");
            }
            else
            {

                bool v1 = sur.Del_Str_titleSql(TID);
                bool v2 = sur.Del_Str_itemSql_1(TID);
                bool v3 = sur.Del_Str_stepSql(TID);
                bool v4 = sur.Del_Str_manageSql(TID);

                if (v1 && v2 && v3 && v4)
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "删除投票主题", "删除成功");
                    Common.MessageBox.ShowAndRedirect(this, "删除成功!", "setTitle.aspx");
                }
                else
                {
                    Common.MessageBox.Show(this, "意外错误：未知错误!");
                }
            }
        }

        /// <summary>
        /// 管理列表
        /// </summary>
        /// <param name="PageIndex"></param>


        protected void VoteTitleManage(int PageIndex)//显示投票类别管理页面
        {
            #region 查询条件语句判断
            string KeyWord = Common.Input.Filter(this.KeyWord.Text.Trim());//取得关键字的内容
            string type = this.DdlKwdType.SelectedValue;//取得选择的类型
            int i = 0, j = 0;
            int num = 20;//从参数设置里取得每页显示记录的条数
            DataTable dt = null;

            if (KeyWord != "" && KeyWord != null)//如果关键字处内容不为空,则按下面选择语句进行条件判断并传值
            {
                switch (type)
                {
                    case "choose":
                        dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_1_aspx", PageIndex, num, out i, out j, null);//不跟条件进行查询，显示全部内容                   
                        break;
                    case "title":
                        SQLConditionInfo st = new SQLConditionInfo("@Title", "%" + KeyWord + "%");
                        dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_2_aspx", PageIndex, num, out i, out j, st);//按照主题名查询相关内容                   
                        break;
                    case "class":
                        DataTable dt1 = new DataTable();
                        dt1 = sur.sel_9(KeyWord);
                        if (dt1 != null)
                        {
                            if (dt1.Rows.Count > 0)
                            {
                                for (int l = 0; l < dt1.Rows.Count; l++)
                                {
                                    int Vid = int.Parse(dt1.Rows[l]["VID"].ToString());
                                    SQLConditionInfo st1 = new SQLConditionInfo("@VID", "%" + Vid + "%");
                                    dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_3_aspx", PageIndex, num, out i, out j, st1);//按照类名查询                              
                                }
                            }
                            else
                            {
                                dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_1_aspx", PageIndex, num, out i, out j, null);
                            }
                        }
                        else
                        {
                            dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_1_aspx", PageIndex, num, out i, out j, null);
                        }
                        break;
                    case "num":
                        SQLConditionInfo st2 = new SQLConditionInfo("@MaxNum", "%" + KeyWord + "%");
                        dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_4_aspx", PageIndex, num, out i, out j, st2);//按照最多数查询
                        break;
                    case "starttime":
                        SQLConditionInfo st3 = new SQLConditionInfo("@StartDate", "%" + KeyWord + "%");
                        dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_5_aspx", PageIndex, num, out i, out j, st3);//按照开始时间查询
                        break;
                    case "endtime":
                        SQLConditionInfo st4 = new SQLConditionInfo("@EndDate", "%" + KeyWord + "%");
                        dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_6_aspx", PageIndex, num, out i, out j, st4);//按照结束时间查询
                        break;
                    case "itemmodel":
                        SQLConditionInfo st5 = new SQLConditionInfo("@ItemMode", "%" + KeyWord + "%");
                        dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_7_aspx", PageIndex, num, out i, out j, st5); //按照排列方式查询
                        break;
                    default:
                        dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_1_aspx", PageIndex, num, out i, out j, null);
                        break;
                }
            }
            else
            {
                dt = Foosun.CMS.Pagination.GetPage("manage_survey_setTitle_1_aspx", PageIndex, num, out i, out j, null);
            }
            #endregion

            this.PageNavigator1.PageCount = j;
            this.PageNavigator1.PageIndex = PageIndex;
            this.PageNavigator1.RecordCount = i;
            DataTable dts = sur.sel_VoteClassSql();
            if (dts == null)
            {
                this.PageNavigator1.Visible = false;
            }
            else
            {

                if (dt != null)//判断如果dt里面没有内容，将不会显示
                {
                    if (dt.Rows.Count > 0)
                    {
                        //添加列
                        dt.Columns.Add("voteClass", typeof(String));//调查类别
                        dt.Columns.Add("type", typeof(String));//项目类型
                        dt.Columns.Add("displayModel", typeof(String));//显示方式
                        dt.Columns.Add("js", typeof(String));//js调用
                        dt.Columns.Add("oPerate", typeof(String));//操作

                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            int idv = int.Parse(dt.Rows[k]["VID"].ToString());
                            int idt = int.Parse(dt.Rows[k]["TID"].ToString());
                            int Type = int.Parse(dt.Rows[k]["Type"].ToString());//项目类型
                            int DisMode = int.Parse(dt.Rows[k]["DisMode"].ToString());//显示方式
                            //从调查类别表中取类别名
                            try
                            {
                                string VoteClassName = sur.sel_VoteClass_Sql(idv);//取得调查类别的值
                                dt.Rows[k]["voteClass"] = VoteClassName;//将查找出来的值传给调查类别栏
                            }
                            catch { }
                            switch (Type)
                            {
                                case 0:
                                    dt.Rows[k]["type"] = "单选";
                                    break;
                                case 1:
                                    dt.Rows[k]["type"] = "多选";
                                    break;
                            }
                            switch (DisMode)
                            {
                                case 0:
                                    dt.Rows[k]["displayModel"] = "柱形图";
                                    break;
                                default:
                                    dt.Rows[k]["displayModel"] = "柱形图";
                                    break;
                            }
                            dt.Rows[k]["Title"] = "<a href='settitle.aspx?type=edit&id=" + idt + "' class='xa3' title='点击查看详情或修改'>" + dt.Rows[k]["Title"].ToString() + "</a>";
                            dt.Rows[k]["js"] = "<a href=\"javascript:getjsCode(" + idt + ");\" class=\"xa3\">代码</a>";
                            dt.Rows[k]["oPerate"] = "<a href=\"settitle.aspx?type=edit&id=" + idt + "\"  class=\"xa3\" title=\"修改此项\">修改</a><a href=\"setTitle.aspx?type=delone&id=" + idt + "\"  class=\"xa3\" title=\"删除此项\" onclick=\"{if(confirm('确认删除吗？')){return true;}return false;}\">删除</a><input type='checkbox' name='vote_checkbox' id='vote_checkbox' value=\"" + idt + "\"/>";
                        }
                    }
                    else
                    {
                        this.PageNavigator1.Visible = false;
                    }
                }
                else
                {
                    this.PageNavigator1.Visible = false;
                }
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            VoteTitleManage(1);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        protected void DelP_Click(object sender, EventArgs e)
        {
            this.Authority_Code = "S005";
            this.CheckAdminAuthority();
            string vote_checkbox = Request.Form["vote_checkbox"];
            if (vote_checkbox == null || vote_checkbox == String.Empty)
            {
                Common.MessageBox.Show(this, "请先选择批量操作的内容!");
            }
            else
            {
                String[] CheckboxArray = vote_checkbox.Split(',');
                vote_checkbox = null;
                for (int i = 0; i < CheckboxArray.Length; i++)
                {
                    if (sur.Del_Vote_Sql_2(CheckboxArray[i]) != 0 && sur.Del_Str_itemSql_2(CheckboxArray[i]) != 0 && sur.Del_Str_stepSql_3(CheckboxArray[i]) != 0 && sur.Del_Str_manageSql_2(CheckboxArray[i]) != 0)
                    {
                        rd.SaveUserAdminLogs(1, 1, UserNum, "批量删除投票主题", "删除成功");
                    }
                }
                Common.MessageBox.ShowAndRedirect(this, "删除数据成功,请返回继续操作!", "setTitle.aspx");
            }
        }

        /// <summary>
        /// 新增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        protected void Savetitle_ServerClick(object sender, EventArgs e)
        {
            this.Authority_Code = "S005";
            this.CheckAdminAuthority();
            if (Page.IsValid)//判断页面是否通过验证
            {
                //取得投票参数设置添加中的表单信息
                string Str_Classname = this.vote_ClassName.SelectedValue;//调查类别
                string Str_Title = Common.Input.Filter(this.Title.Text);//类别名称
                string Str_TypeSelect = this.TypeSelect.SelectedValue;//项目类型
                string Str_MaxselectNum = Common.Input.Filter(this.MaxselectNum.Text);//最多选项个数
                string Str_DisModel = this.DisModel.SelectedValue;//显示方式
                string Str_Starttime = Common.Input.Filter(this.Starttime.Text);//开始时间
                string Str_Endtime = Common.Input.Filter(this.Endtime.Text);//结束时间
                string Str_SortStyle = this.SortStyle.SelectedValue;//排列方式
                string Str_isSteps = this.isSteps.Text;//是否允许多步投票

                //检查是否有已经存在的类别名称
                if (sur.sel_10(Str_Title) != 0)
                {
                    Common.MessageBox.ShowAndRedirect(this, "对不起，该主题已经存在!", "setTitle.aspx?type=add");
                }
                //检查主题名是否为空
                if (Str_Title == null || Str_Title == string.Empty)
                {
                    Common.MessageBox.ShowAndRedirect(this, "对不起，主题名称不能为空，请返回继续添加!", "setTitle.aspx");
                }
                //检查选项数是否为数字型
                if (Str_TypeSelect == "0")//如果是单选，则选项数最多为1
                {
                    Str_MaxselectNum = "1";
                }
                else//否则，是多选，则若输入不是数字,则出错,反之成功
                {
                    if (!Common.Input.IsInteger(Str_MaxselectNum))
                    {
                        Common.MessageBox.ShowAndRedirect(this, "对不起，选项数只能为数字型，请返回继续添加!", "setTitle.aspx");
                    }
                    else
                    {
                        //将输入的值赋给最多选项数
                        Str_MaxselectNum = Common.Input.Filter(this.MaxselectNum.Text);
                    }
                }
                //检查日期是否合法
                if (Common.Input.ChkDate(Str_Starttime) == false)
                {
                    Common.MessageBox.Show(this, "对不起，选项数只能为数字型，请返回继续添加!");
                    return;
                }
                if (Common.Input.ChkDate(Str_Endtime) == false)
                {
                    Common.MessageBox.Show(this, "对不起，选项数只能为数字型，请返回继续添加!");
                    return;
                }
                //向数据库中写入添加的类别信息

                //载入数据-刷新页面
                if (sur.Add_Str_InSql_2(Str_Classname, Str_Title, Str_TypeSelect, Str_MaxselectNum, Str_DisModel, Str_Starttime, Str_Endtime, Str_SortStyle, Str_isSteps, "0") != 0)
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "问卷调查系统新增主题", "问卷调查系统新增主题成功");
                    Common.MessageBox.ShowAndRedirect(this, "问卷调查系统新增主题成功!", "setTitle.aspx");
                }
                else
                {
                    Common.MessageBox.ShowAndRedirect(this, "意外错误：未知错误.或许是没找到记录!", "setTitle.aspx");
                }

            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        protected void Editsave_ServerClick(object sender, EventArgs e)
        {
            this.Authority_Code = "S005";
            this.CheckAdminAuthority();
            if (Page.IsValid)//判断页面是否通过验证
            {
                int TID = int.Parse(Request.QueryString["ID"]);
                //取得修改中的表单信息
                string Str_ClassNameE = Common.Input.Filter(this.ClassnameE.Text.Trim());
                string Str_TitleE = Common.Input.Filter(this.TitleE.Text.Trim());
                string Str_TypeE = Common.Input.Filter(this.TypeE.Text.Trim());
                string Str_MaxNumE = Common.Input.Filter(this.MaxNumE.Text.Trim());
                string Str_DisModelE = Common.Input.Filter(this.DisModelE.Text.Trim());
                string Str_StartTimeE = Common.Input.Filter(this.StartTimeE.Text.Trim());
                string Str_EndTimeE = Common.Input.Filter(this.EndTimeE.Text.Trim());
                string Str_StyleE = Common.Input.Filter(this.StyleE.Text.Trim());
                string Str_isSteps = Common.Input.Filter(this.isStepsE.Text.Trim());

                if (Str_TitleE == null || Str_TitleE == string.Empty)
                {
                    Common.MessageBox.ShowAndRedirect(this, "对不起，主题名称不能为空，请返回继续添加!", "setTitle.aspx");
                }
                //检查选项数是否为数字型
                if (!Common.Input.IsInteger(Str_MaxNumE))
                {
                    Common.MessageBox.Show(this, "对不起，选项数只能为数字型，请返回继续添加!");
                    return;
                }
                //检查日期是否合法
                if (Common.Input.ChkDate(Str_StartTimeE) == false)
                {
                    Common.MessageBox.Show(this, "对不起，选项数只能为数字型，请返回继续添加!");
                    return;
                }
                if (Common.Input.ChkDate(Str_EndTimeE) == false)
                {
                    Common.MessageBox.ShowAndRedirect(this, "对不起，日期格式不正确，请返回继续添加!", "setTitle.aspx");
                }
                //刷新页面
                if (sur.Update_Str_UpdateSqls(Str_ClassNameE, Str_TitleE, Str_TypeE, Str_MaxNumE, Str_DisModelE, Str_StartTimeE, Str_EndTimeE, Str_StyleE, Str_isSteps, TID) != 0)
                {
                    rd.SaveUserAdminLogs(1, 1, UserNum, "问卷调查系统修改主题", "修改成功");
                    Common.MessageBox.ShowAndRedirect(this, "修改成功!", "setTitle.aspx");
                }
                else
                {
                    Common.MessageBox.Show(this, "意外错误：未知错误,可能是没找到记录!");
                }

            }
        }

        /// <summary>
        /// 删除全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DelAll_Click(object sender, EventArgs e)
        {
            this.Authority_Code = "S005";
            this.CheckAdminAuthority();
            if (sur.Del_8() == 0)
            {
                Common.MessageBox.Show(this, "意外错误：未知错误,可能是没找到记录!");
            }
            else
            {
                rd.SaveUserAdminLogs(1, 1, UserNum, "删除全部投票主题成功", "删除全部成功");
                Common.MessageBox.ShowAndRedirect(this, "删除全部成功!", "setTitle.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.news
{
    public partial class HistoryManage :Foosun.PageBasic.ManagePage
    {
        public HistoryManage()
        {
            Authority_Code = "C048";
        }
        News ns = new News();
        RootPublic log = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 分页调用函数
            this.PageNavigator1.OnPageChange += new PageChangeHandler(PageNavigator1_PageChange);
            #endregion
            Response.CacheControl = "no-cache";//设置页面无缓存
            HistoryManageList(1);//分页初始值
        }
	#region 管理页面分页查询
	protected void PageNavigator1_PageChange(object sender, int PageIndex) {
		HistoryManageList(PageIndex);
	}
	#endregion

	/// <summary>
	/// 归档管理页面
	/// </summary>
	protected void HistoryManageList(int PageIndex) {
		int i, j;
		DataTable dt = Foosun.CMS.Pagination.GetPage("manage_news_History_Manage_aspx", PageIndex, 20, out i, out j, null);
		this.PageNavigator1.PageCount = j;
		this.PageNavigator1.PageIndex = PageIndex;
		this.PageNavigator1.RecordCount = i;

		#region 判断如果dt里面没有内容，将不会显示
		if (dt != null) {
			if (dt.Rows.Count > 0) {
				dt.Columns.Add("Type", typeof(String));//类型
				dt.Columns.Add("table", typeof(String));//所属表
				dt.Columns.Add("stat", typeof(String));//状态
				dt.Columns.Add("oPerate", typeof(String));//操作
				for (int k = 0; k < dt.Rows.Count; k++) {
					int id = int.Parse(dt.Rows[k]["id"].ToString());
					string NewsType = dt.Rows[k]["NewsType"].ToString();
					string islock = dt.Rows[k]["isLock"].ToString();
					string DataLib = dt.Rows[k]["DataLib"].ToString();
					#region 判断新闻的类型，以区分不同
					switch (NewsType) {
						case "0":
							dt.Rows[k]["Type"] = "普通";
							break;
						case "1":
							dt.Rows[k]["Type"] = "图片";
							break;
						case "2":
							dt.Rows[k]["Type"] = "标题";
							break;
						default:
							dt.Rows[k]["Type"] = "普通";
							break;
					}
					#endregion
					#region 判断新闻所属表
					dt.Rows[k]["table"] = DataLib;
					#endregion
					#region 新闻锁定状态
					switch (islock) {
						case "0":
                            dt.Rows[k]["stat"] = "<img src=\"../imges/lie_61.gif\" border=\"0\">";
							break;
						case "1":
                            dt.Rows[k]["stat"] = "<img src=\"../imges/lie_65.gif\" border=\"0\">";
							break;
						default:
                            dt.Rows[k]["stat"] = "<img src=\"../imges/lie_61.gif\" border=\"0\">";
							break;
					}
					#endregion
					#region 复选框操作
					dt.Rows[k]["oPerate"] = "<input type='checkbox' name='Checkbox1',id='Checkbox1' value=\"" + id + "\"/>";
					#endregion
				}
				DataList1.DataSource = dt;
				DataList1.DataBind();
			}
			else {
				NoContent.InnerHtml = Show_NoContent();
				this.PageNavigator1.Visible = false;
			}
		}
		else {
			NoContent.InnerHtml = Show_NoContent();
			this.PageNavigator1.Visible = false;
		}
	}
		#endregion

	/// <summary>
	/// 批量删除
	/// </summary>
	protected void Del_ClickP(object sender, EventArgs e) {
		this.Authority_Code = "C049";
		this.CheckAdminAuthority();
		string Checkbox1 = Request.Form["Checkbox1"];
		if (Checkbox1 == null || Checkbox1 == string.Empty) {           
            Common.MessageBox.Show(this, "请先选择删除操作的新闻!", "提示", "");
		}
		else {
            if (ns.DelOld(Checkbox1) == 0)
            {
                log.SaveUserAdminLogs(1, 1, UserNum, "新闻数据删除失败", "新闻数据删除失败");
                Common.MessageBox.Show(this, "新闻数据删除失败,请与管理联系!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");
            }
            else
            {
                log.SaveUserAdminLogs(1, 1, UserNum, "新闻数据删除成功", "新闻数据删除成功");
                Common.MessageBox.Show(this, "新闻数据删除成功!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");                
            }
		}
	}
	/// <summary>
	/// 批量锁定
	/// </summary>
	protected void Suo_ClickP(object sender, EventArgs e) {
		this.Authority_Code = "C049";
		this.CheckAdminAuthority();
		string Checkbox1 = Request.Form["Checkbox1"];
		if (Checkbox1 == null || Checkbox1 == string.Empty) {
            Common.MessageBox.Show(this, "请先选择锁定操作的新闻!", "提示", "");
		}
		else 
        {          
            if (ns.UpdateOld(Checkbox1, 1, "1", "isLock") == 0)
            {
                Common.MessageBox.Show(this, "新闻数据锁定失败,请与管理联系!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");
            }
            else
            {
                log.SaveUserAdminLogs(1, 1, UserNum, "新闻数据锁定成功", "新闻数据锁定成功");
                Common.MessageBox.Show(this, "新闻数据锁定成功!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");
            }
		}
	}
	/// <summary>
	/// 批量解锁
	/// </summary>
	protected void Unsuo_ClickP(object sender, EventArgs e) {
		this.Authority_Code = "C049";
		this.CheckAdminAuthority();
		string Checkbox1 = Request.Form["Checkbox1"];
		if (Checkbox1 == null || Checkbox1 == string.Empty) {
            Common.MessageBox.Show(this, "请先选择解锁操作的新闻!", "提示", "");
		}
        else
        {
            if (ns.UpdateOld(Checkbox1, 1, "0", "isLock") == 0)
            {
                Common.MessageBox.Show(this, "新闻数据解锁失败,请与管理联系!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");
            }
            {
                log.SaveUserAdminLogs(1, 1, UserNum, "新闻数据解锁成功", "新闻数据解锁成功");
                Common.MessageBox.Show(this, "新闻数据解锁成功!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");
            }
        }
	}
	/// <summary>
	/// 生成索引
	/// </summary>
    protected void Index_ClickP(object sender, EventArgs e)
    {
        this.Authority_Code = "C049";
        this.CheckAdminAuthority();
        Common.HProgressBar.Start();
        int getHistoryNum = int.Parse(Common.Public.readparamConfig("HistoryNum"));
        try
        {
            Common.HProgressBar.Roll("正在发布索引", 0);
            int m = 0;
            int j = 0;
            for (int i = 0; i < getHistoryNum; i++)
            {
                if (Foosun.Publish.General.PublishHistryIndex(i))
                {
                    m++;
                }
                else
                {
                    j++;
                }
                Common.HProgressBar.Roll("正在发布第" + i + "天,共" + getHistoryNum + ",失败" + j + "个(可能当天没归档新闻。)", ((i + 1) * 100 / getHistoryNum));
            }
            Common.HProgressBar.Roll("发布索引成功, 共" + getHistoryNum + ",失败" + j + "个(可能当天没归档新闻。). &nbsp;<a href=\"history_Manage.aspx\">返回</a>", 100);
        }
        catch (Exception ex)
        {
            Common.Public.savePublicLogFiles("□□□发布索引", "【错误描述：】\r\n" + ex.ToString(), UserName);
            Common.HProgressBar.Roll("发布索引失败。<a href=\"error/geterror.aspx?\">查看日志</a>", 0);
        }
        Response.End();
    }

	/// <summary>
	/// 删除全部
	/// </summary>
	protected void DelAll_ClickP(object sender, EventArgs e) {
		this.Authority_Code = "C049";
		this.CheckAdminAuthority();
		int delap = ns.DelOld();
		if (delap == 0) {
			log.SaveUserAdminLogs(1, 1, UserNum, "删除全部归档新闻", "新闻数据全部删除失败");
            Common.MessageBox.Show(this, "新闻数据全部删除失败,请与管理联系!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");
		}
		log.SaveUserAdminLogs(1, 1, UserNum, "删除全部归档新闻", "新闻数据全部删除成功");
        Common.MessageBox.Show(this, "新闻数据全部删除成功!", "提示", "__doPostBack('PageNavigator1$LnkBtnGoto', '');");
	}

	/// <summary>
	/// 提示无内容显示信息
	/// </summary>
	string Show_NoContent() {

		string nos = "<table border=0 width='98%' align=center cellpadding=5 cellspacing=1 class='table'>";
		nos = nos + "<tr>";
		nos = nos + "<td>当前没有被归档的新闻！</td>";
		nos = nos + "</tr>";
		nos = nos + "</table>";
		return nos;
	}
    }
}
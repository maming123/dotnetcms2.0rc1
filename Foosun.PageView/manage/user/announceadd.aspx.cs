using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using Common;
using System.Data;

namespace Foosun.PageView.manage.user
{
    public partial class announceadd : Foosun.PageBasic.ManagePage
    {
        UserMisc rd = new UserMisc();
        RootPublic pd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            if (!IsPostBack)
            {

                //copyright.InnerHtml = CopyRight;
                #region 为表单赋值
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    Authority_Code = "U022";
                    this.CheckAdminAuthority();
                    int aId = 0;
                    try
                    {
                        aId = int.Parse(Common.Input.Filter(Request.QueryString["id"]));
                        DataTable dt = rd.getAnnounceEdit(aId);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                this.title.Text = dt.Rows[0]["title"].ToString();
                                this.content.Value = dt.Rows[0]["content"].ToString();
                                this.getPoint.Text = dt.Rows[0]["getpoint"].ToString();
                                GroupList.InnerHtml = groupliststr(dt.Rows[0]["GroupNumber"].ToString());
                                this.aId.Value = dt.Rows[0]["id"].ToString();
                            }
                        }
                    }
                    catch (Exception AX)
                    {
                        PageError("错误的参数。<li>" + AX + "</li>", "");
                    }
                }
                else
                {
                    Authority_Code = "U020";
                    this.CheckAdminAuthority();
                    GroupList.InnerHtml = groupliststr("");
                }
                #endregion 为表单赋值
            }

           
        }
        string groupliststr(string GroupNumber)
        {
            string _str = "<select Name=\"GroupNumber\" class=\"select4\">";
            _str += "<option value=\"\">设置会员组浏览权限</option>";
            IDataReader dr = pd.GetGroupList();
            while (dr.Read())
            {
                if (GroupNumber.ToString() == dr["GroupNumber"].ToString()&&GroupNumber!="")
                {
                    _str += "<option value=\"" + dr["GroupNumber"].ToString() + "\" selected>" + dr["GroupName"].ToString() + "</option>";
                }
                else
                {
                    _str += "<option value=\"" + dr["GroupNumber"].ToString() + "\">" + dr["GroupName"].ToString() + "</option>";
                }
            }
            dr.Close();
            _str += "</select>";
            return _str;
        }
        /// <summary>
        /// sumbitsave 的摘要说明
        /// 数据提交入数据库
        /// </summary>
        protected void sumbitsave(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string TxtTitle = this.title.Text;
                string TxtContent = this.content.Value;
                string TxtGroupNumber = Request.Form["GroupNumber"];
                string TxtgetPoint = this.getPoint.Text;
                DateTime DateCreatTime = System.DateTime.Now;
                if (TxtgetPoint.IndexOf("|") == -1)
                {
                    PageError("点数/条件 格式为：1|1|0 格式<br />", "announce.aspx");
                }
                if (TxtTitle.ToString() != "" && TxtTitle.ToString() != null)
                {
                    string ramAID;
                    ramAID = Rand.Number(12);//产生12位随机字符
                    Foosun.Model.UserInfo5 uc = new Foosun.Model.UserInfo5();
                   
                    uc.Title = TxtTitle;
                    uc.content = TxtContent;
                  
                    uc.GroupNumber = TxtGroupNumber;
                    uc.getPoint = TxtgetPoint;
                    uc.SiteId = Foosun.Global.Current.SiteID;
                    string aid = aId.Value;
                    if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString () != "")
                    {
                        uc.Id = int.Parse(aId.Value);
                        rd.UpdateAnnounce(uc);
                        PageRight("修改公告成功成功。", "announce.aspx");
                    }
                    else
                    {
                        uc.newsID = ramAID;
                        uc.creatTime = DateCreatTime;
                        rd.InsertAnnounce(uc);
                        PageRight("创建公告成功成功。", "announce.aspx");
                    }
                   
                    
                }
                else
                {
                    PageError("请填写公告标题", "");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;
using Common;

namespace Foosun.PageView.manage.user
{
    public partial class usergroupadd : Foosun.PageBasic.ManagePage
    {
        public usergroupadd(){       
        }
        UserMisc rd = new UserMisc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].Trim() != "")
                {
                    Authority_Code = "U013";
                    this.CheckAdminAuthority();
                    int gid = 0;
                    try
                    {
                        gid = int.Parse(Common.Input.Filter(Request.QueryString["id"].Trim()));
                        DataTable dt = rd.getGroupEdit(gid);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                #region 为表单赋值
                                this.GroupName.Text = dt.Rows[0]["GroupName"].ToString();
                                this.iPoint.Text = dt.Rows[0]["iPoint"].ToString();
                                this.gPoint.Text = dt.Rows[0]["gPoint"].ToString();
                                this.Rtime.Text = dt.Rows[0]["Rtime"].ToString();
                                this.LenCommContent.Text = dt.Rows[0]["LenCommContent"].ToString();
                                CommCheckTF.SelectedValue = dt.Rows[0]["CommCheckTF"].ToString();                              
                                this.PostCommTime.Text = dt.Rows[0]["PostCommTime"].ToString();
                                this.upfileType.Text = dt.Rows[0]["upfileType"].ToString();
                                this.upfileNum.Text = dt.Rows[0]["upfileNum"].ToString();
                                this.upfileSize.Text = dt.Rows[0]["upfileSize"].ToString();
                                this.DayUpfilenum.Text = dt.Rows[0]["DayUpfilenum"].ToString();
                                this.ContrNum.Text = dt.Rows[0]["ContrNum"].ToString();
                                this.DicussTF.SelectedValue = dt.Rows[0]["DicussTF"].ToString();
                                this.PostTitle.SelectedValue = dt.Rows[0]["PostTitle"].ToString();
                                this.ReadUser.SelectedValue = dt.Rows[0]["ReadUser"].ToString();
                                
                                this.MessageNum.Text = dt.Rows[0]["MessageNum"].ToString();

                                this.MessageGroupNum.Text = dt.Rows[0]["MessageGroupNum"].ToString();
                                this.IsCert.SelectedValue = dt.Rows[0]["IsCert"].ToString();
                                this.CharTF.SelectedValue = dt.Rows[0]["CharTF"].ToString();
                                this.CharHTML.SelectedValue = dt.Rows[0]["CharHTML"].ToString();
                               
                                this.CharLenContent.Text = dt.Rows[0]["CharLenContent"].ToString();
                                this.RegMinute.Text = dt.Rows[0]["RegMinute"].ToString();
                                this.PostTitleHTML.SelectedValue = dt.Rows[0]["PostTitleHTML"].ToString();
                                this.DelSelfTitle.SelectedValue = dt.Rows[0]["DelSelfTitle"].ToString();
                                this.DelOTitle.SelectedValue = dt.Rows[0]["DelOTitle"].ToString();
                                this.EditSelfTitle.SelectedValue = dt.Rows[0]["EditSelfTitle"].ToString();
                                this.EditOtitle.SelectedValue = dt.Rows[0]["EditOtitle"].ToString();
                                this.ReadTitle.SelectedValue = dt.Rows[0]["ReadTitle"].ToString();
                                this.MoveSelfTitle.SelectedValue = dt.Rows[0]["MoveSelfTitle"].ToString();
                                this.MoveOTitle.SelectedValue = dt.Rows[0]["MoveOTitle"].ToString();
                                this.TopTitle.SelectedValue = dt.Rows[0]["TopTitle"].ToString();
                                this.GoodTitle.SelectedValue = dt.Rows[0]["GoodTitle"].ToString();
                                this.LockUser.SelectedValue = dt.Rows[0]["LockUser"].ToString();
                                
                                this.UserFlag.Text = dt.Rows[0]["UserFlag"].ToString();
                                this.CheckTtile.SelectedValue = dt.Rows[0]["CheckTtile"].ToString();
                                this.IPTF.SelectedValue = dt.Rows[0]["IPTF"].ToString();
                                this.EncUser.SelectedValue = dt.Rows[0]["EncUser"].ToString();
                                this.OCTF.SelectedValue = dt.Rows[0]["OCTF"].ToString();
                                this.StyleTF.SelectedValue = dt.Rows[0]["StyleTF"].ToString();

                                this.UpfaceSize.Text = dt.Rows[0]["UpfaceSize"].ToString();
                                this.GIChange.Text = dt.Rows[0]["GIChange"].ToString();
                                this.GTChageRate.Text = dt.Rows[0]["GTChageRate"].ToString();
                                this.LoginPoint.Text = dt.Rows[0]["LoginPoint"].ToString();
                                this.RegPoint.Text = dt.Rows[0]["RegPoint"].ToString();
                                this.GroupTF.SelectedValue = dt.Rows[0]["GroupTF"].ToString();

                                this.GroupSize.Text = dt.Rows[0]["GroupSize"].ToString();
                                this.GroupPerNum.Text = dt.Rows[0]["GroupPerNum"].ToString();
                                this.GroupCreatNum.Text = dt.Rows[0]["GroupCreatNum"].ToString();
                                this.gids.Value = dt.Rows[0]["id"].ToString();
                                this.Discount.Text = dt.Rows[0]["Discount"].ToString();
                                #endregion 为表单赋值
                            }
                        }
                    }
                    catch (Exception GS)
                    {
                        PageError("参数传递错误<li>" + GS.ToString() + "</li>", "");
                    }
                }
                else
                {
                    Authority_Code = "U012";
                    this.CheckAdminAuthority();
                }
            }
           
        }

        protected void sumbitsave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                #region 获取表单值
                string TxtGroupName = GroupName.Text;
                int intiPoint = 0, intgPoint = 0, intLenCommContent = 0, intCommCheckTF = 0, intPostCommTime = 0, intupfileNum = 0, intupfileSize = 0, intDayUpfilenum = 0, intContrNum = 0, intDicussTF = 0, intPostTitle = 0, intReadUser = 0, intMessageNum = 0, intIsCert = 0, intCharTF = 0, intCharHTML = 0, intCharLenContent = 0, intRegMinute = 0, intPostTitleHTML = 0, intDelSelfTitle = 0, intDelOTitle = 0, intEditSelfTitle = 0, intEditOtitle = 0, intReadTitle = 0, intMoveSelfTitle = 0, intMoveOTitle = 0, intTopTitle = 0, intGoodTitle = 0, intLockUser = 0, intGroupTF = 0, intGroupSize = 0, intGroupPerNum = 0, intGroupCreatNum = 0, intCheckTtile = 0, intIPTF = 0, intEncUser = 0, intOCTF = 0, intStyleTF = 0, intUpfaceSize = 0, intRtime = 0;
                string TxtupfileType = this.upfileType.Text;
                string TxtUserFlag = this.UserFlag.Text;
                string TxtGTChageRate = this.GTChageRate.Text;
                string TxtMessageGroupNum = this.MessageGroupNum.Text;
                string TxtLoginPoint = this.LoginPoint.Text;
                string TxtRegPoint = this.RegPoint.Text;
                string TxtGIChange = this.GIChange.Text;
                double Discount = 0;
                try
                {
                    intiPoint = int.Parse(this.iPoint.Text);
                    intgPoint = int.Parse(this.gPoint.Text);
                    intRtime = int.Parse(this.Rtime.Text);
                    intLenCommContent = int.Parse(this.LenCommContent.Text);
                    intCommCheckTF = int.Parse(this.CommCheckTF.SelectedValue);
                    intPostCommTime = int.Parse(this.PostCommTime.Text);
                    intupfileNum = int.Parse(this.upfileNum.Text);
                    intupfileSize = int.Parse(this.upfileSize.Text);
                    intDayUpfilenum = int.Parse(this.DayUpfilenum.Text);
                    intContrNum = int.Parse(this.ContrNum.Text);
                    intDicussTF = int.Parse(this.DicussTF.SelectedValue);
                    intPostTitle = int.Parse(this.PostTitle.SelectedValue);
                    intReadUser = int.Parse(this.ReadUser.SelectedValue);
                    intMessageNum = int.Parse(this.MessageNum.Text);
                    intIsCert = int.Parse(this.IsCert.SelectedValue);
                    intCharTF = int.Parse(this.CharTF.SelectedValue);
                    intCharHTML = int.Parse(this.CharHTML.SelectedValue);
                    intCharLenContent = int.Parse(this.CharLenContent.Text);
                    intRegMinute = int.Parse(this.RegMinute.Text);
                    intPostTitleHTML = int.Parse(this.PostTitleHTML.SelectedValue);
                    intDelSelfTitle = int.Parse(this.DelSelfTitle.SelectedValue);
                    intDelOTitle = int.Parse(this.DelOTitle.SelectedValue);
                    intEditSelfTitle = int.Parse(this.EditSelfTitle.SelectedValue);
                    intEditOtitle = int.Parse(this.EditOtitle.SelectedValue);
                    intReadTitle = int.Parse(this.ReadTitle.SelectedValue);
                    intMoveSelfTitle = int.Parse(this.MoveSelfTitle.SelectedValue);
                    intMoveOTitle = int.Parse(this.MoveOTitle.SelectedValue);
                    intTopTitle = int.Parse(this.TopTitle.SelectedValue);
                    intGoodTitle = int.Parse(this.GoodTitle.SelectedValue);
                    intLockUser = int.Parse(this.LockUser.SelectedValue);
                    intCheckTtile = int.Parse(this.CheckTtile.SelectedValue);
                    intIPTF = int.Parse(this.IPTF.SelectedValue);
                    intEncUser = int.Parse(this.EncUser.SelectedValue);
                    intOCTF = int.Parse(this.OCTF.SelectedValue);
                    intStyleTF = int.Parse(this.StyleTF.SelectedValue);
                    intUpfaceSize = int.Parse(this.UpfaceSize.Text);
                    intGroupTF = int.Parse(this.GroupTF.SelectedValue);
                    intGroupSize = int.Parse(this.GroupSize.Text);
                    intGroupPerNum = int.Parse(this.GroupPerNum.Text);
                    intGroupCreatNum = int.Parse(this.GroupCreatNum.Text);
                    Discount = double.Parse(this.Discount.Text);
                }

                catch (Exception getvalue)
                {
                    PageError("请正确填写数字类型<li>" + getvalue.ToString() + "</li>", "");
                }
                #endregion 获取表单值
                #region 更新数据
                Foosun.Model.UserInfo4 uc1 = new Foosun.Model.UserInfo4();
                uc1.GroupName = TxtGroupName;
                uc1.iPoint = intiPoint;
                uc1.Gpoint = intgPoint;
                uc1.Rtime = intRtime;
                uc1.LenCommContent = intLenCommContent;
                uc1.CommCheckTF = intCommCheckTF;
                uc1.PostCommTime = intPostCommTime;
                uc1.upfileType = TxtupfileType;
                uc1.upfileNum = intupfileNum;
                uc1.upfileSize = intupfileSize;
                uc1.DayUpfilenum = intDayUpfilenum;
                uc1.ContrNum = intContrNum;
                uc1.DicussTF = intDicussTF;
                uc1.PostTitle = intPostTitle;
                uc1.ReadUser = intReadUser;
                uc1.MessageNum = intMessageNum;
                uc1.MessageGroupNum = TxtMessageGroupNum;
                uc1.IsCert = intIsCert;
                uc1.CharTF = intCharTF;
                uc1.CharHTML = intCharHTML;
                uc1.CharLenContent = intCharLenContent;
                uc1.RegMinute = intRegMinute;
                uc1.PostTitleHTML = intPostTitleHTML;
                uc1.DelSelfTitle = intDelSelfTitle;
                uc1.DelOTitle = intDelOTitle;
                uc1.EditSelfTitle = intEditSelfTitle;
                uc1.EditOtitle = intEditOtitle;
                uc1.ReadTitle = intReadTitle;
                uc1.MoveSelfTitle = intMoveSelfTitle;
                uc1.MoveOTitle = intMoveOTitle;
                uc1.TopTitle = intTopTitle;
                uc1.GoodTitle = intGoodTitle;
                uc1.LockUser = intLockUser;
                uc1.UserFlag = TxtUserFlag;
                uc1.CheckTtile = intCheckTtile;
                uc1.IPTF = intIPTF;
                uc1.EncUser = intEncUser;
                uc1.OCTF = intOCTF;
                uc1.StyleTF = intStyleTF;
                uc1.UpfaceSize = intUpfaceSize;
                uc1.GIChange = TxtGIChange;
                uc1.GTChageRate = TxtGTChageRate;
                uc1.LoginPoint = TxtLoginPoint;
                uc1.RegPoint = TxtRegPoint;
                uc1.GroupTF = intGroupTF;
                uc1.GroupSize = intGroupSize;
                uc1.GroupPerNum = intGroupPerNum;
                uc1.GroupCreatNum = intGroupCreatNum;
                uc1.Discount = Discount;
                if (gids.Value != "")
                {
                    uc1.gID = int.Parse(gids.Value);
                    rd.updateGroupEdit(uc1);
                    PageRight("更新会员组 [" + TxtGroupName + "] 成功！。", "usergroup.aspx");
                }
                else
                {
                    string SessionSiteID = Foosun.Global.Current.SiteID;
                    string ramGroupNumber;
                Num: ramGroupNumber = Rand.Number(12);//产生12位随机字符
                    DataTable udt = rd.GetGroupNumber(ramGroupNumber);
                    if (udt != null)
                    {
                        if (udt.Rows.Count > 0)
                        {
                            goto Num;
                        }
                        udt.Clear(); udt.Dispose();
                    }
                    uc1.SiteID = SessionSiteID;
                    uc1.GroupNumber = ramGroupNumber;
                    DateTime dateNowstr = System.DateTime.Now;
                    uc1.CreatTime = dateNowstr;
                    rd.InsertGroup(uc1);
                    PageRight("创建会员组成功。", "usergroup.aspx");
                }
                #endregion 更新数据
            }
        }

    }
}
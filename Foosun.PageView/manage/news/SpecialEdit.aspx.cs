using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Foosun.CMS;

public partial class SpecialEdit : Foosun.PageBasic.ManagePage
{
    public SpecialEdit()
    {
        Authority_Code = "C039";
    }
    public string fileexname = "";
    Foosun.CMS.DropTemplet DropTempletCMS = new DropTemplet();
    Foosun.CMS.NewsSpecial NewsSpecialCMS = new Foosun.CMS.NewsSpecial();
    Foosun.CMS.sys param = new Foosun.CMS.sys();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region 模版加载
            string publishType = param.GetParamBase("publishType");
            if (publishType == "0")
            {
                labelTemplet.Style.Add("display", "block");
                dropTemplet.Style.Add("display", "none");
            }
            else
            {
                labelTemplet.Style.Add("display", "none");
                dropTemplet.Style.Add("display", "block");
            }
            #endregion
            //copyright.InnerHtml = CopyRight;            //获取版权信息
            GetSpeacilInfo();
        }
    }

    /// <summary>
    /// 取得此条记录并在前台呈现出来
    /// </summary>
    /// <returns>取得此条记录并在前台呈现出来</returns>
    protected void GetSpeacilInfo()
    {
        string ID = Common.Input.checkID(Request.QueryString["ID"]);

        Foosun.Model.NewsSpecial NewsSpecialModel = NewsSpecialCMS.GetModel(ID);

        if (NewsSpecialModel != null)
        {
            SpaecilID.Value = NewsSpecialModel.SpecialID;
            S_Cname.Text = NewsSpecialModel.SpecialCName;
            S_Ename.Text = NewsSpecialModel.specialEName;
            S_Parent.Text = NewsSpecialModel.ParentID;
            if (NewsSpecialModel.ParentID != "0")
            {
                this.S_ParentName.Text = NewsSpecialCMS.GetModel(NewsSpecialModel.ParentID).SpecialCName;
            }
            else
            {
                this.S_ParentName.Text = "根专题";
            }
            S_Domain.Text = NewsSpecialModel.Domain;
            S_FileExname.Text = NewsSpecialModel.FileEXName;

            string str_UesrGroup = NewsSpecialModel.GroupNumber;
            string[] arr_UserGroup = str_UesrGroup.Split(',');

            RootPublic RootPublicCMS = new RootPublic();
            IDataReader rd = RootPublicCMS.GetGroupList();
            ListItem defaultitm = new ListItem();
            defaultitm.Value = "0";
            defaultitm.Text = "请选择会员组";
            S_UserGroup.Items.Add(defaultitm);
            while (rd.Read())
            {
                ListItem itm = new ListItem();
                itm.Text = rd["GroupName"].ToString();
                itm.Value = rd["GroupNumber"].ToString();
                for (int j = 0; j < arr_UserGroup.Length; j++)
                {
                    if (arr_UserGroup[j].ToString() == rd["GroupNumber"].ToString())
                    {
                        itm.Selected = true;
                    }
                }
                S_UserGroup.Items.Add(itm);
            }
            rd.Close();
            fileexname = NewsSpecialModel.FileEXName;

            S_IsDel.Text = NewsSpecialModel.isDelPoint.ToString();
            S_Point.Text = NewsSpecialModel.iPoint.ToString();
            S_Money.Text = NewsSpecialModel.Gpoint.ToString();
            S_DirRule.Text = NewsSpecialModel.saveDirPath;
            S_FileRule.Text = NewsSpecialModel.FileName;
            S_SavePath.Text = NewsSpecialModel.SavePath;

            S_Pic.Text = NewsSpecialModel.NaviPicURL;
            S_Text.Text = NewsSpecialModel.NaviContent;
            S_Templet.Text = NewsSpecialModel.Templet;
            dTemplet.Text = DropTempletCMS.GetSpecialTemplet(ID);

            S_Page.Text = NewsSpecialModel.NaviPosition;
        }
        else
        {
            Common.MessageBox.ShowAndRedirect(this, "参数传递错误!", "SpecialList.aspx");
        }
    }

    /// <summary>
    /// 修改专题信息开始
    /// </summary>
    /// <returns>修改专题信息开始</returns>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //---------------------------取得表单值

        Foosun.Model.NewsSpecial NewsSpecialModel = new Foosun.Model.NewsSpecial();
        NewsSpecialModel.SpecialID = Request.Form["SpaecilID"];            //专题编号
        NewsSpecialModel.SpecialCName = Request.Form["S_Cname"];           //中文名
        NewsSpecialModel.specialEName = "";
        NewsSpecialModel.Domain = Request.Form["S_Domain"];                //域名
        NewsSpecialModel.FileEXName = Request.Form["S_FileExname"];        //生成文件的扩展名

        if (Request.Form["isTrue"] == "1")                    //是否启用浏览权限控制
        {
            NewsSpecialModel.GroupNumber = Request.Form["S_UserGroup"] + "";    //可浏览用户组
            NewsSpecialModel.isDelPoint = int.Parse(Request.Form["S_IsDel"]);  //是否启用扣取与所需
            NewsSpecialModel.iPoint = int.Parse(Request.Form["S_Point"]);      //点数
            NewsSpecialModel.Gpoint = int.Parse(Request.Form["S_Money"]);      //金币
        }
        else
        {
            NewsSpecialModel.GroupNumber = "0";
            NewsSpecialModel.isDelPoint = 0;  //是否启用扣取与所需
            NewsSpecialModel.iPoint = 0;      //点数
            NewsSpecialModel.Gpoint = 0;      //金币
        }
        //英文名
        string enNames = this.S_Ename.Text;

        string fileNames = Foosun.CMS.CommStr.FileRandName(Request.Form["S_FileRule"]);      //文件名生成规则
        string f_name = Regex.Replace(fileNames, "{@EName}", enNames);

        NewsSpecialModel.saveDirPath = Foosun.CMS.CommStr.FileRandName(Request.Form["S_DirRule"]);    //目录生成规则
        NewsSpecialModel.FileName = f_name;      //文件名生成规则
        NewsSpecialModel.SavePath = Request.Form["S_SavePath"];            //保存路径

        NewsSpecialModel.NaviPicURL = Request.Form["S_Pic"];               //导航图片路径
        NewsSpecialModel.NaviContent = Request.Form["S_Text"];             //导航文字
        NewsSpecialModel.Templet = Request.Form["S_Templet"];              //专题模板路径
        NewsSpecialModel.NaviPosition = Request.Form["S_Page"];            //页面导航条

        NewsSpecialModel.SiteID = SiteID;
        NewsSpecialModel.CreatTime = DateTime.Now;
        NewsSpecialModel.isRecyle = 0;
        NewsSpecialModel.ParentID = "";

        bool result = NewsSpecialCMS.Update(NewsSpecialModel);
        //清除缓存
        if (result)
        {
            DropTempletCMS.DeleteTemplet(Request.Form["SpaecilID"], "2");
            DropTempletCMS.UpdateTemplet(Request.Form["SpaecilID"], Request.Form["dTemplet"], "", "2");
            Common.MessageBox.ShowAndRedirect(this, "修改专题信息成功!", "SpecialList.aspx");
        }
        else
            Common.MessageBox.Show(this, "修改专题信息失败!");
    }

    /// <summary>
    /// 显示前台JS效果,如果是.aspx后缀名就显示浏览权限选项.
    /// </summary>
    /// <returns>显示前台JS效果</returns>
    protected void Show()
    {
        if (fileexname == ".aspx")
        {
            Response.Write("<script language=\"javascript\">Hide('.aspx');</script>");
        }
    }
}

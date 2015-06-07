using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Foosun.CMS;

public partial class SpecialAdd : Foosun.PageBasic.ManagePage
{
    public SpecialAdd()
    {
        Authority_Code = "C099";
    }
    Foosun.CMS.NewsSpecial NewsSpecialCMS = new Foosun.CMS.NewsSpecial();
    public string DirHtml = Foosun.Config.UIConfig.dirHtml;
    Foosun.CMS.sys param = new Foosun.CMS.sys();
    Foosun.CMS.DropTemplet DropTempletCMS = new DropTemplet();
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
            
            if (SiteID != "0"){DirHtml = Foosun.Config.UIConfig.dirSite;}
            string parentID = Request.QueryString["parentID"];
            RootPublic RootPublicCMS = new RootPublic();
            IDataReader dr = RootPublicCMS.GetGroupList();
            while (dr.Read())
            {
                ListItem it = new ListItem();
                it.Value = dr["GroupNumber"].ToString();
                it.Text = dr["GroupName"].ToString();
                S_UserGroup.Items.Add(it);
            }
            dr.Close();
            ListItem itm = new ListItem();
            itm.Value = "0";
            itm.Text = "请选择会员组";
            //itm.Selected = true;
            S_UserGroup.Items.Insert(0, itm);
            itm = null; 
            if (parentID != null && parentID != "")
            {
                this.S_Parent.Text = parentID.ToString();
                Foosun.Model.NewsSpecial NewsSpecialModel = NewsSpecialCMS.GetModel(parentID);
                this.S_ParentName.Text = NewsSpecialModel.SpecialCName;
            }
            else
            {
                this.S_Parent.Text = "0";
                this.S_ParentName.Text = "根专题";
            }
            this.S_Templet.Text = RootPublicCMS.allTemplet().Split(new Char[] { '|' })[2];
            this.S_DirRule.Text = "{@year04}-{@month}";
            this.S_FileRule.Text = "{@EName}/index";
            this.S_SavePath.Text = "/" + Foosun.Config.UIConfig.dirHtml + "/special";
        }
    }


    /// <summary>
    /// 添加专题进数据库
    /// </summary>
    /// <returns>返回域名字符串</returns>

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            //-----------------取得表单内容
            Foosun.Model.NewsSpecial NewsSpecialModel = new Foosun.Model.NewsSpecial();
            NewsSpecialModel.SpecialCName = Request.Form["S_Cname"];             //中文名
            NewsSpecialModel.specialEName = Request.Form["S_Ename"];             //英文名
            NewsSpecialModel.ParentID = Request.Form["S_Parent"];                //父栏目

            NewsSpecialModel.Domain = Request.Form["S_Domain"];                  //域名
            NewsSpecialModel.FileEXName = Request.Form["S_FileExname"];          //生成文件的扩展名

            if (Request.Form["isTrue"] == "1")                         //是否启用浏览权限控制
            {
                NewsSpecialModel.GroupNumber = Request.Form["S_UserGroup"]+"";         //可浏览用户组
                NewsSpecialModel.isDelPoint = int.Parse(Request.Form["S_IsDel"]);   //是否启用扣取与所需
                NewsSpecialModel.iPoint = int.Parse(Request.Form["S_Point"]);       //点数
                NewsSpecialModel.Gpoint = int.Parse(Request.Form["S_Money"]);       //金币
            }
            else
            {
                NewsSpecialModel.GroupNumber = "0";                               
                NewsSpecialModel.isDelPoint = 0;    
                NewsSpecialModel.iPoint = 0;        
                NewsSpecialModel.Gpoint = 0;
            }
            string DirPath =Foosun.CMS.CommStr.FileRandName(Request.Form["S_DirRule"]);
            string SaveTP=Request.Form["S_SavePath"].Replace("{@dirHtml}",Foosun.Config.UIConfig.dirHtml);
            string fName=Foosun.CMS.CommStr.FileRandName(Request.Form["S_FileRule"]).Replace("{@EName}", Request.Form["S_Ename"]);
            NewsSpecialModel.saveDirPath = DirPath;    //目录生成规则
            NewsSpecialModel.FileName = fName;      //文件名生成规则
            NewsSpecialModel.SavePath = SaveTP;                                             //保存路径

            NewsSpecialModel.NaviPicURL = Request.Form["S_Pic"];                 //导航图片路径
            NewsSpecialModel.NaviContent = Request.Form["S_Text"];               //导航文字
            NewsSpecialModel.Templet = Request.Form["S_Templet"];                //专题模板路径
            string NPosion =Request.Form["S_Page"];
            //替换导航
            NPosion = (NPosion.Replace("{#URL}", SaveTP + "/" + DirPath + "/" + fName + Request.Form["S_FileExname"])).Replace("//", "/");
            NewsSpecialModel.NaviPosition = NPosion;              //页面导航条
            NewsSpecialModel.isLock = int.Parse(Request.Form["S_Lock"]);         //是否锁定
            string SpecialId = Common.Rand.Number(12);
            NewsSpecialModel.SpecialID = SpecialId;
            NewsSpecialModel.SiteID = SiteID;
            NewsSpecialModel.CreatTime = DateTime.Now;
            NewsSpecialModel.isRecyle = 0;

            string result = NewsSpecialCMS.Add(NewsSpecialModel);
            string[] arr_result = result.Split('|');

            //清除缓存
            if (arr_result[0].ToString() == "1")
            {
                DropTempletCMS.AddTemplet(SpecialId, Request.Form["dTemplet"], "", "2");
                Common.MessageBox.ShowAndRedirect(this, "添加专题成功!", "SpecialList.aspx");
            }
            else
                Common.MessageBox.Show(this, result);
        }
    }
}

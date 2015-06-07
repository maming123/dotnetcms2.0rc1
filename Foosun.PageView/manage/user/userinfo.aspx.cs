using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using System.Data;

namespace Foosun.PageView.manage.user
{
    public partial class userinfo : Foosun.PageBasic.ManagePage
    {
        public userinfo()
        {
            Authority_Code = "U003";
        }
        UserMisc rd = new UserMisc();
        RootPublic pd = new RootPublic();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            if (!IsPostBack)
            {
                //copyright.InnerHtml = CopyRight;
                string uids = Common.Input.Filter(Request.QueryString["id"]);
                int uid = 0;
                try
                {
                    uid = int.Parse(uids);
                }
                catch (Exception UX)
                {
                    PageError("错误的参数.<li>" + UX + "</li>", "");
                }
                suid.Value = Request.QueryString["id"];
                sex.InnerHtml = sexlist();
                marriage.InnerHtml = marriagelist();
                isopen.InnerHtml = isopenlist();
                string strUserNum = "";
                DataTable dt = rd.getUserInfobase1(uid);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        strUserNum = dt.Rows[0]["UserNum"].ToString();
                        NickName.Text = dt.Rows[0]["NickName"].ToString();
                        string birthdays = dt.Rows[0]["birthday"].ToString();
                        if (birthdays != "" || birthdays != null || birthdays == string.Empty)
                        {
                            try
                            {
                                birthday.Text = ((DateTime)dt.Rows[0]["birthday"]).ToString("yyyy-MM-dd");
                            }
                            catch
                            {
                                birthday.Text = "1988-1-1";
                            }
                        }

                        this.RealName.Text = dt.Rows[0]["RealName"].ToString();
                        this.Userinfo.Text = Common.Input.ToTxt(dt.Rows[0]["Userinfo"].ToString());
                        this.UserFace.Text = dt.Rows[0]["UserFace"].ToString();
                        this.userFacesize.Text = dt.Rows[0]["userFacesize"].ToString();
                        this.email.Text = dt.Rows[0]["email"].ToString();
                        string UserGroupNumber = "<select name=\"UserGroupNumber\" class=\"select3\">\r";                        
                        IDataReader dr = pd.GetGroupList();
                        while (dr.Read())
                        {
                            if (dt.Rows[0]["UserGroupNumber"].ToString() == dr["GroupNumber"].ToString())
                            {
                                UserGroupNumber += "<option selected value=\"" + dr["GroupNumber"].ToString() + "\">" + dr["GroupName"].ToString() + "</option>\r";
                            }
                            else
                            {
                                UserGroupNumber += "<option value=\"" + dr["GroupNumber"].ToString() + "\">" + dr["GroupName"].ToString() + "</option>\r";
                            }
                        }
                        dr.Close();
                        UserGroupNumber += "</select>\r";
                        GroupNumber.InnerHtml = UserGroupNumber;
                    }
                }

                DataTable dts = rd.getUserInfobase2(strUserNum);
                if (dts != null)
                {
                    if (dts.Rows.Count > 0)
                    {
                        this.job.Text = dts.Rows[0]["Job"].ToString();//职业
                        this.Nation.Text = dts.Rows[0]["Nation"].ToString();//民族
                        this.orgSch.Text = dts.Rows[0]["orgSch"].ToString();//组织关系
                        this.character.Text = dts.Rows[0]["character"].ToString();//性格
                        this.UserFan.Text = dts.Rows[0]["UserFan"].ToString();//用户爱好
                        this.education.Text = dts.Rows[0]["education"].ToString();//学历
                        this.Lastschool.Text = dts.Rows[0]["Lastschool"].ToString();//毕业学校
                        this.nativeplace.Text = dts.Rows[0]["nativeplace"].ToString();
                    }
                    dts.Clear();
                    dts.Dispose();
                }
                string getUserNum = pd.GetUidUserNum(uid);
                dt = rd.getUserInfoContact(getUserNum);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        province.Text = dt.Rows[0]["province"].ToString();
                        City.Text = dt.Rows[0]["City"].ToString();
                        Address.Text = dt.Rows[0]["Address"].ToString();
                        Postcode.Text = dt.Rows[0]["Postcode"].ToString();
                        FaTel.Text = dt.Rows[0]["FaTel"].ToString();
                        WorkTel.Text = dt.Rows[0]["WorkTel"].ToString();
                        Fax.Text = dt.Rows[0]["Fax"].ToString();
                        QQ.Text = dt.Rows[0]["QQ"].ToString();
                        MSN.Text = dt.Rows[0]["MSN"].ToString();
                    }
                }               
                dt = rd.getPassWord(uid);
                if (dt != null&&dt.Rows.Count>0)
                {                    
                        PassQuestion.Text = dt.Rows[0]["PassQuestion"].ToString();
                }
                 dt.Clear();
                 dt.Dispose();
                 lockTF.InnerHtml = locks(uid);
                 adminTF.InnerHtml = admins(uid);
                 GroupList.InnerHtml = GroupLists(uid);
                 isCerts.InnerHtml = Certs(uid);
                 DataTable udt = rd.getUserInfoBaseStat(uid);
                 if (udt != null)
                 {
                     if (udt.Rows.Count > 0)
                     {
                         CertType.Value = udt.Rows[0]["CertType"].ToString();
                         CertNumber.Text = udt.Rows[0]["CertNumber"].ToString();
                         ipoint.Text = udt.Rows[0]["ipoint"].ToString();
                         gpoint.Text = udt.Rows[0]["gpoint"].ToString();
                         cpoint.Text = udt.Rows[0]["cpoint"].ToString();
                         epoint.Text = udt.Rows[0]["epoint"].ToString();
                         apoint.Text = udt.Rows[0]["apoint"].ToString();
                         RegTime.Text = udt.Rows[0]["RegTime"].ToString();
                         onlineTime.Text = udt.Rows[0]["onlineTime"].ToString();
                         LoginNumber.Text = udt.Rows[0]["LoginNumber"].ToString();
                         LoginLimtNumber.Text = udt.Rows[0]["LoginLimtNumber"].ToString();
                         lastIP.Text = udt.Rows[0]["lastIP"].ToString();
                         TxtSite.Text = udt.Rows[0]["SiteID"].ToString();
                         LastLoginTime.Text = udt.Rows[0]["LastLoginTime"].ToString();
                     }
                     udt.Dispose();
                 }
            }
        }
        string locks(int suid)
        {
            string liststr = "<select class=\"select3\" name=\"islock\">";
            DataTable dt = rd.getLockStat(suid);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["islock"].ToString() == "1")
                    {
                        liststr += "<option value=\"1\" selected>锁定</option>";
                    }
                    else
                    {
                        liststr += "<option value=\"1\">锁定</option>";
                    }

                    if (dt.Rows[0]["islock"].ToString() == "0")
                    {
                        liststr += "<option value=\"0\" selected>正常</option>";
                    }
                    else
                    {
                        liststr += "<option value=\"0\">正常</option>";
                    }
                }
                dt.Dispose();
            }
            liststr += "</select>";
            return liststr;
        }

        string admins(int suid)
        {
            string liststr = "<select class=\"select3\" name=\"isadmin\" style=\"width:150px\">";
            DataTable dt = rd.getAdminsStat(suid);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["isadmin"].ToString() == "1")
                    {
                        liststr += "<option value=\"1\" selected>是</option>";
                    }
                    else
                    {
                        liststr += "<option value=\"1\">是</option>";
                    }

                    if (dt.Rows[0]["isadmin"].ToString() == "0")
                    {
                        liststr += "<option value=\"0\" selected>否</option>";
                    }
                    else
                    {
                        liststr += "<option value=\"0\">否</option>";
                    }
                }
                dt.Dispose();
            }
            liststr += "</select>";
            return liststr;
        }

        string GroupLists(int suid)
        {
            string liststr = "<select class=\"select3\" name=\"GroupNumber\">";
            DataTable udt = rd.getGroupListStat(suid);
            if (udt != null)
            {
                if (udt.Rows.Count > 0)
                {
                    Foosun.CMS.RootPublic rp = new Foosun.CMS.RootPublic();
                    IDataReader dr = rp.GetGroupList();
                    while (dr.Read())
                    {
                        if (udt.Rows[0]["UserGroupNumber"].ToString() == dr["GroupNumber"].ToString())
                        {
                            liststr += "<option value=\"" + dr["GroupNumber"] + "\" selected>" + dr["GroupName"] + "</option>";
                        }
                        else
                        {
                            liststr += "<option value=\"" + dr["GroupNumber"] + "\">" + dr["GroupName"] + "</option>";
                        }
                    }
                    dr.Close();
                }
                udt.Dispose();
            }
            return liststr;
        }


        protected string Certs(int suid)
        {
            string liststr = "";
            DataTable dt = rd.getCertsStat(suid);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["isIDcard"].ToString() == "1")
                    {
                        liststr += "<font color=blue>已通过认证</font>";
                    }
                    else
                    {
                        liststr += "<font color=red>未通过认证</font>";
                    }
                }
                dt.Dispose();
            }
            return liststr;

        }
        string sexlist()
        {
            string _Str = "";
            DataTable dt = rd.sexlist(int.Parse(Common.Input.Filter(Request.QueryString["id"])));
            if (dt != null)
            {
                _Str += "<select name=\"sex\" class=\"select1\">";
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["sex"].ToString() == "0")
                    {
                        _Str += "<option value=\"0\" selected>保密</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"0\">保密</option>";
                    }
                    if (dt.Rows[0]["sex"].ToString() == "1")
                    {
                        _Str += "<option value=\"1\" selected>男</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"1\">男</option>";
                    }
                    if (dt.Rows[0]["sex"].ToString() == "2")
                    {
                        _Str += "<option value=\"2\" selected>女</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"2\">女</option>";
                    }
                }
                else
                {
                    _Str += "<option value=\"0\" selected>保密</option>";
                    _Str += "<option value=\"1\">男</option>";
                    _Str += "<option value=\"2\">女</option>";
                }
                _Str += "</select>";
            }
            return _Str;
        }
        string marriagelist()
        {
            string _Str = "";
            DataTable dt = rd.marriagelist(int.Parse(Common.Input.Filter(Request.QueryString["id"])));
            if (dt != null)
            {
                _Str += "<select name=\"marriage\"  class=\"select1\">";
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["marriage"].ToString() == "0")
                    {
                        _Str += "<option value=\"0\" selected>保密</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"0\">保密</option>";
                    }
                    if (dt.Rows[0]["marriage"].ToString() == "1")
                    {
                        _Str += "<option value=\"1\" selected>未婚</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"1\">未婚</option>";
                    }
                    if (dt.Rows[0]["marriage"].ToString() == "2")
                    {
                        _Str += "<option value=\"2\" selected>已婚</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"2\">已婚</option>";
                    }
                    _Str += "</select>";
                }
                else
                {
                    _Str += "<option value=\"0\" selected>保密</option>";
                    _Str += "<option value=\"1\">未婚</option>";
                    _Str += "<option value=\"2\">已婚</option>";
                }
            }
            return _Str;
        }
        string isopenlist()
        {
            string _Str = "";
            DataTable dt = rd.isopenlist(int.Parse(Common.Input.Filter(Request.QueryString["id"])));
            if (dt != null)
            {
                _Str += "<select name=\"isopen\" class=\"select3\">";
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["isopen"].ToString() == "0")
                    {
                        _Str += "<option value=\"0\" selected>不开放</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"0\">不开放</option>";
                    }
                    if (dt.Rows[0]["isopen"].ToString() == "1")
                    {
                        _Str += "<option value=\"1\" selected>开放</option>";
                    }
                    else
                    {
                        _Str += "<option value=\"1\">开放</option>";
                    }
                    _Str += "</select>";
                }
                else
                {
                    _Str += "<option value=\"1\" selected>开放</option>";
                    _Str += "<option value=\"0\">不开放</option>";
                }
            }
            return _Str;
        }
        protected void submitSave(object sender, EventArgs e)
        {
            if (Page.IsValid == true)                       //判断是否验证成功
            {
                string NickName = Request.Form["NickName"];
                string sex = Request.Form["sex"];
                string birthday = this.birthday.Text;
                string Nation = this.Nation.Text;
                string nativeplace = this.nativeplace.Text;
                string Userinfo = this.Userinfo.Text;
                string UserFace = this.UserFace.Text;
                string userFacesize = this.userFacesize.Text;
                string email = this.email.Text;
                string character = this.character.Text;
                string UserFan = this.UserFan.Text;
                string orgSch = this.orgSch.Text;
                string job = this.job.Text;
                string education = this.education.Text;
                string Lastschool = this.Lastschool.Text;
                string RealName = this.RealName.Text;
                string marriage = Request.Form["marriage"];
                string isopen = Request.Form["isopen"];
                string UserGroupNumber = Request.Form["UserGroupNumber"];
                string[] userFacesizes = userFacesize.Split('|');
                int suid = int.Parse(Request.Form["suid"]);
                int uf = 0, uf1 = 0;
                try
                {
                    uf = int.Parse(userFacesizes[0].ToString());
                    uf1 = int.Parse(userFacesizes[1].ToString());
                }
                catch
                {
                    userFacesize = "80|60";
                }
                if (uf > 120) { PageError("头像宽度不能超过120px", ""); }
                if (uf1 > 120) { PageError("头像高度不能超过120px", ""); }
                DataTable dt = rd.getUserInfoParam(suid);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Userinfo.Length > int.Parse(dt.Rows[0]["CharLenContent"].ToString()))
                        {
                            PageError("签名长度大于" + dt.Rows[0]["CharLenContent"] + "字符", "");
                        }
                        if (dt.Rows[0]["CharHTML"].ToString() == "0")
                        {
                            Userinfo = Common.Input.ToHtml(Userinfo);
                        }
                    }
                    else
                    {
                        if (Userinfo.Length > 300)
                        {
                            PageError("签名长度大于300字符", "");
                        }
                    }
                }
                else
                {
                    if (Userinfo.Length > 300)
                    {
                        PageError("签名长度大于300字符", "");
                    }
                }

                ///更新基本表
                Foosun.Model.UserInfo uc = new Foosun.Model.UserInfo();
                uc.Id = suid;
                uc.NickName = NickName;
                uc.RealName = RealName;
                uc.sex = int.Parse(sex);
                if (birthday.Trim() != "")
                {
                    uc.birthday = DateTime.Parse(birthday);
                }
                else
                {
                    uc.birthday = DateTime.Parse("3000-1-1");
                }
                uc.Userinfo = Userinfo;
                uc.UserFace = UserFace;
                uc.userFacesize = userFacesize;
                uc.UserGroupNumber = UserGroupNumber;
                uc.marriage = int.Parse(marriage);
                uc.isopen = int.Parse(isopen);
                uc.email = email;
                rd.UpdateUserInfoBase(uc);

                //同步更新用户信息
                Foosun.PlugIn.Passport.DPO_Request request = new Foosun.PlugIn.Passport.DPO_Request(Context);
                request.Birthday = uc.birthday.ToString("yyyy-MM-dd");
                switch (uc.sex)
                {
                    case 2:
                        request.Sex = "0";
                        break;
                    case 1:
                        request.Sex = "1";
                        break;
                    default:
                        request.Sex = "2";
                        break;
                }
                request.TrueName = uc.RealName;
                request.UserName = Foosun.Global.Current.UserName;
                request.ProcessMultiPing("update");

                if (request.FoundErr)
                {
                    PageError("同步更新用户信息失败", "userinfo.aspx");
                }
                //获得UserID
                DataTable getdt = rd.getUserInfoNum(suid);
                string strUsernum = "";
                if (getdt != null)
                {
                    if (getdt.Rows.Count > 0)
                    {
                        strUsernum = getdt.Rows[0]["userNum"].ToString();
                    }
                    getdt.Clear();
                    getdt.Dispose();
                }
                //获取记录
                DataTable sdt = rd.getUserInfoRecord(strUsernum);
                if (sdt != null)
                {
                    if (sdt.Rows.Count > 0)
                    {
                        Foosun.Model.UserInfo1 uc1 = new Foosun.Model.UserInfo1();
                        uc1.UserNum = strUsernum;
                        uc1.Nation = Nation;
                        uc1.nativeplace = nativeplace;
                        uc1.character = character;
                        uc1.UserFan = UserFan;
                        uc1.orgSch = orgSch;
                        uc1.job = job;
                        uc1.education = education;
                        uc1.Lastschool = Lastschool;
                        rd.UpdateUserInfoBase1(uc1);
                    }
                    else
                    {
                        Foosun.Model.UserInfo1 uc1 = new Foosun.Model.UserInfo1();
                        uc1.UserNum = strUsernum;
                        uc1.Nation = Nation;
                        uc1.nativeplace = nativeplace;
                        uc1.character = character;
                        uc1.UserFan = UserFan;
                        uc1.orgSch = orgSch;
                        uc1.job = job;
                        uc1.education = education;
                        uc1.Lastschool = Lastschool;
                        rd.UpdateUserInfoBase2(uc1);
                    }
                    sdt.Clear();
                    sdt.Dispose();
                }
                else
                {
                    Foosun.Model.UserInfo1 uc1 = new Foosun.Model.UserInfo1();
                    uc1.UserNum = strUsernum;
                    uc1.Nation = Nation;
                    uc1.nativeplace = nativeplace;
                    uc1.character = character;
                    uc1.UserFan = UserFan;
                    uc1.orgSch = orgSch;
                    uc1.job = job;
                    uc1.education = education;
                    uc1.Lastschool = Lastschool;
                    rd.UpdateUserInfoBase1(uc1);
                }
                PageRight("修改基本资料成功！", "userlist.aspx");
            }
        }
        protected void btncontact(object sender, EventArgs e)
        {
            if (Page.IsValid == true)                       //判断是否验证成功
            {
                string RealName = Request.Form["RealName"];
                string province = Request.Form["province"];
                string City = Request.Form["City"];
                string Address = Request.Form["Address"];
                string Postcode = Request.Form["Postcode"];
                string FaTel = Request.Form["FaTel"];
                string WorkTel = Request.Form["WorkTel"];
                string Fax = Request.Form["Fax"];
                string QQ = Request.Form["QQ"];
                string MSN = Request.Form["MSN"];
                int suid = int.Parse(Request.Form["suid"]);
                string getUserNum = pd.GetUidUserNum(suid);
                //同步更新用户信息
                Foosun.PlugIn.Passport.DPO_Request request = new Foosun.PlugIn.Passport.DPO_Request(Context);
                request.Province = province;
                request.City = City;
                request.address = Address;
                request.TelePhone = FaTel;
                request.QQ = QQ;
                request.MSN = MSN;
                request.UserName = Foosun.Global.Current.UserName;
                request.ProcessMultiPing("update");

                if (request.FoundErr)
                {
                    PageError("同步更新用户信息失败", "userinfo.aspx");
                }

                DataTable sdt = rd.getUserContactRecord(getUserNum);
                if (sdt != null)
                {
                    if (sdt.Rows.Count > 0)
                    {
                        Foosun.Model.UserInfo2 uc1 = new Foosun.Model.UserInfo2();
                        uc1.UserNum = getUserNum;
                        uc1.province = province;
                        uc1.City = City;
                        uc1.Address = Address;
                        uc1.Postcode = Postcode;
                        uc1.FaTel = FaTel;
                        uc1.WorkTel = WorkTel;
                        uc1.Fax = Fax;
                        uc1.QQ = QQ;
                        uc1.MSN = MSN;
                        rd.UpdateUserInfoContact1(uc1);
                    }
                    else
                    {
                        Foosun.Model.UserInfo2 uc1 = new Foosun.Model.UserInfo2();
                        uc1.UserNum = getUserNum;
                        uc1.province = province;
                        uc1.City = City;
                        uc1.Address = Address;
                        uc1.Postcode = Postcode;
                        uc1.FaTel = FaTel;
                        uc1.WorkTel = WorkTel;
                        uc1.Fax = Fax;
                        uc1.QQ = QQ;
                        uc1.MSN = MSN;
                        rd.UpdateUserInfoContact2(uc1);
                    }
                }
                else
                {
                    Foosun.Model.UserInfo2 uc1 = new Foosun.Model.UserInfo2();
                    uc1.UserNum = getUserNum;
                    uc1.province = province;
                    uc1.City = City;
                    uc1.Address = Address;
                    uc1.Postcode = Postcode;
                    uc1.FaTel = FaTel;
                    uc1.WorkTel = WorkTel;
                    uc1.Fax = Fax;
                    uc1.QQ = QQ;
                    uc1.MSN = MSN;
                    rd.UpdateUserInfoContact1(uc1);
                }
                PageRight("修改资料成功！", "userlist.aspx");
            }
        }
        protected void btnsafe(object sender, EventArgs e)
        {
            if (Page.IsValid == true)                       //判断是否验证成功
            {
                string PassQuestion = this.PassQuestion.Text;
                string oldpassword = this.oldpassword.Text; ;
                string PassKey = this.PassKey.Text;
                string password = this.password.Text;
                int suid = int.Parse(Common.Input.Filter(Request.Form["suid"]));
                if ((PassQuestion != null && PassQuestion != "") && (PassKey != null && PassKey != "") && (password != null && password != ""))
                {
                        //同步更新用户信息
                        Foosun.PlugIn.Passport.DPO_Request request = new Foosun.PlugIn.Passport.DPO_Request(Context);
                        request.PassWord = password;
                        request.UserName = Foosun.Global.Current.UserName;
                        request.ProcessMultiPing("update");

                        if (request.FoundErr)
                        {
                            PageError("同步更新用户信息失败", "userinfo.aspx");
                        }

                        rd.UpdateUserSafe(suid, PassQuestion, PassKey, password);
                        PageRight("安全资料成功！", "userlist.aspx");
                }
                else
                {
                    PageError("所有项目必须填写", "");
                }
            }
        }
        protected void btnbase(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Common.DataCache.DelCache("userinfo-" + Request.QueryString["userNum"]);
                int UserID = 0, lockTF = 0, adminTF = 0, ipoint = 0, gpoint = 0, cpoint = 0, epoint = 0, apoint = 0, onlineTime = 0, LoginNumber = 0, LoginLimtNumber = 0;
                DateTime RegTime = System.DateTime.Now;
                try
                {
                    UserID = Convert.ToInt32(Request.Form["suid"]);
                    lockTF = Convert.ToInt32(Request.Form["islock"]);
                    adminTF = Convert.ToInt32(Request.Form["isadmin"]);
                    ipoint = Convert.ToInt32(Request.Form["ipoint"]);
                    gpoint = Convert.ToInt32(Request.Form["gpoint"]);
                    cpoint = Convert.ToInt32(Request.Form["cpoint"]);
                    epoint = Convert.ToInt32(Request.Form["epoint"]);
                    apoint = Convert.ToInt32(Request.Form["apoint"]);
                    RegTime = DateTime.Parse(Request.Form["RegTime"]);
                    onlineTime = Convert.ToInt32(Request.Form["onlineTime"]);
                    LoginNumber = Convert.ToInt32(Request.Form["LoginNumber"]);
                    LoginLimtNumber = Convert.ToInt32(Request.Form["LoginLimtNumber"]);
                }
                catch (Exception us)
                {
                    PageError("错误的参数<br />" + us.ToString() + "", "");
                }

                string LastLoginTime = Request.Form["LastLoginTime"];
                string GroupList = Request.Form["GroupNumber"];
                string CertType = Request.Form["CertType"];
                string CertNumber = Request.Form["CertNumber"];
                string lastIP = Request.Form["lastIP"];
                string ReqSite = Request.Form["TxtSite"];

                Foosun.Model.UserInfo3 uc = new Foosun.Model.UserInfo3();
                uc.Id = UserID;
                uc.UserGroupNumber = GroupList;
                uc.islock = lockTF;
                uc.isadmin = adminTF;
                uc.CertType = CertType;
                uc.CertNumber = CertNumber;
                uc.ipoint = ipoint;
                uc.gpoint = gpoint;
                uc.cpoint = cpoint;
                uc.epoint = epoint;
                uc.apoint = apoint;
                uc.onlineTime = onlineTime;
                uc.RegTime = RegTime;
                if (LastLoginTime != null && LastLoginTime != "")
                {
                    uc.LastLoginTime = DateTime.Parse(LastLoginTime);
                }
                else
                {
                    uc.LastLoginTime = System.DateTime.Now;
                }
                uc.LoginNumber = LoginNumber;
                uc.LoginLimtNumber = LoginLimtNumber;
                uc.lastIP = lastIP;
                uc.SiteID = ReqSite;
                rd.UpdateUserInfoBaseStat(uc);
                PageRight("修改资料成功。", "userlist.aspx");
            }
        }
    }
}
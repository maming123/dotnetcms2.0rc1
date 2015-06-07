using System;
using System.Collections.Generic;
using System.Text;

namespace Foosun.Model
{
    public enum EnumUserType
    {
        Admin = 0,
        Person = 1
    }
    [Serializable]

    public class UserInfo
    {
        public int Id;
        public string NickName;
        public string RealName;
        public int sex;
        public DateTime birthday;
        public string Userinfo;
        public string UserFace;
        public string userFacesize;
        public int marriage;
        public int isopen;
        public string UserGroupNumber;
        public string email;

    }

    //点卡
    public class IDCARD
    {
        public int Id;
        public string CaID;
        public string CardNumber;
        public string CardPassWord;
        public DateTime creatTime;
        public int Money;
        public int Point;
        public int isBuy;
        public int isUse;
        public int isLock;
        public string UserNum;
        public string siteID;
        public DateTime TimeOutDate;
    }

    //会员基本信息构造函数
    public class UserInfo1
    {
        public string UserNum;
        public string Nation;
        public string nativeplace;
        public string character;
        public string UserFan;
        public string orgSch;
        public string job;
        public string education;
        public string Lastschool;
    }
    //会员联系方式构造函数
    public class UserInfo2
    {
        public string UserNum;
        public string province;
        public string City;
        public string Address;
        public string Postcode;
        public string FaTel;
        public string WorkTel;
        public string Fax;
        public string QQ;
        public string MSN;
    }
    //会员状态构造函数
    public class UserInfo3
    {
        public int Id;
        public string UserNum;
        public string UserGroupNumber;
        public int islock;
        public int isadmin;
        public string CertType;
        public string CertNumber;
        public int ipoint;
        public int gpoint;
        public int cpoint;
        public int epoint;
        public int apoint;
        public int onlineTime;
        public DateTime RegTime;
        public DateTime LastLoginTime;
        public int LoginNumber;
        public int LoginLimtNumber;
        public string lastIP;
        public string SiteID;
    }
    //构造会员组插入数据
    public class UserInfo4
    {
        public int gID;
        public string GroupNumber;
        public string GroupName;
        public int iPoint;
        public int Gpoint;
        public int Rtime;
        public int LenCommContent;
        public int CommCheckTF;
        public int PostCommTime;
        public string upfileType;
        public int upfileNum;
        public int upfileSize;
        public int DayUpfilenum;
        public int ContrNum;
        public int DicussTF;
        public int PostTitle;
        public int ReadUser;
        public int MessageNum;
        public string MessageGroupNum;
        public int IsCert;
        public int CharTF;
        public int CharHTML;
        public int CharLenContent;
        public int RegMinute;
        public int PostTitleHTML;
        public int DelSelfTitle;
        public int DelOTitle;
        public int EditSelfTitle;
        public int EditOtitle;
        public int ReadTitle;
        public int MoveSelfTitle;
        public int MoveOTitle;
        public int TopTitle;
        public int GoodTitle;
        public int LockUser;
        public string UserFlag;
        public int CheckTtile;
        public int IPTF;
        public int EncUser;
        public int OCTF;
        public int StyleTF;
        public int UpfaceSize;
        public string GIChange;
        public string GTChageRate;
        public string LoginPoint;
        public string RegPoint;
        public int GroupTF;
        public int GroupSize;
        public int GroupPerNum;
        public int GroupCreatNum;
        public DateTime CreatTime;
        public string SiteID;
        public double Discount;
    }
    //公告构造函数
    public class UserInfo5
    {
        public int Id;
        public string newsID;
        public string Title;
        public string content;
        public DateTime creatTime;
        public string GroupNumber;
        public string getPoint;
        public string SiteId;
        public int isLock;
    }
    //在线支付构造函数
    public class UserInfo6
    {
        public int onpayType;
        public string O_userName;
        public string O_key;
        public string O_sendurl;
        public string O_returnurl;
        public string O_md5;
        public string O_other1;//合作合办ID
        public string O_other2;//选择的类别
        public string O_other3;
        public int Id;
    }

    //菜单构造函数
    public class UserInfo7
    {
		#region Model
		private int _am_id;
		private string _am_classid;
		private string _am_name;
		private string _am_filepath;
		private string _am_childrenid;
		private DateTime? _am_creattime;
		private int? _am_orderid;
		private int? _issys;
		private string _siteid;
		private string _usernum;
		private string _popcode;
		private string _imgpath;
		private string _imgwidth;
		private string _imgheight;
		/// <summary>
		/// 
		/// </summary>
		public int am_ID
		{
			set{ _am_id=value;}
			get{return _am_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string am_ClassID
		{
			set{ _am_classid=value;}
			get{return _am_classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string am_Name
		{
			set{ _am_name=value;}
			get{return _am_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string am_FilePath
		{
			set{ _am_filepath=value;}
			get{return _am_filepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string am_ChildrenID
		{
			set{ _am_childrenid=value;}
			get{return _am_childrenid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? am_creatTime
		{
			set{ _am_creattime=value;}
			get{return _am_creattime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? am_orderID
		{
			set{ _am_orderid=value;}
			get{return _am_orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isSys
		{
			set{ _issys=value;}
			get{return _issys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string siteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userNum
		{
			set{ _usernum=value;}
			get{return _usernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string popCode
		{
			set{ _popcode=value;}
			get{return _popcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgPath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgwidth
		{
			set{ _imgwidth=value;}
			get{return _imgwidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgheight
		{
			set{ _imgheight=value;}
			get{return _imgheight;}
		}
		#endregion Model
    }
    
    //快捷方式构造函数
    public class UserInfo8
    {
        public string QmID;
        public string qName;
        public string FilePath;
        public int Ismanage;
        public int OrderID;
        public string usernum;
        public string SiteID;
        public int Id;
    }
}

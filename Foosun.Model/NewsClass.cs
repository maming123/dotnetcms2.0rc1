using System;
using System.Collections.Generic;
using System.Text;

namespace Foosun.Model
{
    /// <summary>
    /// NewsClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsClass
    {
        public NewsClass()
        { }
        #region Model
        private int _id;
        private string _classId;
        private string _classcname;
        private string _classename;
        private string _parentid;
        private int? _isurl;
        private int? _orderid;
        private string _urladdress;
        private string _domain;
        private string _classtemplet;
        private string _readnewstemplet;
        private string _savepath;
        private string _saveclassframe;
        private int? _checkint;
        private string _classsaverule;
        private string _classindexrule;
        private string _newssavepath;
        private string _newsfilerule;
        private string _picdirpath;
        private int? _contentpictf;
        private string _contentpicurl;
        private string _contentpicsize;
        private int? _inhitoryday;
        private string _datalib;
        private string _siteid;
        private int? _navishowtf;
        private string _navipic;
        private string _navicontent;
        private string _metakeywords;
        private string _metadescript;
        private int? _isdelpoint;
        private int? _gpoint;
        private int? _ipoint;
        private string _groupnumber;
        private string _filename;
        private int? _islock;
        private int? _isrecyle;
        private string _naviposition;
        private string _newsposition;
        private int? _iscomm;
        private string _defineworkey;
        private DateTime? _creattime;
        private int? _ispage;
        private string _pagecontent;
        private string _modelid;
        private int? _isunhtml;
        /// <summary>
        /// 主键标识列
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标识列
        /// </summary>
        public string ClassID
        {
            set { _classId = value; }
            get { return _classId; }
        }
        /// <summary>
        /// 栏目中文名
        /// </summary>
        public string ClassCName
        {
            set { _classcname = value; }
            get { return _classcname; }
        }
        /// <summary>
        /// 栏目英文名
        /// </summary>
        public string ClassEName
        {
            set { _classename = value; }
            get { return _classename; }
        }
        /// <summary>
        /// 父栏目ID
        /// </summary>
        public string ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 是否为外部栏目
        /// </summary>
        public int? IsURL
        {
            set { _isurl = value; }
            get { return _isurl; }
        }
        /// <summary>
        /// 权重
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 外部地址
        /// </summary>
        public string URLaddress
        {
            set { _urladdress = value; }
            get { return _urladdress; }
        }
        /// <summary>
        /// 捆绑域名
        /// </summary>
        public string Domain
        {
            set { _domain = value; }
            get { return _domain; }
        }
        /// <summary>
        /// 栏目模版
        /// </summary>
        public string ClassTemplet
        {
            set { _classtemplet = value; }
            get { return _classtemplet; }
        }
        /// <summary>
        /// 流浪模版
        /// </summary>
        public string ReadNewsTemplet
        {
            set { _readnewstemplet = value; }
            get { return _readnewstemplet; }
        }
        /// <summary>
        /// 保存路劲
        /// </summary>
        public string SavePath
        {
            set { _savepath = value; }
            get { return _savepath; }
        }
        /// <summary>
        /// 保存栏目生成目录结构
        /// </summary>
        public string SaveClassframe
        {
            set { _saveclassframe = value; }
            get { return _saveclassframe; }
        }
        /// <summary>
        /// 审核机制
        /// </summary>
        public int? Checkint
        {
            set { _checkint = value; }
            get { return _checkint; }
        }
        /// <summary>
        /// 文件命名规则
        /// </summary>
        public string ClassSaveRule
        {
            set { _classsaverule = value; }
            get { return _classsaverule; }
        }
        /// <summary>
        /// 索引页规则
        /// </summary>
        public string ClassIndexRule
        {
            set { _classindexrule = value; }
            get { return _classindexrule; }
        }
        /// <summary>
        /// 	新闻保存目录
        /// </summary>
        public string NewsSavePath
        {
            set { _newssavepath = value; }
            get { return _newssavepath; }
        }
        /// <summary>
        /// 新闻浏览文件命名规则
        /// </summary>
        public string NewsFileRule
        {
            set { _newsfilerule = value; }
            get { return _newsfilerule; }
        }
        /// <summary>
        /// 图片上传目录
        /// </summary>
        public string PicDirPath
        {
            set { _picdirpath = value; }
            get { return _picdirpath; }
        }
        /// <summary>
        /// 是否允许画中画
        /// </summary>
        public int? ContentPicTF
        {
            set { _contentpictf = value; }
            get { return _contentpictf; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ContentPICurl
        {
            set { _contentpicurl = value; }
            get { return _contentpicurl; }
        }
        /// <summary>
        /// 画中画大小
        /// </summary>
        public string ContentPicSize
        {
            set { _contentpicsize = value; }
            get { return _contentpicsize; }
        }
        /// <summary>
        /// 本类新闻自动归档日期
        /// </summary>
        public int? InHitoryDay
        {
            set { _inhitoryday = value; }
            get { return _inhitoryday; }
        }
        /// <summary>
        /// 此栏目下新闻使用数据库表
        /// </summary>
        public string DataLib
        {
            set { _datalib = value; }
            get { return _datalib; }
        }
        /// <summary>
        /// 频道ID
        /// </summary>
        public string SiteID
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        /// <summary>
        /// 是否在导航中显示
        /// </summary>
        public int? NaviShowtf
        {
            set { _navishowtf = value; }
            get { return _navishowtf; }
        }
        /// <summary>
        /// 导航图片
        /// </summary>
        public string NaviPIC
        {
            set { _navipic = value; }
            get { return _navipic; }
        }
        /// <summary>
        /// 导航文字
        /// </summary>
        public string NaviContent
        {
            set { _navicontent = value; }
            get { return _navicontent; }
        }
        /// <summary>
        /// Meta关键字
        /// </summary>
        public string MetaKeywords
        {
            set { _metakeywords = value; }
            get { return _metakeywords; }
        }
        /// <summary>
        /// Meta描述
        /// </summary>
        public string MetaDescript
        {
            set { _metadescript = value; }
            get { return _metadescript; }
        }
        /// <summary>
        /// 是否设置有浏览权限
        /// </summary>
        public int? isDelPoint
        {
            set { _isdelpoint = value; }
            get { return _isdelpoint; }
        }
        /// <summary>
        /// G币权限
        /// </summary>
        public int? Gpoint
        {
            set { _gpoint = value; }
            get { return _gpoint; }
        }
        /// <summary>
        /// 积分权限
        /// </summary>
        public int? iPoint
        {
            set { _ipoint = value; }
            get { return _ipoint; }
        }
        /// <summary>
        /// 会员组设置（权限）
        /// </summary>
        public string GroupNumber
        {
            set { _groupnumber = value; }
            get { return _groupnumber; }
        }
        /// <summary>
        /// 生成文件的扩展名
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int? isLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 是否能回复
        /// </summary>
        public int? isRecyle
        {
            set { _isrecyle = value; }
            get { return _isrecyle; }
        }
        /// <summary>
        /// 栏目页导航样式
        /// </summary>
        public string NaviPosition
        {
            set { _naviposition = value; }
            get { return _naviposition; }
        }
        /// <summary>
        /// 新闻页导航样式
        /// </summary>
        public string NewsPosition
        {
            set { _newsposition = value; }
            get { return _newsposition; }
        }
        /// <summary>
        /// 是否能评论
        /// </summary>
        public int? isComm
        {
            set { _iscomm = value; }
            get { return _iscomm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Defineworkey
        {
            set { _defineworkey = value; }
            get { return _defineworkey; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatTime
        {
            set { _creattime = value; }
            get { return _creattime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isPage
        {
            set { _ispage = value; }
            get { return _ispage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PageContent
        {
            set { _pagecontent = value; }
            get { return _pagecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModelID
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isunHTML
        {
            set { _isunhtml = value; }
            get { return _isunhtml; }
        }
        #endregion Model

    }
}

using System;
namespace Foosun.Model
{
    /// <summary>
    /// News实体类
    /// </summary>
    [Serializable]
    public partial class News
    {
        public News()
        { }
        #region Model
        private int _id;
        private string _newsid;
        private int _newstype;
        private int _orderid = 50;
        private string _newstitle;
        private string _snewstitle;
        private string _titlecolor;
        private int _titleitf;
        private int? _titlebtf;
        private int? _commlinktf;
        private int? _subnewstf;
        private string _urladdress;
        private string _picurl;
        private string _spicurl;
        private string _classid;
        private string _specialid;
        private string _author;
        private string _souce;
        private string _tags;
        private string _newsproperty;
        private int _newspictopline;
        private string _templet;
        private string _content;
        private string _metakeywords;
        private string _metadesc;
        private string _navicontent;
        private int _click = 0;
        private DateTime _creattime;
        private DateTime? _edittime;
        private string _savepath;
        private string _filename;
        private string _fileexname;
        private int _isdelpoint;
        private int _gpoint;
        private int _ipoint;
        private string _groupnumber;
        private int _contentpictf;
        private string _contentpicurl;
        private string _contentpicsize;
        private int _commtf;
        private int _discusstf;
        private int _topnum;
        private int _votetf;
        private string _checkstat = "0|0|0";
        private int _islock = 0;
        private int _isrecyle = 0;
        private string _siteid;
        private string _datalib;
        private int? _defineid;
        private int _isvotetf;
        private string _editor;
        private int _ishtml;
        private int _isconstr;
        private int? _isfiles;
        private string _vurl;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NewsType
        {
            set { _newstype = value; }
            get { return _newstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewsTitle
        {
            set { _newstitle = value; }
            get { return _newstitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sNewsTitle
        {
            set { _snewstitle = value; }
            get { return _snewstitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TitleColor
        {
            set { _titlecolor = value; }
            get { return _titlecolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TitleITF
        {
            set { _titleitf = value; }
            get { return _titleitf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TitleBTF
        {
            set { _titlebtf = value; }
            get { return _titlebtf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CommLinkTF
        {
            set { _commlinktf = value; }
            get { return _commlinktf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SubNewsTF
        {
            set { _subnewstf = value; }
            get { return _subnewstf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string URLaddress
        {
            set { _urladdress = value; }
            get { return _urladdress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PicURL
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPicURL
        {
            set { _spicurl = value; }
            get { return _spicurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SpecialID
        {
            set { _specialid = value; }
            get { return _specialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Souce
        {
            set { _souce = value; }
            get { return _souce; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewsProperty
        {
            set { _newsproperty = value; }
            get { return _newsproperty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NewsPicTopline
        {
            set { _newspictopline = value; }
            get { return _newspictopline; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Templet
        {
            set { _templet = value; }
            get { return _templet; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Metakeywords
        {
            set { _metakeywords = value; }
            get { return _metakeywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Metadesc
        {
            set { _metadesc = value; }
            get { return _metadesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string naviContent
        {
            set { _navicontent = value; }
            get { return _navicontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatTime
        {
            set { _creattime = value; }
            get { return _creattime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EditTime
        {
            set { _edittime = value; }
            get { return _edittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SavePath
        {
            set { _savepath = value; }
            get { return _savepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileEXName
        {
            set { _fileexname = value; }
            get { return _fileexname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isDelPoint
        {
            set { _isdelpoint = value; }
            get { return _isdelpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Gpoint
        {
            set { _gpoint = value; }
            get { return _gpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iPoint
        {
            set { _ipoint = value; }
            get { return _ipoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupNumber
        {
            set { _groupnumber = value; }
            get { return _groupnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ContentPicTF
        {
            set { _contentpictf = value; }
            get { return _contentpictf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContentPicURL
        {
            set { _contentpicurl = value; }
            get { return _contentpicurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContentPicSize
        {
            set { _contentpicsize = value; }
            get { return _contentpicsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CommTF
        {
            set { _commtf = value; }
            get { return _commtf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DiscussTF
        {
            set { _discusstf = value; }
            get { return _discusstf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TopNum
        {
            set { _topnum = value; }
            get { return _topnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int VoteTF
        {
            set { _votetf = value; }
            get { return _votetf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CheckStat
        {
            set { _checkstat = value; }
            get { return _checkstat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isRecyle
        {
            set { _isrecyle = value; }
            get { return _isrecyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SiteID
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DataLib
        {
            set { _datalib = value; }
            get { return _datalib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DefineID
        {
            set { _defineid = value; }
            get { return _defineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isVoteTF
        {
            set { _isvotetf = value; }
            get { return _isvotetf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Editor
        {
            set { _editor = value; }
            get { return _editor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isHtml
        {
            set { _ishtml = value; }
            get { return _ishtml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isConstr
        {
            set { _isconstr = value; }
            get { return _isconstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isFiles
        {
            set { _isfiles = value; }
            get { return _isfiles; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vURL
        {
            set { _vurl = value; }
            get { return _vurl; }
        }
        #endregion Model

    }
    public class NewsContentTT
    {
        public int Id;
        public int NewsTF;
        public string NewsID;
        public string DataLib;
        public DateTime Creattime;
        public string tl_font;
        public int tl_size;
        public int tl_style;
        public string tl_color;
        public int tl_space;
        public string tl_PicColor;
        public string tl_SavePath;
        public string tl_Title;
        public int tl_Width;
        public string SiteID;
    }
    /// <summary>
    /// 新闻附件
    /// </summary>
    public class NewsUrl
    {
        public int id { set; get; }
        public string URLName { set; get; }
        public string NewsID { set; get; }
        public string DataLib { set; get; }
        public string FileURL { set; get; }
        public DateTime CreatTime { set; get; }
        public byte OrderID { set; get; }
    }
}


using System;
namespace Foosun.Model
{
    /// <summary>
    /// NewsSpecial:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsSpecial
    {
        public NewsSpecial()
        { }
        #region Model
        private int _id;
        private string _specialid;
        private string _specialcname;
        private string _specialename;
        private string _parentid;
        private string _domain;
        private int? _isdelpoint;
        private int? _gpoint;
        private int? _ipoint;
        private string _groupnumber;
        private string _savedirpath;
        private string _savepath;
        private string _filename;
        private string _fileexname;
        private string _navipicurl;
        private string _navicontent;
        private string _siteid;
        private string _templet;
        private int? _islock;
        private int? _isrecyle;
        private DateTime? _creattime;
        private string _naviposition;
        private string _modelid;
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
        public string SpecialID
        {
            set { _specialid = value; }
            get { return _specialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SpecialCName
        {
            set { _specialcname = value; }
            get { return _specialcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string specialEName
        {
            set { _specialename = value; }
            get { return _specialename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Domain
        {
            set { _domain = value; }
            get { return _domain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isDelPoint
        {
            set { _isdelpoint = value; }
            get { return _isdelpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Gpoint
        {
            set { _gpoint = value; }
            get { return _gpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iPoint
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
        public string saveDirPath
        {
            set { _savedirpath = value; }
            get { return _savedirpath; }
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
        public string NaviPicURL
        {
            set { _navipicurl = value; }
            get { return _navipicurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NaviContent
        {
            set { _navicontent = value; }
            get { return _navicontent; }
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
        public string Templet
        {
            set { _templet = value; }
            get { return _templet; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isRecyle
        {
            set { _isrecyle = value; }
            get { return _isrecyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatTime
        {
            set { _creattime = value; }
            get { return _creattime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NaviPosition
        {
            set { _naviposition = value; }
            get { return _naviposition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModelID
        {
            set { _modelid = value; }
            get { return _modelid; }
        }
        #endregion Model

    }
}


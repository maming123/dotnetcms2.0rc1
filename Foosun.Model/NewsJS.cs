using System;
namespace Foosun.Model
{
    /// <summary>
    /// NewsJS:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsJS
    {
        public NewsJS()
        { }
        #region Model
        private int _id;
        private string _jsid;
        private int _jstype;
        private string _jsname;
        private string _jstempletid;
        private int? _jsnum;
        private int? _jslentitle;
        private int? _jslennavi;
        private int? _jslencontent;
        private string _jscontent;
        private string _siteid;
        private int? _jscolsnum;
        private DateTime? _creattime;
        private string _jsfilename;
        private string _jssavepath;
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
        public string JsID
        {
            set { _jsid = value; }
            get { return _jsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int jsType
        {
            set { _jstype = value; }
            get { return _jstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JSName
        {
            set { _jsname = value; }
            get { return _jsname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JsTempletID
        {
            set { _jstempletid = value; }
            get { return _jstempletid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? jsNum
        {
            set { _jsnum = value; }
            get { return _jsnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? jsLenTitle
        {
            set { _jslentitle = value; }
            get { return _jslentitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? jsLenNavi
        {
            set { _jslennavi = value; }
            get { return _jslennavi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? jsLenContent
        {
            set { _jslencontent = value; }
            get { return _jslencontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jsContent
        {
            set { _jscontent = value; }
            get { return _jscontent; }
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
        public int? jsColsNum
        {
            set { _jscolsnum = value; }
            get { return _jscolsnum; }
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
        public string jsfilename
        {
            set { _jsfilename = value; }
            get { return _jsfilename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jssavepath
        {
            set { _jssavepath = value; }
            get { return _jssavepath; }
        }
        #endregion Model

    }
}


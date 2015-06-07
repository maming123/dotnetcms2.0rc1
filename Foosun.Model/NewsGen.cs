using System;
namespace Foosun.Model
{
    /// <summary>
    /// NewsGen:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsGen
    {
        public NewsGen()
        { }
        #region Model
        private int _id;
        private string _cname;
        private int? _gtype;
        private string _url;
        private string _emailurl;
        private int? _islock = 0;
        private string _siteid;
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
        public string Cname
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? gType
        {
            set { _gtype = value; }
            get { return _gtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string URL
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmailURL
        {
            set { _emailurl = value; }
            get { return _emailurl; }
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
        public string SiteID
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        #endregion Model

    }
}


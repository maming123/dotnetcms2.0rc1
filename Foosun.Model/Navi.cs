using System;
namespace Foosun.Model
{
    /// <summary>
    /// fs_api_navi:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Navi
    {
        public Navi()
        { }
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
            set { _am_id = value; }
            get { return _am_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string am_ClassID
        {
            set { _am_classid = value; }
            get { return _am_classid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string am_Name
        {
            set { _am_name = value; }
            get { return _am_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string am_FilePath
        {
            set { _am_filepath = value; }
            get { return _am_filepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string am_ChildrenID
        {
            set { _am_childrenid = value; }
            get { return _am_childrenid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? am_creatTime
        {
            set { _am_creattime = value; }
            get { return _am_creattime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? am_orderID
        {
            set { _am_orderid = value; }
            get { return _am_orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isSys
        {
            set { _issys = value; }
            get { return _issys; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string siteID
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userNum
        {
            set { _usernum = value; }
            get { return _usernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string popCode
        {
            set { _popcode = value; }
            get { return _popcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgPath
        {
            set { _imgpath = value; }
            get { return _imgpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgwidth
        {
            set { _imgwidth = value; }
            get { return _imgwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imgheight
        {
            set { _imgheight = value; }
            get { return _imgheight; }
        }
        #endregion Model

    }
}


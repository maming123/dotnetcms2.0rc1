using System;
namespace Foosun.Model
{
    /// <summary>
    /// NewsJSFile:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsJSFile
    {
        public NewsJSFile()
        { }
        #region Model
        private int _id;
        private string _jsid;
        private string _njf_title;
        private string _newsid;
        private string _newstable;
        private string _picpath;
        private string _classid;
        private string _siteid;
        private DateTime? _creattime;
        private DateTime? _tojstime;
        private int _reclyetf = 0;
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
        public string Njf_title
        {
            set { _njf_title = value; }
            get { return _njf_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewsId
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewsTable
        {
            set { _newstable = value; }
            get { return _newstable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PicPath
        {
            set { _picpath = value; }
            get { return _picpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassId
        {
            set { _classid = value; }
            get { return _classid; }
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
        public DateTime? CreatTime
        {
            set { _creattime = value; }
            get { return _creattime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TojsTime
        {
            set { _tojstime = value; }
            get { return _tojstime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReclyeTF
        {
            set { _reclyetf = value; }
            get { return _reclyetf; }
        }
        #endregion Model

    }
}


using System;
namespace Foosun.Model
{
    /// <summary>
    /// NewsJSTemplet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsJSTemplet
    {
        public NewsJSTemplet()
        { }
        #region Model
        private int _id;
        private string _templetid;
        private string _cname;
        private string _jsclassid;
        private int _jsttype = 0;
        private string _jstcontent;
        private DateTime _creattime;
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
        public string TempletID
        {
            set { _templetid = value; }
            get { return _templetid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JSClassid
        {
            set { _jsclassid = value; }
            get { return _jsclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int JSTType
        {
            set { _jsttype = value; }
            get { return _jsttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JSTContent
        {
            set { _jstcontent = value; }
            get { return _jstcontent; }
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
        public string SiteID
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        #endregion Model

    }
}


using System;
namespace Foosun.Model
{
    /// <summary>
    /// DefineSave:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DefineSave
    {
        public DefineSave()
        { }
        #region Model
        private int _id;
        private string _dsnewsid;
        private string _dsename;
        private string _dsnewstable;
        private int? _dstype;
        private string _dscontent;
        private string _dsapiid;
        private string _siteid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DsNewsID
        {
            set { _dsnewsid = value; }
            get { return _dsnewsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DsEname
        {
            set { _dsename = value; }
            get { return _dsename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DsNewsTable
        {
            set { _dsnewstable = value; }
            get { return _dsnewstable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DsType
        {
            set { _dstype = value; }
            get { return _dstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DsContent
        {
            set { _dscontent = value; }
            get { return _dscontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DsApiID
        {
            set { _dsapiid = value; }
            get { return _dsapiid; }
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


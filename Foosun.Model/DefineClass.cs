using System;
namespace Foosun.Model
{
    /// <summary>
    /// DefineClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DefineClass
    {
        public DefineClass()
        { }
        #region Model
        private int _defineid;
        private string _defineinfoid;
        private string _definename;
        private string _parentinfoid = "0";
        private string _siteid;
        /// <summary>
        /// 
        /// </summary>
        public int DefineId
        {
            set { _defineid = value; }
            get { return _defineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DefineInfoId
        {
            set { _defineinfoid = value; }
            get { return _defineinfoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DefineName
        {
            set { _definename = value; }
            get { return _definename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentInfoId
        {
            set { _parentinfoid = value; }
            get { return _parentinfoid; }
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


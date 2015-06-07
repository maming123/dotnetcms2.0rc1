using System;
namespace Foosun.Model
{
    /// <summary>
    /// DefineData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DefineData
    {
        public DefineData()
        { }
        #region Model
        private int _id;
        private string _defineinfoid;
        private string _definecname;
        private string _definecolumns;
        private int? _definetype;
        private int? _isnull;
        private string _definevalue;
        private string _defineexpr;
        private string _definedvalue;
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
        public string defineInfoId
        {
            set { _defineinfoid = value; }
            get { return _defineinfoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string defineCname
        {
            set { _definecname = value; }
            get { return _definecname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string defineColumns
        {
            set { _definecolumns = value; }
            get { return _definecolumns; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? defineType
        {
            set { _definetype = value; }
            get { return _definetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsNull
        {
            set { _isnull = value; }
            get { return _isnull; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string defineValue
        {
            set { _definevalue = value; }
            get { return _definevalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string defineExpr
        {
            set { _defineexpr = value; }
            get { return _defineexpr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string definedvalue
        {
            set { _definedvalue = value; }
            get { return _definedvalue; }
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


using System;
namespace Foosun.Model
{
    /// <summary>
    /// Attachments:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Attachments
    {
        public Attachments()
        { }
        #region Model
        private int _id;
        private string _filename;
        private string _filetype;
        private DateTime? _uploaddate;
        private string _filesize;
        private string _filepath;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 文件类型(1：附件   2：图片)
        /// </summary>
        public string FileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? UploadDate
        {
            set { _uploaddate = value; }
            get { return _uploaddate; }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        #endregion Model

    }
}


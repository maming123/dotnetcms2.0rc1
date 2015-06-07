using System;
namespace Foosun.Model
{
    /// <summary>
    /// Attachment:附件图片管理
    /// </summary>
    [Serializable]
    public partial class Attachment
    {
        public Attachment()
        { }
        #region Model
        private int _id;
        private string _filename;
        private string _filetype;
        private DateTime? _uploaddate;
        private string _filesize;
        private string _filepath;
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
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UploadDate
        {
            set { _uploaddate = value; }
            get { return _uploaddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        #endregion Model

    }
}


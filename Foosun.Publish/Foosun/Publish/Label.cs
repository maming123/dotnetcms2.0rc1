namespace Foosun.Publish
{
    using Foosun.Model;
    using System;
    using System.Text.RegularExpressions;

    public class Label
    {
        protected int _CurrentCHClassID;
        protected int _CurrentChID;
        protected int _CurrentCHNewsID;
        protected int _CurrentCHSpecialID;
        protected string _CurrentClassID = null;
        protected string _CurrentNewsID = null;
        protected string _CurrentSpecialID = null;
        protected string _FinalHtmlCode = string.Empty;
        protected bool _isConten;
        protected string _LabelContent = string.Empty;
        protected string _LabelName = string.Empty;
        protected LabelType _LabelType;
        protected News _ModelNews;
        protected TempType _TemplateType;

        public Label(string labelname, LabelType labeltype)
        {
            this._LabelName = labelname;
            this._LabelType = labeltype;
        }

        public virtual void GetContentFromDB()
        {
        }

        public static Label GetLabel(string labelname)
        {
            string input = labelname;
            if (Regex.Match(input, @"\{FS_FREE_[^\}]+\}", RegexOptions.Compiled).Success)
            {
                return new FreeLabel(labelname, LabelType.Free);
            }
            if (Regex.Match(input, @"\{FS_DYN[^\}]+\}", RegexOptions.Compiled).Success)
            {
                return new DynamicLabel(labelname, LabelType.Class);
            }
            if (Regex.Match(input, @"\{FS_CH\$\d+_[^\}]+\}", RegexOptions.Compiled).Success)
            {
                string str2 = input.Replace("{FS_CH$", "");
                int index = str2.IndexOf("_");
                string s = str2.Substring(0, index);
                ChannelLabel label = new ChannelLabel(labelname, LabelType.Channel);
                label.CHID = int.Parse(s);
                return label;
            }
            if (!Regex.Match(input, @"\{FS_[^\}]+\}", RegexOptions.Compiled).Success)
            {
                throw new Exception("标签名称非法");
            }
            return new CustomLabel(labelname, LabelType.Custom);
        }

        public virtual void MakeHtmlCode()
        {
        }

        public int CurrentChClassID
        {
            set
            {
                this._CurrentCHClassID = value;
            }
        }

        public int CurrentChID
        {
            set
            {
                this._CurrentChID = value;
            }
        }

        public int CurrentCHNewsID
        {
            set
            {
                this._CurrentCHNewsID = value;
            }
        }

        public int CurrentCHSpecialID
        {
            set
            {
                this._CurrentCHSpecialID = value;
            }
        }

        public string CurrentClassID
        {
            set
            {
                this._CurrentClassID = value;
            }
        }

        public string CurrentNewsID
        {
            set
            {
                this._CurrentNewsID = value;
            }
        }

        public string CurrentSpecialID
        {
            set
            {
                this._CurrentSpecialID = value;
            }
        }

        public string FinalHtmlCode
        {
            get
            {
                return this._FinalHtmlCode;
            }
        }

        public bool IsConten
        {
            get
            {
                return this._isConten;
            }
            set
            {
                this._isConten = value;
            }
        }

        public string LabelContent
        {
            get
            {
                return this._LabelContent;
            }
            set
            {
                this._LabelContent = value;
            }
        }

        public string LabelName
        {
            get
            {
                return this._LabelName;
            }
        }

        public News ModelNews
        {
            get
            {
                return this._ModelNews;
            }
            set
            {
                this._ModelNews = value;
            }
        }

        public LabelType MyType
        {
            get
            {
                return this._LabelType;
            }
        }

        public TempType TemplateType
        {
            get
            {
                return this._TemplateType;
            }
            set
            {
                this._TemplateType = value;
            }
        }
    }
}


namespace Foosun.Publish
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Template
    {
        protected int _chclassid;
        protected int _chid;
        protected int _chnewsid;
        protected int _chspecialid;
        protected string _classid = null;
        protected bool _isContent;
        protected string _newsid = null;
        protected string _specialid = null;
        protected string _tempcontent = string.Empty;
        protected string _tempfinallyconent = string.Empty;
        protected string _temppath;
        protected TempType _temptype;
        private Dictionary<string, string> DicTemplet = new Dictionary<string, string>();

        public Template(string temppath, TempType temptype)
        {
            this._temppath = temppath;
            this._temptype = temptype;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() * 2);
        }

        public void GetHTML()
        {
            this._tempcontent = General.ReadHtml(this._temppath);
        }

        public void NewReplaceLabels(string templetPath)
        {
            string pattern = @"\{FS_[^\}]+\}";
            this._tempfinallyconent = this._tempcontent;
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            for (Match match = regex.Match(this._tempfinallyconent); match.Success; match = regex.Match(this._tempfinallyconent))
            {
                string labelname = match.Value;
                Label label = Label.GetLabel(labelname);
                label.CurrentClassID = this._classid;
                label.CurrentSpecialID = this._specialid;
                label.CurrentNewsID = this._newsid;
                label.CurrentChClassID = this._chclassid;
                label.CurrentCHSpecialID = this._chspecialid;
                label.CurrentCHNewsID = this._chnewsid;
                label.CurrentChID = this._chid;
                label.TemplateType = this._temptype;
                label.IsConten = this.IsContent;
                label.GetContentFromDB();
                label.MakeHtmlCode();
                string finalHtmlCode = label.FinalHtmlCode;
                this._tempfinallyconent = this._tempfinallyconent.Replace(labelname, finalHtmlCode);
            }
        }

        public static bool operator ==(Template t1, Template t2)
        {
            return t1.TempFilePath.Equals(t2.TempFilePath);
        }

        public static bool operator !=(Template t1, Template t2)
        {
            if (t1.TempFilePath.Equals(t2.TempFilePath))
            {
                return false;
            }
            return true;
        }

        public void ReplaceLabels()
        {
            string pattern = @"\{FS_[^\}]+\}";
            this._tempfinallyconent = this._tempcontent;
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            Match match = regex.Match(this._tempfinallyconent);
            while (match.Success)
            {
                string key = match.Value;
                if (LabelParse.dicLabel.ContainsKey(key))
                {
                    this._tempfinallyconent = this._tempfinallyconent.Replace(key, LabelParse.dicLabel[key]);
                    match = regex.Match(this._tempfinallyconent);
                }
                else
                {
                    Label label = Label.GetLabel(key);
                    label.CurrentClassID = this._classid;
                    label.CurrentSpecialID = this._specialid;
                    label.CurrentNewsID = this._newsid;
                    label.CurrentChClassID = this._chclassid;
                    label.CurrentCHSpecialID = this._chspecialid;
                    label.CurrentCHNewsID = this._chnewsid;
                    label.CurrentChID = this._chid;
                    label.TemplateType = this._temptype;
                    label.IsConten = this.IsContent;
                    label.GetContentFromDB();
                    label.MakeHtmlCode();
                    string finalHtmlCode = label.FinalHtmlCode;
                    this._tempfinallyconent = this._tempfinallyconent.Replace(key, finalHtmlCode);
                    match = regex.Match(this._tempfinallyconent);
                }
            }
        }

        public void ReplaceNewsLabels()
        {
            string pattern = @"\{FS_[^\}]+\}";
            this._tempfinallyconent = this._tempcontent;
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            for (Match match = regex.Match(this._tempfinallyconent); match.Success; match = regex.Match(this._tempfinallyconent))
            {
                string key = match.Value;
                if (!LabelParse.dicLabel.ContainsKey(key))
                {
                    break;
                }
                if (LabelParse.dicLabel[key] == "")
                {
                    Label label = Label.GetLabel(key);
                    label.CurrentClassID = this._classid;
                    label.CurrentSpecialID = this._specialid;
                    label.CurrentNewsID = this._newsid;
                    label.CurrentChClassID = this._chclassid;
                    label.CurrentCHSpecialID = this._chspecialid;
                    label.CurrentCHNewsID = this._chnewsid;
                    label.CurrentChID = this._chid;
                    label.TemplateType = this._temptype;
                    label.IsConten = this.IsContent;
                    label.GetContentFromDB();
                    label.MakeHtmlCode();
                    string finalHtmlCode = label.FinalHtmlCode;
                    this._tempfinallyconent = this._tempfinallyconent.Replace(key, finalHtmlCode);
                }
                else
                {
                    this._tempfinallyconent = this._tempfinallyconent.Replace(key, LabelParse.dicLabel[key]);
                }
            }
        }

        public int CHClassID
        {
            get
            {
                return this._chclassid;
            }
            set
            {
                this._chclassid = value;
            }
        }

        public int ChID
        {
            get
            {
                return this._chid;
            }
            set
            {
                this._chid = value;
            }
        }

        public int CHNewsID
        {
            get
            {
                return this._chnewsid;
            }
            set
            {
                this._chnewsid = value;
            }
        }

        public int CHSpecialID
        {
            get
            {
                return this._chspecialid;
            }
            set
            {
                this._chspecialid = value;
            }
        }

        public string ClassID
        {
            get
            {
                return this._classid;
            }
            set
            {
                this._classid = value;
            }
        }

        public string FinallyContent
        {
            get
            {
                return this._tempfinallyconent;
            }
            set
            {
                this._tempfinallyconent = value;
            }
        }

        public bool IsContent
        {
            get
            {
                return this._isContent;
            }
            set
            {
                this._isContent = value;
            }
        }

        public TempType MyTempType
        {
            get
            {
                return this._temptype;
            }
        }

        public string NewsID
        {
            get
            {
                return this._newsid;
            }
            set
            {
                this._newsid = value;
            }
        }

        public string OriginalContent
        {
            get
            {
                return this._tempcontent;
            }
        }

        public string SpecialID
        {
            get
            {
                return this._specialid;
            }
            set
            {
                this._specialid = value;
            }
        }

        public string TempFilePath
        {
            get
            {
                return this._temppath;
            }
        }
    }
}


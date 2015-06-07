namespace Foosun.Publish
{
    using System;
    using System.Data;
    using System.Text.RegularExpressions;

    public class CustomLabel : Label
    {
        public static DataTable _lableTableInfo = new DataTable();
        private string Custom_Front;
        private string Custom_Medial;
        private string Custom_Terminal;
        private string LabelContent;

        public CustomLabel(string labelname, LabelType labeltype) : base(labelname, labeltype)
        {
            this.Custom_Front = string.Empty;
            this.Custom_Medial = string.Empty;
            this.Custom_Terminal = string.Empty;
            this.LabelContent = string.Empty;
            if (_lableTableInfo.Columns.Count == 0)
            {
                lock (_lableTableInfo)
                {
                    _lableTableInfo.Columns.Add("LabelID", typeof(string));
                    _lableTableInfo.Columns.Add("Label_Name", typeof(string));
                    _lableTableInfo.Columns.Add("Label_Content", typeof(string));
                }
            }
        }

        public override void GetContentFromDB()
        {
            if (_lableTableInfo.Rows.Count == 0)
            {
                IDataReader sysLabelContentByAll = CommonData.DalPublish.GetSysLabelContentByAll();
                lock (_lableTableInfo)
                {
                    _lableTableInfo.Load(sysLabelContentByAll);
                }
            }
            DataRow[] rowArray = _lableTableInfo.Select("Label_Name='" + base._LabelName + "'");
            DataRow row = null;
            if (rowArray.Length != 0)
            {
                row = rowArray[0];
                this.LabelContent = row["Label_Content"].ToString();
            }
            else
            {
                this.LabelContent = string.Empty;
            }
            if (!base.IsConten)
            {
                this.LabelContent = this.LabelContent.Replace("{#CommForm}", "");
            }
        }

        public override void MakeHtmlCode()
        {
            this.ParseLabelConetent();
        }

        protected void ParseLabelConetent()
        {
            string pattern = @"\[FS:unLoop,[^\]]+\][\s\S]*?\[/FS:unLoop\]|\[FS:Loop,[^\]]+\][\s\S]*?\[/FS:Loop\]";
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            string labelContent = this.LabelContent;
            if (labelContent == "")
            {
                labelContent = base._LabelContent;
            }
            for (Match match = regex.Match(labelContent); match.Success; match = regex.Match(labelContent))
            {
                string masscontent = match.Value.Trim();
                LabelMass mass = new LabelMass(masscontent, base._CurrentClassID, base._CurrentSpecialID, base._CurrentNewsID, base._CurrentChID, base._CurrentCHClassID, base._CurrentCHSpecialID, base._CurrentCHNewsID);
                mass.TemplateType = base._TemplateType;
                mass.ParseContent();
                string newValue = "";
                if (base._LabelContent == "")
                {
                    newValue = mass.Parse();
                }
                else
                {
                    newValue = mass.NewParse();
                }
                labelContent = labelContent.Replace(masscontent, newValue);
            }
            base._FinalHtmlCode = labelContent;
        }
    }
}


namespace Foosun.Publish
{
    using System;
    using System.Text.RegularExpressions;

    public class ChannelLabel : Label
    {
        private int _ChID;
        private string Custom_Front;
        private string Custom_Medial;
        private string Custom_Terminal;
        private string LabelContent;

        public ChannelLabel(string labelname, LabelType labeltype) : base(labelname, labeltype)
        {
            this.Custom_Front = string.Empty;
            this.Custom_Medial = string.Empty;
            this.Custom_Terminal = string.Empty;
            this.LabelContent = string.Empty;
        }

        public override void GetContentFromDB()
        {
            string str = base._LabelName.Replace("{FS_CH$", "");
            int index = str.IndexOf("_");
            str = str.Substring(index + 1);
            this.LabelContent = CommonData.DalPublish.GetChannelSysLabelContent(str.Remove(str.LastIndexOf("}")));
        }

        public override void MakeHtmlCode()
        {
            this.ParseLabelConetent(this._ChID);
        }

        protected void ParseLabelConetent(int ChID)
        {
            string pattern = @"\[FS:unLoop,[^\]]+\][\s\S]*?\[/FS:unLoop\]|\[FS:Loop,[^\]]+\][\s\S]*?\[/FS:Loop\]";
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            string labelContent = this.LabelContent;
            for (Match match = regex.Match(labelContent); match.Success; match = regex.Match(labelContent))
            {
                string masscontent = match.Value.Trim();
                LabelMass mass = new LabelMass(masscontent, base._CurrentClassID, base._CurrentSpecialID, base._CurrentNewsID, ChID, base._CurrentCHClassID, base._CurrentCHSpecialID, base._CurrentCHNewsID);
                mass.TemplateType = base._TemplateType;
                mass.ParseContent();
                string newValue = mass.Parse(ChID);
                labelContent = labelContent.Replace(masscontent, newValue);
            }
            base._FinalHtmlCode = labelContent;
        }

        public int CHID
        {
            set
            {
                this._ChID = value;
            }
        }
    }
}


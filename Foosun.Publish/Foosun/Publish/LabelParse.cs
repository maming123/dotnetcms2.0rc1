namespace Foosun.Publish
{
    using Foosun.CMS;
    using Foosun.CMS.Style;
    using Foosun.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class LabelParse
    {
        public static Dictionary<string, string> dicLabel = new Dictionary<string, string>();
        private Foosun.CMS.Label LabelCMS = new Foosun.CMS.Label();
        public Foosun.Model.News NewModel = null;
        private Foosun.CMS.Style.Style StyleCMS = new Foosun.CMS.Style.Style();

        public void ParseAllLabel()
        {
            if (dicLabel.Count <= 0)
            {
                DataTable table = this.LabelCMS.outLabelALL(2);
                foreach (DataRow row in table.Rows)
                {
                    Foosun.Publish.Label label = Foosun.Publish.Label.GetLabel(row["Label_Name"].ToString());
                    label.LabelContent = row["Label_Content"].ToString();
                    label.MakeHtmlCode();
                    string finalHtmlCode = label.FinalHtmlCode;
                    if (!dicLabel.ContainsKey(row["Label_Name"].ToString()) && (finalHtmlCode != ""))
                    {
                        dicLabel.Add(row["Label_Name"].ToString(), finalHtmlCode);
                    }
                }
            }
        }

        public void ParseNewsLabel(int newsId, string labelName)
        {
            Foosun.Publish.Label label = Foosun.Publish.Label.GetLabel(labelName);
        }
    }
}


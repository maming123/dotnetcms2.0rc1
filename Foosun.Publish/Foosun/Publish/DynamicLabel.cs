namespace Foosun.Publish
{
    using System;
    using System.Text.RegularExpressions;

    public class DynamicLabel : Label
    {
        private string LabelContent;

        public DynamicLabel(string labelname, LabelType labeltype) : base(labelname, labeltype)
        {
            this.LabelContent = string.Empty;
        }

        public override void GetContentFromDB()
        {
            string str = base._LabelName;
            string str2 = "";
            if (base._LabelName.Trim() == "{FS_DynClassLD}")
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=ClassList,FS:ListType=News,FS:PageStyle=0$$30$]\x00b7<a href=\"{#URL}\"><a href=\"{#URL}\">{#Title}</a></a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.Trim() == "{FS_DynClassLDC}")
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=ClassList,FS:ListType=News,FS:PageStyle=0$$30$,FS:SubNews=true]\x00b7<a href=\"{#URL}\">{#Title}</a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynClassD_") > -1)
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=List,FS:Number=10,FS:NewsType=Last,FS:ClassID=" + base._LabelName.Replace("{FS_DynClassD_", "").TrimEnd(new char[] { '}' }) + "]\x00b7<a href=\"{#URL}\">{#Title}</a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynClassDC_") > -1)
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=List,FS:Number=10,FS:NewsType=Last,FS:SubNews=true,FS:ClassID=" + base._LabelName.Replace("{FS_DynClassDC_", "").TrimEnd(new char[] { '}' }) + "]\x00b7<a href=\"{#URL}\">{#Title}</a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynClassR_") > -1)
            {
                str2 = "[FS:unLoop,FS:SiteID=0,FS:LabelType=RSS,FS:ClassID=" + base._LabelName.Replace("{FS_DynClassR_", "").TrimEnd(new char[] { '}' }) + "][/FS:unLoop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynClassC_") > -1)
            {
                str2 = "[FS:unLoop,FS:SiteID=0,FS:LabelType=ClassNaviRead,FS:ClassID=" + base._LabelName.Replace("{FS_DynClassC_", "").TrimEnd(new char[] { '}' }) + ",FS:ClassTitleNumber=30,FS:ClassNaviTitleNumber=150][/FS:unLoop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynClassC_") > -1)
            {
                str2 = "[FS:unLoop,FS:SiteID=0,FS:LabelType=ClassNaviRead,FS:ClassID=" + base._LabelName.Replace("{FS_DynClassC_", "").TrimEnd(new char[] { '}' }) + ",FS:ClassTitleNumber=30,FS:ClassNaviTitleNumber=150][/FS:unLoop]";
            }
            else if (base._LabelName.Trim() == "{FS_DynSpecialLD}")
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=ClassList,FS:ListType=Special,FS:PageStyle=0$$30$]\x00b7<a href=\"{#URL}\">{#Title}</a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.Trim() == "{FS_DynSpecialLDC}")
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=ClassList,FS:ListType=Special,FS:PageStyle=0$$30$,FS:SubNews=true]\x00b7<a href=\"{#URL}\">{#Title}</a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynSpecialD_") > -1)
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=List,FS:Number=10,FS:NewsType=Special,FS:SpecialID=" + base._LabelName.Replace("{FS_DynSpecialD_", "").TrimEnd(new char[] { '}' }) + "]\x00b7<a href=\"{#URL}\">{#Title}</a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynSpecialDC_") > -1)
            {
                str2 = "[FS:Loop,FS:SiteID=0,FS:LabelType=List,FS:Number=10,FS:NewsType=Special,FS:SubNews=true,FS:SpecialID=" + base._LabelName.Replace("{FS_DynSpecialDC_", "").TrimEnd(new char[] { '}' }) + "]\x00b7<a href=\"{#URL}\">{#Title}</a>  <span style=\"color:#999999;font-size:10px\">({#Date:Month}-{#Date:Day})</span>[/FS:Loop]";
            }
            else if (base._LabelName.IndexOf("{FS_DynSpecialC_") > -1)
            {
                str2 = "[FS:unLoop,FS:SiteID=0,FS:LabelType=SpeicalNaviRead,FS:SpecialID=" + base._LabelName.Replace("{FS_DynSpecialC_", "").TrimEnd(new char[] { '}' }) + ",FS:SpecialTitleNumber=30,FS:SpecialNaviTitleNumber=150][/FS:unLoop]";
            }
            this.LabelContent = str2;
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
            for (Match match = regex.Match(labelContent); match.Success; match = regex.Match(labelContent))
            {
                string masscontent = match.Value.Trim();
                LabelMass mass = new LabelMass(masscontent, base._CurrentClassID, base._CurrentSpecialID, base._CurrentNewsID, base._CurrentChID, base._CurrentCHClassID, base._CurrentCHSpecialID, base._CurrentCHNewsID);
                mass.TemplateType = base._TemplateType;
                mass.ParseContent();
                string newValue = mass.Parse();
                labelContent = labelContent.Replace(masscontent, newValue);
            }
            base._FinalHtmlCode = labelContent;
        }
    }
}


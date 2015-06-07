namespace Foosun.Publish.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [DefaultSettingValue("http://127.0.0.1:82/WebServirce/PublishPage.asmx"), ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string Foosun_Publish_FoosunWebServircePublish_PublishPage
        {
            get
            {
                return (string) this["Foosun_Publish_FoosunWebServircePublish_PublishPage"];
            }
        }
    }
}


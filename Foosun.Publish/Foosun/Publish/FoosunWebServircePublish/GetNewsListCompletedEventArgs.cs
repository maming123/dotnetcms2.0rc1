namespace Foosun.Publish.FoosunWebServircePublish
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;

    [DesignerCategory("code"), GeneratedCode("System.Web.Services", "4.0.30319.1"), DebuggerStepThrough]
    public class GetNewsListCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        internal GetNewsListCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public DataTable Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (DataTable) this.results[0];
            }
        }
    }
}


namespace Foosun.Publish.FoosunWebServircePublish
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;

    [DebuggerStepThrough, GeneratedCode("System.Web.Services", "4.0.30319.1"), DesignerCategory("code")]
    public class GetPageListCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        internal GetPageListCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
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


namespace Foosun.Publish.FoosunWebServircePublish
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;

    [GeneratedCode("System.Web.Services", "4.0.30319.1"), DebuggerStepThrough, DesignerCategory("code")]
    public class GetNewsByClassIDCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        internal GetNewsByClassIDCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public int nNewsCount
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (int) this.results[1];
            }
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


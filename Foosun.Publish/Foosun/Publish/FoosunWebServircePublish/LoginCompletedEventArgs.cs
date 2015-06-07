namespace Foosun.Publish.FoosunWebServircePublish
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;

    [DebuggerStepThrough, GeneratedCode("System.Web.Services", "4.0.30319.1"), DesignerCategory("code")]
    public class LoginCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        internal LoginCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public bool Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (bool) this.results[0];
            }
        }
    }
}


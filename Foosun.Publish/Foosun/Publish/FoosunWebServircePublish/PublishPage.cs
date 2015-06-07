namespace Foosun.Publish.FoosunWebServircePublish
{
    using Foosun.Publish.Properties;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;

    [GeneratedCode("System.Web.Services", "4.0.30319.1"), DebuggerStepThrough, DesignerCategory("code"), WebServiceBinding(Name="PublishPageSoap", Namespace="http://tempuri.org/")]
    public class PublishPage : SoapHttpClientProtocol
    {
        private SendOrPostCallback GetNewsAllOperationCompleted;
        private SendOrPostCallback GetNewsByClassIDOperationCompleted;
        private SendOrPostCallback GetNewsByCreateTimeOperationCompleted;
        private SendOrPostCallback GetNewsLastOperationCompleted;
        private SendOrPostCallback GetNewsListOperationCompleted;
        private SendOrPostCallback GetNewsUnHtmlOperationCompleted;
        private SendOrPostCallback GetPageListOperationCompleted;
        private SendOrPostCallback GetPublishResultOperationCompleted;
        private SendOrPostCallback GetSpecialListOperationCompleted;
        private SendOrPostCallback HelloWorldOperationCompleted;
        private SendOrPostCallback LoginOperationCompleted;
        private SendOrPostCallback PublishNewsOperationCompleted;
        private SendOrPostCallback PublishSingNewsOperationCompleted;
        private bool useDefaultCredentialsSetExplicitly;

        public event GetNewsAllCompletedEventHandler GetNewsAllCompleted;

        public event GetNewsByClassIDCompletedEventHandler GetNewsByClassIDCompleted;

        public event GetNewsByCreateTimeCompletedEventHandler GetNewsByCreateTimeCompleted;

        public event GetNewsLastCompletedEventHandler GetNewsLastCompleted;

        public event GetNewsListCompletedEventHandler GetNewsListCompleted;

        public event GetNewsUnHtmlCompletedEventHandler GetNewsUnHtmlCompleted;

        public event GetPageListCompletedEventHandler GetPageListCompleted;

        public event GetPublishResultCompletedEventHandler GetPublishResultCompleted;

        public event GetSpecialListCompletedEventHandler GetSpecialListCompleted;

        public event HelloWorldCompletedEventHandler HelloWorldCompleted;

        public event LoginCompletedEventHandler LoginCompleted;

        public event PublishNewsCompletedEventHandler PublishNewsCompleted;

        public event PublishSingNewsCompletedEventHandler PublishSingNewsCompleted;

        public PublishPage()
        {
            this.Url = Settings.Default.Foosun_Publish_FoosunWebServircePublish_PublishPage;
            if (this.IsLocalFileSystemWebService(this.Url))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetNewsAll", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetNewsAll(out int nNewsCount)
        {
            object[] objArray = base.Invoke("GetNewsAll", new object[0]);
            nNewsCount = (int) objArray[1];
            return (DataTable) objArray[0];
        }

        public void GetNewsAllAsync()
        {
            this.GetNewsAllAsync(null);
        }

        public void GetNewsAllAsync(object userState)
        {
            if (this.GetNewsAllOperationCompleted == null)
            {
                this.GetNewsAllOperationCompleted = new SendOrPostCallback(this.OnGetNewsAllOperationCompleted);
            }
            base.InvokeAsync("GetNewsAll", new object[0], this.GetNewsAllOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetNewsByClassID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetNewsByClassID(string classID, out int nNewsCount)
        {
            object[] objArray = base.Invoke("GetNewsByClassID", new object[] { classID });
            nNewsCount = (int) objArray[1];
            return (DataTable) objArray[0];
        }

        public void GetNewsByClassIDAsync(string classID)
        {
            this.GetNewsByClassIDAsync(classID, null);
        }

        public void GetNewsByClassIDAsync(string classID, object userState)
        {
            if (this.GetNewsByClassIDOperationCompleted == null)
            {
                this.GetNewsByClassIDOperationCompleted = new SendOrPostCallback(this.OnGetNewsByClassIDOperationCompleted);
            }
            base.InvokeAsync("GetNewsByClassID", new object[] { classID }, this.GetNewsByClassIDOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetNewsByCreateTime", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetNewsByCreateTime(DateTime beginTime, DateTime endTime, out int nNewsCount)
        {
            object[] objArray = base.Invoke("GetNewsByCreateTime", new object[] { beginTime, endTime });
            nNewsCount = (int) objArray[1];
            return (DataTable) objArray[0];
        }

        public void GetNewsByCreateTimeAsync(DateTime beginTime, DateTime endTime)
        {
            this.GetNewsByCreateTimeAsync(beginTime, endTime, null);
        }

        public void GetNewsByCreateTimeAsync(DateTime beginTime, DateTime endTime, object userState)
        {
            if (this.GetNewsByCreateTimeOperationCompleted == null)
            {
                this.GetNewsByCreateTimeOperationCompleted = new SendOrPostCallback(this.OnGetNewsByCreateTimeOperationCompleted);
            }
            base.InvokeAsync("GetNewsByCreateTime", new object[] { beginTime, endTime }, this.GetNewsByCreateTimeOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetNewsLast", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetNewsLast(int lastNum, out int nNewsCount)
        {
            object[] objArray = base.Invoke("GetNewsLast", new object[] { lastNum });
            nNewsCount = (int) objArray[1];
            return (DataTable) objArray[0];
        }

        public void GetNewsLastAsync(int lastNum)
        {
            this.GetNewsLastAsync(lastNum, null);
        }

        public void GetNewsLastAsync(int lastNum, object userState)
        {
            if (this.GetNewsLastOperationCompleted == null)
            {
                this.GetNewsLastOperationCompleted = new SendOrPostCallback(this.OnGetNewsLastOperationCompleted);
            }
            base.InvokeAsync("GetNewsLast", new object[] { lastNum }, this.GetNewsLastOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetNewsList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetNewsList()
        {
            return (DataTable) base.Invoke("GetNewsList", new object[0])[0];
        }

        public void GetNewsListAsync()
        {
            this.GetNewsListAsync(null);
        }

        public void GetNewsListAsync(object userState)
        {
            if (this.GetNewsListOperationCompleted == null)
            {
                this.GetNewsListOperationCompleted = new SendOrPostCallback(this.OnGetNewsListOperationCompleted);
            }
            base.InvokeAsync("GetNewsList", new object[0], this.GetNewsListOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetNewsUnHtml", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetNewsUnHtml(int topNum, out int nNewsCount)
        {
            object[] objArray = base.Invoke("GetNewsUnHtml", new object[] { topNum });
            nNewsCount = (int) objArray[1];
            return (DataTable) objArray[0];
        }

        public void GetNewsUnHtmlAsync(int topNum)
        {
            this.GetNewsUnHtmlAsync(topNum, null);
        }

        public void GetNewsUnHtmlAsync(int topNum, object userState)
        {
            if (this.GetNewsUnHtmlOperationCompleted == null)
            {
                this.GetNewsUnHtmlOperationCompleted = new SendOrPostCallback(this.OnGetNewsUnHtmlOperationCompleted);
            }
            base.InvokeAsync("GetNewsUnHtml", new object[] { topNum }, this.GetNewsUnHtmlOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetPageList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetPageList()
        {
            return (DataTable) base.Invoke("GetPageList", new object[0])[0];
        }

        public void GetPageListAsync()
        {
            this.GetPageListAsync(null);
        }

        public void GetPageListAsync(object userState)
        {
            if (this.GetPageListOperationCompleted == null)
            {
                this.GetPageListOperationCompleted = new SendOrPostCallback(this.OnGetPageListOperationCompleted);
            }
            base.InvokeAsync("GetPageList", new object[0], this.GetPageListOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetPublishResult", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string GetPublishResult()
        {
            return (string) base.Invoke("GetPublishResult", new object[0])[0];
        }

        public void GetPublishResultAsync()
        {
            this.GetPublishResultAsync(null);
        }

        public void GetPublishResultAsync(object userState)
        {
            if (this.GetPublishResultOperationCompleted == null)
            {
                this.GetPublishResultOperationCompleted = new SendOrPostCallback(this.OnGetPublishResultOperationCompleted);
            }
            base.InvokeAsync("GetPublishResult", new object[0], this.GetPublishResultOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/GetSpecialList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public DataTable GetSpecialList()
        {
            return (DataTable) base.Invoke("GetSpecialList", new object[0])[0];
        }

        public void GetSpecialListAsync()
        {
            this.GetSpecialListAsync(null);
        }

        public void GetSpecialListAsync(object userState)
        {
            if (this.GetSpecialListOperationCompleted == null)
            {
                this.GetSpecialListOperationCompleted = new SendOrPostCallback(this.OnGetSpecialListOperationCompleted);
            }
            base.InvokeAsync("GetSpecialList", new object[0], this.GetSpecialListOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string HelloWorld()
        {
            return (string) base.Invoke("HelloWorld", new object[0])[0];
        }

        public void HelloWorldAsync()
        {
            this.HelloWorldAsync(null);
        }

        public void HelloWorldAsync(object userState)
        {
            if (this.HelloWorldOperationCompleted == null)
            {
                this.HelloWorldOperationCompleted = new SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            base.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }

        private bool IsLocalFileSystemWebService(string url)
        {
            if ((url == null) || (url == string.Empty))
            {
                return false;
            }
            Uri uri = new Uri(url);
            return ((uri.Port >= 0x400) && (string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0));
        }

        [SoapDocumentMethod("http://tempuri.org/Login", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public bool Login(string userName, string passWord)
        {
            return (bool) base.Invoke("Login", new object[] { userName, passWord })[0];
        }

        public void LoginAsync(string userName, string passWord)
        {
            this.LoginAsync(userName, passWord, null);
        }

        public void LoginAsync(string userName, string passWord, object userState)
        {
            if (this.LoginOperationCompleted == null)
            {
                this.LoginOperationCompleted = new SendOrPostCallback(this.OnLoginOperationCompleted);
            }
            base.InvokeAsync("Login", new object[] { userName, passWord }, this.LoginOperationCompleted, userState);
        }

        private void OnGetNewsAllOperationCompleted(object arg)
        {
            if (this.GetNewsAllCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetNewsAllCompleted(this, new GetNewsAllCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetNewsByClassIDOperationCompleted(object arg)
        {
            if (this.GetNewsByClassIDCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetNewsByClassIDCompleted(this, new GetNewsByClassIDCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetNewsByCreateTimeOperationCompleted(object arg)
        {
            if (this.GetNewsByCreateTimeCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetNewsByCreateTimeCompleted(this, new GetNewsByCreateTimeCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetNewsLastOperationCompleted(object arg)
        {
            if (this.GetNewsLastCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetNewsLastCompleted(this, new GetNewsLastCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetNewsListOperationCompleted(object arg)
        {
            if (this.GetNewsListCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetNewsListCompleted(this, new GetNewsListCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetNewsUnHtmlOperationCompleted(object arg)
        {
            if (this.GetNewsUnHtmlCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetNewsUnHtmlCompleted(this, new GetNewsUnHtmlCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetPageListOperationCompleted(object arg)
        {
            if (this.GetPageListCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetPageListCompleted(this, new GetPageListCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetPublishResultOperationCompleted(object arg)
        {
            if (this.GetPublishResultCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetPublishResultCompleted(this, new GetPublishResultCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetSpecialListOperationCompleted(object arg)
        {
            if (this.GetSpecialListCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetSpecialListCompleted(this, new GetSpecialListCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnHelloWorldOperationCompleted(object arg)
        {
            if (this.HelloWorldCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnLoginOperationCompleted(object arg)
        {
            if (this.LoginCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.LoginCompleted(this, new LoginCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnPublishNewsOperationCompleted(object arg)
        {
            if (this.PublishNewsCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.PublishNewsCompleted(this, new PublishNewsCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnPublishSingNewsOperationCompleted(object arg)
        {
            if (this.PublishSingNewsCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.PublishSingNewsCompleted(this, new PublishSingNewsCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        [SoapDocumentMethod("http://tempuri.org/PublishNews", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string PublishNews(bool PublishIndex, bool BakIndex, bool isPubNew, int newsFlag, string newsPara, bool isPubClass, int classFlag, string classPara, bool isPubSpcial, int specialFlag, string specialPara, bool isPubPage, int pageFlag, string pagePara, bool isClassIndex)
        {
            return (string) base.Invoke("PublishNews", new object[] { PublishIndex, BakIndex, isPubNew, newsFlag, newsPara, isPubClass, classFlag, classPara, isPubSpcial, specialFlag, specialPara, isPubPage, pageFlag, pagePara, isClassIndex })[0];
        }

        public void PublishNewsAsync(bool PublishIndex, bool BakIndex, bool isPubNew, int newsFlag, string newsPara, bool isPubClass, int classFlag, string classPara, bool isPubSpcial, int specialFlag, string specialPara, bool isPubPage, int pageFlag, string pagePara, bool isClassIndex)
        {
            this.PublishNewsAsync(PublishIndex, BakIndex, isPubNew, newsFlag, newsPara, isPubClass, classFlag, classPara, isPubSpcial, specialFlag, specialPara, isPubPage, pageFlag, pagePara, isClassIndex, null);
        }

        public void PublishNewsAsync(bool PublishIndex, bool BakIndex, bool isPubNew, int newsFlag, string newsPara, bool isPubClass, int classFlag, string classPara, bool isPubSpcial, int specialFlag, string specialPara, bool isPubPage, int pageFlag, string pagePara, bool isClassIndex, object userState)
        {
            if (this.PublishNewsOperationCompleted == null)
            {
                this.PublishNewsOperationCompleted = new SendOrPostCallback(this.OnPublishNewsOperationCompleted);
            }
            base.InvokeAsync("PublishNews", new object[] { PublishIndex, BakIndex, isPubNew, newsFlag, newsPara, isPubClass, classFlag, classPara, isPubSpcial, specialFlag, specialPara, isPubPage, pageFlag, pagePara, isClassIndex }, this.PublishNewsOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://tempuri.org/PublishSingNews", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public bool PublishSingNews(string newsID, string classID, string templet, string isDelPoint, string SavePath1, string SaveClassframe, string SavePath, string FileName, string FileEXName, string CommTF)
        {
            return (bool) base.Invoke("PublishSingNews", new object[] { newsID, classID, templet, isDelPoint, SavePath1, SaveClassframe, SavePath, FileName, FileEXName, CommTF })[0];
        }

        public void PublishSingNewsAsync(string newsID, string classID, string templet, string isDelPoint, string SavePath1, string SaveClassframe, string SavePath, string FileName, string FileEXName, string CommTF)
        {
            this.PublishSingNewsAsync(newsID, classID, templet, isDelPoint, SavePath1, SaveClassframe, SavePath, FileName, FileEXName, CommTF, null);
        }

        public void PublishSingNewsAsync(string newsID, string classID, string templet, string isDelPoint, string SavePath1, string SaveClassframe, string SavePath, string FileName, string FileEXName, string CommTF, object userState)
        {
            if (this.PublishSingNewsOperationCompleted == null)
            {
                this.PublishSingNewsOperationCompleted = new SendOrPostCallback(this.OnPublishSingNewsOperationCompleted);
            }
            base.InvokeAsync("PublishSingNews", new object[] { newsID, classID, templet, isDelPoint, SavePath1, SaveClassframe, SavePath, FileName, FileEXName, CommTF }, this.PublishSingNewsOperationCompleted, userState);
        }

        public string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if (!((!this.IsLocalFileSystemWebService(base.Url) || this.useDefaultCredentialsSetExplicitly) || this.IsLocalFileSystemWebService(value)))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
    }
}


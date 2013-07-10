using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Collections.Specialized;

namespace Utility.Update
{
    public class DownloadErrorEventArgs : EventArgs
    {
        public Exception Error { get; set; }

        public Manifest Manifest { get; set; }
    }

    public class DownloadProgressEventArgs : ProgressChangedEventArgs
    {
        public DownloadProgressEventArgs(int progressPercentage, object userState)
            : base(progressPercentage,userState)
        { }

        /// <summary>
        /// 当前下载的文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 获取收到的字节数。
        /// </summary>
        public long BytesReceived { get; set; }
        /// <summary>
        /// 获取 System.Net.WebClient 数据下载操作中的字节总数。
        /// </summary>
        public long TotalBytesToReceive { get; set; }
    }

    public class DownloadCompleteEventArgs : AsyncCompletedEventArgs
    {
        public DownloadCompleteEventArgs(Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        { 
        }

        public Manifest Manifest { get; set; }
    }

    public class DownloadClass : Component
    {
        private WebClient webClient=new WebClient();
        private Manifest manifest;
        private int fileCount = 0;
        private bool cancel = false;
        private string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");

        private HybridDictionary userStateToLifetime = new HybridDictionary();
        private object defaultTaskId = new object();
        private delegate void WorkerEventHandler(AsyncOperation asyncOp);
        private System.ComponentModel.Container components = null;
        private SendOrPostCallback onProgressReportDelegate;
        private SendOrPostCallback onCompletedDelegate;
        private AsyncOperation current;

        /// <summary>
        /// 下载进度
        /// </summary>
        public event EventHandler<DownloadProgressEventArgs> DownloadProgressChanged;
        /// <summary>
        /// 下载完成事件
        /// </summary>
        public event EventHandler<DownloadCompleteEventArgs> DownloadCompleted;
        /// <summary>
        /// 下载错误触发的事件
        /// </summary>
        public event EventHandler<DownloadErrorEventArgs> DownloadError;

        public DownloadClass(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeDelegates();
        }

        public DownloadClass()
        {
            InitializeComponent();
            InitializeDelegates();
        }

        /// <summary>
        /// 初始化代理
        /// </summary>
        protected virtual void InitializeDelegates()
        {
            onProgressReportDelegate = new SendOrPostCallback(ReportProgress);
            onCompletedDelegate = new SendOrPostCallback(DoDownloadCompleted);
        }

        /// <summary>
        /// 触发下载进度事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDownloadProgressChanged(DownloadProgressEventArgs e)
        {
            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(this, e);
            }
        }

        /// <summary>
        /// 触发下载完成事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDownloadCompleted(DownloadCompleteEventArgs e)
        {
            if (DownloadCompleted != null)
            {
                DownloadCompleted(this, e);
            }
        }

        /// <summary>
        /// 触发下载错误事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDownloadError(DownloadErrorEventArgs e)
        {
            if (DownloadError != null)
            {
                DownloadError(this, e);
            }
        }

        /// <summary>
        /// 下载文字保存的临时目录
        /// </summary>
        public string TempPath
        {
            get
            {
                return tempPath;
            }
            set
            {
                tempPath = value;
            }
        }

        /// <summary>
        /// 同步下载
        /// </summary>
        /// <param name="manifest"></param>
        public void Download(Manifest manifest)
        {
            Init(manifest);
            foreach (var file in manifest.ManifestFiles.Files)
            {
                string serverFileName = Path.Combine(manifest.ManifestFiles.BaseUrl, file.Source);
                string clientFileName = Path.Combine(tempPath, file.Source);
                Uri uri = new Uri(serverFileName);
                if (!Directory.Exists(Path.GetDirectoryName(clientFileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(clientFileName));
                }
                webClient.DownloadFile(uri, clientFileName);
            }
        }

        /// <summary>
        /// 异步下载
        /// </summary>
        /// <param name="manifest"></param>
        public void DownloadAsync(Manifest manifest)
        {
            Init(manifest);
            DownloadAsync(manifest,defaultTaskId);
        }

        /// <summary>
        /// 异步下载并指定任务Id
        /// </summary>
        /// <param name="manifest"></param>
        /// <param name="taskId"></param>
        public void DownloadAsync(Manifest manifest,object taskId)
        {
            AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(taskId);
            lock (userStateToLifetime.SyncRoot)
            {
                if (userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException("参数taskId必须是唯一的", "taskId");
                }
                userStateToLifetime[taskId] = asyncOp;
            }
            WorkerEventHandler workerDelegate = new WorkerEventHandler(DownloadWorker);
            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private void Init(Manifest manifest)
        {
            this.manifest = manifest;
            webClient.BaseAddress = manifest.ManifestFiles.BaseUrl;
            webClient.Credentials = CredentialCache.DefaultCredentials;
            webClient.Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// 异步下载方法
        /// </summary>
        /// <param name="asyncOp"></param>
        private void DownloadWorker(AsyncOperation asyncOp)
        {
            current = asyncOp;
            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    foreach (var file in manifest.ManifestFiles.Files)
                    {
                        string serverFileName = Path.Combine(manifest.ManifestFiles.BaseUrl, file.Source);
                        string clientFileName = Path.Combine(tempPath, file.Source);
                        Uri uri = new Uri(serverFileName);
                        if (!Directory.Exists(Path.GetDirectoryName(clientFileName)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(clientFileName));
                        }
                        while (webClient.IsBusy)
                        {
                            //阻塞异步下载
                        }
                        if (!cancel)
                        {
                            webClient.DownloadFileAsync(uri, clientFileName, file.Source);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DownloadErrorEventArgs e = new DownloadErrorEventArgs();
                    e.Error = ex;
                    e.Manifest = manifest;
                    OnDownloadError(e);
                }
            }
        }

        /// <summary>
        /// 异步完成方法
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="canceled"></param>
        /// <param name="asyncOp"></param>
        private void CompletionMethod(Exception exception, bool canceled, AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }
            DownloadCompleteEventArgs e = new DownloadCompleteEventArgs(exception, canceled, asyncOp.UserSuppliedState);
            e.Manifest = manifest;
            asyncOp.PostOperationCompleted(onCompletedDelegate, e);
            current = null;
        }

        /// <summary>
        /// 异步下载进度事件（仅对于单个文件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressEventArgs args = new DownloadProgressEventArgs(e.ProgressPercentage, e.UserState);
            args.BytesReceived = e.BytesReceived;
            args.FileName = e.UserState.ToString();
            args.TotalBytesToReceive = e.TotalBytesToReceive;
            if (current != null)
            {
                current.Post(onProgressReportDelegate, args);
            }
        }

        /// <summary>
        /// 异步下载完成事件（仅对于单个文件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            fileCount++;
            if (fileCount == manifest.ManifestFiles.Files.Length)
            {
                this.CompletionMethod(e.Error, TaskCanceled(current.UserSuppliedState), current);
            }
        }

        /// <summary>
        /// 取消异步下载
        /// </summary>
        public void CancelAsync()
        {
            CancelAsync(defaultTaskId);
        }

        /// <summary>
        /// 取消异步下载
        /// </summary>
        public void CancelAsync(object taskId)
        {
            webClient.CancelAsync();
            cancel = true;
            current = null;
            AsyncOperation asyncOp = userStateToLifetime[taskId] as AsyncOperation;
            if (asyncOp != null)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(taskId);
                }
            }
        }

        private bool TaskCanceled(object taskId)
        {
            return cancel || (userStateToLifetime[taskId] == null);
        }
        
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void DoDownloadCompleted(object operationState)
        {
            DownloadCompleteEventArgs e = operationState as DownloadCompleteEventArgs;
            OnDownloadCompleted(e);
        }

        private void ReportProgress(object state)
        {
            DownloadProgressEventArgs e = state as DownloadProgressEventArgs;
            OnDownloadProgressChanged(e);
        }
    }

}

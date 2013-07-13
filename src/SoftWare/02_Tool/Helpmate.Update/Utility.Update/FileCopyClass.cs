using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Collections.Specialized;
using System.Collections;
using System.IO;

namespace Utility.Update
{
    /// <summary>
    /// 文件复制进度报告事件参数
    /// </summary>
    public class FileCopyProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public FileCopyProgressChangedEventArgs(int progressPercentage, object userState)
            : base(progressPercentage, userState)
        {
        }

        /// <summary>
        /// 当前复制的字节数
        /// </summary>
        public double BytesToCopy { get; set; }

        /// <summary>
        /// 当前复制操作中的字节总数
        /// </summary>
        public double TotalBytesToCopy { get; set; }

        /// <summary>
        /// 当前复制的源文件名
        /// </summary>
        public string SourceFileName { get; set; }

        /// <summary>
        /// 当前复制的目标文件名
        /// </summary>
        public string TargetFileName { get; set; }

        public Manifest Manifest { get; set; }
    }

    /// <summary>
    /// 文件复制完成事件参数
    /// </summary>
    public class FileCopyCompletedEventArgs : AsyncCompletedEventArgs
    {
        public FileCopyCompletedEventArgs(Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {
        }

        public Manifest Manifest { get; set; }
    }

    public class FileCopyErrorEventArgs : EventArgs
    {
        public Exception Error { get; set; }

        public Manifest Manifest { get; set; }
    }

    /// <summary>
    /// 文件复制组件类
    /// </summary>
    public class FileCopyClass : Component
    {
        private object defaultTaskId = new object();
        private int writeFileLength = 1024 * 64;

        private delegate void WorkerEventHandler(Manifest manifest, string sourcePath, AsyncOperation asyncOp);

        private SendOrPostCallback onProgressReportDelegate;
        private SendOrPostCallback onCompletedDelegate;

        private HybridDictionary userStateToLifetime = new HybridDictionary();

        private System.ComponentModel.Container components = null;

        #region Public events

        /// <summary>
        /// 文件复制进度事件
        /// </summary>
        public event EventHandler<FileCopyProgressChangedEventArgs> FileCopyProgressChanged;
        /// <summary>
        /// 文件复制完成事件
        /// </summary>
        public event EventHandler<FileCopyCompletedEventArgs> FileCopyCompleted;

        public event EventHandler<FileCopyErrorEventArgs> FileCopyError;

        #endregion

        #region Construction and destruction

        public FileCopyClass(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeDelegates();
        }

        public FileCopyClass()
        {
            InitializeComponent();
            InitializeDelegates();
        }

        protected virtual void InitializeDelegates()
        {
            onProgressReportDelegate = new SendOrPostCallback(ReportProgress);
            onCompletedDelegate = new SendOrPostCallback(CopyCompleted);
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

        #endregion

        #region 实现

        public int WriteFileLength
        {
            set
            {
                writeFileLength = value;
            }
        }

        public void Copy(Manifest manifest, string sourcePath)
        {
            string[] sourceFiles = null;
            string[] targetFiles = null;
            GetFiles(manifest, sourcePath, out sourceFiles, out targetFiles);
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                if (!Directory.Exists(Path.GetDirectoryName(targetFiles[i])))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(targetFiles[i]));
                }
                File.Copy(sourceFiles[i], targetFiles[i], true);
            }
        }

        public void CopyAsync(Manifest manifest, string sourcePath)
        {
            CopyAsync(manifest, sourcePath, defaultTaskId);
        }

        public void CopyAsync(Manifest manifest, string sourcePath, object taskId)
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

            WorkerEventHandler workerDelegate = new WorkerEventHandler(FileCopyWorker);
            workerDelegate.BeginInvoke(manifest, sourcePath, asyncOp, null, null);
        }

        private bool TaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }

        public void CancelAsync()
        {
            CancelAsync(defaultTaskId);
        }

        public void CancelAsync(object taskId)
        {
            AsyncOperation asyncOp = userStateToLifetime[taskId] as AsyncOperation;
            if (asyncOp != null)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(taskId);
                }
            }
        }

        private void FileCopyWorker(Manifest manifest, string sourcePath, AsyncOperation asyncOp)
        {
            Exception exception = null;
            FileCopyProgressChangedEventArgs e = null;
            Stream rStream = null;
            Stream wStream = null;
            double writeBytes = 0;
            string[] sourceFiles = null;
            string[] targetFiles = null;
            GetFiles(manifest, sourcePath, out sourceFiles, out targetFiles);
            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    double totalBytes = GetFileLength(sourceFiles);
                    byte[] buffer = new byte[writeFileLength];
                    int len = 0;
                    int offset = 0;
                    for (int i = 0; i < sourceFiles.Length; i++)
                    {
                        try
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(targetFiles[i])))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(targetFiles[i]));
                            }
                            rStream = new FileStream(sourceFiles[i], FileMode.Open, FileAccess.Read, FileShare.None);
                            wStream = new FileStream(targetFiles[i], FileMode.Create, FileAccess.Write, FileShare.None);
                            while ((len = rStream.Read(buffer, offset, writeFileLength)) > 0)
                            {
                                wStream.Write(buffer, offset, len);
                                writeBytes += len;
                                e = new FileCopyProgressChangedEventArgs((int)(writeBytes / totalBytes * 100), asyncOp.UserSuppliedState);
                                e.SourceFileName = sourceFiles[i];
                                e.TargetFileName = targetFiles[i];
                                e.TotalBytesToCopy = totalBytes;
                                e.BytesToCopy = len;
                                e.Manifest = manifest;
                                asyncOp.Post(this.onProgressReportDelegate, e);
                                Thread.Sleep(1);
                            }
                        }
                        finally
                        {
                            DisposeStream(wStream);
                            DisposeStream(rStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                    OnFileCopyError(new FileCopyErrorEventArgs() { Error = ex, Manifest = manifest });
                }

                if (exception == null && targetFiles.Length > 0)
                {
                    //解压文件
                    string fileName = targetFiles.First();
                    ZipHelper.DeCompressionZip(fileName, Path.GetFullPath("."));
                    File.Delete(fileName);
                }
            }
            this.CompletionMethod(manifest, exception, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        private void GetFiles(Manifest manifest, string sourcePath, out string[] sourceFiles, out string[] targetFiles)
        {
            sourceFiles = new string[manifest.ManifestFiles.Files.Length];
            targetFiles = new string[manifest.ManifestFiles.Files.Length];
            string path = Path.GetFullPath(manifest.Application.Location);
            for (int i = 0; i < manifest.ManifestFiles.Files.Length; i++)
            {
                sourceFiles[i] = Path.Combine(sourcePath, manifest.ManifestFiles.Files[i].Source);
                targetFiles[i] = Path.Combine(path, manifest.ManifestFiles.Files[i].Source);
            }
        }

        private void DisposeStream(Stream stream)
        {
            if (stream != null)
            {
                stream.Flush();
                stream.Close();
                stream.Dispose();
            }
        }

        private double GetFileLength(string[] sourceFiles)
        {
            double bytes = 0;
            foreach (var file in sourceFiles)
            {
                FileInfo fileInfo = new FileInfo(file);
                bytes += fileInfo.Length;
            }
            return bytes;
        }

        private void CopyCompleted(object operationState)
        {
            FileCopyCompletedEventArgs e = operationState as FileCopyCompletedEventArgs;

            OnFileCopyCompleted(e);
        }

        private void ReportProgress(object state)
        {
            FileCopyProgressChangedEventArgs e = state as FileCopyProgressChangedEventArgs;

            OnProgressChanged(e);
        }

        protected void OnFileCopyCompleted(FileCopyCompletedEventArgs e)
        {
            if (FileCopyCompleted != null)
            {
                FileCopyCompleted(this, e);
            }
        }

        protected void OnProgressChanged(FileCopyProgressChangedEventArgs e)
        {
            if (FileCopyProgressChanged != null)
            {
                FileCopyProgressChanged(this, e);
            }
        }

        protected void OnFileCopyError(FileCopyErrorEventArgs e)
        {
            if (FileCopyError != null)
            {
                FileCopyError(this, e);
            }
        }

        private void CompletionMethod(Manifest manifest, Exception exception, bool canceled, AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            FileCopyCompletedEventArgs e = new FileCopyCompletedEventArgs(exception, canceled, asyncOp.UserSuppliedState);
            e.Manifest = manifest;
            asyncOp.PostOperationCompleted(onCompletedDelegate, e);
        }

        #endregion

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
    }

}

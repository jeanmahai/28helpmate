using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;

namespace Utility.Update
{
    public class ManifestEventArgs : EventArgs
    {
        public Manifest Manifest { get; set; }
    }

    public class ActivationStartedEventArgs : EventArgs
    {
        public Manifest Manifest { get; set; }

        public bool Cancel { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class ActivationCompletedEventArgs : AsyncCompletedEventArgs
    {
        public ActivationCompletedEventArgs(Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {
        }

        public Manifest Manifest { get; set; }
    }

    public class UpdateClass
    {
        private DownloadClass downloader = new DownloadClass();
        private FileCopyClass fileCopyer = new FileCopyClass();
        private UpdaterConfigurationView updateCfgView = new UpdaterConfigurationView();
        private string backupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backup");

        #region events
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

        public event EventHandler<ManifestEventArgs> ActivationInitializing;

        public event EventHandler<ActivationCompletedEventArgs> ActivationCompleted;

        public event EventHandler<ActivationStartedEventArgs> ActivationStarted;

        public event EventHandler<FileCopyProgressChangedEventArgs> ActivationProgressChanged;

        public event EventHandler<FileCopyErrorEventArgs> ActivationError;
        #endregion

        public UpdateClass()
        {
            downloader.DownloadCompleted += new EventHandler<DownloadCompleteEventArgs>(downloader_DownloadCompleted);
            downloader.DownloadError += new EventHandler<DownloadErrorEventArgs>(downloader_DownloadError);
            downloader.DownloadProgressChanged += new EventHandler<DownloadProgressEventArgs>(downloader_DownloadProgressChanged);
            fileCopyer.FileCopyError += new EventHandler<FileCopyErrorEventArgs>(fileCopyer_FileCopyError);
            fileCopyer.FileCopyCompleted += new EventHandler<FileCopyCompletedEventArgs>(fileCopyer_FileCopyCompleted);
            fileCopyer.FileCopyProgressChanged += new EventHandler<FileCopyProgressChangedEventArgs>(fileCopyer_FileCopyProgressChanged);
        }

        public DownloadClass Downloader
        {
            get
            {
                return downloader;
            }
        }

        public FileCopyClass FileCopyer
        {
            get
            {
                return fileCopyer;
            }
        }

        public Manifest[] CheckForUpdates()
        {
            Uri uri = new Uri(updateCfgView.ManifestUri);
            string doc = DownLoadFile(uri);
            XmlSerializer xser = new XmlSerializer(typeof(Manifest));
            var manifest = xser.Deserialize(new XmlTextReader(doc, XmlNodeType.Document, null)) as Manifest;
            if (manifest == null ||
                manifest.Version == updateCfgView.Version ||
                manifest.Application.ApplicationId != updateCfgView.ApplicationId)
            {
                return new Manifest[0];
            }
            return new Manifest[] { manifest };
        }

        private string DownLoadFile(Uri uri)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            string response = String.Empty;
            using (WebResponse res = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(res.GetResponseStream(), true))
                {
                    response = reader.ReadToEnd();
                }
            }
            return response;
        }

        public void Download(Manifest[] manifests)
        {
            foreach (var m in manifests)
            {
                downloader.Download(m);
            }
        }

        public void DownloadAsync(Manifest[] manifests)
        {
            foreach (var m in manifests)
            {
                downloader.DownloadAsync(m);
            }
        }

        public void Activate(Manifest[] manifests)
        {
            foreach (var m in manifests)
            {
                OnActivationInitializing(new ManifestEventArgs() { Manifest = m });
                Backup(m);
                ActivationStartedEventArgs e = new ActivationStartedEventArgs() { Manifest = m };
                OnActivationStarted(e);
                if (e.Cancel)
                {
                    Clear();
                    break;
                }
                else
                {
                    fileCopyer.CopyAsync(m, downloader.TempPath);
                }
            }
        }

        private void Backup(Manifest manifest)
        {
            try
            {
                string sourcePath = Path.GetFullPath(manifest.Application.Location);
                string s_filename = string.Empty;
                string t_filename = string.Empty;
                if (!Directory.Exists(backupFilePath))
                {
                    Directory.CreateDirectory(backupFilePath);
                }
                foreach (var file in manifest.ManifestFiles.Files)
                {
                    t_filename = Path.Combine(backupFilePath, file.Source);
                    s_filename = Path.Combine(sourcePath, file.Source);
                    if (File.Exists(s_filename))
                    {
                        File.Copy(s_filename, t_filename, true);
                    }
                }
            }
            catch
            {
            }
        }

        public void Rollback(Manifest manifest)
        {
            try
            {
                string filename = string.Empty;
                foreach (var file in manifest.ManifestFiles.Files)
                {
                    filename = Path.Combine(backupFilePath, file.Source);
                    File.Copy(filename, Path.Combine(Path.GetFullPath(manifest.Application.Location), file.Source));
                }
                Directory.Delete(backupFilePath, true);
            }
            catch
            {
            }
        }

        private void Clear()
        {
            try
            {
                Directory.Delete(backupFilePath, true);
                Directory.Delete(downloader.TempPath, true);
            }
            catch
            { }
        }

        #region onevents

        private void fileCopyer_FileCopyError(object sender, FileCopyErrorEventArgs e)
        {
            OnActivationError(e);
        }

        private void fileCopyer_FileCopyProgressChanged(object sender, FileCopyProgressChangedEventArgs e)
        {
            if (ActivationProgressChanged != null)
            {
                ActivationProgressChanged(sender, e);
            }
        }

        private void fileCopyer_FileCopyCompleted(object sender, FileCopyCompletedEventArgs e)
        {
            Clear();
            try
            {
                updateCfgView.Version = e.Manifest.Version;
            }
            catch
            {
            }
            if (ActivationCompleted != null)
            {
                ActivationCompletedEventArgs evt = new ActivationCompletedEventArgs(e.Error, e.Cancelled, e.UserState);
                evt.Manifest = e.Manifest;
                OnActivationCompleted(evt);
            }
        }

        private void downloader_DownloadProgressChanged(object sender, DownloadProgressEventArgs e)
        {
            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(sender, e);
            }
        }

        private void downloader_DownloadError(object sender, DownloadErrorEventArgs e)
        {
            if (DownloadError != null)
            {
                DownloadError(sender, e);
            }
        }

        private void downloader_DownloadCompleted(object sender, DownloadCompleteEventArgs e)
        {
            if (DownloadCompleted != null)
            {
                DownloadCompleted(sender, e);
            }
        }

        private void OnActivationInitializing(ManifestEventArgs e)
        {
            if (ActivationInitializing != null)
            {
                ActivationInitializing(this, e);
            }
        }

        private void OnActivationStarted(ActivationStartedEventArgs e)
        {
            if (ActivationStarted != null)
            {
                ActivationStarted(this, e);
            }
        }

        private void OnActivationCompleted(ActivationCompletedEventArgs e)
        {
            if (ActivationCompleted != null)
            {
                ActivationCompleted(this, e);
            }
        }

        private void OnActivationError(FileCopyErrorEventArgs e)
        {
            if (ActivationError != null)
            {
                ActivationError(this, e);
            }
        }

        private void OnActivationProgressChanged(FileCopyProgressChangedEventArgs e)
        {
            if (ActivationProgressChanged != null)
            {
                ActivationProgressChanged(this, e);
            }
        }

        #endregion

    }
}

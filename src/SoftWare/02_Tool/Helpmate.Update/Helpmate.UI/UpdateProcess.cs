using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Updater.Core;
using Updater;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Helpmate.UI
{
    public partial class UpdateProcess : Form
    {
        //主程序传入的参数，系统标示 是否需要重新启动主程序
        private string[] args;
        //表示主程序打开时传入的参数
        private readonly static string OPEN_FLAG = "121";
        private bool isComplete = true;

        private UpdateClass updater;
        private List<Manifest> mList = new List<Manifest>();
        private int mLen = 0;

        public UpdateProcess()
        {
            InitializeComponent();
        }

        public UpdateProcess(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }

        private void nfiUpdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.Visible)
                {
                    this.Hide();
                    nfiUpdate.Visible = true;
                }
                else
                {
                    this.Show();
                    nfiUpdate.Visible = false;
                }
            }
        }

        private void MenuItem_exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

       

        private void picClose_Click(object sender, EventArgs e)
        {
            if (isComplete)
            {
                Exit();
            }
            else
            {
                this.Hide();
                nfiUpdate.Visible = true;
            }
        }

        private void UpdateProcess_Load(object sender, EventArgs e)
        {
            try
            {
                updater = new UpdateClass();
                updater.ActivationCompleted += new EventHandler<ActivationCompletedEventArgs>(ActivationCompleted);
                updater.ActivationError += new EventHandler<FileCopyErrorEventArgs>(ActivationError);
                updater.ActivationInitializing += new EventHandler<ManifestEventArgs>(ActivationInitializing);
                updater.ActivationProgressChanged += new EventHandler<FileCopyProgressChangedEventArgs>(ActivationProgressChanged);
                updater.ActivationStarted += new EventHandler<ActivationStartedEventArgs>(ActivationStarted);
                updater.DownloadCompleted += new EventHandler<DownloadCompleteEventArgs>(DownloadCompleted);
                updater.DownloadError += new EventHandler<DownloadErrorEventArgs>(DownloadError);
                updater.DownloadProgressChanged += new EventHandler<DownloadProgressEventArgs>(DownloadProgressChanged);

                InitUpdater();
            }
            catch (Exception ex)
            {
                Log.Write("更新错误：" + ex.Message);
                MessageBox.Show("更新错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region 系统方法

        private void InitUpdater()
        {
            var m = updater.CheckForUpdates();
            mLen = m.Length;
            if (mLen > 0)
            {
                if (args != null && args.Length > 0)
                {
                    //关闭主程序
                    ExeCommand("taskkill /im " + m[0].Application.EntryPoint.File + " /f ");
                }
                isComplete = false;
                updater.DownloadAsync(m);
            }
            else
            {
                lab_filename.Text = "";
                //不需要更新，如果args不为空表示是由主程序打开
                InvokeAction(() =>
                {
                    MessageBox.Show("您当前的版本已经是最新，不需要更新。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
        }

        private void Startup(string entryPoint, string parameters)
        {
            try
            {
                if (args != null && args.Length > 0)
                {
                    if (args[0] == OPEN_FLAG)
                    {
                        //关闭主程序
                        ExeCommand("taskkill /im " + Path.GetFileName(entryPoint) + " /f ");
                        //启动主程序
                        System.Threading.Thread.Sleep(1500);
                        System.Diagnostics.Process.Start(entryPoint, parameters);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        private void Exit()
        {
            nfiUpdate.Visible = false;
            nfiUpdate.Dispose();
            this.Close();
            Environment.Exit(0);
        }

        private void ExeCommand(string commandText)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(commandText);
                p.StandardInput.WriteLine("exit");
                //p.StandardOutput.ReadToEnd();
            }
            catch
            {

            }
        }

        private void InvokeAction(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        #endregion 系统方法

        #region 鼠标选中移动窗体

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = System.Windows.Forms.Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y); //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
        #endregion

        #region events

        void DownloadProgressChanged(object sender, DownloadProgressEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lab_percent.Text = e.ProgressPercentage.ToString() + "%";
            lab_percent.Update();
            lab_fileinfo.Text = string.Format("字节数:{0}/{1}", e.BytesReceived, e.TotalBytesToReceive);
            lab_fileinfo.Update();
            lab_filename.Text = "正在下载文件：" + e.FileName;
            lab_filename.Update();
        }

        void DownloadError(object sender, DownloadErrorEventArgs e)
        {
            Log.Write("下载过程中出现错误，错误描述：" + e.Error.Message + System.Environment.NewLine + "Version:" + e.Manifest.Version);
            MessageBox.Show("下载出错：" + e.Error.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void DownloadCompleted(object sender, DownloadCompleteEventArgs e)
        {
            mList.Add(e.Manifest);
            if (mList.Count == mLen)
            {
                updater.Activate(mList.ToArray());
                mList.Clear();
            }
        }

        void ActivationStarted(object sender, ActivationStartedEventArgs e)
        {
            lab_filename.Text = "开始安装，请稍后......";
            lab_filename.Update();
            e.Cancel = CheckActivation();
            if (e.Cancel)
            {
                lab_filename.Text = "安装已被取消";
                isComplete = true;
            }
        }

        private bool CheckActivation()
        {
            bool cancel = false;
            //检查主程序（进程名称）是否打开，如果打开则提示
            string[] processName = { "Client", "Server" };
            foreach (string name in processName)
            {
                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(name);
                if (processes != null && processes.Length != 0)
                {
                    if (MessageBox.Show(string.Format("进程{0}正在运行中，请关闭后重试。", name), "系统提示",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        cancel = true;
                        break;
                    }
                    else
                    {
                        return CheckActivation();
                    }
                }
            }
            return cancel;
        }

       protected void ActivationProgressChanged(object sender, FileCopyProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lab_percent.Text = e.ProgressPercentage.ToString() + "%";
            lab_percent.Update();
            lab_fileinfo.Text = string.Format("字节数:{0}/{1}", e.BytesToCopy, e.TotalBytesToCopy);
            lab_fileinfo.Update();
            lab_filename.Text = "正在安装：" + e.SourceFileName;
            lab_filename.Update();
        }

       protected void ActivationInitializing(object sender, ManifestEventArgs e)
        {
            lab_filename.Text = "正在初始化安装，请稍后......";
            lab_filename.Update();
            lab_percent.Text = "0%";
            lab_percent.Update();
            lab_fileinfo.Text = "";
            lab_fileinfo.Update();
            progressBar1.Value = 0;
        }

        void ActivationError(object sender, FileCopyErrorEventArgs e)
        {
            Log.Write("安装过程中出现错误，错误描述：" + e.Error.Message + System.Environment.NewLine + "Version:" + e.Manifest.Version);
            MessageBox.Show(this, "安装错误：" + e.Error.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lab_filename.Text = "系统正在回滚";
            updater.Rollback(e.Manifest);
        }

        void ActivationCompleted(object sender, ActivationCompletedEventArgs e)
        {
            //安装完成
            isComplete = true;
            lab_filename.Text = "安装完成";
            lab_percent.Text = "100%";
            if (progressBar1.Value != progressBar1.Maximum)
            {
                progressBar1.Value = progressBar1.Maximum;
            }
            if (e.Error != null)
            {
                lab_filename.Text += "，但出现错误";
                lab_filename.Update();
            }
            else
            {
                lab_filename.Update();
                System.Threading.Thread.Sleep(1000);
                string filename = GetFileName(e.Manifest.Application.Location, e.Manifest.Application.EntryPoint.File);
                Startup(filename, e.Manifest.Application.EntryPoint.Parameters);
                if (args != null && args.Length > 0)
                {
                    Exit();
                }
            }
        }

        private string GetFileName(string location, string file)
        {
            return Path.Combine(Path.GetFullPath(location), file);
        }

        #endregion
    }
}

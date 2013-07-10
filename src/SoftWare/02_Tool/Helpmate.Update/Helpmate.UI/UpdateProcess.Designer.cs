namespace Helpmate.UI
{
    partial class UpdateProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateProcess));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_percent = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lab_fileinfo = new System.Windows.Forms.Label();
            this.lab_filename = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.nfiUpdate = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.cmsApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Helpmate.UI.Properties.Resources.载入条2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.ContextMenuStrip = this.cmsApp;
            this.panel1.Controls.Add(this.lab_percent);
            this.panel1.Controls.Add(this.picClose);
            this.panel1.Controls.Add(this.lab_fileinfo);
            this.panel1.Controls.Add(this.lab_filename);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 182);
            this.panel1.TabIndex = 1;
            // 
            // cmsApp
            // 
            this.cmsApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_exit});
            this.cmsApp.Name = "contextMenuStrip1";
            this.cmsApp.Size = new System.Drawing.Size(99, 26);
            // 
            // MenuItem_exit
            // 
            this.MenuItem_exit.Name = "MenuItem_exit";
            this.MenuItem_exit.Size = new System.Drawing.Size(98, 22);
            this.MenuItem_exit.Text = "退出";
            this.MenuItem_exit.Click += new System.EventHandler(this.MenuItem_exit_Click);
            // 
            // lab_percent
            // 
            this.lab_percent.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_percent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_percent.Location = new System.Drawing.Point(432, 77);
            this.lab_percent.Name = "lab_percent";
            this.lab_percent.Size = new System.Drawing.Size(51, 25);
            this.lab_percent.TabIndex = 4;
            this.lab_percent.Text = "0%";
            this.lab_percent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Helpmate.UI.Properties.Resources.close;
            this.picClose.Location = new System.Drawing.Point(451, 3);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(42, 24);
            this.picClose.TabIndex = 3;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // lab_fileinfo
            // 
            this.lab_fileinfo.BackColor = System.Drawing.Color.Transparent;
            this.lab_fileinfo.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileinfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_fileinfo.Location = new System.Drawing.Point(13, 111);
            this.lab_fileinfo.Name = "lab_fileinfo";
            this.lab_fileinfo.Size = new System.Drawing.Size(410, 20);
            this.lab_fileinfo.TabIndex = 1;
            this.lab_fileinfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_filename
            // 
            this.lab_filename.BackColor = System.Drawing.Color.Transparent;
            this.lab_filename.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_filename.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_filename.Location = new System.Drawing.Point(15, 51);
            this.lab_filename.Name = "lab_filename";
            this.lab_filename.Size = new System.Drawing.Size(410, 20);
            this.lab_filename.TabIndex = 1;
            this.lab_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar1.ForeColor = System.Drawing.Color.DarkCyan;
            this.progressBar1.Location = new System.Drawing.Point(15, 77);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(410, 30);
            this.progressBar1.TabIndex = 0;
            // 
            // nfiUpdate
            // 
            this.nfiUpdate.ContextMenuStrip = this.cmsApp;
            this.nfiUpdate.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiUpdate.Icon")));
            this.nfiUpdate.Text = "28分析平台客户端更新";
            this.nfiUpdate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfiUpdate_MouseDoubleClick);
            // 
            // UpdateProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 182);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateProcess";
            this.Text = "UpdateProcess";
            this.Load += new System.EventHandler(this.UpdateProcess_Load);
            this.panel1.ResumeLayout(false);
            this.cmsApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsApp;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_exit;
        private System.Windows.Forms.Label lab_percent;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label lab_fileinfo;
        private System.Windows.Forms.Label lab_filename;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon nfiUpdate;
    }
}
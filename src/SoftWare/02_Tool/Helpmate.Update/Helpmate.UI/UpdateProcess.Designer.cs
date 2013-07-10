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
            this.pnlAPP = new System.Windows.Forms.Panel();
            this.lab_percent = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lab_fileinfo = new System.Windows.Forms.Label();
            this.lab_filename = new System.Windows.Forms.Label();
            this.pgbApp = new System.Windows.Forms.ProgressBar();
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.nfiUpdate = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlAPP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.cmsApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAPP
            // 
            this.pnlAPP.BackColor = System.Drawing.Color.Transparent;
            this.pnlAPP.BackgroundImage = global::Helpmate.UI.Properties.Resources.bg;
            this.pnlAPP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlAPP.Controls.Add(this.lab_percent);
            this.pnlAPP.Controls.Add(this.picClose);
            this.pnlAPP.Controls.Add(this.lab_fileinfo);
            this.pnlAPP.Controls.Add(this.lab_filename);
            this.pnlAPP.Controls.Add(this.pgbApp);
            this.pnlAPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAPP.Location = new System.Drawing.Point(0, 0);
            this.pnlAPP.Name = "pnlAPP";
            this.pnlAPP.Size = new System.Drawing.Size(496, 168);
            this.pnlAPP.TabIndex = 1;
            this.pnlAPP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.pnlAPP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.pnlAPP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // lab_percent
            // 
            this.lab_percent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_percent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_percent.Location = new System.Drawing.Point(442, 71);
            this.lab_percent.Name = "lab_percent";
            this.lab_percent.Size = new System.Drawing.Size(31, 23);
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
            this.picClose.Size = new System.Drawing.Size(42, 22);
            this.picClose.TabIndex = 3;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // lab_fileinfo
            // 
            this.lab_fileinfo.BackColor = System.Drawing.Color.Transparent;
            this.lab_fileinfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileinfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_fileinfo.Location = new System.Drawing.Point(23, 102);
            this.lab_fileinfo.Name = "lab_fileinfo";
            this.lab_fileinfo.Size = new System.Drawing.Size(410, 18);
            this.lab_fileinfo.TabIndex = 1;
            this.lab_fileinfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_filename
            // 
            this.lab_filename.BackColor = System.Drawing.Color.Transparent;
            this.lab_filename.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_filename.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_filename.Location = new System.Drawing.Point(25, 47);
            this.lab_filename.Name = "lab_filename";
            this.lab_filename.Size = new System.Drawing.Size(410, 18);
            this.lab_filename.TabIndex = 1;
            this.lab_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbApp
            // 
            this.pgbApp.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pgbApp.ForeColor = System.Drawing.Color.DarkCyan;
            this.pgbApp.Location = new System.Drawing.Point(25, 71);
            this.pgbApp.Name = "pgbApp";
            this.pgbApp.Size = new System.Drawing.Size(410, 28);
            this.pgbApp.TabIndex = 0;
            // 
            // cmsApp
            // 
            this.cmsApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_exit});
            this.cmsApp.Name = "contextMenuStrip1";
            this.cmsApp.Size = new System.Drawing.Size(101, 26);
            // 
            // MenuItem_exit
            // 
            this.MenuItem_exit.Name = "MenuItem_exit";
            this.MenuItem_exit.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_exit.Text = "退出";
            this.MenuItem_exit.Click += new System.EventHandler(this.MenuItem_exit_Click);
            // 
            // nfiUpdate
            // 
            this.nfiUpdate.ContextMenuStrip = this.cmsApp;
            this.nfiUpdate.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiUpdate.Icon")));
            this.nfiUpdate.Text = "28分析平台智能更新";
            this.nfiUpdate.Visible = true;
            this.nfiUpdate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfiUpdate_MouseDoubleClick);
            // 
            // UpdateProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 168);
            this.Controls.Add(this.pnlAPP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateProcess";
            this.Load += new System.EventHandler(this.UpdateProcess_Load);
            this.pnlAPP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.cmsApp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAPP;
        private System.Windows.Forms.ContextMenuStrip cmsApp;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_exit;
        private System.Windows.Forms.Label lab_percent;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label lab_fileinfo;
        private System.Windows.Forms.Label lab_filename;
        private System.Windows.Forms.ProgressBar pgbApp;
        private System.Windows.Forms.NotifyIcon nfiUpdate;
    }
}
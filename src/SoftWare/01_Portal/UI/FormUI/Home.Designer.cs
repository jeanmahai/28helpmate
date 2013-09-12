namespace Helpmate.UI.Forms.FormUI
{
    partial class Home
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
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tmRefresh = new System.Windows.Forms.Timer(this.components);
            this.bgwApp = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ucLotteryM4 = new Helpmate.UI.Forms.UIContorl.UIPlug.UCNormalCount();
            this.ucLotteryM3 = new Helpmate.UI.Forms.UIContorl.UIPlug.UCNormalCount();
            this.ucLotteryM2 = new Helpmate.UI.Forms.UIContorl.UIPlug.UCNormalCount();
            this.ucLotteryM1 = new Helpmate.UI.Forms.UIContorl.UIPlug.UCNormalCount();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F);
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(193, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(557, 12);
            this.label14.TabIndex = 149;
            this.label14.Text = "下图统计当前开奖的号码之前每一次出现后下一期所开之号。（共显示20期，数据按时间排列左近右远）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(58, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 19);
            this.label6.TabIndex = 147;
            this.label6.Text = "同号统计图：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(214, 277);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 12);
            this.label17.TabIndex = 155;
            this.label17.Text = "提示：统计本期相同分钟";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(58, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 153;
            this.label2.Text = "同分钟统计图：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(214, 815);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 12);
            this.label5.TabIndex = 159;
            this.label5.Text = "下图统计当下竞猜期之前的开奖号码走势，显示同上。";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(58, 809);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 19);
            this.label7.TabIndex = 158;
            this.label7.Text = "最近走势图：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F);
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(214, 550);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 12);
            this.label19.TabIndex = 163;
            this.label19.Text = "提示：统计本期相同时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(58, 544);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 19);
            this.label4.TabIndex = 161;
            this.label4.Text = "同时间统计图：";
            // 
            // tmRefresh
            // 
            this.tmRefresh.Interval = 30000;
            this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
            // 
            // bgwApp
            // 
            this.bgwApp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwApp_DoWork);
            this.bgwApp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwApp_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(21, 567);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 1);
            this.panel2.TabIndex = 160;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(21, 832);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(682, 1);
            this.panel3.TabIndex = 157;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(21, 294);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 1);
            this.panel1.TabIndex = 152;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.help;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(718, 22);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 22);
            this.btnHelp.TabIndex = 151;
            this.btnHelp.Tag = "";
            this.toolTip1.SetToolTip(this.btnHelp, "帮助文档");
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.Refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(21, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 22);
            this.btnRefresh.TabIndex = 151;
            this.btnRefresh.Tag = "";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BackColor = System.Drawing.Color.Transparent;
            this.pnlLine.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.pnlLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLine.Location = new System.Drawing.Point(21, 48);
            this.pnlLine.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(682, 1);
            this.pnlLine.TabIndex = 146;
            // 
            // ucLotteryM4
            // 
            this.ucLotteryM4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucLotteryM4.Location = new System.Drawing.Point(35, 844);
            this.ucLotteryM4.Lotteries = null;
            this.ucLotteryM4.Name = "ucLotteryM4";
            this.ucLotteryM4.Size = new System.Drawing.Size(706, 201);
            this.ucLotteryM4.TabIndex = 165;
            // 
            // ucLotteryM3
            // 
            this.ucLotteryM3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucLotteryM3.Location = new System.Drawing.Point(35, 586);
            this.ucLotteryM3.Lotteries = null;
            this.ucLotteryM3.Name = "ucLotteryM3";
            this.ucLotteryM3.Size = new System.Drawing.Size(706, 201);
            this.ucLotteryM3.TabIndex = 165;
            // 
            // ucLotteryM2
            // 
            this.ucLotteryM2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucLotteryM2.Location = new System.Drawing.Point(35, 313);
            this.ucLotteryM2.Lotteries = null;
            this.ucLotteryM2.Name = "ucLotteryM2";
            this.ucLotteryM2.Size = new System.Drawing.Size(706, 201);
            this.ucLotteryM2.TabIndex = 165;
            // 
            // ucLotteryM1
            // 
            this.ucLotteryM1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucLotteryM1.Location = new System.Drawing.Point(35, 56);
            this.ucLotteryM1.Lotteries = null;
            this.ucLotteryM1.Name = "ucLotteryM1";
            this.ucLotteryM1.Size = new System.Drawing.Size(706, 201);
            this.ucLotteryM1.TabIndex = 165;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ucLotteryM4);
            this.Controls.Add(this.ucLotteryM3);
            this.Controls.Add(this.ucLotteryM2);
            this.Controls.Add(this.ucLotteryM1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnlLine);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.ShowIcon = false;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private UIContorl.UIPlug.UCNormalCount ucLotteryM1;
        private UIContorl.UIPlug.UCNormalCount ucLotteryM2;
        private UIContorl.UIPlug.UCNormalCount ucLotteryM4;
        private UIContorl.UIPlug.UCNormalCount ucLotteryM3;
        private System.Windows.Forms.Timer tmRefresh;
        private System.ComponentModel.BackgroundWorker bgwApp;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolTip toolTip1;


    }
}
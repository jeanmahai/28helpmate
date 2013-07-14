namespace Helpmate.UI.Forms.FormUI
{
    partial class NormalTrend
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
            this.countList = new System.Windows.Forms.DataGridView();
            this.headerList = new System.Windows.Forms.DataGridView();
            this.dataList = new System.Windows.Forms.DataGridView();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lblPage = new System.Windows.Forms.Label();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkLast = new System.Windows.Forms.LinkLabel();
            this.lnkFirst = new System.Windows.Forms.LinkLabel();
            this.bgworkerLoad = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.countList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            this.SuspendLayout();
            // 
            // countList
            // 
            this.countList.BackgroundColor = System.Drawing.Color.White;
            this.countList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.countList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.countList.Location = new System.Drawing.Point(20, 28);
            this.countList.Name = "countList";
            this.countList.RowTemplate.Height = 23;
            this.countList.Size = new System.Drawing.Size(1113, 23);
            this.countList.TabIndex = 0;
            // 
            // headerList
            // 
            this.headerList.BackgroundColor = System.Drawing.Color.White;
            this.headerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.headerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerList.Location = new System.Drawing.Point(20, 50);
            this.headerList.Name = "headerList";
            this.headerList.RowTemplate.Height = 23;
            this.headerList.Size = new System.Drawing.Size(1113, 23);
            this.headerList.TabIndex = 1;
            // 
            // dataList
            // 
            this.dataList.BackgroundColor = System.Drawing.Color.White;
            this.dataList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList.Location = new System.Drawing.Point(20, 72);
            this.dataList.Name = "dataList";
            this.dataList.RowTemplate.Height = 23;
            this.dataList.Size = new System.Drawing.Size(1113, 514);
            this.dataList.TabIndex = 2;
            this.dataList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataList_CellFormatting);
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Location = new System.Drawing.Point(54, 9);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(41, 12);
            this.lnkPrev.TabIndex = 3;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "上一页";
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.ForeColor = System.Drawing.Color.Red;
            this.lblPage.Location = new System.Drawing.Point(103, 10);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(23, 12);
            this.lblPage.TabIndex = 4;
            this.lblPage.Text = "0/0";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Location = new System.Drawing.Point(136, 9);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(41, 12);
            this.lnkNext.TabIndex = 5;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "下一页";
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkLast
            // 
            this.lnkLast.AutoSize = true;
            this.lnkLast.Location = new System.Drawing.Point(185, 9);
            this.lnkLast.Name = "lnkLast";
            this.lnkLast.Size = new System.Drawing.Size(29, 12);
            this.lnkLast.TabIndex = 6;
            this.lnkLast.TabStop = true;
            this.lnkLast.Text = "尾页";
            this.lnkLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLast_LinkClicked);
            // 
            // lnkFirst
            // 
            this.lnkFirst.AutoSize = true;
            this.lnkFirst.Location = new System.Drawing.Point(20, 9);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(29, 12);
            this.lnkFirst.TabIndex = 7;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "首页";
            this.lnkFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFirst_LinkClicked);
            // 
            // bgworkerLoad
            // 
            this.bgworkerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkerLoad_DoWork);
            this.bgworkerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworkerLoad_RunWorkerCompleted);
            // 
            // NormalTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lnkFirst);
            this.Controls.Add(this.lnkLast);
            this.Controls.Add(this.lnkNext);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lnkPrev);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.headerList);
            this.Controls.Add(this.countList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NormalTrend";
            this.Text = "NormalTrend";
            this.Load += new System.EventHandler(this.NormalTrend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.countList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView countList;
        private System.Windows.Forms.DataGridView headerList;
        private System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkLast;
        private System.Windows.Forms.LinkLabel lnkFirst;
        private System.ComponentModel.BackgroundWorker bgworkerLoad;
    }
}
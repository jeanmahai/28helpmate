namespace Helpmate.UI.Forms.FormUI
{
    partial class SpecialAnalysisDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialAnalysisDetail));
            this.gvList = new System.Windows.Forms.DataGridView();
            this.bgwLoad = new System.ComponentModel.BackgroundWorker();
            this.headerList = new System.Windows.Forms.DataGridView();
            this.countList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countList)).BeginInit();
            this.SuspendLayout();
            // 
            // gvList
            // 
            this.gvList.BackgroundColor = System.Drawing.Color.White;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.Location = new System.Drawing.Point(3, 48);
            this.gvList.Name = "gvList";
            this.gvList.RowTemplate.Height = 23;
            this.gvList.Size = new System.Drawing.Size(1113, 511);
            this.gvList.TabIndex = 0;
            this.gvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvList_CellFormatting);
            // 
            // bgwLoad
            // 
            this.bgwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoad_DoWork);
            this.bgwLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoad_RunWorkerCompleted);
            // 
            // headerList
            // 
            this.headerList.BackgroundColor = System.Drawing.Color.White;
            this.headerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.headerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerList.Location = new System.Drawing.Point(3, 25);
            this.headerList.Name = "headerList";
            this.headerList.RowTemplate.Height = 23;
            this.headerList.Size = new System.Drawing.Size(1113, 23);
            this.headerList.TabIndex = 3;
            // 
            // countList
            // 
            this.countList.BackgroundColor = System.Drawing.Color.White;
            this.countList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.countList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.countList.Location = new System.Drawing.Point(3, 3);
            this.countList.Name = "countList";
            this.countList.RowTemplate.Height = 23;
            this.countList.Size = new System.Drawing.Size(1113, 23);
            this.countList.TabIndex = 2;
            // 
            // SpecialAnalysisDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 562);
            this.Controls.Add(this.headerList);
            this.Controls.Add(this.countList);
            this.Controls.Add(this.gvList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "SpecialAnalysisDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "特殊分析详情";
            this.Load += new System.EventHandler(this.SpecialAnalysisDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvList;
        private System.ComponentModel.BackgroundWorker bgwLoad;
        private System.Windows.Forms.DataGridView headerList;
        private System.Windows.Forms.DataGridView countList;
    }
}
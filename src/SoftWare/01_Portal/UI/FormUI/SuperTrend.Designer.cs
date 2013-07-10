namespace Helpmate.UI.Forms.FormUI
{
    partial class SuperTrend
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
            this.ddlHour = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbxDate = new System.Windows.Forms.TextBox();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.ddlMinute = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.pnlLine = new System.Windows.Forms.Panel();
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
            this.countList.Location = new System.Drawing.Point(20, 88);
            this.countList.Name = "countList";
            this.countList.RowTemplate.Height = 23;
            this.countList.Size = new System.Drawing.Size(1011, 23);
            this.countList.TabIndex = 0;
            // 
            // headerList
            // 
            this.headerList.BackgroundColor = System.Drawing.Color.White;
            this.headerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.headerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerList.Location = new System.Drawing.Point(20, 110);
            this.headerList.Name = "headerList";
            this.headerList.RowTemplate.Height = 23;
            this.headerList.Size = new System.Drawing.Size(1011, 23);
            this.headerList.TabIndex = 1;
            // 
            // dataList
            // 
            this.dataList.BackgroundColor = System.Drawing.Color.White;
            this.dataList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList.Location = new System.Drawing.Point(20, 132);
            this.dataList.Name = "dataList";
            this.dataList.RowTemplate.Height = 23;
            this.dataList.Size = new System.Drawing.Size(1011, 440);
            this.dataList.TabIndex = 2;
            this.dataList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataList_CellFormatting);
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Location = new System.Drawing.Point(55, 66);
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
            this.lblPage.Location = new System.Drawing.Point(106, 66);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(23, 12);
            this.lblPage.TabIndex = 4;
            this.lblPage.Text = "0/0";
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Location = new System.Drawing.Point(141, 66);
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
            this.lnkLast.Location = new System.Drawing.Point(187, 66);
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
            this.lnkFirst.Location = new System.Drawing.Point(20, 66);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(29, 12);
            this.lnkFirst.TabIndex = 7;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "首页";
            this.lnkFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFirst_LinkClicked);
            // 
            // ddlHour
            // 
            this.ddlHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHour.DropDownWidth = 85;
            this.ddlHour.FormattingEnabled = true;
            this.ddlHour.Location = new System.Drawing.Point(212, 25);
            this.ddlHour.Name = "ddlHour";
            this.ddlHour.Size = new System.Drawing.Size(90, 20);
            this.ddlHour.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.Location = new System.Drawing.Point(20, 28);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 12);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "日期：";
            // 
            // tbxDate
            // 
            this.tbxDate.Location = new System.Drawing.Point(57, 24);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Size = new System.Drawing.Size(100, 21);
            this.tbxDate.TabIndex = 10;
            this.tbxDate.Click += new System.EventHandler(this.tbxDate_Click);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHour.Location = new System.Drawing.Point(168, 28);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(44, 12);
            this.lblHour.TabIndex = 11;
            this.lblHour.Text = "小时：";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMinute.Location = new System.Drawing.Point(312, 29);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(44, 12);
            this.lblMinute.TabIndex = 13;
            this.lblMinute.Text = "分钟：";
            // 
            // ddlMinute
            // 
            this.ddlMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMinute.DropDownWidth = 85;
            this.ddlMinute.FormattingEnabled = true;
            this.ddlMinute.Location = new System.Drawing.Point(357, 26);
            this.ddlMinute.Name = "ddlMinute";
            this.ddlMinute.Size = new System.Drawing.Size(90, 20);
            this.ddlMinute.TabIndex = 12;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(503, 25);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BackColor = System.Drawing.Color.Transparent;
            this.pnlLine.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.pnlLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLine.Location = new System.Drawing.Point(22, 55);
            this.pnlLine.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(682, 1);
            this.pnlLine.TabIndex = 147;
            // 
            // SuperTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblMinute);
            this.Controls.Add(this.ddlMinute);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.ddlHour);
            this.Controls.Add(this.lnkFirst);
            this.Controls.Add(this.lnkLast);
            this.Controls.Add(this.lnkNext);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lnkPrev);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.headerList);
            this.Controls.Add(this.countList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuperTrend";
            this.Text = "SuperTrend";
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
        private System.Windows.Forms.ComboBox ddlHour;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox tbxDate;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.ComboBox ddlMinute;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel pnlLine;
    }
}
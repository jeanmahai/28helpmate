namespace Helpmate.UI.Forms.FormUI
{
    partial class RemindSet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSource = new System.Windows.Forms.Label();
            this.ddlSource = new System.Windows.Forms.ComboBox();
            this.lblGame = new System.Windows.Forms.Label();
            this.ddlGame = new System.Windows.Forms.ComboBox();
            this.lnkFirst = new System.Windows.Forms.LinkLabel();
            this.lnkLast = new System.Windows.Forms.LinkLabel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lblPage = new System.Windows.Forms.Label();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.dataList = new System.Windows.Forms.DataGridView();
            this.headerList = new System.Windows.Forms.DataGridView();
            this.lblSite = new System.Windows.Forms.Label();
            this.ddlSite = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.ddlResult = new System.Windows.Forms.ComboBox();
            this.lblCnt = new System.Windows.Forms.Label();
            this.tbxCnt = new System.Windows.Forms.TextBox();
            this.bgworkLoadData = new System.ComponentModel.BackgroundWorker();
            this.bgworkerAdd = new System.ComponentModel.BackgroundWorker();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.bgworkerDel = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSource.Location = new System.Drawing.Point(220, 31);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(31, 12);
            this.lblSource.TabIndex = 28;
            this.lblSource.Text = "源：";
            // 
            // ddlSource
            // 
            this.ddlSource.DisplayMember = "Value";
            this.ddlSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSource.DropDownWidth = 85;
            this.ddlSource.FormattingEnabled = true;
            this.ddlSource.Location = new System.Drawing.Point(251, 28);
            this.ddlSource.Name = "ddlSource";
            this.ddlSource.Size = new System.Drawing.Size(130, 20);
            this.ddlSource.TabIndex = 27;
            this.ddlSource.ValueMember = "Key";
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGame.Location = new System.Drawing.Point(19, 30);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(44, 12);
            this.lblGame.TabIndex = 26;
            this.lblGame.Text = "游戏：";
            // 
            // ddlGame
            // 
            this.ddlGame.BackColor = System.Drawing.SystemColors.Window;
            this.ddlGame.DisplayMember = "Value";
            this.ddlGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGame.DropDownWidth = 85;
            this.ddlGame.FormattingEnabled = true;
            this.ddlGame.Location = new System.Drawing.Point(63, 27);
            this.ddlGame.Name = "ddlGame";
            this.ddlGame.Size = new System.Drawing.Size(130, 20);
            this.ddlGame.TabIndex = 23;
            this.ddlGame.ValueMember = "Key";
            // 
            // lnkFirst
            // 
            this.lnkFirst.AutoSize = true;
            this.lnkFirst.Location = new System.Drawing.Point(15, 117);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(29, 12);
            this.lnkFirst.TabIndex = 22;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "首页";
            this.lnkFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFirst_LinkClicked);
            // 
            // lnkLast
            // 
            this.lnkLast.AutoSize = true;
            this.lnkLast.Location = new System.Drawing.Point(182, 117);
            this.lnkLast.Name = "lnkLast";
            this.lnkLast.Size = new System.Drawing.Size(29, 12);
            this.lnkLast.TabIndex = 21;
            this.lnkLast.TabStop = true;
            this.lnkLast.Text = "尾页";
            this.lnkLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLast_LinkClicked);
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Location = new System.Drawing.Point(136, 117);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(41, 12);
            this.lnkNext.TabIndex = 20;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "下一页";
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.ForeColor = System.Drawing.Color.Red;
            this.lblPage.Location = new System.Drawing.Point(101, 117);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(23, 12);
            this.lblPage.TabIndex = 19;
            this.lblPage.Text = "0/0";
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Location = new System.Drawing.Point(50, 117);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(41, 12);
            this.lnkPrev.TabIndex = 18;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "上一页";
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // dataList
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataList.BackgroundColor = System.Drawing.Color.White;
            this.dataList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataList.Location = new System.Drawing.Point(15, 162);
            this.dataList.Name = "dataList";
            this.dataList.RowTemplate.Height = 23;
            this.dataList.Size = new System.Drawing.Size(1113, 440);
            this.dataList.TabIndex = 17;
            this.dataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataList_CellContentClick);
            // 
            // headerList
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.headerList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.headerList.BackgroundColor = System.Drawing.Color.White;
            this.headerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.headerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.headerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.headerList.DefaultCellStyle = dataGridViewCellStyle8;
            this.headerList.Location = new System.Drawing.Point(15, 140);
            this.headerList.Name = "headerList";
            this.headerList.RowTemplate.Height = 23;
            this.headerList.Size = new System.Drawing.Size(1113, 23);
            this.headerList.TabIndex = 16;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSite.Location = new System.Drawing.Point(429, 32);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(44, 12);
            this.lblSite.TabIndex = 31;
            this.lblSite.Text = "网站：";
            // 
            // ddlSite
            // 
            this.ddlSite.DisplayMember = "Value";
            this.ddlSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSite.DropDownWidth = 85;
            this.ddlSite.FormattingEnabled = true;
            this.ddlSite.Location = new System.Drawing.Point(473, 29);
            this.ddlSite.Name = "ddlSite";
            this.ddlSite.Size = new System.Drawing.Size(130, 20);
            this.ddlSite.TabIndex = 30;
            this.ddlSite.ValueMember = "Key";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.Location = new System.Drawing.Point(19, 69);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(44, 12);
            this.lblResult.TabIndex = 33;
            this.lblResult.Text = "结果：";
            // 
            // ddlResult
            // 
            this.ddlResult.DisplayMember = "Value";
            this.ddlResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlResult.DropDownWidth = 85;
            this.ddlResult.FormattingEnabled = true;
            this.ddlResult.Location = new System.Drawing.Point(63, 66);
            this.ddlResult.Name = "ddlResult";
            this.ddlResult.Size = new System.Drawing.Size(130, 20);
            this.ddlResult.TabIndex = 32;
            this.ddlResult.ValueMember = "Key";
            // 
            // lblCnt
            // 
            this.lblCnt.AutoSize = true;
            this.lblCnt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCnt.Location = new System.Drawing.Point(209, 70);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(44, 12);
            this.lblCnt.TabIndex = 34;
            this.lblCnt.Text = "次数：";
            // 
            // tbxCnt
            // 
            this.tbxCnt.Location = new System.Drawing.Point(251, 65);
            this.tbxCnt.Name = "tbxCnt";
            this.tbxCnt.Size = new System.Drawing.Size(130, 21);
            this.tbxCnt.TabIndex = 35;
            // 
            // bgworkLoadData
            // 
            this.bgworkLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkLoadData_DoWork);
            this.bgworkLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworkLoadData_RunWorkerCompleted);
            // 
            // bgworkerAdd
            // 
            this.bgworkerAdd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkerAdd_DoWork);
            this.bgworkerAdd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworkerAdd_RunWorkerCompleted);
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BackColor = System.Drawing.Color.Transparent;
            this.pnlLine.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.pnlLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLine.Location = new System.Drawing.Point(13, 102);
            this.pnlLine.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(1348, 1);
            this.pnlLine.TabIndex = 148;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.btn;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(431, 63);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bgworkerDel
            // 
            this.bgworkerDel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkerDel_DoWork);
            this.bgworkerDel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworkerDel_RunWorkerCompleted);
            // 
            // RemindSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.tbxCnt);
            this.Controls.Add(this.lblCnt);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.ddlResult);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.ddlSite);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.ddlSource);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.ddlGame);
            this.Controls.Add(this.lnkFirst);
            this.Controls.Add(this.lnkLast);
            this.Controls.Add(this.lnkNext);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lnkPrev);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.headerList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemindSet";
            this.Text = "RemindSet";
            this.Load += new System.EventHandler(this.RemindSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ComboBox ddlSource;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.ComboBox ddlGame;
        private System.Windows.Forms.LinkLabel lnkFirst;
        private System.Windows.Forms.LinkLabel lnkLast;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.DataGridView headerList;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox ddlSite;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox ddlResult;
        private System.Windows.Forms.Label lblCnt;
        private System.Windows.Forms.TextBox tbxCnt;
        private System.Windows.Forms.Panel pnlLine;
        private System.ComponentModel.BackgroundWorker bgworkLoadData;
        private System.ComponentModel.BackgroundWorker bgworkerAdd;
        private System.ComponentModel.BackgroundWorker bgworkerDel;

    }
}
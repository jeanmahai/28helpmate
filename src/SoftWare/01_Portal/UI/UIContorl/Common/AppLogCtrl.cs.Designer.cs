namespace Helpmate.UI.Forms.UIContorl.Common
{
    partial class AppLogCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUrlType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtEndTime);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtStartTime);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.pnlLoading);
            this.splitContainer1.Panel1.Controls.Add(this.pnlPage);
            this.splitContainer1.Panel1.Controls.Add(this.picSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtFunction);
            this.splitContainer1.Panel1.Controls.Add(this.txtClass);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.pnlLine);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvItems);
            this.splitContainer1.Size = new System.Drawing.Size(800, 416);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 57;
            // 
            // txtEndTime
            // 
            this.txtEndTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEndTime.Location = new System.Drawing.Point(375, 87);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(188, 21);
            this.txtEndTime.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(302, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "结束时间：";
            // 
            // txtStartTime
            // 
            this.txtStartTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStartTime.Location = new System.Drawing.Point(94, 87);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(188, 21);
            this.txtStartTime.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(21, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "开始时间：";
            // 
            // pnlLoading
            // 
            this.pnlLoading.Location = new System.Drawing.Point(609, 41);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(116, 25);
            this.pnlLoading.TabIndex = 103;
            // 
            // pnlPage
            // 
            this.pnlPage.Location = new System.Drawing.Point(581, 83);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(217, 30);
            this.pnlPage.TabIndex = 62;
            // 
            // picSearch
            // 
            this.picSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearch.Image = global::Helpmate.UI.Forms.Properties.Resources.Preview;
            this.picSearch.Location = new System.Drawing.Point(580, 41);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(23, 25);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearch.TabIndex = 61;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // txtFunction
            // 
            this.txtFunction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFunction.Location = new System.Drawing.Point(375, 43);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(188, 21);
            this.txtFunction.TabIndex = 60;
            // 
            // txtClass
            // 
            this.txtClass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClass.Location = new System.Drawing.Point(94, 43);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(188, 21);
            this.txtClass.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(302, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "方法名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(21, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "来源页：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 58;
            this.label6.Text = "系统日志";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.Transparent;
            this.pnlLine.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.pnlLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLine.Location = new System.Drawing.Point(3, 32);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(800, 1);
            this.pnlLine.TabIndex = 57;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clID,
            this.clPage,
            this.clFunction,
            this.clRemark,
            this.clUrlType,
            this.clCreateTime});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvItems.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.RowTemplate.Height = 23;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(800, 291);
            this.dgvItems.TabIndex = 41;
            // 
            // clID
            // 
            this.clID.DataPropertyName = "SysNo";
            this.clID.HeaderText = "SysNo";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            this.clID.Visible = false;
            // 
            // clPage
            // 
            this.clPage.DataPropertyName = "Page";
            this.clPage.HeaderText = "来源页";
            this.clPage.Name = "clPage";
            this.clPage.ReadOnly = true;
            this.clPage.Width = 150;
            // 
            // clFunction
            // 
            this.clFunction.DataPropertyName = "Function";
            this.clFunction.HeaderText = "方法名";
            this.clFunction.Name = "clFunction";
            this.clFunction.ReadOnly = true;
            // 
            // clRemark
            // 
            this.clRemark.DataPropertyName = "Remark";
            this.clRemark.FillWeight = 200F;
            this.clRemark.HeaderText = "说明";
            this.clRemark.Name = "clRemark";
            this.clRemark.ReadOnly = true;
            this.clRemark.Width = 150;
            // 
            // clUrlType
            // 
            this.clUrlType.DataPropertyName = "Message";
            this.clUrlType.HeaderText = "报错消息";
            this.clUrlType.Name = "clUrlType";
            this.clUrlType.ReadOnly = true;
            this.clUrlType.Width = 250;
            // 
            // clCreateTime
            // 
            this.clCreateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clCreateTime.DataPropertyName = "CreateTime";
            this.clCreateTime.HeaderText = "时间";
            this.clCreateTime.Name = "clCreateTime";
            this.clCreateTime.ReadOnly = true;
            // 
            // AppLogCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AppLogCtrl";
            this.Size = new System.Drawing.Size(800, 416);
            this.Load += new System.EventHandler(this.AppLogCtrl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.Panel pnlLoading;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUrlType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCreateTime;

    }
}

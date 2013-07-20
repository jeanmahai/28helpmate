namespace Helpmate.UI.Forms.FormUI
{
    partial class SpecialAnalysis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNumber = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTrend = new System.Windows.Forms.DataGridView();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dgvFoot = new System.Windows.Forms.DataGridView();
            this.dgvHead = new System.Windows.Forms.DataGridView();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblHour = new System.Windows.Forms.Label();
            this.ddlHour = new System.Windows.Forms.ComboBox();
            this.bgwApp = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHead)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNumber
            // 
            this.dgvNumber.AllowUserToAddRows = false;
            this.dgvNumber.AllowUserToDeleteRows = false;
            this.dgvNumber.AllowUserToResizeColumns = false;
            this.dgvNumber.AllowUserToResizeRows = false;
            this.dgvNumber.BackgroundColor = System.Drawing.Color.White;
            this.dgvNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumber.ColumnHeadersVisible = false;
            this.dgvNumber.Location = new System.Drawing.Point(50, 485);
            this.dgvNumber.Name = "dgvNumber";
            this.dgvNumber.ReadOnly = true;
            this.dgvNumber.RowHeadersVisible = false;
            this.dgvNumber.RowTemplate.Height = 26;
            this.dgvNumber.Size = new System.Drawing.Size(905, 27);
            this.dgvNumber.TabIndex = 140;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(10, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1640, 1);
            this.panel1.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 139;
            this.label2.Text = "特殊统计：";
            // 
            // dgvTrend
            // 
            this.dgvTrend.AllowUserToAddRows = false;
            this.dgvTrend.AllowUserToDeleteRows = false;
            this.dgvTrend.AllowUserToResizeColumns = false;
            this.dgvTrend.AllowUserToResizeRows = false;
            this.dgvTrend.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrend.ColumnHeadersVisible = false;
            this.dgvTrend.Location = new System.Drawing.Point(50, 511);
            this.dgvTrend.Name = "dgvTrend";
            this.dgvTrend.ReadOnly = true;
            this.dgvTrend.RowHeadersVisible = false;
            this.dgvTrend.RowTemplate.Height = 26;
            this.dgvTrend.Size = new System.Drawing.Size(905, 29);
            this.dgvTrend.TabIndex = 140;
            this.dgvTrend.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTrend_CellFormatting);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Location = new System.Drawing.Point(50, 110);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.Size = new System.Drawing.Size(905, 376);
            this.dgvData.TabIndex = 140;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // dgvFoot
            // 
            this.dgvFoot.AllowUserToAddRows = false;
            this.dgvFoot.AllowUserToDeleteRows = false;
            this.dgvFoot.AllowUserToResizeColumns = false;
            this.dgvFoot.AllowUserToResizeRows = false;
            this.dgvFoot.BackgroundColor = System.Drawing.Color.White;
            this.dgvFoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFoot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFoot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoot.ColumnHeadersVisible = false;
            this.dgvFoot.Location = new System.Drawing.Point(50, 536);
            this.dgvFoot.Name = "dgvFoot";
            this.dgvFoot.ReadOnly = true;
            this.dgvFoot.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFoot.RowHeadersVisible = false;
            this.dgvFoot.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFoot.RowTemplate.Height = 39;
            this.dgvFoot.Size = new System.Drawing.Size(905, 40);
            this.dgvFoot.TabIndex = 141;
            // 
            // dgvHead
            // 
            this.dgvHead.AllowUserToAddRows = false;
            this.dgvHead.AllowUserToDeleteRows = false;
            this.dgvHead.AllowUserToResizeColumns = false;
            this.dgvHead.AllowUserToResizeRows = false;
            this.dgvHead.BackgroundColor = System.Drawing.Color.White;
            this.dgvHead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHead.ColumnHeadersVisible = false;
            this.dgvHead.Location = new System.Drawing.Point(50, 82);
            this.dgvHead.Name = "dgvHead";
            this.dgvHead.ReadOnly = true;
            this.dgvHead.RowHeadersVisible = false;
            this.dgvHead.RowTemplate.Height = 29;
            this.dgvHead.Size = new System.Drawing.Size(905, 30);
            this.dgvHead.TabIndex = 140;
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.btn;
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.FlatAppearance.BorderSize = 0;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(359, 52);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 144;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHour.Location = new System.Drawing.Point(61, 58);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(70, 12);
            this.lblHour.TabIndex = 143;
            this.lblHour.Text = "开奖时间：";
            // 
            // ddlHour
            // 
            this.ddlHour.BackColor = System.Drawing.SystemColors.Window;
            this.ddlHour.DisplayMember = "Value";
            this.ddlHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHour.DropDownWidth = 85;
            this.ddlHour.FormattingEnabled = true;
            this.ddlHour.Location = new System.Drawing.Point(141, 54);
            this.ddlHour.Name = "ddlHour";
            this.ddlHour.Size = new System.Drawing.Size(185, 20);
            this.ddlHour.TabIndex = 142;
            this.ddlHour.ValueMember = "Key";
            // 
            // bgwApp
            // 
            this.bgwApp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwApp_DoWork);
            this.bgwApp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwApp_RunWorkerCompleted);
            // 
            // SpecialAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvFoot);
            this.Controls.Add(this.dgvTrend);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.ddlHour);
            this.Controls.Add(this.dgvHead);
            this.Controls.Add(this.dgvNumber);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpecialAnalysis";
            this.Text = "SpecialAnalysis";
            this.Load += new System.EventHandler(this.SpecialAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTrend;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridView dgvFoot;
        private System.Windows.Forms.DataGridView dgvHead;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.ComboBox ddlHour;
        private System.ComponentModel.BackgroundWorker bgwApp;
    }
}
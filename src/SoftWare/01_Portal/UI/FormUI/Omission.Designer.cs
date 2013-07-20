namespace Helpmate.UI.Forms.FormUI
{
    partial class Omission
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
            this.label17 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bgwApp = new System.ComponentModel.BackgroundWorker();
            this.dgvDataOne = new System.Windows.Forms.DataGridView();
            this.dgvDataTwo = new System.Windows.Forms.DataGridView();
            this.dgvHead = new System.Windows.Forms.DataGridView();
            this.dgvFoot = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoot)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(552, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(197, 12);
            this.label17.TabIndex = 126;
            this.label17.Text = "提示：统计本期之前20期遗漏的号码";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(25, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 1);
            this.panel1.TabIndex = 123;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(36, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 124;
            this.label2.Text = "遗漏号码统计：";
            // 
            // bgwApp
            // 
            this.bgwApp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwApp_DoWork);
            this.bgwApp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwApp_RunWorkerCompleted);
            // 
            // dgvDataOne
            // 
            this.dgvDataOne.AllowUserToAddRows = false;
            this.dgvDataOne.AllowUserToDeleteRows = false;
            this.dgvDataOne.AllowUserToResizeColumns = false;
            this.dgvDataOne.AllowUserToResizeRows = false;
            this.dgvDataOne.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvDataOne.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDataOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataOne.ColumnHeadersVisible = false;
            this.dgvDataOne.Location = new System.Drawing.Point(40, 80);
            this.dgvDataOne.Name = "dgvDataOne";
            this.dgvDataOne.ReadOnly = true;
            this.dgvDataOne.RowHeadersVisible = false;
            this.dgvDataOne.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDataOne.RowTemplate.Height = 23;
            this.dgvDataOne.Size = new System.Drawing.Size(360, 393);
            this.dgvDataOne.TabIndex = 136;
            this.dgvDataOne.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDataOne_CellFormatting);
            // 
            // dgvDataTwo
            // 
            this.dgvDataTwo.AllowUserToAddRows = false;
            this.dgvDataTwo.AllowUserToDeleteRows = false;
            this.dgvDataTwo.AllowUserToResizeColumns = false;
            this.dgvDataTwo.AllowUserToResizeRows = false;
            this.dgvDataTwo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvDataTwo.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataTwo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDataTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTwo.ColumnHeadersVisible = false;
            this.dgvDataTwo.Location = new System.Drawing.Point(385, 80);
            this.dgvDataTwo.Name = "dgvDataTwo";
            this.dgvDataTwo.ReadOnly = true;
            this.dgvDataTwo.RowHeadersVisible = false;
            this.dgvDataTwo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDataTwo.RowTemplate.Height = 23;
            this.dgvDataTwo.Size = new System.Drawing.Size(375, 393);
            this.dgvDataTwo.TabIndex = 136;
            this.dgvDataTwo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDataOne_CellFormatting);
            // 
            // dgvHead
            // 
            this.dgvHead.AllowUserToAddRows = false;
            this.dgvHead.AllowUserToDeleteRows = false;
            this.dgvHead.AllowUserToResizeColumns = false;
            this.dgvHead.AllowUserToResizeRows = false;
            this.dgvHead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvHead.BackgroundColor = System.Drawing.Color.White;
            this.dgvHead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHead.ColumnHeadersVisible = false;
            this.dgvHead.Location = new System.Drawing.Point(40, 51);
            this.dgvHead.Name = "dgvHead";
            this.dgvHead.ReadOnly = true;
            this.dgvHead.RowHeadersVisible = false;
            this.dgvHead.RowTemplate.Height = 29;
            this.dgvHead.Size = new System.Drawing.Size(720, 30);
            this.dgvHead.TabIndex = 137;
            // 
            // dgvFoot
            // 
            this.dgvFoot.AllowUserToAddRows = false;
            this.dgvFoot.AllowUserToDeleteRows = false;
            this.dgvFoot.AllowUserToResizeColumns = false;
            this.dgvFoot.AllowUserToResizeRows = false;
            this.dgvFoot.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvFoot.BackgroundColor = System.Drawing.Color.White;
            this.dgvFoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFoot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFoot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoot.ColumnHeadersVisible = false;
            this.dgvFoot.Location = new System.Drawing.Point(40, 472);
            this.dgvFoot.Name = "dgvFoot";
            this.dgvFoot.ReadOnly = true;
            this.dgvFoot.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFoot.RowHeadersVisible = false;
            this.dgvFoot.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFoot.RowTemplate.Height = 39;
            this.dgvFoot.Size = new System.Drawing.Size(720, 40);
            this.dgvFoot.TabIndex = 138;
            // 
            // Omission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvFoot);
            this.Controls.Add(this.dgvHead);
            this.Controls.Add(this.dgvDataTwo);
            this.Controls.Add(this.dgvDataOne);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Omission";
            this.Text = "Omission";
            this.Load += new System.EventHandler(this.Omission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgwApp;
        private System.Windows.Forms.DataGridView dgvDataOne;
        private System.Windows.Forms.DataGridView dgvDataTwo;
        private System.Windows.Forms.DataGridView dgvHead;
        private System.Windows.Forms.DataGridView dgvFoot;
    }
}
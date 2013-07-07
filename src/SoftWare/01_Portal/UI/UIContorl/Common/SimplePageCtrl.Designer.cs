namespace Helpmate.UI.Forms.UIContorl.Common
{
    partial class SimplePageCtrl
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
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPageDown = new System.Windows.Forms.Button();
            this.btnPageUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.ForeColor = System.Drawing.Color.Black;
            this.lblPageInfo.Location = new System.Drawing.Point(46, 8);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(23, 12);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "0/0";
            // 
            // btnPageDown
            // 
            this.btnPageDown.BackColor = System.Drawing.Color.Transparent;
            this.btnPageDown.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.pageup;
            this.btnPageDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPageDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPageDown.Location = new System.Drawing.Point(97, 3);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(55, 22);
            this.btnPageDown.TabIndex = 1;
            this.btnPageDown.UseVisualStyleBackColor = false;
            this.btnPageDown.Click += new System.EventHandler(this.btnPageDown_Click);
            // 
            // btnPageUp
            // 
            this.btnPageUp.BackColor = System.Drawing.Color.Transparent;
            this.btnPageUp.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.pagedown;
            this.btnPageUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPageUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPageUp.Location = new System.Drawing.Point(157, 3);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(55, 22);
            this.btnPageUp.TabIndex = 1;
            this.btnPageUp.UseVisualStyleBackColor = false;
            this.btnPageUp.Click += new System.EventHandler(this.btnPageUp_Click);
            // 
            // SimplePageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnPageUp);
            this.Controls.Add(this.btnPageDown);
            this.Controls.Add(this.lblPageInfo);
            this.Name = "SimplePageCtrl";
            this.Size = new System.Drawing.Size(215, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnPageDown;
        private System.Windows.Forms.Button btnPageUp;
    }
}

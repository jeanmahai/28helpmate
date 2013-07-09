namespace Helpmate.UI.Forms.FormUI
{
    partial class DateSlt
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
            this.dateControl = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // dateControl
            // 
            this.dateControl.Location = new System.Drawing.Point(1, 2);
            this.dateControl.Name = "dateControl";
            this.dateControl.TabIndex = 0;
            this.dateControl.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.dateControl_DateSelected);
            // 
            // DateSlt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 181);
            this.Controls.Add(this.dateControl);
            this.Name = "DateSlt";
            this.Text = "选择日期";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar dateControl;
    }
}
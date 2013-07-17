namespace Helpmate.UI.Forms.FormUI.Customer
{
    partial class GetPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetPwd));
            this.cmbQuestionTwo = new System.Windows.Forms.ComboBox();
            this.cmbQuestionOne = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bgwGetPwd = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAnswerOne = new System.Windows.Forms.TextBox();
            this.txtAnswerTwo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNewPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbQuestionTwo
            // 
            this.cmbQuestionTwo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbQuestionTwo.DisplayMember = "Value";
            this.cmbQuestionTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionTwo.FormattingEnabled = true;
            this.cmbQuestionTwo.Items.AddRange(new object[] {
            "请选择"});
            this.cmbQuestionTwo.Location = new System.Drawing.Point(219, 233);
            this.cmbQuestionTwo.Name = "cmbQuestionTwo";
            this.cmbQuestionTwo.Size = new System.Drawing.Size(319, 20);
            this.cmbQuestionTwo.TabIndex = 182;
            this.cmbQuestionTwo.ValueMember = "Key";
            // 
            // cmbQuestionOne
            // 
            this.cmbQuestionOne.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbQuestionOne.DisplayMember = "Value";
            this.cmbQuestionOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionOne.FormattingEnabled = true;
            this.cmbQuestionOne.Items.AddRange(new object[] {
            "请选择"});
            this.cmbQuestionOne.Location = new System.Drawing.Point(219, 167);
            this.cmbQuestionOne.Name = "cmbQuestionOne";
            this.cmbQuestionOne.Size = new System.Drawing.Size(319, 20);
            this.cmbQuestionOne.TabIndex = 183;
            this.cmbQuestionOne.ValueMember = "Key";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(6, 145);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 1);
            this.panel2.TabIndex = 179;
            // 
            // bgwGetPwd
            // 
            this.bgwGetPwd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetPwd_DoWork);
            this.bgwGetPwd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGetPwd_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.border_sidemenu_top;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(6, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 1);
            this.panel1.TabIndex = 178;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(15, 119);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 19);
            this.label12.TabIndex = 181;
            this.label12.Text = "密码安全";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(15, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 19);
            this.label11.TabIndex = 180;
            this.label11.Text = "基本信息";
            // 
            // pnlLoading
            // 
            this.pnlLoading.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoading.Location = new System.Drawing.Point(250, 302);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(267, 20);
            this.pnlLoading.TabIndex = 177;
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.Transparent;
            this.btnSure.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.btn;
            this.btnSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSure.FlatAppearance.BorderSize = 0;
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSure.ForeColor = System.Drawing.Color.White;
            this.btnSure.Location = new System.Drawing.Point(250, 338);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(94, 31);
            this.btnSure.TabIndex = 176;
            this.btnSure.Text = "确 定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.btn;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(423, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 31);
            this.btnCancel.TabIndex = 175;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAnswerOne
            // 
            this.txtAnswerOne.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAnswerOne.Location = new System.Drawing.Point(219, 197);
            this.txtAnswerOne.MaxLength = 40;
            this.txtAnswerOne.Name = "txtAnswerOne";
            this.txtAnswerOne.Size = new System.Drawing.Size(319, 21);
            this.txtAnswerOne.TabIndex = 163;
            // 
            // txtAnswerTwo
            // 
            this.txtAnswerTwo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAnswerTwo.Location = new System.Drawing.Point(219, 265);
            this.txtAnswerTwo.MaxLength = 40;
            this.txtAnswerTwo.Name = "txtAnswerTwo";
            this.txtAnswerTwo.Size = new System.Drawing.Size(319, 21);
            this.txtAnswerTwo.TabIndex = 164;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(110, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 170;
            this.label10.Text = "密码问题答案一：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(110, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 165;
            this.label8.Text = "密码问题答案二：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(110, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 166;
            this.label9.Text = "密码保护问题一：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(110, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 168;
            this.label7.Text = "密码保护问题二：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(110, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 171;
            this.label6.Text = "新的密码：";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserID.Location = new System.Drawing.Point(219, 47);
            this.txtUserID.MaxLength = 40;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(234, 21);
            this.txtUserID.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(110, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 172;
            this.label1.Text = "邮箱账号：";
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.AutoSize = true;
            this.lblNewPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNewPwd.ForeColor = System.Drawing.Color.Red;
            this.lblNewPwd.Location = new System.Drawing.Point(219, 87);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(0, 12);
            this.lblNewPwd.TabIndex = 184;
            // 
            // GetPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 406);
            this.Controls.Add(this.lblNewPwd);
            this.Controls.Add(this.cmbQuestionTwo);
            this.Controls.Add(this.cmbQuestionOne);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtAnswerOne);
            this.Controls.Add(this.txtAnswerTwo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "找回密码";
            this.Load += new System.EventHandler(this.GetPwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbQuestionTwo;
        private System.Windows.Forms.ComboBox cmbQuestionOne;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bgwGetPwd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlLoading;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAnswerOne;
        private System.Windows.Forms.TextBox txtAnswerTwo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNewPwd;
    }
}
﻿namespace Helpmate.UI.Forms
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.bgwUserLogin = new System.ComponentModel.BackgroundWorker();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.bgwUpdate = new System.ComponentModel.BackgroundWorker();
            this.picCode = new System.Windows.Forms.PictureBox();
            this.bgwCode = new System.ComponentModel.BackgroundWorker();
            this.tlAlter = new System.Windows.Forms.ToolTip(this.components);
            this.lnkGetPwd = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(294, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(295, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "密   码：";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserName.Location = new System.Drawing.Point(355, 82);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(221, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserPwd.Location = new System.Drawing.Point(355, 127);
            this.txtUserPwd.MaxLength = 50;
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Size = new System.Drawing.Size(221, 21);
            this.txtUserPwd.TabIndex = 2;
            this.txtUserPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.btn;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(313, 235);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(94, 31);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "立即登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlLoading
            // 
            this.pnlLoading.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoading.Location = new System.Drawing.Point(297, 208);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(279, 20);
            this.pnlLoading.TabIndex = 3;
            // 
            // bgwUserLogin
            // 
            this.bgwUserLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUserLogin_DoWork);
            this.bgwUserLogin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUserLogin_RunWorkerCompleted);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCode.Location = new System.Drawing.Point(355, 172);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(96, 21);
            this.txtCode.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(294, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "验证码：";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.btn;
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(413, 234);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(94, 31);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "用户注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // bgwUpdate
            // 
            this.bgwUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundUpdate_DoWork);
            this.bgwUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundUpdate_RunWorkerCompleted);
            // 
            // picCode
            // 
            this.picCode.BackColor = System.Drawing.Color.Transparent;
            this.picCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCode.Location = new System.Drawing.Point(457, 166);
            this.picCode.Name = "picCode";
            this.picCode.Size = new System.Drawing.Size(119, 33);
            this.picCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCode.TabIndex = 7;
            this.picCode.TabStop = false;
            this.tlAlter.SetToolTip(this.picCode, "点击获取验证码");
            this.picCode.Click += new System.EventHandler(this.picCode_Click);
            // 
            // bgwCode
            // 
            this.bgwCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCode_DoWork);
            this.bgwCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCode_RunWorkerCompleted);
            // 
            // lnkGetPwd
            // 
            this.lnkGetPwd.AutoSize = true;
            this.lnkGetPwd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkGetPwd.Location = new System.Drawing.Point(513, 243);
            this.lnkGetPwd.Name = "lnkGetPwd";
            this.lnkGetPwd.Size = new System.Drawing.Size(63, 14);
            this.lnkGetPwd.TabIndex = 8;
            this.lnkGetPwd.TabStop = true;
            this.lnkGetPwd.Text = "忘记密码";
            this.lnkGetPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGetPwd_LinkClicked);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Helpmate.UI.Forms.Properties.Resources.loginbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(590, 286);
            this.Controls.Add(this.lnkGetPwd);
            this.Controls.Add(this.picCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "28伴侣-分析平台";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlLoading;
        private System.ComponentModel.BackgroundWorker bgwUserLogin;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegister;
        private System.ComponentModel.BackgroundWorker bgwUpdate;
        private System.Windows.Forms.PictureBox picCode;
        private System.ComponentModel.BackgroundWorker bgwCode;
        private System.Windows.Forms.ToolTip tlAlter;
        private System.Windows.Forms.LinkLabel lnkGetPwd;
    }
}
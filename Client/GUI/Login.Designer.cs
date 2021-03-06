﻿namespace Client
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.EnterEmail = new System.Windows.Forms.TextBox();
            this.EnterPassword = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.MailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.ExitLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rememberMeCheckBox = new System.Windows.Forms.CheckBox();
            this.poweredBy = new System.Windows.Forms.Label();
            this.fantastic4 = new System.Windows.Forms.Label();
            this.loginFailedLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnterEmail
            // 
            this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.EnterEmail.ForeColor = System.Drawing.Color.Gray;
            this.EnterEmail.Location = new System.Drawing.Point(19, 70);
            this.EnterEmail.Margin = new System.Windows.Forms.Padding(2);
            this.EnterEmail.MaximumSize = new System.Drawing.Size(543, 50);
            this.EnterEmail.MinimumSize = new System.Drawing.Size(443, 30);
            this.EnterEmail.Name = "EnterEmail";
            this.EnterEmail.Size = new System.Drawing.Size(443, 30);
            this.EnterEmail.TabIndex = 2;
            this.EnterEmail.Tag = "";
            this.EnterEmail.Text = "Username";
            this.EnterEmail.TextChanged += new System.EventHandler(this.EnterEmail_TextChanged);
            this.EnterEmail.Enter += new System.EventHandler(this.EnterEmail_Enter);
            this.EnterEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            this.EnterEmail.Leave += new System.EventHandler(this.EnterEmail_Leave);
            // 
            // EnterPassword
            // 
            this.EnterPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.EnterPassword.ForeColor = System.Drawing.Color.Gray;
            this.EnterPassword.Location = new System.Drawing.Point(19, 106);
            this.EnterPassword.Margin = new System.Windows.Forms.Padding(2);
            this.EnterPassword.MaximumSize = new System.Drawing.Size(333, 50);
            this.EnterPassword.MinimumSize = new System.Drawing.Size(443, 30);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.Size = new System.Drawing.Size(443, 30);
            this.EnterPassword.TabIndex = 3;
            this.EnterPassword.Text = "Password";
            this.EnterPassword.TextChanged += new System.EventHandler(this.EnterPassword_TextChanged);
            this.EnterPassword.Enter += new System.EventHandler(this.EnterPassword_Enter);
            this.EnterPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            this.EnterPassword.Leave += new System.EventHandler(this.EnterPassword_Leave);
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.BackColor = System.Drawing.Color.AliceBlue;
            this.LoginButton.Enabled = false;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.SteelBlue;
            this.LoginButton.Location = new System.Drawing.Point(136, 173);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(203, 33);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // MailLabel
            // 
            this.MailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MailLabel.AutoSize = true;
            this.MailLabel.BackColor = System.Drawing.Color.Transparent;
            this.MailLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MailLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.MailLabel.Location = new System.Drawing.Point(182, 12);
            this.MailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(105, 39);
            this.MailLabel.TabIndex = 4;
            this.MailLabel.Text = "Login";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(78, 462);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(114, 25);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.Visible = false;
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RegisterLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.RegisterLabel.Location = new System.Drawing.Point(176, 228);
            this.RegisterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(126, 17);
            this.RegisterLabel.TabIndex = 7;
            this.RegisterLabel.Text = "Become a member";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.RegisterButton.Location = new System.Drawing.Point(160, 247);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(2);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(157, 23);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // ExitLogin
            // 
            this.ExitLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.ExitLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLogin.ForeColor = System.Drawing.Color.AliceBlue;
            this.ExitLogin.Location = new System.Drawing.Point(200, 334);
            this.ExitLogin.Margin = new System.Windows.Forms.Padding(2);
            this.ExitLogin.Name = "ExitLogin";
            this.ExitLogin.Size = new System.Drawing.Size(75, 23);
            this.ExitLogin.TabIndex = 1;
            this.ExitLogin.Text = "Exit";
            this.ExitLogin.UseVisualStyleBackColor = false;
            this.ExitLogin.Click += new System.EventHandler(this.ExitLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Client.Properties.Resources.manchattan;
            this.pictureBox1.Location = new System.Drawing.Point(73, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 150);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(172, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Registration Succeded!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.AutoSize = true;
            this.rememberMeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rememberMeCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.rememberMeCheckBox.Location = new System.Drawing.Point(23, 143);
            this.rememberMeCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(101, 17);
            this.rememberMeCheckBox.TabIndex = 4;
            this.rememberMeCheckBox.Text = "Remember Me?";
            this.rememberMeCheckBox.UseVisualStyleBackColor = false;
            this.rememberMeCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // poweredBy
            // 
            this.poweredBy.AutoSize = true;
            this.poweredBy.BackColor = System.Drawing.Color.Transparent;
            this.poweredBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poweredBy.ForeColor = System.Drawing.Color.White;
            this.poweredBy.Location = new System.Drawing.Point(214, 583);
            this.poweredBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.poweredBy.Name = "poweredBy";
            this.poweredBy.Size = new System.Drawing.Size(142, 13);
            this.poweredBy.TabIndex = 13;
            this.poweredBy.Text = "Powered by ClientDriver 1.1";
            // 
            // fantastic4
            // 
            this.fantastic4.AutoSize = true;
            this.fantastic4.BackColor = System.Drawing.Color.Transparent;
            this.fantastic4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fantastic4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fantastic4.Location = new System.Drawing.Point(429, 125);
            this.fantastic4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fantastic4.Name = "fantastic4";
            this.fantastic4.Size = new System.Drawing.Size(83, 16);
            this.fantastic4.TabIndex = 14;
            this.fantastic4.Text = "By Fantastic4";
            // 
            // loginFailedLabel
            // 
            this.loginFailedLabel.AutoSize = true;
            this.loginFailedLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginFailedLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginFailedLabel.ForeColor = System.Drawing.Color.Crimson;
            this.loginFailedLabel.Location = new System.Drawing.Point(203, 171);
            this.loginFailedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginFailedLabel.Name = "loginFailedLabel";
            this.loginFailedLabel.Size = new System.Drawing.Size(194, 16);
            this.loginFailedLabel.TabIndex = 15;
            this.loginFailedLabel.Text = "Wrong Username or Password";
            this.loginFailedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginFailedLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.MailLabel);
            this.panel1.Controls.Add(this.EnterEmail);
            this.panel1.Controls.Add(this.EnterPassword);
            this.panel1.Controls.Add(this.LoginButton);
            this.panel1.Controls.Add(this.rememberMeCheckBox);
            this.panel1.Controls.Add(this.RegisterLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RegisterButton);
            this.panel1.Controls.Add(this.ExitLogin);
            this.panel1.Location = new System.Drawing.Point(51, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 383);
            this.panel1.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SteelBlue;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel6.Location = new System.Drawing.Point(20, 56);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(443, 2);
            this.panel6.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Location = new System.Drawing.Point(20, 317);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 2);
            this.panel2.TabIndex = 24;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Client.Properties.Resources.background7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 605);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loginFailedLabel);
            this.Controls.Add(this.fantastic4);
            this.Controls.Add(this.poweredBy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PasswordLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManChattan - Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button ExitLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox rememberMeCheckBox;
        public System.Windows.Forms.TextBox EnterEmail;
        public System.Windows.Forms.TextBox EnterPassword;
        private System.Windows.Forms.Label poweredBy;
        private System.Windows.Forms.Label fantastic4;
        private System.Windows.Forms.Label loginFailedLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
    }
}

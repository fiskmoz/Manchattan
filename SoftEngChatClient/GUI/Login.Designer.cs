namespace SoftEngChatClient
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
            this.Title = new System.Windows.Forms.Label();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.ExitLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rememberMeCheckBox = new System.Windows.Forms.CheckBox();
            this.poweredBy = new System.Windows.Forms.Label();
            this.fantastic4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterEmail
            // 
            this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.EnterEmail.ForeColor = System.Drawing.Color.Gray;
            this.EnterEmail.Location = new System.Drawing.Point(73, 192);
            this.EnterEmail.MaximumSize = new System.Drawing.Size(543, 50);
            this.EnterEmail.MinimumSize = new System.Drawing.Size(443, 30);
            this.EnterEmail.Name = "EnterEmail";
            this.EnterEmail.Size = new System.Drawing.Size(443, 29);
            this.EnterEmail.TabIndex = 1;
            this.EnterEmail.TabStop = false;
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
            this.EnterPassword.Location = new System.Drawing.Point(73, 228);
            this.EnterPassword.MaximumSize = new System.Drawing.Size(443, 50);
            this.EnterPassword.MinimumSize = new System.Drawing.Size(443, 30);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.Size = new System.Drawing.Size(443, 29);
            this.EnterPassword.TabIndex = 2;
            this.EnterPassword.TabStop = false;
            this.EnterPassword.Text = "Password";
            this.EnterPassword.TextChanged += new System.EventHandler(this.EnterPassword_TextChanged);
            this.EnterPassword.Enter += new System.EventHandler(this.EnterPassword_Enter);
            this.EnterPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            this.EnterPassword.Leave += new System.EventHandler(this.EnterPassword_Leave);
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
            this.LoginButton.Enabled = false;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(190, 295);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(203, 33);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // MailLabel
            // 
            this.MailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MailLabel.AutoSize = true;
            this.MailLabel.BackColor = System.Drawing.Color.Transparent;
            this.MailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.MailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MailLabel.Location = new System.Drawing.Point(235, 149);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(106, 39);
            this.MailLabel.TabIndex = 4;
            this.MailLabel.Text = "Login";
            this.MailLabel.Visible = false;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(7, 452);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(114, 25);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.Visible = false;
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.AutoSize = true;
            this.Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(121, 64);
            this.Title.MinimumSize = new System.Drawing.Size(326, 36);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(326, 37);
            this.Title.TabIndex = 6;
            this.Title.Text = "Manchattan 2k18";
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RegisterLabel.ForeColor = System.Drawing.Color.White;
            this.RegisterLabel.Location = new System.Drawing.Point(234, 349);
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
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(214, 369);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(157, 23);
            this.RegisterButton.TabIndex = 8;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // ExitLogin
            // 
            this.ExitLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExitLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLogin.ForeColor = System.Drawing.Color.White;
            this.ExitLogin.Location = new System.Drawing.Point(255, 450);
            this.ExitLogin.Name = "ExitLogin";
            this.ExitLogin.Size = new System.Drawing.Size(75, 23);
            this.ExitLogin.TabIndex = 9;
            this.ExitLogin.Text = "Exit";
            this.ExitLogin.UseVisualStyleBackColor = false;
            this.ExitLogin.Click += new System.EventHandler(this.ExitLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SoftEngChatClient.Properties.Resources.manchattan;
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
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(221, 269);
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
            this.rememberMeCheckBox.ForeColor = System.Drawing.Color.White;
            this.rememberMeCheckBox.Location = new System.Drawing.Point(73, 263);
            this.rememberMeCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(101, 17);
            this.rememberMeCheckBox.TabIndex = 12;
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
            this.poweredBy.Location = new System.Drawing.Point(441, 472);
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
            this.fantastic4.Location = new System.Drawing.Point(426, 124);
            this.fantastic4.Name = "fantastic4";
            this.fantastic4.Size = new System.Drawing.Size(83, 16);
            this.fantastic4.TabIndex = 14;
            this.fantastic4.Text = "By Fantastic4";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SoftEngChatClient.Properties.Resources.background7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 487);
            this.Controls.Add(this.fantastic4);
            this.Controls.Add(this.poweredBy);
            this.Controls.Add(this.rememberMeCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExitLogin);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.RegisterLabel);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.MailLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.EnterPassword);
            this.Controls.Add(this.EnterEmail);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManChattan - Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label Title;
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
    }
}

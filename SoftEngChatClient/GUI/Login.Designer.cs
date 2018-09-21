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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterEmail
            // 
            this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterEmail.Location = new System.Drawing.Point(201, 340);
            this.EnterEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EnterEmail.Name = "EnterEmail";
            this.EnterEmail.Size = new System.Drawing.Size(468, 26);
            this.EnterEmail.TabIndex = 1;
            this.EnterEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            // 
            // EnterPassword
            // 
            this.EnterPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterPassword.Location = new System.Drawing.Point(201, 478);
            this.EnterPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.PasswordChar = '*';
            this.EnterPassword.Size = new System.Drawing.Size(468, 26);
            this.EnterPassword.TabIndex = 2;
            this.EnterPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(355, 546);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(135, 42);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // MailLabel
            // 
            this.MailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MailLabel.AutoSize = true;
            this.MailLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MailLabel.Location = new System.Drawing.Point(351, 282);
            this.MailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(161, 38);
            this.MailLabel.TabIndex = 4;
            this.MailLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(354, 422);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(140, 34);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.AutoSize = true;
            this.Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(181, 98);
            this.Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Title.MinimumSize = new System.Drawing.Size(489, 55);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(489, 55);
            this.Title.TabIndex = 6;
            this.Title.Text = "Manchattan 2k18";
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Location = new System.Drawing.Point(34, 632);
            this.RegisterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(143, 20);
            this.RegisterLabel.TabIndex = 7;
            this.RegisterLabel.Text = "Become a member";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterButton.Location = new System.Drawing.Point(39, 658);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(112, 35);
            this.RegisterButton.TabIndex = 8;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // ExitLogin
            // 
            this.ExitLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitLogin.Location = new System.Drawing.Point(674, 658);
            this.ExitLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExitLogin.Name = "ExitLogin";
            this.ExitLogin.Size = new System.Drawing.Size(112, 35);
            this.ExitLogin.TabIndex = 9;
            this.ExitLogin.Text = "Exit";
            this.ExitLogin.UseVisualStyleBackColor = true;
            this.ExitLogin.Click += new System.EventHandler(this.ExitLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SoftEngChatClient.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(109, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(658, 160);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(342, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Registration Succeded!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.AutoSize = true;
            this.rememberMeCheckBox.Location = new System.Drawing.Point(176, 559);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(149, 24);
            this.rememberMeCheckBox.TabIndex = 12;
            this.rememberMeCheckBox.Text = "Remember Me?";
            this.rememberMeCheckBox.UseVisualStyleBackColor = true;
            this.rememberMeCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(876, 749);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.Opacity = 0.95D;
            this.Text = "Login";
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
    }
}

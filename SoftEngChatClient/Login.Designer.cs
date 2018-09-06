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
            this.SuspendLayout();
            // 
            // EnterEmail
            // 
            this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterEmail.Location = new System.Drawing.Point(156, 221);
            this.EnterEmail.Name = "EnterEmail";
            this.EnterEmail.Size = new System.Drawing.Size(313, 20);
            this.EnterEmail.TabIndex = 1;
            // 
            // EnterPassword
            // 
            this.EnterPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterPassword.Location = new System.Drawing.Point(156, 310);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.Size = new System.Drawing.Size(313, 20);
            this.EnterPassword.TabIndex = 2;
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(259, 355);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(90, 27);
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
            this.MailLabel.Location = new System.Drawing.Point(256, 183);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(76, 25);
            this.MailLabel.TabIndex = 4;
            this.MailLabel.Text = "E-mail";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(258, 274);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(91, 23);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.AutoSize = true;
            this.Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(143, 63);
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
            this.RegisterLabel.Location = new System.Drawing.Point(23, 411);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(95, 13);
            this.RegisterLabel.TabIndex = 7;
            this.RegisterLabel.Text = "Become a member";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterButton.Location = new System.Drawing.Point(26, 427);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 23);
            this.RegisterButton.TabIndex = 8;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // ExitLogin
            // 
            this.ExitLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitLogin.Location = new System.Drawing.Point(449, 427);
            this.ExitLogin.Name = "ExitLogin";
            this.ExitLogin.Size = new System.Drawing.Size(75, 23);
            this.ExitLogin.TabIndex = 9;
            this.ExitLogin.Text = "Exit";
            this.ExitLogin.UseVisualStyleBackColor = true;
            this.ExitLogin.Click += new System.EventHandler(this.ExitLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.ExitLogin);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.RegisterLabel);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.MailLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.EnterPassword);
            this.Controls.Add(this.EnterEmail);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox EnterEmail;
        private System.Windows.Forms.TextBox EnterPassword;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button ExitLogin;
    }
}

namespace SoftEngChatClient
{
    partial class Register
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
            this.RegisterAccept = new System.Windows.Forms.Button();
            this.RegisterCancel = new System.Windows.Forms.Button();
            this.EnterPassword = new System.Windows.Forms.TextBox();
            this.EnterEmail = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegisterAccept
            // 
            this.RegisterAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterAccept.Location = new System.Drawing.Point(85, 304);
            this.RegisterAccept.Name = "RegisterAccept";
            this.RegisterAccept.Size = new System.Drawing.Size(75, 23);
            this.RegisterAccept.TabIndex = 0;
            this.RegisterAccept.Text = "Register";
            this.RegisterAccept.UseVisualStyleBackColor = true;
            this.RegisterAccept.Click += new System.EventHandler(this.RegisterAccept_Click);
            // 
            // RegisterCancel
            // 
            this.RegisterCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterCancel.Location = new System.Drawing.Point(228, 304);
            this.RegisterCancel.Name = "RegisterCancel";
            this.RegisterCancel.Size = new System.Drawing.Size(75, 23);
            this.RegisterCancel.TabIndex = 1;
            this.RegisterCancel.Text = "Cancel";
            this.RegisterCancel.UseVisualStyleBackColor = true;
            this.RegisterCancel.Click += new System.EventHandler(this.RegisterCancel_Click);
            // 
            // EnterPassword
            // 
            this.EnterPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterPassword.Location = new System.Drawing.Point(85, 208);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.Size = new System.Drawing.Size(218, 20);
            this.EnterPassword.TabIndex = 2;
            // 
            // EnterEmail
            // 
            this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterEmail.Location = new System.Drawing.Point(85, 127);
            this.EnterEmail.Name = "EnterEmail";
            this.EnterEmail.Size = new System.Drawing.Size(218, 20);
            this.EnterEmail.TabIndex = 3;
            // 
            // EmailLabel
            // 
            this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(150, 101);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(67, 23);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "E-mail";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(150, 182);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(91, 23);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 399);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.EnterEmail);
            this.Controls.Add(this.EnterPassword);
            this.Controls.Add(this.RegisterCancel);
            this.Controls.Add(this.RegisterAccept);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterAccept;
        private System.Windows.Forms.Button RegisterCancel;
        private System.Windows.Forms.TextBox EnterPassword;
        private System.Windows.Forms.TextBox EnterEmail;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
    }
}

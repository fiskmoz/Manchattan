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
			this.EnterUsername = new System.Windows.Forms.TextBox();
			this.EmailLabel = new System.Windows.Forms.Label();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.EnterEmail = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.EnterForename = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.EnterSurname = new System.Windows.Forms.TextBox();
			this.regRejectLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// RegisterAccept
			// 
			this.RegisterAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.RegisterAccept.Location = new System.Drawing.Point(106, 422);
			this.RegisterAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.RegisterAccept.Name = "RegisterAccept";
			this.RegisterAccept.Size = new System.Drawing.Size(100, 28);
			this.RegisterAccept.TabIndex = 0;
			this.RegisterAccept.Text = "Register";
			this.RegisterAccept.UseVisualStyleBackColor = true;
			this.RegisterAccept.Click += new System.EventHandler(this.RegisterAccept_Click);
			// 
			// RegisterCancel
			// 
			this.RegisterCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.RegisterCancel.Location = new System.Drawing.Point(296, 422);
			this.RegisterCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.RegisterCancel.Name = "RegisterCancel";
			this.RegisterCancel.Size = new System.Drawing.Size(100, 28);
			this.RegisterCancel.TabIndex = 1;
			this.RegisterCancel.Text = "Cancel";
			this.RegisterCancel.UseVisualStyleBackColor = true;
			this.RegisterCancel.Click += new System.EventHandler(this.RegisterCancel_Click);
			// 
			// EnterPassword
			// 
			this.EnterPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EnterPassword.Location = new System.Drawing.Point(112, 158);
			this.EnterPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.EnterPassword.Name = "EnterPassword";
			this.EnterPassword.Size = new System.Drawing.Size(289, 22);
			this.EnterPassword.TabIndex = 2;
			// 
			// EnterUsername
			// 
			this.EnterUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EnterUsername.Location = new System.Drawing.Point(112, 84);
			this.EnterUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.EnterUsername.Name = "EnterUsername";
			this.EnterUsername.Size = new System.Drawing.Size(289, 22);
			this.EnterUsername.TabIndex = 3;
			// 
			// EmailLabel
			// 
			this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EmailLabel.AutoSize = true;
			this.EmailLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EmailLabel.Location = new System.Drawing.Point(182, 51);
			this.EmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.EmailLabel.Name = "EmailLabel";
			this.EmailLabel.Size = new System.Drawing.Size(122, 29);
			this.EmailLabel.TabIndex = 4;
			this.EmailLabel.Text = "Username";
			this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.EmailLabel.Click += new System.EventHandler(this.EmailLabel_Click);
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordLabel.Location = new System.Drawing.Point(188, 125);
			this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(115, 29);
			this.PasswordLabel.TabIndex = 5;
			this.PasswordLabel.Text = "Password";
			this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(200, 199);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 29);
			this.label1.TabIndex = 7;
			this.label1.Text = "E-Mail";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EnterEmail
			// 
			this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EnterEmail.Location = new System.Drawing.Point(112, 232);
			this.EnterEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.EnterEmail.Name = "EnterEmail";
			this.EnterEmail.Size = new System.Drawing.Size(289, 22);
			this.EnterEmail.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(188, 276);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 29);
			this.label2.TabIndex = 9;
			this.label2.Text = "Forename";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EnterForename
			// 
			this.EnterForename.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EnterForename.Location = new System.Drawing.Point(112, 309);
			this.EnterForename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.EnterForename.Name = "EnterForename";
			this.EnterForename.Size = new System.Drawing.Size(289, 22);
			this.EnterForename.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(194, 351);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 29);
			this.label3.TabIndex = 11;
			this.label3.Text = "Surname";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EnterSurname
			// 
			this.EnterSurname.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EnterSurname.Location = new System.Drawing.Point(106, 384);
			this.EnterSurname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.EnterSurname.Name = "EnterSurname";
			this.EnterSurname.Size = new System.Drawing.Size(289, 22);
			this.EnterSurname.TabIndex = 10;
			// 
			// regRejectLbl
			// 
			this.regRejectLbl.AutoSize = true;
			this.regRejectLbl.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.regRejectLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.regRejectLbl.Location = new System.Drawing.Point(173, 9);
			this.regRejectLbl.Name = "regRejectLbl";
			this.regRejectLbl.Size = new System.Drawing.Size(148, 17);
			this.regRejectLbl.TabIndex = 12;
			this.regRejectLbl.Text = "Registration Rejected!";
			this.regRejectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.regRejectLbl.Visible = false;
			// 
			// Register
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 491);
			this.Controls.Add(this.regRejectLbl);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.EnterSurname);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.EnterForename);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EnterEmail);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.EmailLabel);
			this.Controls.Add(this.EnterUsername);
			this.Controls.Add(this.EnterPassword);
			this.Controls.Add(this.RegisterCancel);
			this.Controls.Add(this.RegisterAccept);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Register";
			this.Text = "Register";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterAccept;
        private System.Windows.Forms.Button RegisterCancel;
        private System.Windows.Forms.TextBox EnterPassword;
        private System.Windows.Forms.TextBox EnterUsername;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EnterEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EnterForename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EnterSurname;
		private System.Windows.Forms.Label regRejectLbl;
	}
}

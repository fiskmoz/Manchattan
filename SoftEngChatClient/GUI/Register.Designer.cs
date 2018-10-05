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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.poweredBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterAccept
            // 
            this.RegisterAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.RegisterAccept.Enabled = false;
            this.RegisterAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterAccept.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold);
            this.RegisterAccept.ForeColor = System.Drawing.Color.White;
            this.RegisterAccept.Location = new System.Drawing.Point(91, 278);
            this.RegisterAccept.Name = "RegisterAccept";
            this.RegisterAccept.Size = new System.Drawing.Size(184, 44);
            this.RegisterAccept.TabIndex = 5;
            this.RegisterAccept.Text = "Register";
            this.RegisterAccept.UseVisualStyleBackColor = false;
            this.RegisterAccept.Click += new System.EventHandler(this.RegisterAccept_Click);
            // 
            // RegisterCancel
            // 
            this.RegisterCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterCancel.Font = new System.Drawing.Font("Rockwell Extra Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterCancel.ForeColor = System.Drawing.Color.White;
            this.RegisterCancel.Location = new System.Drawing.Point(132, 334);
            this.RegisterCancel.Name = "RegisterCancel";
            this.RegisterCancel.Size = new System.Drawing.Size(104, 32);
            this.RegisterCancel.TabIndex = 6;
            this.RegisterCancel.Text = "Cancel";
            this.RegisterCancel.UseVisualStyleBackColor = false;
            this.RegisterCancel.Click += new System.EventHandler(this.RegisterCancel_Click);
            // 
            // EnterPassword
            // 
            this.EnterPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterPassword.Font = new System.Drawing.Font("Rockwell Extra Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterPassword.ForeColor = System.Drawing.Color.Gray;
            this.EnterPassword.Location = new System.Drawing.Point(16, 125);
            this.EnterPassword.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterPassword.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.Size = new System.Drawing.Size(335, 30);
            this.EnterPassword.TabIndex = 1;
            this.EnterPassword.TabStop = false;
            this.EnterPassword.Text = "Password";
            this.EnterPassword.TextChanged += new System.EventHandler(this.EnterPassword_TextChanged);
            this.EnterPassword.Enter += new System.EventHandler(this.EnterPassword_Enter);
            this.EnterPassword.Leave += new System.EventHandler(this.EnterPassword_Leave);
            // 
            // EnterUsername
            // 
            this.EnterUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterUsername.Font = new System.Drawing.Font("Rockwell Extra Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterUsername.ForeColor = System.Drawing.Color.Gray;
            this.EnterUsername.Location = new System.Drawing.Point(16, 89);
            this.EnterUsername.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterUsername.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterUsername.Name = "EnterUsername";
            this.EnterUsername.Size = new System.Drawing.Size(335, 30);
            this.EnterUsername.TabIndex = 0;
            this.EnterUsername.TabStop = false;
            this.EnterUsername.Text = "Username";
            this.EnterUsername.TextChanged += new System.EventHandler(this.EnterUsername_TextChanged);
            this.EnterUsername.Enter += new System.EventHandler(this.EnterUsername_Enter);
            this.EnterUsername.Leave += new System.EventHandler(this.EnterUsername_Leave);
            // 
            // EmailLabel
            // 
            this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(12, 367);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(96, 23);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Username";
            this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EmailLabel.Visible = false;
            this.EmailLabel.Click += new System.EventHandler(this.EmailLabel_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(17, 367);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(91, 23);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PasswordLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "E-Mail";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // EnterEmail
            // 
            this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterEmail.Font = new System.Drawing.Font("Rockwell Extra Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterEmail.ForeColor = System.Drawing.Color.Gray;
            this.EnterEmail.Location = new System.Drawing.Point(16, 161);
            this.EnterEmail.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterEmail.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterEmail.Name = "EnterEmail";
            this.EnterEmail.Size = new System.Drawing.Size(335, 30);
            this.EnterEmail.TabIndex = 2;
            this.EnterEmail.TabStop = false;
            this.EnterEmail.Text = "Email";
            this.EnterEmail.TextChanged += new System.EventHandler(this.EnterEmail_TextChanged);
            this.EnterEmail.Enter += new System.EventHandler(this.EnterEmail_Enter);
            this.EnterEmail.Leave += new System.EventHandler(this.EnterEmail_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Forename";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // EnterForename
            // 
            this.EnterForename.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterForename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterForename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterForename.Font = new System.Drawing.Font("Rockwell Extra Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterForename.ForeColor = System.Drawing.Color.Gray;
            this.EnterForename.Location = new System.Drawing.Point(17, 197);
            this.EnterForename.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterForename.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterForename.Name = "EnterForename";
            this.EnterForename.Size = new System.Drawing.Size(335, 30);
            this.EnterForename.TabIndex = 3;
            this.EnterForename.TabStop = false;
            this.EnterForename.Text = "Forename";
            this.EnterForename.TextChanged += new System.EventHandler(this.EnterForename_TextChanged);
            this.EnterForename.Enter += new System.EventHandler(this.EnterForename_Enter);
            this.EnterForename.Leave += new System.EventHandler(this.EnterForename_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Rockwell Extra Bold", 25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(95, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 40);
            this.label3.TabIndex = 11;
            this.label3.Text = "Register";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnterSurname
            // 
            this.EnterSurname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterSurname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterSurname.Font = new System.Drawing.Font("Rockwell Extra Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterSurname.ForeColor = System.Drawing.Color.Gray;
            this.EnterSurname.Location = new System.Drawing.Point(17, 233);
            this.EnterSurname.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterSurname.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterSurname.Name = "EnterSurname";
            this.EnterSurname.Size = new System.Drawing.Size(335, 30);
            this.EnterSurname.TabIndex = 4;
            this.EnterSurname.TabStop = false;
            this.EnterSurname.Text = "Surname";
            this.EnterSurname.TextChanged += new System.EventHandler(this.EnterSurname_TextChanged);
            this.EnterSurname.Enter += new System.EventHandler(this.EnterSurname_Enter);
            this.EnterSurname.Leave += new System.EventHandler(this.EnterSurname_Leave);
            // 
            // regRejectLbl
            // 
            this.regRejectLbl.AutoSize = true;
            this.regRejectLbl.BackColor = System.Drawing.Color.Transparent;
            this.regRejectLbl.Font = new System.Drawing.Font("Georgia", 10F);
            this.regRejectLbl.ForeColor = System.Drawing.Color.Red;
            this.regRejectLbl.Location = new System.Drawing.Point(127, 9);
            this.regRejectLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.regRejectLbl.Name = "regRejectLbl";
            this.regRejectLbl.Size = new System.Drawing.Size(148, 17);
            this.regRejectLbl.TabIndex = 12;
            this.regRejectLbl.Text = "Registration Rejected!";
            this.regRejectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.regRejectLbl.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SoftEngChatClient.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(42, 20);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(60, 60);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(60, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // poweredBy
            // 
            this.poweredBy.AutoSize = true;
            this.poweredBy.BackColor = System.Drawing.Color.Transparent;
            this.poweredBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poweredBy.ForeColor = System.Drawing.Color.White;
            this.poweredBy.Location = new System.Drawing.Point(114, 377);
            this.poweredBy.Name = "poweredBy";
            this.poweredBy.Size = new System.Drawing.Size(142, 13);
            this.poweredBy.TabIndex = 14;
            this.poweredBy.Text = "Powered by ClientDriver 1.1";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SoftEngChatClient.Properties.Resources.background7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(363, 399);
            this.Controls.Add(this.poweredBy);
            this.Controls.Add(this.pictureBox1);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Register";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ManChattan - Register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label poweredBy;
    }
}

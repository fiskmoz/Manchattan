namespace Client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.RegisterAccept = new System.Windows.Forms.Button();
            this.RegisterCancel = new System.Windows.Forms.Button();
            this.EnterPassword = new System.Windows.Forms.TextBox();
            this.EnterUsername = new System.Windows.Forms.TextBox();
            this.EnterEmail = new System.Windows.Forms.TextBox();
            this.EnterForename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EnterSurname = new System.Windows.Forms.TextBox();
            this.regRejectLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.poweredBy = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.RegistrationColorIndicatorlbl = new System.Windows.Forms.Label();
            this.RegistrationIndicatorlbl = new System.Windows.Forms.Label();
            this.showPasswordImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPasswordImage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterAccept
            // 
            this.RegisterAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterAccept.BackColor = System.Drawing.Color.AliceBlue;
            this.RegisterAccept.Enabled = false;
            this.RegisterAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.RegisterAccept.ForeColor = System.Drawing.Color.SteelBlue;
            this.RegisterAccept.Location = new System.Drawing.Point(106, 353);
            this.RegisterAccept.Name = "RegisterAccept";
            this.RegisterAccept.Size = new System.Drawing.Size(184, 44);
            this.RegisterAccept.TabIndex = 7;
            this.RegisterAccept.Text = "Register";
            this.RegisterAccept.UseVisualStyleBackColor = false;
            this.RegisterAccept.Click += new System.EventHandler(this.RegisterAccept_Click);
            // 
            // RegisterCancel
            // 
            this.RegisterCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterCancel.ForeColor = System.Drawing.Color.White;
            this.RegisterCancel.Location = new System.Drawing.Point(328, 496);
            this.RegisterCancel.Name = "RegisterCancel";
            this.RegisterCancel.Size = new System.Drawing.Size(76, 32);
            this.RegisterCancel.TabIndex = 1;
            this.RegisterCancel.Text = "Cancel";
            this.RegisterCancel.UseVisualStyleBackColor = false;
            this.RegisterCancel.Click += new System.EventHandler(this.RegisterCancel_Click);
            // 
            // EnterPassword
            // 
            this.EnterPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterPassword.ForeColor = System.Drawing.Color.Gray;
            this.EnterPassword.Location = new System.Drawing.Point(28, 135);
            this.EnterPassword.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterPassword.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.Size = new System.Drawing.Size(335, 29);
            this.EnterPassword.TabIndex = 3;
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
            this.EnterUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterUsername.ForeColor = System.Drawing.Color.Gray;
            this.EnterUsername.Location = new System.Drawing.Point(28, 99);
            this.EnterUsername.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterUsername.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterUsername.Name = "EnterUsername";
            this.EnterUsername.Size = new System.Drawing.Size(335, 29);
            this.EnterUsername.TabIndex = 2;
            this.EnterUsername.Text = "Username";
            this.EnterUsername.TextChanged += new System.EventHandler(this.EnterUsername_TextChanged);
            this.EnterUsername.Enter += new System.EventHandler(this.EnterUsername_Enter);
            this.EnterUsername.Leave += new System.EventHandler(this.EnterUsername_Leave);
            // 
            // EnterEmail
            // 
            this.EnterEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterEmail.ForeColor = System.Drawing.Color.Gray;
            this.EnterEmail.Location = new System.Drawing.Point(28, 208);
            this.EnterEmail.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterEmail.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterEmail.Name = "EnterEmail";
            this.EnterEmail.Size = new System.Drawing.Size(335, 29);
            this.EnterEmail.TabIndex = 4;
            this.EnterEmail.Text = "Email";
            this.EnterEmail.TextChanged += new System.EventHandler(this.EnterEmail_TextChanged);
            this.EnterEmail.Enter += new System.EventHandler(this.EnterEmail_Enter);
            this.EnterEmail.Leave += new System.EventHandler(this.EnterEmail_Leave);
            // 
            // EnterForename
            // 
            this.EnterForename.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterForename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterForename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterForename.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterForename.ForeColor = System.Drawing.Color.Gray;
            this.EnterForename.Location = new System.Drawing.Point(29, 243);
            this.EnterForename.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterForename.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterForename.Name = "EnterForename";
            this.EnterForename.Size = new System.Drawing.Size(335, 29);
            this.EnterForename.TabIndex = 5;
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
            this.label3.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(121, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 40);
            this.label3.TabIndex = 11;
            this.label3.Text = "Register";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnterSurname
            // 
            this.EnterSurname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterSurname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterSurname.ForeColor = System.Drawing.Color.Gray;
            this.EnterSurname.Location = new System.Drawing.Point(29, 278);
            this.EnterSurname.MaximumSize = new System.Drawing.Size(335, 50);
            this.EnterSurname.MinimumSize = new System.Drawing.Size(335, 30);
            this.EnterSurname.Name = "EnterSurname";
            this.EnterSurname.Size = new System.Drawing.Size(335, 29);
            this.EnterSurname.TabIndex = 6;
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
            this.regRejectLbl.Location = new System.Drawing.Point(125, 10);
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
            this.pictureBox1.Image = global::Client.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(13, 493);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(60, 60);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(40, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
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
            this.poweredBy.Location = new System.Drawing.Point(137, 507);
            this.poweredBy.Name = "poweredBy";
            this.poweredBy.Size = new System.Drawing.Size(142, 13);
            this.poweredBy.TabIndex = 14;
            this.poweredBy.Text = "Powered by ClientDriver 1.1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // RegistrationColorIndicatorlbl
            // 
            this.RegistrationColorIndicatorlbl.AutoSize = true;
            this.RegistrationColorIndicatorlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegistrationColorIndicatorlbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistrationColorIndicatorlbl.Location = new System.Drawing.Point(28, 163);
            this.RegistrationColorIndicatorlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RegistrationColorIndicatorlbl.MinimumSize = new System.Drawing.Size(33, 13);
            this.RegistrationColorIndicatorlbl.Name = "RegistrationColorIndicatorlbl";
            this.RegistrationColorIndicatorlbl.Size = new System.Drawing.Size(33, 15);
            this.RegistrationColorIndicatorlbl.TabIndex = 15;
            this.RegistrationColorIndicatorlbl.Visible = false;
            // 
            // RegistrationIndicatorlbl
            // 
            this.RegistrationIndicatorlbl.AutoSize = true;
            this.RegistrationIndicatorlbl.BackColor = System.Drawing.Color.Transparent;
            this.RegistrationIndicatorlbl.Location = new System.Drawing.Point(38, 213);
            this.RegistrationIndicatorlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RegistrationIndicatorlbl.Name = "RegistrationIndicatorlbl";
            this.RegistrationIndicatorlbl.Size = new System.Drawing.Size(0, 13);
            this.RegistrationIndicatorlbl.TabIndex = 16;
            this.RegistrationIndicatorlbl.Visible = false;
            // 
            // showPasswordImage
            // 
            this.showPasswordImage.BackColor = System.Drawing.Color.Transparent;
            this.showPasswordImage.Image = global::Client.Properties.Resources.showPassword;
            this.showPasswordImage.Location = new System.Drawing.Point(366, 139);
            this.showPasswordImage.Margin = new System.Windows.Forms.Padding(2);
            this.showPasswordImage.Name = "showPasswordImage";
            this.showPasswordImage.Size = new System.Drawing.Size(22, 22);
            this.showPasswordImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showPasswordImage.TabIndex = 17;
            this.showPasswordImage.TabStop = false;
            this.showPasswordImage.Click += new System.EventHandler(this.showPasswordImage_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.RegisterAccept);
            this.panel1.Controls.Add(this.showPasswordImage);
            this.panel1.Controls.Add(this.EnterEmail);
            this.panel1.Controls.Add(this.RegistrationColorIndicatorlbl);
            this.panel1.Controls.Add(this.regRejectLbl);
            this.panel1.Controls.Add(this.EnterPassword);
            this.panel1.Controls.Add(this.EnterUsername);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.EnterForename);
            this.panel1.Controls.Add(this.EnterSurname);
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 418);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Location = new System.Drawing.Point(45, 329);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 2);
            this.panel2.TabIndex = 25;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SteelBlue;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel6.Location = new System.Drawing.Point(45, 74);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(300, 2);
            this.panel6.TabIndex = 24;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(29, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(176, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Client.Properties.Resources.background7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(416, 535);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RegistrationIndicatorlbl);
            this.Controls.Add(this.poweredBy);
            this.Controls.Add(this.RegisterCancel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(198, 246);
            this.Name = "Register";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManChattan - Register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPasswordImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterAccept;
        private System.Windows.Forms.Button RegisterCancel;
        private System.Windows.Forms.TextBox EnterPassword;
        private System.Windows.Forms.TextBox EnterUsername;
        private System.Windows.Forms.TextBox EnterEmail;
        private System.Windows.Forms.TextBox EnterForename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EnterSurname;
		private System.Windows.Forms.Label regRejectLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label poweredBy;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label RegistrationColorIndicatorlbl;
        private System.Windows.Forms.Label RegistrationIndicatorlbl;
        private System.Windows.Forms.PictureBox showPasswordImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

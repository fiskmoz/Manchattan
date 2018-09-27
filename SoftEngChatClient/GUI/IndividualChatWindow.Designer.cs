namespace SoftEngChatClient
{
    partial class IndividualChatWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividualChatWindow));
            this.IndividualChatBox = new System.Windows.Forms.TextBox();
            this.IndividualMessageBox = new System.Windows.Forms.TextBox();
            this.IndividualSendButton = new System.Windows.Forms.Button();
            this.YouAreChattingWith = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IndividualChatBox
            // 
            this.IndividualChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IndividualChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndividualChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.IndividualChatBox.ForeColor = System.Drawing.Color.White;
            this.IndividualChatBox.Location = new System.Drawing.Point(14, 47);
            this.IndividualChatBox.Multiline = true;
            this.IndividualChatBox.Name = "IndividualChatBox";
            this.IndividualChatBox.ReadOnly = true;
            this.IndividualChatBox.Size = new System.Drawing.Size(488, 255);
            this.IndividualChatBox.TabIndex = 0;
            // 
            // IndividualMessageBox
            // 
            this.IndividualMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IndividualMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndividualMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.IndividualMessageBox.ForeColor = System.Drawing.Color.White;
            this.IndividualMessageBox.Location = new System.Drawing.Point(14, 308);
            this.IndividualMessageBox.Multiline = true;
            this.IndividualMessageBox.Name = "IndividualMessageBox";
            this.IndividualMessageBox.Size = new System.Drawing.Size(396, 91);
            this.IndividualMessageBox.TabIndex = 1;
            this.IndividualMessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IndividualMessageBox_KeyUp);
            // 
            // IndividualSendButton
            // 
            this.IndividualSendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IndividualSendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IndividualSendButton.Font = new System.Drawing.Font("Rockwell Extra Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualSendButton.ForeColor = System.Drawing.Color.White;
            this.IndividualSendButton.Location = new System.Drawing.Point(416, 308);
            this.IndividualSendButton.Name = "IndividualSendButton";
            this.IndividualSendButton.Size = new System.Drawing.Size(86, 91);
            this.IndividualSendButton.TabIndex = 2;
            this.IndividualSendButton.Text = "Send";
            this.IndividualSendButton.UseVisualStyleBackColor = false;
            this.IndividualSendButton.Click += new System.EventHandler(this.IndividualSendButton_Click);
            // 
            // YouAreChattingWith
            // 
            this.YouAreChattingWith.AutoSize = true;
            this.YouAreChattingWith.BackColor = System.Drawing.Color.Transparent;
            this.YouAreChattingWith.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold);
            this.YouAreChattingWith.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.YouAreChattingWith.Location = new System.Drawing.Point(5, 15);
            this.YouAreChattingWith.Name = "YouAreChattingWith";
            this.YouAreChattingWith.Size = new System.Drawing.Size(226, 19);
            this.YouAreChattingWith.TabIndex = 3;
            this.YouAreChattingWith.Text = "You are chatting with: ";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.UsernameLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.UsernameLabel.Location = new System.Drawing.Point(227, 12);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(124, 22);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::SoftEngChatClient.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(456, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // IndividualChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::SoftEngChatClient.Properties.Resources.background7;
            this.ClientSize = new System.Drawing.Size(516, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.YouAreChattingWith);
            this.Controls.Add(this.IndividualSendButton);
            this.Controls.Add(this.IndividualMessageBox);
            this.Controls.Add(this.IndividualChatBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IndividualChatWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ManChattan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndividualChatWindow_FormClosing);
            this.Load += new System.EventHandler(this.IndividualChatWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IndividualChatBox;
        private System.Windows.Forms.TextBox IndividualMessageBox;
        private System.Windows.Forms.Button IndividualSendButton;
        private System.Windows.Forms.Label YouAreChattingWith;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
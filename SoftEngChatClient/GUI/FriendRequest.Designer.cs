namespace SoftEngChatClient.GUI
{
    partial class FriendRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendRequest));
            this.label1 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FriendRequestsBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(84, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Friend request from:";
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.acceptButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.acceptButton.Location = new System.Drawing.Point(405, 50);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(96, 33);
            this.acceptButton.TabIndex = 2;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // rejectButton
            // 
            this.rejectButton.BackColor = System.Drawing.Color.White;
            this.rejectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rejectButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectButton.ForeColor = System.Drawing.Color.DarkRed;
            this.rejectButton.Location = new System.Drawing.Point(421, 89);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(61, 22);
            this.rejectButton.TabIndex = 3;
            this.rejectButton.Text = "Reject";
            this.rejectButton.UseVisualStyleBackColor = false;
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FriendRequestsBox
            // 
            this.FriendRequestsBox.BackColor = System.Drawing.SystemColors.Window;
            this.FriendRequestsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FriendRequestsBox.FormattingEnabled = true;
            this.FriendRequestsBox.ItemHeight = 24;
            this.FriendRequestsBox.Location = new System.Drawing.Point(88, 37);
            this.FriendRequestsBox.Name = "FriendRequestsBox";
            this.FriendRequestsBox.Size = new System.Drawing.Size(286, 100);
            this.FriendRequestsBox.TabIndex = 5;
            // 
            // FriendRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(551, 155);
            this.Controls.Add(this.FriendRequestsBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Cyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FriendRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incoming Friend Request";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox FriendRequestsBox;
    }
}
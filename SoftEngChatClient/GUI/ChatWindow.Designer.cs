﻿using System.Windows.Forms;

namespace SoftEngChatClient
{
    partial class ChatWindow
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
			this.MessageBox = new System.Windows.Forms.TextBox();
			this.SendButton = new System.Windows.Forms.Button();
			this.ActiveChatPlaceholder = new System.Windows.Forms.GroupBox();
			this.ProfilePlaceholder = new System.Windows.Forms.GroupBox();
			this.ConctactsPlaceholder = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.ChatBox = new System.Windows.Forms.TextBox();
			this.Toolbar = new System.Windows.Forms.GroupBox();
			this.PreviousMessagesButton = new System.Windows.Forms.Button();
			this.userNameLbl = new System.Windows.Forms.Label();
			this.logoutBtn = new System.Windows.Forms.Button();
			this.ActiveChatPlaceholder.SuspendLayout();
			this.ConctactsPlaceholder.SuspendLayout();
			this.SuspendLayout();
			// 
			// MessageBox
			// 
			this.MessageBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MessageBox.Location = new System.Drawing.Point(243, 423);
			this.MessageBox.Margin = new System.Windows.Forms.Padding(4);
			this.MessageBox.Multiline = true;
			this.MessageBox.Name = "MessageBox";
			this.MessageBox.Size = new System.Drawing.Size(435, 67);
			this.MessageBox.TabIndex = 0;
			this.MessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyUp);
			// 
			// SendButton
			// 
			this.SendButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.SendButton.Location = new System.Drawing.Point(687, 423);
			this.SendButton.Margin = new System.Windows.Forms.Padding(4);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size(104, 68);
			this.SendButton.TabIndex = 1;
			this.SendButton.Text = "Send";
			this.SendButton.UseVisualStyleBackColor = true;
			this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
			// 
			// ActiveChatPlaceholder
			// 
			this.ActiveChatPlaceholder.Controls.Add(this.ProfilePlaceholder);
			this.ActiveChatPlaceholder.Location = new System.Drawing.Point(16, 116);
			this.ActiveChatPlaceholder.Margin = new System.Windows.Forms.Padding(4);
			this.ActiveChatPlaceholder.Name = "ActiveChatPlaceholder";
			this.ActiveChatPlaceholder.Padding = new System.Windows.Forms.Padding(4);
			this.ActiveChatPlaceholder.Size = new System.Drawing.Size(193, 361);
			this.ActiveChatPlaceholder.TabIndex = 2;
			this.ActiveChatPlaceholder.TabStop = false;
			this.ActiveChatPlaceholder.Text = "Active Chats";
			// 
			// ProfilePlaceholder
			// 
			this.ProfilePlaceholder.Location = new System.Drawing.Point(8, 23);
			this.ProfilePlaceholder.Margin = new System.Windows.Forms.Padding(4);
			this.ProfilePlaceholder.Name = "ProfilePlaceholder";
			this.ProfilePlaceholder.Padding = new System.Windows.Forms.Padding(4);
			this.ProfilePlaceholder.Size = new System.Drawing.Size(177, 105);
			this.ProfilePlaceholder.TabIndex = 3;
			this.ProfilePlaceholder.TabStop = false;
			this.ProfilePlaceholder.Text = "Profile";
			// 
			// ConctactsPlaceholder
			// 
			this.ConctactsPlaceholder.Controls.Add(this.listBox1);
			this.ConctactsPlaceholder.Location = new System.Drawing.Point(829, 16);
			this.ConctactsPlaceholder.Margin = new System.Windows.Forms.Padding(4);
			this.ConctactsPlaceholder.Name = "ConctactsPlaceholder";
			this.ConctactsPlaceholder.Padding = new System.Windows.Forms.Padding(4);
			this.ConctactsPlaceholder.Size = new System.Drawing.Size(200, 475);
			this.ConctactsPlaceholder.TabIndex = 3;
			this.ConctactsPlaceholder.TabStop = false;
			this.ConctactsPlaceholder.Text = "Conctacts";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(0, 22);
			this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(200, 452);
			this.listBox1.TabIndex = 0;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// ChatBox
			// 
			this.ChatBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ChatBox.Location = new System.Drawing.Point(243, 38);
			this.ChatBox.Margin = new System.Windows.Forms.Padding(4);
			this.ChatBox.Multiline = true;
			this.ChatBox.Name = "ChatBox";
			this.ChatBox.ReadOnly = true;
			this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ChatBox.Size = new System.Drawing.Size(547, 333);
			this.ChatBox.TabIndex = 4;
			// 
			// Toolbar
			// 
			this.Toolbar.Location = new System.Drawing.Point(243, 380);
			this.Toolbar.Margin = new System.Windows.Forms.Padding(4);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Padding = new System.Windows.Forms.Padding(4);
			this.Toolbar.Size = new System.Drawing.Size(548, 36);
			this.Toolbar.TabIndex = 5;
			this.Toolbar.TabStop = false;
			this.Toolbar.Text = "Toolbar";
			// 
			// PreviousMessagesButton
			// 
			this.PreviousMessagesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.PreviousMessagesButton.Location = new System.Drawing.Point(243, 6);
			this.PreviousMessagesButton.Margin = new System.Windows.Forms.Padding(4);
			this.PreviousMessagesButton.Name = "PreviousMessagesButton";
			this.PreviousMessagesButton.Size = new System.Drawing.Size(185, 25);
			this.PreviousMessagesButton.TabIndex = 6;
			this.PreviousMessagesButton.Text = "View previous messages";
			this.PreviousMessagesButton.UseVisualStyleBackColor = true;
			this.PreviousMessagesButton.Click += new System.EventHandler(this.PreviousMessagesButton_Click);
			// 
			// userNameLbl
			// 
			this.userNameLbl.AutoSize = true;
			this.userNameLbl.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userNameLbl.Location = new System.Drawing.Point(24, 38);
			this.userNameLbl.Name = "userNameLbl";
			this.userNameLbl.Size = new System.Drawing.Size(168, 32);
			this.userNameLbl.TabIndex = 7;
			this.userNameLbl.Text = "UserName";
			// 
			// logoutBtn
			// 
			this.logoutBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.logoutBtn.FlatAppearance.BorderSize = 0;
			this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.logoutBtn.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logoutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.logoutBtn.Location = new System.Drawing.Point(63, 64);
			this.logoutBtn.Name = "logoutBtn";
			this.logoutBtn.Size = new System.Drawing.Size(87, 36);
			this.logoutBtn.TabIndex = 100;
			this.logoutBtn.Text = "Logout";
			this.logoutBtn.UseVisualStyleBackColor = false;
			this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
			// 
			// ChatWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1045, 506);
			this.Controls.Add(this.logoutBtn);
			this.Controls.Add(this.userNameLbl);
			this.Controls.Add(this.PreviousMessagesButton);
			this.Controls.Add(this.Toolbar);
			this.Controls.Add(this.ConctactsPlaceholder);
			this.Controls.Add(this.ActiveChatPlaceholder);
			this.Controls.Add(this.SendButton);
			this.Controls.Add(this.MessageBox);
			this.Controls.Add(this.ChatBox);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ChatWindow";
			this.Text = "ChatWindow";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatWindow_FormClosed);
			this.Load += new System.EventHandler(this.ChatWindow_Load);
			this.ActiveChatPlaceholder.ResumeLayout(false);
			this.ConctactsPlaceholder.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.GroupBox ActiveChatPlaceholder;
        private System.Windows.Forms.GroupBox ProfilePlaceholder;
        private System.Windows.Forms.GroupBox ConctactsPlaceholder;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.GroupBox Toolbar;
        private System.Windows.Forms.Button PreviousMessagesButton;
        public ListBox listBox1;
		private Label userNameLbl;
		private Button logoutBtn;
	}
}

using System.Windows.Forms;

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
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.Toolbar = new System.Windows.Forms.GroupBox();
            this.PreviousMessagesButton = new System.Windows.Forms.Button();
            this.ActiveChatPlaceholder.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox.Location = new System.Drawing.Point(182, 344);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(327, 55);
            this.MessageBox.TabIndex = 0;
            this.MessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyUp);
            // 
            // SendButton
            // 
            this.SendButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SendButton.Location = new System.Drawing.Point(515, 344);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(78, 55);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ActiveChatPlaceholder
            // 
            this.ActiveChatPlaceholder.Controls.Add(this.ProfilePlaceholder);
            this.ActiveChatPlaceholder.Location = new System.Drawing.Point(12, 12);
            this.ActiveChatPlaceholder.Name = "ActiveChatPlaceholder";
            this.ActiveChatPlaceholder.Size = new System.Drawing.Size(145, 375);
            this.ActiveChatPlaceholder.TabIndex = 2;
            this.ActiveChatPlaceholder.TabStop = false;
            this.ActiveChatPlaceholder.Text = "Active Chats";
            // 
            // ProfilePlaceholder
            // 
            this.ProfilePlaceholder.Location = new System.Drawing.Point(6, 19);
            this.ProfilePlaceholder.Name = "ProfilePlaceholder";
            this.ProfilePlaceholder.Size = new System.Drawing.Size(133, 85);
            this.ProfilePlaceholder.TabIndex = 3;
            this.ProfilePlaceholder.TabStop = false;
            this.ProfilePlaceholder.Text = "Profile";
            // 
            // ConctactsPlaceholder
            // 
            this.ConctactsPlaceholder.Location = new System.Drawing.Point(622, 13);
            this.ConctactsPlaceholder.Name = "ConctactsPlaceholder";
            this.ConctactsPlaceholder.Size = new System.Drawing.Size(150, 386);
            this.ConctactsPlaceholder.TabIndex = 3;
            this.ConctactsPlaceholder.TabStop = false;
            this.ConctactsPlaceholder.Text = "Conctacts";
            // 
            // ChatBox
            // 
            this.ChatBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChatBox.Location = new System.Drawing.Point(182, 31);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(411, 271);
            this.ChatBox.TabIndex = 4;
            // 
            // Toolbar
            // 
            this.Toolbar.Location = new System.Drawing.Point(182, 309);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(411, 29);
            this.Toolbar.TabIndex = 5;
            this.Toolbar.TabStop = false;
            this.Toolbar.Text = "Toolbar";
            // 
            // PreviousMessagesButton
            // 
            this.PreviousMessagesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PreviousMessagesButton.Location = new System.Drawing.Point(182, 5);
            this.PreviousMessagesButton.Name = "PreviousMessagesButton";
            this.PreviousMessagesButton.Size = new System.Drawing.Size(139, 20);
            this.PreviousMessagesButton.TabIndex = 6;
            this.PreviousMessagesButton.Text = "View previous messages";
            this.PreviousMessagesButton.UseVisualStyleBackColor = true;
            this.PreviousMessagesButton.Click += new System.EventHandler(this.PreviousMessagesButton_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.PreviousMessagesButton);
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.ConctactsPlaceholder);
            this.Controls.Add(this.ActiveChatPlaceholder);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ChatBox);
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatWindow_FormClosed);
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.ActiveChatPlaceholder.ResumeLayout(false);
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
    }
}

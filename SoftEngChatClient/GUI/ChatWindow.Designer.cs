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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ActiveChatPlaceholder.SuspendLayout();
            this.ConctactsPlaceholder.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox.Location = new System.Drawing.Point(273, 529);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(488, 82);
            this.MessageBox.TabIndex = 0;
            this.MessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyUp);
            // 
            // SendButton
            // 
            this.SendButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SendButton.Location = new System.Drawing.Point(772, 529);
            this.SendButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(117, 85);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ActiveChatPlaceholder
            // 
            this.ActiveChatPlaceholder.Controls.Add(this.ProfilePlaceholder);
            this.ActiveChatPlaceholder.Location = new System.Drawing.Point(18, 18);
            this.ActiveChatPlaceholder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ActiveChatPlaceholder.Name = "ActiveChatPlaceholder";
            this.ActiveChatPlaceholder.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ActiveChatPlaceholder.Size = new System.Drawing.Size(218, 577);
            this.ActiveChatPlaceholder.TabIndex = 2;
            this.ActiveChatPlaceholder.TabStop = false;
            this.ActiveChatPlaceholder.Text = "Active Chats";
            // 
            // ProfilePlaceholder
            // 
            this.ProfilePlaceholder.Location = new System.Drawing.Point(9, 29);
            this.ProfilePlaceholder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProfilePlaceholder.Name = "ProfilePlaceholder";
            this.ProfilePlaceholder.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProfilePlaceholder.Size = new System.Drawing.Size(200, 131);
            this.ProfilePlaceholder.TabIndex = 3;
            this.ProfilePlaceholder.TabStop = false;
            this.ProfilePlaceholder.Text = "Profile";
            // 
            // ConctactsPlaceholder
            // 
            this.ConctactsPlaceholder.Controls.Add(this.listBox1);
            this.ConctactsPlaceholder.Location = new System.Drawing.Point(933, 20);
            this.ConctactsPlaceholder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConctactsPlaceholder.Name = "ConctactsPlaceholder";
            this.ConctactsPlaceholder.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConctactsPlaceholder.Size = new System.Drawing.Size(225, 594);
            this.ConctactsPlaceholder.TabIndex = 3;
            this.ConctactsPlaceholder.TabStop = false;
            this.ConctactsPlaceholder.Text = "Conctacts";
            // 
            // ChatBox
            // 
            this.ChatBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChatBox.Location = new System.Drawing.Point(273, 48);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(614, 415);
            this.ChatBox.TabIndex = 4;
            // 
            // Toolbar
            // 
            this.Toolbar.Location = new System.Drawing.Point(273, 475);
            this.Toolbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Toolbar.Size = new System.Drawing.Size(616, 45);
            this.Toolbar.TabIndex = 5;
            this.Toolbar.TabStop = false;
            this.Toolbar.Text = "Toolbar";
            // 
            // PreviousMessagesButton
            // 
            this.PreviousMessagesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PreviousMessagesButton.Location = new System.Drawing.Point(273, 8);
            this.PreviousMessagesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PreviousMessagesButton.Name = "PreviousMessagesButton";
            this.PreviousMessagesButton.Size = new System.Drawing.Size(208, 31);
            this.PreviousMessagesButton.TabIndex = 6;
            this.PreviousMessagesButton.Text = "View previous messages";
            this.PreviousMessagesButton.UseVisualStyleBackColor = true;
            this.PreviousMessagesButton.Click += new System.EventHandler(this.PreviousMessagesButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Nicklas",
            "Anders"});
            this.listBox1.Location = new System.Drawing.Point(0, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 564);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 632);
            this.Controls.Add(this.PreviousMessagesButton);
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.ConctactsPlaceholder);
            this.Controls.Add(this.ActiveChatPlaceholder);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ChatBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}

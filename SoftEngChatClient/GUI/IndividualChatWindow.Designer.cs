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
            this.IndividualChatBox = new System.Windows.Forms.TextBox();
            this.IndividualMessageBox = new System.Windows.Forms.TextBox();
            this.IndividualSendButton = new System.Windows.Forms.Button();
            this.YouAreChattingWith = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IndividualChatBox
            // 
            this.IndividualChatBox.Location = new System.Drawing.Point(66, 60);
            this.IndividualChatBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IndividualChatBox.Multiline = true;
            this.IndividualChatBox.Name = "IndividualChatBox";
            this.IndividualChatBox.Size = new System.Drawing.Size(422, 346);
            this.IndividualChatBox.TabIndex = 0;
            // 
            // IndividualMessageBox
            // 
            this.IndividualMessageBox.Location = new System.Drawing.Point(66, 457);
            this.IndividualMessageBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IndividualMessageBox.Multiline = true;
            this.IndividualMessageBox.Name = "IndividualMessageBox";
            this.IndividualMessageBox.Size = new System.Drawing.Size(308, 76);
            this.IndividualMessageBox.TabIndex = 1;
            this.IndividualMessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IndividualMessageBox_KeyUp);
            // 
            // IndividualSendButton
            // 
            this.IndividualSendButton.Location = new System.Drawing.Point(386, 457);
            this.IndividualSendButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IndividualSendButton.Name = "IndividualSendButton";
            this.IndividualSendButton.Size = new System.Drawing.Size(104, 78);
            this.IndividualSendButton.TabIndex = 2;
            this.IndividualSendButton.Text = "Send";
            this.IndividualSendButton.UseVisualStyleBackColor = true;
            this.IndividualSendButton.Click += new System.EventHandler(this.IndividualSendButton_Click);
            // 
            // YouAreChattingWith
            // 
            this.YouAreChattingWith.AutoSize = true;
            this.YouAreChattingWith.Location = new System.Drawing.Point(66, 20);
            this.YouAreChattingWith.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YouAreChattingWith.Name = "YouAreChattingWith";
            this.YouAreChattingWith.Size = new System.Drawing.Size(166, 20);
            this.YouAreChattingWith.TabIndex = 3;
            this.YouAreChattingWith.Text = "You are chatting with: ";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(244, 20);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(83, 20);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // IndividualChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 554);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.YouAreChattingWith);
            this.Controls.Add(this.IndividualSendButton);
            this.Controls.Add(this.IndividualMessageBox);
            this.Controls.Add(this.IndividualChatBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IndividualChatWindow";
            this.Text = "IndividualChatWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IndividualChatWindow_FormClosed);
            this.Load += new System.EventHandler(this.IndividualChatWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IndividualChatBox;
        private System.Windows.Forms.TextBox IndividualMessageBox;
        private System.Windows.Forms.Button IndividualSendButton;
        private System.Windows.Forms.Label YouAreChattingWith;
        private System.Windows.Forms.Label UsernameLabel;
    }
}
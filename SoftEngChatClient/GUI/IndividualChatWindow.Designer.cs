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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.poweredBy = new System.Windows.Forms.Label();
            this.IndividualSendButton = new System.Windows.Forms.PictureBox();
            this.msgTextBoxPanel = new System.Windows.Forms.Panel();
            this.emojiPanel = new System.Windows.Forms.Panel();
            this.emojiLogoBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.viewMsgTextBoxPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.emojiLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndividualSendButton)).BeginInit();
            this.msgTextBoxPanel.SuspendLayout();
            this.emojiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emojiLogoBox)).BeginInit();
            this.viewMsgTextBoxPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IndividualChatBox
            // 
            this.IndividualChatBox.BackColor = System.Drawing.Color.AliceBlue;
            this.IndividualChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IndividualChatBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.IndividualChatBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualChatBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IndividualChatBox.Location = new System.Drawing.Point(29, 0);
            this.IndividualChatBox.Multiline = true;
            this.IndividualChatBox.Name = "IndividualChatBox";
            this.IndividualChatBox.ReadOnly = true;
            this.IndividualChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.IndividualChatBox.Size = new System.Drawing.Size(562, 358);
            this.IndividualChatBox.TabIndex = 0;
            // 
            // IndividualMessageBox
            // 
            this.IndividualMessageBox.BackColor = System.Drawing.Color.AliceBlue;
            this.IndividualMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IndividualMessageBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndividualMessageBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IndividualMessageBox.Location = new System.Drawing.Point(29, 47);
            this.IndividualMessageBox.Multiline = true;
            this.IndividualMessageBox.Name = "IndividualMessageBox";
            this.IndividualMessageBox.Size = new System.Drawing.Size(466, 41);
            this.IndividualMessageBox.TabIndex = 1;
            this.IndividualMessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IndividualMessageBox_KeyUp);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.UsernameLabel.ForeColor = System.Drawing.Color.AliceBlue;
            this.UsernameLabel.Location = new System.Drawing.Point(107, 21);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(105, 24);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::SoftEngChatClient.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // poweredBy
            // 
            this.poweredBy.AutoSize = true;
            this.poweredBy.BackColor = System.Drawing.Color.Transparent;
            this.poweredBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poweredBy.ForeColor = System.Drawing.Color.Black;
            this.poweredBy.Location = new System.Drawing.Point(167, 544);
            this.poweredBy.Name = "poweredBy";
            this.poweredBy.Size = new System.Drawing.Size(238, 13);
            this.poweredBy.TabIndex = 15;
            this.poweredBy.Text = "ManChattan 2018 - Powered by ClientDriver 1.1";
            this.poweredBy.Click += new System.EventHandler(this.poweredBy_Click);
            // 
            // IndividualSendButton
            // 
            this.IndividualSendButton.BackColor = System.Drawing.Color.Transparent;
            this.IndividualSendButton.Image = ((System.Drawing.Image)(resources.GetObject("IndividualSendButton.Image")));
            this.IndividualSendButton.Location = new System.Drawing.Point(516, 30);
            this.IndividualSendButton.Name = "IndividualSendButton";
            this.IndividualSendButton.Size = new System.Drawing.Size(68, 68);
            this.IndividualSendButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IndividualSendButton.TabIndex = 16;
            this.IndividualSendButton.TabStop = false;
            this.IndividualSendButton.Click += new System.EventHandler(this.IndividualSendButton_Click);
            this.IndividualSendButton.MouseLeave += new System.EventHandler(this.IndividualSendButton_MouseLeave);
            this.IndividualSendButton.MouseHover += new System.EventHandler(this.IndividualSendButton_MouseHover);
            // 
            // msgTextBoxPanel
            // 
            this.msgTextBoxPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.msgTextBoxPanel.Controls.Add(this.emojiPanel);
            this.msgTextBoxPanel.Controls.Add(this.label2);
            this.msgTextBoxPanel.Controls.Add(this.IndividualMessageBox);
            this.msgTextBoxPanel.Controls.Add(this.IndividualSendButton);
            this.msgTextBoxPanel.Location = new System.Drawing.Point(-8, 421);
            this.msgTextBoxPanel.Name = "msgTextBoxPanel";
            this.msgTextBoxPanel.Size = new System.Drawing.Size(602, 116);
            this.msgTextBoxPanel.TabIndex = 17;
            // 
            // emojiPanel
            // 
            this.emojiPanel.BackColor = System.Drawing.Color.Transparent;
            this.emojiPanel.Controls.Add(this.emojiLabel);
            this.emojiPanel.Controls.Add(this.emojiLogoBox);
            this.emojiPanel.Location = new System.Drawing.Point(17, 11);
            this.emojiPanel.Name = "emojiPanel";
            this.emojiPanel.Size = new System.Drawing.Size(30, 30);
            this.emojiPanel.TabIndex = 22;
            // 
            // emojiLogoBox
            // 
            this.emojiLogoBox.BackColor = System.Drawing.Color.Transparent;
            this.emojiLogoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.emojiLogoBox.Image = global::SoftEngChatClient.Properties.Resources.logo1;
            this.emojiLogoBox.Location = new System.Drawing.Point(0, 0);
            this.emojiLogoBox.Name = "emojiLogoBox";
            this.emojiLogoBox.Size = new System.Drawing.Size(30, 30);
            this.emojiLogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.emojiLogoBox.TabIndex = 6;
            this.emojiLogoBox.TabStop = false;
            this.emojiLogoBox.MouseLeave += new System.EventHandler(this.emojiLogoBox_MouseLeave);
            this.emojiLogoBox.MouseHover += new System.EventHandler(this.emojiLogoBox_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(16, -5);
            this.label2.MinimumSize = new System.Drawing.Size(550, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(571, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "_________________________________________________________________________________" +
    "_____________";
            // 
            // viewMsgTextBoxPanel
            // 
            this.viewMsgTextBoxPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.viewMsgTextBoxPanel.Controls.Add(this.IndividualChatBox);
            this.viewMsgTextBoxPanel.Location = new System.Drawing.Point(-8, 92);
            this.viewMsgTextBoxPanel.Name = "viewMsgTextBoxPanel";
            this.viewMsgTextBoxPanel.Size = new System.Drawing.Size(602, 449);
            this.viewMsgTextBoxPanel.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.UsernameLabel);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 89);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BackgroundImage = global::SoftEngChatClient.Properties.Resources.Background5;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Location = new System.Drawing.Point(-5, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 11);
            this.panel2.TabIndex = 20;
            // 
            // emojiLabel
            // 
            this.emojiLabel.AutoSize = true;
            this.emojiLabel.BackColor = System.Drawing.Color.Transparent;
            this.emojiLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emojiLabel.ForeColor = System.Drawing.Color.Snow;
            this.emojiLabel.Location = new System.Drawing.Point(34, 5);
            this.emojiLabel.Name = "emojiLabel";
            this.emojiLabel.Size = new System.Drawing.Size(106, 19);
            this.emojiLabel.TabIndex = 7;
            this.emojiLabel.Text = "ManChaticons";
            // 
            // IndividualChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::SoftEngChatClient.Properties.Resources.Background5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.poweredBy);
            this.Controls.Add(this.msgTextBoxPanel);
            this.Controls.Add(this.viewMsgTextBoxPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IndividualChatWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ManChattan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndividualChatWindow_FormClosing);
            this.Load += new System.EventHandler(this.IndividualChatWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndividualSendButton)).EndInit();
            this.msgTextBoxPanel.ResumeLayout(false);
            this.msgTextBoxPanel.PerformLayout();
            this.emojiPanel.ResumeLayout(false);
            this.emojiPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emojiLogoBox)).EndInit();
            this.viewMsgTextBoxPanel.ResumeLayout(false);
            this.viewMsgTextBoxPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox IndividualChatBox;
        private System.Windows.Forms.TextBox IndividualMessageBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label poweredBy;
        private System.Windows.Forms.PictureBox IndividualSendButton;
        private System.Windows.Forms.Panel msgTextBoxPanel;
        private System.Windows.Forms.Panel viewMsgTextBoxPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel emojiPanel;
        private System.Windows.Forms.PictureBox emojiLogoBox;
        private System.Windows.Forms.Label emojiLabel;
    }
}
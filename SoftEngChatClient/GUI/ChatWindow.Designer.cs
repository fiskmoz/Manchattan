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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.contactListBox = new System.Windows.Forms.ListBox();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.PreviousMessagesButton = new System.Windows.Forms.Button();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.poweredBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox.ForeColor = System.Drawing.Color.White;
            this.MessageBox.Location = new System.Drawing.Point(260, 431);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(390, 79);
            this.MessageBox.TabIndex = 0;
            this.MessageBox.TextChanged += new System.EventHandler(this.MessageBox_TextChanged);
            this.MessageBox.Enter += new System.EventHandler(this.MessageBox_Enter);
            this.MessageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyUp);
            // 
            // SendButton
            // 
            this.SendButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendButton.Enabled = false;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.SendButton.ForeColor = System.Drawing.Color.White;
            this.SendButton.Location = new System.Drawing.Point(656, 431);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(104, 79);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // listBox1
            // 
            this.contactListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.contactListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.contactListBox.ForeColor = System.Drawing.Color.White;
            this.contactListBox.FormattingEnabled = true;
            this.contactListBox.ItemHeight = 24;
            this.contactListBox.Location = new System.Drawing.Point(2, 34);
            this.contactListBox.Margin = new System.Windows.Forms.Padding(2);
            this.contactListBox.Name = "listBox1";
            this.contactListBox.Size = new System.Drawing.Size(199, 408);
            this.contactListBox.TabIndex = 0;
            this.contactListBox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // ChatBox
            // 
            this.ChatBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ChatBox.ForeColor = System.Drawing.Color.White;
            this.ChatBox.Location = new System.Drawing.Point(260, 55);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(500, 370);
            this.ChatBox.TabIndex = 4;
            // 
            // PreviousMessagesButton
            // 
            this.PreviousMessagesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PreviousMessagesButton.Location = new System.Drawing.Point(565, 7);
            this.PreviousMessagesButton.Name = "PreviousMessagesButton";
            this.PreviousMessagesButton.Size = new System.Drawing.Size(139, 20);
            this.PreviousMessagesButton.TabIndex = 6;
            this.PreviousMessagesButton.Text = "View previous messages";
            this.PreviousMessagesButton.UseVisualStyleBackColor = true;
            this.PreviousMessagesButton.Visible = false;
            this.PreviousMessagesButton.Click += new System.EventHandler(this.PreviousMessagesButton_Click);
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.userNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.userNameLbl.Location = new System.Drawing.Point(24, 15);
            this.userNameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(137, 29);
            this.userNameLbl.TabIndex = 7;
            this.userNameLbl.Text = "UserName";
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logoutBtn.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.logoutBtn.Location = new System.Drawing.Point(875, 7);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(92, 41);
            this.logoutBtn.TabIndex = 100;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(451, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 26);
            this.label1.TabIndex = 101;
            this.label1.Text = "Global Chat";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SoftEngChatClient.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(401, 2);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(8, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 455);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Active Chat";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.contactListBox);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(766, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 455);
            this.panel2.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(47, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contacts";
            // 
            // poweredBy
            // 
            this.poweredBy.AutoSize = true;
            this.poweredBy.BackColor = System.Drawing.Color.Transparent;
            this.poweredBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poweredBy.ForeColor = System.Drawing.Color.White;
            this.poweredBy.Location = new System.Drawing.Point(764, 509);
            this.poweredBy.Name = "poweredBy";
            this.poweredBy.Size = new System.Drawing.Size(142, 13);
            this.poweredBy.TabIndex = 104;
            this.poweredBy.Text = "Powered by ClientDriver 1.1";
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = global::SoftEngChatClient.Properties.Resources.background7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 522);
            this.Controls.Add(this.poweredBy);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.PreviousMessagesButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ChatBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChatWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ManChattan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatWindow_FormClosed);
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.Button PreviousMessagesButton;
        public ListBox contactListBox;
		private Label userNameLbl;
		private Button logoutBtn;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label3;
        private Panel panel2;
        private Label label2;
        private Label poweredBy;
    }
}

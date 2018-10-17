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
            this.userNameLbl = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.activeChatBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.poweredBy = new System.Windows.Forms.Label();
            this.findFriendsPanel = new System.Windows.Forms.Panel();
            this.addFriendButton = new System.Windows.Forms.Button();
            this.noFriendsLabel = new System.Windows.Forms.Label();
            this.findFriendsBox = new System.Windows.Forms.ListBox();
            this.findFriendsTextBox = new System.Windows.Forms.TextBox();
            this.findFriendsLabel = new System.Windows.Forms.Label();
            this.addFriends = new System.Windows.Forms.Label();
            this.showFriends = new System.Windows.Forms.Label();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.xLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.findFriendsPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            // contactListBox
            // 
            this.contactListBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.contactListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactListBox.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactListBox.ForeColor = System.Drawing.Color.White;
            this.contactListBox.FormattingEnabled = true;
            this.contactListBox.ItemHeight = 23;
            this.contactListBox.Location = new System.Drawing.Point(6, 40);
            this.contactListBox.Margin = new System.Windows.Forms.Padding(2);
            this.contactListBox.Name = "contactListBox";
            this.contactListBox.Size = new System.Drawing.Size(188, 391);
            this.contactListBox.TabIndex = 0;
            this.contactListBox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // ChatBox
            // 
            this.ChatBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatBox.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logoutBtn.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logoutBtn.Location = new System.Drawing.Point(67, 61);
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
            this.panel1.Controls.Add(this.activeChatBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(8, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 455);
            this.panel1.TabIndex = 0;
            // 
            // activeChatBox
            // 
            this.activeChatBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.activeChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.activeChatBox.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeChatBox.ForeColor = System.Drawing.Color.White;
            this.activeChatBox.FormattingEnabled = true;
            this.activeChatBox.ItemHeight = 23;
            this.activeChatBox.Location = new System.Drawing.Point(16, 40);
            this.activeChatBox.Name = "activeChatBox";
            this.activeChatBox.Size = new System.Drawing.Size(214, 391);
            this.activeChatBox.TabIndex = 109;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
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
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
            this.label2.Location = new System.Drawing.Point(55, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "My Friends";
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
            // findFriendsPanel
            // 
            this.findFriendsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.findFriendsPanel.Controls.Add(this.addFriendButton);
            this.findFriendsPanel.Controls.Add(this.noFriendsLabel);
            this.findFriendsPanel.Controls.Add(this.findFriendsBox);
            this.findFriendsPanel.Controls.Add(this.findFriendsTextBox);
            this.findFriendsPanel.Controls.Add(this.findFriendsLabel);
            this.findFriendsPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findFriendsPanel.ForeColor = System.Drawing.Color.White;
            this.findFriendsPanel.Location = new System.Drawing.Point(768, 55);
            this.findFriendsPanel.Name = "findFriendsPanel";
            this.findFriendsPanel.Size = new System.Drawing.Size(200, 455);
            this.findFriendsPanel.TabIndex = 105;
            this.findFriendsPanel.Visible = false;
            // 
            // addFriendButton
            // 
            this.addFriendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
            this.addFriendButton.Enabled = false;
            this.addFriendButton.FlatAppearance.BorderSize = 0;
            this.addFriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addFriendButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFriendButton.ForeColor = System.Drawing.Color.Black;
            this.addFriendButton.Location = new System.Drawing.Point(107, 424);
            this.addFriendButton.Margin = new System.Windows.Forms.Padding(2);
            this.addFriendButton.Name = "addFriendButton";
            this.addFriendButton.Size = new System.Drawing.Size(87, 21);
            this.addFriendButton.TabIndex = 108;
            this.addFriendButton.Text = "Add";
            this.addFriendButton.UseVisualStyleBackColor = false;
            this.addFriendButton.Click += new System.EventHandler(this.addFriendButton_Click);
            // 
            // noFriendsLabel
            // 
            this.noFriendsLabel.AutoSize = true;
            this.noFriendsLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.noFriendsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noFriendsLabel.Location = new System.Drawing.Point(8, 72);
            this.noFriendsLabel.Name = "noFriendsLabel";
            this.noFriendsLabel.Size = new System.Drawing.Size(135, 13);
            this.noFriendsLabel.TabIndex = 5;
            this.noFriendsLabel.Text = "Couldn\'t find your friend...";
            this.noFriendsLabel.Visible = false;
            // 
            // findFriendsBox
            // 
            this.findFriendsBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.findFriendsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.findFriendsBox.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findFriendsBox.ForeColor = System.Drawing.Color.White;
            this.findFriendsBox.FormattingEnabled = true;
            this.findFriendsBox.ItemHeight = 23;
            this.findFriendsBox.Location = new System.Drawing.Point(6, 70);
            this.findFriendsBox.Name = "findFriendsBox";
            this.findFriendsBox.Size = new System.Drawing.Size(188, 345);
            this.findFriendsBox.TabIndex = 4;
            this.findFriendsBox.SelectedIndexChanged += new System.EventHandler(this.findFriendsBox_SelectedIndexChanged);
            // 
            // findFriendsTextBox
            // 
            this.findFriendsTextBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.findFriendsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.findFriendsTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findFriendsTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.findFriendsTextBox.Location = new System.Drawing.Point(6, 36);
            this.findFriendsTextBox.MinimumSize = new System.Drawing.Size(188, 22);
            this.findFriendsTextBox.Name = "findFriendsTextBox";
            this.findFriendsTextBox.Size = new System.Drawing.Size(188, 20);
            this.findFriendsTextBox.TabIndex = 3;
            this.findFriendsTextBox.Text = "Search...";
            this.findFriendsTextBox.Click += new System.EventHandler(this.findFriendsTextBox_Click);
            this.findFriendsTextBox.TextChanged += new System.EventHandler(this.findFriendsTextBox_TextChanged);
            this.findFriendsTextBox.Leave += new System.EventHandler(this.findFriendsTextBox_Leave);
            // 
            // findFriendsLabel
            // 
            this.findFriendsLabel.AutoSize = true;
            this.findFriendsLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findFriendsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
            this.findFriendsLabel.Location = new System.Drawing.Point(49, 10);
            this.findFriendsLabel.Name = "findFriendsLabel";
            this.findFriendsLabel.Size = new System.Drawing.Size(107, 19);
            this.findFriendsLabel.TabIndex = 2;
            this.findFriendsLabel.Text = "Find Friends";
            // 
            // addFriends
            // 
            this.addFriends.AutoSize = true;
            this.addFriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(226)))));
            this.addFriends.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addFriends.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFriends.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addFriends.Location = new System.Drawing.Point(766, 20);
            this.addFriends.Name = "addFriends";
            this.addFriends.Size = new System.Drawing.Size(39, 39);
            this.addFriends.TabIndex = 106;
            this.addFriends.Text = "+";
            this.addFriends.Click += new System.EventHandler(this.addFriends_Click);
            this.addFriends.MouseLeave += new System.EventHandler(this.addFriends_MouseLeave);
            this.addFriends.MouseHover += new System.EventHandler(this.addFriends_MouseHover);
            // 
            // showFriends
            // 
            this.showFriends.AutoSize = true;
            this.showFriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.showFriends.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.showFriends.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFriends.ForeColor = System.Drawing.Color.White;
            this.showFriends.Location = new System.Drawing.Point(803, 20);
            this.showFriends.MinimumSize = new System.Drawing.Size(63, 38);
            this.showFriends.Name = "showFriends";
            this.showFriends.Size = new System.Drawing.Size(63, 38);
            this.showFriends.TabIndex = 107;
            this.showFriends.Text = "Friends";
            this.showFriends.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showFriends.Click += new System.EventHandler(this.showFriends_Click);
            this.showFriends.MouseLeave += new System.EventHandler(this.showFriends_MouseLeave);
            this.showFriends.MouseHover += new System.EventHandler(this.showFriends_MouseHover);
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.SettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsLabel.ForeColor = System.Drawing.Color.Black;
            this.SettingsLabel.Location = new System.Drawing.Point(888, 26);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(76, 20);
            this.SettingsLabel.TabIndex = 108;
            this.SettingsLabel.Text = "Settings";
            this.SettingsLabel.Click += new System.EventHandler(this.SettingsLabel_Click);
            this.SettingsLabel.MouseLeave += new System.EventHandler(this.SettingsLabel_MouseLeave);
            this.SettingsLabel.MouseHover += new System.EventHandler(this.settingsLabel_MouseHover);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.pictureBox2);
            this.settingsPanel.Controls.Add(this.xLabel);
            this.settingsPanel.Controls.Add(this.logoutBtn);
            this.settingsPanel.Location = new System.Drawing.Point(401, 205);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(222, 122);
            this.settingsPanel.TabIndex = 109;
            this.settingsPanel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(97, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 110;
            this.label4.Text = "Settings";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(54, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 102;
            this.pictureBox2.TabStop = false;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xLabel.Location = new System.Drawing.Point(197, 3);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(20, 19);
            this.xLabel.TabIndex = 101;
            this.xLabel.Text = "X";
            this.xLabel.Click += new System.EventHandler(this.xLabel_Click);
            this.xLabel.MouseLeave += new System.EventHandler(this.xLabel_MouseLeave);
            this.xLabel.MouseHover += new System.EventHandler(this.xLabel_MouseHover);
            this.xLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xLabel_MouseMove);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = global::SoftEngChatClient.Properties.Resources.background7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 522);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.poweredBy);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.addFriends);
            this.Controls.Add(this.showFriends);
            this.Controls.Add(this.findFriendsPanel);
            this.Controls.Add(this.panel2);
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
            this.findFriendsPanel.ResumeLayout(false);
            this.findFriendsPanel.PerformLayout();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox ChatBox;
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
        private Panel findFriendsPanel;
        private Label findFriendsLabel;
        private TextBox findFriendsTextBox;
        private Label addFriends;
        private Label showFriends;
        private ListBox findFriendsBox;
        private Label noFriendsLabel;
        private Button addFriendButton;
        private ListBox activeChatBox;
        private Label SettingsLabel;
        private Panel settingsPanel;
        private Label xLabel;
        private Label label4;
        private PictureBox pictureBox2;
    }
}

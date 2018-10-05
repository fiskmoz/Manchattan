using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngChatClient
{
    public partial class ChatWindow : Form
    {
        public event EventHandler sendButtonClicked;
        public event KeyEventHandler messageBoxKeyReleased;
        public event EventHandler previousMessageButtonClick;
        public event EventHandler chatWindowLoad;
        public event EventHandler usernamePressed;
		public event EventHandler logoutEvent;
        public event FormClosedEventHandler formClose;

        public ChatWindow()
        {
            InitializeComponent();
        }

        // When send button is clicked.
        private void SendButton_Click(object sender, EventArgs e)
        {
            sendButtonClicked(this, e);
        }

        // When ChatWindow is closed, 
        // Messages are saved in file then program closes.
        private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //chatWindowClosed(this, e);
            formClose(sender, e);
        }

        // Experimental, isnt working as intented yet.
        private void PreviousMessagesButton_Click(object sender, EventArgs e)
        {
            previousMessageButtonClick(this, e);
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            chatWindowLoad(this, e);
        }

        public void clearMessageBox()
        {
            MessageBox.Clear();
        }

        // Print a string to the ChatBox and add the message to the list.
        public void AppendTextBox(List<string> L, string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<string>, string>(AppendTextBox), new object[] { L, value });
                return;
            }
            ChatBox.AppendText(value);
        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            ChatBox.AppendText(value + System.Environment.NewLine );
        }

        //Returnerar skrivfältet
        public string getTextMessageBox()
        {
            return MessageBox.Text;
        }

        //Returnerar läsfältet
        public string getChatBox()
        {
            return ChatBox.Text;
        }

        private void MessageBox_KeyUp(object sender, KeyEventArgs e)
        {
            messageBoxKeyReleased(this, e);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            usernamePressed(this, e);
        }

		public void SetUserName(string name)
		{
			userNameLbl.Text = name;
		}

        public string removeEnterWhenSending()
        {
            if(MessageBox.Text.Contains(System.Environment.NewLine))
            {
                return MessageBox.Text.Remove(MessageBox.Text.IndexOf(System.Environment.NewLine));
            }
            return MessageBox.Text;
        }

		private void logoutBtn_Click(object sender, EventArgs e)
		{
			logoutEvent(sender, e);
		}

        private void MessageBox_Enter(object sender, EventArgs e)
        {
            
        }

        private void MessageBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageBox.Text == "")
            {
                SendButton.Enabled = false;
            }
            else
                SendButton.Enabled = true;
        }

        private void addFriends_MouseHover(object sender, EventArgs e)
        {
            addFriends.ForeColor = Color.White;
        }

        private void addFriends_MouseLeave(object sender, EventArgs e)
        {
            if (findFriendsPanel.Visible == false)
                addFriends.ForeColor = Color.FromArgb(64, 64, 64);
            else
                addFriends.ForeColor = Color.White;
        }

        private void addFriends_Click(object sender, EventArgs e)
        {
            if (findFriendsPanel.Visible == false)
            {
                findFriendsPanel.Visible = true;
                addFriends.BackColor = Color.FromArgb(64, 64, 64);
                addFriends.ForeColor = Color.White;

                showFriends.BackColor = Color.FromArgb(59, 177, 226);
                showFriends.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void showFriends_MouseHover(object sender, EventArgs e)
        {
            showFriends.ForeColor = Color.White;
        }

        private void showFriends_MouseLeave(object sender, EventArgs e)
        {
            if (findFriendsPanel.Visible == true)
                showFriends.ForeColor = Color.FromArgb(64, 64, 64);
            else
                showFriends.ForeColor = Color.White;
        }

        private void showFriends_Click(object sender, EventArgs e)
        {
            if(findFriendsPanel.Visible == true)
            {
                findFriendsPanel.Visible = false;
                showFriends.BackColor = Color.FromArgb(64, 64, 64);
                showFriends.ForeColor = Color.White;

                addFriends.BackColor = Color.FromArgb(59, 177, 226);
                addFriends.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void findFriendsTextBox_Click(object sender, EventArgs e)
        {
            if(findFriendsTextBox.Text == "Search...")
            {
                findFriendsTextBox.Text = "";
                findFriendsTextBox.ForeColor = Color.White;
                noFriendsLabel.Visible = false;
            }
        }

        private void findFriendsTextBox_Leave(object sender, EventArgs e)
        {
            if(findFriendsTextBox.Text == "")
            {
                findFriendsTextBox.Text = "Search...";
                findFriendsTextBox.ForeColor = Color.Gainsboro;
            }
        }

        private void findFriendsTextBox_TextChanged(object sender, EventArgs e)
        {
            string name1 = "MrThailand35";
            string name2 = "MrThailand36";
            int searchLength = findFriendsTextBox.TextLength;
            string temp = findFriendsTextBox.Text;
            for (int i = 0; i < searchLength; i++)
            {
                if (temp[i] == name1[i])
                {
                    findFriendsBox.Items.Add(name1[i]);
                }
            }
        }
    }
}

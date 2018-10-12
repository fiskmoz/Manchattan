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
        public event EventHandler findFriendsSearchEvent;
        public event EventHandler findFriendsTextBoxClickEvent;
        public event EventHandler findFriendsTextBoxLeaveEvent;
        public event EventHandler showFriendsEvent;
        public event EventHandler addFriendsEvent;
        public event EventHandler addFriendsButtonClicked;
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
            // garbage
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
            addFriendsEvent(this, e);
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
            showFriendsEvent(this, e);
        }

        private void findFriendsTextBox_Click(object sender, EventArgs e)
        {
            findFriendsTextBoxClickEvent(this, e);
        }

        private void findFriendsTextBox_Leave(object sender, EventArgs e)
        {
            findFriendsTextBoxLeaveEvent(this, e);
        }

        private void findFriendsTextBox_TextChanged(object sender, EventArgs e)
        {
            findFriendsSearchEvent(this, e);
        }
        public TextBox getFindFriendsTextbox()
        {
            return findFriendsTextBox;
        }
        public ListBox getFindFriendsBox()
        {
            return findFriendsBox;
        }
        public Label getNoFriendsLabel()
        {
            return noFriendsLabel;
        }
        public Panel getFindFriendsPanel()
        {
            return findFriendsPanel;
        }
        public Label getShowFriendsLabel()
        {
            return showFriends;
        }
        public Label getAddFriendsLabel()
        {
            return addFriends;
        }
        public TextBox getGlobalChatBox()
        {
            return ChatBox;
        }

        public Panel getPanelSettings()
        {
            return settingsPanel;
        }

        private void addFriendButton_Click(object sender, EventArgs e)
        {
            addFriendsButtonClicked(this, e);
        }

        private void settingsLabel_MouseHover(object sender, EventArgs e)
        {
            SettingsLabel.ForeColor = Color.FromArgb(59, 177, 226);
        }

        private void SettingsLabel_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = true;
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = false;
        }

        private void SettingsLabel_MouseLeave(object sender, EventArgs e)
        {
            SettingsLabel.ForeColor = Color.Black;
        }

        private void xLabel_MouseHover(object sender, EventArgs e)
        {
            xLabel.ForeColor = Color.FromArgb(59, 177, 226);
        }

        private void xLabel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void xLabel_MouseLeave(object sender, EventArgs e)
        {
            xLabel.ForeColor = Color.Black;
        }

        private void findFriendsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(findFriendsBox.SelectedIndex != -1)
            {
                addFriendButton.Enabled = true;
            }
        }

        public Button getAddFriendsButton()
        {
            return addFriendButton;
        }
    }
}

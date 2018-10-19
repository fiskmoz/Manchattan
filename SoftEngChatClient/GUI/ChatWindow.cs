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
using Manchaticons;

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
        public event EventHandler statusSendEvent;
        public event FormClosedEventHandler formClose;
        public event EventHandler openPendingFriendRequests;

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
            MessageBox.SelectionStart = MessageBox.Text.Length + 1;
            if (MessageBox.Text == "")
            {
                SendButton.Enabled = false;
            }
            else
                SendButton.Enabled = true;
        }

        private void addFriends_Click(object sender, EventArgs e)
        {
            addFriendsEvent(this, e);
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
        public TextBox getMessageBox()
        {
            return MessageBox;
        }
        public TextBox getStatusTextBox()
        {
            return statusTextBox;
        }
        public Label getStatusTextLabel()
        {
            return statusTextLbl;
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
            if(settingsPanel.Visible == false)
                settingsLabel.BackColor = Color.SteelBlue;
        }

        private void SettingsLabel_Click(object sender, EventArgs e)
        {
            if (settingsPanel.Visible == false)
            {
                settingsPanel.Visible = true;
                settingsLabel.BackColor = Color.SteelBlue;
            }
            else
            {
                settingsPanel.Visible = false;
                settingsLabel.BackColor = Color.Transparent;
            }
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = false;
        }

        private void SettingsLabel_MouseLeave(object sender, EventArgs e)
        {
            if (settingsPanel.Visible == false)
                settingsLabel.BackColor = Color.Transparent;
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
        public Label getFindFriendsLabel()
        {
            return findFriendsLabel;
        }
        public Label getMyFriendsLabel()
        {
            return myFriendsLabel;
        }

        private void FRButton_Click(object sender, EventArgs e)
        {
            openPendingFriendRequests(this, e);
        }
        private void emojiHappy_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Happy;
        }

        private void emojiSad_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Sad;
        }

        private void emojiTongue_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Tongue;
        }

        private void emojiDevil_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Devil;
        }

        private void emojiThinking_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Thinking;
        }

        private void emojiSick_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Sick;
        }

        private void emojiMuted_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Muted;
        }

        private void emojiSleeping_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Sleeping;
        }

        private void emojiShocked_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Shocked;
        }

        private void emojiShockedLightly_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Shocked_lightly;
        }

        private void emojiCrying_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Crying;
        }

        private void emojiAngry_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Angry;
        }

        private void emojiKiss_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Kiss;
        }

        private void emojiSmart_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Smart;
        }

        private void emojiCool_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Cool;
        }

        private void emojiInLove_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.In_love;
        }

        private void emojiWink_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Wink;
        }

        private void emojiHappier_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Happier;
        }

        private void emojiDyingLaughter_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Dying_laugher;
        }

        private void emojiPoo_Click(object sender, EventArgs e)
        {
            MessageBox.Text = MessageBox.Text + Emoji.Poo;
        }
        private void emojiLogoBox_MouseHover(object sender, EventArgs e)
        {
            emojiPanel.Size = new Size(150, 30);
            emojiPanel.BackColor = Color.SteelBlue;
            emojiPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void emojiLogoBox_MouseLeave(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == false)
            {
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
            }
        }

        private void emojiLogoBox_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == false)
            {
                emojiPanel.Size = new Size(150, 30);
                emojiPanel.BackColor = Color.SteelBlue;
                allEmoticonsPanel.Visible = true;
            }
            else if (allEmoticonsPanel.Visible == true)
            {
                allEmoticonsPanel.Visible = false;
            }
        }

        private void groupChatPanel_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == true)
            {
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
                allEmoticonsPanel.Visible = false;
            }
        }

        private void ChatBox_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == true)
            {
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
                allEmoticonsPanel.Visible = false;
            }
        }

        private void MessageBox_Click(object sender, EventArgs e)
        {
            if (allEmoticonsPanel.Visible == true)
            {
                emojiPanel.Size = new Size(30, 30);
                emojiPanel.BackColor = Color.Transparent;
                emojiPanel.BorderStyle = BorderStyle.None;
                allEmoticonsPanel.Visible = false;
            }
        }

        private void statusTextLbl_Click(object sender, EventArgs e)
        {
            statusTextBox.Visible = true;
            statusTextBox.Focus();
            if(statusTextLbl.Text.Length > 0)
            {
                statusTextBox.Clear();
            }
        }

        private void statusTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(statusTextBox.Text == "")
                {
                    statusTextLbl.Text = "Status";
                }
                else
                {
                    statusTextLbl.Text = statusTextBox.Text;
                }
                
                statusTextBox.Visible = false;
            }

            if(statusTextLbl.Text != "Status")
            {
                statusSendEvent(sender, e);
            }

        }
    }
}

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
        public event EventHandler chatWindowClosed;
        public event KeyEventHandler messageBoxKeyReleased;
        public event EventHandler previousMessageButtonClick;
        public event EventHandler chatWindowLoad;
        public event EventHandler usernamePressed;
		public event EventHandler logoutEvent;

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
            chatWindowClosed(this, e);
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
	}
}

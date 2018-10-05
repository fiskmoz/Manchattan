using SoftEngChatClient.Model.SSLCommunication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SoftEngChatClient.Model;

namespace SoftEngChatClient.Drivers
{
    class ChatWindowDriver
    {
        private ChatWindow chatWindow;
        int spam;
        private List<IndividualChatDriver> individualChatDrivers;
        private SSLWriter writer;
        private Cryptography logCrypto;

        public event EventHandler restart;

        private bool loggingOut = false;

        private string username;

        private List<string> messageList;

        public ChatWindowDriver(SSLWriter writer, Cryptography logCrypto)
        {
            this.writer = writer;
            this.logCrypto = logCrypto;
            individualChatDrivers = new List<IndividualChatDriver>();
            chatWindow = new ChatWindow();
            SetupListeners();
        }

        private void SetupListeners()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(SpamTimerElapsed);
            timer.Enabled = true;

            chatWindow.sendButtonClicked += new EventHandler(ChatWindowSendButtonClicked);
            chatWindow.messageBoxKeyReleased += new KeyEventHandler(ChatWindowEnterReleased);
            chatWindow.previousMessageButtonClick += new EventHandler(PreviousMessageButtonClicked);
            chatWindow.chatWindowLoad += new EventHandler(ChatWindowLoaded);
            chatWindow.usernamePressed += new EventHandler(HandleIndividualUsernamePressed);
            chatWindow.logoutEvent += new EventHandler(LogoutButtonClicked);
            chatWindow.formClose += new FormClosedEventHandler(ChatWindowClosed);
        }

		public void Subscribe(Messagehandler mh)
		{
			mh.IncommingClientMessage += new EventHandler(IncommingMessage);
		}

        private void SpamTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (spam >= 0)
            {
                spam--;
            }
        }

        private void ChatWindowLoaded(object sender, EventArgs e)
        {
            messageList = new List<string>();
            try
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\MessageLog.txt";
                byte[] ba = File.ReadAllBytes(filePath);

                var goodString = logCrypto.DecryptBytes(ba);
                chatWindow.AppendTextBox(messageList, goodString);

            }
            catch (Exception)
            {
                chatWindow.AppendTextBox(messageList, "" + System.Environment.NewLine);
            }
        }

        private void ChatWindowClosed(object obj, FormClosedEventArgs e)
        {
            var str = chatWindow.getChatBox();
            var byteArray = logCrypto.EncryptString(str);
            var fs = new FileStream("MessageLog.txt", FileMode.Create, FileAccess.Write);
            fs.Write(byteArray, 0, byteArray.Length);
            fs.Close();
            if (loggingOut == false)
            {
                writer.WriteLogout(MessageType.logout);
                Thread.Sleep(1000);
                Application.Exit();
                System.Environment.Exit(1);
            }
        }

        private void ChatWindowSendButtonClicked(object sender, EventArgs e)
        {
            if (chatWindow.removeEnterWhenSending().Length > 0)
            {
                spam++;
                if (spam < 5)
                {
                    writer.WriteClient(MessageType.client, this.username, "All", chatWindow.removeEnterWhenSending());
                    chatWindow.AppendTextBox("[" + username + "] : " + chatWindow.removeEnterWhenSending());
                }
                else
                {
                    chatWindow.AppendTextBox("[Program] Don´t spam");
                }
            }
            chatWindow.clearMessageBox();
        }

        private void ChatWindowEnterReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChatWindowSendButtonClicked(sender, e);
            }
        }

        private void HandleIndividualUsernamePressed(object sender, EventArgs e)
        {
            var index = chatWindow.listBox1.SelectedItem;
            string receiver = chatWindow.listBox1.GetItemText(index);
            if (receiver != username)
            {
                AddNewIndividualChat(receiver);
            }
        }

        private void LogoutButtonClicked(object sender, EventArgs e)
        {
            loggingOut = true;
            chatWindow.Close();
            writer.WriteLogout(MessageType.logout);
            Thread.Sleep(2000);
            chatWindow = new ChatWindow();
            loggingOut = false;
            restart(this, e);
        }

        private void PreviousMessageButtonClicked(object sender, EventArgs e)
        {
            foreach (string s in messageList)
            {
                chatWindow.AppendTextBox(messageList, s + System.Environment.NewLine);
            }
        }

        public void ChatWindowPrint(string sender, string message)
        {
            chatWindow.AppendTextBox("[" + sender + "] : " + message);
        }

        public void UpdateOnlineList(string str)
        {
            if (chatWindow.InvokeRequired)
            {
                chatWindow.Invoke(new Action<string>(UpdateOnlineList), new object[] { str });
                return;
            }
            string[] usernames;
            usernames = str.Split(':');
            for (int n = chatWindow.listBox1.Items.Count - 1; n >= 0; --n)
            {
                chatWindow.listBox1.Items.RemoveAt(n);
            }

            for (int i = 1; i < usernames.Length; i++)
            {
                chatWindow.listBox1.Items.Add(usernames[i]);
            }
        }

        public void SetUserName(string name)
        {
            if (chatWindow.InvokeRequired)
            {
                chatWindow.Invoke(new Action<string>(chatWindow.SetUserName), name);
                return;
            }
            this.username = name;
            chatWindow.SetUserName(name);
        }

        public void IndividualChatPrint(string sender, string message)
        {
            foreach (var icd in individualChatDrivers)
            {
                if (sender == icd.getSender())
                {
                    icd.ReceiveMessage(message);
                }
            }
        }

        public void AddNewIndividualChat(string sender)
        {
            bool found = false;
            foreach (IndividualChatDriver icd in individualChatDrivers)
            {
                if (icd.getSender() == sender)
                {
                    found = true;
                    if (!icd.isWindowVisible())
                    {
                        icd.displayWindow();
                    }
                }
            }
            if (found == false)
                individualChatDrivers.Add(new IndividualChatDriver(writer, username, sender));
        }

		private void IncommingMessage(object sender, EventArgs eventArgs)
		{
			if(((ClientMessage) eventArgs).receiver == "All")
			{
				ChatWindowPrint(((ClientMessage)eventArgs).sender, ((ClientMessage)eventArgs).message);
			}
			else
			{
				IndividualChatPrint(((ClientMessage)eventArgs).sender, ((ClientMessage)eventArgs).message);
			}
		}
    }
}
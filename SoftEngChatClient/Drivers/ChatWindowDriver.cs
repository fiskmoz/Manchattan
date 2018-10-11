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
using SoftEngChatClient.Controller;
using System.Drawing;
using SoftEngChatClient.GUI;

namespace SoftEngChatClient.Drivers
{
    class ChatWindowDriver
    {
        private ChatWindow chatWindow;
        private List<IndividualChatDriver> individualChatDrivers;
        private SSLWriter writer;
        private ClientCrypto logCrypto;
        private SpamProtector spam;
        private List<string> userlist;
		private ContactsHandler contactsHandler;
		private FileManager fileManager;
        private FriendRequest friendrequest;

        public event EventHandler restart;

        private bool loggingOut = false;

        private string username;

        private byte[] personalKey;

        private List<string> messageList;

        public ChatWindowDriver(SSLWriter writer, ClientCrypto logCrypto)
        {
            userlist = new List<string>();
            
            this.writer = writer;
            this.logCrypto = logCrypto;
            fileManager = new FileManager();

            contactsHandler = new ContactsHandler(fileManager);
            spam = new SpamProtector();
            individualChatDrivers = new List<IndividualChatDriver>();
            chatWindow = new ChatWindow();
            friendrequest = new FriendRequest();
            SetupListeners();
            username = ClientDriver.globalUsername;
            
        }

        private void SetupListeners()
        {
            chatWindow.sendButtonClicked += new EventHandler(ChatWindowSendButtonClicked);
            chatWindow.messageBoxKeyReleased += new KeyEventHandler(ChatWindowEnterReleased);
            chatWindow.previousMessageButtonClick += new EventHandler(PreviousMessageButtonClicked);
            chatWindow.chatWindowLoad += new EventHandler(ChatWindowLoaded);
            chatWindow.usernamePressed += new EventHandler(HandleIndividualUsernamePressed);
            chatWindow.logoutEvent += new EventHandler(LogoutButtonClicked);
            chatWindow.formClose += new FormClosedEventHandler(ChatWindowClosed);
            chatWindow.findFriendsSearchEvent += new EventHandler(FindFriendsSearch);
            chatWindow.findFriendsTextBoxClickEvent += new EventHandler(FindFriendsTextBoxClickEvent);
            chatWindow.findFriendsTextBoxLeaveEvent += new EventHandler(FindFriendsTextBoxLeaveEvent);
            chatWindow.showFriendsEvent += new EventHandler(ShowFriendsLabel);
            chatWindow.addFriendsEvent += new EventHandler(AddFriendsLabel);
            chatWindow.addFriendsButtonClicked += new EventHandler(AddFriendsButtonClickedEvent);
            friendrequest.acceptButtonClick += new EventHandler(AcceptFriendRequestButton);
            friendrequest.rejectButtonClick += new EventHandler(RejectFriendRequestButton);
			contactsHandler.UpdateContactList += new EventHandler(UpdateOnlineList);
        }

		public void Subscribe(Messagehandler mh)
		{
			mh.IncommingClientMessage += new EventHandler(IncommingMessage);
            mh.IncommingLoginAck += new EventHandler(LoggingIn);
            mh.IncommingFriendRequest += new EventHandler(ReceivedFriendRequest);
            mh.IncommmingFriendResponse += new EventHandler(ReceivedFriendResponse);
			contactsHandler.Subscribe(mh);
		}
    
        private void ChatWindowLoaded(object sender, EventArgs e)
        {
            messageList = new List<string>();
            try
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\MessageLog.txt";
                byte[] ba = File.ReadAllBytes(filePath);

                var goodString = logCrypto.DecryptWithGlobal(ba);
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
            if (str != "")
            {
                var byteArray = logCrypto.EncryptWithGlobal(str);
                var fs = new FileStream("MessageLog.txt", FileMode.Create, FileAccess.Write);
                chatWindow.getGlobalChatBox().Clear();
                fs.Write(byteArray, 0, byteArray.Length);
                fs.Close();
            }
            if (loggingOut == false)
            {
                writer.WriteLogout(MessageType.logout);
                Thread.Sleep(250);
                Application.Exit();
                System.Environment.Exit(1);
            }
        }

        private void ChatWindowSendButtonClicked(object sender, EventArgs e)
        {
            if (chatWindow.removeEnterWhenSending().Length > 0)
            {
                spam.SpamAppend();
                if (spam.IsNotSpamming())
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
            var index = chatWindow.contactListBox.SelectedItem;
            string receiver = chatWindow.contactListBox.GetItemText(index);
            if (receiver != username)
            {
                AddNewIndividualChat(receiver);
            }
        }

        private void LogoutButtonClicked(object sender, EventArgs e)
        {
            loggingOut = true;
            ChatWindowClosed(sender, new FormClosedEventArgs(CloseReason.None));
            chatWindow.Hide();
            writer.WriteLogout(MessageType.logout);
            Thread.Sleep(250);
            restart(this, e);
            loggingOut = false;
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

        public void UpdateOnlineList(object sender, EventArgs eventArgs)
        {
            if (chatWindow.InvokeRequired)
            {
                chatWindow.Invoke(new Action<object, EventArgs>(UpdateOnlineList), new object[] { sender, eventArgs });
                return;
            }
			List<Contact> contactList = ((ContactListEventArg)eventArgs).contacts;
            for (int n = chatWindow.contactListBox.Items.Count - 1; n >= 0; --n)
            {
                chatWindow.contactListBox.Items.RemoveAt(n);
            }

            foreach(Contact contact in contactList)
			{
                chatWindow.contactListBox.Items.Add(contact.name);
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
                individualChatDrivers.Add(new IndividualChatDriver(writer, username, sender, fileManager));
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
        //If login OK, set username and personal key.
        private void LoggingIn(object sender, EventArgs args)
        {
            if( ((LoginAck)args).message)
            {
                if (chatWindow.InvokeRequired)
                {
                    chatWindow.Invoke(new Action<object, EventArgs>(LoggingIn), new object[] { sender, args });
                    return;
                }
                username = ClientDriver.globalUsername;
                chatWindow.SetUserName(username);

                string key = ((LoginAck)args).key;
                int NumberChars = key.Length;
                personalKey = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    personalKey[i / 2] = System.Convert.ToByte(key.Substring(i, 2), 16);
                logCrypto.SetNewKey(personalKey);
                fileManager.cyptoMessage.SetNewKey(personalKey);

                new Thread(() => chatWindow.ShowDialog()).Start();
            }
        }

        private void ReceivedFriendRequest(object sender, EventArgs message)
        {
            if (friendrequest.InvokeRequired)
            {
                friendrequest.Invoke(new Action<object, EventArgs>(ReceivedFriendRequest), new object[] { sender, message });
                return;
            }
            friendrequest.getFriendLabel().Text = ((ClientMessage)message).sender;
            friendrequest.ShowDialog();
        }

        private void ReceivedFriendResponse(object sender, EventArgs message)
        {
            MessageBox.Show("FriendResponse");
        }

        private void FindFriendsSearch(object sender, EventArgs e)
        {
            try
            {
                userlist = contactsHandler.offlineList;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed: usersInput has 0 users\n" + ex.Message.ToString());
                return;
            }
            int userAmount = userlist.Count;
            int counter = 0;
            int searchLength = chatWindow.getFindFriendsTextbox().Text.Length;
            string temp = chatWindow.getFindFriendsTextbox().Text;

            foreach (var user in userlist)
            {
                if(chatWindow.getFindFriendsTextbox().Text == "Search...")
                {
                    chatWindow.getNoFriendsLabel().Visible = false;
                    return;
                }
                if (user.ToString().StartsWith(temp))
                {
                    chatWindow.getNoFriendsLabel().Visible = false;
                    if (!chatWindow.getFindFriendsBox().Items.Contains(user))
                    {
                        chatWindow.getFindFriendsBox().Items.Add(user);
                    }
                }
                else
                {
                    chatWindow.getFindFriendsBox().Items.Remove(user);
                    if (chatWindow.getFindFriendsBox().Items.Count <= 0)
                    {
                        for (int i = 0; i < userAmount; i++)
                        {
                            if (temp != user)
                            {
                                counter++;
                            }
                        }
                        if (counter == userAmount)
                        {
                            chatWindow.getFindFriendsBox().Items.Clear();
                            chatWindow.getNoFriendsLabel().Visible = true;
                        }
                    }
                }
            }
            if (chatWindow.getFindFriendsTextbox().Text == "")
            {
                chatWindow.getFindFriendsBox().Items.Clear();
                chatWindow.getNoFriendsLabel().Visible = false;
            }
        }

        private void FindFriendsTextBoxClickEvent(object sender, EventArgs e)
        {
            if (chatWindow.getFindFriendsTextbox().Text == "Search...")
            {
                chatWindow.getFindFriendsTextbox().Text = "";
                chatWindow.getFindFriendsTextbox().ForeColor = Color.White;
                chatWindow.getNoFriendsLabel().Visible = false;
            }
        }

        private void FindFriendsTextBoxLeaveEvent(object sender, EventArgs e)
        {
            if (chatWindow.getFindFriendsTextbox().Text == "")
            {
                chatWindow.getFindFriendsTextbox().Text = "Search...";
                chatWindow.getFindFriendsTextbox().ForeColor = Color.Gainsboro;
            }
        }

        private void ShowFriendsLabel(object sender, EventArgs e)
        {
            if (chatWindow.getFindFriendsPanel().Visible == true)
            {
                chatWindow.getFindFriendsPanel().Visible = false;
                chatWindow.getShowFriendsLabel().BackColor = Color.FromArgb(64, 64, 64);
                chatWindow.getShowFriendsLabel().ForeColor = Color.White;

                chatWindow.getAddFriendsLabel().BackColor = Color.FromArgb(59, 177, 226);
                chatWindow.getAddFriendsLabel().ForeColor = Color.FromArgb(64, 64, 64);
                FindFriendsTextBoxLeaveEvent(this, e);
            }
        }

        private void AddFriendsLabel(object sender, EventArgs e)
        {
            if (chatWindow.getFindFriendsPanel().Visible == false)
            {
                chatWindow.getFindFriendsPanel().Visible = true;
                chatWindow.getAddFriendsLabel().BackColor = Color.FromArgb(64, 64, 64);
                chatWindow.getAddFriendsLabel().ForeColor = Color.White;

                chatWindow.getShowFriendsLabel().BackColor = Color.FromArgb(59, 177, 226);
                chatWindow.getShowFriendsLabel().ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void AddFriendsButtonClickedEvent(object sender, EventArgs e)
        {
            string userAdd = chatWindow.getFindFriendsBox().SelectedItem.ToString();
            writer.WriteFriendRequest(MessageType.friendRequest, username, userAdd);
            MessageBox.Show("Friend Request Sent!");
        }

        private void AcceptFriendRequestButton(object sender, EventArgs e)
        {
            writer.WriteFriendResponse(MessageType.friendReponse, username, "1");
        }

        private void RejectFriendRequestButton(object sender, EventArgs e)
        {
            writer.WriteFriendResponse(MessageType.friendReponse, username, "0");
        }
    }

}
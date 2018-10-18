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
using System.Net.Sockets;
using Tulpep.NotificationWindow;
using SoftEngChatClient.P2P;

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
        private PopupNotifier popup;
		private P2PConnector p2pConnector;
		private Messagehandler messageHandler;

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
            popup = new PopupNotifier();
            popup.Image = Properties.Resources.logo;
            popup.Click += new EventHandler(OnPopupClick);
			p2pConnector = new P2P.P2PConnector();

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

		public void Subscribe(Messagehandler mh, P2PConnector p2pc)
		{
			messageHandler = mh;
			mh.IncommingClientMessage += new EventHandler(IncommingMessage);
            mh.IncommingLoginAck += new EventHandler(LoggingIn);
            mh.IncommingFriendRequest += new EventHandler(ReceivedFriendRequest);
            mh.IncommmingFriendResponse += new EventHandler(ReceivedFriendResponse);
			mh.OutgoingP2P += new EventHandler(ReceivedP2PResponse);
			contactsHandler.Subscribe(mh);
			p2pc.IncommingConnection += new EventHandler(NewP2PConnection);
		}

		private void NewP2PConnection(object sender, EventArgs e)
		{
			IncommingP2PConnection args = (IncommingP2PConnection)e;
			AddNewIndividualP2PChat(args.sender, args.netStream);
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
            contactsHandler.SaveContactList();

			chatWindow.contactListBox.Items.Clear();
			chatWindow.contactListBox.Refresh();

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
                    SendPopup("SENDING TO ALL", chatWindow.removeEnterWhenSending());
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
				CreateNewIndivivualChat(receiver.Replace(" (offline)", ""));
            }
        }

		private void CreateNewIndivivualChat(string receiver)
		{
			foreach(Contact contact in contactsHandler.contactList)
			{
				if(contact.name == receiver)
				{
					if (contact.isOnline)
					{
						writer.WriteEstablishP2P(MessageType.establishP2P, username, receiver);
					}
					else
					{
						AddNewIndividualChat(receiver);
					}
					break;
				}
			}
		}

        private void LogoutButtonClicked(object sender, EventArgs e)
        {
            foreach(var idc in individualChatDrivers)
            {
                idc.hideWindow();
            }
                
            individualChatDrivers.Clear();
            chatWindow.getPanelSettings().Visible = false;
            ResetSearchField();
            ShowFriendsLabel(this, e);
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
                if(contact.isOnline)
                {
                    chatWindow.contactListBox.Items.Add(contact.name);
                }
                else
                {
                    chatWindow.contactListBox.Items.Add(contact.name+ " (offline)");
                }
            }
			chatWindow.contactListBox.Update();
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
            //AddNewIndividualChat(sender);
            foreach (var icd in individualChatDrivers)
            {
                if (sender == icd.getSender())
                {
                    if(!icd.isWindowVisible())
                    {
                        SendPopup("Received message from: " + sender, message);
                    }
                    icd.ReceiveMessage(message);
                    return;
                }
            }
            individualChatDrivers.Add(new IndividualChatDriver(writer, username, sender, fileManager));
            individualChatDrivers[individualChatDrivers.Count()-1].ReceiveMessage(message);
            SendPopup("Received message from: " + sender, message);
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
                    icd.SetNormalWindowState();
                }
            }
            if (found == false)
            {
                individualChatDrivers.Add(new IndividualChatDriver(writer, username, sender, fileManager));
                individualChatDrivers[individualChatDrivers.Count() - 1].SetNormalWindowState();
                //Add to active chats
                //chatWindow.activeChats.Items.Add(sender);
            }
        }

		public void AddNewIndividualP2PChat(string sender, NetworkStream netStream)
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
			{
				individualChatDrivers.Add(new IndividualChatDriver(username, sender, fileManager, netStream, messageHandler));
				//Add to active chats
				//chatWindow.activeChats.Items.Add(sender);
			}

		}

		private void IncommingMessage(object sender, EventArgs eventArgs)
		{
            if (((ClientMessage) eventArgs).receiver == "All")
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

                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\" + username);

                new Thread(() => chatWindow.ShowDialog()).Start();
                
            }
        }

		private void ReceivedP2PResponse(object sender, EventArgs e)
		{
			P2POutgoingConnection arg = (P2POutgoingConnection)e;
			NetworkStream netstream = p2pConnector.Connect(arg.ip, arg.port);
			AddNewIndividualP2PChat(arg.receiver, netstream);
		}

		private void ReceivedFriendRequest(object sender, EventArgs message)
        {
            SendPopup("Received friend request from: " + ((ClientMessage)message).sender, ((ClientMessage)message).message);
        }

        private void ReceivedFriendResponse(object sender, EventArgs message)
        {
			if(((ClientMessage)message).message == "1")
			{
				string friend = ((ClientMessage)message).sender;
				contactsHandler.AddContact(friend);
			}
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
                chatWindow.getAddFriendsButton().Enabled = false;
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
            SendPopup("Friend request sent!", "To: " + userAdd);
        }

        private void AcceptFriendRequestButton(object sender, EventArgs e)
        {
            writer.WriteFriendResponse(MessageType.friendReponse, username, friendrequest.getFriendLabel().Text, "1");
            contactsHandler.AddContact(friendrequest.getFriendLabel().Text);
            friendrequest.Close();
        }

        private void RejectFriendRequestButton(object sender, EventArgs e)
        {
            writer.WriteFriendResponse(MessageType.friendReponse, username, friendrequest.getFriendLabel().Text, "0");
            friendrequest.Close();
        }

        private void ResetSearchField()
        {
            chatWindow.getFindFriendsTextbox().Text = "Search...";
            chatWindow.getFindFriendsBox().Items.Clear();
        }

        private void SendPopup(string header, string text)
        {
            if(chatWindow.InvokeRequired)
            {
                chatWindow.Invoke(new Action<string, string>(SendPopup), new object[] { header, text });
                return;
            }
            popup.TitleText = header;
            popup.ContentText = text;
            popup.Popup();
        }

        private void OnPopupClick(object sender, EventArgs e)
        {
            string[] popupSplit = popup.TitleText.Split(' ');
            if (popupSplit.Count() < 4)
            {

            }
            else if(contactsHandler.FindContact(popupSplit[3]))
            {
                AddNewIndividualChat(popup.TitleText.Split(' ')[3]);
            }
            else if(popup.TitleText.Split(' ').Count() > 3)
            {
                if (friendrequest.InvokeRequired)
                {
                    friendrequest.Invoke(new Action<object, EventArgs>(ReceivedFriendRequest), new object[] { sender, e });
                    return;
                }
                friendrequest.getFriendLabel().Text = popup.TitleText.Split(' ')[4];
                friendrequest.ShowDialog();
            }
            else
            {

            }
        }
    }
}
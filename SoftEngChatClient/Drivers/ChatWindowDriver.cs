﻿using SoftEngChatClient.Model.SSLCommunication;
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

namespace SoftEngChatClient.Drivers
{
    class ChatWindowDriver
    {
        private ChatWindow chatWindow;
        private List<IndividualChatDriver> individualChatDrivers;
        private SSLWriter writer;
        private ClientCrypto logCrypto;
        private SpamProtector spam;
        private ContactsHandler contactList;
        private List<string> usersInput;
		private ContactsHandler contactsHandler;
		private FileManager fileManager;

        public event EventHandler restart;

        private bool loggingOut = false;

        private string username;

        private List<string> messageList;

        public ChatWindowDriver(SSLWriter writer, ClientCrypto logCrypto)
        {
            this.writer = writer;
            this.logCrypto = logCrypto;
			fileManager = new FileManager();
			contactsHandler = new ContactsHandler(fileManager);
            spam = new SpamProtector();
            individualChatDrivers = new List<IndividualChatDriver>();
            chatWindow = new ChatWindow();
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
            if (str != "")
            {
                var byteArray = logCrypto.EncryptString(str);
                var fs = new FileStream("MessageLog.txt", FileMode.Create, FileAccess.Write);
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
                    if (chatWindow.removeEnterWhenSending()[0] == '7')
                    {
                        writer.WriteFriendRequest(MessageType.friendRequest, this.username, "olaf");
                    }
                    else if (chatWindow.removeEnterWhenSending()[0] == '0')
                    {
                        writer.WriteFriendResponse(MessageType.friendReponse, this.username, "Admin");
                    }
                    else
                    {
                        writer.WriteClient(MessageType.client, this.username, "All", chatWindow.removeEnterWhenSending());
                    }
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
                new Thread(() => chatWindow.ShowDialog()).Start();
            }
        }

        private void ReceivedFriendRequest(object sender, EventArgs message)
        {
            MessageBox.Show("FriendRequest");
        }

        private void ReceivedFriendResponse(object sender, EventArgs message)
        {
            MessageBox.Show("FriendResponse");
        }

        private void FindFriendsSearch(object sender, EventArgs e)
        {
			//Contact test = new Contact("test", false);
			//Messagehandler test = new Messagehandler();
			//contactList.Subscribe(test);
			usersInput = contactList.offlineList;

			/**********************************************/
			// Written by Roman
			/**********************************************/
			//Offlinelist is a List<string>
			//förstår inte varför usersInput är en kopia av offlineList.
			//Offlinelist finns alltid sparad hos ContactsHandler
			//och uppdateras där också. Det enda som måsta göras här är
			//att söka igenom den listan
			/**********************************************/

            int userAmount = usersInput.Count;
            string[] users = new string[userAmount];
            for(int i = 0; i < userAmount; i++)
            {
                users[i] = usersInput[i];
            }
            //string[] name = { "MrThailand35", "MrThailand45", "MrThaiband" };
            int counter = 0;
            int searchLength = chatWindow.getFindFriendsTextbox().Text.Length;
            string temp = chatWindow.getFindFriendsTextbox().Text.Trim();

            foreach (string user in users)
            {
                if(chatWindow.getFindFriendsTextbox().Text == "Search...")
                {
                    chatWindow.getNoFriendsLabel().Visible = false;
                    return;
                }
                if (user.StartsWith(temp))
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
                            if (temp != users[i])
                            {
                                counter++;
                            }
                        }
                        if (counter == userAmount)
                        {
                            chatWindow.getFindFriendsBox().Items.Clear();
                            chatWindow.getNoFriendsLabel().Visible = true;
                            return;
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
    }
}
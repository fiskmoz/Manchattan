using SoftEngChatClient.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.Drivers
{
    class ChatWindowGraphicsDriver
    {
        private ChatWindow chatWindow;
        public ChatWindowGraphicsDriver(ChatWindow window)
        {
            chatWindow = window;
            SetupListeners();
        }

        private void SetupListeners()
        {
            chatWindow.findFriendsTextBoxClickEvent += new EventHandler(FindFriendsTextBoxClickEvent);
            chatWindow.findFriendsTextBoxLeaveEvent += new EventHandler(FindFriendsTextBoxLeaveEvent);
            chatWindow.showFriendsEvent += new EventHandler(ShowFriendsLabel);
            chatWindow.addFriendsEvent += new EventHandler(AddFriendsLabel);
        }

        public void ResetSearchField()
        {
            chatWindow.getFindFriendsTextbox().Text = "Search...";
            chatWindow.getFindFriendsBox().Items.Clear();
        }

        public void AddFriendsLabel(object sender, EventArgs e)
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

        public void ShowFriendsLabel(object sender, EventArgs e)
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

        public void FindFriendsTextBoxLeaveEvent(object sender, EventArgs e)
        {
            if (chatWindow.getFindFriendsTextbox().Text == "")
            {
                chatWindow.getFindFriendsTextbox().Text = "Search...";
                chatWindow.getFindFriendsTextbox().ForeColor = Color.Gainsboro;
            }
        }

        public void FindFriendsTextBoxClickEvent(object sender, EventArgs e)
        {
            if (chatWindow.getFindFriendsTextbox().Text == "Search...")
            {
                chatWindow.getFindFriendsTextbox().Text = "";
                chatWindow.getFindFriendsTextbox().ForeColor = Color.White;
                chatWindow.getNoFriendsLabel().Visible = false;
            }
        }

        public void ChatWindowPrint(string sender, string message)
        {
            chatWindow.AppendTextBox("[" + sender + "] : " + message);
        }

        public void SearchForFriend(List<string> userlist)
        {
            int userAmount = userlist.Count;
            int counter = 0;
            int searchLength = chatWindow.getFindFriendsTextbox().Text.Length;
            string temp = chatWindow.getFindFriendsTextbox().Text;

            foreach (var user in userlist)
            {
                if (chatWindow.getFindFriendsTextbox().Text == "Search...")
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

        public void UpdateGraphicalOnlineList(List<Contact> contactList)
        {
            if (chatWindow.InvokeRequired)
            {
                chatWindow.Invoke(new Action<List<Contact>>(UpdateGraphicalOnlineList), new object[] { contactList });
                return;
            }
            
            for (int n = chatWindow.contactListBox.Items.Count - 1; n >= 0; --n)
            {
                chatWindow.contactListBox.Items.RemoveAt(n);
            }

            foreach (Contact contact in contactList)
            {
                if (contact.isOnline)
                {
                    chatWindow.contactListBox.Items.Add(contact.name);
                }
                else
                {
                    chatWindow.contactListBox.Items.Add(contact.name + " (offline)");
                }
            }
            chatWindow.contactListBox.Update();
        }
    }
}

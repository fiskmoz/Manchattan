using SoftEngChatClient.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.Model
{
	class ContactsHandler
	{
		public event EventHandler UpdateContactList;
		private List<Contact> contactList;
		public List<string> offlineList { get; private set; }
		private List<string> onlineList;
		private FileManager fileManager;
        private string username;

		public bool hasOfflineList { get; private set; }
		private bool hasOnlineList;

		public ContactsHandler(FileManager fm)
		{
			hasOfflineList = false;
			hasOnlineList = false;
			contactList = new List<Contact>();
			onlineList = new List<string>();
			offlineList = new List<string>();
			fileManager = fm;
		}

		public void Subscribe(Messagehandler mh)
		{
			mh.IncommingOnlineList += new EventHandler(HandleOnlineList);
			mh.IncommingOfflineList += new EventHandler(HandleOfflineList);
			mh.IncommingUserStatus += new EventHandler(HandleContactUpdate);
		}

		private void HandleOfflineList(object sender, EventArgs e)
		{
			hasOfflineList = true;
			offlineList = ((OnlineList)e).onlineList;
		}

		private void HandleOnlineList(object sender, EventArgs e)
		{
			hasOnlineList = true;
			onlineList = ((OnlineList)e).onlineList;


			contactList.AddRange(CreateContactList()); //= CreateContactList();

			UpdateContactList(this, new ContactListEventArg(contactList));

		}
		private List<Contact> CreateContactList()
		{
            List<string> contacts = new List<string>();
            contacts = fileManager.ReadContacts();
            List<Contact> tempContactList = new List<Contact>();
			foreach(string contact in contacts)
			{
				tempContactList.Add(new Contact(contact, onlineList.Contains(contact)));
			}

			return tempContactList;
		}

		private void HandleContactUpdate(object sender, EventArgs e)
		{
			Contact updated = new Contact(((UserOnlineStatusUpdate)e).username, ((UserOnlineStatusUpdate)e).isOnline);

			UpdateOnlineOfflineLists(updated);
			UpdateContacts(updated);
		}

		private void UpdateOnlineOfflineLists(Contact updated)
		{
			if (onlineList.Contains(updated.name) && !(updated.isOnline))
			{
				onlineList.Remove(updated.name);
			}
			else if (offlineList.Contains(updated.name) && updated.isOnline)
			{
				onlineList.Add(updated.name);
			}
		}

		private void UpdateContacts(Contact updated)
		{
			foreach (Contact contact in contactList)
			{
				if (contact.name == updated.name)
				{
					contact.isOnline = updated.isOnline;
					break;
				}
			}

			UpdateContactList(this, new ContactListEventArg(contactList));
		}

        public void SaveContactList()
        {
            string contactListString = "";
            foreach(Contact contact in contactList)
            {
                contactListString += contact.name + ":";
            }
            if(contactListString != "")
                fileManager.WriteToFile(AppDomain.CurrentDomain.BaseDirectory + @"\" + ClientDriver.globalUsername + @"\Contacts.txt", contactListString);

			contactList.Clear();
        }

		public void AddContact(string username)
		{
			Contact contact = new Contact(username, onlineList.Contains(username));
			contactList.Add(contact);
			UpdateContacts(contact);
		}
	}
}

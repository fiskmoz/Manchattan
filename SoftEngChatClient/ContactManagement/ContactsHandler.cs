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
		}

		private void HandleOnlineList(object sender, EventArgs e)
		{
			hasOnlineList = true;
			onlineList = ((OnlineList)e).onlineList;
			contactList = CreateContactList();

			UpdateContactList(this, new ContactListEventArg(contactList));

		}

		private void HandleOfflineList(object sender, EventArgs e)
		{
			hasOfflineList = true;
			offlineList = ((OnlineList)e).onlineList;
		}

		private List<Contact> CreateContactList()
		{
			List<string> contacts = fileManager.ReadContacts();
			List<Contact> tempContactList = new List<Contact>();
			foreach(string contact in contacts)
			{
				tempContactList.Add(new Contact(contact, onlineList.Contains(contact)));
			}

			return tempContactList;

		}
	}
}

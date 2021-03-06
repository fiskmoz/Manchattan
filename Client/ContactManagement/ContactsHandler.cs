﻿using Client.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
	class ContactsHandler
	{
		public event EventHandler UpdateContactList;
		public List<Contact> contactList { get; private set; }
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
			mh.IncommingUserStatus += new EventHandler(HandleContactUpdate);
		}

		private void HandleOfflineList(object sender, EventArgs e)
		{
			offlineList = ((OnlineList)e).onlineList;
			foreach(Contact contact in contactList)
			{
				offlineList.Remove(contact.name);
			}
			offlineList.Remove(ClientDriver.globalUsername);
			hasOfflineList = true;
		}

		private void HandleOnlineList(object sender, EventArgs e)
		{
			
			onlineList = ((OnlineList)e).onlineList;
			contactList.AddRange(CreateContactList()); //= CreateContactList();
            fileManager.ReadStatusMessages(contactList);
			hasOnlineList = true;
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
			if (!(offlineList.Contains(updated.name)))
				offlineList.Add(updated.name);

			offlineList.Remove(ClientDriver.globalUsername);

			UpdateOnlineList(updated);
			UpdateContacts(updated);
		}

		private void UpdateOnlineList(Contact updated)
		{
			if (onlineList.Contains(updated.name) && !(updated.isOnline))
				onlineList.Remove(updated.name);

			else if (!(onlineList.Contains(updated.name)) && offlineList.Contains(updated.name))
					onlineList.Add(updated.name);
		}

		private void UpdateContacts(Contact updated)
		{
			foreach (Contact contact in contactList)
			{

				if (contact.name == updated.name)
				{
					offlineList.Remove(updated.name);
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

			
        }

        public void SaveStatusMessages()
        {
            string statusListString = "";
            foreach(var contact in contactList)
            {
                statusListString += contact.status + "§";
            }
            if(statusListString != "")
            {
                fileManager.WriteToFile(AppDomain.CurrentDomain.BaseDirectory + @"\" + ClientDriver.globalUsername + @"\StatusMessages.txt", statusListString);
            }
            contactList.Clear();
        }

		public void AddContact(string username)
		{
			Contact contact = new Contact(username, onlineList.Contains(username));
			contactList.Add(contact);
			UpdateContacts(contact);
		}

        public bool FindContact(string username)
        {
            foreach(Contact contact in contactList)
            {
                if(contact.name == username)
                {
                    return true;
                }
            }
            return false;
        }

        public Contact GetContact(string username)
        {
            foreach (Contact contact in contactList)
            {
                if (contact.name == username)
                {
                    return contact;
                }
            }
            return null;
        }

        public bool IsOnline(string username)
		{
			if (FindContact(username))
			{
				foreach(Contact contact in contactList)
				{
					if(contact.name == username)
						return contact.isOnline;
				}
			}
			return false;
		}
	}
}

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

		public ContactsHandler()
		{
			contactList = new List<Contact>();
		}

		public void Subscribe(Messagehandler mh)
		{
			mh.IncommingOnlineList += new EventHandler(HandleOnlineList);
		}

		private void HandleOnlineList(object sender, EventArgs e)
		{
			UpdateContactList(this, new ContactListEventArg(CreateContactList(((OnlineList)e).onlineList)));

		}

		private List<Contact> CreateContactList(List<string> onlineList)
		{
			foreach( string i in onlineList)
			{
				contactList.Add(new Contact(i, true));
			}

			return contactList;
		}
	}
}

using System;
using System.Collections.Generic;

namespace SoftEngChatClient.Model
{
	class ContactListEventArg : EventArgs
	{
		public List<Contact> contacts { get; private set; }
		public ContactListEventArg(List<Contact> contactList)
		{
			contacts = contactList;
		}
	}
}

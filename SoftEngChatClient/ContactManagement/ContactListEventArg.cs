using System;
using System.Collections.Generic;

namespace SoftEngChatClient.Model
{
	class ContactListEventArg : EventArgs
	{
		public List<Contact> contacts { get; set; }
		public ContactListEventArg(List<Contact> contactList)
		{
			contacts = contactList;
		}
	}
}

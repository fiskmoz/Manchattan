﻿namespace SoftEngChatClient.Model
{
	class Contact
	{
		public string name { get; private set; }
		public bool isOnline { get; private set; }

		public Contact(string name, bool isOnline)
		{
			this.name = name;
			this.isOnline = isOnline;
		}
	}
}

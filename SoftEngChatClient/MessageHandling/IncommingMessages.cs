using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient
{
	public enum MessageType
	{
		register = 0, // "0:username:mail:pass:name:surname"
		registerACK = 1, // "1:0/1"
		client = 2, // "2:sender:receiver:message"
		login = 3,  // "3:username:password"
		loginACK = 4,  // "4:0/1"
		logout = 5,  // "5: 1
		onlineList = 6,  // 6:1/0:A:B:C:D"
		onlineStatus = 9 // 9:1/0:username
	}

	class IncommingMessage : EventArgs
	{
		public string Message { get; set; }
		public IncommingMessage(string message)
		{
			Message = message;
		}
	}

	class RegAck : EventArgs
	{
		public bool message { get; private set; }

		public RegAck(bool ack)
		{
			message = ack;
		}
	}

	class ClientMessage : EventArgs
	{
		public string sender { get; private set; }
		public string receiver { get; private set; }
		public string message { get; private set; }

		public ClientMessage(string sender, string receiver, string message)
		{
			this.sender = sender;
			this.receiver = receiver;
			this.message = message;
		}

		public ClientMessage(string[] parsedMessage)
		{
			sender = parsedMessage[1];
			receiver = parsedMessage[2];
			message = parsedMessage[3];

		}
	}

	class OnlineList : EventArgs
	{
		public List<String> onlineList { get; private set; }

		public OnlineList(List<string> onlineList)
		{
			this.onlineList = onlineList;
		}
	}

	class UserOnlineStatusUpdate : EventArgs
	{
		public string username { get; private set; }
		public bool isOnline { get; private set; }
		public UserOnlineStatusUpdate(string username, bool isOnline)
		{
			this.username = username;
			this.isOnline = isOnline;
		}
	}

	class LoginAck : EventArgs
	{
		public bool message { get; private set; }

		public LoginAck(bool ack)
		{
			message = ack;
		}
	}
}

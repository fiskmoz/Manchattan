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
		logout = 5,  // "5:1
		onlineList = 6,  // 6:1/0:A:B:C:D"
        friendRequest = 7, // 7:sender:receiver
        friendReponse = 8, // 8:sender:receiver:0/1
		onlineStatus = 9, // 9:1/0:username
        establishP2P = 10, // 10:sender:receiver
        incommingP2P = 11, // 11:sender:port:key
        outgoingP2P = 12 //12:receiver:port:key
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

            if (parsedMessage.Length > 4)
            {
                for (int i = 4; i < parsedMessage.Length; i++)
                {
                    message += ":" + parsedMessage[i];
                }
            }
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

    //response from login. 1/0 plus user key.
	class LoginAck : EventArgs
	{
		public bool message { get; private set; }
        public string key { get; set; }

		public LoginAck(bool ack, string key)
		{
			message = ack;
            this.key = key;
		}

        public LoginAck(string v1, string v2)
        {
        }
    }

	class P2POutgoingConnection : EventArgs
	{
		public string receiver { get; private set; }
		public string ip { get; private set; }
		public int port { get; private set; }
		public string key { get; private set; }

        public int parsedPort;
		public P2POutgoingConnection(string[] incomming)
		{
			receiver = incomming[1];
			int.TryParse(incomming[2], out parsedPort);
			port = parsedPort;
			key = incomming[3];
			ip = Constants.ip;
		}
		public P2POutgoingConnection(string receiver, int port, string key, string ip = Constants.ip)
		{
			this.receiver = receiver;
			this.port = port;
			this.key = key;
			this.ip = ip;
		}
	}

	class P2PIncommingConnection : EventArgs
	{
		public string sender { get; private set; }
		public string ip { get; private set; }
		public int port { get; private set; }
		public string key { get; private set; }
        public int parsedPort;
        public P2PIncommingConnection(string[] incomming)
		{
			sender = incomming[1];
			int.TryParse(incomming[2], out parsedPort);
			port = parsedPort;
			key = incomming[3];
			ip = "127.0.0.1";
		}
	}

	class P2PDisconnect : EventArgs
	{
		public string sender { get; private set; }
		public P2PDisconnect(string[] incomming)
		{
			this.sender = incomming[2];
		}
		public P2PDisconnect(string sender)
		{
			this.sender = sender;
		}
	}
}

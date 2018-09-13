using System;
using System.Collections.Generic;
using System.Text;

namespace SoftEngChatClient.Model.SSLCommunication
{
	internal class Messagehandler
	{
		//Handles messages arriving at Client.
		//Eventhandler, Consumes IncommingMessage Events.
		internal void HandleIncommingMessage(object sender, IncommingMessage message)
		{
			string incomming = Encoding.UTF8.GetString(message.Message); //Encoding!

			if ( (int) incomming[0] == (int) MessageType.loginACK){
				//Raises event to inform client if the login was accepted by the server.
				RaiseEvent((int)incomming[1] == 0 ? false : true);
			}
			else if((int)incomming[0] == (int)MessageType.incommingClient)
			{
				ClientMessage(incomming);
			}
		}

		//Raises new event containing a message for the client
		private void ClientMessage(string incomming)
		{
			List<string> list = ParseIncomming(incomming);
			RaiseEvent(list[0], list[1]);
		}

		//Parses incomming client message
		private List<string> ParseIncomming(string incomming)
		{
			List<string> list = new List<string>();
			int i;
			string sender = null;
			string message = null;
			StringBuilder stringBuilder = new StringBuilder();
			for (i = 1; incomming[i] != ':'; i++)
			{
				sender += incomming[i];
			}
			for (int j = ++i; j < incomming.Length; j++)
			{
				message += incomming[j];
			}
			list.Add(sender);
			list.Add(message);

			return list;
		}

		public delegate void LoginEventHandler(Object sender, LoginValid eventArgs);
		public delegate void IncommingEventHandler(Object sender, ParsedIncommingMessage eventArgs);

		public event LoginEventHandler LoginValid;
		public event IncommingEventHandler ParsedIncommmingMessage;

		private void RaiseEvent(bool isValid)
		{
			LoginValid flag = new LoginValid();
			flag.isValid = isValid;
			LoginValid(this, flag);
		}

		private void RaiseEvent(string sender, string message)
		{
			ParsedIncommingMessage messageEvent = new ParsedIncommingMessage(sender, message);
			ParsedIncommmingMessage(this, messageEvent);
		}

	}

	class LoginValid : EventArgs
	{
		public bool isValid;
	}

	class ParsedIncommingMessage : EventArgs
	{

		public string sender;
		public string message;
		public ParsedIncommingMessage(string sender, string message)
		{
			this.sender = sender;
			this.message = message;
		}
	}
}
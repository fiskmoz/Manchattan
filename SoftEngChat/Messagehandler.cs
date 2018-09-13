using System;
using System.Text;

namespace SoftEngChat.Model.SSLCommunication
{
	internal class Messagehandler
	{
		private string userName;
		private SSLServer server;
		private SSLClient client;

		//Handles messages arriving at server.
		public Messagehandler(string userName, SSLServer server, SSLClient client)
		{
			this.userName = userName;
			this.server = server;
			this.client = client;
		}

		//Eventhandler, Consumes IncommingMessage Events.
		internal void HandleMessage(object sender, IncommingMessage message)
		{
			if(message.Message == null) //Error when event was raised.
			{
				Console.WriteLine("ERROR: Event for incomming message was raised but no message arrived.");
				return;
			}

			string incomming = Encoding.UTF8.GetString(message.Message); //Encoding!

            Console.WriteLine("" + incomming);

			switch (incomming[0])//Handle different message types (temporary placeholders here)
			{
				case '0':
					Console.WriteLine("Message arrived; Clientmessage:");
					Console.WriteLine(incomming);
					HandleClientMessage(incomming);
					break;
				case '1':
					Console.WriteLine("Message arrived; Login username:");
					Console.WriteLine(incomming);
					break;
				case '2':
					Console.WriteLine("Message arrived; Login password:");
					Console.WriteLine(incomming);
					break;
				case '3':
					Console.WriteLine("Message arrived; Credentials:");
					Console.WriteLine(incomming);
					HandleLogin(incomming);
					break;
				default:
					Console.WriteLine("Message arrived; Error:");
					Console.WriteLine(incomming);
					break;
			}
			
		}

		private void HandleClientMessage(string incomming)
		{
			server.WriteAll(userName, ParseClientMessage(incomming));
		}

		private string ParseClientMessage(string message)
		{
			int i = 0;
			string payload = null;
			do
			{
				i++;
			} while (message[i-1] != ':');

			while (i < message.Length)
			{
				payload += message[i];
			}
			return payload;
		}

		private void HandleLogin(string incomming)
		{
			bool valid = ValidateLoginMessage(incomming);
			client.writer.WriteLoginACK(valid?1:0);

			if (!valid)
			{
				server.RemoveClient(client);
			}
		}

		private bool ValidateLoginMessage(string message)
		{
			int i = 2;
			string username = null;
			string password = null;
			
			while(message[i] != ':')
			{
				username += message[i];
				i++;
			}

			while (i < message.Length)
			{
				password += message[i];
				i++;
			}

			return true;
		}
	}
}
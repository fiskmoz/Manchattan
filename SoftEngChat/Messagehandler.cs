using System;
using System.Collections.Generic;
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
            string incomming = message.Message;

			switch (incomming[0])//Handle different message types (temporary placeholders here)
			{
				case '0':
                    Console.WriteLine("Message arrived; Register Attempt:");
                    Console.WriteLine(incomming);
                    HandleRegistration(incomming);
					break;
				case '1':
                    Console.WriteLine("Message arrived; Register ACK:");
                    Console.WriteLine(incomming);
					break;
				case '2':
                    Console.WriteLine("Message arrived; Clientmessage:");
					Console.WriteLine(incomming);
                    HandleClientMessage(incomming);
                    break;
				case '3':
					Console.WriteLine("Message arrived; Credentials:");
					Console.WriteLine(incomming);
					HandleLogin(incomming);
					break;
                case '4':
                    Console.WriteLine("Message arrived; Login ACK:");
                    Console.WriteLine(incomming);
                    break;
                case '5':
                    Console.WriteLine("Message arrived; Logout Message:");
                    Console.WriteLine(incomming);
					HandleLogout();
					break;
                case '6':
                    Console.WriteLine("Message arrived; OnlineList:");
                    Console.WriteLine(incomming);
                    break;
                default:
					Console.WriteLine("Message arrived; Error:");
					Console.WriteLine(incomming);
					HandleLogout();
					break;
			}
			
		}

		private void HandleClientMessage(string incomming)
		{
            string[] parsed = ParseMessage(incomming);
            string sender = parsed[1];
            string receiver = parsed[2];
            string message = parsed[3];
            if (receiver == "All")
            {
                server.WriteAll(sender, message);
            }
            else
            {
                server.WriteIndivualMessage(sender, receiver, message);
            }
			
		}


		private void HandleLogin(string incomming)
		{
			bool valid = ValidateLoginMessage(incomming);
            client.writer.WriteLoginACK(valid ? 1 : 0);
			if(valid) server.SendOnlineListToAllClient();
			
		}

		private bool ValidateLoginMessage(string message)
		{
			int i = 2;
			string username = null;
			string password = null;
           // string mail = null;
			
			while(message[i] != ':')
			{
				username += message[i];
				i++;
			}
            i++;
			while (i < message.Length)
			{
				password += message[i];
				i++;
			}

            if((server.userManager.ValidateUser(username, password)) && server.IsUserOnline(username)==false)
            {
                userName = username;
                client.updateUserInfo(username, "emailPH", password);
                return true;
            }else
            {
                return false;
            }
		}
		
		private void HandleRegistration(string incomming)
		{
			List<string> user = new List<string>(ParseMessage(incomming));

			user.RemoveAt(0);
			bool regFlag = server.userManager.AddUser(user);

			client.writer.WriteRegAck(regFlag);
		}

		private string[] ParseMessage(string incomming)
		{
			string[] messageArray;

			messageArray = incomming.Split(':');

			return messageArray;
		}

		private void HandleLogout()
		{
			client.listener.StopListen();
			server.RemoveClient(client);
		}
	}
}
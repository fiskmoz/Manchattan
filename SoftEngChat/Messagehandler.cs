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
		private UserManager userManager;

		//Handles messages arriving at server.
		public Messagehandler(string userName, SSLServer server, SSLClient client)
		{
			this.userName = userName;
			this.server = server;
			this.client = client;
			userManager = new UserManager();
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
                    break;
                case '6':
                    Console.WriteLine("Message arrived; OnlineList:");
                    Console.WriteLine(incomming);
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
			int i = 2;
			string payload = null;
			do
			{
				i++;
			} while (message[i-1] != ':');

			while (i < message.Length)
			{
				payload += message[i++];
			}
            Console.WriteLine("Parsed message : " + payload);
			return payload;
		}

		private void HandleLogin(string incomming)
		{
			bool valid = ValidateLoginMessage(incomming);
            client.writer.WriteLoginACK(valid ? 1 : 0);
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
            i++;
			while (i < message.Length)
			{
				password += message[i];
				i++;
			}

            if(userManager.validateUser(username, password))
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
			List<string> user = new List<string>(ParseRegistration(incomming));

			user.RemoveAt(0);
			bool regFlag = userManager.AddUser(user);
			client.writer.WriteRegAck(regFlag);
		}

		private string[] ParseRegistration(string incomming)
		{
			string[] userInfo;

			userInfo = incomming.Split(':');

			return userInfo;
		}
	}
}
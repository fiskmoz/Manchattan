using System;
using System.Collections.Generic;

namespace SoftEngChat.Model.SSLCommunication
{
    internal class Messagehandler
	{
		private SSLServer server;
		private SSLClient client;


		//Handles messages arriving at server.
		public Messagehandler(string userName, SSLServer server, SSLClient client)
		{
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
                case '7':
                    Console.WriteLine("Message arrived; FriendRequest:");
                    Console.WriteLine(incomming);
                    HandleFriendRequest(incomming);
                    break;
                case '8':
                    Console.WriteLine("Message arrived; FriendRespond ACK");
                    Console.WriteLine(incomming);
                    ValidateFriendResponse(incomming);
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
                server.SendMessageAll(sender, message);
            }
            else
            {
                server.SendIndivualMessage(incomming, sender, receiver, message);
            }
			
		}


		private void HandleLogin(string incomming)
		{
            string[] messageArray = ParseMessage(incomming);
            string username = messageArray[1];
            string password = messageArray[2];
            bool valid = ValidateLoginMessage(username, password);
            if (valid)
            {
                client.writer.WriteLoginACK(valid ? 1 : 0, username);
                server.UserLogin(username);
            }
		}

        //IN:   Login message
        //OUT:  True if username and password is correct and user not already logged in.
        //      False otherwise
		private bool ValidateLoginMessage(string username, string password)
		{
            if((server.userManager.ValidateUser(username, password)) && server.IsUserOnline(username)==false)
            {
                client.userName = username;
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
            if(regFlag)
            {
                server.everyRegisteredUserList.Add(user[1]);
                server.UpdateOfflineList();
            }
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
            if(client.userName != null) // IF USER LOGGED IN
            server.UpdateUserClientList(client.userName.ToString(), true);
            server.RemoveClient(client);
            
		}

        private void HandleFriendRequest(string incomming)
        {
            string[] messageArray = ParseMessage(incomming);
            string sender = messageArray[1];
            string receiver = messageArray[2];
            server.SendFriendRequest(incomming, sender, receiver);
        }

        private void ValidateFriendResponse(string incomming)
        {
            string[] messageArray = ParseMessage(incomming);
            //Opposite sender of friendrequest becomes the reciver.

            string sender = messageArray[1];
            string receiver = messageArray[2];
            int answer;
            if(Int32.TryParse(messageArray[3], out answer))           
                server.SendFriendResponse(incomming, sender, receiver, answer);
        }
	}
}
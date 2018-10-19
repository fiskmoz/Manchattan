using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace SoftEngChat.Model.SSLCommunication
{
    //Server driving object. Opens SSL Stream for clients to connect.
    class SSLServer
	{
		private List<SSLClient> clientList;
		private TcpListener serverListener;
        public UserManager userManager;
        public int sessionIDCounter = 0;
        private int nextPort = 21000;

        public List<string> everyRegisteredUserList;
        public List<string> allOnlineusers;

        private string onlineListAsString;
        private string offlineListAsString;

		public SSLServer(IPAddress ip, int port)
		{
			X509Certificate2 cert = new X509Certificate2("servercert.pfx", "keypw");
			clientList = new List<SSLClient>();
			serverListener = new TcpListener(ip, port);
			serverListener.Start();
            userManager = new UserManager();
            everyRegisteredUserList = new List<string>();
            allOnlineusers = new List<string>();
            userManager.SetListOfAllClients(everyRegisteredUserList);
			while (true)
			{
				Console.WriteLine("Listening for connections....");
				var client = serverListener.AcceptTcpClient(); //Client connects!
				NetworkStream netStream = client.GetStream();
				var ssl = new SslStream(netStream, false);
				try
				{
					ssl.AuthenticateAsServer(cert, false, SslProtocols.Tls, true); //Server Authentication
				}
				catch(Exception e)
				{
					Console.WriteLine("Exception: {0}", e.Message);
					if (e.InnerException != null)
					{
						Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
					}

					Console.WriteLine("Authentication failed - closing the connection.");
					client.Close();
					Console.ReadLine();
				}
                string ipAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
				clientList.Add(new SSLClient(ssl, this, ++sessionIDCounter, ipAddress)); //Client added to list!
				Console.Write("Client connected! IP: ");
                Console.WriteLine(ipAddress);
            }
		}

        public void UserLogin(string username)
        {
            UpdateOnlineList();
            UpdateOfflineList();
            SendListsToClient(username);
            UpdateUserClientList(username, false);

            var Receiver = FindClient(username);
            if(Receiver != null)
            {
                Thread.Sleep(2000);
                var offlineMessageList = userManager.FindUser(username).waitingMessages;
                foreach(var message in offlineMessageList)
                {
                    string[] messageArray;
                    messageArray = message.Split(':');
                    if (messageArray.Length > 4)
                    {
                        for (int i = 4; i < messageArray.Length; i++)
                        {
                            messageArray[3] += ":" + messageArray[i];
                        }
                    }
                    switch (messageArray[0])
                    {
                        case "2":
                            Receiver.writer.WriteClient(MessageType.client, messageArray[1], messageArray[2], messageArray[3]);
                            break;
                        case "7":
                            Receiver.writer.WriteFriendRequest(messageArray[1], messageArray[2]);
                            break;
                        case "8":
                            Receiver.writer.WriteFriendResponse(messageArray[1], messageArray[2], Convert.ToInt32(messageArray[3]));
                            break;
                    }
                }
                userManager.FindUser(username).waitingMessages.Clear();
            }
        }

        public void SendListsToClient(string username)
        {
			Thread.BeginCriticalRegion();

			lock (clientList)
			{
				foreach (SSLClient client in clientList)
				{
                    if (client.userName == username && client.userName != null)
                    {
                        client.writer.WriteOnlineList(onlineListAsString);
                        client.writer.WriteOnlineList(offlineListAsString);
                    }
				}
			}
            

			Thread.EndCriticalRegion();
        }
        
        public bool IsUserOnline(string username)
        {
            foreach (var client in clientList)
            {
                if (client.userName == username)
                {
                    return true;
                }
            }
            return false;
        }

		//Send messages to all clients (IRC) but sender.
		//IN: Username of client who sent message and the actual message.
		public void SendMessageAll(string sender, string message)
		{
            foreach ( var client in clientList)
			{
				//let each client handle it themselves
				if(client.userName != sender && client.userName != null)
				{
                    client.writer.WriteClient(MessageType.client, sender, "All", message);
                }
			}
		}

        public void SendIndivualMessage(string entireMessage, string sender, string receiver, string message)
        {
            var Receiver = FindClient(receiver);
            if (Receiver != null)
            {
                Receiver.writer.WriteClient(MessageType.client, sender, receiver, message);
            }
            else
            {
                userManager.FindUser(receiver).waitingMessages.Add(entireMessage);
                Console.WriteLine("Receiver was offline message was stored");
            }
        }

        
        public void SendFriendResponse(string entireMessage, string sender, string receiver, int answer)
        {
            var Receiver = FindClient(receiver);
            if (Receiver != null)
            {
                Receiver.writer.WriteFriendResponse(sender, receiver, answer);
            }
            else
            {
                userManager.FindUser(receiver).waitingMessages.Add(entireMessage);
                Console.WriteLine("Receiver was offline message was stored");
            }
        }


        public void SendFriendRequest(string entireMessage, string sender, string receiver)
        {
            var Receiver = FindClient(receiver);
            if (Receiver != null)
            {
                Receiver.writer.WriteFriendRequest(sender, receiver);
            }
            else
            {
                userManager.FindUser(receiver).waitingMessages.Add(entireMessage);
                Console.WriteLine("Receiver was offline message was stored");
            }
        }

        internal void RemoveClient(SSLClient client)
		{
			Thread.BeginCriticalRegion();

			lock (clientList)
			{
				client.Dispose();
				clientList.Remove(client);
			}
			
			Thread.EndCriticalRegion();
		}

        public void UpdateUserClientList(string clientGoingOffline, bool goingOffline)
        {
            foreach(var client in clientList)
            {
                if(allOnlineusers.Contains(client.userName))
                {
                    client.writer.WriteOnlineListUpdate(clientGoingOffline, goingOffline);
                }
            }
        }

        public void UpdateOnlineList()
        {
            StringBuilder str = new StringBuilder();
            str.Append((int)MessageType.onlineList + ":1");
            foreach (SSLClient client in clientList)
            {
                // If client has yet to log in, do not send.
                if (client.userName != null)
                {
                    str.Append(":" + client.userName);
                    allOnlineusers.Add(client.userName);
                }
            }
            onlineListAsString = str.ToString();
        }
        public void UpdateOfflineList()
        {
            //userManager.SetListOfAllClients(everyRegisteredUserList);
            StringBuilder str = new StringBuilder();
            str.Append((int)MessageType.onlineList + ":0");
            foreach (string String in everyRegisteredUserList)
            {
                str.Append(":" + String);
            }
            offlineListAsString = str.ToString();
        }

        public SSLClient FindClient(string username)
        {
            foreach(SSLClient client in clientList)
            {
                if (client.userName == username)
                {
                    return client;
                }
            }
            return null;
        }

        public void SendIncommingP2P(string sender, string receiver, int port, string key, string ip)
        {
            SSLClient receiverClient = FindClient(receiver);
            if(receiverClient != null)
            {
                receiverClient.writer.WriteIncommingP2P(sender, port, key, ip);
            }
            else
            {
                Console.WriteLine("Error: Receiving client not in ClientList");
            }
        }

        public int getNextPort()
        {
            return nextPort++;
        }

        public void SendSatusUpdate(string sender, string receiver, string statusUpdate)
        {
            FindClient(receiver).writer.WriteStatusMessage(sender, reciver, statusUpdate);
        }
    }
}

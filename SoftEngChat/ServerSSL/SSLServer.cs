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

        public List<string> everyRegisteredUserList;
        public List<string> allOnlineusers;

        private string onlineListAsString;


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
				clientList.Add(new SSLClient(ssl, this, ++sessionIDCounter)); //Client added to list!
				Console.WriteLine("Client connected!");
			}
		}

        public void SendOnlineListToClient(string username)
        {
			Thread.BeginCriticalRegion();

			lock (clientList)
			{
				foreach (SSLClient client in clientList)
				{
                    if (client.userName == username || client.userName != null)
                    {
                        client.writer.WriteOnlineList(onlineListAsString);
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

        public void SendIndivualMessage(string sender, string receiver, string message)
        {
            foreach (var client in clientList)
            {
                if(client.userName == receiver)
                {
                    client.writer.WriteClient(MessageType.client, sender, receiver, message);
                    return;
                }
            }
        }

        
        public void SendFriendResponse(string sender, string receiver, int answer)
        {
           foreach (var client in clientList)
            {
                if(client.userName == receiver)
                {
                    client.writer.WriteFriendResponse(sender, receiver, answer);
                    return;
                }
            }
        }


        public void SendFriendRequest(string sender, string receiver)
        {
            foreach (var client in clientList)
            {
                if (client.userName == receiver)
                {
                    client.writer.WriteFriendRequest(sender, receiver);
                    return;
                }
            }
        }

        internal void RemoveClient(SSLClient client)
		{
			Thread.BeginCriticalRegion();

			lock (clientList)
			{
				client.Dispose();
				clientList.Remove(client);
				SendStatusUpdateToClients();
			}
			
			Thread.EndCriticalRegion();
		}

        public void UpdateUserClientList(string clientGoingOffline, bool goingOffline)
        {
            foreach(var client in clientList)
            {
                client.writer.WriteOnlineListUpdate(clientGoingOffline, goingOffline);
            }
        }

        public void SendStatusUpdateToClients()
        {

        }

        public void UpdateOnlineList()
        {
            StringBuilder str = new StringBuilder();
            str.Append((int)MessageType.onlineList);
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
    }
}

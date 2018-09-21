using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChat.Model.SSLCommunication
{
	//Server driving object. Opens SSL Stream for clients to connect.
	class SSLServer
	{
		private List<SSLClient> clientList;
		private TcpListener serverListener;
        public UserManager userManager;
        public int sessionIDCounter = 0;


		public SSLServer(IPAddress ip, int port)
		{
			X509Certificate2 cert = new X509Certificate2("servercert.pfx", "keypw");
			clientList = new List<SSLClient>();
			serverListener = new TcpListener(ip, port);
			serverListener.Start();
            userManager = new UserManager();
            

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

        public void SendOnlineListToAllClient()
        {
            StringBuilder str = new StringBuilder();
            str.Append((int)MessageType.onlineList);
            foreach (SSLClient client in clientList)
            {
                // If client has yet to log in, do not send.
                if(client.getUserName() != "User")
                {
                    str.Append(":" + client.getUserName());
                }
            }
            foreach (SSLClient client in clientList)
            {
                client.writer.WriteOnlineList(str.ToString());
            }
        }
        
        public bool IsUserOnline(string username)
        {
            foreach (var client in clientList)
            {
                if (client.getUserName()==username)
                {
                    return true;
                }
            }
            return false;
        }

		//Send messages to all clients (IRC) but sender.
		//IN: Username of client who sent message and the actual message.
		public void WriteAll(string sender, string message)
		{
            foreach ( var client in clientList)
			{
				//let each client handle it themselves
				if(client.UserInfo.UserName != sender)
				{
                    if (client.getUserName() != "User" || client.getUserName() != sender)
                    {
                        client.writer.WriteClient(MessageType.client, sender, "All", message);
                    }
                }
			}
		}

        public void WriteIndivualMessage(string sender, string receiver, string message)
        {
            foreach (var client in clientList)
            {
                if(client.UserInfo.UserName == receiver)
                {
                    client.writer.WriteClient(MessageType.client, sender, receiver, message);
                    return;
                }
            }
        }

		internal void RemoveClient(SSLClient client)
		{
			clientList.Remove(client);
		}
	}
}

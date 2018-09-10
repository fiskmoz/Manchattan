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
		private string lastMessage;
		private string lastSender;

		public SSLServer(IPAddress ip, int port)
		{
			X509Certificate2 cert = new X509Certificate2("server.crt", "keypw");
			clientList = new List<SSLClient>();
			serverListener = new TcpListener(ip, port);
			serverListener.Start();

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
				clientList.Add(new SSLClient(ssl, this)); //Client added to list!
				Console.WriteLine("Client connected!");
			}
		}

		//Send messages to all clients (IRC) but sender.
		//IN: Username of client who sent message and the actual message.
		public void WriteAll(string sender, string message)
		{
			lastMessage = message;
			lastSender = sender;
			foreach( var client in clientList)
			{
				//let each client handle it themselves
				if(client.UserInfo.name != sender)
				{
					Thread messenger = new Thread(() => Write(client));
					messenger.Start();
				}
			}
		}

		//Writes latest message arrived at server to a client
		//IN: Client who shall receive message.
		private void Write(SSLClient client)
		{
			client.writer.Write(lastMessage, lastSender);
		}
	}
}

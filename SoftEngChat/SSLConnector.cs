using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat.Model.SSLCommunication
{
	class SSLConnector
	{
		private List<SSLClient> clientList;
		private TcpListener serverListener;

		public SSLConnector(IPAddress ip, int port)
		{
			X509Certificate2 cert = new X509Certificate2();
			clientList = new List<SSLClient>();
			serverListener = new TcpListener(ip, port);
			while (true)
			{
				var client = serverListener.AcceptTcpClient();
				NetworkStream netStream = client.GetStream();
				var ssl = new SslStream(netStream, false);
				//ssl.AuthenticateAsServer()
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.Model.SSLCommunication
{
	// Establishes encrypted (SSL) connection with server.
	class SSLConnector
	{
		private TcpClient client;
		private NetworkStream netStream;
		public SslStream SslStream { get; private set; }

		public SSLConnector(string ip, int port)
		{
			try
			{

				client = new TcpClient(ip, port);
			}
			catch(Exception e)
			{
				return;
			}
			//Client connected

			netStream = client.GetStream();
			SslStream = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));

			try
			{
				SslStream.AuthenticateAsClient("Manchattan");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: {0}", e.Message);
				if (e.InnerException != null)
				{
					Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
				}

				Console.WriteLine("Authentication failed - closing the connection.");
				client.Close();
				return;
			}

		}

		private static bool ValidateCert(object sender, X509Certificate certificate,
										X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{/*
			if (sslPolicyErrors == SslPolicyErrors.None) return true;
			return false;
		*/
			return true;
		}
		
	}
}

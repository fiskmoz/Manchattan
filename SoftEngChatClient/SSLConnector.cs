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
		private const int RECONNECT_TIME = 1000; //Time in miliseconds to wait before trying to connect to server again.
		private const int MAX_RECONNECT_TRIES = 60; //maximal nuber of tries to connect to the server.

		public SslStream SslStream { get; private set; }

		public SSLConnector(string ip, int port)
		{
			int retryAttempts = 1;
			do
			{
				try
				{
					client = new TcpClient(ip, port);
					break;
				}
				catch (Exception)
				{
					//Client connected
					System.Threading.Thread.Sleep(RECONNECT_TIME); //Wait 1second before trying again.
					retryAttempts += 1;
				}
			}while(retryAttempts < MAX_RECONNECT_TRIES);
			if (retryAttempts >= MAX_RECONNECT_TRIES) return;

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

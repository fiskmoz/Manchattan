using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEngChatClient.Model.SSLCommunication
{
	// Establishes encrypted (SSL) connection with server.
	class SSLConnector
	{
		private TcpClient client;
		private NetworkStream netStream;
		private const int RECONNECT_TIME = 1000; //Time in miliseconds to wait before trying to connect to server again.
		private const int MAX_RECONNECT_TRIES = 10; //maximal nuber of tries to connect to the server.

		public SslStream SslStream { get; private set; }

		public SSLConnector(string ip, int port)
		{
			int retryAttempts = 1;
			do
			{
				try
				{
					client = new TcpClient(ip, port);
					//Client connected
					break;
				}
				catch (Exception)
				{
					System.Threading.Thread.Sleep(RECONNECT_TIME); //Wait 1second before trying again.
					retryAttempts += 1;
					//Will in future sprint raise event each time to tell that server can't be reached.
				}
			}while(retryAttempts < MAX_RECONNECT_TRIES);
			if (retryAttempts >= MAX_RECONNECT_TRIES) Environment.Exit(0); //Closes down if timed out! Will in future sprint rais event.

			//Encrypt connection
			netStream = client.GetStream();
			SslStream = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));

			try
			{
				SslStream.AuthenticateAsClient("Manchattan"); //Authenticate server.
			}
			catch (Exception)
			{
				//  !!!Authentication failed!!!
				client.Close(); //Close connection
				return; //Raise event in future sprint!
			}

		}

		private static bool ValidateCert(object sender, X509Certificate certificate,
										X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if (sslPolicyErrors == SslPolicyErrors.None) return true;
			return false;
		
			//return true;
		}
		
	}
}

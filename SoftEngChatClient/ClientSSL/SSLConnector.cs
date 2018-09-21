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
		private const int RECONNECT_TIME = 1000;
		private const int MAX_RECONNECT_TRIES = 10;
		private string serverIP;
		private int serverPort;
		public SslStream SslStream { get; private set; }

		public SSLConnector(string ip, int port)
		{
			serverIP = ip;
			serverPort = port;
		}

		internal void Connect()
		{
			int retryAttempts = 1;
			do
			{
				try
				{
					client = new TcpClient(serverIP, serverPort);
					break;
				}
				catch (Exception)
				{
					System.Threading.Thread.Sleep(RECONNECT_TIME);
					retryAttempts += 1;
				}
			} while (retryAttempts < MAX_RECONNECT_TRIES);
			if (retryAttempts >= MAX_RECONNECT_TRIES) Environment.Exit(0);
			EncryptConnection();
		}

		private void EncryptConnection()
		{
			netStream = client.GetStream();
			SslStream = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));

			try
			{
				SslStream.AuthenticateAsClient("Manchattan");
			}
			catch (Exception)
			{
				client.Close();
				return;
			}
		}

		private static bool ValidateCert(object sender, X509Certificate certificate,
										X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			//Since cert. is self-signed standard validation code won't accept it.
			return true;
		}
	}
}

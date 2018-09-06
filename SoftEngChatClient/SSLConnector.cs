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
	class SSLConnector
	{
		public SSLListener sslListener {private get; private set; ;
		public SSLWriter sslWriter { private get; private set; }
		private TcpClient client;
		private NetworkStream netStream;
		private SslStream sslStream;

		public SSLConnector(string ip, int port)
		{
			client = new TcpClient(ip, port);
			//Client connected

			netStream = client.GetStream();
			sslStream = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));

			try
			{
				sslStream.AuthenticateAsClient(ip);
			}
			catch (AuthenticationException e)
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
			sslListener = new SSLListener(sslStream);
			sslWriter = new SSLWriter(sslStream);

		}

		private static bool ValidateCert(object sender, X509Certificate certificate,
										X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if (sslPolicyErrors == SslPolicyErrors.None) return true;
			return false;
		}

	}
}

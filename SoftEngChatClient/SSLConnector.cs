using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.Model.SSLCommunication
{
	class SSLConnector
	{
		private SSLListener sslListener;
		private SSLWriter sSLWriter;
		private TcpClient client;
		private NetworkStream netStream;
		private SslStream sslStream;

		public SSLConnector(string ip, int port)
		{
			client = new TcpClient(ip, port);
			netStream = client.GetStream();
			sslStream = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));
		}

		private static bool ValidateCert(object sender, X509Certificate certificate,
										X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true; //Will be changed
		}

	}
}

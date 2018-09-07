using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChat.Model.SSLCommunication
{
	class SSLWriter
	{
		private SslStream stream;
		private SSLConnector server;
		public SSLWriter(SslStream stream, SSLConnector server)
		{

		}
		public void Write(string message, string sender)
		{
			stream.Write(Encoding.UTF8.GetBytes(sender + "@"+ message));
		}
	}
}

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
		private SSLServer server;

		public SSLWriter(SslStream stream, SSLServer server)
		{
			this.stream = stream;
			this.server = server;
		}

		//Sends a message to the client the writer belongs to.
		//In: Outgoing message, sender of the message.
		public void Write(string message, string sender)
		{
			stream.Write(Encoding.UTF8.GetBytes("5:" + sender + ":"+ message));
		}
		public void WriteLoginACK(int flag)
		{
			stream.Write(Encoding.UTF8.GetBytes("4" + flag.ToString()));
		}
	}
}

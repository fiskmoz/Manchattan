using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.Model.SSLCommunication
{
	class SSLWriter
	{
		protected enum MessageType { loginUserName=0, loginUserPassword=1, client=2}
		public SSLWriter(SslStream stream)
		{

		}

		public void Write(string message, MessageType type)
		{
			string outgoing = BuildMessage(type, message);
			SendMessage(outgoing);
		}

		public void Write(string message, string client)
		{
			string outgoing = BuildMessage(MessageType.client, client, message);
			SendMessage(outgoing);
		}

		private string BuildMessage(MessageType type, string client, string message)
		{
			string outgoing = type + "@" + client + ":" + message;
			return outgoing;
		}

		private string BuildMessage(MessageType type, string message)
		{
			string outgoing = type + ":" + message;
		}

		private void SendMessage(string outgoing)
		{

		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngChatClient.MessageHandling
{
	interface StreamWriter
	{
		void WriteClient(MessageType type, string sender, string receiver, string message);
		void SendMessage(string outgoing);
		void WriteLogout(MessageType type);
	}
}

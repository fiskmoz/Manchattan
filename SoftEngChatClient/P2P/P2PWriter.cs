using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SoftEngChatClient.MessageHandling;
using SoftEngChatClient.Controller;

namespace SoftEngChatClient.P2P
{
    class P2PWriter : StreamWriter
    {
        NetworkStream netStream;
        public P2PWriter(NetworkStream netStream)
        {
            this.netStream = netStream;
        }

		public void WriteClient(MessageType type, string sender, string receiver, string message)
		{
			string outgoing = ((int)type).ToString() + ":" + sender + ":" + receiver + ":" + message;
			SendMessage(outgoing);
		}

		public void SendMessage(string outgoing)
		{
			byte[] outgoingBytes = Encoding.UTF8.GetBytes(outgoing);
			netStream.Write(outgoingBytes, 0, outgoingBytes.Length);
		}

		public void WriteLogout(MessageType type)
		{
			string outgoing = ((int)type).ToString() + ":1:" + ClientDriver.globalUsername;
			SendMessage(outgoing);
		}
	}
}

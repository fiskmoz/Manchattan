using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SoftEngChatClient.MessageHandling;

namespace SoftEngChatClient.P2P
{
    class P2PWriter : StreamWriter
    {
        NetworkStream netStream;
        private ClientCrypto cc;

        public P2PWriter(NetworkStream netStream, byte[] key)
        {
            this.netStream = netStream;
            cc = new ClientCrypto();
            cc.SetNewKey(key);
        }

		public void WriteClient(MessageType type, string sender, string receiver, string message)
		{
            byte[] cipher = cc.EncryptString(message);
            string encryptedMessage = BitConverter.ToString(cipher).Replace("-", "");
            string outgoing = ((int)type).ToString() + ":" + sender + ":" + receiver + ":" + encryptedMessage;
			SendMessage(outgoing);
		}

		public void SendMessage(string outgoing)
		{
			byte[] outgoingBytes = Encoding.UTF8.GetBytes(outgoing);
			netStream.Write(outgoingBytes, 0, outgoingBytes.Length);
		}
	}
}

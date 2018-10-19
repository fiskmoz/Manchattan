using SoftEngChatClient.Controller;
using SoftEngChatClient.MessageHandling;
using System;
using System.Net.Sockets;
using System.Text;

namespace SoftEngChatClient.P2P
{
	class P2PWriter : CustomStreamWriter
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

		public void WriteSendFileRequest(MessageType type, string sender, string receiver, int packageSize, string filename)
		{
			string outgoing= ((int)type).ToString() + ":" + sender + ":" + receiver +":"+packageSize +":"+filename;
			SendMessage(outgoing);
		}

		public void WriteLogout(MessageType type)
		{
			string outgoing = ((int)type).ToString() + ":1:" + ClientDriver.globalUsername;
			SendMessage(outgoing);
		}

		public void SendFile(byte[] package)
		{
			int bytesSent = 0;
			int bytesLeft = package.Length;

			while(bytesLeft > 0)
			{
				int nextPacketSize = (bytesLeft > bytesSent) ? 2048 : bytesLeft;

				netStream.Write(package, bytesSent, nextPacketSize);
				bytesSent += nextPacketSize;
				bytesLeft -= nextPacketSize;
			}
		}

		internal void WriteFileResponse(MessageType type, string sender, string receiver, bool accept)
		{
			byte[] cipher = cc.EncryptString(accept?"1":"0");
			string encryptedMessage = BitConverter.ToString(cipher).Replace("-", "");
			string outgoing = ((int)type).ToString() + ":" + sender + ":" + receiver + ":" + encryptedMessage;
			SendMessage(outgoing);
		}
	}
}

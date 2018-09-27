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
        public SslStream stream;
		public SSLWriter(SslStream stream)
		{
			this.stream = stream;
		}

        public void WriteRegister(MessageType type, string username, string mail, string password, string name, string surname)
        {
            string outgoing = ((int)type).ToString() + ":" + username + ":" + mail + ":" + password + ":" + name + ":" + surname;
            SendMessage(outgoing);
        }

        public void WriteClient(MessageType type, string sender, string receiver, string message)
        {
            string outgoing = ((int)type).ToString() + ":" + sender + ":" + receiver + ":" + message;
            SendMessage(outgoing);
        }

        public void WriteLogin(MessageType type, string username, string password)
        {
            string outgoing = ((int)type).ToString() + ":" + username + ":" + password;
            SendMessage(outgoing);
        }

        public void WriteLogout(MessageType type)
        {
            string outgoing = ((int)type).ToString() + ":1";
            SendMessage(outgoing);
        }

		private void SendMessage(string outgoing)
		{
            byte[] outgoingBytes = Encoding.UTF8.GetBytes(outgoing);
            stream.Write(outgoingBytes, 0, outgoingBytes.Length);
		}
	}
}

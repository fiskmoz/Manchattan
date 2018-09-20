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
        private SslStream stream;
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
        /*
		public void Write(string userName, string password, MessageType login)
		{
            string outgoing = BuildMessage(login, userName , password);
            SendMessage(outgoing);
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
			string outgoing = ((int)type).ToString() + ":" + client + ":" + message;
			return outgoing;
		}

		private string BuildMessage(MessageType type, string message)
		{
			string outgoing = ((int)type).ToString() + ":" + message;
			return outgoing;
		}*/

		private void SendMessage(string outgoing)
		{
			stream.Write(Encoding.UTF8.GetBytes(outgoing), 0, outgoing.Length);
		}
	}
}

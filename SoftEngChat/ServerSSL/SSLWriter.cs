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

        public void WriteRegACK(MessageType type, int flag)
        {
            string isValid = flag == 0 ? "0" : "1";
            stream.Write(Encoding.UTF8.GetBytes(((int)type).ToString() + ":" + isValid));
            Console.WriteLine("Registration is: " + isValid);
        }

		//Sends a message to the client the writer belongs to.
		//In: Outgoing message, sender of the message.
		public void WriteClient(MessageType type,string sender, string receiver, string message)
		{
            string outgoing = ((int)type).ToString() + ":" + sender + ":" + receiver + ":" + message;
            stream.Write(Encoding.UTF8.GetBytes(outgoing));

        }
        public void WriteLoginACK(MessageType type, int flag)
        {
            string isValid = flag == 0 ? "0" : "1";
            stream.Write(Encoding.UTF8.GetBytes(((int)type).ToString() + ":" + isValid));
            Console.WriteLine("Write login is: " + isValid);
        }
	}
}

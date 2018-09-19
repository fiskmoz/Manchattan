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
        public void WriteClient(MessageType type, string sender, string receiver, string message)
        {
            string outgoing = ((int)type).ToString() + ":" + sender + ":" + receiver + ":" + message;
            stream.Write(Encoding.UTF8.GetBytes(outgoing));

        }
        public void WriteLoginACK(int flag)
        {
            string isValid = flag == 0 ? "0" : "1";
            stream.Write(Encoding.UTF8.GetBytes("3:" + isValid));
            Console.WriteLine("Write login is: " + isValid);
        }

		internal void WriteRegAck(bool flag)
		{
			string isValid = flag ? "1" : "0";
			stream.Write(Encoding.UTF8.GetBytes("1:" + isValid));
			Console.WriteLine("Sent regAck: " + isValid);
		}

        public void WriteOnlineList(string str)
        {
            stream.Write(Encoding.UTF8.GetBytes(str));
        }
	}
}

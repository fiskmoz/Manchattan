using System;
using System.Net.Security;
using System.Text;

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
            stream.Write(Encoding.UTF8.GetBytes(((int)MessageType.loginACK).ToString() + flag.ToString()));
            Console.WriteLine("Write login is: " + flag.ToString());
        }

		internal void WriteRegAck(bool flag)
		{
			string isValid = flag ? "1" : "0";
			stream.Write(Encoding.UTF8.GetBytes(((int)MessageType.registerACK).ToString() + isValid));
			Console.WriteLine("Sent regAck: " + isValid);
		}

        public void WriteOnlineList(string str)
        {
			try
			{
				stream.Write(Encoding.UTF8.GetBytes(str));
			}
			catch (Exception e)
			{
				Console.WriteLine();
				Console.WriteLine("Write OnlineList Exception:");
				Console.WriteLine(e.Message);
			}
        }
	}
}

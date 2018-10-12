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
        public void WriteLoginACK(int flag, string userName)
        {
            User user = server.userManager.FindUser(userName);
            if (user != null)
            {
                stream.Write(Encoding.UTF8.GetBytes(((int)MessageType.loginACK).ToString() + ":" + flag.ToString() + ":" + user.key));
            }
            else
            {
                stream.Write(Encoding.UTF8.GetBytes(((int)MessageType.loginACK).ToString() + ":" + flag.ToString() + ":error"));
            }
            Console.WriteLine("Write login is: " + flag.ToString());
        }

		internal void WriteRegAck(bool flag)
		{
			string isValid = flag ? "1" : "0";
			stream.Write(Encoding.UTF8.GetBytes(((int)MessageType.registerACK).ToString() + ":" + isValid));
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

        public void WriteFriendRequest(string sender, string receiver)
        {
            string outgoing = "7:" + sender + ":" + receiver + ":" + "Placeholder";
            stream.Write(Encoding.UTF8.GetBytes(outgoing));
            Console.WriteLine("\"" + sender + "\" sends friend request to \"" + receiver + "\"");
        }

        public void WriteFriendResponse(string sender, string receiver, int answer)
        {
            string outgoing = "8:" + sender + ":" + receiver + ":" + answer;
            stream.Write(Encoding.UTF8.GetBytes(outgoing));
            Console.Write("FriendResponse: \"" + sender + "\" answers \"" + receiver + "'s\"friend request with ");
            if (answer == 0) Console.WriteLine("Deny");
            else if (answer == 1) Console.WriteLine("Accept");

        }

        public void WriteOnlineListUpdate(string client, bool goingOffline)
        {
            string outgoing = "";
            if(goingOffline)
            {
                outgoing = "9:0:" + client;
            }
            else
            {
                outgoing = "9:1:" + client;
            }
            stream.Write(Encoding.UTF8.GetBytes(outgoing));
        }
	}
}

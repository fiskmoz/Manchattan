using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftEngChat.Model.SSLCommunication
{
	//A client we are connected to.
    class SSLClient
    {
        public User UserInfo { get; set; }
		public SSLListener listener;
		public SSLWriter writer;
		public SslStream stream;
		private SSLServer server;
		private Messagehandler messageHandler;
		internal bool isVerifiedUser;

        public SSLClient(SslStream stream, SSLServer connector)
        {
			isVerifiedUser = false;
			server = connector;
			this.stream = stream;
            UserInfo = new User("NamePH", "MailPH", "PassPH");

			listener = new SSLListener(stream);		//Listens to SSLStream
			writer = new SSLWriter(stream, server); //Writes into SSlStream
			messageHandler = new Messagehandler(UserInfo.UserName, server, client: this);	//Handles incomming messages.
			listener.IncommingMessage += messageHandler.HandleMessage;  //Client starts to listen for incomming messages.
		}

        public void setUserName (string text)
        {
            UserInfo.UserName = text;
        }
    }

}

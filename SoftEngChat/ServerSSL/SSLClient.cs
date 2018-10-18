using System.Net.Security;

namespace SoftEngChat.Model.SSLCommunication
{
    //A client we are connected to.
    class SSLClient
    {
        public string userName { set; get; }
        public string ipAddress { get; private set; }
		public SSLListener listener;
		public SSLWriter writer;
		public SslStream stream;
		private SSLServer server;
		private Messagehandler messageHandler;
		internal bool isVerifiedUser;
        public int sessionID;


		public SSLClient(SslStream stream, SSLServer connector, int incomingID, string ip)
        {
			isVerifiedUser = false;
			server = connector;
			this.stream = stream;
            this.sessionID = incomingID;
            ipAddress = ip;

            userName = null;

			listener = new SSLListener(stream);		//Listens to SSLStream
			writer = new SSLWriter(stream, server); //Writes into SSlStream
			messageHandler = new Messagehandler(userName, server, client: this);	//Handles incomming messages.
			listener.IncommingMessage += messageHandler.HandleMessage;  //Client starts to listen for incomming messages.
		}

		internal void Dispose()
		{
			if (stream != null)
			{
				stream.Dispose();
				stream = null;
			}
		}
	}

}

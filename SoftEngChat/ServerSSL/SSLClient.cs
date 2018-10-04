﻿using System;
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
		public List<string> info;
        public int sessionID;


		public SSLClient(SslStream stream, SSLServer connector, int incomingID)
        {
			isVerifiedUser = false;
			server = connector;
			this.stream = stream;
            this.sessionID = incomingID;

			info = new List<string>();
			info.Add("User");
			info.Add("Mail");
			info.Add("Pass");
			info.Add("firstname");
			info.Add("lastname");
			UserInfo = new User(info);

			listener = new SSLListener(stream);		//Listens to SSLStream
			writer = new SSLWriter(stream, server); //Writes into SSlStream
			messageHandler = new Messagehandler(UserInfo.userName, server, client: this);	//Handles incomming messages.
			listener.IncommingMessage += messageHandler.HandleMessage;  //Client starts to listen for incomming messages.
		}

        public void updateUserInfo(string username, string email, string password)
        {
            UserInfo.userName = username;
            UserInfo.mail = email;
            UserInfo.password = password;
        }


        public string getUserName()
        {
            return UserInfo.userName;
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

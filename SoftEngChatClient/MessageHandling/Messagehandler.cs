using System;
using System.Collections.Generic;

namespace SoftEngChatClient.Model
{
	internal class Messagehandler
    {
        public Messagehandler()
        {
        }

		//public delegate void EventHandler(Object sender, EventArgs eventArgs);
		public event EventHandler IncommingRegAck;
		public event EventHandler IncommingLoginAck;
		public event EventHandler IncommingClientMessage;
		public event EventHandler IncommingOnlineList;
        public event EventHandler IncommingFriendRequest;
        public event EventHandler IncommmingFriendResponse;
		public event EventHandler IncommingOfflineList;
		public event EventHandler IncommingUserStatus;
		public event EventHandler OutgoingP2P;
		public event EventHandler IncommingP2P;
		public event EventHandler DisconnectP2P;
		public event EventHandler FileRequest;
		public event EventHandler FileResponse;

		//Handles messages arriving at Client.
		//Eventhandler, Consumes IncommingMessage Events.
		internal void HandleIncommingMessage(object sender, EventArgs message)
        {

            string[] incomming = ParseMessage(((IncommingMessage)message).Message);
            switch (incomming[0])
            {
                case "1":
                    HandleRegistrationACK(incomming);
                    break;
                case "2":
                    HandleClientMessage(incomming);
                    break;
                case "4":
                    HandleLoginACK(incomming);
                    break;
				case "5":
					HandleP2Pdisconnect(incomming);
					break;

				case "6":
                    HandleUpdateOnlineList(incomming);
                    break;
                case "7":
                    HandleFriendRequest(incomming);
                    break;
                case "8":
                    HandleFriendResponse(incomming);
                    break;
				case "9":
					HandleUserOnlineStatus(incomming);
					break;
				case "11":
					HandleIncommmingP2P(incomming);
					break;
				case "12":
					HandleOutgoingP2P(incomming);
					break;
				case "13":
					HandleFileRequest(incomming);
					break;
            }
		}

		private void HandleFileRequest(string[] incomming)
		{
			FileRequest(this, new FileRequestArgs(incomming));
		}
		private void HandleFileResponse(string[] incomming)
		{
			FileResponse(this, new FileResponseArgs(incomming));
		}

		private void HandleP2Pdisconnect(string[] incomming)
		{
			DisconnectP2P(this, new P2PDisconnect(incomming));
		}

		private void HandleOutgoingP2P(string[] incomming)
		{
			OutgoingP2P(this, new P2POutgoingConnection(incomming));
		}

		private void HandleIncommmingP2P(string[] incomming)
		{
			IncommingP2P(this, new P2PIncommingConnection(incomming));
		}

		private void HandleRegistrationACK(string[] incomming)
		{
			IncommingRegAck(this, new RegAck(incomming[1] == "1"));
		}

		private void HandleClientMessage(string[] incomming)
		{
			IncommingClientMessage(this, new ClientMessage(incomming));
		}

		private void HandleLoginACK(string[] incomming)
		{
			IncommingLoginAck(this, new LoginAck(incomming[1] == "1", incomming[2]));
        }

		private void HandleUpdateOnlineList( string[] incomming)
		{
			List<string> userList = new List<string>();

			for(int i = 2; i < incomming.Length; i++)
				userList.Add(incomming[i]);

			if (incomming[1] == "1")
				IncommingOnlineList(this, new OnlineList(userList));
			else
				IncommingOfflineList(this, new OnlineList(userList));

		}

        private void HandleFriendRequest(string[] incomming)
        {
            IncommingFriendRequest(this, new ClientMessage(incomming));
        }

        private void HandleFriendResponse(string[] incomming)
        {
            IncommmingFriendResponse(this, new ClientMessage(incomming));
        }


        private void HandleUserOnlineStatus(string[] incomming)
		{
			IncommingUserStatus(this, new UserOnlineStatusUpdate(incomming[2], incomming[1] == "1"));
		}
		private string[] ParseMessage(string incomming)
        {
            string[] messageArray;

            messageArray = incomming.Split(':');

            return messageArray;
        }

		public void Subscribe(MessageHandling.StreamListener streamListener)
		{
			streamListener.IncommingMessage += new EventHandler(HandleIncommingMessage);
		}
    }
}